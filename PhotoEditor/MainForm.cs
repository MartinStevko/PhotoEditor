using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
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

        #endregion

        #region Form initialization

        public MainForm()
        {
            InitializeComponent();
            imageSet = new ImageSet();
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
        }

        #endregion

        #region Window management

        /// <summary>
        /// Close button click event handler
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
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
            // TODO: Save
            // TODO: Disable when nothing is opened
            panel3.Visible = false;
        }

        /// <summary>
        /// File -> Save as... menu button - saves chnages made to the object with custom name
        /// </summary>
        private void button12_Click(object sender, EventArgs e)
        {
            // TODO: Save as...
            // TODO: Disable when nothing is opened
            panel3.Visible = false;
        }

        /// <summary>
        /// File -> Multiple apply menu button - applies chages setted in settings to more files at once
        /// </summary>
        private void button13_Click(object sender, EventArgs e)
        {
            // TODO: Multiple apply
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
            // TODO: Undo
            // TODO: Disable when no action precede
            panel4.Visible = false;
        }

        /// <summary>
        /// Edit -> Redo menu button - redo last action if it was undone
        /// </summary>
        private void button16_Click(object sender, EventArgs e)
        {
            // TODO: Redo
            // TODO: Disable when no action follows
            panel4.Visible = false;
        }

        /// <summary>
        /// Edit -> Export LUT menu button - exports LUT file from changes made onto currently opened image
        /// </summary>
        private void button15_Click(object sender, EventArgs e)
        {
            // TODO: Export LUT
            panel4.Visible = false;
        }

        /// <summary>
        /// Edit -> Settings menu button - opens app settings
        /// </summary>
        private void button14_Click(object sender, EventArgs e)
        {
            // TODO: Settings
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
        }

        /// <summary>
        /// Help -> Documentation menu button - opens program documentation in user default web browser
        /// </summary>
        private void button20_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            string targetURL = @"https://github.com/MartinStevko/PhotoEditor/wiki/Documentation";
            System.Diagnostics.Process.Start(targetURL);
        }

        /// <summary>
        /// Help -> Report issue menu button - opens report issue website in user default web browser
        /// </summary>
        private void button19_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            string targetURL = @"https://github.com/MartinStevko/PhotoEditor/issues/new/choose";
            System.Diagnostics.Process.Start(targetURL);
        }


        #endregion

        #region Image load control

        private void OpenNewImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Images|*.jpg;*.bmp;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.FileName;
                Thread thr = new Thread(LoadNewImage);
                thr.Start(filename);
            }
            ResetSettings();
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
            OnSyncValues(ImageModification.Saturation, value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericUpDown2.Value;
            OnSyncValues(ImageModification.Brightness, value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericUpDown3.Value;
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
                    task = new SaturationEdit(newValue);
                    break;
                case ImageModification.Brightness:
                    task = new BrightnessEdit(newValue);
                    break;
                case ImageModification.Clarity:
                    task = new ClarityEdit(newValue);
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
            ImageTask task = new ColorInvert();
            taskControl.Add(task);
            taskControl.CheckAndProcess();
        }

        #endregion
    }
}
