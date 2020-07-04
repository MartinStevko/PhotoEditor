using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace PhotoEditor
{
    public enum ImageMode
    {
        Full,
        Red,
        Green,
        Blue
    }

    public class ImageSet
    {
        public string filename;
        private Bitmap origin;

        public Bitmap image;
        public ImageMode imageMode;
        private Rectangle rectangle;

        public Bitmap thumb;
        public Bitmap thumbRed;
        public Bitmap thumbGreen;
        public Bitmap thumbBlue;
        private Rectangle thumbRectangle;

        public int saturation;
        public int brightness;
        public int clarity;

        public ImageSet()
        {
            filename = null;
            origin = null;

            image = null;
            imageMode = ImageMode.Full;
            rectangle = new Rectangle(0, 0, 0, 0);

            thumb = null;
            thumbRed = null;
            thumbGreen = null;
            thumbBlue = null;
            thumbRectangle = new Rectangle(0, 0, 0, 0);

            saturation = 0;
            brightness = 0;
            clarity = 0;
        }

        public void Load(string file, int width, int height, int thumbWidth, int thumbHeight)
        {
            Image source = Image.FromFile(file);

            (width, height) = PreserveAspectRation(width, height, source.Width, source.Height);
            (thumbWidth, thumbHeight) = PreserveAspectRation(thumbWidth, thumbHeight, source.Width, source.Height);

            filename = file;
            rectangle = new Rectangle(0, 0, width, height);
            thumbRectangle = new Rectangle(0, 0, thumbWidth, thumbHeight);

            origin = new Bitmap(width, height);
            origin.SetResolution(source.HorizontalResolution, source.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(origin))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(source, rectangle, 0, 0, source.Width, source.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            image = origin.Clone(rectangle, origin.PixelFormat);

            thumb = Resize(true);
            thumbRed = CopyThumbnailWithFilter(ColorFilters.RedFilter);
            thumbGreen = CopyThumbnailWithFilter(ColorFilters.GreenFilter);
            thumbBlue = CopyThumbnailWithFilter(ColorFilters.BlueFilter);
        }

        private Bitmap Resize(bool toThumbnail)
        {
            Rectangle r = toThumbnail ? thumbRectangle : rectangle;
            Bitmap t = new Bitmap(r.Width, r.Height);
            t.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(t))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, r, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return t;
        }

        public Bitmap ShowWithFilter(ColorMixer mixer)
        {
            Bitmap t = image.Clone(rectangle, image.PixelFormat);

            unsafe
            {
                BitmapData tData = t.LockBits(rectangle, ImageLockMode.ReadWrite, t.PixelFormat);

                int bytesPerPixel = Bitmap.GetPixelFormatSize(t.PixelFormat) / 8;
                int heightInPixels = tData.Height;
                int widthInBytes = tData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)tData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* currentLine = ptrFirstPixel + (y * tData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        (byte red, byte green, byte blue) = mixer(currentLine[x + 2], currentLine[x + 1], currentLine[x]);

                        currentLine[x] = blue;
                        currentLine[x + 1] = green;
                        currentLine[x + 2] = red;
                    }
                });

                t.UnlockBits(tData);
            }

            return t;
        }

        private Bitmap CopyThumbnailWithFilter(ColorMixer mixer)
        {
            Bitmap t = thumb.Clone(thumbRectangle, thumb.PixelFormat);

            unsafe
            {
                BitmapData tData = t.LockBits(thumbRectangle, ImageLockMode.ReadWrite, t.PixelFormat);

                int bytesPerPixel = Bitmap.GetPixelFormatSize(t.PixelFormat) / 8;
                int heightInPixels = tData.Height;
                int widthInBytes = tData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)tData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* currentLine = ptrFirstPixel + (y * tData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        (byte red, byte green, byte blue) = mixer(currentLine[x + 2], currentLine[x + 1], currentLine[x]);

                        currentLine[x] = blue;
                        currentLine[x + 1] = green;
                        currentLine[x + 2] = red;
                    }
                });

                t.UnlockBits(tData);
            }

            return t;
        }

        public static Tuple<int, int> PreserveAspectRation(int width, int height, int pWidth, int pHeight)
        {
            double xRatio = (double)width / (double)pWidth;
            double yRatio = (double)height / (double)pHeight;
            if (xRatio > yRatio)
            {
                return new Tuple<int, int>((int)(pWidth * yRatio), (int)(pHeight * yRatio));
            }
            else
            {
                return new Tuple<int, int>((int)(pWidth * xRatio), (int)(pHeight * xRatio));
            }
        }

        /// <summary>
        /// Changes RGB value of pixel according to the defined rules
        /// </summary>
        /// <param name="mixer">Function which calculate new RGB values</param>
        public void ProcessColor(ColorMixer mixer)
        {
            for (int x = 0; x < image.Width; ++x)
            {
                for (int y = 0; y < image.Height; ++y)
                {
                    Color pixel = image.GetPixel(x, y);
                    (int red, int green, int blue) = mixer(pixel.R, pixel.G, pixel.B);
                    Color p = Color.FromArgb(red, green, blue);
                    image.SetPixel(x, y, p);
                }
            }
        }

        public void ProcessThumbnailColor(ColorMixer mixer)
        {
            for (int x = 0; x < thumb.Width; ++x)
            {
                for (int y = 0; y < thumb.Height; ++y)
                {
                    Color pixel = thumb.GetPixel(x, y);
                    (int red, int green, int blue) = mixer(pixel.R, pixel.G, pixel.B);
                    Color p = Color.FromArgb(red, green, blue);
                    thumb.SetPixel(x, y, p);
                }
            }

            thumbRed = CopyThumbnailWithFilter(ColorFilters.RedFilter);
            thumbGreen = CopyThumbnailWithFilter(ColorFilters.GreenFilter);
            thumbBlue = CopyThumbnailWithFilter(ColorFilters.BlueFilter);
        }

        /// <summary>
        /// Changes layout of pixels in image according to defined rules in 'mixer'
        /// </summary>
        /// <param name="mixer">Method which returns new coordinates of pixel</param>
        /// <param name="changer">Method which returns controls for image traverse</param>
        public void ProcessLayout(LayoutMixer mixer, LayoutCoordinatesMaxValue changer)
        {
            (int xMax, int yMax) = changer(image.Width, image.Height);
            for (int x = 0; x < xMax; ++x)
            {
                for (int y = 0; y < yMax; ++y)
                {
                    (int newX, int newY) = mixer(x, y);
                    Color oldPixel = image.GetPixel(newX, newY);
                    image.SetPixel(newX, newY, image.GetPixel(x, y));
                    image.SetPixel(x, y, oldPixel);
                }
            }
        }

        public void ProcessThumbnailLayout(LayoutMixer mixer, LayoutCoordinatesMaxValue changer)
        {
            (int xMax, int yMax) = changer(thumb.Width, thumb.Height);
            for (int x = 0; x < xMax; ++x)
            {
                for (int y = 0; y < yMax; ++y)
                {
                    (int newX, int newY) = mixer(x, y);
                    Color oldPixel = thumb.GetPixel(newX, newY);
                    thumb.SetPixel(newX, newY, image.GetPixel(x, y));
                    thumb.SetPixel(x, y, oldPixel);
                }
            }
        }
    }
}
