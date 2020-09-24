using System;

namespace PhotoEditor
{
    /// <summary>
    /// Task for swapping two colors
    /// </summary>
    public class ColorChange : ColorTask
    {
        /// <summary>
        /// Index of first color in exchange
        /// </summary>
        private sbyte first;

        /// <summary>
        /// Index of second color in exchange
        /// </summary>
        private sbyte second;

        /// <summary>
        /// Constructor caller of base constructor and color exchange parser
        /// </summary>
        /// <param name="mod">One of provided image modifications</param>
        /// <param name="imageSet">Pointer to image set from engine</param>
        /// <param name="first">First color</param>
        /// <param name="second">Second color</param>
        public ColorChange(ImageModification mod, ImageSet imageSet, string first, string second) : base(mod, imageSet)
        {
            this.first = -1;
            this.second = -1;
            switch (first)
            {
                case "red":
                    this.first = 0;
                    break;
                case "green":
                    this.first = 1;
                    break;
                case "blue":
                    this.first = 2;
                    break;
            }
            switch (second)
            {
                case "red":
                    this.second = 0;
                    break;
                case "green":
                    this.second = 1;
                    break;
                case "blue":
                    this.second = 2;
                    break;
            }
        }

        /// <summary>
        /// Calculate RGB value from current value after swapping two colors
        /// </summary>
        /// <param name="red">Red value in RGB format</param>
        /// <param name="green">Green value in RGB format</param>
        /// <param name="blue">Blue value in RGB format</param>
        /// <returns>Tuple of (red, green, blue) values of new color in RGB format</returns>
        public override Tuple<byte, byte, byte> ColorMixer(byte red, byte green, byte blue)
        {
            byte[] colors = new byte[] { red, green, blue };
            byte temp = colors[first];
            colors[first] = colors[second];
            colors[second] = temp;

            return new Tuple<byte, byte, byte>(colors[0], colors[1], colors[2]);
        }
    }
}
