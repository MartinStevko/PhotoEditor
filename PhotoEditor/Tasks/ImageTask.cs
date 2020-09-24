using System;

namespace PhotoEditor
{
    /// <summary>
    /// Provided image modifications
    /// </summary>
    public enum ImageModification
    {
        Saturation,
        Brightness,
        Clarity,
        InvertColor,
        FlipHorizontally,
        FlipVertically,
        ColorRotate,
        ApplyGreyStyle,
        ApplyLUT
    }

    /// <summary>
    /// Abstract class which provides common ancestor of all types of image tasks
    /// </summary>
    public abstract class ImageTask
    {
        /// <summary>
        /// One of provided image modifications
        /// Provides easy access to image task type
        /// </summary>
        public ImageModification taskType;

        /// <summary>
        /// Boolean indicator whether task is in processing or in waiting list
        /// </summary>
        public bool ongoing;

        /// <summary>
        /// Pointer to previous image task
        /// Required as linked list implementation
        /// </summary>
        public ImageTask previous;
        /// <summary>
        /// Pointer to next image task
        /// Required as linked list implementation
        /// </summary>
        public ImageTask next;

        /// <summary>
        /// Pointer to image set from engine
        /// </summary>
        internal ImageSet iSet;
        /// <summary>
        /// Deep coppy of current mode in image set
        /// </summary>
        internal ImageMode iMode;

        /// <summary>
        /// Initialize image task type, image color filter (as image view mode), image set and 
        /// other variables with defaults
        /// </summary>
        /// <param name="mod">One of provided image modifications</param>
        /// <param name="imageSet">Pointer to image set from engine</param>
        public ImageTask(ImageModification mod, ImageSet imageSet)
        {
            taskType = mod;

            ongoing = false;
            previous = null;
            next = null;

            iSet = imageSet;
            iMode = iSet.imageMode;
        }

        /// <summary>
        /// Task entry point for task control
        /// Implements logic how to properly execute this type of image task
        /// </summary>
        public abstract void Process();
    }

    #region Color edit tasks

    /// <summary>
    /// Common ancestor for sauration/brightness/clarity changes
    /// </summary>
    public abstract class ColorEdit : ColorTask
    {
        /// <summary>
        /// Level of saturation/brightness/clarity
        /// </summary>
        public int value;

        /// <summary>
        /// Constructor caller of base constructor
        /// Inicialize also edit value
        /// </summary>
        /// <param name="mod">One of provided image modifications</param>
        /// <param name="imageSet">Pointer to image set from engine</param>
        /// <param name="value">Particular edit level</param>
        public ColorEdit(ImageModification mod, ImageSet imageSet, int value) : base(mod, imageSet)
        {
            this.value = value;
        }
    }

    /// <summary>
    /// Color saturation edit task
    /// </summary>
    public class SaturationEdit : ColorEdit
    {
        /// <summary>
        /// Edit coeficient based on current and desired saturation
        /// </summary>
        private int c;

        /// <summary>
        /// Constructor caller of base constructor
        /// </summary>
        /// <param name="mod">One of provided image modifications</param>
        /// <param name="imageSet">Pointer to image set from engine</param>
        /// <param name="value">Particular edit level</param>
        public SaturationEdit(ImageModification mod, ImageSet imageSet, int value) : base(mod, imageSet, value) { }

        /// <summary>
        /// Override of ancestors Process() method
        /// Implements determination of edit coeficient
        /// </summary>
        public override void Process()
        {
            if (iSet != null)
            {
                c = (value - iSet.saturation) / 3;
                iSet.saturation = value;

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
            int r = Math.Min(Math.Max(0, red - c), 255);
            int g = Math.Min(Math.Max(0, green - c), 255);
            int b = Math.Min(Math.Max(0, blue - c), 255);

            Tuple<byte, byte, byte> response = ReturnWithFilter(red, green, blue, r, g, b);
            return response;
        }
    }

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

    #endregion

    #region Color swap tasks

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

    #endregion

    #region Color map tasks

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

    #endregion

    #region Filter tasks

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

    #endregion
}
