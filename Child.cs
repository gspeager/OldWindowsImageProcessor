using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;


namespace ImageProcessor
{
    public partial class Child : Form
    {
        #region Variables

        public imageEdit pic;//class to edit image
        public Bitmap b, o;
        
        private static int exH = 36, exW = 16;//boarder around a windows form
        
        private Stack UndoStack;
        private Stack RedoStack;

        public float zoom = 1.0f;//Zoom variable

        bool changed = false;

        public HistogramWin hist;

        public Parent pappy;

        #endregion

        #region Constructors

        /// <summary>
        /// Simple constructor
        /// </summary>
        public Child()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="f"></param>
        public Child(Parent p, string f)
        {
            LoadImage(f);

            UndoStack = new Stack();
            RedoStack = new Stack();

            RestoreImage();//for some reason Invert messes up without doing this first

            this.Height = pic.getHeight() + 37;
            this.Width = pic.getWidth() + 17;

            pappy = p;

            InitializeComponent();
        }

        #endregion
        
        #region Undo/Redo/Restore Functions

        /// <summary>
        /// Restore to Original image
        /// </summary>
        public void RestoreImage()
        {
            this.UndoStack.Clear();
            this.RedoStack.Clear();

            pic.LoadFromBitmap(ref o);
            pic.UpdateBitmap(ref b);
            this.Invalidate();
        }

        /// <summary>
        /// Undoes last operation
        /// </summary>
        public void Undo()
        {
            byte[, ,] temp = new byte[pic.getHeight(), pic.getWidth(), 4];

            for (int i = 0; i < pic.getHeight(); i++)
                for (int j = 0; j < pic.getWidth(); j++)
                {
                    temp[i, j, 0] = pic.image[i, j, 0];
                    temp[i, j, 1] = pic.image[i, j, 1];
                    temp[i, j, 2] = pic.image[i, j, 2];
                    temp[i, j, 3] = 0;
                }
            RedoStack.Push(pic.getHeight());
            RedoStack.Push(pic.getWidth());
            RedoStack.Push(temp);

            pic.image = (byte[,,])UndoStack.Pop();
            pic.setWidth((int)UndoStack.Pop());
            pic.setHeight((int)UndoStack.Pop());

            this.Height = (int)(pic.getHeight()*zoom + exH);
            this.Width = (int)(pic.getWidth() * zoom + exW);

            pic.UpdateBitmap(ref b);
            this.Invalidate();
        }
  
        /// <summary>
        /// Restore previous operations
        /// </summary>
        public void Redo()
        {
            byte[, ,] temp = new byte[pic.getHeight(), pic.getWidth(), 4];

            for (int i = 0; i < pic.getHeight(); i++)
                for (int j = 0; j < pic.getWidth(); j++)
                {
                    temp[i, j, 0] = pic.image[i, j, 0];
                    temp[i, j, 1] = pic.image[i, j, 1];
                    temp[i, j, 2] = pic.image[i, j, 2];
                    temp[i, j, 3] = 0;
                }

            UndoStack.Push(pic.getHeight());
            UndoStack.Push(pic.getWidth());          
            UndoStack.Push(temp);

            pic.image = (byte[,,])RedoStack.Pop();
            pic.setWidth((int)RedoStack.Pop());
            pic.setHeight((int)RedoStack.Pop());

            this.Height = (int)(pic.getHeight() * zoom + exH);
            this.Width = (int)(pic.getWidth() * zoom + exW);

            pic.UpdateBitmap(ref b);          
            this.Invalidate();
        }

        /// <summary>
        /// Adds the proper data to the Undo Stack
        /// </summary>
        public void addToUndo()
        {
            RedoStack.Clear();
            byte[, ,] temp = new byte[pic.getHeight(), pic.getWidth(), 4];

            for (int i = 0; i < pic.getHeight(); i++)
                for (int j = 0; j < pic.getWidth(); j++)
                {
                    temp[i, j, 0] = pic.image[i, j, 0];
                    temp[i, j, 1] = pic.image[i, j, 1];
                    temp[i, j, 2] = pic.image[i, j, 2];
                    temp[i, j, 3] = 0;
                }

            UndoStack.Push(pic.getHeight());
            UndoStack.Push(pic.getWidth());
            UndoStack.Push(temp);
        }

        #endregion

        /// <summary>
        /// Loads an Image into b. (saves original in o).
        /// </summary>
        /// <param name="f">The filename to load.</param>
        public void LoadImage(string f)
        {

            if (b != null)
                b.Dispose();
            if (o != null)
                b.Dispose();

            b = (Bitmap)Image.FromFile(f);
            o = (Bitmap)b.Clone(new Rectangle(0, 0, b.Width, b.Height), b.PixelFormat);

            if (pic == null)
                pic = new imageEdit(b);
            else
            {
                pic = null;
                pic = new imageEdit(b);
            }
            
        }

        #region Event Overrides

        /// <summary>
        /// Draws the Image in the Window
        /// </summary>
        /// <param name="e">Event Arguements</param>
        protected override void OnPaint(PaintEventArgs e)
        {

            if (b == null)
                return;

            if (this.WindowState == FormWindowState.Maximized)
                e.Graphics.DrawImage(b, (this.Width - b.Width*zoom) / 2, (this.Height - b.Height*zoom) / 2, b.Width*zoom, b.Height*zoom);
            else if (this.Width > b.Width*zoom + exW && this.Height > b.Height*zoom + exH)
                e.Graphics.DrawImage(b, (this.Width - b.Width*zoom) / 2, (this.Height - b.Height*zoom) / 2, b.Width*zoom, b.Height*zoom);
            else if (this.Width > b.Width*zoom + exW)
                e.Graphics.DrawImage(b, (this.Width - b.Width * zoom) / 2, 0, b.Width*zoom, b.Height*zoom);
            else if (this.Height > b.Height*zoom + exH)
                e.Graphics.DrawImage(b, 0, (this.Height - b.Height) / 2, b.Width*zoom, b.Height*zoom);
            else
                e.Graphics.DrawImage(b, 0, 0, b.Width*zoom, b.Height*zoom);

            base.OnPaint(e);
        }

        /// <summary>
        /// Makes sure the entire window redraws when resized
        /// </summary>
        /// <param name="e">Event Arguements</param>
        protected override void OnResize(EventArgs e)
        {
            this.Invalidate();
            base.OnResize(e);
        }

        /// <summary>
        /// updates the menu when the window gets focus
        /// </summary>
        /// <param name="e">Event Arguements</param>
        protected override void OnGotFocus(EventArgs e)
        {
            this.Invalidate();

            this.pappy.lblCh.Text = this.Text;
            this.pappy.lblZoom.Text = "" + this.zoom;

            if (UndoStack.Count > 0)
                this.undoToolStripMenuItem.Enabled = true;
            else
                this.undoToolStripMenuItem.Enabled = false;

            if (RedoStack.Count > 0)
                this.redoToolStripMenuItem.Enabled = true;
            else
                this.redoToolStripMenuItem.Enabled = false;

            base.OnGotFocus(e);
        }

        #endregion

        #region Event Handlers

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pappy.lblAction.Text = "Window Closed";
            if (hist != null)
                hist.Close();
            this.Close();
        }

        #region View Window Size Functions

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Invalidate();
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void sizeToImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Height = (int)(pic.getHeight()*zoom + exH);
            this.Width = (int)(pic.getWidth() * zoom + exW);
            this.Invalidate();
        }

        #endregion

        #region Undo/Redo/Restore Events

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreImage();
            if (hist != null)
                hist.UpdateHistogram();
            OnGotFocus(e);
            pappy.lblAction.Text = "Image Restored";
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pappy.lblAction.Text = "Undo Successful";
            Undo();
            if (hist != null)
                hist.UpdateHistogram();
            OnGotFocus(e);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pappy.lblAction.Text = "Redo Successful";
            Redo();
            if (hist != null)
                hist.UpdateHistogram();
            OnGotFocus(e);
        }

        private void clearStacksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pappy.lblAction.Text = "Stacks Cleared";
            RedoStack.Clear();
            UndoStack.Clear();
            OnGotFocus(e);
        }

        #endregion

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.Invert();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Inverted";
        }

        private void greyScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.GreyScale();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Grey Scaled";
        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            Selection sel = new Selection(this, 1);
            sel.ShowDialog();
            int val = System.Convert.ToInt32(sel.tbValue.Text);

            if (val > 255 || val < -255)
            {
                pic.UpdateBitmap(ref b);
            }
            else
            {
                pappy.lblAction.Text = "Brightness Adjusted";
                if (hist != null)
                    hist.UpdateHistogram();
            }
            sel.Dispose();
            OnGotFocus(e);
            this.Invalidate();
        }

        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            Selection sel = new Selection(this, 2);
            sel.ShowDialog();
            int val = System.Convert.ToInt32(sel.tbValue.Text);

            if (val > 100 || val < -100)
                pic.UpdateBitmap(ref b);
            else
            {
                pappy.lblAction.Text = "Contrast Altered";
                if (hist != null)
                    hist.UpdateHistogram();
            }
            sel.Dispose();
            OnGotFocus(e);
            this.Invalidate();
        }

        private void gammaCorrectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            Selection sel = new Selection(this, 3);
            sel.ShowDialog();
            double val = System.Convert.ToDouble(sel.tbValue.Text);

            if (val > 8 || val < 0)
                pic.UpdateBitmap(ref b);
            else
            {
                pappy.lblAction.Text = "Gamma Level Adjusted";
                if (hist != null)
                    hist.UpdateHistogram();
            }
            sel.Dispose();
            OnGotFocus(e);
            this.Invalidate();
        }

        private void adjustColorLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();

            ColorSelector cs = new ColorSelector(this);
            cs.ShowDialog();

            int red = System.Convert.ToInt32(cs.tbRed.Text);
            int green = System.Convert.ToInt32(cs.tbGreen.Text);
            int blue = System.Convert.ToInt32(cs.tbBlue.Text);

            if (red > 255 || green > 255 || blue > 255)
            {
                pic.UpdateBitmap(ref b);
            }
            else
            {
                pappy.lblAction.Text = "Color Levels Adjusted";
                if (hist != null)
                    hist.UpdateHistogram();
            }
            cs.Dispose();
            OnGotFocus(e);
            this.Invalidate();
        }

        #region Histogram events

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hist == null)
                hist = new HistogramWin(this);
            hist.Show();
            hist.UpdateHistogram();
            hist.BringToFront();
        }

        private void hideHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hist != null)
            {
                hist.Close();
                hist = null;
            }
        }

        #endregion

        #region Open/Save events

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OFD.InitialDirectory = "g:\\";
            OFD.Filter = "PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|Bitmap files (*.bmp)|*.bmp|JPG files (*.jpg)|*.jpg|All Valid Files (*.bmp/*.jpg/*.gif/*.png)|*.bmp;*.jpg;*.gif;*.png";
            OFD.FilterIndex = 5;
            OFD.RestoreDirectory = true;

            if (DialogResult.OK == OFD.ShowDialog())
            {
                try
                {
                    LoadImage(OFD.FileName);

                    //set the title of the child window.
                    this.Text = OFD.FileName;

                    this.fileloc = OFD.FileName;

                    //display the child window
                    this.Height = b.Height + exH;
                    this.Width = b.Width + exW;

                    RestoreImage();//for some reason Invert messes up without doing this first

                    if (hist != null)
                    {
                        hist.UpdateHistogram();
                    }
                }
                catch
                {
                    MessageBox.Show("Error opening image", "Expose", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "JPG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
            SFD.Title = "Save an Image File";

            if (DialogResult.OK == SFD.ShowDialog())
            {
                try
                {
                    // If the file name is not an empty string open it for saving.
                    if (SFD.FileName != "")
                    {
                        // Saves the Image via a FileStream created by the OpenFile method.
                        System.IO.FileStream fs = (System.IO.FileStream)SFD.OpenFile();
                        switch (SFD.FilterIndex)
                        {
                            case 1:
                                this.b.Save(fs,
                                   System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;

                            case 2:
                                this.b.Save(fs,
                                   System.Drawing.Imaging.ImageFormat.Bmp);
                                break;

                            case 3:
                                this.b.Save(fs,
                                   System.Drawing.Imaging.ImageFormat.Gif);
                                break;

                            case 4:
                                this.b.Save(fs,
                                    System.Drawing.Imaging.ImageFormat.Png);
                                break;
                        }

                        fs.Close();
                    }

                }
                catch
                {
                    MessageBox.Show("Error Saving Image", "Expose", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Zooms

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            zoom = 0.25f;
            this.Height = (int)(b.Height * zoom) + exH;
            this.Width = (int)(b.Width * zoom) + exW;

            pappy.lblZoom.Text = "" + zoom;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            zoom = 0.5f;
            this.Height = (int)(b.Height * zoom) + exH;
            this.Width = (int)(b.Width * zoom) + exW;
            pappy.lblZoom.Text = "" + zoom;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            zoom = 0.75f;
            this.Height = (int)(b.Height * zoom) + exH;
            this.Width = (int)(b.Width * zoom) + exW;
            pappy.lblZoom.Text = "" + zoom;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            zoom = 1.00f;
            this.Height = (int)(b.Height * zoom) + exH;
            this.Width = (int)(b.Width * zoom) + exW;
            pappy.lblZoom.Text = "" + zoom;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            zoom = 1.25f;
            this.Height = (int)(b.Height * zoom) + exH;
            this.Width = (int)(b.Width * zoom) + exW;
            pappy.lblZoom.Text = "" + zoom;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            zoom = 1.50f;
            this.Height = (int)(b.Height * zoom) + exH;
            this.Width = (int)(b.Width * zoom) + exW;
            pappy.lblZoom.Text = "" + zoom;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            zoom = 1.75f;
            this.Height = (int)(b.Height * zoom) + exH;
            this.Width = (int)(b.Width * zoom) + exW;
            pappy.lblZoom.Text = "" + zoom;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            zoom = 2.00f;
            this.Height = (int)(b.Height * zoom) + exH;
            this.Width = (int)(b.Width * zoom) + exW;
            pappy.lblZoom.Text = "" + zoom;
        }

        private void otherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom Z = new Zoom(this);
            Z.ShowDialog();
            this.Height = (int)(b.Height * zoom) + exH;
            this.Width = (int)(b.Width * zoom) + exW;
            pappy.lblZoom.Text = "" + zoom;
        }

        #endregion

        private void contrastStretchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.ContrastStretch();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Contrast Stretched";
        }

        private void horizontalFlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.FlipH();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Mirrored on X";
        }

        private void verticalFlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.FlipV();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Mirror on Y";
        }

        private void brightnessSliceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            BrSlice bS = new BrSlice(this);
            bS.ShowDialog();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            bS.Dispose();
        }

        #region Bit Masks

        private void posterizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.AndMask(192);
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Posterization";
        }

        private void bitClippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.AndMask(63);
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Bit Clipping";
        }

        private void firstBitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.AndMask(1);
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Bit Mask 00000001";
        }

        private void secondBitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.AndMask(2);
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Bit Mask 00000010";
        }

        private void thirdBitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.AndMask(4);
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Bit Mask 00000100";
        }

        private void fourthBitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.AndMask(8);
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Bit Mask 00001000";
        }

        private void fifthBitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.AndMask(16);
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Bit Mask 00010000";
        }

        private void sixthBitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.AndMask(32);
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Bit Mask 0010000";
        }

        private void seventhBitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.AndMask(64);
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Bit Mask 01000000";
        }

        private void eighthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.AndMask(128);
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Bit Mask 1000000";
        }

        private void customMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            BitMask BM = new BitMask(this);
            BM.ShowDialog();
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            BM.Dispose();
        }

        #endregion

        private void parabolicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.Parabol();
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Parabolic Transform";
        }

        private void inverseParabolicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.InverseParabol();
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Inverse Parabolic";
        }

        private void clockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.RotateClockwise();
            pic.UpdateBitmap(ref b);
            this.Height = b.Height + exH;
            this.Width = b.Width + exW;
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Rotated Clockwise 90";
        }

        private void counterClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.RotateCClockwise();
            pic.UpdateBitmap(ref b);
            this.Height = b.Height + exH;
            this.Width = b.Width + exW;
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Rotated Counter Clockwise 90";
        }

        private void addNoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            AddNoise AN = new AddNoise(this);
            AN.ShowDialog();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            AN.Dispose();
        }

        private void binaryThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            BinThresh BT = new BinThresh(this);
            BT.ShowDialog();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            BT.Dispose();
        }

        #region Multiple Images

        private void alphaBlendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            GetAlpha GA = new GetAlpha(this);
            GA.ShowDialog();
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            GA.Dispose();
        }

        private void imageDifferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.ImageDifferencing();
            pappy.lblAction.Text = "Image Difference";
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
        }

        private void imageRatioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.ImageRatio();
            pappy.lblAction.Text = "Image Ratio";
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
        }

        private void andImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.ImageAnd();
            pappy.lblAction.Text = "Image AND";
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
        }

        private void oRImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.ImageOR();
            pappy.lblAction.Text = "Image OR";
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
        }

        private void xORImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.ImageXOR();
            pappy.lblAction.Text = "Image XOR";
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
        }

        private void imageAveragingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pic.ImageAverage();
            pappy.lblAction.Text = "Image Average";
            pic.UpdateBitmap(ref b);
            changed = true;
            OnGotFocus(e);
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
        }

        #endregion

        #region Low Pass

        #region Spatial Means

        private void lowPass9ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Low Pass 9...";
            pic.Low3Filter(1, 1, 1,
                            1, 1, 1,
                            1, 1, 1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Low Pass 9";
        }

        private void lowPass16ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pappy.lblAction.Text = "Low Pass 16...";
            addToUndo();
            pic.Low3Filter(1, 2, 1,
                            2, 4, 2,
                            1, 2, 1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Low Pass 16";
        }

        private void otherToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            addToUndo();
            MatrixInput MI = new MatrixInput(this, 1);
            MI.ShowDialog();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            MI.Dispose();
        }

        #endregion

        #region Spatial Statistic

        private void medianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Median Filter...";
            pic.MedianFilter(this);
            pic.UpdateBitmap(ref b);
            pappy.lblAction.Text = "Median Filter";
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            OnGotFocus(e);
            this.Invalidate();
        }

        private void minToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Min Filter...";
            pic.MinFilter(this);
            pic.UpdateBitmap(ref b);
            pappy.lblAction.Text = "Min Filter";
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            OnGotFocus(e);
            this.Invalidate();
        }

        private void maxFilterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Max Filter...";
            pic.MaxFilter(this);
            pic.UpdateBitmap(ref b);
            pappy.lblAction.Text = "Max Filter";
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            OnGotFocus(e);
            this.Invalidate();
        }

        private void modeFilterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Mode Filter...";
            pic.ModeFilter(this);
            pic.UpdateBitmap(ref b);
            pappy.lblAction.Text = "Mode Filter";
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            OnGotFocus(e);
            this.Invalidate();
        }

        private void midPointFilterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Mid Point Filter...";
            pic.MidFilter(this);
            pic.UpdateBitmap(ref b);
            pappy.lblAction.Text = "Mid Point Filter";
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            OnGotFocus(e);
            this.Invalidate();
        }

        #endregion

        private void washFilterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Mid Point Filter...";
            pic.WashFilter(this);
            pic.UpdateBitmap(ref b);
            pappy.lblAction.Text = "Mid Point Filter";
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            OnGotFocus(e);
            this.Invalidate();
        }

        private void horizontalBlurToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Mid Point Filter...";
            pic.HorizBlur(1, 1, 1, 1, 1, 1, 1, 1, 1, this);
            pic.UpdateBitmap(ref b);
            pappy.lblAction.Text = "Mid Point Filter";
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            OnGotFocus(e);
            this.Invalidate();
        }

        #endregion

        #region High Pass

        private void highPass9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "High Pass 9...";
            pic.High3Filter(-1, -1, -1,
                            -1, 9, -1,
                            -1, -1, -1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "High Pass 9";
        }

        private void highPass50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "High Pass 5-0...";
            pic.High3Filter(0, -1, 0,
                            -1, 5, -1,
                             0, -1, 0, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "High Pass 5-0";
        }

        private void highPass51ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "High Pass 5-1...";
            pic.High3Filter(1, -2, 1,
                            -2, 5, -2,
                             1, -2, 1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "High Pass 5-1";
        }

        private void otherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addToUndo();
            MatrixInput MI = new MatrixInput(this, 2);
            MI.ShowDialog();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            MI.Dispose();
        }

        #endregion

        private void unsharpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "High Pass 9...";
            pic.Unsharp(this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "High Pass 9";
        }

        #region Laplacian

        private void laplacian4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Laplacian 4...";
            pic.Laplacian3Filter(0, -1, 0,
                                 -1, 4, -1,
                                  0, -1, 0, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Laplacian 4";
        }

        private void laplacian8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Laplacian 4...";
            pic.Laplacian3Filter(-1, -1, -1,
                                 -1, 8, -1,
                                 -1, -1, -1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Laplacian 4";
        }

        private void otherToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            addToUndo();
            MatrixInput MI = new MatrixInput(this, 3);
            MI.ShowDialog();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            MI.Dispose();
        }

        #endregion

        #region Shift And Differnce

        private void horizontalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Horizontal Shift and Difference...";
            pic.Laplacian3Filter(0, -1, 0,
                                 0, 1, 0,
                                 0, 0, 0, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Horizontal Shift and Difference";
        }

        private void verticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Vertical Shift and Difference...";
            pic.Laplacian3Filter(0, 0, 0,
                                 -1, 1, 0,
                                 0, 0, 0, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Vertical Shift and Difference";
        }

        private void diagonalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Diagonal Shift and Difference...";
            pic.Laplacian3Filter(-1, 0, 0,
                                 0, 1, 0,
                                 0, 0, 0, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Diagonal Shift and Difference";
        }

        #endregion

        #region Complex Directional

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Horizontal Complex Directional...";
            pic.Laplacian3Filter(-1, -1, -1,
                                  2,  2,  2,
                                 -1, -1, -1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Horizontal Complex Directional";
        }

        private void degreesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "+45 Complex Directional...";
            pic.Laplacian3Filter( -1,-1, 2,
                                  -1, 2,-1,
                                   2,-1,-1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "+45 Complex Directional";

        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Vertical Complex Directional...";
            pic.Laplacian3Filter(-1,2,-1,
                                 -1,2,-1,
                                 -1,2,-1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Vertical Complex Directional";
        }

        private void degreesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "-45 Complex Directional...";
            pic.Laplacian3Filter( 2,-1,-1,
                                 -1, 2,-1,
                                 -1,-1, 2, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "-45 Complex Directional";
        }

        #endregion

        #region Compass Gradient

        private void eastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "East Compass Gradient...";
            pic.Laplacian3Filter(1, 0,-1,
                                 1, 0,-1,
                                 1, 0,-1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "East Compass Gradient";
        }

        private void northEastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "North-East Compass Gradient...";
            pic.Laplacian3Filter(0, -1, -1,
                                 1, 0, -1,
                                 1, 1, 0, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "North-East Compass Gradient";
        }

        private void northToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "North Compass Gradient...";
            pic.Laplacian3Filter(-1, -1, -1,
                                  0, 0, 0,
                                  1, 1, 1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "North Compass Gradient";
        }

        private void northWestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "North-West Compass Gradient...";
            pic.Laplacian3Filter(-1, -1, 0,
                                 -1, 0, 1,
                                  0, 1, 1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "North-West Compass Gradient";
        }

        private void westToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "West Compass Gradient...";
            pic.Laplacian3Filter(-1, 0, 1,
                                 -1, 0, 1,
                                 -1, 0, 1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "West Compass Gradient";
        }

        private void southWestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "South-West Compass Gradient...";
            pic.Laplacian3Filter(0, 1, 1,
                                 -1, 0, 1,
                                 -1, -1, 0, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "South-West Compass Gradient";
        }

        private void southToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "South Compass Gradient...";
            pic.Laplacian3Filter(1, 1, 1,
                                  0, 0, 0,
                                 -1, -1, -1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "South Compass Gradient";
        }

        private void southToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "South-East Compass Gradient...";
            pic.Laplacian3Filter(1, 1, 0,
                                 1, 0, -1,
                                 0, -1, -1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "South-East Compass Gradient";
        }

        #endregion

        #region Sobel Operator

        private void horizontalToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Y-Axis Sobel Operator...";
            pic.Laplacian3Filter(1, 2, 1,
                                  0, 0, 0,
                                 -1, -2, -1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Y-Axis Sobel Operator";
        }

        private void verticalToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "X-Axis Sobel Operator...";
            pic.Laplacian3Filter(-1, 0, 1,
                                 -2, 0, 2,
                                 -1, 0, 1, this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "X-Axis Sobel Operator";
        }

        private void sumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Sum Sobel Operator...";
            pic.Sobel3Filter(this);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Sum Sobel Operator";
        }


        #endregion

        private void createCertaintyMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Create Certainty Matrix...";
            pic.setupNormalizedConvolution();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Create Certainty Matrix";
        }


        #endregion

        private void blurMatraciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Blur Images...";
            pic.blurImages2();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Blur Images";
        }

        private void showCertaintyMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Show Certainty Matrix...";
            pic.showCertainty();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Show Certainty Matrix";
        }

        private void divideResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Divide Certainty Matrix...";
            pic.divideResults();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Divide Certainty Matrix";
        }

        private void radialWeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Blur Images...";
            pic.radialWeight(3,0);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Blur Images";
        }

        private void radialWeight2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Blur Images...";
            pic.radialWeight(0, 2);
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Blur Images";
        }

        private void inputRadialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToUndo();
            pappy.lblAction.Text = "Blur Images...";
            pic.radialWeight();
            pic.UpdateBitmap(ref b);
            changed = true;
            if (hist != null)
                hist.UpdateHistogram();
            this.Invalidate();
            OnGotFocus(e);
            pappy.lblAction.Text = "Blur Images";
        }

    }
}
