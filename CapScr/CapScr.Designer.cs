namespace CapScr
{
    partial class CapScr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CapScr));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tssbtnNewCap = new System.Windows.Forms.ToolStripSplitButton();
            this.tssbtnClearCapture = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tssbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSendToClip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tssbtnOptions = new System.Windows.Forms.ToolStripButton();
            this.plPicContent = new System.Windows.Forms.Panel();
            this.ssImageStatus = new System.Windows.Forms.StatusStrip();
            this.tsslblImageState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblImageLink = new System.Windows.Forms.ToolStripStatusLabel();
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.plInfo = new System.Windows.Forms.Panel();
            this.lblInfoText = new System.Windows.Forms.Label();
            this.tsMain.SuspendLayout();
            this.plPicContent.SuspendLayout();
            this.ssImageStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            this.plInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.BackColor = System.Drawing.Color.Transparent;
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssbtnNewCap,
            this.toolStripSeparator2,
            this.tssbtnSave,
            this.tsbtnSendToClip,
            this.toolStripSeparator1,
            this.tssbtnOptions});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.MinimumSize = new System.Drawing.Size(0, 50);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(529, 50);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // tssbtnNewCap
            // 
            this.tssbtnNewCap.AutoToolTip = false;
            this.tssbtnNewCap.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssbtnClearCapture});
            this.tssbtnNewCap.Image = global::CapScr.Resources.ResourceImages.onebit_30;
            this.tssbtnNewCap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbtnNewCap.Name = "tssbtnNewCap";
            this.tssbtnNewCap.Size = new System.Drawing.Size(79, 47);
            this.tssbtnNewCap.Text = "New";
            this.tssbtnNewCap.ButtonClick += new System.EventHandler(this.tssbtnNewCap_ButtonClick);
            // 
            // tssbtnClearCapture
            // 
            this.tssbtnClearCapture.Name = "tssbtnClearCapture";
            this.tssbtnClearCapture.Size = new System.Drawing.Size(146, 22);
            this.tssbtnClearCapture.Text = "Clear Capture";
            this.tssbtnClearCapture.Click += new System.EventHandler(this.tssbtnClearCapture_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 50);
            // 
            // tssbtnSave
            // 
            this.tssbtnSave.Enabled = false;
            this.tssbtnSave.Image = global::CapScr.Resources.ResourceImages.onebit_11;
            this.tssbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbtnSave.Name = "tssbtnSave";
            this.tssbtnSave.Size = new System.Drawing.Size(67, 47);
            this.tssbtnSave.Text = "Save";
            this.tssbtnSave.Click += new System.EventHandler(this.tssbtnSave_Click);
            // 
            // tsbtnSendToClip
            // 
            this.tsbtnSendToClip.Enabled = false;
            this.tsbtnSendToClip.Image = global::CapScr.Resources.ResourceImages._005;
            this.tsbtnSendToClip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSendToClip.Name = "tsbtnSendToClip";
            this.tsbtnSendToClip.Size = new System.Drawing.Size(71, 47);
            this.tsbtnSendToClip.Text = "Copy";
            this.tsbtnSendToClip.Click += new System.EventHandler(this.tsbtnSendToClip_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // tssbtnOptions
            // 
            this.tssbtnOptions.Image = global::CapScr.Resources.ResourceImages.onebit_38;
            this.tssbtnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbtnOptions.Name = "tssbtnOptions";
            this.tssbtnOptions.Size = new System.Drawing.Size(76, 47);
            this.tssbtnOptions.Text = "About";
            this.tssbtnOptions.Click += new System.EventHandler(this.tssbtnOptions_Click);
            // 
            // plPicContent
            // 
            this.plPicContent.BackColor = System.Drawing.Color.Transparent;
            this.plPicContent.Controls.Add(this.ssImageStatus);
            this.plPicContent.Controls.Add(this.picCapture);
            this.plPicContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plPicContent.Location = new System.Drawing.Point(0, 90);
            this.plPicContent.Name = "plPicContent";
            this.plPicContent.Size = new System.Drawing.Size(529, 188);
            this.plPicContent.TabIndex = 2;
            this.plPicContent.Visible = false;
            // 
            // ssImageStatus
            // 
            this.ssImageStatus.BackColor = System.Drawing.Color.White;
            this.ssImageStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblImageState,
            this.tsslblImageLink});
            this.ssImageStatus.Location = new System.Drawing.Point(0, 166);
            this.ssImageStatus.Name = "ssImageStatus";
            this.ssImageStatus.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.ssImageStatus.Size = new System.Drawing.Size(529, 22);
            this.ssImageStatus.TabIndex = 2;
            this.ssImageStatus.Text = "statusStrip1";
            // 
            // tsslblImageState
            // 
            this.tsslblImageState.Name = "tsslblImageState";
            this.tsslblImageState.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslblImageLink
            // 
            this.tsslblImageLink.IsLink = true;
            this.tsslblImageLink.Name = "tsslblImageLink";
            this.tsslblImageLink.Size = new System.Drawing.Size(0, 17);
            this.tsslblImageLink.Click += new System.EventHandler(this.tsslblImageLink_Click);
            // 
            // picCapture
            // 
            this.picCapture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCapture.Location = new System.Drawing.Point(77, 71);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(239, 46);
            this.picCapture.TabIndex = 0;
            this.picCapture.TabStop = false;
            // 
            // plInfo
            // 
            this.plInfo.Controls.Add(this.lblInfoText);
            this.plInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.plInfo.Location = new System.Drawing.Point(0, 50);
            this.plInfo.Name = "plInfo";
            this.plInfo.Size = new System.Drawing.Size(529, 40);
            this.plInfo.TabIndex = 3;
            // 
            // lblInfoText
            // 
            this.lblInfoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfoText.Location = new System.Drawing.Point(0, 0);
            this.lblInfoText.Name = "lblInfoText";
            this.lblInfoText.Padding = new System.Windows.Forms.Padding(5);
            this.lblInfoText.Size = new System.Drawing.Size(529, 40);
            this.lblInfoText.TabIndex = 0;
            this.lblInfoText.Text = "Click the \"New\" Button to Capture an Area of the Screen";
            // 
            // CapScr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(529, 278);
            this.Controls.Add(this.plPicContent);
            this.Controls.Add(this.plInfo);
            this.Controls.Add(this.tsMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CapScr";
            this.Text = "CapScr";
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.plPicContent.ResumeLayout(false);
            this.plPicContent.PerformLayout();
            this.ssImageStatus.ResumeLayout(false);
            this.ssImageStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            this.plInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripSplitButton tssbtnNewCap;
        private System.Windows.Forms.Panel plPicContent;
        private System.Windows.Forms.ToolStripButton tssbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tssbtnOptions;
        private System.Windows.Forms.Panel plInfo;
        private System.Windows.Forms.Label lblInfoText;
        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.ToolStripMenuItem tssbtnClearCapture;
        private System.Windows.Forms.StatusStrip ssImageStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslblImageState;
        private System.Windows.Forms.ToolStripStatusLabel tsslblImageLink;
        private System.Windows.Forms.ToolStripButton tsbtnSendToClip;

    }
}

