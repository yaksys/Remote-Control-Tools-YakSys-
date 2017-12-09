using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace YakSys
{
    namespace Server_Core
    {

        class ScreenCaptureEnvironment
        {
            [DllImport("YakSysRctServerLib.dll")]
            private static extern void ChangeDisplayMode(int int_ScreenWidth, int int_ScreenHeight, int int_ScreenBPP, int int_DisplayFreq);

            [DllImport("YakSysRctServerLib.dll")]
            private static extern void DisableMonitorPowerSaveActivity();

            [DllImport("YakSysRctServerLib.dll")]
            private static extern void EnableMonitorPowerSaveActivity();

            public static Bitmap bitmap_ScreenCopy = null;

            static int int_RTDVSleepValue = 1000;
            public static int RTDVSleepValue
            {
                get
                {
                    return int_RTDVSleepValue;
                }

                set
                {
                    int_RTDVSleepValue = value;
                }
            }

            static bool bool_NeedToStopRTDV = false;
            public static bool NeedToStopRTDV
            {
                get
                {
                    return bool_NeedToStopRTDV;
                }

                set
                {
                    bool_NeedToStopRTDV = value;
                }
            }

            static int int_RTDVClientsCount = 0;
            public static int RTDVClientsCount
            {
                get
                {
                    return int_RTDVClientsCount;
                }

                set
                {
                    int_RTDVClientsCount = value;
                }
            }

            public Bitmap GetCapturedScreen()
            {
                Bitmap bitmap_ScreenShot = null;

                Graphics graphics_Screen = null;

                try
                {
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

                    bitmap_ScreenShot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, pixelFormat_CurrentFormat);

                    graphics_Screen = Graphics.FromImage(bitmap_ScreenShot);

                    graphics_Screen.CopyFromScreen(0, 0, 0, 0, Screen.AllScreens[0].Bounds.Size);

                    return bitmap_ScreenShot;
                }

                catch (Exception exception_obj)
                {
                    return null;
                }
            }
            
            public void SaveCapturedScreenForRTRDV()
            {
                try
                {
                    if (Monitor.TryEnter(this) == false) return;

                    Monitor.Enter(this);

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

                    bitmap_ScreenCopy = new Bitmap(int16_ScreenWidthSize, int16_ScreenHeightSize, pixelFormat_CurrentFormat);

                    Graphics graphics_Screen = Graphics.FromImage(bitmap_ScreenCopy);

                    if (int16_ScreenBitsPerPixel <= 8)
                    {
                        ChangeDisplayMode(int16_ScreenWidthSize, int16_ScreenHeightSize, 16, 75);
                    }

                    bool bool_NeedToRestartRTDV = false;
                    bool_NeedToStopRTDV = false;

                    DisableMonitorPowerSaveActivity();

                    int int_WaitingValue = 0;

                    for (int int_CycleCount = 0; bool_NeedToStopRTDV != true; int_CycleCount++)
                    {
                        int_WaitingValue = 0;

                        while (Monitor.TryEnter(bitmap_ScreenCopy, 50) == false)
                        {
                            int_WaitingValue += 50;
                        }

                        if (int16_ScreenWidthSize != Screen.PrimaryScreen.Bounds.Width ||
                            int16_ScreenHeightSize != Screen.PrimaryScreen.Bounds.Height ||
                            int16_ScreenBitsPerPixel != Screen.PrimaryScreen.BitsPerPixel)
                        {
                            bool_NeedToRestartRTDV = true;

                            Monitor.Exit(bitmap_ScreenCopy);

                            break;
                        }

                        if (bool_NeedToStopRTDV == true)
                        {
                            Monitor.Exit(bitmap_ScreenCopy);

                            break;
                        }

                        graphics_Screen.CopyFromScreen(0, 0, 0, 0, new Size(int16_ScreenWidthSize, int16_ScreenHeightSize));

                        Monitor.Exit(bitmap_ScreenCopy);

                        if (int_RTDVSleepValue > int_WaitingValue)
                        {
                            Thread.Sleep(int_RTDVSleepValue);
                        }
                    }

                    EnableMonitorPowerSaveActivity();

                    Monitor.Exit(this);

                    if (bool_NeedToRestartRTDV == true) SaveCapturedScreenForRTRDV();
                }

                catch
                {
                }
            }
            
            public static void ReleaseRTDVResources()
            {
                ScreenCaptureEnvironment.RTDVClientsCount--;

                if (ScreenCaptureEnvironment.RTDVClientsCount <= 0)
                {
                    ScreenCaptureEnvironment.NeedToStopRTDV = true;

                    ScreenCaptureEnvironment.RTDVClientsCount = 0;

                    ScreenCaptureEnvironment.RTDVSleepValue = 1000;
                }
            }
        }


    }
}