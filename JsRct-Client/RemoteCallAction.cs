using System;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctClient;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;

public class RemoteCallAction
{
    #region Local Properties

    string
        string_TextOfMessageBox, string_CaptionOfMessageBox, string_ExecutedNameOfFile,
        string_CommandLineArguments, string_WorkingDirectory, string_DisplayedNameOfService,
        string_NameOfService, string_NameOfProcess, string_PID, string_NameOfNewFolder,
        string_CurrentFilePath = "C:\\", string_LastSelectedNameOfFileWithPath,
        string_LastSelectedNameOfFolderWithPath, string_LastSelectedNameOfFolderOrFile,
        string_LastSelectedNameOfFolderOrFileWithPath, string_StatusOfService,
        string_SelectedPriorityOfProcess, string_FolderForReceivedFiles,
        string_DisplayedNameOfDriver, string_NameOfDriver, string_LastFileWriteTime,
        string_NewNameOfFolderOrFile, string_CurrentSystemEventLog, string_ConsoleCommandToSend,
        string_RegistryKeyFullName, string_RegistryValueName, string_NewRegistryValueName,
        string_RegistryKeyName;

    int int_IconOfMessageBox, int_ButtonsOfMessageBox, int_UseInformingOfUserChoice,
        int_WindowStyleForExecutedFile, int_UseShellExecute, int_DisplayErrorDialog,
        int_ExecuteWithoutWindowCreation, int_RefreshIntervalOfProcessesList,
        int_LastSelectedServiceAction, int_ForcingTermination, int_ForcingTerminationIfHung,
        int_ForcedSuspension, int_LastSelectedDriverAction, int_SizeOfLastSelectedFile,
        int_IndexOfCapturedImageFormat, int_SourceOfScreenCaptureQuery;

    bool bool_StatusOfProcessesListRefreshing = false, bool_DeleteToRecycleBin = false;

    object object_NewRegistryValue;

    List<int> list_RegistryKeyPath;

    int[] intArray_RemoteSystemInformationNodePath;

    public int[] RemoteSystemInformationNodePath
    {
        get
        {
            return intArray_RemoteSystemInformationNodePath;
        }

        set
        {
            intArray_RemoteSystemInformationNodePath = value;
        }
    }


    public List<int> RegistryKeyPath
    {
        get
        {
            return list_RegistryKeyPath;
        }

        set
        {
            list_RegistryKeyPath = value;
        }
    }


    public object NewRegistryValue
    {
        get
        {
            return object_NewRegistryValue;
        }

        set
        {
            object_NewRegistryValue = value;
        }
    }


    public string RegistryKeyName
    {
        get
        {
            return string_RegistryKeyName;
        }

        set
        {
            string_RegistryKeyName = value;
        }
    }


    public string NewRegistryValueName
    {
        get
        {
            return string_NewRegistryValueName;
        }

        set
        {
            string_NewRegistryValueName = value;
        }
    }


    public string ConsoleCommandToSend
    {
        get
        {
            return string_ConsoleCommandToSend;
        }

        set
        {
            string_ConsoleCommandToSend = value;
        }

    }

    public string CurrentSystemEventLog
    {
        get
        {
            return string_CurrentSystemEventLog;
        }

        set
        {
            string_CurrentSystemEventLog = value;
        }

    }



    public int IndexOfCapturedImageFormat
    {
        get
        {
            return int_IndexOfCapturedImageFormat;
        }

        set
        {
            int_IndexOfCapturedImageFormat = value;
        }
    }

    public int SourceOfScreenCaptureQuery
    {
        get
        {
            return int_SourceOfScreenCaptureQuery;
        }

        set
        {
            int_SourceOfScreenCaptureQuery = value;
        }
    }


    public string ExecutedNameOfFile
    {
        get
        {
            return string_ExecutedNameOfFile;
        }

        set
        {
            string_ExecutedNameOfFile = value;
        }
    }

    public string CommandLineArguments
    {
        get
        {
            return string_CommandLineArguments;
        }

        set
        {
            string_CommandLineArguments = value;
        }
    }

    public string WorkingDirectory
    {
        get
        {
            return string_WorkingDirectory;
        }

        set
        {
            string_WorkingDirectory = value;
        }
    }


    public int WindowStyleForExecutedFile
    {
        get
        {
            return int_WindowStyleForExecutedFile;
        }

        set
        {
            int_WindowStyleForExecutedFile = value;
        }
    }

    public int UseShellExecute
    {
        get
        {
            return int_UseShellExecute;
        }

        set
        {
            int_UseShellExecute = value;
        }
    }

    public int DisplayErrorDialog
    {
        get
        {
            return int_DisplayErrorDialog;
        }

        set
        {
            int_DisplayErrorDialog = value;
        }
    }

    public int ExecuteWithoutWindowCreation
    {
        get
        {
            return int_ExecuteWithoutWindowCreation;
        }

        set
        {
            int_ExecuteWithoutWindowCreation = value;
        }
    }


    public string DisplayedNameOfService
    {
        get
        {
            return string_DisplayedNameOfService;
        }

        set
        {
            string_DisplayedNameOfService = value;
        }
    }
    public string NameOfService
    {
        get
        {
            return string_NameOfService;
        }

        set
        {
            string_NameOfService = value;
        }
    }


    public string DisplayedNameOfDriver
    {
        get
        {
            return string_DisplayedNameOfDriver;
        }

        set
        {
            string_DisplayedNameOfDriver = value;
        }
    }
    public string NameOfDriver
    {
        get
        {
            return string_NameOfDriver;
        }

        set
        {
            string_NameOfDriver = value;
        }
    }


    public string NameOfProcess
    {
        get
        {
            return string_NameOfProcess;
        }

        set
        {
            string_NameOfProcess = value;
        }

    }

    public string PID
    {
        get
        {
            return string_PID;
        }

        set
        {
            string_PID = value;
        }
    }



    public int RefreshIntervalOfProcessesList
    {
        get
        {
            return int_RefreshIntervalOfProcessesList;
        }

        set
        {
            int_RefreshIntervalOfProcessesList = value;
        }
    }


    public string NameOfNewFolder
    {
        get
        {
            return string_NameOfNewFolder;
        }

        set
        {
            string_NameOfNewFolder = value;
        }
    }


    public string LastSelectedNameOfFileWithPath
    {
        get
        {
            return string_LastSelectedNameOfFileWithPath;
        }

        set
        {
            string_LastSelectedNameOfFileWithPath = value;
        }
    }

    public string LastSelectedNameOfFolderWithPath
    {
        get
        {
            return string_LastSelectedNameOfFolderWithPath;
        }

        set
        {
            string_LastSelectedNameOfFolderWithPath = value;
        }
    }


    public string LastSelectedNameOfFolderOrFile
    {
        get
        {
            return string_LastSelectedNameOfFolderOrFile;
        }

        set
        {
            string_LastSelectedNameOfFolderOrFile = value;
        }
    }

    public string LastSelectedNameOfFolderOrFileWithPath
    {
        get
        {
            return string_LastSelectedNameOfFolderOrFileWithPath;
        }

        set
        {
            string_LastSelectedNameOfFolderOrFileWithPath = value;
        }
    }


    public string NewNameOfFolderOrFile
    {

        get
        {
            return string_NewNameOfFolderOrFile;
        }

        set
        {
            string_NewNameOfFolderOrFile = value;
        }

    }

    public string LastFileWriteTime
    {
        get
        {
            return string_LastFileWriteTime;
        }

        set
        {
            string_LastFileWriteTime = value;
        }
    }

    public string CurrentFilePath
    {
        get
        {
            return string_CurrentFilePath;
        }

        set
        {
            string_CurrentFilePath = value;
        }
    }


    public string StatusOfService
    {
        get
        {
            return string_StatusOfService;
        }

        set
        {
            string_StatusOfService = value;
        }
    }


    public int LastSelectedServiceAction
    {
        get
        {
            return int_LastSelectedServiceAction;
        }

        set
        {
            int_LastSelectedServiceAction = value;
        }
    }


    public int LastSelectedDriverAction
    {
        get
        {
            return int_LastSelectedDriverAction;
        }

        set
        {
            int_LastSelectedDriverAction = value;
        }
    }

    public int ForcingTermination
    {
        get
        {
            return int_ForcingTermination;
        }

        set
        {
            int_ForcingTermination = value;
        }
    }

    public int ForcingTerminationIfHung
    {
        get
        {
            return int_ForcingTerminationIfHung;
        }

        set
        {
            int_ForcingTerminationIfHung = value;
        }
    }

    public int ForcedSuspension
    {
        get
        {
            return int_ForcedSuspension;
        }

        set
        {
            int_ForcedSuspension = value;
        }
    }


    public int SizeOfLastSelectedFile
    {
        get
        {
            return int_SizeOfLastSelectedFile;
        }

        set
        {
            int_SizeOfLastSelectedFile = value;
        }
    }


    public string SelectedPriorityOfProcess
    {
        get
        {
            return string_SelectedPriorityOfProcess;
        }

        set
        {
            string_SelectedPriorityOfProcess = value;
        }
    }


    public string FolderForReceivedFiles
    {
        get
        {
            return string_FolderForReceivedFiles;
        }

        set
        {
            string_FolderForReceivedFiles = value;
        }
    }


    public bool StatusOfProcessesListRefreshing
    {
        get
        {
            return bool_StatusOfProcessesListRefreshing;
        }

        set
        {
            bool_StatusOfProcessesListRefreshing = value;
        }
    }


    public bool DeleteToRecycleBin
    {
        get
        {
            return bool_DeleteToRecycleBin;
        }

        set
        {
            bool_DeleteToRecycleBin = value;
        }
    }


    public string RegistryKeyFullName
    {
        get
        {
            return string_RegistryKeyFullName;
        }
        set
        {
            string_RegistryKeyFullName = value;
        }
    }


    public string RegistryValueName
    {
        get
        {
            return string_RegistryValueName;
        }
        set
        {
            string_RegistryValueName = value;
        }
    }


    public MainTcpClient CurrentlyUsedTcpClient
    {
        get
        {
            return NetworkAction.tcpClient_MainClient;
        }
    }



    #endregion



    public void ChangeClientDataTransferSettings()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 47);

        if (ClientSettingsEnvironment.ToEncryptReceivedSystemData)
            CommonMethods.WriteIntToStream(memoryStream_DataToSend, ClientSettingsEnvironment.ReceivedSystemDataEncryptAlgorithmIndex + 1);
        else CommonMethods.WriteIntToStream(memoryStream_DataToSend, 0);

        if (ClientSettingsEnvironment.ToCompressReceivedSystemData)
            CommonMethods.WriteIntToStream(memoryStream_DataToSend, ClientSettingsEnvironment.ReceivedSystemDataCompressAlgorithmIndex + 1);
        else CommonMethods.WriteIntToStream(memoryStream_DataToSend, 0);

        if (ClientSettingsEnvironment.ToEncryptDownloadedFiles)
            CommonMethods.WriteIntToStream(memoryStream_DataToSend, ClientSettingsEnvironment.DownloadedFilesEncryptAlgorithmIndex + 1);
        else CommonMethods.WriteIntToStream(memoryStream_DataToSend, 0);

        if (ClientSettingsEnvironment.ToCompressDownloadedFiles)
            CommonMethods.WriteIntToStream(memoryStream_DataToSend, ClientSettingsEnvironment.DownloadedFilesCompressAlgorithmIndex + 1);
        else CommonMethods.WriteIntToStream(memoryStream_DataToSend, 0);

        if (ClientSettingsEnvironment.ToEncryptReceivedScreenshots)
            CommonMethods.WriteIntToStream(memoryStream_DataToSend, ClientSettingsEnvironment.ReceivedScreenshotsEncryptAlgorithmIndex + 1);
        else CommonMethods.WriteIntToStream(memoryStream_DataToSend, 0);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void StopRTDV()
    {
        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(48), SentDataType.ApplicationData);
    }


    public void GetDisplaySettings()
    {
        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(45), SentDataType.ApplicationData);
    }


    public void SetDisplaySettings()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 46);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ObjCopy.obj_MainClientForm.GetSelectedScreenWidth());
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ObjCopy.obj_MainClientForm.GetSelectedScreenHeight());
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ObjCopy.obj_MainClientForm.CurrentDisplayColorQuality);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ObjCopy.obj_MainClientForm.CurrentDisplayFrequency);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void EjectCD()
    {
        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(22), SentDataType.ApplicationData);
    }


    public void CloseCD()
    {
        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(23), SentDataType.ApplicationData);
    }



    public void StartWebCam()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 82);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }

    public void StartMicRecord()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 83);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void InformAboutDisconnect()
    {
        try
        {
            this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(40), SentDataType.ApplicationData);
        }
        catch
        {
        }
    }


    public void ShutDown()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 14);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ForcingTermination);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ForcingTerminationIfHung);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void PowerOff()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 15);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ForcingTermination);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ForcingTerminationIfHung);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void Restart()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 16);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ForcingTermination);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ForcingTerminationIfHung);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void UserLogOff()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 17);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ForcingTermination);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ForcingTerminationIfHung);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void StandBy()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 18);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ForcedSuspension);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void Hibernate()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 19);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ForcedSuspension);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void LockWorkStation()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 58);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ForcedSuspension);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void ChangeProcessPriority()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 2);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, NameOfProcess);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, Convert.ToInt32(PID));

        switch (SelectedPriorityOfProcess)
        {
            case ("Idle"):
                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 0);
                break;

            case ("Low"):
                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1);
                break;

            case ("BelowNormal"):
                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 2);
                break;

            case ("Normal"):
                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 3);
                break;

            case ("AboveNormal"):
                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 4);
                break;

            case ("High"):
                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 5);
                break;

            case ("RealTime"):
                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 6);
                break;

        }

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        GetProcessList();
    }


    public void ActionWithSelectedService()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 12);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, DisplayedNameOfService);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, NameOfService);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, Convert.ToInt32(LastSelectedServiceAction));

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();

        GetServicesList();
    }


    public void ExecuteConsoleCommand()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 43);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, ConsoleCommandToSend);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void DeleteFolder()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 21);

        if (DeleteToRecycleBin) CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1);
        else CommonMethods.WriteIntToStream(memoryStream_DataToSend, 0);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, LastSelectedNameOfFolderWithPath);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void RenameFolderOrFile()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 29);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, LastSelectedNameOfFolderOrFileWithPath);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, NewNameOfFolderOrFile);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        GetFileList();

        memoryStream_DataToSend.Close();
    }


    public void CreateNewFolder()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 20);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, CurrentFilePath + NameOfNewFolder);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        GetFileList();

        memoryStream_DataToSend.Close();
    }


    public void DeleteFile()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 13);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, LastSelectedNameOfFileWithPath);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void ReceiveFileManagerObjectPropertes(int int_FileManagerObjectType)
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 54);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_FileManagerObjectType);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, LastSelectedNameOfFolderOrFileWithPath);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void GetDrivesInformation()
    {
        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(42), SentDataType.ApplicationData);
    }


    public void ClearRemoteClipboard()
    {
        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(77), SentDataType.ApplicationData);
    }


    public void GetRemoteClipboardDataType()
    {
        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(80), SentDataType.ApplicationData);
    }

    public void SendImageToRemoteClipboard(Image image_SentImage)
    {
        MemoryStream memoryStream_SentData = new MemoryStream();

        try
        {
            CommonMethods.WriteIntToStream(memoryStream_SentData, (int)81);

            int int_ImageFormat = ObjCopy.obj_MainClientForm.RemoteClipboardPreviewImageFormat;

            int int_AdditionalImageCaptureParameterValue = 0;

            if (ObjCopy.obj_MainClientForm.RemoteClipboardPreviewImageFormat == 2)//where 2 is JPEG
            {
                int_AdditionalImageCaptureParameterValue = ObjCopy.obj_MainClientForm.RemoteClipboardPreviewImageQuality;
            }
            if (ObjCopy.obj_MainClientForm.RemoteClipboardPreviewImageFormat == 4) //where 4 is TIFF
            {
                int_AdditionalImageCaptureParameterValue = ObjCopy.obj_MainClientForm.RemoteClipboardPreviewImageCompressionFormat;
            }

            MemoryStream memoryStream_CapturedImage = new MemoryStream();

            ImageFormat imageFormat_ImageFormat = null;

            ImageCodecInfo imageCodecInfo_obj = null;

            EncoderParameters encoderParameters_obj = new EncoderParameters();

            switch (int_ImageFormat)
            {
                case 0:
                    imageFormat_ImageFormat = ImageFormat.Bmp;
                    break;

                case 1:
                    imageFormat_ImageFormat = ImageFormat.Png;
                    break;

                case 2:
                    {
                        imageFormat_ImageFormat = ImageFormat.Jpeg;
                        imageCodecInfo_obj = ImageCodecInfo.GetImageEncoders()[1];
                    }
                    break;

                case 3:
                    imageFormat_ImageFormat = ImageFormat.Gif;
                    break;

                case 4:
                    {
                        imageCodecInfo_obj = ImageCodecInfo.GetImageEncoders()[3];
                        imageFormat_ImageFormat = ImageFormat.Tiff;
                    }
                    break;
            }

            if (int_ImageFormat == 2)
            {
                encoderParameters_obj.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, int_AdditionalImageCaptureParameterValue);
            }

            if (int_ImageFormat == 4)
            {
                if (int_AdditionalImageCaptureParameterValue == 0)
                {
                    encoderParameters_obj.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)System.Drawing.Imaging.EncoderValue.CompressionLZW);
                }
                else
                {
                    encoderParameters_obj.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)System.Drawing.Imaging.EncoderValue.CompressionNone);
                }
            }

            if ((int_ImageFormat == 2 || int_ImageFormat == 4) && encoderParameters_obj != null)
            {
                image_SentImage.Save(memoryStream_CapturedImage, imageCodecInfo_obj, encoderParameters_obj);

                encoderParameters_obj.Param[0].Dispose();

                encoderParameters_obj.Dispose();
            }
            else
            {
                image_SentImage.Save(memoryStream_CapturedImage, imageFormat_ImageFormat);
            }

            CommonMethods.WriteBytesToStream(memoryStream_SentData, memoryStream_CapturedImage.ToArray());

            memoryStream_CapturedImage.Close();          
            
            CurrentlyUsedTcpClient.SendData(memoryStream_SentData.ToArray(), SentDataType.ApplicationData);

            memoryStream_SentData.Close();
        
        }

        catch (Exception exception_obj)
        {

        }

        finally
        {
            if (memoryStream_SentData != null)
            {
                memoryStream_SentData.Close();
            }
        }
    }

    public void Local2RemoteClipboardSync()
    {
        if (Clipboard.ContainsFileDropList() == false && Clipboard.ContainsImage() == false && Clipboard.ContainsText() == false)
        {
            return;
        }

        MemoryStream memoryStream_SentData = new MemoryStream();

        try
        {
            CommonMethods.WriteIntToStream(memoryStream_SentData, (int)79);

            if (Clipboard.ContainsImage() == true)
            {
                int int_ImageFormat = ObjCopy.obj_MainClientForm.RemoteClipboardPreviewImageFormat;

                int int_AdditionalImageCaptureParameterValue = 0;

                if (ObjCopy.obj_MainClientForm.RemoteClipboardPreviewImageFormat == 2)
                {
                    int_AdditionalImageCaptureParameterValue = ObjCopy.obj_MainClientForm.RemoteClipboardPreviewImageQuality;
                }
                if (ObjCopy.obj_MainClientForm.RemoteClipboardPreviewImageFormat == 4)
                {
                    int_AdditionalImageCaptureParameterValue = ObjCopy.obj_MainClientForm.RemoteClipboardPreviewImageCompressionFormat;
                }

                MemoryStream memoryStream_CapturedImage = new MemoryStream();

                Image image_ClipboardImage = Clipboard.GetImage();

                ImageFormat imageFormat_ImageFormat = null;

                ImageCodecInfo imageCodecInfo_obj = null;

                EncoderParameters encoderParameters_obj = new EncoderParameters();

                switch (int_ImageFormat)
                {
                    case 0:
                        imageFormat_ImageFormat = ImageFormat.Bmp;
                        break;

                    case 1:
                        imageFormat_ImageFormat = ImageFormat.Png;
                        break;

                    case 2:
                        {
                            imageFormat_ImageFormat = ImageFormat.Jpeg;
                            imageCodecInfo_obj = ImageCodecInfo.GetImageEncoders()[1];
                        }
                        break;

                    case 3:
                        imageFormat_ImageFormat = ImageFormat.Gif;
                        break;

                    case 4:
                        {
                            imageCodecInfo_obj = ImageCodecInfo.GetImageEncoders()[3];
                            imageFormat_ImageFormat = ImageFormat.Tiff;
                        }
                        break;
                }

                if (int_ImageFormat == 2)
                {
                    encoderParameters_obj.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, int_AdditionalImageCaptureParameterValue);
                }

                if (int_ImageFormat == 4)
                {
                    if (int_AdditionalImageCaptureParameterValue == 0)
                    {
                        encoderParameters_obj.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)System.Drawing.Imaging.EncoderValue.CompressionLZW);
                    }
                    else
                    {
                        encoderParameters_obj.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)System.Drawing.Imaging.EncoderValue.CompressionNone);
                    }
                }

                if ((int_ImageFormat == 2 || int_ImageFormat == 4) && encoderParameters_obj != null)
                {
                    image_ClipboardImage.Save(memoryStream_CapturedImage, imageCodecInfo_obj, encoderParameters_obj);

                    encoderParameters_obj.Param[0].Dispose();

                    encoderParameters_obj.Dispose();
                }
                else
                {
                    image_ClipboardImage.Save(memoryStream_CapturedImage, imageFormat_ImageFormat);
                }

                CommonMethods.WriteIntToStream(memoryStream_SentData, 1);

                CommonMethods.WriteBytesToStream(memoryStream_SentData, memoryStream_CapturedImage.ToArray());

                memoryStream_CapturedImage.Close();
            }

            if (Clipboard.ContainsText() == true)
            {
                CommonMethods.WriteIntToStream(memoryStream_SentData, 2);

                string string_ClipboardText = Clipboard.GetText();

                CommonMethods.WriteStringToStream(memoryStream_SentData, string_ClipboardText);
            }

            if (Clipboard.ContainsFileDropList() == true)
            {
                CommonMethods.WriteIntToStream(memoryStream_SentData, 3);

                System.Collections.Specialized.StringCollection stringCollection_ClipboardFileDropList = Clipboard.GetFileDropList();

                CommonMethods.WriteIntToStream(memoryStream_SentData, stringCollection_ClipboardFileDropList.Count);

                foreach (String string_obj in stringCollection_ClipboardFileDropList)
                {
                    CommonMethods.WriteStringToStream(memoryStream_SentData, string_obj);
                }
            }

            CurrentlyUsedTcpClient.SendData(memoryStream_SentData.ToArray(), SentDataType.ApplicationData);

            memoryStream_SentData.Close();
        }

        catch (Exception exception_obj)
        {

        }

        finally
        {
            if (memoryStream_SentData != null)
            {
                memoryStream_SentData.Close();
            }
        }
    }


    public void SendRequestToUploadFile()
    {
        try
        {

            DatabaseOfUploadingFiles obj_DatabaseOfUploadingFiles = DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0];

            obj_DatabaseOfUploadingFiles.fileStream_UploadingFile = new FileStream(obj_DatabaseOfUploadingFiles.LocalNameOfFileWithPath, FileMode.Open, FileAccess.Read, FileShare.None);
            obj_DatabaseOfUploadingFiles.fileStream_UploadingFile.Position = 0;

            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 30);
            CommonMethods.WriteInt64ToStream(memoryStream_DataToSend, obj_DatabaseOfUploadingFiles.SizeOfUploadingFile);

            // bool - overwrite file is 0 ->
            CommonMethods.WriteIntToStream(memoryStream_DataToSend, LocalAction.LastResultOfRemoteFileReplace);

            CommonMethods.WriteStringToStream(memoryStream_DataToSend, obj_DatabaseOfUploadingFiles.NameOfUploadingFile);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, obj_DatabaseOfUploadingFiles.RemoteFolderForReceivedFiles);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, obj_DatabaseOfUploadingFiles.TimeOfLastFileWrite);

            this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        catch (IOException)
        {
            ObjCopy.obj_FilesUploadForm.AddError(ClientStringFactory.GetString(68, ClientSettingsEnvironment.CurrentLanguage) + " <" +
                DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].NameOfUploadingFile + ">. " +
                ClientStringFactory.GetString(246, ClientSettingsEnvironment.CurrentLanguage) + ClientStringFactory.GetString(69, ClientSettingsEnvironment.CurrentLanguage));


            if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count > 1)
            {
                ObjCopy.obj_FilesUploadForm.TotalFilesNum--;
                ObjCopy.obj_FilesUploadForm.TotalUploadProgress_MaxValue = DatabaseOfUploadingFiles.TotalUploadingSize - DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].SizeOfUploadingFile;
            }

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
        }

    }


    public void GetRemoteClipboardTextData()
    {
        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(52), SentDataType.ApplicationData);
    }


    public void GetRemoteClipboardData()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 78);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ObjCopy.obj_MainClientForm.RemoteClipboardPreviewImageFormat);

        int int_AdditionalImageCaptureParameterValue = 0;

        if (ObjCopy.obj_MainClientForm.RemoteClipboardPreviewImageFormat == 2)
        {
            int_AdditionalImageCaptureParameterValue = ObjCopy.obj_MainClientForm.RemoteClipboardPreviewImageQuality;
        }
        if (ObjCopy.obj_MainClientForm.RemoteClipboardPreviewImageFormat == 4)
        {
            int_AdditionalImageCaptureParameterValue = ObjCopy.obj_MainClientForm.RemoteClipboardPreviewImageCompressionFormat;
        }

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_AdditionalImageCaptureParameterValue);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void SetRemoteClipboardTextData()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        try
        {
            IDataObject iDataOject_obj = Clipboard.GetDataObject();

            string string_SendingClipboardString = string.Empty;

            // Determines whether the data is in a format you can use.
            if (iDataOject_obj != null && iDataOject_obj.GetDataPresent(DataFormats.UnicodeText))
            {
                string_SendingClipboardString = (String)iDataOject_obj.GetData(DataFormats.UnicodeText);
            }
            else
            {
                MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(357, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                return;
            }

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 53);

            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_SendingClipboardString);

            this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }
        catch
        {
        }

        finally
        {
            memoryStream_DataToSend.Close();
        }
    }


    public void SendRequestToDownloadFolders()
    {
        try
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 49);

            CommonMethods.WriteStringToStream(memoryStream_DataToSend, DatabaseOfDownloadingFolders.list_DatabaseOfDownloadingFolders[0].LocalFolderForReceivedFolder);

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, DatabaseOfDownloadingFolders.list_DatabaseOfDownloadingFolders.Count);

            for (int int_CycleCount = 0; int_CycleCount != DatabaseOfDownloadingFolders.list_DatabaseOfDownloadingFolders.Count; int_CycleCount++)
            {
                CommonMethods.WriteStringToStream(memoryStream_DataToSend, DatabaseOfDownloadingFolders.list_DatabaseOfDownloadingFolders[int_CycleCount].RemoteFolderNameAndPath);
            }

            this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        catch (Exception)
        {
        }
    }


    public void SendRequestToDownloadFile()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 27);
        CommonMethods.WriteInt64ToStream(memoryStream_DataToSend, DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList[0].SizeOfDownloadingFile);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList[0].RemoteFileNameAndPath);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList[0].TimeOfLastFileWrite);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void GetPossibleServiceActions()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 9);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, DisplayedNameOfService);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, NameOfService);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void GetPossibleDriverActions()
    {

        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 26);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, DisplayedNameOfDriver);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, NameOfDriver);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void GetServicesList()
    {
        ObjCopy.obj_MainClientForm.EnableServicesManager = false;

        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(8), SentDataType.ApplicationData);
    }


    public void GetDriversList()
    {
        ObjCopy.obj_MainClientForm.EnableDriversManager = false;

        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(24), SentDataType.ApplicationData);
    }

    public void SetMouseMoveEvent(int int_X, int int_Y)
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 50);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_X);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_Y);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }
  
    public void SetMouseMoveEventFromMiniRTDV(int int_X, int int_Y)
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 56);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_X);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_Y);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }

    public void SetMouseButtonClickEvent(int int_X, int int_Y, int int_MouseEventType, int int_MouseButtonNum, int int_MouseClicksCount)
    {
        //int_MouseEventType - 0 is MouseDown, 1 id MouseUp
        //int_MouseButtonNum - 1 is Left Mouse Button, 2 is Middle Mouse Button Up, 3 is Right Mouse Button
        //int_ClicksCount - 1 is Mouse Click, 2 is Double Click 

        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 57);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_MouseEventType);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_MouseButtonNum);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_MouseClicksCount);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_X);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_Y);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void SetSingleKeyKeyboardEvent(int int_EventType, int int_KeyValue, Keys keys_obj)
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 51);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_EventType);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_KeyValue);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, (int)keys_obj);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void SetSequenceOfTwoKeysKeyboardEvent(int int_TypeOfSequence)
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 59);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_TypeOfSequence);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void SetSequenceOfThreeKeysKeyboardEvent(int int_TypeOfSequence)
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 60);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_TypeOfSequence);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void StartRTRDV()
    {
        if (ObjCopy.obj_MainClientForm.RTRDVEnabled)
        {
            if (ObjCopy.obj_MainClientForm.RTRDVRealSize)
            {
                ObjCopy.obj_MainClientForm.BringToFront();

                ObjCopy.obj_RTDVForm = new RTDVForm();

                ObjCopy.obj_RTDVForm.Location = new System.Drawing.Point(0, 0);

                ObjCopy.obj_RTDVForm.Show();
            }

            int int_RTDVRegionsCount = 0;

            switch (ObjCopy.obj_MainClientForm.RTDVRegionsCount)
            {
                case 0:
                    int_RTDVRegionsCount = 1;
                    break;

                case 1:
                    int_RTDVRegionsCount = 2;
                    break;

                case 2:
                    int_RTDVRegionsCount = 4;
                    break;

                case 3:
                    int_RTDVRegionsCount = 8;
                    break;
            }

            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 62);

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, (int)ObjCopy.obj_MainClientForm.MaxRTDVUpsatesPerSec);

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, (int)ObjCopy.obj_MainClientForm.RTDVImageCodingAlgorithm);

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_RTDVRegionsCount);

            this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }
    }


    public void GetSystemEventsList()
    {
        ObjCopy.obj_MainClientForm.EnableSystemEventsManager = false;

        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 33);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, CurrentSystemEventLog);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void DeleteSystemEventsList()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 34);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, CurrentSystemEventLog);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void DeleteSystemLog()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 35);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, CurrentSystemEventLog);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void GetListOfExistingDrives()
    {
        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(7), SentDataType.ApplicationData);
    }


    public void GetInstalledProgramsList()
    {
        ObjCopy.obj_MainClientForm.EnableInstalledSoftwareManager = false;

        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(61), SentDataType.ApplicationData);
    }


    public void GetInstalledUpdatesList()
    {
        ObjCopy.obj_MainClientForm.EnableInstalledUpdatesManager = false;

        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(63), SentDataType.ApplicationData);
    }


    public void GetListOfExistingSystemLogs()
    {
        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(32), SentDataType.ApplicationData);
    }


    public void ReceiveCapturedScreen()
    {
        if (int_SourceOfScreenCaptureQuery == 0) ObjCopy.obj_MainClientForm.EnableDisplayCapture = false;

        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 39);

        if (ClientSettingsEnvironment.ToEncryptReceivedScreenshots)
        {
            CommonMethods.WriteIntToStream(memoryStream_DataToSend, ClientSettingsEnvironment.ReceivedScreenshotsEncryptAlgorithmIndex + 1);
        }
        else
        {
            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 0);
        }

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, IndexOfCapturedImageFormat);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, SourceOfScreenCaptureQuery);

        int int_AdditionalImageCaptureParameterValue = 0;

        switch (SourceOfScreenCaptureQuery)
        {
            case 0:
                {
                    if (IndexOfCapturedImageFormat == 2)
                    {
                        int_AdditionalImageCaptureParameterValue = ObjCopy.obj_MainClientForm.SingleImageCaptureQualityLevel;
                    }
                    if (IndexOfCapturedImageFormat == 4)
                    {
                        int_AdditionalImageCaptureParameterValue = ObjCopy.obj_MainClientForm.SingleImageCaptureCompressionFormat;
                    }
                    break;
                }

            case 1:
                {
                    if (IndexOfCapturedImageFormat == 2)
                    {
                        int_AdditionalImageCaptureParameterValue = ObjCopy.obj_MainClientForm.CaptureInIntervaQualityLevel;
                    }
                    if (IndexOfCapturedImageFormat == 4)
                    {
                        int_AdditionalImageCaptureParameterValue = ObjCopy.obj_MainClientForm.CaptureInIntervaCompressionFormat;
                    }
                    break;
                }
        }

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_AdditionalImageCaptureParameterValue);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void GetFileList()
    {
        ObjCopy.obj_MainClientForm.EnableFileManager = false;

        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, CurrentFilePath);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();

        Thread.Sleep(5000);

        ObjCopy.obj_MainClientForm.EnableFileManager = true;
    }


    public void GetProcessList()
    {
        ObjCopy.obj_MainClientForm.EnableProcessesManager = false;

        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(4), SentDataType.ApplicationData);
    }


    public void GetFullProcessInfo()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 2);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, NameOfProcess);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, Convert.ToInt32(PID));

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void EnableMessageButton()
    {
        Thread.Sleep(2000);

        ObjCopy.obj_MainClientForm.EnableSendMessage = true;
    }


    public void SendMessage(string MessageBoxCaption, string MessageBoxText, int MessageBoxIconIndex, int MessageBoxButtonsCollection, int InformingOfUserChoice)
    {
        ObjCopy.obj_MainClientForm.EnableSendMessage = false;

        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 6);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, MessageBoxCaption);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, MessageBoxText);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, MessageBoxIconIndex);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, MessageBoxButtonsCollection);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, InformingOfUserChoice);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();

        new Thread(new ThreadStart(EnableMessageButton)).Start();
    }


    public void ExecuteProcess()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 5);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, ExecutedNameOfFile);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, CommandLineArguments);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, WorkingDirectory);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, WindowStyleForExecutedFile);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ExecuteWithoutWindowCreation);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, UseShellExecute);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, DisplayErrorDialog);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void KillSelectedProcess()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 3);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, NameOfProcess);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, Convert.ToInt32(PID));

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();

        GetProcessList();
    }


    public void ActivateWindowOfSelectedProcess()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 41);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, NameOfProcess);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, Convert.ToInt32(PID));

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();

        GetProcessList();
    }


    public void DeleteAllUploadingTasks()
    {
        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(36), SentDataType.ApplicationData);
    }


    public void DeleteAllDownloadingTasks()
    {
        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(38), SentDataType.ApplicationData);
    }


    public void SendAuthorizationRequest()
    {
        this.CurrentlyUsedTcpClient.SendData(BitConverter.GetBytes(-37), SentDataType.SystemData);
    }


    public void GetRegistrySubKeysList()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 64);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.RegistryKeyFullName);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, this.RegistryKeyPath.Count);

        for (int int_CycleCount = 0; int_CycleCount != this.RegistryKeyPath.Count; int_CycleCount++)
        {
            CommonMethods.WriteIntToStream(memoryStream_DataToSend, (int)this.RegistryKeyPath[int_CycleCount]);
        }

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void GetRegistryKeyValues()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 65);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.RegistryKeyFullName);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, this.RegistryKeyPath.Count);

        for (int int_CycleCount = 0; int_CycleCount != this.RegistryKeyPath.Count; int_CycleCount++)
        {
            CommonMethods.WriteIntToStream(memoryStream_DataToSend, (int)this.RegistryKeyPath[int_CycleCount]);
        }

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void CreateRegistryDWordValue()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 71);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.RegistryKeyFullName);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.NewRegistryValueName);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, (int)this.NewRegistryValue);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void CreateRegistryMultiStringValue()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 70);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.RegistryKeyFullName);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.NewRegistryValueName);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ((string[])this.NewRegistryValue).Length);

        for (int int_CycleCount = 0; int_CycleCount != ((string[])this.NewRegistryValue).Length; int_CycleCount++)
        {
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, ((string[])this.NewRegistryValue)[int_CycleCount]);
        }

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void CreateRegistryStringValue()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 66);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.RegistryKeyFullName);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.NewRegistryValueName);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, (string)this.NewRegistryValue);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void CreateNewRegistryKey()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 67);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.RegistryKeyFullName);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.RegistryKeyName);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void RenameRegistryValue()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 75);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.RegistryKeyFullName);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.RegistryValueName);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.NewRegistryValueName);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void DeleteRegistryValue()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 68);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.RegistryKeyFullName);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.RegistryValueName);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void ModifyRegistryValue()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 76);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.RegistryKeyFullName);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.RegistryValueName);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void DeleteRegistryKey()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 69);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.RegistryKeyFullName);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, this.RegistryKeyName);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void SetFileManagerObjectAttributes(string string_SelectedAttributes)
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 55);

        CommonMethods.WriteStringToStream(memoryStream_DataToSend, LastSelectedNameOfFolderOrFileWithPath);
        CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_SelectedAttributes);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void GetRemoteSystemInformationRootItemsCollection()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 72);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ClientSettingsEnvironment.CurrentLanguage);

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void GetSelectedRemoteSystemInformationItemSubNodes()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 73);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ClientSettingsEnvironment.CurrentLanguage);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, this.RemoteSystemInformationNodePath.Length);

        for (int int_CycleCount = 0; int_CycleCount != this.RemoteSystemInformationNodePath.Length; int_CycleCount++)
        {
            CommonMethods.WriteIntToStream(memoryStream_DataToSend, this.RemoteSystemInformationNodePath[int_CycleCount]);
        }

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }


    public void GetSelectedRemoteSystemInformationItemContent()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 74);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, ClientSettingsEnvironment.CurrentLanguage);

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, this.RemoteSystemInformationNodePath.Length);

        for (int int_CycleCount = 0; int_CycleCount != this.RemoteSystemInformationNodePath.Length; int_CycleCount++)
        {
            CommonMethods.WriteIntToStream(memoryStream_DataToSend, this.RemoteSystemInformationNodePath[int_CycleCount]);
        }

        this.CurrentlyUsedTcpClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }
}