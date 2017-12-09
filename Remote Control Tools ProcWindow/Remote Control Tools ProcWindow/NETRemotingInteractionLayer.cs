using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Net;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using YakSys.Server_Core;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace Remote_Control_Tools_ProcWindow
{
    class NETRemotingInteractionLayer
    {
        public static void ConnectToNETRemotingLocalHost()
        {
            try
            {
                RemotingConfiguration.RegisterWellKnownClientType(typeof(ProcWindowService), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ProcWindowService_URI");

                RemotingConfiguration.RegisterWellKnownClientType(typeof(ProcWindowService.ApplicationStartPendingPool), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ProcWindowService_ApplicationStartPendingPool_URI");

                RemotingConfiguration.RegisterWellKnownClientType(typeof(ProcWindowService.MessageBoxPendingPool), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ProcWindowService_MessageBoxPendingPool_URI");

                RemotingConfiguration.RegisterWellKnownClientType(typeof(ProcWindowService.RTDVContainer), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ProcWindowService_RTDVContainer_URI");

                RemotingConfiguration.RegisterWellKnownClientType(typeof(ProcWindowService.ClipboardWrapper), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ProcWindowService_ClipboardWrapper_URI");

            //!!!    RemotingConfiguration.RegisterWellKnownClientType(typeof(ProcWindowService.KeyboardMouseInputWrapper), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ProcWindowService_KeyboardMouseInputWrapper_URI");
                
            }
            catch (Exception ex)
            {

            }
        }
    }


    class LocalObjCopy
    {
        public static ProcWindowService obj_ProcWindowService = (ProcWindowService)Activator.GetObject(typeof(ProcWindowService), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ProcWindowService_URI");

        public static ProcWindowService.ApplicationStartPendingPool obj_ApplicationStartPendingPool = (ProcWindowService.ApplicationStartPendingPool)Activator.GetObject(typeof(ProcWindowService.ApplicationStartPendingPool), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ProcWindowService_ApplicationStartPendingPool_URI");

        public static ProcWindowService.MessageBoxPendingPool obj_MessageBoxPendingPool = (ProcWindowService.MessageBoxPendingPool)Activator.GetObject(typeof(ProcWindowService.MessageBoxPendingPool), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ProcWindowService_MessageBoxPendingPool_URI");

        public static ProcWindowService.RTDVContainer obj_RTDVContainer = (ProcWindowService.RTDVContainer)Activator.GetObject(typeof(ProcWindowService.RTDVContainer), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ProcWindowService_RTDVContainer_URI");

        public static ProcWindowService.ClipboardWrapper obj_ClipboardWrapper = (ProcWindowService.ClipboardWrapper)Activator.GetObject(typeof(ProcWindowService.ClipboardWrapper), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ProcWindowService_ClipboardWrapper_URI");
        
        public static ProcWindowService.WebCamContainer obj_WebCamContainer = (ProcWindowService.WebCamContainer)Activator.GetObject(typeof(ProcWindowService.WebCamContainer), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ProcWindowService_WebCamContainer_URI");

        public static ProcWindowService.MicrophoneRecordWrapper obj_MicrophoneRecordWrapper = (ProcWindowService.MicrophoneRecordWrapper)Activator.GetObject(typeof(ProcWindowService.MicrophoneRecordWrapper), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ProcWindowService_MicrophoneRecordWrapper_URI");

  //!!!      public static ProcWindowService.KeyboardMouseInputWrapper obj_KeyboardMouseInputWrapper = (ProcWindowService.KeyboardMouseInputWrapper)Activator.GetObject(typeof(ProcWindowService.KeyboardMouseInputWrapper), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ProcWindowService_KeyboardMouseInputWrapper_URI");


        public static Form_Main formMain_obj = null;

        public static LocalAction localAction_obj = new LocalAction();

      //  public static SoundCapture soundCapture_obj;// = new SoundCapture();
    }


   

    /*
    class KeyboardMouseInputService
    {
        bool bool_NewMouseInputEventrise = false;


        void MouseEventProcess(int Type, int Button, int ClickCount, int X, int Y)
        {
            MessageBox.Show("Mouse event type:" + Type.ToString(), "Mouse event Button:" + Button.ToString());
        }
        public void RegToMouseInputEvent()
        {
            ProcWindowService.KeyboardMouseInputWrapper.MouseEvent += new ProcWindowService.KeyboardMouseInputWrapper.MouseEventDelegate(MouseEventProcess);
        }

        void KeyboardEventProcess(int int_KeyboardEventType, int int_Key, int int_ModifierKey, int int_TypeOfSequence)
        {

        }
        public void RegToKeyboardInputEvent()
        {
            ProcWindowService.KeyboardMouseInputWrapper.KeyboardEvent += new ProcWindowService.KeyboardMouseInputWrapper.KeyboardEventDelegate(KeyboardEventProcess);
        }


        int int_KeyboardEventType, int_KeyboardKey, int_KeyboardModifierKey, int_Keyboard_TypeOfSequence;

        int MouseEventType, MouseButton, MouseClickCount, Mouse_X_Coord, Mouse_Y_Coord;



        public void MouseJobsWatcher()
        {
          
        }

    }
    */

    

    public class LocalAction
    {

     






        #region ExecuteProcess Method



        void ExecuteProcess()
        {
            ProcessStartInfo ExecutingProcessStartInfo = new ProcessStartInfo();

            ExecutingProcessStartInfo.FileName = LocalObjCopy.obj_ApplicationStartPendingPool.ExecutedNameOfFileWithPath;
            ExecutingProcessStartInfo.WorkingDirectory = LocalObjCopy.obj_ApplicationStartPendingPool.WorkingDirectory;
            ExecutingProcessStartInfo.Arguments = LocalObjCopy.obj_ApplicationStartPendingPool.CommandLineArguments;

            switch (LocalObjCopy.obj_ApplicationStartPendingPool.WindowStyle)
            {
                case 0:
                    ExecutingProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    break;

                case 1:
                    ExecutingProcessStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                    break;

                case 2:
                    ExecutingProcessStartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    break;

                case 3:
                    ExecutingProcessStartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    break;
            }

            if (LocalObjCopy.obj_ApplicationStartPendingPool.CreateNoWindow == 1) ExecutingProcessStartInfo.CreateNoWindow = true;
            else ExecutingProcessStartInfo.CreateNoWindow = false;

            if (LocalObjCopy.obj_ApplicationStartPendingPool.UseShellExecute == 1) ExecutingProcessStartInfo.UseShellExecute = true;
            else ExecutingProcessStartInfo.UseShellExecute = false;

            if (LocalObjCopy.obj_ApplicationStartPendingPool.DisplayErrorDialog == 1) ExecutingProcessStartInfo.ErrorDialog = true;
            else ExecutingProcessStartInfo.ErrorDialog = false;

            try
            {
                Process.Start(ExecutingProcessStartInfo);
            }

            catch (Exception exception_obj)
            {

            }
            finally
            {
                LocalObjCopy.obj_ApplicationStartPendingPool.TaskExecutionCompletedFlag = true;
            }
        }

        #endregion

        #region ShowMessageBox Method
        void ShowMessageBox()
        {
            try
            {
                string string_MessageText = LocalObjCopy.obj_MessageBoxPendingPool.MessageText;
                string string_CaptionText = LocalObjCopy.obj_MessageBoxPendingPool.CaptionText;

                MessageBoxButtons messageBoxButtons_obj = MessageBoxButtons.OK;

                MessageBoxIcon messageBoxIcon_obj = MessageBoxIcon.Information;

                switch (LocalObjCopy.obj_MessageBoxPendingPool.IconIndex)
                {
                    case 0:
                        messageBoxIcon_obj = MessageBoxIcon.Asterisk;
                        break;

                    case 1:
                        messageBoxIcon_obj = MessageBoxIcon.Error;
                        break;

                    case 2:
                        messageBoxIcon_obj = MessageBoxIcon.Exclamation;
                        break;

                    case 3:
                        messageBoxIcon_obj = MessageBoxIcon.Hand;
                        break;

                    case 4:
                        messageBoxIcon_obj = MessageBoxIcon.Information;
                        break;

                    case 5:
                        messageBoxIcon_obj = MessageBoxIcon.None;
                        break;

                    case 6:
                        messageBoxIcon_obj = MessageBoxIcon.Question;
                        break;

                    case 7:
                        messageBoxIcon_obj = MessageBoxIcon.Stop;
                        break;

                    case 8:
                        messageBoxIcon_obj = MessageBoxIcon.Warning;
                        break;
                }

                switch (LocalObjCopy.obj_MessageBoxPendingPool.ButtonsIndex)
                {
                    case 0:
                        messageBoxButtons_obj = MessageBoxButtons.AbortRetryIgnore;
                        break;

                    case 1:
                        messageBoxButtons_obj = MessageBoxButtons.OK;
                        break;

                    case 2:
                        messageBoxButtons_obj = MessageBoxButtons.OKCancel;
                        break;

                    case 3:
                        messageBoxButtons_obj = MessageBoxButtons.RetryCancel;
                        break;

                    case 4:
                        messageBoxButtons_obj = MessageBoxButtons.YesNo;
                        break;

                    case 5:
                        messageBoxButtons_obj = MessageBoxButtons.YesNoCancel;
                        break;
                }

                LocalObjCopy.obj_MessageBoxPendingPool.DialogResult_UserSelection = MessageBox.Show(string_MessageText, string_CaptionText, messageBoxButtons_obj, messageBoxIcon_obj);

                LocalObjCopy.obj_MessageBoxPendingPool.TaskExecutionCompletedFlag = true;
            }

            catch (Exception exception_obj)
            {
            }
            finally
            {
            }
        }

        #endregion

        #region ExecClipBoardJob Method

        void ExecClipBoardJob()
        {
            try
            {
                if (LocalObjCopy.obj_ClipboardWrapper.RemotingWrapper_IsSetDataJob == true)
                {
                    LocalObjCopy.formMain_obj.Invoke((MethodInvoker)delegate
                    {
                        if (LocalObjCopy.obj_ClipboardWrapper.ContainsImage_RemotingWrapper() == true)
                        {
                            byte[] byteArray_ScreenCopy = LocalObjCopy.obj_ClipboardWrapper.GetImageStreamBytes();

                            if (byteArray_ScreenCopy == null) return;

                            MemoryStream memoryStream_Image = new MemoryStream(byteArray_ScreenCopy);

                            memoryStream_Image.Position = 0;

                            Image Image_ReceivedImage = Image.FromStream(memoryStream_Image);

                         //   memoryStream_Image.Close();

                            Clipboard.SetImage(Image_ReceivedImage);
                        }

                        if (LocalObjCopy.obj_ClipboardWrapper.ContainsFileDropList_RemotingWrapper() == true)
                        {
                            Clipboard.SetFileDropList(LocalObjCopy.obj_ClipboardWrapper.FileDropListData);
                        }

                        if (LocalObjCopy.obj_ClipboardWrapper.ContainsText_RemotingWrapper() == true)
                        {
                            Clipboard.SetText(LocalObjCopy.obj_ClipboardWrapper.TextData);
                        }
                    });
                }
                else
                {
                    LocalObjCopy.formMain_obj.Invoke((MethodInvoker)delegate
                    {
                        if (Clipboard.ContainsImage() == true)
                        {
                            MemoryStream memoryStream_Image = new MemoryStream();

                            memoryStream_Image.Position = 0;

                            Clipboard.GetImage().Save(memoryStream_Image, ImageFormat.Png);

                            memoryStream_Image.SetLength(memoryStream_Image.Length);

                            LocalObjCopy.obj_ClipboardWrapper.SetClipBoardImageBytes(memoryStream_Image.ToArray());
                        }

                        if (Clipboard.ContainsFileDropList() == true)
                        {
                            LocalObjCopy.obj_ClipboardWrapper.FileDropListData = Clipboard.GetFileDropList();
                        }

                        if (Clipboard.ContainsText() == true)
                        {
                            LocalObjCopy.obj_ClipboardWrapper.TextData = Clipboard.GetText();
                        }
                    });

                    LocalObjCopy.obj_ClipboardWrapper.RemotingWrapper_RefreshCompleteFlag = true;
                }
            }

            catch
            {
            }
            finally
            {
                LocalObjCopy.obj_ClipboardWrapper.RemotingWrapper_RefreshCompleteFlag = true;
            }
        }

        #endregion

        public void ExecuteProcessJobsWatcher()
        {
            Thread.Sleep(300);

            bool bool_IsTaskToExecuteExist = false;

            try
            {
                for (int int_CycleCount = 0; int_CycleCount != LocalObjCopy.obj_ApplicationStartPendingPool.RemoteWrapper_ApplicationStartPendingPool.Count; int_CycleCount++)
                {
                    if (LocalObjCopy.obj_ApplicationStartPendingPool.RemoteWrapper_ApplicationStartPendingPool[int_CycleCount].TaskExecutionCompletedFlag == false)
                    {
                        LocalObjCopy.obj_ApplicationStartPendingPool = LocalObjCopy.obj_ApplicationStartPendingPool.RemoteWrapper_ApplicationStartPendingPool[int_CycleCount];

                        bool_IsTaskToExecuteExist = true;

                        break;
                    }
                }

                if (bool_IsTaskToExecuteExist == false)
                {
                    Thread.Sleep(1000);

                    ExecuteProcessJobsWatcher();

                    return;
                }

                ExecuteProcess();

                ExecuteProcessJobsWatcher();
            }
            catch
            {
                Thread.Sleep(1000);

                ExecuteProcessJobsWatcher();
            }
        }

        public void MessageBoxJobsWatcher()
        {
            Thread.Sleep(300);

            bool bool_IsTaskToExecuteExist = false;
            try
            {
                for (int int_CycleCount = 0; int_CycleCount != LocalObjCopy.obj_MessageBoxPendingPool.RemoteWrapper_MessageBoxPendingPool.Count; int_CycleCount++)
                {
                    if (LocalObjCopy.obj_MessageBoxPendingPool.RemoteWrapper_MessageBoxPendingPool[int_CycleCount].TaskExecutionCompletedFlag == false)
                    {
                        LocalObjCopy.obj_MessageBoxPendingPool = LocalObjCopy.obj_MessageBoxPendingPool.RemoteWrapper_MessageBoxPendingPool[int_CycleCount];

                        bool_IsTaskToExecuteExist = true;

                        break;
                    }
                }

                if (bool_IsTaskToExecuteExist == false)
                {
                    Thread.Sleep(1000);

                    MessageBoxJobsWatcher();

                    return;
                }

                ShowMessageBox();

                MessageBoxJobsWatcher();
            }
            catch
            {
                Thread.Sleep(1000);

                MessageBoxJobsWatcher();
            }
        }

        public void ClipboardWrapperWatcher()
        {
            Thread.Sleep(300);

            try
            {
                if (LocalObjCopy.obj_ClipboardWrapper.RemotingWrapper_NeedToRefreshFlag == false)
                {
                    Thread.Sleep(1000);

                    ClipboardWrapperWatcher();

                    return;
                }

                ExecClipBoardJob();

                LocalObjCopy.obj_ClipboardWrapper.RemotingWrapper_RefreshCompleteFlag = true;
                LocalObjCopy.obj_ClipboardWrapper.RemotingWrapper_NeedToRefreshFlag = false;

                ClipboardWrapperWatcher();
            }
            catch
            {
                Thread.Sleep(1000);

                ClipboardWrapperWatcher();
            }
        }
        /*
        public void WebCamWrapperWatcher()
        {
            Thread.Sleep(300);

            try
            {
                if (LocalObjCopy.obj_WebCamContainer.RemotingWrapper_NeedToRefreshFlag == false)
                {
                    Thread.Sleep(1000);

                    WebCamWrapperWatcher();

                    return;
                }

                new WebCamLayer().StartCapture(); //!!

                WebCamWrapperWatcher();
            }
            catch
            {
                Thread.Sleep(1000);

                WebCamWrapperWatcher();
            }
        }
        
        public void MicRecordWrapperWatcher()
        {

            Thread.Sleep(300);

            try
            {
                if (LocalObjCopy.obj_MicrophoneRecordWrapper.RemotingWrapper_NeedToRefreshFlag == false)
                {
                    Thread.Sleep(1000);

                    MicRecordWrapperWatcher();

                    return;
                }

                LocalObjCopy.soundCapture_obj.Record();

                MicRecordWrapperWatcher();
            }
            catch
            {
                Thread.Sleep(1000);

                MicRecordWrapperWatcher();
            }
        }                          

        */


        #region DllImport methods declaration

        [DllImport("YakSysRctServerLib.dll")]
        private static extern void ChangeDisplayMode(int int_ScreenWidth, int int_ScreenHeight, int int_ScreenBPP, int int_DisplayFreq);

        [DllImport("YakSysRctServerLib.dll")]
        private static extern void DisableMonitorPowerSaveActivity();

        [DllImport("YakSysRctServerLib.dll")]
        private static extern void EnableMonitorPowerSaveActivity();

        [DllImport("YakSysRctServerLib.dll")]
        private static extern bool ConnectToDesktop();
        
        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();

        #endregion

        public void ScreenForRTRDVWatcher()
        {
            try
            {
                int int16_ScreenWidthSize = Screen.PrimaryScreen.Bounds.Width;
                int int16_ScreenHeightSize = Screen.PrimaryScreen.Bounds.Height;

                int int16_ScreenBitsPerPixel = Screen.PrimaryScreen.BitsPerPixel;

                PixelFormat pixelFormat_CurrentFormat = PixelFormat.Format24bppRgb;

                Bitmap bitmap_ScreenCopy = null;
                BitmapData bitmapData_obj = null;

                IntPtr intPtr_BitmapPixelPtr = IntPtr.Zero;

                #region Pixel Format initialization

                switch (Screen.PrimaryScreen.BitsPerPixel)
                {
                    case 32:
                        pixelFormat_CurrentFormat = PixelFormat.Format32bppArgb;
                        break;

                    case 24:
                        pixelFormat_CurrentFormat = PixelFormat.Format24bppRgb;
                        break;

                    case 16:
                        pixelFormat_CurrentFormat = PixelFormat.Format16bppRgb555;
                        break;
                }

                #endregion

                bitmap_ScreenCopy = new Bitmap(int16_ScreenWidthSize, int16_ScreenHeightSize, pixelFormat_CurrentFormat);

                Graphics graphics_Screen = Graphics.FromImage(bitmap_ScreenCopy);

                if (int16_ScreenBitsPerPixel <= 8)
                {
                    ChangeDisplayMode(int16_ScreenWidthSize, int16_ScreenHeightSize, 16, 75);

                    int16_ScreenBitsPerPixel = 16;
                }

                LocalObjCopy.obj_RTDVContainer.RemotingWrapper_NeedToStopRTDV = false;
                try
                {
                    ConnectToDesktop();

                    DisableMonitorPowerSaveActivity();
                }
                catch
                {
                }

                byte[] byteArray_ScreenCopy = null;

                for (int int_CycleCount = 0; LocalObjCopy.obj_RTDVContainer.RemotingWrapper_NeedToStopRTDV != true; int_CycleCount++)
                {
                    if (int16_ScreenWidthSize != Screen.PrimaryScreen.Bounds.Width ||
                        int16_ScreenHeightSize != Screen.PrimaryScreen.Bounds.Height ||
                        int16_ScreenBitsPerPixel != Screen.PrimaryScreen.BitsPerPixel)
                    {
                        ScreenForRTRDVWatcher();

                        if (bitmap_ScreenCopy != null) bitmap_ScreenCopy.Dispose();
                        if (graphics_Screen != null) graphics_Screen.Dispose();
                        
                        return;
                    }

                    if (byteArray_ScreenCopy == null || byteArray_ScreenCopy.Length < (bitmap_ScreenCopy.Width * bitmap_ScreenCopy.Height) * (int16_ScreenBitsPerPixel / 8))
                    {
                        byteArray_ScreenCopy = new byte[(bitmap_ScreenCopy.Width * bitmap_ScreenCopy.Height) * (int16_ScreenBitsPerPixel / 8)];
                    }

                    graphics_Screen = Graphics.FromImage(bitmap_ScreenCopy);
                    
                    while (LocalObjCopy.obj_RTDVContainer.RemotingWrapper_NeedToRefreshFlag == false)
                    {                                     
                        Thread.Sleep(10);
                    }
                                        
                    /////////////// DX capture for test
                    /*
                    bitmap_DxScreenCapture = (Bitmap)ScreenCapture.Direct3DCapture.CaptureWindow(GetDesktopWindow());

                    bitmapData_obj = bitmap_DxScreenCapture.LockBits(new Rectangle(0, 0, bitmap_DxScreenCapture.Width, bitmap_DxScreenCapture.Height), ImageLockMode.ReadWrite, pixelFormat_CurrentFormat);

                    intPtr_BitmapPixelPtr = bitmapData_obj.Scan0;

                    if (byteArray_ScreenCopy == null || byteArray_ScreenCopy.Length < (bitmap_DxScreenCapture.Width * bitmap_DxScreenCapture.Height) * (int16_ScreenBitsPerPixel / 8))
                    {
                        byteArray_ScreenCopy = new byte[(bitmap_DxScreenCapture.Width * bitmap_DxScreenCapture.Height) * (int16_ScreenBitsPerPixel / 8)];
                    }

                    Marshal.Copy(intPtr_BitmapPixelPtr, byteArray_ScreenCopy, 0, byteArray_ScreenCopy.Length);

                    bitmap_DxScreenCapture.UnlockBits(bitmapData_obj);
                    */
                    ///////////////

                    graphics_Screen.CopyFromScreen(0, 0, 0, 0, new Size(int16_ScreenWidthSize, int16_ScreenHeightSize));

                    bitmapData_obj = bitmap_ScreenCopy.LockBits(new Rectangle(0, 0, bitmap_ScreenCopy.Width, bitmap_ScreenCopy.Height), ImageLockMode.ReadWrite, pixelFormat_CurrentFormat);
                    
                    intPtr_BitmapPixelPtr = bitmapData_obj.Scan0;

                    Marshal.Copy(intPtr_BitmapPixelPtr, byteArray_ScreenCopy, 0, byteArray_ScreenCopy.Length);

                    bitmap_ScreenCopy.UnlockBits(bitmapData_obj);
                    
                    LocalObjCopy.obj_RTDVContainer.RemotingWrapper_ScreenHeightSize = (Int16)bitmap_ScreenCopy.Height;
                    LocalObjCopy.obj_RTDVContainer.RemotingWrapper_ScreenWidthSize = (Int16)bitmap_ScreenCopy.Width;
                    LocalObjCopy.obj_RTDVContainer.RemotingWrapper_ScreenBitsPerPixel = (Int16)int16_ScreenBitsPerPixel;

                    LocalObjCopy.obj_RTDVContainer.SetScreenBytes(byteArray_ScreenCopy);
                 
                    LocalObjCopy.obj_RTDVContainer.RemotingWrapper_RefreshCompleteFlag = true;
                    LocalObjCopy.obj_RTDVContainer.RemotingWrapper_NeedToRefreshFlag = false;
                }               
            }

            catch (Exception ex)
            {
                Thread.Sleep(1000);

                GC.Collect();

                Thread.Sleep(2000);

                ScreenForRTRDVWatcher();

                ProcessStartInfo ExecutingProcessStartInfo = new ProcessStartInfo();

                ExecutingProcessStartInfo.FileName = "Remote Control Tools ProcWindow.exe";
                ExecutingProcessStartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                ExecutingProcessStartInfo.WindowStyle = ProcessWindowStyle.Normal;//!!

                ExecutingProcessStartInfo.CreateNoWindow = true; //!!
                ExecutingProcessStartInfo.UseShellExecute = true;
                ExecutingProcessStartInfo.ErrorDialog = true;

                Process.Start(ExecutingProcessStartInfo);

                Process.GetCurrentProcess().Kill();
            }

            finally
            {
                EnableMonitorPowerSaveActivity();

                Process.GetCurrentProcess().Kill();
            }
        }

        public byte [] GetCapturedScreenBytes()
        {
            try
            {              
                int int16_ScreenWidthSize = Screen.PrimaryScreen.Bounds.Width;
                int int16_ScreenHeightSize = Screen.PrimaryScreen.Bounds.Height;

                int int16_ScreenBitsPerPixel = Screen.PrimaryScreen.BitsPerPixel;

                PixelFormat pixelFormat_CurrentFormat = PixelFormat.Format24bppRgb;

                #region Pixel Format initialization

                switch (Screen.PrimaryScreen.BitsPerPixel)
                {
                    case 32:
                        pixelFormat_CurrentFormat = PixelFormat.Format32bppArgb;
                        break;

                    case 24:
                        pixelFormat_CurrentFormat = PixelFormat.Format24bppRgb;
                        break;

                    case 16:
                        pixelFormat_CurrentFormat = PixelFormat.Format16bppRgb555;
                        break;
                }

                #endregion

                Bitmap bitmap_ScreenCopy = new Bitmap(int16_ScreenWidthSize, int16_ScreenHeightSize, pixelFormat_CurrentFormat);

                Graphics graphics_Screen = Graphics.FromImage(bitmap_ScreenCopy);

                graphics_Screen.CopyFromScreen(0, 0, 0, 0, new Size(int16_ScreenWidthSize, int16_ScreenHeightSize));

                MemoryStream memoryStream_Image = new MemoryStream();

                memoryStream_Image.Position = 0;

                bitmap_ScreenCopy.Save(memoryStream_Image, ImageFormat.Png);

                memoryStream_Image.SetLength(memoryStream_Image.Length);

                return memoryStream_Image.ToArray();
            }

            catch
            {
                return null;
            }
        }       
    }
}