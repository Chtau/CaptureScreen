using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapScr
{
    public partial class CapScr : Form
    {
        private Capture.Capture mCap;

        public CapScr()
        {
            InitializeComponent();

            HasImageToShow(false);

            mCap = new Capture.Capture();
            mCap.AfterFullInit += mCap_AfterFullInit;
            mCap.AfterClosingCapture += mCap_AfterClosingCapture;
            mCap.AfterInitCapture += mCap_AfterInitCapture;
            mCap.BeforeStartCapture += mCap_BeforeStartCapture;

            this.Icon = global::CapScr.Resources.ResourceImages.onebit_301;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (mCap != null)
            {
                mCap.AfterFullInit -= mCap_AfterFullInit;
                mCap.AfterClosingCapture -= mCap_AfterClosingCapture;
                mCap.AfterInitCapture -= mCap_AfterInitCapture;
                mCap.BeforeStartCapture -= mCap_BeforeStartCapture;
                mCap.Dispose();
                mCap = null;
            }
            base.OnClosing(e);
        }

        #region Capture Events
        void mCap_BeforeStartCapture(object sender, EventArgs e)
        {
            try
            {
                this.Opacity = 0;
            }
            catch (Exception ex)
            {
                Log.Logger.Log("mCap_BeforeStartCapture", ex);
            }
        }

        void mCap_AfterInitCapture(object sender, EventArgs e)
        {
            try
            {
                this.Opacity = 100;
                this.BringToFront();
            }
            catch (Exception ex)
            {
                Log.Logger.Log("mCap_AfterInitCapture", ex);
            }
        }

        void mCap_AfterFullInit(object sender, EventArgs e)
        {
            try
            {
                CaptureIsVisible(true);
            }
            catch (Exception ex)
            {
                Log.Logger.Log("mCap_AfterFullInit", ex);
            }
        }

        void mCap_AfterClosingCapture(object sender, EventArgs e)
        {
            try
            {
                CaptureIsVisible(false);
                if (mCap.ScreenCapture != null)
                {
                    LoadBitmap(mCap.ScreenCapture);
                    mCap.Dispose();
                }
            } catch (Exception ex)
            {
                Log.Logger.Log("mCap_AfterClosingCapture", ex);
            }
        }
        #endregion

        #region Methods
        private bool LoadBitmap(Bitmap bm)
        {
            try
            {
                if (bm != null)
                {

                    HasImageToShow(true);

                    picCapture.Height = bm.Height;
                    picCapture.Width = bm.Width;
                    picCapture.Image = bm;
                    int newHeight = (40 + tsMain.Height + picCapture.Height + ssImageStatus.Height + 20);
                    int newWidth = (30 + picCapture.Width);
                    if (newWidth < 400)
                    {
                        newWidth = 400;
                    }
                    this.MinimumSize = new System.Drawing.Size(newWidth, newHeight);
                    this.Height = newHeight;
                    this.Width = newWidth;
                    

                    Global.Helper.CenterControl(ref plPicContent, ref picCapture);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Logger.Log("LoadBitmap", ex);
                return false;
            }
        }

        private void HasImageToShow(bool HasImage)
        {
            try
            {
                ImageSaveState(false, "", true);
                this.plInfo.Visible = !HasImage;
                this.plPicContent.Visible = HasImage;
                this.tssbtnSave.Enabled = HasImage;
                this.tsbtnSendToClip.Enabled = HasImage;

                if (HasImage)
                {

                } else
                {
                    picCapture.Image = null;
                    //this.MinimumSize = new System.Drawing.Size(this.Width, 130);
                    this.MinimumSize = new System.Drawing.Size(450, 130);
                    this.Height = 130;
                    this.Width = 450;
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Log("HasImageToShow", ex);
            }
        }

        private void ImageSaveState(bool IsSaved, string fileLink = "", bool newCaputr = false)
        {
            try
            {
                this.tsslblImageState.Visible = !newCaputr;
                if (!newCaputr)
                {
                    if (IsSaved)
                    {
                        this.tsslblImageState.Text = "Image saved";
                        this.tsslblImageState.ForeColor = Color.Green;
                        if (!string.IsNullOrEmpty(fileLink))
                        {
                            this.tsslblImageLink.Text = fileLink;
                            this.tsslblImageLink.Visible = true;
                        }
                        else
                        {
                            this.tsslblImageLink.Text = "";
                            this.tsslblImageLink.Visible = false;
                        }
                    }
                    else
                    {
                        this.tsslblImageState.Text = "couldn't save Image";
                        this.tsslblImageState.ForeColor = Color.Red;
                        this.tsslblImageLink.Text = "";
                        this.tsslblImageLink.Visible = false;
                    }
                } else
                {
                    this.tsslblImageState.Text = "";
                    this.tsslblImageLink.Text = "";
                    this.tsslblImageLink.Visible = false;
                }
                
            }
            catch (Exception ex)
            {
                Log.Logger.Log("ImageSaveState", ex);
            }
        }

        private void CaptureIsVisible(bool IsVisible)
        {
            try
            {
                if (IsVisible)
                {
                    
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Log("CaptureIsVisible", ex);
            }
        }
        #endregion

        #region GUI Events
        private void tssbtnNewCap_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (mCap != null)
                {
                    mCap.InitScreens();
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Log("tssbtnNewCap_ButtonClick", ex);
            }
        }

        private void tssbtnClearCapture_Click(object sender, EventArgs e)
        {
            try
            {
                HasImageToShow(false);
            }
            catch (Exception ex)
            {
                Log.Logger.Log("tssbtnClearCapture_Click", ex);
            }
        }

        private void tssbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.DefaultExt = "jpg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = dialog.FileName;
                    if (Global.Helper.CheckDirectoryAccess(System.IO.Path.GetDirectoryName(strFileName)))
                    {
                        if (Global.Helper.SaveImage(picCapture.Image, strFileName))
                        {
                            ImageSaveState(true, strFileName);
                        } else
                        {
                            MessageBox.Show("Error while saving the Capture!");
                            ImageSaveState(false);
                        }
                    } else
                    {
                        MessageBox.Show("You have no access in the selected Directory to save a file!");
                        ImageSaveState(false);
                    }
                } 
            }
            catch (Exception ex)
            {
                Log.Logger.Log("tssbtnSave_Click", ex);
            }
        }

        private void tsslblImageLink_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tsslblImageLink.Text))
                {
                    System.Diagnostics.Process.Start(tsslblImageLink.Text);
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Log("tsslblImageLink_Click", ex);
            }
        }

        private void tsbtnSendToClip_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.picCapture.Image != null)
                {
                    Clipboard.SetImage(this.picCapture.Image);
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Log("tsbtnSendToClip_Click", ex);
            }
        }
#endregion

        private void tssbtnOptions_Click(object sender, EventArgs e)
        {
            try
            {
                Settings se = new Settings();
                if (se.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
                Log.Logger.Log("tssbtnOptions_Click", ex);
            }
        }

    }
}
