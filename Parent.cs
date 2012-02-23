using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class Parent : Form
    {

        #region Constructor

        public Parent()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FileNew(object sender, System.EventArgs e)
        {
            openFileDialog1.InitialDirectory = "g:\\";
            openFileDialog1.Filter = "PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|Bitmap files (*.bmp)|*.bmp|JPG files (*.jpg)|*.jpg|All Valid Files (*.bmp/*.jpg/*.gif/*.png)|*.bmp;*.jpg;*.gif;*.png";
            openFileDialog1.FilterIndex = 5;
            openFileDialog1.RestoreDirectory = true;

            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                try
                {
                    Child chForm = new Child(this, openFileDialog1.FileName);//make new child
                    
                    chForm.MdiParent = this;//Set parent

                    //set the title of the child window.
                    chForm.Text = openFileDialog1.FileName;

                    chForm.fileloc = openFileDialog1.FileName;

                    //display the child window
                    chForm.Height = chForm.b.Height + 36;
                    chForm.Width = chForm.b.Width + 16;
                    chForm.Show();
                    chForm.menuStrip1.Hide();
                }
                catch
                {
                    MessageBox.Show("Error opening image", "Expose", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void HelpAbout(object sender, System.EventArgs e)
        {
            About a = new About();
            a.Show();
            //a.Dispose();
            //About(this.Handle, "Simulacrum Processing Suite", "Written by Aaron Lefkowitz.", IntPtr.Zero);
        }

        //
        //Window Layout events
        //
        private void WindowAI(object sender, System.EventArgs e)
        {
            //Arrange MDI child icons within the client region of the MDI parent form.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
        }

        private void WindowCascade(object sender, System.EventArgs e)
        {
            //Cascade all child forms.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void WindowAH(object sender, System.EventArgs e)
        {
            //Tile all child forms horizontally.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void WindowAV(object sender, System.EventArgs e)
        {
            //Tile all child forms vertically.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void WindowMaxAll(object sender, System.EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            Form[] charr = this.MdiChildren;

            //for each child form set the window state to Maximized
            foreach (Form chform in charr)
                chform.WindowState = FormWindowState.Maximized;
        }

        private void WindowMinAll(object sender, System.EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            Form[] charr = this.MdiChildren;

            //for each child form set the window state to Minimized
            foreach (Form chform in charr)
                chform.WindowState = FormWindowState.Minimized;
        }

        #endregion

    }
}
