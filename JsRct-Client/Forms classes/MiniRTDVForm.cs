using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctClient;
using YakSys.XMLConfigImporter.YakSysRctClient.Version110;

public class MiniRTDVForm : System.Windows.Forms.Form
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MiniRTDV)).EndInit();
            this.ResumeLayout(false);

    }
    #endregion

    private System.Windows.Forms.PictureBox pictureBox_MiniRTDV;


    private void pictureBox_MiniRTDVForm_ReceivedImage_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (this.pictureBox_MiniRTDV.Image != null && MainTcpClient.IsConnected && ObjCopy.obj_MainClientForm.RTDVIsAllowControl && !ObjCopy.obj_MainClientForm.RTRDVRealSize && ObjCopy.obj_MainClientForm.RTRDVEnabled)
        {
            int int_MouseButtonNum = 1;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    int_MouseButtonNum = 1;
                    break;

                case MouseButtons.Middle:
                    int_MouseButtonNum = 2;
                    break;
                    
                case MouseButtons.Right:
                    int_MouseButtonNum = 3;
                    break;
            }

            new RemoteCallAction().SetMouseButtonClickEvent(e.X * (UInt16.MaxValue / this.ClientSize.Width), e.Y * (UInt16.MaxValue / this.ClientSize.Height), 0, int_MouseButtonNum, e.Clicks);
        }
    }

    private void pictureBox_MiniRTDVForm_ReceivedImage_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (pictureBox_MiniRTDV.Image != null && MainTcpClient.IsConnected && ObjCopy.obj_MainClientForm.RTDVIsAllowControl && !ObjCopy.obj_MainClientForm.RTRDVRealSize && ObjCopy.obj_MainClientForm.RTRDVEnabled)
        {
            int int_MouseButtonNum = 1;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    int_MouseButtonNum = 1;
                    break;

                case MouseButtons.Middle:
                    int_MouseButtonNum = 2;
                    break;

                case MouseButtons.Right:
                    int_MouseButtonNum = 3;
                    break;
            }

            new RemoteCallAction().SetMouseButtonClickEvent(e.X * (UInt16.MaxValue / this.ClientSize.Width), e.Y * (UInt16.MaxValue / this.ClientSize.Height), 1, int_MouseButtonNum, e.Clicks);
        }
    }

    private void pictureBox_MiniRTDVForm_ReceivedImage_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        lock (this)
        {
            if (pictureBox_MiniRTDV.Image != null && MainTcpClient.IsConnected && ObjCopy.obj_MainClientForm.RTDVIsAllowControl && !ObjCopy.obj_MainClientForm.RTRDVRealSize && ObjCopy.obj_MainClientForm.RTRDVEnabled)
            {
                new RemoteCallAction().SetMouseMoveEventFromMiniRTDV(e.X * (UInt16.MaxValue / this.ClientSize.Width), e.Y * (UInt16.MaxValue / this.ClientSize.Height));
            }
            System.Threading.Thread.Sleep(30);
        }
    }


    private void MiniRTDVForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (pictureBox_MiniRTDV.Image != null && MainTcpClient.IsConnected && ObjCopy.obj_MainClientForm.RTDVIsAllowControl && !ObjCopy.obj_MainClientForm.RTRDVRealSize && ObjCopy.obj_MainClientForm.RTRDVEnabled)
        {
            new RemoteCallAction().SetSingleKeyKeyboardEvent(1, e.KeyValue, e.Modifiers);
        }
    }

    private void MiniRTDVForm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (pictureBox_MiniRTDV.Image != null && MainTcpClient.IsConnected && ObjCopy.obj_MainClientForm.RTDVIsAllowControl && !ObjCopy.obj_MainClientForm.RTRDVRealSize && ObjCopy.obj_MainClientForm.RTRDVEnabled)
        {
            //      new RemoteCallAction().SetSingleKeyKeyboardEvent(2, e.KeyValue, e.Modifiers);	
        }
    }

    private void pictureBox_MiniRTDV_Click(object sender, System.EventArgs e)
    {
        if (pictureBox_MiniRTDV.Image == null) return;

        this.Activate();
    }

    private void MiniRTDVForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        e.Cancel = true;
    }

    private void pictureBox_MiniRTDV_MouseEnter(object sender, System.EventArgs e)
    {
        if (ClientSettingsEnvironment.HideLocalCursorOnMiniRTDV == true) Cursor.Hide();

        if (pictureBox_MiniRTDV.Image != null && MainTcpClient.IsConnected && ObjCopy.obj_MainClientForm.RTDVIsAllowControl && !ObjCopy.obj_MainClientForm.RTRDVRealSize && ObjCopy.obj_MainClientForm.RTRDVEnabled)
        {
            this.Activate();
        }
    }

    private void pictureBox_MiniRTDV_MouseLeave(object sender, System.EventArgs e)
    {
        if (ClientSettingsEnvironment.HideLocalCursorOnMiniRTDV == true) Cursor.Show();

        if (pictureBox_MiniRTDV.Image != null && MainTcpClient.IsConnected && ObjCopy.obj_MainClientForm.RTDVIsAllowControl && !ObjCopy.obj_MainClientForm.RTRDVRealSize && ObjCopy.obj_MainClientForm.RTRDVEnabled)
        {
            ObjCopy.obj_MainClientForm.Activate();
        }
    }

    public PictureBox MiniRemoteDisplay
    {
        get
        {
            return pictureBox_MiniRTDV;
        }

        set
        {
            pictureBox_MiniRTDV = value;
        }
    }
}

