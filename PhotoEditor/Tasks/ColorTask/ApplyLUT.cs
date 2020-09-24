using System;

namespace PhotoEditor
{
    /// <summary>
    /// Task for look-up table applying
    /// </summary>
    public class ApplyLUT : ColorTask
    {
        /// <summary>
        /// LUT file accuracy
        /// </summary>
        private int size;

        /// <summary>
        /// LUT color map
        /// </summary>
        private Tuple<byte, byte, byte>[,,] map;

        /// <summary>
        /// Constructor caller of base constructor
        /// Also reads a saves LUT file by its filename
        /// </summary>
        /// <param name="mod">One of provided image modifications</param>
        /// <param name="imageSet">Pointer to image set from engine</param>
        /// <param name="name">LUT filename</param>
        public ApplyLUT(ImageModification mod, ImageSet imageSet, string name) : base(mod, imageSet)
        {
            Tuple<int, Tuple<byte, byte, byte>[,,]> lut = LookUpTable.Read(name);
            size = lut.Item1;
            map = lut.Item2;
        }

        /// <summary>
        /// Calculate RGB value from current value after mapping colors according to LUT file
        /// </summary>
        /// <param name="red">Red value in RGB format</param>
        /// <param name="green">Green value in RGB format</param>
        /// <param name="blue">Blue value in RGB format</param>
        /// <returns>Tuple of (red, green, blue) values of new color in RGB format</returns>
        public override Tuple<byte, byte, byte> ColorMixer(byte red, byte green, byte blue)
        {
            Tuple<byte, byte, byte> color = map[
                (int)Math.Round((double)red * (size - 1) / 255),
                (int)Math.Round((double)green * (size - 1) / 255),
                (int)Math.Round((double)blue * (size - 1) / 255)
            ];

            Tuple<byte, byte, byte> response = ReturnWithFilter(red, green, blue, color.Item1, color.Item2, color.Item3);
            return response;
        }
    }
}
