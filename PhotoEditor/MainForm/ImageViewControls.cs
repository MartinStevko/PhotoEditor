using System;
using System.Threading;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Changes main image for some other miniature
        /// </summary>
        private void ChangePreview()
        {
            if (imageSet != null)
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
        }

        /// <summary>
        /// Redraws main image with currently active color filter
        /// </summary>
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

        /// <summary>
        /// Redrwas whole image set (main image and all thumbnails)
        /// </summary>
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

        /// <summary>
        /// Applies image restore point from undo/redo queue and 
        /// propagates to thumbnails also
        /// </summary>
        /// <param name="restorePoint">Restore point to be applied</param>
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
    }
}
