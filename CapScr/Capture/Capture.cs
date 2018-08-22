using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapScr.Capture
{
    public class Capture : IDisposable
    {
        public event EventHandler AfterFullInit;
        public event EventHandler AfterClosingCapture;
        public event EventHandler BeforeStartCapture;
        public event EventHandler AfterInitCapture;

        /// <summary>
        /// Bitmap which was captured
        /// </summary>
        public Bitmap ScreenCapture 
        { 
            get { return myScreenCapture; } 
        }

        List<CaptureScreen> lCScr;
        ScreenShot scrShot;
        Bitmap myScreenCapture;
        bool IsDisposed = false;

        public void Dispose()
        {
            DeaktivateCloseCapScr(false);
            if (lCScr != null)
            {
                lCScr.Clear();
                lCScr = null;
            }
            scrShot = null;
            myScreenCapture = null;
        }

        /// <summary>
        /// Initialzie the Screen caputre function
        /// </summary>
        public void InitScreens()
        {
            try
            {
                this.IsDisposed = false;
                this.myScreenCapture = null;

                OnBeforeStartCapture();

                DeaktivateCloseCapScr(false);              

                lCScr = new List<CaptureScreen>();
                scrShot = new ScreenShot();

                //InitCaptureControlToScreen(Screen.AllScreens[0]); //Only for debug/test single screen

                foreach (Screen scr in Screen.AllScreens)
	            {
                    InitCaptureControlToScreen(scr);
	            }

                foreach (CaptureScreen mCap in lCScr)
                {
                    if (mCap != null)
                    {
                        mCap.bInternalCall = false;
                    }
                }

                OnAfterFullInit();
            } catch (Exception ex)
            {
                Log.Logger.Log("InitScreens", ex);
                DeaktivateCloseCapScr();
            } finally
            {
                OnAfterInitCapture();
            }
        }

        #region Events
        protected virtual void OnAfterFullInit()
        {
            EventHandler handler = AfterFullInit;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        protected virtual void OnAfterClosingCapture()
        {
            EventHandler handler = AfterClosingCapture;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        protected virtual void OnBeforeStartCapture()
        {
            EventHandler handler = BeforeStartCapture;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        protected virtual void OnAfterInitCapture()
        {
            EventHandler handler = AfterInitCapture;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
        #endregion

        private void DeaktivateCloseCapScr(bool bFireEvent = true)
        {
            try
            {
                if (lCScr != null)
                {
                    if (lCScr.Count > 0)
                    {
                        foreach (CaptureScreen cscr in lCScr)
                        {
                            if (cscr != null)
                            {
                                cscr.Close();
                                cscr.Dispose();
                            }
                        }
                    }
                    lCScr = null;
                }
                if (bFireEvent)
                    OnAfterClosingCapture();
            } catch (Exception ex)
            {
                Log.Logger.Log("DeaktivateCloseCapScr", ex);
            }
        }

        /// <summary>
        /// Initialize the CaptureScreen Control for the Screen
        /// </summary>
        /// <param name="mScr">the Screen on which the form should be shown</param>
        private void InitCaptureControlToScreen(Screen mScr)
        {
            try
            {
                System.Drawing.Point pLocation = new System.Drawing.Point(mScr.Bounds.Location.X, mScr.Bounds.Location.Y);
                System.Drawing.Size sSize = new System.Drawing.Size(mScr.Bounds.Size.Width, mScr.Bounds.Size.Height);
                //System.Drawing.Size sSize = new System.Drawing.Size(200,200); //debug on one screen
                lCScr.Add(new CaptureScreen());
                int mCurCS = lCScr.Count - 1;
                lCScr[mCurCS].bInternalCall = true;
                lCScr[mCurCS].Location = pLocation;
                lCScr[mCurCS].Size = sSize;
                lCScr[mCurCS].Tag = mScr.DeviceName + mCurCS;
                lCScr[mCurCS].DeaktivateForms += Capture_DeaktivateForms;
                lCScr[mCurCS].BackgroundImage = scrShot.CreateBitmapFromScreen(sSize, pLocation);
                lCScr[mCurCS].FormClosing += Capture_FormClosing;
                lCScr[mCurCS].Show();

            } catch (Exception ex)
            {
                Log.Logger.Log("InitCaptureControlToScreen", ex);
            }
        }

        #region Events CaptureScreen Form
        void Capture_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!IsDisposed)
                {
                    System.Diagnostics.Debug.Print("CaptureScreen closing");
                    if (lCScr != null && lCScr.Count > 0)
                    {
                        //get the captured image from the screen
                        foreach (CaptureScreen item in lCScr)
                        {
                            if (item.SelectedImageArea != null)
                            {
                                this.myScreenCapture = item.SelectedImageArea;
                            }
                            item.Dispose();
                        }
                        IsDisposed = true;
                    }

                    OnAfterClosingCapture();
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Log("Capture_FormClosing", ex);
            }
        }


        void Capture_DeaktivateForms(object sender, EventArgs e)
        {
            try
            {
                //Only close the forms if no own screencapture form has focus
                if (!Global.Helper.FormsAreActivate())
                {
                    DeaktivateCloseCapScr(false);
                }
            } catch (Exception ex)
            {
                Log.Logger.Log("Capture_DeaktivateForms", ex);
            }
        }
        #endregion

    }
}
