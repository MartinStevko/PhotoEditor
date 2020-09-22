using System;
using System.Drawing;
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
        public static Log log = new Log();

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
    }

        /// <summary>
        /// Loads form and calculate size and location of responsive objects
        /// </summary>
        private void MainFormLoad(object sender, EventArgs e)
        {
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            toolboxPanel.Width = Width / 4;
            toolboxPanel.Location = new Point(Width - toolboxPanel.Width, 30);
            int newPreviewWidth = 3 * Width / 16;
            int newPreviewHeight = (Height - 30) / 5;
            Button[] buttons = { resetPreviewButton, redPreviewButton, greenPreviewButton, bluePreviewButton };
            for (int i = 0; i < 4; ++i)
            {
                buttons[i].Width = newPreviewWidth;
                buttons[i].Height = newPreviewHeight;
                buttons[i].Location = new Point(newPreviewWidth * i, Height - newPreviewHeight);
            }
            mainPictureBox.Width = Width - toolboxPanel.Width - 20;
            mainPictureBox.Height = Height - newPreviewHeight - 50;

            taskControl = new TaskControl(this);

            lutComboBox.Items.AddRange(LookUpTable.List());
            log.Add("Form loaded");
        }

        /// <summary>
        /// Resets all image task controls to its defaults
        /// Use only when loading new image
        /// </summary>
        private void ResetSettings()
        {
            saturationChanging = true;
            imageSet.saturation = 0;
            saturationTrackBar.Value = 0;
            saturationChanging = false;
            brightnessChanging = true;
            imageSet.brightness = 0;
            brightnessTrackBar.Value = 0;
            brightnessChanging = false;
            clarityChanging = true;
            imageSet.clarity = 0;
            clarityTrackBar.Value = 0;
            clarityChanging = false;

            saturationTrackBar.Enabled = true;
            brightnessTrackBar.Enabled = true;
            clarityTrackBar.Enabled = true;
            saturationNumericUpDown.Enabled = true;
            brightnessNumericUpDown.Enabled = true;
            clarityNumericUpDown.Enabled = true;
            invertColorButton.Enabled = true;
            colorButton.Enabled = true;
            graystyleButton.Enabled = true;
            horizontalFlipButton.Enabled = true;
            verticalFlipButton.Enabled = true;

            saveButton.Enabled = true;
            saveAsButton.Enabled = true;

            applyLutButton.Enabled = true;
            exportLutButton.Enabled = true;
            applyConfirmButton.Enabled = true;

            resetPreviewButton.Enabled = true;
            redPreviewButton.Enabled = true;
            greenPreviewButton.Enabled = true;
            bluePreviewButton.Enabled = true;
        }

        #endregion

        #region Window management

        /// <summary>
        /// Close button click event handler
        /// </summary>
        private void CloseButtonClick(object sender, EventArgs e)
        {
            log.Add("Leaving application");
            Application.Exit();
        }

        /// <summary>
        /// Minimize button click event handler
        /// </summary>
        private void MinimizeButtonClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            CloseAllPopUps(sender, e);
        }

        /// <summary>
        /// Closes all menu panels (main menu and its popups)
        /// </summary>
        private void CloseAllPopUps(object sender, EventArgs e)
        {
            filePanel.Visible = false;
            editPanel.Visible = false;
            helpPanel.Visible = false;
            openConfirmationPanel.Visible = false;
            lutPanel.Visible = false;
        }

        #endregion
    }
}
