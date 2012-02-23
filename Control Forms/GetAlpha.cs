using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class GetAlpha : Form
    {

        Child ch;

        public GetAlpha(Child c)
        {
            ch = c;
            InitializeComponent();
        }

        #region Event Handlers

        private void btOK_Click(object sender, EventArgs e)
        {
            try
            {
                float f = (float)Convert.ToDouble(textBox1.Text);
                ch.pic.AlphaBlend(f);
                ch.pappy.lblAction.Text = "Alpha Blend";
                this.Close();
            }
            catch
            {
                textBox1.Text = "";
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}