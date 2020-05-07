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

        public ImageTask previous;
        public ImageTask next;

        public ImageTask(ImageTask last)
        {
            if (last == null)
            {
                previous = null;
            }
            else
            {
                last.next = this;
                previous = last;
            }
            next = null;
        }

        public abstract void Process(ImageSet iSet);
    }

    #region Color edit tasks

    public abstract class ColorEdit : ImageTask
    {
        private double value;

        public ColorEdit(ImageTask last, double value) : base(last)
        {
            this.value = value;
        }
    }

    public class SaturationEdit : ColorEdit
    {
        public SaturationEdit(ImageTask last, double value) : base(last, value) { }

        public override void Process(ImageSet iSet)
        {
            // TODO: Process saturation edit
            throw new NotImplementedException();
        }
    }

    public class BrightnessEdit : ColorEdit
    {
        public BrightnessEdit(ImageTask last, double value) : base(last, value) { }

        public override void Process(ImageSet iSet)
        {
            // TODO: Process brightness edit
            throw new NotImplementedException();
        }
    }

    public class ClarityEdit : ColorEdit
    {
        public ClarityEdit(ImageTask last, double value) : base(last, value) { }

        public override void Process(ImageSet iSet)
        {
            // TODO: Process clarity edit
            throw new NotImplementedException();
        }
    }

    #endregion

    #region Color swap tasks



    #endregion

    #region Layout tasks



    #endregion

    #region Filter tasks

    public abstract class ApplyFilter : ImageTask
    {
        public ApplyFilter(ImageTask last) : base(last) { }

        public abstract Tuple<byte, byte, byte> Filter(byte red, byte green, byte blue);

        public override void Process(ImageSet iSet)
        {
            iSet.ProcessColor(Filter);
        }
    }

    public class ApplyGreyStyle : ApplyFilter
    {
        private double redBrightness = 0.2989;
        private double greenBrightness = 0.5866;
        private double blueBrightness = 0.1145;

        public ApplyGreyStyle(ImageTask last) : base(last) { }

        public override Tuple<byte, byte, byte> Filter(byte red, byte green, byte blue)
        {
            byte grey = (byte)(red * redBrightness + green * greenBrightness + blue * blueBrightness);
            return new Tuple<byte, byte, byte>(grey, grey, grey);
        }
    }

    #endregion
}
