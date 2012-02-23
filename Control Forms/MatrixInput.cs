using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class MatrixInput : Form
    {
        Child ch;
        int type;

        public MatrixInput(Child c, int t)
        {
            ch = c;
            type = t;
            InitializeComponent();
            if (type == 1)
            {
                this.Text = "Low Pass Mean Filter";
                tb1.Text = "1"; tb2.Text = "1"; tb3.Text = "1";
                tb4.Text = "1"; tb5.Text = "1"; tb6.Text = "1";
                tb7.Text = "1"; tb8.Text = "1"; tb9.Text = "1";
            }
            else if (type == 2)
            {
                this.Text = "High Pass Filter";
                tb1.Text = "-1"; tb2.Text = "-1"; tb3.Text = "-1";
                tb4.Text = "-1"; tb5.Text = "9"; tb6.Text = "-1";
                tb7.Text = "-1"; tb8.Text = "-1"; tb9.Text = "-1";
            }
            else if (type == 3)
            {
                this.Text = "Laplacian Filter";
                tb1.Text = "-1"; tb2.Text = "-1"; tb3.Text = "-1";
                tb4.Text = "-1"; tb5.Text = "8"; tb6.Text = "-1";
                tb7.Text = "-1"; tb8.Text = "-1"; tb9.Text = "-1";
            }
        }

        #region Event Handlers

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (type == 1)
            {
                try
                {
                    byte tl = Convert.ToByte(tb1.Text), tm = Convert.ToByte(tb2.Text), tr = Convert.ToByte(tb3.Text),
                        cl = Convert.ToByte(tb4.Text), cm = Convert.ToByte(tb5.Text), cr = Convert.ToByte(tb6.Text),
                        bl = Convert.ToByte(tb7.Text), bm = Convert.ToByte(tb8.Text), br = Convert.ToByte(tb9.Text);

                    ch.pappy.lblAction.Text = "Custom Low Pass Filter...";
                    ch.pic.Low3Filter(tl, tm, tr,
                                       cl, cm, cr,
                                       bl, bm, br, ch);
                    ch.pappy.lblAction.Text = "Custom Low Pass Filter";
                    this.Close();
                }
                catch
                {
                    tb1.Text = "1"; tb2.Text = "1"; tb3.Text = "1";
                    tb4.Text = "1"; tb5.Text = "1"; tb6.Text = "1";
                    tb7.Text = "1"; tb8.Text = "1"; tb9.Text = "1";
                }
            }
            else if(type == 2)
            {
                try
                {
                    int tl = Convert.ToInt32(tb1.Text), tm = Convert.ToInt32(tb2.Text), tr = Convert.ToInt32(tb3.Text),
                        cl = Convert.ToInt32(tb4.Text), cm = Convert.ToInt32(tb5.Text), cr = Convert.ToInt32(tb6.Text),
                        bl = Convert.ToInt32(tb7.Text), bm = Convert.ToInt32(tb8.Text), br = Convert.ToInt32(tb9.Text);

                    if (tl + tm + tr + cl + cm + cr + bl + bm + br == 1)
                    {
                        ch.pappy.lblAction.Text = "Custom High Pass Filter...";
                        ch.pic.High3Filter(tl, tm, tr,
                                           cl, cm, cr,
                                           bl, bm, br, ch);
                        ch.pappy.lblAction.Text = "Custom High Pass Filter";
                        this.Close();
                    }
                    else
                    {
                        tb1.Text = "-1"; tb2.Text = "-1"; tb3.Text = "-1";
                        tb4.Text = "-1"; tb5.Text = "9"; tb6.Text = "-1";
                        tb7.Text = "-1"; tb8.Text = "-1"; tb9.Text = "-1";
                    }
                }
                catch
                {
                    tb1.Text = "-1"; tb2.Text = "-1"; tb3.Text = "-1";
                    tb4.Text = "-1"; tb5.Text = "9"; tb6.Text = "-1";
                    tb7.Text = "-1"; tb8.Text = "-1"; tb9.Text = "-1";
                }
            }
            else if (type == 3)
            {
                try
                {
                    int tl = Convert.ToInt32(tb1.Text), tm = Convert.ToInt32(tb2.Text), tr = Convert.ToInt32(tb3.Text),
                        cl = Convert.ToInt32(tb4.Text), cm = Convert.ToInt32(tb5.Text), cr = Convert.ToInt32(tb6.Text),
                        bl = Convert.ToInt32(tb7.Text), bm = Convert.ToInt32(tb8.Text), br = Convert.ToInt32(tb9.Text);

                    if (tl + tm + tr + cl + cm + cr + bl + bm + br == 0)
                    {
                        ch.pappy.lblAction.Text = "Custom Laplacian Filter...";
                        ch.pic.Laplacian3Filter(tl, tm, tr,
                                           cl, cm, cr,
                                           bl, bm, br, ch);
                        ch.pappy.lblAction.Text = "Custom Laplacian Filter";
                        this.Close();
                    }
                    else
                    {
                        tb1.Text = "-1"; tb2.Text = "-1"; tb3.Text = "-1";
                        tb4.Text = "-1"; tb5.Text = "8"; tb6.Text = "-1";
                        tb7.Text = "-1"; tb8.Text = "-1"; tb9.Text = "-1";
                    }
                }
                catch
                {
                    tb1.Text = "-1"; tb2.Text = "-1"; tb3.Text = "-1";
                    tb4.Text = "-1"; tb5.Text = "8"; tb6.Text = "-1";
                    tb7.Text = "-1"; tb8.Text = "-1"; tb9.Text = "-1";
                }
            }
        }

        #endregion

    }
}