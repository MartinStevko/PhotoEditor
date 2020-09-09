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
    }

    /// <summary>
    /// Queue of restore points implementation
    /// </summary>
    class Queue
    {
        /// <summary>
        /// Index of first free cell in restore point array
        /// </summary>
        private int free;

        /// <summary>
        /// Restore point array size
        /// </summary>
        private int length;

        /// <summary>
        /// Restore point array
        /// </summary>
        private RestorePoint[] data;

        /// <summary>
        /// Initialization of queue to its defaults
        /// </summary>
        public Queue()
        {
            free = 0;
            length = 100;
            data = new RestorePoint[length];
        }

        /// <summary>
        /// Adds restore point to free cell to restore point array
        /// </summary>
        /// <param name="restorePoint">Restore point to add</param>
        public void Add(RestorePoint restorePoint)
        {
            data[free] = restorePoint;
            free = (free + 1) % length;
        }

        /// <summary>
        /// Removes and returns last restore point from queue
        /// </summary>
        /// <returns>Last added restore point from queue</returns>
        public RestorePoint RemoveLast()
        {
            if (free == 0)
            {
                free = length - 1;
            }
            else
            {
                --free;
            }

            RestorePoint response = data[free];
            data[free] = null;
            return response;
        }

        /// <summary>
        /// Removes each restore point from queue
        /// </summary>
        public void Flush()
        {
            for (int i = 0; i < length; ++i)
            {
                data[i] = null;
            }
        }

        /// <summary>
        /// Determines whether queue contains valid data
        /// </summary>
        /// <returns>Boolean whether queue is empty</returns>
        public bool IsEmpty()
        {
            if (free == 0)
            {
                if (data[length - 1] == null)
                {
                    return true;
                }
            }
            else
            {
                if (data[free - 1] == null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
