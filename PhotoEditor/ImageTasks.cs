using System;

namespace PhotoEditor
{
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

    public abstract class ImageTask
    {
        public ImageModification taskType;
        public bool ongoing;

        public ImageTask previous;
        public ImageTask next;

        internal ImageSet iSet;
        internal ImageMode iMode;

        public ImageTask(ImageModification mod, ImageSet imageSet)
        {
            taskType = mod;

            ongoing = false;
            previous = null;
            next = null;

            iSet = imageSet;
            iMode = iSet.imageMode;
        }

        public abstract void Process();
    }

    public abstract class ColorTask : ImageTask
    {
        public ColorTask(ImageModification mod, ImageSet imageSet) : base(mod, imageSet) { }

        public abstract Tuple<byte, byte, byte> ColorMixer(byte red, byte green, byte blue);

        public override void Process()
        {
            if (iSet != null)
            {
                iSet.ProcessColor(ColorMixer);
                iSet.ProcessThumbnailColor(ColorMixer);
            }
        }

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

    #region Color edit tasks

    public abstract class ColorEdit : ColorTask
    {
        public int value;

        public ColorEdit(ImageModification mod, ImageSet imageSet, int value) : base(mod, imageSet)
        {
            this.value = value;
        }
    }

    public class SaturationEdit : ColorEdit
    {
        private int c;

        public SaturationEdit(ImageModification mod, ImageSet imageSet, int value) : base(mod, imageSet, value) { }

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

        public override Tuple<byte, byte, byte> ColorMixer(byte red, byte green, byte blue)
        {
            int r = Math.Min(Math.Max(0, red - c), 255);
            int g = Math.Min(Math.Max(0, green - c), 255);
            int b = Math.Min(Math.Max(0, blue - c), 255);

            Tuple<byte, byte, byte> response = ReturnWithFilter(red, green, blue, r, g, b);
            return response;
        }
    }

    public class BrightnessEdit : ColorEdit
    {
        private double c;

        public BrightnessEdit(ImageModification mod, ImageSet imageSet, int value) : base(mod, imageSet, value) { }

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

        public override Tuple<byte, byte, byte> ColorMixer(byte red, byte green, byte blue)
        {
            int r = Math.Min(Math.Max(0, red + (int)((red) * c)), 255);
            int g = Math.Min(Math.Max(0, green + (int)((green) * c)), 255);
            int b = Math.Min(Math.Max(0, blue + (int)((blue) * c)), 255);

            Tuple<byte, byte, byte> response = ReturnWithFilter(red, green, blue, r, g, b);
            return response;
        }
    }

    public class ClarityEdit : ColorEdit
    {
        private double c;

        public ClarityEdit(ImageModification mod, ImageSet imageSet, int value) : base(mod, imageSet, value) { }

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

    public class ColorInvert : ColorTask
    {
        public ColorInvert(ImageModification mod, ImageSet imageSet) : base(mod, imageSet) { }

        public override Tuple<byte, byte, byte> ColorMixer(byte red, byte green, byte blue)
        {
            int r = 255 - red;
            int g = 255 - green;
            int b = 255 - blue;

            Tuple<byte, byte, byte> response = ReturnWithFilter(red, green, blue, r, g, b);
            return response;
        }
    }

    public class ColorChange : ColorTask
    {
        private sbyte first;

        private sbyte second;

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

    public class ApplyLUT : ColorTask
    {
        private int size;

        private Tuple<byte, byte, byte>[,,] map;

        public ApplyLUT(ImageModification mod, ImageSet imageSet, string name) : base(mod, imageSet)
        {
            Tuple<int, Tuple<byte, byte, byte>[,,]> lut = LookUpTable.Read(name);
            size = lut.Item1;
            map = lut.Item2;
        }

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

    #region Layout tasks

    public abstract class FlipTask : ImageTask
    {
        protected int width;

        protected int height;

        public FlipTask(ImageModification mod, ImageSet imageSet) : base(mod, imageSet) { }

        public override void Process()
        {
            iSet.ProcessLayout(MixLayout, MaxCoordinates);
            iSet.ProcessThumbnailLayout(MixLayout, MaxCoordinates);
        }

        protected abstract Tuple<int, int> MaxCoordinates(int x, int y);

        protected abstract Tuple<int, int> MixLayout(int x, int y);
    }

    public class FlipHorizontal : FlipTask
    {
        public FlipHorizontal(ImageModification mod, ImageSet imageSet) : base(mod, imageSet) { }

        protected override Tuple<int, int> MaxCoordinates(int x, int y)
        {
            width = x;
            height = y;
            return new Tuple<int, int>(x, y / 2);
        }

        protected override Tuple<int, int> MixLayout(int x, int y)
        {
            return new Tuple<int, int>(x, height - y - 1);
        }
    }

    public class FlipVertical : FlipTask
    {
        public FlipVertical(ImageModification mod, ImageSet imageSet) : base(mod, imageSet) { }

        protected override Tuple<int, int> MaxCoordinates(int x, int y)
        {
            width = x;
            height = y;
            return new Tuple<int, int>(x / 2, y);
        }

        protected override Tuple<int, int> MixLayout(int x, int y)
        {
            return new Tuple<int, int>(width - x - 1, y);
        }
    }

    #endregion

    #region Filter tasks

    public class ApplyGreyStyle : ColorTask
    {
        private double redBrightness = 0.2989;
        private double greenBrightness = 0.5866;
        private double blueBrightness = 0.1145;

        public ApplyGreyStyle(ImageModification mod, ImageSet imageSet) : base(mod, imageSet) { }

        public override Tuple<byte, byte, byte> ColorMixer(byte red, byte green, byte blue)
        {
            byte grey = (byte)(red * redBrightness + green * greenBrightness + blue * blueBrightness);
            return new Tuple<byte, byte, byte>(grey, grey, grey);
        }
    }

    #endregion
}
