using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class AddNoise : Form
    {
        Child ch;

        public AddNoise(Child c)
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
                int i = Convert.ToInt32(tbVal.Text);

                if (rbPepper.Checked == true)
                    {
                        ch.pic.AddNoise(i,0);
                        ch.pappy.lblAction.Text = "" + i + "% Pepper Noise Added";
                    }
                else if (rbSalt.Checked == true)
                    {
                        ch.pic.AddNoise(i,255);
                        ch.pappy.lblAction.Text = "" + i + "% Salt Noise Added";
                    }
                    this.Close();
            }
            catch
            {
                tbVal.Text = "";
            }
        }

        #endregion

    }
}