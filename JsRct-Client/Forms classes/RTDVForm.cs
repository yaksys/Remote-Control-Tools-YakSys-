using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctClient;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;

public class RTDVForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.PictureBox pictureBox_RTDV;

    private System.ComponentModel.Container components = null;

    public RTDVForm()
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

    public PictureBox RemoteDisplay
    {
        get
        {
            return pictureBox_RTDV;
        }
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RTDVForm));
        this.pictureBox_RTDV = new System.Windows.Forms.PictureBox();
        this.SuspendLayout();
        // 
        // pictureBox_RTDV
        // 
        this.pictureBox_RTDV.Location = new System.Drawing.Point(0, 0);
        this.pictureBox_RTDV.Margin = new System.Windows.Forms.Padding(0);
        this.pictureBox_RTDV.Name = "pictureBox_RTDV";
        this.pictureBox_RTDV.Size = new System.Drawing.Size(634, 458);
        this.pictureBox_RTDV.TabIndex = 0;
        this.pictureBox_RTDV.TabStop = false;
        this.pictureBox_RTDV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_RTDV_MouseDown);
        this.pictureBox_RTDV.MouseEnter += new System.EventHandler(this.pictureBox_RTDV_MouseEnter);
        this.pictureBox_RTDV.MouseLeave += new System.EventHandler(this.pictureBox_RTDV_MouseLeave);
        this.pictureBox_RTDV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_RTDV_MouseMove);
        this.pictureBox_RTDV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_RTDV_MouseUp);
        // 
        // RTDVForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.AutoScroll = true;
        this.AutoScrollMargin = new System.Drawing.Size(1, 1);
        this.AutoScrollMinSize = new System.Drawing.Size(1, 1);
        this.ClientSize = new System.Drawing.Size(636, 460);
        this.Controls.Add(this.pictureBox_RTDV);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "RTDVForm";
        this.Text = "RTDV";
        this.Closing += new System.ComponentModel.CancelEventHandler(this.RTDVForm_Closing);
        this.Closed += new System.EventHandler(this.RTDVForm_Closed);
        this.Shown += new System.EventHandler(this.RTDVForm_Shown);
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTDVForm_KeyDown);
        this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RTDVForm_KeyUp);
        this.ResumeLayout(false);

    }
    #endregion

    private void RTDVForm_Closed(object sender, System.EventArgs e)
    {
        ObjCopy.obj_MainClientForm.RTRDVRealSize = false;
    }


    private void pictureBox_RTDV_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        lock (this)
        {
            if (pictureBox_RTDV.Image != null && MainTcpClient.IsConnected && ObjCopy.obj_MainClientForm.RTDVIsAllowControl && ObjCopy.obj_MainClientForm.RTRDVRealSize && ObjCopy.obj_MainClientForm.RTRDVEnabled)
            {
                new RemoteCallAction().SetMouseMoveEvent(e.X, e.Y);
            }

            System.Threading.Thread.Sleep(30);
        }
    }

    private void pictureBox_RTDV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (pictureBox_RTDV.Image != null && MainTcpClient.IsConnected && ObjCopy.obj_MainClientForm.RTDVIsAllowControl && ObjCopy.obj_MainClientForm.RTRDVRealSize && ObjCopy.obj_MainClientForm.RTRDVEnabled)
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

            new RemoteCallAction().SetMouseButtonClickEvent(e.X, e.Y, 0, int_MouseButtonNum, e.Clicks);
        }       
    }

    private void pictureBox_RTDV_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (pictureBox_RTDV.Image != null && MainTcpClient.IsConnected && ObjCopy.obj_MainClientForm.RTDVIsAllowControl && ObjCopy.obj_MainClientForm.RTRDVRealSize && ObjCopy.obj_MainClientForm.RTRDVEnabled)
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

            new RemoteCallAction().SetMouseButtonClickEvent(e.X, e.Y, 1, int_MouseButtonNum, e.Clicks);
        }
    }


    private void RTDVForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (MainTcpClient.IsConnected && ObjCopy.obj_MainClientForm.RTDVIsAllowControl && ObjCopy.obj_MainClientForm.RTRDVRealSize && ObjCopy.obj_MainClientForm.RTRDVEnabled)
        {
            new RemoteCallAction().SetSingleKeyKeyboardEvent(1, e.KeyValue, e.Modifiers);
        }
    }

    private void RTDVForm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (MainTcpClient.IsConnected && ObjCopy.obj_MainClientForm.RTDVIsAllowControl && ObjCopy.obj_MainClientForm.RTRDVRealSize && ObjCopy.obj_MainClientForm.RTRDVEnabled)
        {
            //   new RemoteCallAction().SetSingleKeyKeyboardEvent(2, e.KeyValue, e.Modifiers);
        }
    }

    private void RTDVForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        ObjCopy.obj_MainClientForm.RTRDVRealSize = false;
    }

    private void RTDVForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }

    private void pictureBox_RTDV_MouseEnter(object sender, System.EventArgs e)
    {
        if (ClientSettingsEnvironment.HideLocalCursorOnMiniRTDV == true) Cursor.Hide();
    }

    private void pictureBox_RTDV_MouseLeave(object sender, System.EventArgs e)
    {
        if (ClientSettingsEnvironment.HideLocalCursorOnMiniRTDV == true) Cursor.Show();
    }

}
