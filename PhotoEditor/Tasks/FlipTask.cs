using System;

namespace PhotoEditor
{
    /// <summary>
    /// Common ancestor for flipping tasks
    /// </summary>
    public abstract class FlipTask : ImageTask
    {
        /// <summary>
        /// Image pixels width
        /// </summary>
        protected int width;

        /// <summary>
        /// Image pixels height
        /// </summary>
        protected int height;

        /// <summary>
        /// Constructor caller of base constructor
        /// </summary>
        /// <param name="mod">One of provided image modifications</param>
        /// <param name="imageSet">Pointer to image set from engine</param>
        public FlipTask(ImageModification mod, ImageSet imageSet) : base(mod, imageSet) { }

        /// <summary>
        /// Task common processing override
        /// </summary>
        public override void Process()
        {
            iSet.ProcessLayout(MixLayout, MaxCoordinates);
            iSet.ProcessThumbnailLayout(MixLayout, MaxCoordinates);
        }

        /// <summary>
        /// Determines iterate array size based on image size
        /// </summary>
        /// <param name="x">Image width</param>
        /// <param name="y">Image height</param>
        /// <returns>Iterate array size as tuple (x, y)</returns>
        protected abstract Tuple<int, int> MaxCoordinates(int x, int y);

        /// <summary>
        /// Delegate for layout change
        /// </summary>
        /// <param name="x">X coordinate of pixel</param>
        /// <param name="y">Y coordinate of pixel</param>
        /// <returns>New coordinates as tuple (x, y)</returns>
        protected abstract Tuple<int, int> MixLayout(int x, int y);
    }
}
