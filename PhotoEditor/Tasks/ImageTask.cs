using System;

namespace PhotoEditor
{
    /// <summary>
    /// Provided image modifications
    /// </summary>
    public enum ImageModification
    {
        Saturation,
        Brightness,
        Clarity,
        InvertColor,
        FlipHorizontally,
        FlipVertically,
        ColorRotate,
        ApplyGreyStyle,
        ApplyLUT
    }

    /// <summary>
    /// Abstract class which provides common ancestor of all types of image tasks
    /// </summary>
    public abstract class ImageTask
    {
        /// <summary>
        /// One of provided image modifications
        /// Provides easy access to image task type
        /// </summary>
        public ImageModification taskType;

        /// <summary>
        /// Boolean indicator whether task is in processing or in waiting list
        /// </summary>
        public bool ongoing;

        /// <summary>
        /// Pointer to previous image task
        /// Required as linked list implementation
        /// </summary>
        public ImageTask previous;
        /// <summary>
        /// Pointer to next image task
        /// Required as linked list implementation
        /// </summary>
        public ImageTask next;

        /// <summary>
        /// Pointer to image set from engine
        /// </summary>
        internal ImageSet iSet;
        /// <summary>
        /// Deep coppy of current mode in image set
        /// </summary>
        internal ImageMode iMode;

        /// <summary>
        /// Initialize image task type, image color filter (as image view mode), image set and 
        /// other variables with defaults
        /// </summary>
        /// <param name="mod">One of provided image modifications</param>
        /// <param name="imageSet">Pointer to image set from engine</param>
        public ImageTask(ImageModification mod, ImageSet imageSet)
        {
            taskType = mod;

            ongoing = false;
            previous = null;
            next = null;

            iSet = imageSet;
            iMode = iSet.imageMode;
        }

        /// <summary>
        /// Task entry point for task control
        /// Implements logic how to properly execute this type of image task
        /// </summary>
        public abstract void Process();
    }
}
