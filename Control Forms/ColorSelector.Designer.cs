namespace ImageProcessor
{
    partial class ColorSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorSelector));
            this.RedTrack = new System.Windows.Forms.TrackBar();
            this.GreenTrack = new System.Windows.Forms.TrackBar();
            this.BlueTrack = new System.Windows.Forms.TrackBar();
            this.lblRed = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.lblBlue = new System.Windows.Forms.Label();
            this.tbRed = new System.Windows.Forms.TextBox();
            this.tbGreen = new System.Windows.Forms.TextBox();
            this.tbBlue = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RedTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // RedTrack
            // 
            this.RedTrack.Location = new System.Drawing.Point(-1, 16);
            this.RedTrack.Maximum = 255;
            this.RedTrack.Minimum = -255;
            this.RedTrack.Name = "RedTrack";
            this.RedTrack.Size = new System.Drawing.Size(330, 45);
            this.RedTrack.TabIndex = 0;
            this.RedTrack.TickFrequency = 5;
            this.RedTrack.Scroll += new System.EventHandler(this.RedTrack_Scroll);
            // 
            // GreenTrack
            // 
            this.GreenTrack.Location = new System.Drawing.Point(-1, 72);
            this.GreenTrack.Maximum = 255;
            this.GreenTrack.Minimum = -255;
            this.GreenTrack.Name = "GreenTrack";
            this.GreenTrack.Size = new System.Drawing.Size(330, 45);
            this.GreenTrack.TabIndex = 1;
            this.GreenTrack.TickFrequency = 5;
            this.GreenTrack.Scroll += new System.EventHandler(this.GreenTrack_Scroll);
            // 
            // BlueTrack
            // 
            this.BlueTrack.Location = new System.Drawing.Point(-1, 128);
            this.BlueTrack.Maximum = 255;
            this.BlueTrack.Minimum = -255;
            this.BlueTrack.Name = "BlueTrack";
            this.BlueTrack.Size = new System.Drawing.Size(330, 45);
            this.BlueTrack.TabIndex = 2;
            this.BlueTrack.TickFrequency = 5;
            this.BlueTrack.Scroll += new System.EventHandler(this.BlueTrack_Scroll);
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.Location = new System.Drawing.Point(12, 5);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(27, 13);
            this.lblRed.TabIndex = 3;
            this.lblRed.Text = "Red";
            // 
            // lblGreen
            // 
            this.lblGreen.AutoSize = true;
            this.lblGreen.Location = new System.Drawing.Point(12, 61);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(36, 13);
            this.lblGreen.TabIndex = 4;
            this.lblGreen.Text = "Green";
            // 
            // lblBlue
            // 
            this.lblBlue.AutoSize = true;
            this.lblBlue.Location = new System.Drawing.Point(12, 117);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(28, 13);
            this.lblBlue.TabIndex = 5;
            this.lblBlue.Text = "Blue";
            // 
            // tbRed
            // 
            this.tbRed.Location = new System.Drawing.Point(286, 51);
            this.tbRed.Name = "tbRed";
            this.tbRed.Size = new System.Drawing.Size(34, 20);
            this.tbRed.TabIndex = 6;
            // 
            // tbGreen
            // 
            this.tbGreen.Location = new System.Drawing.Point(286, 107);
            this.tbGreen.Name = "tbGreen";
            this.tbGreen.Size = new System.Drawing.Size(34, 20);
            this.tbGreen.TabIndex = 7;
            // 
            // tbBlue
            // 
            this.tbBlue.Location = new System.Drawing.Point(286, 163);
            this.tbBlue.Name = "tbBlue";
            this.tbBlue.Size = new System.Drawing.Size(34, 20);
            this.tbBlue.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(245, 191);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(164, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(8, 196);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(29, 13);
            this.lblError.TabIndex = 11;
            this.lblError.Text = "Error";
            // 
            // ColorSelector
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(330, 218);
            this.ControlBox = false;
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbBlue);
            this.Controls.Add(this.tbGreen);
            this.Controls.Add(this.tbRed);
            this.Controls.Add(this.lblBlue);
            this.Controls.Add(this.lblGreen);
            this.Controls.Add(this.lblRed);
            this.Controls.Add(this.BlueTrack);
            this.Controls.Add(this.GreenTrack);
            this.Controls.Add(this.RedTrack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ColorSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Color Selector";
            ((System.ComponentModel.ISupportInitialize)(this.RedTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar RedTrack;
        private System.Windows.Forms.TrackBar GreenTrack;
        private System.Windows.Forms.TrackBar BlueTrack;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.Label lblBlue;
        public System.Windows.Forms.TextBox tbRed;
        public System.Windows.Forms.TextBox tbGreen;
        public System.Windows.Forms.TextBox tbBlue;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblError;
    }
}