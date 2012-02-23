using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class ColorSelector : Form
    {

        #region Variables

        Child ch;
        byte[, ,] data;

        #endregion

        #region Constructor

        public ColorSelector(Child c)
        {
            ch = c;

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
            this.lblError.Text = "";
            this.tbRed.Text = "" + this.RedTrack.Value;
            this.tbGreen.Text = "" + this.GreenTrack.Value;
            this.tbBlue.Text = "" + this.BlueTrack.Value;
        }

        #endregion

        #region Color Adjust Functions

        /// <summary>
        /// Adjusts the Color levels of the image
        /// </summary>
        /// <param name="red">Amount to Adjust the Red Values</param>
        /// <param name="green">Amount to Adjust the Green Values</param>
        /// <param name="blue">Amount to Adjust the Blue Values</param>
        /// <param name="iE">Image to modify</param>
        private void AdjustColor(int red, int green, int blue, imageEdit iE)
        {
            int value = 0;
            for (int i = 0; i < iE.getHeight(); i++)
                for (int j = 0; j < iE.getWidth(); j++)
                {
                    //Red
                    value = data[i, j, 0] + red;
                    if (value > 255) value = 255;
                    if (value < 0) value = 0;
                    iE.image[i, j, 0] = (byte)value;
                    //Green
                    value = data[i, j, 1] + green;
                    if (value > 255) value = 255;
                    if (value < 0) value = 0;
                    iE.image[i, j, 1] = (byte)value;
                    //Blue
                    value = data[i, j, 2] + blue;
                    if (value > 255) value = 255;
                    if (value < 0) value = 0;
                    iE.image[i, j, 2] = (byte)value;
                }
        }

        /// <summary>
        /// Adjusts the red levels of the image
        /// </summary>
        /// <param name="red">Amount to Adjust the Red Values</param>
        /// <param name="iE">Image to modify</param>
        private void AdjustRed(int red, imageEdit iE)
        {
            int value = 0;
            for (int i = 0; i < iE.getHeight(); i++)
                for (int j = 0; j < iE.getWidth(); j++)
                {
                    //Red
                    value = data[i, j, 0] + red;
                    if (value > 255) value = 255;
                    if (value < 0) value = 0;
                    iE.image[i, j, 0] = (byte)value;
                }
        }

        /// <summary>
        /// Adjusts the green levels of the image
        /// </summary>
        /// <param name="green">Amount to Adjust the Green Values</param>
        /// <param name="iE">Image to modify</param>
        private void AdjustGreen(int green, imageEdit iE)
        {
            int value = 0;
            for (int i = 0; i < iE.getHeight(); i++)
                for (int j = 0; j < iE.getWidth(); j++)
                {
                    //Green
                    value = data[i, j, 1] + green;
                    if (value > 255) value = 255;
                    if (value < 0) value = 0;
                    iE.image[i, j, 1] = (byte)value;
                }
        }

        /// <summary>
        /// Adjusts the blue levels of the image
        /// </summary>
        /// <param name="blue">Amount to Adjust the Blue Values</param>
        /// <param name="iE">Image to modify</param>
        private void AdjustBlue(int blue, imageEdit iE)
        {
            int value = 0;
            for (int i = 0; i < iE.getHeight(); i++)
                for (int j = 0; j < iE.getWidth(); j++)
                {
                    //Blue
                    value = data[i, j, 2] + blue;
                    if (value > 255) value = 255;
                    if (value < 0) value = 0;
                    iE.image[i, j, 2] = (byte)value;
                }
        }

        #endregion

        #region Control Event

        private void RedTrack_Scroll(object sender, System.EventArgs e)
        {
            tbRed.Text = "" + RedTrack.Value;
            AdjustRed(RedTrack.Value, ch.pic);

            ch.pic.UpdateBitmap(ref ch.b);
            ch.Invalidate();
        }

        private void GreenTrack_Scroll(object sender, System.EventArgs e)
        {
            tbGreen.Text = "" + GreenTrack.Value;
            AdjustGreen(GreenTrack.Value, ch.pic);

            ch.pic.UpdateBitmap(ref ch.b);
            ch.Invalidate();
        }

        private void BlueTrack_Scroll(object sender, System.EventArgs e)
        {
            tbBlue.Text = "" + BlueTrack.Value;
            AdjustBlue(BlueTrack.Value, ch.pic);

            ch.pic.UpdateBitmap(ref ch.b);
            ch.Invalidate();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            int red = Convert.ToInt32(tbRed.Text);
            int green = Convert.ToInt32(tbGreen.Text);
            int blue = Convert.ToInt32(tbBlue.Text);

            if (red > 255 || red < -255 || green > 255
                || green < -255 || blue > 255 || blue < -255)
            {
                lblError.Text = "Invalid Input, Range:(-255,255)";
            }
            else
            {
                AdjustColor(red, green, blue, ch.pic);
                this.Close();
            }
        }

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
            tbRed.Text = "500";
            tbGreen.Text = "500";
            tbBlue.Text = "500";

            this.Close();
        }
        /*
        private void tbRed_TextChanged(object sender, EventArgs e)
        {
            int value = System.Convert.ToInt32(tbRed.Text);

            RedTrack.Value = value;

            RedTrack_Scroll(sender, e);
        }
        */
        #endregion

    }
}