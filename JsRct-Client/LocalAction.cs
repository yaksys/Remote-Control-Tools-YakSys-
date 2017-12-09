using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.ServiceProcess;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO.Compression;
using YakSys.Compression;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctClient;
using YakSys.XMLConfigImporter.YakSysRctClient.Version110;
//using Microsoft.DirectX.DirectSound;

public class EventsData
{
    string string_EventMessage;

    public string EventMessage
    {
        get
        {
            return string_EventMessage;
        }

        set
        {
            string_EventMessage = value;
        }
    }
}

public class AvailableDisplayMode
{
    public int int_ScreenWidth = 0, int_ScreenHeight = 0, int_BPP = 0, int_DisplayFrequency = 0;
}

//Mothods that receives and process data from server after the Client's requests
public class LocalAction
{

    #region Properties and Variables

    public static List<EventsData> list_EventsData = new List<EventsData>();
    public static List<AvailableDisplayMode> list_AvailableDisplayModes = new List<AvailableDisplayMode>();
    public static List<AvailableDisplayMode> list_AvailableDisplayModes_Temp = new List<AvailableDisplayMode>();
    public static List<int> list_UniqueDisplayResolutionsPosition = new List<int>();

    byte[] byteArray_ReceivedData;
    public byte[] RecivedData
    {
        set
        {
            this.byteArray_ReceivedData = value;
        }

        get
        {
            return this.byteArray_ReceivedData;
        }
    }


    static int int_LastResultOfLocalFileReplace = 3;
    public static int LastResultOfLocalFileReplace
    {
        get
        {
            return int_LastResultOfLocalFileReplace;
        }

        set
        {
            int_LastResultOfLocalFileReplace = value;
        }
    }


    static int int_LastResultOfRemoteFileReplace = 0;
    public static int LastResultOfRemoteFileReplace
    {
        get
        {
            return int_LastResultOfRemoteFileReplace;
        }

        set
        {
            int_LastResultOfRemoteFileReplace = value;
        }
    }


    int int_Action = 0;
    public int ActionNumber
    {
        get
        {
            return int_Action;
        }

        set
        {
            int_Action = value;
        }
    }


    MainTcpClient tcpClient_NecessaryClient;
    public MainTcpClient CurrentlyUsedTcpClient
    {
        set
        {
            tcpClient_NecessaryClient = value;
        }

        get
        {
            return tcpClient_NecessaryClient;
        }
    }


    #endregion

    public void ActionAllocator()
    {
        switch (ActionNumber)
        {
            case -34:
                SynchronizeCryptoKeys();
                break;

            case 1:
                new Thread(new ThreadStart(ShowUserMessageDialogResult)).Start();
                break;

            case 2:
                RefreshProcessList();
                break;

            case 3:
                RefreshFileManager();
                break;

            case 4:
                RefreshListOfExistingDrives();
                break;

            case 5:
                RefreshServicesList();
                break;

            case 6:
                RefreshPossibleServiceAction();
                break;

            case 7:
                {
                    ObjCopy.obj_MainClientForm.RSIEnableAvailableItemsGroupBox = true;
                    ObjCopy.obj_MainClientForm.RSIStatus = String.Empty;
                }
                break;

            case 8:
                RefreshDriversList();
                break;

            case 10:
                new Thread(new ThreadStart(ReadRequiredFileSanction)).Start();
                break;

            case 11:
                new Thread(new ThreadStart(SaveReceivedFile)).Start();
                break;

            case 12:
                new Thread(new ThreadStart(ReadUploadedFileSanctionAndSendFilePart)).Start();
                break;

            case 13:
                new Thread(new ThreadStart(SaveReceivedScreenCopy)).Start();
                break;

            case 14:
                RefreshListOfExistingSystemLogs();
                break;

            case 15:
                new Thread(new ThreadStart(RefreshSystemEventsList)).Start();
                break;

            case 16:
                new Thread(new ThreadStart(AnswerAboutEventsDeleting)).Start();
                break;

            case 17:
                new Thread(new ThreadStart(AnswerAboutLogDeleting)).Start();
                break;

            case 18:
                new Thread(new ThreadStart(ShowChangesOfAccountState)).Start();
                break;

            case 19:
                ShowAuthorizationStatus();
                break;

            case 20:
                new Thread(new ThreadStart(ConfirmFileReplaceOnRemoteSide)).Start();
                break;

            case 21:
                RefreshDrivesInformation();
                break;

            case 22:
                ModifyRegistryKeyValues();
                break;

            case 23:

                break;

            case 24:
                SendRSAEncryptedAuthorizationData();
                break;

            case 25:
                ShowAvailableDisplayModes();
                break;

            case 26:
                new Thread(new ThreadStart(GetFilesOfFolders)).Start();
                break;

            case 27:
                ShowInfoAboutRecievedFilesArray();
                break;

            case 28:
                {
                    Thread thread_obj = new Thread(new ThreadStart(this.SetReceivedTextDataToLocalClipboard));

                    thread_obj.SetApartmentState(ApartmentState.STA);

                    thread_obj.Start();
                }
                break;

            case 29:
                ProcessFileManagerProperties();
                break;

            case 30:
                RefreshInstalledProgramsList();
                break;

            case 31:
                RefreshInstalledUpdatesList();
                break;

            case 32:
                ExpandRegistryKey();
                break;

            case 33:
                SetRegistryKeyValues();
                break;

            case 34:
                SetRemoteSystemInformationItemsCollection();
                break;

            case 35:
                SetRemoteSystemInformationSelectedItemSubNodes();
                break;

            case 36:
                SetRemoteSystemInformationSelectedItemContent();
                break;

            case 37:
                new Thread(new ThreadStart(RefreshImageInRTRDV)).Start();
                break;

            case 38:
                {
                    Thread thread_obj = new Thread(new ThreadStart(this.PreviewReceivedClipboardData));

                    thread_obj.SetApartmentState(ApartmentState.STA);

                    thread_obj.Start();
                }
                break;

            case 39:
                {
                    Thread thread_obj = new Thread(new ThreadStart(this.ShowRemoteClipboardDataType));

                    thread_obj.SetApartmentState(ApartmentState.STA);

                    thread_obj.Start();
                }
                break;

            case 40:
                new Thread(new ThreadStart(PlaySoundBuffer)).Start();
                break;

                           
            case 41:
                new Thread(new ThreadStart(ShowCameraFrame)).Start();
                break;
        }
    }




    void ShowAvailableDisplayModes()
    {
        try
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            int int_ElementsCount = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData),
                int_CurrentScreenWidth = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData),
                int_CurrentScreenHeight = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData),
                int_CurrentBPP = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData),
                int_CurrentDisplayFrequency = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            list_AvailableDisplayModes_Temp.Clear();
            list_AvailableDisplayModes.Clear();

            AvailableDisplayMode availableDisplayMode_CurrentMode;

            for (int int_CycleCount = 0; int_ElementsCount != int_CycleCount; int_CycleCount++)
            {
                availableDisplayMode_CurrentMode = new AvailableDisplayMode();

                availableDisplayMode_CurrentMode.int_ScreenWidth = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);
                availableDisplayMode_CurrentMode.int_ScreenHeight = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

                availableDisplayMode_CurrentMode.int_BPP = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);
                availableDisplayMode_CurrentMode.int_DisplayFrequency = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

                list_AvailableDisplayModes.Add(availableDisplayMode_CurrentMode);
                list_AvailableDisplayModes_Temp.Add(availableDisplayMode_CurrentMode);

                if (int_CycleCount > 300) break;  //!!! добавлено из за ошибки в int_ElementsCount (почему то там было огромное число)
            }

            bool bool_NewUniqueResolutionIsFound = true;

            int int_CountOfUniqueResolution = 0, int_NumOfCurrentResolution = 0;

            list_UniqueDisplayResolutionsPosition.Clear();

            for (int int_CycleCount = 0; int_ElementsCount != int_CycleCount; int_CycleCount++)
            {
                for (int int_InternalCycleCount = 0; int_CycleCount != int_InternalCycleCount; int_InternalCycleCount++)
                {
                    if (
                        list_AvailableDisplayModes_Temp[int_CycleCount].int_ScreenWidth ==
                        list_AvailableDisplayModes_Temp[int_InternalCycleCount].int_ScreenWidth
                        &&
                        list_AvailableDisplayModes_Temp[int_CycleCount].int_ScreenHeight ==
                        list_AvailableDisplayModes_Temp[int_InternalCycleCount].int_ScreenHeight
                        )
                    {
                        bool_NewUniqueResolutionIsFound = false;
                        break;
                    }
                }

                if (bool_NewUniqueResolutionIsFound)
                {
                    int_CountOfUniqueResolution++;

                    if (list_AvailableDisplayModes_Temp[int_CycleCount].int_ScreenWidth == int_CurrentScreenWidth &&
                       list_AvailableDisplayModes_Temp[int_CycleCount].int_ScreenHeight == int_CurrentScreenHeight)
                    {
                        int_NumOfCurrentResolution = int_CountOfUniqueResolution;
                    }

                    list_UniqueDisplayResolutionsPosition.Add(int_CycleCount);

                }
                else bool_NewUniqueResolutionIsFound = true;
            }

            list_AvailableDisplayModes_Temp.Clear();

            ObjCopy.obj_MainClientForm.DisplayResolutionTrackBar.Minimum = 1;
            ObjCopy.obj_MainClientForm.DisplayResolutionTrackBar.Maximum = int_CountOfUniqueResolution;
            ObjCopy.obj_MainClientForm.DisplayResolutionTrackBar.Value = int_NumOfCurrentResolution;

            ObjCopy.obj_MainClientForm.ShowSelectedDisplaySettings(int_NumOfCurrentResolution);

            ObjCopy.obj_MainClientForm.CurrentDisplayFrequency = int_CurrentDisplayFrequency;
            ObjCopy.obj_MainClientForm.CurrentDisplayColorQuality = int_CurrentBPP;

            memoryStream_ReceivedData.Close();
        }
        catch
        {

        }
    }

    void SaveReceivedScreenCopy()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_ImageFormat = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData),
            int_SourceOfScreenCaptureQuery = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        string string_ImageFormatExt = null, string_ImageName = "image";

        switch (int_ImageFormat)
        {
            case 0:
                string_ImageFormatExt = "bmp";
                break;

            case 1:
                string_ImageFormatExt = "png";
                break;

            case 2:
                string_ImageFormatExt = "jpg";
                break;

            case 3:
                string_ImageFormatExt = "gif";
                break;

            case 4:
                string_ImageFormatExt = "tif";
                break;
        }

        if (!Directory.Exists(ClientSettingsEnvironment.DownloadedScreenShotsPath))
        {
            if (DialogResult.Yes == MessageBox.Show(ClientStringFactory.GetString(49, ClientSettingsEnvironment.CurrentLanguage),
                ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Directory.CreateDirectory(ClientSettingsEnvironment.DownloadedScreenShotsPath);
            }

            else return;
        }


        int int_CycleCount = 0;

        for (; File.Exists(ClientSettingsEnvironment.DownloadedScreenShotsPath + string_ImageName + int_CycleCount.ToString() + "." + string_ImageFormatExt); int_CycleCount++)
        { }

        byte[] byteArray_ReceivedImage = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

        FileStream fileStream_ReceivedImage = File.Create(ClientSettingsEnvironment.DownloadedScreenShotsPath + string_ImageName + int_CycleCount.ToString() + "." + string_ImageFormatExt);
        fileStream_ReceivedImage.Write(byteArray_ReceivedImage, 0, byteArray_ReceivedImage.Length);

        MainClientForm.bool_CanSendCaptureRequest = true;

        ProcessStartInfo processStartInfo_Image = new ProcessStartInfo();

        processStartInfo_Image.UseShellExecute = true;
        processStartInfo_Image.FileName = ClientSettingsEnvironment.DownloadedScreenShotsPath + string_ImageName + int_CycleCount.ToString() + "." + string_ImageFormatExt;

        if (ObjCopy.obj_MainClientForm.SelectedActionWithSingleCapturedImage == 1 && int_SourceOfScreenCaptureQuery == 0)
        {
            Process.Start(processStartInfo_Image);
        }
        if (ObjCopy.obj_MainClientForm.SelectedActionWithCapturedImageInInterval == 1 && int_SourceOfScreenCaptureQuery == 1)
        {
            Process.Start(processStartInfo_Image);
        }

        fileStream_ReceivedImage.Close();

        memoryStream_ReceivedData.Close();

        if (int_SourceOfScreenCaptureQuery == 0) ObjCopy.obj_MainClientForm.EnableDisplayCapture = true;
    }

    #region RTDV environment

    void XORRleDecompress(ref byte[] byteArray_RleCompressedData, ref byte[] byteArray_PreviousUncompressedData)
    {
        byte byte_ReadedByte = 0;

        int int_DecompressedBufferPos = 0, int_CycleCount = 0, int_RleCompressedDataLength = byteArray_RleCompressedData.Length;

        for (; int_CycleCount != int_RleCompressedDataLength; int_CycleCount++)
        {
            byte_ReadedByte = byteArray_RleCompressedData[int_CycleCount];

            if (byte_ReadedByte > 127)
            {
                byte_ReadedByte = (byte)(byte_ReadedByte << 1);
                byte_ReadedByte = (byte)(byte_ReadedByte >> 1);

                int_CycleCount++;

                while (byte_ReadedByte-- != 0)
                {
                    if (byteArray_RleCompressedData[int_CycleCount] != 0)
                    {
                        byteArray_PreviousUncompressedData[int_DecompressedBufferPos] ^= byteArray_RleCompressedData[int_CycleCount];
                    }

                    int_DecompressedBufferPos++;
                }

                continue;
            }
            else
            {
                while (byte_ReadedByte-- != 0)
                {
                    int_CycleCount++;

                    if (byteArray_RleCompressedData[int_CycleCount] != 0)
                    {
                        byteArray_PreviousUncompressedData[int_DecompressedBufferPos] ^= byteArray_RleCompressedData[int_CycleCount];
                    }

                    int_DecompressedBufferPos++;
                }
            }
        }
    }

    void XORDeflateDecompres(ref byte[] byteArray_DeflateCompressedData, ref byte[] byteArray_PreviousUncompressedData)
    {
        if (byteArray_DeflateDecompressedData == null || byteArray_DeflateDecompressedData.Length != byteArray_PreviousUncompressedData.Length)
        {
            byteArray_DeflateDecompressedData = new byte[byteArray_PreviousUncompressedData.Length];
        }

        if (memoryStream_CompressedBitmap == null)
        {
            memoryStream_CompressedBitmap = new MemoryStream();
        }

        if (memoryStream_CompressedBitmap.Length > 0)
        {
            memoryStream_CompressedBitmap.SetLength(0);
        }

        memoryStream_CompressedBitmap.Write(byteArray_DeflateCompressedData, 0, byteArray_DeflateCompressedData.Length);

        memoryStream_CompressedBitmap.Position = 0;

        DeflateStream deflateStream_DecompressedBitmap = new DeflateStream(memoryStream_CompressedBitmap, CompressionMode.Decompress, true);

        deflateStream_DecompressedBitmap.Read(byteArray_DeflateDecompressedData, 0, byteArray_DeflateDecompressedData.Length);

        deflateStream_DecompressedBitmap.Flush();
        deflateStream_DecompressedBitmap.Close();

        for (int int_CycleCount = 0; int_CycleCount != byteArray_PreviousUncompressedData.Length; int_CycleCount++)
        {
            if (byteArray_DeflateDecompressedData[int_CycleCount] != 0)
            {
                byteArray_PreviousUncompressedData[int_CycleCount] ^= byteArray_DeflateDecompressedData[int_CycleCount];
            }
        }
    }

    MemoryStream memoryStream_CompressedBitmap = new MemoryStream();

    public static byte[][] byteMultiDimArray_PreviousRegions = new byte[64][];

    public static BitmapData bitmapData_obj = null, bitmapData_XORedInPng = null;

    public static Bitmap image_ReceivedImage = null, bitmap_XORedInPng = null;

    static byte[] byteArray_CurrentBitmap = null, byteArray_CurrentRegion = null,
                  byteArray_XORedCompressedRegion = null, byteArray_DeflateDecompressedData = null;

    #endregion

    #region RefreshImageInRTRDV Environment

    void RefreshImageInRTRDV()
    {
        try
        {
            lock (this)
            {
                if (ObjCopy.obj_MainClientForm.RTRDVEnabled == false) return;

                #region Sent request for NEXT frame

                MemoryStream memoryStream_DataToSend = new MemoryStream();

                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 44);

                this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

                memoryStream_DataToSend.Close();

                #endregion

                MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

                MemoryStream memoryStream_CompressedBitmap = new MemoryStream();

                DeflateStream deflateStream_DecompressedBitmap = new DeflateStream(memoryStream_CompressedBitmap, CompressionMode.Decompress, true);

                Int16 int16_RemoteScreenWidth = CommonMethods.ReadInt16FromStream(memoryStream_ReceivedData),
                        int16_RemoteScreenHeight = CommonMethods.ReadInt16FromStream(memoryStream_ReceivedData),
                        int16_CursorXPos = CommonMethods.ReadInt16FromStream(memoryStream_ReceivedData),
                        int16_CursorYPos = CommonMethods.ReadInt16FromStream(memoryStream_ReceivedData);

                byte byte_BitsPerPixel = (byte)memoryStream_ReceivedData.ReadByte(),
                    byte_RTDVRegionsCount = (byte)memoryStream_ReceivedData.ReadByte(),
                    byte_FrameEncodingAlgorithm = (byte)memoryStream_ReceivedData.ReadByte();

                int int_BytesPerPixel = byte_BitsPerPixel / 8, int_RegionPortion = byte_RTDVRegionsCount,
                    int_BitmapSize = int16_RemoteScreenWidth * int16_RemoteScreenHeight * int_BytesPerPixel,
                    int_RegionWidth = 0, int_RegionHeight = 0, int_RectangeYPoint = 0,
                    int_CopyStartIndex = 0, int_RegionIndex = 0, int_DecompressedBitmapLength = 0;

                byte[] byteArray_CompressedBitmap = null;

                IntPtr intPtr_BitmapPixelPtr = IntPtr.Zero;

                PixelFormat pixelFormat_CurrentFormat = PixelFormat.Format24bppRgb;

                if (byte_BitsPerPixel == 32)
                {
                    pixelFormat_CurrentFormat = PixelFormat.Format32bppArgb;
                }

                if (byte_BitsPerPixel == 24)
                {
                    pixelFormat_CurrentFormat = PixelFormat.Format24bppRgb;
                }

                if (byte_BitsPerPixel == 16)
                {
                    pixelFormat_CurrentFormat = PixelFormat.Format16bppRgb555;
                }

                if (image_ReceivedImage == null || image_ReceivedImage.Width != int16_RemoteScreenWidth || image_ReceivedImage.Height != int16_RemoteScreenHeight)
                {
                    image_ReceivedImage = new Bitmap(int16_RemoteScreenWidth, int16_RemoteScreenHeight, pixelFormat_CurrentFormat);
                }

                int_RegionWidth = int16_RemoteScreenWidth / int_RegionPortion;
                int_RegionHeight = int16_RemoteScreenHeight / int_RegionPortion;

                if (byteArray_CurrentRegion == null || byteArray_CurrentRegion.Length != (int_RegionWidth * int_RegionHeight) * int_BytesPerPixel)
                {
                    byteArray_CurrentRegion = new byte[(int_RegionWidth * int_RegionHeight) * int_BytesPerPixel];
                }

                bitmapData_obj = image_ReceivedImage.LockBits(new Rectangle(0, 0, int16_RemoteScreenWidth, int16_RemoteScreenHeight), ImageLockMode.ReadWrite, pixelFormat_CurrentFormat);

                intPtr_BitmapPixelPtr = bitmapData_obj.Scan0;

                if (byteArray_CurrentBitmap == null || byteArray_CurrentBitmap.Length != int_BitmapSize)
                {
                    byteArray_CurrentBitmap = new byte[int_BitmapSize];
                }


                if (byte_FrameEncodingAlgorithm == 0) // FIRST Frame
                {
                    #region Decompress First Compressed Frame

                    int_DecompressedBitmapLength = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

                    byteArray_CompressedBitmap = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

                    memoryStream_CompressedBitmap = new MemoryStream(byteArray_CompressedBitmap);

                    memoryStream_CompressedBitmap.Position = 0;

                    deflateStream_DecompressedBitmap = new DeflateStream(memoryStream_CompressedBitmap, CompressionMode.Decompress);

                    byteArray_CurrentBitmap = new byte[int_DecompressedBitmapLength];

                    deflateStream_DecompressedBitmap.Read(byteArray_CurrentBitmap, 0, byteArray_CurrentBitmap.Length);

                    deflateStream_DecompressedBitmap.Close();

                    #endregion

                    for (int int_CycleCount = 0; int_CycleCount != int_RegionPortion; int_CycleCount++)
                    {
                        int_RectangeYPoint = int_RegionHeight * int_CycleCount;

                        int_RectangeYPoint = int_RectangeYPoint * int16_RemoteScreenWidth;

                        for (int int_SubCycleCount = 0; int_SubCycleCount != int_RegionPortion; int_SubCycleCount++)
                        {
                            int_CopyStartIndex = int_RectangeYPoint + (int_SubCycleCount * int_RegionWidth);

                            for (int int_SecondSubCycleCount = 0; int_SecondSubCycleCount != int_RegionHeight; int_SecondSubCycleCount++)
                            {
                                Array.Copy(byteArray_CurrentBitmap, (int)int_CopyStartIndex * int_BytesPerPixel, byteArray_CurrentRegion, (int_SecondSubCycleCount * int_RegionWidth) * int_BytesPerPixel, int_RegionWidth * int_BytesPerPixel);

                                Marshal.Copy(byteArray_CurrentRegion, (int_SecondSubCycleCount * int_RegionWidth) * int_BytesPerPixel, (IntPtr)(intPtr_BitmapPixelPtr.ToInt64() + (int_CopyStartIndex * int_BytesPerPixel)), int_RegionWidth * int_BytesPerPixel);

                                int_CopyStartIndex += int16_RemoteScreenWidth;
                            }

                            byteMultiDimArray_PreviousRegions[int_RegionIndex] = new byte[byteArray_CurrentRegion.Length];

                            Array.Copy(byteArray_CurrentRegion, 0, byteMultiDimArray_PreviousRegions[int_RegionIndex], 0, byteArray_CurrentRegion.Length);

                            int_RegionIndex++;
                        }
                    }
                }

                else // NEXT Frame
                {
                    int_RegionIndex = 0;

                    for (int int_CycleCount = 0; int_CycleCount != int_RegionPortion; int_CycleCount++)
                    {
                        int_RectangeYPoint = int_RegionHeight * int_CycleCount;

                        int_RectangeYPoint = int_RectangeYPoint * int16_RemoteScreenWidth;

                        for (int int_SubCycleCount = 0; int_SubCycleCount != int_RegionPortion; int_SubCycleCount++)
                        {
                            int_CopyStartIndex = int_RectangeYPoint + (int_SubCycleCount * int_RegionWidth);

                            byte_FrameEncodingAlgorithm = (byte)memoryStream_ReceivedData.ReadByte();

                            byteArray_CurrentRegion = byteMultiDimArray_PreviousRegions[int_RegionIndex];

                            if (byte_FrameEncodingAlgorithm > 1)
                            {
                                byteArray_XORedCompressedRegion = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);
                            }

                            if (byte_FrameEncodingAlgorithm == 2)
                            {
                                this.XORRleDecompress(ref byteArray_XORedCompressedRegion, ref byteArray_CurrentRegion);
                            }

                            if (byte_FrameEncodingAlgorithm == 3)
                            {
                                this.XORDeflateDecompres(ref byteArray_XORedCompressedRegion, ref byteArray_CurrentRegion);
                            }

                            if (byte_FrameEncodingAlgorithm == 4)
                            {
                                bitmap_XORedInPng = new Bitmap(new MemoryStream(byteArray_XORedCompressedRegion));

                                bitmapData_XORedInPng = bitmap_XORedInPng.LockBits(new Rectangle(0, 0, int_RegionWidth, int_RegionHeight), ImageLockMode.ReadWrite, pixelFormat_CurrentFormat);

                                unsafe
                                {
                                    byte* bytePointer_XORedInPng = (byte*)bitmapData_XORedInPng.Scan0.ToPointer();

                                    for (int int_XORCycleCount = 0; int_XORCycleCount != byteMultiDimArray_PreviousRegions[int_RegionIndex].Length; int_XORCycleCount++)
                                    {
                                        if (*bytePointer_XORedInPng != 0)
                                        {
                                            byteMultiDimArray_PreviousRegions[int_RegionIndex][int_XORCycleCount] ^= *bytePointer_XORedInPng;
                                        }

                                        bytePointer_XORedInPng++;
                                    }
                                }

                                bitmap_XORedInPng.UnlockBits(bitmapData_XORedInPng);

                                byteArray_CurrentRegion = byteMultiDimArray_PreviousRegions[int_RegionIndex];
                            }

                            for (int int_ThirdSubCycleCount = 0; int_ThirdSubCycleCount != int_RegionHeight; int_ThirdSubCycleCount++)
                            {
                                Marshal.Copy(byteArray_CurrentRegion, (int_ThirdSubCycleCount * int_RegionWidth) * int_BytesPerPixel, (IntPtr)(intPtr_BitmapPixelPtr.ToInt64() + (int_CopyStartIndex * int_BytesPerPixel)), int_RegionWidth * int_BytesPerPixel);

                                int_CopyStartIndex += int16_RemoteScreenWidth;
                            }

                            int_RegionIndex++;
                        }
                    }
                }

                image_ReceivedImage.UnlockBits(bitmapData_obj);

                if (ClientSettingsEnvironment.ShowRemoteCursorInRTDV == true)
                {
                    Cursors.Arrow.Draw(Graphics.FromImage(image_ReceivedImage), new Rectangle(int16_CursorXPos - 10, int16_CursorYPos - 10, Cursors.Arrow.Size.Width, Cursors.Arrow.Size.Height));
                }

                if (ObjCopy.obj_MainClientForm.RTRDVRealSize == false)
                {
                    int int_SizeWidth = 640, int_SizeHeigth = 480;

                    if (ObjCopy.obj_MainClientForm.RTDVSizeMode == 1)
                    {
                        switch (ObjCopy.obj_MainClientForm.ReceivedImageSizeForRTDV)
                        {
                            case 0:
                                {
                                    int_SizeWidth = 320;
                                    int_SizeHeigth = 240;
                                }
                                break;

                            case 1:
                                {
                                    int_SizeWidth = 400;
                                    int_SizeHeigth = 300;
                                }
                                break;

                            case 2:
                                {
                                    int_SizeWidth = 480;
                                    int_SizeHeigth = 360;
                                }
                                break;

                            case 3:
                                {
                                    int_SizeWidth = 512;
                                    int_SizeHeigth = 384;
                                }
                                break;

                            case 4:
                                {
                                    int_SizeWidth = 640;
                                    int_SizeHeigth = 480;
                                }
                                break;
                        }

                    }
                    else
                    {
                        ObjCopy.obj_MiniRTDVForm.Invoke((MethodInvoker)delegate
                        {
                            int_SizeWidth = ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize.Width;
                            int_SizeHeigth = ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize.Height;
                        });
                    }

                    ObjCopy.obj_MiniRTDVForm.Invoke((MethodInvoker)delegate
                    {
                        ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.Image = image_ReceivedImage.GetThumbnailImage(int_SizeWidth, int_SizeHeigth, null, IntPtr.Zero);
                    });
                }

                else
                {
                    if (ObjCopy.obj_RTDVForm == null)
                    {
                        for (int int_CycleCount = 0; int_CycleCount != 100; int_CycleCount++)
                        {
                            Thread.Sleep(10);
                        }
                    }

                    if (ObjCopy.obj_RTDVForm != null)
                    {
                        ObjCopy.obj_RTDVForm.Invoke((MethodInvoker)delegate
                        {
                            if (ObjCopy.obj_RTDVForm.ClientSize != image_ReceivedImage.Size ||
                                ObjCopy.obj_RTDVForm.RemoteDisplay.Size != image_ReceivedImage.Size)
                            {
                                ObjCopy.obj_RTDVForm.RemoteDisplay.Size = image_ReceivedImage.Size;
                                ObjCopy.obj_RTDVForm.ClientSize = new Size(image_ReceivedImage.Size.Width + 2, image_ReceivedImage.Size.Height + 2);
                            }

                            ObjCopy.obj_RTDVForm.RemoteDisplay.Image = (Image)image_ReceivedImage.Clone();
                        });
                    }
                }

                memoryStream_ReceivedData.Close();
            }
        }
        catch (Exception exception)
        {
            //MessageBox.Show(exception.Message + " -- " + exception.StackTrace);
            try
            {
                // image_ReceivedImage.UnlockBits(bitmapData_obj);

                image_ReceivedImage = null;

                GC.Collect();

                new RemoteCallAction().StopRTDV();

                Thread.Sleep(500);

                new RemoteCallAction().StartRTRDV();
            }
            catch
            {

            }
        }
    }
    /*
    private const int WM_VSCROLL = 0x115;

    private const int SB_VERT = 0x1;

    private const int SB_THUMBPOSITION = 4;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern Int32 SetScrollPos(IntPtr hWnd, Int32 ScrollBar, Int32 NewPos, bool Redraw);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern bool PostMessageA(IntPtr hWnd, int nBar, int wParam, int lParam);
    */


    #endregion


        
    public void ShowCameraFrame()
    {
        try
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);            
        }
        catch
        {
        }
    }
    #region DxSound buffer play
      
 
    //Device device_SelectedDevice;
    //BufferDescription bufferDescription_obj;
    
   // Capture capture_obj;
    //CaptureBufferDescription captureBufferDescription_obj;
   // CaptureBuffer captureBuffer_obj;
    //MemoryStream memoryStreams_Record;
    /*
        public void InitDxEnvironment(int int_Buffer_LengthInSeconds)
        {
            // Create Device
            device_SelectedDevice = new Device();
            device_SelectedDevice.SetCooperativeLevel(ObjCopy.obj_MainClientForm, CooperativeLevel.Normal);

            // Init Wave Format
            WaveFormat waveFormat_CurrentFormat = new WaveFormat();

            waveFormat_CurrentFormat.BitsPerSample = 8;
            waveFormat_CurrentFormat.Channels = 1;
            waveFormat_CurrentFormat.BlockAlign = 1;

            waveFormat_CurrentFormat.FormatTag = WaveFormatTag.Pcm;
            waveFormat_CurrentFormat.SamplesPerSecond = 8000; //sampling frequency of your data;   
            waveFormat_CurrentFormat.AverageBytesPerSecond = waveFormat_CurrentFormat.SamplesPerSecond * waveFormat_CurrentFormat.BlockAlign;

            // buffer description         
            bufferDescription_obj = new BufferDescription(waveFormat_CurrentFormat);

            bufferDescription_obj.DeferLocation = true;
            bufferDescription_obj.BufferBytes = int_Buffer_LengthInSeconds * waveFormat_CurrentFormat.AverageBytesPerSecond;
            /////////////////////

            captureBufferDescription_obj = new CaptureBufferDescription();

            capture_obj = new Capture();

            captureBufferDescription_obj.Format = waveFormat_CurrentFormat;
            captureBufferDescription_obj.BufferBytes = int_Buffer_LengthInSeconds * waveFormat_CurrentFormat.AverageBytesPerSecond;
            captureBufferDescription_obj.BufferBytes = int_Buffer_LengthInSeconds * waveFormat_CurrentFormat.AverageBytesPerSecond;

            captureBuffer_obj = new CaptureBuffer(captureBufferDescription_obj, capture_obj);

            captureBufferDescription_obj.Format = waveFormat_CurrentFormat;

            memoryStreams_Record = new MemoryStream(bufferDescription_obj.BufferBytes);
        }
     * 
     *  public void PlaySoundBuffer()
    {
        try
        {
            if (device_SelectedDevice == null || bufferDescription_obj == null)
            {
                try
                {
                    unsafe
                    {
                    //    InitDxEnvironment(8000);
                    }
                }
                catch
                {
                }
            }

            SecondaryBuffer secondaryBuffer_obj = new SecondaryBuffer(bufferDescription_obj, device_SelectedDevice);

            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            secondaryBuffer_obj.SetCurrentPosition(0);

            secondaryBuffer_obj.Write(0, CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData), LockFlag.None);

            secondaryBuffer_obj.Play(0, BufferPlayFlags.Default);

            while (secondaryBuffer_obj.Status.Playing == true) Thread.Sleep(100);

            secondaryBuffer_obj.Stop();

            memoryStream_ReceivedData.Close();
        }
        catch
        {
        }
    }
        */
    public void PlaySoundBuffer()
    {
        try
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);
            
       //     ObjCopy.obj_SoundPlayAndCapture.PlaySoundBuffer(CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData));        
        }
        catch
        {
        }
    }

    #endregion



    void SaveReceivedFile()
    {
        try
        {
            while (ObjCopy.obj_FilesDownloadForm.DownloadPaused) Thread.Sleep(200);

            if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count == 0) return;

            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            int int_UINT = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            byte[] byteArray_ReceivedFileSegment = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            DatabaseOfDownloadingFiles databaseOfDownloadingFiles_CurrentElement = DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList[0];//= new DatabaseOfDownloadingFiles();

            databaseOfDownloadingFiles_CurrentElement.DownloadingFileStream.Write(byteArray_ReceivedFileSegment, 0, byteArray_ReceivedFileSegment.Length);

            databaseOfDownloadingFiles_CurrentElement.DownloadingFileStream.Flush();

            databaseOfDownloadingFiles_CurrentElement.BytesReceived += byteArray_ReceivedFileSegment.Length;

            DatabaseOfDownloadingFiles.TotalBytesRecieved += byteArray_ReceivedFileSegment.Length;

            ObjCopy.obj_FilesDownloadForm.TotalDownloadProgress = DatabaseOfDownloadingFiles.TotalBytesRecieved;

            if (databaseOfDownloadingFiles_CurrentElement.BytesReceived == databaseOfDownloadingFiles_CurrentElement.SizeOfDownloadingFile)
            {
                databaseOfDownloadingFiles_CurrentElement.DownloadingFileStream.Flush();
                databaseOfDownloadingFiles_CurrentElement.DownloadingFileStream.Close();

                ObjCopy.obj_MainClientForm.ChangeDownloadProgress();

                DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Remove(databaseOfDownloadingFiles_CurrentElement);

                if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count > 0)
                {
                    ObjCopy.obj_RemoteCallAction.SendRequestToDownloadFile();
                }

                ObjCopy.obj_MainClientForm.ChangeDownloadProgress();

                if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count == 0) return;

                ObjCopy.obj_FilesDownloadForm.CurrentFileNum++;

                return;
            }

            else ObjCopy.obj_MainClientForm.ChangeDownloadProgress();

            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 28);

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_UINT);

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, ObjCopy.obj_FilesDownloadForm.DownloadedSegmentSize);

            this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.FileObject);

            memoryStream_DataToSend.Close();
        }

        catch (Exception exception_obj)
        {

        }
    }


    void RefreshPossibleServiceAction()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_CanPauseAndContinue = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData),
            int_CanShutdown = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData),
            int_CanStop = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        if (int_CanPauseAndContinue == 1)
        {
            ObjCopy.obj_MainClientForm.EnablePauseServiceButton();
        }

        if (int_CanShutdown == 1)
        {

        }

        if (int_CanStop == 1)
        {
            ObjCopy.obj_MainClientForm.EnableStopServiceButton();
        }

        memoryStream_ReceivedData.Close();
    }


    void RefreshServicesList()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_TotalElements = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        ObjCopy.obj_MainClientForm.DeleteAllServiceViewData();

        string string_ServiceDisplayName, string_ServiceName,
                string_ServiceStatus, string_ServiceType;

        ListViewItem[] listViewItemArray_Services = new ListViewItem[int_TotalElements];

        for (int int_CycleCount = 0; int_CycleCount != int_TotalElements; int_CycleCount++)
        {
            string_ServiceDisplayName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_ServiceName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_ServiceStatus = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_ServiceType = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            if (string_ServiceStatus == "Stopped") string_ServiceStatus = String.Empty;

            listViewItemArray_Services[int_CycleCount] = new ListViewItem(string_ServiceDisplayName);

            listViewItemArray_Services[int_CycleCount].ImageIndex = 0;

            listViewItemArray_Services[int_CycleCount].SubItems.Add(string_ServiceName);
            listViewItemArray_Services[int_CycleCount].SubItems.Add(string_ServiceStatus);
            listViewItemArray_Services[int_CycleCount].SubItems.Add(string_ServiceType);

        }

        ObjCopy.obj_MainClientForm.AddServicesManagerItem(listViewItemArray_Services);

        memoryStream_ReceivedData.Close();

        ObjCopy.obj_MainClientForm.EnableServicesManager = true;
    }


    void RefreshSystemEventsList()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_ErrorCode = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        if (int_ErrorCode != 0)
        {
            ObjCopy.obj_MainClientForm.EnableSystemEventsManager = true;
            MessageBox.Show(ClientStringFactory.GetString(50, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
        }

        int int_TotalElements = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData),
            int_SystemEventType = 0;

        Int64 int64_EventID = 0;

        ObjCopy.obj_MainClientForm.SystemLogInformation = int_TotalElements.ToString() + " event(s)";
        ObjCopy.obj_MainClientForm.DeleteAllSystemEventsViewData();

        string string_DateGenerated, string_TimeGenerated,
               string_Source, string_Category, string_UserName,
               string_MachineName, string_Message, string_SystemEventType = String.Empty;

        list_EventsData.Clear();

        EventsData eventsData_CurrentEvent;

        ListViewItem[] listViewItemArray_SystemEvents = new ListViewItem[int_TotalElements];

        for (int int_CycleCount = 0; int_CycleCount != int_TotalElements; int_CycleCount++)
        {
            int_SystemEventType = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            switch (int_SystemEventType)
            {
                case 0:
                    string_SystemEventType = ClientStringFactory.GetString(51, ClientSettingsEnvironment.CurrentLanguage);
                    break;

                case 1:
                    string_SystemEventType = "FailureAudit";
                    break;

                case 2:
                    string_SystemEventType = ClientStringFactory.GetString(237, ClientSettingsEnvironment.CurrentLanguage);
                    break;

                case 3:
                    string_SystemEventType = "SuccessAudit";
                    break;

                case 4:
                    string_SystemEventType = ClientStringFactory.GetString(236, ClientSettingsEnvironment.CurrentLanguage);
                    break;
            }

            string_DateGenerated = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_TimeGenerated = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_Source = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_Category = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            int64_EventID = CommonMethods.ReadInt64FromStream(memoryStream_ReceivedData);
            string_UserName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_MachineName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_Message = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            eventsData_CurrentEvent = new EventsData();
            eventsData_CurrentEvent.EventMessage = string_Message;
            list_EventsData.Add(eventsData_CurrentEvent);

            listViewItemArray_SystemEvents[int_CycleCount] = new ListViewItem(string_SystemEventType);

            if (string_SystemEventType == ClientStringFactory.GetString(51, ClientSettingsEnvironment.CurrentLanguage)) listViewItemArray_SystemEvents[int_CycleCount].ImageIndex = 0;
            if (string_SystemEventType == ClientStringFactory.GetString(236, ClientSettingsEnvironment.CurrentLanguage)) listViewItemArray_SystemEvents[int_CycleCount].ImageIndex = 1;
            if (string_SystemEventType == ClientStringFactory.GetString(237, ClientSettingsEnvironment.CurrentLanguage)) listViewItemArray_SystemEvents[int_CycleCount].ImageIndex = 2;

            listViewItemArray_SystemEvents[int_CycleCount].SubItems.Add(string_DateGenerated);
            listViewItemArray_SystemEvents[int_CycleCount].SubItems.Add(string_TimeGenerated);
            listViewItemArray_SystemEvents[int_CycleCount].SubItems.Add(string_Source);
            listViewItemArray_SystemEvents[int_CycleCount].SubItems.Add(string_Category);
            listViewItemArray_SystemEvents[int_CycleCount].SubItems.Add(int64_EventID.ToString());
            listViewItemArray_SystemEvents[int_CycleCount].SubItems.Add(string_UserName);
            listViewItemArray_SystemEvents[int_CycleCount].SubItems.Add(string_MachineName);
        }

        ObjCopy.obj_MainClientForm.AddSystemEventsManagerItem(listViewItemArray_SystemEvents);

        memoryStream_ReceivedData.Close();

        ObjCopy.obj_MainClientForm.EnableSystemEventsManager = true;
    }


    void RefreshDriversList()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_TotalElements = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        ObjCopy.obj_MainClientForm.DeleteAllDriverViewData();

        string string_DriverDisplayName, string_DriverName, string_DriverStatus, string_DriverType;

        ListViewItem[] listViewItemArray_Driver = new ListViewItem[int_TotalElements];

        for (int int_CycleCount = 0; int_CycleCount != int_TotalElements; int_CycleCount++)
        {
            string_DriverDisplayName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_DriverName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_DriverStatus = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_DriverType = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            if (string_DriverStatus == "Stopped") string_DriverStatus = String.Empty;

            listViewItemArray_Driver[int_CycleCount] = new ListViewItem(string_DriverDisplayName);

            listViewItemArray_Driver[int_CycleCount].ImageIndex = 0;

            listViewItemArray_Driver[int_CycleCount].SubItems.Add(string_DriverName);
            listViewItemArray_Driver[int_CycleCount].SubItems.Add(string_DriverStatus);
            listViewItemArray_Driver[int_CycleCount].SubItems.Add(string_DriverType);
        }

        ObjCopy.obj_MainClientForm.AddDriversManagerItem(listViewItemArray_Driver);

        memoryStream_ReceivedData.Close();

        ObjCopy.obj_MainClientForm.EnableDriversManager = true;
    }


    void SynchronizeCryptoKeys()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        this.CurrentlyUsedTcpClient.tripleDES128bit_Session = new TripleDESCryptoServiceProvider();
        this.CurrentlyUsedTcpClient.tripleDES128bit_Session.KeySize = 128;
        this.CurrentlyUsedTcpClient.tripleDES128bit_Session.Key = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);
        this.CurrentlyUsedTcpClient.tripleDES128bit_Session.IV = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

        this.CurrentlyUsedTcpClient.tripleDES192bit_Session = new TripleDESCryptoServiceProvider();
        this.CurrentlyUsedTcpClient.tripleDES192bit_Session.KeySize = 192;
        this.CurrentlyUsedTcpClient.tripleDES192bit_Session.Key = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);
        this.CurrentlyUsedTcpClient.tripleDES192bit_Session.IV = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

        this.CurrentlyUsedTcpClient.DES64bit_Session = new DESCryptoServiceProvider();
        this.CurrentlyUsedTcpClient.DES64bit_Session.KeySize = 64;
        this.CurrentlyUsedTcpClient.DES64bit_Session.Key = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);
        this.CurrentlyUsedTcpClient.DES64bit_Session.IV = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

        this.CurrentlyUsedTcpClient.RCtwo40bit_Session = new RC2CryptoServiceProvider();
        this.CurrentlyUsedTcpClient.RCtwo40bit_Session.KeySize = 40;
        this.CurrentlyUsedTcpClient.RCtwo40bit_Session.Key = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);
        this.CurrentlyUsedTcpClient.RCtwo40bit_Session.IV = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

        this.CurrentlyUsedTcpClient.RCtwo128bit_Session = new RC2CryptoServiceProvider();
        this.CurrentlyUsedTcpClient.RCtwo128bit_Session.KeySize = 128;
        this.CurrentlyUsedTcpClient.RCtwo128bit_Session.Key = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);
        this.CurrentlyUsedTcpClient.RCtwo128bit_Session.IV = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

        this.CurrentlyUsedTcpClient.AES128bit_Session = new RijndaelManaged();
        this.CurrentlyUsedTcpClient.AES128bit_Session.KeySize = 128;
        this.CurrentlyUsedTcpClient.AES128bit_Session.Key = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);
        this.CurrentlyUsedTcpClient.AES128bit_Session.IV = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

        this.CurrentlyUsedTcpClient.AES256bit_Session = new RijndaelManaged();
        this.CurrentlyUsedTcpClient.AES256bit_Session.KeySize = 256;
        this.CurrentlyUsedTcpClient.AES256bit_Session.Key = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);
        this.CurrentlyUsedTcpClient.AES256bit_Session.IV = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

        memoryStream_ReceivedData.Close();

        this.CurrentlyUsedTcpClient.InitEncryptors();
        this.CurrentlyUsedTcpClient.InitDecryptors();

        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, -35);

        MemoryStream memoryStream_AuthData = new MemoryStream();

        CommonMethods.WriteStringToStream(memoryStream_AuthData, ObjCopy.obj_MainClientForm.LoginForConnection);
        CommonMethods.WriteStringToStream(memoryStream_AuthData, ObjCopy.obj_MainClientForm.PasswordForConnection);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.CurrentlyUsedTcpClient.EncryptData(memoryStream_AuthData.ToArray(), 8));

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.SystemData);

        memoryStream_AuthData.Close();
        memoryStream_DataToSend.Close();
    }


    void SendRSAEncryptedAuthorizationData()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_RSAKeySize = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        this.CurrentlyUsedTcpClient.XMLStringWithServersPublicRSAKeys = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

        memoryStream_ReceivedData.Close();

        RSACryptoServiceProvider rSACryptoServiceProvider_Session = new RSACryptoServiceProvider(int_RSAKeySize);

        this.CurrentlyUsedTcpClient.XMLStringWithPrivateRSAKeys = rSACryptoServiceProvider_Session.ToXmlString(true);

        rSACryptoServiceProvider_Session.FromXmlString(this.CurrentlyUsedTcpClient.XMLStringWithServersPublicRSAKeys);


        this.CurrentlyUsedTcpClient.AES256bit_PrimaryObj = new RijndaelManaged();
        this.CurrentlyUsedTcpClient.AES256bit_PrimaryObj.KeySize = 256;
        this.CurrentlyUsedTcpClient.AES256bit_PrimaryObj.GenerateIV();
        this.CurrentlyUsedTcpClient.AES256bit_PrimaryObj.GenerateKey();

        this.CurrentlyUsedTcpClient.iCryptoTransform_DecryptorAES256bit_PrimaryObj = this.CurrentlyUsedTcpClient.AES256bit_PrimaryObj.CreateDecryptor();
        this.CurrentlyUsedTcpClient.iCryptoTransform_EncryptorAES256bit_PrimaryObj = this.CurrentlyUsedTcpClient.AES256bit_PrimaryObj.CreateEncryptor();


        byte[] byteArray_EncryptedPrimaryAESKey = rSACryptoServiceProvider_Session.Encrypt(this.CurrentlyUsedTcpClient.AES256bit_PrimaryObj.Key, false),
               byteArray_EncryptedPrimaryAESIV = rSACryptoServiceProvider_Session.Encrypt(this.CurrentlyUsedTcpClient.AES256bit_PrimaryObj.IV, false);


        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, -33);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, this.CurrentlyUsedTcpClient.AES256bit_PrimaryObj.KeySize);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, byteArray_EncryptedPrimaryAESKey);
        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, byteArray_EncryptedPrimaryAESIV);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.SystemData);

        rSACryptoServiceProvider_Session.Clear();

        memoryStream_DataToSend.Close();
    }


    void RefreshDrivesInformation()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_TotalElements = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData), int_DriveType = 0;

        string string_VolumeName, string_FileSystemName, string_DriveLetter, string_DriveType = string.Empty;

        long int_TotalBytes, int_FreeBytes, int_VolumeSerialNumber,
              int_FileSystemFlags, int_MaximumFileNameLength;

        ObjCopy.obj_MainClientForm.DeleteAllDrivesInformationViewData();

        ListViewItem[] listViewItemArray_Drives = new ListViewItem[int_TotalElements];

        for (int int_CycleCount = 0; int_CycleCount != int_TotalElements; int_CycleCount++)
        {

            string_DriveLetter = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            int_DriveType = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            int_TotalBytes = BitConverter.ToInt64(CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData), 0);
            int_FreeBytes = BitConverter.ToInt64(CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData), 0);

            string_VolumeName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            int_VolumeSerialNumber = BitConverter.ToInt64(CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData), 0);
            int_MaximumFileNameLength = BitConverter.ToInt64(CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData), 0);
            int_FileSystemFlags = BitConverter.ToInt64(CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData), 0);

            string_FileSystemName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            listViewItemArray_Drives[int_CycleCount] = new ListViewItem(string_DriveLetter);

            listViewItemArray_Drives[int_CycleCount].ImageIndex = 5;

            switch (int_DriveType)
            {
                case 0:
                    string_DriveType = "Unknown";
                    break;

                case 2:
                    {
                        listViewItemArray_Drives[int_CycleCount].ImageIndex = 0;
                        string_DriveType = "Removable";
                    }
                    break;

                case 3:
                    {
                        listViewItemArray_Drives[int_CycleCount].ImageIndex = 1;
                        string_DriveType = "HDD";
                    }
                    break;

                case 4:
                    {
                        listViewItemArray_Drives[int_CycleCount].ImageIndex = 3;
                        string_DriveType = "Network Drive";
                    }
                    break;

                case 5:
                    {
                        listViewItemArray_Drives[int_CycleCount].ImageIndex = 2;
                        string_DriveType = "CD-ROM";
                    }
                    break;

                case 6:
                    string_DriveType = "RAM Drive";

                    break;
            }

            listViewItemArray_Drives[int_CycleCount].SubItems.Add(string_DriveType);
            listViewItemArray_Drives[int_CycleCount].SubItems.Add(ObjCopy.obj_MainClientForm.SpreadToHundreds(int_TotalBytes.ToString()));
            listViewItemArray_Drives[int_CycleCount].SubItems.Add(ObjCopy.obj_MainClientForm.SpreadToHundreds(int_FreeBytes.ToString()));
            listViewItemArray_Drives[int_CycleCount].SubItems.Add(string_FileSystemName);
            listViewItemArray_Drives[int_CycleCount].SubItems.Add(int_VolumeSerialNumber.ToString());
            listViewItemArray_Drives[int_CycleCount].SubItems.Add(string_VolumeName);
            listViewItemArray_Drives[int_CycleCount].SubItems.Add(int_MaximumFileNameLength.ToString());
        }

        ObjCopy.obj_MainClientForm.AddDrivesInformationViewItem(listViewItemArray_Drives);

        memoryStream_ReceivedData.Close();
    }


    void RefreshListOfExistingDrives()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_TotalElements = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        ObjCopy.obj_MainClientForm.DeleteListOfExistingDrives();
        ObjCopy.obj_MainClientForm.DeleteAllAvailableDrivesViewData();

        string string_LogicalDriveName;

        for (int int_CycleCount = 0; int_CycleCount != int_TotalElements; int_CycleCount++)
        {
            string_LogicalDriveName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            ObjCopy.obj_MainClientForm.InsertExistingDriveName(string_LogicalDriveName, int_CycleCount);
        }

        memoryStream_ReceivedData.Close();
    }


    void RefreshListOfExistingSystemLogs()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_TotalElements = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        ObjCopy.obj_MainClientForm.DeleteListOfExistingSystemLogs();

        for (int int_CycleCount = 0; int_CycleCount != int_TotalElements; int_CycleCount++)
        {
            string string_SystemLogName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            ObjCopy.obj_MainClientForm.InsertExistingSystemLogName(string_SystemLogName);
        }

        memoryStream_ReceivedData.Close();
    }


    void AnswerAboutEventsDeleting()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_ErrorCode = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        if (int_ErrorCode != 0)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(50, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Stop);

            return;
        }

        ObjCopy.obj_RemoteCallAction.CurrentSystemEventLog = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

        memoryStream_ReceivedData.Close();

        ObjCopy.obj_RemoteCallAction.GetSystemEventsList();
    }


    void AnswerAboutLogDeleting()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_ErrorCode = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        string string_LogName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

        if (int_ErrorCode != 0)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(50, ClientSettingsEnvironment.CurrentLanguage) + ": <" + string_LogName + ">", ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
        }

        else MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(53, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

        memoryStream_ReceivedData.Close();
    }


    void RefreshFileManager()
    {
        try
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            int int_TotalFolderElements = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            ObjCopy.obj_MainClientForm.DeleteAllFileManagerViewData();

            ListViewItem[] listViewItemArray_Dir = new ListViewItem[int_TotalFolderElements];

            int int_CycleCount = 0;

            string string_ItemName = String.Empty, string_ItemModifiedDate = String.Empty,
                    string_ItemAttribute = String.Empty, string_FileSize = String.Empty;

            for (; int_CycleCount != int_TotalFolderElements; int_CycleCount++)
            {
                string_ItemName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                string_ItemModifiedDate = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                string_ItemAttribute = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

                listViewItemArray_Dir[int_CycleCount] = new ListViewItem(string_ItemName.ToUpper());//, int_NecessaryItemNumber);

                listViewItemArray_Dir[int_CycleCount].ImageIndex = 0;
                listViewItemArray_Dir[int_CycleCount].SubItems.Add("");
                listViewItemArray_Dir[int_CycleCount].SubItems.Add(string_ItemModifiedDate);
                listViewItemArray_Dir[int_CycleCount].SubItems.Add(string_ItemAttribute);
                listViewItemArray_Dir[int_CycleCount].SubItems.Add(ClientStringFactory.GetString(667, ClientSettingsEnvironment.CurrentLanguage));
            }

            ObjCopy.obj_MainClientForm.AddFileManagerDirItem(listViewItemArray_Dir);

            int int_TotalFileElements = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            ListViewItem[] listViewItemArray_Files = new ListViewItem[int_TotalFileElements];

            for (int int_FileCycleCount = 0; int_FileCycleCount != int_TotalFileElements; int_CycleCount++, int_FileCycleCount++)
            {
                string_ItemName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                string_FileSize = CommonMethods.ReadInt64FromStream(memoryStream_ReceivedData).ToString();
                string_ItemModifiedDate = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                string_ItemAttribute = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

                listViewItemArray_Files[int_FileCycleCount] = new ListViewItem(string_ItemName.ToLower());

                listViewItemArray_Files[int_FileCycleCount].ImageIndex = 1;
                listViewItemArray_Files[int_FileCycleCount].SubItems.Add(ObjCopy.obj_MainClientForm.SpreadToHundreds(string_FileSize));
                listViewItemArray_Files[int_FileCycleCount].SubItems.Add(string_ItemModifiedDate);
                listViewItemArray_Files[int_FileCycleCount].SubItems.Add(string_ItemAttribute);
                listViewItemArray_Files[int_FileCycleCount].SubItems.Add(ClientStringFactory.GetString(200, ClientSettingsEnvironment.CurrentLanguage));
            }

            ObjCopy.obj_MainClientForm.AddFileManagerItem(listViewItemArray_Files);

            if (int_TotalFileElements > 0 || int_TotalFolderElements > 0) ObjCopy.obj_MainClientForm.SelectFirstFileManagetItem();

            ObjCopy.obj_MainClientForm.CurrentFilePath = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            ObjCopy.obj_MainClientForm.EnableFileManager = true;
        }

        catch (Exception exception_obj)
        {

        }
    }


    void RefreshProcessList()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_TotalElements = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        ObjCopy.obj_MainClientForm.DeleteAllProcessViewData();

        string string_ProcessName, string_MainWindowTitle,
                string_ProcessPriority, string_PID,
                string_ThreadsAmount, string_MemoryUsage;

        bool bool_IsProcessResponding;

        ListViewItem[] listViewItemArray_Process = new ListViewItem[int_TotalElements];

        for (int int_CycleCount = 0; int_CycleCount != int_TotalElements; int_CycleCount++)
        {
            string_ProcessName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_MainWindowTitle = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_ProcessPriority = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_PID = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData).ToString();
            string_ThreadsAmount = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData).ToString();

            string_MemoryUsage = CommonMethods.ReadInt64FromStream(memoryStream_ReceivedData).ToString();

            if (CommonMethods.ReadIntFromStream(memoryStream_ReceivedData) == 1) bool_IsProcessResponding = true;
            else bool_IsProcessResponding = false;

            if (string_MemoryUsage.Length > 3)
            {
                string_MemoryUsage = string_MemoryUsage.Remove(string_MemoryUsage.Length - 3, 3);
                //		string_MemoryUsage =  string_MemoryUsage.Insert(string_MemoryUsage.Length, "  KB");			
            }

            if (string_MemoryUsage.Length > 3)
            {
                string_MemoryUsage = string_MemoryUsage.Insert(string_MemoryUsage.Length - 3, ", ");
            }


            listViewItemArray_Process[int_CycleCount] = new ListViewItem(string_ProcessName);

            listViewItemArray_Process[int_CycleCount].ImageIndex = 0;

            listViewItemArray_Process[int_CycleCount].SubItems.Add(string_ProcessPriority);
            listViewItemArray_Process[int_CycleCount].SubItems.Add(string_ThreadsAmount);
            listViewItemArray_Process[int_CycleCount].SubItems.Add(string_PID);

            if (bool_IsProcessResponding)
            {
                listViewItemArray_Process[int_CycleCount].SubItems.Add(ClientStringFactory.GetString(324, ClientSettingsEnvironment.CurrentLanguage));
            }
            else
            {
                listViewItemArray_Process[int_CycleCount].SubItems.Add(ClientStringFactory.GetString(323, ClientSettingsEnvironment.CurrentLanguage));
            }

            listViewItemArray_Process[int_CycleCount].SubItems.Add(string_MemoryUsage);
            listViewItemArray_Process[int_CycleCount].SubItems.Add(string_MainWindowTitle);
        }

        ObjCopy.obj_MainClientForm.AddProcessManagerItem(listViewItemArray_Process);


        memoryStream_ReceivedData.Close();

        ObjCopy.obj_MainClientForm.EnableProcessesManager = true;
    }


    void ShowUserMessageDialogResult()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_UserMessageDialogResult = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        string string_UserMessageDialogResult = ClientStringFactory.GetString(54, ClientSettingsEnvironment.CurrentLanguage);

        switch (int_UserMessageDialogResult)
        {

            case 1:
                string_UserMessageDialogResult += ClientStringFactory.GetString(264, ClientSettingsEnvironment.CurrentLanguage);
                break;

            case 2:
                string_UserMessageDialogResult += ClientStringFactory.GetString(265, ClientSettingsEnvironment.CurrentLanguage);
                break;

            case 3:
                string_UserMessageDialogResult += ClientStringFactory.GetString(266, ClientSettingsEnvironment.CurrentLanguage);
                break;

            case 4:
                string_UserMessageDialogResult += ClientStringFactory.GetString(267, ClientSettingsEnvironment.CurrentLanguage);
                break;

            case 5:
                string_UserMessageDialogResult += "None";
                break;

            case 6:
                string_UserMessageDialogResult += ClientStringFactory.GetString(268, ClientSettingsEnvironment.CurrentLanguage);
                break;

            case 7:
                string_UserMessageDialogResult += ClientStringFactory.GetString(269, ClientSettingsEnvironment.CurrentLanguage);
                break;

            case 8:
                string_UserMessageDialogResult += ClientStringFactory.GetString(270, ClientSettingsEnvironment.CurrentLanguage);
                break;
        }

        ObjCopy.obj_MainClientForm.EnableSendMessage = true;

        MessageBox.Show(ObjCopy.obj_MainClientForm, string_UserMessageDialogResult);

        memoryStream_ReceivedData.Close();
    }


    void DeleteSelectedDownloadingTask(int int_UINT)
    {
        if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count == 0) return;

        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 37);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_UINT);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();

        DatabaseOfDownloadingFiles.TotalDownloadingSize -= DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList[0].SizeOfDownloadingFile;

        if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count > 1)
        {
            ObjCopy.obj_FilesDownloadForm.TotalFilesNum--;
            ObjCopy.obj_FilesDownloadForm.TotalDownloadProgress_MaxValue = DatabaseOfDownloadingFiles.TotalDownloadingSize;
        }

        ObjCopy.obj_MainClientForm.ChangeDownloadProgress();

        DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.RemoveAt(0);

        ObjCopy.obj_MainClientForm.ChangeDownloadProgress();

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    void ReadRequiredFileSanction()
    {
        if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count < 1 || ObjCopy.obj_FilesDownloadForm == null) return;

        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        DatabaseOfDownloadingFiles databaseOfDownloadingFiles_ZeroElement = DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList[0];

        int int_ReturnCode = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData),
            int_UINT = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        switch (int_ReturnCode)
        {
            case 0:
                break;

            case -1:
                {
                    ObjCopy.obj_FilesDownloadForm.AddError(ClientStringFactory.GetString(59, ClientSettingsEnvironment.CurrentLanguage) + " <" + databaseOfDownloadingFiles_ZeroElement.NameOfDownloadingFile + ">. " + ClientStringFactory.GetString(60, ClientSettingsEnvironment.CurrentLanguage));

                    DeleteSelectedDownloadingTask(int_UINT);

                    if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count == 0)
                        return;

                    if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count >= 1)
                        ObjCopy.obj_RemoteCallAction.SendRequestToDownloadFile();

                    return;
                }

            case -2:
                {
                    if (DialogResult.No == MessageBox.Show(ClientStringFactory.GetString(62, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(51, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        DeleteSelectedDownloadingTask(int_UINT);

                        if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count == 0)
                            return;

                        if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count >= 1)
                            ObjCopy.obj_RemoteCallAction.SendRequestToDownloadFile();
                        return;
                    }

                } break;
        }

        if (File.Exists(databaseOfDownloadingFiles_ZeroElement.LocalFolderForReceivedFiles + databaseOfDownloadingFiles_ZeroElement.NameOfDownloadingFile))
        {
            if (LastResultOfLocalFileReplace == 3 || LastResultOfLocalFileReplace == 1)
            {
                FileInfo fileInfo_LocalFile = new FileInfo(databaseOfDownloadingFiles_ZeroElement.LocalFolderForReceivedFiles + databaseOfDownloadingFiles_ZeroElement.NameOfDownloadingFile);

                ObjCopy.obj_ConfirmFileReplaceForm = new ConfirmFileReplaceForm
                    (1,
                    databaseOfDownloadingFiles_ZeroElement.NameOfDownloadingFile,
                    fileInfo_LocalFile.Length.ToString(),
                    File.GetLastWriteTime(databaseOfDownloadingFiles_ZeroElement.LocalFolderForReceivedFiles + databaseOfDownloadingFiles_ZeroElement.NameOfDownloadingFile).ToShortDateString() + "     " +
                    File.GetLastWriteTime(databaseOfDownloadingFiles_ZeroElement.LocalFolderForReceivedFiles + databaseOfDownloadingFiles_ZeroElement.NameOfDownloadingFile).ToShortTimeString(),

                    databaseOfDownloadingFiles_ZeroElement.NameOfDownloadingFile,
                    databaseOfDownloadingFiles_ZeroElement.SizeOfDownloadingFile.ToString(),
                    databaseOfDownloadingFiles_ZeroElement.TimeOfLastFileWrite);

                ObjCopy.obj_ConfirmFileReplaceForm.ShowDialog();
            }

            if (LastResultOfLocalFileReplace == 3 || LastResultOfLocalFileReplace == 4)
            {
                DeleteSelectedDownloadingTask(int_UINT);

                if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count == 0)
                    return;

                if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count >= 1)
                    ObjCopy.obj_RemoteCallAction.SendRequestToDownloadFile();

                return;
            };
        }

        if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count == 0)
            return;

        databaseOfDownloadingFiles_ZeroElement.UINT = int_UINT;

        if (!Directory.Exists(databaseOfDownloadingFiles_ZeroElement.LocalFolderForReceivedFiles)) Directory.CreateDirectory(databaseOfDownloadingFiles_ZeroElement.LocalFolderForReceivedFiles);

        databaseOfDownloadingFiles_ZeroElement.DownloadingFileStream = new FileStream(databaseOfDownloadingFiles_ZeroElement.LocalFolderForReceivedFiles + databaseOfDownloadingFiles_ZeroElement.NameOfDownloadingFile, FileMode.Create, FileAccess.ReadWrite);



        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 28);

        if (ClientSettingsEnvironment.ToEncryptDownloadedFiles) CommonMethods.WriteIntToStream(memoryStream_DataToSend, ClientSettingsEnvironment.DownloadedFilesEncryptAlgorithmIndex + 1);
        else CommonMethods.WriteIntToStream(memoryStream_DataToSend, 0);

        if (ClientSettingsEnvironment.ToCompressDownloadedFiles) CommonMethods.WriteIntToStream(memoryStream_DataToSend, ClientSettingsEnvironment.DownloadedFilesCompressAlgorithmIndex + 1);
        else CommonMethods.WriteIntToStream(memoryStream_DataToSend, 0); // отправка ин-ции о требуемом сжатии файла


        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_UINT);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ObjCopy.obj_FilesDownloadForm.DownloadedSegmentSize);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    void ShowChangesOfAccountState()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_ChangesOfAccountState = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        memoryStream_ReceivedData.Close();

        if (int_ChangesOfAccountState == 5)
        {
            MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(78, ClientSettingsEnvironment.CurrentLanguage);

            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(226, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

            ObjCopy.obj_NetworkAction.DisconnectFromServer();

            return;
        }

        if (int_ChangesOfAccountState == 4)
        {
            MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(78, ClientSettingsEnvironment.CurrentLanguage);

            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(558, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

            ObjCopy.obj_NetworkAction.DisconnectFromServer();

            return;
        }

        if (int_ChangesOfAccountState == 3)
        {
            MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(261, ClientSettingsEnvironment.CurrentLanguage);

            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(271, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

            ObjCopy.obj_NetworkAction.DisconnectFromServer();

            return;
        }

        if (int_ChangesOfAccountState == 2)
        {
            MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(261, ClientSettingsEnvironment.CurrentLanguage);

            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(562, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

            ObjCopy.obj_NetworkAction.DisconnectFromServer();

            return;
        }

        if (int_ChangesOfAccountState == 1)
        {
            ObjCopy.obj_MainClientForm.RestoreControlsEnabledState();

            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(63, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        if (int_ChangesOfAccountState == 0)
        {
            ObjCopy.obj_MainClientForm.SaveControlsEnabledState();

            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(64, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }


    void ShowAuthorizationStatus()
    {
        try
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            int int_AuthorizationStatus = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            if (int_AuthorizationStatus == 1)
            {
                new RemoteCallAction().ChangeClientDataTransferSettings();

                //!!new RemoteCallAction().GetDisplaySettings();

                new Thread(new ThreadStart(new RemoteCallAction().GetRemoteSystemInformationRootItemsCollection)).Start();

                MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(261, ClientSettingsEnvironment.CurrentLanguage);

                return;
            }

            if (int_AuthorizationStatus == 0)
            {
                ObjCopy.obj_NetworkAction.DisconnectFromServer();
                               
                ObjCopy.obj_MainClientForm.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(67, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });

                return;
            }

            if (int_AuthorizationStatus == 2)
            {
                ObjCopy.obj_NetworkAction.DisconnectFromServer();

                MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(563, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (int_AuthorizationStatus == 3)
            {
                ObjCopy.obj_NetworkAction.DisconnectFromServer();

                MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(564, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
        }
        catch (Exception exception_obj)
        {
            return;
        }
    }


    void ReadUploadedFileSanctionAndSendFilePart()
    {
        try
        {
            if (ObjCopy.obj_FilesUploadForm.UploadPaused) while (ObjCopy.obj_FilesUploadForm.UploadPaused) Thread.Sleep(200);

            if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count == 0) return;

            #region Read received data

            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            int int_ReturnCode = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData),
                int_UINT = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            switch (int_ReturnCode)
            {
                case 0:

                    break;

                case -1:
                    {
                        ObjCopy.obj_FilesUploadForm.AddError(ClientStringFactory.GetString(68, ClientSettingsEnvironment.CurrentLanguage) + " <" +
                        DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].NameOfUploadingFile + ">. " +
                        ClientStringFactory.GetString(61, ClientSettingsEnvironment.CurrentLanguage) + ClientStringFactory.GetString(69, ClientSettingsEnvironment.CurrentLanguage));

                        if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count > 1)
                        {
                            ObjCopy.obj_FilesUploadForm.TotalFilesNum--;
                            ObjCopy.obj_FilesUploadForm.TotalUploadProgress_MaxValue = DatabaseOfUploadingFiles.TotalUploadingSize - DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].SizeOfUploadingFile;
                        }

                        DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].fileStream_UploadingFile.Close();

                        DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.RemoveAt(0);

                        if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count == 0)
                        {
                            ObjCopy.obj_MainClientForm.ChangeUploadProgress();
                            return;
                        }

                        if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count >= 1)
                        {
                            ObjCopy.obj_RemoteCallAction.SendRequestToUploadFile();
                        }

                        return;
                    }


                case -2:
                    {
                        if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count > 1)
                        {
                            ObjCopy.obj_FilesUploadForm.TotalFilesNum--;
                            ObjCopy.obj_FilesUploadForm.TotalUploadProgress_MaxValue = DatabaseOfUploadingFiles.TotalUploadingSize - DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].SizeOfUploadingFile;
                        }

                        DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].fileStream_UploadingFile.Close();

                        DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.RemoveAt(0);

                        if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count == 0)
                        {
                            ObjCopy.obj_MainClientForm.ChangeUploadProgress();

                            return;
                        }

                        if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count >= 1)
                        {
                            ObjCopy.obj_RemoteCallAction.SendRequestToUploadFile();
                        }

                        return;
                    }
            }

            #endregion

            DatabaseOfUploadingFiles obj_DatabaseOfUploadingFiles = DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0];


            if (obj_DatabaseOfUploadingFiles.BytesSent == 0) obj_DatabaseOfUploadingFiles.UINT = int_UINT;

            int int_SizeOfSendingFragment = 0;

            if (obj_DatabaseOfUploadingFiles.fileStream_UploadingFile.Length - obj_DatabaseOfUploadingFiles.fileStream_UploadingFile.Position > ObjCopy.obj_FilesUploadForm.UploadedSegmentSize)
                int_SizeOfSendingFragment = ObjCopy.obj_FilesUploadForm.UploadedSegmentSize;

            else int_SizeOfSendingFragment = (int)(obj_DatabaseOfUploadingFiles.fileStream_UploadingFile.Length - obj_DatabaseOfUploadingFiles.fileStream_UploadingFile.Position);

            obj_DatabaseOfUploadingFiles.BytesSent += int_SizeOfSendingFragment;

            byte[] byteArray_SendingFragment = new byte[int_SizeOfSendingFragment];

            obj_DatabaseOfUploadingFiles.fileStream_UploadingFile.Read(byteArray_SendingFragment, 0, byteArray_SendingFragment.Length);

            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 31);
            CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_UINT);

            CommonMethods.WriteBytesToStream(memoryStream_DataToSend, byteArray_SendingFragment);



            this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.FileObject);



            memoryStream_DataToSend.Close();

            DatabaseOfUploadingFiles.TotalBytesUploaded += int_SizeOfSendingFragment;
            ObjCopy.obj_FilesUploadForm.TotalUploadProgress = DatabaseOfUploadingFiles.TotalBytesUploaded;

            if (obj_DatabaseOfUploadingFiles.fileStream_UploadingFile.Length == obj_DatabaseOfUploadingFiles.BytesSent)
            {
                obj_DatabaseOfUploadingFiles.fileStream_UploadingFile.Close();

                if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count > 1)
                {
                    ObjCopy.obj_FilesUploadForm.CurrentFileNum++;
                }

                ObjCopy.obj_MainClientForm.ChangeUploadProgress();
                obj_DatabaseOfUploadingFiles.BytesSent = 0;

                DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].fileStream_UploadingFile.Close();

                DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.RemoveAt(0);

                ObjCopy.obj_MainClientForm.ChangeUploadProgress();

                if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count >= 1)
                {
                    ObjCopy.obj_RemoteCallAction.SendRequestToUploadFile();
                }

                if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count == 0)
                    return;
            }

            else ObjCopy.obj_MainClientForm.ChangeUploadProgress();
        }

        catch (Exception exception_obj)
        {

        }
    }


    void ConfirmFileReplaceOnRemoteSide()
    {
        if (LastResultOfRemoteFileReplace == 4)
        {
            DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].fileStream_UploadingFile.Close();

            if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count > 1)
            {
                ObjCopy.obj_FilesUploadForm.TotalFilesNum--;
                ObjCopy.obj_FilesUploadForm.TotalUploadProgress_MaxValue = DatabaseOfUploadingFiles.TotalUploadingSize - DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].SizeOfUploadingFile;
            }

            DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].fileStream_UploadingFile.Close();

            DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.RemoveAt(0);

            if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count == 0)
            {
                ObjCopy.obj_MainClientForm.ChangeUploadProgress();

                return;
            }

            if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count >= 1)
            {
                ObjCopy.obj_RemoteCallAction.SendRequestToUploadFile();
            }

            return;
        }


        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        string string_RemoteFileName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData),
                string_RemoteFileSize = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData),
                string_RemoteFileLastWriteTime = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);


        FileInfo fileInfo_LocalFile = new FileInfo(DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].LocalNameOfFileWithPath);

        ObjCopy.obj_ConfirmFileReplaceForm = new ConfirmFileReplaceForm
        (0,

        fileInfo_LocalFile.Name,
        fileInfo_LocalFile.Length.ToString(),

        fileInfo_LocalFile.LastWriteTime.ToShortDateString() + "     " +
        fileInfo_LocalFile.LastWriteTime.ToShortTimeString(),

        string_RemoteFileName,
        string_RemoteFileSize,
        string_RemoteFileLastWriteTime);

        ObjCopy.obj_ConfirmFileReplaceForm.ShowDialog();


        if (LastResultOfRemoteFileReplace == 3 || LastResultOfRemoteFileReplace == 4)
        {

            if (LastResultOfRemoteFileReplace == 3) LastResultOfRemoteFileReplace = 0;

            DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].fileStream_UploadingFile.Close();

            if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count > 1)
            {
                ObjCopy.obj_FilesUploadForm.TotalFilesNum--;
                ObjCopy.obj_FilesUploadForm.TotalUploadProgress_MaxValue = DatabaseOfUploadingFiles.TotalUploadingSize - DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].SizeOfUploadingFile;
            }

            DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].fileStream_UploadingFile.Close();

            DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.RemoveAt(0);

            if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count == 0)
            {
                ObjCopy.obj_MainClientForm.ChangeUploadProgress();
                return;
            }

            if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count >= 1)
            {
                ObjCopy.obj_RemoteCallAction.SendRequestToUploadFile();
            }

            return;
        }

        DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].fileStream_UploadingFile.Close();

        ObjCopy.obj_RemoteCallAction.SendRequestToUploadFile();

        if (LastResultOfRemoteFileReplace == 1) LastResultOfRemoteFileReplace = 0;
    }


    void GetFilesOfFolders()
    {
        try
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            int int_ErrorCode = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData),
                int_CountOfFiles = 0, int_LengthOfCharsToRemove = 0, int_CountOfFolders = 0;

            long long_TotalDownloadingSize = 0;

            string string_CurrentFolder, string_PartOfNewLocalFolder, string_LocalFolderForReceivedFiles;

            if (int_ErrorCode == 1)
            {
                ObjCopy.obj_FilesDownloadForm.AddError(ClientStringFactory.GetString(339, ClientSettingsEnvironment.CurrentLanguage) + CommonMethods.ReadStringFromStream(memoryStream_ReceivedData).ToUpper());

                memoryStream_ReceivedData.Close();

                return;
            }

            ObjCopy.obj_FilesDownloadForm.EnableStopButton = true;
            ObjCopy.obj_FilesDownloadForm.Cursor = Cursors.Default;

            int_CountOfFolders = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);
            string_LocalFolderForReceivedFiles = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            DatabaseOfDownloadingFiles databaseOfDownloadingFiles_CurrentCopy;

            for (int int_CycleCount = 0; int_CountOfFolders != int_CycleCount; int_CycleCount++)
            {
                string_CurrentFolder = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

                int_CountOfFiles = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

                int_LengthOfCharsToRemove = string_CurrentFolder.LastIndexOf("\\") + 1;

                string_CurrentFolder = string_CurrentFolder.Remove(0, string_CurrentFolder.LastIndexOf("\\") + 1);

                for (int int_SubCycleCount = 0; int_SubCycleCount != int_CountOfFiles; int_SubCycleCount++)
                {
                    databaseOfDownloadingFiles_CurrentCopy = new DatabaseOfDownloadingFiles();

                    databaseOfDownloadingFiles_CurrentCopy.SizeOfDownloadingFile = CommonMethods.ReadInt64FromStream(memoryStream_ReceivedData);
                    databaseOfDownloadingFiles_CurrentCopy.TimeOfLastFileWrite = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                    databaseOfDownloadingFiles_CurrentCopy.NameOfDownloadingFile = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                    databaseOfDownloadingFiles_CurrentCopy.RemoteFileNameAndPath = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

                    string_PartOfNewLocalFolder = string_LocalFolderForReceivedFiles + databaseOfDownloadingFiles_CurrentCopy.RemoteFileNameAndPath.Remove(0, int_LengthOfCharsToRemove);

                    databaseOfDownloadingFiles_CurrentCopy.LocalFolderForReceivedFiles = string_PartOfNewLocalFolder.Remove(string_PartOfNewLocalFolder.LastIndexOf("\\"), string_PartOfNewLocalFolder.Length - string_PartOfNewLocalFolder.LastIndexOf("\\")) + "\\";

                    if (!Directory.Exists(databaseOfDownloadingFiles_CurrentCopy.LocalFolderForReceivedFiles)) Directory.CreateDirectory(databaseOfDownloadingFiles_CurrentCopy.LocalFolderForReceivedFiles);

                    DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Add(databaseOfDownloadingFiles_CurrentCopy);
                }
            }

            for (int int_CycleCount = 0; int_CycleCount != DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count; int_CycleCount++)
            {
                long_TotalDownloadingSize += DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList[int_CycleCount].SizeOfDownloadingFile;
            }

            if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count == 0)
            {
                ObjCopy.obj_MainClientForm.ShowDownloadCompleteMessage();

                DatabaseOfDownloadingFolders.list_DatabaseOfDownloadingFolders.Clear();

                return;
            }

            DatabaseOfDownloadingFiles.TotalDownloadingSize = long_TotalDownloadingSize;

            ObjCopy.obj_FilesDownloadForm.TotalDownloadProgress_MaxValue = long_TotalDownloadingSize;
            ObjCopy.obj_FilesDownloadForm.TotalFilesNum = DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count;

            new RemoteCallAction().SendRequestToDownloadFile();

            ObjCopy.obj_FilesDownloadForm.AddTask(ClientStringFactory.GetString(348, ClientSettingsEnvironment.CurrentLanguage));

            DatabaseOfDownloadingFolders.list_DatabaseOfDownloadingFolders.Clear();
        }

        catch (Exception exception_obj)
        {

        }
    }


    void ShowInfoAboutRecievedFilesArray()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        string string_SystemDataLength = ObjCopy.obj_MainClientForm.SpreadToHundreds(CommonMethods.ReadIntFromStream(memoryStream_ReceivedData).ToString());

        ObjCopy.obj_FilesDownloadForm.AddTask(ClientStringFactory.GetString(344, ClientSettingsEnvironment.CurrentLanguage) + string_SystemDataLength + " " + ClientStringFactory.GetString(345, ClientSettingsEnvironment.CurrentLanguage));

        memoryStream_ReceivedData.Close();
    }


    void ShowRemoteClipboardDataType()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        try
        {
            int int_RemoteClipboardDataType = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            if (int_RemoteClipboardDataType == 0)
            {
                ObjCopy.obj_MainClientForm.RemoteClipboardType = ClientStringFactory.GetString(680, ClientSettingsEnvironment.CurrentLanguage);
            }

            if (int_RemoteClipboardDataType == 1)
            {
                ObjCopy.obj_MainClientForm.RemoteClipboardType = ClientStringFactory.GetString(677, ClientSettingsEnvironment.CurrentLanguage);
            }

            if (int_RemoteClipboardDataType == 2)
            {
                ObjCopy.obj_MainClientForm.RemoteClipboardType = ClientStringFactory.GetString(678, ClientSettingsEnvironment.CurrentLanguage);
            }

            if (int_RemoteClipboardDataType == 3)
            {
                ObjCopy.obj_MainClientForm.RemoteClipboardType = ClientStringFactory.GetString(679, ClientSettingsEnvironment.CurrentLanguage);
            }
        }

        catch (Exception exception_obj)
        {

        }

        finally
        {
            if (memoryStream_ReceivedData != null)
            {
                memoryStream_ReceivedData.Close();
            }
        }

    }


    void PreviewReceivedClipboardData()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        try
        {
            int int_RemoteClipboardDataType = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            if (int_RemoteClipboardDataType == 0)
            {
                if (ObjCopy.obj_MainClientForm.ShowClipboardWarnings == true)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(220, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ObjCopy.obj_MainClientForm.RemoteClipboardType = ClientStringFactory.GetString(680, ClientSettingsEnvironment.CurrentLanguage);

                return;
            }
            else
            {
                ObjCopy.obj_MainClientForm.ClipboardPreviewImageData = new Bitmap(100, 100);

                ObjCopy.obj_MainClientForm.ClipboardPreviewTextData = string.Empty;

                ObjCopy.obj_MainClientForm.ClipboardPreviewFileDropListItems = new string[0];
            }

            if (int_RemoteClipboardDataType == 1)
            {
                ObjCopy.obj_MainClientForm.RemoteClipboardType = ClientStringFactory.GetString(677, ClientSettingsEnvironment.CurrentLanguage);

                MemoryStream memoryStream_RemoteClipboardImage = new MemoryStream(CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData));

                Image image_RemoteClipboardImage = Image.FromStream(memoryStream_RemoteClipboardImage);

                ObjCopy.obj_MainClientForm.ClipboardPreviewImageData = image_RemoteClipboardImage;

                //     memoryStream_RemoteClipboardImage.Close(); // DO NOT CALL CLOSE METHOD! IN OTHER CASE GDI+ ERROR ARE APPEAR WHILE SAVINE IMAGE TO A FILE!!!
            }

            if (int_RemoteClipboardDataType == 2)
            {
                ObjCopy.obj_MainClientForm.RemoteClipboardType = ClientStringFactory.GetString(678, ClientSettingsEnvironment.CurrentLanguage);

                string string_RemoteClipboardText = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

                ObjCopy.obj_MainClientForm.ClipboardPreviewTextData = string_RemoteClipboardText;
            }

            if (int_RemoteClipboardDataType == 3)
            {
                ObjCopy.obj_MainClientForm.RemoteClipboardType = ClientStringFactory.GetString(679, ClientSettingsEnvironment.CurrentLanguage);

                int int_RemoteClipboardStringsCount = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

                string[] stringArray_FileDropList = new string[int_RemoteClipboardStringsCount];

                for (int int_CycleCount = 0; int_RemoteClipboardStringsCount != int_CycleCount; int_CycleCount++)
                {
                    stringArray_FileDropList[int_CycleCount] = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                }

                ObjCopy.obj_MainClientForm.ClipboardPreviewFileDropListItems = stringArray_FileDropList;
            }
        }

        catch (Exception exception_obj)
        {

        }

        finally
        {
            if (memoryStream_ReceivedData != null)
            {
                memoryStream_ReceivedData.Close();
            }
        }
    }


    void SetReceivedTextDataToLocalClipboard()
    {
        try
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            Clipboard.SetDataObject(CommonMethods.ReadStringFromStream(memoryStream_ReceivedData), true);

            memoryStream_ReceivedData.Close();
        }

        catch (Exception)
        {

        }
    }


    void ProcessFileManagerProperties()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_FileManagerObjectType = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        string string_ObjectName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData),
               string_ObjectFullName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData),
               string_ObjectSize = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData),
               string_ObjectContainsFoldersOrExtension = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData),
               string_ObjectContainsFiles = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData),
               string_FileAttributes = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData),
               string_CreatedTime = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData),
               string_ModifiedTime = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData),
               string_AccessedTime = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

        ObjCopy.obj_FileManagerObjectPropertiesForm = new FileManagerObjectPropertiesForm(int_FileManagerObjectType, string_ObjectName, string_ObjectFullName,
        string_ObjectSize, string_ObjectContainsFoldersOrExtension, string_ObjectContainsFiles, string_FileAttributes, string_CreatedTime, string_ModifiedTime, string_AccessedTime);

        ObjCopy.obj_FileManagerObjectPropertiesForm.ShowDialog();

        memoryStream_ReceivedData.Close();
    }


    void RefreshInstalledProgramsList()
    {
        try
        {
            ObjCopy.obj_MainClientForm.EnableInstalledSoftwareManager = true;

            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            int int_TotalProgramsElements = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            ObjCopy.obj_MainClientForm.DeleteAllInstalledProgramsViewData();

            string string_ProgramName, string_ProgramVersion, string_Publisher,
                   string_InstallDate, string_InstallLocation;

            ListViewItem[] listViewItemArray_Programs = new ListViewItem[int_TotalProgramsElements];

            for (int int_CycleCount = 0; int_CycleCount != int_TotalProgramsElements; int_CycleCount++)
            {
                string_ProgramName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                string_ProgramVersion = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                string_Publisher = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                string_InstallDate = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                string_InstallLocation = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

                string_InstallDate = string_InstallDate.Replace("/", ".");
                string_InstallDate = string_InstallDate.Replace("\\", ".");
                string_InstallDate = string_InstallDate.Replace("-", ".");

                if (string_InstallDate.Length == 9)
                {
                    string_InstallDate = string_InstallDate.Insert(0, "0");
                    try
                    {
                        string_InstallDate = DateTime.Parse(string_InstallDate).ToShortDateString();
                    }
                    catch
                    {
                    }
                }

                if (string_InstallDate.Length == 8)
                {
                    string_InstallDate = string_InstallDate.Insert(4, ".");
                    string_InstallDate = string_InstallDate.Insert(7, ".");

                    try
                    {
                        string_InstallDate = DateTime.Parse(string_InstallDate).ToShortDateString();
                    }
                    catch
                    {
                    }
                }

                listViewItemArray_Programs[int_CycleCount] = new ListViewItem(string_ProgramName);

                listViewItemArray_Programs[int_CycleCount].ImageIndex = 0;

                listViewItemArray_Programs[int_CycleCount].SubItems.Add(string_ProgramVersion);
                listViewItemArray_Programs[int_CycleCount].SubItems.Add(string_Publisher);
                listViewItemArray_Programs[int_CycleCount].SubItems.Add(string_InstallDate);
                listViewItemArray_Programs[int_CycleCount].SubItems.Add(string_InstallLocation);
            }

            ObjCopy.obj_MainClientForm.AddInstalledProgramItem(listViewItemArray_Programs);

            memoryStream_ReceivedData.Close();
        }

        catch (Exception exception_obj)
        {

        }
    }


    void RefreshInstalledUpdatesList() //!!
    {
        try
        {
            ObjCopy.obj_MainClientForm.EnableInstalledUpdatesManager = true;

            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            int int_TotalProgramsElements = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            ObjCopy.obj_MainClientForm.DeleteAllInstalledUpdatesViewData();

            string string_UpdateDescription, string_InstallBy, string_InstallDate;

            ListViewItem[] listViewItemArray_Updates = new ListViewItem[int_TotalProgramsElements];

            for (int int_CycleCount = 0; int_CycleCount != int_TotalProgramsElements; int_CycleCount++)
            {
                string_UpdateDescription = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                string_InstallBy = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                string_InstallDate = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

                string_InstallDate = string_InstallDate.Replace("/", ".");
                string_InstallDate = string_InstallDate.Replace("\\", ".");
                string_InstallDate = string_InstallDate.Replace("-", ".");

                if (string_InstallDate.Length == 9)
                {
                    string_InstallDate = string_InstallDate.Insert(0, "0");
                    try
                    {
                        string_InstallDate = DateTime.Parse(string_InstallDate).ToShortDateString();
                    }
                    catch
                    {
                    }
                }

                if (string_InstallDate.Length == 8)
                {
                    string_InstallDate = string_InstallDate.Insert(4, ".");
                    string_InstallDate = string_InstallDate.Insert(7, ".");

                    try
                    {
                        string_InstallDate = DateTime.Parse(string_InstallDate).ToShortDateString();
                    }
                    catch
                    {
                    }
                }

                listViewItemArray_Updates[int_CycleCount] = new ListViewItem(string_UpdateDescription);

                listViewItemArray_Updates[int_CycleCount].ImageIndex = 0;

                listViewItemArray_Updates[int_CycleCount].SubItems.Add(string_InstallBy);
                listViewItemArray_Updates[int_CycleCount].SubItems.Add(string_InstallDate);
            }

            ObjCopy.obj_MainClientForm.AddInstalledUpdatesItem(listViewItemArray_Updates);

            memoryStream_ReceivedData.Close();
        }

        catch (Exception exception_obj)
        {

        }
    }


    void SetRemoteSystemInformationItemsCollection()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_RootNodesCount = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData),
            int_SubNodesCount = 0, int_IsEmptyNode = 0;

        string string_NewRootNodeName = String.Empty, string_NewItemName = String.Empty;

        ObjCopy.obj_MainClientForm.ClearRemoteSystemInformationNodes();

        for (int int_CycleCount = 0; int_CycleCount != int_RootNodesCount; int_CycleCount++)
        {
            string_NewRootNodeName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            int_SubNodesCount = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            ObjCopy.obj_MainClientForm.AddNewRemoteSystemInformationNode(string_NewRootNodeName, int_CycleCount, int_IsEmptyNode);

            for (int int_SubCycleCount = 0; int_SubCycleCount != int_SubNodesCount; int_SubCycleCount++)
            {
                int_IsEmptyNode = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

                string_NewItemName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

                ObjCopy.obj_MainClientForm.AddNewRemoteSystemInformationNode(string_NewItemName, int_CycleCount, int_IsEmptyNode);
            }
        }

        ObjCopy.obj_MainClientForm.RSIEnableAvailableItemsGroupBox = true;
        ObjCopy.obj_MainClientForm.RSIStatus = String.Empty;

    }


    void SetRemoteSystemInformationSelectedItemSubNodes()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_SystemInformationNodePathLength = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        int[] intArray_SystemInformationNodePath = new int[int_SystemInformationNodePathLength];

        for (int int_CycleCount = 0; int_CycleCount != int_SystemInformationNodePathLength; int_CycleCount++)
        {
            intArray_SystemInformationNodePath[int_CycleCount] = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);
        }

        int int_RSIChildNodesCount = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        string[] stringArray_ChildNodesNames = new string[int_RSIChildNodesCount];

        int[] intArray_SubItemsCount = new int[int_RSIChildNodesCount];

        for (int int_CycleCount = 0; int_CycleCount != int_RSIChildNodesCount; int_CycleCount++)
        {
            intArray_SubItemsCount[int_CycleCount] = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);
            stringArray_ChildNodesNames[int_CycleCount] = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
        }

        Delegate_AddNewRemoteSystemInformationItem delegateObj_AddNewRemoteSystemInformationItem = new Delegate_AddNewRemoteSystemInformationItem(AddNewRemoteSystemInformationItemCallback);

        ObjCopy.obj_MainClientForm.Invoke(delegateObj_AddNewRemoteSystemInformationItem, new Object[] { this.GetRemoteSystemInformationTreeNodeByPath(intArray_SystemInformationNodePath), stringArray_ChildNodesNames, intArray_SubItemsCount });

        ObjCopy.obj_MainClientForm.RSIEnableAvailableItemsGroupBox = true;
        ObjCopy.obj_MainClientForm.RSIStatus = String.Empty;
    }


    void SetRemoteSystemInformationSelectedItemContent()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        int int_SystemInformationNodePathLength = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        int[] intArray_SystemInformationNodePath = new int[int_SystemInformationNodePathLength];

        for (int int_CycleCount = 0; int_CycleCount != int_SystemInformationNodePathLength; int_CycleCount++)
        {
            intArray_SystemInformationNodePath[int_CycleCount] = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);
        }

        int int_WMIItemsCount = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);
        int int_PropertiesPerItem = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);
        int int_ColumnsCount = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        if (int_WMIItemsCount == 0 || int_PropertiesPerItem == 0) return;


        /////////////////////////////////////


        string[] stringArray_ColumnsNames = new string[int_ColumnsCount];

        int[] intArray_ColumnsSizes = new int[int_ColumnsCount];

        for (int int_CycleCount = 0; int_CycleCount != int_ColumnsCount; int_CycleCount++)
        {
            stringArray_ColumnsNames[int_CycleCount] = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            intArray_ColumnsSizes[int_CycleCount] = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);
        }

        ObjCopy.obj_MainClientForm.SetRemoteSystemInformationColumns(stringArray_ColumnsNames, intArray_ColumnsSizes);


        /////////////////////////////////////

        string[] stringArray_ItemsRange = new string[int_ColumnsCount];

        ObjCopy.obj_MainClientForm.ClearRemoteSystemInformationProperties();

        ListViewItem[] listViewItemArray_RSIItems = new ListViewItem[int_WMIItemsCount * int_PropertiesPerItem];

        int int_CurrentItemPropertiesIndex = 0;

        for (int int_CycleCount = 0; int_CycleCount != int_WMIItemsCount; int_CycleCount++)
        {
            for (int int_FirstSubCycleCount = 0; int_FirstSubCycleCount != int_PropertiesPerItem; int_FirstSubCycleCount++)
            {
                for (int int_SecondSubCycleCount = 0; int_SecondSubCycleCount != int_ColumnsCount; int_SecondSubCycleCount++)
                {
                    stringArray_ItemsRange[int_SecondSubCycleCount] = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                }

                listViewItemArray_RSIItems[int_CurrentItemPropertiesIndex++] = new ListViewItem(stringArray_ItemsRange);
            }
        }

        ObjCopy.obj_MainClientForm.AddRemoteSystemInformationItem(listViewItemArray_RSIItems);

        ObjCopy.obj_MainClientForm.RSIEnableAvailableItemsGroupBox = true;
        ObjCopy.obj_MainClientForm.RSIStatus = String.Empty;

        memoryStream_ReceivedData.Close();
    }


    #region Remote System Information Environment

    public TreeNode GetRemoteSystemInformationTreeNodeByPath(int[] intArray_RemoteSystemInformationKeyPath)
    {
        TreeNode treeNode_TempRemoteSystemInformationKey = null;

        for (int int_CycleCount = 0; int_CycleCount != intArray_RemoteSystemInformationKeyPath.Length; int_CycleCount++)
        {
            if (treeNode_TempRemoteSystemInformationKey == null && int_CycleCount > 0) return null;

            if (treeNode_TempRemoteSystemInformationKey == null && int_CycleCount == 0)
            {
                treeNode_TempRemoteSystemInformationKey = ObjCopy.obj_MainClientForm.RSI_Items.Nodes[intArray_RemoteSystemInformationKeyPath[int_CycleCount]];
            }
            else
            {
                treeNode_TempRemoteSystemInformationKey = treeNode_TempRemoteSystemInformationKey.Nodes[intArray_RemoteSystemInformationKeyPath[int_CycleCount]];
            }
        }

        return treeNode_TempRemoteSystemInformationKey;
    }

    delegate void Delegate_AddNewRemoteSystemInformationItem(TreeNode treeNode_RemoteSystemInformationItemDestination, string[] stringArray_NewRemoteSystemInformationItemsNames, int[] intArray_SubItemsCount);

    void AddNewRemoteSystemInformationItemCallback(TreeNode treeNode_RemoteSystemInformationItemDestination, string[] stringArray_NewRemoteSystemInformationItemsNames, int[] intArray_SubItemsCount)
    {
        treeNode_RemoteSystemInformationItemDestination.Nodes.Clear();

        for (int int_CycleCount = 0; int_CycleCount != stringArray_NewRemoteSystemInformationItemsNames.Length; int_CycleCount++)
        {
            if (intArray_SubItemsCount[int_CycleCount] > 0)
            {
                treeNode_RemoteSystemInformationItemDestination.Nodes.Add(stringArray_NewRemoteSystemInformationItemsNames[int_CycleCount]).Nodes.Add("");
            }

            else treeNode_RemoteSystemInformationItemDestination.Nodes.Add(stringArray_NewRemoteSystemInformationItemsNames[int_CycleCount]);
        }
    }

    #endregion

    #region Remote Registry Environment

    void SetRegistryKeyValues()
    {
        try
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            string string_RegistryKeyFullName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData),
                string_StringRepresentationOfValue = String.Empty, string_ValueName = String.Empty;

            int int_TotalElements = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData),
                int_DataTypeIndex = 0, int_ItemsCount = 0, int_DWordValue = 0;

            byte[] byteArray_BinValue = null;

            int[] intArray_RegistryKeyPath = null;

            ObjCopy.obj_MainClientForm.ClearCurrentRegistryValues();

            ListViewItem[] listViewItemArray_RegistryValues = new ListViewItem[int_TotalElements];

            for (int int_CycleCount = 0; int_CycleCount != int_TotalElements; int_CycleCount++)
            {
                string_ValueName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

                int_DataTypeIndex = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

                switch (int_DataTypeIndex)
                {
                    case 0:
                        {
                            int_DWordValue = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);
                            string_StringRepresentationOfValue = int_DWordValue.ToString();
                        }
                        break;

                    case 1:
                        {
                            string_StringRepresentationOfValue = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                        }
                        break;

                    case 2:
                        {
                            int_ItemsCount = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

                            for (int int_SubCycleCount = 0; int_SubCycleCount != int_ItemsCount; int_SubCycleCount++)
                            {
                                string_StringRepresentationOfValue += CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                                string_StringRepresentationOfValue += " ";
                            }
                        }
                        break;

                    case 3:
                        {
                            byteArray_BinValue = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

                            if (byteArray_BinValue.Length > 1)
                            {
                                string_StringRepresentationOfValue = BitConverter.ToString(byteArray_BinValue);
                            }
                            else
                            {
                                string_StringRepresentationOfValue = ClientStringFactory.GetString(595, ClientSettingsEnvironment.CurrentLanguage);
                            }
                        }
                        break;
                }

                listViewItemArray_RegistryValues[int_CycleCount] = new ListViewItem(string_ValueName);

                switch (int_DataTypeIndex)
                {
                    case 0:
                        {
                            listViewItemArray_RegistryValues[int_CycleCount].ImageIndex = 1;
                            listViewItemArray_RegistryValues[int_CycleCount].SubItems.Add(ClientStringFactory.GetString(578, ClientSettingsEnvironment.CurrentLanguage));
                        }
                        break;

                    case 1:
                        {
                            listViewItemArray_RegistryValues[int_CycleCount].ImageIndex = 2;
                            listViewItemArray_RegistryValues[int_CycleCount].SubItems.Add(ClientStringFactory.GetString(579, ClientSettingsEnvironment.CurrentLanguage));
                        }
                        break;

                    case 2:
                        {
                            listViewItemArray_RegistryValues[int_CycleCount].ImageIndex = 2;
                            listViewItemArray_RegistryValues[int_CycleCount].SubItems.Add(ClientStringFactory.GetString(580, ClientSettingsEnvironment.CurrentLanguage));
                        }
                        break;

                    case 3:
                        {
                            listViewItemArray_RegistryValues[int_CycleCount].ImageIndex = 1;
                            listViewItemArray_RegistryValues[int_CycleCount].SubItems.Add(ClientStringFactory.GetString(581, ClientSettingsEnvironment.CurrentLanguage));
                        }
                        break;
                }

                listViewItemArray_RegistryValues[int_CycleCount].SubItems.Add(string_StringRepresentationOfValue);

                string_StringRepresentationOfValue = string.Empty;
            }

            ObjCopy.obj_MainClientForm.AddNewRegistryItem(listViewItemArray_RegistryValues);

            int_ItemsCount = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            intArray_RegistryKeyPath = new int[int_ItemsCount];

            for (int int_CycleCount = 0; int_CycleCount != int_ItemsCount; int_CycleCount++)
            {
                intArray_RegistryKeyPath[int_CycleCount] = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);
            }

            ObjCopy.obj_MainClientForm.SetRegistryValuesParentNode(GetRegistryTreeNodeByPath(intArray_RegistryKeyPath));

            memoryStream_ReceivedData.Close();
        }

        catch (Exception exception_obj)
        {

        }
    }

    void ModifyRegistryKeyValues()
    {

        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        try
        {
            string string_RegistryKeyFullName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData),
                   string_ValueName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData),
                    string_StringValue = String.Empty;

            int int_DataTypeIndex = 0, int_ItemsCount = 0, int_DWordValue = 0;

            byte[] byteArray_BinValue = null;

            int_DataTypeIndex = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            switch (int_DataTypeIndex)
            {
                case 0:
                    {
                        ObjCopy.obj_MainClientForm.Invoke((MethodInvoker)delegate
                        {
                            int_DWordValue = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

                            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                            CreateDWORDValueForm createDWORDValueForm_obj = new CreateDWORDValueForm(ObjCopy.obj_MainClientForm, string_ValueName, int_DWordValue);

                            createDWORDValueForm_obj.ValueNameReadOnly = true;

                            if (createDWORDValueForm_obj.ShowDialog() != DialogResult.OK || createDWORDValueForm_obj.ValueName.Length == 0)
                            {
                                return;
                            }

                            obj_RemoteCallAction.RegistryKeyFullName = string_RegistryKeyFullName;
                            obj_RemoteCallAction.NewRegistryValueName = createDWORDValueForm_obj.ValueName;
                            obj_RemoteCallAction.NewRegistryValue = createDWORDValueForm_obj.ValueData;

                            obj_RemoteCallAction.CreateRegistryDWordValue();

                            createDWORDValueForm_obj.Close();
                        });
                    }
                    break;

                case 1:
                    {
                        ObjCopy.obj_MainClientForm.Invoke((MethodInvoker)delegate
                        {
                            string_StringValue = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

                            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                            CreateTextValueForm createTextValueForm_obj = new CreateTextValueForm(ObjCopy.obj_MainClientForm, string_ValueName, string_StringValue);

                            createTextValueForm_obj.ValueNameReadOnly = true;

                            if (createTextValueForm_obj.ShowDialog() != DialogResult.OK || createTextValueForm_obj.ValueData.Length == 0 || createTextValueForm_obj.ValueName.Length == 0)
                            {
                                return;
                            }

                            obj_RemoteCallAction.RegistryKeyFullName = string_RegistryKeyFullName;
                            obj_RemoteCallAction.NewRegistryValueName = createTextValueForm_obj.ValueName;
                            obj_RemoteCallAction.NewRegistryValue = createTextValueForm_obj.ValueData;

                            obj_RemoteCallAction.CreateRegistryStringValue();

                            createTextValueForm_obj.Close();
                        });
                    }
                    break;

                case 2:
                    {
                        ObjCopy.obj_MainClientForm.Invoke((MethodInvoker)delegate
                        {
                            int_ItemsCount = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

                            string[] stringArray_MultiStringValue = new string[int_ItemsCount];

                            for (int int_SubCycleCount = 0; int_SubCycleCount != int_ItemsCount; int_SubCycleCount++)
                            {
                                stringArray_MultiStringValue[int_SubCycleCount] = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                            }

                            CreateMultilineTextValueForm createMultilineTextValueForm_obj = new CreateMultilineTextValueForm(ObjCopy.obj_MainClientForm, string_ValueName, stringArray_MultiStringValue);

                            createMultilineTextValueForm_obj.ValueNameReadOnly = true;

                            DialogResult dialogResult_obj = createMultilineTextValueForm_obj.ShowDialog(ObjCopy.obj_MainClientForm);

                            if (dialogResult_obj != DialogResult.OK || createMultilineTextValueForm_obj.ValueData.Length == 0 || createMultilineTextValueForm_obj.ValueName.Length == 0)
                            {
                                return;
                            }

                            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                            obj_RemoteCallAction.RegistryKeyFullName = string_RegistryKeyFullName;
                            obj_RemoteCallAction.NewRegistryValueName = createMultilineTextValueForm_obj.ValueName;
                            obj_RemoteCallAction.NewRegistryValue = createMultilineTextValueForm_obj.ValueData;

                            obj_RemoteCallAction.CreateRegistryMultiStringValue();

                            createMultilineTextValueForm_obj.Close();
                        });
                    }
                    break;


                case 3:
                    {
                        byteArray_BinValue = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

                        BinaryValueViewerForm binaryValueViewerForm_obj = new BinaryValueViewerForm(ObjCopy.obj_MainClientForm, byteArray_BinValue);

                        binaryValueViewerForm_obj.ShowDialog();

                        return;
                    }
                    break;
            }

            Thread.Sleep(1000);

            ObjCopy.obj_MainClientForm.RefreshRemoteRegistryValuesContent();
        }

        catch (Exception exception_obj)
        {

        }


        finally
        {
            ObjCopy.obj_MainClientForm.Invoke((MethodInvoker)delegate
            {
                ObjCopy.obj_MainClientForm.Activate();
            });

            memoryStream_ReceivedData.Close();
        }
    }

    void ExpandRegistryKey()
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

        string string_RegistryKeyFullName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData), string_CurrentKeyName = String.Empty;

        int int_TotalElements = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData),
            int_SubKeysCount = 0, int_ItemsCount = 0;

        TreeNode[] treeNodeArray_RegistryKeys = new TreeNode[int_TotalElements];

        for (int int_CycleCount = 0; int_CycleCount != int_TotalElements; int_CycleCount++)
        {
            string_CurrentKeyName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            int_SubKeysCount = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            treeNodeArray_RegistryKeys[int_CycleCount] = new TreeNode(string_CurrentKeyName);

            if (int_SubKeysCount > 0) treeNodeArray_RegistryKeys[int_CycleCount].Nodes.Add("");
        }

        int_ItemsCount = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

        int[] intArray_RegistryKeyPath = new int[int_ItemsCount];

        for (int int_CycleCount = 0; int_CycleCount != int_ItemsCount; int_CycleCount++)
        {
            intArray_RegistryKeyPath[int_CycleCount] = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);
        }

        Delegate_AddRegistryKey delegate_AddRegistryKey_obj = new Delegate_AddRegistryKey(AddRegistryKeyCallback);

        ObjCopy.obj_MainClientForm.RemoteRegistry.Invoke(delegate_AddRegistryKey_obj, new Object[] { treeNodeArray_RegistryKeys, intArray_RegistryKeyPath, string_RegistryKeyFullName });

        memoryStream_ReceivedData.Close();
    }

    public TreeNode GetRegistryTreeNodeByPath(int[] intArray_RegistryKeyPath)
    {
        TreeNode treeNode_TempRegistryKey = null;

        for (int int_CycleCount = 0; int_CycleCount != intArray_RegistryKeyPath.Length; int_CycleCount++)
        {
            if (treeNode_TempRegistryKey == null)
            {
                treeNode_TempRegistryKey = ObjCopy.obj_MainClientForm.RemoteRegistry.Nodes[intArray_RegistryKeyPath[int_CycleCount]];
            }
            else
            {
                treeNode_TempRegistryKey = treeNode_TempRegistryKey.Nodes[intArray_RegistryKeyPath[int_CycleCount]];
            }
        }

        return treeNode_TempRegistryKey;
    }

    delegate void Delegate_AddRegistryKey(TreeNode[] treeNodeArray_RegistryKeys, int[] intArray_RegistryKeyPath, string string_RegistryKeyName);

    void AddRegistryKeyCallback(TreeNode[] treeNodeArray_RegistryKeys, int[] intArray_RegistryKeyPath, string string_RegistryKeyFullName)
    {
        try
        {
            TreeNode treeNode_TempRegistryKey = GetRegistryTreeNodeByPath(intArray_RegistryKeyPath);

            treeNode_TempRegistryKey.Nodes.Clear();
            treeNode_TempRegistryKey.Nodes.AddRange(treeNodeArray_RegistryKeys);

            treeNode_TempRegistryKey.Expand();

            ObjCopy.obj_MainClientForm.ChangeExpandButtonState(treeNode_TempRegistryKey);

            ObjCopy.obj_MainClientForm.SelectRegistryKey(treeNode_TempRegistryKey);
        }

        catch (Exception exception_obj)
        {

        }
    }

    #endregion
}