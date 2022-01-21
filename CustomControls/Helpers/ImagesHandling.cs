using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using Media = System.Windows.Media;


namespace CustomControls
{
    public class RGBColors
    {
        public int red { get; set; }
        public int green { get; set; }
        public int blue { get; set; }
        public RGBColors(int r, int g, int b)
        {
            this.red = b;
            this.green = g;
            this.blue = r;
        }       
    }

    



    public static class ImagesHandling
    {

        public static void SetPathData(object sender, Geometry pathData)
        {
            IButton iButton = sender as IButton;
            iButton.CanvasContent = new Grid();
            iButton.CanvasContent.Children.Add(GetPathValues(iButton, pathData));
            iButton.Content = iButton.CanvasContent;
        }


        public static System.Windows.Shapes.Path GetPathValues(IButton customButton, Geometry data)
        {
          System.Windows.Shapes.Path path = new System.Windows.Shapes.Path();
          path.Data = data;
          path.Fill = customButton.Foreground;
          path.Stretch = Stretch.Uniform;
          path.Margin = customButton.MarginImage;
          return path;
        }

        public static float GetBrightnessFromMediaColor(this System.Windows.Media.Color c) =>
                     System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B).GetBrightness();

        public static System.Drawing.Color ConvertMediaToDrawingColor(this System.Windows.Media.Color mediaColor)
        {
            return System.Drawing.Color.FromArgb(mediaColor.A, mediaColor.R, mediaColor.G, mediaColor.B);
        }

        public static System.Windows.Media.Color ConvertDrawingToMediaColor(this System.Drawing.Color color)
        {
            return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

                
        public static System.Windows.Media.ImageSource ConvertBitmapToImageSource(System.Drawing.Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            try
            {
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            }
            finally { DeleteObject(handle); }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]

        public static extern bool DeleteObject([System.Runtime.InteropServices.In] IntPtr hObject);

        public static DropShadowEffect SetDropShadowEffect(System.Windows.Media.Color DropShadowEffectColorArrived)
        {
            DropShadowEffect myDropShadowEffectMouseOver = new DropShadowEffect();
            myDropShadowEffectMouseOver.Opacity = 1;
            myDropShadowEffectMouseOver.Color = DropShadowEffectColorArrived;
            myDropShadowEffectMouseOver.ShadowDepth = 0;
            myDropShadowEffectMouseOver.BlurRadius = 15;
            return myDropShadowEffectMouseOver;
        }        
        
        public static Media.Color ReturnInvertedMediaColor(Media.Color ColourToInvert)
        {
            return Media.Color.FromRgb((byte)~ColourToInvert.R, (byte)~ColourToInvert.G, (byte)~ColourToInvert.B);
        }

        public static System.Windows.Controls.Image ColorBitmapSourceIntoMediaColor(BitmapSource bitmapSource, Media.Color markColor)
        {
            int stride = (bitmapSource.PixelWidth * bitmapSource.Format.BitsPerPixel + 7) / 8;

            int length = stride * bitmapSource.PixelHeight;
            byte[] data = new byte[length];

            bitmapSource.CopyPixels(data, stride, 0);

            //normal
            for (int i = 0; i < length; i += 4)
            {
                if (data[i + 3] == 0) continue;
                data[i] = (byte)(ImagesHandling.GetHexFromMediaColor(markColor).red); //B
                data[i + 1] = (byte)(ImagesHandling.GetHexFromMediaColor(markColor).green); //G
                data[i + 2] = (byte)(ImagesHandling.GetHexFromMediaColor(markColor).blue); //R

            }

            // Create a new BitmapSource from the inverted pixel buffer

            return new System.Windows.Controls.Image
            {
                Source = BitmapSource.Create(
                     bitmapSource.PixelWidth, bitmapSource.PixelHeight,
                     bitmapSource.DpiX, bitmapSource.DpiY, bitmapSource.Format,
                     bitmapSource.Palette, data, stride)
            };


        }

        public static RGBColors GetHexFromMediaColor(Media.Color color)
        {
            var resultAsHex = String.Format("#{0}{1}{2}{3}"
                , color.A.ToString("X").Length == 1 ? String.Format("0{0}", color.A.ToString("X")) : color.A.ToString("X")
                , color.R.ToString("X").Length == 1 ? String.Format("0{0}", color.R.ToString("X")) : color.R.ToString("X")
                , color.G.ToString("X").Length == 1 ? String.Format("0{0}", color.G.ToString("X")) : color.G.ToString("X")
                , color.B.ToString("X").Length == 1 ? String.Format("0{0}", color.B.ToString("X")) : color.B.ToString("X"));

            System.Drawing.Color colorFinal = System.Drawing.ColorTranslator.FromHtml(resultAsHex);
            int r = Convert.ToInt16(colorFinal.R);
            int g = Convert.ToInt16(colorFinal.G);
            int b = Convert.ToInt16(colorFinal.B);

            return new RGBColors(r, g, b);
        }


    #region Unused functions

    //public static Image ColorReplace(this Image inputImage, int tolerance, System.Drawing.Color oldColor, System.Drawing.Color NewColor)
    //{
    //    Bitmap outputImage = new Bitmap(inputImage.Width, inputImage.Height);
    //    Graphics G = Graphics.FromImage(outputImage);
    //    G.DrawImage(inputImage, 0, 0);
    //    for (Int32 y = 0; y < outputImage.Height; y++)
    //        for (Int32 x = 0; x < outputImage.Width; x++)
    //        {
    //            System.Drawing.Color PixelColor = outputImage.GetPixel(x, y);
    //            if (PixelColor.R > oldColor.R - tolerance && PixelColor.R < oldColor.R + tolerance && PixelColor.G > oldColor.G - tolerance && PixelColor.G < oldColor.G + tolerance && PixelColor.B > oldColor.B - tolerance && PixelColor.B < oldColor.B + tolerance)
    //            {
    //                int RColorDiff = oldColor.R - PixelColor.R;
    //                int GColorDiff = oldColor.G - PixelColor.G;
    //                int BColorDiff = oldColor.B - PixelColor.B;

    //                if (PixelColor.R > oldColor.R) RColorDiff = NewColor.R + RColorDiff;
    //                else RColorDiff = NewColor.R - RColorDiff;
    //                if (RColorDiff > 255) RColorDiff = 255;
    //                if (RColorDiff < 0) RColorDiff = 0;
    //                if (PixelColor.G > oldColor.G) GColorDiff = NewColor.G + GColorDiff;
    //                else GColorDiff = NewColor.G - GColorDiff;
    //                if (GColorDiff > 255) GColorDiff = 255;
    //                if (GColorDiff < 0) GColorDiff = 0;
    //                if (PixelColor.B > oldColor.B) BColorDiff = NewColor.B + BColorDiff;
    //                else BColorDiff = NewColor.B - BColorDiff;
    //                if (BColorDiff > 255) BColorDiff = 255;
    //                if (BColorDiff < 0) BColorDiff = 0;

    //                outputImage.SetPixel(x, y, System.Drawing.Color.FromArgb(RColorDiff, GColorDiff, BColorDiff));
    //            }
    //        }
    //    return outputImage;
    //}
    //public static BitmapImage ToBitmapImage(this Bitmap bitmap)
    //{
    //    using (var memory = new MemoryStream())
    //    {
    //        bitmap.Save(memory, ImageFormat.Png);
    //        memory.Position = 0;

    //        var bitmapImage = new BitmapImage();
    //        bitmapImage.BeginInit();
    //        bitmapImage.StreamSource = memory;
    //        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
    //        bitmapImage.EndInit();
    //        return bitmapImage;
    //    }
    //}
    //public static BitmapSource Invert(BitmapSource source)
    //{
    //    // Calculate stride of source
    //    int stride = (source.PixelWidth * source.Format.BitsPerPixel + 7) / 8;

    //    // Create data array to hold source pixel data
    //    int length = stride * source.PixelHeight;
    //    byte[] data = new byte[length];

    //    // Copy source image pixels to the data array
    //    source.CopyPixels(data, stride, 0);

    //    // Change this loop for other formats
    //    for (int i = 0; i < length; i += 4)
    //    {
    //        data[i] = (byte)(255 - data[i]); //R
    //        data[i + 1] = (byte)(255 - data[i + 1]); //G
    //        data[i + 2] = (byte)(255 - data[i + 2]); //B
    //                                                 //data[i + 3] = (byte)(255 - data[i + 3]); //A
    //    }

    //    // Create a new BitmapSource from the inverted pixel buffer
    //    return BitmapSource.Create(
    //        source.PixelWidth, source.PixelHeight,
    //        source.DpiX, source.DpiY, source.Format,
    //        null, data, stride);
    //}

    //public static Image Invert_02(Image source)
    //{
    //    //create a blank bitmap the same size as original
    //    Bitmap newBitmap = new Bitmap(source.Width, source.Height);

    //    //get a graphics object from the new image
    //    Graphics g = Graphics.FromImage(newBitmap);

    //    // create the negative color matrix
    //    ColorMatrix colorMatrix = new ColorMatrix(new float[][]
    //           {
    //              new float[] {-1, 0, 0, 0, 0},
    //              new float[] {0, -1, 0, 0, 0},
    //              new float[] {0, 0, -1, 0, 0},
    //              new float[] {0, 0, 0, 1, 0},
    //              new float[] {1, 1, 1, 0, 1}
    //           });



    //    // create some image attributes
    //    ImageAttributes attributes = new ImageAttributes();

    //    attributes.SetColorMatrix(colorMatrix);

    //    g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height),
    //                0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attributes);

    //    //dispose the Graphics object
    //    g.Dispose();

    //    return newBitmap;
    //}

    //public static Bitmap BlackAndWhite(Bitmap image)
    //{
    //    return BlackAndWhite(image, new System.Drawing.Rectangle(0, 0, image.Width, image.Height));
    //}
    //private static Bitmap BlackAndWhite(Bitmap image, Rectangle rectangle)
    //{
    //    Bitmap blackAndWhite = new System.Drawing.Bitmap(image.Width, image.Height);

    //    // make an exact copy of the bitmap provided
    //    using (Graphics graphics = System.Drawing.Graphics.FromImage(blackAndWhite))
    //        graphics.DrawImage(image, new System.Drawing.Rectangle(0, 0, image.Width, image.Height),
    //            new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

    //    // for every pixel in the rectangle region
    //    for (Int32 xx = rectangle.X; xx < rectangle.X + rectangle.Width && xx < image.Width; xx++)
    //    {
    //        for (Int32 yy = rectangle.Y; yy < rectangle.Y + rectangle.Height && yy < image.Height; yy++)
    //        {
    //            // average the red, green and blue of the pixel to get a gray value
    //            System.Drawing.Color pixel = blackAndWhite.GetPixel(xx, yy);
    //            Int32 avg = (pixel.R + pixel.G + pixel.B) / 3;

    //            blackAndWhite.SetPixel(xx, yy, System.Drawing.Color.FromArgb(0, avg, avg, avg));
    //        }
    //    }

    //    return blackAndWhite;
    //}
    //public static Bitmap MakeGrayscale3(Bitmap original)
    //{
    //    //create a blank bitmap the same size as original
    //    Bitmap newBitmap = new Bitmap(original.Width, original.Height);

    //    //get a graphics object from the new image
    //    Graphics g = Graphics.FromImage(newBitmap);

    //    //create the grayscale ColorMatrix
    //    ColorMatrix colorMatrix = new ColorMatrix(
    //       new float[][]
    //       {
    // new float[] {.3f, .3f, .3f, 0, 0},
    // new float[] {.59f, .59f, .59f, 0, 0},
    // new float[] {.11f, .11f, .11f, 0, 0},
    // new float[] {0, 0, 0, 1, 0},
    // new float[] {0, 0, 0, 0, 1}
    //       });

    //    //create some image attributes
    //    ImageAttributes attributes = new ImageAttributes();

    //    //set the color matrix attribute
    //    attributes.SetColorMatrix(colorMatrix);

    //    //draw the original image on the new image
    //    //using the grayscale color matrix
    //    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
    //       0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

    //    //dispose the Graphics object
    //    g.Dispose();
    //    return newBitmap;
    //}

    #endregion


  }

}
