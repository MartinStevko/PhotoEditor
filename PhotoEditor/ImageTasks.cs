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
        ApplyGreyStyle
    }

    public abstract class ImageTask
    {
        public ImageModification taskType;
        public bool ongoing;

        public ImageTask previous;
        public ImageTask next;

        public ImageTask(ImageModification mod)
        {
            taskType = mod;

            ongoing = false;
            previous = null;
            next = null;
        }

        public abstract void Process(ImageSet iSet);
    }

    #region Color edit tasks

    public abstract class ColorEdit : ImageTask
    {
        public int value;

        public ColorEdit(ImageModification mod, int value) : base(mod)
        {
            this.value = value;
        }
    }

    public class SaturationEdit : ColorEdit
    {
        public SaturationEdit(ImageModification mod, int value) : base(mod, value) { }

        public override void Process(ImageSet iSet)
        {
            if (iSet != null)
            {
                int c = (value - iSet.saturation) / 3;
                iSet.saturation = value;

                Tuple<byte, byte, byte> SaturationMixer(byte red, byte green, byte blue)
                {
                    int r = Math.Min(Math.Max(0, red - c), 255);
                    int g = Math.Min(Math.Max(0, green - c), 255);
                    int b = Math.Min(Math.Max(0, blue - c), 255);

                    return new Tuple<byte, byte, byte>((byte)r, (byte)g, (byte)b);
                }

                iSet.ProcessColor(SaturationMixer);
                iSet.ProcessThumbnailColor(SaturationMixer);
            }
        }
    }

    public class BrightnessEdit : ColorEdit
    {
        public BrightnessEdit(ImageModification mod, int value) : base(mod, value) { }

        public override void Process(ImageSet iSet)
        {
            if (iSet != null)
            {
                double c = (value - iSet.brightness) / 600.0;
                iSet.brightness = value;

                Tuple<byte, byte, byte> BrightnessMixer(byte red, byte green, byte blue)
                {
                    int r = Math.Min(Math.Max(0, red + (int)((red) * c)), 255);
                    int g = Math.Min(Math.Max(0, green + (int)((green) * c)), 255);
                    int b = Math.Min(Math.Max(0, blue + (int)((blue) * c)), 255);

                    return new Tuple<byte, byte, byte>((byte)r, (byte)g, (byte)b);
                }

                iSet.ProcessColor(BrightnessMixer);
                iSet.ProcessThumbnailColor(BrightnessMixer);
            }
        }
    }

    public class ClarityEdit : ColorEdit
    {
        public ClarityEdit(ImageModification mod, int value) : base(mod, value) { }

        public override void Process(ImageSet iSet)
        {
            if (iSet != null)
            {
                double c = (value - iSet.clarity + 1000) / 1000.0;
                iSet.clarity = value;

                Tuple<byte, byte, byte> SaturationMixer(byte red, byte green, byte blue)
                {
                    int r = 128 - Math.Min(Math.Max(-128, (int)((128 - red) * c)), 127);
                    int g = 128 - Math.Min(Math.Max(-128, (int)((128 - green) * c)), 127);
                    int b = 128 - Math.Min(Math.Max(-128, (int)((128 - blue) * c)), 127);

                    return new Tuple<byte, byte, byte>((byte)r, (byte)g, (byte)b);
                }

                iSet.ProcessColor(SaturationMixer);
                iSet.ProcessThumbnailColor(SaturationMixer);
            }
        }
    }

    #endregion

    #region Color swap tasks

    public class ColorInvert : ImageTask
    {
        public ColorInvert(ImageModification mod) : base(mod) { }

        public override void Process(ImageSet iSet)
        {
            iSet.ProcessColor(Inverter);
            iSet.ProcessThumbnailColor(Inverter);
        }

        private static Tuple<byte, byte, byte> Inverter(byte red, byte green, byte blue)
        {
            return new Tuple<byte, byte, byte>(
                (byte)(255 - red),
                (byte)(255 - green),
                (byte)(255 - blue)
            );
        }
    }

    public class ColorChange : ImageTask
    {
        private sbyte first;

        private sbyte second;

        public ColorChange(ImageModification mod, string first, string second) : base(mod)
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

        public override void Process(ImageSet iSet)
        {
            Tuple<byte, byte, byte> Changer(byte red, byte green, byte blue)
            {
                byte[] colors = new byte[] { red, green, blue };
                byte temp = colors[first];
                colors[first] = colors[second];
                colors[second] = temp;

                return new Tuple<byte, byte, byte>(colors[0], colors[1], colors[2]);
            }

            iSet.ProcessColor(Changer);
            iSet.ProcessThumbnailColor(Changer);
        }
    }

    #endregion

    #region Layout tasks

    public abstract class FlipTask : ImageTask
    {
        protected int width;

        protected int height;

        public FlipTask(ImageModification mod) : base(mod) { }

        public override void Process(ImageSet iSet)
        {
            iSet.ProcessLayout(MixLayout, MaxCoordinates);
            iSet.ProcessThumbnailLayout(MixLayout, MaxCoordinates);
        }

        protected abstract Tuple<int, int> MaxCoordinates(int x, int y);

        protected abstract Tuple<int, int> MixLayout(int x, int y);
    }

    public class FlipHorizontal : FlipTask
    {
        public FlipHorizontal(ImageModification mod) : base(mod) { }

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
        public FlipVertical(ImageModification mod) : base(mod) { }

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

    public abstract class ApplyFilter : ImageTask
    {
        public ApplyFilter(ImageModification mod) : base(mod) { }

        public abstract Tuple<byte, byte, byte> Filter(byte red, byte green, byte blue);

        public override void Process(ImageSet iSet)
        {
            iSet.ProcessColor(Filter);
            iSet.ProcessThumbnailColor(Filter);
        }
    }

    public class ApplyGreyStyle : ApplyFilter
    {
        private double redBrightness = 0.2989;
        private double greenBrightness = 0.5866;
        private double blueBrightness = 0.1145;

        public ApplyGreyStyle(ImageModification mod) : base(mod) { }

        public override Tuple<byte, byte, byte> Filter(byte red, byte green, byte blue)
        {
            byte grey = (byte)(red * redBrightness + green * greenBrightness + blue * blueBrightness);
            return new Tuple<byte, byte, byte>(grey, grey, grey);
        }
    }

    #endregion
}
