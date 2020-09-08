using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class MainForm : Form
    {
        #region Form variables

        /// <summary>
        /// Color used for navbar, toolbar and inactive picture buttons
        /// </summary>
        private readonly Color toolGrey = Color.FromArgb(36, 36, 36);

        /// <summary>
        /// Color used behind main picture box and on active picture button
        /// </summary>
        private readonly Color pictureGrey = Color.FromArgb(42, 42, 42);

        /// <summary>
        /// Set of all displayed branches (RGB, R, G, B) of current image
        /// </summary>
        public ImageSet imageSet;

        /// <summary>
        /// Control poin for all running and scheduled tasks
        /// </summary>
        private TaskControl taskControl;

        /// <summary>
        /// PhotoEditor logger
        /// </summary>
        private Log log;

        private static Random random;

        #endregion

        #region Form initialization

        public MainForm()
        {
            InitializeComponent();
            imageSet = new ImageSet();
            log = new Log();
            random = new Random();
    }

        /// <summary>
        /// Loads form and calculate size and location of responsive objects
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            panel2.Width = Width / 4;
            panel2.Location = new Point(Width - panel2.Width, 30);
            int newPreviewWidth = 3 * Width / 16;
            int newPreviewHeight = (Height - 30) / 5;
            Button[] buttons = { button3, button4, button5, button6 };
            for (int i = 0; i < 4; ++i)
            {
                buttons[i].Width = newPreviewWidth;
                buttons[i].Height = newPreviewHeight;
                buttons[i].Location = new Point(newPreviewWidth * i, Height - newPreviewHeight);
            }
            pictureBox2.Width = Width - panel2.Width - 20;
            pictureBox2.Height = Height - newPreviewHeight - 50;

            taskControl = new TaskControl(this);

            comboBox3.Items.AddRange(LookUpTable.List());
            log.Add("Form loaded");
        }

        private void SetNumericUpDownValue(NumericUpDown control, decimal value)
        {
            if (control == null) throw new ArgumentNullException(nameof(control));
            var currentValueField = control.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
            if (currentValueField != null)
            {
                currentValueField.SetValue(control, value);
                control.Text = value.ToString();
            }
        }

        private void ResetSettings()
        {
            imageSet.saturation = 0;
            SetNumericUpDownValue(numericUpDown1, 0);
            imageSet.brightness = 0;
            SetNumericUpDownValue(numericUpDown2, 0);
            imageSet.clarity = 0;
            SetNumericUpDownValue(numericUpDown3, 0);

            trackBar1.Enabled = true;
            trackBar2.Enabled = true;
            trackBar3.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            button23.Enabled = true;
            button24.Enabled = true;
            button25.Enabled = true;
            button26.Enabled = true;
            button27.Enabled = true;

            button11.Enabled = true;
            button12.Enabled = true;

            button14.Enabled = true;
            button15.Enabled = true;
            button28.Enabled = true;
        }

        #endregion

        #region Window management

        /// <summary>
        /// Close button click event handler
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            log.Add("Leaving application");
            Application.Exit();
        }

        /// <summary>
        /// Minimize button click event handler
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region File menu events

        /// <summary>
        /// Show app menu under 'File' - Open new, Save, Save as..., Multiple apply
        /// </summary>
        private void button7_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Visible = !panel3.Visible;
        }

        /// <summary>
        /// File -> Open menu button - promt warning if previous image is not saved or open a new image
        /// </summary>
        private void button10_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                panel6.Visible = true;
            }
            else
            {
                panel3.Visible = false;
                OpenNewImage();
            }
        }

        /// <summary>
        /// File -> Open -> Yes, I am sure button - open new image
        /// </summary>
        private void button22_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            panel3.Visible = false;
            OpenNewImage();
        }

        /// <summary>
        /// File -> Open -> No, take me back button - hide newly visible components
        /// </summary>
        private void button18_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            panel3.Visible = false;
        }

        /// <summary>
        /// File -> Save menu button - saves changes made to the image with origin name
        /// </summary>
        private void button11_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            string file = imageSet.filename;
            pictureBox2.Image.Save(file);
            log.Add("File saved");
        }

        /// <summary>
        /// File -> Save as... menu button - saves chnages made to the object with custom name
        /// </summary>
        private void button12_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "All Images|*.jpg;*.bmp;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(dialog.FileName);
            }
            log.Add("File saved as " + dialog.FileName);
        }

        /// <summary>
        /// File -> Import LUT menu button - imports .CUBE file as look-up table
        /// </summary>
        private void button13_Click(object sender, EventArgs e)
        {
            // TODO: Import LUT
            panel3.Visible = false;
        }

        #endregion

        #region Edit menu events

        /// <summary>
        /// Show app menu under 'Edit' - Undo, Redo, Export LUT, Settings
        /// </summary>
        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel5.Visible = false;
            panel4.Visible = !panel4.Visible;
        }

        /// <summary>
        /// Edit -> Undo menu button - undo last action
        /// </summary>
        private void button17_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;

            if (taskControl.tasks.Any())
            {
                taskControl.removed.Push(taskControl.tasks.Pop());
            }
            RestorePoint restorePoint = taskControl.undoQueue.RemoveLast();
            if (restorePoint != null)
            {
                RestorePoint old = new RestorePoint(
                    imageSet.imageMode,
                    restorePoint.taskType,
                    imageSet.image.Clone(imageSet.rectangle, imageSet.image.PixelFormat),
                    imageSet.thumb.Clone(imageSet.thumbRectangle, imageSet.thumb.PixelFormat),
                    imageSet.saturation,
                    imageSet.brightness,
                    imageSet.clarity
                );
                taskControl.redoQueue.Add(old);

                ApplyRestorePoint(restorePoint);
                log.Add("Last action was un-done");
            }
            else
            {
                log.Add("Action can not be un-done, there is no actions left in the queue");
            }
        }

        /// <summary>
        /// Edit -> Redo menu button - redo last action if it was undone
        /// </summary>
        private void button16_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;

            if (taskControl.removed.Any())
            {
                taskControl.tasks.Push(taskControl.removed.Pop());
            }
            RestorePoint restorePoint = taskControl.redoQueue.RemoveLast();
            if (restorePoint != null)
            {
                RestorePoint old = new RestorePoint(
                    imageSet.imageMode,
                    restorePoint.taskType,
                    imageSet.image.Clone(imageSet.rectangle, imageSet.image.PixelFormat),
                    imageSet.thumb.Clone(imageSet.thumbRectangle, imageSet.thumb.PixelFormat),
                    imageSet.saturation,
                    imageSet.brightness,
                    imageSet.clarity
                );
                taskControl.undoQueue.Add(old);

                ApplyRestorePoint(restorePoint);
                log.Add("Last un-done action was re-done");
            }
            else
            {
                log.Add("Action cannot be re-done, there is no other actions in the queue");
            }
        }

        /// <summary>
        /// Determines whether Undo and Redo buttons should be enabled
        /// Use by adding to the end of "RedrawMainImage" method
        /// </summary>
        private void ActionHandlersActive()
        {
            if (taskControl.undoQueue.IsEmpty())
            {
                button17.Enabled = false;
            }
            else
            {
                button17.Enabled = true;
            }
            if (taskControl.redoQueue.IsEmpty())
            {
                button16.Enabled = false;
            }
            else
            {
                button16.Enabled = true;
            }
        }

        /// <summary>
        /// Edit -> Export LUT menu button - exports LUT file from changes made onto currently opened image
        /// </summary>
        private void button15_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(ExportLUT);
            thr.Start();
            panel4.Visible = false;
        }

        /// <summary>
        /// Exports look-up table file
        /// </summary>
        private void ExportLUT()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string filename = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());
            LookUpTable.Write(filename + ".CUBE", taskControl.tasks);
            log.Add("LUT file exported");
        }

        /// <summary>
        /// Edit -> Apply LUT file menu button - prompts LUT file choice
        /// </summary>
        private void button14_Click(object sender, EventArgs e)
        {
            panel7.Visible = panel7.Visible == false;
        }

        /// <summary>
        /// Edit -> Apply LUT file -> Apply menu button - applies choosen LUT file
        /// </summary>
        private void button28_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                ImageTask task = new ApplyLUT(
                    ImageModification.ApplyLUT,
                    imageSet,
                    comboBox3.SelectedItem.ToString()
                );
                taskControl.Add(task);
                taskControl.CheckAndProcess();
                log.Add("LUT file applied");
            }
            panel7.Visible = false;
            panel4.Visible = false;
        }

        #endregion

        #region Help menu events

        /// <summary>
        /// Show app menu under 'Help' - User manual, Documentation, Report issue
        /// </summary>
        private void button9_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = !panel5.Visible;
        }

        /// <summary>
        /// Help -> User manual menu button - opens user manual in user default web browser
        /// </summary>
        private void button21_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            string targetURL = @"https://github.com/MartinStevko/PhotoEditor/wiki/User-manual";
            System.Diagnostics.Process.Start(targetURL);
            log.Add("User manual opened");
        }

        /// <summary>
        /// Help -> Documentation menu button - opens program documentation in user default web browser
        /// </summary>
        private void button20_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            string targetURL = @"https://github.com/MartinStevko/PhotoEditor/wiki/Documentation";
            System.Diagnostics.Process.Start(targetURL);
            log.Add("Program documentation opened");
        }

        /// <summary>
        /// Help -> Report issue menu button - opens report issue website in user default web browser
        /// </summary>
        private void button19_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            string targetURL = @"https://github.com/MartinStevko/PhotoEditor/issues/new/choose";
            System.Diagnostics.Process.Start(targetURL);
            log.Add("Report issue form opened");
        }

        #endregion

        #region Image load control

        private void OpenNewImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Images|*.jpg;*.bmp;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ResetSettings();
                string filename = dialog.FileName;
                Thread thr = new Thread(LoadNewImage);
                thr.Start(filename);
            }
            log.Add("Image opened");
        }

        private void LoadNewImage(object data)
        {
            string filename = data.ToString();
            imageSet.Load(
                filename,
                pictureBox2.Width,
                pictureBox2.Height,
                button3.Width - 26,
                button3.Height - 10
            );
            RedrawImageSet();
        }

        #endregion

        #region Image view controls

        /// <summary>
        /// Changes main image for some other miniature
        /// </summary>
        /// <param name="button">Miniature which should be shown</param>
        private void ChangePreview()
        {
            button3.BackColor = toolGrey;
            button4.BackColor = toolGrey;
            button5.BackColor = toolGrey;
            button6.BackColor = toolGrey;

            switch (imageSet.imageMode)
            {
                case ImageMode.Full:
                    button3.BackColor = pictureGrey;
                    break;
                case ImageMode.Red:
                    button4.BackColor = pictureGrey;
                    break;
                case ImageMode.Green:
                    button5.BackColor = pictureGrey;
                    break;
                case ImageMode.Blue:
                    button6.BackColor = pictureGrey;
                    break;
            }

            RedrawMainImage();
        }

        public void RedrawMainImage()
        {
            switch (imageSet.imageMode)
            {
                case ImageMode.Red:
                    pictureBox2.Image = imageSet.ShowWithFilter(ColorFilters.RedFilter);
                    break;
                case ImageMode.Green:
                    pictureBox2.Image = imageSet.ShowWithFilter(ColorFilters.GreenFilter);
                    break;
                case ImageMode.Blue:
                    pictureBox2.Image = imageSet.ShowWithFilter(ColorFilters.BlueFilter);
                    break;
                default:
                    pictureBox2.Image = imageSet.image;
                    break;
            }
        }

        public void RedrawImageSet()
        {
            try
            {
                RedrawMainImage();

                button3.BackgroundImage = imageSet.thumb;
                button4.BackgroundImage = imageSet.thumbRed;
                button5.BackgroundImage = imageSet.thumbGreen;
                button6.BackgroundImage = imageSet.thumbBlue;
            }
            catch (InvalidOperationException)
            {
                Thread.Sleep(100);
                RedrawImageSet();
            }
        }

        private void ApplyRestorePoint(RestorePoint restorePoint)
        {
            imageSet.image = restorePoint.image;
            imageSet.thumb = restorePoint.thumb;

            imageSet.saturation = restorePoint.saturation;
            imageSet.brightness = restorePoint.brightness;
            imageSet.clarity = restorePoint.clarity;

            imageSet.thumbRed = imageSet.CopyThumbnailWithFilter(ColorFilters.RedFilter);
            imageSet.thumbGreen = imageSet.CopyThumbnailWithFilter(ColorFilters.GreenFilter);
            imageSet.thumbBlue = imageSet.CopyThumbnailWithFilter(ColorFilters.BlueFilter);

            SetNumericUpDownValue(numericUpDown1, restorePoint.saturation);
            trackBar1.Value = restorePoint.saturation;
            SetNumericUpDownValue(numericUpDown2, restorePoint.brightness);
            trackBar2.Value = restorePoint.brightness;
            SetNumericUpDownValue(numericUpDown3, restorePoint.clarity);
            trackBar3.Value = restorePoint.clarity;

            RedrawImageSet();
        }

        #region Preview selection

        /// <summary>
        /// Maximize miniature with all colors
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            imageSet.imageMode = ImageMode.Full;
            ChangePreview();
        }

        /// <summary>
        /// Maximize miniature with red color
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            imageSet.imageMode = ImageMode.Red;
            ChangePreview();
        }

        /// <summary>
        /// Maximize miniature with green color
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            imageSet.imageMode = ImageMode.Green;
            ChangePreview();
        }

        /// <summary>
        /// Maximize miniature with blue color
        /// </summary>
        private void button6_Click(object sender, EventArgs e)
        {
            imageSet.imageMode = ImageMode.Blue;
            ChangePreview();
        }

        #endregion

        #endregion

        #region Image setting controls

        #region Control values synchronization

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericUpDown1.Value;
            trackBar1.Value = value;
            OnSyncValues(ImageModification.Saturation, value);
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            int value = trackBar1.Value;
            SetNumericUpDownValue(numericUpDown1, value);
            OnSyncValues(ImageModification.Saturation, value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericUpDown2.Value;
            trackBar2.Value = value;
            OnSyncValues(ImageModification.Brightness, value);
        }

        private void trackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            int value = trackBar2.Value;
            SetNumericUpDownValue(numericUpDown2, value);
            OnSyncValues(ImageModification.Brightness, value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericUpDown3.Value;
            trackBar3.Value = value;
            OnSyncValues(ImageModification.Clarity, value);
        }

        private void trackBar3_MouseUp(object sender, MouseEventArgs e)
        {
            int value = trackBar3.Value;
            SetNumericUpDownValue(numericUpDown3, value);
            OnSyncValues(ImageModification.Clarity, value);
        }

        #endregion

        /// <summary>
        /// Processes adjustment of saturation, brightness and clarity
        /// </summary>
        /// <param name="mod">adjustment type</param>
        /// <param name="newValue">new value from numeric field</param>
        private void OnSyncValues(ImageModification mod, int newValue)
        {
            ColorEdit task;
            switch (mod)
            {
                case ImageModification.Saturation:
                    task = new SaturationEdit(ImageModification.Saturation, imageSet, newValue);
                    log.Add("Image saturation modified");
                    break;
                case ImageModification.Brightness:
                    task = new BrightnessEdit(ImageModification.Brightness, imageSet, newValue);
                    log.Add("Image brightness modified");
                    break;
                case ImageModification.Clarity:
                    task = new ClarityEdit(ImageModification.Clarity, imageSet, newValue);
                    log.Add("Image clarity modified");
                    break;
                default:
                    task = null;
                    break;
            }
            taskControl.Add(task);
            taskControl.CheckAndProcess();
        }

        /// <summary>
        /// Invert color
        /// </summary>
        private void button23_Click(object sender, EventArgs e)
        {
            ImageTask task = new ColorInvert(ImageModification.InvertColor, imageSet);
            taskControl.Add(task);
            taskControl.CheckAndProcess();
            log.Add("Image color inverted");
        }

        /// <summary>
        /// Change two colors
        /// </summary>
        private void button24_Click(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedItem != null) && (comboBox2.SelectedItem != null)) 
            {
                ImageTask task = new ColorChange(
                    ImageModification.ColorRotate,
                    imageSet,
                    comboBox1.SelectedItem.ToString(),
                    comboBox2.SelectedItem.ToString()
                );
                taskControl.Add(task);
                taskControl.CheckAndProcess();
                log.Add("Image colors swaped (" + comboBox1.SelectedItem.ToString() + ", " + comboBox2.SelectedItem.ToString() + ")");
            }
        }

        /// <summary>
        /// Apply gray style
        /// </summary>
        private void button25_Click(object sender, EventArgs e)
        {
            ImageTask task = new ApplyGreyStyle(ImageModification.ApplyGreyStyle, imageSet);
            taskControl.Add(task);
            taskControl.CheckAndProcess();
            log.Add("Image converted to graystyle");
        }

        /// <summary>
        /// Flip image over axe X
        /// </summary>
        private void button26_Click(object sender, EventArgs e)
        {
            ImageTask task = new FlipHorizontal(ImageModification.FlipHorizontally, imageSet);
            taskControl.Add(task);
            taskControl.CheckAndProcess();
            log.Add("Image flipped vertically");
        }

        /// <summary>
        /// Flip image over axe Y
        /// </summary>
        private void button27_Click(object sender, EventArgs e)
        {
            ImageTask task = new FlipVertical(ImageModification.FlipVertically, imageSet);
            taskControl.Add(task);
            taskControl.CheckAndProcess();
            log.Add("Image flipped horizontally");
        }

        #endregion
    }
}
