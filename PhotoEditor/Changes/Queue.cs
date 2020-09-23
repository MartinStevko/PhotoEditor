using System.Collections.Generic;

namespace PhotoEditor
{
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

        public string[] ToStringList()
        {
            List<string> list = new List<string>();
            if (IsEmpty())
            {
                list.Add("No changes made yet...");
            } 
            else
            {
                int i = free;
                if (i == 0)
                {
                    i = length - 1;
                }
                else
                {
                    --i;
                }
                while (data[i] != null)
                {
                    list.Add(data[i].ToString());
                    if (i == 0)
                    {
                        i = length - 1;
                    }
                    else
                    {
                        --i;
                    }
                    if (i == free)
                    {
                        break;
                    }
                }
            }
            return list.ToArray();
        }
    }
}
