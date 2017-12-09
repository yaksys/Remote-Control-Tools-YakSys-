using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using YakSys.Server_Core;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.Security.Principal;

namespace Remote_Control_Tools_ProcWindow
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {

            InitializeComponent();
            this.Hide();
        }

        private void Form_Main_Load(object sender, EventArgs e) //!! из за чего то в дебаг НЕ x86 не загружается Load метод этот
        {
   
        }
        
        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)            
        {

        }

        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void Form_Main_Shown(object sender, EventArgs e)
        {
            this.Hide();

            LocalObjCopy.formMain_obj = this;
            
        //  LocalObjCopy.soundCapture_obj = new SoundCapture();
                           
            Thread.CurrentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            

            try
            {

                NETRemotingInteractionLayer.ConnectToNETRemotingLocalHost();
                
                //LocalObjCopy.localAction_obj.RegToKeyboardInputEvent();
                //LocalObjCopy.localAction_obj.RegToMouseInputEvent();


                new Thread(new ThreadStart(LocalObjCopy.localAction_obj.ScreenForRTRDVWatcher)).Start();

                new Thread(new ThreadStart(LocalObjCopy.localAction_obj.ExecuteProcessJobsWatcher)).Start();

                new Thread(new ThreadStart(LocalObjCopy.localAction_obj.MessageBoxJobsWatcher)).Start();

                new Thread(new ThreadStart(LocalObjCopy.localAction_obj.ClipboardWrapperWatcher)).Start();

       //         new Thread(new ThreadStart(LocalObjCopy.localAction_obj.WebCamWrapperWatcher)).Start();

        //        new Thread(new ThreadStart(LocalObjCopy.localAction_obj.MicRecordWrapperWatcher)).Start();         
            }
            catch
            {
            }       

             //!!! при старте из под сервиса микрофон не рботает !!!
        }

    }
}
