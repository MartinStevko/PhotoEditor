using System.Drawing;

namespace PhotoEditor
{
    class RestorePoint
    {
        public ImageMode mode;
        
        public ImageModification taskType;

        public Bitmap image;

        public Bitmap thumb;

        public int saturation;

        public int brightness;

        public int clarity;

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

    class Queue
    {
        private int free;

        private int length;

        private RestorePoint[] data;

        public Queue()
        {
            free = 0;
            length = 10;
            data = new RestorePoint[length];
        }

        public void Add(RestorePoint restorePoint)
        {
            data[free] = restorePoint;
            free = (free + 1) % length;
        }

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

        public void Flush()
        {
            for (int i = 0; i < length; ++i)
            {
                data[i] = null;
            }
        }

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
