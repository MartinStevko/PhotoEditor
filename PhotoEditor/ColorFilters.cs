using System;

namespace PhotoEditor
{
    /// <summary>
    /// Spectra color filters
    /// </summary>
    static public class ColorFilters
    {
        /// <summary>
        /// Calculate new RGB value from current value after filter applying
        /// </summary>
        /// <param name="red">Red value in RGB format</param>
        /// <param name="green">Green value in RGB format</param>
        /// <param name="blue">Blue value in RGB format</param>
        /// <returns>Tuple of (red, green, blue) values of unchanged color</returns>
        static public Tuple<byte, byte, byte> NoFilter(byte red, byte green, byte blue)
        {
            return new Tuple<byte, byte, byte>(red, green, blue);
        }

        /// <summary>
        /// Calculate new RGB value from current value after filter applying
        /// </summary>
        /// <param name="red">Red value in RGB format</param>
        /// <param name="green">Green value in RGB format</param>
        /// <param name="blue">Blue value in RGB format</param>
        /// <returns>Tuple of (red, 0, 0) values from source color</returns>
        static public Tuple<byte, byte, byte> RedFilter(byte red, byte green, byte blue)
        {
            return new Tuple<byte, byte, byte>(red, 0, 0);
        }

        /// <summary>
        /// Calculate new RGB value from current value after filter applying
        /// </summary>
        /// <param name="red">Red value in RGB format</param>
        /// <param name="green">Green value in RGB format</param>
        /// <param name="blue">Blue value in RGB format</param>
        /// <returns>Tuple of (0, green, 0) values from source color</returns>
        static public Tuple<byte, byte, byte> GreenFilter(byte red, byte green, byte blue)
        {
            return new Tuple<byte, byte, byte>(0, green, 0);
        }

        /// <summary>
        /// Calculate new RGB value from current value after filter applying
        /// </summary>
        /// <param name="red">Red value in RGB format</param>
        /// <param name="green">Green value in RGB format</param>
        /// <param name="blue">Blue value in RGB format</param>
        /// <returns>Tuple of (0, 0, blue) values from source color</returns>
        static public Tuple<byte, byte, byte> BlueFilter(byte red, byte green, byte blue)
        {
            return new Tuple<byte, byte, byte>(0, 0, blue);
        }
    }
}
