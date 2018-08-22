using System;
using System.Drawing;
using System.Security.AccessControl;

namespace CapScr.Global
{
    public static class Helper
    {
        public static bool SaveImage(Image img, string fileName)
        {
            try
            {
                if (img != null)
                {
                    img.Save(fileName);
                    return true;
                }
                return false;
            } catch (Exception ex)
            {
                Log.Logger.Log("SaveImage", ex);
                return false;
            }
        }

        /// <summary>
        /// True if the application is allowed to access the directory
        /// </summary>
        /// <param name="strDirectory"></param>
        /// <returns></returns>
        public static bool CheckDirectoryAccess(string strDirectory)
        {
            if (!string.IsNullOrEmpty(strDirectory))
            {
                try
                {
                    DirectorySecurity mDirSec = System.IO.Directory.GetAccessControl(strDirectory);
                    return true;
                }
                catch (UnauthorizedAccessException UAex)
                {
                    System.Diagnostics.Debug.Print(string.Format("No Access or write Access to the Directory:'{0}' Error:'{1}'", strDirectory, UAex.Message));
                }
            }
            return false;
        }

        /// <summary>
        /// Check if the current active window is from our own application
        /// </summary>
        /// <returns>true if it is our own window</returns>
        public static bool FormsAreActivate()
        {
            try
            {
                IntPtr hWND = Nativ.GetForegroundWindow();
                if (hWND == IntPtr.Zero)
                {
                    return false;
                }

                int procId = System.Diagnostics.Process.GetCurrentProcess().Id;
                int activeProcId;
                Nativ.GetWindowThreadProcessId(hWND, out activeProcId);

                return activeProcId == procId;
            } catch (Exception ex)
            {
                Log.Logger.Log("FormsAreActivate", ex);
                return false;
            }
        }

        public static Bitmap CropImage(Bitmap source, Rectangle section)
        {
            // An empty bitmap which will hold the cropped image
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            Graphics g = Graphics.FromImage(bmp);

            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }

        /// <summary>
        /// Center the ctrlInner Control in the ctrlHolder Control
        /// </summary>
        /// <param name="ctrlHolder">Panel which is the holder Control (as referenz)</param>
        /// <param name="ctrlInner">PictureBox which is the inner Control (as referenz)</param>
        /// <returns></returns>
        public static bool CenterControl(ref System.Windows.Forms.Panel ctrlHolder, ref System.Windows.Forms.PictureBox ctrlInner)
        {
            if (ctrlHolder != null && ctrlInner != null)
            {
                int xPad = (ctrlHolder.Width - ctrlInner.Width) / 2;
                int yPad = (ctrlHolder.Height - ctrlInner.Height) / 2;
                ctrlInner.Location = new Point(xPad, yPad);

                return true;
            }
            return false;
        }
    }
}
