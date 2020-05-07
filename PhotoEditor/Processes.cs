using System;

namespace PhotoEditor
{
    /// <summary>
    /// Calculate new RGB value from current value
    /// </summary>
    /// <param name="red">Red value in RGB format</param>
    /// <param name="green">Green value in RGB format</param>
    /// <param name="blue">Blue value in RGB format</param>
    /// <returns>Tuple of (red, green, blue) values of new color in RGB format</returns>
    public delegate Tuple<byte, byte, byte> ColorMixer(byte red, byte green, byte blue);

    /// <summary>
    /// Determines new coordinates of the pixel
    /// </summary>
    /// <param name="x">x coordinate of pixel</param>
    /// <param name="y">y coordinate of pixel</param>
    /// <returns>New coordinates in tuple</returns>
    public delegate Tuple<int, int> LayoutMixer(int x, int y);

    /// <summary>
    /// Determines maximal values of controls in array traversal
    /// </summary>
    /// <param name="x">Number of raws</param>
    /// <param name="y">Number of columns</param>
    /// <returns>Tuple (x, y) where x is length of raw traversal and y length of column traversal</returns>
    public delegate Tuple<int, int> LayoutCoordinatesMaxValue(int x, int y);
}
