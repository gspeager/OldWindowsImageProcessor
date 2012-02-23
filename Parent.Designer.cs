using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ImageProcessor
{
    partial class Parent
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolTip toolTip1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Parent));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maximizeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCh = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lblAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(652, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "MainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::ImageProcessor.Properties.Resources.window_new;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&New...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.FileNew);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.MergeIndex = 4;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::ImageProcessor.Properties.Resources.Log_Off;
            this.exitToolStripMenuItem.MergeIndex = 4;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arrangeIconsToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.arrangeHorizontalToolStripMenuItem,
            this.arrangeVerticalToolStripMenuItem,
            this.maximizeAllToolStripMenuItem,
            this.minimizeAllToolStripMenuItem,
            this.toolStripSeparator4});
            this.windowToolStripMenuItem.MergeIndex = 4;
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.arrangeIconsToolStripMenuItem.Text = "Arrange Icons";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.WindowAI);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.WindowCascade);
            // 
            // arrangeHorizontalToolStripMenuItem
            // 
            this.arrangeHorizontalToolStripMenuItem.Name = "arrangeHorizontalToolStripMenuItem";
            this.arrangeHorizontalToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.arrangeHorizontalToolStripMenuItem.Text = "Arrange Horizontal";
            this.arrangeHorizontalToolStripMenuItem.Click += new System.EventHandler(this.WindowAH);
            // 
            // arrangeVerticalToolStripMenuItem
            // 
            this.arrangeVerticalToolStripMenuItem.Name = "arrangeVerticalToolStripMenuItem";
            this.arrangeVerticalToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.arrangeVerticalToolStripMenuItem.Text = "Arrange Vertical";
            this.arrangeVerticalToolStripMenuItem.Click += new System.EventHandler(this.WindowAV);
            // 
            // maximizeAllToolStripMenuItem
            // 
            this.maximizeAllToolStripMenuItem.Name = "maximizeAllToolStripMenuItem";
            this.maximizeAllToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.maximizeAllToolStripMenuItem.Text = "Maximize All";
            this.maximizeAllToolStripMenuItem.Click += new System.EventHandler(this.WindowMaxAll);
            // 
            // minimizeAllToolStripMenuItem
            // 
            this.minimizeAllToolStripMenuItem.Name = "minimizeAllToolStripMenuItem";
            this.minimizeAllToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.minimizeAllToolStripMenuItem.Text = "Minimize All";
            this.minimizeAllToolStripMenuItem.Click += new System.EventHandler(this.WindowMinAll);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(171, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.MergeIndex = 4;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Enabled = false;
            this.helpToolStripMenuItem1.Image = global::ImageProcessor.Properties.Resources.help_browser;
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.helpToolStripMenuItem1.Text = "&Help";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(115, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::ImageProcessor.Properties.Resources.about;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.HelpAbout);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCh,
            this.TSProgress,
            this.lblAction,
            this.lblZoom});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 510);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(652, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCh
            // 
            this.lblCh.AutoToolTip = true;
            this.lblCh.BackColor = System.Drawing.SystemColors.Control;
            this.lblCh.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblCh.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblCh.Name = "lblCh";
            this.lblCh.Size = new System.Drawing.Size(101, 19);
            this.lblCh.Text = "Memory Opened";
            this.lblCh.ToolTipText = "File Name";
            // 
            // TSProgress
            // 
            this.TSProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TSProgress.Name = "TSProgress";
            this.TSProgress.Size = new System.Drawing.Size(100, 18);
            this.TSProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.TSProgress.Visible = false;
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = false;
            this.lblAction.AutoToolTip = true;
            this.lblAction.BackColor = System.Drawing.SystemColors.Control;
            this.lblAction.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblAction.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(250, 19);
            this.lblAction.Text = " ";
            this.lblAction.ToolTipText = "Performed Action";
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = false;
            this.lblZoom.AutoToolTip = true;
            this.lblZoom.BackColor = System.Drawing.SystemColors.Control;
            this.lblZoom.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblZoom.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(50, 19);
            this.lblZoom.ToolTipText = "Zoom Multiplier";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.InitialDirectory = "G:\\";
            // 
            // Parent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(652, 534);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Parent";
            this.Text = "Memory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ToolStripMenuItem windowToolStripMenuItem;
        private ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private ToolStripMenuItem cascadeToolStripMenuItem;
        private ToolStripMenuItem arrangeHorizontalToolStripMenuItem;
        private ToolStripMenuItem arrangeVerticalToolStripMenuItem;
        private ToolStripMenuItem maximizeAllToolStripMenuItem;
        private ToolStripMenuItem minimizeAllToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        public ToolStripProgressBar TSProgress;
        public ToolStripStatusLabel lblCh;
        public ToolStripStatusLabel lblAction;
        public ToolStripStatusLabel lblZoom;


    }
}


