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
                resetPreviewButton.BackColor = toolGrey;
                redPreviewButton.BackColor = toolGrey;
                greenPreviewButton.BackColor = toolGrey;
                bluePreviewButton.BackColor = toolGrey;

                switch (imageSet.imageMode)
                {
                    case ImageMode.Full:
                        resetPreviewButton.BackColor = pictureGrey;
                        break;
                    case ImageMode.Red:
                        redPreviewButton.BackColor = pictureGrey;
                        break;
                    case ImageMode.Green:
                        greenPreviewButton.BackColor = pictureGrey;
                        break;
                    case ImageMode.Blue:
                        bluePreviewButton.BackColor = pictureGrey;
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
                    mainPictureBox.Image = imageSet.ShowWithFilter(ColorFilters.RedFilter);
                    break;
                case ImageMode.Green:
                    mainPictureBox.Image = imageSet.ShowWithFilter(ColorFilters.GreenFilter);
                    break;
                case ImageMode.Blue:
                    mainPictureBox.Image = imageSet.ShowWithFilter(ColorFilters.BlueFilter);
                    break;
                default:
                    mainPictureBox.Image = imageSet.image;
                    break;
            }
            ActionHandlersActive();
        }

        /// <summary>
        /// Redrwas whole image set (main image and all thumbnails)
        /// </summary>
        public void RedrawImageSet()
        {
            try
            {
                RedrawMainImage();

                resetPreviewButton.BackgroundImage = imageSet.thumb;
                redPreviewButton.BackgroundImage = imageSet.thumbRed;
                greenPreviewButton.BackgroundImage = imageSet.thumbGreen;
                bluePreviewButton.BackgroundImage = imageSet.thumbBlue;
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

            saturationChanging = true;
            brightnessChanging = true;
            clarityChanging = true;
            saturationTrackBar.Value = restorePoint.saturation;
            brightnessTrackBar.Value = restorePoint.brightness;
            clarityTrackBar.Value = restorePoint.clarity;
            saturationChanging = false;
            brightnessChanging = false;
            clarityChanging = false;

            RedrawImageSet();
        }

        #region Preview selection

        /// <summary>
        /// Maximize miniature with all colors
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            CloseAllPopUps(sender, e);
            imageSet.imageMode = ImageMode.Full;
            ChangePreview();
        }

        /// <summary>
        /// Maximize miniature with red color
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            CloseAllPopUps(sender, e);
            imageSet.imageMode = ImageMode.Red;
            ChangePreview();
        }

        /// <summary>
        /// Maximize miniature with green color
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            CloseAllPopUps(sender, e);
            imageSet.imageMode = ImageMode.Green;
            ChangePreview();
        }

        /// <summary>
        /// Maximize miniature with blue color
        /// </summary>
        private void button6_Click(object sender, EventArgs e)
        {
            CloseAllPopUps(sender, e);
            imageSet.imageMode = ImageMode.Blue;
            ChangePreview();
        }

        #endregion
    }
}
