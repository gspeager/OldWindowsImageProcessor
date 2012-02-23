using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class Selection : Form
    {
        #region Variables

        Child ch;
        int type;
        byte[,,] data;

        #endregion

        #region Constructor

        /// <summary>
        /// Selection Constructor
        /// </summary>
        /// <param name="c">Child Form</param>
        /// <param name="t">Selects algorithm</param>
        public Selection(Child c, int t)
        {
            ch = c;
            type = t;
            data = new byte[ch.pic.getHeight(), ch.pic.getWidth(), 4];
            
            for (int i = 0; i < ch.pic.getHeight(); i++)
                for (int j = 0; j < ch.pic.getWidth(); j++)
                {
                    data[i, j, 0] = ch.pic.image[i, j, 0];
                    data[i, j, 1] = ch.pic.image[i, j, 1];
                    data[i, j, 2] = ch.pic.image[i, j, 2];
                    data[i, j, 3] = ch.pic.image[i, j, 3];
                }

            InitializeComponent();
            if (type == 1)
            {
                this.Text = ch.Text + " Brightness - Selection";
                this.lblType.Text = "Brightness:";
                this.trackBar1.Maximum = 255;
                this.trackBar1.Minimum = -255;
            }
            else if (type == 2)
            {
                this.Text = ch.Text + " Contrast - Selection";
                this.lblType.Text = "Contrast:";
                this.trackBar1.Maximum = 100;
                this.trackBar1.Minimum = -100;
            }
            else if (type == 3)
            {
                this.Text = ch.Text + " Gamma - Selection";
                this.lblType.Text = "Gamma:";
                this.trackBar1.Maximum = 160;
                this.trackBar1.Minimum = 0;
                this.trackBar1.TickFrequency = 1;
                this.trackBar1.Value = 20;
            }
        }

        #endregion

        #region Image Manipulation Functions

        /// <summary>
        /// Lightens or Darkens an image
        /// </summary>
        /// <param name="br">Value of new Brightness</param>
        /// <param name="iE">imageEdit to be modified</param>
        public void Brightness(int br, imageEdit iE)
        {
            int nVal = 0;

            for (int i = 0; i < ch.pic.getHeight(); i++)
                for (int j = 0; j < ch.pic.getWidth(); j++)
                {
                    //Red
                    nVal = (data[i, j, 0] + br);
                    if (nVal < 0) nVal = 0;
                    if (nVal > 255) nVal = 255;
                    iE.image[i, j, 0] = (byte)nVal;
                    //Green
                    nVal = (data[i, j, 1] + br);
                    if (nVal < 0) nVal = 0;
                    if (nVal > 255) nVal = 255;
                    iE.image[i, j, 1] = (byte)nVal;
                    //Blue
                    nVal = (data[i, j, 2] + br);
                    if (nVal < 0) nVal = 0;
                    if (nVal > 255) nVal = 255;
                    iE.image[i, j, 2] = (byte)nVal;
                }
        }

        /// <summary>
        /// Increases or lowers contrast of the image
        /// </summary>
        /// <param name="con">Contrast modifier</param>
        /// <param name="iE">imageEdit to be modified</param>
        public void Contrast(int con, imageEdit iE)
        {
            double pixel = 0, contrast = (100.0 + con) / 100.0;

            contrast *= contrast;

            byte red, green, blue;

            for (int i = 0; i < ch.pic.getHeight(); i++)
                for (int j = 0; j < ch.pic.getWidth(); j++)
                {
                    red = data[i, j, 0];
                    green = data[i, j, 1];
                    blue = data[i, j, 2];
                    //Red
                    pixel = red / 255.0;
                    pixel -= 0.5;
                    pixel *= contrast;
                    pixel += 0.5;
                    pixel *= 255;
                    if (pixel < 0) pixel = 0;
                    if (pixel > 255) pixel = 255;
                    iE.image[i, j, 0] = (byte)pixel;
                    //Green
                    pixel = green / 255.0;
                    pixel -= 0.5;
                    pixel *= contrast;
                    pixel += 0.5;
                    pixel *= 255;
                    if (pixel < 0) pixel = 0;
                    if (pixel > 255) pixel = 255;
                    iE.image[i, j, 1] = (byte)pixel;
                    //Blue
                    pixel = blue / 255.0;
                    pixel -= 0.5;
                    pixel *= contrast;
                    pixel += 0.5;
                    pixel *= 255;
                    if (pixel < 0) pixel = 0;
                    if (pixel > 255) pixel = 255;
                    iE.image[i, j, 2] = (byte)pixel;	
                }
        }

        /// <summary>
        /// Corrects the Gamma intensity of the image
        /// </summary>
        /// <param name="gam">Gamma modifier</param>
        /// <param name="iE">imageEdit to be modified</param>
        private void GammaCorrection(double gam, imageEdit iE)
        {
            for (int i = 0; i < iE.getHeight(); i++)
                for (int j = 0; j < iE.getWidth(); j++)
                {
                    //Red
                    iE.image[i, j, 0] = (byte)(255 * Math.Pow(((double)data[i, j, 0] / 255.0), gam));
                    //Green
                    iE.image[i, j, 1] = (byte)(255 * Math.Pow(((double)data[i, j, 1] / 255.0), gam));
                    //Blue
                    iE.image[i, j, 2] = (byte)(255 * Math.Pow(((double)data[i, j, 2] / 255.0), gam));
                }
        }

        #endregion

        #region Control Events

        private void btnCancel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ch.pic.getHeight(); i++)
                for (int j = 0; j < ch.pic.getWidth(); j++)
                {
                     ch.pic.image[i, j, 0] = data[i, j, 0];
                     ch.pic.image[i, j, 1] = data[i, j, 1];
                     ch.pic.image[i, j, 2] = data[i, j, 2];
                     ch.pic.image[i, j, 3] = data[i, j, 3];
                }
            tbValue.Text = "500";
            this.Close();
        }

        private void trackBar1_Scroll(object sender, System.EventArgs e)
        {           
            if (type == 1)
            {
                tbValue.Text = "" + trackBar1.Value;
                Brightness(System.Convert.ToInt32(tbValue.Text), ch.pic);
            }
            else if (type == 2)
            {
                tbValue.Text = "" + trackBar1.Value;
                Contrast(System.Convert.ToInt32(tbValue.Text), ch.pic);
            }
            else if (type == 3)
            {
                double d = (trackBar1.Value / 20.0);
                tbValue.Text = "" + d;
                GammaCorrection(d, ch.pic);
            }
            ch.pic.UpdateBitmap(ref ch.b);
            ch.Invalidate();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            double val = System.Convert.ToDouble(tbValue.Text);
            
            if (type == 1)
            {
                if (val < 256 && val > -256)
                    this.Close();
                else
                    lblError.Text = "Invalid Input, Range:(-255,255)";
            }
            else if (type == 2)
            {
                if (val < 101 && val > -101)
                    this.Close();
                else
                    lblError.Text = "Invalid Input, Range:(-100,100)";
            }
            else if (type == 3)
            {
                if (val <= 8 && val >= 0)
                    this.Close();
                else
                    lblError.Text = "Invalid Input, Range:(0,5)";
            }
        }

        #endregion

    }
}