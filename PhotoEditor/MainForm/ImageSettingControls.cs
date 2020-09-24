using System;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class MainForm : Form
    {
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
    }
}
