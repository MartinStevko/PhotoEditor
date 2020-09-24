﻿using System;

namespace PhotoEditor
{
    /// <summary>
    /// Color brigthness edit task
    /// </summary>
    public class BrightnessEdit : ColorEdit
    {
        /// <summary>
        /// Edit coeficient based on current and desired brightness
        /// </summary>
        private double c;

        /// <summary>
        /// Constructor caller of base constructor
        /// </summary>
        /// <param name="mod">One of provided image modifications</param>
        /// <param name="imageSet">Pointer to image set from engine</param>
        /// <param name="value">Particular edit level</param>
        public BrightnessEdit(ImageModification mod, ImageSet imageSet, int value) : base(mod, imageSet, value) { }

        /// <summary>
        /// Override of ancestors Process() method
        /// Implements determination of edit coeficient
        /// </summary>
        public override void Process()
        {
            if (iSet != null)
            {
                c = (value - iSet.brightness) / 600.0;
                iSet.brightness = value;

                iSet.ProcessColor(ColorMixer);
                iSet.ProcessThumbnailColor(ColorMixer);
            }
        }

        /// <summary>
        /// Calculate new RGB saturation value from current value
        /// </summary>
        /// <param name="red">Red value in RGB format</param>
        /// <param name="green">Green value in RGB format</param>
        /// <param name="blue">Blue value in RGB format</param>
        /// <returns>Tuple of (red, green, blue) values of new color in RGB format</returns>
        public override Tuple<byte, byte, byte> ColorMixer(byte red, byte green, byte blue)
        {
            int r = Math.Min(Math.Max(0, red + (int)((red) * c)), 255);
            int g = Math.Min(Math.Max(0, green + (int)((green) * c)), 255);
            int b = Math.Min(Math.Max(0, blue + (int)((blue) * c)), 255);

            Tuple<byte, byte, byte> response = ReturnWithFilter(red, green, blue, r, g, b);
            return response;
        }
    }
}