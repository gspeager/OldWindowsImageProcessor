namespace ImageProcessor
{
    partial class BitMask
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
            this.label1 = new System.Windows.Forms.Label();
            this.gBMType = new System.Windows.Forms.GroupBox();
            this.rBOR = new System.Windows.Forms.RadioButton();
            this.rBAND = new System.Windows.Forms.RadioButton();
            this.tbVal = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.rbXOR = new System.Windows.Forms.RadioButton();
            this.gBMType.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Bit Mask Value (0-255)";
            // 
            // gBMType
            // 
            this.gBMType.Controls.Add(this.rbXOR);
            this.gBMType.Controls.Add(this.rBOR);
            this.gBMType.Controls.Add(this.rBAND);
            this.gBMType.Location = new System.Drawing.Point(3, 26);
            this.gBMType.Name = "gBMType";
            this.gBMType.Size = new System.Drawing.Size(88, 89);
            this.gBMType.TabIndex = 1;
            this.gBMType.TabStop = false;
            this.gBMType.Text = "Mask Type";
            // 
            // rBOR
            // 
            this.rBOR.AutoSize = true;
            this.rBOR.Location = new System.Drawing.Point(7, 43);
            this.rBOR.Name = "rBOR";
            this.rBOR.Size = new System.Drawing.Size(70, 17);
            this.rBOR.TabIndex = 1;
            this.rBOR.TabStop = true;
            this.rBOR.Text = "OR Mask";
            this.rBOR.UseVisualStyleBackColor = true;
            // 
            // rBAND
            // 
            this.rBAND.AutoSize = true;
            this.rBAND.Location = new System.Drawing.Point(7, 20);
            this.rBAND.Name = "rBAND";
            this.rBAND.Size = new System.Drawing.Size(77, 17);
            this.rBAND.TabIndex = 0;
            this.rBAND.TabStop = true;
            this.rBAND.Text = "AND Mask";
            this.rBAND.UseVisualStyleBackColor = true;
            // 
            // tbVal
            // 
            this.tbVal.Location = new System.Drawing.Point(102, 59);
            this.tbVal.Name = "tbVal";
            this.tbVal.Size = new System.Drawing.Size(29, 20);
            this.tbVal.TabIndex = 2;
            this.tbVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(3, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(80, 121);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rbXOR
            // 
            this.rbXOR.AutoSize = true;
            this.rbXOR.Location = new System.Drawing.Point(6, 66);
            this.rbXOR.Name = "rbXOR";
            this.rbXOR.Size = new System.Drawing.Size(77, 17);
            this.rbXOR.TabIndex = 2;
            this.rbXOR.TabStop = true;
            this.rbXOR.Text = "XOR Mask";
            this.rbXOR.UseVisualStyleBackColor = true;
            // 
            // BitMask
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(146, 149);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbVal);
            this.Controls.Add(this.gBMType);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BitMask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bit Mask";
            this.gBMType.ResumeLayout(false);
            this.gBMType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gBMType;
        private System.Windows.Forms.RadioButton rBAND;
        private System.Windows.Forms.RadioButton rBOR;
        private System.Windows.Forms.TextBox tbVal;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rbXOR;
    }
}