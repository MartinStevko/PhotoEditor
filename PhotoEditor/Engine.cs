using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace PhotoEditor
{
    /// <summary>
    /// Available image modes
    /// </summary>
    public enum ImageMode
    {
        /// <summary>
        /// Shows all colors
        /// </summary>
        Full,
        /// <summary>
        /// Shows only red spectra
        /// </summary>
        Red,
        /// <summary>
        /// Shows only green spectra
        /// </summary>
        Green,
        /// <summary>
        /// Shows only blue spectra
        /// </summary>
        Blue
    }

    /// <summary>
    /// Main engine for application
    /// </summary>
    public class ImageSet : IDisposable
    {
        #region Image set variables

        /// <summary>
        /// Image original filename
        /// </summary>
        public string filename;
        /// <summary>
        /// Original image
        /// </summary>
        private Bitmap origin;

        /// <summary>
        /// Main image - resized original
        /// </summary>
        public Bitmap image;
        /// <summary>
        /// Image view mode
        /// </summary>
        public ImageMode imageMode;
        /// <summary>
        /// Image area
        /// </summary>
        public Rectangle rectangle;

        /// <summary>
        /// Image thumbnail
        /// </summary>
        public Bitmap thumb;
        /// <summary>
        /// Image thumbnail with red color filtered
        /// </summary>
        public Bitmap thumbRed;
        /// <summary>
        /// Image thumbnail with green color filtered
        /// </summary>
        public Bitmap thumbGreen;
        /// <summary>
        /// Image thumbnail with blue color filtered
        /// </summary>
        public Bitmap thumbBlue;
        /// <summary>
        /// Image thumbnail area
        /// </summary>
        public Rectangle thumbRectangle;

        /// <summary>
        /// Image saturation level
        /// </summary>
        public int saturation;
        /// <summary>
        /// Image brightness level
        /// </summary>
        public int brightness;
        /// <summary>
        /// Image clarity level
        /// </summary>
        public int clarity;

        #endregion

        #region Loading essentials

        /// <summary>
        /// Initialize image set variables to its defaults
        /// </summary>
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

        /// <summary>
        /// Loads new image to application components
        /// </summary>
        /// <param name="file">Image name</param>
        /// <param name="width">Width of canvas in pixels</param>
        /// <param name="height">Height of canvas in pixels</param>
        /// <param name="thumbWidth">Width of thumbnail canvas in pixels</param>
        /// <param name="thumbHeight">Height of thumbnail canvas in pixels</param>
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

        /// <summary>
        /// Resizes source image (main or thumbnail) to required size
        /// </summary>
        /// <param name="toThumbnail">Boolean indicator whether resizing thumbnail or main image</param>
        /// <returns>Resized bitmap</returns>
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

        /// <summary>
        /// Shows main image with color filter
        /// </summary>
        /// <param name="mixer">Color filter</param>
        /// <returns>Bitmap with color filtered by filter from main image</returns>
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
                    for (int x = 0; x < widthInBytes; x += bytesPerPixel)
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

        /// <summary>
        /// Copies thumbnails for red, green and blue colors from main thumbnail
        /// </summary>
        /// <param name="mixer">Color filter</param>
        /// <returns>Thumbnail with filtered color</returns>
        public Bitmap CopyThumbnailWithFilter(ColorMixer mixer)
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
                    for (int x = 0; x < widthInBytes; x += bytesPerPixel)
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

        /// <summary>
        /// Resizes width and height preserving original aspect ration
        /// </summary>
        /// <param name="width">Canvas width in pixel</param>
        /// <param name="height">Canvas height in pixels</param>
        /// <param name="pWidth">Image width in pixels</param>
        /// <param name="pHeight">Image height in pixels</param>
        /// <returns>Tuple of new image width and height</returns>
        public static Tuple<int, int> PreserveAspectRation(int width, int height, int pWidth, int pHeight)
        {
            double xRatio = width / (double)pWidth;
            double yRatio = height / (double)pHeight;
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
        /// Dispose all sub images
        /// </summary>
        public void Dispose()
        {
            if (origin != null)
            {
                origin.Dispose();
            }
            if (image != null)
            {
                image.Dispose();
            }
            if (thumb != null)
            {
                thumb.Dispose();
            }
            if (thumbRed != null)
            {
                thumbRed.Dispose();
            }
            if (thumbGreen != null)
            {
                thumbGreen.Dispose();
            }
            if (thumbBlue != null)
            {
                thumbBlue.Dispose();
            }
        }

        #endregion

        #region Color processors

        /// <summary>
        /// Changes RGB value of each pixel according to the defined rules
        /// </summary>
        /// <param name="mixer">Function which calculate new RGB values</param>
        public void ProcessColor(ColorMixer mixer)
        {
            unsafe
            {
                BitmapData bitmapData = image.LockBits(rectangle, ImageLockMode.ReadWrite, image.PixelFormat);

                int bytesPerPixel = Bitmap.GetPixelFormatSize(image.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                    {
                        (byte red, byte green, byte blue) = mixer(currentLine[x + 2], currentLine[x + 1], currentLine[x]);

                        currentLine[x] = blue;
                        currentLine[x + 1] = green;
                        currentLine[x + 2] = red;
                    }
                });
                image.UnlockBits(bitmapData);
            }
        }

        /// <summary>
        /// Changes RGB value of each pixel according to the defined rules
        /// </summary>
        /// <param name="mixer">Function which calculate new RGB values</param>
        public void ProcessThumbnailColor(ColorMixer mixer)
        {
            unsafe
            {
                BitmapData bitmapData = thumb.LockBits(thumbRectangle, ImageLockMode.ReadWrite, thumb.PixelFormat);

                int bytesPerPixel = Bitmap.GetPixelFormatSize(thumb.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                    {
                        (byte red, byte green, byte blue) = mixer(currentLine[x + 2], currentLine[x + 1], currentLine[x]);

                        currentLine[x] = blue;
                        currentLine[x + 1] = green;
                        currentLine[x + 2] = red;
                    }
                });
                thumb.UnlockBits(bitmapData);
            }

            thumbRed = CopyThumbnailWithFilter(ColorFilters.RedFilter);
            thumbGreen = CopyThumbnailWithFilter(ColorFilters.GreenFilter);
            thumbBlue = CopyThumbnailWithFilter(ColorFilters.BlueFilter);
        }

        #endregion

        #region Layout processors

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

        /// <summary>
        /// Changes layout of pixels in image according to defined rules in 'mixer'
        /// </summary>
        /// <param name="mixer">Method which returns new coordinates of pixel</param>
        /// <param name="changer">Method which returns controls for image traverse</param>
        public void ProcessThumbnailLayout(LayoutMixer mixer, LayoutCoordinatesMaxValue changer)
        {
            (int xMax, int yMax) = changer(thumb.Width, thumb.Height);
            for (int x = 0; x < xMax; ++x)
            {
                for (int y = 0; y < yMax; ++y)
                {
                    (int newX, int newY) = mixer(x, y);
                    Color oldPixel = thumb.GetPixel(newX, newY);
                    thumb.SetPixel(newX, newY, thumb.GetPixel(x, y));
                    thumb.SetPixel(x, y, oldPixel);
                }
            }
        }

        #endregion
    }
}
