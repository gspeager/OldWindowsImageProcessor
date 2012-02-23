using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;

namespace ImageProcessor
{
    public class imageEdit
    {

        #region Variables

        public byte[,,] image; //main image that will be modified
        public byte[,,] extra; //extra array for mutliple image processing
        public float[,] normalize;
        private int iH, iW, eH, eW; //height and width of image

        OpenFileDialog OpenFD = new OpenFileDialog();

        private static DialogSelection ds = new DialogSelection();

        #endregion

        #region Constructors
       
        /// <summary>
        /// Simple Constructor
        /// </summary>
        public imageEdit()
        {
            iH = 0;
            iW = 0;
        }

        /// <summary>
        /// Constructor to fill out an image array and width and height
        /// </summary>
        /// <param name="b">Bitmap</param>
        unsafe public imageEdit(Bitmap b)
        {
            BitmapData bd = b.LockBits(
                new Rectangle(0, 0, b.Width, b.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb); ;

            iH = b.Height;
            iW = b.Width;

            image = new byte[iH, iW, 4];

            byte* p = (byte*)bd.Scan0;

            int offset = bd.Stride - iW * 3;

            for (int i = 0; i < iH; i++)
            {
                for (int j = 0; j < iW; j++)
                {
                    image[i, j, 2] = *(p++); //Blue
                    image[i, j, 1] = *(p++); //Green
                    image[i, j, 0] = *(p++); //Red
                    image[i, j, 3] = 0;      //Alpha
                }

                p += offset;
            }
            
            b.UnlockBits(bd);
        }

        /// <summary> 
        /// Copy Constructor
        /// </summary>
        /// <param name="pic">imageEdit</param>
        public imageEdit(imageEdit pic)
        {
            image = new byte[pic.getHeight(), pic.getWidth(), 3];
            iH = pic.getHeight();
            iW = pic.getWidth();

            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    this.image[i, j, 0] = pic.image[i, j, 0];
                    this.image[i, j, 1] = pic.image[i, j, 1];
                    this.image[i, j, 2] = pic.image[i, j, 2];
                    this.image[i, j, 3] = pic.image[i, j, 3];
                }
        }

        #endregion

        #region Value Functions

        /// <summary>
        /// Returns the height of the image
        /// </summary>
        /// <returns>int iH</returns>
        public int getHeight()
        {
            return iH;
        }
        
        /// <summary>
        /// Returns the width of the image
        /// </summary>
        /// <returns>int iH</returns>
        public int getWidth()
        {
            return iW;
        }
        /// <summary>
        /// Sets the height of the image
        /// </summary>
        /// <param name="h">Int height of the image</param>
        public void setHeight(int h)
        {
            iH = h;
        }

        /// <summary>
        /// Sets the width of the image
        /// </summary>
        /// <param name="w">Int width of image</param>
        public void setWidth(int w)
        {
            iW = w;
        }

        /// <summary>
        /// Returns red value at a point in the image
        /// </summary>
        /// <param name="x">x or horizontal position</param>
        /// <param name="y">y or vertical position</param>
        /// <returns>(byte)Red value at (x,y)</returns>
        public byte getR(int x, int y)
        {
            return image[y, x, 0];
        }

        /// <summary>
        /// Returns Green value at a point in the image
        /// </summary>
        /// <param name="x">x or horizontal position</param>
        /// <param name="y">y or vertical position</param>
        /// <returns>(byte)Green value at (x,y)</returns>
        public byte getG(int x, int y)
        {
            return image[y, x, 1];
        }

        /// <summary>
        /// Returns Blue value at a point in the image
        /// </summary>
        /// <param name="x">x or horizontal position</param>
        /// <param name="y">y or vertical position</param>
        /// <returns>(byte)Blue value at (x,y)</returns>
        public byte getB(int x, int y)
        {
            return image[y, x, 2];
        }

        /// <summary>
        /// Gets an Integer
        /// </summary>
        /// <param name="caption">Dialog Title</param>
        /// <param name="text">Dialog Message</param>
        /// <returns></returns>
        private int GetInt(string caption, string text)
        {

            ds.Init(caption, text);

            while (true)
                try
                {
                    if (ds.ShowDialog() == DialogResult.Cancel) return -1;

                    return int.Parse(ds.GetValue);
                }
                catch (Exception)
                {
                    continue;
                }
        }


        /// <summary>
        /// Clamps an integer value into a byte's range.
        /// </summary>
        /// <param name="x">The integer to clamp.</param>
        /// <returns>The converted byte.</returns>
        public static byte Clamp(int x)
        {
            if (x > 255)
                x = 255;
            else if (x < 0)
                x = 0;

            return (byte)x;
        }

        /// <summary>
        /// Clamps a value between two other values.
        /// </summary>
        /// <param name="x">The number to clamp.</param>
        /// <param name="low">The lower bound.</param>
        /// <param name="high">The higher bound.</param>
        /// <returns>The clamped integer.</returns>
        public static int Clamp(int x, int low, int high)
        {
            if (x < low)
                return low;
            if (x > high)
                return high;
            return x;
        }

        /// <summary>
        /// Clamps a float value into a byte's range.
        /// </summary>
        /// <param name="x">The float to clamp.</param>
        /// <returns>The converted byte.</returns>
        public static byte Clamp(float x)
        {
            return Clamp((int)x);
        }

        #endregion

        #region Bitmap Functions

        /// <summary>
        /// Load Bitmap data into direct memory
        /// </summary>
        /// <param name="b">Bitmap to be loaded into memory</param>
        unsafe public void LoadFromBitmap(ref Bitmap b)
        {
            BitmapData bd = b.LockBits(
                new Rectangle(0, 0, b.Width, b.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            
            iH = b.Height;
            iW = b.Width;

            image = new byte[iH, iW, 4];

            byte* p = (byte*)bd.Scan0;

            int offset = bd.Stride - iW * 3;

            for (int i = 0; i < iH; i++)
            {
                for (int j = 0; j < iW; j++)
                {
                    image[i, j, 2] = *(p++); //Blue
                    image[i, j, 1] = *(p++); //Green
                    image[i, j, 0] = *(p++); //Red
                    image[i, j, 3] = 0;      //Alpha
                }

                p += offset;
            }

            b.UnlockBits(bd);
        }

        /// <summary>
        /// Updates a Bitmap with image data
        /// </summary>
        /// <param name="b">Bitmap to be filled</param>
        unsafe public void UpdateBitmap(ref Bitmap b)
        {

            if (image == null) 
                return;

            if (b != null)
                b.Dispose();

            b = new Bitmap(iW, iH);

            BitmapData bd = b.LockBits(
                new Rectangle(0, 0, b.Width, b.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            byte* p = (byte*)bd.Scan0;

            int offset = bd.Stride - bd.Width * 3;

            for (int i = 0; i < iH; i++)
            {
                for (int j = 0; j < iW; j++)
                {
                    *(p++) = image[i, j, 2]; //Blue
                    *(p++) = image[i, j, 1]; //Green
                    *(p++) = image[i, j, 0]; //Red
                }
                p += offset;
            }
            b.UnlockBits(bd);
        }

        /// <summary>
        /// Fill Extra Array for Multiple Image processing
        /// </summary>
        unsafe public void FillExtra()
        {
            OpenFD.Title = "Open Image for Processing";
            OpenFD.InitialDirectory = "g:\\";
            OpenFD.Filter = "PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|Bitmap files (*.bmp)|*.bmp|JPG files (*.jpg)|*.jpg|All Valid Files (*.bmp/*.jpg/*.gif/*.png)|*.bmp;*.jpg;*.gif;*.png";
            OpenFD.FilterIndex = 5;
            OpenFD.RestoreDirectory = true;

            if (DialogResult.OK == OpenFD.ShowDialog())
            {
                try
                {
                    Bitmap map = (Bitmap)Image.FromFile(OpenFD.FileName);

                    BitmapData bd = map.LockBits(
                        new Rectangle(0, 0, map.Width, map.Height),
                        ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                    eW = map.Width;
                    eH = map.Height;

                    extra = new byte[eH, eW, 4];

                    byte* p = (byte*)bd.Scan0;

                    int offset = bd.Stride - eW * 3;

                    for (int i = 0; i < eH; i++)
                    {
                        for (int j = 0; j < eW; j++)
                        {
                            extra[i, j, 2] = *(p++); //Blue
                            extra[i, j, 1] = *(p++); //Green
                            extra[i, j, 0] = *(p++); //Red
                            extra[i, j, 3] = 0;      //Alpha
                        }

                        p += offset;
                    }
                    map.UnlockBits(bd);
                    map.Dispose();
                }
                catch
                {
                    MessageBox.Show("Error opening image", "Expose", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Per Pixel Functions

        #region Flips

        /// <summary>
        /// Flips the Image on the Y-axis
        /// </summary>
        public void FlipH()
        {
            byte[, ,] d = new byte[iH, iW, 4];

            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    d[i, j, 0] = image[i, iW - j - 1, 0]; //Red
                    d[i, j, 1] = image[i, iW - j - 1, 1]; //Green
                    d[i, j, 2] = image[i, iW - j - 1, 2]; //Blue
                    d[i, j, 3] = 0;
                }

            image = d;
        }

        /// <summary>
        /// Flips the Image on the X-axis
        /// </summary>
        public void FlipV()
        {
            byte[, ,] d = new byte[iH, iW, 4];

            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    d[i, j, 0] = image[iH - i - 1, j, 0]; //Red
                    d[i, j, 1] = image[iH - i - 1, j, 1]; //Green
                    d[i, j, 2] = image[iH - i - 1, j, 2]; //Blue
                    d[i, j, 3] = 0;
                }

            image = d;
        }

        #endregion

        /// <summary>
        /// Inverts the value of each pixel
        /// </summary>
        public void Invert()
        {
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    image[i, j, 0] = (byte)(255 - image[i, j, 0]); //Red
                    image[i, j, 1] = (byte)(255 - image[i, j, 1]); //Green
                    image[i, j, 2] = (byte)(255 - image[i, j, 2]); //Blue
                }
        }

        /// <summary>
        /// Converts the image to Greyscale
        /// </summary>
        public void GreyScale()
        {
            byte tot;
            
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    tot = (byte)(.299 * image[i, j, 0] + .587 * image[i, j, 0] + .114 * image[i, j, 0]);

                    image[i, j, 0] = tot; //Red
                    image[i, j, 1] = tot; //Green
                    image[i, j, 2] = tot; //Blue
                }
        }

        /// <summary>
        /// Increases or Decreases the brightness of the image
        /// </summary>
        /// <param name="br">Brightness value</param>
        public void Brightness(int br)
        {
            int nVal = 0;

            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    //Red
                    nVal = (image[i, j, 0] + br);
                    if (nVal < 0) nVal = 0;
                    if (nVal > 255) nVal = 255;
                    image[i, j, 0] = (byte)nVal;
                    //Green
                    nVal = (image[i, j, 1] + br);
                    if (nVal < 0) nVal = 0;
                    if (nVal > 255) nVal = 255;
                    image[i, j, 1] = (byte)nVal;
                    //Blue
                    nVal = (image[i, j, 2] + br);
                    if (nVal < 0) nVal = 0;
                    if (nVal > 255) nVal = 255;
                    image[i, j, 2] = (byte)nVal;
                }
        }

        /// <summary>
        /// Increases or Decreases the contrast of the image
        /// </summary>
        /// <param name="con">Contrast value</param>
        public void Contrast(int con)
        {
            double pixel = 0, contrast = (100.0 + con) / 100.0;

            contrast *= contrast;

            byte red, green, blue;

            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    red = image[i, j, 0];
                    green = image[i, j, 1];
                    blue = image[i, j, 2];
                    //Red
                    pixel = red / 255.0;
                    pixel -= 0.5;
                    pixel *= contrast;
                    pixel += 0.5;
                    pixel *= 255;
                    if (pixel < 0) pixel = 0;
                    if (pixel > 255) pixel = 255;
                    image[i, j, 0] = (byte)pixel;
                    //Green
                    pixel = green / 255.0;
                    pixel -= 0.5;
                    pixel *= contrast;
                    pixel += 0.5;
                    pixel *= 255;
                    if (pixel < 0) pixel = 0;
                    if (pixel > 255) pixel = 255;
                    image[i, j, 1] = (byte)pixel;
                    //Blue
                    pixel = blue / 255.0;
                    pixel -= 0.5;
                    pixel *= contrast;
                    pixel += 0.5;
                    pixel *= 255;
                    if (pixel < 0) pixel = 0;
                    if (pixel > 255) pixel = 255;
                    image[i, j, 2] = (byte)pixel;
                }
        }

        /// <summary>
        /// Corrects Gamma levels of the image
        /// </summary>
        /// <param name="gam">Gamma level</param>
        public void GammaCorrection(double gam)
        {
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    //Red
                    image[i, j, 0] = (byte)(255 * Math.Pow((double)(image[i, j, 0] / 255), gam));
                    //Green
                    image[i, j, 1] = (byte)(255 * Math.Pow((double)(image[i, j, 1] / 255), gam));
                    //Blue
                    image[i, j, 2] = (byte)(255 * Math.Pow((double)(image[i, j, 2] / 255), gam));
                }
        }

        #region Color Adjustments

        /// <summary>
        /// Adjusts Color levels of an image
        /// </summary>
        /// <param name="red">Value to adjust Red levels</param>
        /// <param name="green">Value to adjust Green levels</param>
        /// <param name="blue">Value to adjust Blue levels</param>
        public void AdjustColor(int red, int green, int blue)
        {
            int value = 0;
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    //Red
                    value = image[i, j, 0] + red;
                    if (value > 255) value = 255;
                    if (value < 0) value = 0;
                    image[i, j, 0] = (byte)value;
                    //Green
                    value = image[i, j, 1] + green;
                    if (value > 255) value = 255;
                    if (value < 0) value = 0;
                    image[i, j, 1] = (byte)value;
                    //Blue
                    value = image[i, j, 2] + blue;
                    if (value > 255) value = 255;
                    if (value < 0) value = 0;
                    image[i, j, 2] = (byte)value;
                }    
        }

        /// <summary>
        /// Adjusts Red level
        /// </summary>
        /// <param name="red">Value to modify Red</param>
        public void AdjustRed(int red)
        {
            int value = 0;
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    //Red
                    value = image[i, j, 0] + red;
                    if (value > 255) value = 255;
                    if (value < 0) value = 0;
                    image[i, j, 0] = (byte)value;
                }
        }

        /// <summary>
        /// Adjusts Green level
        /// </summary>
        /// <param name="green">Value to modify Green</param>
        public void AdjustGreen(int green)
        {
            int value = 0;
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    //Green
                    value = image[i, j, 1] + green;
                    if (value > 255) value = 255;
                    if (value < 0) value = 0;
                    image[i, j, 1] = (byte)value;
                }
        }
        
        /// <summary>
        /// Adjusts Blue level
        /// </summary>
        /// <param name="blue">Value to modify Blue</param>
        public void AdjustColor(int blue)
        {
            int value = 0;
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    //Blue
                    value = image[i, j, 2] + blue;
                    if (value > 255) value = 255;
                    if (value < 0) value = 0;
                    image[i, j, 2] = (byte)value;
                }
        }

        #endregion

        /// <summary>
        /// Takes an image and stretches is color range
        /// to be from 0 to 255
        /// </summary>
        public void ContrastStretch()
        {
            int rMax = 0, gMax = 0, bMax = 0;
            int rMin = 255, gMin = 255, bMin = 255;

            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    if (rMax < image[i, j, 0])
                        rMax = image[i, j, 0];
                    if (rMin > image[i, j, 0])
                        rMin = image[i, j, 0];
                    if (gMax < image[i, j, 1])
                        gMax = image[i, j, 1];
                    if (gMin > image[i, j, 1])
                        gMin = image[i, j, 1];
                    if (bMax < image[i, j, 2])
                        bMax = image[i, j, 2];
                    if (bMin > image[i, j, 2])
                        bMin = image[i, j, 2];
                }

            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    //Red
                    image[i, j, 0] = (byte)((float)(image[i, j, 0] - rMin) * (float)(255f / (float)(rMax - rMin)));
                    //Green
                    image[i, j, 1] = (byte)((float)(image[i, j, 1] - gMin) * (float)(255f / (float)(gMax - gMin)));
                    //Blue
                    image[i, j, 2] = (byte)((float)(image[i, j, 2] - bMin) * (float)(255f / (float)(bMax - bMin)));
                }
        }

        #region Parabolic Functions

        /// <summary>
        /// Applies a Parabolic function to each pixel
        /// </summary>
        public void Parabol()
        {
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    //Red
                    image[i, j, 0] = (byte)(255 * Math.Pow((float)(image[i, j, 0]) / 128f - 1f, 2));
                    //Green
                    image[i, j, 1] = (byte)(255 * Math.Pow((float)(image[i, j, 1]) / 128f - 1f, 2));
                    //Blue
                    image[i, j, 2] = (byte)(255 * Math.Pow((float)(image[i, j, 2]) / 128f - 1f, 2));
                }
        }

        /// <summary>
        /// Applies an inverse Parabolic function to each pixel
        /// </summary>
        public void InverseParabol()
        {
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    //Red
                    image[i, j, 0] = (byte)(255 - (255 * Math.Pow((float)(image[i, j, 0]) / 128f - 1f, 2)));
                    //Green
                    image[i, j, 1] = (byte)(255 - (255 * Math.Pow((float)(image[i, j, 1]) / 128f - 1f, 2)));
                    //Blue
                    image[i, j, 2] = (byte)(255 - (255 * Math.Pow((float)(image[i, j, 2]) / 128f - 1f, 2)));
                }
        }

        #endregion

        /// <summary>
        /// Changes the values of pixels within the range (lower-higher)
        /// </summary>
        /// <param name="lower">Lower Bound</param>
        /// <param name="upper">Upper Bound</param>
        /// <param name="val">Value to change pixels to</param>
        public void BrightnessSlice(int lower, int upper, byte val)
        {
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {   
                    //Red
                    if (image[i, j, 0] >= lower && image[i, j, 0] <= upper)
                        image[i, j, 0] = val;
                    //Green
                    if (image[i, j, 1] >= lower && image[i, j, 1] <= upper)
                        image[i, j, 1] = val;
                    //Blue
                    if (image[i, j, 2] >= lower && image[i, j, 2] <= upper)
                        image[i, j, 2] = val;
                }
        }

        #region Bit Masks

        /// <summary>
        /// Performs AND operation on each pixel
        /// </summary>
        /// <param name="mask">value to AND with pixel Value</param>
        public void AndMask(byte mask)
        {
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    image[i, j, 0] = (byte)(image[i, j, 0] & mask);//Red
                    image[i, j, 1] = (byte)(image[i, j, 1] & mask);//Green
                    image[i, j, 2] = (byte)(image[i, j, 2] & mask);//Blue
                }
        }

        /// <summary>
        /// Performs OR operation on each pixel
        /// </summary>
        /// <param name="mask">value to OR with pixel Value</param>
        public void ORMask(byte mask)
        {
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    image[i, j, 0] = (byte)(image[i, j, 0] | mask);//Red
                    image[i, j, 1] = (byte)(image[i, j, 1] | mask);//Green
                    image[i, j, 2] = (byte)(image[i, j, 2] | mask);//Blue
                }
        }

        /// <summary>
        /// Performs XOR operation ot each pixel
        /// </summary>
        /// <param name="mask">value to XOR with pixel Value</param>
        public void XORMask(byte mask)
        {
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    image[i, j, 0] = (byte)(image[i, j, 0] ^ mask);//Red
                    image[i, j, 1] = (byte)(image[i, j, 1] ^ mask);//Green
                    image[i, j, 2] = (byte)(image[i, j, 2] ^ mask);//Blue
                }
        }

        #endregion

        #region Flip Low and High 

        /// <summary>
        /// Make all 0 pixels = 255
        /// </summary>
        public void FlipLowToHigh()
        {
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    //Red
                    if (image[i, j, 0] == 0)
                        image[i, j, 0] = 255;
                    //Green
                    if (image[i, j, 1] == 0)
                        image[i, j, 1] = 255;
                    //Blue
                    if (image[i, j, 2] == 0)
                        image[i, j, 2] = 255;
                }
        }

        /// <summary>
        /// make all 255 pixels = 0;
        /// </summary>
        public void FlipHighToLow()
        {
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    //Red
                    if (image[i, j, 0] == 255)
                        image[i, j, 0] = 0;
                    //Green
                    if (image[i, j, 1] == 255)
                        image[i, j, 1] = 0;
                    //Blue
                    if (image[i, j, 2] == 255)
                        image[i, j, 2] = 0;
                }
        }

        #endregion

        #region 90 Degree Rotates

        /// <summary>
        /// Rotates the Image 90 degrees Clockwise
        /// </summary>
        public void RotateClockwise()
        {
            byte[, ,] d = new byte[iW, iH, 4];

            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    d[j, iH - 1 - i, 0] = image[i, j, 0];//Red
                    d[j, iH - 1 - i, 1] = image[i, j, 1];//Green
                    d[j, iH - 1 - i, 2] = image[i, j, 2];//Blue
                    d[j, iH - 1 - i, 3] = 0;
                }

            int c = iH;
            iH = iW;
            iW = c;

            image = d;
        }

        /// <summary>
        /// Rotates the image 90 degrees counter clockwise
        /// </summary>
        public void RotateCClockwise()
        {
            byte[, ,] d = new byte[iW, iH, 4];

            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    d[iW - 1 - j, i, 0] = image[i, j, 0];//Red
                    d[iW - 1 - j, i, 1] = image[i, j, 1];//Green
                    d[iW - 1 - j, i, 2] = image[i, j, 2];//Blue
                    d[iW - 1 - j, i, 3] = 0;
                }

            int c = iH;
            iH = iW;
            iW = c;

            image = d;
        }

        #endregion

        /// <summary>
        /// Adds Pixel Noise to an image
        /// </summary>
        /// <param name="amt">Amount of image to Corrupt</param>
        /// <param name="val">Pixel value of Corruption</param>
        public void AddNoise(int amt, byte val)
        {
            Random RandomClass = new Random();
            int rNumber = 0;

            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    rNumber = RandomClass.Next(1, 100);
                    if (rNumber <= amt)
                    {
                        image[i, j, 0] = val;//Red
                        image[i, j, 1] = val;//Green
                        image[i, j, 2] = val;//Blue
                    }
                }
        }

        /// <summary>
        /// Cuts the image into 2 values based on a thresh hold
        /// </summary>
        /// <param name="val">Threshold value</param>
        public void BinaryThreshold(byte val)
        {

            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    image[i, j, 0] = (image[i, j, 0] < val) ? (byte)0 : (byte)255;//Red
                    image[i, j, 1] = (image[i, j, 1] < val) ? (byte)0 : (byte)255;//Green
                    image[i, j, 2] = (image[i, j, 2] < val) ? (byte)0 : (byte)255;//Blue
                }
        }

        #region Multiple Images

        /// <summary>
        /// Blends with another Image using an alpha value
        /// </summary>
        /// <param name="alpha">Alpha Value for blending</param>
        public void AlphaBlend(float alpha)
        {
            FillExtra();
            try
            {
                int minH = (iH <= eH) ? iH : eH;
                int minW = (iW <= eW) ? iW : eW;

                for (int i = 0; i < minH; i++)
                    for (int j = 0; j < minW; j++)
                    {
                        //Red
                        image[i, j, 0] = (byte)(alpha * (float)image[i, j, 0] + (1 - alpha) * (float)extra[i, j, 0]);
                        //Green
                        image[i, j, 1] = (byte)(alpha * (float)image[i, j, 1] + (1 - alpha) * (float)extra[i, j, 1]);
                        //Blue
                        image[i, j, 2] = (byte)(alpha * (float)image[i, j, 2] + (1 - alpha) * (float)extra[i, j, 2]);
                    }
                extra = null;
            }
            catch { }
        }

        /// <summary>
        /// Gets the difference with another image
        /// </summary>
        public void ImageDifferencing()
        {
            FillExtra();
            try
            {
                int minH = (iH <= eH) ? iH : eH;
                int minW = (iW <= eW) ? iW : eW;

                for (int i = 0; i < minH; i++)
                    for (int j = 0; j < minW; j++)
                    {
                        //Red
                        image[i, j, 0] = (byte)(image[i, j, 0] - ((int)extra[i, j, 0] + 255 / 2));
                        //Green
                        image[i, j, 1] = (byte)(image[i, j, 1] - ((int)extra[i, j, 1] + 255 / 2));
                        //Blue
                        image[i, j, 2] = (byte)(image[i, j, 2] - ((int)extra[i, j, 2] + 255 / 2));
                    }
                extra = null;
            }
            catch { }
        }

        /// <summary>
        /// Finds the Ratio with another image
        /// </summary>
        public void ImageRatio()
        {
            FillExtra();
            try
            {

                int minH = (iH <= eH) ? iH : eH;
                int minW = (iW <= eW) ? iW : eW;

                float rat;

                for (int i = 0; i < minH; i++)
                    for (int j = 0; j < minW; j++)
                    {
                        //Red
                        rat = (float)image[i, j, 0] * (float)((float)image[i, j, 0] / (float)extra[i, j, 0]);
                        image[i, j, 0] = (rat > 255) ? (byte)255 : (byte)rat;
                        //Green
                        rat = (float)image[i, j, 1] * (float)((float)image[i, j, 1] / (float)extra[i, j, 1]);
                        image[i, j, 1] = (rat > 255) ? (byte)255 : (byte)rat;
                        //Blue
                        rat = (float)image[i, j, 2] * (float)((float)image[i, j, 2] / (float)extra[i, j, 2]);
                        image[i, j, 2] = (rat > 255) ? (byte)255 : (byte)rat;
                    }
                extra = null;
            }
            catch { }
        }

        /// <summary>
        /// And Image with another Image
        /// </summary>
        public void ImageAnd()
        {
            FillExtra();
            try
            {
                int minH = (iH <= eH) ? iH : eH;
                int minW = (iW <= eW) ? iW : eW;

                for (int i = 0; i < minH; i++)
                    for (int j = 0; j < minW; j++)
                    {
                        //Red
                        image[i, j, 0] = (byte)(image[i, j, 0] & extra[i, j, 0]);
                        //Green
                        image[i, j, 1] = (byte)(image[i, j, 1] & extra[i, j, 1]);
                        //Blue
                        image[i, j, 2] = (byte)(image[i, j, 2] & extra[i, j, 2]);
                    }
                extra = null;
            }
            catch { }
        }

        /// <summary>
        /// OR Image with another image
        /// </summary>
        public void ImageOR()
        {
            FillExtra();
            try
            {
                int minH = (iH <= eH) ? iH : eH;
                int minW = (iW <= eW) ? iW : eW;

                for (int i = 0; i < minH; i++)
                    for (int j = 0; j < minW; j++)
                    {
                        //Red
                        image[i, j, 0] = (byte)(image[i, j, 0] | extra[i, j, 0]);
                        //Green
                        image[i, j, 1] = (byte)(image[i, j, 1] | extra[i, j, 1]);
                        //Blue
                        image[i, j, 2] = (byte)(image[i, j, 2] | extra[i, j, 2]);
                    }
                extra = null;
            }
            catch { }
        }

        /// <summary>
        /// XOR Image with another image
        /// </summary>
        public void ImageXOR()
        {
            FillExtra();
            try
            {

                int minH = (iH <= eH) ? iH : eH;
                int minW = (iW <= eW) ? iW : eW;

                for (int i = 0; i < minH; i++)
                    for (int j = 0; j < minW; j++)
                    {
                        //Red
                        image[i, j, 0] = (byte)(image[i, j, 0] ^ extra[i, j, 0]);
                        //Green
                        image[i, j, 1] = (byte)(image[i, j, 1] ^ extra[i, j, 1]);
                        //Blue
                        image[i, j, 2] = (byte)(image[i, j, 2] ^ extra[i, j, 2]);
                    }
                extra = null;
            }
            catch { }
        }

        /// <summary>
        /// Average an Image with another image
        /// </summary>
        public void ImageAverage()
        {
            FillExtra();
            try
            {
                int minH = (iH <= eH) ? iH : eH;
                int minW = (iW <= eW) ? iW : eW;

                for (int i = 0; i < minH; i++)
                    for (int j = 0; j < minW; j++)
                    {
                        //Red
                        image[i, j, 0] = (byte)((image[i, j, 0] + extra[i, j, 0]) / 2);
                        //Green
                        image[i, j, 1] = (byte)((image[i, j, 1] + extra[i, j, 1]) / 2);
                        //Blue
                        image[i, j, 2] = (byte)((image[i, j, 2] + extra[i, j, 2]) / 2);
                    }
                extra = null;
            }
            catch { }
        }

        #endregion

        #endregion

        #region Spatial Filters

        #region Low Pass 3x3

        /// <summary>
        /// Gets mean with 3 x 3 neighborhood
        /// </summary>
        /// <param name="tl">Top Left</param>
        /// <param name="tm">Top Middle</param>
        /// <param name="tr">Top Right</param>
        /// <param name="cl">Center Left</param>
        /// <param name="cm">Center Middle</param>
        /// <param name="cr">Center Right</param>
        /// <param name="bl">Bottom Left</param>
        /// <param name="bm">Bottom Middle</param>
        /// <param name="br">Bottom Right</param>
        public void Low3Filter(byte tl, byte tm, byte tr,
                                byte cl, byte cm, byte cr,
                                byte bl, byte bm, byte br, Child c)
        {
            c.pappy.TSProgress.Minimum = 0;//Interface Junk
            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Maximum = (iH) * (iW);//Interface Junk

            extra = new byte[iH, iW, 4];
            int total = 0;
            int sumR = 0, sumG = 0, sumB = 0;

            c.pappy.TSProgress.Visible = true;//Interface Junk
            for (int i = 0; i < iH; i++)
            {
                for (int j = 0; j < iW; j++)
                {
                    if (i != 0 && j != 0)//top left
                    {
                        sumR += tl * image[i - 1, j - 1, 0];
                        sumG += tl * image[i - 1, j - 1, 1];
                        sumB += tl * image[i - 1, j - 1, 2];
                        total += tl;
                    }
                    if (i != 0)//top middle
                    {
                        sumR += tm * image[i - 1, j, 0];
                        sumG += tm * image[i - 1, j, 1];
                        sumB += tm * image[i - 1, j, 2];
                        total += tm;
                    }
                    if (i != 0 && j != iW - 1)//top right
                    {
                        sumR += tr * image[i - 1, j + 1, 0];
                        sumG += tr * image[i - 1, j + 1, 1];
                        sumB += tr * image[i - 1, j + 1, 2];
                        total += tr;
                    }
                    if (j != 0)//center left
                    {
                        sumR += cl * image[i, j - 1, 0];
                        sumG += cl * image[i, j - 1, 1];
                        sumB += cl * image[i, j - 1, 2];
                        total += cl;
                    }
                    if (j != iW - 1)//center right
                    {
                        sumR += cr * image[i, j + 1, 0];
                        sumG += cr * image[i, j + 1, 1];
                        sumB += cr * image[i, j + 1, 2];
                        total += cr;
                    }
                    if (i != iH - 1 && j != 0)//bottom left
                    {
                        sumR += bl * image[i + 1, j - 1, 0];
                        sumG += bl * image[i + 1, j - 1, 1];
                        sumB += bl * image[i + 1, j - 1, 2];
                        total += bl;
                    }
                    if (i != iH - 1)//bottom middle
                    {
                        sumR += bm * image[i + 1, j, 0];
                        sumG += bm * image[i + 1, j, 1];
                        sumB += bm * image[i + 1, j, 2];
                        total += bm;
                    }
                    if (i != iH - 1 && j != iW - 1)//bottom right
                    {
                        sumR += br * image[i + 1, j + 1, 0];
                        sumG += br * image[i + 1, j + 1, 1];
                        sumB += br * image[i + 1, j + 1, 2];
                        total += br;
                    }
                    sumR += cm * image[i, j, 0];
                    sumG += cm * image[i, j, 1];
                    sumB += cm * image[i, j, 2];
                    total += cm;

                    extra[i, j, 0] = (byte)((float)sumR / (float)total);
                    extra[i, j, 1] = (byte)((float)sumG / (float)total);
                    extra[i, j, 2] = (byte)((float)sumB / (float)total);
                    extra[i, j, 3] = 0;

                    sumR = 0;
                    sumG = 0;
                    sumB = 0;
                    total = 0;

                    c.pappy.TSProgress.Value++;//Interface Junk
                }
            }

            image = extra;

            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Visible = false;//Interface Junk
        }

        #endregion

        #region Accidents

        /// <summary>
        /// Neat Mistake
        /// </summary>
        /// <param name="tl">Top Left</param>
        /// <param name="tm">Top Middle</param>
        /// <param name="tr">Top Right</param>
        /// <param name="cl">Center Left</param>
        /// <param name="cm">Center Middle</param>
        /// <param name="cr">Center Right</param>
        /// <param name="bl">Bottom Left</param>
        /// <param name="bm">Bottom Middle</param>
        /// <param name="br">Bottom Right</param>
        public void HorizBlur(byte tl, byte tm, byte tr,
                              byte cl, byte cm, byte cr,
                              byte bl, byte bm, byte br, Child c)
        {
            c.pappy.TSProgress.Minimum = 0;//Interface Junk
            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Maximum = (iH) * (iW);//Interface Junk

            int total = 0;
            int sumR = 0, sumG = 0, sumB = 0;

            c.pappy.TSProgress.Visible = true;//Interface Junk
            for (int i = 0; i < iH; i++)
            {
                for (int j = 0; j < iW; j++)
                {
                    if (i != 0 && j != 0)
                    {
                        sumR += tl * image[i - 1, j - 1, 0];
                        sumG += tl * image[i - 1, j - 1, 1];
                        sumB += tl * image[i - 1, j - 1, 2];
                        total += tl;
                    }
                    if (i != 0)
                    {
                        sumR += tl * image[i - 1, j, 0];
                        sumG += tl * image[i - 1, j, 1];
                        sumB += tl * image[i - 1, j, 2];
                        total += tm;
                    }
                    if (i != 0 && j != iW - 1)
                    {
                        sumR += tr * image[i - 1, j + 1, 0];
                        sumG += tr * image[i - 1, j + 1, 1];
                        sumB += tr * image[i - 1, j + 1, 2];
                        total += tr;
                    }
                    if (j != 0)
                    {
                        sumR += cl * image[i, j - 1, 0];
                        sumG += cl * image[i, j - 1, 1];
                        sumB += tr * image[i, j - 1, 2];
                        total += cl;
                    }
                    if (j != iW - 1)
                    {
                        sumR += cl * image[i, j + 1, 0];
                        sumG += cl * image[i, j + 1, 1];
                        sumB += tr * image[i, j + 1, 2];
                        total += cr;
                    }
                    if (i != iH - 1 && j != 0)
                    {
                        sumR += bl * image[i + 1, j - 1, 0];
                        sumG += bl * image[i + 1, j - 1, 1];
                        sumB += bl * image[i + 1, j - 1, 2];
                        total += bl;
                    }
                    if (i != iH - 1)
                    {
                        sumR += bm * image[i + 1, j, 0];
                        sumG += bm * image[i + 1, j, 1];
                        sumB += bm * image[i + 1, j, 2];
                        total += bm;
                    }
                    if (i != iH - 1 && j != iW - 1)
                    {
                        sumR += br * image[i + 1, j + 1, 0];
                        sumG += br * image[i + 1, j + 1, 1];
                        sumB += br * image[i + 1, j + 1, 2];
                        total += br;
                    }
                    sumR += cm * image[i, j, 0];
                    sumG += cm * image[i, j, 1];
                    sumB += cm * image[i, j, 2];
                    total += cm;

                    image[i, j, 0] = (byte)(sumR / total);
                    image[i, j, 1] = (byte)(sumG / total);
                    image[i, j, 2] = (byte)(sumB / total);

                    c.pappy.TSProgress.Value++;//Interface Junk
                }
                sumR = 0;
                sumG = 0;
                sumB = 0;
                total = 0;
            }
            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Visible = false;//Interface Junk
        }

        /// <summary>
        /// Performs Wash filter with variable size matrix
        /// </summary>
        public void WashFilter(Child c)
        {
            c.pappy.TSProgress.Minimum = 0;//Interface Junk
            c.pappy.TSProgress.Value = 0;//Interface Junk

            int size = GetInt("Mode Filter", "Input a Matrix Size (3)x3 or (5)x5 etc.");

            if ((size % 2) != 1 || size == -1)
                return;

            int off = size / 2;

            c.pappy.TSProgress.Maximum = (iH - off) * (iW - off);//Interface Junk
            c.pappy.TSProgress.Visible = true;//Interface Junk

            int[] rf = new int[256];
            int[] gf = new int[256];
            int[] bf = new int[256];

            byte rm = 0, gm = 0, bm = 0;

            for (int i = off; i < iH - off; i++)
                for (int j = off; j < iW - off; j++)
                {

                    for (int x = 0; x < size; x++)
                        for (int y = 0; y < size; y++)
                        {
                            rf[image[i + x - off, j + y - off, 0]]++;
                            gf[image[i + x - off, j + y - off, 1]]++;
                            bf[image[i + x - off, j + y - off, 2]]++;
                        }

                    for (int z = 1; z < 256; z++)
                    {
                        if (rf[z] > rf[rm])
                            rm = (byte)z;
                        if (gf[z] > gf[gm])
                            gm = (byte)z;
                        if (bf[z] > bf[bm])
                            bm = (byte)z;
                    }

                    image[i, j, 0] = rm;
                    image[i, j, 1] = gm;
                    image[i, j, 2] = bm;

                    for (int k = 0; k < 256; k++)
                    {
                        rf[k] = 0;
                        gf[k] = 0;
                        bf[k] = 0;
                    }

                    c.pappy.TSProgress.Value++;//Interface Junk
                }

            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Visible = false;//Interface Junk
        }


        #endregion

        #region Statistic Filters

        /// <summary>
        /// Performs Median Filter with variable matrix size.
        /// </summary>
        public void MedianFilter(Child c)
        {
            c.pappy.TSProgress.Minimum = 0;//Interface Junk
            c.pappy.TSProgress.Value = 0;//Interface Junk

            int size = GetInt("Median Filter", "Input a Matrix Size (3)x3 or (5)x5 etc.");

            if ((size % 2) != 1 || size == -1)
                return;

            byte[] r = new byte[size * size];
            byte[] g = new byte[size * size];
            byte[] b = new byte[size * size];

            extra = new byte[iH, iW, 4];

            int off = size / 2;

            c.pappy.TSProgress.Maximum = (iH - off) * (iW - off);//Interface Junk
            c.pappy.TSProgress.Visible = true;//Interface Junk

            for (int i = off; i < iH - off; i++)
                for (int j = off; j < iW - off; j++)
                {

                    for (int x = 0; x < size; x++)
                        for (int y = 0; y < size; y++)
                        {
                            r[x * size + y] = image[i + x - off, j + y - off, 0];
                            g[x * size + y] = image[i + x - off, j + y - off, 1];
                            b[x * size + y] = image[i + x - off, j + y - off, 2];
                        }

                    Array.Sort(r);
                    Array.Sort(g);
                    Array.Sort(b);

                    extra[i, j, 0] = r[r.Length / 2];
                    extra[i, j, 1] = g[g.Length / 2];
                    extra[i, j, 2] = b[b.Length / 2];

                    c.pappy.TSProgress.Value++;//Interface Junk
                }

            image = extra;

            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Visible = false;//Interface Junk
        }

        /// <summary>
        /// Performs Min filter with variable size matrix
        /// </summary>
        public void MinFilter(Child c)
        {
            c.pappy.TSProgress.Minimum = 0;//Interface Junk
            c.pappy.TSProgress.Value = 0;//Interface Junk

            int size = GetInt("Min Filter", "Input a Matrix Size (3)x3 or (5)x5 etc.");

            if ((size % 2) != 1 || size == -1)
                return;

            byte[] r = new byte[size * size];
            byte[] g = new byte[size * size];
            byte[] b = new byte[size * size];

            extra = new byte[iH, iW, 4];

            int off = size / 2;

            c.pappy.TSProgress.Maximum = (iH - off) * (iW - off);//Interface Junk
            c.pappy.TSProgress.Visible = true;//Interface Junk

            for (int i = off; i < iH - off; i++)
                for (int j = off; j < iW - off; j++)
                {

                    for (int x = 0; x < size; x++)
                        for (int y = 0; y < size; y++)
                        {
                            r[x * size + y] = image[i + x - off, j + y - off, 0];
                            g[x * size + y] = image[i + x - off, j + y - off, 1];
                            b[x * size + y] = image[i + x - off, j + y - off, 2];
                        }

                    Array.Sort(r);
                    Array.Sort(g);
                    Array.Sort(b);

                    extra[i, j, 0] = r[0];
                    extra[i, j, 1] = g[0];
                    extra[i, j, 2] = b[0];

                    c.pappy.TSProgress.Value++;//Interface Junk
                }

            image = extra;

            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Visible = false;//Interface Junk
        }

        /// <summary>
        /// Performs Max filter with variable size matrix
        /// </summary>
        public void MaxFilter(Child c)
        {
            c.pappy.TSProgress.Minimum = 0;//Interface Junk
            c.pappy.TSProgress.Value = 0;//Interface Junk

            int size = GetInt("Max Filter", "Input a Matrix Size (3)x3 or (5)x5 etc.");

            if ((size % 2) != 1 || size == -1)
                return;

            byte[] r = new byte[size * size];
            byte[] g = new byte[size * size];
            byte[] b = new byte[size * size];

            extra = new byte[iH, iW, 4];

            int off = size / 2;

            c.pappy.TSProgress.Maximum = (iH - off) * (iW - off);//Interface Junk
            c.pappy.TSProgress.Visible = true;//Interface Junk

            for (int i = off; i < iH - off; i++)
                for (int j = off; j < iW - off; j++)
                {

                    for (int x = 0; x < size; x++)
                        for (int y = 0; y < size; y++)
                        {
                            r[x * size + y] = image[i + x - off, j + y - off, 0];
                            g[x * size + y] = image[i + x - off, j + y - off, 1];
                            b[x * size + y] = image[i + x - off, j + y - off, 2];
                        }

                    Array.Sort(r);
                    Array.Sort(g);
                    Array.Sort(b);

                    extra[i, j, 0] = r[size * size - 1];
                    extra[i, j, 1] = g[size * size - 1];
                    extra[i, j, 2] = b[size * size - 1];

                    c.pappy.TSProgress.Value++;//Interface Junk
                }

            image = extra;

            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Visible = false;//Interface Junk
        }

        /// <summary>
        /// Performs Mode filter with variable size matrix
        /// </summary>
        public void ModeFilter(Child c)
        {
            c.pappy.TSProgress.Minimum = 0;//Interface Junk
            c.pappy.TSProgress.Value = 0;//Interface Junk

            int size = GetInt("Mode Filter", "Input a Matrix Size (3)x3 or (5)x5 etc.");

            if ((size % 2) != 1 || size == -1)
                return;

            extra = new byte[iH, iW, 4];

            int off = size / 2;

            c.pappy.TSProgress.Maximum = (iH - off) * (iW - off);//Interface Junk
            c.pappy.TSProgress.Visible = true;//Interface Junk

            int[] rf = new int[256];
            int[] gf = new int[256];
            int[] bf = new int[256];

            byte rm = 0, gm = 0, bm = 0;

            for (int i = off; i < iH - off; i++)
                for (int j = off; j < iW - off; j++)
                {

                    for (int x = 0; x < size; x++)
                        for (int y = 0; y < size; y++)
                        {
                            rf[image[i + x - off, j + y - off, 0]]++;
                            gf[image[i + x - off, j + y - off, 1]]++;
                            bf[image[i + x - off, j + y - off, 2]]++;
                        }

                    for (int z = 1; z < 256; z++)
                    {
                        if (rf[z] > rf[rm])
                            rm = (byte)z;
                        if (gf[z] > gf[gm])
                            gm = (byte)z;
                        if (bf[z] > bf[bm])
                            bm = (byte)z;
                    }

                    extra[i, j, 0] = rm;
                    extra[i, j, 1] = gm;
                    extra[i, j, 2] = bm;

                    for (int k = 0; k < 256; k++)
                    {
                        rf[k] = 0;
                        gf[k] = 0;
                        bf[k] = 0;
                    }

                    c.pappy.TSProgress.Value++;//Interface Junk
                }
            image = extra;

            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Visible = false;//Interface Junk
        }

        /// <summary>
        /// Performs Mid Point filter with variable size matrix
        /// </summary>
        public void MidFilter(Child c)
        {
            c.pappy.TSProgress.Minimum = 0;//Interface Junk
            c.pappy.TSProgress.Value = 0;//Interface Junk

            int size = GetInt("Max Filter", "Input a Matrix Size (3)x3 or (5)x5 etc.");

            if ((size % 2) != 1 || size == -1)
                return;

            byte[] r = new byte[size * size];
            byte[] g = new byte[size * size];
            byte[] b = new byte[size * size];

            extra = new byte[iH, iW, 4];

            int off = size / 2;

            c.pappy.TSProgress.Maximum = (iH - off) * (iW - off);//Interface Junk
            c.pappy.TSProgress.Visible = true;//Interface Junk

            for (int i = off; i < iH - off; i++)
                for (int j = off; j < iW - off; j++)
                {

                    for (int x = 0; x < size; x++)
                        for (int y = 0; y < size; y++)
                        {
                            r[x * size + y] = image[i + x - off, j + y - off, 0];
                            g[x * size + y] = image[i + x - off, j + y - off, 1];
                            b[x * size + y] = image[i + x - off, j + y - off, 2];
                        }

                    Array.Sort(r);
                    Array.Sort(g);
                    Array.Sort(b);

                    extra[i, j, 0] = (byte)(((int)r[0] + (int)r[r.Length - 1]) / 2);
                    extra[i, j, 1] = (byte)(((int)g[0] + (int)g[g.Length - 1]) / 2);
                    extra[i, j, 2] = (byte)(((int)b[0] + (int)b[b.Length - 1]) / 2);

                    c.pappy.TSProgress.Value++;//Interface Junk
                }

            image = extra;

            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Visible = false;//Interface Junk
        }

        #endregion

        #region High Pass 3 x 3

        /// <summary>
        /// High Pass 3x3 filter
        /// </summary>
        /// <param name="tl">Top Left</param>
        /// <param name="tm">Top Middle</param>
        /// <param name="tr">Top Right</param>
        /// <param name="cl">Center Left</param>
        /// <param name="cm">Center Middle</param>
        /// <param name="cr">Center Right</param>
        /// <param name="bl">Bottom Left</param>
        /// <param name="bm">Bottom Middle</param>
        /// <param name="br">Bottom Right</param>
        /// <param name="c">Child to Update interface;</param>
        public void High3Filter(int tl, int tm, int tr,
                                int cl, int cm, int cr,
                                int bl, int bm, int br, Child c)
        {
            c.pappy.TSProgress.Minimum = 0;//Interface Junk
            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Maximum = (iH) * (iW);//Interface Junk

            extra = new byte[iH, iW, 4];
            int total = 0;
            int sumR = 0, sumG = 0, sumB = 0;

            c.pappy.TSProgress.Visible = true;//Interface Junk
            for (int i = 0; i < iH; i++)
            {
                for (int j = 0; j < iW; j++)
                {
                    if (i != 0 && j != 0)//top left
                    {
                        sumR += tl * image[i - 1, j - 1, 0];
                        sumG += tl * image[i - 1, j - 1, 1];
                        sumB += tl * image[i - 1, j - 1, 2];
                        total += tl;
                    }
                    if (i != 0)//top middle
                    {
                        sumR += tm * image[i - 1, j, 0];
                        sumG += tm * image[i - 1, j, 1];
                        sumB += tm * image[i - 1, j, 2];
                        total += tm;
                    }
                    if (i != 0 && j != iW - 1)//top right
                    {
                        sumR += tr * image[i - 1, j + 1, 0];
                        sumG += tr * image[i - 1, j + 1, 1];
                        sumB += tr * image[i - 1, j + 1, 2];
                        total += tr;
                    }
                    if (j != 0)//center left
                    {
                        sumR += cl * image[i, j - 1, 0];
                        sumG += cl * image[i, j - 1, 1];
                        sumB += cl * image[i, j - 1, 2];
                        total += cl;
                    }
                    if (j != iW - 1)//center right
                    {
                        sumR += cr * image[i, j + 1, 0];
                        sumG += cr * image[i, j + 1, 1];
                        sumB += cr * image[i, j + 1, 2];
                        total += cr;
                    }
                    if (i != iH - 1 && j != 0)//bottom left
                    {
                        sumR += bl * image[i + 1, j - 1, 0];
                        sumG += bl * image[i + 1, j - 1, 1];
                        sumB += bl * image[i + 1, j - 1, 2];
                        total += bl;
                    }
                    if (i != iH - 1)//bottom middle
                    {
                        sumR += bm * image[i + 1, j, 0];
                        sumG += bm * image[i + 1, j, 1];
                        sumB += bm * image[i + 1, j, 2];
                        total += bm;
                    }
                    if (i != iH - 1 && j != iW - 1)//bottom right
                    {
                        sumR += br * image[i + 1, j + 1, 0];
                        sumG += br * image[i + 1, j + 1, 1];
                        sumB += br * image[i + 1, j + 1, 2];
                        total += br;
                    }
                    sumR += (Math.Abs(total) + 1)  * image[i, j, 0];
                    sumG += (Math.Abs(total) + 1)  * image[i, j, 1];
                    sumB += (Math.Abs(total) + 1)  * image[i, j, 2];
                    total += (Math.Abs(total) + 1);

                    extra[i, j, 0] = Clamp(sumR);
                    extra[i, j, 1] = Clamp(sumG);
                    extra[i, j, 2] = Clamp(sumB);
                    extra[i, j, 3] = 0;

                    sumR = 0;
                    sumG = 0;
                    sumB = 0;
                    total = 0;

                    c.pappy.TSProgress.Value++;//Interface Junk
                }
            }
            image = extra;

            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Visible = false;//Interface Junk
        }

        #endregion

        #region Laplacian

        /// <summary>
        /// Laplacian 3x3 filter
        /// </summary>
        /// <param name="tl">Top Left</param>
        /// <param name="tm">Top Middle</param>
        /// <param name="tr">Top Right</param>
        /// <param name="cl">Center Left</param>
        /// <param name="cm">Center Middle</param>
        /// <param name="cr">Center Right</param>
        /// <param name="bl">Bottom Left</param>
        /// <param name="bm">Bottom Middle</param>
        /// <param name="br">Bottom Right</param>
        /// <param name="c">Child to Update interface</param>
        public void Laplacian3Filter(int tl, int tm, int tr,
                                int cl, int cm, int cr,
                                int bl, int bm, int br, Child c)
        {
            c.pappy.TSProgress.Minimum = 0;//Interface Junk
            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Maximum = (iH) * (iW);//Interface Junk

            extra = new byte[iH, iW, 4];
            int total = 0;
            int sumR = 0, sumG = 0, sumB = 0;

            c.pappy.TSProgress.Visible = true;//Interface Junk
            for (int i = 0; i < iH; i++)
            {
                for (int j = 0; j < iW; j++)
                {
                    if (i != 0 && j != 0)//top left
                    {
                        sumR += tl * image[i - 1, j - 1, 0];
                        sumG += tl * image[i - 1, j - 1, 1];
                        sumB += tl * image[i - 1, j - 1, 2];
                        total += tl;
                    }
                    if (i != 0)//top middle
                    {
                        sumR += tm * image[i - 1, j, 0];
                        sumG += tm * image[i - 1, j, 1];
                        sumB += tm * image[i - 1, j, 2];
                        total += tm;
                    }
                    if (i != 0 && j != iW - 1)//top right
                    {
                        sumR += tr * image[i - 1, j + 1, 0];
                        sumG += tr * image[i - 1, j + 1, 1];
                        sumB += tr * image[i - 1, j + 1, 2];
                        total += tr;
                    }
                    if (j != 0)//center left
                    {
                        sumR += cl * image[i, j - 1, 0];
                        sumG += cl * image[i, j - 1, 1];
                        sumB += cl * image[i, j - 1, 2];
                        total += cl;
                    }
                    if (j != iW - 1)//center right
                    {
                        sumR += cr * image[i, j + 1, 0];
                        sumG += cr * image[i, j + 1, 1];
                        sumB += cr * image[i, j + 1, 2];
                        total += cr;
                    }
                    if (i != iH - 1 && j != 0)//bottom left
                    {
                        sumR += bl * image[i + 1, j - 1, 0];
                        sumG += bl * image[i + 1, j - 1, 1];
                        sumB += bl * image[i + 1, j - 1, 2];
                        total += bl;
                    }
                    if (i != iH - 1)//bottom middle
                    {
                        sumR += bm * image[i + 1, j, 0];
                        sumG += bm * image[i + 1, j, 1];
                        sumB += bm * image[i + 1, j, 2];
                        total += bm;
                    }
                    if (i != iH - 1 && j != iW - 1)//bottom right
                    {
                        sumR += br * image[i + 1, j + 1, 0];
                        sumG += br * image[i + 1, j + 1, 1];
                        sumB += br * image[i + 1, j + 1, 2];
                        total += br;
                    }
                    sumR += cm * image[i, j, 0];
                    sumG += cm * image[i, j, 1];
                    sumB += cm * image[i, j, 2];
                    total += cm;

                    extra[i, j, 0] = Clamp(sumR);
                    extra[i, j, 1] = Clamp(sumG);
                    extra[i, j, 2] = Clamp(sumB);
                    extra[i, j, 3] = 0;

                    sumR = 0;
                    sumG = 0;
                    sumB = 0;
                    total = 0;

                    c.pappy.TSProgress.Value++;//Interface Junk
                }
            }
            image = extra;

            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Visible = false;//Interface Junk
        }

        #endregion

        #region Unsharp

        /// <summary>
        /// Sharpens an Image
        /// </summary>
        /// <param name="c">Child to Update Interface</param>
        public void Unsharp(Child c)
        {
            c.pappy.TSProgress.Minimum = 0;//Interface Junk
            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Maximum = (iH) * (iW) * 3;//Interface Junk

            extra = new byte[iH, iW, 4];

            byte[, ,] d = new byte[iH, iW, 4];
            int total = 0;
            int sumR = 0, sumG = 0, sumB = 0;

            c.pappy.TSProgress.Visible = true;//Interface Junk

            #region Blur

            for (int i = 0; i < iH; i++)
            {
                for (int j = 0; j < iW; j++)
                {
                    if (i != 0 && j != 0)//top left
                    {
                        sumR += image[i - 1, j - 1, 0];
                        sumG += image[i - 1, j - 1, 1];
                        sumB += image[i - 1, j - 1, 2];
                        total++;
                    }
                    if (i != 0)//top middle
                    {
                        sumR += image[i - 1, j, 0];
                        sumG += image[i - 1, j, 1];
                        sumB += image[i - 1, j, 2];
                        total++;
                    }
                    if (i != 0 && j != iW - 1)//top right
                    {
                        sumR += image[i - 1, j + 1, 0];
                        sumG += image[i - 1, j + 1, 1];
                        sumB += image[i - 1, j + 1, 2];
                        total++;
                    }
                    if (j != 0)//center left
                    {
                        sumR += image[i, j - 1, 0];
                        sumG += image[i, j - 1, 1];
                        sumB += image[i, j - 1, 2];
                        total++;
                    }
                    if (j != iW - 1)//center right
                    {
                        sumR += image[i, j + 1, 0];
                        sumG += image[i, j + 1, 1];
                        sumB += image[i, j + 1, 2];
                        total++;
                    }
                    if (i != iH - 1 && j != 0)//bottom left
                    {
                        sumR += image[i + 1, j - 1, 0];
                        sumG += image[i + 1, j - 1, 1];
                        sumB += image[i + 1, j - 1, 2];
                        total++;
                    }
                    if (i != iH - 1)//bottom middle
                    {
                        sumR += image[i + 1, j, 0];
                        sumG += image[i + 1, j, 1];
                        sumB += image[i + 1, j, 2];
                        total++;
                    }
                    if (i != iH - 1 && j != iW - 1)//bottom right
                    {
                        sumR += image[i + 1, j + 1, 0];
                        sumG += image[i + 1, j + 1, 1];
                        sumB += image[i + 1, j + 1, 2];
                        total++;
                    }
                    sumR += image[i, j, 0];
                    sumG += image[i, j, 1];
                    sumB += image[i, j, 2];
                    total++;

                    extra[i, j, 0] = (byte)((float)sumR / (float)total);
                    extra[i, j, 1] = (byte)((float)sumG / (float)total);
                    extra[i, j, 2] = (byte)((float)sumB / (float)total);
                    extra[i, j, 3] = 0;

                    sumR = 0;
                    sumG = 0;
                    sumB = 0;
                    total = 0;

                    c.pappy.TSProgress.Value++;//Interface Junk
                }
            }

            #endregion

            #region Difference

            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    //Red
                    d[i, j, 0] = Clamp(image[i, j, 0] - (int)extra[i, j, 0]);
                    //Green
                    d[i, j, 1] = Clamp(image[i, j, 1] - (int)extra[i, j, 1]);
                    //Blue
                    d[i, j, 2] = Clamp(image[i, j, 2] - (int)extra[i, j, 2]);

                    c.pappy.TSProgress.Value++;//Interface Junk
                }

            #endregion

            #region Additon

            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    //Red
                    image[i, j, 0] = Clamp(image[i, j, 0] + ((int)d[i, j, 0]));
                    //Green
                    image[i, j, 1] = Clamp(image[i, j, 1] + ((int)d[i, j, 1]));
                    //Blue
                    image[i, j, 2] = Clamp(image[i, j, 2] + ((int)d[i, j, 2]));

                    c.pappy.TSProgress.Value++;//Interface Junk
                }

            #endregion

            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Visible = false;//Interface Junk

            extra = null;
            d = null;
        }

        #endregion

        #region Sobel

        /// <summary>
        /// Sobel sum 3x3 filter
        /// </summary>
        /// <param name="c">Child to Update interface</param>
        public void Sobel3Filter(Child c)
        {
            c.pappy.TSProgress.Minimum = 0;//Interface Junk
            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Maximum = (iH) * (iW) * 3;//Interface Junk

            extra = new byte[iH, iW, 4];
            byte[,,] temp = new byte[iH, iW, 4];
            
            int sumR = 0, sumG = 0, sumB = 0;

            c.pappy.TSProgress.Visible = true;//Interface Junk

            #region X-Axis Sobel

            for (int i = 0; i < iH; i++)
            {
                for (int j = 0; j < iW; j++)
                {
                    if (i != 0 && j != 0)//top left
                    {
                        sumR += -1 * image[i - 1, j - 1, 0];
                        sumG += -1 * image[i - 1, j - 1, 1];
                        sumB += -1 * image[i - 1, j - 1, 2];
                    }
                    if (i != 0 && j != iW - 1)//top right
                    {
                        sumR += 1 * image[i - 1, j + 1, 0];
                        sumG += 1 * image[i - 1, j + 1, 1];
                        sumB += 1 * image[i - 1, j + 1, 2];
                    }
                    if (j != 0)//center left
                    {
                        sumR += -2 * image[i, j - 1, 0];
                        sumG += -2 * image[i, j - 1, 1];
                        sumB += -2 * image[i, j - 1, 2];
                    }
                    if (j != iW - 1)//center right
                    {
                        sumR += 2 * image[i, j + 1, 0];
                        sumG += 2 * image[i, j + 1, 1];
                        sumB += 2 * image[i, j + 1, 2];
                    }
                    if (i != iH - 1 && j != 0)//bottom left
                    {
                        sumR += -1 * image[i + 1, j - 1, 0];
                        sumG += -1 * image[i + 1, j - 1, 1];
                        sumB += -1 * image[i + 1, j - 1, 2];
                    }
                    if (i != iH - 1 && j != iW - 1)//bottom right
                    {
                        sumR += 1 * image[i + 1, j + 1, 0];
                        sumG += 1 * image[i + 1, j + 1, 1];
                        sumB += 1 * image[i + 1, j + 1, 2];
                    }

                    extra[i, j, 0] = Clamp(sumR);
                    extra[i, j, 1] = Clamp(sumG);
                    extra[i, j, 2] = Clamp(sumB);
                    extra[i, j, 3] = 0;

                    sumR = 0;
                    sumG = 0;
                    sumB = 0;

                    c.pappy.TSProgress.Value++;//Interface Junk
                }
            }

            #endregion

            #region Y-Axis Sobel

            for (int i = 0; i < iH; i++)
            {
                for (int j = 0; j < iW; j++)
                {
                    if (i != 0 && j != 0)//top left
                    {
                        sumR += 1 * image[i - 1, j - 1, 0];
                        sumG += 1 * image[i - 1, j - 1, 1];
                        sumB += 1 * image[i - 1, j - 1, 2];
                    }
                    if (i != 0)//top middle
                    {
                        sumR += 2 * image[i - 1, j, 0];
                        sumG += 2 * image[i - 1, j, 1];
                        sumB += 2 * image[i - 1, j, 2];
                    }
                    if (i != 0 && j != iW - 1)//top right
                    {
                        sumR += 1 * image[i - 1, j + 1, 0];
                        sumG += 1 * image[i - 1, j + 1, 1];
                        sumB += 1 * image[i - 1, j + 1, 2];
                    }
                    if (i != iH - 1 && j != 0)//bottom left
                    {
                        sumR += -1 * image[i + 1, j - 1, 0];
                        sumG += -1 * image[i + 1, j - 1, 1];
                        sumB += -1 * image[i + 1, j - 1, 2];
                    }
                    if (i != iH - 1)//bottom middle
                    {
                        sumR += -2 * image[i + 1, j, 0];
                        sumG += -2 * image[i + 1, j, 1];
                        sumB += -2 * image[i + 1, j, 2];
                    }
                    if (i != iH - 1 && j != iW - 1)//bottom right
                    {
                        sumR += -1 * image[i + 1, j + 1, 0];
                        sumG += -1 * image[i + 1, j + 1, 1];
                        sumB += -1 * image[i + 1, j + 1, 2];
                    }

                    temp[i, j, 0] = Clamp(sumR);
                    temp[i, j, 1] = Clamp(sumG);
                    temp[i, j, 2] = Clamp(sumB);
                    temp[i, j, 3] = 0;

                    sumR = 0;
                    sumG = 0;
                    sumB = 0;

                    c.pappy.TSProgress.Value++;//Interface Junk
                }
            }

            #endregion

            #region Addition

            for (int i = 0; i < iH; i++)
            {
                for (int j = 0; j < iW; j++)
                {
                    image[i, j, 0] = Clamp(temp[i, j, 0] + extra[i, j, 0]);
                    image[i, j, 1] = Clamp(temp[i, j, 1] + extra[i, j, 1]);
                    image[i, j, 2] = Clamp(temp[i, j, 2] + extra[i, j, 2]);
                    image[i, j, 3] = 0;

                    c.pappy.TSProgress.Value++;//Interface Junk
                }
            }

            #endregion

            extra = null;
            temp = null;

            c.pappy.TSProgress.Value = 0;//Interface Junk
            c.pappy.TSProgress.Visible = false;//Interface Junk
        }

        #endregion

        #endregion

        #region Normalized Convolution stuff

        public float[,] certainty; //Certainty matrix for normalized convolution

        /// <summary>
        /// Sets up everything for Normalized Convolution
        /// -Greyscales the image
        /// -adds noise to image
        /// -creates certainty matrix
        /// </summary>
        public void setupNormalizedConvolution()
        {
            certainty = new float[iH, iW]; //initialize Certainty matrix
            GreyScale();//Call function to desaturate image (incase of color)
            int amt = GetInt("Get percent of Noise", "Get percent of Noise");//Opens dialog to get percentage of noise

            byte val = 0;//noise value

            Random RandomClass = new Random(); 
            int rNumber = 0;//random number

            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    rNumber = RandomClass.Next(1, 100);//Gets random number between 1-100
                    if (rNumber <= amt)//Pass noise test
                    {
                        image[i, j, 0] = val;//set noise for Red Channel
                        image[i, j, 1] = val;//set noise for Green Channel
                        image[i, j, 2] = val;//set noise for Blue Channel
                        certainty[i, j] = 0;//Set certainty to 0
                    }
                    else//Fail noise check
                        certainty[i, j] = 1;//Value is valid so certainty is 1
                }
        }
        /// <summary>
        /// Blurs image and certainty matrix
        /// </summary>
        public void blurImages2()
        {

            int size = GetInt("Median Filter", "Input a Matrix Size (3)x3 or (5)x5 etc.");//Opens dialog to get filter size

            if ((size % 2) != 1 || size == -1)//if filter size is even then it is invalid
                return;

            normalize = new float[iH, iW];//initialize normalize array with image height and width
            float[,] temp = new float[iH, iW];//initialize temp array to hold certainty values
            
            int off = size / 2; //Calculate offset for processing filter positions

            int sumI = 0;//Sum value for a neighborhood in the image
            float sumC = 0;//Sum value for a neighborhood in the certainty matrix

            //Loop through image starting at first position where the filter fits inside the image
            for (int i = off; i < iH - off; i++)
                for (int j = off; j < iW - off; j++)
                {
                    //loop through neighborhood around the position
                    for (int x = 0; x < size; x++)
                        for (int y = 0; y < size; y++)
                        {
                            sumI += image[i + x - off, j + y - off, 0];
                            sumC += certainty[i + x - off, j + y - off];
                        }

                    normalize[i, j] = (byte)Clamp(((float)sumI / (float)(size*size)));//set the mean for that location
                    temp[i, j] = ((float)sumC / (float)(size*size));//set the mean certainty for that location

                    sumI = 0;
                    sumC = 0;
                }

            //image = normalize;
            certainty = temp;

        }

        /// <summary>
        /// Creates the Distance weighted area filter from Knutsson and Westin
        /// </summary>
        /// <param name="alpha">weights the distance</param>
        /// <param name="beta">weights the cos function</param>
        public void radialWeight(int alpha, int beta)
        {

            int size = GetInt("Radial Weighted Filter", "Input a Matrix Size (3)x3 or (5)x5 etc.");//Get Filter Size

            if ((size % 2) != 1 || size == -1)//check for even size
                return;

            float[,] mask = new float[size, size];//declare mask array
            normalize = new float[iH, iW];
            float[,] temp = new float[iH, iW];

            int off = size / 2;

            float rmax = (float)Math.Sqrt(2*(((size-1)-off)*((size-1)-off)));//get max distance

            //Create Mask
            float dist = 0;//variable to hold distance
            float division = 0;//variable to hold the PIr/2rmax
            float distPow = 0;//distance with exponent
            float cosPow = 0;//cos of division with exponent
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //get Distance from center to to pixel
                    dist = (float)Math.Sqrt(((i - off) * (i - off)) + ((j - off) * (j - off)));

                    if (j == off && i == off)//if center of filter just set to 1
                    {
                        mask[i, j] = 1;
                    }
                    else if (dist < rmax)
                    {
                        division = (float)(Math.PI * dist) / (2.0f * rmax);//calculate division
                        distPow = (float)Math.Pow((double)dist, (double)(-1 * alpha));//get distance to exponent
                        cosPow = (float)Math.Pow(Math.Cos(division), (double)beta);//get cos to exponent
                        mask[i, j] = distPow * cosPow;
                    }
                    else
                    {
                        mask[i, j] = 0;//if dist >= rmax just set to 0
                    }
                }
            }

            float sumI = 0;//sum for image
            float sumC = 0;//sum for certainty
            //run mask over signal and certainty matrices
            for (int i = off; i < iH - off; i++)
                for (int j = off; j < iW - off; j++)
                {
                    //apply mask
                    for (int x = 0; x < size; x++)
                        for (int y = 0; y < size; y++)
                        {
                            sumI += image[i + x - off, j + y - off, 0]*mask[x,y];//get strength of signal at position
                            sumC += certainty[i + x - off, j + y - off]*mask[x,y];//get strength of certainty at position
                        }
                    normalize[i, j] = sumI;//set image values
                    temp[i, j] = sumC;//set certainty values

                    sumI = 0;
                    sumC = 0;
                }
            //image = normalize;
            certainty = temp;
        }

        /// <summary>
        /// Same as other radial Weight function just prompts for variables
        /// </summary>
        public void radialWeight()
        {

            int size = GetInt("Radial Weighted Filter", "Input a Matrix Size (3)x3 or (5)x5 etc.");
            int alpha = GetInt("Radial Weighted Filter", "Input Alpha Value");
            int beta = GetInt("Radial Weighted Filter", "Input Beta Value");

            if ((size % 2) != 1 || size == -1)
                return;
            float[,] mask = new float[size, size];
            normalize = new float[iH, iW];
            float[,] temp = new float[iH, iW];

            int off = size / 2;
            int mid = off + 1;

            float rmax = (float)Math.Sqrt(2 * (((size - 1) - off) * ((size - 1) - off)));

            //Create Mask
            float dist = 0;
            float division = 0;
            float distPow = 0;
            float cosPow = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    dist = (float)Math.Sqrt(((i - off) * (i - off)) + ((j - off) * (j - off)));

                    if (j == off && i == off)
                    {
                        mask[i, j] = 1;
                    }
                    else if (dist < rmax)
                    {
                        division = (float)(Math.PI * dist) / (2.0f * rmax);
                        distPow = (float)Math.Pow((double)dist, (double)(-1 * alpha));
                        cosPow = (float)Math.Pow(Math.Cos(division), (double)beta);
                        mask[i, j] = distPow * cosPow;
                    }
                    else
                    {
                        mask[i, j] = 0;
                    }
                }
            }

            float sumI = 0;
            float sumC = 0;

            for (int i = off; i < iH - off; i++)
                for (int j = off; j < iW - off; j++)
                {

                    for (int x = 0; x < size; x++)
                        for (int y = 0; y < size; y++)
                        {
                            sumI += image[i + x - off, j + y - off, 0] * mask[x, y];
                            sumC += certainty[i + x - off, j + y - off] * mask[x, y];
                        }
                    normalize[i, j] = sumI;
                    temp[i, j] = sumC;

                    sumI = 0;
                    sumC = 0;
                }
            //image = normalize;
            certainty = temp;
        }
 
        /// <summary>
        /// Puts certainty values into the image array to be displayed by gui
        /// </summary>
        public void showCertainty()
        {
            extra = new byte[iH, iW, 4];
            for (int i = 0; i < iH; i++)
                for (int j = 0; j < iW; j++)
                {
                    extra[i, j, 0] = extra[i, j, 1] = extra[i, j, 2] = image[i, j, 0];
                    image[i, j, 0] = (byte)(certainty[i, j]*255.0f);//Red
                    image[i, j, 1] = (byte)(certainty[i, j]*255.0f);//Green
                    image[i, j, 2] = (byte)(certainty[i, j]*255.0f);//Blue
                    extra[i, j, 3] = 0;
                }
        }

        /// <summary>
        /// Standard Image division between image and certainty matrices 
        /// </summary>
        public void divideResults()
        {
            try
            {
                float rat;//ratio

                for (int i = 0; i < iH; i++)
                    for (int j = 0; j < iW; j++)
                    {
                        rat = (float)((float)normalize[i, j] / certainty[i, j]);
                        image[i, j, 0] = (rat > 255) ? (byte)255 : (byte)rat;//check that the division is not too large
                        image[i,j,1] = image[i,j,2] = image[i,j,0];//set all layers to the same value
                    }
            }
            catch { }
        }


        #endregion
    }
}