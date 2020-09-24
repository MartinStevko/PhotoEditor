using System;
using System.Drawing;
using System.Reflection;
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
    }
}
