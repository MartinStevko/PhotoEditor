using System;

namespace PhotoEditor
{
    /// <summary>
    /// Common ancestor for all types of image tasks which 
    /// processes image color pixel by pixel
    /// </summary>
    public abstract class ColorTask : ImageTask
    {
        /// <summary>
        /// Constructor caller of base constructor
        /// </summary>
        /// <param name="mod">One of provided image modifications</param>
        /// <param name="imageSet">Pointer to image set from engine</param>
        public ColorTask(ImageModification mod, ImageSet imageSet) : base(mod, imageSet) { }

        /// <summary>
        /// Function which defines color mapping of particular change in image set
        /// Must use the same interface as color mixer delegate, because it is used as delegate
        /// </summary>
        /// <param name="red">Red value in RGB format</param>
        /// <param name="green">Green value in RGB format</param>
        /// <param name="blue">Blue value in RGB format</param>
        /// <returns>Tuple of (red, green, blue) values of new color in RGB format</returns>
        public abstract Tuple<byte, byte, byte> ColorMixer(byte red, byte green, byte blue);

        /// <summary>
        /// Common processing (can be overriden later)
        /// </summary>
        public override void Process()
        {
            if (iSet != null)
            {
                iSet.ProcessColor(ColorMixer);
                iSet.ProcessThumbnailColor(ColorMixer);
            }
        }

        /// <summary>
        /// Color filter based on image mode - returns only edits ofcurrently shown color spectre
        /// </summary>
        /// <param name="red">Input red value in RGB format</param>
        /// <param name="green">Input green value in RGB format</param>
        /// <param name="blue">Input blue value in RGB format</param>
        /// <param name="r">Processed red value in RGB format</param>
        /// <param name="g">Processed green value in RGB format</param>
        /// <param name="b">Processed blue value in RGB format</param>
        /// <returns>Tuple of (red, green, blue) values of new color in RGB format with filter applied</returns>
        public Tuple<byte, byte, byte> ReturnWithFilter(byte red, byte green, byte blue, int r, int g, int b)
        {
            switch (iMode)
            {
                case ImageMode.Red:
                    return new Tuple<byte, byte, byte>((byte)r, green, blue);
                case ImageMode.Green:
                    return new Tuple<byte, byte, byte>(red, (byte)g, blue);
                case ImageMode.Blue:
                    return new Tuple<byte, byte, byte>(red, green, (byte)b);
                default:
                    return new Tuple<byte, byte, byte>((byte)r, (byte)g, (byte)b);
            }
        }
    }
}
