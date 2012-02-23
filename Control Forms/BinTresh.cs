using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class BinThresh : Form
    {
        Child ch;

        public BinThresh(Child c)
        {
            ch = c;
            InitializeComponent();
        }

        #region Event Handlers

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                byte b = Convert.ToByte(tbThresh.Text);
                ch.pic.BinaryThreshold(b);
                ch.pappy.lblAction.Text = "Binary Contrast Enhancement";
                this.Close();
            }
            catch
            {
                tbThresh.Text = "";
            }
        }

        #endregion
    }
}