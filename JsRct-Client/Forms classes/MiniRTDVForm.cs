using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctClient;
using YakSys.XMLConfigImporter.YakSysRctClient.Version110;





public partial class MiniRTDVForm : System.Windows.Forms.Form
{
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


