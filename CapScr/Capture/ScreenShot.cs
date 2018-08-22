using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CapScr.Capture
{
    public class ScreenShot
    {
        private System.Drawing.Imaging.PixelFormat mPixFor = System.Drawing.Imaging.PixelFormat.Format32bppArgb;

        public System.Drawing.Imaging.PixelFormat PixelFormat
        {
            get
            {
                return mPixFor;
            }
            set
            {
                mPixFor = value;
            }
        }

        public Bitmap CreateBitmapFromScreen(Size sSize, Point pLocation)
        {
            try
            {
                if (sSize != null && pLocation != null && !sSize.IsEmpty)
                {
                    Bitmap bmap = new Bitmap(sSize.Width, sSize.Height, mPixFor);
                    if (bmap != null)
                    {
                        System.Drawing.Graphics gFX = Graphics.FromImage(bmap);
                        if (gFX != null)
                        {
                            gFX.CopyFromScreen(pLocation.X, pLocation.Y, 0, 0, sSize, CopyPixelOperation.SourceCopy);

                            return bmap;
                        }
                    }
                }
                return null;
            } catch (Exception ex)
            {
                Log.Logger.Log("CreateBitmapFromScreen", ex);
                return null;
            }
        }
    }
}
