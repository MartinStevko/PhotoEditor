using System.Drawing;

namespace PhotoEditor
{
    /// <summary>
    /// Restore point for undo/redo queue
    /// </summary>
    class RestorePoint
    {
        /// <summary>
        /// Image mode on restore point creation
        /// </summary>
        public ImageMode mode;
        
        /// <summary>
        /// Image modification type
        /// </summary>
        public ImageModification taskType;

        /// <summary>
        /// Deep copy of main image on restore point creation
        /// </summary>
        public Bitmap image;

        /// <summary>
        /// Deep copy of thumbnail image on restore point creation
        /// </summary>
        public Bitmap thumb;

        /// <summary>
        /// Saturation level on restore point creation
        /// </summary>
        public int saturation;

        /// <summary>
        /// Brightness level on restore point creation
        /// </summary>
        public int brightness;

        /// <summary>
        /// Clarity level on restore point creation
        /// </summary>
        public int clarity;

        /// <summary>
        /// Create restore point and initialize values from current image set
        /// </summary>
        /// <param name="mode">Image view mode</param>
        /// <param name="taskType">Task type</param>
        /// <param name="image">Main image</param>
        /// <param name="thumb">Thumbnail image</param>
        /// <param name="saturation">Saturation level</param>
        /// <param name="brightness">Brightness level</param>
        /// <param name="clarity">Clarity level</param>
        public RestorePoint(
            ImageMode mode,
            ImageModification taskType,
            Bitmap image,
            Bitmap thumb,
            int saturation,
            int brightness,
            int clarity
        )
        {
            this.mode = mode;
            this.taskType = taskType;
            this.image = image;
            this.thumb = thumb;
            this.saturation = saturation;
            this.brightness = brightness;
            this.clarity = clarity;
        }

        /// <summary>
        /// Converts restore point to string description of task type
        /// </summary>
        /// <returns>String description</returns>
        public override string ToString()
        {
            string s;
            switch (taskType)
            {
                case ImageModification.ApplyGreyStyle:
                    s = "Graystyle applied";
                    break;
                case ImageModification.ApplyLUT:
                    s = "LUT file applied";
                    break;
                case ImageModification.Brightness:
                    s = "Brightness edit - new value: " + brightness.ToString();
                    break;
                case ImageModification.Clarity:
                    s = "Clarity edit - new value: " + clarity.ToString();
                    break;
                case ImageModification.Saturation:
                    s = "Saturation edit - new value: " + saturation.ToString();
                    break;
                case ImageModification.ColorRotate:
                    s = "Color rotated";
                    break;
                case ImageModification.FlipHorizontally:
                    s = "Flipped horizontaly";
                    break;
                case ImageModification.FlipVertically:
                    s = "Flipped verticaly";
                    break;
                case ImageModification.InvertColor:
                    s = "Color inverted";
                    break;
                default:
                    s = "Unknown task type";
                    break;
            }
            return s;
        }
    }
}
