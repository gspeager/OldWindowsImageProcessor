using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class BrSlice : Form
    {
        Child ch;

        public BrSlice(Child c)
        {
            ch = c;
            InitializeComponent();
        }

        #region Event Handlers

        private void btnOK_Click(object sender, EventArgs e)
        {
            int lv, uv;
            try
            {
                lv = Convert.ToInt32(tbMin.Text);
                uv = Convert.ToInt32(tbMax.Text);
                byte val = Convert.ToByte(tbVal.Text);

                if (lv > uv || lv > 255 || lv < 0 || uv > 255 || uv < 0)
                {
                    tbMin.Text = "";
                    tbMax.Text = "";
                }
                else if (val > 255 || val < 0)
                {
                    tbVal.Text = "";
                }
                else
                {
                    ch.pic.BrightnessSlice(lv, uv, val);
                    ch.pappy.lblAction.Text = "Brightness Slice";
                    this.Close();
                }
            }
            catch
            {
                tbMin.Text = "";
                tbMax.Text = ""; 
                tbVal.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}