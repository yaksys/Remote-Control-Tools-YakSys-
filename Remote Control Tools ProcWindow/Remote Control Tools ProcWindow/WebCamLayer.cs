using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Text;
using Microsoft.Win32;
using System.Data;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Runtime.InteropServices;
//using AForge.Video;
//using AForge.Video.DirectShow;

    /*
namespace Remote_Control_Tools_ProcWindow
{
    class WebCamLayer
    {
        private bool bool_IsDeviceExist = false;

        private FilterInfoCollection filterInfoCollection_Devices;

        private VideoCaptureDevice videoCaptureDevice_VideoSource = null;

        private FilterInfoCollection AquireWebCamDevice()
        {
            try
            {
                filterInfoCollection_Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (filterInfoCollection_Devices.Count == 0)
                {
                    throw new ApplicationException();
                }

                bool_IsDeviceExist = true;

                foreach (FilterInfo filterInfo_CurrentDevice in filterInfoCollection_Devices)
                {

                }

                return filterInfoCollection_Devices;
            }
            catch (ApplicationException)
            {
                bool_IsDeviceExist = false;

                return null;
            }
        }

        private void StartWebCamCapture(int int_CaptureDeviceIndex)
        {
            if (bool_IsDeviceExist)
            {
                videoCaptureDevice_VideoSource = new VideoCaptureDevice(filterInfoCollection_Devices[int_CaptureDeviceIndex].MonikerString); //!! 0 is a default device index
                                             
                CloseVideoSourceIfBusy();

                videoCaptureDevice_VideoSource.DesiredFrameSize = new Size(320, 240);

                videoCaptureDevice_VideoSource.DesiredFrameRate = 1;

                videoCaptureDevice_VideoSource.Start();
                
                videoCaptureDevice_VideoSource.NewFrame += new NewFrameEventHandler(NewVideoFrameEvent);

            }
            else
            {
            }
        }

        private void CloseVideoSourceIfBusy()
        {
            if (videoCaptureDevice_VideoSource != null)
            {
                if (videoCaptureDevice_VideoSource.IsRunning == true)
                {
                    videoCaptureDevice_VideoSource.SignalToStop();
                    videoCaptureDevice_VideoSource = null;
                }
            }
        }

        private void NewVideoFrameEvent(object sender, NewFrameEventArgs eventArgs)
        {
            if(LocalObjCopy.obj_WebCamContainer.RemotingWrapper_NeedToStopWebCam == true)
            {
                videoCaptureDevice_VideoSource.Stop();

                videoCaptureDevice_VideoSource.NewFrame -= new NewFrameEventHandler(NewVideoFrameEvent);

                return;
            }

            LocalObjCopy.obj_WebCamContainer.RemotingWrapper_ScreenHeightSize = (short)((Bitmap)eventArgs.Frame).Height;
            LocalObjCopy.obj_WebCamContainer.RemotingWrapper_ScreenWidthSize = (short)((Bitmap)eventArgs.Frame).Width;

            LocalObjCopy.obj_WebCamContainer.SetScreenBytes(GetBytesFromBitmap((Bitmap)eventArgs.Frame.Clone()));

            LocalObjCopy.obj_WebCamContainer.RemotingWrapper_RefreshCompleteFlag = true;

            eventArgs.Frame.Dispose();
        }

        public void StartCapture()
        {
            AquireWebCamDevice();

            StartWebCamCapture(0);
        }

        public byte[] GetBytesFromBitmap(Bitmap bitmap_Image)
        {
            try
            {
                MemoryStream memoryStream_Image = new MemoryStream();

                memoryStream_Image.Position = 0;

                bitmap_Image.Save(memoryStream_Image, ImageFormat.Png);
                
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
*/