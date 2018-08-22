using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapScr.Capture
{
    public partial class CaptureScreen : Form
    {
        public event EventHandler DeaktivateForms;
        public bool bInternalCall = false;
        public Bitmap FormBackgroundCaptur;
        public Bitmap SelectedImageArea { get; set; }
        public List<Bitmap> MultiselectedImageArea { get; set; }
        public bool IsDirty { get; set; }

        /*mouse select area*/
        private System.Drawing.Point RectStartPoint;
        private Rectangle Rect = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));


        public CaptureScreen()
        {
            InitializeComponent();

            this.Opacity = 1.0f;
            this.pictureBox1.BackColor = Color.FromArgb(100, Color.Gray);
            this.FormBackgroundCaptur = this.BackgroundImage as Bitmap;
            this.MultiselectedImageArea = new List<Bitmap>();
            this.IsDirty = false;
        }

        #region Form Events
        private void CaptureScreen_Leave(object sender, EventArgs e)
        {
            //this.Close();
            OnDeaktivateForms();
        }

        private void CaptureScreen_Deactivate(object sender, EventArgs e)
        {
            if (!bInternalCall)
            {
                OnDeaktivateForms();
            }
        }
        #endregion

        /// <summary>
        /// will be called if the form or control lost it focus
        /// </summary>
        protected virtual void OnDeaktivateForms()
        {
            EventHandler handler = DeaktivateForms;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        #region Control Events
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.FormBackgroundCaptur == null)
            {
                this.FormBackgroundCaptur = this.BackgroundImage as Bitmap;
            }

            System.Diagnostics.Debug.Print("mouse down");
            RectStartPoint = e.Location;
            Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            System.Diagnostics.Debug.Print("mouse move");
            Point tempEndPoint = e.Location;
            Rect.Location = new Point(Math.Min(RectStartPoint.X, tempEndPoint.X), Math.Min(RectStartPoint.Y, tempEndPoint.Y));
            Rect.Size = new Size(Math.Abs(RectStartPoint.X - tempEndPoint.X), Math.Abs(RectStartPoint.Y - tempEndPoint.Y));
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                System.Diagnostics.Debug.Print("left mouse up");
                //picture open/save dialog
                this.Close();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
            {
                Pen blackPen = new Pen(Color.Black);
                this.SelectedImageArea = Global.Helper.CropImage(FormBackgroundCaptur, Rect);
                e.Graphics.DrawImage(SelectedImageArea, Rect);
                e.Graphics.DrawRectangle(blackPen, Rect);
                //e.Graphics.FillRectangle(selectionBrush, Rect);
                System.Diagnostics.Debug.Print("paint picture");
            }
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                //exit
                this.IsDirty = true;
                this.Close();
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            OnDeaktivateForms();
        }
        #endregion

    }
}
