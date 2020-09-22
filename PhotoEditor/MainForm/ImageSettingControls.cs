using System;
using System.Reflection;
using System.Windows.Forms;
using PhotoEditor.Tasks;

namespace PhotoEditor
{
    public partial class MainForm : Form
    {
        private bool saturationChanging = false;
        private bool brightnessChanging = false;
        private bool clarityChanging = false;

        #region Control values synchronization

        /// <summary>
        /// Synchronizes appropriate track bar value on numeric up/down value change
        /// </summary>
        private void SaturationUpDownValueChanged(object sender, EventArgs e)
        {
            if (!saturationChanging)
            {
                int value = (int)saturationNumericUpDown.Value;
                saturationTrackBar.Value = value;
            }
        }

        /// <summary>
        /// Synchronizes appropriate numeric up/down value on track bar value change
        /// </summary>
        private void SaturationTrackBarMouseUp(object sender, MouseEventArgs e)
        {
            if (!saturationChanging)
            {
                saturationChanging = true;
                int value = saturationTrackBar.Value;
                saturationNumericUpDown.Value = value;
                OnSyncValues(ImageModification.Saturation, value);
                saturationChanging = false;
            }
        }

        /// <summary>
        /// Synchronizes appropriate track bar value on numeric up/down value change
        /// </summary>
        private void BrightnessUpDownValueChanged(object sender, EventArgs e)
        {
            if (!brightnessChanging)
            {
                int value = (int)brightnessNumericUpDown.Value;
                brightnessTrackBar.Value = value;
            }
        }

        /// <summary>
        /// Synchronizes appropriate numeric up/down value on track bar value change
        /// </summary>
        private void BrightnessTrackBarMouseUp(object sender, MouseEventArgs e)
        {
            if (!brightnessChanging)
            {
                brightnessChanging = true;
                int value = brightnessTrackBar.Value;
                brightnessNumericUpDown.Value = value;
                OnSyncValues(ImageModification.Brightness, value);
                brightnessChanging = false;
            }
        }

        /// <summary>
        /// Synchronizes appropriate track bar value on numeric up/down value change
        /// </summary>
        private void ClarityUpDownValueChanged(object sender, EventArgs e)
        {
            if (!clarityChanging)
            {
                int value = (int)clarityNumericUpDown.Value;
                clarityTrackBar.Value = value;
            }
        }

        /// <summary>
        /// Synchronizes appropriate numeric up/down value on track bar value change
        /// </summary>
        private void ClarityTrackBarMouseUp(object sender, MouseEventArgs e)
        {
            if (!clarityChanging)
            {
                clarityChanging = true;
                int value = clarityTrackBar.Value;
                clarityNumericUpDown.Value = value;
                OnSyncValues(ImageModification.Clarity, value);
                clarityChanging = false;
            }
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
        private void InvertColorButtonClick(object sender, EventArgs e)
        {
            CloseAllPopUps(sender, e);
            ImageTask task = new ColorInvert(ImageModification.InvertColor, imageSet);
            taskControl.Add(task);
            taskControl.CheckAndProcess();
            log.Add("Image color inverted");
        }

        /// <summary>
        /// Change two colors
        /// </summary>
        private void SwapColorButtonClick(object sender, EventArgs e)
        {
            CloseAllPopUps(sender, e);
            if ((firstColorComboBox.SelectedItem != null) && (secondColorComboBox.SelectedItem != null))
            {
                ImageTask task = new ColorChange(
                    ImageModification.ColorRotate,
                    imageSet,
                    firstColorComboBox.SelectedItem.ToString(),
                    secondColorComboBox.SelectedItem.ToString()
                );
                taskControl.Add(task);
                taskControl.CheckAndProcess();
                log.Add("Image colors swaped (" + firstColorComboBox.SelectedItem.ToString() + ", " + secondColorComboBox.SelectedItem.ToString() + ")");
            }
        }

        /// <summary>
        /// Apply gray style
        /// </summary>
        private void GrayStyleButtonClick(object sender, EventArgs e)
        {
            CloseAllPopUps(sender, e);
            ImageTask task = new ApplyGreyStyle(ImageModification.ApplyGreyStyle, imageSet);
            taskControl.Add(task);
            taskControl.CheckAndProcess();
            log.Add("Image converted to graystyle");
        }

        /// <summary>
        /// Flip image over axe X
        /// </summary>
        private void HorizontalFlipButtonClick(object sender, EventArgs e)
        {
            CloseAllPopUps(sender, e);
            ImageTask task = new FlipHorizontal(ImageModification.FlipHorizontally, imageSet);
            taskControl.Add(task);
            taskControl.CheckAndProcess();
            log.Add("Image flipped vertically");
        }

        /// <summary>
        /// Flip image over axe Y
        /// </summary>
        private void VerticalFlipButtonClick(object sender, EventArgs e)
        {
            CloseAllPopUps(sender, e);
            ImageTask task = new FlipVertical(ImageModification.FlipVertically, imageSet);
            taskControl.Add(task);
            taskControl.CheckAndProcess();
            log.Add("Image flipped horizontally");
        }
    }
}
