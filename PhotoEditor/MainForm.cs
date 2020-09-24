using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace PhotoEditor
{
    /// <summary>
    /// Main form - graphic editor interface
    /// </summary>
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

        /// <summary>
        /// Random generator
        /// </summary>
        private static Random random;

        #endregion

        #region Form initialization

        /// <summary>
        /// Initialize form, image set, log file and rendom generator to its defaults
        /// </summary>
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

        /// <summary>
        /// Sets numeric up/down value without raising on change event
        /// </summary>
        /// <param name="control">Pointer to numeric up/down</param>
        /// <param name="value">Value to be set</param>
        private void SetNumericUpDownValue(NumericUpDown control, decimal value)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            var currentValueField = control.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
            if (currentValueField != null)
            {
                currentValueField.SetValue(control, value);
                control.Text = value.ToString();
            }
        }

        /// <summary>
        /// Resets all image task controls to its defaults
        /// Use only when loading new image
        /// </summary>
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

        /// <summary>
        /// Closes all menu panels (main menu and its popups)
        /// </summary>
        private void CloseAllPopUps()
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
        }

        /// <summary>
        /// Closes all menu panels (main menu and its popups)
        /// </summary>
        private void CloseAllPopUps(object sender, EventArgs e)
        {
            CloseAllPopUps();
        }

        /// <summary>
        /// Closes all menu panels (main menu and its popups)
        /// </summary>
        private void CloseAllPopUps(object sender, MouseEventArgs e)
        {
            CloseAllPopUps();
        }

        #endregion

        #region Image setting controls

        #region Control values synchronization

        /// <summary>
        /// Synchronizes appropriate track bar value on numeric up/down value change
        /// </summary>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericUpDown1.Value;
            trackBar1.Value = value;
            OnSyncValues(ImageModification.Saturation, value);
        }

        /// <summary>
        /// Synchronizes appropriate numeric up/down value on track bar value change
        /// </summary>
        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            int value = trackBar1.Value;
            SetNumericUpDownValue(numericUpDown1, value);
            OnSyncValues(ImageModification.Saturation, value);
        }

        /// <summary>
        /// Synchronizes appropriate track bar value on numeric up/down value change
        /// </summary>
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericUpDown2.Value;
            trackBar2.Value = value;
            OnSyncValues(ImageModification.Brightness, value);
        }

        /// <summary>
        /// Synchronizes appropriate numeric up/down value on track bar value change
        /// </summary>
        private void trackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            int value = trackBar2.Value;
            SetNumericUpDownValue(numericUpDown2, value);
            OnSyncValues(ImageModification.Brightness, value);
        }

        /// <summary>
        /// Synchronizes appropriate track bar value on numeric up/down value change
        /// </summary>
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericUpDown3.Value;
            trackBar3.Value = value;
            OnSyncValues(ImageModification.Clarity, value);
        }

        /// <summary>
        /// Synchronizes appropriate numeric up/down value on track bar value change
        /// </summary>
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
