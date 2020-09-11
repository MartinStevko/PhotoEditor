using System;

namespace PhotoEditor.Tasks
{
    /// <summary>
    /// Color clarity edit task
    /// </summary>
    public class ClarityEdit : ColorEdit
    {
        /// <summary>
        /// Edit coeficient based on current and desired clarity
        /// </summary>
        private double c;

        /// <summary>
        /// Constructor caller of base constructor
        /// </summary>
        /// <param name="mod">One of provided image modifications</param>
        /// <param name="imageSet">Pointer to image set from engine</param>
        /// <param name="value">Particular edit level</param>
        public ClarityEdit(ImageModification mod, ImageSet imageSet, int value) : base(mod, imageSet, value) { }

        /// <summary>
        /// Override of ancestors Process() method
        /// Implements determination of edit coeficient
        /// </summary>
        public override void Process()
        {
            if (iSet != null)
            {
                c = (value - iSet.clarity + 300) / 300.0;
                iSet.clarity = value;

                iSet.ProcessColor(ColorMixer);
                iSet.ProcessThumbnailColor(ColorMixer);
            }
        }

        /// <summary>
        /// Calculate new RGB clarity value from current value
        /// </summary>
        /// <param name="red">Red value in RGB format</param>
        /// <param name="green">Green value in RGB format</param>
        /// <param name="blue">Blue value in RGB format</param>
        /// <returns>Tuple of (red, green, blue) values of new color in RGB format</returns>
        public override Tuple<byte, byte, byte> ColorMixer(byte red, byte green, byte blue)
        {
            int r = 128 - Math.Min(Math.Max(-127, (int)((128 - red) * c)), 128);
            int g = 128 - Math.Min(Math.Max(-127, (int)((128 - green) * c)), 128);
            int b = 128 - Math.Min(Math.Max(-127, (int)((128 - blue) * c)), 128);

            Tuple<byte, byte, byte> response = ReturnWithFilter(red, green, blue, r, g, b);
            return response;
        }
    }
}
