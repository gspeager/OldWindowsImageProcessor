using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class DrawArea : UserControl
    {

        #region Variables

        int height = 150;
        float ratio;
        HistogramWin histo;
        uint largest = 0;
        public int max = 0, min = 255;
        
        uint[] data = new uint[256];

        Pen myPen;

        #endregion

        #region Constructor

        public DrawArea()
        {
            InitializeComponent();
        }

        #endregion

        #region DrawArea Data Funcitons

        /// <summary>
        /// Fills out the info for a DrawArea
        /// </summary>
        /// <param name="h">Parent HistogramWin</param>
        /// <param name="d">data to draw</param>
        /// <param name="clr">color to paint the window</param>
        public void DrawAreaData(HistogramWin h, uint[] d, Color clr)
        {
            histo = h;
            largest = 0;  max = 0; min = 255;

            for (int i = 0; i < 256; i++)
            {
                if (d[i] > largest)
                    largest = d[i];
                if (d[i] > 0 && i < min)
                    min = i;
                if (d[i] > 0 && i > max)
                    max = i;
                data[i] = d[i];
            }
            ratio = (float)largest / (float)height;
            myPen = new Pen(clr);

            InitializeComponent();
        }

        /// <summary>
        /// Updates the DrawArea data
        /// </summary>
        /// <param name="d">data to draw</param>
        /// <param name="clr">color to paint the window</param>
        public void UpdateDrawArea(uint[] d,Color clr)
        {
            largest = 0; max = 0; min = 255;
            
            for (int i = 0; i < 256; i++)
            {
                if (d[i] > largest)
                    largest = d[i];
                if (d[i] > 0 && i < min)
                    min = i;
                if (d[i] > 0 && i > max)
                    max = i;
                data[i] = d[i];
            }

            ratio = (float)largest / (float)height;
            myPen = new Pen(clr);
        }

        #endregion

        #region Event Overrides

        protected override void OnPaint(PaintEventArgs e)
        {

            if (myPen == null)
                return;

            Graphics g = e.Graphics;

            for (int i = 0; i < 256; i++)
            {
                g.DrawLine(myPen, i, 150, i, (150 - ((float)data[i]/ratio)));
            }
            histo.lblMax.Text = "" + max;
            histo.lblMin.Text = "" + min;
            histo.lblHVal.Text = "" +  histo.ch.b.Height;
            histo.lblWVal.Text = "" + histo.ch.b.Width;
            base.OnPaint(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Point p = new Point(MousePosition.X, MousePosition.Y);
            p = this.PointToClient(p);
            
            histo.lblClrVal.Text = "" + p.X;
            histo.lblCount.Text = "" + data[p.X];
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            histo.lblClrVal.Text = "";
            histo.lblCount.Text = "";
            base.OnMouseLeave(e);
        }

        #endregion

    }
}
