using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class BitMask : Form
    {
        Child ch;

        public BitMask(Child c)
        {
            ch = c;
            InitializeComponent();
        }

        #region Event Handlers

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                byte b = Convert.ToByte(tbVal.Text);

                if (rBAND.Checked == true)
                {
                    ch.pic.AndMask(b);
                    ch.pappy.lblAction.Text = "And Mask Performed";
                }
                else if (rBOR.Checked == true)
                {
                    ch.pic.ORMask(b);
                    ch.pappy.lblAction.Text = "OR Mask Performed";
                }
                else if (rbXOR.Checked == true)
                {
                    ch.pic.XORMask(b);
                    ch.pappy.lblAction.Text = "XOR Mask Performed";
                }

                this.Close();
            }
            catch
            {
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