namespace ImageProcessor
{
    partial class MatrixInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatrixInput));
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.MaskedTextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.tb5 = new System.Windows.Forms.TextBox();
            this.tb6 = new System.Windows.Forms.TextBox();
            this.tb7 = new System.Windows.Forms.TextBox();
            this.tb8 = new System.Windows.Forms.TextBox();
            this.tb9 = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input a 3 x 3 Mask";
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(22, 21);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(20, 20);
            this.tb1.TabIndex = 1;
            this.tb1.Text = "1";
            this.tb1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(48, 21);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(20, 20);
            this.tb2.TabIndex = 2;
            this.tb2.Text = "1";
            this.tb2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb3
            // 
            this.tb3.Location = new System.Drawing.Point(74, 21);
            this.tb3.Name = "tb3";
            this.tb3.Size = new System.Drawing.Size(20, 20);
            this.tb3.TabIndex = 3;
            this.tb3.Text = "1";
            this.tb3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb4
            // 
            this.tb4.Location = new System.Drawing.Point(22, 48);
            this.tb4.Name = "tb4";
            this.tb4.Size = new System.Drawing.Size(20, 20);
            this.tb4.TabIndex = 4;
            this.tb4.Text = "1";
            this.tb4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb5
            // 
            this.tb5.Location = new System.Drawing.Point(48, 48);
            this.tb5.Name = "tb5";
            this.tb5.Size = new System.Drawing.Size(20, 20);
            this.tb5.TabIndex = 5;
            this.tb5.Text = "1";
            this.tb5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb6
            // 
            this.tb6.Location = new System.Drawing.Point(74, 48);
            this.tb6.Name = "tb6";
            this.tb6.Size = new System.Drawing.Size(20, 20);
            this.tb6.TabIndex = 6;
            this.tb6.Text = "1";
            this.tb6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb7
            // 
            this.tb7.Location = new System.Drawing.Point(22, 74);
            this.tb7.Name = "tb7";
            this.tb7.Size = new System.Drawing.Size(20, 20);
            this.tb7.TabIndex = 7;
            this.tb7.Text = "1";
            this.tb7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb8
            // 
            this.tb8.Location = new System.Drawing.Point(48, 74);
            this.tb8.Name = "tb8";
            this.tb8.Size = new System.Drawing.Size(20, 20);
            this.tb8.TabIndex = 8;
            this.tb8.Text = "1";
            this.tb8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb9
            // 
            this.tb9.Location = new System.Drawing.Point(74, 74);
            this.tb9.Name = "tb9";
            this.tb9.Size = new System.Drawing.Size(20, 20);
            this.tb9.TabIndex = 9;
            this.tb9.Text = "1";
            this.tb9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(74, 106);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(33, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // MeanInput
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(122, 134);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tb9);
            this.Controls.Add(this.tb8);
            this.Controls.Add(this.tb7);
            this.Controls.Add(this.tb6);
            this.Controls.Add(this.tb5);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MeanInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Low Pass Mean Filter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox tb1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.TextBox tb4;
        private System.Windows.Forms.TextBox tb5;
        private System.Windows.Forms.TextBox tb6;
        private System.Windows.Forms.TextBox tb7;
        private System.Windows.Forms.TextBox tb8;
        private System.Windows.Forms.TextBox tb9;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}