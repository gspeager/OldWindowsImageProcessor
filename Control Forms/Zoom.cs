using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class Zoom : Form
    {
        #region Variables

        Child ch;

        #endregion

        #region Constructor

        public Zoom(Child c)
        {
            ch = c;

            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void btnOK_Click(object sender, EventArgs e)
        {
            float f = (float)Convert.ToDouble(this.textBox1.Text);

            if (f > 0.00 && f <= 16.00)
            {
                ch.zoom = f;
                this.Close();
            }
            else
            {
                textBox1.Clear();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}