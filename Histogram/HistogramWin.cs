using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class HistogramWin : Form
    {
        #region Variables

        public Child ch;

        uint h, w;

        float kb, mb;

        Color clr = new Color();

        public uint total;

        public uint[] redVals = new uint[256];
        public uint[] greenVals = new uint[256];
        public uint[] blueVals = new uint[256];

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to build Histogram
        /// </summary>
        /// <param name="c">Window that's opening the Histogram</param>
        public HistogramWin(Child c)
        {
            clr = new Color();
            ch = c;
            this.MdiParent = c.MdiParent;

            h = (uint)ch.pic.getHeight();
            w = (uint)ch.pic.getWidth();

            total = h * w;

            InitializeComponent();

            //Red
            clr = Color.Red;
            this.drawAreaRed.DrawAreaData(this, redVals, clr);
            this.drawAreaRed.Invalidate();
            //Green
            clr = Color.Green;
            this.drawAreaGreen.DrawAreaData(this, greenVals, clr);
            this.drawAreaGreen.Invalidate();
            //Blue
            clr = Color.Blue;
            this.drawAreaBlue.DrawAreaData(this, blueVals, clr);
            this.drawAreaBlue.Invalidate();

            this.Text = "Histogram - " + ch.Text ;

            this.lblHVal.Text = "" + ch.pic.getHeight();
            this.lblWVal.Text = "" + ch.pic.getWidth();

            kb = (float)(h * w * 4) / 1000f;
            mb = (float)(h * w * 4) / 1000000f;

            this.lblKB.Text = "" + kb + " KB";
            this.lblMB.Text = "" + mb + " MB";

            this.lblClrVal.Text = "";
            this.lblCount.Text = "";

            this.lblMax.Text = "" + drawAreaRed.max;
            this.lblMin.Text = "" + drawAreaRed.min;
        }

        #endregion

        #region Update Function

        /// <summary>
        /// updates the Histogram information
        /// </summary>
        public void UpdateHistogram()
        {
            h = (uint)ch.pic.getHeight();
            w = (uint)ch.pic.getWidth();

            this.Text = "Histogram - " + ch.Text;

            this.lblHVal.Text = "" + ch.pic.getHeight();
            this.lblWVal.Text = "" + ch.pic.getWidth();

            kb = (float)(h * w * 4) / 1000f;
            mb = (float)(h * w * 4) / 1000000f;

            this.lblKB.Text = "" + kb + " KB";
            this.lblMB.Text = "" + mb + " MB";

            for (int i = 0; i < 256; i++)
            {
                redVals[i] = 0;
                greenVals[i] = 0;
                blueVals[i] = 0;
            }

            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                {
                    redVals[ch.pic.image[i, j, 0]]++;
                    greenVals[ch.pic.image[i, j, 1]]++;
                    blueVals[ch.pic.image[i, j, 2]]++;
                }
           
            //Red
            clr = Color.Red;
            this.drawAreaRed.UpdateDrawArea(redVals, clr);
            this.drawAreaRed.Invalidate();
            //Green
            clr = Color.Green;
            this.drawAreaGreen.UpdateDrawArea(greenVals, clr);
            this.drawAreaGreen.Invalidate();
            //Blue
            clr = Color.Blue;
            this.drawAreaBlue.UpdateDrawArea(blueVals, clr);
            this.drawAreaBlue.Invalidate();
        }

        #endregion

        #region Event functions

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            ch.hist = null;
            this.Dispose();
        }

        #endregion

    }
}