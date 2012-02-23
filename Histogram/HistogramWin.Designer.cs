namespace ImageProcessor
{
    partial class HistogramWin
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabRed = new System.Windows.Forms.TabPage();
            this.drawAreaRed = new ImageProcessor.DrawArea();
            this.tabGreen = new System.Windows.Forms.TabPage();
            this.drawAreaGreen = new ImageProcessor.DrawArea();
            this.tabBlue = new System.Windows.Forms.TabPage();
            this.drawAreaBlue = new ImageProcessor.DrawArea();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblDem = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHVal = new System.Windows.Forms.Label();
            this.lblWVal = new System.Windows.Forms.Label();
            this.lblISize = new System.Windows.Forms.Label();
            this.lblKB = new System.Windows.Forms.Label();
            this.lblMB = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblClrVal = new System.Windows.Forms.Label();
            this.lblCnt = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabRed.SuspendLayout();
            this.tabGreen.SuspendLayout();
            this.tabBlue.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabRed);
            this.tabMain.Controls.Add(this.tabGreen);
            this.tabMain.Controls.Add(this.tabBlue);
            this.tabMain.Location = new System.Drawing.Point(4, 2);
            this.tabMain.Multiline = true;
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(267, 178);
            this.tabMain.TabIndex = 0;
            // 
            // tabRed
            // 
            this.tabRed.Controls.Add(this.drawAreaRed);
            this.tabRed.Location = new System.Drawing.Point(4, 22);
            this.tabRed.Name = "tabRed";
            this.tabRed.Padding = new System.Windows.Forms.Padding(3);
            this.tabRed.Size = new System.Drawing.Size(259, 152);
            this.tabRed.TabIndex = 0;
            this.tabRed.Text = "Red";
            this.tabRed.UseVisualStyleBackColor = true;
            // 
            // drawAreaRed
            // 
            this.drawAreaRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawAreaRed.Cursor = System.Windows.Forms.Cursors.Cross;
            this.drawAreaRed.Location = new System.Drawing.Point(0, 0);
            this.drawAreaRed.Name = "drawAreaRed";
            this.drawAreaRed.Size = new System.Drawing.Size(257, 150);
            this.drawAreaRed.TabIndex = 0;
            // 
            // tabGreen
            // 
            this.tabGreen.Controls.Add(this.drawAreaGreen);
            this.tabGreen.Location = new System.Drawing.Point(4, 22);
            this.tabGreen.Name = "tabGreen";
            this.tabGreen.Padding = new System.Windows.Forms.Padding(3);
            this.tabGreen.Size = new System.Drawing.Size(259, 152);
            this.tabGreen.TabIndex = 1;
            this.tabGreen.Text = "Green";
            this.tabGreen.UseVisualStyleBackColor = true;
            // 
            // drawAreaGreen
            // 
            this.drawAreaGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawAreaGreen.Cursor = System.Windows.Forms.Cursors.Cross;
            this.drawAreaGreen.Location = new System.Drawing.Point(0, 0);
            this.drawAreaGreen.Name = "drawAreaGreen";
            this.drawAreaGreen.Size = new System.Drawing.Size(256, 150);
            this.drawAreaGreen.TabIndex = 0;
            // 
            // tabBlue
            // 
            this.tabBlue.Controls.Add(this.drawAreaBlue);
            this.tabBlue.Location = new System.Drawing.Point(4, 22);
            this.tabBlue.Name = "tabBlue";
            this.tabBlue.Padding = new System.Windows.Forms.Padding(3);
            this.tabBlue.Size = new System.Drawing.Size(259, 152);
            this.tabBlue.TabIndex = 2;
            this.tabBlue.Text = "Blue";
            this.tabBlue.UseVisualStyleBackColor = true;
            // 
            // drawAreaBlue
            // 
            this.drawAreaBlue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawAreaBlue.Cursor = System.Windows.Forms.Cursors.Cross;
            this.drawAreaBlue.Location = new System.Drawing.Point(0, 0);
            this.drawAreaBlue.Name = "drawAreaBlue";
            this.drawAreaBlue.Size = new System.Drawing.Size(257, 150);
            this.drawAreaBlue.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(184, 289);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(1, 183);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(117, 16);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Image Information:";
            // 
            // lblDem
            // 
            this.lblDem.AutoSize = true;
            this.lblDem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDem.Location = new System.Drawing.Point(12, 205);
            this.lblDem.Name = "lblDem";
            this.lblDem.Size = new System.Drawing.Size(76, 15);
            this.lblDem.TabIndex = 3;
            this.lblDem.Text = "Dimensions:";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(22, 225);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(47, 13);
            this.lblHeight.TabIndex = 4;
            this.lblHeight.Text = "Height =";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(25, 243);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(44, 13);
            this.lblWidth.TabIndex = 5;
            this.lblWidth.Text = "Width =";
            // 
            // lblHVal
            // 
            this.lblHVal.AutoSize = true;
            this.lblHVal.Location = new System.Drawing.Point(67, 225);
            this.lblHVal.Name = "lblHVal";
            this.lblHVal.Size = new System.Drawing.Size(13, 13);
            this.lblHVal.TabIndex = 8;
            this.lblHVal.Text = "h";
            // 
            // lblWVal
            // 
            this.lblWVal.AutoSize = true;
            this.lblWVal.Location = new System.Drawing.Point(67, 243);
            this.lblWVal.Name = "lblWVal";
            this.lblWVal.Size = new System.Drawing.Size(15, 13);
            this.lblWVal.TabIndex = 9;
            this.lblWVal.Text = "w";
            // 
            // lblISize
            // 
            this.lblISize.AutoSize = true;
            this.lblISize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblISize.Location = new System.Drawing.Point(12, 264);
            this.lblISize.Name = "lblISize";
            this.lblISize.Size = new System.Drawing.Size(72, 15);
            this.lblISize.TabIndex = 10;
            this.lblISize.Text = "Image Size:";
            // 
            // lblKB
            // 
            this.lblKB.AutoSize = true;
            this.lblKB.Location = new System.Drawing.Point(22, 284);
            this.lblKB.Name = "lblKB";
            this.lblKB.Size = new System.Drawing.Size(41, 13);
            this.lblKB.TabIndex = 11;
            this.lblKB.Text = "KBSize";
            // 
            // lblMB
            // 
            this.lblMB.AutoSize = true;
            this.lblMB.Location = new System.Drawing.Point(22, 302);
            this.lblMB.Name = "lblMB";
            this.lblMB.Size = new System.Drawing.Size(43, 13);
            this.lblMB.TabIndex = 12;
            this.lblMB.Text = "MBSize";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(140, 204);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(64, 13);
            this.lblColor.TabIndex = 13;
            this.lblColor.Text = "Color Value:";
            // 
            // lblClrVal
            // 
            this.lblClrVal.AutoSize = true;
            this.lblClrVal.Location = new System.Drawing.Point(202, 204);
            this.lblClrVal.Name = "lblClrVal";
            this.lblClrVal.Size = new System.Drawing.Size(34, 13);
            this.lblClrVal.TabIndex = 14;
            this.lblClrVal.Text = "Value";
            // 
            // lblCnt
            // 
            this.lblCnt.AutoSize = true;
            this.lblCnt.Location = new System.Drawing.Point(140, 217);
            this.lblCnt.Name = "lblCnt";
            this.lblCnt.Size = new System.Drawing.Size(38, 13);
            this.lblCnt.TabIndex = 15;
            this.lblCnt.Text = "Count:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(176, 217);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(35, 13);
            this.lblCount.TabIndex = 16;
            this.lblCount.Text = "Count";
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(140, 243);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(30, 13);
            this.labelMax.TabIndex = 17;
            this.labelMax.Text = "Max:";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(140, 256);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(27, 13);
            this.labelMin.TabIndex = 18;
            this.labelMin.Text = "Min:";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(168, 243);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(27, 13);
            this.lblMax.TabIndex = 19;
            this.lblMax.Text = "Max";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(165, 256);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(24, 13);
            this.lblMin.TabIndex = 20;
            this.lblMin.Text = "Min";
            // 
            // HistogramWin
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(271, 324);
            this.ControlBox = false;
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblCnt);
            this.Controls.Add(this.lblClrVal);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblMB);
            this.Controls.Add(this.lblKB);
            this.Controls.Add(this.lblISize);
            this.Controls.Add(this.lblWVal);
            this.Controls.Add(this.lblHVal);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblDem);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HistogramWin";
            this.Text = "Histogram";
            this.tabMain.ResumeLayout(false);
            this.tabRed.ResumeLayout(false);
            this.tabGreen.ResumeLayout(false);
            this.tabBlue.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabRed;
        private System.Windows.Forms.TabPage tabGreen;
        private System.Windows.Forms.TabPage tabBlue;
        private DrawArea drawAreaRed;
        private DrawArea drawAreaGreen;
        private DrawArea drawAreaBlue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblDem;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblISize;
        private System.Windows.Forms.Label lblKB;
        private System.Windows.Forms.Label lblMB;
        private System.Windows.Forms.Label lblColor;
        public System.Windows.Forms.Label lblClrVal;
        private System.Windows.Forms.Label lblCnt;
        public System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelMin;
        public System.Windows.Forms.Label lblMax;
        public System.Windows.Forms.Label lblMin;
        public System.Windows.Forms.Label lblHVal;
        public System.Windows.Forms.Label lblWVal;
    }
}