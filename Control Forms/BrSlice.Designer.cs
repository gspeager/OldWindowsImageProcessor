namespace ImageProcessor
{
    partial class BrSlice
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
            this.lblRng = new System.Windows.Forms.Label();
            this.tbMin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbVal = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRng
            // 
            this.lblRng.AutoSize = true;
            this.lblRng.Location = new System.Drawing.Point(0, 3);
            this.lblRng.Name = "lblRng";
            this.lblRng.Size = new System.Drawing.Size(103, 13);
            this.lblRng.TabIndex = 0;
            this.lblRng.Text = "Enter Range (0-255)";
            // 
            // tbMin
            // 
            this.tbMin.Location = new System.Drawing.Point(3, 17);
            this.tbMin.Name = "tbMin";
            this.tbMin.Size = new System.Drawing.Size(29, 20);
            this.tbMin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "-";
            // 
            // tbMax
            // 
            this.tbMax.Location = new System.Drawing.Point(55, 17);
            this.tbMax.Name = "tbMax";
            this.tbMax.Size = new System.Drawing.Size(29, 20);
            this.tbMax.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Value:";
            // 
            // tbVal
            // 
            this.tbVal.Location = new System.Drawing.Point(12, 56);
            this.tbVal.Name = "tbVal";
            this.tbVal.Size = new System.Drawing.Size(29, 20);
            this.tbVal.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(3, 82);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(64, 82);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(31, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "(0-255)";
            // 
            // BrSlice
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(102, 113);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbVal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMax);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMin);
            this.Controls.Add(this.lblRng);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BrSlice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Brightness Slice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRng;
        private System.Windows.Forms.TextBox tbMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbVal;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label3;
    }
}