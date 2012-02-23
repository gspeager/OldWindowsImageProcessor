using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ImageProcessor
{

    /// <summary>
    /// Summary description for DialogSelection.
    /// </summary>
    public class DialogSelection : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label EnterLabel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelBut;
        private System.Windows.Forms.TextBox TextField;

        private string val;

        public string GetValue
        {
            get { return val; }
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public DialogSelection()
        {
            InitializeComponent();

            this.CancelButton = CancelBut;
            this.AcceptButton = OKButton;
        }

        public void Init(string caption, string message)
        {
            this.Text = caption;
            this.EnterLabel.Text = message;

            this.TextField.Text = string.Empty;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogSelection));
            this.EnterLabel = new System.Windows.Forms.Label();
            this.TextField = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EnterLabel
            // 
            this.EnterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterLabel.Location = new System.Drawing.Point(8, 8);
            this.EnterLabel.Name = "EnterLabel";
            this.EnterLabel.Size = new System.Drawing.Size(272, 16);
            this.EnterLabel.TabIndex = 0;
            // 
            // TextField
            // 
            this.TextField.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextField.Location = new System.Drawing.Point(48, 32);
            this.TextField.Name = "TextField";
            this.TextField.Size = new System.Drawing.Size(232, 21);
            this.TextField.TabIndex = 1;
            this.TextField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextField_KeyDown);
            // 
            // OKButton
            // 
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OKButton.Location = new System.Drawing.Point(216, 65);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(64, 24);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "&OK";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelBut
            // 
            this.CancelBut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBut.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CancelBut.Location = new System.Drawing.Point(146, 65);
            this.CancelBut.Name = "CancelBut";
            this.CancelBut.Size = new System.Drawing.Size(64, 24);
            this.CancelBut.TabIndex = 3;
            this.CancelBut.Text = "&Cancel";
            this.CancelBut.Click += new System.EventHandler(this.CancelBut_Click);
            // 
            // DialogSelection
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.CancelBut;
            this.ClientSize = new System.Drawing.Size(292, 96);
            this.ControlBox = false;
            this.Controls.Add(this.CancelBut);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.TextField);
            this.Controls.Add(this.EnterLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DialogSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DialogSelection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void OKButton_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.val = this.TextField.Text;

            this.Close();
        }

        private void CancelBut_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TextField_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                OKButton_Click(null, null);
            }
        }
    }
}