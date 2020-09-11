using System;

namespace PhotoEditor.Tasks
{
    /// <summary>
    /// Task to invert image color
    /// </summary>
    public class ColorInvert : ColorTask
    {
        /// <summary>
        /// Constructor caller of base constructor
        /// </summary>
        /// <param name="mod">One of provided image modifications</param>
        /// <param name="imageSet">Pointer to image set from engine</param>
        public ColorInvert(ImageModification mod, ImageSet imageSet) : base(mod, imageSet) { }

        /// <summary>
        /// Calculate RGB inverted value from current value
        /// </summary>
        /// <param name="red">Red value in RGB format</param>
        /// <param name="green">Green value in RGB format</param>
        /// <param name="blue">Blue value in RGB format</param>
        /// <returns>Tuple of (red, green, blue) values of new color in RGB format</returns>
        public override Tuple<byte, byte, byte> ColorMixer(byte red, byte green, byte blue)
        {
            int r = 255 - red;
            int g = 255 - green;
            int b = 255 - blue;

            Tuple<byte, byte, byte> response = ReturnWithFilter(red, green, blue, r, g, b);
            return response;
        }
    }
}
