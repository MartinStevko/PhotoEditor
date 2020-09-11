using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEditor.Tasks
{
    /// <summary>
    /// Tsk for vertical image flip
    /// </summary>
    public class FlipVertical : FlipTask
    {
        /// <summary>
        /// Constructor caller of base constructor
        /// </summary>
        /// <param name="mod">One of provided image modifications</param>
        /// <param name="imageSet">Pointer to image set from engine</param>
        public FlipVertical(ImageModification mod, ImageSet imageSet) : base(mod, imageSet) { }

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
            return new Tuple<int, int>(x / 2, y);
        }

        /// <summary>
        /// Delegate for layout change
        /// </summary>
        /// <param name="x">X coordinate of pixel</param>
        /// <param name="y">Y coordinate of pixel</param>
        /// <returns>New coordinates as tuple (x, y)</returns>
        protected override Tuple<int, int> MixLayout(int x, int y)
        {
            return new Tuple<int, int>(width - x - 1, y);
        }
    }
}
