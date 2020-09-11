using System;

namespace PhotoEditor.Tasks
{
    /// <summary>
    /// Grey style filter for image
    /// </summary>
    public class ApplyGreyStyle : ColorTask
    {
        /// <summary>
        /// Red color brightness ratio
        /// </summary>
        private double redBrightness = 0.2989;
        /// <summary>
        /// Green color brightness ratio
        /// </summary>
        private double greenBrightness = 0.5866;
        /// <summary>
        /// Blue color brightness ration
        /// </summary>
        private double blueBrightness = 0.1145;

        /// <summary>
        /// Constructor caller of base constructor
        /// </summary>
        /// <param name="mod">One of provided image modifications</param>
        /// <param name="imageSet">Pointer to image set from engine</param>
        public ApplyGreyStyle(ImageModification mod, ImageSet imageSet) : base(mod, imageSet) { }

        /// <summary>
        /// Calculate new RGB value from current value after greystyle applying
        /// </summary>
        /// <param name="red">Red value in RGB format</param>
        /// <param name="green">Green value in RGB format</param>
        /// <param name="blue">Blue value in RGB format</param>
        /// <returns>Tuple of (red, green, blue) values of new color in RGB format</returns>
        public override Tuple<byte, byte, byte> ColorMixer(byte red, byte green, byte blue)
        {
            byte grey = (byte)(red * redBrightness + green * greenBrightness + blue * blueBrightness);
            return new Tuple<byte, byte, byte>(grey, grey, grey);
        }
    }
}
