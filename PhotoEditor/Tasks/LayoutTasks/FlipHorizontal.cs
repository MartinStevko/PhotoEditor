using System;

namespace PhotoEditor
{
    /// <summary>
    /// Task for horizontal image flip
    /// </summary>
    public class FlipHorizontal : FlipTask
    {
        /// <summary>
        /// Constructor caller of base constructor
        /// </summary>
        /// <param name="mod">One of provided image modifications</param>
        /// <param name="imageSet">Pointer to image set from engine</param>
        public FlipHorizontal(ImageModification mod, ImageSet imageSet) : base(mod, imageSet) { }

        /// <summary>
        /// Determines iterate array size based on image size
        /// </summary>
        /// <param name="x">Image width</param>
        /// <param name="y">Image height</param>
        /// <returns>Iterate array size as tuple (x, y)</returns>
        protected override Tuple<int, int> MaxCoordinates(int x, int y)
        {
            width = x;
            height = y;
            return new Tuple<int, int>(x, y / 2);
        }

        /// <summary>
        /// Delegate for layout change
        /// </summary>
        /// <param name="x">X coordinate of pixel</param>
        /// <param name="y">Y coordinate of pixel</param>
        /// <returns>New coordinates as tuple (x, y)</returns>
        protected override Tuple<int, int> MixLayout(int x, int y)
        {
            return new Tuple<int, int>(x, height - y - 1);
        }
    }
}
