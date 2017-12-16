
    partial class MiniRTDVForm
    {

        private System.ComponentModel.Container components = null;
    
    public MiniRTDVForm()
    {
        InitializeComponent();
    }



    protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pictureBox_MiniRTDV = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MiniRTDV)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_MiniRTDV
            // 
            this.pictureBox_MiniRTDV.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox_MiniRTDV.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_MiniRTDV.Name = "pictureBox_MiniRTDV";
            this.pictureBox_MiniRTDV.Size = new System.Drawing.Size(640, 480);
            this.pictureBox_MiniRTDV.TabIndex = 0;
            this.pictureBox_MiniRTDV.TabStop = false;
            this.pictureBox_MiniRTDV.Click += new System.EventHandler(this.pictureBox_MiniRTDV_Click);
            this.pictureBox_MiniRTDV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MiniRTDVForm_ReceivedImage_MouseDown);
            this.pictureBox_MiniRTDV.MouseEnter += new System.EventHandler(this.pictureBox_MiniRTDV_MouseEnter);
            this.pictureBox_MiniRTDV.MouseLeave += new System.EventHandler(this.pictureBox_MiniRTDV_MouseLeave);
            this.pictureBox_MiniRTDV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MiniRTDVForm_ReceivedImage_MouseMove);
            this.pictureBox_MiniRTDV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MiniRTDVForm_ReceivedImage_MouseUp);
            // 
            // MiniRTDVForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(638, 478);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox_MiniRTDV);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MiniRTDVForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MiniRTDVForm_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MiniRTDVForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MiniRTDVForm_KeyUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MiniRTDVForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MiniRTDV)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion    
}