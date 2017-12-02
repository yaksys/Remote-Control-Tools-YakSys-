using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;
using System.Data;
using System.Drawing.Imaging;
using System.Management;
using System.Management.Instrumentation;
using System.ComponentModel;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctClient;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;
using System.Runtime.InteropServices;
// comment

public class MainClientForm : System.Windows.Forms.Form
{
    #region MainClientForm controls declaration

    private System.Windows.Forms.TabControl tabControl_Main;
    private System.Windows.Forms.TabPage tabPage_NetworkControl;
    private System.Windows.Forms.TabPage tabPage_FileManager;
    private System.Windows.Forms.TabPage tabPage_RemoteExecution;
    private System.Windows.Forms.TabPage tabPage_ProcessesManager;
    private System.Windows.Forms.TabPage tabPage_ServicesManager;
    private System.Windows.Forms.TabPage tabPage_DriversList;
    private System.Windows.Forms.TabPage tabPage_SystemStateManager;
    private System.Windows.Forms.TabPage tabPage_DrivesManager;
    private System.Windows.Forms.ListView listView_FileManager_FileManager;
    private System.Windows.Forms.ColumnHeader columnHeader_FileManager_ItemName;
    private System.Windows.Forms.ColumnHeader columnHeader_FileManager_FileSize;
    private System.Windows.Forms.ColumnHeader columnHeader_FileManager_LastFileWriteTime;
    private System.Windows.Forms.ColumnHeader columnHeader_FileManager_ItemAttribute;
    private System.Windows.Forms.Label label_FileManager_LogicalDrives;
    private System.Windows.Forms.Button button_FileManager_DirUp;
    private System.Windows.Forms.Button button_FileManager_Refresh;
    private System.Windows.Forms.Button button_FileManager_Download;
    private System.Windows.Forms.Button button_FileManager_Upload;
    private System.Windows.Forms.Button button_FileManager_Delete;
    private System.Windows.Forms.Button button_FileManager_Rename;
    private System.Windows.Forms.Button button_FileManager_NewFolder;
    private System.Windows.Forms.Button button_FileManager_Execute;
    private System.Windows.Forms.GroupBox groupBox_RemoteExecution_ExecuteParameters;
    private System.Windows.Forms.Label label_RemoteExecution_FileNameWithPath;
    private System.Windows.Forms.Label label_RemoteExecution_WindowStyle;
    private System.Windows.Forms.Label label_RemoteExecution_WorkingFolder;
    private System.Windows.Forms.Label label_RemoteExecution_CommandLineArguments;
    private System.Windows.Forms.ComboBox comboBox_RemoteExecution_WindowStyle;
    private System.Windows.Forms.Button button_RemoteExecution_Execute;
    private System.Windows.Forms.CheckBox checkBox_RemoteExecution_ShowErrorDialog;
    private System.Windows.Forms.CheckBox checkBox_RemoteExecution_NotCreateWindow;
    private System.Windows.Forms.CheckBox checkBox_RemoteExecution_UseShellExecute;
    private System.Windows.Forms.TextBox textBox_RemoteExecution_WorkingFolder;
    private System.Windows.Forms.TextBox textBox_RemoteExecution_CommandLineArguments;
    private System.Windows.Forms.Splitter splitter_RemoteExecution_Remarks;
    private System.Windows.Forms.Label label_RemoteExecution_Remarks;
    private System.Windows.Forms.Label label_RemoteExecution_about5;
    private System.Windows.Forms.Label label_RemoteExecution_about4;
    private System.Windows.Forms.Label label_RemoteExecution_about3;
    private System.Windows.Forms.Label label_RemoteExecution_about2;
    private System.Windows.Forms.Label label_RemoteExecution_about1;
    private System.Windows.Forms.GroupBox groupBox_ProcessesManager_ProcessPriority;
    private System.Windows.Forms.ComboBox comboBox_ProcessesManager_ProcessPriority;
    private System.Windows.Forms.Label label_ProcessesManager_ProcessPriority;
    private System.Windows.Forms.ListView listView_ProcessesManager_Processes;
    private System.Windows.Forms.ColumnHeader columnHeader_ProcessesManager_ItemName;
    private System.Windows.Forms.ColumnHeader columnHeader_ProcessesManager_ProcessPriority;
    private System.Windows.Forms.ColumnHeader columnHeader_ProcessesManager_ThreadsAmount;
    private System.Windows.Forms.ColumnHeader columnHeader_ProcessesManager_PID;
    private System.Windows.Forms.ColumnHeader columnHeader_ProcessesManager_MainWindowTitle;
    private System.Windows.Forms.Button button_ProcessesManager_Refresh;
    private System.Windows.Forms.Button button_ProcessesManager_KillSelectedProcess;
    private System.Windows.Forms.ColumnHeader columnHeader_ServicesManager_ServiceDisplayName;
    private System.Windows.Forms.ColumnHeader columnHeader_ServicesManager_ServiceName;
    private System.Windows.Forms.ColumnHeader columnHeader_ServicesManager_ServiceStatus;
    private System.Windows.Forms.Button button_ServicesManager_StopService;
    private System.Windows.Forms.Button button_ServicesManager_PauseService;
    private System.Windows.Forms.Button button_ServicesManager_StartService;
    private System.Windows.Forms.Label label_ServicesManager_ServiceManagement;
    private System.Windows.Forms.Button button_ServicesManager_Refresh;
    private System.Windows.Forms.TabPage tabPage_Message;
    private System.Windows.Forms.Button button_DriversList_Refresh;
    private System.Windows.Forms.ListView listView_DriversList_DriversList;
    private System.Windows.Forms.ColumnHeader columnHeader_DriversList_DriverName;
    private System.Windows.Forms.ColumnHeader columnHeader_DriversList_Name;
    private System.Windows.Forms.ColumnHeader columnHeader_DriversList_DriverSatus;
    private System.Windows.Forms.ColumnHeader columnHeader_DriversList_DriverType;
    private System.Windows.Forms.Label label_Message_MessageText;
    private System.Windows.Forms.Label label_Message_MessageCaption;
    private System.Windows.Forms.TextBox textBox_Message_MessageText;
    private System.Windows.Forms.TextBox textBox_Message_MessageCaption;
    private System.Windows.Forms.CheckBox checkBox_Message_ReceiveUserChoice;
    private System.Windows.Forms.GroupBox groupBox_Message_IconSelect;
    private System.Windows.Forms.PictureBox pictureBox_Message_IconStop;
    private System.Windows.Forms.PictureBox pictureBox_Message_IconInformation;
    private System.Windows.Forms.PictureBox pictureBox_Message_IconWarning;
    private System.Windows.Forms.PictureBox pictureBox_Message_IconQuestion;
    private System.Windows.Forms.RadioButton radioButton_Message_IconNone;
    private System.Windows.Forms.RadioButton radioButton_Message_IconStop;
    private System.Windows.Forms.RadioButton radioButton_Message_IconWarning;
    private System.Windows.Forms.RadioButton radioButton_Message_IconQuestion;
    private System.Windows.Forms.RadioButton radioButton_Message_IconInformation;
    private System.Windows.Forms.Button button_Message_SendMessage;
    private System.Windows.Forms.GroupBox groupBox_Message_ButtonSelect;
    private System.Windows.Forms.RadioButton radioButton_Message_AbortRetryIgnore;
    private System.Windows.Forms.RadioButton radioButton_Message_radioButton_Message_YesNoCancel;
    private System.Windows.Forms.RadioButton radioButton_Message_RetryCancel;
    private System.Windows.Forms.RadioButton radioButton_Message_YesNo;
    private System.Windows.Forms.RadioButton radioButton_Message_OkCancel;
    private System.Windows.Forms.RadioButton radioButton_Message_Ok;
    private System.Windows.Forms.GroupBox groupBox_SystemStateManager_ChangeSystemState;
    private System.Windows.Forms.Button button_SystemStateManager_PowerOff;
    private System.Windows.Forms.CheckBox checkBox_SystemStateManager_ForceTerminateIfHung;
    private System.Windows.Forms.CheckBox checkBox_SystemStateManager_ForceTerminate;
    private System.Windows.Forms.Button button_SystemStateManager_ShutDown;
    private System.Windows.Forms.Button button_SystemStateManager_Restart;
    private System.Windows.Forms.Button button_SystemStateManager_UserLogOff;
    private System.Windows.Forms.GroupBox groupBox_SystemStateManager_ChangePowerState;
    private System.Windows.Forms.CheckBox checkBox_SystemStateManager_ForceImmediatelySuspend;
    private System.Windows.Forms.Label label_SystemStateManager_HibernateDescription;
    private System.Windows.Forms.Button button_SystemStateManager_Hiberate;
    private System.Windows.Forms.Button button_SystemStateManager_StandBy;
    private System.Windows.Forms.Splitter splitter_SystemStateManager_Remarks;
    private System.Windows.Forms.Label label_SystemStateManager_HibernateRemarks;
    private System.Windows.Forms.Label label_SystemStateManager_StandByRemarks;
    private System.Windows.Forms.Label label_SystemStateManager_Remarks;
    private System.Windows.Forms.Label label_SystemStateManager_ShutDownRemarks;
    private System.Windows.Forms.Label label_SystemStateManager_RestartRemarks;
    private System.Windows.Forms.Label label_SystemStateManager_PowerOffRemarks;
    private System.Windows.Forms.Label label_SystemStateManager_UserLogOffRemarks;
    private System.Windows.Forms.Button button_DrivesManager_EjectCD;
    private System.Windows.Forms.Button button_DrivesManager_CloseCD;
    private System.Windows.Forms.TextBox textBox_RemoteExecution_FileNameWithPath;
    private System.Windows.Forms.ComboBox comboBox_FileManager_LogicalDrives;
    private System.Windows.Forms.ColumnHeader columnHeader_ServicesManager_DisplayName;
    private System.Windows.Forms.ColumnHeader columnHeader_ServicesManager_name;
    private System.Windows.Forms.ColumnHeader columnHeader_ServicesManager_Status;
    private System.Windows.Forms.ColumnHeader columnHeader_ServicesManager_ServiceType;
    private System.Windows.Forms.ImageList imageList_ServicesManager;
    private System.Windows.Forms.ListView listView_ServicesManager_Services;
    private System.Windows.Forms.MainMenu mainMenu_Main;
    private System.Windows.Forms.MenuItem menuItem_File;
    private System.Windows.Forms.MenuItem menuItem_File_Exit;
    private System.Windows.Forms.MenuItem menuItem_Help;
    private System.Windows.Forms.TabPage tabPage_Display;
    private System.Windows.Forms.TabPage tabPage_SystemEvents;
    private System.Windows.Forms.ComboBox comboBox_SystemEvents_Logs;
    private System.Windows.Forms.Button button_SystemEvents_Refresh;
    private System.Windows.Forms.ListView listView_SystemEvents_Events;
    private System.Windows.Forms.ColumnHeader columnHeader_SystemEvents_EventType;
    private System.Windows.Forms.ColumnHeader columnHeader_SystemEvents_EventDate;
    private System.Windows.Forms.ColumnHeader columnHeader_SystemEvents_EventTime;
    private System.Windows.Forms.ColumnHeader columnHeader_SystemEvents_EventSource;
    private System.Windows.Forms.ColumnHeader columnHeader_SystemEvents_EventCategoty;
    private System.Windows.Forms.ColumnHeader columnHeader_SystemEvents_EventID;
    private System.Windows.Forms.ColumnHeader columnHeader_SystemEvents_User;
    private System.Windows.Forms.ColumnHeader columnHeader_SystemEvents_Computer;
    private System.Windows.Forms.ImageList imageList_SystemEvents;
    private System.Windows.Forms.TextBox textBox_SystemEvents_Information;
    private System.Windows.Forms.Button button_SystemEvents_DeleteLog;
    private System.Windows.Forms.Button button_SystemEvents_DeleteAllEvents;
    private System.Windows.Forms.Button button_SystemEvents_EventProperties;
    private System.Windows.Forms.TextBox textBox_FileManager_CurrentPath;
    private System.Windows.Forms.Label label_FileManager_CurrentFolder;
    private System.Windows.Forms.ImageList imageList_Drivers;
    private System.Windows.Forms.MenuItem menuItem_Options;
    private System.Windows.Forms.MenuItem menuItem_Options_Settings;
    private System.Windows.Forms.Button button_ProcessesManager_ActivateWindowOfSelectedProcess;
    private System.Windows.Forms.ColumnHeader columnHeader_ProcessesManager_MemoryUsage;
    private System.Windows.Forms.ColumnHeader columnHeader_DrivesManager_DriveLetter;
    private System.Windows.Forms.ColumnHeader columnHeader_DrivesManager_DriveType;
    private System.Windows.Forms.ColumnHeader columnHeader_DrivesManager_TotalSpace;
    private System.Windows.Forms.ColumnHeader columnHeader_DrivesManager_FreeSpace;
    private System.Windows.Forms.ColumnHeader columnHeader_DrivesManager_FileSystem;
    private System.Windows.Forms.ColumnHeader columnHeader_DrivesManager_FileSystem_SerialNumber;
    private System.Windows.Forms.ColumnHeader columnHeader_DrivesManager_FileSystem_VolumeName;
    private System.Windows.Forms.Button button_DrivesManager_Refresh;
    private System.Windows.Forms.ColumnHeader columnHeader_DrivesManager_FileSystem_maximumFileNameLength;
    private System.Windows.Forms.ListView listView_DrivesManager_DrivesInformation;
    private System.Windows.Forms.ImageList imageList_DrivesManager;
    private System.Windows.Forms.Label label_DrivesManager_AvailableInformation;
    private System.Windows.Forms.ListView listView_DrivesManager_AvailableDrives;
    private System.Windows.Forms.ColumnHeader columnHeader_DrivesManager_AvailableDrives;
    private System.Windows.Forms.Label label_SingleImageCapture_CurrentResolution;
    private System.Windows.Forms.Splitter splitter_NetworkControl_Remarks;
    private System.Windows.Forms.GroupBox groupBox_NetworkControl_ServersList;
    private System.Windows.Forms.Button button_ServersList_ClearList;
    private System.Windows.Forms.ListView listView_ServersList_ServersList;
    private System.Windows.Forms.TabPage tabPage_RTDV;
    private System.Windows.Forms.CheckBox checkBox_RTDV_AllowControl;
    private System.Windows.Forms.CheckBox checkBox_RTDV_RealSize;
    private System.Windows.Forms.Label label_RTDV_MaxUpdatePerSec;
    private System.Windows.Forms.NumericUpDown numericUpDown_RTDV_MaxUpdatePerSec;
    private System.Windows.Forms.CheckBox checkBox_RTDV_EnableRealTimeRemoteDisplayViewer;
    private System.Windows.Forms.ColumnHeader columnHeader_ProcessesManager_ProcessStatus;
    private System.Windows.Forms.MenuItem menuItem_Help_About;
    private System.Windows.Forms.MenuItem menuItem_Help_Register;
    private System.Windows.Forms.ContextMenu contextMenu_FileManager_Upload;
    private System.Windows.Forms.MenuItem menuItem_UploadFiles;
    private System.Windows.Forms.MenuItem menuItem_UploadFolders;
    private System.Windows.Forms.TrackBar trackBar_RTDV_ReceivedImageSize;
    private System.Windows.Forms.Label label_RTDV_ReceivedImageSize;
    private System.Windows.Forms.Label label_RTDV_SelectedImageSize;
    private System.Windows.Forms.ComboBox comboBox_RTDV_SizeMode;
    private System.Windows.Forms.Label label_RTDV_SizeMode;
    private System.Windows.Forms.GroupBox groupBox_RTDV_AdditionalParameters;
    private System.Windows.Forms.Button button_RTDV_GetRemoteClipboardData;
    private System.Windows.Forms.Button button_RTDV_SetRemoteClipboardData;
    private System.Windows.Forms.ContextMenu contextMenu_FileManager_ObjectProperties;
    private System.Windows.Forms.MenuItem menuItem_Properties;
    private System.Windows.Forms.Label label_ProxySettings_ProxyPort;
    private System.Windows.Forms.Label label_ProxySettings_ProxyHost;
    private System.Windows.Forms.TextBox textBox_ProxySettings_ProxyPort;
    private System.Windows.Forms.TextBox textBox_ProxySettings_ProxyHost;
    private System.Windows.Forms.GroupBox groupBox_NetworkControl_ProxySettings;
    private System.Windows.Forms.ComboBox comboBox_ProxySettings_ProxyTimeOut;
    private System.Windows.Forms.Label label_ProxySettings_ProxyTimeOut;
    private System.Windows.Forms.CheckBox checkBox_ProxySettings_Authentication;
    private System.Windows.Forms.Label label_ProxySettings_ProxyType;
    private System.Windows.Forms.CheckBox checkBox_ProxySettings_ResolveHostNames;
    private System.Windows.Forms.Label label_ProxySettings_Socks5UserName;
    private System.Windows.Forms.TextBox textBox_ProxySettings_Socks5Password;
    private System.Windows.Forms.TextBox textBox_ProxySettings_Socks5UserName;
    private System.Windows.Forms.Label label_ProxySettings_Socks5Password;
    private System.Windows.Forms.CheckBox checkBox_ProxySettings_UseProxy;
    private System.Windows.Forms.Button button_RTDV_SendKeys;
    private System.Windows.Forms.ContextMenu contextMenu_RTDV_SendKeys;
    private System.Windows.Forms.MenuItem menuItem_AltF12;
    private System.Windows.Forms.MenuItem menuItem_AltCtrlF12;
    private System.Windows.Forms.MenuItem menuItem_CtrlEsc;
    private System.Windows.Forms.MenuItem menuItem_F12;
    private System.Windows.Forms.MenuItem menuItem_TAB;
    private System.Windows.Forms.ImageList imageList_ProcessesList;
    private System.Windows.Forms.ImageList imageList_FileManager;
    private System.Windows.Forms.ImageList imageList_ServersList;
    private System.Windows.Forms.GroupBox groupBox_SystemStateManager_ChangeSecurityState;
    private System.Windows.Forms.Button button_SystemStateManager_LockWorkStation;
    private System.Windows.Forms.ListView listView_RemoteExecution_WorkingFolder_ListOfPresets;
    private System.Windows.Forms.ImageList imageList_FastLaunchPresets_SmallIcons;
    private System.Windows.Forms.ColumnHeader columnHeader_Preset;
    private System.Windows.Forms.Button button_RemoteExecution_CleanParameters;
    private System.Windows.Forms.Label label_SystemStateManager_LockWorkstationRemarks;
    private System.Windows.Forms.ImageList imageList_RTDV;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.ListBox listBox_ProxySettings_ProxyType;
    private System.Windows.Forms.Button button_ServersList_EditRecord;
    private System.Windows.Forms.Button button_ServersList_RemoveRecord;
    private System.Windows.Forms.Button button_ServersList_AddRecord;
    private System.Windows.Forms.Button button_ServersList_ViewRecord;
    private System.Windows.Forms.Button button_ProxyServersList_EditRecord;
    private System.Windows.Forms.Button button_ProxyServersList_ClearList;
    private System.Windows.Forms.Button button_ProxyServersList_RemoveRecord;
    private System.Windows.Forms.Button button_ProxyServersList_AddRecord;
    private System.Windows.Forms.Button button_ProxyServersList_ViewRecord;
    private System.Windows.Forms.GroupBox groupBox_NetworkControl_ProxyServersList;
    private System.Windows.Forms.ListView listView_ProxyServersList_ProxyServersList;
    private System.Windows.Forms.ColumnHeader columnHeader_ProxyServersList_Host;
    private System.Windows.Forms.ColumnHeader columnHeader_ProxyServersList_Port;
    private System.Windows.Forms.ColumnHeader columnHeader_ProxyServersList_Title;
    private System.Windows.Forms.ColumnHeader columnHeader_NetworkControl_Host;
    private System.Windows.Forms.ColumnHeader columnHeader_NetworkControl_Port;
    private System.Windows.Forms.Button button_ProxyServersList_Use;
    private System.Windows.Forms.Button button_ServersList_Use;
    private System.Windows.Forms.ComboBox comboBox_ServersList_ServersGroups;
    private System.Windows.Forms.Label label_ServersList_GroupSelection;
    private System.Windows.Forms.Button button_FileManager_Properties;
    private System.Windows.Forms.ColumnHeader columnHeader_NetworkControl_ServerName;
    private System.Windows.Forms.ColumnHeader columnHeader_NetworkControl_ServerLocation;
    private System.Windows.Forms.ColumnHeader columnHeader_NetworkControl_GroupMember;
    private System.Windows.Forms.GroupBox groupBox_SingleImageCapture;
    private System.Windows.Forms.Label label_SingleImageCapture_ImageQuality;
    private System.Windows.Forms.Label label_SingleImageCapture_CompressionFormat;
    private System.Windows.Forms.ComboBox comboBox_SingleImageCapture_ImageFormat;
    private System.Windows.Forms.RadioButton radioButton_SingleImageCapture_OnlySave;
    private System.Windows.Forms.RadioButton radioButton_SingleImageCapture_SaveAndShow;
    private System.Windows.Forms.Label label_SingleImageCapture_ImageFormat;
    private System.Windows.Forms.Button button_SingleImageCapture_CaptureImage;
    private System.Windows.Forms.TrackBar trackBar_SingleImageCapture_ImageQuality;
    private System.Windows.Forms.ComboBox comboBox_SingleImageCapture_CompressionFormat;
    private System.Windows.Forms.GroupBox groupBox_DisplaySettings_DisplaySettings;
    private System.Windows.Forms.Label label_DisplaySettings_MoreResolution;
    private System.Windows.Forms.Label label_DisplaySettings_LessResolution;
    private System.Windows.Forms.TrackBar trackBar_DisplaySettings_Resolution;
    private System.Windows.Forms.Button button_DisplaySettings_SetDisplaySettings;
    private System.Windows.Forms.Button button_DisplaySettings_GetDisplaySettings;
    private System.Windows.Forms.Label label_DisplaySettings_ScreenRefreshRate;
    private System.Windows.Forms.Label label_DisplaySettings_ColorQuality;
    private System.Windows.Forms.ComboBox comboBox_DisplaySettings_ColorQuality;
    private System.Windows.Forms.ComboBox comboBox_DisplaySettings_ScreenRefreshRate;
    private System.Windows.Forms.GroupBox groupBox_CaptureInInterval;
    private System.Windows.Forms.ComboBox comboBox_CaptureInInterval_CompressionFormat;
    private System.Windows.Forms.Label label_CaptureInInterval_CompressionFormat;
    private System.Windows.Forms.Label label_CaptureInInterval_ImageQuality;
    private System.Windows.Forms.TrackBar trackBar_CaptureInInterval_ImageQuality;
    private System.Windows.Forms.RadioButton radioButton_CaptureInInterval_OnlySave;
    private System.Windows.Forms.RadioButton radioButton_CaptureInInterval_SaveAndShow;
    private System.Windows.Forms.Label label_CaptureInInterval_ImageFormat;
    private System.Windows.Forms.Label label_CaptureInInterval_InetrvalSettings;
    private System.Windows.Forms.Button button_CaptureInInterval_StartCapture;
    private System.Windows.Forms.Button button_CaptureInInterval_StopCapture;
    private System.Windows.Forms.ComboBox comboBox_CaptureInInterval_ImageFormat;
    private System.Windows.Forms.ComboBox comboBox_CaptureInInterval_InetrvalSettings;
    private System.Windows.Forms.MenuItem menuItem_File_Import;
    private System.Windows.Forms.MenuItem menuItem_File_Export;
    private System.Windows.Forms.MenuItem menuItem_File_Import_SettingsDatabase;
    private System.Windows.Forms.MenuItem menuItem_File_Export_SettingsDatabase;
    private System.Windows.Forms.TabPage tabPage_InstalledPrograms;
    private System.Windows.Forms.Button button_InstalledPrograms_Refresh;
    private System.Windows.Forms.ListView listView_InstalledPrograms_ProgramsList;
    private System.Windows.Forms.ColumnHeader columnHeader_InstalledPrograms_ProgramName;
    private System.Windows.Forms.ColumnHeader columnHeader_InstalledPrograms_ProgramVersion;
    private System.Windows.Forms.ColumnHeader columnHeader_InstalledPrograms_ProgramPublisher;
    private System.Windows.Forms.ColumnHeader columnHeader_InstalledPrograms_InstallDate;
    private System.Windows.Forms.ColumnHeader columnHeader_InstalledPrograms_InstallLocation;
    private System.Windows.Forms.ImageList imageList_InstalledPrograms;
    private System.Windows.Forms.CheckBox checkBox_RTDV_ShowRemoteCursor;
    private System.Windows.Forms.CheckBox checkBox_RTDV_HideMyCursor;
    private System.Windows.Forms.TabPage tabPage_InstalledUpdates;
    private System.Windows.Forms.Button button_InstalledUpdates_Refresh;
    private System.Windows.Forms.ListView listView_InstalledUpdates_UpdatesList;
    private System.Windows.Forms.ColumnHeader columnHeader_InstalledUpdates_UpdateDescription;
    private System.Windows.Forms.ColumnHeader columnHeader_InstalledUpdates_InstalledBy;
    private System.Windows.Forms.ColumnHeader columnHeader_InstalledUpdates_InstallDate;
    private System.Windows.Forms.ImageList imageList_InstalledUpdates;
    private System.Windows.Forms.TabPage tabPage_RemoteRegistry;
    private System.Windows.Forms.ListView listView_RemoteRegistry_Values;
    private System.Windows.Forms.Button button_RemoteRegistry_Refresh;
    private System.Windows.Forms.ImageList imageList_RemoteRegistry;
    private System.Windows.Forms.TreeView treeView_RemoteRegistry_NodesTree;
    private System.Windows.Forms.ColumnHeader columnHeader_RemoteRegistryValues_ValueName;
    private System.Windows.Forms.ColumnHeader columnHeader_RemoteRegistryValues_ValueType;
    private System.Windows.Forms.ColumnHeader columnHeader_RemoteRegistryValues_ValueData;
    private System.Windows.Forms.Label label_RemoteRegistry_CurrentPath;
    private System.Windows.Forms.TextBox textBox_RemoteRegistry_CurrentPath;
    private System.Windows.Forms.Button button_RemoteRegistry_Modify;
    private System.Windows.Forms.Button button_RemoteRegistry_Expand;
    private System.Windows.Forms.Button button_RemoteRegistry_RenameItem;
    private System.Windows.Forms.Button button_RemoteRegistry_CreateValue;
    private System.Windows.Forms.Button button_RemoteRegistry_CreateKey;
    private System.Windows.Forms.Button button_RemoteRegistry_Delete;
    private System.Windows.Forms.ContextMenu contextMenu_RemoteRegistry_NewValue;
    private System.Windows.Forms.ContextMenu contextMenu_RemoteRegistry_KeysContextMenu;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistry_ToggleKeyState;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistry_NewItem;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistry_DeleteKey;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistry_CopyKeyName;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistry_NewItem_Key;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistry_NewItem_String;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistry_NewItem_MultiString;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistry_NewItem_DWORD;
    private System.Windows.Forms.ContextMenu contextMenu_RemoteRegistry_ValuesContextMenu;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistryValuesContextMenu_NewItem;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistryValuesContextMenu_New_Key;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistryValuesContextMenu_New_String;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistryValuesContextMenu_New_MultiString;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistryValuesContextMenu_New_DWORD;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistryValuesContextMenu_New_Binary;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistry_NewValue_String;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistry_NewValue_MultiString;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistry_NewValue_DWORD;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistry_NewValue_Binary;
    private System.Windows.Forms.ContextMenu contextMenu_RemoteRegistry_ValueActions;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistryValueActions_Modify;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistryValueActions_Rename;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistryValueActions_Delete;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistry_NewItem_Separator1;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistryValuesContextMenu_New_Separator1;
    private System.Windows.Forms.MenuItem menuItem_RemoteRegistryValueActions_Separaton1;
    private System.Windows.Forms.Button button_ServersList_Refresh;
    private System.Windows.Forms.TabPage tabPage_RemoteSystemInformation;
    private System.Windows.Forms.GroupBox groupBox_RemoteSystemInformation_AvailableItems;
    private System.Windows.Forms.TextBox textBox_RemoteSystemInformation_AvailableItems_CurrentStatus;
    private System.Windows.Forms.Button button_RemoteSystemInformation_AvailableItems_Refresh;
    private System.Windows.Forms.TreeView treeView_RemoteSystemInformation_AvailableItems_AvailableItems;
    private System.Windows.Forms.Label label_RemoteSystemInformation_AvailableItems_AvailableItems;
    private System.Windows.Forms.Label label_RemoteSystemInformation_AvailableItems_CurrentStatus;
    private System.Windows.Forms.GroupBox groupBox_RemoteSystemInformation_AvailableInformation;
    private System.Windows.Forms.Label label_RemoteSystemInformation_AvailableInformation_CurrentItem;
    private System.Windows.Forms.Button button_RemoteSystemInformation_AvailableInformation_Refresh;
    private System.Windows.Forms.Label label_RemoteSystemInformation_AvailableInformation_AvailableInformation;
    private System.Windows.Forms.ListView listView_RemoteSystemInformation_AvailableInformation_AvailableInformation;
    private System.Windows.Forms.TextBox textBox_RemoteSystemInformation_AvailableInformation_CurrentItem;
    private System.Windows.Forms.ColumnHeader columnHeader_RemoteSystemInformation_Parameter;
    private System.Windows.Forms.ColumnHeader columnHeader_RemoteSystemInformation_Value;
    private System.Windows.Forms.StatusBar statusBar_Main;
    private System.Windows.Forms.StatusBarPanel statusBarPanel_BytesSent;
    private System.Windows.Forms.StatusBarPanel statusBarPanel_BytesReceived;
    private System.Windows.Forms.StatusBarPanel statusBarPanel_CompletedTasksOfTransfers;
    private System.Windows.Forms.StatusBarPanel statusBarPanel_LastConnectionTime;
    private System.Windows.Forms.TrackBar trackBar_RTDV_ImageCodingAlgorithm;
    private System.Windows.Forms.Label label_RTDV_MoreCPUUsage;
    private System.Windows.Forms.Label label_RTDV_MoreBandwidth;
    private Label label_RTDV_DataFormat;
    private ColumnHeader columnHeader_FileManager_ItemType;
    private ComboBox comboBox_RTDV_AmountOfRegions;
    private Label label_RTDV_NumberOfRegions;
    private Button button_RemoteSystemInformation_AvailableInformation_CopyItemInfoToClipboard;
    private SplitContainer splitContainer_RemoteRegistry_MainSplit;
    private TabPage tabPage_ClipboardManager;
    private GroupBox groupBox_ClipboardManager_FileDropList;
    private GroupBox groupBox_ClipboardManager_Image;
    private GroupBox groupBox2;
    private TextBox textBox_ClipboardManager_RemoteClipboardType;
    private Label label_ClipboardManager_RemoteClipboardType;
    private TextBox textBox_ClipboardManager_LocalClipboardType;
    private Label label_ClipboardManager_LocalClipboardType;
    private Button button_ClipboardManager_ClearLocalClipboard;
    private Button button_ClipboardManager_ClearRemoteClipboard;
    private Button button_ClipboardManager_Local2RemoteSync;
    private Button button_ClipboardManager_Remote2LocalSync;
    private Button button_ClipboardManager_PreviewLocalClipboard;
    private GroupBox groupBox_ClipboardManager_TextData;
    private Button button_ClipboardManager_PreviewRemoteClipboard;
    private RichTextBox richTextBox_ClipboardManager_TextData;
    private PictureBox pictureBox_ClipboardManager_Image;
    private ListView listView_ClipboardManager_FileDropList;
    private Label label_RemoteClipboardImageSettings_ImageQuality;
    private Label label_RemoteClipboardImageSettings_CompressionFormat;
    private ComboBox comboBox_RemoteClipboardImageSettings_ImageFormat;
    private Label label_RemoteClipboardImageSettings_ImageFormat;
    private TrackBar trackBar_RemoteClipboardImageSettings_ImageQuality;
    private ComboBox comboBox_RemoteClipboardImageSettings_CompressionFormat;
    private GroupBox groupBox_ClipboardManager_ClipboardImageSettings;
    private ComboBox comboBox_RemoteClipboardImageSettings_PreviewSizeMode;
    private Label label_RemoteClipboardImageSettings_PreviewSizeMode;
    private GroupBox groupBox_ClipboardManager_AddClipboardImageSettings;
    private Button button_RemoteClipboardImageEnv_SendImage;
    private Button button_RemoteClipboardImageEnv_SaveImageToDisk;
    private Button button_ClipboardManager_RefreshClipboardsTypeInfo;
    private ComboBox comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval;
    private Label label_ClipboardManager_RefreshClipboardsTypeInfoInterval;
    private ColumnHeader columnHeader_ClipboardManager_Item;
    private CheckBox checkBox_ClipboardManager_ShowWarnings;
    private GroupBox groupBox_NetworkControl_Security;
    private Label label_NetworkControl_Password;
    private Label label_NetworkControl_Login;
    private TextBox textBox_NetworkControl_Password;
    private TextBox textBox_NetworkControl_Login;
    private GroupBox groupBox_NetworkControl_MainNetworkControl;
    private Label label_NetworkControl_ConnectionTimeOut;
    private ComboBox comboBox_NetworkControl_ConnectionTimeOut;
    private Button button_NetworkControl_ConnectingService;
    private Label label_NetworkControl_ConnectionStatus;
    private Label label_NetworkControl_Port;
    private Label label_NetworkControl_IP;
    private TextBox textBox_NetworkControl_ConnectionStatus;
    private TextBox textBox_NetworkControl_Port;
    private TextBox textBox_NetworkControl_IP;
    private Button button_NetworkControl_Connect;
    private Button button_NetworkControl_Disconnect;
    private TabPage tabPage_Camera;
    private GroupBox groupBox9;
    private Label label26;
    private RadioButton radioButton9;
    private RadioButton radioButton10;
    private Button button12;
    private TrackBar trackBar7;
    private GroupBox groupBox10;
    private ComboBox comboBox18;
    private Label label29;
    private Label label30;
    private TrackBar trackBar8;
    private RadioButton radioButton11;
    private RadioButton radioButton12;
    private Label label31;
    private Label label32;
    private ComboBox comboBox19;
    private Button button13;
    private Button button14;
    private ComboBox comboBox20;
    private GroupBox groupBox1;
    private PictureBox pictureBox1;
    private Label label33;
    private ComboBox comboBox21;
    private Label label2;
    private ComboBox comboBox1;
    private GroupBox groupBox3;
    private Button button2;
    private Button button3;
    private Label label1;
    private Label label3;
    private ComboBox comboBox2;
    private ComboBox comboBox3;
    private TrackBar trackBar1;
    private Label label4;
    private Label label5;
    private Label label6;
    private GroupBox groupBox4;
    private Label label7;
    private Label label8;
    private ComboBox comboBox4;
    private RadioButton radioButton1;
    private RadioButton radioButton2;
    private Label label9;
    private Button button4;
    private TrackBar trackBar2;
    private ComboBox comboBox5;
    private GroupBox groupBox5;
    private ComboBox comboBox6;
    private Label label10;
    private Label label11;
    private TrackBar trackBar3;
    private RadioButton radioButton3;
    private RadioButton radioButton4;
    private Label label12;
    private Label label13;
    private ComboBox comboBox7;
    private Button button5;
    private Button button6;
    private ComboBox comboBox8;
    private GroupBox groupBox6;
    private Button button7;
    private Button button8;
    private Label label14;
    private Label label15;
    private ComboBox comboBox9;
    private ComboBox comboBox10;
    private TrackBar trackBar4;
    private Label label16;
    private Label label17;
    private Label label18;
    private GroupBox groupBox7;
    private Label label19;
    private Label label20;
    private ComboBox comboBox11;
    private RadioButton radioButton5;
    private RadioButton radioButton6;
    private Label label21;
    private Button button9;
    private TrackBar trackBar5;
    private ComboBox comboBox12;
    private GroupBox groupBox8;
    private ComboBox comboBox13;
    private Label label22;
    private Label label23;
    private TrackBar trackBar6;
    private RadioButton radioButton7;
    private RadioButton radioButton8;
    private Label label24;
    private Label label25;
    private ComboBox comboBox14;
    private Button button10;
    private Button button11;
    private ComboBox comboBox15;
    private ComboBox comboBox16;
    private Label label27;
    private Label label28;
    private ComboBox comboBox17;
    private Button button1;
    private CheckBox checkBox2;
    private CheckBox checkBox1;
    private CheckBox checkBox3;
    private Button button16;
    private Button button15;
    private CheckBox checkBox_CameraTab_EnableCamera;
    private System.Windows.Forms.Timer timer_MainFormTimer;
    private System.ComponentModel.IContainer components;

    #endregion

    #region Windows Form Designer generated code for InitializeComponent and Dispose methods

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("HKEY_CLASSES_ROOT");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("HKEY_CURRENT_USER");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("HKEY_LOCAL_MACHINE");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("HKEY_USERS");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("HKEY_CURRENT_CONFIG");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainClientForm));
            this.splitContainer_RemoteRegistry_MainSplit = new System.Windows.Forms.SplitContainer();
            this.treeView_RemoteRegistry_NodesTree = new System.Windows.Forms.TreeView();
            this.imageList_RemoteRegistry = new System.Windows.Forms.ImageList(this.components);
            this.listView_RemoteRegistry_Values = new System.Windows.Forms.ListView();
            this.columnHeader_RemoteRegistryValues_ValueName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_RemoteRegistryValues_ValueType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_RemoteRegistryValues_ValueData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_NetworkControl = new System.Windows.Forms.TabPage();
            this.groupBox_NetworkControl_Security = new System.Windows.Forms.GroupBox();
            this.label_NetworkControl_Password = new System.Windows.Forms.Label();
            this.label_NetworkControl_Login = new System.Windows.Forms.Label();
            this.textBox_NetworkControl_Password = new System.Windows.Forms.TextBox();
            this.textBox_NetworkControl_Login = new System.Windows.Forms.TextBox();
            this.groupBox_NetworkControl_ProxySettings = new System.Windows.Forms.GroupBox();
            this.label_ProxySettings_ProxyType = new System.Windows.Forms.Label();
            this.checkBox_ProxySettings_ResolveHostNames = new System.Windows.Forms.CheckBox();
            this.checkBox_ProxySettings_Authentication = new System.Windows.Forms.CheckBox();
            this.label_ProxySettings_ProxyTimeOut = new System.Windows.Forms.Label();
            this.comboBox_ProxySettings_ProxyTimeOut = new System.Windows.Forms.ComboBox();
            this.label_ProxySettings_ProxyPort = new System.Windows.Forms.Label();
            this.label_ProxySettings_ProxyHost = new System.Windows.Forms.Label();
            this.textBox_ProxySettings_ProxyPort = new System.Windows.Forms.TextBox();
            this.textBox_ProxySettings_ProxyHost = new System.Windows.Forms.TextBox();
            this.label_ProxySettings_Socks5Password = new System.Windows.Forms.Label();
            this.label_ProxySettings_Socks5UserName = new System.Windows.Forms.Label();
            this.textBox_ProxySettings_Socks5Password = new System.Windows.Forms.TextBox();
            this.textBox_ProxySettings_Socks5UserName = new System.Windows.Forms.TextBox();
            this.listBox_ProxySettings_ProxyType = new System.Windows.Forms.ListBox();
            this.checkBox_ProxySettings_UseProxy = new System.Windows.Forms.CheckBox();
            this.groupBox_NetworkControl_MainNetworkControl = new System.Windows.Forms.GroupBox();
            this.label_NetworkControl_ConnectionTimeOut = new System.Windows.Forms.Label();
            this.comboBox_NetworkControl_ConnectionTimeOut = new System.Windows.Forms.ComboBox();
            this.button_NetworkControl_ConnectingService = new System.Windows.Forms.Button();
            this.label_NetworkControl_ConnectionStatus = new System.Windows.Forms.Label();
            this.label_NetworkControl_Port = new System.Windows.Forms.Label();
            this.label_NetworkControl_IP = new System.Windows.Forms.Label();
            this.textBox_NetworkControl_ConnectionStatus = new System.Windows.Forms.TextBox();
            this.textBox_NetworkControl_Port = new System.Windows.Forms.TextBox();
            this.textBox_NetworkControl_IP = new System.Windows.Forms.TextBox();
            this.button_NetworkControl_Connect = new System.Windows.Forms.Button();
            this.button_NetworkControl_Disconnect = new System.Windows.Forms.Button();
            this.splitter_NetworkControl_Remarks = new System.Windows.Forms.Splitter();
            this.groupBox_NetworkControl_ServersList = new System.Windows.Forms.GroupBox();
            this.button_ServersList_Refresh = new System.Windows.Forms.Button();
            this.label_ServersList_GroupSelection = new System.Windows.Forms.Label();
            this.comboBox_ServersList_ServersGroups = new System.Windows.Forms.ComboBox();
            this.button_ServersList_Use = new System.Windows.Forms.Button();
            this.button_ServersList_ViewRecord = new System.Windows.Forms.Button();
            this.button_ServersList_ClearList = new System.Windows.Forms.Button();
            this.listView_ServersList_ServersList = new System.Windows.Forms.ListView();
            this.columnHeader_NetworkControl_ServerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_NetworkControl_Host = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_NetworkControl_Port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_NetworkControl_ServerLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_NetworkControl_GroupMember = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_ServersList = new System.Windows.Forms.ImageList(this.components);
            this.button_ServersList_AddRecord = new System.Windows.Forms.Button();
            this.button_ServersList_RemoveRecord = new System.Windows.Forms.Button();
            this.button_ServersList_EditRecord = new System.Windows.Forms.Button();
            this.groupBox_NetworkControl_ProxyServersList = new System.Windows.Forms.GroupBox();
            this.button_ProxyServersList_Use = new System.Windows.Forms.Button();
            this.button_ProxyServersList_EditRecord = new System.Windows.Forms.Button();
            this.button_ProxyServersList_ClearList = new System.Windows.Forms.Button();
            this.button_ProxyServersList_AddRecord = new System.Windows.Forms.Button();
            this.listView_ProxyServersList_ProxyServersList = new System.Windows.Forms.ListView();
            this.columnHeader_ProxyServersList_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ProxyServersList_Host = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ProxyServersList_Port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_ProxyServersList_RemoveRecord = new System.Windows.Forms.Button();
            this.button_ProxyServersList_ViewRecord = new System.Windows.Forms.Button();
            this.tabPage_FileManager = new System.Windows.Forms.TabPage();
            this.button_FileManager_Properties = new System.Windows.Forms.Button();
            this.label_FileManager_CurrentFolder = new System.Windows.Forms.Label();
            this.textBox_FileManager_CurrentPath = new System.Windows.Forms.TextBox();
            this.button_FileManager_Execute = new System.Windows.Forms.Button();
            this.button_FileManager_NewFolder = new System.Windows.Forms.Button();
            this.button_FileManager_Rename = new System.Windows.Forms.Button();
            this.button_FileManager_Delete = new System.Windows.Forms.Button();
            this.button_FileManager_Upload = new System.Windows.Forms.Button();
            this.button_FileManager_Download = new System.Windows.Forms.Button();
            this.button_FileManager_Refresh = new System.Windows.Forms.Button();
            this.button_FileManager_DirUp = new System.Windows.Forms.Button();
            this.label_FileManager_LogicalDrives = new System.Windows.Forms.Label();
            this.comboBox_FileManager_LogicalDrives = new System.Windows.Forms.ComboBox();
            this.listView_FileManager_FileManager = new System.Windows.Forms.ListView();
            this.columnHeader_FileManager_ItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_FileManager_FileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_FileManager_LastFileWriteTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_FileManager_ItemAttribute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_FileManager_ItemType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenu_FileManager_ObjectProperties = new System.Windows.Forms.ContextMenu();
            this.menuItem_Properties = new System.Windows.Forms.MenuItem();
            this.imageList_FileManager = new System.Windows.Forms.ImageList(this.components);
            this.tabPage_RemoteExecution = new System.Windows.Forms.TabPage();
            this.label_RemoteExecution_Remarks = new System.Windows.Forms.Label();
            this.label_RemoteExecution_about5 = new System.Windows.Forms.Label();
            this.label_RemoteExecution_about4 = new System.Windows.Forms.Label();
            this.label_RemoteExecution_about3 = new System.Windows.Forms.Label();
            this.label_RemoteExecution_about2 = new System.Windows.Forms.Label();
            this.label_RemoteExecution_about1 = new System.Windows.Forms.Label();
            this.splitter_RemoteExecution_Remarks = new System.Windows.Forms.Splitter();
            this.groupBox_RemoteExecution_ExecuteParameters = new System.Windows.Forms.GroupBox();
            this.button_RemoteExecution_CleanParameters = new System.Windows.Forms.Button();
            this.listView_RemoteExecution_WorkingFolder_ListOfPresets = new System.Windows.Forms.ListView();
            this.columnHeader_Preset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_FastLaunchPresets_SmallIcons = new System.Windows.Forms.ImageList(this.components);
            this.label_RemoteExecution_WindowStyle = new System.Windows.Forms.Label();
            this.label_RemoteExecution_WorkingFolder = new System.Windows.Forms.Label();
            this.label_RemoteExecution_CommandLineArguments = new System.Windows.Forms.Label();
            this.label_RemoteExecution_FileNameWithPath = new System.Windows.Forms.Label();
            this.comboBox_RemoteExecution_WindowStyle = new System.Windows.Forms.ComboBox();
            this.checkBox_RemoteExecution_ShowErrorDialog = new System.Windows.Forms.CheckBox();
            this.checkBox_RemoteExecution_NotCreateWindow = new System.Windows.Forms.CheckBox();
            this.checkBox_RemoteExecution_UseShellExecute = new System.Windows.Forms.CheckBox();
            this.textBox_RemoteExecution_WorkingFolder = new System.Windows.Forms.TextBox();
            this.textBox_RemoteExecution_CommandLineArguments = new System.Windows.Forms.TextBox();
            this.textBox_RemoteExecution_FileNameWithPath = new System.Windows.Forms.TextBox();
            this.button_RemoteExecution_Execute = new System.Windows.Forms.Button();
            this.tabPage_ProcessesManager = new System.Windows.Forms.TabPage();
            this.button_ProcessesManager_ActivateWindowOfSelectedProcess = new System.Windows.Forms.Button();
            this.button_ProcessesManager_Refresh = new System.Windows.Forms.Button();
            this.button_ProcessesManager_KillSelectedProcess = new System.Windows.Forms.Button();
            this.listView_ProcessesManager_Processes = new System.Windows.Forms.ListView();
            this.columnHeader_ProcessesManager_ItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ProcessesManager_ProcessPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ProcessesManager_ThreadsAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ProcessesManager_PID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ProcessesManager_ProcessStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ProcessesManager_MemoryUsage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ProcessesManager_MainWindowTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_ProcessesList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox_ProcessesManager_ProcessPriority = new System.Windows.Forms.GroupBox();
            this.comboBox_ProcessesManager_ProcessPriority = new System.Windows.Forms.ComboBox();
            this.label_ProcessesManager_ProcessPriority = new System.Windows.Forms.Label();
            this.tabPage_DrivesManager = new System.Windows.Forms.TabPage();
            this.listView_DrivesManager_AvailableDrives = new System.Windows.Forms.ListView();
            this.columnHeader_DrivesManager_AvailableDrives = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_DrivesManager_AvailableInformation = new System.Windows.Forms.Label();
            this.button_DrivesManager_Refresh = new System.Windows.Forms.Button();
            this.listView_DrivesManager_DrivesInformation = new System.Windows.Forms.ListView();
            this.columnHeader_DrivesManager_DriveLetter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_DrivesManager_DriveType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_DrivesManager_TotalSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_DrivesManager_FreeSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_DrivesManager_FileSystem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_DrivesManager_FileSystem_SerialNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_DrivesManager_FileSystem_VolumeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_DrivesManager_FileSystem_maximumFileNameLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_DrivesManager = new System.Windows.Forms.ImageList(this.components);
            this.button_DrivesManager_EjectCD = new System.Windows.Forms.Button();
            this.button_DrivesManager_CloseCD = new System.Windows.Forms.Button();
            this.tabPage_RemoteRegistry = new System.Windows.Forms.TabPage();
            this.label_RemoteRegistry_CurrentPath = new System.Windows.Forms.Label();
            this.textBox_RemoteRegistry_CurrentPath = new System.Windows.Forms.TextBox();
            this.button_RemoteRegistry_Modify = new System.Windows.Forms.Button();
            this.button_RemoteRegistry_Expand = new System.Windows.Forms.Button();
            this.button_RemoteRegistry_RenameItem = new System.Windows.Forms.Button();
            this.button_RemoteRegistry_Delete = new System.Windows.Forms.Button();
            this.button_RemoteRegistry_CreateValue = new System.Windows.Forms.Button();
            this.button_RemoteRegistry_CreateKey = new System.Windows.Forms.Button();
            this.button_RemoteRegistry_Refresh = new System.Windows.Forms.Button();
            this.tabPage_Display = new System.Windows.Forms.TabPage();
            this.groupBox_DisplaySettings_DisplaySettings = new System.Windows.Forms.GroupBox();
            this.button_DisplaySettings_SetDisplaySettings = new System.Windows.Forms.Button();
            this.button_DisplaySettings_GetDisplaySettings = new System.Windows.Forms.Button();
            this.label_DisplaySettings_ScreenRefreshRate = new System.Windows.Forms.Label();
            this.label_DisplaySettings_ColorQuality = new System.Windows.Forms.Label();
            this.comboBox_DisplaySettings_ColorQuality = new System.Windows.Forms.ComboBox();
            this.comboBox_DisplaySettings_ScreenRefreshRate = new System.Windows.Forms.ComboBox();
            this.trackBar_DisplaySettings_Resolution = new System.Windows.Forms.TrackBar();
            this.label_SingleImageCapture_CurrentResolution = new System.Windows.Forms.Label();
            this.label_DisplaySettings_MoreResolution = new System.Windows.Forms.Label();
            this.label_DisplaySettings_LessResolution = new System.Windows.Forms.Label();
            this.groupBox_SingleImageCapture = new System.Windows.Forms.GroupBox();
            this.label_SingleImageCapture_ImageQuality = new System.Windows.Forms.Label();
            this.label_SingleImageCapture_CompressionFormat = new System.Windows.Forms.Label();
            this.comboBox_SingleImageCapture_ImageFormat = new System.Windows.Forms.ComboBox();
            this.radioButton_SingleImageCapture_OnlySave = new System.Windows.Forms.RadioButton();
            this.radioButton_SingleImageCapture_SaveAndShow = new System.Windows.Forms.RadioButton();
            this.label_SingleImageCapture_ImageFormat = new System.Windows.Forms.Label();
            this.button_SingleImageCapture_CaptureImage = new System.Windows.Forms.Button();
            this.trackBar_SingleImageCapture_ImageQuality = new System.Windows.Forms.TrackBar();
            this.comboBox_SingleImageCapture_CompressionFormat = new System.Windows.Forms.ComboBox();
            this.groupBox_CaptureInInterval = new System.Windows.Forms.GroupBox();
            this.comboBox_CaptureInInterval_CompressionFormat = new System.Windows.Forms.ComboBox();
            this.label_CaptureInInterval_CompressionFormat = new System.Windows.Forms.Label();
            this.label_CaptureInInterval_ImageQuality = new System.Windows.Forms.Label();
            this.trackBar_CaptureInInterval_ImageQuality = new System.Windows.Forms.TrackBar();
            this.radioButton_CaptureInInterval_OnlySave = new System.Windows.Forms.RadioButton();
            this.radioButton_CaptureInInterval_SaveAndShow = new System.Windows.Forms.RadioButton();
            this.label_CaptureInInterval_ImageFormat = new System.Windows.Forms.Label();
            this.label_CaptureInInterval_InetrvalSettings = new System.Windows.Forms.Label();
            this.comboBox_CaptureInInterval_InetrvalSettings = new System.Windows.Forms.ComboBox();
            this.button_CaptureInInterval_StartCapture = new System.Windows.Forms.Button();
            this.button_CaptureInInterval_StopCapture = new System.Windows.Forms.Button();
            this.comboBox_CaptureInInterval_ImageFormat = new System.Windows.Forms.ComboBox();
            this.tabPage_RTDV = new System.Windows.Forms.TabPage();
            this.comboBox_RTDV_AmountOfRegions = new System.Windows.Forms.ComboBox();
            this.label_RTDV_NumberOfRegions = new System.Windows.Forms.Label();
            this.label_RTDV_DataFormat = new System.Windows.Forms.Label();
            this.label_RTDV_MoreBandwidth = new System.Windows.Forms.Label();
            this.label_RTDV_MoreCPUUsage = new System.Windows.Forms.Label();
            this.trackBar_RTDV_ImageCodingAlgorithm = new System.Windows.Forms.TrackBar();
            this.checkBox_RTDV_HideMyCursor = new System.Windows.Forms.CheckBox();
            this.checkBox_RTDV_ShowRemoteCursor = new System.Windows.Forms.CheckBox();
            this.button_RTDV_SendKeys = new System.Windows.Forms.Button();
            this.button_RTDV_SetRemoteClipboardData = new System.Windows.Forms.Button();
            this.button_RTDV_GetRemoteClipboardData = new System.Windows.Forms.Button();
            this.groupBox_RTDV_AdditionalParameters = new System.Windows.Forms.GroupBox();
            this.label_RTDV_SizeMode = new System.Windows.Forms.Label();
            this.comboBox_RTDV_SizeMode = new System.Windows.Forms.ComboBox();
            this.label_RTDV_SelectedImageSize = new System.Windows.Forms.Label();
            this.label_RTDV_ReceivedImageSize = new System.Windows.Forms.Label();
            this.trackBar_RTDV_ReceivedImageSize = new System.Windows.Forms.TrackBar();
            this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer = new System.Windows.Forms.CheckBox();
            this.checkBox_RTDV_RealSize = new System.Windows.Forms.CheckBox();
            this.label_RTDV_MaxUpdatePerSec = new System.Windows.Forms.Label();
            this.checkBox_RTDV_AllowControl = new System.Windows.Forms.CheckBox();
            this.numericUpDown_RTDV_MaxUpdatePerSec = new System.Windows.Forms.NumericUpDown();
            this.tabPage_Message = new System.Windows.Forms.TabPage();
            this.groupBox_Message_ButtonSelect = new System.Windows.Forms.GroupBox();
            this.radioButton_Message_AbortRetryIgnore = new System.Windows.Forms.RadioButton();
            this.radioButton_Message_radioButton_Message_YesNoCancel = new System.Windows.Forms.RadioButton();
            this.radioButton_Message_RetryCancel = new System.Windows.Forms.RadioButton();
            this.radioButton_Message_YesNo = new System.Windows.Forms.RadioButton();
            this.radioButton_Message_OkCancel = new System.Windows.Forms.RadioButton();
            this.radioButton_Message_Ok = new System.Windows.Forms.RadioButton();
            this.label_Message_MessageText = new System.Windows.Forms.Label();
            this.label_Message_MessageCaption = new System.Windows.Forms.Label();
            this.textBox_Message_MessageText = new System.Windows.Forms.TextBox();
            this.textBox_Message_MessageCaption = new System.Windows.Forms.TextBox();
            this.checkBox_Message_ReceiveUserChoice = new System.Windows.Forms.CheckBox();
            this.groupBox_Message_IconSelect = new System.Windows.Forms.GroupBox();
            this.pictureBox_Message_IconStop = new System.Windows.Forms.PictureBox();
            this.pictureBox_Message_IconInformation = new System.Windows.Forms.PictureBox();
            this.pictureBox_Message_IconWarning = new System.Windows.Forms.PictureBox();
            this.pictureBox_Message_IconQuestion = new System.Windows.Forms.PictureBox();
            this.radioButton_Message_IconNone = new System.Windows.Forms.RadioButton();
            this.radioButton_Message_IconStop = new System.Windows.Forms.RadioButton();
            this.radioButton_Message_IconWarning = new System.Windows.Forms.RadioButton();
            this.radioButton_Message_IconQuestion = new System.Windows.Forms.RadioButton();
            this.radioButton_Message_IconInformation = new System.Windows.Forms.RadioButton();
            this.button_Message_SendMessage = new System.Windows.Forms.Button();
            this.tabPage_ClipboardManager = new System.Windows.Forms.TabPage();
            this.checkBox_ClipboardManager_ShowWarnings = new System.Windows.Forms.CheckBox();
            this.groupBox_ClipboardManager_ClipboardImageSettings = new System.Windows.Forms.GroupBox();
            this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode = new System.Windows.Forms.ComboBox();
            this.label_RemoteClipboardImageSettings_PreviewSizeMode = new System.Windows.Forms.Label();
            this.comboBox_RemoteClipboardImageSettings_ImageFormat = new System.Windows.Forms.ComboBox();
            this.label_RemoteClipboardImageSettings_ImageQuality = new System.Windows.Forms.Label();
            this.label_RemoteClipboardImageSettings_ImageFormat = new System.Windows.Forms.Label();
            this.label_RemoteClipboardImageSettings_CompressionFormat = new System.Windows.Forms.Label();
            this.trackBar_RemoteClipboardImageSettings_ImageQuality = new System.Windows.Forms.TrackBar();
            this.comboBox_RemoteClipboardImageSettings_CompressionFormat = new System.Windows.Forms.ComboBox();
            this.button_ClipboardManager_RefreshClipboardsTypeInfo = new System.Windows.Forms.Button();
            this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval = new System.Windows.Forms.ComboBox();
            this.label_ClipboardManager_RefreshClipboardsTypeInfoInterval = new System.Windows.Forms.Label();
            this.groupBox_ClipboardManager_AddClipboardImageSettings = new System.Windows.Forms.GroupBox();
            this.button_RemoteClipboardImageEnv_SendImage = new System.Windows.Forms.Button();
            this.button_RemoteClipboardImageEnv_SaveImageToDisk = new System.Windows.Forms.Button();
            this.button_ClipboardManager_PreviewRemoteClipboard = new System.Windows.Forms.Button();
            this.groupBox_ClipboardManager_Image = new System.Windows.Forms.GroupBox();
            this.pictureBox_ClipboardManager_Image = new System.Windows.Forms.PictureBox();
            this.textBox_ClipboardManager_RemoteClipboardType = new System.Windows.Forms.TextBox();
            this.label_ClipboardManager_RemoteClipboardType = new System.Windows.Forms.Label();
            this.textBox_ClipboardManager_LocalClipboardType = new System.Windows.Forms.TextBox();
            this.label_ClipboardManager_LocalClipboardType = new System.Windows.Forms.Label();
            this.button_ClipboardManager_ClearLocalClipboard = new System.Windows.Forms.Button();
            this.button_ClipboardManager_ClearRemoteClipboard = new System.Windows.Forms.Button();
            this.button_ClipboardManager_Local2RemoteSync = new System.Windows.Forms.Button();
            this.button_ClipboardManager_Remote2LocalSync = new System.Windows.Forms.Button();
            this.button_ClipboardManager_PreviewLocalClipboard = new System.Windows.Forms.Button();
            this.groupBox_ClipboardManager_TextData = new System.Windows.Forms.GroupBox();
            this.richTextBox_ClipboardManager_TextData = new System.Windows.Forms.RichTextBox();
            this.groupBox_ClipboardManager_FileDropList = new System.Windows.Forms.GroupBox();
            this.listView_ClipboardManager_FileDropList = new System.Windows.Forms.ListView();
            this.columnHeader_ClipboardManager_Item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage_RemoteSystemInformation = new System.Windows.Forms.TabPage();
            this.groupBox_RemoteSystemInformation_AvailableItems = new System.Windows.Forms.GroupBox();
            this.textBox_RemoteSystemInformation_AvailableItems_CurrentStatus = new System.Windows.Forms.TextBox();
            this.button_RemoteSystemInformation_AvailableItems_Refresh = new System.Windows.Forms.Button();
            this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems = new System.Windows.Forms.TreeView();
            this.label_RemoteSystemInformation_AvailableItems_AvailableItems = new System.Windows.Forms.Label();
            this.label_RemoteSystemInformation_AvailableItems_CurrentStatus = new System.Windows.Forms.Label();
            this.groupBox_RemoteSystemInformation_AvailableInformation = new System.Windows.Forms.GroupBox();
            this.button_RemoteSystemInformation_AvailableInformation_CopyItemInfoToClipboard = new System.Windows.Forms.Button();
            this.label_RemoteSystemInformation_AvailableInformation_CurrentItem = new System.Windows.Forms.Label();
            this.button_RemoteSystemInformation_AvailableInformation_Refresh = new System.Windows.Forms.Button();
            this.label_RemoteSystemInformation_AvailableInformation_AvailableInformation = new System.Windows.Forms.Label();
            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation = new System.Windows.Forms.ListView();
            this.columnHeader_RemoteSystemInformation_Parameter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_RemoteSystemInformation_Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox_RemoteSystemInformation_AvailableInformation_CurrentItem = new System.Windows.Forms.TextBox();
            this.tabPage_ServicesManager = new System.Windows.Forms.TabPage();
            this.listView_ServicesManager_Services = new System.Windows.Forms.ListView();
            this.columnHeader_ServicesManager_DisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ServicesManager_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ServicesManager_Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ServicesManager_ServiceType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_ServicesManager = new System.Windows.Forms.ImageList(this.components);
            this.button_ServicesManager_StopService = new System.Windows.Forms.Button();
            this.button_ServicesManager_PauseService = new System.Windows.Forms.Button();
            this.button_ServicesManager_StartService = new System.Windows.Forms.Button();
            this.label_ServicesManager_ServiceManagement = new System.Windows.Forms.Label();
            this.button_ServicesManager_Refresh = new System.Windows.Forms.Button();
            this.tabPage_SystemEvents = new System.Windows.Forms.TabPage();
            this.button_SystemEvents_EventProperties = new System.Windows.Forms.Button();
            this.button_SystemEvents_DeleteLog = new System.Windows.Forms.Button();
            this.textBox_SystemEvents_Information = new System.Windows.Forms.TextBox();
            this.listView_SystemEvents_Events = new System.Windows.Forms.ListView();
            this.columnHeader_SystemEvents_EventType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_SystemEvents_EventDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_SystemEvents_EventTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_SystemEvents_EventSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_SystemEvents_EventCategoty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_SystemEvents_EventID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_SystemEvents_User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_SystemEvents_Computer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_SystemEvents = new System.Windows.Forms.ImageList(this.components);
            this.button_SystemEvents_Refresh = new System.Windows.Forms.Button();
            this.button_SystemEvents_DeleteAllEvents = new System.Windows.Forms.Button();
            this.comboBox_SystemEvents_Logs = new System.Windows.Forms.ComboBox();
            this.tabPage_DriversList = new System.Windows.Forms.TabPage();
            this.button_DriversList_Refresh = new System.Windows.Forms.Button();
            this.listView_DriversList_DriversList = new System.Windows.Forms.ListView();
            this.columnHeader_DriversList_DriverName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_DriversList_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_DriversList_DriverSatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_DriversList_DriverType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_Drivers = new System.Windows.Forms.ImageList(this.components);
            this.tabPage_InstalledPrograms = new System.Windows.Forms.TabPage();
            this.button_InstalledPrograms_Refresh = new System.Windows.Forms.Button();
            this.listView_InstalledPrograms_ProgramsList = new System.Windows.Forms.ListView();
            this.columnHeader_InstalledPrograms_ProgramName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_InstalledPrograms_ProgramVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_InstalledPrograms_ProgramPublisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_InstalledPrograms_InstallDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_InstalledPrograms_InstallLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_InstalledPrograms = new System.Windows.Forms.ImageList(this.components);
            this.tabPage_InstalledUpdates = new System.Windows.Forms.TabPage();
            this.button_InstalledUpdates_Refresh = new System.Windows.Forms.Button();
            this.listView_InstalledUpdates_UpdatesList = new System.Windows.Forms.ListView();
            this.columnHeader_InstalledUpdates_UpdateDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_InstalledUpdates_InstalledBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_InstalledUpdates_InstallDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_InstalledUpdates = new System.Windows.Forms.ImageList(this.components);
            this.tabPage_SystemStateManager = new System.Windows.Forms.TabPage();
            this.label_SystemStateManager_LockWorkstationRemarks = new System.Windows.Forms.Label();
            this.label_SystemStateManager_HibernateRemarks = new System.Windows.Forms.Label();
            this.label_SystemStateManager_StandByRemarks = new System.Windows.Forms.Label();
            this.label_SystemStateManager_Remarks = new System.Windows.Forms.Label();
            this.label_SystemStateManager_ShutDownRemarks = new System.Windows.Forms.Label();
            this.label_SystemStateManager_RestartRemarks = new System.Windows.Forms.Label();
            this.label_SystemStateManager_PowerOffRemarks = new System.Windows.Forms.Label();
            this.label_SystemStateManager_UserLogOffRemarks = new System.Windows.Forms.Label();
            this.splitter_SystemStateManager_Remarks = new System.Windows.Forms.Splitter();
            this.groupBox_SystemStateManager_ChangeSystemState = new System.Windows.Forms.GroupBox();
            this.button_SystemStateManager_PowerOff = new System.Windows.Forms.Button();
            this.checkBox_SystemStateManager_ForceTerminateIfHung = new System.Windows.Forms.CheckBox();
            this.checkBox_SystemStateManager_ForceTerminate = new System.Windows.Forms.CheckBox();
            this.button_SystemStateManager_ShutDown = new System.Windows.Forms.Button();
            this.button_SystemStateManager_Restart = new System.Windows.Forms.Button();
            this.button_SystemStateManager_UserLogOff = new System.Windows.Forms.Button();
            this.groupBox_SystemStateManager_ChangePowerState = new System.Windows.Forms.GroupBox();
            this.checkBox_SystemStateManager_ForceImmediatelySuspend = new System.Windows.Forms.CheckBox();
            this.label_SystemStateManager_HibernateDescription = new System.Windows.Forms.Label();
            this.button_SystemStateManager_Hiberate = new System.Windows.Forms.Button();
            this.button_SystemStateManager_StandBy = new System.Windows.Forms.Button();
            this.groupBox_SystemStateManager_ChangeSecurityState = new System.Windows.Forms.GroupBox();
            this.button_SystemStateManager_LockWorkStation = new System.Windows.Forms.Button();
            this.tabPage_Camera = new System.Windows.Forms.TabPage();
            this.checkBox_CameraTab_EnableCamera = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.comboBox16 = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.comboBox17 = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.button12 = new System.Windows.Forms.Button();
            this.trackBar7 = new System.Windows.Forms.TrackBar();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.comboBox18 = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.trackBar8 = new System.Windows.Forms.TrackBar();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.comboBox19 = new System.Windows.Forms.ComboBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.comboBox20 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label33 = new System.Windows.Forms.Label();
            this.comboBox21 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.contextMenu_RemoteRegistry_KeysContextMenu = new System.Windows.Forms.ContextMenu();
            this.menuItem_RemoteRegistry_ToggleKeyState = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistry_NewItem = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistry_NewItem_Key = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistry_NewItem_Separator1 = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistry_NewItem_String = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistry_NewItem_MultiString = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistry_NewItem_DWORD = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistry_DeleteKey = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistry_CopyKeyName = new System.Windows.Forms.MenuItem();
            this.contextMenu_RemoteRegistry_ValuesContextMenu = new System.Windows.Forms.ContextMenu();
            this.menuItem_RemoteRegistryValuesContextMenu_NewItem = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistryValuesContextMenu_New_Key = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistryValuesContextMenu_New_Separator1 = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistryValuesContextMenu_New_String = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistryValuesContextMenu_New_MultiString = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistryValuesContextMenu_New_DWORD = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistryValuesContextMenu_New_Binary = new System.Windows.Forms.MenuItem();
            this.contextMenu_FileManager_Upload = new System.Windows.Forms.ContextMenu();
            this.menuItem_UploadFiles = new System.Windows.Forms.MenuItem();
            this.menuItem_UploadFolders = new System.Windows.Forms.MenuItem();
            this.columnHeader_ServicesManager_ServiceDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ServicesManager_ServiceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ServicesManager_ServiceStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainMenu_Main = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem_File = new System.Windows.Forms.MenuItem();
            this.menuItem_File_Import = new System.Windows.Forms.MenuItem();
            this.menuItem_File_Import_SettingsDatabase = new System.Windows.Forms.MenuItem();
            this.menuItem_File_Export = new System.Windows.Forms.MenuItem();
            this.menuItem_File_Export_SettingsDatabase = new System.Windows.Forms.MenuItem();
            this.menuItem_File_Exit = new System.Windows.Forms.MenuItem();
            this.menuItem_Options = new System.Windows.Forms.MenuItem();
            this.menuItem_Options_Settings = new System.Windows.Forms.MenuItem();
            this.menuItem_Help = new System.Windows.Forms.MenuItem();
            this.menuItem_Help_About = new System.Windows.Forms.MenuItem();
            this.menuItem_Help_Register = new System.Windows.Forms.MenuItem();
            this.contextMenu_RTDV_SendKeys = new System.Windows.Forms.ContextMenu();
            this.menuItem_AltF12 = new System.Windows.Forms.MenuItem();
            this.menuItem_AltCtrlF12 = new System.Windows.Forms.MenuItem();
            this.menuItem_CtrlEsc = new System.Windows.Forms.MenuItem();
            this.menuItem_F12 = new System.Windows.Forms.MenuItem();
            this.menuItem_TAB = new System.Windows.Forms.MenuItem();
            this.imageList_RTDV = new System.Windows.Forms.ImageList(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenu_RemoteRegistry_NewValue = new System.Windows.Forms.ContextMenu();
            this.menuItem_RemoteRegistry_NewValue_String = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistry_NewValue_MultiString = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistry_NewValue_DWORD = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistry_NewValue_Binary = new System.Windows.Forms.MenuItem();
            this.contextMenu_RemoteRegistry_ValueActions = new System.Windows.Forms.ContextMenu();
            this.menuItem_RemoteRegistryValueActions_Modify = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistryValueActions_Separaton1 = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistryValueActions_Delete = new System.Windows.Forms.MenuItem();
            this.menuItem_RemoteRegistryValueActions_Rename = new System.Windows.Forms.MenuItem();
            this.statusBar_Main = new System.Windows.Forms.StatusBar();
            this.statusBarPanel_BytesSent = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel_BytesReceived = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel_CompletedTasksOfTransfers = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel_LastConnectionTime = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.label21 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.comboBox12 = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBox13 = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.comboBox14 = new System.Windows.Forms.ComboBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.comboBox15 = new System.Windows.Forms.ComboBox();
            this.timer_MainFormTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_RemoteRegistry_MainSplit)).BeginInit();
            this.splitContainer_RemoteRegistry_MainSplit.Panel1.SuspendLayout();
            this.splitContainer_RemoteRegistry_MainSplit.Panel2.SuspendLayout();
            this.splitContainer_RemoteRegistry_MainSplit.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_NetworkControl.SuspendLayout();
            this.groupBox_NetworkControl_Security.SuspendLayout();
            this.groupBox_NetworkControl_ProxySettings.SuspendLayout();
            this.groupBox_NetworkControl_MainNetworkControl.SuspendLayout();
            this.groupBox_NetworkControl_ServersList.SuspendLayout();
            this.groupBox_NetworkControl_ProxyServersList.SuspendLayout();
            this.tabPage_FileManager.SuspendLayout();
            this.tabPage_RemoteExecution.SuspendLayout();
            this.groupBox_RemoteExecution_ExecuteParameters.SuspendLayout();
            this.tabPage_ProcessesManager.SuspendLayout();
            this.groupBox_ProcessesManager_ProcessPriority.SuspendLayout();
            this.tabPage_DrivesManager.SuspendLayout();
            this.tabPage_RemoteRegistry.SuspendLayout();
            this.tabPage_Display.SuspendLayout();
            this.groupBox_DisplaySettings_DisplaySettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_DisplaySettings_Resolution)).BeginInit();
            this.groupBox_SingleImageCapture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_SingleImageCapture_ImageQuality)).BeginInit();
            this.groupBox_CaptureInInterval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_CaptureInInterval_ImageQuality)).BeginInit();
            this.tabPage_RTDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RTDV_ImageCodingAlgorithm)).BeginInit();
            this.groupBox_RTDV_AdditionalParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RTDV_ReceivedImageSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RTDV_MaxUpdatePerSec)).BeginInit();
            this.tabPage_Message.SuspendLayout();
            this.groupBox_Message_ButtonSelect.SuspendLayout();
            this.groupBox_Message_IconSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Message_IconStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Message_IconInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Message_IconWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Message_IconQuestion)).BeginInit();
            this.tabPage_ClipboardManager.SuspendLayout();
            this.groupBox_ClipboardManager_ClipboardImageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RemoteClipboardImageSettings_ImageQuality)).BeginInit();
            this.groupBox_ClipboardManager_AddClipboardImageSettings.SuspendLayout();
            this.groupBox_ClipboardManager_Image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ClipboardManager_Image)).BeginInit();
            this.groupBox_ClipboardManager_TextData.SuspendLayout();
            this.groupBox_ClipboardManager_FileDropList.SuspendLayout();
            this.tabPage_RemoteSystemInformation.SuspendLayout();
            this.groupBox_RemoteSystemInformation_AvailableItems.SuspendLayout();
            this.groupBox_RemoteSystemInformation_AvailableInformation.SuspendLayout();
            this.tabPage_ServicesManager.SuspendLayout();
            this.tabPage_SystemEvents.SuspendLayout();
            this.tabPage_DriversList.SuspendLayout();
            this.tabPage_InstalledPrograms.SuspendLayout();
            this.tabPage_InstalledUpdates.SuspendLayout();
            this.tabPage_SystemStateManager.SuspendLayout();
            this.groupBox_SystemStateManager_ChangeSystemState.SuspendLayout();
            this.groupBox_SystemStateManager_ChangePowerState.SuspendLayout();
            this.groupBox_SystemStateManager_ChangeSecurityState.SuspendLayout();
            this.tabPage_Camera.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_BytesSent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_BytesReceived)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_CompletedTasksOfTransfers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_LastConnectionTime)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer_RemoteRegistry_MainSplit
            // 
            this.splitContainer_RemoteRegistry_MainSplit.Location = new System.Drawing.Point(8, 64);
            this.splitContainer_RemoteRegistry_MainSplit.Name = "splitContainer_RemoteRegistry_MainSplit";
            // 
            // splitContainer_RemoteRegistry_MainSplit.Panel1
            // 
            this.splitContainer_RemoteRegistry_MainSplit.Panel1.AutoScroll = true;
            this.splitContainer_RemoteRegistry_MainSplit.Panel1.Controls.Add(this.treeView_RemoteRegistry_NodesTree);
            // 
            // splitContainer_RemoteRegistry_MainSplit.Panel2
            // 
            this.splitContainer_RemoteRegistry_MainSplit.Panel2.Controls.Add(this.listView_RemoteRegistry_Values);
            this.splitContainer_RemoteRegistry_MainSplit.Size = new System.Drawing.Size(928, 513);
            this.splitContainer_RemoteRegistry_MainSplit.SplitterDistance = 290;
            this.splitContainer_RemoteRegistry_MainSplit.TabIndex = 16;
            // 
            // treeView_RemoteRegistry_NodesTree
            // 
            this.treeView_RemoteRegistry_NodesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_RemoteRegistry_NodesTree.FullRowSelect = true;
            this.treeView_RemoteRegistry_NodesTree.HideSelection = false;
            this.treeView_RemoteRegistry_NodesTree.ImageIndex = 0;
            this.treeView_RemoteRegistry_NodesTree.ImageList = this.imageList_RemoteRegistry;
            this.treeView_RemoteRegistry_NodesTree.Location = new System.Drawing.Point(0, 0);
            this.treeView_RemoteRegistry_NodesTree.Name = "treeView_RemoteRegistry_NodesTree";
            treeNode1.Name = "";
            treeNode1.Text = "HKEY_CLASSES_ROOT";
            treeNode2.Name = "";
            treeNode2.Text = "HKEY_CURRENT_USER";
            treeNode3.Name = "";
            treeNode3.Text = "HKEY_LOCAL_MACHINE";
            treeNode4.Name = "";
            treeNode4.Text = "HKEY_USERS";
            treeNode5.Name = "";
            treeNode5.Text = "HKEY_CURRENT_CONFIG";
            this.treeView_RemoteRegistry_NodesTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.treeView_RemoteRegistry_NodesTree.SelectedImageIndex = 0;
            this.treeView_RemoteRegistry_NodesTree.Size = new System.Drawing.Size(290, 513);
            this.treeView_RemoteRegistry_NodesTree.TabIndex = 0;
            this.treeView_RemoteRegistry_NodesTree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView_RemoteRegistry_NodesTree_AfterCollapse);
            this.treeView_RemoteRegistry_NodesTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_RemoteRegistry_NodesTree_BeforeExpand);
            this.treeView_RemoteRegistry_NodesTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView_RemoteRegistry_NodesTree_AfterExpand);
            this.treeView_RemoteRegistry_NodesTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_RemoteRegistry_NodesTree_BeforeSelect);
            this.treeView_RemoteRegistry_NodesTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_RemoteRegistry_NodesTree_KeyDown);
            this.treeView_RemoteRegistry_NodesTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView_RemoteRegistry_NodesTree_MouseUp);
            // 
            // imageList_RemoteRegistry
            // 
            this.imageList_RemoteRegistry.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_RemoteRegistry.ImageStream")));
            this.imageList_RemoteRegistry.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_RemoteRegistry.Images.SetKeyName(0, "");
            this.imageList_RemoteRegistry.Images.SetKeyName(1, "");
            this.imageList_RemoteRegistry.Images.SetKeyName(2, "");
            // 
            // listView_RemoteRegistry_Values
            // 
            this.listView_RemoteRegistry_Values.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_RemoteRegistryValues_ValueName,
            this.columnHeader_RemoteRegistryValues_ValueType,
            this.columnHeader_RemoteRegistryValues_ValueData});
            this.listView_RemoteRegistry_Values.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_RemoteRegistry_Values.FullRowSelect = true;
            this.listView_RemoteRegistry_Values.GridLines = true;
            this.listView_RemoteRegistry_Values.Location = new System.Drawing.Point(0, 0);
            this.listView_RemoteRegistry_Values.Name = "listView_RemoteRegistry_Values";
            this.listView_RemoteRegistry_Values.Size = new System.Drawing.Size(634, 513);
            this.listView_RemoteRegistry_Values.SmallImageList = this.imageList_RemoteRegistry;
            this.listView_RemoteRegistry_Values.TabIndex = 1;
            this.listView_RemoteRegistry_Values.UseCompatibleStateImageBehavior = false;
            this.listView_RemoteRegistry_Values.View = System.Windows.Forms.View.Details;
            this.listView_RemoteRegistry_Values.SelectedIndexChanged += new System.EventHandler(this.listView_RemoteRegistry_Values_SelectedIndexChanged);
            this.listView_RemoteRegistry_Values.DoubleClick += new System.EventHandler(this.listView_RemoteRegistry_Values_DoubleClick);
            this.listView_RemoteRegistry_Values.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_RemoteRegistry_Values_KeyDown);
            this.listView_RemoteRegistry_Values.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView_RemoteRegistry_Values_MouseUp);
            // 
            // columnHeader_RemoteRegistryValues_ValueName
            // 
            this.columnHeader_RemoteRegistryValues_ValueName.Text = "Name";
            this.columnHeader_RemoteRegistryValues_ValueName.Width = 140;
            // 
            // columnHeader_RemoteRegistryValues_ValueType
            // 
            this.columnHeader_RemoteRegistryValues_ValueType.Text = "Type";
            this.columnHeader_RemoteRegistryValues_ValueType.Width = 120;
            // 
            // columnHeader_RemoteRegistryValues_ValueData
            // 
            this.columnHeader_RemoteRegistryValues_ValueData.Text = "Data";
            this.columnHeader_RemoteRegistryValues_ValueData.Width = 350;
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage_NetworkControl);
            this.tabControl_Main.Controls.Add(this.tabPage_FileManager);
            this.tabControl_Main.Controls.Add(this.tabPage_RemoteExecution);
            this.tabControl_Main.Controls.Add(this.tabPage_ProcessesManager);
            this.tabControl_Main.Controls.Add(this.tabPage_DrivesManager);
            this.tabControl_Main.Controls.Add(this.tabPage_RemoteRegistry);
            this.tabControl_Main.Controls.Add(this.tabPage_Display);
            this.tabControl_Main.Controls.Add(this.tabPage_RTDV);
            this.tabControl_Main.Controls.Add(this.tabPage_Message);
            this.tabControl_Main.Controls.Add(this.tabPage_ClipboardManager);
            this.tabControl_Main.Controls.Add(this.tabPage_RemoteSystemInformation);
            this.tabControl_Main.Controls.Add(this.tabPage_ServicesManager);
            this.tabControl_Main.Controls.Add(this.tabPage_SystemEvents);
            this.tabControl_Main.Controls.Add(this.tabPage_DriversList);
            this.tabControl_Main.Controls.Add(this.tabPage_InstalledPrograms);
            this.tabControl_Main.Controls.Add(this.tabPage_InstalledUpdates);
            this.tabControl_Main.Controls.Add(this.tabPage_SystemStateManager);
            this.tabControl_Main.Controls.Add(this.tabPage_Camera);
            this.tabControl_Main.HotTrack = true;
            this.tabControl_Main.ItemSize = new System.Drawing.Size(88, 18);
            this.tabControl_Main.Location = new System.Drawing.Point(8, 0);
            this.tabControl_Main.Multiline = true;
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(952, 631);
            this.tabControl_Main.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl_Main.TabIndex = 0;
            this.tabControl_Main.SelectedIndexChanged += new System.EventHandler(this.tabControl_Main_SelectedIndexChanged);
            // 
            // tabPage_NetworkControl
            // 
            this.tabPage_NetworkControl.Controls.Add(this.groupBox_NetworkControl_Security);
            this.tabPage_NetworkControl.Controls.Add(this.groupBox_NetworkControl_ProxySettings);
            this.tabPage_NetworkControl.Controls.Add(this.groupBox_NetworkControl_MainNetworkControl);
            this.tabPage_NetworkControl.Controls.Add(this.splitter_NetworkControl_Remarks);
            this.tabPage_NetworkControl.Controls.Add(this.groupBox_NetworkControl_ServersList);
            this.tabPage_NetworkControl.Controls.Add(this.groupBox_NetworkControl_ProxyServersList);
            this.tabPage_NetworkControl.Location = new System.Drawing.Point(4, 40);
            this.tabPage_NetworkControl.Name = "tabPage_NetworkControl";
            this.tabPage_NetworkControl.Size = new System.Drawing.Size(944, 587);
            this.tabPage_NetworkControl.TabIndex = 0;
            this.tabPage_NetworkControl.Text = "Network Control";
            // 
            // groupBox_NetworkControl_Security
            // 
            this.groupBox_NetworkControl_Security.Controls.Add(this.label_NetworkControl_Password);
            this.groupBox_NetworkControl_Security.Controls.Add(this.label_NetworkControl_Login);
            this.groupBox_NetworkControl_Security.Controls.Add(this.textBox_NetworkControl_Password);
            this.groupBox_NetworkControl_Security.Controls.Add(this.textBox_NetworkControl_Login);
            this.groupBox_NetworkControl_Security.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_NetworkControl_Security.Location = new System.Drawing.Point(438, 18);
            this.groupBox_NetworkControl_Security.Name = "groupBox_NetworkControl_Security";
            this.groupBox_NetworkControl_Security.Size = new System.Drawing.Size(146, 120);
            this.groupBox_NetworkControl_Security.TabIndex = 46;
            this.groupBox_NetworkControl_Security.TabStop = false;
            this.groupBox_NetworkControl_Security.Text = "Security";
            // 
            // label_NetworkControl_Password
            // 
            this.label_NetworkControl_Password.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_NetworkControl_Password.Location = new System.Drawing.Point(17, 64);
            this.label_NetworkControl_Password.Name = "label_NetworkControl_Password";
            this.label_NetworkControl_Password.Size = new System.Drawing.Size(112, 16);
            this.label_NetworkControl_Password.TabIndex = 3;
            this.label_NetworkControl_Password.Text = "Password:";
            // 
            // label_NetworkControl_Login
            // 
            this.label_NetworkControl_Login.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_NetworkControl_Login.Location = new System.Drawing.Point(17, 24);
            this.label_NetworkControl_Login.Name = "label_NetworkControl_Login";
            this.label_NetworkControl_Login.Size = new System.Drawing.Size(112, 16);
            this.label_NetworkControl_Login.TabIndex = 2;
            this.label_NetworkControl_Login.Text = "Login:";
            // 
            // textBox_NetworkControl_Password
            // 
            this.textBox_NetworkControl_Password.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox_NetworkControl_Password.Location = new System.Drawing.Point(17, 80);
            this.textBox_NetworkControl_Password.Name = "textBox_NetworkControl_Password";
            this.textBox_NetworkControl_Password.PasswordChar = '*';
            this.textBox_NetworkControl_Password.Size = new System.Drawing.Size(112, 20);
            this.textBox_NetworkControl_Password.TabIndex = 6;
            // 
            // textBox_NetworkControl_Login
            // 
            this.textBox_NetworkControl_Login.Location = new System.Drawing.Point(17, 40);
            this.textBox_NetworkControl_Login.Name = "textBox_NetworkControl_Login";
            this.textBox_NetworkControl_Login.Size = new System.Drawing.Size(112, 20);
            this.textBox_NetworkControl_Login.TabIndex = 5;
            // 
            // groupBox_NetworkControl_ProxySettings
            // 
            this.groupBox_NetworkControl_ProxySettings.Controls.Add(this.label_ProxySettings_ProxyType);
            this.groupBox_NetworkControl_ProxySettings.Controls.Add(this.checkBox_ProxySettings_ResolveHostNames);
            this.groupBox_NetworkControl_ProxySettings.Controls.Add(this.checkBox_ProxySettings_Authentication);
            this.groupBox_NetworkControl_ProxySettings.Controls.Add(this.label_ProxySettings_ProxyTimeOut);
            this.groupBox_NetworkControl_ProxySettings.Controls.Add(this.comboBox_ProxySettings_ProxyTimeOut);
            this.groupBox_NetworkControl_ProxySettings.Controls.Add(this.label_ProxySettings_ProxyPort);
            this.groupBox_NetworkControl_ProxySettings.Controls.Add(this.label_ProxySettings_ProxyHost);
            this.groupBox_NetworkControl_ProxySettings.Controls.Add(this.textBox_ProxySettings_ProxyPort);
            this.groupBox_NetworkControl_ProxySettings.Controls.Add(this.textBox_ProxySettings_ProxyHost);
            this.groupBox_NetworkControl_ProxySettings.Controls.Add(this.label_ProxySettings_Socks5Password);
            this.groupBox_NetworkControl_ProxySettings.Controls.Add(this.label_ProxySettings_Socks5UserName);
            this.groupBox_NetworkControl_ProxySettings.Controls.Add(this.textBox_ProxySettings_Socks5Password);
            this.groupBox_NetworkControl_ProxySettings.Controls.Add(this.textBox_ProxySettings_Socks5UserName);
            this.groupBox_NetworkControl_ProxySettings.Controls.Add(this.listBox_ProxySettings_ProxyType);
            this.groupBox_NetworkControl_ProxySettings.Controls.Add(this.checkBox_ProxySettings_UseProxy);
            this.groupBox_NetworkControl_ProxySettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_NetworkControl_ProxySettings.Location = new System.Drawing.Point(600, 16);
            this.groupBox_NetworkControl_ProxySettings.Name = "groupBox_NetworkControl_ProxySettings";
            this.groupBox_NetworkControl_ProxySettings.Size = new System.Drawing.Size(336, 224);
            this.groupBox_NetworkControl_ProxySettings.TabIndex = 3;
            this.groupBox_NetworkControl_ProxySettings.TabStop = false;
            this.groupBox_NetworkControl_ProxySettings.Text = "Proxy\\Firewall settings";
            // 
            // label_ProxySettings_ProxyType
            // 
            this.label_ProxySettings_ProxyType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_ProxySettings_ProxyType.Location = new System.Drawing.Point(16, 24);
            this.label_ProxySettings_ProxyType.Name = "label_ProxySettings_ProxyType";
            this.label_ProxySettings_ProxyType.Size = new System.Drawing.Size(144, 16);
            this.label_ProxySettings_ProxyType.TabIndex = 44;
            this.label_ProxySettings_ProxyType.Text = "Proxy Type:";
            // 
            // checkBox_ProxySettings_ResolveHostNames
            // 
            this.checkBox_ProxySettings_ResolveHostNames.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_ProxySettings_ResolveHostNames.Location = new System.Drawing.Point(16, 192);
            this.checkBox_ProxySettings_ResolveHostNames.Name = "checkBox_ProxySettings_ResolveHostNames";
            this.checkBox_ProxySettings_ResolveHostNames.Size = new System.Drawing.Size(304, 16);
            this.checkBox_ProxySettings_ResolveHostNames.TabIndex = 15;
            this.checkBox_ProxySettings_ResolveHostNames.Text = "Use Proxy to resolve hostnames";
            // 
            // checkBox_ProxySettings_Authentication
            // 
            this.checkBox_ProxySettings_Authentication.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_ProxySettings_Authentication.Location = new System.Drawing.Point(168, 120);
            this.checkBox_ProxySettings_Authentication.Name = "checkBox_ProxySettings_Authentication";
            this.checkBox_ProxySettings_Authentication.Size = new System.Drawing.Size(152, 16);
            this.checkBox_ProxySettings_Authentication.TabIndex = 12;
            this.checkBox_ProxySettings_Authentication.Text = "Authentication";
            this.checkBox_ProxySettings_Authentication.CheckedChanged += new System.EventHandler(this.checkBox_ProxySettings_Authentication_CheckedChanged);
            // 
            // label_ProxySettings_ProxyTimeOut
            // 
            this.label_ProxySettings_ProxyTimeOut.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_ProxySettings_ProxyTimeOut.Location = new System.Drawing.Point(240, 72);
            this.label_ProxySettings_ProxyTimeOut.Name = "label_ProxySettings_ProxyTimeOut";
            this.label_ProxySettings_ProxyTimeOut.Size = new System.Drawing.Size(80, 16);
            this.label_ProxySettings_ProxyTimeOut.TabIndex = 39;
            this.label_ProxySettings_ProxyTimeOut.Text = "Time Out:";
            // 
            // comboBox_ProxySettings_ProxyTimeOut
            // 
            this.comboBox_ProxySettings_ProxyTimeOut.Items.AddRange(new object[] {
            "5 seconds",
            "10 seconds",
            "15 seconds"});
            this.comboBox_ProxySettings_ProxyTimeOut.Location = new System.Drawing.Point(240, 88);
            this.comboBox_ProxySettings_ProxyTimeOut.Name = "comboBox_ProxySettings_ProxyTimeOut";
            this.comboBox_ProxySettings_ProxyTimeOut.Size = new System.Drawing.Size(80, 21);
            this.comboBox_ProxySettings_ProxyTimeOut.TabIndex = 10;
            // 
            // label_ProxySettings_ProxyPort
            // 
            this.label_ProxySettings_ProxyPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_ProxySettings_ProxyPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_ProxySettings_ProxyPort.Location = new System.Drawing.Point(168, 72);
            this.label_ProxySettings_ProxyPort.Name = "label_ProxySettings_ProxyPort";
            this.label_ProxySettings_ProxyPort.Size = new System.Drawing.Size(64, 16);
            this.label_ProxySettings_ProxyPort.TabIndex = 11;
            this.label_ProxySettings_ProxyPort.Text = "Port:";
            // 
            // label_ProxySettings_ProxyHost
            // 
            this.label_ProxySettings_ProxyHost.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_ProxySettings_ProxyHost.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_ProxySettings_ProxyHost.Location = new System.Drawing.Point(168, 24);
            this.label_ProxySettings_ProxyHost.Name = "label_ProxySettings_ProxyHost";
            this.label_ProxySettings_ProxyHost.Size = new System.Drawing.Size(152, 16);
            this.label_ProxySettings_ProxyHost.TabIndex = 10;
            this.label_ProxySettings_ProxyHost.Text = "Host:";
            // 
            // textBox_ProxySettings_ProxyPort
            // 
            this.textBox_ProxySettings_ProxyPort.Location = new System.Drawing.Point(168, 88);
            this.textBox_ProxySettings_ProxyPort.MaxLength = 5;
            this.textBox_ProxySettings_ProxyPort.Name = "textBox_ProxySettings_ProxyPort";
            this.textBox_ProxySettings_ProxyPort.Size = new System.Drawing.Size(64, 20);
            this.textBox_ProxySettings_ProxyPort.TabIndex = 9;
            this.textBox_ProxySettings_ProxyPort.Text = "1080";
            // 
            // textBox_ProxySettings_ProxyHost
            // 
            this.textBox_ProxySettings_ProxyHost.Location = new System.Drawing.Point(168, 40);
            this.textBox_ProxySettings_ProxyHost.Name = "textBox_ProxySettings_ProxyHost";
            this.textBox_ProxySettings_ProxyHost.Size = new System.Drawing.Size(152, 20);
            this.textBox_ProxySettings_ProxyHost.TabIndex = 8;
            // 
            // label_ProxySettings_Socks5Password
            // 
            this.label_ProxySettings_Socks5Password.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_ProxySettings_Socks5Password.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_ProxySettings_Socks5Password.Location = new System.Drawing.Point(168, 144);
            this.label_ProxySettings_Socks5Password.Name = "label_ProxySettings_Socks5Password";
            this.label_ProxySettings_Socks5Password.Size = new System.Drawing.Size(152, 16);
            this.label_ProxySettings_Socks5Password.TabIndex = 7;
            this.label_ProxySettings_Socks5Password.Text = "Password:";
            // 
            // label_ProxySettings_Socks5UserName
            // 
            this.label_ProxySettings_Socks5UserName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_ProxySettings_Socks5UserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_ProxySettings_Socks5UserName.Location = new System.Drawing.Point(16, 144);
            this.label_ProxySettings_Socks5UserName.Name = "label_ProxySettings_Socks5UserName";
            this.label_ProxySettings_Socks5UserName.Size = new System.Drawing.Size(144, 16);
            this.label_ProxySettings_Socks5UserName.TabIndex = 6;
            this.label_ProxySettings_Socks5UserName.Text = "User Name:";
            // 
            // textBox_ProxySettings_Socks5Password
            // 
            this.textBox_ProxySettings_Socks5Password.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox_ProxySettings_Socks5Password.Location = new System.Drawing.Point(168, 160);
            this.textBox_ProxySettings_Socks5Password.Name = "textBox_ProxySettings_Socks5Password";
            this.textBox_ProxySettings_Socks5Password.PasswordChar = '*';
            this.textBox_ProxySettings_Socks5Password.Size = new System.Drawing.Size(152, 20);
            this.textBox_ProxySettings_Socks5Password.TabIndex = 14;
            // 
            // textBox_ProxySettings_Socks5UserName
            // 
            this.textBox_ProxySettings_Socks5UserName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox_ProxySettings_Socks5UserName.Location = new System.Drawing.Point(16, 160);
            this.textBox_ProxySettings_Socks5UserName.Name = "textBox_ProxySettings_Socks5UserName";
            this.textBox_ProxySettings_Socks5UserName.Size = new System.Drawing.Size(144, 20);
            this.textBox_ProxySettings_Socks5UserName.TabIndex = 13;
            // 
            // listBox_ProxySettings_ProxyType
            // 
            this.listBox_ProxySettings_ProxyType.IntegralHeight = false;
            this.listBox_ProxySettings_ProxyType.Items.AddRange(new object[] {
            "Socks server version 4",
            "Socks server version 5",
            "HTTPS Proxy server"});
            this.listBox_ProxySettings_ProxyType.Location = new System.Drawing.Point(16, 40);
            this.listBox_ProxySettings_ProxyType.Name = "listBox_ProxySettings_ProxyType";
            this.listBox_ProxySettings_ProxyType.Size = new System.Drawing.Size(144, 68);
            this.listBox_ProxySettings_ProxyType.TabIndex = 7;
            this.listBox_ProxySettings_ProxyType.SelectedIndexChanged += new System.EventHandler(this.listBox_NetworkControl_ProxyType_SelectedIndexChanged);
            // 
            // checkBox_ProxySettings_UseProxy
            // 
            this.checkBox_ProxySettings_UseProxy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_ProxySettings_UseProxy.Location = new System.Drawing.Point(16, 120);
            this.checkBox_ProxySettings_UseProxy.Name = "checkBox_ProxySettings_UseProxy";
            this.checkBox_ProxySettings_UseProxy.Size = new System.Drawing.Size(144, 16);
            this.checkBox_ProxySettings_UseProxy.TabIndex = 11;
            this.checkBox_ProxySettings_UseProxy.Text = "Use Proxy";
            this.checkBox_ProxySettings_UseProxy.CheckedChanged += new System.EventHandler(this.checkBox_NetworkControl_UseProxy_CheckedChanged);
            // 
            // groupBox_NetworkControl_MainNetworkControl
            // 
            this.groupBox_NetworkControl_MainNetworkControl.Controls.Add(this.label_NetworkControl_ConnectionTimeOut);
            this.groupBox_NetworkControl_MainNetworkControl.Controls.Add(this.comboBox_NetworkControl_ConnectionTimeOut);
            this.groupBox_NetworkControl_MainNetworkControl.Controls.Add(this.button_NetworkControl_ConnectingService);
            this.groupBox_NetworkControl_MainNetworkControl.Controls.Add(this.label_NetworkControl_ConnectionStatus);
            this.groupBox_NetworkControl_MainNetworkControl.Controls.Add(this.label_NetworkControl_Port);
            this.groupBox_NetworkControl_MainNetworkControl.Controls.Add(this.label_NetworkControl_IP);
            this.groupBox_NetworkControl_MainNetworkControl.Controls.Add(this.textBox_NetworkControl_ConnectionStatus);
            this.groupBox_NetworkControl_MainNetworkControl.Controls.Add(this.textBox_NetworkControl_Port);
            this.groupBox_NetworkControl_MainNetworkControl.Controls.Add(this.textBox_NetworkControl_IP);
            this.groupBox_NetworkControl_MainNetworkControl.Controls.Add(this.button_NetworkControl_Connect);
            this.groupBox_NetworkControl_MainNetworkControl.Controls.Add(this.button_NetworkControl_Disconnect);
            this.groupBox_NetworkControl_MainNetworkControl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_NetworkControl_MainNetworkControl.Location = new System.Drawing.Point(8, 18);
            this.groupBox_NetworkControl_MainNetworkControl.Name = "groupBox_NetworkControl_MainNetworkControl";
            this.groupBox_NetworkControl_MainNetworkControl.Size = new System.Drawing.Size(414, 120);
            this.groupBox_NetworkControl_MainNetworkControl.TabIndex = 45;
            this.groupBox_NetworkControl_MainNetworkControl.TabStop = false;
            this.groupBox_NetworkControl_MainNetworkControl.Text = "Main Network Control";
            // 
            // label_NetworkControl_ConnectionTimeOut
            // 
            this.label_NetworkControl_ConnectionTimeOut.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_NetworkControl_ConnectionTimeOut.Location = new System.Drawing.Point(196, 24);
            this.label_NetworkControl_ConnectionTimeOut.Name = "label_NetworkControl_ConnectionTimeOut";
            this.label_NetworkControl_ConnectionTimeOut.Size = new System.Drawing.Size(80, 16);
            this.label_NetworkControl_ConnectionTimeOut.TabIndex = 41;
            this.label_NetworkControl_ConnectionTimeOut.Text = "Time Out:";
            // 
            // comboBox_NetworkControl_ConnectionTimeOut
            // 
            this.comboBox_NetworkControl_ConnectionTimeOut.Items.AddRange(new object[] {
            "5 seconds",
            "10 seconds",
            "15 seconds"});
            this.comboBox_NetworkControl_ConnectionTimeOut.Location = new System.Drawing.Point(196, 40);
            this.comboBox_NetworkControl_ConnectionTimeOut.Name = "comboBox_NetworkControl_ConnectionTimeOut";
            this.comboBox_NetworkControl_ConnectionTimeOut.Size = new System.Drawing.Size(80, 21);
            this.comboBox_NetworkControl_ConnectionTimeOut.TabIndex = 40;
            // 
            // button_NetworkControl_ConnectingService
            // 
            this.button_NetworkControl_ConnectingService.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_NetworkControl_ConnectingService.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_NetworkControl_ConnectingService.Location = new System.Drawing.Point(282, 80);
            this.button_NetworkControl_ConnectingService.Name = "button_NetworkControl_ConnectingService";
            this.button_NetworkControl_ConnectingService.Size = new System.Drawing.Size(121, 23);
            this.button_NetworkControl_ConnectingService.TabIndex = 8;
            this.button_NetworkControl_ConnectingService.Text = "Connecting Service";
            this.button_NetworkControl_ConnectingService.Click += new System.EventHandler(this.button_NetworkControl_ConnectingService_Click);
            // 
            // label_NetworkControl_ConnectionStatus
            // 
            this.label_NetworkControl_ConnectionStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_NetworkControl_ConnectionStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_NetworkControl_ConnectionStatus.Location = new System.Drawing.Point(282, 24);
            this.label_NetworkControl_ConnectionStatus.Name = "label_NetworkControl_ConnectionStatus";
            this.label_NetworkControl_ConnectionStatus.Size = new System.Drawing.Size(121, 16);
            this.label_NetworkControl_ConnectionStatus.TabIndex = 7;
            this.label_NetworkControl_ConnectionStatus.Text = "Connection Status:";
            // 
            // label_NetworkControl_Port
            // 
            this.label_NetworkControl_Port.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_NetworkControl_Port.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_NetworkControl_Port.Location = new System.Drawing.Point(137, 24);
            this.label_NetworkControl_Port.Name = "label_NetworkControl_Port";
            this.label_NetworkControl_Port.Size = new System.Drawing.Size(32, 16);
            this.label_NetworkControl_Port.TabIndex = 6;
            this.label_NetworkControl_Port.Text = "Port:";
            // 
            // label_NetworkControl_IP
            // 
            this.label_NetworkControl_IP.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_NetworkControl_IP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_NetworkControl_IP.Location = new System.Drawing.Point(14, 24);
            this.label_NetworkControl_IP.Name = "label_NetworkControl_IP";
            this.label_NetworkControl_IP.Size = new System.Drawing.Size(104, 16);
            this.label_NetworkControl_IP.TabIndex = 5;
            this.label_NetworkControl_IP.Text = "IP address of Server:";
            // 
            // textBox_NetworkControl_ConnectionStatus
            // 
            this.textBox_NetworkControl_ConnectionStatus.Location = new System.Drawing.Point(282, 40);
            this.textBox_NetworkControl_ConnectionStatus.Name = "textBox_NetworkControl_ConnectionStatus";
            this.textBox_NetworkControl_ConnectionStatus.ReadOnly = true;
            this.textBox_NetworkControl_ConnectionStatus.Size = new System.Drawing.Size(121, 20);
            this.textBox_NetworkControl_ConnectionStatus.TabIndex = 4;
            // 
            // textBox_NetworkControl_Port
            // 
            this.textBox_NetworkControl_Port.Location = new System.Drawing.Point(137, 40);
            this.textBox_NetworkControl_Port.MaxLength = 5;
            this.textBox_NetworkControl_Port.Name = "textBox_NetworkControl_Port";
            this.textBox_NetworkControl_Port.Size = new System.Drawing.Size(53, 20);
            this.textBox_NetworkControl_Port.TabIndex = 2;
            this.textBox_NetworkControl_Port.Text = "5544";
            // 
            // textBox_NetworkControl_IP
            // 
            this.textBox_NetworkControl_IP.Location = new System.Drawing.Point(14, 40);
            this.textBox_NetworkControl_IP.Name = "textBox_NetworkControl_IP";
            this.textBox_NetworkControl_IP.Size = new System.Drawing.Size(117, 20);
            this.textBox_NetworkControl_IP.TabIndex = 1;
            this.textBox_NetworkControl_IP.Text = "localhost";
            // 
            // button_NetworkControl_Connect
            // 
            this.button_NetworkControl_Connect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_NetworkControl_Connect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_NetworkControl_Connect.Location = new System.Drawing.Point(14, 80);
            this.button_NetworkControl_Connect.Name = "button_NetworkControl_Connect";
            this.button_NetworkControl_Connect.Size = new System.Drawing.Size(117, 23);
            this.button_NetworkControl_Connect.TabIndex = 3;
            this.button_NetworkControl_Connect.Text = "Connect";
            this.button_NetworkControl_Connect.Click += new System.EventHandler(this.button_NetworkControl_Connect_Click);
            // 
            // button_NetworkControl_Disconnect
            // 
            this.button_NetworkControl_Disconnect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_NetworkControl_Disconnect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_NetworkControl_Disconnect.Location = new System.Drawing.Point(137, 80);
            this.button_NetworkControl_Disconnect.Name = "button_NetworkControl_Disconnect";
            this.button_NetworkControl_Disconnect.Size = new System.Drawing.Size(139, 23);
            this.button_NetworkControl_Disconnect.TabIndex = 4;
            this.button_NetworkControl_Disconnect.Text = "Disconnect";
            this.button_NetworkControl_Disconnect.Click += new System.EventHandler(this.button_NetworkControl_Disconnect_Click);
            // 
            // splitter_NetworkControl_Remarks
            // 
            this.splitter_NetworkControl_Remarks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitter_NetworkControl_Remarks.Location = new System.Drawing.Point(0, 0);
            this.splitter_NetworkControl_Remarks.Name = "splitter_NetworkControl_Remarks";
            this.splitter_NetworkControl_Remarks.Size = new System.Drawing.Size(3, 587);
            this.splitter_NetworkControl_Remarks.TabIndex = 0;
            this.splitter_NetworkControl_Remarks.TabStop = false;
            // 
            // groupBox_NetworkControl_ServersList
            // 
            this.groupBox_NetworkControl_ServersList.Controls.Add(this.button_ServersList_Refresh);
            this.groupBox_NetworkControl_ServersList.Controls.Add(this.label_ServersList_GroupSelection);
            this.groupBox_NetworkControl_ServersList.Controls.Add(this.comboBox_ServersList_ServersGroups);
            this.groupBox_NetworkControl_ServersList.Controls.Add(this.button_ServersList_Use);
            this.groupBox_NetworkControl_ServersList.Controls.Add(this.button_ServersList_ViewRecord);
            this.groupBox_NetworkControl_ServersList.Controls.Add(this.button_ServersList_ClearList);
            this.groupBox_NetworkControl_ServersList.Controls.Add(this.listView_ServersList_ServersList);
            this.groupBox_NetworkControl_ServersList.Controls.Add(this.button_ServersList_AddRecord);
            this.groupBox_NetworkControl_ServersList.Controls.Add(this.button_ServersList_RemoveRecord);
            this.groupBox_NetworkControl_ServersList.Controls.Add(this.button_ServersList_EditRecord);
            this.groupBox_NetworkControl_ServersList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_NetworkControl_ServersList.Location = new System.Drawing.Point(8, 144);
            this.groupBox_NetworkControl_ServersList.Name = "groupBox_NetworkControl_ServersList";
            this.groupBox_NetworkControl_ServersList.Size = new System.Drawing.Size(576, 416);
            this.groupBox_NetworkControl_ServersList.TabIndex = 2;
            this.groupBox_NetworkControl_ServersList.TabStop = false;
            this.groupBox_NetworkControl_ServersList.Text = "Servers list";
            this.groupBox_NetworkControl_ServersList.Enter += new System.EventHandler(this.groupBox_NetworkControl_ServersList_Enter);
            // 
            // button_ServersList_Refresh
            // 
            this.button_ServersList_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ServersList_Refresh.Location = new System.Drawing.Point(456, 344);
            this.button_ServersList_Refresh.Name = "button_ServersList_Refresh";
            this.button_ServersList_Refresh.Size = new System.Drawing.Size(104, 23);
            this.button_ServersList_Refresh.TabIndex = 67;
            this.button_ServersList_Refresh.Text = "Refresh";
            this.button_ServersList_Refresh.Click += new System.EventHandler(this.button_ServersList_Refresh_Click);
            // 
            // label_ServersList_GroupSelection
            // 
            this.label_ServersList_GroupSelection.Location = new System.Drawing.Point(16, 376);
            this.label_ServersList_GroupSelection.Name = "label_ServersList_GroupSelection";
            this.label_ServersList_GroupSelection.Size = new System.Drawing.Size(96, 16);
            this.label_ServersList_GroupSelection.TabIndex = 62;
            this.label_ServersList_GroupSelection.Text = "Group selection:";
            this.label_ServersList_GroupSelection.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // comboBox_ServersList_ServersGroups
            // 
            this.comboBox_ServersList_ServersGroups.Location = new System.Drawing.Point(120, 376);
            this.comboBox_ServersList_ServersGroups.Name = "comboBox_ServersList_ServersGroups";
            this.comboBox_ServersList_ServersGroups.Size = new System.Drawing.Size(216, 21);
            this.comboBox_ServersList_ServersGroups.TabIndex = 64;
            this.comboBox_ServersList_ServersGroups.SelectedIndexChanged += new System.EventHandler(this.comboBox_ServersList_ServersGroups_SelectedIndexChanged);
            // 
            // button_ServersList_Use
            // 
            this.button_ServersList_Use.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ServersList_Use.Location = new System.Drawing.Point(16, 344);
            this.button_ServersList_Use.Name = "button_ServersList_Use";
            this.button_ServersList_Use.Size = new System.Drawing.Size(96, 23);
            this.button_ServersList_Use.TabIndex = 60;
            this.button_ServersList_Use.Text = "Use";
            this.button_ServersList_Use.Click += new System.EventHandler(this.button_ServersList_Use_Click);
            // 
            // button_ServersList_ViewRecord
            // 
            this.button_ServersList_ViewRecord.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ServersList_ViewRecord.Location = new System.Drawing.Point(344, 344);
            this.button_ServersList_ViewRecord.Name = "button_ServersList_ViewRecord";
            this.button_ServersList_ViewRecord.Size = new System.Drawing.Size(104, 23);
            this.button_ServersList_ViewRecord.TabIndex = 63;
            this.button_ServersList_ViewRecord.Text = "View";
            this.button_ServersList_ViewRecord.Click += new System.EventHandler(this.button_ServersList_ViewRecord_Click);
            // 
            // button_ServersList_ClearList
            // 
            this.button_ServersList_ClearList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ServersList_ClearList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_ServersList_ClearList.Location = new System.Drawing.Point(456, 376);
            this.button_ServersList_ClearList.Name = "button_ServersList_ClearList";
            this.button_ServersList_ClearList.Size = new System.Drawing.Size(104, 23);
            this.button_ServersList_ClearList.TabIndex = 66;
            this.button_ServersList_ClearList.Text = "Clear";
            this.button_ServersList_ClearList.Click += new System.EventHandler(this.button_ServersList_ClearList_Click);
            // 
            // listView_ServersList_ServersList
            // 
            this.listView_ServersList_ServersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_NetworkControl_ServerName,
            this.columnHeader_NetworkControl_Host,
            this.columnHeader_NetworkControl_Port,
            this.columnHeader_NetworkControl_ServerLocation,
            this.columnHeader_NetworkControl_GroupMember});
            this.listView_ServersList_ServersList.FullRowSelect = true;
            this.listView_ServersList_ServersList.GridLines = true;
            this.listView_ServersList_ServersList.HideSelection = false;
            this.listView_ServersList_ServersList.HoverSelection = true;
            this.listView_ServersList_ServersList.Location = new System.Drawing.Point(16, 24);
            this.listView_ServersList_ServersList.MultiSelect = false;
            this.listView_ServersList_ServersList.Name = "listView_ServersList_ServersList";
            this.listView_ServersList_ServersList.Size = new System.Drawing.Size(544, 304);
            this.listView_ServersList_ServersList.SmallImageList = this.imageList_ServersList;
            this.listView_ServersList_ServersList.TabIndex = 59;
            this.listView_ServersList_ServersList.UseCompatibleStateImageBehavior = false;
            this.listView_ServersList_ServersList.View = System.Windows.Forms.View.Details;
            this.listView_ServersList_ServersList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ServersList_ServersList_ColumnClick);
            this.listView_ServersList_ServersList.DoubleClick += new System.EventHandler(this.listView_ServersList_ServersList_DoubleClick);
            // 
            // columnHeader_NetworkControl_ServerName
            // 
            this.columnHeader_NetworkControl_ServerName.Text = "Server Name";
            this.columnHeader_NetworkControl_ServerName.Width = 120;
            // 
            // columnHeader_NetworkControl_Host
            // 
            this.columnHeader_NetworkControl_Host.Text = "Host";
            this.columnHeader_NetworkControl_Host.Width = 130;
            // 
            // columnHeader_NetworkControl_Port
            // 
            this.columnHeader_NetworkControl_Port.Text = "Port";
            // 
            // columnHeader_NetworkControl_ServerLocation
            // 
            this.columnHeader_NetworkControl_ServerLocation.Text = "Location";
            this.columnHeader_NetworkControl_ServerLocation.Width = 100;
            // 
            // columnHeader_NetworkControl_GroupMember
            // 
            this.columnHeader_NetworkControl_GroupMember.Text = "Group";
            this.columnHeader_NetworkControl_GroupMember.Width = 110;
            // 
            // imageList_ServersList
            // 
            this.imageList_ServersList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_ServersList.ImageStream")));
            this.imageList_ServersList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_ServersList.Images.SetKeyName(0, "");
            this.imageList_ServersList.Images.SetKeyName(1, "");
            // 
            // button_ServersList_AddRecord
            // 
            this.button_ServersList_AddRecord.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ServersList_AddRecord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_ServersList_AddRecord.Location = new System.Drawing.Point(120, 344);
            this.button_ServersList_AddRecord.Name = "button_ServersList_AddRecord";
            this.button_ServersList_AddRecord.Size = new System.Drawing.Size(104, 23);
            this.button_ServersList_AddRecord.TabIndex = 61;
            this.button_ServersList_AddRecord.Text = "Add";
            this.button_ServersList_AddRecord.Click += new System.EventHandler(this.button_ServersList_AddRecord_Click);
            // 
            // button_ServersList_RemoveRecord
            // 
            this.button_ServersList_RemoveRecord.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ServersList_RemoveRecord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_ServersList_RemoveRecord.Location = new System.Drawing.Point(344, 376);
            this.button_ServersList_RemoveRecord.Name = "button_ServersList_RemoveRecord";
            this.button_ServersList_RemoveRecord.Size = new System.Drawing.Size(104, 23);
            this.button_ServersList_RemoveRecord.TabIndex = 65;
            this.button_ServersList_RemoveRecord.Text = "Remove";
            this.button_ServersList_RemoveRecord.Click += new System.EventHandler(this.button_ServersList_RemoveServer_Click);
            // 
            // button_ServersList_EditRecord
            // 
            this.button_ServersList_EditRecord.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ServersList_EditRecord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_ServersList_EditRecord.Location = new System.Drawing.Point(232, 344);
            this.button_ServersList_EditRecord.Name = "button_ServersList_EditRecord";
            this.button_ServersList_EditRecord.Size = new System.Drawing.Size(104, 23);
            this.button_ServersList_EditRecord.TabIndex = 62;
            this.button_ServersList_EditRecord.Text = "Edit";
            this.button_ServersList_EditRecord.Click += new System.EventHandler(this.button_ServersList_EditRecord_Click);
            // 
            // groupBox_NetworkControl_ProxyServersList
            // 
            this.groupBox_NetworkControl_ProxyServersList.Controls.Add(this.button_ProxyServersList_Use);
            this.groupBox_NetworkControl_ProxyServersList.Controls.Add(this.button_ProxyServersList_EditRecord);
            this.groupBox_NetworkControl_ProxyServersList.Controls.Add(this.button_ProxyServersList_ClearList);
            this.groupBox_NetworkControl_ProxyServersList.Controls.Add(this.button_ProxyServersList_AddRecord);
            this.groupBox_NetworkControl_ProxyServersList.Controls.Add(this.listView_ProxyServersList_ProxyServersList);
            this.groupBox_NetworkControl_ProxyServersList.Controls.Add(this.button_ProxyServersList_RemoveRecord);
            this.groupBox_NetworkControl_ProxyServersList.Controls.Add(this.button_ProxyServersList_ViewRecord);
            this.groupBox_NetworkControl_ProxyServersList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_NetworkControl_ProxyServersList.Location = new System.Drawing.Point(600, 248);
            this.groupBox_NetworkControl_ProxyServersList.Name = "groupBox_NetworkControl_ProxyServersList";
            this.groupBox_NetworkControl_ProxyServersList.Size = new System.Drawing.Size(336, 312);
            this.groupBox_NetworkControl_ProxyServersList.TabIndex = 52;
            this.groupBox_NetworkControl_ProxyServersList.TabStop = false;
            this.groupBox_NetworkControl_ProxyServersList.Text = "Proxy Servers list";
            // 
            // button_ProxyServersList_Use
            // 
            this.button_ProxyServersList_Use.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ProxyServersList_Use.Location = new System.Drawing.Point(16, 240);
            this.button_ProxyServersList_Use.Name = "button_ProxyServersList_Use";
            this.button_ProxyServersList_Use.Size = new System.Drawing.Size(96, 24);
            this.button_ProxyServersList_Use.TabIndex = 50;
            this.button_ProxyServersList_Use.Text = "Use";
            this.button_ProxyServersList_Use.Click += new System.EventHandler(this.button_ProxyServersList_Use_Click);
            // 
            // button_ProxyServersList_EditRecord
            // 
            this.button_ProxyServersList_EditRecord.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ProxyServersList_EditRecord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_ProxyServersList_EditRecord.Location = new System.Drawing.Point(224, 240);
            this.button_ProxyServersList_EditRecord.Name = "button_ProxyServersList_EditRecord";
            this.button_ProxyServersList_EditRecord.Size = new System.Drawing.Size(96, 23);
            this.button_ProxyServersList_EditRecord.TabIndex = 52;
            this.button_ProxyServersList_EditRecord.Text = "Edit";
            this.button_ProxyServersList_EditRecord.Click += new System.EventHandler(this.button_ProxyServersList_EditRecord_Click);
            // 
            // button_ProxyServersList_ClearList
            // 
            this.button_ProxyServersList_ClearList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ProxyServersList_ClearList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_ProxyServersList_ClearList.Location = new System.Drawing.Point(224, 272);
            this.button_ProxyServersList_ClearList.Name = "button_ProxyServersList_ClearList";
            this.button_ProxyServersList_ClearList.Size = new System.Drawing.Size(96, 23);
            this.button_ProxyServersList_ClearList.TabIndex = 55;
            this.button_ProxyServersList_ClearList.Text = "Clear";
            this.button_ProxyServersList_ClearList.Click += new System.EventHandler(this.button_ProxyServersList_ClearList_Click);
            // 
            // button_ProxyServersList_AddRecord
            // 
            this.button_ProxyServersList_AddRecord.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ProxyServersList_AddRecord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_ProxyServersList_AddRecord.Location = new System.Drawing.Point(120, 240);
            this.button_ProxyServersList_AddRecord.Name = "button_ProxyServersList_AddRecord";
            this.button_ProxyServersList_AddRecord.Size = new System.Drawing.Size(96, 23);
            this.button_ProxyServersList_AddRecord.TabIndex = 51;
            this.button_ProxyServersList_AddRecord.Text = "Add";
            this.button_ProxyServersList_AddRecord.Click += new System.EventHandler(this.button_ProxyServersList_AddRecord_Click);
            // 
            // listView_ProxyServersList_ProxyServersList
            // 
            this.listView_ProxyServersList_ProxyServersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ProxyServersList_Title,
            this.columnHeader_ProxyServersList_Host,
            this.columnHeader_ProxyServersList_Port});
            this.listView_ProxyServersList_ProxyServersList.FullRowSelect = true;
            this.listView_ProxyServersList_ProxyServersList.GridLines = true;
            this.listView_ProxyServersList_ProxyServersList.HideSelection = false;
            this.listView_ProxyServersList_ProxyServersList.HoverSelection = true;
            this.listView_ProxyServersList_ProxyServersList.Location = new System.Drawing.Point(16, 24);
            this.listView_ProxyServersList_ProxyServersList.MultiSelect = false;
            this.listView_ProxyServersList_ProxyServersList.Name = "listView_ProxyServersList_ProxyServersList";
            this.listView_ProxyServersList_ProxyServersList.Size = new System.Drawing.Size(304, 200);
            this.listView_ProxyServersList_ProxyServersList.TabIndex = 52;
            this.listView_ProxyServersList_ProxyServersList.UseCompatibleStateImageBehavior = false;
            this.listView_ProxyServersList_ProxyServersList.View = System.Windows.Forms.View.Details;
            this.listView_ProxyServersList_ProxyServersList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ProxyServersList_ProxyServersList_ColumnClick);
            this.listView_ProxyServersList_ProxyServersList.DoubleClick += new System.EventHandler(this.listView_ProxyServersList_ProxyServersList_DoubleClick);
            // 
            // columnHeader_ProxyServersList_Title
            // 
            this.columnHeader_ProxyServersList_Title.Text = "Title";
            this.columnHeader_ProxyServersList_Title.Width = 110;
            // 
            // columnHeader_ProxyServersList_Host
            // 
            this.columnHeader_ProxyServersList_Host.Text = "Host";
            this.columnHeader_ProxyServersList_Host.Width = 110;
            // 
            // columnHeader_ProxyServersList_Port
            // 
            this.columnHeader_ProxyServersList_Port.Text = "Port";
            // 
            // button_ProxyServersList_RemoveRecord
            // 
            this.button_ProxyServersList_RemoveRecord.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ProxyServersList_RemoveRecord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_ProxyServersList_RemoveRecord.Location = new System.Drawing.Point(120, 272);
            this.button_ProxyServersList_RemoveRecord.Name = "button_ProxyServersList_RemoveRecord";
            this.button_ProxyServersList_RemoveRecord.Size = new System.Drawing.Size(96, 23);
            this.button_ProxyServersList_RemoveRecord.TabIndex = 54;
            this.button_ProxyServersList_RemoveRecord.Text = "Remove";
            this.button_ProxyServersList_RemoveRecord.Click += new System.EventHandler(this.button_ProxyServersList_RemoveRecord_Click);
            // 
            // button_ProxyServersList_ViewRecord
            // 
            this.button_ProxyServersList_ViewRecord.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ProxyServersList_ViewRecord.Location = new System.Drawing.Point(16, 272);
            this.button_ProxyServersList_ViewRecord.Name = "button_ProxyServersList_ViewRecord";
            this.button_ProxyServersList_ViewRecord.Size = new System.Drawing.Size(96, 24);
            this.button_ProxyServersList_ViewRecord.TabIndex = 53;
            this.button_ProxyServersList_ViewRecord.Text = "View";
            this.button_ProxyServersList_ViewRecord.Click += new System.EventHandler(this.button_ProxyServersList_ViewRecord_Click);
            // 
            // tabPage_FileManager
            // 
            this.tabPage_FileManager.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_FileManager.Controls.Add(this.button_FileManager_Properties);
            this.tabPage_FileManager.Controls.Add(this.label_FileManager_CurrentFolder);
            this.tabPage_FileManager.Controls.Add(this.textBox_FileManager_CurrentPath);
            this.tabPage_FileManager.Controls.Add(this.button_FileManager_Execute);
            this.tabPage_FileManager.Controls.Add(this.button_FileManager_NewFolder);
            this.tabPage_FileManager.Controls.Add(this.button_FileManager_Rename);
            this.tabPage_FileManager.Controls.Add(this.button_FileManager_Delete);
            this.tabPage_FileManager.Controls.Add(this.button_FileManager_Upload);
            this.tabPage_FileManager.Controls.Add(this.button_FileManager_Download);
            this.tabPage_FileManager.Controls.Add(this.button_FileManager_Refresh);
            this.tabPage_FileManager.Controls.Add(this.button_FileManager_DirUp);
            this.tabPage_FileManager.Controls.Add(this.label_FileManager_LogicalDrives);
            this.tabPage_FileManager.Controls.Add(this.comboBox_FileManager_LogicalDrives);
            this.tabPage_FileManager.Controls.Add(this.listView_FileManager_FileManager);
            this.tabPage_FileManager.Location = new System.Drawing.Point(4, 40);
            this.tabPage_FileManager.Name = "tabPage_FileManager";
            this.tabPage_FileManager.Size = new System.Drawing.Size(944, 587);
            this.tabPage_FileManager.TabIndex = 1;
            this.tabPage_FileManager.Text = "File Manger";
            // 
            // button_FileManager_Properties
            // 
            this.button_FileManager_Properties.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_FileManager_Properties.Location = new System.Drawing.Point(840, 32);
            this.button_FileManager_Properties.Name = "button_FileManager_Properties";
            this.button_FileManager_Properties.Size = new System.Drawing.Size(96, 23);
            this.button_FileManager_Properties.TabIndex = 14;
            this.button_FileManager_Properties.Text = "Properties";
            this.button_FileManager_Properties.Click += new System.EventHandler(this.button_FileManager_Properties_Click);
            // 
            // label_FileManager_CurrentFolder
            // 
            this.label_FileManager_CurrentFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label_FileManager_CurrentFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_FileManager_CurrentFolder.Location = new System.Drawing.Point(232, 13);
            this.label_FileManager_CurrentFolder.Name = "label_FileManager_CurrentFolder";
            this.label_FileManager_CurrentFolder.Size = new System.Drawing.Size(88, 16);
            this.label_FileManager_CurrentFolder.TabIndex = 13;
            this.label_FileManager_CurrentFolder.Text = "Current Folder:";
            // 
            // textBox_FileManager_CurrentPath
            // 
            this.textBox_FileManager_CurrentPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.textBox_FileManager_CurrentPath.Location = new System.Drawing.Point(320, 8);
            this.textBox_FileManager_CurrentPath.Name = "textBox_FileManager_CurrentPath";
            this.textBox_FileManager_CurrentPath.ReadOnly = true;
            this.textBox_FileManager_CurrentPath.Size = new System.Drawing.Size(616, 18);
            this.textBox_FileManager_CurrentPath.TabIndex = 12;
            // 
            // button_FileManager_Execute
            // 
            this.button_FileManager_Execute.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_FileManager_Execute.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_FileManager_Execute.Location = new System.Drawing.Point(736, 32);
            this.button_FileManager_Execute.Name = "button_FileManager_Execute";
            this.button_FileManager_Execute.Size = new System.Drawing.Size(96, 23);
            this.button_FileManager_Execute.TabIndex = 10;
            this.button_FileManager_Execute.Text = "Execute";
            this.button_FileManager_Execute.Click += new System.EventHandler(this.button_FileManager_Execute_Click);
            // 
            // button_FileManager_NewFolder
            // 
            this.button_FileManager_NewFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_FileManager_NewFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_FileManager_NewFolder.Location = new System.Drawing.Point(632, 32);
            this.button_FileManager_NewFolder.Name = "button_FileManager_NewFolder";
            this.button_FileManager_NewFolder.Size = new System.Drawing.Size(96, 23);
            this.button_FileManager_NewFolder.TabIndex = 9;
            this.button_FileManager_NewFolder.Text = "New Folder";
            this.button_FileManager_NewFolder.Click += new System.EventHandler(this.button_FileManager_NewFolder_Click);
            // 
            // button_FileManager_Rename
            // 
            this.button_FileManager_Rename.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_FileManager_Rename.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_FileManager_Rename.Location = new System.Drawing.Point(528, 32);
            this.button_FileManager_Rename.Name = "button_FileManager_Rename";
            this.button_FileManager_Rename.Size = new System.Drawing.Size(96, 23);
            this.button_FileManager_Rename.TabIndex = 8;
            this.button_FileManager_Rename.Text = "Rename";
            this.button_FileManager_Rename.Click += new System.EventHandler(this.button_FileManager_Rename_Click);
            // 
            // button_FileManager_Delete
            // 
            this.button_FileManager_Delete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_FileManager_Delete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_FileManager_Delete.Location = new System.Drawing.Point(424, 32);
            this.button_FileManager_Delete.Name = "button_FileManager_Delete";
            this.button_FileManager_Delete.Size = new System.Drawing.Size(96, 23);
            this.button_FileManager_Delete.TabIndex = 7;
            this.button_FileManager_Delete.Text = "Delete";
            this.button_FileManager_Delete.Click += new System.EventHandler(this.button_FileManager_Delete_Click);
            // 
            // button_FileManager_Upload
            // 
            this.button_FileManager_Upload.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button_FileManager_Upload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_FileManager_Upload.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_FileManager_Upload.Location = new System.Drawing.Point(320, 32);
            this.button_FileManager_Upload.Name = "button_FileManager_Upload";
            this.button_FileManager_Upload.Size = new System.Drawing.Size(96, 23);
            this.button_FileManager_Upload.TabIndex = 6;
            this.button_FileManager_Upload.Text = "Upload";
            this.button_FileManager_Upload.Click += new System.EventHandler(this.button_FileManager_Upload_Click);
            // 
            // button_FileManager_Download
            // 
            this.button_FileManager_Download.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_FileManager_Download.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_FileManager_Download.Location = new System.Drawing.Point(216, 32);
            this.button_FileManager_Download.Name = "button_FileManager_Download";
            this.button_FileManager_Download.Size = new System.Drawing.Size(96, 23);
            this.button_FileManager_Download.TabIndex = 5;
            this.button_FileManager_Download.Text = "Download";
            this.button_FileManager_Download.Click += new System.EventHandler(this.button_FileManager_Download_Click);
            // 
            // button_FileManager_Refresh
            // 
            this.button_FileManager_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_FileManager_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_FileManager_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("button_FileManager_Refresh.Image")));
            this.button_FileManager_Refresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_FileManager_Refresh.Location = new System.Drawing.Point(159, 8);
            this.button_FileManager_Refresh.Name = "button_FileManager_Refresh";
            this.button_FileManager_Refresh.Size = new System.Drawing.Size(48, 48);
            this.button_FileManager_Refresh.TabIndex = 4;
            this.button_FileManager_Refresh.Click += new System.EventHandler(this.button_FileManager_Refresh_Click);
            // 
            // button_FileManager_DirUp
            // 
            this.button_FileManager_DirUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_FileManager_DirUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_FileManager_DirUp.Image = ((System.Drawing.Image)(resources.GetObject("button_FileManager_DirUp.Image")));
            this.button_FileManager_DirUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_FileManager_DirUp.Location = new System.Drawing.Point(112, 8);
            this.button_FileManager_DirUp.Name = "button_FileManager_DirUp";
            this.button_FileManager_DirUp.Size = new System.Drawing.Size(48, 48);
            this.button_FileManager_DirUp.TabIndex = 3;
            this.button_FileManager_DirUp.Click += new System.EventHandler(this.button_FileManager_DirUp_Click);
            // 
            // label_FileManager_LogicalDrives
            // 
            this.label_FileManager_LogicalDrives.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_FileManager_LogicalDrives.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_FileManager_LogicalDrives.Location = new System.Drawing.Point(8, 16);
            this.label_FileManager_LogicalDrives.Name = "label_FileManager_LogicalDrives";
            this.label_FileManager_LogicalDrives.Size = new System.Drawing.Size(96, 16);
            this.label_FileManager_LogicalDrives.TabIndex = 2;
            this.label_FileManager_LogicalDrives.Text = "Logical Drives:";
            // 
            // comboBox_FileManager_LogicalDrives
            // 
            this.comboBox_FileManager_LogicalDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FileManager_LogicalDrives.DropDownWidth = 88;
            this.comboBox_FileManager_LogicalDrives.ItemHeight = 13;
            this.comboBox_FileManager_LogicalDrives.Items.AddRange(new object[] {
            "",
            "",
            "",
            ""});
            this.comboBox_FileManager_LogicalDrives.Location = new System.Drawing.Point(8, 32);
            this.comboBox_FileManager_LogicalDrives.Name = "comboBox_FileManager_LogicalDrives";
            this.comboBox_FileManager_LogicalDrives.Size = new System.Drawing.Size(96, 21);
            this.comboBox_FileManager_LogicalDrives.Sorted = true;
            this.comboBox_FileManager_LogicalDrives.TabIndex = 1;
            this.comboBox_FileManager_LogicalDrives.DropDown += new System.EventHandler(this.comboBox_FileManager_LogicalDrives_DropDown);
            this.comboBox_FileManager_LogicalDrives.SelectedIndexChanged += new System.EventHandler(this.comboBox_FileManager_LogicalDrives_SelectedIndexChanged);
            // 
            // listView_FileManager_FileManager
            // 
            this.listView_FileManager_FileManager.AllowDrop = true;
            this.listView_FileManager_FileManager.BackColor = System.Drawing.SystemColors.Window;
            this.listView_FileManager_FileManager.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_FileManager_ItemName,
            this.columnHeader_FileManager_FileSize,
            this.columnHeader_FileManager_LastFileWriteTime,
            this.columnHeader_FileManager_ItemAttribute,
            this.columnHeader_FileManager_ItemType});
            this.listView_FileManager_FileManager.ContextMenu = this.contextMenu_FileManager_ObjectProperties;
            this.listView_FileManager_FileManager.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.listView_FileManager_FileManager.FullRowSelect = true;
            this.listView_FileManager_FileManager.GridLines = true;
            this.listView_FileManager_FileManager.HideSelection = false;
            this.listView_FileManager_FileManager.Location = new System.Drawing.Point(8, 64);
            this.listView_FileManager_FileManager.Name = "listView_FileManager_FileManager";
            this.listView_FileManager_FileManager.Size = new System.Drawing.Size(928, 504);
            this.listView_FileManager_FileManager.SmallImageList = this.imageList_FileManager;
            this.listView_FileManager_FileManager.TabIndex = 0;
            this.listView_FileManager_FileManager.UseCompatibleStateImageBehavior = false;
            this.listView_FileManager_FileManager.View = System.Windows.Forms.View.Details;
            this.listView_FileManager_FileManager.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_FileManager_FileManager_ColumnClick);
            this.listView_FileManager_FileManager.DoubleClick += new System.EventHandler(this.listView_FileManager_FileManager_DoubleClick);
            this.listView_FileManager_FileManager.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView_FileManager_FileManager_KeyPress);
            // 
            // columnHeader_FileManager_ItemName
            // 
            this.columnHeader_FileManager_ItemName.Text = "Name";
            this.columnHeader_FileManager_ItemName.Width = 260;
            // 
            // columnHeader_FileManager_FileSize
            // 
            this.columnHeader_FileManager_FileSize.Text = "File Size (Bytes)";
            this.columnHeader_FileManager_FileSize.Width = 122;
            // 
            // columnHeader_FileManager_LastFileWriteTime
            // 
            this.columnHeader_FileManager_LastFileWriteTime.Text = "Last Write Time";
            this.columnHeader_FileManager_LastFileWriteTime.Width = 110;
            // 
            // columnHeader_FileManager_ItemAttribute
            // 
            this.columnHeader_FileManager_ItemAttribute.Text = "Attribute";
            this.columnHeader_FileManager_ItemAttribute.Width = 365;
            // 
            // columnHeader_FileManager_ItemType
            // 
            this.columnHeader_FileManager_ItemType.Text = "Type";
            this.columnHeader_FileManager_ItemType.Width = 50;
            // 
            // contextMenu_FileManager_ObjectProperties
            // 
            this.contextMenu_FileManager_ObjectProperties.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_Properties});
            // 
            // menuItem_Properties
            // 
            this.menuItem_Properties.Index = 0;
            this.menuItem_Properties.Text = "Свойства";
            this.menuItem_Properties.Click += new System.EventHandler(this.menuItem_Properties_Click);
            // 
            // imageList_FileManager
            // 
            this.imageList_FileManager.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_FileManager.ImageStream")));
            this.imageList_FileManager.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_FileManager.Images.SetKeyName(0, "");
            this.imageList_FileManager.Images.SetKeyName(1, "");
            // 
            // tabPage_RemoteExecution
            // 
            this.tabPage_RemoteExecution.Controls.Add(this.label_RemoteExecution_Remarks);
            this.tabPage_RemoteExecution.Controls.Add(this.label_RemoteExecution_about5);
            this.tabPage_RemoteExecution.Controls.Add(this.label_RemoteExecution_about4);
            this.tabPage_RemoteExecution.Controls.Add(this.label_RemoteExecution_about3);
            this.tabPage_RemoteExecution.Controls.Add(this.label_RemoteExecution_about2);
            this.tabPage_RemoteExecution.Controls.Add(this.label_RemoteExecution_about1);
            this.tabPage_RemoteExecution.Controls.Add(this.splitter_RemoteExecution_Remarks);
            this.tabPage_RemoteExecution.Controls.Add(this.groupBox_RemoteExecution_ExecuteParameters);
            this.tabPage_RemoteExecution.Location = new System.Drawing.Point(4, 40);
            this.tabPage_RemoteExecution.Name = "tabPage_RemoteExecution";
            this.tabPage_RemoteExecution.Size = new System.Drawing.Size(944, 587);
            this.tabPage_RemoteExecution.TabIndex = 2;
            this.tabPage_RemoteExecution.Text = "Remote Execute";
            // 
            // label_RemoteExecution_Remarks
            // 
            this.label_RemoteExecution_Remarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RemoteExecution_Remarks.BackColor = System.Drawing.Color.LightGray;
            this.label_RemoteExecution_Remarks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteExecution_Remarks.Location = new System.Drawing.Point(696, 16);
            this.label_RemoteExecution_Remarks.Name = "label_RemoteExecution_Remarks";
            this.label_RemoteExecution_Remarks.Size = new System.Drawing.Size(100, 16);
            this.label_RemoteExecution_Remarks.TabIndex = 25;
            this.label_RemoteExecution_Remarks.Text = "Remarks:";
            // 
            // label_RemoteExecution_about5
            // 
            this.label_RemoteExecution_about5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RemoteExecution_about5.BackColor = System.Drawing.Color.LightGray;
            this.label_RemoteExecution_about5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteExecution_about5.Location = new System.Drawing.Point(592, 256);
            this.label_RemoteExecution_about5.Name = "label_RemoteExecution_about5";
            this.label_RemoteExecution_about5.Size = new System.Drawing.Size(312, 144);
            this.label_RemoteExecution_about5.TabIndex = 24;
            this.label_RemoteExecution_about5.Text = resources.GetString("label_RemoteExecution_about5.Text");
            // 
            // label_RemoteExecution_about4
            // 
            this.label_RemoteExecution_about4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RemoteExecution_about4.BackColor = System.Drawing.Color.LightGray;
            this.label_RemoteExecution_about4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteExecution_about4.Location = new System.Drawing.Point(592, 192);
            this.label_RemoteExecution_about4.Name = "label_RemoteExecution_about4";
            this.label_RemoteExecution_about4.Size = new System.Drawing.Size(328, 64);
            this.label_RemoteExecution_about4.TabIndex = 23;
            // 
            // label_RemoteExecution_about3
            // 
            this.label_RemoteExecution_about3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RemoteExecution_about3.BackColor = System.Drawing.Color.LightGray;
            this.label_RemoteExecution_about3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteExecution_about3.Location = new System.Drawing.Point(592, 144);
            this.label_RemoteExecution_about3.Name = "label_RemoteExecution_about3";
            this.label_RemoteExecution_about3.Size = new System.Drawing.Size(328, 40);
            this.label_RemoteExecution_about3.TabIndex = 22;
            // 
            // label_RemoteExecution_about2
            // 
            this.label_RemoteExecution_about2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RemoteExecution_about2.BackColor = System.Drawing.Color.LightGray;
            this.label_RemoteExecution_about2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteExecution_about2.Location = new System.Drawing.Point(592, 96);
            this.label_RemoteExecution_about2.Name = "label_RemoteExecution_about2";
            this.label_RemoteExecution_about2.Size = new System.Drawing.Size(328, 48);
            this.label_RemoteExecution_about2.TabIndex = 21;
            // 
            // label_RemoteExecution_about1
            // 
            this.label_RemoteExecution_about1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RemoteExecution_about1.BackColor = System.Drawing.Color.LightGray;
            this.label_RemoteExecution_about1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteExecution_about1.Location = new System.Drawing.Point(592, 48);
            this.label_RemoteExecution_about1.Name = "label_RemoteExecution_about1";
            this.label_RemoteExecution_about1.Size = new System.Drawing.Size(320, 40);
            this.label_RemoteExecution_about1.TabIndex = 20;
            // 
            // splitter_RemoteExecution_Remarks
            // 
            this.splitter_RemoteExecution_Remarks.BackColor = System.Drawing.Color.LightGray;
            this.splitter_RemoteExecution_Remarks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter_RemoteExecution_Remarks.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter_RemoteExecution_Remarks.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter_RemoteExecution_Remarks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitter_RemoteExecution_Remarks.Location = new System.Drawing.Point(568, 0);
            this.splitter_RemoteExecution_Remarks.Name = "splitter_RemoteExecution_Remarks";
            this.splitter_RemoteExecution_Remarks.Size = new System.Drawing.Size(376, 587);
            this.splitter_RemoteExecution_Remarks.TabIndex = 7;
            this.splitter_RemoteExecution_Remarks.TabStop = false;
            // 
            // groupBox_RemoteExecution_ExecuteParameters
            // 
            this.groupBox_RemoteExecution_ExecuteParameters.Controls.Add(this.button_RemoteExecution_CleanParameters);
            this.groupBox_RemoteExecution_ExecuteParameters.Controls.Add(this.listView_RemoteExecution_WorkingFolder_ListOfPresets);
            this.groupBox_RemoteExecution_ExecuteParameters.Controls.Add(this.label_RemoteExecution_WindowStyle);
            this.groupBox_RemoteExecution_ExecuteParameters.Controls.Add(this.label_RemoteExecution_WorkingFolder);
            this.groupBox_RemoteExecution_ExecuteParameters.Controls.Add(this.label_RemoteExecution_CommandLineArguments);
            this.groupBox_RemoteExecution_ExecuteParameters.Controls.Add(this.label_RemoteExecution_FileNameWithPath);
            this.groupBox_RemoteExecution_ExecuteParameters.Controls.Add(this.comboBox_RemoteExecution_WindowStyle);
            this.groupBox_RemoteExecution_ExecuteParameters.Controls.Add(this.checkBox_RemoteExecution_ShowErrorDialog);
            this.groupBox_RemoteExecution_ExecuteParameters.Controls.Add(this.checkBox_RemoteExecution_NotCreateWindow);
            this.groupBox_RemoteExecution_ExecuteParameters.Controls.Add(this.checkBox_RemoteExecution_UseShellExecute);
            this.groupBox_RemoteExecution_ExecuteParameters.Controls.Add(this.textBox_RemoteExecution_WorkingFolder);
            this.groupBox_RemoteExecution_ExecuteParameters.Controls.Add(this.textBox_RemoteExecution_CommandLineArguments);
            this.groupBox_RemoteExecution_ExecuteParameters.Controls.Add(this.textBox_RemoteExecution_FileNameWithPath);
            this.groupBox_RemoteExecution_ExecuteParameters.Controls.Add(this.button_RemoteExecution_Execute);
            this.groupBox_RemoteExecution_ExecuteParameters.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_RemoteExecution_ExecuteParameters.Location = new System.Drawing.Point(8, 8);
            this.groupBox_RemoteExecution_ExecuteParameters.Name = "groupBox_RemoteExecution_ExecuteParameters";
            this.groupBox_RemoteExecution_ExecuteParameters.Size = new System.Drawing.Size(544, 552);
            this.groupBox_RemoteExecution_ExecuteParameters.TabIndex = 0;
            this.groupBox_RemoteExecution_ExecuteParameters.TabStop = false;
            this.groupBox_RemoteExecution_ExecuteParameters.Text = "Execute Parameters";
            // 
            // button_RemoteExecution_CleanParameters
            // 
            this.button_RemoteExecution_CleanParameters.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_RemoteExecution_CleanParameters.Image = ((System.Drawing.Image)(resources.GetObject("button_RemoteExecution_CleanParameters.Image")));
            this.button_RemoteExecution_CleanParameters.Location = new System.Drawing.Point(40, 328);
            this.button_RemoteExecution_CleanParameters.Name = "button_RemoteExecution_CleanParameters";
            this.button_RemoteExecution_CleanParameters.Size = new System.Drawing.Size(32, 32);
            this.button_RemoteExecution_CleanParameters.TabIndex = 13;
            this.button_RemoteExecution_CleanParameters.Click += new System.EventHandler(this.textBox_RemoteExecution_CleanParameters_Click);
            // 
            // listView_RemoteExecution_WorkingFolder_ListOfPresets
            // 
            this.listView_RemoteExecution_WorkingFolder_ListOfPresets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Preset});
            this.listView_RemoteExecution_WorkingFolder_ListOfPresets.FullRowSelect = true;
            this.listView_RemoteExecution_WorkingFolder_ListOfPresets.GridLines = true;
            this.listView_RemoteExecution_WorkingFolder_ListOfPresets.Location = new System.Drawing.Point(272, 192);
            this.listView_RemoteExecution_WorkingFolder_ListOfPresets.Name = "listView_RemoteExecution_WorkingFolder_ListOfPresets";
            this.listView_RemoteExecution_WorkingFolder_ListOfPresets.Size = new System.Drawing.Size(256, 344);
            this.listView_RemoteExecution_WorkingFolder_ListOfPresets.SmallImageList = this.imageList_FastLaunchPresets_SmallIcons;
            this.listView_RemoteExecution_WorkingFolder_ListOfPresets.TabIndex = 12;
            this.listView_RemoteExecution_WorkingFolder_ListOfPresets.UseCompatibleStateImageBehavior = false;
            this.listView_RemoteExecution_WorkingFolder_ListOfPresets.View = System.Windows.Forms.View.Details;
            this.listView_RemoteExecution_WorkingFolder_ListOfPresets.SelectedIndexChanged += new System.EventHandler(this.listView_RemoteExecution_WorkingFolder_ListOfPresets_SelectedIndexChanged);
            // 
            // columnHeader_Preset
            // 
            this.columnHeader_Preset.Text = "";
            this.columnHeader_Preset.Width = 235;
            // 
            // imageList_FastLaunchPresets_SmallIcons
            // 
            this.imageList_FastLaunchPresets_SmallIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_FastLaunchPresets_SmallIcons.ImageStream")));
            this.imageList_FastLaunchPresets_SmallIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_FastLaunchPresets_SmallIcons.Images.SetKeyName(0, "");
            this.imageList_FastLaunchPresets_SmallIcons.Images.SetKeyName(1, "");
            this.imageList_FastLaunchPresets_SmallIcons.Images.SetKeyName(2, "");
            this.imageList_FastLaunchPresets_SmallIcons.Images.SetKeyName(3, "");
            this.imageList_FastLaunchPresets_SmallIcons.Images.SetKeyName(4, "");
            this.imageList_FastLaunchPresets_SmallIcons.Images.SetKeyName(5, "");
            this.imageList_FastLaunchPresets_SmallIcons.Images.SetKeyName(6, "");
            this.imageList_FastLaunchPresets_SmallIcons.Images.SetKeyName(7, "");
            this.imageList_FastLaunchPresets_SmallIcons.Images.SetKeyName(8, "");
            this.imageList_FastLaunchPresets_SmallIcons.Images.SetKeyName(9, "");
            this.imageList_FastLaunchPresets_SmallIcons.Images.SetKeyName(10, "");
            this.imageList_FastLaunchPresets_SmallIcons.Images.SetKeyName(11, "");
            this.imageList_FastLaunchPresets_SmallIcons.Images.SetKeyName(12, "");
            this.imageList_FastLaunchPresets_SmallIcons.Images.SetKeyName(13, "");
            this.imageList_FastLaunchPresets_SmallIcons.Images.SetKeyName(14, "");
            // 
            // label_RemoteExecution_WindowStyle
            // 
            this.label_RemoteExecution_WindowStyle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteExecution_WindowStyle.Location = new System.Drawing.Point(16, 296);
            this.label_RemoteExecution_WindowStyle.Name = "label_RemoteExecution_WindowStyle";
            this.label_RemoteExecution_WindowStyle.Size = new System.Drawing.Size(88, 16);
            this.label_RemoteExecution_WindowStyle.TabIndex = 11;
            this.label_RemoteExecution_WindowStyle.Text = "Window Style:";
            // 
            // label_RemoteExecution_WorkingFolder
            // 
            this.label_RemoteExecution_WorkingFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_RemoteExecution_WorkingFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteExecution_WorkingFolder.Location = new System.Drawing.Point(16, 144);
            this.label_RemoteExecution_WorkingFolder.Name = "label_RemoteExecution_WorkingFolder";
            this.label_RemoteExecution_WorkingFolder.Size = new System.Drawing.Size(208, 16);
            this.label_RemoteExecution_WorkingFolder.TabIndex = 10;
            this.label_RemoteExecution_WorkingFolder.Text = "Working Folder:";
            // 
            // label_RemoteExecution_CommandLineArguments
            // 
            this.label_RemoteExecution_CommandLineArguments.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_RemoteExecution_CommandLineArguments.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteExecution_CommandLineArguments.Location = new System.Drawing.Point(16, 88);
            this.label_RemoteExecution_CommandLineArguments.Name = "label_RemoteExecution_CommandLineArguments";
            this.label_RemoteExecution_CommandLineArguments.Size = new System.Drawing.Size(208, 16);
            this.label_RemoteExecution_CommandLineArguments.TabIndex = 9;
            this.label_RemoteExecution_CommandLineArguments.Text = "Command Lisne arguments:";
            // 
            // label_RemoteExecution_FileNameWithPath
            // 
            this.label_RemoteExecution_FileNameWithPath.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_RemoteExecution_FileNameWithPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteExecution_FileNameWithPath.Location = new System.Drawing.Point(16, 32);
            this.label_RemoteExecution_FileNameWithPath.Name = "label_RemoteExecution_FileNameWithPath";
            this.label_RemoteExecution_FileNameWithPath.Size = new System.Drawing.Size(208, 16);
            this.label_RemoteExecution_FileNameWithPath.TabIndex = 8;
            this.label_RemoteExecution_FileNameWithPath.Text = "File Name (with Path):";
            // 
            // comboBox_RemoteExecution_WindowStyle
            // 
            this.comboBox_RemoteExecution_WindowStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RemoteExecution_WindowStyle.ItemHeight = 13;
            this.comboBox_RemoteExecution_WindowStyle.Items.AddRange(new object[] {
            "Hidden",
            "Maximized",
            "Minimized",
            "Normal"});
            this.comboBox_RemoteExecution_WindowStyle.Location = new System.Drawing.Point(104, 296);
            this.comboBox_RemoteExecution_WindowStyle.Name = "comboBox_RemoteExecution_WindowStyle";
            this.comboBox_RemoteExecution_WindowStyle.Size = new System.Drawing.Size(144, 21);
            this.comboBox_RemoteExecution_WindowStyle.TabIndex = 7;
            this.comboBox_RemoteExecution_WindowStyle.SelectedIndexChanged += new System.EventHandler(this.comboBox_RemoteExecution_WindowStyle_SelectedIndexChanged);
            // 
            // checkBox_RemoteExecution_ShowErrorDialog
            // 
            this.checkBox_RemoteExecution_ShowErrorDialog.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_RemoteExecution_ShowErrorDialog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_RemoteExecution_ShowErrorDialog.Location = new System.Drawing.Point(16, 264);
            this.checkBox_RemoteExecution_ShowErrorDialog.Name = "checkBox_RemoteExecution_ShowErrorDialog";
            this.checkBox_RemoteExecution_ShowErrorDialog.Size = new System.Drawing.Size(232, 16);
            this.checkBox_RemoteExecution_ShowErrorDialog.TabIndex = 5;
            this.checkBox_RemoteExecution_ShowErrorDialog.Text = "Show Error Dialog";
            this.checkBox_RemoteExecution_ShowErrorDialog.CheckedChanged += new System.EventHandler(this.checkBox_RemoteExecution_ShowErrorDialog_CheckedChanged);
            // 
            // checkBox_RemoteExecution_NotCreateWindow
            // 
            this.checkBox_RemoteExecution_NotCreateWindow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_RemoteExecution_NotCreateWindow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_RemoteExecution_NotCreateWindow.Location = new System.Drawing.Point(16, 232);
            this.checkBox_RemoteExecution_NotCreateWindow.Name = "checkBox_RemoteExecution_NotCreateWindow";
            this.checkBox_RemoteExecution_NotCreateWindow.Size = new System.Drawing.Size(232, 16);
            this.checkBox_RemoteExecution_NotCreateWindow.TabIndex = 4;
            this.checkBox_RemoteExecution_NotCreateWindow.Text = "To not create Window";
            // 
            // checkBox_RemoteExecution_UseShellExecute
            // 
            this.checkBox_RemoteExecution_UseShellExecute.Checked = true;
            this.checkBox_RemoteExecution_UseShellExecute.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_RemoteExecution_UseShellExecute.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_RemoteExecution_UseShellExecute.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_RemoteExecution_UseShellExecute.Location = new System.Drawing.Point(16, 200);
            this.checkBox_RemoteExecution_UseShellExecute.Name = "checkBox_RemoteExecution_UseShellExecute";
            this.checkBox_RemoteExecution_UseShellExecute.Size = new System.Drawing.Size(232, 16);
            this.checkBox_RemoteExecution_UseShellExecute.TabIndex = 3;
            this.checkBox_RemoteExecution_UseShellExecute.Text = "Use Shell Execute";
            this.checkBox_RemoteExecution_UseShellExecute.CheckedChanged += new System.EventHandler(this.checkBox_RemoteExecution_UseShellExecute_CheckedChanged);
            // 
            // textBox_RemoteExecution_WorkingFolder
            // 
            this.textBox_RemoteExecution_WorkingFolder.Location = new System.Drawing.Point(16, 160);
            this.textBox_RemoteExecution_WorkingFolder.Name = "textBox_RemoteExecution_WorkingFolder";
            this.textBox_RemoteExecution_WorkingFolder.Size = new System.Drawing.Size(512, 20);
            this.textBox_RemoteExecution_WorkingFolder.TabIndex = 2;
            // 
            // textBox_RemoteExecution_CommandLineArguments
            // 
            this.textBox_RemoteExecution_CommandLineArguments.Location = new System.Drawing.Point(16, 104);
            this.textBox_RemoteExecution_CommandLineArguments.Name = "textBox_RemoteExecution_CommandLineArguments";
            this.textBox_RemoteExecution_CommandLineArguments.Size = new System.Drawing.Size(512, 20);
            this.textBox_RemoteExecution_CommandLineArguments.TabIndex = 1;
            // 
            // textBox_RemoteExecution_FileNameWithPath
            // 
            this.textBox_RemoteExecution_FileNameWithPath.Location = new System.Drawing.Point(16, 48);
            this.textBox_RemoteExecution_FileNameWithPath.Name = "textBox_RemoteExecution_FileNameWithPath";
            this.textBox_RemoteExecution_FileNameWithPath.Size = new System.Drawing.Size(512, 20);
            this.textBox_RemoteExecution_FileNameWithPath.TabIndex = 0;
            // 
            // button_RemoteExecution_Execute
            // 
            this.button_RemoteExecution_Execute.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_RemoteExecution_Execute.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_RemoteExecution_Execute.Location = new System.Drawing.Point(104, 336);
            this.button_RemoteExecution_Execute.Name = "button_RemoteExecution_Execute";
            this.button_RemoteExecution_Execute.Size = new System.Drawing.Size(144, 23);
            this.button_RemoteExecution_Execute.TabIndex = 6;
            this.button_RemoteExecution_Execute.Text = "Execute";
            this.button_RemoteExecution_Execute.Click += new System.EventHandler(this.button_RemoteExecution_Execute_Click);
            // 
            // tabPage_ProcessesManager
            // 
            this.tabPage_ProcessesManager.Controls.Add(this.button_ProcessesManager_ActivateWindowOfSelectedProcess);
            this.tabPage_ProcessesManager.Controls.Add(this.button_ProcessesManager_Refresh);
            this.tabPage_ProcessesManager.Controls.Add(this.button_ProcessesManager_KillSelectedProcess);
            this.tabPage_ProcessesManager.Controls.Add(this.listView_ProcessesManager_Processes);
            this.tabPage_ProcessesManager.Controls.Add(this.groupBox_ProcessesManager_ProcessPriority);
            this.tabPage_ProcessesManager.Location = new System.Drawing.Point(4, 40);
            this.tabPage_ProcessesManager.Name = "tabPage_ProcessesManager";
            this.tabPage_ProcessesManager.Size = new System.Drawing.Size(944, 587);
            this.tabPage_ProcessesManager.TabIndex = 3;
            this.tabPage_ProcessesManager.Text = "Processes Manager";
            // 
            // button_ProcessesManager_ActivateWindowOfSelectedProcess
            // 
            this.button_ProcessesManager_ActivateWindowOfSelectedProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ProcessesManager_ActivateWindowOfSelectedProcess.Enabled = false;
            this.button_ProcessesManager_ActivateWindowOfSelectedProcess.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ProcessesManager_ActivateWindowOfSelectedProcess.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_ProcessesManager_ActivateWindowOfSelectedProcess.Location = new System.Drawing.Point(352, 24);
            this.button_ProcessesManager_ActivateWindowOfSelectedProcess.Name = "button_ProcessesManager_ActivateWindowOfSelectedProcess";
            this.button_ProcessesManager_ActivateWindowOfSelectedProcess.Size = new System.Drawing.Size(128, 23);
            this.button_ProcessesManager_ActivateWindowOfSelectedProcess.TabIndex = 12;
            this.button_ProcessesManager_ActivateWindowOfSelectedProcess.Text = "Activate Window";
            this.button_ProcessesManager_ActivateWindowOfSelectedProcess.Visible = false;
            this.button_ProcessesManager_ActivateWindowOfSelectedProcess.Click += new System.EventHandler(this.button_ProcessesManager_ActivateWindowOfSelectedProcess_Click);
            // 
            // button_ProcessesManager_Refresh
            // 
            this.button_ProcessesManager_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ProcessesManager_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_ProcessesManager_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("button_ProcessesManager_Refresh.Image")));
            this.button_ProcessesManager_Refresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_ProcessesManager_Refresh.Location = new System.Drawing.Point(8, 8);
            this.button_ProcessesManager_Refresh.Name = "button_ProcessesManager_Refresh";
            this.button_ProcessesManager_Refresh.Size = new System.Drawing.Size(48, 48);
            this.button_ProcessesManager_Refresh.TabIndex = 10;
            this.button_ProcessesManager_Refresh.Click += new System.EventHandler(this.button_ProcessesManager_Refresh_Click);
            // 
            // button_ProcessesManager_KillSelectedProcess
            // 
            this.button_ProcessesManager_KillSelectedProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ProcessesManager_KillSelectedProcess.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ProcessesManager_KillSelectedProcess.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_ProcessesManager_KillSelectedProcess.Location = new System.Drawing.Point(264, 24);
            this.button_ProcessesManager_KillSelectedProcess.Name = "button_ProcessesManager_KillSelectedProcess";
            this.button_ProcessesManager_KillSelectedProcess.Size = new System.Drawing.Size(75, 23);
            this.button_ProcessesManager_KillSelectedProcess.TabIndex = 11;
            this.button_ProcessesManager_KillSelectedProcess.Text = "Kill";
            this.button_ProcessesManager_KillSelectedProcess.Click += new System.EventHandler(this.button_ProcessesManager_KillSelectedProcess_Click);
            // 
            // listView_ProcessesManager_Processes
            // 
            this.listView_ProcessesManager_Processes.AllowColumnReorder = true;
            this.listView_ProcessesManager_Processes.AutoArrange = false;
            this.listView_ProcessesManager_Processes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ProcessesManager_ItemName,
            this.columnHeader_ProcessesManager_ProcessPriority,
            this.columnHeader_ProcessesManager_ThreadsAmount,
            this.columnHeader_ProcessesManager_PID,
            this.columnHeader_ProcessesManager_ProcessStatus,
            this.columnHeader_ProcessesManager_MemoryUsage,
            this.columnHeader_ProcessesManager_MainWindowTitle});
            this.listView_ProcessesManager_Processes.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.listView_ProcessesManager_Processes.FullRowSelect = true;
            this.listView_ProcessesManager_Processes.GridLines = true;
            this.listView_ProcessesManager_Processes.HideSelection = false;
            this.listView_ProcessesManager_Processes.LabelWrap = false;
            this.listView_ProcessesManager_Processes.Location = new System.Drawing.Point(8, 64);
            this.listView_ProcessesManager_Processes.MultiSelect = false;
            this.listView_ProcessesManager_Processes.Name = "listView_ProcessesManager_Processes";
            this.listView_ProcessesManager_Processes.Size = new System.Drawing.Size(928, 510);
            this.listView_ProcessesManager_Processes.SmallImageList = this.imageList_ProcessesList;
            this.listView_ProcessesManager_Processes.TabIndex = 9;
            this.listView_ProcessesManager_Processes.UseCompatibleStateImageBehavior = false;
            this.listView_ProcessesManager_Processes.View = System.Windows.Forms.View.Details;
            this.listView_ProcessesManager_Processes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ProcessesManager_Processes_ColumnClick);
            this.listView_ProcessesManager_Processes.Click += new System.EventHandler(this.listView_ProcessesManager_Processes_Click);
            // 
            // columnHeader_ProcessesManager_ItemName
            // 
            this.columnHeader_ProcessesManager_ItemName.Text = "Image Name";
            this.columnHeader_ProcessesManager_ItemName.Width = 140;
            // 
            // columnHeader_ProcessesManager_ProcessPriority
            // 
            this.columnHeader_ProcessesManager_ProcessPriority.Text = "Priority";
            this.columnHeader_ProcessesManager_ProcessPriority.Width = 100;
            // 
            // columnHeader_ProcessesManager_ThreadsAmount
            // 
            this.columnHeader_ProcessesManager_ThreadsAmount.Text = "Threads";
            this.columnHeader_ProcessesManager_ThreadsAmount.Width = 70;
            // 
            // columnHeader_ProcessesManager_PID
            // 
            this.columnHeader_ProcessesManager_PID.Text = "PID";
            // 
            // columnHeader_ProcessesManager_ProcessStatus
            // 
            this.columnHeader_ProcessesManager_ProcessStatus.Text = "Status";
            this.columnHeader_ProcessesManager_ProcessStatus.Width = 100;
            // 
            // columnHeader_ProcessesManager_MemoryUsage
            // 
            this.columnHeader_ProcessesManager_MemoryUsage.Text = "Memory Usage";
            this.columnHeader_ProcessesManager_MemoryUsage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader_ProcessesManager_MemoryUsage.Width = 100;
            // 
            // columnHeader_ProcessesManager_MainWindowTitle
            // 
            this.columnHeader_ProcessesManager_MainWindowTitle.Text = "Title of Main Window";
            this.columnHeader_ProcessesManager_MainWindowTitle.Width = 340;
            // 
            // imageList_ProcessesList
            // 
            this.imageList_ProcessesList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_ProcessesList.ImageStream")));
            this.imageList_ProcessesList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_ProcessesList.Images.SetKeyName(0, "");
            // 
            // groupBox_ProcessesManager_ProcessPriority
            // 
            this.groupBox_ProcessesManager_ProcessPriority.Controls.Add(this.comboBox_ProcessesManager_ProcessPriority);
            this.groupBox_ProcessesManager_ProcessPriority.Controls.Add(this.label_ProcessesManager_ProcessPriority);
            this.groupBox_ProcessesManager_ProcessPriority.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_ProcessesManager_ProcessPriority.Location = new System.Drawing.Point(64, 8);
            this.groupBox_ProcessesManager_ProcessPriority.Name = "groupBox_ProcessesManager_ProcessPriority";
            this.groupBox_ProcessesManager_ProcessPriority.Size = new System.Drawing.Size(192, 48);
            this.groupBox_ProcessesManager_ProcessPriority.TabIndex = 8;
            this.groupBox_ProcessesManager_ProcessPriority.TabStop = false;
            this.groupBox_ProcessesManager_ProcessPriority.Text = "Priority";
            // 
            // comboBox_ProcessesManager_ProcessPriority
            // 
            this.comboBox_ProcessesManager_ProcessPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ProcessesManager_ProcessPriority.ItemHeight = 13;
            this.comboBox_ProcessesManager_ProcessPriority.Items.AddRange(new object[] {
            "RealTime",
            "High",
            "AboveNormal",
            "Normal",
            "BelowNormal",
            "Idle"});
            this.comboBox_ProcessesManager_ProcessPriority.Location = new System.Drawing.Point(72, 16);
            this.comboBox_ProcessesManager_ProcessPriority.Name = "comboBox_ProcessesManager_ProcessPriority";
            this.comboBox_ProcessesManager_ProcessPriority.Size = new System.Drawing.Size(112, 21);
            this.comboBox_ProcessesManager_ProcessPriority.TabIndex = 6;
            this.comboBox_ProcessesManager_ProcessPriority.SelectedIndexChanged += new System.EventHandler(this.comboBox_ProcessesManager_ProcessPriority_SelectedIndexChanged);
            this.comboBox_ProcessesManager_ProcessPriority.SelectionChangeCommitted += new System.EventHandler(this.comboBox_ProcessesManager_ProcessPriority_SelectionChangeCommitted);
            // 
            // label_ProcessesManager_ProcessPriority
            // 
            this.label_ProcessesManager_ProcessPriority.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_ProcessesManager_ProcessPriority.Location = new System.Drawing.Point(8, 24);
            this.label_ProcessesManager_ProcessPriority.Name = "label_ProcessesManager_ProcessPriority";
            this.label_ProcessesManager_ProcessPriority.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_ProcessesManager_ProcessPriority.Size = new System.Drawing.Size(64, 16);
            this.label_ProcessesManager_ProcessPriority.TabIndex = 5;
            this.label_ProcessesManager_ProcessPriority.Text = "Select:";
            this.label_ProcessesManager_ProcessPriority.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage_DrivesManager
            // 
            this.tabPage_DrivesManager.Controls.Add(this.listView_DrivesManager_AvailableDrives);
            this.tabPage_DrivesManager.Controls.Add(this.label_DrivesManager_AvailableInformation);
            this.tabPage_DrivesManager.Controls.Add(this.button_DrivesManager_Refresh);
            this.tabPage_DrivesManager.Controls.Add(this.listView_DrivesManager_DrivesInformation);
            this.tabPage_DrivesManager.Controls.Add(this.button_DrivesManager_EjectCD);
            this.tabPage_DrivesManager.Controls.Add(this.button_DrivesManager_CloseCD);
            this.tabPage_DrivesManager.Location = new System.Drawing.Point(4, 40);
            this.tabPage_DrivesManager.Name = "tabPage_DrivesManager";
            this.tabPage_DrivesManager.Size = new System.Drawing.Size(944, 587);
            this.tabPage_DrivesManager.TabIndex = 8;
            this.tabPage_DrivesManager.Text = "Drives Manager";
            // 
            // listView_DrivesManager_AvailableDrives
            // 
            this.listView_DrivesManager_AvailableDrives.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_DrivesManager_AvailableDrives});
            this.listView_DrivesManager_AvailableDrives.FullRowSelect = true;
            this.listView_DrivesManager_AvailableDrives.GridLines = true;
            this.listView_DrivesManager_AvailableDrives.HoverSelection = true;
            this.listView_DrivesManager_AvailableDrives.Location = new System.Drawing.Point(88, 8);
            this.listView_DrivesManager_AvailableDrives.Name = "listView_DrivesManager_AvailableDrives";
            this.listView_DrivesManager_AvailableDrives.Size = new System.Drawing.Size(152, 136);
            this.listView_DrivesManager_AvailableDrives.TabIndex = 7;
            this.listView_DrivesManager_AvailableDrives.UseCompatibleStateImageBehavior = false;
            this.listView_DrivesManager_AvailableDrives.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_DrivesManager_AvailableDrives
            // 
            this.columnHeader_DrivesManager_AvailableDrives.Text = "Available Drives";
            this.columnHeader_DrivesManager_AvailableDrives.Width = 129;
            // 
            // label_DrivesManager_AvailableInformation
            // 
            this.label_DrivesManager_AvailableInformation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_DrivesManager_AvailableInformation.Location = new System.Drawing.Point(256, 136);
            this.label_DrivesManager_AvailableInformation.Name = "label_DrivesManager_AvailableInformation";
            this.label_DrivesManager_AvailableInformation.Size = new System.Drawing.Size(152, 16);
            this.label_DrivesManager_AvailableInformation.TabIndex = 6;
            this.label_DrivesManager_AvailableInformation.Text = "Available Information:";
            // 
            // button_DrivesManager_Refresh
            // 
            this.button_DrivesManager_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_DrivesManager_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_DrivesManager_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("button_DrivesManager_Refresh.Image")));
            this.button_DrivesManager_Refresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_DrivesManager_Refresh.Location = new System.Drawing.Point(9, 8);
            this.button_DrivesManager_Refresh.Name = "button_DrivesManager_Refresh";
            this.button_DrivesManager_Refresh.Size = new System.Drawing.Size(72, 72);
            this.button_DrivesManager_Refresh.TabIndex = 5;
            this.button_DrivesManager_Refresh.Click += new System.EventHandler(this.button_DrivesManager_Refresh_Click);
            // 
            // listView_DrivesManager_DrivesInformation
            // 
            this.listView_DrivesManager_DrivesInformation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_DrivesManager_DriveLetter,
            this.columnHeader_DrivesManager_DriveType,
            this.columnHeader_DrivesManager_TotalSpace,
            this.columnHeader_DrivesManager_FreeSpace,
            this.columnHeader_DrivesManager_FileSystem,
            this.columnHeader_DrivesManager_FileSystem_SerialNumber,
            this.columnHeader_DrivesManager_FileSystem_VolumeName,
            this.columnHeader_DrivesManager_FileSystem_maximumFileNameLength});
            this.listView_DrivesManager_DrivesInformation.FullRowSelect = true;
            this.listView_DrivesManager_DrivesInformation.GridLines = true;
            this.listView_DrivesManager_DrivesInformation.HoverSelection = true;
            this.listView_DrivesManager_DrivesInformation.Location = new System.Drawing.Point(8, 152);
            this.listView_DrivesManager_DrivesInformation.MultiSelect = false;
            this.listView_DrivesManager_DrivesInformation.Name = "listView_DrivesManager_DrivesInformation";
            this.listView_DrivesManager_DrivesInformation.Size = new System.Drawing.Size(928, 416);
            this.listView_DrivesManager_DrivesInformation.SmallImageList = this.imageList_DrivesManager;
            this.listView_DrivesManager_DrivesInformation.TabIndex = 4;
            this.listView_DrivesManager_DrivesInformation.UseCompatibleStateImageBehavior = false;
            this.listView_DrivesManager_DrivesInformation.View = System.Windows.Forms.View.Details;
            this.listView_DrivesManager_DrivesInformation.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_DrivesManager_DrivesInformation_ColumnClick);
            // 
            // columnHeader_DrivesManager_DriveLetter
            // 
            this.columnHeader_DrivesManager_DriveLetter.Text = "Drive Letter";
            this.columnHeader_DrivesManager_DriveLetter.Width = 90;
            // 
            // columnHeader_DrivesManager_DriveType
            // 
            this.columnHeader_DrivesManager_DriveType.Text = "Drive Type";
            this.columnHeader_DrivesManager_DriveType.Width = 90;
            // 
            // columnHeader_DrivesManager_TotalSpace
            // 
            this.columnHeader_DrivesManager_TotalSpace.Text = "Total Space";
            this.columnHeader_DrivesManager_TotalSpace.Width = 110;
            // 
            // columnHeader_DrivesManager_FreeSpace
            // 
            this.columnHeader_DrivesManager_FreeSpace.Text = "Free Space";
            this.columnHeader_DrivesManager_FreeSpace.Width = 110;
            // 
            // columnHeader_DrivesManager_FileSystem
            // 
            this.columnHeader_DrivesManager_FileSystem.Text = "File System";
            this.columnHeader_DrivesManager_FileSystem.Width = 120;
            // 
            // columnHeader_DrivesManager_FileSystem_SerialNumber
            // 
            this.columnHeader_DrivesManager_FileSystem_SerialNumber.Text = "Serial Number";
            this.columnHeader_DrivesManager_FileSystem_SerialNumber.Width = 110;
            // 
            // columnHeader_DrivesManager_FileSystem_VolumeName
            // 
            this.columnHeader_DrivesManager_FileSystem_VolumeName.Text = "Volume Name";
            this.columnHeader_DrivesManager_FileSystem_VolumeName.Width = 110;
            // 
            // columnHeader_DrivesManager_FileSystem_maximumFileNameLength
            // 
            this.columnHeader_DrivesManager_FileSystem_maximumFileNameLength.Text = "Max file name length";
            this.columnHeader_DrivesManager_FileSystem_maximumFileNameLength.Width = 170;
            // 
            // imageList_DrivesManager
            // 
            this.imageList_DrivesManager.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_DrivesManager.ImageStream")));
            this.imageList_DrivesManager.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_DrivesManager.Images.SetKeyName(0, "");
            this.imageList_DrivesManager.Images.SetKeyName(1, "");
            this.imageList_DrivesManager.Images.SetKeyName(2, "");
            this.imageList_DrivesManager.Images.SetKeyName(3, "");
            // 
            // button_DrivesManager_EjectCD
            // 
            this.button_DrivesManager_EjectCD.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_DrivesManager_EjectCD.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_DrivesManager_EjectCD.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_DrivesManager_EjectCD.Location = new System.Drawing.Point(8, 88);
            this.button_DrivesManager_EjectCD.Name = "button_DrivesManager_EjectCD";
            this.button_DrivesManager_EjectCD.Size = new System.Drawing.Size(75, 23);
            this.button_DrivesManager_EjectCD.TabIndex = 3;
            this.button_DrivesManager_EjectCD.Text = "Eject CD";
            this.button_DrivesManager_EjectCD.Click += new System.EventHandler(this.button_DrivesManager_EjectCD_Click);
            // 
            // button_DrivesManager_CloseCD
            // 
            this.button_DrivesManager_CloseCD.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_DrivesManager_CloseCD.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_DrivesManager_CloseCD.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_DrivesManager_CloseCD.Location = new System.Drawing.Point(8, 120);
            this.button_DrivesManager_CloseCD.Name = "button_DrivesManager_CloseCD";
            this.button_DrivesManager_CloseCD.Size = new System.Drawing.Size(75, 23);
            this.button_DrivesManager_CloseCD.TabIndex = 2;
            this.button_DrivesManager_CloseCD.Text = "Close CD";
            this.button_DrivesManager_CloseCD.Click += new System.EventHandler(this.button_DrivesManager_CloseCD_Click);
            // 
            // tabPage_RemoteRegistry
            // 
            this.tabPage_RemoteRegistry.Controls.Add(this.splitContainer_RemoteRegistry_MainSplit);
            this.tabPage_RemoteRegistry.Controls.Add(this.label_RemoteRegistry_CurrentPath);
            this.tabPage_RemoteRegistry.Controls.Add(this.textBox_RemoteRegistry_CurrentPath);
            this.tabPage_RemoteRegistry.Controls.Add(this.button_RemoteRegistry_Modify);
            this.tabPage_RemoteRegistry.Controls.Add(this.button_RemoteRegistry_Expand);
            this.tabPage_RemoteRegistry.Controls.Add(this.button_RemoteRegistry_RenameItem);
            this.tabPage_RemoteRegistry.Controls.Add(this.button_RemoteRegistry_Delete);
            this.tabPage_RemoteRegistry.Controls.Add(this.button_RemoteRegistry_CreateValue);
            this.tabPage_RemoteRegistry.Controls.Add(this.button_RemoteRegistry_CreateKey);
            this.tabPage_RemoteRegistry.Controls.Add(this.button_RemoteRegistry_Refresh);
            this.tabPage_RemoteRegistry.Location = new System.Drawing.Point(4, 40);
            this.tabPage_RemoteRegistry.Name = "tabPage_RemoteRegistry";
            this.tabPage_RemoteRegistry.Size = new System.Drawing.Size(944, 587);
            this.tabPage_RemoteRegistry.TabIndex = 15;
            this.tabPage_RemoteRegistry.Text = "Remote Registry";
            // 
            // label_RemoteRegistry_CurrentPath
            // 
            this.label_RemoteRegistry_CurrentPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label_RemoteRegistry_CurrentPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_RemoteRegistry_CurrentPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteRegistry_CurrentPath.Location = new System.Drawing.Point(56, 8);
            this.label_RemoteRegistry_CurrentPath.Name = "label_RemoteRegistry_CurrentPath";
            this.label_RemoteRegistry_CurrentPath.Size = new System.Drawing.Size(80, 24);
            this.label_RemoteRegistry_CurrentPath.TabIndex = 15;
            this.label_RemoteRegistry_CurrentPath.Text = "Current Path:";
            this.label_RemoteRegistry_CurrentPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_RemoteRegistry_CurrentPath
            // 
            this.textBox_RemoteRegistry_CurrentPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.textBox_RemoteRegistry_CurrentPath.Location = new System.Drawing.Point(136, 8);
            this.textBox_RemoteRegistry_CurrentPath.Name = "textBox_RemoteRegistry_CurrentPath";
            this.textBox_RemoteRegistry_CurrentPath.ReadOnly = true;
            this.textBox_RemoteRegistry_CurrentPath.Size = new System.Drawing.Size(800, 18);
            this.textBox_RemoteRegistry_CurrentPath.TabIndex = 14;
            // 
            // button_RemoteRegistry_Modify
            // 
            this.button_RemoteRegistry_Modify.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_RemoteRegistry_Modify.Location = new System.Drawing.Point(816, 32);
            this.button_RemoteRegistry_Modify.Name = "button_RemoteRegistry_Modify";
            this.button_RemoteRegistry_Modify.Size = new System.Drawing.Size(120, 23);
            this.button_RemoteRegistry_Modify.TabIndex = 8;
            this.button_RemoteRegistry_Modify.Text = "Modify";
            this.button_RemoteRegistry_Modify.Click += new System.EventHandler(this.button_RemoteRegistry_Modify_Click);
            // 
            // button_RemoteRegistry_Expand
            // 
            this.button_RemoteRegistry_Expand.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_RemoteRegistry_Expand.Location = new System.Drawing.Point(136, 32);
            this.button_RemoteRegistry_Expand.Name = "button_RemoteRegistry_Expand";
            this.button_RemoteRegistry_Expand.Size = new System.Drawing.Size(120, 23);
            this.button_RemoteRegistry_Expand.TabIndex = 7;
            this.button_RemoteRegistry_Expand.Text = "Expand";
            this.button_RemoteRegistry_Expand.Click += new System.EventHandler(this.button_RemoteRegistry_Expand_Click);
            // 
            // button_RemoteRegistry_RenameItem
            // 
            this.button_RemoteRegistry_RenameItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_RemoteRegistry_RenameItem.Location = new System.Drawing.Point(680, 32);
            this.button_RemoteRegistry_RenameItem.Name = "button_RemoteRegistry_RenameItem";
            this.button_RemoteRegistry_RenameItem.Size = new System.Drawing.Size(120, 23);
            this.button_RemoteRegistry_RenameItem.TabIndex = 6;
            this.button_RemoteRegistry_RenameItem.Text = "Rename";
            this.button_RemoteRegistry_RenameItem.Click += new System.EventHandler(this.button_RemoteRegistry_RenameItem_Click);
            // 
            // button_RemoteRegistry_Delete
            // 
            this.button_RemoteRegistry_Delete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_RemoteRegistry_Delete.Location = new System.Drawing.Point(544, 32);
            this.button_RemoteRegistry_Delete.Name = "button_RemoteRegistry_Delete";
            this.button_RemoteRegistry_Delete.Size = new System.Drawing.Size(120, 23);
            this.button_RemoteRegistry_Delete.TabIndex = 5;
            this.button_RemoteRegistry_Delete.Text = "Delete";
            this.button_RemoteRegistry_Delete.Click += new System.EventHandler(this.button_RemoteRegistry_DeleteItem_Click);
            // 
            // button_RemoteRegistry_CreateValue
            // 
            this.button_RemoteRegistry_CreateValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_RemoteRegistry_CreateValue.Location = new System.Drawing.Point(408, 32);
            this.button_RemoteRegistry_CreateValue.Name = "button_RemoteRegistry_CreateValue";
            this.button_RemoteRegistry_CreateValue.Size = new System.Drawing.Size(120, 23);
            this.button_RemoteRegistry_CreateValue.TabIndex = 4;
            this.button_RemoteRegistry_CreateValue.Text = "Create Value";
            this.button_RemoteRegistry_CreateValue.Click += new System.EventHandler(this.button_RemoteRegistry_CreateValue_Click);
            // 
            // button_RemoteRegistry_CreateKey
            // 
            this.button_RemoteRegistry_CreateKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_RemoteRegistry_CreateKey.Location = new System.Drawing.Point(272, 32);
            this.button_RemoteRegistry_CreateKey.Name = "button_RemoteRegistry_CreateKey";
            this.button_RemoteRegistry_CreateKey.Size = new System.Drawing.Size(120, 23);
            this.button_RemoteRegistry_CreateKey.TabIndex = 3;
            this.button_RemoteRegistry_CreateKey.Text = "Create Key";
            this.button_RemoteRegistry_CreateKey.Click += new System.EventHandler(this.button_RemoteRegistry_CreateKey_Click);
            // 
            // button_RemoteRegistry_Refresh
            // 
            this.button_RemoteRegistry_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_RemoteRegistry_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_RemoteRegistry_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("button_RemoteRegistry_Refresh.Image")));
            this.button_RemoteRegistry_Refresh.Location = new System.Drawing.Point(8, 8);
            this.button_RemoteRegistry_Refresh.Name = "button_RemoteRegistry_Refresh";
            this.button_RemoteRegistry_Refresh.Size = new System.Drawing.Size(48, 48);
            this.button_RemoteRegistry_Refresh.TabIndex = 2;
            this.button_RemoteRegistry_Refresh.Click += new System.EventHandler(this.button_RemoteRegistry_Refresh_Click);
            // 
            // tabPage_Display
            // 
            this.tabPage_Display.Controls.Add(this.groupBox_DisplaySettings_DisplaySettings);
            this.tabPage_Display.Controls.Add(this.groupBox_SingleImageCapture);
            this.tabPage_Display.Controls.Add(this.groupBox_CaptureInInterval);
            this.tabPage_Display.Location = new System.Drawing.Point(4, 40);
            this.tabPage_Display.Name = "tabPage_Display";
            this.tabPage_Display.Size = new System.Drawing.Size(944, 587);
            this.tabPage_Display.TabIndex = 9;
            this.tabPage_Display.Text = "Display";
            // 
            // groupBox_DisplaySettings_DisplaySettings
            // 
            this.groupBox_DisplaySettings_DisplaySettings.Controls.Add(this.button_DisplaySettings_SetDisplaySettings);
            this.groupBox_DisplaySettings_DisplaySettings.Controls.Add(this.button_DisplaySettings_GetDisplaySettings);
            this.groupBox_DisplaySettings_DisplaySettings.Controls.Add(this.label_DisplaySettings_ScreenRefreshRate);
            this.groupBox_DisplaySettings_DisplaySettings.Controls.Add(this.label_DisplaySettings_ColorQuality);
            this.groupBox_DisplaySettings_DisplaySettings.Controls.Add(this.comboBox_DisplaySettings_ColorQuality);
            this.groupBox_DisplaySettings_DisplaySettings.Controls.Add(this.comboBox_DisplaySettings_ScreenRefreshRate);
            this.groupBox_DisplaySettings_DisplaySettings.Controls.Add(this.trackBar_DisplaySettings_Resolution);
            this.groupBox_DisplaySettings_DisplaySettings.Controls.Add(this.label_SingleImageCapture_CurrentResolution);
            this.groupBox_DisplaySettings_DisplaySettings.Controls.Add(this.label_DisplaySettings_MoreResolution);
            this.groupBox_DisplaySettings_DisplaySettings.Controls.Add(this.label_DisplaySettings_LessResolution);
            this.groupBox_DisplaySettings_DisplaySettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_DisplaySettings_DisplaySettings.Location = new System.Drawing.Point(16, 16);
            this.groupBox_DisplaySettings_DisplaySettings.Name = "groupBox_DisplaySettings_DisplaySettings";
            this.groupBox_DisplaySettings_DisplaySettings.Size = new System.Drawing.Size(384, 176);
            this.groupBox_DisplaySettings_DisplaySettings.TabIndex = 13;
            this.groupBox_DisplaySettings_DisplaySettings.TabStop = false;
            this.groupBox_DisplaySettings_DisplaySettings.Text = "Display Settings";
            // 
            // button_DisplaySettings_SetDisplaySettings
            // 
            this.button_DisplaySettings_SetDisplaySettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_DisplaySettings_SetDisplaySettings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_DisplaySettings_SetDisplaySettings.Location = new System.Drawing.Point(200, 136);
            this.button_DisplaySettings_SetDisplaySettings.Name = "button_DisplaySettings_SetDisplaySettings";
            this.button_DisplaySettings_SetDisplaySettings.Size = new System.Drawing.Size(120, 23);
            this.button_DisplaySettings_SetDisplaySettings.TabIndex = 9;
            this.button_DisplaySettings_SetDisplaySettings.Text = "Apply";
            this.button_DisplaySettings_SetDisplaySettings.Click += new System.EventHandler(this.button_Display_SetDisplaySettings_Click);
            // 
            // button_DisplaySettings_GetDisplaySettings
            // 
            this.button_DisplaySettings_GetDisplaySettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_DisplaySettings_GetDisplaySettings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_DisplaySettings_GetDisplaySettings.Location = new System.Drawing.Point(56, 136);
            this.button_DisplaySettings_GetDisplaySettings.Name = "button_DisplaySettings_GetDisplaySettings";
            this.button_DisplaySettings_GetDisplaySettings.Size = new System.Drawing.Size(128, 23);
            this.button_DisplaySettings_GetDisplaySettings.TabIndex = 8;
            this.button_DisplaySettings_GetDisplaySettings.Text = "View";
            this.button_DisplaySettings_GetDisplaySettings.Click += new System.EventHandler(this.button_Display_GetDisplaySettings_Click);
            // 
            // label_DisplaySettings_ScreenRefreshRate
            // 
            this.label_DisplaySettings_ScreenRefreshRate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_DisplaySettings_ScreenRefreshRate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_DisplaySettings_ScreenRefreshRate.Location = new System.Drawing.Point(200, 24);
            this.label_DisplaySettings_ScreenRefreshRate.Name = "label_DisplaySettings_ScreenRefreshRate";
            this.label_DisplaySettings_ScreenRefreshRate.Size = new System.Drawing.Size(168, 16);
            this.label_DisplaySettings_ScreenRefreshRate.TabIndex = 7;
            this.label_DisplaySettings_ScreenRefreshRate.Text = "Screen refresh rate:";
            // 
            // label_DisplaySettings_ColorQuality
            // 
            this.label_DisplaySettings_ColorQuality.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_DisplaySettings_ColorQuality.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_DisplaySettings_ColorQuality.Location = new System.Drawing.Point(16, 24);
            this.label_DisplaySettings_ColorQuality.Name = "label_DisplaySettings_ColorQuality";
            this.label_DisplaySettings_ColorQuality.Size = new System.Drawing.Size(168, 16);
            this.label_DisplaySettings_ColorQuality.TabIndex = 6;
            this.label_DisplaySettings_ColorQuality.Text = "Color quality:";
            // 
            // comboBox_DisplaySettings_ColorQuality
            // 
            this.comboBox_DisplaySettings_ColorQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DisplaySettings_ColorQuality.ItemHeight = 13;
            this.comboBox_DisplaySettings_ColorQuality.Location = new System.Drawing.Point(16, 40);
            this.comboBox_DisplaySettings_ColorQuality.Name = "comboBox_DisplaySettings_ColorQuality";
            this.comboBox_DisplaySettings_ColorQuality.Size = new System.Drawing.Size(168, 21);
            this.comboBox_DisplaySettings_ColorQuality.TabIndex = 2;
            // 
            // comboBox_DisplaySettings_ScreenRefreshRate
            // 
            this.comboBox_DisplaySettings_ScreenRefreshRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DisplaySettings_ScreenRefreshRate.ItemHeight = 13;
            this.comboBox_DisplaySettings_ScreenRefreshRate.Location = new System.Drawing.Point(200, 40);
            this.comboBox_DisplaySettings_ScreenRefreshRate.Name = "comboBox_DisplaySettings_ScreenRefreshRate";
            this.comboBox_DisplaySettings_ScreenRefreshRate.Size = new System.Drawing.Size(168, 21);
            this.comboBox_DisplaySettings_ScreenRefreshRate.TabIndex = 0;
            // 
            // trackBar_DisplaySettings_Resolution
            // 
            this.trackBar_DisplaySettings_Resolution.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar_DisplaySettings_Resolution.LargeChange = 1;
            this.trackBar_DisplaySettings_Resolution.Location = new System.Drawing.Point(112, 88);
            this.trackBar_DisplaySettings_Resolution.Maximum = 0;
            this.trackBar_DisplaySettings_Resolution.Name = "trackBar_DisplaySettings_Resolution";
            this.trackBar_DisplaySettings_Resolution.Size = new System.Drawing.Size(152, 45);
            this.trackBar_DisplaySettings_Resolution.TabIndex = 1;
            this.trackBar_DisplaySettings_Resolution.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar_DisplaySettings_Resolution.ValueChanged += new System.EventHandler(this.trackBar_SingleImageCapture_Resolution_ValueChanged);
            // 
            // label_SingleImageCapture_CurrentResolution
            // 
            this.label_SingleImageCapture_CurrentResolution.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_SingleImageCapture_CurrentResolution.Location = new System.Drawing.Point(128, 72);
            this.label_SingleImageCapture_CurrentResolution.Name = "label_SingleImageCapture_CurrentResolution";
            this.label_SingleImageCapture_CurrentResolution.Size = new System.Drawing.Size(120, 16);
            this.label_SingleImageCapture_CurrentResolution.TabIndex = 3;
            this.label_SingleImageCapture_CurrentResolution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_DisplaySettings_MoreResolution
            // 
            this.label_DisplaySettings_MoreResolution.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_DisplaySettings_MoreResolution.Location = new System.Drawing.Point(272, 104);
            this.label_DisplaySettings_MoreResolution.Name = "label_DisplaySettings_MoreResolution";
            this.label_DisplaySettings_MoreResolution.Size = new System.Drawing.Size(48, 16);
            this.label_DisplaySettings_MoreResolution.TabIndex = 4;
            this.label_DisplaySettings_MoreResolution.Text = "More";
            this.label_DisplaySettings_MoreResolution.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_DisplaySettings_LessResolution
            // 
            this.label_DisplaySettings_LessResolution.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_DisplaySettings_LessResolution.Location = new System.Drawing.Point(56, 104);
            this.label_DisplaySettings_LessResolution.Name = "label_DisplaySettings_LessResolution";
            this.label_DisplaySettings_LessResolution.Size = new System.Drawing.Size(48, 16);
            this.label_DisplaySettings_LessResolution.TabIndex = 5;
            this.label_DisplaySettings_LessResolution.Text = "Less";
            this.label_DisplaySettings_LessResolution.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox_SingleImageCapture
            // 
            this.groupBox_SingleImageCapture.Controls.Add(this.label_SingleImageCapture_ImageQuality);
            this.groupBox_SingleImageCapture.Controls.Add(this.label_SingleImageCapture_CompressionFormat);
            this.groupBox_SingleImageCapture.Controls.Add(this.comboBox_SingleImageCapture_ImageFormat);
            this.groupBox_SingleImageCapture.Controls.Add(this.radioButton_SingleImageCapture_OnlySave);
            this.groupBox_SingleImageCapture.Controls.Add(this.radioButton_SingleImageCapture_SaveAndShow);
            this.groupBox_SingleImageCapture.Controls.Add(this.label_SingleImageCapture_ImageFormat);
            this.groupBox_SingleImageCapture.Controls.Add(this.button_SingleImageCapture_CaptureImage);
            this.groupBox_SingleImageCapture.Controls.Add(this.trackBar_SingleImageCapture_ImageQuality);
            this.groupBox_SingleImageCapture.Controls.Add(this.comboBox_SingleImageCapture_CompressionFormat);
            this.groupBox_SingleImageCapture.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_SingleImageCapture.Location = new System.Drawing.Point(16, 200);
            this.groupBox_SingleImageCapture.Name = "groupBox_SingleImageCapture";
            this.groupBox_SingleImageCapture.Size = new System.Drawing.Size(384, 168);
            this.groupBox_SingleImageCapture.TabIndex = 10;
            this.groupBox_SingleImageCapture.TabStop = false;
            this.groupBox_SingleImageCapture.Text = "Single image capture";
            // 
            // label_SingleImageCapture_ImageQuality
            // 
            this.label_SingleImageCapture_ImageQuality.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_SingleImageCapture_ImageQuality.Location = new System.Drawing.Point(200, 104);
            this.label_SingleImageCapture_ImageQuality.Name = "label_SingleImageCapture_ImageQuality";
            this.label_SingleImageCapture_ImageQuality.Size = new System.Drawing.Size(168, 16);
            this.label_SingleImageCapture_ImageQuality.TabIndex = 16;
            this.label_SingleImageCapture_ImageQuality.Text = "Image quality:";
            // 
            // label_SingleImageCapture_CompressionFormat
            // 
            this.label_SingleImageCapture_CompressionFormat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_SingleImageCapture_CompressionFormat.Location = new System.Drawing.Point(200, 56);
            this.label_SingleImageCapture_CompressionFormat.Name = "label_SingleImageCapture_CompressionFormat";
            this.label_SingleImageCapture_CompressionFormat.Size = new System.Drawing.Size(168, 16);
            this.label_SingleImageCapture_CompressionFormat.TabIndex = 11;
            this.label_SingleImageCapture_CompressionFormat.Text = "Compression format:";
            // 
            // comboBox_SingleImageCapture_ImageFormat
            // 
            this.comboBox_SingleImageCapture_ImageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SingleImageCapture_ImageFormat.ItemHeight = 13;
            this.comboBox_SingleImageCapture_ImageFormat.Location = new System.Drawing.Point(16, 72);
            this.comboBox_SingleImageCapture_ImageFormat.Name = "comboBox_SingleImageCapture_ImageFormat";
            this.comboBox_SingleImageCapture_ImageFormat.Size = new System.Drawing.Size(168, 21);
            this.comboBox_SingleImageCapture_ImageFormat.TabIndex = 7;
            this.comboBox_SingleImageCapture_ImageFormat.SelectedIndexChanged += new System.EventHandler(this.comboBox_SingleImageCapture_ImageFormat_SelectedIndexChanged);
            // 
            // radioButton_SingleImageCapture_OnlySave
            // 
            this.radioButton_SingleImageCapture_OnlySave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_SingleImageCapture_OnlySave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_SingleImageCapture_OnlySave.Location = new System.Drawing.Point(16, 32);
            this.radioButton_SingleImageCapture_OnlySave.Name = "radioButton_SingleImageCapture_OnlySave";
            this.radioButton_SingleImageCapture_OnlySave.Size = new System.Drawing.Size(168, 16);
            this.radioButton_SingleImageCapture_OnlySave.TabIndex = 4;
            this.radioButton_SingleImageCapture_OnlySave.Text = "Only Save";
            // 
            // radioButton_SingleImageCapture_SaveAndShow
            // 
            this.radioButton_SingleImageCapture_SaveAndShow.Checked = true;
            this.radioButton_SingleImageCapture_SaveAndShow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_SingleImageCapture_SaveAndShow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_SingleImageCapture_SaveAndShow.Location = new System.Drawing.Point(200, 32);
            this.radioButton_SingleImageCapture_SaveAndShow.Name = "radioButton_SingleImageCapture_SaveAndShow";
            this.radioButton_SingleImageCapture_SaveAndShow.Size = new System.Drawing.Size(168, 16);
            this.radioButton_SingleImageCapture_SaveAndShow.TabIndex = 3;
            this.radioButton_SingleImageCapture_SaveAndShow.TabStop = true;
            this.radioButton_SingleImageCapture_SaveAndShow.Text = "Save and Show";
            // 
            // label_SingleImageCapture_ImageFormat
            // 
            this.label_SingleImageCapture_ImageFormat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_SingleImageCapture_ImageFormat.Location = new System.Drawing.Point(16, 56);
            this.label_SingleImageCapture_ImageFormat.Name = "label_SingleImageCapture_ImageFormat";
            this.label_SingleImageCapture_ImageFormat.Size = new System.Drawing.Size(168, 16);
            this.label_SingleImageCapture_ImageFormat.TabIndex = 9;
            this.label_SingleImageCapture_ImageFormat.Text = "Image format:";
            // 
            // button_SingleImageCapture_CaptureImage
            // 
            this.button_SingleImageCapture_CaptureImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_SingleImageCapture_CaptureImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_SingleImageCapture_CaptureImage.Location = new System.Drawing.Point(16, 120);
            this.button_SingleImageCapture_CaptureImage.Name = "button_SingleImageCapture_CaptureImage";
            this.button_SingleImageCapture_CaptureImage.Size = new System.Drawing.Size(168, 24);
            this.button_SingleImageCapture_CaptureImage.TabIndex = 1;
            this.button_SingleImageCapture_CaptureImage.Text = "Capture Image";
            this.button_SingleImageCapture_CaptureImage.Click += new System.EventHandler(this.button_SingleImageCapture_Capture_Click);
            // 
            // trackBar_SingleImageCapture_ImageQuality
            // 
            this.trackBar_SingleImageCapture_ImageQuality.AutoSize = false;
            this.trackBar_SingleImageCapture_ImageQuality.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar_SingleImageCapture_ImageQuality.LargeChange = 1;
            this.trackBar_SingleImageCapture_ImageQuality.Location = new System.Drawing.Point(192, 120);
            this.trackBar_SingleImageCapture_ImageQuality.Maximum = 100;
            this.trackBar_SingleImageCapture_ImageQuality.Name = "trackBar_SingleImageCapture_ImageQuality";
            this.trackBar_SingleImageCapture_ImageQuality.Size = new System.Drawing.Size(184, 32);
            this.trackBar_SingleImageCapture_ImageQuality.TabIndex = 15;
            this.trackBar_SingleImageCapture_ImageQuality.TickFrequency = 5;
            this.trackBar_SingleImageCapture_ImageQuality.Value = 100;
            // 
            // comboBox_SingleImageCapture_CompressionFormat
            // 
            this.comboBox_SingleImageCapture_CompressionFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SingleImageCapture_CompressionFormat.ItemHeight = 13;
            this.comboBox_SingleImageCapture_CompressionFormat.Items.AddRange(new object[] {
            "LZW",
            "None"});
            this.comboBox_SingleImageCapture_CompressionFormat.Location = new System.Drawing.Point(200, 72);
            this.comboBox_SingleImageCapture_CompressionFormat.Name = "comboBox_SingleImageCapture_CompressionFormat";
            this.comboBox_SingleImageCapture_CompressionFormat.Size = new System.Drawing.Size(168, 21);
            this.comboBox_SingleImageCapture_CompressionFormat.TabIndex = 10;
            // 
            // groupBox_CaptureInInterval
            // 
            this.groupBox_CaptureInInterval.Controls.Add(this.comboBox_CaptureInInterval_CompressionFormat);
            this.groupBox_CaptureInInterval.Controls.Add(this.label_CaptureInInterval_CompressionFormat);
            this.groupBox_CaptureInInterval.Controls.Add(this.label_CaptureInInterval_ImageQuality);
            this.groupBox_CaptureInInterval.Controls.Add(this.trackBar_CaptureInInterval_ImageQuality);
            this.groupBox_CaptureInInterval.Controls.Add(this.radioButton_CaptureInInterval_OnlySave);
            this.groupBox_CaptureInInterval.Controls.Add(this.radioButton_CaptureInInterval_SaveAndShow);
            this.groupBox_CaptureInInterval.Controls.Add(this.label_CaptureInInterval_ImageFormat);
            this.groupBox_CaptureInInterval.Controls.Add(this.label_CaptureInInterval_InetrvalSettings);
            this.groupBox_CaptureInInterval.Controls.Add(this.comboBox_CaptureInInterval_InetrvalSettings);
            this.groupBox_CaptureInInterval.Controls.Add(this.button_CaptureInInterval_StartCapture);
            this.groupBox_CaptureInInterval.Controls.Add(this.button_CaptureInInterval_StopCapture);
            this.groupBox_CaptureInInterval.Controls.Add(this.comboBox_CaptureInInterval_ImageFormat);
            this.groupBox_CaptureInInterval.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_CaptureInInterval.Location = new System.Drawing.Point(16, 376);
            this.groupBox_CaptureInInterval.Name = "groupBox_CaptureInInterval";
            this.groupBox_CaptureInInterval.Size = new System.Drawing.Size(384, 192);
            this.groupBox_CaptureInInterval.TabIndex = 13;
            this.groupBox_CaptureInInterval.TabStop = false;
            this.groupBox_CaptureInInterval.Text = "Capture using interval";
            // 
            // comboBox_CaptureInInterval_CompressionFormat
            // 
            this.comboBox_CaptureInInterval_CompressionFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CaptureInInterval_CompressionFormat.ItemHeight = 13;
            this.comboBox_CaptureInInterval_CompressionFormat.Items.AddRange(new object[] {
            "LZW",
            "None"});
            this.comboBox_CaptureInInterval_CompressionFormat.Location = new System.Drawing.Point(200, 72);
            this.comboBox_CaptureInInterval_CompressionFormat.Name = "comboBox_CaptureInInterval_CompressionFormat";
            this.comboBox_CaptureInInterval_CompressionFormat.Size = new System.Drawing.Size(168, 21);
            this.comboBox_CaptureInInterval_CompressionFormat.TabIndex = 21;
            // 
            // label_CaptureInInterval_CompressionFormat
            // 
            this.label_CaptureInInterval_CompressionFormat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_CaptureInInterval_CompressionFormat.Location = new System.Drawing.Point(200, 56);
            this.label_CaptureInInterval_CompressionFormat.Name = "label_CaptureInInterval_CompressionFormat";
            this.label_CaptureInInterval_CompressionFormat.Size = new System.Drawing.Size(168, 16);
            this.label_CaptureInInterval_CompressionFormat.TabIndex = 22;
            this.label_CaptureInInterval_CompressionFormat.Text = "Compression Format:";
            // 
            // label_CaptureInInterval_ImageQuality
            // 
            this.label_CaptureInInterval_ImageQuality.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_CaptureInInterval_ImageQuality.Location = new System.Drawing.Point(200, 104);
            this.label_CaptureInInterval_ImageQuality.Name = "label_CaptureInInterval_ImageQuality";
            this.label_CaptureInInterval_ImageQuality.Size = new System.Drawing.Size(168, 16);
            this.label_CaptureInInterval_ImageQuality.TabIndex = 20;
            this.label_CaptureInInterval_ImageQuality.Text = "Image quality:";
            // 
            // trackBar_CaptureInInterval_ImageQuality
            // 
            this.trackBar_CaptureInInterval_ImageQuality.AutoSize = false;
            this.trackBar_CaptureInInterval_ImageQuality.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar_CaptureInInterval_ImageQuality.LargeChange = 1;
            this.trackBar_CaptureInInterval_ImageQuality.Location = new System.Drawing.Point(192, 120);
            this.trackBar_CaptureInInterval_ImageQuality.Maximum = 100;
            this.trackBar_CaptureInInterval_ImageQuality.Name = "trackBar_CaptureInInterval_ImageQuality";
            this.trackBar_CaptureInInterval_ImageQuality.Size = new System.Drawing.Size(184, 32);
            this.trackBar_CaptureInInterval_ImageQuality.TabIndex = 19;
            this.trackBar_CaptureInInterval_ImageQuality.TickFrequency = 5;
            this.trackBar_CaptureInInterval_ImageQuality.Value = 100;
            // 
            // radioButton_CaptureInInterval_OnlySave
            // 
            this.radioButton_CaptureInInterval_OnlySave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_CaptureInInterval_OnlySave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_CaptureInInterval_OnlySave.Location = new System.Drawing.Point(16, 32);
            this.radioButton_CaptureInInterval_OnlySave.Name = "radioButton_CaptureInInterval_OnlySave";
            this.radioButton_CaptureInInterval_OnlySave.Size = new System.Drawing.Size(168, 16);
            this.radioButton_CaptureInInterval_OnlySave.TabIndex = 18;
            this.radioButton_CaptureInInterval_OnlySave.Text = "Only Save";
            // 
            // radioButton_CaptureInInterval_SaveAndShow
            // 
            this.radioButton_CaptureInInterval_SaveAndShow.Checked = true;
            this.radioButton_CaptureInInterval_SaveAndShow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_CaptureInInterval_SaveAndShow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_CaptureInInterval_SaveAndShow.Location = new System.Drawing.Point(200, 32);
            this.radioButton_CaptureInInterval_SaveAndShow.Name = "radioButton_CaptureInInterval_SaveAndShow";
            this.radioButton_CaptureInInterval_SaveAndShow.Size = new System.Drawing.Size(168, 16);
            this.radioButton_CaptureInInterval_SaveAndShow.TabIndex = 17;
            this.radioButton_CaptureInInterval_SaveAndShow.TabStop = true;
            this.radioButton_CaptureInInterval_SaveAndShow.Text = "Save and Show";
            // 
            // label_CaptureInInterval_ImageFormat
            // 
            this.label_CaptureInInterval_ImageFormat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_CaptureInInterval_ImageFormat.Location = new System.Drawing.Point(16, 56);
            this.label_CaptureInInterval_ImageFormat.Name = "label_CaptureInInterval_ImageFormat";
            this.label_CaptureInInterval_ImageFormat.Size = new System.Drawing.Size(168, 16);
            this.label_CaptureInInterval_ImageFormat.TabIndex = 16;
            this.label_CaptureInInterval_ImageFormat.Text = "Image format:";
            // 
            // label_CaptureInInterval_InetrvalSettings
            // 
            this.label_CaptureInInterval_InetrvalSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_CaptureInInterval_InetrvalSettings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_CaptureInInterval_InetrvalSettings.Location = new System.Drawing.Point(16, 104);
            this.label_CaptureInInterval_InetrvalSettings.Name = "label_CaptureInInterval_InetrvalSettings";
            this.label_CaptureInInterval_InetrvalSettings.Size = new System.Drawing.Size(168, 16);
            this.label_CaptureInInterval_InetrvalSettings.TabIndex = 14;
            this.label_CaptureInInterval_InetrvalSettings.Text = "Interval (seconds):";
            // 
            // comboBox_CaptureInInterval_InetrvalSettings
            // 
            this.comboBox_CaptureInInterval_InetrvalSettings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CaptureInInterval_InetrvalSettings.ItemHeight = 13;
            this.comboBox_CaptureInInterval_InetrvalSettings.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "45",
            "60"});
            this.comboBox_CaptureInInterval_InetrvalSettings.Location = new System.Drawing.Point(16, 120);
            this.comboBox_CaptureInInterval_InetrvalSettings.Name = "comboBox_CaptureInInterval_InetrvalSettings";
            this.comboBox_CaptureInInterval_InetrvalSettings.Size = new System.Drawing.Size(168, 21);
            this.comboBox_CaptureInInterval_InetrvalSettings.TabIndex = 13;
            // 
            // button_CaptureInInterval_StartCapture
            // 
            this.button_CaptureInInterval_StartCapture.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_CaptureInInterval_StartCapture.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_CaptureInInterval_StartCapture.Location = new System.Drawing.Point(16, 152);
            this.button_CaptureInInterval_StartCapture.Name = "button_CaptureInInterval_StartCapture";
            this.button_CaptureInInterval_StartCapture.Size = new System.Drawing.Size(80, 23);
            this.button_CaptureInInterval_StartCapture.TabIndex = 11;
            this.button_CaptureInInterval_StartCapture.Text = "Start";
            this.button_CaptureInInterval_StartCapture.Click += new System.EventHandler(this.button_SingleImageCapture_StartCaptureUsingInterval_Click);
            // 
            // button_CaptureInInterval_StopCapture
            // 
            this.button_CaptureInInterval_StopCapture.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_CaptureInInterval_StopCapture.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_CaptureInInterval_StopCapture.Location = new System.Drawing.Point(104, 152);
            this.button_CaptureInInterval_StopCapture.Name = "button_CaptureInInterval_StopCapture";
            this.button_CaptureInInterval_StopCapture.Size = new System.Drawing.Size(80, 23);
            this.button_CaptureInInterval_StopCapture.TabIndex = 12;
            this.button_CaptureInInterval_StopCapture.Text = "Stop";
            this.button_CaptureInInterval_StopCapture.Click += new System.EventHandler(this.button_SingleImageCapture_StopCaptureUsingInterval_Click);
            // 
            // comboBox_CaptureInInterval_ImageFormat
            // 
            this.comboBox_CaptureInInterval_ImageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CaptureInInterval_ImageFormat.ItemHeight = 13;
            this.comboBox_CaptureInInterval_ImageFormat.Location = new System.Drawing.Point(16, 72);
            this.comboBox_CaptureInInterval_ImageFormat.Name = "comboBox_CaptureInInterval_ImageFormat";
            this.comboBox_CaptureInInterval_ImageFormat.Size = new System.Drawing.Size(168, 21);
            this.comboBox_CaptureInInterval_ImageFormat.TabIndex = 15;
            this.comboBox_CaptureInInterval_ImageFormat.SelectedIndexChanged += new System.EventHandler(this.comboBox_CaptureInInterval_ImageFormat_SelectedIndexChanged);
            // 
            // tabPage_RTDV
            // 
            this.tabPage_RTDV.Controls.Add(this.comboBox_RTDV_AmountOfRegions);
            this.tabPage_RTDV.Controls.Add(this.label_RTDV_NumberOfRegions);
            this.tabPage_RTDV.Controls.Add(this.label_RTDV_DataFormat);
            this.tabPage_RTDV.Controls.Add(this.label_RTDV_MoreBandwidth);
            this.tabPage_RTDV.Controls.Add(this.label_RTDV_MoreCPUUsage);
            this.tabPage_RTDV.Controls.Add(this.trackBar_RTDV_ImageCodingAlgorithm);
            this.tabPage_RTDV.Controls.Add(this.checkBox_RTDV_HideMyCursor);
            this.tabPage_RTDV.Controls.Add(this.checkBox_RTDV_ShowRemoteCursor);
            this.tabPage_RTDV.Controls.Add(this.button_RTDV_SendKeys);
            this.tabPage_RTDV.Controls.Add(this.button_RTDV_SetRemoteClipboardData);
            this.tabPage_RTDV.Controls.Add(this.button_RTDV_GetRemoteClipboardData);
            this.tabPage_RTDV.Controls.Add(this.groupBox_RTDV_AdditionalParameters);
            this.tabPage_RTDV.Controls.Add(this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer);
            this.tabPage_RTDV.Controls.Add(this.checkBox_RTDV_RealSize);
            this.tabPage_RTDV.Controls.Add(this.label_RTDV_MaxUpdatePerSec);
            this.tabPage_RTDV.Controls.Add(this.checkBox_RTDV_AllowControl);
            this.tabPage_RTDV.Controls.Add(this.numericUpDown_RTDV_MaxUpdatePerSec);
            this.tabPage_RTDV.Location = new System.Drawing.Point(4, 40);
            this.tabPage_RTDV.Name = "tabPage_RTDV";
            this.tabPage_RTDV.Size = new System.Drawing.Size(944, 587);
            this.tabPage_RTDV.TabIndex = 12;
            this.tabPage_RTDV.Text = "Remote Desktop";
            // 
            // comboBox_RTDV_AmountOfRegions
            // 
            this.comboBox_RTDV_AmountOfRegions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RTDV_AmountOfRegions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_RTDV_AmountOfRegions.FormatString = "N2";
            this.comboBox_RTDV_AmountOfRegions.Items.AddRange(new object[] {
            "1",
            "4",
            "16",
            "64"});
            this.comboBox_RTDV_AmountOfRegions.Location = new System.Drawing.Point(154, 244);
            this.comboBox_RTDV_AmountOfRegions.Name = "comboBox_RTDV_AmountOfRegions";
            this.comboBox_RTDV_AmountOfRegions.Size = new System.Drawing.Size(54, 21);
            this.comboBox_RTDV_AmountOfRegions.TabIndex = 31;
            this.comboBox_RTDV_AmountOfRegions.SelectedIndexChanged += new System.EventHandler(this.comboBox_RTDV_AmountOfRegions_SelectedIndexChanged);
            // 
            // label_RTDV_NumberOfRegions
            // 
            this.label_RTDV_NumberOfRegions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_RTDV_NumberOfRegions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RTDV_NumberOfRegions.Location = new System.Drawing.Point(16, 249);
            this.label_RTDV_NumberOfRegions.Name = "label_RTDV_NumberOfRegions";
            this.label_RTDV_NumberOfRegions.Size = new System.Drawing.Size(132, 16);
            this.label_RTDV_NumberOfRegions.TabIndex = 30;
            this.label_RTDV_NumberOfRegions.Text = "Number of Regions:";
            // 
            // label_RTDV_DataFormat
            // 
            this.label_RTDV_DataFormat.AutoSize = true;
            this.label_RTDV_DataFormat.Location = new System.Drawing.Point(13, 210);
            this.label_RTDV_DataFormat.Name = "label_RTDV_DataFormat";
            this.label_RTDV_DataFormat.Size = new System.Drawing.Size(185, 13);
            this.label_RTDV_DataFormat.TabIndex = 29;
            this.label_RTDV_DataFormat.Text = "*Data Format: DEFLATE compression";
            // 
            // label_RTDV_MoreBandwidth
            // 
            this.label_RTDV_MoreBandwidth.Location = new System.Drawing.Point(3, 133);
            this.label_RTDV_MoreBandwidth.Name = "label_RTDV_MoreBandwidth";
            this.label_RTDV_MoreBandwidth.Size = new System.Drawing.Size(114, 31);
            this.label_RTDV_MoreBandwidth.TabIndex = 27;
            this.label_RTDV_MoreBandwidth.Text = "More Bandwidth";
            this.label_RTDV_MoreBandwidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_RTDV_MoreCPUUsage
            // 
            this.label_RTDV_MoreCPUUsage.Location = new System.Drawing.Point(115, 134);
            this.label_RTDV_MoreCPUUsage.Name = "label_RTDV_MoreCPUUsage";
            this.label_RTDV_MoreCPUUsage.Size = new System.Drawing.Size(93, 30);
            this.label_RTDV_MoreCPUUsage.TabIndex = 26;
            this.label_RTDV_MoreCPUUsage.Text = "More CPU Usage";
            this.label_RTDV_MoreCPUUsage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackBar_RTDV_ImageCodingAlgorithm
            // 
            this.trackBar_RTDV_ImageCodingAlgorithm.AutoSize = false;
            this.trackBar_RTDV_ImageCodingAlgorithm.Location = new System.Drawing.Point(16, 167);
            this.trackBar_RTDV_ImageCodingAlgorithm.Maximum = 2;
            this.trackBar_RTDV_ImageCodingAlgorithm.Name = "trackBar_RTDV_ImageCodingAlgorithm";
            this.trackBar_RTDV_ImageCodingAlgorithm.Size = new System.Drawing.Size(192, 40);
            this.trackBar_RTDV_ImageCodingAlgorithm.TabIndex = 25;
            this.trackBar_RTDV_ImageCodingAlgorithm.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_RTDV_ImageCodingAlgorithm.Value = 1;
            this.trackBar_RTDV_ImageCodingAlgorithm.ValueChanged += new System.EventHandler(this.trackBar_RTDV_TransferringAlgorithm_ValueChanged);
            // 
            // checkBox_RTDV_HideMyCursor
            // 
            this.checkBox_RTDV_HideMyCursor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_RTDV_HideMyCursor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_RTDV_HideMyCursor.Location = new System.Drawing.Point(16, 108);
            this.checkBox_RTDV_HideMyCursor.Name = "checkBox_RTDV_HideMyCursor";
            this.checkBox_RTDV_HideMyCursor.Size = new System.Drawing.Size(192, 16);
            this.checkBox_RTDV_HideMyCursor.TabIndex = 22;
            this.checkBox_RTDV_HideMyCursor.Text = "Hide My Cursor";
            this.checkBox_RTDV_HideMyCursor.CheckedChanged += new System.EventHandler(this.checkBox_RTDV_HideMyCursor_CheckedChanged);
            // 
            // checkBox_RTDV_ShowRemoteCursor
            // 
            this.checkBox_RTDV_ShowRemoteCursor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_RTDV_ShowRemoteCursor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_RTDV_ShowRemoteCursor.Location = new System.Drawing.Point(16, 87);
            this.checkBox_RTDV_ShowRemoteCursor.Name = "checkBox_RTDV_ShowRemoteCursor";
            this.checkBox_RTDV_ShowRemoteCursor.Size = new System.Drawing.Size(192, 16);
            this.checkBox_RTDV_ShowRemoteCursor.TabIndex = 21;
            this.checkBox_RTDV_ShowRemoteCursor.Text = "Show Remote Cursor";
            this.checkBox_RTDV_ShowRemoteCursor.CheckedChanged += new System.EventHandler(this.checkBox_RTDV_ShowRemoteCursor_CheckedChanged);
            // 
            // button_RTDV_SendKeys
            // 
            this.button_RTDV_SendKeys.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_RTDV_SendKeys.Location = new System.Drawing.Point(16, 488);
            this.button_RTDV_SendKeys.Name = "button_RTDV_SendKeys";
            this.button_RTDV_SendKeys.Size = new System.Drawing.Size(192, 23);
            this.button_RTDV_SendKeys.TabIndex = 20;
            this.button_RTDV_SendKeys.Text = "Send Keys >>";
            this.button_RTDV_SendKeys.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_RTDV_SendKeys_MouseDown);
            // 
            // button_RTDV_SetRemoteClipboardData
            // 
            this.button_RTDV_SetRemoteClipboardData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_RTDV_SetRemoteClipboardData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_RTDV_SetRemoteClipboardData.Location = new System.Drawing.Point(16, 546);
            this.button_RTDV_SetRemoteClipboardData.Name = "button_RTDV_SetRemoteClipboardData";
            this.button_RTDV_SetRemoteClipboardData.Size = new System.Drawing.Size(192, 23);
            this.button_RTDV_SetRemoteClipboardData.TabIndex = 19;
            this.button_RTDV_SetRemoteClipboardData.Text = "Set Remote Clipboard Data";
            this.button_RTDV_SetRemoteClipboardData.Click += new System.EventHandler(this.button_RTDV_SetRemoteClipboardData_Click);
            // 
            // button_RTDV_GetRemoteClipboardData
            // 
            this.button_RTDV_GetRemoteClipboardData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_RTDV_GetRemoteClipboardData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_RTDV_GetRemoteClipboardData.Location = new System.Drawing.Point(16, 517);
            this.button_RTDV_GetRemoteClipboardData.Name = "button_RTDV_GetRemoteClipboardData";
            this.button_RTDV_GetRemoteClipboardData.Size = new System.Drawing.Size(192, 23);
            this.button_RTDV_GetRemoteClipboardData.TabIndex = 18;
            this.button_RTDV_GetRemoteClipboardData.Text = "Get Remote Clipboard Data";
            this.button_RTDV_GetRemoteClipboardData.Click += new System.EventHandler(this.button_RTDV_GetRemoteClipboardData_Click);
            // 
            // groupBox_RTDV_AdditionalParameters
            // 
            this.groupBox_RTDV_AdditionalParameters.Controls.Add(this.label_RTDV_SizeMode);
            this.groupBox_RTDV_AdditionalParameters.Controls.Add(this.comboBox_RTDV_SizeMode);
            this.groupBox_RTDV_AdditionalParameters.Controls.Add(this.label_RTDV_SelectedImageSize);
            this.groupBox_RTDV_AdditionalParameters.Controls.Add(this.label_RTDV_ReceivedImageSize);
            this.groupBox_RTDV_AdditionalParameters.Controls.Add(this.trackBar_RTDV_ReceivedImageSize);
            this.groupBox_RTDV_AdditionalParameters.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_RTDV_AdditionalParameters.Location = new System.Drawing.Point(16, 306);
            this.groupBox_RTDV_AdditionalParameters.Name = "groupBox_RTDV_AdditionalParameters";
            this.groupBox_RTDV_AdditionalParameters.Size = new System.Drawing.Size(192, 176);
            this.groupBox_RTDV_AdditionalParameters.TabIndex = 17;
            this.groupBox_RTDV_AdditionalParameters.TabStop = false;
            this.groupBox_RTDV_AdditionalParameters.Text = "Additional parameters";
            // 
            // label_RTDV_SizeMode
            // 
            this.label_RTDV_SizeMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RTDV_SizeMode.Location = new System.Drawing.Point(8, 32);
            this.label_RTDV_SizeMode.Name = "label_RTDV_SizeMode";
            this.label_RTDV_SizeMode.Size = new System.Drawing.Size(144, 16);
            this.label_RTDV_SizeMode.TabIndex = 4;
            this.label_RTDV_SizeMode.Text = "Size mode:";
            // 
            // comboBox_RTDV_SizeMode
            // 
            this.comboBox_RTDV_SizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RTDV_SizeMode.ItemHeight = 13;
            this.comboBox_RTDV_SizeMode.Items.AddRange(new object[] {
            "Auto size",
            "Stretch image"});
            this.comboBox_RTDV_SizeMode.Location = new System.Drawing.Point(8, 48);
            this.comboBox_RTDV_SizeMode.Name = "comboBox_RTDV_SizeMode";
            this.comboBox_RTDV_SizeMode.Size = new System.Drawing.Size(144, 21);
            this.comboBox_RTDV_SizeMode.TabIndex = 3;
            this.comboBox_RTDV_SizeMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_RTDV_SizeMode_SelectedIndexChanged);
            // 
            // label_RTDV_SelectedImageSize
            // 
            this.label_RTDV_SelectedImageSize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RTDV_SelectedImageSize.Location = new System.Drawing.Point(72, 152);
            this.label_RTDV_SelectedImageSize.Name = "label_RTDV_SelectedImageSize";
            this.label_RTDV_SelectedImageSize.Size = new System.Drawing.Size(88, 16);
            this.label_RTDV_SelectedImageSize.TabIndex = 2;
            this.label_RTDV_SelectedImageSize.Text = "Image Size";
            // 
            // label_RTDV_ReceivedImageSize
            // 
            this.label_RTDV_ReceivedImageSize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RTDV_ReceivedImageSize.Location = new System.Drawing.Point(8, 88);
            this.label_RTDV_ReceivedImageSize.Name = "label_RTDV_ReceivedImageSize";
            this.label_RTDV_ReceivedImageSize.Size = new System.Drawing.Size(176, 16);
            this.label_RTDV_ReceivedImageSize.TabIndex = 1;
            this.label_RTDV_ReceivedImageSize.Text = "Received image size:";
            // 
            // trackBar_RTDV_ReceivedImageSize
            // 
            this.trackBar_RTDV_ReceivedImageSize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar_RTDV_ReceivedImageSize.LargeChange = 1;
            this.trackBar_RTDV_ReceivedImageSize.Location = new System.Drawing.Point(8, 104);
            this.trackBar_RTDV_ReceivedImageSize.Maximum = 5;
            this.trackBar_RTDV_ReceivedImageSize.Name = "trackBar_RTDV_ReceivedImageSize";
            this.trackBar_RTDV_ReceivedImageSize.Size = new System.Drawing.Size(178, 45);
            this.trackBar_RTDV_ReceivedImageSize.TabIndex = 0;
            this.trackBar_RTDV_ReceivedImageSize.Value = 4;
            this.trackBar_RTDV_ReceivedImageSize.ValueChanged += new System.EventHandler(this.trackBar_RTDV_ReceivedImageSize_ValueChanged);
            // 
            // checkBox_RTDV_EnableRealTimeRemoteDisplayViewer
            // 
            this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer.Location = new System.Drawing.Point(16, 24);
            this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer.Name = "checkBox_RTDV_EnableRealTimeRemoteDisplayViewer";
            this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer.Size = new System.Drawing.Size(192, 16);
            this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer.TabIndex = 12;
            this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer.Text = "Enable";
            this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer.CheckedChanged += new System.EventHandler(this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer_CheckedChanged);
            // 
            // checkBox_RTDV_RealSize
            // 
            this.checkBox_RTDV_RealSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_RTDV_RealSize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_RTDV_RealSize.Location = new System.Drawing.Point(16, 45);
            this.checkBox_RTDV_RealSize.Name = "checkBox_RTDV_RealSize";
            this.checkBox_RTDV_RealSize.Size = new System.Drawing.Size(192, 16);
            this.checkBox_RTDV_RealSize.TabIndex = 15;
            this.checkBox_RTDV_RealSize.Text = "Real Size";
            this.checkBox_RTDV_RealSize.CheckedChanged += new System.EventHandler(this.checkBox_RTDV_RealSize_CheckedChanged);
            // 
            // label_RTDV_MaxUpdatePerSec
            // 
            this.label_RTDV_MaxUpdatePerSec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_RTDV_MaxUpdatePerSec.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RTDV_MaxUpdatePerSec.Location = new System.Drawing.Point(16, 285);
            this.label_RTDV_MaxUpdatePerSec.Name = "label_RTDV_MaxUpdatePerSec";
            this.label_RTDV_MaxUpdatePerSec.Size = new System.Drawing.Size(152, 16);
            this.label_RTDV_MaxUpdatePerSec.TabIndex = 14;
            this.label_RTDV_MaxUpdatePerSec.Text = "Maximum updates per second:";
            // 
            // checkBox_RTDV_AllowControl
            // 
            this.checkBox_RTDV_AllowControl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_RTDV_AllowControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_RTDV_AllowControl.Location = new System.Drawing.Point(16, 66);
            this.checkBox_RTDV_AllowControl.Name = "checkBox_RTDV_AllowControl";
            this.checkBox_RTDV_AllowControl.Size = new System.Drawing.Size(192, 16);
            this.checkBox_RTDV_AllowControl.TabIndex = 16;
            this.checkBox_RTDV_AllowControl.Text = "Control";
            // 
            // numericUpDown_RTDV_MaxUpdatePerSec
            // 
            this.numericUpDown_RTDV_MaxUpdatePerSec.Location = new System.Drawing.Point(168, 285);
            this.numericUpDown_RTDV_MaxUpdatePerSec.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_RTDV_MaxUpdatePerSec.Name = "numericUpDown_RTDV_MaxUpdatePerSec";
            this.numericUpDown_RTDV_MaxUpdatePerSec.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_RTDV_MaxUpdatePerSec.TabIndex = 13;
            this.numericUpDown_RTDV_MaxUpdatePerSec.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown_RTDV_MaxUpdatePerSec.ValueChanged += new System.EventHandler(this.numericUpDown_RTDV_MaxUpdatePerSec_ValueChanged);
            // 
            // tabPage_Message
            // 
            this.tabPage_Message.Controls.Add(this.groupBox_Message_ButtonSelect);
            this.tabPage_Message.Controls.Add(this.label_Message_MessageText);
            this.tabPage_Message.Controls.Add(this.label_Message_MessageCaption);
            this.tabPage_Message.Controls.Add(this.textBox_Message_MessageText);
            this.tabPage_Message.Controls.Add(this.textBox_Message_MessageCaption);
            this.tabPage_Message.Controls.Add(this.checkBox_Message_ReceiveUserChoice);
            this.tabPage_Message.Controls.Add(this.groupBox_Message_IconSelect);
            this.tabPage_Message.Controls.Add(this.button_Message_SendMessage);
            this.tabPage_Message.Location = new System.Drawing.Point(4, 40);
            this.tabPage_Message.Name = "tabPage_Message";
            this.tabPage_Message.Size = new System.Drawing.Size(944, 587);
            this.tabPage_Message.TabIndex = 6;
            this.tabPage_Message.Text = "Message";
            // 
            // groupBox_Message_ButtonSelect
            // 
            this.groupBox_Message_ButtonSelect.Controls.Add(this.radioButton_Message_AbortRetryIgnore);
            this.groupBox_Message_ButtonSelect.Controls.Add(this.radioButton_Message_radioButton_Message_YesNoCancel);
            this.groupBox_Message_ButtonSelect.Controls.Add(this.radioButton_Message_RetryCancel);
            this.groupBox_Message_ButtonSelect.Controls.Add(this.radioButton_Message_YesNo);
            this.groupBox_Message_ButtonSelect.Controls.Add(this.radioButton_Message_OkCancel);
            this.groupBox_Message_ButtonSelect.Controls.Add(this.radioButton_Message_Ok);
            this.groupBox_Message_ButtonSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_Message_ButtonSelect.Location = new System.Drawing.Point(712, 24);
            this.groupBox_Message_ButtonSelect.Name = "groupBox_Message_ButtonSelect";
            this.groupBox_Message_ButtonSelect.Size = new System.Drawing.Size(216, 184);
            this.groupBox_Message_ButtonSelect.TabIndex = 20;
            this.groupBox_Message_ButtonSelect.TabStop = false;
            // 
            // radioButton_Message_AbortRetryIgnore
            // 
            this.radioButton_Message_AbortRetryIgnore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_Message_AbortRetryIgnore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Message_AbortRetryIgnore.Location = new System.Drawing.Point(16, 144);
            this.radioButton_Message_AbortRetryIgnore.Name = "radioButton_Message_AbortRetryIgnore";
            this.radioButton_Message_AbortRetryIgnore.Size = new System.Drawing.Size(192, 24);
            this.radioButton_Message_AbortRetryIgnore.TabIndex = 10;
            this.radioButton_Message_AbortRetryIgnore.Text = "Abort Retry Ignore";
            // 
            // radioButton_Message_radioButton_Message_YesNoCancel
            // 
            this.radioButton_Message_radioButton_Message_YesNoCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_Message_radioButton_Message_YesNoCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Message_radioButton_Message_YesNoCancel.Location = new System.Drawing.Point(16, 120);
            this.radioButton_Message_radioButton_Message_YesNoCancel.Name = "radioButton_Message_radioButton_Message_YesNoCancel";
            this.radioButton_Message_radioButton_Message_YesNoCancel.Size = new System.Drawing.Size(144, 24);
            this.radioButton_Message_radioButton_Message_YesNoCancel.TabIndex = 9;
            this.radioButton_Message_radioButton_Message_YesNoCancel.Text = "Yes No Cancel";
            // 
            // radioButton_Message_RetryCancel
            // 
            this.radioButton_Message_RetryCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_Message_RetryCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Message_RetryCancel.Location = new System.Drawing.Point(16, 96);
            this.radioButton_Message_RetryCancel.Name = "radioButton_Message_RetryCancel";
            this.radioButton_Message_RetryCancel.Size = new System.Drawing.Size(120, 24);
            this.radioButton_Message_RetryCancel.TabIndex = 8;
            this.radioButton_Message_RetryCancel.Text = "Retry Cancel";
            // 
            // radioButton_Message_YesNo
            // 
            this.radioButton_Message_YesNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_Message_YesNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Message_YesNo.Location = new System.Drawing.Point(16, 48);
            this.radioButton_Message_YesNo.Name = "radioButton_Message_YesNo";
            this.radioButton_Message_YesNo.Size = new System.Drawing.Size(64, 24);
            this.radioButton_Message_YesNo.TabIndex = 7;
            this.radioButton_Message_YesNo.Text = "Yes No";
            // 
            // radioButton_Message_OkCancel
            // 
            this.radioButton_Message_OkCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_Message_OkCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Message_OkCancel.Location = new System.Drawing.Point(16, 72);
            this.radioButton_Message_OkCancel.Name = "radioButton_Message_OkCancel";
            this.radioButton_Message_OkCancel.Size = new System.Drawing.Size(96, 24);
            this.radioButton_Message_OkCancel.TabIndex = 6;
            this.radioButton_Message_OkCancel.Text = "OK Cancel";
            // 
            // radioButton_Message_Ok
            // 
            this.radioButton_Message_Ok.Checked = true;
            this.radioButton_Message_Ok.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_Message_Ok.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Message_Ok.Location = new System.Drawing.Point(16, 24);
            this.radioButton_Message_Ok.Name = "radioButton_Message_Ok";
            this.radioButton_Message_Ok.Size = new System.Drawing.Size(40, 24);
            this.radioButton_Message_Ok.TabIndex = 5;
            this.radioButton_Message_Ok.TabStop = true;
            this.radioButton_Message_Ok.Text = "OK";
            // 
            // label_Message_MessageText
            // 
            this.label_Message_MessageText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Message_MessageText.Location = new System.Drawing.Point(16, 72);
            this.label_Message_MessageText.Name = "label_Message_MessageText";
            this.label_Message_MessageText.Size = new System.Drawing.Size(104, 16);
            this.label_Message_MessageText.TabIndex = 19;
            this.label_Message_MessageText.Text = "Message Text:";
            // 
            // label_Message_MessageCaption
            // 
            this.label_Message_MessageCaption.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Message_MessageCaption.Location = new System.Drawing.Point(16, 16);
            this.label_Message_MessageCaption.Name = "label_Message_MessageCaption";
            this.label_Message_MessageCaption.Size = new System.Drawing.Size(160, 16);
            this.label_Message_MessageCaption.TabIndex = 18;
            this.label_Message_MessageCaption.Text = "Message Caption:";
            // 
            // textBox_Message_MessageText
            // 
            this.textBox_Message_MessageText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_Message_MessageText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Message_MessageText.Location = new System.Drawing.Point(8, 88);
            this.textBox_Message_MessageText.Multiline = true;
            this.textBox_Message_MessageText.Name = "textBox_Message_MessageText";
            this.textBox_Message_MessageText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Message_MessageText.Size = new System.Drawing.Size(528, 472);
            this.textBox_Message_MessageText.TabIndex = 17;
            // 
            // textBox_Message_MessageCaption
            // 
            this.textBox_Message_MessageCaption.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_Message_MessageCaption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Message_MessageCaption.Location = new System.Drawing.Point(8, 32);
            this.textBox_Message_MessageCaption.Name = "textBox_Message_MessageCaption";
            this.textBox_Message_MessageCaption.Size = new System.Drawing.Size(528, 20);
            this.textBox_Message_MessageCaption.TabIndex = 16;
            // 
            // checkBox_Message_ReceiveUserChoice
            // 
            this.checkBox_Message_ReceiveUserChoice.Checked = true;
            this.checkBox_Message_ReceiveUserChoice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Message_ReceiveUserChoice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_Message_ReceiveUserChoice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_Message_ReceiveUserChoice.Location = new System.Drawing.Point(712, 224);
            this.checkBox_Message_ReceiveUserChoice.Name = "checkBox_Message_ReceiveUserChoice";
            this.checkBox_Message_ReceiveUserChoice.Size = new System.Drawing.Size(216, 24);
            this.checkBox_Message_ReceiveUserChoice.TabIndex = 15;
            this.checkBox_Message_ReceiveUserChoice.Text = "Receive a user choice";
            // 
            // groupBox_Message_IconSelect
            // 
            this.groupBox_Message_IconSelect.Controls.Add(this.pictureBox_Message_IconStop);
            this.groupBox_Message_IconSelect.Controls.Add(this.pictureBox_Message_IconInformation);
            this.groupBox_Message_IconSelect.Controls.Add(this.pictureBox_Message_IconWarning);
            this.groupBox_Message_IconSelect.Controls.Add(this.pictureBox_Message_IconQuestion);
            this.groupBox_Message_IconSelect.Controls.Add(this.radioButton_Message_IconNone);
            this.groupBox_Message_IconSelect.Controls.Add(this.radioButton_Message_IconStop);
            this.groupBox_Message_IconSelect.Controls.Add(this.radioButton_Message_IconWarning);
            this.groupBox_Message_IconSelect.Controls.Add(this.radioButton_Message_IconQuestion);
            this.groupBox_Message_IconSelect.Controls.Add(this.radioButton_Message_IconInformation);
            this.groupBox_Message_IconSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_Message_IconSelect.Location = new System.Drawing.Point(552, 24);
            this.groupBox_Message_IconSelect.Name = "groupBox_Message_IconSelect";
            this.groupBox_Message_IconSelect.Size = new System.Drawing.Size(144, 184);
            this.groupBox_Message_IconSelect.TabIndex = 14;
            this.groupBox_Message_IconSelect.TabStop = false;
            // 
            // pictureBox_Message_IconStop
            // 
            this.pictureBox_Message_IconStop.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Message_IconStop.Image")));
            this.pictureBox_Message_IconStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox_Message_IconStop.Location = new System.Drawing.Point(32, 88);
            this.pictureBox_Message_IconStop.Name = "pictureBox_Message_IconStop";
            this.pictureBox_Message_IconStop.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_Message_IconStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Message_IconStop.TabIndex = 15;
            this.pictureBox_Message_IconStop.TabStop = false;
            // 
            // pictureBox_Message_IconInformation
            // 
            this.pictureBox_Message_IconInformation.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Message_IconInformation.Image")));
            this.pictureBox_Message_IconInformation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox_Message_IconInformation.Location = new System.Drawing.Point(96, 32);
            this.pictureBox_Message_IconInformation.Name = "pictureBox_Message_IconInformation";
            this.pictureBox_Message_IconInformation.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_Message_IconInformation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Message_IconInformation.TabIndex = 14;
            this.pictureBox_Message_IconInformation.TabStop = false;
            // 
            // pictureBox_Message_IconWarning
            // 
            this.pictureBox_Message_IconWarning.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Message_IconWarning.Image")));
            this.pictureBox_Message_IconWarning.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox_Message_IconWarning.Location = new System.Drawing.Point(96, 88);
            this.pictureBox_Message_IconWarning.Name = "pictureBox_Message_IconWarning";
            this.pictureBox_Message_IconWarning.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_Message_IconWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Message_IconWarning.TabIndex = 13;
            this.pictureBox_Message_IconWarning.TabStop = false;
            // 
            // pictureBox_Message_IconQuestion
            // 
            this.pictureBox_Message_IconQuestion.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_Message_IconQuestion.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Message_IconQuestion.Image")));
            this.pictureBox_Message_IconQuestion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox_Message_IconQuestion.Location = new System.Drawing.Point(32, 32);
            this.pictureBox_Message_IconQuestion.Name = "pictureBox_Message_IconQuestion";
            this.pictureBox_Message_IconQuestion.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_Message_IconQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Message_IconQuestion.TabIndex = 12;
            this.pictureBox_Message_IconQuestion.TabStop = false;
            // 
            // radioButton_Message_IconNone
            // 
            this.radioButton_Message_IconNone.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_Message_IconNone.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Message_IconNone.Location = new System.Drawing.Point(16, 152);
            this.radioButton_Message_IconNone.Name = "radioButton_Message_IconNone";
            this.radioButton_Message_IconNone.Size = new System.Drawing.Size(72, 16);
            this.radioButton_Message_IconNone.TabIndex = 11;
            this.radioButton_Message_IconNone.Text = "None";
            // 
            // radioButton_Message_IconStop
            // 
            this.radioButton_Message_IconStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_Message_IconStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Message_IconStop.Location = new System.Drawing.Point(16, 88);
            this.radioButton_Message_IconStop.Name = "radioButton_Message_IconStop";
            this.radioButton_Message_IconStop.Size = new System.Drawing.Size(16, 40);
            this.radioButton_Message_IconStop.TabIndex = 2;
            // 
            // radioButton_Message_IconWarning
            // 
            this.radioButton_Message_IconWarning.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_Message_IconWarning.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Message_IconWarning.Location = new System.Drawing.Point(80, 88);
            this.radioButton_Message_IconWarning.Name = "radioButton_Message_IconWarning";
            this.radioButton_Message_IconWarning.Size = new System.Drawing.Size(16, 40);
            this.radioButton_Message_IconWarning.TabIndex = 4;
            // 
            // radioButton_Message_IconQuestion
            // 
            this.radioButton_Message_IconQuestion.Checked = true;
            this.radioButton_Message_IconQuestion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_Message_IconQuestion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Message_IconQuestion.Location = new System.Drawing.Point(16, 32);
            this.radioButton_Message_IconQuestion.Name = "radioButton_Message_IconQuestion";
            this.radioButton_Message_IconQuestion.Size = new System.Drawing.Size(16, 40);
            this.radioButton_Message_IconQuestion.TabIndex = 1;
            this.radioButton_Message_IconQuestion.TabStop = true;
            // 
            // radioButton_Message_IconInformation
            // 
            this.radioButton_Message_IconInformation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_Message_IconInformation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Message_IconInformation.Location = new System.Drawing.Point(80, 32);
            this.radioButton_Message_IconInformation.Name = "radioButton_Message_IconInformation";
            this.radioButton_Message_IconInformation.Size = new System.Drawing.Size(16, 40);
            this.radioButton_Message_IconInformation.TabIndex = 3;
            // 
            // button_Message_SendMessage
            // 
            this.button_Message_SendMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_Message_SendMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Message_SendMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_Message_SendMessage.Location = new System.Drawing.Point(552, 224);
            this.button_Message_SendMessage.Name = "button_Message_SendMessage";
            this.button_Message_SendMessage.Size = new System.Drawing.Size(144, 23);
            this.button_Message_SendMessage.TabIndex = 13;
            this.button_Message_SendMessage.Text = "Send Message";
            this.button_Message_SendMessage.Click += new System.EventHandler(this.button_Message_SendMessage_Click);
            // 
            // tabPage_ClipboardManager
            // 
            this.tabPage_ClipboardManager.Controls.Add(this.checkBox_ClipboardManager_ShowWarnings);
            this.tabPage_ClipboardManager.Controls.Add(this.groupBox_ClipboardManager_ClipboardImageSettings);
            this.tabPage_ClipboardManager.Controls.Add(this.button_ClipboardManager_RefreshClipboardsTypeInfo);
            this.tabPage_ClipboardManager.Controls.Add(this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval);
            this.tabPage_ClipboardManager.Controls.Add(this.label_ClipboardManager_RefreshClipboardsTypeInfoInterval);
            this.tabPage_ClipboardManager.Controls.Add(this.groupBox_ClipboardManager_AddClipboardImageSettings);
            this.tabPage_ClipboardManager.Controls.Add(this.button_ClipboardManager_PreviewRemoteClipboard);
            this.tabPage_ClipboardManager.Controls.Add(this.groupBox_ClipboardManager_Image);
            this.tabPage_ClipboardManager.Controls.Add(this.textBox_ClipboardManager_RemoteClipboardType);
            this.tabPage_ClipboardManager.Controls.Add(this.label_ClipboardManager_RemoteClipboardType);
            this.tabPage_ClipboardManager.Controls.Add(this.textBox_ClipboardManager_LocalClipboardType);
            this.tabPage_ClipboardManager.Controls.Add(this.label_ClipboardManager_LocalClipboardType);
            this.tabPage_ClipboardManager.Controls.Add(this.button_ClipboardManager_ClearLocalClipboard);
            this.tabPage_ClipboardManager.Controls.Add(this.button_ClipboardManager_ClearRemoteClipboard);
            this.tabPage_ClipboardManager.Controls.Add(this.button_ClipboardManager_Local2RemoteSync);
            this.tabPage_ClipboardManager.Controls.Add(this.button_ClipboardManager_Remote2LocalSync);
            this.tabPage_ClipboardManager.Controls.Add(this.button_ClipboardManager_PreviewLocalClipboard);
            this.tabPage_ClipboardManager.Controls.Add(this.groupBox_ClipboardManager_TextData);
            this.tabPage_ClipboardManager.Controls.Add(this.groupBox_ClipboardManager_FileDropList);
            this.tabPage_ClipboardManager.Location = new System.Drawing.Point(4, 40);
            this.tabPage_ClipboardManager.Name = "tabPage_ClipboardManager";
            this.tabPage_ClipboardManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ClipboardManager.Size = new System.Drawing.Size(944, 587);
            this.tabPage_ClipboardManager.TabIndex = 17;
            this.tabPage_ClipboardManager.Text = "Clipboard Manager";
            // 
            // checkBox_ClipboardManager_ShowWarnings
            // 
            this.checkBox_ClipboardManager_ShowWarnings.AutoSize = true;
            this.checkBox_ClipboardManager_ShowWarnings.Checked = true;
            this.checkBox_ClipboardManager_ShowWarnings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ClipboardManager_ShowWarnings.Location = new System.Drawing.Point(9, 79);
            this.checkBox_ClipboardManager_ShowWarnings.Name = "checkBox_ClipboardManager_ShowWarnings";
            this.checkBox_ClipboardManager_ShowWarnings.Size = new System.Drawing.Size(101, 17);
            this.checkBox_ClipboardManager_ShowWarnings.TabIndex = 31;
            this.checkBox_ClipboardManager_ShowWarnings.Text = "Show Warnings";
            this.checkBox_ClipboardManager_ShowWarnings.UseVisualStyleBackColor = true;
            // 
            // groupBox_ClipboardManager_ClipboardImageSettings
            // 
            this.groupBox_ClipboardManager_ClipboardImageSettings.Controls.Add(this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode);
            this.groupBox_ClipboardManager_ClipboardImageSettings.Controls.Add(this.label_RemoteClipboardImageSettings_PreviewSizeMode);
            this.groupBox_ClipboardManager_ClipboardImageSettings.Controls.Add(this.comboBox_RemoteClipboardImageSettings_ImageFormat);
            this.groupBox_ClipboardManager_ClipboardImageSettings.Controls.Add(this.label_RemoteClipboardImageSettings_ImageQuality);
            this.groupBox_ClipboardManager_ClipboardImageSettings.Controls.Add(this.label_RemoteClipboardImageSettings_ImageFormat);
            this.groupBox_ClipboardManager_ClipboardImageSettings.Controls.Add(this.label_RemoteClipboardImageSettings_CompressionFormat);
            this.groupBox_ClipboardManager_ClipboardImageSettings.Controls.Add(this.trackBar_RemoteClipboardImageSettings_ImageQuality);
            this.groupBox_ClipboardManager_ClipboardImageSettings.Controls.Add(this.comboBox_RemoteClipboardImageSettings_CompressionFormat);
            this.groupBox_ClipboardManager_ClipboardImageSettings.Location = new System.Drawing.Point(367, 6);
            this.groupBox_ClipboardManager_ClipboardImageSettings.Name = "groupBox_ClipboardManager_ClipboardImageSettings";
            this.groupBox_ClipboardManager_ClipboardImageSettings.Size = new System.Drawing.Size(193, 282);
            this.groupBox_ClipboardManager_ClipboardImageSettings.TabIndex = 24;
            this.groupBox_ClipboardManager_ClipboardImageSettings.TabStop = false;
            this.groupBox_ClipboardManager_ClipboardImageSettings.Text = "Clipboard Image Settings";
            // 
            // comboBox_RemoteClipboardImageSettings_PreviewSizeMode
            // 
            this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode.ItemHeight = 13;
            this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode.Items.AddRange(new object[] {
            "Auto size",
            "Stretch image",
            "Center image"});
            this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode.Location = new System.Drawing.Point(16, 253);
            this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode.Name = "comboBox_RemoteClipboardImageSettings_PreviewSizeMode";
            this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode.Size = new System.Drawing.Size(164, 21);
            this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode.TabIndex = 24;
            this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode_SelectedIndexChanged);
            // 
            // label_RemoteClipboardImageSettings_PreviewSizeMode
            // 
            this.label_RemoteClipboardImageSettings_PreviewSizeMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteClipboardImageSettings_PreviewSizeMode.Location = new System.Drawing.Point(13, 237);
            this.label_RemoteClipboardImageSettings_PreviewSizeMode.Name = "label_RemoteClipboardImageSettings_PreviewSizeMode";
            this.label_RemoteClipboardImageSettings_PreviewSizeMode.Size = new System.Drawing.Size(167, 16);
            this.label_RemoteClipboardImageSettings_PreviewSizeMode.TabIndex = 25;
            this.label_RemoteClipboardImageSettings_PreviewSizeMode.Text = "Preview Area Size Mode:";
            // 
            // comboBox_RemoteClipboardImageSettings_ImageFormat
            // 
            this.comboBox_RemoteClipboardImageSettings_ImageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RemoteClipboardImageSettings_ImageFormat.ItemHeight = 13;
            this.comboBox_RemoteClipboardImageSettings_ImageFormat.Location = new System.Drawing.Point(16, 44);
            this.comboBox_RemoteClipboardImageSettings_ImageFormat.Name = "comboBox_RemoteClipboardImageSettings_ImageFormat";
            this.comboBox_RemoteClipboardImageSettings_ImageFormat.Size = new System.Drawing.Size(164, 21);
            this.comboBox_RemoteClipboardImageSettings_ImageFormat.TabIndex = 18;
            this.comboBox_RemoteClipboardImageSettings_ImageFormat.SelectedIndexChanged += new System.EventHandler(this.comboBox_RemoteClipboardImageSettings_ImageFormat_SelectedIndexChanged);
            // 
            // label_RemoteClipboardImageSettings_ImageQuality
            // 
            this.label_RemoteClipboardImageSettings_ImageQuality.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteClipboardImageSettings_ImageQuality.Location = new System.Drawing.Point(13, 154);
            this.label_RemoteClipboardImageSettings_ImageQuality.Name = "label_RemoteClipboardImageSettings_ImageQuality";
            this.label_RemoteClipboardImageSettings_ImageQuality.Size = new System.Drawing.Size(136, 18);
            this.label_RemoteClipboardImageSettings_ImageQuality.TabIndex = 23;
            this.label_RemoteClipboardImageSettings_ImageQuality.Text = "Image quality:";
            this.label_RemoteClipboardImageSettings_ImageQuality.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label_RemoteClipboardImageSettings_ImageFormat
            // 
            this.label_RemoteClipboardImageSettings_ImageFormat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteClipboardImageSettings_ImageFormat.Location = new System.Drawing.Point(13, 28);
            this.label_RemoteClipboardImageSettings_ImageFormat.Name = "label_RemoteClipboardImageSettings_ImageFormat";
            this.label_RemoteClipboardImageSettings_ImageFormat.Size = new System.Drawing.Size(167, 16);
            this.label_RemoteClipboardImageSettings_ImageFormat.TabIndex = 19;
            this.label_RemoteClipboardImageSettings_ImageFormat.Text = "Image format:";
            // 
            // label_RemoteClipboardImageSettings_CompressionFormat
            // 
            this.label_RemoteClipboardImageSettings_CompressionFormat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteClipboardImageSettings_CompressionFormat.Location = new System.Drawing.Point(13, 89);
            this.label_RemoteClipboardImageSettings_CompressionFormat.Name = "label_RemoteClipboardImageSettings_CompressionFormat";
            this.label_RemoteClipboardImageSettings_CompressionFormat.Size = new System.Drawing.Size(160, 16);
            this.label_RemoteClipboardImageSettings_CompressionFormat.TabIndex = 21;
            this.label_RemoteClipboardImageSettings_CompressionFormat.Text = "Compression format:";
            // 
            // trackBar_RemoteClipboardImageSettings_ImageQuality
            // 
            this.trackBar_RemoteClipboardImageSettings_ImageQuality.AutoSize = false;
            this.trackBar_RemoteClipboardImageSettings_ImageQuality.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar_RemoteClipboardImageSettings_ImageQuality.LargeChange = 1;
            this.trackBar_RemoteClipboardImageSettings_ImageQuality.Location = new System.Drawing.Point(8, 175);
            this.trackBar_RemoteClipboardImageSettings_ImageQuality.Maximum = 100;
            this.trackBar_RemoteClipboardImageSettings_ImageQuality.Name = "trackBar_RemoteClipboardImageSettings_ImageQuality";
            this.trackBar_RemoteClipboardImageSettings_ImageQuality.Size = new System.Drawing.Size(180, 32);
            this.trackBar_RemoteClipboardImageSettings_ImageQuality.TabIndex = 22;
            this.trackBar_RemoteClipboardImageSettings_ImageQuality.TickFrequency = 5;
            this.trackBar_RemoteClipboardImageSettings_ImageQuality.Value = 100;
            // 
            // comboBox_RemoteClipboardImageSettings_CompressionFormat
            // 
            this.comboBox_RemoteClipboardImageSettings_CompressionFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RemoteClipboardImageSettings_CompressionFormat.ItemHeight = 13;
            this.comboBox_RemoteClipboardImageSettings_CompressionFormat.Items.AddRange(new object[] {
            "LZW",
            "None"});
            this.comboBox_RemoteClipboardImageSettings_CompressionFormat.Location = new System.Drawing.Point(16, 108);
            this.comboBox_RemoteClipboardImageSettings_CompressionFormat.Name = "comboBox_RemoteClipboardImageSettings_CompressionFormat";
            this.comboBox_RemoteClipboardImageSettings_CompressionFormat.Size = new System.Drawing.Size(164, 21);
            this.comboBox_RemoteClipboardImageSettings_CompressionFormat.TabIndex = 20;
            // 
            // button_ClipboardManager_RefreshClipboardsTypeInfo
            // 
            this.button_ClipboardManager_RefreshClipboardsTypeInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ClipboardManager_RefreshClipboardsTypeInfo.Location = new System.Drawing.Point(9, 181);
            this.button_ClipboardManager_RefreshClipboardsTypeInfo.Name = "button_ClipboardManager_RefreshClipboardsTypeInfo";
            this.button_ClipboardManager_RefreshClipboardsTypeInfo.Size = new System.Drawing.Size(170, 23);
            this.button_ClipboardManager_RefreshClipboardsTypeInfo.TabIndex = 30;
            this.button_ClipboardManager_RefreshClipboardsTypeInfo.Text = "Refresh Clipboards Type Info";
            this.button_ClipboardManager_RefreshClipboardsTypeInfo.UseVisualStyleBackColor = false;
            this.button_ClipboardManager_RefreshClipboardsTypeInfo.Click += new System.EventHandler(this.button_ClipboardManager_RefreshClipboardsTypeInfo_Click);
            // 
            // comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval
            // 
            this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval.ItemHeight = 13;
            this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval.Items.AddRange(new object[] {
            "Stopped",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30"});
            this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval.Location = new System.Drawing.Point(191, 183);
            this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval.Name = "comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval";
            this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval.Size = new System.Drawing.Size(166, 21);
            this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval.TabIndex = 28;
            this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval.SelectedIndexChanged += new System.EventHandler(this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval_SelectedIndexChanged);
            // 
            // label_ClipboardManager_RefreshClipboardsTypeInfoInterval
            // 
            this.label_ClipboardManager_RefreshClipboardsTypeInfoInterval.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_ClipboardManager_RefreshClipboardsTypeInfoInterval.Location = new System.Drawing.Point(188, 164);
            this.label_ClipboardManager_RefreshClipboardsTypeInfoInterval.Name = "label_ClipboardManager_RefreshClipboardsTypeInfoInterval";
            this.label_ClipboardManager_RefreshClipboardsTypeInfoInterval.Size = new System.Drawing.Size(167, 16);
            this.label_ClipboardManager_RefreshClipboardsTypeInfoInterval.TabIndex = 29;
            this.label_ClipboardManager_RefreshClipboardsTypeInfoInterval.Text = "Refresh using interval (sec):";
            // 
            // groupBox_ClipboardManager_AddClipboardImageSettings
            // 
            this.groupBox_ClipboardManager_AddClipboardImageSettings.Controls.Add(this.button_RemoteClipboardImageEnv_SendImage);
            this.groupBox_ClipboardManager_AddClipboardImageSettings.Controls.Add(this.button_RemoteClipboardImageEnv_SaveImageToDisk);
            this.groupBox_ClipboardManager_AddClipboardImageSettings.Location = new System.Drawing.Point(-12, 100);
            this.groupBox_ClipboardManager_AddClipboardImageSettings.Name = "groupBox_ClipboardManager_AddClipboardImageSettings";
            this.groupBox_ClipboardManager_AddClipboardImageSettings.Size = new System.Drawing.Size(386, 54);
            this.groupBox_ClipboardManager_AddClipboardImageSettings.TabIndex = 27;
            this.groupBox_ClipboardManager_AddClipboardImageSettings.TabStop = false;
            // 
            // button_RemoteClipboardImageEnv_SendImage
            // 
            this.button_RemoteClipboardImageEnv_SendImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_RemoteClipboardImageEnv_SendImage.Location = new System.Drawing.Point(21, 19);
            this.button_RemoteClipboardImageEnv_SendImage.Name = "button_RemoteClipboardImageEnv_SendImage";
            this.button_RemoteClipboardImageEnv_SendImage.Size = new System.Drawing.Size(170, 23);
            this.button_RemoteClipboardImageEnv_SendImage.TabIndex = 25;
            this.button_RemoteClipboardImageEnv_SendImage.Text = "Send Image to Remote PC";
            this.button_RemoteClipboardImageEnv_SendImage.UseVisualStyleBackColor = false;
            this.button_RemoteClipboardImageEnv_SendImage.Click += new System.EventHandler(this.button_RemoteClipboardImageEnv_SendImage_Click);
            // 
            // button_RemoteClipboardImageEnv_SaveImageToDisk
            // 
            this.button_RemoteClipboardImageEnv_SaveImageToDisk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_RemoteClipboardImageEnv_SaveImageToDisk.Location = new System.Drawing.Point(200, 19);
            this.button_RemoteClipboardImageEnv_SaveImageToDisk.Name = "button_RemoteClipboardImageEnv_SaveImageToDisk";
            this.button_RemoteClipboardImageEnv_SaveImageToDisk.Size = new System.Drawing.Size(166, 23);
            this.button_RemoteClipboardImageEnv_SaveImageToDisk.TabIndex = 26;
            this.button_RemoteClipboardImageEnv_SaveImageToDisk.Text = "Save Image to local disk";
            this.button_RemoteClipboardImageEnv_SaveImageToDisk.UseVisualStyleBackColor = false;
            this.button_RemoteClipboardImageEnv_SaveImageToDisk.Click += new System.EventHandler(this.button_RemoteClipboardImageEnv_SaveImageToDisk_Click);
            // 
            // button_ClipboardManager_PreviewRemoteClipboard
            // 
            this.button_ClipboardManager_PreviewRemoteClipboard.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ClipboardManager_PreviewRemoteClipboard.Location = new System.Drawing.Point(9, 14);
            this.button_ClipboardManager_PreviewRemoteClipboard.Name = "button_ClipboardManager_PreviewRemoteClipboard";
            this.button_ClipboardManager_PreviewRemoteClipboard.Size = new System.Drawing.Size(170, 23);
            this.button_ClipboardManager_PreviewRemoteClipboard.TabIndex = 14;
            this.button_ClipboardManager_PreviewRemoteClipboard.Text = "Preview Remote Clipboard data";
            this.button_ClipboardManager_PreviewRemoteClipboard.UseVisualStyleBackColor = false;
            this.button_ClipboardManager_PreviewRemoteClipboard.Click += new System.EventHandler(this.button_ClipboardManager_PreviewRemoteClipboard_Click);
            // 
            // groupBox_ClipboardManager_Image
            // 
            this.groupBox_ClipboardManager_Image.Controls.Add(this.pictureBox_ClipboardManager_Image);
            this.groupBox_ClipboardManager_Image.Location = new System.Drawing.Point(566, 6);
            this.groupBox_ClipboardManager_Image.Name = "groupBox_ClipboardManager_Image";
            this.groupBox_ClipboardManager_Image.Size = new System.Drawing.Size(372, 282);
            this.groupBox_ClipboardManager_Image.TabIndex = 0;
            this.groupBox_ClipboardManager_Image.TabStop = false;
            this.groupBox_ClipboardManager_Image.Text = "Image Preview";
            // 
            // pictureBox_ClipboardManager_Image
            // 
            this.pictureBox_ClipboardManager_Image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_ClipboardManager_Image.Location = new System.Drawing.Point(6, 22);
            this.pictureBox_ClipboardManager_Image.Name = "pictureBox_ClipboardManager_Image";
            this.pictureBox_ClipboardManager_Image.Size = new System.Drawing.Size(360, 254);
            this.pictureBox_ClipboardManager_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_ClipboardManager_Image.TabIndex = 0;
            this.pictureBox_ClipboardManager_Image.TabStop = false;
            // 
            // textBox_ClipboardManager_RemoteClipboardType
            // 
            this.textBox_ClipboardManager_RemoteClipboardType.Location = new System.Drawing.Point(191, 262);
            this.textBox_ClipboardManager_RemoteClipboardType.Name = "textBox_ClipboardManager_RemoteClipboardType";
            this.textBox_ClipboardManager_RemoteClipboardType.ReadOnly = true;
            this.textBox_ClipboardManager_RemoteClipboardType.Size = new System.Drawing.Size(166, 20);
            this.textBox_ClipboardManager_RemoteClipboardType.TabIndex = 11;
            // 
            // label_ClipboardManager_RemoteClipboardType
            // 
            this.label_ClipboardManager_RemoteClipboardType.AutoSize = true;
            this.label_ClipboardManager_RemoteClipboardType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_ClipboardManager_RemoteClipboardType.Location = new System.Drawing.Point(188, 246);
            this.label_ClipboardManager_RemoteClipboardType.Name = "label_ClipboardManager_RemoteClipboardType";
            this.label_ClipboardManager_RemoteClipboardType.Size = new System.Drawing.Size(117, 13);
            this.label_ClipboardManager_RemoteClipboardType.TabIndex = 10;
            this.label_ClipboardManager_RemoteClipboardType.Text = "Remote Clipboard type:";
            this.label_ClipboardManager_RemoteClipboardType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_ClipboardManager_LocalClipboardType
            // 
            this.textBox_ClipboardManager_LocalClipboardType.Location = new System.Drawing.Point(191, 223);
            this.textBox_ClipboardManager_LocalClipboardType.Name = "textBox_ClipboardManager_LocalClipboardType";
            this.textBox_ClipboardManager_LocalClipboardType.ReadOnly = true;
            this.textBox_ClipboardManager_LocalClipboardType.Size = new System.Drawing.Size(166, 20);
            this.textBox_ClipboardManager_LocalClipboardType.TabIndex = 9;
            // 
            // label_ClipboardManager_LocalClipboardType
            // 
            this.label_ClipboardManager_LocalClipboardType.AutoSize = true;
            this.label_ClipboardManager_LocalClipboardType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_ClipboardManager_LocalClipboardType.Location = new System.Drawing.Point(188, 207);
            this.label_ClipboardManager_LocalClipboardType.Name = "label_ClipboardManager_LocalClipboardType";
            this.label_ClipboardManager_LocalClipboardType.Size = new System.Drawing.Size(106, 13);
            this.label_ClipboardManager_LocalClipboardType.TabIndex = 8;
            this.label_ClipboardManager_LocalClipboardType.Text = "Local Clipboard type:";
            this.label_ClipboardManager_LocalClipboardType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_ClipboardManager_ClearLocalClipboard
            // 
            this.button_ClipboardManager_ClearLocalClipboard.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ClipboardManager_ClearLocalClipboard.Location = new System.Drawing.Point(188, 50);
            this.button_ClipboardManager_ClearLocalClipboard.Name = "button_ClipboardManager_ClearLocalClipboard";
            this.button_ClipboardManager_ClearLocalClipboard.Size = new System.Drawing.Size(166, 23);
            this.button_ClipboardManager_ClearLocalClipboard.TabIndex = 7;
            this.button_ClipboardManager_ClearLocalClipboard.Text = "Clear Local Clipboard";
            this.button_ClipboardManager_ClearLocalClipboard.UseVisualStyleBackColor = false;
            this.button_ClipboardManager_ClearLocalClipboard.Click += new System.EventHandler(this.button_ClipboardManager_ClearLocalClipboard_Click);
            // 
            // button_ClipboardManager_ClearRemoteClipboard
            // 
            this.button_ClipboardManager_ClearRemoteClipboard.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ClipboardManager_ClearRemoteClipboard.Location = new System.Drawing.Point(188, 14);
            this.button_ClipboardManager_ClearRemoteClipboard.Name = "button_ClipboardManager_ClearRemoteClipboard";
            this.button_ClipboardManager_ClearRemoteClipboard.Size = new System.Drawing.Size(166, 23);
            this.button_ClipboardManager_ClearRemoteClipboard.TabIndex = 6;
            this.button_ClipboardManager_ClearRemoteClipboard.Text = "Clear Remote Clipboard";
            this.button_ClipboardManager_ClearRemoteClipboard.UseVisualStyleBackColor = false;
            this.button_ClipboardManager_ClearRemoteClipboard.Click += new System.EventHandler(this.button_ClipboardManager_ClearRemoteClipboard_Click);
            // 
            // button_ClipboardManager_Local2RemoteSync
            // 
            this.button_ClipboardManager_Local2RemoteSync.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ClipboardManager_Local2RemoteSync.Location = new System.Drawing.Point(9, 259);
            this.button_ClipboardManager_Local2RemoteSync.Name = "button_ClipboardManager_Local2RemoteSync";
            this.button_ClipboardManager_Local2RemoteSync.Size = new System.Drawing.Size(170, 23);
            this.button_ClipboardManager_Local2RemoteSync.TabIndex = 5;
            this.button_ClipboardManager_Local2RemoteSync.Text = "Local Clipboard to Remote Sync";
            this.button_ClipboardManager_Local2RemoteSync.UseVisualStyleBackColor = false;
            this.button_ClipboardManager_Local2RemoteSync.Click += new System.EventHandler(this.button_ClipboardManager_Local2RemoteSync_Click);
            // 
            // button_ClipboardManager_Remote2LocalSync
            // 
            this.button_ClipboardManager_Remote2LocalSync.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ClipboardManager_Remote2LocalSync.Location = new System.Drawing.Point(9, 220);
            this.button_ClipboardManager_Remote2LocalSync.Name = "button_ClipboardManager_Remote2LocalSync";
            this.button_ClipboardManager_Remote2LocalSync.Size = new System.Drawing.Size(170, 23);
            this.button_ClipboardManager_Remote2LocalSync.TabIndex = 4;
            this.button_ClipboardManager_Remote2LocalSync.Text = "Remote Clipboard to Local Sync";
            this.button_ClipboardManager_Remote2LocalSync.UseVisualStyleBackColor = false;
            this.button_ClipboardManager_Remote2LocalSync.Click += new System.EventHandler(this.button_ClipboardManager_Remote2LocalSync_Click);
            // 
            // button_ClipboardManager_PreviewLocalClipboard
            // 
            this.button_ClipboardManager_PreviewLocalClipboard.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ClipboardManager_PreviewLocalClipboard.Location = new System.Drawing.Point(9, 50);
            this.button_ClipboardManager_PreviewLocalClipboard.Name = "button_ClipboardManager_PreviewLocalClipboard";
            this.button_ClipboardManager_PreviewLocalClipboard.Size = new System.Drawing.Size(170, 23);
            this.button_ClipboardManager_PreviewLocalClipboard.TabIndex = 3;
            this.button_ClipboardManager_PreviewLocalClipboard.Text = "Preview Local Clipboard data";
            this.button_ClipboardManager_PreviewLocalClipboard.UseVisualStyleBackColor = false;
            this.button_ClipboardManager_PreviewLocalClipboard.Click += new System.EventHandler(this.button_ClipboardManager_PreviewLocalClipboard_Click);
            // 
            // groupBox_ClipboardManager_TextData
            // 
            this.groupBox_ClipboardManager_TextData.Controls.Add(this.richTextBox_ClipboardManager_TextData);
            this.groupBox_ClipboardManager_TextData.Location = new System.Drawing.Point(9, 291);
            this.groupBox_ClipboardManager_TextData.Name = "groupBox_ClipboardManager_TextData";
            this.groupBox_ClipboardManager_TextData.Size = new System.Drawing.Size(551, 282);
            this.groupBox_ClipboardManager_TextData.TabIndex = 2;
            this.groupBox_ClipboardManager_TextData.TabStop = false;
            this.groupBox_ClipboardManager_TextData.Text = "Text Data";
            // 
            // richTextBox_ClipboardManager_TextData
            // 
            this.richTextBox_ClipboardManager_TextData.AcceptsTab = true;
            this.richTextBox_ClipboardManager_TextData.Location = new System.Drawing.Point(6, 19);
            this.richTextBox_ClipboardManager_TextData.Name = "richTextBox_ClipboardManager_TextData";
            this.richTextBox_ClipboardManager_TextData.ReadOnly = true;
            this.richTextBox_ClipboardManager_TextData.Size = new System.Drawing.Size(539, 257);
            this.richTextBox_ClipboardManager_TextData.TabIndex = 0;
            this.richTextBox_ClipboardManager_TextData.Text = "";
            // 
            // groupBox_ClipboardManager_FileDropList
            // 
            this.groupBox_ClipboardManager_FileDropList.Controls.Add(this.listView_ClipboardManager_FileDropList);
            this.groupBox_ClipboardManager_FileDropList.Location = new System.Drawing.Point(566, 291);
            this.groupBox_ClipboardManager_FileDropList.Name = "groupBox_ClipboardManager_FileDropList";
            this.groupBox_ClipboardManager_FileDropList.Size = new System.Drawing.Size(372, 282);
            this.groupBox_ClipboardManager_FileDropList.TabIndex = 1;
            this.groupBox_ClipboardManager_FileDropList.TabStop = false;
            this.groupBox_ClipboardManager_FileDropList.Text = "File Drop List";
            // 
            // listView_ClipboardManager_FileDropList
            // 
            this.listView_ClipboardManager_FileDropList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ClipboardManager_Item});
            this.listView_ClipboardManager_FileDropList.FullRowSelect = true;
            this.listView_ClipboardManager_FileDropList.GridLines = true;
            this.listView_ClipboardManager_FileDropList.Location = new System.Drawing.Point(6, 19);
            this.listView_ClipboardManager_FileDropList.Name = "listView_ClipboardManager_FileDropList";
            this.listView_ClipboardManager_FileDropList.Size = new System.Drawing.Size(360, 257);
            this.listView_ClipboardManager_FileDropList.TabIndex = 0;
            this.listView_ClipboardManager_FileDropList.UseCompatibleStateImageBehavior = false;
            this.listView_ClipboardManager_FileDropList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_ClipboardManager_Item
            // 
            this.columnHeader_ClipboardManager_Item.Text = "Item";
            this.columnHeader_ClipboardManager_Item.Width = 338;
            // 
            // tabPage_RemoteSystemInformation
            // 
            this.tabPage_RemoteSystemInformation.Controls.Add(this.groupBox_RemoteSystemInformation_AvailableItems);
            this.tabPage_RemoteSystemInformation.Controls.Add(this.groupBox_RemoteSystemInformation_AvailableInformation);
            this.tabPage_RemoteSystemInformation.Location = new System.Drawing.Point(4, 40);
            this.tabPage_RemoteSystemInformation.Name = "tabPage_RemoteSystemInformation";
            this.tabPage_RemoteSystemInformation.Size = new System.Drawing.Size(944, 587);
            this.tabPage_RemoteSystemInformation.TabIndex = 16;
            this.tabPage_RemoteSystemInformation.Text = "Remote System Information";
            // 
            // groupBox_RemoteSystemInformation_AvailableItems
            // 
            this.groupBox_RemoteSystemInformation_AvailableItems.Controls.Add(this.textBox_RemoteSystemInformation_AvailableItems_CurrentStatus);
            this.groupBox_RemoteSystemInformation_AvailableItems.Controls.Add(this.button_RemoteSystemInformation_AvailableItems_Refresh);
            this.groupBox_RemoteSystemInformation_AvailableItems.Controls.Add(this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems);
            this.groupBox_RemoteSystemInformation_AvailableItems.Controls.Add(this.label_RemoteSystemInformation_AvailableItems_AvailableItems);
            this.groupBox_RemoteSystemInformation_AvailableItems.Controls.Add(this.label_RemoteSystemInformation_AvailableItems_CurrentStatus);
            this.groupBox_RemoteSystemInformation_AvailableItems.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_RemoteSystemInformation_AvailableItems.Location = new System.Drawing.Point(8, 8);
            this.groupBox_RemoteSystemInformation_AvailableItems.Name = "groupBox_RemoteSystemInformation_AvailableItems";
            this.groupBox_RemoteSystemInformation_AvailableItems.Size = new System.Drawing.Size(288, 562);
            this.groupBox_RemoteSystemInformation_AvailableItems.TabIndex = 20;
            this.groupBox_RemoteSystemInformation_AvailableItems.TabStop = false;
            // 
            // textBox_RemoteSystemInformation_AvailableItems_CurrentStatus
            // 
            this.textBox_RemoteSystemInformation_AvailableItems_CurrentStatus.Location = new System.Drawing.Point(16, 40);
            this.textBox_RemoteSystemInformation_AvailableItems_CurrentStatus.Name = "textBox_RemoteSystemInformation_AvailableItems_CurrentStatus";
            this.textBox_RemoteSystemInformation_AvailableItems_CurrentStatus.ReadOnly = true;
            this.textBox_RemoteSystemInformation_AvailableItems_CurrentStatus.Size = new System.Drawing.Size(200, 20);
            this.textBox_RemoteSystemInformation_AvailableItems_CurrentStatus.TabIndex = 19;
            // 
            // button_RemoteSystemInformation_AvailableItems_Refresh
            // 
            this.button_RemoteSystemInformation_AvailableItems_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_RemoteSystemInformation_AvailableItems_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_RemoteSystemInformation_AvailableItems_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("button_RemoteSystemInformation_AvailableItems_Refresh.Image")));
            this.button_RemoteSystemInformation_AvailableItems_Refresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_RemoteSystemInformation_AvailableItems_Refresh.Location = new System.Drawing.Point(224, 24);
            this.button_RemoteSystemInformation_AvailableItems_Refresh.Name = "button_RemoteSystemInformation_AvailableItems_Refresh";
            this.button_RemoteSystemInformation_AvailableItems_Refresh.Size = new System.Drawing.Size(48, 48);
            this.button_RemoteSystemInformation_AvailableItems_Refresh.TabIndex = 16;
            this.button_RemoteSystemInformation_AvailableItems_Refresh.Click += new System.EventHandler(this.button_RemoteSystemInformation_AvailableItems_Refresh_Click);
            // 
            // treeView_RemoteSystemInformation_AvailableItems_AvailableItems
            // 
            this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.FullRowSelect = true;
            this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.HideSelection = false;
            this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.Location = new System.Drawing.Point(16, 88);
            this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.Name = "treeView_RemoteSystemInformation_AvailableItems_AvailableItems";
            this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.Size = new System.Drawing.Size(256, 461);
            this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.TabIndex = 14;
            this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems_BeforeExpand);
            this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems_BeforeSelect);
            // 
            // label_RemoteSystemInformation_AvailableItems_AvailableItems
            // 
            this.label_RemoteSystemInformation_AvailableItems_AvailableItems.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_RemoteSystemInformation_AvailableItems_AvailableItems.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteSystemInformation_AvailableItems_AvailableItems.Location = new System.Drawing.Point(16, 72);
            this.label_RemoteSystemInformation_AvailableItems_AvailableItems.Name = "label_RemoteSystemInformation_AvailableItems_AvailableItems";
            this.label_RemoteSystemInformation_AvailableItems_AvailableItems.Size = new System.Drawing.Size(208, 16);
            this.label_RemoteSystemInformation_AvailableItems_AvailableItems.TabIndex = 17;
            this.label_RemoteSystemInformation_AvailableItems_AvailableItems.Text = "Available Items:";
            this.label_RemoteSystemInformation_AvailableItems_AvailableItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_RemoteSystemInformation_AvailableItems_CurrentStatus
            // 
            this.label_RemoteSystemInformation_AvailableItems_CurrentStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_RemoteSystemInformation_AvailableItems_CurrentStatus.Location = new System.Drawing.Point(16, 24);
            this.label_RemoteSystemInformation_AvailableItems_CurrentStatus.Name = "label_RemoteSystemInformation_AvailableItems_CurrentStatus";
            this.label_RemoteSystemInformation_AvailableItems_CurrentStatus.Size = new System.Drawing.Size(200, 16);
            this.label_RemoteSystemInformation_AvailableItems_CurrentStatus.TabIndex = 18;
            this.label_RemoteSystemInformation_AvailableItems_CurrentStatus.Text = "Current Status:";
            // 
            // groupBox_RemoteSystemInformation_AvailableInformation
            // 
            this.groupBox_RemoteSystemInformation_AvailableInformation.Controls.Add(this.button_RemoteSystemInformation_AvailableInformation_CopyItemInfoToClipboard);
            this.groupBox_RemoteSystemInformation_AvailableInformation.Controls.Add(this.label_RemoteSystemInformation_AvailableInformation_CurrentItem);
            this.groupBox_RemoteSystemInformation_AvailableInformation.Controls.Add(this.button_RemoteSystemInformation_AvailableInformation_Refresh);
            this.groupBox_RemoteSystemInformation_AvailableInformation.Controls.Add(this.label_RemoteSystemInformation_AvailableInformation_AvailableInformation);
            this.groupBox_RemoteSystemInformation_AvailableInformation.Controls.Add(this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation);
            this.groupBox_RemoteSystemInformation_AvailableInformation.Controls.Add(this.textBox_RemoteSystemInformation_AvailableInformation_CurrentItem);
            this.groupBox_RemoteSystemInformation_AvailableInformation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_RemoteSystemInformation_AvailableInformation.Location = new System.Drawing.Point(312, 8);
            this.groupBox_RemoteSystemInformation_AvailableInformation.Name = "groupBox_RemoteSystemInformation_AvailableInformation";
            this.groupBox_RemoteSystemInformation_AvailableInformation.Size = new System.Drawing.Size(624, 562);
            this.groupBox_RemoteSystemInformation_AvailableInformation.TabIndex = 15;
            this.groupBox_RemoteSystemInformation_AvailableInformation.TabStop = false;
            // 
            // button_RemoteSystemInformation_AvailableInformation_CopyItemInfoToClipboard
            // 
            this.button_RemoteSystemInformation_AvailableInformation_CopyItemInfoToClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_RemoteSystemInformation_AvailableInformation_CopyItemInfoToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("button_RemoteSystemInformation_AvailableInformation_CopyItemInfoToClipboard.Image" +
        "")));
            this.button_RemoteSystemInformation_AvailableInformation_CopyItemInfoToClipboard.Location = new System.Drawing.Point(16, 28);
            this.button_RemoteSystemInformation_AvailableInformation_CopyItemInfoToClipboard.Name = "button_RemoteSystemInformation_AvailableInformation_CopyItemInfoToClipboard";
            this.button_RemoteSystemInformation_AvailableInformation_CopyItemInfoToClipboard.Size = new System.Drawing.Size(32, 32);
            this.button_RemoteSystemInformation_AvailableInformation_CopyItemInfoToClipboard.TabIndex = 21;
            // 
            // label_RemoteSystemInformation_AvailableInformation_CurrentItem
            // 
            this.label_RemoteSystemInformation_AvailableInformation_CurrentItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_RemoteSystemInformation_AvailableInformation_CurrentItem.Location = new System.Drawing.Point(62, 24);
            this.label_RemoteSystemInformation_AvailableInformation_CurrentItem.Name = "label_RemoteSystemInformation_AvailableInformation_CurrentItem";
            this.label_RemoteSystemInformation_AvailableInformation_CurrentItem.Size = new System.Drawing.Size(82, 16);
            this.label_RemoteSystemInformation_AvailableInformation_CurrentItem.TabIndex = 20;
            this.label_RemoteSystemInformation_AvailableInformation_CurrentItem.Text = "Current Item:";
            // 
            // button_RemoteSystemInformation_AvailableInformation_Refresh
            // 
            this.button_RemoteSystemInformation_AvailableInformation_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_RemoteSystemInformation_AvailableInformation_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_RemoteSystemInformation_AvailableInformation_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("button_RemoteSystemInformation_AvailableInformation_Refresh.Image")));
            this.button_RemoteSystemInformation_AvailableInformation_Refresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_RemoteSystemInformation_AvailableInformation_Refresh.Location = new System.Drawing.Point(560, 24);
            this.button_RemoteSystemInformation_AvailableInformation_Refresh.Name = "button_RemoteSystemInformation_AvailableInformation_Refresh";
            this.button_RemoteSystemInformation_AvailableInformation_Refresh.Size = new System.Drawing.Size(48, 48);
            this.button_RemoteSystemInformation_AvailableInformation_Refresh.TabIndex = 19;
            this.button_RemoteSystemInformation_AvailableInformation_Refresh.Click += new System.EventHandler(this.button_RemoteSystemInformation_AvailableInformation_Refresh_Click);
            // 
            // label_RemoteSystemInformation_AvailableInformation_AvailableInformation
            // 
            this.label_RemoteSystemInformation_AvailableInformation_AvailableInformation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_RemoteSystemInformation_AvailableInformation_AvailableInformation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RemoteSystemInformation_AvailableInformation_AvailableInformation.Location = new System.Drawing.Point(16, 72);
            this.label_RemoteSystemInformation_AvailableInformation_AvailableInformation.Name = "label_RemoteSystemInformation_AvailableInformation_AvailableInformation";
            this.label_RemoteSystemInformation_AvailableInformation_AvailableInformation.Size = new System.Drawing.Size(128, 16);
            this.label_RemoteSystemInformation_AvailableInformation_AvailableInformation.TabIndex = 18;
            this.label_RemoteSystemInformation_AvailableInformation_AvailableInformation.Text = "Available Information:";
            this.label_RemoteSystemInformation_AvailableInformation_AvailableInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listView_RemoteSystemInformation_AvailableInformation_AvailableInformation
            // 
            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_RemoteSystemInformation_Parameter,
            this.columnHeader_RemoteSystemInformation_Value});
            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.FullRowSelect = true;
            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.GridLines = true;
            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.HideSelection = false;
            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.Location = new System.Drawing.Point(16, 88);
            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.MultiSelect = false;
            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.Name = "listView_RemoteSystemInformation_AvailableInformation_AvailableInformation";
            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.Size = new System.Drawing.Size(592, 461);
            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.TabIndex = 2;
            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.UseCompatibleStateImageBehavior = false;
            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_RemoteSystemInformation_Parameter
            // 
            this.columnHeader_RemoteSystemInformation_Parameter.Text = "Parameter";
            this.columnHeader_RemoteSystemInformation_Parameter.Width = 285;
            // 
            // columnHeader_RemoteSystemInformation_Value
            // 
            this.columnHeader_RemoteSystemInformation_Value.Text = "Value";
            this.columnHeader_RemoteSystemInformation_Value.Width = 285;
            // 
            // textBox_RemoteSystemInformation_AvailableInformation_CurrentItem
            // 
            this.textBox_RemoteSystemInformation_AvailableInformation_CurrentItem.Location = new System.Drawing.Point(62, 40);
            this.textBox_RemoteSystemInformation_AvailableInformation_CurrentItem.Name = "textBox_RemoteSystemInformation_AvailableInformation_CurrentItem";
            this.textBox_RemoteSystemInformation_AvailableInformation_CurrentItem.ReadOnly = true;
            this.textBox_RemoteSystemInformation_AvailableInformation_CurrentItem.Size = new System.Drawing.Size(490, 20);
            this.textBox_RemoteSystemInformation_AvailableInformation_CurrentItem.TabIndex = 1;
            // 
            // tabPage_ServicesManager
            // 
            this.tabPage_ServicesManager.Controls.Add(this.listView_ServicesManager_Services);
            this.tabPage_ServicesManager.Controls.Add(this.button_ServicesManager_StopService);
            this.tabPage_ServicesManager.Controls.Add(this.button_ServicesManager_PauseService);
            this.tabPage_ServicesManager.Controls.Add(this.button_ServicesManager_StartService);
            this.tabPage_ServicesManager.Controls.Add(this.label_ServicesManager_ServiceManagement);
            this.tabPage_ServicesManager.Controls.Add(this.button_ServicesManager_Refresh);
            this.tabPage_ServicesManager.Location = new System.Drawing.Point(4, 40);
            this.tabPage_ServicesManager.Name = "tabPage_ServicesManager";
            this.tabPage_ServicesManager.Size = new System.Drawing.Size(944, 587);
            this.tabPage_ServicesManager.TabIndex = 4;
            this.tabPage_ServicesManager.Text = "Services Manager";
            // 
            // listView_ServicesManager_Services
            // 
            this.listView_ServicesManager_Services.AllowColumnReorder = true;
            this.listView_ServicesManager_Services.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ServicesManager_DisplayName,
            this.columnHeader_ServicesManager_name,
            this.columnHeader_ServicesManager_Status,
            this.columnHeader_ServicesManager_ServiceType});
            this.listView_ServicesManager_Services.FullRowSelect = true;
            this.listView_ServicesManager_Services.GridLines = true;
            this.listView_ServicesManager_Services.HideSelection = false;
            this.listView_ServicesManager_Services.Location = new System.Drawing.Point(8, 64);
            this.listView_ServicesManager_Services.Name = "listView_ServicesManager_Services";
            this.listView_ServicesManager_Services.Size = new System.Drawing.Size(928, 510);
            this.listView_ServicesManager_Services.SmallImageList = this.imageList_ServicesManager;
            this.listView_ServicesManager_Services.TabIndex = 12;
            this.listView_ServicesManager_Services.UseCompatibleStateImageBehavior = false;
            this.listView_ServicesManager_Services.View = System.Windows.Forms.View.Details;
            this.listView_ServicesManager_Services.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ServicesManager_Services_ColumnClick);
            this.listView_ServicesManager_Services.SelectedIndexChanged += new System.EventHandler(this.listView_ServicesManager_Services_SelectedIndexChanged);
            this.listView_ServicesManager_Services.Click += new System.EventHandler(this.listView_ServicesManager_Services_Click);
            // 
            // columnHeader_ServicesManager_DisplayName
            // 
            this.columnHeader_ServicesManager_DisplayName.Text = "Friendly name";
            this.columnHeader_ServicesManager_DisplayName.Width = 400;
            // 
            // columnHeader_ServicesManager_name
            // 
            this.columnHeader_ServicesManager_name.Text = "Name";
            this.columnHeader_ServicesManager_name.Width = 170;
            // 
            // columnHeader_ServicesManager_Status
            // 
            this.columnHeader_ServicesManager_Status.Text = "Status";
            this.columnHeader_ServicesManager_Status.Width = 100;
            // 
            // columnHeader_ServicesManager_ServiceType
            // 
            this.columnHeader_ServicesManager_ServiceType.Text = "Service Type";
            this.columnHeader_ServicesManager_ServiceType.Width = 235;
            // 
            // imageList_ServicesManager
            // 
            this.imageList_ServicesManager.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_ServicesManager.ImageStream")));
            this.imageList_ServicesManager.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_ServicesManager.Images.SetKeyName(0, "service.ICO");
            // 
            // button_ServicesManager_StopService
            // 
            this.button_ServicesManager_StopService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ServicesManager_StopService.Enabled = false;
            this.button_ServicesManager_StopService.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_ServicesManager_StopService.Image = ((System.Drawing.Image)(resources.GetObject("button_ServicesManager_StopService.Image")));
            this.button_ServicesManager_StopService.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_ServicesManager_StopService.Location = new System.Drawing.Point(96, 32);
            this.button_ServicesManager_StopService.Name = "button_ServicesManager_StopService";
            this.button_ServicesManager_StopService.Size = new System.Drawing.Size(24, 23);
            this.button_ServicesManager_StopService.TabIndex = 11;
            this.button_ServicesManager_StopService.Click += new System.EventHandler(this.button_ServicesManager_StopService_Click);
            // 
            // button_ServicesManager_PauseService
            // 
            this.button_ServicesManager_PauseService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ServicesManager_PauseService.Enabled = false;
            this.button_ServicesManager_PauseService.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_ServicesManager_PauseService.Image = ((System.Drawing.Image)(resources.GetObject("button_ServicesManager_PauseService.Image")));
            this.button_ServicesManager_PauseService.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_ServicesManager_PauseService.Location = new System.Drawing.Point(128, 32);
            this.button_ServicesManager_PauseService.Name = "button_ServicesManager_PauseService";
            this.button_ServicesManager_PauseService.Size = new System.Drawing.Size(24, 23);
            this.button_ServicesManager_PauseService.TabIndex = 10;
            this.button_ServicesManager_PauseService.Click += new System.EventHandler(this.button_ServicesManager_PauseService_Click);
            // 
            // button_ServicesManager_StartService
            // 
            this.button_ServicesManager_StartService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ServicesManager_StartService.Enabled = false;
            this.button_ServicesManager_StartService.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_ServicesManager_StartService.Image = ((System.Drawing.Image)(resources.GetObject("button_ServicesManager_StartService.Image")));
            this.button_ServicesManager_StartService.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_ServicesManager_StartService.Location = new System.Drawing.Point(64, 32);
            this.button_ServicesManager_StartService.Name = "button_ServicesManager_StartService";
            this.button_ServicesManager_StartService.Size = new System.Drawing.Size(24, 23);
            this.button_ServicesManager_StartService.TabIndex = 9;
            this.button_ServicesManager_StartService.Click += new System.EventHandler(this.button_ServicesManager_StartService_Click);
            // 
            // label_ServicesManager_ServiceManagement
            // 
            this.label_ServicesManager_ServiceManagement.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_ServicesManager_ServiceManagement.Location = new System.Drawing.Point(64, 16);
            this.label_ServicesManager_ServiceManagement.Name = "label_ServicesManager_ServiceManagement";
            this.label_ServicesManager_ServiceManagement.Size = new System.Drawing.Size(74, 16);
            this.label_ServicesManager_ServiceManagement.TabIndex = 8;
            // 
            // button_ServicesManager_Refresh
            // 
            this.button_ServicesManager_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ServicesManager_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_ServicesManager_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("button_ServicesManager_Refresh.Image")));
            this.button_ServicesManager_Refresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_ServicesManager_Refresh.Location = new System.Drawing.Point(8, 8);
            this.button_ServicesManager_Refresh.Name = "button_ServicesManager_Refresh";
            this.button_ServicesManager_Refresh.Size = new System.Drawing.Size(48, 48);
            this.button_ServicesManager_Refresh.TabIndex = 7;
            this.button_ServicesManager_Refresh.Click += new System.EventHandler(this.button_ServicesManager_Refresh_Click);
            // 
            // tabPage_SystemEvents
            // 
            this.tabPage_SystemEvents.Controls.Add(this.button_SystemEvents_EventProperties);
            this.tabPage_SystemEvents.Controls.Add(this.button_SystemEvents_DeleteLog);
            this.tabPage_SystemEvents.Controls.Add(this.textBox_SystemEvents_Information);
            this.tabPage_SystemEvents.Controls.Add(this.listView_SystemEvents_Events);
            this.tabPage_SystemEvents.Controls.Add(this.button_SystemEvents_Refresh);
            this.tabPage_SystemEvents.Controls.Add(this.button_SystemEvents_DeleteAllEvents);
            this.tabPage_SystemEvents.Controls.Add(this.comboBox_SystemEvents_Logs);
            this.tabPage_SystemEvents.Location = new System.Drawing.Point(4, 40);
            this.tabPage_SystemEvents.Name = "tabPage_SystemEvents";
            this.tabPage_SystemEvents.Size = new System.Drawing.Size(944, 587);
            this.tabPage_SystemEvents.TabIndex = 10;
            this.tabPage_SystemEvents.Text = "System Events";
            // 
            // button_SystemEvents_EventProperties
            // 
            this.button_SystemEvents_EventProperties.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_SystemEvents_EventProperties.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_SystemEvents_EventProperties.Location = new System.Drawing.Point(360, 8);
            this.button_SystemEvents_EventProperties.Name = "button_SystemEvents_EventProperties";
            this.button_SystemEvents_EventProperties.Size = new System.Drawing.Size(136, 24);
            this.button_SystemEvents_EventProperties.TabIndex = 7;
            this.button_SystemEvents_EventProperties.Text = "Event Properties";
            this.button_SystemEvents_EventProperties.Click += new System.EventHandler(this.button_SystemEvents_EventProperties_Click);
            // 
            // button_SystemEvents_DeleteLog
            // 
            this.button_SystemEvents_DeleteLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_SystemEvents_DeleteLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_SystemEvents_DeleteLog.Location = new System.Drawing.Point(504, 8);
            this.button_SystemEvents_DeleteLog.Name = "button_SystemEvents_DeleteLog";
            this.button_SystemEvents_DeleteLog.Size = new System.Drawing.Size(136, 24);
            this.button_SystemEvents_DeleteLog.TabIndex = 6;
            this.button_SystemEvents_DeleteLog.Text = "Delete Log";
            this.button_SystemEvents_DeleteLog.Click += new System.EventHandler(this.button_SystemEvents_DeleteLog_Click);
            // 
            // textBox_SystemEvents_Information
            // 
            this.textBox_SystemEvents_Information.Location = new System.Drawing.Point(64, 8);
            this.textBox_SystemEvents_Information.Name = "textBox_SystemEvents_Information";
            this.textBox_SystemEvents_Information.ReadOnly = true;
            this.textBox_SystemEvents_Information.Size = new System.Drawing.Size(144, 20);
            this.textBox_SystemEvents_Information.TabIndex = 5;
            // 
            // listView_SystemEvents_Events
            // 
            this.listView_SystemEvents_Events.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_SystemEvents_EventType,
            this.columnHeader_SystemEvents_EventDate,
            this.columnHeader_SystemEvents_EventTime,
            this.columnHeader_SystemEvents_EventSource,
            this.columnHeader_SystemEvents_EventCategoty,
            this.columnHeader_SystemEvents_EventID,
            this.columnHeader_SystemEvents_User,
            this.columnHeader_SystemEvents_Computer});
            this.listView_SystemEvents_Events.FullRowSelect = true;
            this.listView_SystemEvents_Events.GridLines = true;
            this.listView_SystemEvents_Events.Location = new System.Drawing.Point(8, 64);
            this.listView_SystemEvents_Events.Name = "listView_SystemEvents_Events";
            this.listView_SystemEvents_Events.Size = new System.Drawing.Size(928, 510);
            this.listView_SystemEvents_Events.SmallImageList = this.imageList_SystemEvents;
            this.listView_SystemEvents_Events.TabIndex = 4;
            this.listView_SystemEvents_Events.UseCompatibleStateImageBehavior = false;
            this.listView_SystemEvents_Events.View = System.Windows.Forms.View.Details;
            this.listView_SystemEvents_Events.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_SystemEvents_Events_ColumnClick);
            this.listView_SystemEvents_Events.DoubleClick += new System.EventHandler(this.listView_SystemEvents_Events_DoubleClick);
            // 
            // columnHeader_SystemEvents_EventType
            // 
            this.columnHeader_SystemEvents_EventType.Text = "Type";
            this.columnHeader_SystemEvents_EventType.Width = 130;
            // 
            // columnHeader_SystemEvents_EventDate
            // 
            this.columnHeader_SystemEvents_EventDate.Text = "Date";
            this.columnHeader_SystemEvents_EventDate.Width = 90;
            // 
            // columnHeader_SystemEvents_EventTime
            // 
            this.columnHeader_SystemEvents_EventTime.Text = "Time";
            this.columnHeader_SystemEvents_EventTime.Width = 80;
            // 
            // columnHeader_SystemEvents_EventSource
            // 
            this.columnHeader_SystemEvents_EventSource.Text = "Source";
            this.columnHeader_SystemEvents_EventSource.Width = 160;
            // 
            // columnHeader_SystemEvents_EventCategoty
            // 
            this.columnHeader_SystemEvents_EventCategoty.Text = "Category";
            this.columnHeader_SystemEvents_EventCategoty.Width = 100;
            // 
            // columnHeader_SystemEvents_EventID
            // 
            this.columnHeader_SystemEvents_EventID.Text = "Event ID";
            this.columnHeader_SystemEvents_EventID.Width = 90;
            // 
            // columnHeader_SystemEvents_User
            // 
            this.columnHeader_SystemEvents_User.Text = "User";
            this.columnHeader_SystemEvents_User.Width = 160;
            // 
            // columnHeader_SystemEvents_Computer
            // 
            this.columnHeader_SystemEvents_Computer.Text = "Computer";
            this.columnHeader_SystemEvents_Computer.Width = 95;
            // 
            // imageList_SystemEvents
            // 
            this.imageList_SystemEvents.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_SystemEvents.ImageStream")));
            this.imageList_SystemEvents.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_SystemEvents.Images.SetKeyName(0, "");
            this.imageList_SystemEvents.Images.SetKeyName(1, "");
            this.imageList_SystemEvents.Images.SetKeyName(2, "");
            // 
            // button_SystemEvents_Refresh
            // 
            this.button_SystemEvents_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_SystemEvents_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_SystemEvents_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("button_SystemEvents_Refresh.Image")));
            this.button_SystemEvents_Refresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_SystemEvents_Refresh.Location = new System.Drawing.Point(8, 8);
            this.button_SystemEvents_Refresh.Name = "button_SystemEvents_Refresh";
            this.button_SystemEvents_Refresh.Size = new System.Drawing.Size(48, 48);
            this.button_SystemEvents_Refresh.TabIndex = 2;
            this.button_SystemEvents_Refresh.Click += new System.EventHandler(this.button_SystemEvents_Refresh_Click);
            // 
            // button_SystemEvents_DeleteAllEvents
            // 
            this.button_SystemEvents_DeleteAllEvents.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_SystemEvents_DeleteAllEvents.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_SystemEvents_DeleteAllEvents.Location = new System.Drawing.Point(216, 8);
            this.button_SystemEvents_DeleteAllEvents.Name = "button_SystemEvents_DeleteAllEvents";
            this.button_SystemEvents_DeleteAllEvents.Size = new System.Drawing.Size(136, 24);
            this.button_SystemEvents_DeleteAllEvents.TabIndex = 1;
            this.button_SystemEvents_DeleteAllEvents.Text = "Delete all Events";
            this.button_SystemEvents_DeleteAllEvents.Click += new System.EventHandler(this.button_SystemEvents_DeleteAllEvents_Click);
            // 
            // comboBox_SystemEvents_Logs
            // 
            this.comboBox_SystemEvents_Logs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SystemEvents_Logs.ItemHeight = 13;
            this.comboBox_SystemEvents_Logs.Items.AddRange(new object[] {
            "",
            "",
            "",
            ""});
            this.comboBox_SystemEvents_Logs.Location = new System.Drawing.Point(64, 32);
            this.comboBox_SystemEvents_Logs.Name = "comboBox_SystemEvents_Logs";
            this.comboBox_SystemEvents_Logs.Size = new System.Drawing.Size(144, 21);
            this.comboBox_SystemEvents_Logs.TabIndex = 0;
            this.comboBox_SystemEvents_Logs.DropDown += new System.EventHandler(this.comboBox_SystemEvents_Logs_DropDown);
            this.comboBox_SystemEvents_Logs.SelectedIndexChanged += new System.EventHandler(this.comboBox_SystemEvents_Logs_SelectedIndexChanged);
            // 
            // tabPage_DriversList
            // 
            this.tabPage_DriversList.Controls.Add(this.button_DriversList_Refresh);
            this.tabPage_DriversList.Controls.Add(this.listView_DriversList_DriversList);
            this.tabPage_DriversList.Location = new System.Drawing.Point(4, 40);
            this.tabPage_DriversList.Name = "tabPage_DriversList";
            this.tabPage_DriversList.Size = new System.Drawing.Size(944, 587);
            this.tabPage_DriversList.TabIndex = 5;
            this.tabPage_DriversList.Text = "Drivers List";
            // 
            // button_DriversList_Refresh
            // 
            this.button_DriversList_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_DriversList_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_DriversList_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("button_DriversList_Refresh.Image")));
            this.button_DriversList_Refresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_DriversList_Refresh.Location = new System.Drawing.Point(8, 8);
            this.button_DriversList_Refresh.Name = "button_DriversList_Refresh";
            this.button_DriversList_Refresh.Size = new System.Drawing.Size(48, 48);
            this.button_DriversList_Refresh.TabIndex = 3;
            this.button_DriversList_Refresh.Click += new System.EventHandler(this.button_DriversList_Refresh_Click);
            // 
            // listView_DriversList_DriversList
            // 
            this.listView_DriversList_DriversList.AllowColumnReorder = true;
            this.listView_DriversList_DriversList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_DriversList_DriverName,
            this.columnHeader_DriversList_Name,
            this.columnHeader_DriversList_DriverSatus,
            this.columnHeader_DriversList_DriverType});
            this.listView_DriversList_DriversList.FullRowSelect = true;
            this.listView_DriversList_DriversList.GridLines = true;
            this.listView_DriversList_DriversList.Location = new System.Drawing.Point(8, 64);
            this.listView_DriversList_DriversList.Name = "listView_DriversList_DriversList";
            this.listView_DriversList_DriversList.Size = new System.Drawing.Size(928, 504);
            this.listView_DriversList_DriversList.SmallImageList = this.imageList_Drivers;
            this.listView_DriversList_DriversList.TabIndex = 2;
            this.listView_DriversList_DriversList.UseCompatibleStateImageBehavior = false;
            this.listView_DriversList_DriversList.View = System.Windows.Forms.View.Details;
            this.listView_DriversList_DriversList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_DriversList_DriversList_ColumnClick);
            // 
            // columnHeader_DriversList_DriverName
            // 
            this.columnHeader_DriversList_DriverName.Text = "Driver Name";
            this.columnHeader_DriversList_DriverName.Width = 400;
            // 
            // columnHeader_DriversList_Name
            // 
            this.columnHeader_DriversList_Name.Text = "Name";
            this.columnHeader_DriversList_Name.Width = 200;
            // 
            // columnHeader_DriversList_DriverSatus
            // 
            this.columnHeader_DriversList_DriverSatus.Text = "Status";
            this.columnHeader_DriversList_DriverSatus.Width = 140;
            // 
            // columnHeader_DriversList_DriverType
            // 
            this.columnHeader_DriversList_DriverType.Text = "Driver Type";
            this.columnHeader_DriversList_DriverType.Width = 165;
            // 
            // imageList_Drivers
            // 
            this.imageList_Drivers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Drivers.ImageStream")));
            this.imageList_Drivers.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_Drivers.Images.SetKeyName(0, "driver_2.ICO");
            // 
            // tabPage_InstalledPrograms
            // 
            this.tabPage_InstalledPrograms.Controls.Add(this.button_InstalledPrograms_Refresh);
            this.tabPage_InstalledPrograms.Controls.Add(this.listView_InstalledPrograms_ProgramsList);
            this.tabPage_InstalledPrograms.Location = new System.Drawing.Point(4, 40);
            this.tabPage_InstalledPrograms.Name = "tabPage_InstalledPrograms";
            this.tabPage_InstalledPrograms.Size = new System.Drawing.Size(944, 587);
            this.tabPage_InstalledPrograms.TabIndex = 13;
            this.tabPage_InstalledPrograms.Text = "Installed Programs";
            // 
            // button_InstalledPrograms_Refresh
            // 
            this.button_InstalledPrograms_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_InstalledPrograms_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_InstalledPrograms_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("button_InstalledPrograms_Refresh.Image")));
            this.button_InstalledPrograms_Refresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_InstalledPrograms_Refresh.Location = new System.Drawing.Point(8, 10);
            this.button_InstalledPrograms_Refresh.Name = "button_InstalledPrograms_Refresh";
            this.button_InstalledPrograms_Refresh.Size = new System.Drawing.Size(48, 48);
            this.button_InstalledPrograms_Refresh.TabIndex = 5;
            this.button_InstalledPrograms_Refresh.Click += new System.EventHandler(this.button_InstalledPrograms_Refresh_Click);
            // 
            // listView_InstalledPrograms_ProgramsList
            // 
            this.listView_InstalledPrograms_ProgramsList.AllowColumnReorder = true;
            this.listView_InstalledPrograms_ProgramsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_InstalledPrograms_ProgramName,
            this.columnHeader_InstalledPrograms_ProgramVersion,
            this.columnHeader_InstalledPrograms_ProgramPublisher,
            this.columnHeader_InstalledPrograms_InstallDate,
            this.columnHeader_InstalledPrograms_InstallLocation});
            this.listView_InstalledPrograms_ProgramsList.FullRowSelect = true;
            this.listView_InstalledPrograms_ProgramsList.GridLines = true;
            this.listView_InstalledPrograms_ProgramsList.Location = new System.Drawing.Point(8, 66);
            this.listView_InstalledPrograms_ProgramsList.Name = "listView_InstalledPrograms_ProgramsList";
            this.listView_InstalledPrograms_ProgramsList.Size = new System.Drawing.Size(928, 502);
            this.listView_InstalledPrograms_ProgramsList.SmallImageList = this.imageList_InstalledPrograms;
            this.listView_InstalledPrograms_ProgramsList.TabIndex = 4;
            this.listView_InstalledPrograms_ProgramsList.UseCompatibleStateImageBehavior = false;
            this.listView_InstalledPrograms_ProgramsList.View = System.Windows.Forms.View.Details;
            this.listView_InstalledPrograms_ProgramsList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_InstalledPrograms_ProgramsList_ColumnClick);
            // 
            // columnHeader_InstalledPrograms_ProgramName
            // 
            this.columnHeader_InstalledPrograms_ProgramName.Text = "Program Name";
            this.columnHeader_InstalledPrograms_ProgramName.Width = 250;
            // 
            // columnHeader_InstalledPrograms_ProgramVersion
            // 
            this.columnHeader_InstalledPrograms_ProgramVersion.Text = "Version";
            this.columnHeader_InstalledPrograms_ProgramVersion.Width = 70;
            // 
            // columnHeader_InstalledPrograms_ProgramPublisher
            // 
            this.columnHeader_InstalledPrograms_ProgramPublisher.Text = "Publisher";
            this.columnHeader_InstalledPrograms_ProgramPublisher.Width = 130;
            // 
            // columnHeader_InstalledPrograms_InstallDate
            // 
            this.columnHeader_InstalledPrograms_InstallDate.Text = "Date";
            this.columnHeader_InstalledPrograms_InstallDate.Width = 90;
            // 
            // columnHeader_InstalledPrograms_InstallLocation
            // 
            this.columnHeader_InstalledPrograms_InstallLocation.Text = "Install Location";
            this.columnHeader_InstalledPrograms_InstallLocation.Width = 365;
            // 
            // imageList_InstalledPrograms
            // 
            this.imageList_InstalledPrograms.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_InstalledPrograms.ImageStream")));
            this.imageList_InstalledPrograms.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_InstalledPrograms.Images.SetKeyName(0, "pic_installedprogram.ico");
            // 
            // tabPage_InstalledUpdates
            // 
            this.tabPage_InstalledUpdates.Controls.Add(this.button_InstalledUpdates_Refresh);
            this.tabPage_InstalledUpdates.Controls.Add(this.listView_InstalledUpdates_UpdatesList);
            this.tabPage_InstalledUpdates.Location = new System.Drawing.Point(4, 40);
            this.tabPage_InstalledUpdates.Name = "tabPage_InstalledUpdates";
            this.tabPage_InstalledUpdates.Size = new System.Drawing.Size(944, 587);
            this.tabPage_InstalledUpdates.TabIndex = 14;
            this.tabPage_InstalledUpdates.Text = "Installed Updates";
            // 
            // button_InstalledUpdates_Refresh
            // 
            this.button_InstalledUpdates_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_InstalledUpdates_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_InstalledUpdates_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("button_InstalledUpdates_Refresh.Image")));
            this.button_InstalledUpdates_Refresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_InstalledUpdates_Refresh.Location = new System.Drawing.Point(8, 10);
            this.button_InstalledUpdates_Refresh.Name = "button_InstalledUpdates_Refresh";
            this.button_InstalledUpdates_Refresh.Size = new System.Drawing.Size(48, 48);
            this.button_InstalledUpdates_Refresh.TabIndex = 7;
            this.button_InstalledUpdates_Refresh.Click += new System.EventHandler(this.button_InstalledUpdates_Refresh_Click);
            // 
            // listView_InstalledUpdates_UpdatesList
            // 
            this.listView_InstalledUpdates_UpdatesList.AllowColumnReorder = true;
            this.listView_InstalledUpdates_UpdatesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_InstalledUpdates_UpdateDescription,
            this.columnHeader_InstalledUpdates_InstalledBy,
            this.columnHeader_InstalledUpdates_InstallDate});
            this.listView_InstalledUpdates_UpdatesList.FullRowSelect = true;
            this.listView_InstalledUpdates_UpdatesList.GridLines = true;
            this.listView_InstalledUpdates_UpdatesList.Location = new System.Drawing.Point(8, 66);
            this.listView_InstalledUpdates_UpdatesList.Name = "listView_InstalledUpdates_UpdatesList";
            this.listView_InstalledUpdates_UpdatesList.Size = new System.Drawing.Size(928, 494);
            this.listView_InstalledUpdates_UpdatesList.SmallImageList = this.imageList_InstalledUpdates;
            this.listView_InstalledUpdates_UpdatesList.TabIndex = 6;
            this.listView_InstalledUpdates_UpdatesList.UseCompatibleStateImageBehavior = false;
            this.listView_InstalledUpdates_UpdatesList.View = System.Windows.Forms.View.Details;
            this.listView_InstalledUpdates_UpdatesList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_InstalledUpdates_UpdatesList_ColumnClick);
            // 
            // columnHeader_InstalledUpdates_UpdateDescription
            // 
            this.columnHeader_InstalledUpdates_UpdateDescription.Text = "Update Description";
            this.columnHeader_InstalledUpdates_UpdateDescription.Width = 540;
            // 
            // columnHeader_InstalledUpdates_InstalledBy
            // 
            this.columnHeader_InstalledUpdates_InstalledBy.Text = "Update Installed By";
            this.columnHeader_InstalledUpdates_InstalledBy.Width = 240;
            // 
            // columnHeader_InstalledUpdates_InstallDate
            // 
            this.columnHeader_InstalledUpdates_InstallDate.Text = "Install Date";
            this.columnHeader_InstalledUpdates_InstallDate.Width = 125;
            // 
            // imageList_InstalledUpdates
            // 
            this.imageList_InstalledUpdates.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_InstalledUpdates.ImageStream")));
            this.imageList_InstalledUpdates.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_InstalledUpdates.Images.SetKeyName(0, "pic_installedupdates.png");
            // 
            // tabPage_SystemStateManager
            // 
            this.tabPage_SystemStateManager.Controls.Add(this.label_SystemStateManager_LockWorkstationRemarks);
            this.tabPage_SystemStateManager.Controls.Add(this.label_SystemStateManager_HibernateRemarks);
            this.tabPage_SystemStateManager.Controls.Add(this.label_SystemStateManager_StandByRemarks);
            this.tabPage_SystemStateManager.Controls.Add(this.label_SystemStateManager_Remarks);
            this.tabPage_SystemStateManager.Controls.Add(this.label_SystemStateManager_ShutDownRemarks);
            this.tabPage_SystemStateManager.Controls.Add(this.label_SystemStateManager_RestartRemarks);
            this.tabPage_SystemStateManager.Controls.Add(this.label_SystemStateManager_PowerOffRemarks);
            this.tabPage_SystemStateManager.Controls.Add(this.label_SystemStateManager_UserLogOffRemarks);
            this.tabPage_SystemStateManager.Controls.Add(this.splitter_SystemStateManager_Remarks);
            this.tabPage_SystemStateManager.Controls.Add(this.groupBox_SystemStateManager_ChangeSystemState);
            this.tabPage_SystemStateManager.Controls.Add(this.groupBox_SystemStateManager_ChangePowerState);
            this.tabPage_SystemStateManager.Controls.Add(this.groupBox_SystemStateManager_ChangeSecurityState);
            this.tabPage_SystemStateManager.Location = new System.Drawing.Point(4, 40);
            this.tabPage_SystemStateManager.Name = "tabPage_SystemStateManager";
            this.tabPage_SystemStateManager.Size = new System.Drawing.Size(944, 587);
            this.tabPage_SystemStateManager.TabIndex = 7;
            this.tabPage_SystemStateManager.Text = "System State Manager";
            // 
            // label_SystemStateManager_LockWorkstationRemarks
            // 
            this.label_SystemStateManager_LockWorkstationRemarks.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label_SystemStateManager_LockWorkstationRemarks.Location = new System.Drawing.Point(616, 352);
            this.label_SystemStateManager_LockWorkstationRemarks.Name = "label_SystemStateManager_LockWorkstationRemarks";
            this.label_SystemStateManager_LockWorkstationRemarks.Size = new System.Drawing.Size(304, 72);
            this.label_SystemStateManager_LockWorkstationRemarks.TabIndex = 23;
            // 
            // label_SystemStateManager_HibernateRemarks
            // 
            this.label_SystemStateManager_HibernateRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_SystemStateManager_HibernateRemarks.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label_SystemStateManager_HibernateRemarks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_SystemStateManager_HibernateRemarks.Location = new System.Drawing.Point(616, 256);
            this.label_SystemStateManager_HibernateRemarks.Name = "label_SystemStateManager_HibernateRemarks";
            this.label_SystemStateManager_HibernateRemarks.Size = new System.Drawing.Size(304, 80);
            this.label_SystemStateManager_HibernateRemarks.TabIndex = 22;
            // 
            // label_SystemStateManager_StandByRemarks
            // 
            this.label_SystemStateManager_StandByRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_SystemStateManager_StandByRemarks.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label_SystemStateManager_StandByRemarks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_SystemStateManager_StandByRemarks.Location = new System.Drawing.Point(616, 216);
            this.label_SystemStateManager_StandByRemarks.Name = "label_SystemStateManager_StandByRemarks";
            this.label_SystemStateManager_StandByRemarks.Size = new System.Drawing.Size(304, 32);
            this.label_SystemStateManager_StandByRemarks.TabIndex = 21;
            // 
            // label_SystemStateManager_Remarks
            // 
            this.label_SystemStateManager_Remarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_SystemStateManager_Remarks.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label_SystemStateManager_Remarks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_SystemStateManager_Remarks.Location = new System.Drawing.Point(712, 16);
            this.label_SystemStateManager_Remarks.Name = "label_SystemStateManager_Remarks";
            this.label_SystemStateManager_Remarks.Size = new System.Drawing.Size(100, 23);
            this.label_SystemStateManager_Remarks.TabIndex = 20;
            // 
            // label_SystemStateManager_ShutDownRemarks
            // 
            this.label_SystemStateManager_ShutDownRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_SystemStateManager_ShutDownRemarks.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label_SystemStateManager_ShutDownRemarks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_SystemStateManager_ShutDownRemarks.Location = new System.Drawing.Point(616, 88);
            this.label_SystemStateManager_ShutDownRemarks.Name = "label_SystemStateManager_ShutDownRemarks";
            this.label_SystemStateManager_ShutDownRemarks.Size = new System.Drawing.Size(304, 24);
            this.label_SystemStateManager_ShutDownRemarks.TabIndex = 19;
            // 
            // label_SystemStateManager_RestartRemarks
            // 
            this.label_SystemStateManager_RestartRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_SystemStateManager_RestartRemarks.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label_SystemStateManager_RestartRemarks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_SystemStateManager_RestartRemarks.Location = new System.Drawing.Point(616, 128);
            this.label_SystemStateManager_RestartRemarks.Name = "label_SystemStateManager_RestartRemarks";
            this.label_SystemStateManager_RestartRemarks.Size = new System.Drawing.Size(304, 32);
            this.label_SystemStateManager_RestartRemarks.TabIndex = 18;
            // 
            // label_SystemStateManager_PowerOffRemarks
            // 
            this.label_SystemStateManager_PowerOffRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_SystemStateManager_PowerOffRemarks.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label_SystemStateManager_PowerOffRemarks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_SystemStateManager_PowerOffRemarks.Location = new System.Drawing.Point(616, 40);
            this.label_SystemStateManager_PowerOffRemarks.Name = "label_SystemStateManager_PowerOffRemarks";
            this.label_SystemStateManager_PowerOffRemarks.Size = new System.Drawing.Size(304, 48);
            this.label_SystemStateManager_PowerOffRemarks.TabIndex = 17;
            // 
            // label_SystemStateManager_UserLogOffRemarks
            // 
            this.label_SystemStateManager_UserLogOffRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_SystemStateManager_UserLogOffRemarks.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label_SystemStateManager_UserLogOffRemarks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_SystemStateManager_UserLogOffRemarks.Location = new System.Drawing.Point(616, 168);
            this.label_SystemStateManager_UserLogOffRemarks.Name = "label_SystemStateManager_UserLogOffRemarks";
            this.label_SystemStateManager_UserLogOffRemarks.Size = new System.Drawing.Size(304, 40);
            this.label_SystemStateManager_UserLogOffRemarks.TabIndex = 16;
            // 
            // splitter_SystemStateManager_Remarks
            // 
            this.splitter_SystemStateManager_Remarks.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.splitter_SystemStateManager_Remarks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter_SystemStateManager_Remarks.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter_SystemStateManager_Remarks.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter_SystemStateManager_Remarks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitter_SystemStateManager_Remarks.Location = new System.Drawing.Point(592, 0);
            this.splitter_SystemStateManager_Remarks.Name = "splitter_SystemStateManager_Remarks";
            this.splitter_SystemStateManager_Remarks.Size = new System.Drawing.Size(352, 587);
            this.splitter_SystemStateManager_Remarks.TabIndex = 11;
            this.splitter_SystemStateManager_Remarks.TabStop = false;
            // 
            // groupBox_SystemStateManager_ChangeSystemState
            // 
            this.groupBox_SystemStateManager_ChangeSystemState.Controls.Add(this.button_SystemStateManager_PowerOff);
            this.groupBox_SystemStateManager_ChangeSystemState.Controls.Add(this.checkBox_SystemStateManager_ForceTerminateIfHung);
            this.groupBox_SystemStateManager_ChangeSystemState.Controls.Add(this.checkBox_SystemStateManager_ForceTerminate);
            this.groupBox_SystemStateManager_ChangeSystemState.Controls.Add(this.button_SystemStateManager_ShutDown);
            this.groupBox_SystemStateManager_ChangeSystemState.Controls.Add(this.button_SystemStateManager_Restart);
            this.groupBox_SystemStateManager_ChangeSystemState.Controls.Add(this.button_SystemStateManager_UserLogOff);
            this.groupBox_SystemStateManager_ChangeSystemState.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_SystemStateManager_ChangeSystemState.Location = new System.Drawing.Point(16, 24);
            this.groupBox_SystemStateManager_ChangeSystemState.Name = "groupBox_SystemStateManager_ChangeSystemState";
            this.groupBox_SystemStateManager_ChangeSystemState.Size = new System.Drawing.Size(480, 232);
            this.groupBox_SystemStateManager_ChangeSystemState.TabIndex = 9;
            this.groupBox_SystemStateManager_ChangeSystemState.TabStop = false;
            // 
            // button_SystemStateManager_PowerOff
            // 
            this.button_SystemStateManager_PowerOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_SystemStateManager_PowerOff.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_SystemStateManager_PowerOff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_SystemStateManager_PowerOff.Location = new System.Drawing.Point(16, 48);
            this.button_SystemStateManager_PowerOff.Name = "button_SystemStateManager_PowerOff";
            this.button_SystemStateManager_PowerOff.Size = new System.Drawing.Size(120, 23);
            this.button_SystemStateManager_PowerOff.TabIndex = 7;
            this.button_SystemStateManager_PowerOff.Text = "Power Off";
            this.button_SystemStateManager_PowerOff.Click += new System.EventHandler(this.button_SystemStateManager_PowerOff_Click);
            // 
            // checkBox_SystemStateManager_ForceTerminateIfHung
            // 
            this.checkBox_SystemStateManager_ForceTerminateIfHung.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_SystemStateManager_ForceTerminateIfHung.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_SystemStateManager_ForceTerminateIfHung.Location = new System.Drawing.Point(152, 96);
            this.checkBox_SystemStateManager_ForceTerminateIfHung.Name = "checkBox_SystemStateManager_ForceTerminateIfHung";
            this.checkBox_SystemStateManager_ForceTerminateIfHung.Size = new System.Drawing.Size(280, 48);
            this.checkBox_SystemStateManager_ForceTerminateIfHung.TabIndex = 6;
            this.checkBox_SystemStateManager_ForceTerminateIfHung.Text = "Forces Processes to terminate if the do not respond.";
            // 
            // checkBox_SystemStateManager_ForceTerminate
            // 
            this.checkBox_SystemStateManager_ForceTerminate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_SystemStateManager_ForceTerminate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_SystemStateManager_ForceTerminate.Location = new System.Drawing.Point(152, 72);
            this.checkBox_SystemStateManager_ForceTerminate.Name = "checkBox_SystemStateManager_ForceTerminate";
            this.checkBox_SystemStateManager_ForceTerminate.Size = new System.Drawing.Size(280, 16);
            this.checkBox_SystemStateManager_ForceTerminate.TabIndex = 5;
            this.checkBox_SystemStateManager_ForceTerminate.Text = "Forces Processes to terminate.";
            // 
            // button_SystemStateManager_ShutDown
            // 
            this.button_SystemStateManager_ShutDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_SystemStateManager_ShutDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_SystemStateManager_ShutDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_SystemStateManager_ShutDown.Location = new System.Drawing.Point(16, 88);
            this.button_SystemStateManager_ShutDown.Name = "button_SystemStateManager_ShutDown";
            this.button_SystemStateManager_ShutDown.Size = new System.Drawing.Size(120, 23);
            this.button_SystemStateManager_ShutDown.TabIndex = 4;
            this.button_SystemStateManager_ShutDown.Text = "Shut Down";
            this.button_SystemStateManager_ShutDown.Click += new System.EventHandler(this.button_SystemStateManager_ShutDown_Click);
            // 
            // button_SystemStateManager_Restart
            // 
            this.button_SystemStateManager_Restart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_SystemStateManager_Restart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_SystemStateManager_Restart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_SystemStateManager_Restart.Location = new System.Drawing.Point(16, 128);
            this.button_SystemStateManager_Restart.Name = "button_SystemStateManager_Restart";
            this.button_SystemStateManager_Restart.Size = new System.Drawing.Size(120, 23);
            this.button_SystemStateManager_Restart.TabIndex = 3;
            this.button_SystemStateManager_Restart.Text = "Restart";
            this.button_SystemStateManager_Restart.Click += new System.EventHandler(this.button_SystemStateManager_Restart_Click);
            // 
            // button_SystemStateManager_UserLogOff
            // 
            this.button_SystemStateManager_UserLogOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_SystemStateManager_UserLogOff.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_SystemStateManager_UserLogOff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_SystemStateManager_UserLogOff.Location = new System.Drawing.Point(16, 168);
            this.button_SystemStateManager_UserLogOff.Name = "button_SystemStateManager_UserLogOff";
            this.button_SystemStateManager_UserLogOff.Size = new System.Drawing.Size(120, 24);
            this.button_SystemStateManager_UserLogOff.TabIndex = 2;
            this.button_SystemStateManager_UserLogOff.Text = "Log Off User";
            this.button_SystemStateManager_UserLogOff.Click += new System.EventHandler(this.button_SystemStateManager_UserLogOff_Click);
            // 
            // groupBox_SystemStateManager_ChangePowerState
            // 
            this.groupBox_SystemStateManager_ChangePowerState.Controls.Add(this.checkBox_SystemStateManager_ForceImmediatelySuspend);
            this.groupBox_SystemStateManager_ChangePowerState.Controls.Add(this.label_SystemStateManager_HibernateDescription);
            this.groupBox_SystemStateManager_ChangePowerState.Controls.Add(this.button_SystemStateManager_Hiberate);
            this.groupBox_SystemStateManager_ChangePowerState.Controls.Add(this.button_SystemStateManager_StandBy);
            this.groupBox_SystemStateManager_ChangePowerState.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_SystemStateManager_ChangePowerState.Location = new System.Drawing.Point(16, 272);
            this.groupBox_SystemStateManager_ChangePowerState.Name = "groupBox_SystemStateManager_ChangePowerState";
            this.groupBox_SystemStateManager_ChangePowerState.Size = new System.Drawing.Size(480, 136);
            this.groupBox_SystemStateManager_ChangePowerState.TabIndex = 10;
            this.groupBox_SystemStateManager_ChangePowerState.TabStop = false;
            // 
            // checkBox_SystemStateManager_ForceImmediatelySuspend
            // 
            this.checkBox_SystemStateManager_ForceImmediatelySuspend.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_SystemStateManager_ForceImmediatelySuspend.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_SystemStateManager_ForceImmediatelySuspend.Location = new System.Drawing.Point(152, 40);
            this.checkBox_SystemStateManager_ForceImmediatelySuspend.Name = "checkBox_SystemStateManager_ForceImmediatelySuspend";
            this.checkBox_SystemStateManager_ForceImmediatelySuspend.Size = new System.Drawing.Size(320, 24);
            this.checkBox_SystemStateManager_ForceImmediatelySuspend.TabIndex = 8;
            this.checkBox_SystemStateManager_ForceImmediatelySuspend.Text = "Force immediately suspends.";
            // 
            // label_SystemStateManager_HibernateDescription
            // 
            this.label_SystemStateManager_HibernateDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_SystemStateManager_HibernateDescription.Location = new System.Drawing.Point(152, 80);
            this.label_SystemStateManager_HibernateDescription.Name = "label_SystemStateManager_HibernateDescription";
            this.label_SystemStateManager_HibernateDescription.Size = new System.Drawing.Size(320, 32);
            this.label_SystemStateManager_HibernateDescription.TabIndex = 7;
            this.label_SystemStateManager_HibernateDescription.Text = "(2000 \\ XP only)";
            // 
            // button_SystemStateManager_Hiberate
            // 
            this.button_SystemStateManager_Hiberate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_SystemStateManager_Hiberate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_SystemStateManager_Hiberate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_SystemStateManager_Hiberate.Location = new System.Drawing.Point(16, 80);
            this.button_SystemStateManager_Hiberate.Name = "button_SystemStateManager_Hiberate";
            this.button_SystemStateManager_Hiberate.Size = new System.Drawing.Size(120, 23);
            this.button_SystemStateManager_Hiberate.TabIndex = 0;
            this.button_SystemStateManager_Hiberate.Text = "Hibernate";
            this.button_SystemStateManager_Hiberate.Click += new System.EventHandler(this.button_SystemStateManager_Hiberate_Click);
            // 
            // button_SystemStateManager_StandBy
            // 
            this.button_SystemStateManager_StandBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_SystemStateManager_StandBy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_SystemStateManager_StandBy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_SystemStateManager_StandBy.Location = new System.Drawing.Point(16, 40);
            this.button_SystemStateManager_StandBy.Name = "button_SystemStateManager_StandBy";
            this.button_SystemStateManager_StandBy.Size = new System.Drawing.Size(120, 23);
            this.button_SystemStateManager_StandBy.TabIndex = 1;
            this.button_SystemStateManager_StandBy.Text = "Stand By";
            this.button_SystemStateManager_StandBy.Click += new System.EventHandler(this.button_SystemStateManager_StandBy_Click);
            // 
            // groupBox_SystemStateManager_ChangeSecurityState
            // 
            this.groupBox_SystemStateManager_ChangeSecurityState.Controls.Add(this.button_SystemStateManager_LockWorkStation);
            this.groupBox_SystemStateManager_ChangeSecurityState.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_SystemStateManager_ChangeSecurityState.Location = new System.Drawing.Point(16, 424);
            this.groupBox_SystemStateManager_ChangeSecurityState.Name = "groupBox_SystemStateManager_ChangeSecurityState";
            this.groupBox_SystemStateManager_ChangeSecurityState.Size = new System.Drawing.Size(480, 120);
            this.groupBox_SystemStateManager_ChangeSecurityState.TabIndex = 11;
            this.groupBox_SystemStateManager_ChangeSecurityState.TabStop = false;
            // 
            // button_SystemStateManager_LockWorkStation
            // 
            this.button_SystemStateManager_LockWorkStation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_SystemStateManager_LockWorkStation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_SystemStateManager_LockWorkStation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_SystemStateManager_LockWorkStation.Location = new System.Drawing.Point(16, 32);
            this.button_SystemStateManager_LockWorkStation.Name = "button_SystemStateManager_LockWorkStation";
            this.button_SystemStateManager_LockWorkStation.Size = new System.Drawing.Size(120, 23);
            this.button_SystemStateManager_LockWorkStation.TabIndex = 1;
            this.button_SystemStateManager_LockWorkStation.Text = "Lock Workstation";
            this.button_SystemStateManager_LockWorkStation.Click += new System.EventHandler(this.button_SystemStateManager_LockWorkStation_Click);
            // 
            // tabPage_Camera
            // 
            this.tabPage_Camera.Controls.Add(this.checkBox_CameraTab_EnableCamera);
            this.tabPage_Camera.Controls.Add(this.groupBox9);
            this.tabPage_Camera.Controls.Add(this.groupBox10);
            this.tabPage_Camera.Controls.Add(this.groupBox1);
            this.tabPage_Camera.Location = new System.Drawing.Point(4, 40);
            this.tabPage_Camera.Name = "tabPage_Camera";
            this.tabPage_Camera.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Camera.Size = new System.Drawing.Size(944, 587);
            this.tabPage_Camera.TabIndex = 18;
            this.tabPage_Camera.Text = "Video Conference";
            this.tabPage_Camera.UseVisualStyleBackColor = true;
            this.tabPage_Camera.Click += new System.EventHandler(this.tabPage_Camera_Click);
            // 
            // checkBox_CameraTab_EnableCamera
            // 
            this.checkBox_CameraTab_EnableCamera.AutoSize = true;
            this.checkBox_CameraTab_EnableCamera.Location = new System.Drawing.Point(16, 11);
            this.checkBox_CameraTab_EnableCamera.Name = "checkBox_CameraTab_EnableCamera";
            this.checkBox_CameraTab_EnableCamera.Size = new System.Drawing.Size(59, 17);
            this.checkBox_CameraTab_EnableCamera.TabIndex = 25;
            this.checkBox_CameraTab_EnableCamera.Text = "Enable";
            this.checkBox_CameraTab_EnableCamera.UseVisualStyleBackColor = true;
            this.checkBox_CameraTab_EnableCamera.CheckedChanged += new System.EventHandler(this.checkBox_CameraTab_EnableCamera_CheckedChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.comboBox16);
            this.groupBox9.Controls.Add(this.label27);
            this.groupBox9.Controls.Add(this.label28);
            this.groupBox9.Controls.Add(this.comboBox17);
            this.groupBox9.Controls.Add(this.label26);
            this.groupBox9.Controls.Add(this.radioButton9);
            this.groupBox9.Controls.Add(this.radioButton10);
            this.groupBox9.Controls.Add(this.button12);
            this.groupBox9.Controls.Add(this.trackBar7);
            this.groupBox9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox9.Location = new System.Drawing.Point(16, 34);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(222, 259);
            this.groupBox9.TabIndex = 15;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Single image capture";
            // 
            // comboBox16
            // 
            this.comboBox16.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox16.ItemHeight = 13;
            this.comboBox16.Items.AddRange(new object[] {
            "LZW",
            "None"});
            this.comboBox16.Location = new System.Drawing.Point(26, 137);
            this.comboBox16.Name = "comboBox16";
            this.comboBox16.Size = new System.Drawing.Size(168, 21);
            this.comboBox16.TabIndex = 25;
            // 
            // label27
            // 
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(23, 121);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(168, 16);
            this.label27.TabIndex = 26;
            this.label27.Text = "Compression Format:";
            // 
            // label28
            // 
            this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label28.Location = new System.Drawing.Point(23, 79);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(168, 16);
            this.label28.TabIndex = 24;
            this.label28.Text = "Image format:";
            // 
            // comboBox17
            // 
            this.comboBox17.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox17.ItemHeight = 13;
            this.comboBox17.Location = new System.Drawing.Point(26, 97);
            this.comboBox17.Name = "comboBox17";
            this.comboBox17.Size = new System.Drawing.Size(168, 21);
            this.comboBox17.TabIndex = 23;
            // 
            // label26
            // 
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(23, 171);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(168, 16);
            this.label26.TabIndex = 16;
            this.label26.Text = "Image quality:";
            // 
            // radioButton9
            // 
            this.radioButton9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton9.Location = new System.Drawing.Point(24, 53);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(168, 16);
            this.radioButton9.TabIndex = 4;
            this.radioButton9.Text = "Only Save";
            // 
            // radioButton10
            // 
            this.radioButton10.Checked = true;
            this.radioButton10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton10.Location = new System.Drawing.Point(24, 29);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(168, 16);
            this.radioButton10.TabIndex = 3;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "Save and Show";
            // 
            // button12
            // 
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button12.Location = new System.Drawing.Point(24, 223);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(168, 24);
            this.button12.TabIndex = 1;
            this.button12.Text = "Capture Image";
            // 
            // trackBar7
            // 
            this.trackBar7.AutoSize = false;
            this.trackBar7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar7.LargeChange = 1;
            this.trackBar7.Location = new System.Drawing.Point(17, 187);
            this.trackBar7.Maximum = 100;
            this.trackBar7.Name = "trackBar7";
            this.trackBar7.Size = new System.Drawing.Size(184, 26);
            this.trackBar7.TabIndex = 15;
            this.trackBar7.TickFrequency = 5;
            this.trackBar7.Value = 100;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.comboBox18);
            this.groupBox10.Controls.Add(this.label29);
            this.groupBox10.Controls.Add(this.label30);
            this.groupBox10.Controls.Add(this.trackBar8);
            this.groupBox10.Controls.Add(this.radioButton11);
            this.groupBox10.Controls.Add(this.radioButton12);
            this.groupBox10.Controls.Add(this.label31);
            this.groupBox10.Controls.Add(this.label32);
            this.groupBox10.Controls.Add(this.comboBox19);
            this.groupBox10.Controls.Add(this.button13);
            this.groupBox10.Controls.Add(this.button14);
            this.groupBox10.Controls.Add(this.comboBox20);
            this.groupBox10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox10.Location = new System.Drawing.Point(16, 299);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(222, 281);
            this.groupBox10.TabIndex = 16;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Capture using interval";
            // 
            // comboBox18
            // 
            this.comboBox18.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox18.ItemHeight = 13;
            this.comboBox18.Items.AddRange(new object[] {
            "LZW",
            "None"});
            this.comboBox18.Location = new System.Drawing.Point(24, 119);
            this.comboBox18.Name = "comboBox18";
            this.comboBox18.Size = new System.Drawing.Size(168, 21);
            this.comboBox18.TabIndex = 21;
            // 
            // label29
            // 
            this.label29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label29.Location = new System.Drawing.Point(21, 103);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(168, 16);
            this.label29.TabIndex = 22;
            this.label29.Text = "Compression Format:";
            // 
            // label30
            // 
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(24, 148);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(168, 16);
            this.label30.TabIndex = 20;
            this.label30.Text = "Image quality:";
            // 
            // trackBar8
            // 
            this.trackBar8.AutoSize = false;
            this.trackBar8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar8.LargeChange = 1;
            this.trackBar8.Location = new System.Drawing.Point(16, 164);
            this.trackBar8.Maximum = 100;
            this.trackBar8.Name = "trackBar8";
            this.trackBar8.Size = new System.Drawing.Size(184, 32);
            this.trackBar8.TabIndex = 19;
            this.trackBar8.TickFrequency = 5;
            this.trackBar8.Value = 100;
            // 
            // radioButton11
            // 
            this.radioButton11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton11.Location = new System.Drawing.Point(24, 43);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(167, 16);
            this.radioButton11.TabIndex = 18;
            this.radioButton11.Text = "Only Save";
            // 
            // radioButton12
            // 
            this.radioButton12.Checked = true;
            this.radioButton12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton12.Location = new System.Drawing.Point(24, 21);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(168, 16);
            this.radioButton12.TabIndex = 17;
            this.radioButton12.TabStop = true;
            this.radioButton12.Text = "Save and Show";
            // 
            // label31
            // 
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(21, 61);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(168, 16);
            this.label31.TabIndex = 16;
            this.label31.Text = "Image format:";
            // 
            // label32
            // 
            this.label32.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label32.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label32.Location = new System.Drawing.Point(23, 199);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(168, 16);
            this.label32.TabIndex = 14;
            this.label32.Text = "Interval (seconds):";
            // 
            // comboBox19
            // 
            this.comboBox19.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox19.ItemHeight = 13;
            this.comboBox19.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "45",
            "60"});
            this.comboBox19.Location = new System.Drawing.Point(23, 215);
            this.comboBox19.Name = "comboBox19";
            this.comboBox19.Size = new System.Drawing.Size(168, 21);
            this.comboBox19.TabIndex = 13;
            // 
            // button13
            // 
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button13.Location = new System.Drawing.Point(23, 247);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(80, 23);
            this.button13.TabIndex = 11;
            this.button13.Text = "Start";
            // 
            // button14
            // 
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button14.Location = new System.Drawing.Point(111, 247);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(80, 23);
            this.button14.TabIndex = 12;
            this.button14.Text = "Stop";
            // 
            // comboBox20
            // 
            this.comboBox20.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox20.ItemHeight = 13;
            this.comboBox20.Location = new System.Drawing.Point(24, 79);
            this.comboBox20.Name = "comboBox20";
            this.comboBox20.Size = new System.Drawing.Size(168, 21);
            this.comboBox20.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button16);
            this.groupBox1.Controls.Add(this.button15);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.comboBox21);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(244, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 570);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display Settings";
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(472, 37);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(91, 23);
            this.button16.TabIndex = 24;
            this.button16.Text = "Options";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(373, 37);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(91, 23);
            this.button15.TabIndex = 23;
            this.button15.Text = "Options";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(472, 17);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(79, 17);
            this.checkBox3.TabIndex = 22;
            this.checkBox3.Text = "Enable Mic";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(572, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Save To...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(572, 17);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(116, 17);
            this.checkBox2.TabIndex = 20;
            this.checkBox2.Text = "Save To Video File";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 24);
            this.checkBox1.TabIndex = 25;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(25, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(644, 484);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // label33
            // 
            this.label33.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(199, 23);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(168, 16);
            this.label33.TabIndex = 16;
            this.label33.Text = "Refresh Interval (seconds):";
            // 
            // comboBox21
            // 
            this.comboBox21.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox21.ItemHeight = 13;
            this.comboBox21.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "45",
            "60"});
            this.comboBox21.Location = new System.Drawing.Point(199, 39);
            this.comboBox21.Name = "comboBox21";
            this.comboBox21.Size = new System.Drawing.Size(168, 21);
            this.comboBox21.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(92, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Resolution:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ItemHeight = 13;
            this.comboBox1.Location = new System.Drawing.Point(92, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(101, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // contextMenu_RemoteRegistry_KeysContextMenu
            // 
            this.contextMenu_RemoteRegistry_KeysContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_RemoteRegistry_ToggleKeyState,
            this.menuItem_RemoteRegistry_NewItem,
            this.menuItem_RemoteRegistry_DeleteKey,
            this.menuItem_RemoteRegistry_CopyKeyName});
            // 
            // menuItem_RemoteRegistry_ToggleKeyState
            // 
            this.menuItem_RemoteRegistry_ToggleKeyState.Index = 0;
            this.menuItem_RemoteRegistry_ToggleKeyState.Text = "Expand";
            this.menuItem_RemoteRegistry_ToggleKeyState.Click += new System.EventHandler(this.menuItem_RemoteRegistry_ToggleKeyState_Click);
            // 
            // menuItem_RemoteRegistry_NewItem
            // 
            this.menuItem_RemoteRegistry_NewItem.Index = 1;
            this.menuItem_RemoteRegistry_NewItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_RemoteRegistry_NewItem_Key,
            this.menuItem_RemoteRegistry_NewItem_Separator1,
            this.menuItem_RemoteRegistry_NewItem_String,
            this.menuItem_RemoteRegistry_NewItem_MultiString,
            this.menuItem_RemoteRegistry_NewItem_DWORD});
            this.menuItem_RemoteRegistry_NewItem.Text = "New";
            // 
            // menuItem_RemoteRegistry_NewItem_Key
            // 
            this.menuItem_RemoteRegistry_NewItem_Key.Index = 0;
            this.menuItem_RemoteRegistry_NewItem_Key.Text = "Key";
            this.menuItem_RemoteRegistry_NewItem_Key.Click += new System.EventHandler(this.menuItem_RemoteRegistry_NewItem_Key_Click);
            // 
            // menuItem_RemoteRegistry_NewItem_Separator1
            // 
            this.menuItem_RemoteRegistry_NewItem_Separator1.Index = 1;
            this.menuItem_RemoteRegistry_NewItem_Separator1.Text = "-";
            // 
            // menuItem_RemoteRegistry_NewItem_String
            // 
            this.menuItem_RemoteRegistry_NewItem_String.Index = 2;
            this.menuItem_RemoteRegistry_NewItem_String.Text = "String";
            this.menuItem_RemoteRegistry_NewItem_String.Click += new System.EventHandler(this.menuItem_RemoteRegistry_NewItem_String_Click);
            // 
            // menuItem_RemoteRegistry_NewItem_MultiString
            // 
            this.menuItem_RemoteRegistry_NewItem_MultiString.Index = 3;
            this.menuItem_RemoteRegistry_NewItem_MultiString.Text = "Multi-String";
            this.menuItem_RemoteRegistry_NewItem_MultiString.Click += new System.EventHandler(this.menuItem_RemoteRegistry_NewItem_MultiString_Click);
            // 
            // menuItem_RemoteRegistry_NewItem_DWORD
            // 
            this.menuItem_RemoteRegistry_NewItem_DWORD.Index = 4;
            this.menuItem_RemoteRegistry_NewItem_DWORD.Text = "DWORD";
            this.menuItem_RemoteRegistry_NewItem_DWORD.Click += new System.EventHandler(this.menuItem_RemoteRegistry_NewItem_DWORD_Click);
            // 
            // menuItem_RemoteRegistry_DeleteKey
            // 
            this.menuItem_RemoteRegistry_DeleteKey.Index = 2;
            this.menuItem_RemoteRegistry_DeleteKey.Text = "Delete";
            this.menuItem_RemoteRegistry_DeleteKey.Click += new System.EventHandler(this.menuItem_RemoteRegistry_DeleteKey_Click);
            // 
            // menuItem_RemoteRegistry_CopyKeyName
            // 
            this.menuItem_RemoteRegistry_CopyKeyName.Index = 3;
            this.menuItem_RemoteRegistry_CopyKeyName.Text = "Copy Key Name";
            this.menuItem_RemoteRegistry_CopyKeyName.Click += new System.EventHandler(this.menuItem_RemoteRegistry_CopyKeyName_Click);
            // 
            // contextMenu_RemoteRegistry_ValuesContextMenu
            // 
            this.contextMenu_RemoteRegistry_ValuesContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_RemoteRegistryValuesContextMenu_NewItem});
            // 
            // menuItem_RemoteRegistryValuesContextMenu_NewItem
            // 
            this.menuItem_RemoteRegistryValuesContextMenu_NewItem.Index = 0;
            this.menuItem_RemoteRegistryValuesContextMenu_NewItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_RemoteRegistryValuesContextMenu_New_Key,
            this.menuItem_RemoteRegistryValuesContextMenu_New_Separator1,
            this.menuItem_RemoteRegistryValuesContextMenu_New_String,
            this.menuItem_RemoteRegistryValuesContextMenu_New_MultiString,
            this.menuItem_RemoteRegistryValuesContextMenu_New_DWORD,
            this.menuItem_RemoteRegistryValuesContextMenu_New_Binary});
            this.menuItem_RemoteRegistryValuesContextMenu_NewItem.Text = "New";
            // 
            // menuItem_RemoteRegistryValuesContextMenu_New_Key
            // 
            this.menuItem_RemoteRegistryValuesContextMenu_New_Key.Index = 0;
            this.menuItem_RemoteRegistryValuesContextMenu_New_Key.Text = "Key";
            this.menuItem_RemoteRegistryValuesContextMenu_New_Key.Click += new System.EventHandler(this.menuItem_RemoteRegistryValuesContextMenu_New_Key_Click);
            // 
            // menuItem_RemoteRegistryValuesContextMenu_New_Separator1
            // 
            this.menuItem_RemoteRegistryValuesContextMenu_New_Separator1.Index = 1;
            this.menuItem_RemoteRegistryValuesContextMenu_New_Separator1.Text = "-";
            // 
            // menuItem_RemoteRegistryValuesContextMenu_New_String
            // 
            this.menuItem_RemoteRegistryValuesContextMenu_New_String.Index = 2;
            this.menuItem_RemoteRegistryValuesContextMenu_New_String.Text = "String";
            this.menuItem_RemoteRegistryValuesContextMenu_New_String.Click += new System.EventHandler(this.menuItem_RemoteRegistryValuesContextMenu_New_String_Click);
            // 
            // menuItem_RemoteRegistryValuesContextMenu_New_MultiString
            // 
            this.menuItem_RemoteRegistryValuesContextMenu_New_MultiString.Index = 3;
            this.menuItem_RemoteRegistryValuesContextMenu_New_MultiString.Text = "Multi-String";
            this.menuItem_RemoteRegistryValuesContextMenu_New_MultiString.Click += new System.EventHandler(this.menuItem_RemoteRegistryValuesContextMenu_New_MultiString_Click);
            // 
            // menuItem_RemoteRegistryValuesContextMenu_New_DWORD
            // 
            this.menuItem_RemoteRegistryValuesContextMenu_New_DWORD.Index = 4;
            this.menuItem_RemoteRegistryValuesContextMenu_New_DWORD.Text = "DWORD";
            this.menuItem_RemoteRegistryValuesContextMenu_New_DWORD.Click += new System.EventHandler(this.menuItem_RemoteRegistryValuesContextMenu_New_DWORD_Click);
            // 
            // menuItem_RemoteRegistryValuesContextMenu_New_Binary
            // 
            this.menuItem_RemoteRegistryValuesContextMenu_New_Binary.Index = 5;
            this.menuItem_RemoteRegistryValuesContextMenu_New_Binary.Text = "";
            // 
            // contextMenu_FileManager_Upload
            // 
            this.contextMenu_FileManager_Upload.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_UploadFiles,
            this.menuItem_UploadFolders});
            // 
            // menuItem_UploadFiles
            // 
            this.menuItem_UploadFiles.Index = 0;
            this.menuItem_UploadFiles.Text = "Upload files";
            this.menuItem_UploadFiles.Click += new System.EventHandler(this.menuItem_UploadFiles_Click);
            // 
            // menuItem_UploadFolders
            // 
            this.menuItem_UploadFolders.Index = 1;
            this.menuItem_UploadFolders.Text = "Upload folders";
            this.menuItem_UploadFolders.Click += new System.EventHandler(this.menuItem_UploadFolders_Click);
            // 
            // columnHeader_ServicesManager_ServiceDisplayName
            // 
            this.columnHeader_ServicesManager_ServiceDisplayName.Text = "ColumnHeader";
            this.columnHeader_ServicesManager_ServiceDisplayName.Width = 310;
            // 
            // columnHeader_ServicesManager_ServiceName
            // 
            this.columnHeader_ServicesManager_ServiceName.Text = "ColumnHeader";
            this.columnHeader_ServicesManager_ServiceName.Width = 130;
            // 
            // columnHeader_ServicesManager_ServiceStatus
            // 
            this.columnHeader_ServicesManager_ServiceStatus.Text = "ColumnHeader";
            this.columnHeader_ServicesManager_ServiceStatus.Width = 70;
            // 
            // mainMenu_Main
            // 
            this.mainMenu_Main.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_File,
            this.menuItem_Options,
            this.menuItem_Help});
            // 
            // menuItem_File
            // 
            this.menuItem_File.Index = 0;
            this.menuItem_File.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_File_Import,
            this.menuItem_File_Export,
            this.menuItem_File_Exit});
            this.menuItem_File.Text = "File";
            // 
            // menuItem_File_Import
            // 
            this.menuItem_File_Import.Index = 0;
            this.menuItem_File_Import.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_File_Import_SettingsDatabase});
            this.menuItem_File_Import.Text = "Import";
            // 
            // menuItem_File_Import_SettingsDatabase
            // 
            this.menuItem_File_Import_SettingsDatabase.Index = 0;
            this.menuItem_File_Import_SettingsDatabase.Text = "Settings DataBase";
            this.menuItem_File_Import_SettingsDatabase.Click += new System.EventHandler(this.menuItem_File_Import_SettingsDatabase_Click);
            // 
            // menuItem_File_Export
            // 
            this.menuItem_File_Export.Index = 1;
            this.menuItem_File_Export.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_File_Export_SettingsDatabase});
            this.menuItem_File_Export.Text = "Export";
            // 
            // menuItem_File_Export_SettingsDatabase
            // 
            this.menuItem_File_Export_SettingsDatabase.Index = 0;
            this.menuItem_File_Export_SettingsDatabase.Text = "Settings DataBase";
            this.menuItem_File_Export_SettingsDatabase.Click += new System.EventHandler(this.menuItem_File_Export_SettingsDatabase_Click);
            // 
            // menuItem_File_Exit
            // 
            this.menuItem_File_Exit.Index = 2;
            this.menuItem_File_Exit.Text = "Exit";
            this.menuItem_File_Exit.Click += new System.EventHandler(this.menuItem_File_Exit_Click);
            // 
            // menuItem_Options
            // 
            this.menuItem_Options.Index = 1;
            this.menuItem_Options.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_Options_Settings});
            this.menuItem_Options.Text = "Options";
            // 
            // menuItem_Options_Settings
            // 
            this.menuItem_Options_Settings.Index = 0;
            this.menuItem_Options_Settings.Text = "Settings";
            this.menuItem_Options_Settings.Click += new System.EventHandler(this.menuItem_Options_Settings_Click);
            // 
            // menuItem_Help
            // 
            this.menuItem_Help.Index = 2;
            this.menuItem_Help.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_Help_About,
            this.menuItem_Help_Register});
            this.menuItem_Help.Text = "Help";
            // 
            // menuItem_Help_About
            // 
            this.menuItem_Help_About.Index = 0;
            this.menuItem_Help_About.Text = "About";
            this.menuItem_Help_About.Click += new System.EventHandler(this.menuItem_Help_About_Click);
            // 
            // menuItem_Help_Register
            // 
            this.menuItem_Help_Register.Enabled = false;
            this.menuItem_Help_Register.Index = 1;
            this.menuItem_Help_Register.Text = "Register...";
            this.menuItem_Help_Register.Visible = false;
            this.menuItem_Help_Register.Click += new System.EventHandler(this.menuItem_Help_Register_Click);
            // 
            // contextMenu_RTDV_SendKeys
            // 
            this.contextMenu_RTDV_SendKeys.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_AltF12,
            this.menuItem_AltCtrlF12,
            this.menuItem_CtrlEsc,
            this.menuItem_F12,
            this.menuItem_TAB});
            // 
            // menuItem_AltF12
            // 
            this.menuItem_AltF12.Index = 0;
            this.menuItem_AltF12.Text = "Alt-F12";
            this.menuItem_AltF12.Click += new System.EventHandler(this.menuItem_AltF12_Click);
            // 
            // menuItem_AltCtrlF12
            // 
            this.menuItem_AltCtrlF12.Index = 1;
            this.menuItem_AltCtrlF12.Text = "Alt-Ctrl-F12";
            this.menuItem_AltCtrlF12.Click += new System.EventHandler(this.menuItem_AltCtrlF12_Click);
            // 
            // menuItem_CtrlEsc
            // 
            this.menuItem_CtrlEsc.Index = 2;
            this.menuItem_CtrlEsc.Text = "Ctrl-Esc";
            this.menuItem_CtrlEsc.Click += new System.EventHandler(this.menuItem_CtrlEsc_Click);
            // 
            // menuItem_F12
            // 
            this.menuItem_F12.Index = 3;
            this.menuItem_F12.Text = "F12";
            this.menuItem_F12.Click += new System.EventHandler(this.menuItem_F12_Click);
            // 
            // menuItem_TAB
            // 
            this.menuItem_TAB.Index = 4;
            this.menuItem_TAB.Text = "TAB";
            this.menuItem_TAB.Click += new System.EventHandler(this.menuItem_TAB_Click);
            // 
            // imageList_RTDV
            // 
            this.imageList_RTDV.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_RTDV.ImageStream")));
            this.imageList_RTDV.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_RTDV.Images.SetKeyName(0, "");
            // 
            // contextMenu_RemoteRegistry_NewValue
            // 
            this.contextMenu_RemoteRegistry_NewValue.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_RemoteRegistry_NewValue_String,
            this.menuItem_RemoteRegistry_NewValue_MultiString,
            this.menuItem_RemoteRegistry_NewValue_DWORD,
            this.menuItem_RemoteRegistry_NewValue_Binary});
            // 
            // menuItem_RemoteRegistry_NewValue_String
            // 
            this.menuItem_RemoteRegistry_NewValue_String.Index = 0;
            this.menuItem_RemoteRegistry_NewValue_String.Text = "String";
            this.menuItem_RemoteRegistry_NewValue_String.Click += new System.EventHandler(this.menuItem_RemoteRegistry_NewValue_String_Click);
            // 
            // menuItem_RemoteRegistry_NewValue_MultiString
            // 
            this.menuItem_RemoteRegistry_NewValue_MultiString.Index = 1;
            this.menuItem_RemoteRegistry_NewValue_MultiString.Text = "Multi-String";
            this.menuItem_RemoteRegistry_NewValue_MultiString.Click += new System.EventHandler(this.menuItem_RemoteRegistry_NewValue_MultiString_Click);
            // 
            // menuItem_RemoteRegistry_NewValue_DWORD
            // 
            this.menuItem_RemoteRegistry_NewValue_DWORD.Index = 2;
            this.menuItem_RemoteRegistry_NewValue_DWORD.Text = "DWORD";
            this.menuItem_RemoteRegistry_NewValue_DWORD.Click += new System.EventHandler(this.menuItem_RemoteRegistry_NewValue_DWORD_Click);
            // 
            // menuItem_RemoteRegistry_NewValue_Binary
            // 
            this.menuItem_RemoteRegistry_NewValue_Binary.Index = 3;
            this.menuItem_RemoteRegistry_NewValue_Binary.Text = "";
            // 
            // contextMenu_RemoteRegistry_ValueActions
            // 
            this.contextMenu_RemoteRegistry_ValueActions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_RemoteRegistryValueActions_Modify,
            this.menuItem_RemoteRegistryValueActions_Separaton1,
            this.menuItem_RemoteRegistryValueActions_Delete,
            this.menuItem_RemoteRegistryValueActions_Rename});
            // 
            // menuItem_RemoteRegistryValueActions_Modify
            // 
            this.menuItem_RemoteRegistryValueActions_Modify.Index = 0;
            this.menuItem_RemoteRegistryValueActions_Modify.Text = "Modify";
            this.menuItem_RemoteRegistryValueActions_Modify.Click += new System.EventHandler(this.menuItem_RemoteRegistryValueActions_Modify_Click);
            // 
            // menuItem_RemoteRegistryValueActions_Separaton1
            // 
            this.menuItem_RemoteRegistryValueActions_Separaton1.Index = 1;
            this.menuItem_RemoteRegistryValueActions_Separaton1.Text = "-";
            // 
            // menuItem_RemoteRegistryValueActions_Delete
            // 
            this.menuItem_RemoteRegistryValueActions_Delete.Index = 2;
            this.menuItem_RemoteRegistryValueActions_Delete.Text = "Delete";
            this.menuItem_RemoteRegistryValueActions_Delete.Click += new System.EventHandler(this.menuItem_RemoteRegistryValueActions_Delete_Click);
            // 
            // menuItem_RemoteRegistryValueActions_Rename
            // 
            this.menuItem_RemoteRegistryValueActions_Rename.Index = 3;
            this.menuItem_RemoteRegistryValueActions_Rename.Text = "Rename";
            this.menuItem_RemoteRegistryValueActions_Rename.Click += new System.EventHandler(this.menuItem_RemoteRegistryValueActions_Rename_Click);
            // 
            // statusBar_Main
            // 
            this.statusBar_Main.Location = new System.Drawing.Point(0, 638);
            this.statusBar_Main.Name = "statusBar_Main";
            this.statusBar_Main.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel_BytesSent,
            this.statusBarPanel_BytesReceived,
            this.statusBarPanel_CompletedTasksOfTransfers,
            this.statusBarPanel_LastConnectionTime});
            this.statusBar_Main.ShowPanels = true;
            this.statusBar_Main.Size = new System.Drawing.Size(969, 22);
            this.statusBar_Main.SizingGrip = false;
            this.statusBar_Main.TabIndex = 1;
            // 
            // statusBarPanel_BytesSent
            // 
            this.statusBarPanel_BytesSent.Name = "statusBarPanel_BytesSent";
            this.statusBarPanel_BytesSent.Width = 250;
            // 
            // statusBarPanel_BytesReceived
            // 
            this.statusBarPanel_BytesReceived.Name = "statusBarPanel_BytesReceived";
            this.statusBarPanel_BytesReceived.Width = 250;
            // 
            // statusBarPanel_CompletedTasksOfTransfers
            // 
            this.statusBarPanel_CompletedTasksOfTransfers.Name = "statusBarPanel_CompletedTasksOfTransfers";
            this.statusBarPanel_CompletedTasksOfTransfers.Width = 200;
            // 
            // statusBarPanel_LastConnectionTime
            // 
            this.statusBarPanel_LastConnectionTime.Name = "statusBarPanel_LastConnectionTime";
            this.statusBarPanel_LastConnectionTime.Width = 259;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 266);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.comboBox3);
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(16, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(384, 176);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Display Settings";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(200, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Apply";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(56, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "View";
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(200, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Screen refresh rate:";
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(16, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Color quality:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.ItemHeight = 13;
            this.comboBox2.Location = new System.Drawing.Point(16, 40);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(168, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.ItemHeight = 13;
            this.comboBox3.Location = new System.Drawing.Point(200, 40);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(168, 21);
            this.comboBox3.TabIndex = 0;
            // 
            // trackBar1
            // 
            this.trackBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(112, 88);
            this.trackBar1.Maximum = 0;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(152, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(128, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 3;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(272, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "More";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(56, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Less";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.comboBox4);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.trackBar2);
            this.groupBox4.Controls.Add(this.comboBox5);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(16, 200);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(384, 168);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Single image capture";
            // 
            // label7
            // 
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(200, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Image quality:";
            // 
            // label8
            // 
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(200, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Compression format:";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.ItemHeight = 13;
            this.comboBox4.Location = new System.Drawing.Point(16, 72);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(168, 21);
            this.comboBox4.TabIndex = 7;
            // 
            // radioButton1
            // 
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton1.Location = new System.Drawing.Point(16, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(168, 16);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Text = "Only Save";
            // 
            // radioButton2
            // 
            this.radioButton2.Checked = true;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton2.Location = new System.Drawing.Point(200, 32);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(168, 16);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Save and Show";
            // 
            // label9
            // 
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(16, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Image format:";
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button4.Location = new System.Drawing.Point(16, 120);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(168, 24);
            this.button4.TabIndex = 1;
            this.button4.Text = "Capture Image";
            // 
            // trackBar2
            // 
            this.trackBar2.AutoSize = false;
            this.trackBar2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar2.LargeChange = 1;
            this.trackBar2.Location = new System.Drawing.Point(192, 120);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(184, 32);
            this.trackBar2.TabIndex = 15;
            this.trackBar2.TickFrequency = 5;
            this.trackBar2.Value = 100;
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.ItemHeight = 13;
            this.comboBox5.Items.AddRange(new object[] {
            "LZW",
            "None"});
            this.comboBox5.Location = new System.Drawing.Point(200, 72);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(168, 21);
            this.comboBox5.TabIndex = 10;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBox6);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.trackBar3);
            this.groupBox5.Controls.Add(this.radioButton3);
            this.groupBox5.Controls.Add(this.radioButton4);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.comboBox7);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.comboBox8);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox5.Location = new System.Drawing.Point(16, 376);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(384, 192);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Capture using interval";
            // 
            // comboBox6
            // 
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.ItemHeight = 13;
            this.comboBox6.Items.AddRange(new object[] {
            "LZW",
            "None"});
            this.comboBox6.Location = new System.Drawing.Point(200, 72);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(168, 21);
            this.comboBox6.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(200, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(168, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Compression Format:";
            // 
            // label11
            // 
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(200, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(168, 16);
            this.label11.TabIndex = 20;
            this.label11.Text = "Image quality:";
            // 
            // trackBar3
            // 
            this.trackBar3.AutoSize = false;
            this.trackBar3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar3.LargeChange = 1;
            this.trackBar3.Location = new System.Drawing.Point(192, 120);
            this.trackBar3.Maximum = 100;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(184, 32);
            this.trackBar3.TabIndex = 19;
            this.trackBar3.TickFrequency = 5;
            this.trackBar3.Value = 100;
            // 
            // radioButton3
            // 
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton3.Location = new System.Drawing.Point(16, 32);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(168, 16);
            this.radioButton3.TabIndex = 18;
            this.radioButton3.Text = "Only Save";
            // 
            // radioButton4
            // 
            this.radioButton4.Checked = true;
            this.radioButton4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton4.Location = new System.Drawing.Point(200, 32);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(168, 16);
            this.radioButton4.TabIndex = 17;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Save and Show";
            // 
            // label12
            // 
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(16, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(168, 16);
            this.label12.TabIndex = 16;
            this.label12.Text = "Image format:";
            // 
            // label13
            // 
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(16, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(168, 16);
            this.label13.TabIndex = 14;
            this.label13.Text = "Interval (seconds):";
            // 
            // comboBox7
            // 
            this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox7.ItemHeight = 13;
            this.comboBox7.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "45",
            "60"});
            this.comboBox7.Location = new System.Drawing.Point(16, 120);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(168, 21);
            this.comboBox7.TabIndex = 13;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button5.Location = new System.Drawing.Point(16, 152);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Start";
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button6.Location = new System.Drawing.Point(104, 152);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(80, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "Stop";
            // 
            // comboBox8
            // 
            this.comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox8.ItemHeight = 13;
            this.comboBox8.Location = new System.Drawing.Point(16, 72);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(168, 21);
            this.comboBox8.TabIndex = 15;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button7);
            this.groupBox6.Controls.Add(this.button8);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.comboBox9);
            this.groupBox6.Controls.Add(this.comboBox10);
            this.groupBox6.Controls.Add(this.trackBar4);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox6.Location = new System.Drawing.Point(16, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(384, 176);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Display Settings";
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button7.Location = new System.Drawing.Point(200, 136);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(120, 23);
            this.button7.TabIndex = 9;
            this.button7.Text = "Apply";
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button8.Location = new System.Drawing.Point(56, 136);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(128, 23);
            this.button8.TabIndex = 8;
            this.button8.Text = "View";
            // 
            // label14
            // 
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(200, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(168, 16);
            this.label14.TabIndex = 7;
            this.label14.Text = "Screen refresh rate:";
            // 
            // label15
            // 
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(16, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(168, 16);
            this.label15.TabIndex = 6;
            this.label15.Text = "Color quality:";
            // 
            // comboBox9
            // 
            this.comboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox9.ItemHeight = 13;
            this.comboBox9.Location = new System.Drawing.Point(16, 40);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(168, 21);
            this.comboBox9.TabIndex = 2;
            // 
            // comboBox10
            // 
            this.comboBox10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox10.ItemHeight = 13;
            this.comboBox10.Location = new System.Drawing.Point(200, 40);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(168, 21);
            this.comboBox10.TabIndex = 0;
            // 
            // trackBar4
            // 
            this.trackBar4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar4.LargeChange = 1;
            this.trackBar4.Location = new System.Drawing.Point(112, 88);
            this.trackBar4.Maximum = 0;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(152, 45);
            this.trackBar4.TabIndex = 1;
            this.trackBar4.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // label16
            // 
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(128, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 16);
            this.label16.TabIndex = 3;
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(272, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 16);
            this.label17.TabIndex = 4;
            this.label17.Text = "More";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label18
            // 
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(56, 104);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 16);
            this.label18.TabIndex = 5;
            this.label18.Text = "Less";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.comboBox11);
            this.groupBox7.Controls.Add(this.radioButton5);
            this.groupBox7.Controls.Add(this.radioButton6);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Controls.Add(this.button9);
            this.groupBox7.Controls.Add(this.trackBar5);
            this.groupBox7.Controls.Add(this.comboBox12);
            this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox7.Location = new System.Drawing.Point(16, 200);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(384, 168);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Single image capture";
            // 
            // label19
            // 
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(200, 104);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(168, 16);
            this.label19.TabIndex = 16;
            this.label19.Text = "Image quality:";
            // 
            // label20
            // 
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(200, 56);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(168, 16);
            this.label20.TabIndex = 11;
            this.label20.Text = "Compression format:";
            // 
            // comboBox11
            // 
            this.comboBox11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox11.ItemHeight = 13;
            this.comboBox11.Location = new System.Drawing.Point(16, 72);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(168, 21);
            this.comboBox11.TabIndex = 7;
            // 
            // radioButton5
            // 
            this.radioButton5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton5.Location = new System.Drawing.Point(16, 32);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(168, 16);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "Only Save";
            // 
            // radioButton6
            // 
            this.radioButton6.Checked = true;
            this.radioButton6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton6.Location = new System.Drawing.Point(200, 32);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(168, 16);
            this.radioButton6.TabIndex = 3;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Save and Show";
            // 
            // label21
            // 
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(16, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(168, 16);
            this.label21.TabIndex = 9;
            this.label21.Text = "Image format:";
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button9.Location = new System.Drawing.Point(16, 120);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(168, 24);
            this.button9.TabIndex = 1;
            this.button9.Text = "Capture Image";
            // 
            // trackBar5
            // 
            this.trackBar5.AutoSize = false;
            this.trackBar5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar5.LargeChange = 1;
            this.trackBar5.Location = new System.Drawing.Point(192, 120);
            this.trackBar5.Maximum = 100;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(184, 32);
            this.trackBar5.TabIndex = 15;
            this.trackBar5.TickFrequency = 5;
            this.trackBar5.Value = 100;
            // 
            // comboBox12
            // 
            this.comboBox12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox12.ItemHeight = 13;
            this.comboBox12.Items.AddRange(new object[] {
            "LZW",
            "None"});
            this.comboBox12.Location = new System.Drawing.Point(200, 72);
            this.comboBox12.Name = "comboBox12";
            this.comboBox12.Size = new System.Drawing.Size(168, 21);
            this.comboBox12.TabIndex = 10;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.comboBox13);
            this.groupBox8.Controls.Add(this.label22);
            this.groupBox8.Controls.Add(this.label23);
            this.groupBox8.Controls.Add(this.trackBar6);
            this.groupBox8.Controls.Add(this.radioButton7);
            this.groupBox8.Controls.Add(this.radioButton8);
            this.groupBox8.Controls.Add(this.label24);
            this.groupBox8.Controls.Add(this.label25);
            this.groupBox8.Controls.Add(this.comboBox14);
            this.groupBox8.Controls.Add(this.button10);
            this.groupBox8.Controls.Add(this.button11);
            this.groupBox8.Controls.Add(this.comboBox15);
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox8.Location = new System.Drawing.Point(16, 376);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(384, 192);
            this.groupBox8.TabIndex = 13;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Capture using interval";
            // 
            // comboBox13
            // 
            this.comboBox13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox13.ItemHeight = 13;
            this.comboBox13.Items.AddRange(new object[] {
            "LZW",
            "None"});
            this.comboBox13.Location = new System.Drawing.Point(200, 72);
            this.comboBox13.Name = "comboBox13";
            this.comboBox13.Size = new System.Drawing.Size(168, 21);
            this.comboBox13.TabIndex = 21;
            // 
            // label22
            // 
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(200, 56);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(168, 16);
            this.label22.TabIndex = 22;
            this.label22.Text = "Compression Format:";
            // 
            // label23
            // 
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(200, 104);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(168, 16);
            this.label23.TabIndex = 20;
            this.label23.Text = "Image quality:";
            // 
            // trackBar6
            // 
            this.trackBar6.AutoSize = false;
            this.trackBar6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar6.LargeChange = 1;
            this.trackBar6.Location = new System.Drawing.Point(192, 120);
            this.trackBar6.Maximum = 100;
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Size = new System.Drawing.Size(184, 32);
            this.trackBar6.TabIndex = 19;
            this.trackBar6.TickFrequency = 5;
            this.trackBar6.Value = 100;
            // 
            // radioButton7
            // 
            this.radioButton7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton7.Location = new System.Drawing.Point(16, 32);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(168, 16);
            this.radioButton7.TabIndex = 18;
            this.radioButton7.Text = "Only Save";
            // 
            // radioButton8
            // 
            this.radioButton8.Checked = true;
            this.radioButton8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton8.Location = new System.Drawing.Point(200, 32);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(168, 16);
            this.radioButton8.TabIndex = 17;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Save and Show";
            // 
            // label24
            // 
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(16, 56);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(168, 16);
            this.label24.TabIndex = 16;
            this.label24.Text = "Image format:";
            // 
            // label25
            // 
            this.label25.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(16, 104);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(168, 16);
            this.label25.TabIndex = 14;
            this.label25.Text = "Interval (seconds):";
            // 
            // comboBox14
            // 
            this.comboBox14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox14.ItemHeight = 13;
            this.comboBox14.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "45",
            "60"});
            this.comboBox14.Location = new System.Drawing.Point(16, 120);
            this.comboBox14.Name = "comboBox14";
            this.comboBox14.Size = new System.Drawing.Size(168, 21);
            this.comboBox14.TabIndex = 13;
            // 
            // button10
            // 
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button10.Location = new System.Drawing.Point(16, 152);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(80, 23);
            this.button10.TabIndex = 11;
            this.button10.Text = "Start";
            // 
            // button11
            // 
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button11.Location = new System.Drawing.Point(104, 152);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(80, 23);
            this.button11.TabIndex = 12;
            this.button11.Text = "Stop";
            // 
            // comboBox15
            // 
            this.comboBox15.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox15.ItemHeight = 13;
            this.comboBox15.Location = new System.Drawing.Point(16, 72);
            this.comboBox15.Name = "comboBox15";
            this.comboBox15.Size = new System.Drawing.Size(168, 21);
            this.comboBox15.TabIndex = 15;
            // 
            // timer_MainFormTimer
            // 
            this.timer_MainFormTimer.Tick += new System.EventHandler(this.timer_MainFormTimer_Tick);
            // 
            // MainClientForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(969, 660);
            this.Controls.Add(this.statusBar_Main);
            this.Controls.Add(this.tabControl_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(985, 720);
            this.Menu = this.mainMenu_Main;
            this.MinimumSize = new System.Drawing.Size(980, 720);
            this.Name = "MainClientForm";
            this.Activated += new System.EventHandler(this.MainClientForm_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainClientForm_Closing);
            this.Deactivate += new System.EventHandler(this.MainClientForm_Deactivate);
            this.Load += new System.EventHandler(this.MainClientForm_Load);
            this.Move += new System.EventHandler(this.MainClientForm_Move);
            this.splitContainer_RemoteRegistry_MainSplit.Panel1.ResumeLayout(false);
            this.splitContainer_RemoteRegistry_MainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_RemoteRegistry_MainSplit)).EndInit();
            this.splitContainer_RemoteRegistry_MainSplit.ResumeLayout(false);
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_NetworkControl.ResumeLayout(false);
            this.groupBox_NetworkControl_Security.ResumeLayout(false);
            this.groupBox_NetworkControl_Security.PerformLayout();
            this.groupBox_NetworkControl_ProxySettings.ResumeLayout(false);
            this.groupBox_NetworkControl_ProxySettings.PerformLayout();
            this.groupBox_NetworkControl_MainNetworkControl.ResumeLayout(false);
            this.groupBox_NetworkControl_MainNetworkControl.PerformLayout();
            this.groupBox_NetworkControl_ServersList.ResumeLayout(false);
            this.groupBox_NetworkControl_ProxyServersList.ResumeLayout(false);
            this.tabPage_FileManager.ResumeLayout(false);
            this.tabPage_FileManager.PerformLayout();
            this.tabPage_RemoteExecution.ResumeLayout(false);
            this.groupBox_RemoteExecution_ExecuteParameters.ResumeLayout(false);
            this.groupBox_RemoteExecution_ExecuteParameters.PerformLayout();
            this.tabPage_ProcessesManager.ResumeLayout(false);
            this.groupBox_ProcessesManager_ProcessPriority.ResumeLayout(false);
            this.tabPage_DrivesManager.ResumeLayout(false);
            this.tabPage_RemoteRegistry.ResumeLayout(false);
            this.tabPage_RemoteRegistry.PerformLayout();
            this.tabPage_Display.ResumeLayout(false);
            this.groupBox_DisplaySettings_DisplaySettings.ResumeLayout(false);
            this.groupBox_DisplaySettings_DisplaySettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_DisplaySettings_Resolution)).EndInit();
            this.groupBox_SingleImageCapture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_SingleImageCapture_ImageQuality)).EndInit();
            this.groupBox_CaptureInInterval.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_CaptureInInterval_ImageQuality)).EndInit();
            this.tabPage_RTDV.ResumeLayout(false);
            this.tabPage_RTDV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RTDV_ImageCodingAlgorithm)).EndInit();
            this.groupBox_RTDV_AdditionalParameters.ResumeLayout(false);
            this.groupBox_RTDV_AdditionalParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RTDV_ReceivedImageSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RTDV_MaxUpdatePerSec)).EndInit();
            this.tabPage_Message.ResumeLayout(false);
            this.tabPage_Message.PerformLayout();
            this.groupBox_Message_ButtonSelect.ResumeLayout(false);
            this.groupBox_Message_IconSelect.ResumeLayout(false);
            this.groupBox_Message_IconSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Message_IconStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Message_IconInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Message_IconWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Message_IconQuestion)).EndInit();
            this.tabPage_ClipboardManager.ResumeLayout(false);
            this.tabPage_ClipboardManager.PerformLayout();
            this.groupBox_ClipboardManager_ClipboardImageSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RemoteClipboardImageSettings_ImageQuality)).EndInit();
            this.groupBox_ClipboardManager_AddClipboardImageSettings.ResumeLayout(false);
            this.groupBox_ClipboardManager_Image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ClipboardManager_Image)).EndInit();
            this.groupBox_ClipboardManager_TextData.ResumeLayout(false);
            this.groupBox_ClipboardManager_FileDropList.ResumeLayout(false);
            this.tabPage_RemoteSystemInformation.ResumeLayout(false);
            this.groupBox_RemoteSystemInformation_AvailableItems.ResumeLayout(false);
            this.groupBox_RemoteSystemInformation_AvailableItems.PerformLayout();
            this.groupBox_RemoteSystemInformation_AvailableInformation.ResumeLayout(false);
            this.groupBox_RemoteSystemInformation_AvailableInformation.PerformLayout();
            this.tabPage_ServicesManager.ResumeLayout(false);
            this.tabPage_SystemEvents.ResumeLayout(false);
            this.tabPage_SystemEvents.PerformLayout();
            this.tabPage_DriversList.ResumeLayout(false);
            this.tabPage_InstalledPrograms.ResumeLayout(false);
            this.tabPage_InstalledUpdates.ResumeLayout(false);
            this.tabPage_SystemStateManager.ResumeLayout(false);
            this.groupBox_SystemStateManager_ChangeSystemState.ResumeLayout(false);
            this.groupBox_SystemStateManager_ChangePowerState.ResumeLayout(false);
            this.groupBox_SystemStateManager_ChangeSecurityState.ResumeLayout(false);
            this.tabPage_Camera.ResumeLayout(false);
            this.tabPage_Camera.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).EndInit();
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_BytesSent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_BytesReceived)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_CompletedTasksOfTransfers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_LastConnectionTime)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            this.ResumeLayout(false);

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

    #endregion

    #region Main App Methods

   [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        ObjCopy.obj_MainClientForm = new MainClientForm();

        ObjCopy.obj_MiniRTDVForm = new MiniRTDVForm();

     //   ObjCopy.obj_MiniRTDVForm.Show();

      //  ObjCopy.obj_MiniRTDVForm.Hide();

        Application.Run(ObjCopy.obj_MainClientForm);
    }

    public MainClientForm()
    {
        InitializeComponent();

        this.comboBox_NetworkControl_ConnectionTimeOut.SelectedIndex = 2;

        timer_MainFormTimer.Start();


    }


    private void MainClientForm_Load(object sender, System.EventArgs e)
    {
        JurikSoft.XMLConfigImporer.JSClientDBEnvironment.LoadXMLDataFile("JurikSoftClientDB", false);

        ObjCopy.obj_MainClientForm.SetUpClientSettingsFromDB();

        //     new Thread(new ThreadStart(ObjCopy.obj_MainClientForm.NGSCRThread)).Start();

        ObjCopy.obj_MainClientForm.ChangeControlsLanguage();

            

 //       ObjCopy.obj_SoundPlayAndCapture = new SoundPlayAndCapture();
    }

    private void MainClientForm_Deactivate(object sender, EventArgs e)
    {
        this.Deactivate -= new System.EventHandler(this.MainClientForm_Deactivate);
        this.Activated -= new System.EventHandler(this.MainClientForm_Activated);

        ObjCopy.obj_MiniRTDVForm.TopMost = false;

        this.Deactivate += new System.EventHandler(this.MainClientForm_Deactivate);
        this.Activated += new System.EventHandler(this.MainClientForm_Activated);
    }

    private void MainClientForm_Activated(object sender, EventArgs e)
    {
        this.Deactivate -= new System.EventHandler(this.MainClientForm_Deactivate);
        this.Activated -= new System.EventHandler(this.MainClientForm_Activated);

        ObjCopy.obj_MiniRTDVForm.TopMost = true;

        this.Activate();
        this.Focus();

        this.Deactivate += new System.EventHandler(this.MainClientForm_Deactivate);
        this.Activated += new System.EventHandler(this.MainClientForm_Activated);
    }

    private void MainClientForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        bool bool_IsMiniRTDVFormVisible = ObjCopy.obj_MiniRTDVForm.Visible;

        ObjCopy.obj_MiniRTDVForm.Visible = false;

        if (DialogResult.Yes == MessageBox.Show(this, ClientStringFactory.GetString(205, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            WriteClientSettingsToDB();

            ObjCopy.obj_NetworkAction.DisconnectFromServer();
            /*
            if (thread_CaptureUsingInterval != null) thread_CaptureUsingInterval.Abort();
            if (thread_NGSCRThread != null) thread_NGSCRThread.Abort();
            */
            Thread.Sleep(200);

            Process.GetCurrentProcess().Kill();
        }

        else e.Cancel = true;

        ObjCopy.obj_MiniRTDVForm.Visible = bool_IsMiniRTDVFormVisible;

        ObjCopy.obj_MiniRTDVForm.BringToFront();
    }

    private void MainClientForm_Move(object sender, System.EventArgs e)
    {
        try
        {
            //   ObjCopy.obj_MiniRTDVForm.Location = new Point(this.Location.X + 270, this.Location.Y + 145);
            ObjCopy.obj_MiniRTDVForm.Location = new Point(this.Location.X + 230, this.Location.Y + 145);
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
        }

    }

    private void tabControl_Main_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer.Checked = false;

        if (this.tabControl_Main.SelectedIndex != 7)
        {
       //     ObjCopy.obj_MiniRTDVForm.Hide();
        }
        else
        {
         //   ObjCopy.obj_MiniRTDVForm.Show();

            this.Focus();
        }

        int int_SavedNodesTreeWidth = this.treeView_RemoteRegistry_NodesTree.Width;

        this.treeView_RemoteRegistry_NodesTree.Width = 0;

        this.treeView_RemoteRegistry_NodesTree.Width = int_SavedNodesTreeWidth;
    }

    public void ChangeControlsLanguage()
    {
        int int_SelectedItemIndex = 0;

        #region Network Control

        this.Text = ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage);

        this.checkBox_ProxySettings_Authentication_CheckedChanged(null, null);
        this.checkBox_NetworkControl_UseProxy_CheckedChanged(null, null);

        this.label_NetworkControl_IP.Text = ClientStringFactory.GetString(77, ClientSettingsEnvironment.CurrentLanguage);
        this.tabPage_NetworkControl.Text = ClientStringFactory.GetString(70, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_NetworkControl_Security.Text = ClientStringFactory.GetString(71, ClientSettingsEnvironment.CurrentLanguage);
        this.label_NetworkControl_Password.Text = ClientStringFactory.GetString(73, ClientSettingsEnvironment.CurrentLanguage);
        this.label_NetworkControl_Login.Text = ClientStringFactory.GetString(74, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_NetworkControl_MainNetworkControl.Text = ClientStringFactory.GetString(75, ClientSettingsEnvironment.CurrentLanguage);
        this.label_NetworkControl_ConnectionStatus.Text = ClientStringFactory.GetString(76, ClientSettingsEnvironment.CurrentLanguage);
        this.label_NetworkControl_Port.Text = ClientStringFactory.GetString(72, ClientSettingsEnvironment.CurrentLanguage);

        if (MainTcpClient.IsConnected)
        {
            MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(261, ClientSettingsEnvironment.CurrentLanguage);
        }
        else
        {
            MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(78, ClientSettingsEnvironment.CurrentLanguage);
        }

        this.button_NetworkControl_Connect.Text = ClientStringFactory.GetString(79, ClientSettingsEnvironment.CurrentLanguage);
        this.button_NetworkControl_Disconnect.Text = ClientStringFactory.GetString(80, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ServersList_Refresh.Text = ClientStringFactory.GetString(662, ClientSettingsEnvironment.CurrentLanguage);

        this.button_NetworkControl_ConnectingService.Text = ClientStringFactory.GetString(755, ClientSettingsEnvironment.CurrentLanguage);


        this.groupBox_NetworkControl_ServersList.Text = ClientStringFactory.GetString(318, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_NetworkControl_Host.Text = ClientStringFactory.GetString(317, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_NetworkControl_Port.Text = ClientStringFactory.GetString(316, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_NetworkControl_ServerName.Text = ClientStringFactory.GetString(499, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_NetworkControl_ServerLocation.Text = ClientStringFactory.GetString(501, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_NetworkControl_GroupMember.Text = ClientStringFactory.GetString(500, ClientSettingsEnvironment.CurrentLanguage);

        this.button_ServersList_AddRecord.Text = ClientStringFactory.GetString(311, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ServersList_RemoveRecord.Text = ClientStringFactory.GetString(312, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ServersList_ClearList.Text = ClientStringFactory.GetString(313, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ServersList_ViewRecord.Text = ClientStringFactory.GetString(306, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ServersList_EditRecord.Text = ClientStringFactory.GetString(483, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ServersList_Use.Text = ClientStringFactory.GetString(486, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ServersList_GroupSelection.Text = ClientStringFactory.GetString(491, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_NetworkControl_ProxyServersList.Text = ClientStringFactory.GetString(484, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProxyServersList_Title.Text = ClientStringFactory.GetString(485, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProxyServersList_Host.Text = ClientStringFactory.GetString(317, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProxyServersList_Port.Text = ClientStringFactory.GetString(316, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProxyServersList_AddRecord.Text = ClientStringFactory.GetString(311, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProxyServersList_RemoveRecord.Text = ClientStringFactory.GetString(312, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProxyServersList_ClearList.Text = ClientStringFactory.GetString(313, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProxyServersList_ViewRecord.Text = ClientStringFactory.GetString(306, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProxyServersList_EditRecord.Text = ClientStringFactory.GetString(483, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProxyServersList_Use.Text = ClientStringFactory.GetString(486, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_ProxySettings_UseProxy.Text = ClientStringFactory.GetString(382, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_ProxySettings_Authentication.Text = ClientStringFactory.GetString(383, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxySettings_ProxyType.Text = ClientStringFactory.GetString(384, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxySettings_ProxyPort.Text = ClientStringFactory.GetString(72, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxySettings_Socks5Password.Text = ClientStringFactory.GetString(73, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxySettings_Socks5UserName.Text = ClientStringFactory.GetString(405, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxySettings_ProxyTimeOut.Text = ClientStringFactory.GetString(385, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxySettings_ProxyHost.Text = ClientStringFactory.GetString(386, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_ProxySettings_ResolveHostNames.Text = ClientStringFactory.GetString(404, ClientSettingsEnvironment.CurrentLanguage);


        this.groupBox_NetworkControl_ProxySettings.Text = ClientStringFactory.GetString(381, ClientSettingsEnvironment.CurrentLanguage);

        int_SelectedItemIndex = this.comboBox_ProxySettings_ProxyTimeOut.SelectedIndex;

        this.comboBox_ProxySettings_ProxyTimeOut.Items.Clear();
        this.comboBox_ProxySettings_ProxyTimeOut.Items.AddRange(new object[] {
																				 ClientStringFactory.GetString(388, ClientSettingsEnvironment.CurrentLanguage),
																				 ClientStringFactory.GetString(389, ClientSettingsEnvironment.CurrentLanguage),
																				 ClientStringFactory.GetString(400, ClientSettingsEnvironment.CurrentLanguage),
		});

        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 0;

        this.comboBox_ProxySettings_ProxyTimeOut.SelectedIndex = int_SelectedItemIndex;



        int_SelectedItemIndex = this.listBox_ProxySettings_ProxyType.SelectedIndex;

        this.listBox_ProxySettings_ProxyType.Items.Clear();
        this.listBox_ProxySettings_ProxyType.Items.AddRange(new object[] {
																			 ClientStringFactory.GetString(401, ClientSettingsEnvironment.CurrentLanguage),
																			 ClientStringFactory.GetString(402, ClientSettingsEnvironment.CurrentLanguage),
																			 ClientStringFactory.GetString(548, ClientSettingsEnvironment.CurrentLanguage),
		});

        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 0;

        this.listBox_ProxySettings_ProxyType.SelectedIndex = int_SelectedItemIndex;


        int int_SelectedGroupIndex = this.comboBox_ServersList_ServersGroups.SelectedIndex;

        this.comboBox_ServersList_ServersGroups.Items.Clear();

        this.comboBox_ServersList_ServersGroups.Items.Add(ClientStringFactory.GetString(509, ClientSettingsEnvironment.CurrentLanguage));

        this.comboBox_ServersList_ServersGroups.SelectedIndex = int_SelectedGroupIndex;

        #endregion

        #region File Manager

        this.tabPage_FileManager.Text = ClientStringFactory.GetString(81, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FileManager_CurrentFolder.Text = ClientStringFactory.GetString(82, ClientSettingsEnvironment.CurrentLanguage);
        this.button_FileManager_Properties.Text = ClientStringFactory.GetString(436, ClientSettingsEnvironment.CurrentLanguage);
        this.button_FileManager_Execute.Text = ClientStringFactory.GetString(84, ClientSettingsEnvironment.CurrentLanguage);
        this.button_FileManager_NewFolder.Text = ClientStringFactory.GetString(85, ClientSettingsEnvironment.CurrentLanguage);
        this.button_FileManager_Rename.Text = ClientStringFactory.GetString(86, ClientSettingsEnvironment.CurrentLanguage);
        this.button_FileManager_Delete.Text = ClientStringFactory.GetString(87, ClientSettingsEnvironment.CurrentLanguage);
        this.button_FileManager_Upload.Text = ClientStringFactory.GetString(48, ClientSettingsEnvironment.CurrentLanguage);
        this.button_FileManager_Download.Text = ClientStringFactory.GetString(42, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FileManager_LogicalDrives.Text = ClientStringFactory.GetString(90, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_FileManager_ItemName.Text = ClientStringFactory.GetString(135, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_FileManager_FileSize.Text = ClientStringFactory.GetString(91, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_FileManager_LastFileWriteTime.Text = ClientStringFactory.GetString(92, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_FileManager_ItemAttribute.Text = ClientStringFactory.GetString(93, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_FileManager_ItemType.Text = ClientStringFactory.GetString(21, ClientSettingsEnvironment.CurrentLanguage);


        if (ObjCopy.obj_FilesUploadForm != null)
        {
            ObjCopy.obj_FilesUploadForm.ChangeControlsLanguage();
        }

        if (ObjCopy.obj_FilesDownloadForm != null)
        {
            ObjCopy.obj_FilesDownloadForm.ChangeControlsLanguage();
        }

        if (ObjCopy.obj_ConfirmFileReplaceForm != null)
        {
            ObjCopy.obj_ConfirmFileReplaceForm.ChangeControlsLanguage();
        }

        if (ObjCopy.obj_FileManagerObjectPropertiesForm != null)
        {
            ObjCopy.obj_FileManagerObjectPropertiesForm.ChangeControlsLanguage();
        }


        #endregion

        #region Remote Execution

        this.tabPage_RemoteExecution.Text = ClientStringFactory.GetString(94, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RemoteExecution_Remarks.Text = ClientStringFactory.GetString(95, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RemoteExecution_about5.Text = ClientStringFactory.GetString(96, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RemoteExecution_about4.Text = ClientStringFactory.GetString(97, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RemoteExecution_about3.Text = ClientStringFactory.GetString(98, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RemoteExecution_about2.Text = ClientStringFactory.GetString(99, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RemoteExecution_about1.Text = ClientStringFactory.GetString(100, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_RemoteExecution_ExecuteParameters.Text = ClientStringFactory.GetString(101, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RemoteExecution_WindowStyle.Text = ClientStringFactory.GetString(102, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RemoteExecution_WorkingFolder.Text = ClientStringFactory.GetString(103, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RemoteExecution_CommandLineArguments.Text = ClientStringFactory.GetString(104, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RemoteExecution_FileNameWithPath.Text = ClientStringFactory.GetString(105, ClientSettingsEnvironment.CurrentLanguage);

        this.checkBox_RemoteExecution_ShowErrorDialog.Text = ClientStringFactory.GetString(111, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_RemoteExecution_NotCreateWindow.Text = ClientStringFactory.GetString(112, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_RemoteExecution_UseShellExecute.Text = ClientStringFactory.GetString(113, ClientSettingsEnvironment.CurrentLanguage);
        this.button_RemoteExecution_Execute.Text = ClientStringFactory.GetString(114, ClientSettingsEnvironment.CurrentLanguage);

        int_SelectedItemIndex = this.comboBox_RemoteExecution_WindowStyle.SelectedIndex;

        this.comboBox_RemoteExecution_WindowStyle.Items.Clear();
        this.comboBox_RemoteExecution_WindowStyle.Items.AddRange(new object[] {
																				  ClientStringFactory.GetString(107, ClientSettingsEnvironment.CurrentLanguage),
																				  ClientStringFactory.GetString(108, ClientSettingsEnvironment.CurrentLanguage),
																				  ClientStringFactory.GetString(109, ClientSettingsEnvironment.CurrentLanguage),
																				  ClientStringFactory.GetString(110, ClientSettingsEnvironment.CurrentLanguage)
																			  });

        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 3;

        this.comboBox_RemoteExecution_WindowStyle.Text = ClientStringFactory.GetString(110, ClientSettingsEnvironment.CurrentLanguage);
       
        this.comboBox_RemoteExecution_WindowStyle.SelectedIndex = int_SelectedItemIndex;

        #endregion

        #region Processes Manager

        this.tabPage_ProcessesManager.Text = ClientStringFactory.GetString(115, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProcessesManager_KillSelectedProcess.Text = ClientStringFactory.GetString(117, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProcessesManager_ItemName.Text = ClientStringFactory.GetString(118, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProcessesManager_ProcessPriority.Text = ClientStringFactory.GetString(119, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProcessesManager_ThreadsAmount.Text = ClientStringFactory.GetString(120, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProcessesManager_PID.Text = ClientStringFactory.GetString(121, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProcessesManager_MainWindowTitle.Text = ClientStringFactory.GetString(122, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProcessesManager_MemoryUsage.Text = ClientStringFactory.GetString(701, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProcessesManager_ProcessStatus.Text = ClientStringFactory.GetString(136, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_ProcessesManager_ProcessPriority.Text = ClientStringFactory.GetString(119, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProcessesManager_ProcessPriority.Text = ClientStringFactory.GetString(128, ClientSettingsEnvironment.CurrentLanguage);

        this.button_ProcessesManager_ActivateWindowOfSelectedProcess.Text = ClientStringFactory.GetString(257, ClientSettingsEnvironment.CurrentLanguage);

        #endregion

        #region System Events

        this.tabPage_SystemEvents.Text = ClientStringFactory.GetString(129, ClientSettingsEnvironment.CurrentLanguage);
        this.button_SystemEvents_EventProperties.Text = ClientStringFactory.GetString(130, ClientSettingsEnvironment.CurrentLanguage);
        this.button_SystemEvents_DeleteLog.Text = ClientStringFactory.GetString(234, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_SystemEvents_EventType.Text = ClientStringFactory.GetString(21, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_SystemEvents_EventDate.Text = ClientStringFactory.GetString(19, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_SystemEvents_EventTime.Text = ClientStringFactory.GetString(20, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_SystemEvents_EventSource.Text = ClientStringFactory.GetString(24, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_SystemEvents_EventCategoty.Text = ClientStringFactory.GetString(25, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_SystemEvents_EventID.Text = ClientStringFactory.GetString(26, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_SystemEvents_User.Text = ClientStringFactory.GetString(22, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_SystemEvents_Computer.Text = ClientStringFactory.GetString(23, ClientSettingsEnvironment.CurrentLanguage);
        this.button_SystemEvents_DeleteAllEvents.Text = ClientStringFactory.GetString(133, ClientSettingsEnvironment.CurrentLanguage);

        #endregion

        #region Services Manager

        this.tabPage_ServicesManager.Text = ClientStringFactory.GetString(134, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ServicesManager_DisplayName.Text = ClientStringFactory.GetString(199, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ServicesManager_name.Text = ClientStringFactory.GetString(135, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ServicesManager_Status.Text = ClientStringFactory.GetString(136, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ServicesManager_ServiceType.Text = ClientStringFactory.GetString(137, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ServicesManager_ServiceManagement.Text = ClientStringFactory.GetString(141, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ServicesManager_ServiceDisplayName.Text = ClientStringFactory.GetString(199, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ServicesManager_ServiceName.Text = ClientStringFactory.GetString(135, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ServicesManager_ServiceStatus.Text = ClientStringFactory.GetString(136, ClientSettingsEnvironment.CurrentLanguage);

        #endregion

        #region Drivers List

        this.tabPage_DriversList.Text = ClientStringFactory.GetString(144, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_DriversList_DriverName.Text = ClientStringFactory.GetString(146, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_DriversList_Name.Text = ClientStringFactory.GetString(135, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_DriversList_DriverSatus.Text = ClientStringFactory.GetString(136, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_DriversList_DriverType.Text = ClientStringFactory.GetString(147, ClientSettingsEnvironment.CurrentLanguage);

        #endregion

        #region System State Manager

        this.tabPage_SystemStateManager.Text = ClientStringFactory.GetString(148, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SystemStateManager_HibernateRemarks.Text = ClientStringFactory.GetString(149, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SystemStateManager_StandByRemarks.Text = ClientStringFactory.GetString(150, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SystemStateManager_Remarks.Text = ClientStringFactory.GetString(151, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SystemStateManager_ShutDownRemarks.Text = ClientStringFactory.GetString(152, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SystemStateManager_RestartRemarks.Text = ClientStringFactory.GetString(153, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SystemStateManager_PowerOffRemarks.Text = ClientStringFactory.GetString(154, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SystemStateManager_UserLogOffRemarks.Text = ClientStringFactory.GetString(155, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SystemStateManager_LockWorkstationRemarks.Text = ClientStringFactory.GetString(448, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_SystemStateManager_ChangeSystemState.Text = ClientStringFactory.GetString(156, ClientSettingsEnvironment.CurrentLanguage);
        this.button_SystemStateManager_PowerOff.Text = ClientStringFactory.GetString(157, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_SystemStateManager_ForceTerminateIfHung.Text = ClientStringFactory.GetString(158, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_SystemStateManager_ForceTerminate.Text = ClientStringFactory.GetString(159, ClientSettingsEnvironment.CurrentLanguage);
        this.button_SystemStateManager_ShutDown.Text = ClientStringFactory.GetString(160, ClientSettingsEnvironment.CurrentLanguage);
        this.button_SystemStateManager_Restart.Text = ClientStringFactory.GetString(161, ClientSettingsEnvironment.CurrentLanguage);
        this.button_SystemStateManager_UserLogOff.Text = ClientStringFactory.GetString(162, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_SystemStateManager_ChangePowerState.Text = ClientStringFactory.GetString(163, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_SystemStateManager_ForceImmediatelySuspend.Text = ClientStringFactory.GetString(164, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SystemStateManager_HibernateDescription.Text = ClientStringFactory.GetString(165, ClientSettingsEnvironment.CurrentLanguage);
        this.button_SystemStateManager_Hiberate.Text = ClientStringFactory.GetString(166, ClientSettingsEnvironment.CurrentLanguage);
        this.button_SystemStateManager_StandBy.Text = ClientStringFactory.GetString(167, ClientSettingsEnvironment.CurrentLanguage);


        this.groupBox_SystemStateManager_ChangeSecurityState.Text = ClientStringFactory.GetString(446, ClientSettingsEnvironment.CurrentLanguage);
        this.button_SystemStateManager_LockWorkStation.Text = ClientStringFactory.GetString(445, ClientSettingsEnvironment.CurrentLanguage);


        #endregion

        #region Message Tab

        this.tabPage_Message.Text = ClientStringFactory.GetString(168, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_Message_ButtonSelect.Text = ClientStringFactory.GetString(169, ClientSettingsEnvironment.CurrentLanguage);
        this.radioButton_Message_AbortRetryIgnore.Text = ClientStringFactory.GetString(170, ClientSettingsEnvironment.CurrentLanguage);
        this.radioButton_Message_radioButton_Message_YesNoCancel.Text = ClientStringFactory.GetString(171, ClientSettingsEnvironment.CurrentLanguage);
        this.radioButton_Message_RetryCancel.Text = ClientStringFactory.GetString(172, ClientSettingsEnvironment.CurrentLanguage);
        this.radioButton_Message_YesNo.Text = ClientStringFactory.GetString(173, ClientSettingsEnvironment.CurrentLanguage);
        this.radioButton_Message_OkCancel.Text = ClientStringFactory.GetString(174, ClientSettingsEnvironment.CurrentLanguage);
        this.radioButton_Message_Ok.Text = ClientStringFactory.GetString(175, ClientSettingsEnvironment.CurrentLanguage);
        this.label_Message_MessageText.Text = ClientStringFactory.GetString(177, ClientSettingsEnvironment.CurrentLanguage);
        this.label_Message_MessageCaption.Text = ClientStringFactory.GetString(178, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_Message_ReceiveUserChoice.Text = ClientStringFactory.GetString(179, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_Message_IconSelect.Text = ClientStringFactory.GetString(180, ClientSettingsEnvironment.CurrentLanguage);
        this.radioButton_Message_IconNone.Text = ClientStringFactory.GetString(181, ClientSettingsEnvironment.CurrentLanguage);
        this.button_Message_SendMessage.Text = ClientStringFactory.GetString(182, ClientSettingsEnvironment.CurrentLanguage);

        #endregion

        #region Display Tab

        this.tabPage_Display.Text = ClientStringFactory.GetString(183, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SingleImageCapture_ImageFormat.Text = ClientStringFactory.GetString(184, ClientSettingsEnvironment.CurrentLanguage);

        this.comboBox_SingleImageCapture_ImageFormat.Text = "PNG  (Compressed)";

        this.radioButton_SingleImageCapture_OnlySave.Text = ClientStringFactory.GetString(186, ClientSettingsEnvironment.CurrentLanguage);
        this.radioButton_SingleImageCapture_SaveAndShow.Text = ClientStringFactory.GetString(187, ClientSettingsEnvironment.CurrentLanguage);
        this.button_SingleImageCapture_CaptureImage.Text = ClientStringFactory.GetString(188, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SingleImageCapture_CompressionFormat.Text = ClientStringFactory.GetString(519, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SingleImageCapture_ImageQuality.Text = ClientStringFactory.GetString(518, ClientSettingsEnvironment.CurrentLanguage);

        this.radioButton_CaptureInInterval_OnlySave.Text = ClientStringFactory.GetString(186, ClientSettingsEnvironment.CurrentLanguage);
        this.radioButton_CaptureInInterval_SaveAndShow.Text = ClientStringFactory.GetString(187, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CaptureInInterval_CompressionFormat.Text = ClientStringFactory.GetString(519, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CaptureInInterval_ImageQuality.Text = ClientStringFactory.GetString(518, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_DisplaySettings_DisplaySettings.Text = ClientStringFactory.GetString(300, ClientSettingsEnvironment.CurrentLanguage);
        this.label_DisplaySettings_ColorQuality.Text = ClientStringFactory.GetString(301, ClientSettingsEnvironment.CurrentLanguage);
        this.label_DisplaySettings_ScreenRefreshRate.Text = ClientStringFactory.GetString(302, ClientSettingsEnvironment.CurrentLanguage);
        this.label_DisplaySettings_LessResolution.Text = ClientStringFactory.GetString(304, ClientSettingsEnvironment.CurrentLanguage);
        this.label_DisplaySettings_MoreResolution.Text = ClientStringFactory.GetString(305, ClientSettingsEnvironment.CurrentLanguage);
        this.button_DisplaySettings_GetDisplaySettings.Text = ClientStringFactory.GetString(306, ClientSettingsEnvironment.CurrentLanguage);
        this.button_DisplaySettings_SetDisplaySettings.Text = ClientStringFactory.GetString(307, ClientSettingsEnvironment.CurrentLanguage);

        int_SelectedItemIndex = this.comboBox_SingleImageCapture_ImageFormat.SelectedIndex;

        this.comboBox_SingleImageCapture_ImageFormat.Items.Clear();
        this.comboBox_SingleImageCapture_ImageFormat.Text = ClientStringFactory.GetString(241, ClientSettingsEnvironment.CurrentLanguage);
        this.comboBox_SingleImageCapture_ImageFormat.Items.AddRange(new object[] {
																					 ClientStringFactory.GetString(240, ClientSettingsEnvironment.CurrentLanguage),
																					 ClientStringFactory.GetString(241, ClientSettingsEnvironment.CurrentLanguage),
																					 ClientStringFactory.GetString(242, ClientSettingsEnvironment.CurrentLanguage),
																					 ClientStringFactory.GetString(243, ClientSettingsEnvironment.CurrentLanguage),
																					 ClientStringFactory.GetString(319, ClientSettingsEnvironment.CurrentLanguage)});

        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 0;

        this.comboBox_SingleImageCapture_ImageFormat.SelectedIndex = int_SelectedItemIndex;

        this.groupBox_SingleImageCapture.Text = ClientStringFactory.GetString(280, ClientSettingsEnvironment.CurrentLanguage);
        /////////////////////////////////////
        this.groupBox_CaptureInInterval.Text = ClientStringFactory.GetString(325, ClientSettingsEnvironment.CurrentLanguage);

        this.label_CaptureInInterval_InetrvalSettings.Text = ClientStringFactory.GetString(326, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CaptureInInterval_ImageFormat.Text = ClientStringFactory.GetString(184, ClientSettingsEnvironment.CurrentLanguage);
        this.button_CaptureInInterval_StartCapture.Text = ClientStringFactory.GetString(327, ClientSettingsEnvironment.CurrentLanguage);
        this.button_CaptureInInterval_StopCapture.Text = ClientStringFactory.GetString(328, ClientSettingsEnvironment.CurrentLanguage);

        int_SelectedItemIndex = this.comboBox_CaptureInInterval_ImageFormat.SelectedIndex;

        this.comboBox_CaptureInInterval_ImageFormat.Items.Clear();
        this.comboBox_CaptureInInterval_ImageFormat.Items.AddRange(new object[] {
																					ClientStringFactory.GetString(240, ClientSettingsEnvironment.CurrentLanguage),
																					ClientStringFactory.GetString(241, ClientSettingsEnvironment.CurrentLanguage),
																					ClientStringFactory.GetString(242, ClientSettingsEnvironment.CurrentLanguage),
																					ClientStringFactory.GetString(243, ClientSettingsEnvironment.CurrentLanguage),
																					ClientStringFactory.GetString(319, ClientSettingsEnvironment.CurrentLanguage)});

        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 0;

        this.comboBox_CaptureInInterval_ImageFormat.Text = ClientStringFactory.GetString(241, ClientSettingsEnvironment.CurrentLanguage);

        this.comboBox_CaptureInInterval_ImageFormat.SelectedIndex = int_SelectedItemIndex;
        
        /////////////////////////////////

        int_SelectedItemIndex = this.comboBox_SingleImageCapture_CompressionFormat.SelectedIndex;

        this.comboBox_SingleImageCapture_CompressionFormat.Items.Clear();
        this.comboBox_SingleImageCapture_CompressionFormat.Items.AddRange(new object[] {  ClientStringFactory.GetString(520, ClientSettingsEnvironment.CurrentLanguage),
				                                                                            ClientStringFactory.GetString(517, ClientSettingsEnvironment.CurrentLanguage)});
        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 0;

        this.comboBox_SingleImageCapture_CompressionFormat.SelectedIndex = int_SelectedItemIndex;
    
        /////////////////////////////////

        int_SelectedItemIndex = this.comboBox_CaptureInInterval_CompressionFormat.SelectedIndex;

        this.comboBox_CaptureInInterval_CompressionFormat.Items.Clear();
        this.comboBox_CaptureInInterval_CompressionFormat.Items.AddRange(new object[] {  ClientStringFactory.GetString(520, ClientSettingsEnvironment.CurrentLanguage),
				                                                                            ClientStringFactory.GetString(517, ClientSettingsEnvironment.CurrentLanguage)});
        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 0;

        this.comboBox_CaptureInInterval_CompressionFormat.SelectedIndex = int_SelectedItemIndex;

        #endregion

        #region Drives Manager

        this.tabPage_DrivesManager.Text = ClientStringFactory.GetString(189, ClientSettingsEnvironment.CurrentLanguage);
        this.button_DrivesManager_EjectCD.Text = ClientStringFactory.GetString(190, ClientSettingsEnvironment.CurrentLanguage);
        this.button_DrivesManager_CloseCD.Text = ClientStringFactory.GetString(191, ClientSettingsEnvironment.CurrentLanguage);

        this.label_DrivesManager_AvailableInformation.Text = ClientStringFactory.GetString(281, ClientSettingsEnvironment.CurrentLanguage);

        this.columnHeader_DrivesManager_DriveLetter.Text = ClientStringFactory.GetString(282, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_DrivesManager_DriveType.Text = ClientStringFactory.GetString(283, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_DrivesManager_TotalSpace.Text = ClientStringFactory.GetString(284, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_DrivesManager_FreeSpace.Text = ClientStringFactory.GetString(285, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_DrivesManager_FileSystem.Text = ClientStringFactory.GetString(286, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_DrivesManager_FileSystem_SerialNumber.Text = ClientStringFactory.GetString(287, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_DrivesManager_FileSystem_VolumeName.Text = ClientStringFactory.GetString(288, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_DrivesManager_FileSystem_maximumFileNameLength.Text = ClientStringFactory.GetString(289, ClientSettingsEnvironment.CurrentLanguage);

        this.columnHeader_DrivesManager_AvailableDrives.Text = ClientStringFactory.GetString(290, ClientSettingsEnvironment.CurrentLanguage);

        #endregion

        #region Statistics Status Line

        this.SetStatistic_BytesReceived = this.SetStatistic_BytesReceived;
        this.SetStatistic_BytesSent = this.SetStatistic_BytesSent;
        this.SetStatistic_CompletedTasks = this.SetStatistic_CompletedTasks;
        this.SetStatistic_ConnectedAt = this.SetStatistic_ConnectedAt;

        #endregion

        #region Menu Items

        this.menuItem_File.Text = ClientStringFactory.GetString(200, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_File_Exit.Text = ClientStringFactory.GetString(201, ClientSettingsEnvironment.CurrentLanguage);

        this.menuItem_File_Import.Text = ClientStringFactory.GetString(533, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_File_Import_SettingsDatabase.Text = ClientStringFactory.GetString(535, ClientSettingsEnvironment.CurrentLanguage);

        this.menuItem_File_Export.Text = ClientStringFactory.GetString(534, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_File_Export_SettingsDatabase.Text = ClientStringFactory.GetString(535, ClientSettingsEnvironment.CurrentLanguage);

        this.menuItem_Options.Text = ClientStringFactory.GetString(238, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_Options_Settings.Text = ClientStringFactory.GetString(239, ClientSettingsEnvironment.CurrentLanguage);

        this.menuItem_Help.Text = ClientStringFactory.GetString(202, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_Help_About.Text = ClientStringFactory.GetString(203, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_Help_Register.Text = ClientStringFactory.GetString(329, ClientSettingsEnvironment.CurrentLanguage);

        this.menuItem_Properties.Text = ClientStringFactory.GetString(436, ClientSettingsEnvironment.CurrentLanguage);

        this.menuItem_UploadFiles.Text = ClientStringFactory.GetString(358, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_UploadFolders.Text = ClientStringFactory.GetString(359, ClientSettingsEnvironment.CurrentLanguage);

        #endregion

        #region Remote Execution Tab



        #endregion

        #region RTDV Tab

        this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer.Text = ClientStringFactory.GetString(291, ClientSettingsEnvironment.CurrentLanguage);

        this.checkBox_RTDV_RealSize.Text = ClientStringFactory.GetString(308, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_RTDV_AllowControl.Text = ClientStringFactory.GetString(310, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RTDV_MaxUpdatePerSec.Text = ClientStringFactory.GetString(309, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_RTDV_HideMyCursor.Text = ClientStringFactory.GetString(556, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_RTDV_ShowRemoteCursor.Text = ClientStringFactory.GetString(557, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RTDV_DataFormat.Text = ClientStringFactory.GetString(665, ClientSettingsEnvironment.CurrentLanguage);

        this.label_RTDV_ReceivedImageSize.Text = ClientStringFactory.GetString(349, ClientSettingsEnvironment.CurrentLanguage);
        this.trackBar_RTDV_ReceivedImageSize.Value = 5;

        this.label_RTDV_MoreBandwidth.Text = ClientStringFactory.GetString(559, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RTDV_MoreCPUUsage.Text = ClientStringFactory.GetString(560, ClientSettingsEnvironment.CurrentLanguage);

        this.label_RTDV_SizeMode.Text = ClientStringFactory.GetString(351, ClientSettingsEnvironment.CurrentLanguage);

        int_SelectedItemIndex = this.comboBox_RTDV_SizeMode.SelectedIndex;

        this.comboBox_RTDV_SizeMode.Items.Clear();
        this.comboBox_RTDV_SizeMode.Items.AddRange(new object[] {
																	ClientStringFactory.GetString(352, ClientSettingsEnvironment.CurrentLanguage),
																	ClientStringFactory.GetString(353, ClientSettingsEnvironment.CurrentLanguage),
		});

        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 0;

        this.comboBox_RTDV_SizeMode.SelectedIndex = int_SelectedItemIndex;

        this.label_RTDV_NumberOfRegions.Text = ClientStringFactory.GetString(668, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_RTDV_AdditionalParameters.Text = ClientStringFactory.GetString(350, ClientSettingsEnvironment.CurrentLanguage);

        this.button_RTDV_GetRemoteClipboardData.Text = ClientStringFactory.GetString(355, ClientSettingsEnvironment.CurrentLanguage);
        this.button_RTDV_SetRemoteClipboardData.Text = ClientStringFactory.GetString(356, ClientSettingsEnvironment.CurrentLanguage);


        this.button_RTDV_SendKeys.Text = ClientStringFactory.GetString(441, ClientSettingsEnvironment.CurrentLanguage);

        this.comboBox_RTDV_SizeMode.SelectedIndex = 1;

        #endregion

        #region Installed Programs

        this.tabPage_InstalledPrograms.Text = ClientStringFactory.GetString(553, ClientSettingsEnvironment.CurrentLanguage);

        this.listView_InstalledPrograms_ProgramsList.Columns[0].Text = ClientStringFactory.GetString(549, ClientSettingsEnvironment.CurrentLanguage);
        this.listView_InstalledPrograms_ProgramsList.Columns[1].Text = ClientStringFactory.GetString(550, ClientSettingsEnvironment.CurrentLanguage);
        this.listView_InstalledPrograms_ProgramsList.Columns[2].Text = ClientStringFactory.GetString(551, ClientSettingsEnvironment.CurrentLanguage);
        this.listView_InstalledPrograms_ProgramsList.Columns[3].Text = ClientStringFactory.GetString(19, ClientSettingsEnvironment.CurrentLanguage);
        this.listView_InstalledPrograms_ProgramsList.Columns[4].Text = ClientStringFactory.GetString(552, ClientSettingsEnvironment.CurrentLanguage);

        this.tabPage_InstalledUpdates.Text = ClientStringFactory.GetString(565, ClientSettingsEnvironment.CurrentLanguage);

        this.listView_InstalledUpdates_UpdatesList.Columns[0].Text = ClientStringFactory.GetString(566, ClientSettingsEnvironment.CurrentLanguage);
        this.listView_InstalledUpdates_UpdatesList.Columns[1].Text = ClientStringFactory.GetString(567, ClientSettingsEnvironment.CurrentLanguage);
        this.listView_InstalledUpdates_UpdatesList.Columns[2].Text = ClientStringFactory.GetString(568, ClientSettingsEnvironment.CurrentLanguage);

        #endregion

        #region Remote System Information

        this.tabPage_RemoteSystemInformation.Text = ClientStringFactory.GetString(648, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RemoteSystemInformation_AvailableInformation_AvailableInformation.Text = ClientStringFactory.GetString(658, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RemoteSystemInformation_AvailableInformation_CurrentItem.Text = ClientStringFactory.GetString(652, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RemoteSystemInformation_AvailableItems_AvailableItems.Text = ClientStringFactory.GetString(653, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RemoteSystemInformation_AvailableItems_CurrentStatus.Text = ClientStringFactory.GetString(649, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_RemoteSystemInformation_AvailableInformation.Text = ClientStringFactory.GetString(656, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_RemoteSystemInformation_AvailableItems.Text = ClientStringFactory.GetString(657, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_RemoteSystemInformation_Parameter.Text = ClientStringFactory.GetString(650, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_RemoteSystemInformation_Value.Text = ClientStringFactory.GetString(651, ClientSettingsEnvironment.CurrentLanguage);

        #endregion

        #region Remote Registry

        this.tabPage_RemoteRegistry.Text = ClientStringFactory.GetString(577, ClientSettingsEnvironment.CurrentLanguage);

        this.label_RemoteRegistry_CurrentPath.Text = ClientStringFactory.GetString(571, ClientSettingsEnvironment.CurrentLanguage);

        this.listView_RemoteRegistry_Values.Columns[0].Text = ClientStringFactory.GetString(135, ClientSettingsEnvironment.CurrentLanguage);
        this.listView_RemoteRegistry_Values.Columns[1].Text = ClientStringFactory.GetString(587, ClientSettingsEnvironment.CurrentLanguage);
        this.listView_RemoteRegistry_Values.Columns[2].Text = ClientStringFactory.GetString(582, ClientSettingsEnvironment.CurrentLanguage);

        if (this.treeView_RemoteRegistry_NodesTree.SelectedNode != null)
        {
            if (this.treeView_RemoteRegistry_NodesTree.SelectedNode.IsExpanded)
            {
                this.button_RemoteRegistry_Expand.Text = ClientStringFactory.GetString(583, ClientSettingsEnvironment.CurrentLanguage);
            }
            else this.button_RemoteRegistry_Expand.Text = ClientStringFactory.GetString(584, ClientSettingsEnvironment.CurrentLanguage);
        }

        this.button_RemoteRegistry_CreateKey.Text = ClientStringFactory.GetString(585, ClientSettingsEnvironment.CurrentLanguage);
        this.button_RemoteRegistry_CreateValue.Text = ClientStringFactory.GetString(586, ClientSettingsEnvironment.CurrentLanguage);
        this.button_RemoteRegistry_Delete.Text = ClientStringFactory.GetString(11, ClientSettingsEnvironment.CurrentLanguage);
        this.button_RemoteRegistry_RenameItem.Text = ClientStringFactory.GetString(86, ClientSettingsEnvironment.CurrentLanguage);
        this.button_RemoteRegistry_Modify.Text = ClientStringFactory.GetString(575, ClientSettingsEnvironment.CurrentLanguage);
        this.button_RemoteRegistry_Expand.Text = ClientStringFactory.GetString(583, ClientSettingsEnvironment.CurrentLanguage);

        this.menuItem_RemoteRegistry_NewValue_DWORD.Text = ClientStringFactory.GetString(600, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_RemoteRegistry_NewValue_String.Text = ClientStringFactory.GetString(579, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_RemoteRegistry_NewValue_MultiString.Text = ClientStringFactory.GetString(580, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_RemoteRegistry_NewValue_Binary.Text = ClientStringFactory.GetString(599, ClientSettingsEnvironment.CurrentLanguage);

        this.menuItem_RemoteRegistry_NewItem.Text = ClientStringFactory.GetString(597, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_RemoteRegistry_NewItem_Key.Text = ClientStringFactory.GetString(598, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_RemoteRegistry_NewItem_MultiString.Text = ClientStringFactory.GetString(580, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_RemoteRegistry_NewItem_String.Text = ClientStringFactory.GetString(579, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_RemoteRegistry_NewItem_DWORD.Text = ClientStringFactory.GetString(600, ClientSettingsEnvironment.CurrentLanguage);

        this.menuItem_RemoteRegistry_DeleteKey.Text = ClientStringFactory.GetString(11, ClientSettingsEnvironment.CurrentLanguage);

        this.menuItem_RemoteRegistry_CopyKeyName.Text = ClientStringFactory.GetString(601, ClientSettingsEnvironment.CurrentLanguage);

        this.menuItem_RemoteRegistryValuesContextMenu_NewItem.Text = ClientStringFactory.GetString(597, ClientSettingsEnvironment.CurrentLanguage);

        this.menuItem_RemoteRegistryValuesContextMenu_New_Key.Text = ClientStringFactory.GetString(598, ClientSettingsEnvironment.CurrentLanguage);

        this.menuItem_RemoteRegistryValuesContextMenu_New_String.Text = ClientStringFactory.GetString(579, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_RemoteRegistryValuesContextMenu_New_MultiString.Text = ClientStringFactory.GetString(580, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_RemoteRegistryValuesContextMenu_New_DWORD.Text = ClientStringFactory.GetString(600, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_RemoteRegistryValuesContextMenu_New_Binary.Text = ClientStringFactory.GetString(599, ClientSettingsEnvironment.CurrentLanguage);

        this.menuItem_RemoteRegistryValueActions_Modify.Text = ClientStringFactory.GetString(575, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_RemoteRegistryValueActions_Delete.Text = ClientStringFactory.GetString(11, ClientSettingsEnvironment.CurrentLanguage);
        this.menuItem_RemoteRegistryValueActions_Rename.Text = ClientStringFactory.GetString(86, ClientSettingsEnvironment.CurrentLanguage);

        #endregion

        #region Clipboard Manager

        this.tabPage_ClipboardManager.Text = ClientStringFactory.GetString(681, ClientSettingsEnvironment.CurrentLanguage);

        this.button_ClipboardManager_ClearLocalClipboard.Text = ClientStringFactory.GetString(682, ClientSettingsEnvironment.CurrentLanguage);

        this.button_ClipboardManager_ClearRemoteClipboard.Text = ClientStringFactory.GetString(683, ClientSettingsEnvironment.CurrentLanguage);

        this.button_ClipboardManager_PreviewRemoteClipboard.Text = ClientStringFactory.GetString(684, ClientSettingsEnvironment.CurrentLanguage);

        this.button_ClipboardManager_PreviewLocalClipboard.Text = ClientStringFactory.GetString(685, ClientSettingsEnvironment.CurrentLanguage);

        this.checkBox_ClipboardManager_ShowWarnings.Text = ClientStringFactory.GetString(686, ClientSettingsEnvironment.CurrentLanguage);

        this.button_RemoteClipboardImageEnv_SendImage.Text = ClientStringFactory.GetString(687, ClientSettingsEnvironment.CurrentLanguage);

        this.button_RemoteClipboardImageEnv_SaveImageToDisk.Text = ClientStringFactory.GetString(688, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_ClipboardManager_ClipboardImageSettings.Text = ClientStringFactory.GetString(689, ClientSettingsEnvironment.CurrentLanguage);

        this.label_RemoteClipboardImageSettings_ImageFormat.Text = ClientStringFactory.GetString(184, ClientSettingsEnvironment.CurrentLanguage);

        this.label_RemoteClipboardImageSettings_ImageQuality.Text = ClientStringFactory.GetString(518, ClientSettingsEnvironment.CurrentLanguage);

        this.label_RemoteClipboardImageSettings_CompressionFormat.Text = ClientStringFactory.GetString(519, ClientSettingsEnvironment.CurrentLanguage);

        this.label_RemoteClipboardImageSettings_PreviewSizeMode.Text = ClientStringFactory.GetString(690, ClientSettingsEnvironment.CurrentLanguage);

        this.button_ClipboardManager_RefreshClipboardsTypeInfo.Text = ClientStringFactory.GetString(691, ClientSettingsEnvironment.CurrentLanguage);

        this.label_ClipboardManager_RefreshClipboardsTypeInfoInterval.Text = ClientStringFactory.GetString(692, ClientSettingsEnvironment.CurrentLanguage);

        this.button_ClipboardManager_Remote2LocalSync.Text = ClientStringFactory.GetString(693, ClientSettingsEnvironment.CurrentLanguage);

        this.button_ClipboardManager_Local2RemoteSync.Text = ClientStringFactory.GetString(694, ClientSettingsEnvironment.CurrentLanguage);

        this.label_ClipboardManager_LocalClipboardType.Text = ClientStringFactory.GetString(695, ClientSettingsEnvironment.CurrentLanguage);

        this.label_ClipboardManager_RemoteClipboardType.Text = ClientStringFactory.GetString(696, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_ClipboardManager_TextData.Text = ClientStringFactory.GetString(697, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_ClipboardManager_FileDropList.Text = ClientStringFactory.GetString(698, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_ClipboardManager_Image.Text = ClientStringFactory.GetString(699, ClientSettingsEnvironment.CurrentLanguage);

        this.listView_ClipboardManager_FileDropList.Columns[0].Text = ClientStringFactory.GetString(700, ClientSettingsEnvironment.CurrentLanguage);


        int_SelectedItemIndex = this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval.SelectedIndex;

        this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval.Items.Clear();

        this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval.Items.AddRange(new object[] {
																					 ClientStringFactory.GetString(52, ClientSettingsEnvironment.CurrentLanguage),
																					 "5",
																					 "10",
																					 "15",
																					 "20",
                                                                                     "25",
																					 "30"});

        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 1;

        this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval.SelectedIndex = int_SelectedItemIndex;

        ///////////////////////////////////////////////

        int_SelectedItemIndex = this.comboBox_RemoteClipboardImageSettings_ImageFormat.SelectedIndex;

        this.comboBox_RemoteClipboardImageSettings_ImageFormat.Items.Clear();
        this.comboBox_RemoteClipboardImageSettings_ImageFormat.Text = ClientStringFactory.GetString(241, ClientSettingsEnvironment.CurrentLanguage);
        this.comboBox_RemoteClipboardImageSettings_ImageFormat.Items.AddRange(new object[] {
																					 ClientStringFactory.GetString(240, ClientSettingsEnvironment.CurrentLanguage),
																					 ClientStringFactory.GetString(241, ClientSettingsEnvironment.CurrentLanguage),
																					 ClientStringFactory.GetString(242, ClientSettingsEnvironment.CurrentLanguage),
																					 ClientStringFactory.GetString(243, ClientSettingsEnvironment.CurrentLanguage),
																					 ClientStringFactory.GetString(319, ClientSettingsEnvironment.CurrentLanguage)});

        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 2;

        this.comboBox_RemoteClipboardImageSettings_ImageFormat.SelectedIndex = int_SelectedItemIndex;

        ///////////////////////////////////////

        int_SelectedItemIndex = this.comboBox_RemoteClipboardImageSettings_CompressionFormat.SelectedIndex;

        this.comboBox_RemoteClipboardImageSettings_CompressionFormat.Items.Clear();
        this.comboBox_RemoteClipboardImageSettings_CompressionFormat.Items.AddRange(new object[] {  ClientStringFactory.GetString(520, ClientSettingsEnvironment.CurrentLanguage),
																						            ClientStringFactory.GetString(517, ClientSettingsEnvironment.CurrentLanguage)});

        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 1;

        this.comboBox_RemoteClipboardImageSettings_CompressionFormat.SelectedIndex = int_SelectedItemIndex;
      
        ////////////////

        int_SelectedItemIndex = this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode.SelectedIndex;

        this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode.Items.Clear();
        this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode.Items.AddRange(new object[] {  ClientStringFactory.GetString(352, ClientSettingsEnvironment.CurrentLanguage),
                                                                                                    ClientStringFactory.GetString(353, ClientSettingsEnvironment.CurrentLanguage),
																						            ClientStringFactory.GetString(675, ClientSettingsEnvironment.CurrentLanguage)});

        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 1;

        this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode.SelectedIndex = int_SelectedItemIndex;

        #endregion

        this.EnableToolTips();
        
        this.AddPresetsToFastLaunch();
    }
    
    #endregion

    #region Main Network Methods

    private void button_NetworkControl_Connect_Click(object sender, System.EventArgs e)
    {
        if (MainTcpClient.IsConnected)
        {
            MessageBox.Show(ClientStringFactory.GetString(227, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK);

            return;
        }

        new Thread(new ThreadStart(ObjCopy.obj_NetworkAction.ConnectToServer)).Start();

        groupBox_NetworkControl_MainNetworkControl.Enabled = false;
        groupBox_NetworkControl_Security.Enabled = false;

        ConnetionStatus = ClientStringFactory.GetString(354, ClientSettingsEnvironment.CurrentLanguage);
    }
                  
    [DllImport("JsRctServerLib.dll")]
    private static extern string ResolveMACAddressFromIP(string string_IPAddress);
    public string RemotingWrapper_ResolveMACAddressFromIP(string string_IPAddress)
    {
        return ResolveMACAddressFromIP(string_IPAddress);
    }
    
    private void button_NetworkControl_Disconnect_Click(object sender, System.EventArgs e)
    {
        new Thread(new ThreadStart(ObjCopy.obj_NetworkAction.DisconnectFromServer)).Start();
        
        ObjCopy.obj_NetworkAction.DisconnectFromCSP(ref NetworkAction.connectedCSPClient_obj);
    }

    #endregion

    #region Proxy Servers List

    public void RemoveProxyServerFromListView(int int_ProxyServerIndex)
    {
        int int_DeletedTagIndex = (int)this.listView_ProxyServersList_ProxyServersList.Items[int_ProxyServerIndex].Tag;

        foreach (ListViewItem listViewItem_obj in this.listView_ProxyServersList_ProxyServersList.Items)
        {
            if ((int)listViewItem_obj.Tag > int_DeletedTagIndex)
            {
                listViewItem_obj.Tag = (int)listViewItem_obj.Tag - 1;
            }
        }

        this.listView_ProxyServersList_ProxyServersList.Items.RemoveAt(int_ProxyServerIndex);
    }

    private void ApplySelectedProxyServerFromList()
    {
        if (this.listView_ProxyServersList_ProxyServersList.SelectedItems.Count == 0) return;

        int int_SelectedProxyServerRowIndex = (int)this.listView_ProxyServersList_ProxyServersList.SelectedItems[0].Tag;

        if (JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows.Count < 2 ||
            JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows.Count < int_SelectedProxyServerRowIndex + 2)
        {
            return;
        }

        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings;

        this.UseProxyServer = true;

        this.ProxyHost = (string)ProxyServersSettingsDataTable_obj.Rows[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyHostColumn];
        this.ProxyPort = (int)ProxyServersSettingsDataTable_obj.Rows[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyPortColumn];
        this.ProxyTimeOut = (int)ProxyServersSettingsDataTable_obj.Rows[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyTimeOutColumn];

        this.ProxyTypeIndex = (int)ProxyServersSettingsDataTable_obj.Rows[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyTypeColumn];
        this.ProxyTimeOut = (int)ProxyServersSettingsDataTable_obj.Rows[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyTimeOutColumn];
        this.UseProxyResolveHostNames = (bool)ProxyServersSettingsDataTable_obj.Rows[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.UseProxyToResolveHostNamesColumn];
        this.UseSocks5Authentication = (bool)ProxyServersSettingsDataTable_obj.Rows[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.UseAuthenticationColumn];

        this.Socks5UserName = (string)ProxyServersSettingsDataTable_obj.Rows[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.LoginColumn];
        this.Socks5Password = (string)ProxyServersSettingsDataTable_obj.Rows[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.PasswordColumn];

    }

    private void listView_ProxyServersList_ProxyServersList_DoubleClick(object sender, System.EventArgs e)
    {
        ApplySelectedProxyServerFromList();
    }

    private void button_ProxyServersList_AddRecord_Click(object sender, System.EventArgs e)
    {
        ProxyDBManagerForm proxyDBManagerForm_obj = new ProxyDBManagerForm();

        proxyDBManagerForm_obj.ApplyButton.Visible = false;

        proxyDBManagerForm_obj.ShowDialog();
    }

    private void button_ProxyServersList_Use_Click(object sender, System.EventArgs e)
    {
        ApplySelectedProxyServerFromList();
    }

    private void button_ProxyServersList_RemoveRecord_Click(object sender, System.EventArgs e)
    {
        if (this.listView_ProxyServersList_ProxyServersList.SelectedItems.Count == 0) return;

        if (MessageBox.Show(ClientStringFactory.GetString(488, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        new JurikSoft.XMLConfigImporer.JSClientDBEnvironment().RemoveProxyServerRecord((int)this.listView_ProxyServersList_ProxyServersList.SelectedItems[0].Tag + 1);

        int int_SelectedProxyServerRowIndex = this.listView_ProxyServersList_ProxyServersList.SelectedItems[0].Index;

        this.RemoveProxyServerFromListView(int_SelectedProxyServerRowIndex);
    }

    private void button_ProxyServersList_ClearList_Click(object sender, System.EventArgs e)
    {
        if (this.listView_ProxyServersList_ProxyServersList.Items.Count == 0 ||
            DialogResult.Yes != MessageBox.Show(ClientStringFactory.GetString(489, ClientSettingsEnvironment.CurrentLanguage),
            ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            return;
        }

        for (int int_CycleCount = 1; int_CycleCount != JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows.Count; )
        {
            new JurikSoft.XMLConfigImporer.JSClientDBEnvironment().RemoveProxyServerRecord(int_CycleCount);
        }

        this.listView_ProxyServersList_ProxyServersList.Items.Clear();
    }

    private void button_ProxyServersList_EditRecord_Click(object sender, System.EventArgs e)
    {
        if (this.listView_ProxyServersList_ProxyServersList.SelectedItems.Count == 0) return;

        int int_SelectedProxyServerRowIndex = (int)this.listView_ProxyServersList_ProxyServersList.SelectedItems[0].Tag;

        UserAccountsAndAccessRestrictionRulesEnvironment.EditSelectedProxyServerInfo(int_SelectedProxyServerRowIndex);

    }

    private void button_ProxyServersList_ViewRecord_Click(object sender, System.EventArgs e)
    {
        if (this.listView_ProxyServersList_ProxyServersList.SelectedItems.Count == 0) return;

        UserAccountsAndAccessRestrictionRulesEnvironment.ViewSelectedProxyServerInfo((int)this.listView_ProxyServersList_ProxyServersList.SelectedItems[0].Tag);
    }

    public void FillProxyServersList()
    {
        ListViewItem[] listViewItemArray_ProxyServer = new JurikSoft.XMLConfigImporer.JSClientDBEnvironment().GetProxyServersList();

        if (listViewItemArray_ProxyServer != null)
        {
            this.listView_ProxyServersList_ProxyServersList.Items.Clear();

            this.listView_ProxyServersList_ProxyServersList.Items.AddRange(listViewItemArray_ProxyServer);
        }
    }


    public void RefreshProxyServersList()
    {
        this.listView_ProxyServersList_ProxyServersList.Items.Clear();

        FillProxyServersList();
    }

    private void listBox_NetworkControl_ProxyType_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        bool bool_AuthEnabled = true;

        if (listBox_ProxySettings_ProxyType.SelectedIndex == 0) bool_AuthEnabled = false;

        this.label_ProxySettings_Socks5UserName.Enabled =
        this.label_ProxySettings_Socks5Password.Enabled =
        this.textBox_ProxySettings_Socks5UserName.Enabled =
        this.textBox_ProxySettings_Socks5Password.Enabled =
        this.checkBox_ProxySettings_Authentication.Enabled = bool_AuthEnabled;

        this.checkBox_ProxySettings_Authentication_CheckedChanged(null, null);
    }

    public void EditProxyServersListItem(int int_ItemIndex, string string_ProxyServerTitle, string string_ProxyServerHost, string string_ProxyServerPort)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_ProxyServersList_ProxyServersList.Items[int_ItemIndex].Text = string_ProxyServerTitle;

            this.listView_ProxyServersList_ProxyServersList.Items[int_ItemIndex].SubItems[1].Text = string_ProxyServerHost;

            this.listView_ProxyServersList_ProxyServersList.Items[int_ItemIndex].SubItems[2].Text = string_ProxyServerPort;
        });
    }



    #endregion

    #region Menu Items Environment

    private void menuItem_Options_Settings_Click(object sender, System.EventArgs e)
    {
        SettingsForm obj_SettingsForm = new SettingsForm();

        obj_SettingsForm.ShowDialog();

        obj_SettingsForm.Dispose();
    }

    private void menuItem_Help_Register_Click(object sender, System.EventArgs e)
    {
        RegistrationForm obj_RegistrationForm = new RegistrationForm();

        obj_RegistrationForm.ShowDialog();

        obj_RegistrationForm.Dispose();
    }

    private void menuItem_File_Exit_Click(object sender, System.EventArgs e)
    {
        ObjCopy.obj_MainClientForm.BringToFront();

        this.Close();
    }

    private void menuItem_Help_About_Click(object sender, System.EventArgs e)
    {
        new AboutForm().ShowDialog();
    }

    #endregion

    #region ToolTips Environment

    public void EnableToolTips()
    {
        this.toolTip.SetToolTip(this.button_FileManager_Refresh, ClientStringFactory.GetString(176, ClientSettingsEnvironment.CurrentLanguage));
        this.toolTip.SetToolTip(this.button_FileManager_DirUp, ClientStringFactory.GetString(89, ClientSettingsEnvironment.CurrentLanguage));
        this.toolTip.SetToolTip(this.button_ProcessesManager_Refresh, ClientStringFactory.GetString(116, ClientSettingsEnvironment.CurrentLanguage));
        this.toolTip.SetToolTip(this.button_SystemEvents_Refresh, ClientStringFactory.GetString(132, ClientSettingsEnvironment.CurrentLanguage));
        this.toolTip.SetToolTip(this.button_ServicesManager_StopService, ClientStringFactory.GetString(138, ClientSettingsEnvironment.CurrentLanguage));
        this.toolTip.SetToolTip(this.button_ServicesManager_PauseService, ClientStringFactory.GetString(139, ClientSettingsEnvironment.CurrentLanguage));
        this.toolTip.SetToolTip(this.button_ServicesManager_StartService, ClientStringFactory.GetString(140, ClientSettingsEnvironment.CurrentLanguage));
        this.toolTip.SetToolTip(this.button_ServicesManager_Refresh, ClientStringFactory.GetString(143, ClientSettingsEnvironment.CurrentLanguage));
        this.toolTip.SetToolTip(this.button_DriversList_Refresh, ClientStringFactory.GetString(145, ClientSettingsEnvironment.CurrentLanguage));
        this.toolTip.SetToolTip(this.button_RemoteExecution_CleanParameters, ClientStringFactory.GetString(447, ClientSettingsEnvironment.CurrentLanguage));
        this.toolTip.SetToolTip(this.button_DrivesManager_Refresh, ClientStringFactory.GetString(474, ClientSettingsEnvironment.CurrentLanguage));
        this.toolTip.SetToolTip(this.button_InstalledPrograms_Refresh, ClientStringFactory.GetString(569, ClientSettingsEnvironment.CurrentLanguage));
        this.toolTip.SetToolTip(this.button_InstalledUpdates_Refresh, ClientStringFactory.GetString(570, ClientSettingsEnvironment.CurrentLanguage));
        this.toolTip.SetToolTip(this.button_RemoteSystemInformation_AvailableInformation_Refresh, ClientStringFactory.GetString(655, ClientSettingsEnvironment.CurrentLanguage));
        this.toolTip.SetToolTip(this.button_RemoteSystemInformation_AvailableItems_Refresh, ClientStringFactory.GetString(654, ClientSettingsEnvironment.CurrentLanguage));
        //	this.toolTip.SetToolTip(this.button_ServersList_Refresh, ClientStringFactory.GetString(661, ClientSettingsEnvironment.CurrentLanguage));

    }

    public void DisableToolTips()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.toolTip.RemoveAll();
        });
    }


    #endregion

    #region DataBase Environment

    public void WriteClientSettingsToDB()
    {

        ClientSettingsEnvironment.LoginForConnection = this.LoginForConnection;
        ClientSettingsEnvironment.PasswordForConnection = this.PasswordForConnection;

        ClientSettingsEnvironment.ServerHost = this.ServerHost;
        ClientSettingsEnvironment.ServerPort = this.ServerPort;

        ClientSettingsEnvironment.ProxyServerHost = this.ProxyHost;
        ClientSettingsEnvironment.ProxyServerPort = this.ProxyPort;

        ClientSettingsEnvironment.ProxyServerTimeOut = this.ProxyTimeOut;
        ClientSettingsEnvironment.ProxyServerType = this.ProxyTypeIndex;

        ClientSettingsEnvironment.UseProxyToResolveHostNames = this.UseProxyResolveHostNames;
        ClientSettingsEnvironment.UseProxyServer = this.UseProxyServer;

        ClientSettingsEnvironment.UseProxyAuthentication = this.UseSocks5Authentication;
        ClientSettingsEnvironment.ProxyLogin = this.Socks5UserName;
        ClientSettingsEnvironment.ProxyPassword = this.Socks5Password;

        new JurikSoft.XMLConfigImporer.JSClientDBEnvironment().WriteClientSettingsData(Application.StartupPath + "\\JurikSoftClientDB");
    }


    public void FillJurikSoftServersList()
    {
        ListViewItem[] listViewItemArray_ServersList = new JurikSoft.XMLConfigImporer.JSClientDBEnvironment().GetJurikSoftServersList();

        if (listViewItemArray_ServersList != null)
        {
            this.listView_ServersList_ServersList.Items.Clear();

            this.listView_ServersList_ServersList.Items.AddRange(listViewItemArray_ServersList);
        }
    }

    public void FillJurikSoftServersList(int int_GroupID)
    {
        ListViewItem[] listViewItemArray_ServersList = new JurikSoft.XMLConfigImporer.JSClientDBEnvironment().GetJurikSoftServersList(int_GroupID);

        if (listViewItemArray_ServersList != null)
        {
            this.listView_ServersList_ServersList.Items.Clear();

            this.listView_ServersList_ServersList.Items.AddRange(listViewItemArray_ServersList);
        }
    }



    public void FillJurikSoftServersGroups()
    {
        this.comboBox_ServersList_ServersGroups.Items.Clear();

        this.comboBox_ServersList_ServersGroups.Items.AddRange(new JurikSoft.XMLConfigImporer.JSClientDBEnvironment().GetJurikSoftServersGroups());
    }


    public void SetUpClientSettingsFromDB()
    {
        FillProxyServersList();

        FillJurikSoftServersList();

        this.Invoke((MethodInvoker)delegate
        {
            this.ServerPort = ClientSettingsEnvironment.ServerPort;
            this.ServerHost = ClientSettingsEnvironment.ServerHost;

            this.LoginForConnection = ClientSettingsEnvironment.LoginForConnection;
            this.PasswordForConnection = ClientSettingsEnvironment.PasswordForConnection;

            this.UseProxyServer = ClientSettingsEnvironment.UseProxyServer;

            this.ProxyHost = ClientSettingsEnvironment.ProxyServerHost;
            this.ProxyPort = ClientSettingsEnvironment.ProxyServerPort;

            this.ProxyTimeOut = ClientSettingsEnvironment.ProxyServerTimeOut;
            this.ProxyTypeIndex = ClientSettingsEnvironment.ProxyServerType;

            this.UseProxyResolveHostNames = ClientSettingsEnvironment.UseProxyToResolveHostNames;

            this.UseSocks5Authentication = ClientSettingsEnvironment.UseProxyAuthentication;
            this.Socks5UserName = ClientSettingsEnvironment.ProxyLogin;
            this.Socks5Password = ClientSettingsEnvironment.ProxyPassword;

            this.LoginForConnection = ClientSettingsEnvironment.LoginForConnection;
            this.PasswordForConnection = ClientSettingsEnvironment.PasswordForConnection;

            this.comboBox_ServersList_ServersGroups.Items.Clear();

            this.comboBox_ServersList_ServersGroups.Items.Add(ClientStringFactory.GetString(509, ClientSettingsEnvironment.CurrentLanguage));

            this.comboBox_ServersList_ServersGroups.SelectedIndex = 0; // OnChangeIndex calls GetJurikSoftServersList() !!!

            if (ClientSettingsEnvironment.ShowToolTips == false) this.DisableToolTips();

            new JurikSoft.XMLConfigImporer.JSClientDBEnvironment().GetJurikSoftServersGroups();

            new JurikSoft.XMLConfigImporer.JSClientDBEnvironment().GetProxyServersList();

            InitRegistryTreeViewState();

            this.comboBox_RTDV_AmountOfRegions.SelectedIndex = 1;
        });
    }


    private void menuItem_File_Import_SettingsDatabase_Click(object sender, System.EventArgs e)
    {
        OpenFileDialog openFileDialog_obj = new OpenFileDialog();

        openFileDialog_obj.Multiselect = false;

        openFileDialog_obj.Title = ClientStringFactory.GetString(544, ClientSettingsEnvironment.CurrentLanguage);

        if (openFileDialog_obj.ShowDialog() == DialogResult.OK)
        {
            JurikSoft.XMLConfigImporer.JSClientDBEnvironment.LoadXMLDataFile(openFileDialog_obj.FileName, true);

            SetUpClientSettingsFromDB();
        }
    }

    private void menuItem_File_Export_SettingsDatabase_Click(object sender, System.EventArgs e)
    {
        SaveFileDialog saveFileDialog_obj = new SaveFileDialog();

        saveFileDialog_obj.Title = ClientStringFactory.GetString(545, ClientSettingsEnvironment.CurrentLanguage);

        saveFileDialog_obj.FileName = "JurikSoftClientDB";

        if (saveFileDialog_obj.ShowDialog() == DialogResult.OK)
        {
            new JSClientDBEnvironment().WriteClientSettingsData(saveFileDialog_obj.FileName);
        }
    }


    #endregion

    #region Serial Number Verification Environment
    /*
    public int CheckSN(string string_FullName, string string_Key)
    {
        MD5CryptoServiceProvider MD5Object_Key = new MD5CryptoServiceProvider();

        byte[] byteArray_KeyHash = MD5Object_Key.ComputeHash(Encoding.Unicode.GetBytes(string_FullName));

        string string_CurrentNubmer = null;

        for (int int_CycleCount = 0; byteArray_KeyHash.Length != int_CycleCount; int_CycleCount++)
        {
            string_CurrentNubmer += (byteArray_KeyHash[int_CycleCount] * 8).ToString();
        }

        if (string_Key == string_CurrentNubmer.Substring(0, 10))
        {
            if (Registry.CurrentUser.OpenSubKey("Software\\JurikSoft", true) == null)
                Registry.CurrentUser.CreateSubKey("Software\\JurikSoft");

            Registry.CurrentUser.OpenSubKey("Software\\JurikSoft", true).SetValue("SN", string_Key);
            Registry.CurrentUser.OpenSubKey("Software\\JurikSoft", true).SetValue("Name", string_FullName);

            menuItem_Help_Register.Enabled = false;

            ClientSettingsEnvironment.ProductSerialNumber = string_Key;
            ClientSettingsEnvironment.ProductLicenceName = string_FullName;

            ClientSettingsEnvironment.IsProductRegistered = true;

            return 1;
        }

        return 0;
    }

    Thread thread_NGSCRThread;

    void NGSCRThread()
    {
        try
        {
            RegistrationForm registrationForm_obj = new RegistrationForm();

            thread_NGSCRThread = Thread.CurrentThread;

            if (Registry.CurrentUser.OpenSubKey("Software\\JurikSoft", true) != null
                && Registry.CurrentUser.OpenSubKey("Software\\JurikSoft", true).GetValue("SN") != null
                && Registry.CurrentUser.OpenSubKey("Software\\JurikSoft", true).GetValue("Name") != null)
            {
                string string_Key = Registry.CurrentUser.OpenSubKey("Software\\JurikSoft", true).GetValue("SN").ToString(),
                    string_FullName = Registry.CurrentUser.OpenSubKey("Software\\JurikSoft", true).GetValue("Name").ToString();

                if (CheckSN(string_FullName, string_Key) == 1) return;
            }

            Thread.Sleep(10000);

            for (; ClientSettingsEnvironment.IsProductRegistered != true; Thread.Sleep((2 * 60) * 1000))
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Enabled = false;

                    if (ClientSettingsEnvironment.IsProductRegistered == true)
                    {
                        this.Enabled = true;

                        return;
                    }

                    bool bool_IsMiniRTDVFormVisible = ObjCopy.obj_MiniRTDVForm.Visible;

                    ObjCopy.obj_MiniRTDVForm.Visible = false;

                    registrationForm_obj.ShowDialog(this);

                    System.Threading.Thread.Sleep(2000);

                    ObjCopy.obj_MiniRTDVForm.Visible = bool_IsMiniRTDVFormVisible;

                    this.Enabled = true;
                });
            }

            return;
        }

        catch
        {

        }
    }
    */
    #endregion


    #region JurikSoft Servers List Environment

    public void RefreshJurikSoftServersGroups()
    {
        this.Invoke((MethodInvoker)delegate
        {
            int int_GroupSelectedIndex = this.comboBox_ServersList_ServersGroups.SelectedIndex;

            this.comboBox_ServersList_ServersGroups.Items.Clear();

            this.comboBox_ServersList_ServersGroups.Items.Add(ClientStringFactory.GetString(509, ClientSettingsEnvironment.CurrentLanguage));

            ObjCopy.obj_MainClientForm.FillJurikSoftServersGroups();

            this.comboBox_ServersList_ServersGroups.SelectedIndex = 0;

            this.comboBox_ServersList_ServersGroups.SelectedIndex = int_GroupSelectedIndex;
        });
    }

    public void AddNewJurikSoftServersListItem(string string_JurikSoftServerTitle,
                                                string string_JurikSoftServerHost,
                                                string string_JurikSoftServerPort,
                                                string string_ServerLocation,
                                                string string_ServerGroup)
    {
        this.Invoke((MethodInvoker)delegate
        {
            ListViewItem listViewItem_JurikSoftServerItem = new ListViewItem(string_JurikSoftServerTitle);

            listViewItem_JurikSoftServerItem.ImageIndex = 0;

            listViewItem_JurikSoftServerItem.SubItems.Add(string_JurikSoftServerHost);
            listViewItem_JurikSoftServerItem.SubItems.Add(string_JurikSoftServerPort);
            listViewItem_JurikSoftServerItem.SubItems.Add(string_ServerLocation);
            listViewItem_JurikSoftServerItem.SubItems.Add(string_ServerGroup);

            listViewItem_JurikSoftServerItem.Tag = this.listView_ServersList_ServersList.Items.Count;

            this.listView_ServersList_ServersList.Items.Add(listViewItem_JurikSoftServerItem);
        });
    }

    public void EditSelectedJurikSoftServersListItem(string string_JurikSoftServerTitle,
        string string_JurikSoftServerHost, string string_JurikSoftServerPort,
        string string_ServerLocation, string string_ServerGroup)
    {
        this.Invoke((MethodInvoker)delegate
        {
            if (this.listView_ServersList_ServersList.SelectedItems.Count == 0) return;

            int int_ItemIndex = this.listView_ServersList_ServersList.SelectedItems[0].Index;

            this.listView_ServersList_ServersList.Items[int_ItemIndex].Text = string_JurikSoftServerTitle;

            this.listView_ServersList_ServersList.Items[int_ItemIndex].SubItems[1].Text = string_JurikSoftServerHost;
            this.listView_ServersList_ServersList.Items[int_ItemIndex].SubItems[2].Text = string_JurikSoftServerPort;
            this.listView_ServersList_ServersList.Items[int_ItemIndex].SubItems[3].Text = string_ServerLocation;
            this.listView_ServersList_ServersList.Items[int_ItemIndex].SubItems[4].Text = string_ServerGroup;
        });
    }

    public void AddNewJurikSoftServerGroup(string string_GroupName)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.comboBox_ServersList_ServersGroups.Items.Add(string_GroupName);
        });
    }

    public int GetJurikSoftServerRowIndexFromListIndex()
    {
        if (this.comboBox_ServersList_ServersGroups.SelectedIndex == 0)
        {
            return (int)this.listView_ServersList_ServersList.SelectedItems[0].Tag;
        }

        int int_JurikSoftServerIndex = (int)this.listView_ServersList_ServersList.SelectedItems[0].Tag,
            int_GroupIndex = this.comboBox_ServersList_ServersGroups.SelectedIndex - 1,
            int_CycleCount = 0;

        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersRow[] dataRowArray_JurikSoftServersRows = null;

        dataRowArray_JurikSoftServersRows = (DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersRow[])JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes.Rows[int_GroupIndex].GetChildRows("ServerGroupTypes_JurikSoftServerInfo");

        foreach (DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersRow currentRow in JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers)
        {
            if (currentRow == dataRowArray_JurikSoftServersRows[int_JurikSoftServerIndex])
            {
                return int_CycleCount;
            }

            int_CycleCount++;
        }

        return -1;
    }

    #endregion


    #region Add, Insert and Delete ListView items methods

    public void AddNewRegistryItem(ListViewItem[] listViewItemArray_RegistryValues)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_RemoteRegistry_Values.Items.AddRange(listViewItemArray_RegistryValues);
        });
    }

    public void AddSystemEventsManagerItem(ListViewItem[] listViewItemArray_SystemEvents)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_SystemEvents_Events.Items.AddRange(listViewItemArray_SystemEvents);
        });
    }

    public void AddServicesManagerItem(ListViewItem[] listViewItemArray_Services)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_ServicesManager_Services.Items.AddRange(listViewItemArray_Services);
        });
    }

    public void AddDriversManagerItem(ListViewItem[] listViewItemArray_Drivers)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_DriversList_DriversList.Items.AddRange(listViewItemArray_Drivers);
        });
    }

    public void AddProcessManagerItem(ListViewItem[] listViewItemArray_Process)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_ProcessesManager_Processes.Items.AddRange(listViewItemArray_Process);
        });
    }

    public void AddDrivesInformationViewItem(ListViewItem[] listViewItemArray_Drives)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_DrivesManager_DrivesInformation.Items.AddRange(listViewItemArray_Drives);
        });
    }

    public void AddInstalledProgramItem(ListViewItem[] listViewItemArray_Programs)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_InstalledPrograms_ProgramsList.Items.AddRange(listViewItemArray_Programs);
        });
    }

    public void AddInstalledUpdatesItem(ListViewItem[] listViewItemArray_Updates)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_InstalledUpdates_UpdatesList.Items.AddRange(listViewItemArray_Updates);
        });
    }


    public void InsertExistingDriveName(string string_ItemName, int int_NecessaryItemNumber)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.comboBox_FileManager_LogicalDrives.Items.Add(string_ItemName);
       
            this.listView_DrivesManager_AvailableDrives.Items.Add(new ListViewItem(string_ItemName.ToUpper(), int_NecessaryItemNumber));

        });
    }

    public void InsertExistingSystemLogName(string string_ItemName)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.comboBox_SystemEvents_Logs.Items.Add(string_ItemName);
        });
    }


    public void DeleteAllProcessViewData()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_ProcessesManager_Processes.Items.Clear();
        });
    }

    public void DeleteAllInstalledProgramsViewData()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_InstalledPrograms_ProgramsList.Items.Clear();
        });
    }

    public void DeleteAllInstalledUpdatesViewData()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_InstalledUpdates_UpdatesList.Items.Clear();
        });
    }

    public void DeleteAllServiceViewData()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_ServicesManager_Services.Items.Clear();
        });
    }

    public void DeleteAllSystemEventsViewData()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_SystemEvents_Events.Items.Clear();
        });
    }

    public void DeleteListOfExistingDrives()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.comboBox_FileManager_LogicalDrives.Items.Clear();
        });
    }

    public void DeleteListOfExistingSystemLogs()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.comboBox_SystemEvents_Logs.Items.Clear();
        });
    }

    public void DeleteAllDriverViewData()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_DriversList_DriversList.Items.Clear();
        });
    }

    public void DeleteAllDrivesInformationViewData()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_DrivesManager_DrivesInformation.Items.Clear();
        });
    }

    public void DeleteAllAvailableDrivesViewData()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_DrivesManager_AvailableDrives.Items.Clear();
        });
    }

    #endregion



    #region Remote System Information Tab Environment

    private void button_RemoteSystemInformation_AvailableInformation_Refresh_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            List<int> list_NodePath = new List<int>();

            TreeNode treeNode_CurrentNode = this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.SelectedNode;

            if (treeNode_CurrentNode == null)
            {
                MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(659, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            list_NodePath.Add(treeNode_CurrentNode.Index);

            for (; ; )
            {
                if (treeNode_CurrentNode.Parent == null || list_NodePath.Count == 0) break;

                treeNode_CurrentNode = treeNode_CurrentNode.Parent;

                list_NodePath.Insert(0, treeNode_CurrentNode.Index);
            }

            if (list_NodePath.Count < 2) return;

            if (!MainTcpClient.IsConnected)
            {
                return;
            }

            try
            {
                RemoteCallAction remoteCallAction_obj = new RemoteCallAction();

                remoteCallAction_obj.RemoteSystemInformationNodePath = new int[list_NodePath.Count];

                list_NodePath.CopyTo(remoteCallAction_obj.RemoteSystemInformationNodePath);

                remoteCallAction_obj.GetSelectedRemoteSystemInformationItemContent();

                RSIEnableAvailableItemsGroupBox = false;

                RSIStatus = ClientStringFactory.GetString(663, ClientSettingsEnvironment.CurrentLanguage);
            }

            catch
            {

            }
        }

        catch
        {

        }
    }

    private void button_RemoteSystemInformation_AvailableItems_Refresh_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            new Thread(new ThreadStart(obj_RemoteCallAction.GetRemoteSystemInformationRootItemsCollection)).Start();

            RSIEnableAvailableItemsGroupBox = false;

            RSIStatus = ClientStringFactory.GetString(663, ClientSettingsEnvironment.CurrentLanguage);
        }

        catch
        {

        }
    }

    private void button_RemoteSystemInformation_AvailableInformation_CopyItemInfoToClipboard_Click(object sender, EventArgs e)
    {
        ListView.ListViewItemCollection listViewItemCollection_obj = this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.Items;

        ListViewItem.ListViewSubItem listViewSubItem_obj = new ListViewItem.ListViewSubItem();

        string string_ClipboardData = string.Empty;

        for (int int_CycleCount = 0; int_CycleCount != this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.Columns.Count; int_CycleCount++)
        {
            string_ClipboardData += this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.Columns[int_CycleCount].Text;

            if (int_CycleCount < this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.Columns.Count - 1)
            {
                string_ClipboardData += "        |        ";
            }
        }

        string_ClipboardData += "\n\n";

        for (int int_CycleCount = 0; int_CycleCount != listViewItemCollection_obj.Count; int_CycleCount++)
        {
            for (int int_SubCycleCount = 0; int_SubCycleCount != listViewItemCollection_obj[int_CycleCount].SubItems.Count; int_SubCycleCount++)
            {
                listViewSubItem_obj = listViewItemCollection_obj[int_CycleCount].SubItems[int_SubCycleCount];

                string_ClipboardData += listViewSubItem_obj.Text;

                if (int_SubCycleCount == listViewItemCollection_obj[int_CycleCount].SubItems.Count - 1)
                {
                    string_ClipboardData += "\n\n";
                }
                else
                {
                    string_ClipboardData += "        -        ";
                }
            }
        }

        Clipboard.SetDataObject(string_ClipboardData, true);

        string_ClipboardData = String.Empty;
    }


    delegate void delegate_AddNewRemoteSystemInformationNode(string string_NewItemName, int int_ParentNodeIndex, int int_SubNodesCount);

    void delegateMethod_AddNewRemoteSystemInformationNode(string string_NewItemName, int int_ParentNodeIndex, int int_SubNodesCount)
    {
        TreeNode treeNode_NewNode;

        if (ObjCopy.obj_MainClientForm.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.Nodes.Count < int_ParentNodeIndex + 1)
        {
            treeNode_NewNode = ObjCopy.obj_MainClientForm.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.Nodes.Add(string_NewItemName);

            return;
        }

        if (ObjCopy.obj_MainClientForm.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.Nodes[int_ParentNodeIndex].IsExpanded == false)
        {
            ObjCopy.obj_MainClientForm.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.Nodes[int_ParentNodeIndex].Expand();
        }

        treeNode_NewNode = ObjCopy.obj_MainClientForm.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.Nodes[int_ParentNodeIndex].Nodes.Add(string_NewItemName);

        if (int_SubNodesCount > 0) treeNode_NewNode.Nodes.Add("");
    }


    public void AddNewRemoteSystemInformationNode(string string_NewItemName, int int_ParentNodeIndex, int int_SubNodesCount)
    {
        delegate_AddNewRemoteSystemInformationNode delegate_AddNewRemoteSystemInformationItem_obj = new delegate_AddNewRemoteSystemInformationNode(delegateMethod_AddNewRemoteSystemInformationNode);

        this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.Invoke(delegate_AddNewRemoteSystemInformationItem_obj, new object[] { string_NewItemName, int_ParentNodeIndex, int_SubNodesCount });
    }


    public void ClearRemoteSystemInformationNodes()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.Nodes.Clear();
        });
    }


    private void treeView_RemoteSystemInformation_AvailableItems_AvailableItems_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
    {
        if (e.Node.Parent == null) return;

        List<int> list_NodePath = new List<int>();

        TreeNode treeNode_CurrentNode = e.Node;

        list_NodePath.Add(treeNode_CurrentNode.Index);

        for (; ; )
        {
            if (treeNode_CurrentNode.Parent == null || list_NodePath.Count == 0) break;

            treeNode_CurrentNode = treeNode_CurrentNode.Parent;

            list_NodePath.Insert(0, treeNode_CurrentNode.Index);
        }

        if (list_NodePath.Count < 2)
        {
            e.Cancel = true;

            return;
        }

        if (!MainTcpClient.IsConnected)
        {
            e.Cancel = true;

            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            RemoteCallAction remoteCallAction_obj = new RemoteCallAction();

            remoteCallAction_obj.RemoteSystemInformationNodePath = new int[list_NodePath.Count];

            list_NodePath.CopyTo(remoteCallAction_obj.RemoteSystemInformationNodePath);

            remoteCallAction_obj.GetSelectedRemoteSystemInformationItemSubNodes();

            e.Node.Nodes.Clear();

            e.Node.Nodes.Add(ClientStringFactory.GetString(660, ClientSettingsEnvironment.CurrentLanguage));

            RSIEnableAvailableItemsGroupBox = false;

            RSIStatus = ClientStringFactory.GetString(663, ClientSettingsEnvironment.CurrentLanguage);
        }

        catch
        {

        }
    }


    private void treeView_RemoteSystemInformation_AvailableItems_AvailableItems_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
    {
        List<int> list_NodePath = new List<int>();

        if (e.Node == null) return;

        TreeNode treeNode_CurrentNode = e.Node;

        list_NodePath.Add(treeNode_CurrentNode.Index);

        for (; ; )
        {
            if (treeNode_CurrentNode.Parent == null || list_NodePath.Count == 0)
            {
                break;
            }

            treeNode_CurrentNode = treeNode_CurrentNode.Parent;

            list_NodePath.Insert(0, treeNode_CurrentNode.Index);
        }

        if (list_NodePath.Count < 2)
        {
            e.Cancel = true;

            return;
        }

        if (!MainTcpClient.IsConnected)
        {
            e.Cancel = true;

            return;
        }

        try
        {
            RemoteCallAction remoteCallAction_obj = new RemoteCallAction();

            remoteCallAction_obj.RemoteSystemInformationNodePath = new int[list_NodePath.Count];

            this.textBox_RemoteSystemInformation_AvailableInformation_CurrentItem.Text = e.Node.Text;

            list_NodePath.CopyTo(remoteCallAction_obj.RemoteSystemInformationNodePath);

            remoteCallAction_obj.GetSelectedRemoteSystemInformationItemContent();

            if (e.Node.Nodes.Count == 0)
            {
                RSIEnableAvailableItemsGroupBox = false;

                RSIStatus = ClientStringFactory.GetString(663, ClientSettingsEnvironment.CurrentLanguage);
            }
        }

        catch
        {

        }
    }


    public void UpdateRemoteSystemInformationChildNodes(int[] intArray_SystemInformationNodePath, string[] stringArray_ChildNodesNames)
    {
        TreeNode treeNode_Obj = null;

        for (int int_CycleCount = 0; int_CycleCount != intArray_SystemInformationNodePath.Length; int_CycleCount++)
        {
            if (this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.Nodes.Count <= intArray_SystemInformationNodePath[int_CycleCount]) break;

            treeNode_Obj = this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems.Nodes[intArray_SystemInformationNodePath[int_CycleCount]];
        }

        if (treeNode_Obj == null) return;

        treeNode_Obj.Nodes.Clear();

        for (int int_CycleCount = 0; int_CycleCount != stringArray_ChildNodesNames.Length; int_CycleCount++)
        {
            treeNode_Obj.Nodes.Add(stringArray_ChildNodesNames[int_CycleCount]);
        }
    }


    public TreeView RSI_Items
    {
        get
        {
            return (TreeView)this.Invoke((delegate_ReturningTreeViewMethod)delegate
            {
                return this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems;
            });
        }
        set
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.treeView_RemoteSystemInformation_AvailableItems_AvailableItems = value;
            });
        }
    }


    public void ClearRemoteSystemInformationProperties()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.Items.Clear();
        });
    }

    public void AddRemoteSystemInformationItem(ListViewItem[] listViewItemArray_RSIItems)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.Items.AddRange(listViewItemArray_RSIItems);
        });
    }

    public void SetRemoteSystemInformationColumns(string[] stringArray_ColumnsNamesRange, int[] intArray_ColumnsSizes)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.Columns.Clear();

            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.Items.Clear();

            ColumnHeader[] columnHeaderArray_NewRange = new ColumnHeader[stringArray_ColumnsNamesRange.Length];

            for (int int_CycleCount = 0; int_CycleCount != stringArray_ColumnsNamesRange.Length; int_CycleCount++)
            {
                columnHeaderArray_NewRange[int_CycleCount] = new ColumnHeader();

                columnHeaderArray_NewRange[int_CycleCount].Width = intArray_ColumnsSizes[int_CycleCount];

                columnHeaderArray_NewRange[int_CycleCount].Text = stringArray_ColumnsNamesRange[int_CycleCount];
            }

            this.listView_RemoteSystemInformation_AvailableInformation_AvailableInformation.Columns.AddRange(columnHeaderArray_NewRange);
        });
    }


    #endregion

    #region Services Manager Tab Environment

    private void button_ServicesManager_StartService_Click(object sender, System.EventArgs e)
    {
        if (MainTcpClient.IsConnected)
        {

            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();
                obj_RemoteCallAction.LastSelectedServiceAction = 1;
                obj_RemoteCallAction.DisplayedNameOfService = DisplayedNameOfService;
                obj_RemoteCallAction.NameOfService = NameOfService;
                new Thread(new ThreadStart(obj_RemoteCallAction.ActionWithSelectedService)).Start();

            }

            catch
            {

            }
        }
    }

    private void button_ServicesManager_StopService_Click(object sender, System.EventArgs e)
    {
        if (MainTcpClient.IsConnected)
        {
            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                obj_RemoteCallAction.LastSelectedServiceAction = 2;

                obj_RemoteCallAction.DisplayedNameOfService = DisplayedNameOfService;

                obj_RemoteCallAction.NameOfService = NameOfService;

                new Thread(new ThreadStart(obj_RemoteCallAction.ActionWithSelectedService)).Start();
            }

            catch
            {

            }
        }
    }

    private void button_ServicesManager_PauseService_Click(object sender, System.EventArgs e)
    {
        if (MainTcpClient.IsConnected)
        {
            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                obj_RemoteCallAction.LastSelectedServiceAction = 3;

                obj_RemoteCallAction.DisplayedNameOfService = DisplayedNameOfService;

                obj_RemoteCallAction.NameOfService = NameOfService;

                new Thread(new ThreadStart(obj_RemoteCallAction.ActionWithSelectedService)).Start();
            }

            catch
            {

            }
        }
    }

    private void button_ServicesManager_Refresh_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                new Thread(new ThreadStart(new RemoteCallAction().GetServicesList)).Start();
            }

            catch
            {

            }
        }
    }


    public void EnablePauseServiceButton()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.button_ServicesManager_PauseService.Enabled = true;
        });
    }

    public void EnableStartServiceButton()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.button_ServicesManager_StartService.Enabled = true;
        });
    }

    public void EnableStopServiceButton()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.button_ServicesManager_StopService.Enabled = true;
        });
    }


    private void listView_ServicesManager_Services_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MainTcpClient.IsConnected && this.listView_ServicesManager_Services.Items.Count > 0)
        {
            try
            {
                button_ServicesManager_StartService.Enabled = false;
                button_ServicesManager_StopService.Enabled = false;
                button_ServicesManager_PauseService.Enabled = false;

                if (StatusOfService != "Running")
                    ObjCopy.obj_MainClientForm.EnableStartServiceButton();

                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                obj_RemoteCallAction.DisplayedNameOfService = DisplayedNameOfService;
                obj_RemoteCallAction.NameOfService = NameOfService;

                new Thread(new ThreadStart(obj_RemoteCallAction.GetPossibleServiceActions)).Start();
            }

            catch
            {

            }
        }
    }


    private void listView_ServicesManager_Services_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        listView_ServicesManager_Services_Click(null, null);
    }

    #endregion

    #region System Events Tab Environment

    private void button_SystemEvents_Refresh_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (comboBox_SystemEvents_Logs.Text.Length == 0)
        {
            MessageBox.Show(ClientStringFactory.GetString(211, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();
                CurrentSystemEventLog = obj_RemoteCallAction.CurrentSystemEventLog = comboBox_SystemEvents_Logs.Text;
                new Thread(new ThreadStart(obj_RemoteCallAction.GetSystemEventsList)).Start();
            }

            catch
            {

            }
        }
    }

    private void button_SystemEvents_DeleteAllEvents_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (comboBox_SystemEvents_Logs.Text.Length == 0)
        {
            MessageBox.Show(ClientStringFactory.GetString(211, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected)
        {
            if (DialogResult.No == MessageBox.Show(ClientStringFactory.GetString(210, ClientSettingsEnvironment.CurrentLanguage) + " <" + comboBox_SystemEvents_Logs.Text + "> ?",
                ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                CurrentSystemEventLog = obj_RemoteCallAction.CurrentSystemEventLog = comboBox_SystemEvents_Logs.Text;

                new Thread(new ThreadStart(obj_RemoteCallAction.DeleteSystemEventsList)).Start();
            }

            catch
            {

            }
        }
    }

    private void button_SystemEvents_EventProperties_Click(object sender, System.EventArgs e)
    {
        if (this.listView_SystemEvents_Events.SelectedItems.Count > 0)
        {
            EventPropertiesForm eventPropertiesForm_obj = new EventPropertiesForm(this.listView_SystemEvents_Events.SelectedItems[0].Index, listView_SystemEvents_Events);

            eventPropertiesForm_obj.ChangeControlsLanguage();

            eventPropertiesForm_obj.ShowDialog();
        }

        else MessageBox.Show(ClientStringFactory.GetString(208, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
    }


    private void button_SystemEvents_DeleteLog_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (comboBox_SystemEvents_Logs.Text.Length == 0)
        {
            MessageBox.Show(ClientStringFactory.GetString(211, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected)
        {

            if (DialogResult.No == MessageBox.Show(ClientStringFactory.GetString(212, ClientSettingsEnvironment.CurrentLanguage) + " <" + comboBox_SystemEvents_Logs.Text + "> ?",
                ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                CurrentSystemEventLog = obj_RemoteCallAction.CurrentSystemEventLog = comboBox_SystemEvents_Logs.Text;

                new Thread(new ThreadStart(obj_RemoteCallAction.DeleteSystemLog)).Start();
            }

            catch
            {

            }
        }
    }


    private void comboBox_SystemEvents_Logs_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                CurrentSystemEventLog = obj_RemoteCallAction.CurrentSystemEventLog = comboBox_SystemEvents_Logs.SelectedItem.ToString();

                new Thread(new ThreadStart(obj_RemoteCallAction.GetSystemEventsList)).Start();

                EnableSystemEventsManager = false;

                this.textBox_SystemEvents_Information.Select();
            }
            catch
            {

            }
        }
    }

    private void comboBox_SystemEvents_Logs_DropDown(object sender, System.EventArgs e)
    {
        if (MainTcpClient.IsConnected)
        {
            try
            {
                new Thread(new ThreadStart(new RemoteCallAction().GetListOfExistingSystemLogs)).Start();
            }

            catch (Exception exception_obj)
            {

            }
        }
    }


    private void listView_SystemEvents_Events_DoubleClick(object sender, System.EventArgs e)
    {
        if (listView_SystemEvents_Events.SelectedItems.Count > 0)
        {
            EventPropertiesForm obj_EventPropertiesForm = new EventPropertiesForm(this.listView_SystemEvents_Events.SelectedItems[0].Index, listView_SystemEvents_Events);
            obj_EventPropertiesForm.ChangeControlsLanguage();
            obj_EventPropertiesForm.ShowDialog();
        }
        else MessageBox.Show(ClientStringFactory.GetString(208, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
    }


    #endregion

    #region File Manager Tab Environment

    private void menuItem_UploadFiles_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (CurrentFilePath == "" || this.comboBox_FileManager_LogicalDrives.SelectedIndex < 1) 
        {
       //!! индекс 0 и не даёт отправлять    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(768, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        //!!    return;
        }

        DatabaseOfUploadingFiles.TotalUploadingSize = 0;
        DatabaseOfUploadingFiles.TotalBytesUploaded = 0;


        OpenFileDialog obj_OpenFileDialog = new OpenFileDialog();
        obj_OpenFileDialog.Multiselect = true;
        obj_OpenFileDialog.ShowDialog();

        if (obj_OpenFileDialog.FileNames.Length == 0) return;

        try
        {

            long long_TotalToSend = 0;

            DatabaseOfUploadingFiles obj_DatabaseOfUploadingFiles;

            FileInfo obj_FileInfo;



            for (int int_CycleCount = 0; int_CycleCount != obj_OpenFileDialog.FileNames.Length; int_CycleCount++)
            {
                obj_FileInfo = new FileInfo(obj_OpenFileDialog.FileNames[int_CycleCount]);

                obj_DatabaseOfUploadingFiles = new DatabaseOfUploadingFiles();

                obj_DatabaseOfUploadingFiles.LocalNameOfFileWithPath = obj_OpenFileDialog.FileNames[int_CycleCount];
                obj_DatabaseOfUploadingFiles.NameOfUploadingFile = obj_FileInfo.Name;
                obj_DatabaseOfUploadingFiles.RemoteFolderForReceivedFiles = CurrentFilePath;
                obj_DatabaseOfUploadingFiles.SizeOfUploadingFile = obj_FileInfo.Length;
                obj_DatabaseOfUploadingFiles.TimeOfLastFileWrite = obj_FileInfo.LastWriteTime.ToShortDateString() + "     " + obj_FileInfo.LastWriteTime.ToShortTimeString();

                long_TotalToSend += obj_FileInfo.Length;

                DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Add(obj_DatabaseOfUploadingFiles);
            }


            DatabaseOfUploadingFiles.TotalUploadingSize = long_TotalToSend;
            DatabaseOfUploadingFiles.TotalBytesUploaded = 0;

            button_FileManager_Upload.Enabled = false;

            ObjCopy.obj_FilesUploadForm = new FilesUploadForm();

            ObjCopy.obj_FilesUploadForm.ChangeControlsLanguage();

            ObjCopy.obj_FilesUploadForm.TotalUploadProgress_MaxValue = long_TotalToSend;
            ObjCopy.obj_FilesUploadForm.TotalFilesNum = DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count;
            ObjCopy.obj_FilesUploadForm.CurrentFileNum = 1;

            new Thread(new ThreadStart(new RemoteCallAction().SendRequestToUploadFile)).Start();

            ObjCopy.obj_FilesUploadForm.AddTask(ClientStringFactory.GetString(348, ClientSettingsEnvironment.CurrentLanguage));

        }

        catch (Exception)
        {
            DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Clear();
        }

    }


    static List<string[]> list_AllFiles = new List<string[]>();

    void CollectFiles(string string_NecessaryPath)
    {
        try
        {
            list_AllFiles.Add(Directory.GetFiles(string_NecessaryPath));

            foreach (string string_NewFolderPath in Directory.GetDirectories(string_NecessaryPath)) CollectFiles(string_NewFolderPath);

            return;
        }

        catch (System.UnauthorizedAccessException UAexception)
        {
            MessageBox.Show(UAexception.Message, ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));
        }
    }


    private void menuItem_UploadFolders_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (CurrentFilePath == "" || this.comboBox_FileManager_LogicalDrives.SelectedIndex < 1)
        {
          //!!  MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(768, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
           
         //!!   return;
        }

        try
        {

            FolderBrowserDialog obj_FolderBrowserDialog = new FolderBrowserDialog();

            obj_FolderBrowserDialog.ShowDialog();

            string string_FolderToSend = obj_FolderBrowserDialog.SelectedPath;

            if (string_FolderToSend == null) return;

            if (string_FolderToSend.Length == 0)
            {
                MessageBox.Show(ClientStringFactory.GetString(361, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));
                return;
            }

            CollectFiles(string_FolderToSend);

            long long_TotalToSend = 0;

            DatabaseOfUploadingFiles obj_DatabaseOfUploadingFiles;

            FileInfo obj_FileInfo;

            for (int int_CycleCount = 0; list_AllFiles.Count != int_CycleCount; int_CycleCount++)
            {
                foreach (string string_CurentFile in list_AllFiles[int_CycleCount])
                {
                    obj_FileInfo = new FileInfo(string_CurentFile);

                    obj_DatabaseOfUploadingFiles = new DatabaseOfUploadingFiles();

                    obj_DatabaseOfUploadingFiles.LocalNameOfFileWithPath = string_CurentFile;
                    obj_DatabaseOfUploadingFiles.NameOfUploadingFile = obj_FileInfo.Name;
                    obj_DatabaseOfUploadingFiles.SizeOfUploadingFile = obj_FileInfo.Length;
                    obj_DatabaseOfUploadingFiles.TimeOfLastFileWrite = obj_FileInfo.LastWriteTime.ToShortDateString() + "     " + obj_FileInfo.LastWriteTime.ToShortTimeString();

                    long_TotalToSend += obj_FileInfo.Length;

                    if (obj_FileInfo.DirectoryName.Length == string_FolderToSend.Length)
                        obj_DatabaseOfUploadingFiles.RemoteFolderForReceivedFiles = CurrentFilePath + obj_FileInfo.Directory.Name + "\\";

                    else
                        obj_DatabaseOfUploadingFiles.RemoteFolderForReceivedFiles = CurrentFilePath + obj_FileInfo.Directory.FullName.Remove(0, string_FolderToSend.LastIndexOf("\\") + 1) + "\\";


                    DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Add(obj_DatabaseOfUploadingFiles);
                }
            }

            list_AllFiles.Clear();

            DatabaseOfUploadingFiles.TotalUploadingSize = long_TotalToSend;
            DatabaseOfUploadingFiles.TotalBytesUploaded = 0;

            button_FileManager_Upload.Enabled = false;

            ObjCopy.obj_FilesUploadForm = new FilesUploadForm();

            ObjCopy.obj_FilesUploadForm.ChangeControlsLanguage();

            ObjCopy.obj_FilesUploadForm.TotalUploadProgress = 0;
            ObjCopy.obj_FilesUploadForm.TotalUploadProgress_MaxValue = long_TotalToSend;
            ObjCopy.obj_FilesUploadForm.TotalFilesNum = DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count;
            ObjCopy.obj_FilesUploadForm.CurrentFileNum = 1;

            new Thread(new ThreadStart(new RemoteCallAction().SendRequestToUploadFile)).Start();

            ObjCopy.obj_FilesUploadForm.AddTask(ClientStringFactory.GetString(348, ClientSettingsEnvironment.CurrentLanguage));

        }

        catch (Exception)
        {
            list_AllFiles.Clear();
        }

    }


    private void button_FileManager_Upload_Click(object sender, System.EventArgs e)
    {
        contextMenu_FileManager_Upload.Show(tabPage_FileManager, new Point(button_FileManager_Upload.Location.X, button_FileManager_Upload.Location.Y + 23));
    }

    private void button_FileManager_Download_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected && listView_FileManager_FileManager.SelectedItems.Count == 0)
        {
            MessageBox.Show(ClientStringFactory.GetString(215, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));
            return;
        }

        try
        {

            if (!Directory.Exists(ClientSettingsEnvironment.DownloadedFilesPath))
            {
                if (DialogResult.Yes == MessageBox.Show(ClientStringFactory.GetString(218, ClientSettingsEnvironment.CurrentLanguage),
                    ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Directory.CreateDirectory(ClientSettingsEnvironment.DownloadedFilesPath);
                }

                else return;
            }

            long long_TotalDownloadingSize = 0;
            DatabaseOfDownloadingFiles databaseOfDownloadingFiles_CurrentCopy;
            DatabaseOfDownloadingFolders databaseOfDownloadingFolders_CurrentCopy;

            for (int int_CycleCount = 0; int_CycleCount != this.listView_FileManager_FileManager.SelectedItems.Count; int_CycleCount++)
            {
                if (listView_FileManager_FileManager.SelectedItems[int_CycleCount].ImageIndex == 0)
                {
                    databaseOfDownloadingFolders_CurrentCopy = new DatabaseOfDownloadingFolders();

                    databaseOfDownloadingFolders_CurrentCopy.NameOfDownloadingFolder = listView_FileManager_FileManager.SelectedItems[int_CycleCount].SubItems[0].Text;
                    databaseOfDownloadingFolders_CurrentCopy.LocalFolderForReceivedFolder = ClientSettingsEnvironment.DownloadedFilesPath;
                    databaseOfDownloadingFolders_CurrentCopy.RemoteFolderNameAndPath = CurrentFilePath + listView_FileManager_FileManager.SelectedItems[int_CycleCount].SubItems[0].Text;

                    DatabaseOfDownloadingFolders.list_DatabaseOfDownloadingFolders.Add(databaseOfDownloadingFolders_CurrentCopy);
                }

                else
                {
                    databaseOfDownloadingFiles_CurrentCopy = new DatabaseOfDownloadingFiles();

                    databaseOfDownloadingFiles_CurrentCopy.RemoteFileNameAndPath = CurrentFilePath + listView_FileManager_FileManager.SelectedItems[int_CycleCount].SubItems[0].Text;
                    databaseOfDownloadingFiles_CurrentCopy.LocalFolderForReceivedFiles = ClientSettingsEnvironment.DownloadedFilesPath;
                    databaseOfDownloadingFiles_CurrentCopy.NameOfDownloadingFile = listView_FileManager_FileManager.SelectedItems[int_CycleCount].SubItems[0].Text;
                    databaseOfDownloadingFiles_CurrentCopy.SizeOfDownloadingFile = long.Parse(listView_FileManager_FileManager.SelectedItems[int_CycleCount].SubItems[1].Text.Replace(", ", ""));
                    databaseOfDownloadingFiles_CurrentCopy.TimeOfLastFileWrite = listView_FileManager_FileManager.SelectedItems[int_CycleCount].SubItems[2].Text;

                    long_TotalDownloadingSize += databaseOfDownloadingFiles_CurrentCopy.SizeOfDownloadingFile;

                    DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Add(databaseOfDownloadingFiles_CurrentCopy);
                }
            }


            DatabaseOfDownloadingFiles.TotalBytesRecieved = 0;

            button_FileManager_Download.Enabled = false;

            ObjCopy.obj_FilesDownloadForm = new FilesDownloadForm();
            ObjCopy.obj_FilesDownloadForm.ChangeControlsLanguage();
            ObjCopy.obj_FilesDownloadForm.TotalDownloadProgress = 0;
            ObjCopy.obj_FilesDownloadForm.CurrentFileNum = 1;

            if (DatabaseOfDownloadingFolders.list_DatabaseOfDownloadingFolders.Count == 0)
            {
                DatabaseOfDownloadingFiles.TotalDownloadingSize = long_TotalDownloadingSize;
                ObjCopy.obj_FilesDownloadForm.TotalDownloadProgress_MaxValue = long_TotalDownloadingSize;
                ObjCopy.obj_FilesDownloadForm.TotalFilesNum = DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count;

                new Thread(new ThreadStart(new RemoteCallAction().SendRequestToDownloadFile)).Start();

                ObjCopy.obj_FilesDownloadForm.AddTask(ClientStringFactory.GetString(348, ClientSettingsEnvironment.CurrentLanguage));
            }

            else
            {
                ObjCopy.obj_FilesDownloadForm.Cursor = Cursors.WaitCursor;

                ObjCopy.obj_FilesDownloadForm.EnableStopButton = false;
                new Thread(new ThreadStart(new RemoteCallAction().SendRequestToDownloadFolders)).Start();

                ObjCopy.obj_FilesDownloadForm.AddTask(ClientStringFactory.GetString(347, ClientSettingsEnvironment.CurrentLanguage));
            }

            return;
        }

        catch (Exception exception_obj)
        {

        }

    }


    private void button_FileManager_Delete_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (listView_FileManager_FileManager.SelectedItems.Count == 0)
        {
            MessageBox.Show(ClientStringFactory.GetString(279, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            return;
        }

        if (DialogResult.No == MessageBox.Show(ClientStringFactory.GetString(219, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            return;
        }

        RemoteCallAction remoteCallAction_obj = null;

        for (int int_CycleCount = 0; int_CycleCount !=
            listView_FileManager_FileManager.SelectedItems.Count; int_CycleCount++)
        {

            if (listView_FileManager_FileManager.SelectedItems[int_CycleCount].ImageIndex == 1)
            {
                remoteCallAction_obj = new RemoteCallAction();
                remoteCallAction_obj.LastSelectedNameOfFileWithPath = CurrentFilePath + listView_FileManager_FileManager.SelectedItems[int_CycleCount].Text;

                new Thread(new ThreadStart(remoteCallAction_obj.DeleteFile)).Start();

            }


            if (listView_FileManager_FileManager.SelectedItems[int_CycleCount].ImageIndex == 0)
            {
                remoteCallAction_obj = new RemoteCallAction();

                remoteCallAction_obj.LastSelectedNameOfFolderWithPath = CurrentFilePath + listView_FileManager_FileManager.SelectedItems[int_CycleCount].Text;

                new Thread(new ThreadStart(remoteCallAction_obj.DeleteFolder)).Start();
            }
        }

        remoteCallAction_obj = new RemoteCallAction();
        remoteCallAction_obj.CurrentFilePath = string_CurrentFilePath;
        new Thread(new ThreadStart(remoteCallAction_obj.GetFileList)).Start();
    }

    private void button_FileManager_NewFolder_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        else
        {
            CreateNewFolderForm obj_CreateNewFolderForm = new CreateNewFolderForm();
            obj_CreateNewFolderForm.ChangeControlsLanguage();
            obj_CreateNewFolderForm.ShowDialog();
        }
    }


    public void SelectFirstFileManagetItem()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_FileManager_FileManager.Items[0].Selected = true;
            this.listView_FileManager_FileManager.Items[0].Focused = true;
        });
    }


    private void button_FileManager_Execute_Click(object sender, System.EventArgs e)
    {
        try
        {
            if (this.listView_FileManager_FileManager.SelectedItems.Count > 0 &&
                 this.listView_FileManager_FileManager.FocusedItem.ImageIndex == 1)
            {
                this.textBox_RemoteExecution_FileNameWithPath.Text = CurrentFilePath + this.listView_FileManager_FileManager.FocusedItem.Text;

                this.textBox_RemoteExecution_WorkingFolder.Text = CurrentFilePath;

                this.tabControl_Main.SelectedIndex = 2;//tabControl_Main.Controls[2].TabIndex;
            }
        }

        catch (Exception)
        {

        }
    }

    private void button_FileManager_DirUp_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (CurrentFilePath.LastIndexOf("\\") != CurrentFilePath.IndexOf("\\"))
        {

            CurrentFilePath = CurrentFilePath.Remove(CurrentFilePath.Length - 1, 1);

            int int_LastSlashPos = CurrentFilePath.LastIndexOf("\\");

            CurrentFilePath = CurrentFilePath.Remove(int_LastSlashPos + 1, CurrentFilePath.Length - int_LastSlashPos - 1);

            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                obj_RemoteCallAction.CurrentFilePath = CurrentFilePath;

                new Thread(new ThreadStart(obj_RemoteCallAction.GetFileList)).Start();

            }

            catch (Exception exception_obj)
            {

            }
        }
    }

    private void button_FileManager_Refresh_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();
            
            if (this.comboBox_FileManager_LogicalDrives.Text == "")
            {
                new Thread(new ThreadStart(new RemoteCallAction().GetListOfExistingDrives)).Start();                 
            }

            Thread.Sleep(500);

            if (CurrentFilePath == "")
            {         
                CurrentFilePath = obj_RemoteCallAction.CurrentFilePath = comboBox_FileManager_LogicalDrives.Text = "C:\\";
            }

            obj_RemoteCallAction.CurrentFilePath = string_CurrentFilePath;

            new Thread(new ThreadStart(obj_RemoteCallAction.GetFileList)).Start();
        }

        catch (Exception exception_obj)
        {

        }
    }

    private void button_FileManager_Rename_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (listView_FileManager_FileManager.SelectedItems.Count != 1)
        {
            MessageBox.Show(ClientStringFactory.GetString(222, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));
            return;
        }


        if (listView_FileManager_FileManager.SelectedItems.Count > 0
            && listView_FileManager_FileManager.FocusedItem.Selected)
        {
            ObjCopy.obj_RenameFolderOrFileForm = new RenameFolderOrFileForm();

            ObjCopy.obj_RenameFolderOrFileForm.RenameFolderOrFileName = LastSelectedNameOfFolderOrFile;

            ObjCopy.obj_RenameFolderOrFileForm.LastSelectedNameOfFolderOrFile = LastSelectedNameOfFolderOrFile;
            ObjCopy.obj_RenameFolderOrFileForm.LastSelectedNameOfFolderOrFileWithPath = LastSelectedNameOfFolderOrFileWithPath;

            ObjCopy.obj_RenameFolderOrFileForm.ShowDialog();

            button_FileManager_Rename.Refresh();
        }
    }

    private void button_FileManager_Properties_Click(object sender, System.EventArgs e)
    {
        menuItem_Properties_Click(null, null);
    }


    private void menuItem_Properties_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (listView_FileManager_FileManager.SelectedItems.Count != 1)
        {
            MessageBox.Show(ClientStringFactory.GetString(362, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));
            return;
        }

        if (listView_FileManager_FileManager.SelectedItems.Count > 0
            && listView_FileManager_FileManager.FocusedItem.Selected)
        {
            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();
            obj_RemoteCallAction.LastSelectedNameOfFolderOrFileWithPath = LastSelectedNameOfFolderOrFileWithPath;

            obj_RemoteCallAction.ReceiveFileManagerObjectPropertes(listView_FileManager_FileManager.FocusedItem.ImageIndex);
        }
    }


    public void ShowDownloadCompleteMessage()
    {
        DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Clear();

        if (MessageBox.Show(ObjCopy.obj_FilesDownloadForm, ClientStringFactory.GetString(223, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
        {
            Process.Start(new ProcessStartInfo(ClientSettingsEnvironment.DownloadedFilesPath));
        }

        ObjCopy.obj_FilesDownloadForm.Close();

        button_FileManager_Download.Enabled = true;

        LocalAction.LastResultOfLocalFileReplace = 3;
    }

    public void ChangeDownloadProgress()
    {
        this.Invoke((MethodInvoker)delegate
        {
            try
            {
                if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count == 0)
                {
                    new Thread(new ThreadStart(ShowDownloadCompleteMessage)).Start();

                    return;
                }

                DatabaseOfDownloadingFiles obj_DatabaseOfDownloadingFiles = DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList[0];

                ObjCopy.obj_FilesDownloadForm.DownloadProgress_MaxValue = obj_DatabaseOfDownloadingFiles.SizeOfDownloadingFile;

                ObjCopy.obj_FilesDownloadForm.DownloadProgress = obj_DatabaseOfDownloadingFiles.BytesReceived;
                ObjCopy.obj_FilesDownloadForm.CurrentDownloadingFileName = obj_DatabaseOfDownloadingFiles.NameOfDownloadingFile;
                ObjCopy.obj_FilesDownloadForm.DownloadFolder = obj_DatabaseOfDownloadingFiles.LocalFolderForReceivedFiles;
            }

            catch (Exception exception_obj)
            {

            }
        });
    }


    public void ShowUploadCompleteMessage()
    {
        ObjCopy.obj_FilesUploadForm.Invoke((MethodInvoker)delegate
        {
            MessageBox.Show(ObjCopy.obj_FilesUploadForm, ClientStringFactory.GetString(224, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

            DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Clear();

            ObjCopy.obj_FilesUploadForm.Close();

            button_FileManager_Upload.Enabled = true;

            LocalAction.LastResultOfRemoteFileReplace = 0;
        });
    }

    public void ChangeUploadProgress()
    {
        this.Invoke((MethodInvoker)delegate
        {
            try
            {
                if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count == 0)
                {
                    new Thread(new ThreadStart(ShowUploadCompleteMessage)).Start();

                    return;
                }

                DatabaseOfUploadingFiles obj_DatabaseOfUploadingFiles = DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0];

                ObjCopy.obj_FilesUploadForm.UploadProgress_MaxValue = obj_DatabaseOfUploadingFiles.SizeOfUploadingFile;

                ObjCopy.obj_FilesUploadForm.UploadProgress = obj_DatabaseOfUploadingFiles.BytesSent;

                ObjCopy.obj_FilesUploadForm.CurrentUploadingFileName = obj_DatabaseOfUploadingFiles.NameOfUploadingFile;

                ObjCopy.obj_FilesUploadForm.UploadFolder = obj_DatabaseOfUploadingFiles.RemoteFolderForReceivedFiles;
            }

            catch (Exception exception_obj)
            {

            }
        });
    }

    public void AddFileManagerDirItem(ListViewItem[] listViewItemArray_Dir)
    {
        if (this.IsHandleCreated == false || listViewItemArray_Dir == null) return;

        this.Invoke((MethodInvoker)delegate
        {
            this.listView_FileManager_FileManager.Items.AddRange(listViewItemArray_Dir);
        });
    }

    public void AddFileManagerItem(ListViewItem[] listViewItemArray_Files)
    {
        if (this.IsHandleCreated == false || listViewItemArray_Files == null) return;

        this.Invoke((MethodInvoker)delegate
        {
            this.listView_FileManager_FileManager.Items.AddRange(listViewItemArray_Files);
        });
    }

    private void comboBox_FileManager_LogicalDrives_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                ObjCopy.obj_MainClientForm.DeleteAllFileManagerViewData();

                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                CurrentFilePath = obj_RemoteCallAction.CurrentFilePath = comboBox_FileManager_LogicalDrives.SelectedItem.ToString();

                new Thread(new ThreadStart(obj_RemoteCallAction.GetFileList)).Start();
            }
            catch (Exception exception_obj)
            {

            }
        }
    }

    private void comboBox_FileManager_LogicalDrives_DropDown(object sender, System.EventArgs e)
    {
        if (MainTcpClient.IsConnected)
        {
            try
            {
                new Thread(new ThreadStart(new RemoteCallAction().GetListOfExistingDrives)).Start();
            }

            catch (Exception exception_obj)
            {

            }
        }
    }

    private void listView_FileManager_FileManager_DoubleClick(object sender, System.EventArgs e)
    {
        try
        {
            if (!MainTcpClient.IsConnected)
            {
                MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.listView_FileManager_FileManager.SelectedItems[0].Text == this.listView_FileManager_FileManager.SelectedItems[0].Text.ToUpper() &&
                MainTcpClient.IsConnected && listView_FileManager_FileManager.Items.Count > 0)
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                obj_RemoteCallAction.CurrentFilePath = CurrentFilePath + listView_FileManager_FileManager.SelectedItems[0].Text + "\\";

                new Thread(new ThreadStart(obj_RemoteCallAction.GetFileList)).Start();
            }

            if (this.listView_FileManager_FileManager.SelectedItems[0].Text == this.listView_FileManager_FileManager.SelectedItems[0].Text.ToLower() &&
                MainTcpClient.IsConnected && listView_FileManager_FileManager.Items.Count > 0)
            {
                this.button_FileManager_Execute_Click(null, null);
            }

        }

        catch (Exception)
        {

        }


    }

    private void listView_FileManager_FileManager_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {

        switch ((int)e.KeyChar)
        {
            case 13:
                listView_FileManager_FileManager_DoubleClick(null, null);
                break;

            case 8:
                button_FileManager_DirUp_Click(null, null);
                break;
        }

    }



    public void DeleteAllFileManagerViewData()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_FileManager_FileManager.Items.Clear();
        });
    }


    #endregion

    #region Remote Registry Tab Environment

    public void ClearCurrentRegistryValues()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_RemoteRegistry_Values.Items.Clear();
        });
    }


    public TreeView RemoteRegistry
    {
        get
        {
            return this.treeView_RemoteRegistry_NodesTree;
        }
    }


    public void SelectRegistryKey(TreeNode treeNode_obj)
    {
        if (treeNode_obj == null) return;

        this.treeView_RemoteRegistry_NodesTree.SelectedNode = treeNode_obj;
    }


    public void ChangeExpandButtonState(TreeNode treeNode_obj)
    {
        if (this.treeView_RemoteRegistry_NodesTree.SelectedNode == null) return;

        if (treeNode_obj.IsExpanded)
        {
            this.button_RemoteRegistry_Expand.Text = ClientStringFactory.GetString(584, ClientSettingsEnvironment.CurrentLanguage);
        }
        else this.button_RemoteRegistry_Expand.Text = ClientStringFactory.GetString(583, ClientSettingsEnvironment.CurrentLanguage);

        if (treeNode_obj.Nodes.Count == 0) this.button_RemoteRegistry_Expand.Enabled = false;
        else this.button_RemoteRegistry_Expand.Enabled = true;
    }


    List<int> GetRegistryKeyPath(TreeNode treeNode_RegistryKey)
    {
        List<int> list_RegistryKeyPath = new List<int>();

        for (int int_CycleCount = 0; int_CycleCount != -1; int_CycleCount++)
        {
            list_RegistryKeyPath.Insert(0, treeNode_RegistryKey.Index);

            if (treeNode_RegistryKey.Parent == null) break;

            treeNode_RegistryKey = treeNode_RegistryKey.Parent;
        }

        return list_RegistryKeyPath;
    }


    void InitRegistryTreeViewState()
    {
        foreach (System.Windows.Forms.TreeNode treeNode_Obj in this.treeView_RemoteRegistry_NodesTree.Nodes)
        {
            treeNode_Obj.Nodes.Clear();

            treeNode_Obj.Nodes.Add("");
        }
    }


    public void SetRegistryValuesParentNode(TreeNode treeNode_ParentRegistryKey)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_RemoteRegistry_Values.Tag = treeNode_ParentRegistryKey;
        });
    }


    private void ExpandNecessaryRegistryNode(TreeNode treeNode_obj)
    {
        try
        {
            treeNode_obj.Nodes.Clear();
            treeNode_obj.Nodes.Add("");

            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            obj_RemoteCallAction.RegistryKeyFullName = treeNode_obj.FullPath;

            obj_RemoteCallAction.RegistryKeyPath = this.GetRegistryKeyPath(treeNode_obj);

            obj_RemoteCallAction.GetRegistrySubKeysList();
        }

        catch (Exception exception_obj)
        {

        }
    }


    private void CreateNewRegistryKey(TreeNode treeNode_obj)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            if (treeNode_obj == null)
            {
                MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(594, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            AddNewItemForm addNewItemForm_obj = new AddNewItemForm();

            addNewItemForm_obj.Text = ClientStringFactory.GetString(592, ClientSettingsEnvironment.CurrentLanguage);

            addNewItemForm_obj.InfoLabelText = ClientStringFactory.GetString(593, ClientSettingsEnvironment.CurrentLanguage);

            if (addNewItemForm_obj.ShowDialog() != DialogResult.OK || addNewItemForm_obj.NewItemName.Length == 0)
            {
                return;
            }

            obj_RemoteCallAction.RegistryKeyFullName = treeNode_obj.FullPath;
            obj_RemoteCallAction.RegistryKeyName = addNewItemForm_obj.NewItemName;

            obj_RemoteCallAction.CreateNewRegistryKey();

            if (treeNode_obj.Nodes.Count == 0)
            {
                treeNode_obj.Nodes.Add("");
            }

            treeNode_obj.Toggle();
            treeNode_obj.Toggle();

            addNewItemForm_obj.Close();
        }

        catch (Exception exception_obj)
        {

        }
    }


    private void CreateNewRegistryStringValue(TreeNode treeNode_obj)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            if (treeNode_obj == null)
            {
                MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(594, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            CreateTextValueForm createTextValueForm_obj = new CreateTextValueForm(this, "", "");

            if (createTextValueForm_obj.ShowDialog() != DialogResult.OK || createTextValueForm_obj.ValueData.Length == 0 || createTextValueForm_obj.ValueName.Length == 0)
            {
                return;
            }

            obj_RemoteCallAction.RegistryKeyFullName = treeNode_obj.FullPath;
            obj_RemoteCallAction.NewRegistryValueName = createTextValueForm_obj.ValueName;
            obj_RemoteCallAction.NewRegistryValue = createTextValueForm_obj.ValueData;

            obj_RemoteCallAction.CreateRegistryStringValue();

            this.treeView_RemoteRegistry_NodesTree_BeforeSelect(this, new TreeViewCancelEventArgs((TreeNode)this.listView_RemoteRegistry_Values.Tag, false, TreeViewAction.Expand));

            createTextValueForm_obj.Close();
        }

        catch (Exception exception_obj)
        {

        }
    }


    private void CreateNewRegistryMultiStringValue(TreeNode treeNode_obj)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            if (treeNode_obj == null)
            {
                MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(594, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            CreateMultilineTextValueForm createMultilineTextValueForm_obj = new CreateMultilineTextValueForm(this, "", null);

            if (createMultilineTextValueForm_obj.ShowDialog() != DialogResult.OK || createMultilineTextValueForm_obj.ValueData.Length == 0 || createMultilineTextValueForm_obj.ValueName.Length == 0)
            {
                return;
            }

            obj_RemoteCallAction.RegistryKeyFullName = treeNode_obj.FullPath;
            obj_RemoteCallAction.NewRegistryValueName = createMultilineTextValueForm_obj.ValueName;
            obj_RemoteCallAction.NewRegistryValue = createMultilineTextValueForm_obj.ValueData;

            obj_RemoteCallAction.CreateRegistryMultiStringValue();

            this.treeView_RemoteRegistry_NodesTree_BeforeSelect(this, new TreeViewCancelEventArgs((TreeNode)this.listView_RemoteRegistry_Values.Tag, false, TreeViewAction.Expand));

            createMultilineTextValueForm_obj.Close();
        }

        catch (Exception exception_obj)
        {

        }
    }


    private void CreateNewRegistryDwordValue(TreeNode treeNode_obj)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            if (treeNode_obj == null)
            {
                MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(594, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            CreateDWORDValueForm createDWORDValueForm_obj = new CreateDWORDValueForm(this, "", 0);

            if (createDWORDValueForm_obj.ShowDialog() != DialogResult.OK || createDWORDValueForm_obj.ValueName.Length == 0)
            {
                return;
            }

            obj_RemoteCallAction.RegistryKeyFullName = treeNode_obj.FullPath;
            obj_RemoteCallAction.NewRegistryValueName = createDWORDValueForm_obj.ValueName;
            obj_RemoteCallAction.NewRegistryValue = createDWORDValueForm_obj.ValueData;

            obj_RemoteCallAction.CreateRegistryDWordValue();

            this.treeView_RemoteRegistry_NodesTree_BeforeSelect(this, new TreeViewCancelEventArgs((TreeNode)this.listView_RemoteRegistry_Values.Tag, false, TreeViewAction.Expand));

            createDWORDValueForm_obj.Close();
        }

        catch (Exception exception_obj)
        {

        }
    }




    private void DeleteRegistryValue(int int_ValueIndex)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            obj_RemoteCallAction.RegistryKeyFullName = ((TreeNode)this.listView_RemoteRegistry_Values.Tag).FullPath;

            obj_RemoteCallAction.RegistryValueName = this.listView_RemoteRegistry_Values.SelectedItems[0].Text;

            obj_RemoteCallAction.DeleteRegistryValue();
        }

        catch (Exception exception_obj)
        {

        }
    }


    private void DeleteRegistryKey(TreeNode treeNode_obj)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            if (MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(591, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            obj_RemoteCallAction.RegistryKeyName = treeNode_obj.Text;

            if (treeNode_obj.Parent != null)
            {
                treeNode_obj = treeNode_obj.Parent;
            }

            obj_RemoteCallAction.RegistryKeyFullName = treeNode_obj.FullPath;

            obj_RemoteCallAction.DeleteRegistryKey();

            treeNode_obj.Toggle();
            treeNode_obj.Toggle();

            this.treeView_RemoteRegistry_NodesTree.SelectedNode = null;
            this.treeView_RemoteRegistry_NodesTree.SelectedNode = treeNode_obj;
        }

        catch (Exception exception_obj)
        {

        }
    }

    void RenameRegistryValue()
    {
        if (this.listView_RemoteRegistry_Values.SelectedItems.Count != 1)
        {
            return;
        }

        RenameItemForm renameItemForm_obj = new RenameItemForm();

        renameItemForm_obj.OldItemName = this.listView_RemoteRegistry_Values.SelectedItems[0].Text;

        if (renameItemForm_obj.ShowDialog(this) != DialogResult.OK || renameItemForm_obj.NewItemName.Length == 0)
        {
            return;
        }

        RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

        obj_RemoteCallAction.RegistryKeyFullName = ((TreeNode)this.listView_RemoteRegistry_Values.Tag).FullPath;

        obj_RemoteCallAction.RegistryValueName = renameItemForm_obj.OldItemName;

        obj_RemoteCallAction.NewRegistryValueName = renameItemForm_obj.NewItemName;

        obj_RemoteCallAction.RenameRegistryValue();

        this.treeView_RemoteRegistry_NodesTree.SelectedNode = ((TreeNode)this.listView_RemoteRegistry_Values.Tag);
    }

    private void ModifyRegistryValue()
    {
        if (this.listView_RemoteRegistry_Values.SelectedItems.Count != 1)
        {
            return;
        }

        RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

        obj_RemoteCallAction.RegistryKeyFullName = ((TreeNode)this.listView_RemoteRegistry_Values.Tag).FullPath;

        obj_RemoteCallAction.RegistryValueName = this.listView_RemoteRegistry_Values.SelectedItems[0].Text;

        obj_RemoteCallAction.ModifyRegistryValue();

        this.treeView_RemoteRegistry_NodesTree.SelectedNode = ((TreeNode)this.listView_RemoteRegistry_Values.Tag);
    }

    private void button_RemoteRegistry_Refresh_Click(object sender, System.EventArgs e)
    {
        this.RefreshRemoteRegistryValuesContent();
    }


    private void treeView_RemoteRegistry_NodesTree_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            e.Cancel = true;

            return;
        }

        this.ExpandNecessaryRegistryNode(e.Node);
    }


    private void treeView_RemoteRegistry_NodesTree_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
    {
        e.Node.Nodes.Clear();
    }


    private void treeView_RemoteRegistry_NodesTree_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
    {
        this.textBox_RemoteRegistry_CurrentPath.Text = e.Node.FullPath;

        this.button_RemoteRegistry_Modify.Enabled = this.button_RemoteRegistry_RenameItem.Enabled = false;

        ChangeExpandButtonState(e.Node);

        if (e.Node.Parent == null)
        {
            this.button_RemoteRegistry_Delete.Enabled = this.menuItem_RemoteRegistry_DeleteKey.Enabled = false;
        }
        else
        {
            this.button_RemoteRegistry_Delete.Enabled = this.menuItem_RemoteRegistry_DeleteKey.Enabled = true;
        }

        if (!MainTcpClient.IsConnected) return;

        try
        {
            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            obj_RemoteCallAction.RegistryKeyFullName = e.Node.FullPath;

            ArrayList arrayList_RegistryKeyPath = new ArrayList();

            obj_RemoteCallAction.RegistryKeyPath = this.GetRegistryKeyPath(e.Node);

            new Thread(new ThreadStart(obj_RemoteCallAction.GetRegistryKeyValues)).Start();
        }

        catch (Exception exception_obj)
        {

        }
    }


    private void button_RemoteRegistry_Expand_Click(object sender, System.EventArgs e)
    {
        TreeNode treeNode_ToggleKey = null;

        if (this.treeView_RemoteRegistry_NodesTree.SelectedNode != null)
        {
            treeNode_ToggleKey = this.treeView_RemoteRegistry_NodesTree.SelectedNode;
        }

        if (((TreeNode)this.listView_RemoteRegistry_Values.Tag) != null)
        {
            treeNode_ToggleKey = ((TreeNode)this.listView_RemoteRegistry_Values.Tag);
        }

        if (treeNode_ToggleKey == null)
        {
            return;
        }

        treeNode_ToggleKey.Toggle();

        ChangeExpandButtonState(treeNode_ToggleKey);
    }


    private void treeView_RemoteRegistry_NodesTree_AfterCollapse(object sender, System.Windows.Forms.TreeViewEventArgs e)
    {
        ChangeExpandButtonState(e.Node);
    }


    private void button_RemoteRegistry_DeleteItem_Click(object sender, System.EventArgs e)
    {
        if (this.listView_RemoteRegistry_Values.SelectedItems.Count > 0)
        {
            if (MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(596, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            for (; this.listView_RemoteRegistry_Values.SelectedItems.Count != 0; )
            {
                DeleteRegistryValue(this.listView_RemoteRegistry_Values.SelectedItems[0].Index);

                this.listView_RemoteRegistry_Values.SelectedItems[0].Remove();
            }

            this.treeView_RemoteRegistry_NodesTree.SelectedNode = ((TreeNode)this.listView_RemoteRegistry_Values.Tag);

            return;
        }

        if (this.treeView_RemoteRegistry_NodesTree.SelectedNode != null)
        {
            DeleteRegistryKey(this.treeView_RemoteRegistry_NodesTree.SelectedNode);

            return;
        }
    }


    private void listView_RemoteRegistry_Values_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        this.treeView_RemoteRegistry_NodesTree.SelectedNode = null;

        this.button_RemoteRegistry_Modify.Enabled = this.button_RemoteRegistry_RenameItem.Enabled = true;

        this.button_RemoteRegistry_Delete.Enabled = this.button_RemoteRegistry_RenameItem.Enabled = true;
    }


    private void button_RemoteRegistry_CreateKey_Click(object sender, System.EventArgs e)
    {
        this.CreateNewRegistryKey((TreeNode)this.listView_RemoteRegistry_Values.Tag);
    }


    private void button_RemoteRegistry_CreateValue_Click(object sender, System.EventArgs e)
    {
        contextMenu_RemoteRegistry_NewValue.Show(this.tabPage_RemoteRegistry, new Point(this.button_RemoteRegistry_CreateValue.Location.X, this.button_RemoteRegistry_CreateValue.Location.Y + 23));
    }


    private void button_RemoteRegistry_RenameItem_Click(object sender, System.EventArgs e)
    {
        RenameRegistryValue();
    }


    private void button_RemoteRegistry_Modify_Click(object sender, System.EventArgs e)
    {
        ModifyRegistryValue();
    }


    public void RefreshRemoteRegistryValuesContent()
    {
        this.Invoke((MethodInvoker)delegate
        {
            if (this.treeView_RemoteRegistry_NodesTree.SelectedNode == null) return;

            if (!MainTcpClient.IsConnected)
            {
                MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            this.treeView_RemoteRegistry_NodesTree_BeforeSelect(this, new TreeViewCancelEventArgs(this.treeView_RemoteRegistry_NodesTree.SelectedNode, false, TreeViewAction.Expand));

            if (
                this.treeView_RemoteRegistry_NodesTree.SelectedNode.IsSelected != true ||
                this.treeView_RemoteRegistry_NodesTree.SelectedNode.IsExpanded != true ||
                this.treeView_RemoteRegistry_NodesTree.SelectedNode.Nodes.Count < 1
                ) return;

            try
            {
                this.treeView_RemoteRegistry_NodesTree.SelectedNode.Nodes.Clear();
                this.treeView_RemoteRegistry_NodesTree.SelectedNode.Nodes.Add("");

                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                obj_RemoteCallAction.RegistryKeyFullName = this.treeView_RemoteRegistry_NodesTree.SelectedNode.FullPath;

                obj_RemoteCallAction.RegistryKeyPath = this.GetRegistryKeyPath(this.treeView_RemoteRegistry_NodesTree.SelectedNode);

                new Thread(new ThreadStart(obj_RemoteCallAction.GetRegistrySubKeysList)).Start();
            }

            catch (Exception exception_obj)
            {

            }
        });
    }


    private void listView_RemoteRegistry_Values_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;

        if (this.listView_RemoteRegistry_Values.GetItemAt(e.X, e.Y) != null)
        {
            this.contextMenu_RemoteRegistry_ValueActions.Show(this.listView_RemoteRegistry_Values, new Point(e.X, e.Y));

            return;
        }

        this.contextMenu_RemoteRegistry_ValuesContextMenu.Show(this.listView_RemoteRegistry_Values, new Point(e.X, e.Y));

    }


    private void treeView_RemoteRegistry_NodesTree_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right || this.treeView_RemoteRegistry_NodesTree.GetNodeAt(new Point(e.X, e.Y)) == null) return;

        this.treeView_RemoteRegistry_NodesTree.SelectedNode = this.treeView_RemoteRegistry_NodesTree.GetNodeAt(new Point(e.X, e.Y));

        if (this.treeView_RemoteRegistry_NodesTree.SelectedNode.IsExpanded)
        {
            this.menuItem_RemoteRegistry_ToggleKeyState.Text = ClientStringFactory.GetString(584, ClientSettingsEnvironment.CurrentLanguage);
        }
        else
        {
            this.menuItem_RemoteRegistry_ToggleKeyState.Text = ClientStringFactory.GetString(583, ClientSettingsEnvironment.CurrentLanguage);
        }

        if (this.treeView_RemoteRegistry_NodesTree.SelectedNode.Nodes.Count > 0)
        {
            this.menuItem_RemoteRegistry_ToggleKeyState.Enabled = true;
        }
        else
        {
            this.menuItem_RemoteRegistry_ToggleKeyState.Enabled = false;
        }

        this.contextMenu_RemoteRegistry_KeysContextMenu.Show(this.treeView_RemoteRegistry_NodesTree, new Point(e.X, e.Y));
    }


    private void listView_RemoteRegistry_Values_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyData == Keys.Delete && this.listView_RemoteRegistry_Values.SelectedItems.Count > 0)
        {
            if (MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(596, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            for (; this.listView_RemoteRegistry_Values.SelectedItems.Count != 0; )
            {
                DeleteRegistryValue(this.listView_RemoteRegistry_Values.SelectedItems[0].Index);

                this.listView_RemoteRegistry_Values.SelectedItems[0].Remove();
            }

            this.treeView_RemoteRegistry_NodesTree.SelectedNode = ((TreeNode)this.listView_RemoteRegistry_Values.Tag);
        }
    }


    private void treeView_RemoteRegistry_NodesTree_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyData == Keys.Delete && this.treeView_RemoteRegistry_NodesTree.SelectedNode != null)
        {
            DeleteRegistryKey(this.treeView_RemoteRegistry_NodesTree.SelectedNode);
        }
    }


    private void listView_RemoteRegistry_Values_DoubleClick(object sender, System.EventArgs e)
    {
        ModifyRegistryValue();
    }

    private void menuItem_RemoteRegistryValueActions_Delete_Click(object sender, System.EventArgs e)
    {
        if (this.listView_RemoteRegistry_Values.SelectedItems.Count > 0)
        {
            if (MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(596, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            for (; this.listView_RemoteRegistry_Values.SelectedItems.Count != 0; )
            {
                DeleteRegistryValue(this.listView_RemoteRegistry_Values.SelectedItems[0].Index);

                this.listView_RemoteRegistry_Values.SelectedItems[0].Remove();
            }

            this.treeView_RemoteRegistry_NodesTree.SelectedNode = ((TreeNode)this.listView_RemoteRegistry_Values.Tag);

            return;
        }
    }


    private void menuItem_RemoteRegistryValueActions_Rename_Click(object sender, System.EventArgs e)
    {
        this.RenameRegistryValue();
    }


    private void menuItem_RemoteRegistryValueActions_Modify_Click(object sender, System.EventArgs e)
    {
        this.ModifyRegistryValue();
    }


    private void menuItem_RemoteRegistryValuesContextMenu_New_Key_Click(object sender, System.EventArgs e)
    {
        this.CreateNewRegistryKey((TreeNode)this.listView_RemoteRegistry_Values.Tag);
    }


    private void menuItem_RemoteRegistryValuesContextMenu_New_String_Click(object sender, System.EventArgs e)
    {
        CreateNewRegistryStringValue((TreeNode)this.listView_RemoteRegistry_Values.Tag);
    }


    private void menuItem_RemoteRegistryValuesContextMenu_New_DWORD_Click(object sender, System.EventArgs e)
    {
        CreateNewRegistryDwordValue((TreeNode)this.listView_RemoteRegistry_Values.Tag);
    }


    private void menuItem_RemoteRegistryValuesContextMenu_New_MultiString_Click(object sender, System.EventArgs e)
    {
        CreateNewRegistryMultiStringValue((TreeNode)this.listView_RemoteRegistry_Values.Tag);
    }


    private void menuItem_RemoteRegistry_ToggleKeyState_Click(object sender, System.EventArgs e)
    {
        if (this.treeView_RemoteRegistry_NodesTree.SelectedNode != null)
        {
            this.treeView_RemoteRegistry_NodesTree.SelectedNode.Toggle();
        }
    }


    private void menuItem_RemoteRegistry_NewItem_Key_Click(object sender, System.EventArgs e)
    {
        this.CreateNewRegistryKey((TreeNode)this.treeView_RemoteRegistry_NodesTree.SelectedNode);
    }


    private void menuItem_RemoteRegistry_NewItem_String_Click(object sender, System.EventArgs e)
    {
        CreateNewRegistryStringValue((TreeNode)this.treeView_RemoteRegistry_NodesTree.SelectedNode);
    }


    private void menuItem_RemoteRegistry_NewItem_MultiString_Click(object sender, System.EventArgs e)
    {
        CreateNewRegistryMultiStringValue((TreeNode)this.listView_RemoteRegistry_Values.Tag);
    }


    private void menuItem_RemoteRegistry_NewItem_DWORD_Click(object sender, System.EventArgs e)
    {
        CreateNewRegistryDwordValue((TreeNode)this.listView_RemoteRegistry_Values.Tag);
    }


    private void menuItem_RemoteRegistry_DeleteKey_Click(object sender, System.EventArgs e)
    {
        if (this.treeView_RemoteRegistry_NodesTree.SelectedNode != null)
        {
            DeleteRegistryKey(this.treeView_RemoteRegistry_NodesTree.SelectedNode);

            return;
        }
    }


    private void menuItem_RemoteRegistry_RenameKey_Click(object sender, System.EventArgs e)
    {

    }


    private void menuItem_RemoteRegistry_CopyKeyName_Click(object sender, System.EventArgs e)
    {
        if (this.treeView_RemoteRegistry_NodesTree.SelectedNode == null) return;

        Clipboard.SetDataObject(this.treeView_RemoteRegistry_NodesTree.SelectedNode.FullPath);
    }


    private void menuItem_RemoteRegistry_NewValue_String_Click(object sender, System.EventArgs e)
    {
        CreateNewRegistryStringValue((TreeNode)this.listView_RemoteRegistry_Values.Tag);
    }


    private void menuItem_RemoteRegistry_NewValue_MultiString_Click(object sender, System.EventArgs e)
    {
        CreateNewRegistryMultiStringValue((TreeNode)this.listView_RemoteRegistry_Values.Tag);
    }


    private void menuItem_RemoteRegistry_NewValue_DWORD_Click(object sender, System.EventArgs e)
    {
        CreateNewRegistryDwordValue((TreeNode)this.listView_RemoteRegistry_Values.Tag);
    }


    #endregion

    #region System State Manager Tab Environment

    private void button_SystemStateManager_PowerOff_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();
                obj_RemoteCallAction.ForcingTermination = ForcingTermination;
                obj_RemoteCallAction.ForcingTerminationIfHung = ForcingTerminationIfHung;
                new Thread(new ThreadStart(obj_RemoteCallAction.PowerOff)).Start();

            }
            catch (Exception exception_obj)
            {

            }
        }
    }

    private void button_SystemStateManager_ShutDown_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();
                obj_RemoteCallAction.ForcingTermination = ForcingTermination;
                obj_RemoteCallAction.ForcingTerminationIfHung = ForcingTerminationIfHung;
                new Thread(new ThreadStart(obj_RemoteCallAction.ShutDown)).Start();

            }
            catch (Exception exception_obj)
            {

            }
        }
    }

    private void button_SystemStateManager_Restart_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();
                obj_RemoteCallAction.ForcingTermination = ForcingTermination;
                obj_RemoteCallAction.ForcingTerminationIfHung = ForcingTerminationIfHung;
                new Thread(new ThreadStart(obj_RemoteCallAction.Restart)).Start();

            }

            catch (Exception exception_obj)
            {

            }
        }
    }

    private void button_SystemStateManager_UserLogOff_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();
                obj_RemoteCallAction.ForcingTermination = ForcingTermination;
                obj_RemoteCallAction.ForcingTerminationIfHung = ForcingTerminationIfHung;
                new Thread(new ThreadStart(obj_RemoteCallAction.UserLogOff)).Start();

            }
            catch (Exception exception_obj)
            {

            }
        }
    }

    private void button_SystemStateManager_StandBy_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();
                obj_RemoteCallAction.ForcedSuspension = ForcedSuspension;
                new Thread(new ThreadStart(obj_RemoteCallAction.StandBy)).Start();

            }
            catch (Exception exception_obj)
            {

            }
        }
    }

    private void button_SystemStateManager_Hiberate_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();
                obj_RemoteCallAction.ForcedSuspension = ForcedSuspension;
                new Thread(new ThreadStart(obj_RemoteCallAction.Hibernate)).Start();

            }
            catch (Exception exception_obj)
            {

            }
        }
    }

    private void button_SystemStateManager_LockWorkStation_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();
                new Thread(new ThreadStart(obj_RemoteCallAction.LockWorkStation)).Start();

            }
            catch (Exception exception_obj)
            {

            }
        }
    }


    #endregion

    #region Processes Manager Tab Environment

    private void listView_ProcessesManager_Processes_Click(object sender, System.EventArgs e)
    {
        this.comboBox_ProcessesManager_ProcessPriority.Text = this.listView_ProcessesManager_Processes.FocusedItem.SubItems[1].Text;
    }


    private void button_ProcessesManager_Refresh_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                ObjCopy.obj_RemoteCallAction.GetProcessList();
            }

            catch (Exception exception_obj)
            {

            }
        }
    }


    private void button_ProcessesManager_KillSelectedProcess_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (listView_ProcessesManager_Processes.SelectedItems.Count > 0 &&
            listView_ProcessesManager_Processes.Items.Count > 0 &&
            MainTcpClient.IsConnected)
        {
            try
            {
                MessageBoxIcon icon = MessageBoxIcon.Question;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(ClientStringFactory.GetString(225, ClientSettingsEnvironment.CurrentLanguage) + NameOfProcess + " (PID: " + PID + ") ?", "Kill Process", buttons, icon);

                if (result == DialogResult.Yes)
                {
                    RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();
                    obj_RemoteCallAction.PID = PID;
                    obj_RemoteCallAction.NameOfProcess = NameOfProcess;
                    new Thread(new ThreadStart(obj_RemoteCallAction.KillSelectedProcess)).Start();

                }
            }

            catch (Exception exception_obj)
            {

            }
        }

        if (listView_ProcessesManager_Processes.SelectedItems.Count == 0
            && listView_ProcessesManager_Processes.Items.Count > 0
            && MainTcpClient.IsConnected) MessageBox.Show(ClientStringFactory.GetString(232, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

        if (listView_ProcessesManager_Processes.Items.Count == 0
            && MainTcpClient.IsConnected) MessageBox.Show(ClientStringFactory.GetString(233, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));
    }


    private void button_ProcessesManager_ActivateWindowOfSelectedProcess_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (listView_ProcessesManager_Processes.SelectedItems.Count > 0 &&
            listView_ProcessesManager_Processes.Items.Count > 0 &&
            MainTcpClient.IsConnected)
        {
            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();
                obj_RemoteCallAction.PID = PID;
                obj_RemoteCallAction.NameOfProcess = NameOfProcess;
                new Thread(new ThreadStart(obj_RemoteCallAction.ActivateWindowOfSelectedProcess)).Start();

            }

            catch (Exception exception_obj)
            {

            }
        }

        if (listView_ProcessesManager_Processes.SelectedItems.Count == 0
            && listView_ProcessesManager_Processes.Items.Count > 0
            && MainTcpClient.IsConnected) MessageBox.Show(ClientStringFactory.GetString(232, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

        if (listView_ProcessesManager_Processes.Items.Count == 0
            && MainTcpClient.IsConnected) MessageBox.Show(ClientStringFactory.GetString(233, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));
    }

    private void comboBox_ProcessesManager_ProcessPriority_SelectionChangeCommitted(object sender, EventArgs e)
    {

    }

    private void comboBox_ProcessesManager_ProcessPriority_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }


        if (listView_ProcessesManager_Processes.Items.Count > 0 && listView_ProcessesManager_Processes.SelectedItems.Count > 0 &&
            SelectedPriorityOfProcess != listView_ProcessesManager_Processes.FocusedItem.SubItems[1].Text &&
            MainTcpClient.IsConnected)
        {
            try
            {
                if (DialogResult.Yes != MessageBox.Show(ClientStringFactory.GetString(206, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    SelectedPriorityOfProcess = listView_ProcessesManager_Processes.FocusedItem.SubItems[1].Text;
                    return;
                }

                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                obj_RemoteCallAction.PID = PID;
                obj_RemoteCallAction.NameOfProcess = NameOfProcess;
                obj_RemoteCallAction.SelectedPriorityOfProcess = SelectedPriorityOfProcess;

                new Thread(new ThreadStart(obj_RemoteCallAction.ChangeProcessPriority)).Start();

            }

            catch (Exception exception_obj)
            {

            }
        }
    }


    #endregion

    #region Remote Execute Tab Environment

    private void button_RemoteExecution_Execute_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                obj_RemoteCallAction.ExecutedNameOfFile = ExecutedNameOfFile;
                obj_RemoteCallAction.WorkingDirectory = WorkingDirectory;
                obj_RemoteCallAction.CommandLineArguments = CommandLineArguments;
                obj_RemoteCallAction.UseShellExecute = UseShellExecute;
                obj_RemoteCallAction.WindowStyleForExecutedFile = WindowStyleForExecutedFile;
                obj_RemoteCallAction.ExecuteWithoutWindowCreation = ExecuteWithoutWindowCreation;
                obj_RemoteCallAction.DisplayErrorDialog = DisplayErrorDialog;

                new Thread(new ThreadStart(obj_RemoteCallAction.ExecuteProcess)).Start();
            }

            catch (Exception exception_obj)
            {

            }
        }
    }


    public void AddPresetsToFastLaunch()
    {
        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items.Clear();

        for (int int_CycleCount = 0; int_CycleCount != 15; int_CycleCount++)
        {
            ListViewItem listViewItem_Preset = new ListViewItem("", int_CycleCount);

            listView_RemoteExecution_WorkingFolder_ListOfPresets.Items.Add(listViewItem_Preset);
        }

        listView_RemoteExecution_WorkingFolder_ListOfPresets.Columns[0].Text = ClientStringFactory.GetString(449, ClientSettingsEnvironment.CurrentLanguage);

        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items[0].Text = ClientStringFactory.GetString(450, ClientSettingsEnvironment.CurrentLanguage);
        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items[1].Text = ClientStringFactory.GetString(451, ClientSettingsEnvironment.CurrentLanguage);
        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items[2].Text = ClientStringFactory.GetString(452, ClientSettingsEnvironment.CurrentLanguage);
        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items[3].Text = ClientStringFactory.GetString(453, ClientSettingsEnvironment.CurrentLanguage);
        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items[4].Text = ClientStringFactory.GetString(454, ClientSettingsEnvironment.CurrentLanguage);
        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items[5].Text = ClientStringFactory.GetString(455, ClientSettingsEnvironment.CurrentLanguage);
        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items[6].Text = ClientStringFactory.GetString(456, ClientSettingsEnvironment.CurrentLanguage);
        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items[7].Text = ClientStringFactory.GetString(457, ClientSettingsEnvironment.CurrentLanguage);
        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items[8].Text = ClientStringFactory.GetString(458, ClientSettingsEnvironment.CurrentLanguage);
        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items[9].Text = ClientStringFactory.GetString(459, ClientSettingsEnvironment.CurrentLanguage);
        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items[10].Text = ClientStringFactory.GetString(460, ClientSettingsEnvironment.CurrentLanguage);
        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items[11].Text = ClientStringFactory.GetString(461, ClientSettingsEnvironment.CurrentLanguage);
        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items[12].Text = ClientStringFactory.GetString(462, ClientSettingsEnvironment.CurrentLanguage);
        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items[13].Text = ClientStringFactory.GetString(463, ClientSettingsEnvironment.CurrentLanguage);
        listView_RemoteExecution_WorkingFolder_ListOfPresets.Items[14].Text = ClientStringFactory.GetString(464, ClientSettingsEnvironment.CurrentLanguage);
    }


    private void textBox_RemoteExecution_CleanParameters_Click(object sender, System.EventArgs e)
    {
        ExecutedNameOfFile = WorkingDirectory = CommandLineArguments = String.Empty;
    }


    private void checkBox_RemoteExecution_UseShellExecute_CheckedChanged(object sender, System.EventArgs e)
    {
        if (checkBox_RemoteExecution_UseShellExecute.Checked == false)
        {
            if (checkBox_RemoteExecution_ShowErrorDialog.Checked == true) checkBox_RemoteExecution_ShowErrorDialog.Checked = false;
        }
    }


    private void checkBox_RemoteExecution_ShowErrorDialog_CheckedChanged(object sender, System.EventArgs e)
    {
        if (checkBox_RemoteExecution_ShowErrorDialog.Checked == true)
        {
            if (checkBox_RemoteExecution_UseShellExecute.Checked == false)
            {
                checkBox_RemoteExecution_UseShellExecute.Checked = true;
            }
        }
    }


    private void listView_RemoteExecution_WorkingFolder_ListOfPresets_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        try
        {
            switch (listView_RemoteExecution_WorkingFolder_ListOfPresets.SelectedItems[0].Index)
            {
                case 0:
                    {
                        ExecutedNameOfFile = "wab.exe";
                    }
                    break;

                case 1:
                    {
                        ExecutedNameOfFile = "calc.exe";
                    }
                    break;

                case 2:
                    {
                        ExecutedNameOfFile = "cleanmgr.exe";
                    }
                    break;

                case 3:
                    {
                        ExecutedNameOfFile = "cmd.exe";
                    }
                    break;

                case 4:
                    {
                        ExecutedNameOfFile = "dfrg.msc";
                    }
                    break;

                case 5:
                    {
                        ExecutedNameOfFile = "iexplore.exe";
                    }
                    break;

                case 6:
                    {
                        ExecutedNameOfFile = "notepad.exe";
                    }
                    break;

                case 7:
                    {
                        ExecutedNameOfFile = "osk.exe";
                    }
                    break;

                case 8:
                    {
                        ExecutedNameOfFile = "msimn.exe";
                    }
                    break;

                case 9:
                    {
                        ExecutedNameOfFile = "mspaint.exe";
                    }
                    break;

                case 10:
                    {
                        ExecutedNameOfFile = "sndrec32.exe";
                    }
                    break;

                case 11:
                    {
                        ExecutedNameOfFile = "msinfo32.exe";
                    }
                    break;

                case 12:
                    {
                        ExecutedNameOfFile = "taskmgr.exe";
                    }
                    break;

                case 13:
                    {
                        ExecutedNameOfFile = "sndvol32.exe";
                    }
                    break;

                case 14:
                    {
                        ExecutedNameOfFile = "wordpad.exe";
                    }
                    break;
            }
        }

        catch
        {
        }
    }


    private void button_DrivesManager_EjectCD_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                new Thread(new ThreadStart(new RemoteCallAction().EjectCD)).Start();
            }

            catch (Exception exception_obj)
            {

            }
        }
    }


    private void button_DrivesManager_CloseCD_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                new Thread(new ThreadStart(new RemoteCallAction().CloseCD)).Start();
            }

            catch (Exception exception_obj)
            {

            }
        }
    }


    #endregion

    #region Send Message Tab Environment

    private void button_Message_SendMessage_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

                obj_RemoteCallAction.SendMessage(MessageBoxCaption, MessageBoxText, MessageBoxIconIndex, MessageBoxButtonsCollection, InformingOfUserChoice);
            }

            catch (Exception exception_obj)
            {

            }
        }
    }

    #endregion

    #region Drives Manager Tab Environment

    private void button_DriversList_Refresh_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected)
        {

            try
            {
                new Thread(new ThreadStart(new RemoteCallAction().GetDriversList)).Start();
            }

            catch (Exception exception_obj)
            {

            }

        }
    }

    private void button_DrivesManager_Refresh_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {

            new Thread(new ThreadStart(new RemoteCallAction().GetDrivesInformation)).Start();

            new Thread(new ThreadStart(new RemoteCallAction().GetListOfExistingDrives)).Start();

        }

        catch (Exception exception_obj)
        {

        }
    }

    #endregion

    #region Display Tab Inveronment

    private void button_SingleImageCapture_Capture_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
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

        try
        {
            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            obj_RemoteCallAction.IndexOfCapturedImageFormat = IndexOfCapturedImageFormat;

            obj_RemoteCallAction.SourceOfScreenCaptureQuery = 0;

            new Thread(new ThreadStart(obj_RemoteCallAction.ReceiveCapturedScreen)).Start();
        }

        catch (Exception exception_obj)
        {

        }
    }

    private void button_Display_GetDisplaySettings_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            new Thread(new ThreadStart(new RemoteCallAction().GetDisplaySettings)).Start();
        }

        catch (Exception exception_obj)
        {

        }
    }

    private void button_Display_SetDisplaySettings_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            if (ObjCopy.obj_MainClientForm.GetSelectedScreenWidth() < 640 ||
                 ObjCopy.obj_MainClientForm.GetSelectedScreenHeight() < 480 ||
                 ObjCopy.obj_MainClientForm.CurrentDisplayColorQuality < 8 ||
                 ObjCopy.obj_MainClientForm.CurrentDisplayFrequency < 60)
            {
                return;
            }


            new Thread(new ThreadStart(new RemoteCallAction().SetDisplaySettings)).Start();
        }

        catch (Exception exception_obj)
        {

        }
    }

    private void trackBar_SingleImageCapture_Resolution_ValueChanged(object sender, System.EventArgs e)
    {
        ShowSelectedDisplaySettings(trackBar_DisplaySettings_Resolution.Value);
    }

    private void button_SingleImageCapture_StartCaptureUsingInterval_Click(object sender, System.EventArgs e)
    {
        thread_CaptureUsingInterval = new Thread(new ThreadStart(CaptureUsingInterval));
        thread_CaptureUsingInterval.Start();

        button_CaptureInInterval_StartCapture.Enabled = false;
        button_CaptureInInterval_StopCapture.Enabled = true;
    }

    private void button_SingleImageCapture_StopCaptureUsingInterval_Click(object sender, System.EventArgs e)
    {
        button_CaptureInInterval_StartCapture.Enabled = true;
        button_CaptureInInterval_StopCapture.Enabled = false;

        if (thread_CaptureUsingInterval != null) thread_CaptureUsingInterval.Abort();
    }

    private void comboBox_SingleImageCapture_ImageFormat_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (comboBox_SingleImageCapture_ImageFormat.SelectedIndex == 4)
        {
            this.comboBox_SingleImageCapture_CompressionFormat.Enabled =
                this.label_SingleImageCapture_CompressionFormat.Enabled = true;
        }
        else
        {
            this.comboBox_SingleImageCapture_CompressionFormat.Enabled =
                this.label_SingleImageCapture_CompressionFormat.Enabled = false;
        }


        if (comboBox_SingleImageCapture_ImageFormat.SelectedIndex == 2)
        {
            this.trackBar_SingleImageCapture_ImageQuality.Enabled =
                this.label_SingleImageCapture_ImageQuality.Enabled = true;
        }
        else
        {
            this.trackBar_SingleImageCapture_ImageQuality.Enabled =
                this.label_SingleImageCapture_ImageQuality.Enabled = false;
        }
    }

    private void comboBox_CaptureInInterval_ImageFormat_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (comboBox_CaptureInInterval_ImageFormat.SelectedIndex == 4)
        {
            this.comboBox_CaptureInInterval_CompressionFormat.Enabled =
                this.label_CaptureInInterval_CompressionFormat.Enabled = true;
        }
        else
        {
            this.comboBox_CaptureInInterval_CompressionFormat.Enabled =
                this.label_CaptureInInterval_CompressionFormat.Enabled = false;
        }


        if (comboBox_CaptureInInterval_ImageFormat.SelectedIndex == 2)
        {
            this.trackBar_CaptureInInterval_ImageQuality.Enabled =
                this.label_CaptureInInterval_ImageQuality.Enabled = true;
        }
        else
        {
            this.trackBar_CaptureInInterval_ImageQuality.Enabled =
                this.label_CaptureInInterval_ImageQuality.Enabled = false;
        }
    }

    public int GetSelectedScreenWidth()
    {
        return (int)this.Invoke((delegate_ReturningIntMethod)delegate
        {
            int int_NecessaryItem = trackBar_DisplaySettings_Resolution.Value;
            return (LocalAction.list_AvailableDisplayModes[LocalAction.list_UniqueDisplayResolutionsPosition[int_NecessaryItem - 1]]).int_ScreenWidth;
        });
    }

    public int GetSelectedScreenHeight()
    {
        return (int)this.Invoke((delegate_ReturningIntMethod)delegate
        {
            int int_NecessaryItem = trackBar_DisplaySettings_Resolution.Value;
            return LocalAction.list_AvailableDisplayModes[LocalAction.list_UniqueDisplayResolutionsPosition[int_NecessaryItem - 1]].int_ScreenHeight;
        });
    }

    public void ShowSelectedDisplaySettings(int int_NecessaryItem)
    {
        if (this.IsHandleCreated == false) return;

        this.Invoke((MethodInvoker)delegate
        {
            AvailableDisplayMode availableDisplayMode_NecessaryPosition = (LocalAction.list_AvailableDisplayModes[LocalAction.list_UniqueDisplayResolutionsPosition[int_NecessaryItem - 1]]);

            this.label_SingleImageCapture_CurrentResolution.Text = availableDisplayMode_NecessaryPosition.int_ScreenWidth.ToString() + " x " + availableDisplayMode_NecessaryPosition.int_ScreenHeight.ToString();

            this.comboBox_DisplaySettings_ColorQuality.Items.Clear();
            this.comboBox_DisplaySettings_ScreenRefreshRate.Items.Clear();

            int int_ElementsCount = LocalAction.list_AvailableDisplayModes.Count;

            for (int int_CycleCount = 0; int_ElementsCount != int_CycleCount; int_CycleCount++)
            {
                if (
                    availableDisplayMode_NecessaryPosition.int_ScreenWidth == LocalAction.list_AvailableDisplayModes[int_CycleCount].int_ScreenWidth
                    &&
                    availableDisplayMode_NecessaryPosition.int_ScreenHeight == LocalAction.list_AvailableDisplayModes[int_CycleCount].int_ScreenHeight
                    )
                {

                    if (!comboBox_DisplaySettings_ColorQuality.Items.Contains(LocalAction.list_AvailableDisplayModes[int_CycleCount].int_BPP.ToString()))
                    {
                        this.comboBox_DisplaySettings_ColorQuality.Items.Add(LocalAction.list_AvailableDisplayModes[int_CycleCount].int_BPP.ToString());
                    }

                    if (!comboBox_DisplaySettings_ScreenRefreshRate.Items.Contains(LocalAction.list_AvailableDisplayModes[int_CycleCount].int_DisplayFrequency.ToString()))
                    {
                        this.comboBox_DisplaySettings_ScreenRefreshRate.Items.Add(LocalAction.list_AvailableDisplayModes[int_CycleCount].int_DisplayFrequency.ToString());
                    }
                }
            }

            this.comboBox_DisplaySettings_ColorQuality.SelectedIndex = comboBox_DisplaySettings_ColorQuality.Items.Count - 1;
            this.comboBox_DisplaySettings_ScreenRefreshRate.SelectedIndex = comboBox_DisplaySettings_ScreenRefreshRate.Items.Count - 1;
        });
    }

    public static bool bool_CanSendCaptureRequest = true;

    static Thread thread_CaptureUsingInterval;

    private void CaptureUsingInterval()
    {
        int int_SleepCount = 0;

        this.Invoke((MethodInvoker)delegate
        {
            int_SleepCount = int.Parse(comboBox_CaptureInInterval_InetrvalSettings.Text);
        });

        Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;

        RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

        for (; ; )
        {
            while (bool_CanSendCaptureRequest != true) Thread.Sleep(250);

            if (!MainTcpClient.IsConnected)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    button_CaptureInInterval_StartCapture.Enabled = true;
                });

                MessageBox.Show(ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
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

            try
            {
                bool_CanSendCaptureRequest = false;

                this.Invoke((MethodInvoker)delegate
                 {
                     obj_RemoteCallAction.IndexOfCapturedImageFormat = comboBox_CaptureInInterval_ImageFormat.SelectedIndex;
                 });

                obj_RemoteCallAction.SourceOfScreenCaptureQuery = 1;

                new Thread(new ThreadStart(obj_RemoteCallAction.ReceiveCapturedScreen)).Start();

                Thread.Sleep(int_SleepCount * 1000);
            }

            catch (Exception)
            {
                this.Invoke((MethodInvoker)delegate
                 {
                     button_CaptureInInterval_StartCapture.Enabled = true;
                 });

                return;
            }
        }

    }

    #endregion


    private void button_InstalledPrograms_Refresh_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            new Thread(new ThreadStart(new RemoteCallAction().GetInstalledProgramsList)).Start();
        }

        catch (Exception exception_obj)
        {

        }
    }

    private void button_InstalledUpdates_Refresh_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            new Thread(new ThreadStart(new RemoteCallAction().GetInstalledUpdatesList)).Start();
        }

        catch (Exception exception_obj)
        {

        }
    }


    #region RTDV Tab Environment


    private void trackBar_RTDV_ReceivedImageSize_ValueChanged(object sender, System.EventArgs e)
    {
        if (comboBox_RTDV_SizeMode.SelectedIndex == 0)
        {
            switch (trackBar_RTDV_ReceivedImageSize.Value)
            {
                case 0:
                    ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                    ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(320, 240);
                    ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(320, 240);
                    break;

                case 1:
                    ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                    ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(400, 300);
                    ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(400, 300);
                    break;

                case 2:
                    ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                    ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(480, 360);
                    ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(480, 360);
                    break;

                case 3:
                    ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                    ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(512, 384);
                    ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(512, 384);
                    break;

                case 4:
                    ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                    ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(640, 480);
                    ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(640, 480);
                    break;

                case 5:
                    ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                    ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(720, 405);
                    ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(720, 405);
                    break;
            }
        }
        else
        {
            if (trackBar_RTDV_ReceivedImageSize.Value < 5)
            {
                ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(640, 480);
                ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(640, 480);
            }
            else
            {
                ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(720, 405);
                ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(720, 405);
            }
        }


        switch (trackBar_RTDV_ReceivedImageSize.Value)
        {
            case 0:
                this.label_RTDV_SelectedImageSize.Text = "4:3 | 320 x 240";
                break;

            case 1:
                this.label_RTDV_SelectedImageSize.Text = "4:3 | 400 x 300";
                break;

            case 2:
                this.label_RTDV_SelectedImageSize.Text = "4:3 | 480 x 360";
                break;

            case 3:
                this.label_RTDV_SelectedImageSize.Text = "4:3 | 512 x 384";
                break;

            case 4:
                this.label_RTDV_SelectedImageSize.Text = "4:3 | 640 x 480";
                break;

            case 5:
                this.label_RTDV_SelectedImageSize.Text = "16:9 | 720 x 405";
                break;
        }

        if (RTRDVEnabled)
        {
            new RemoteCallAction().StopRTDV();

            this.RTRDVEnabled = false;
        }

    }

    private void checkBox_RTDV_EnableRealTimeRemoteDisplayViewer_CheckedChanged(object sender, System.EventArgs e)
    {
        if (ObjCopy.obj_RTDVForm != null && RTRDVRealSize) ObjCopy.obj_RTDVForm.Close();

        if (!MainTcpClient.IsConnected)
        {
            if (checkBox_RTDV_EnableRealTimeRemoteDisplayViewer.Checked) MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            checkBox_RTDV_EnableRealTimeRemoteDisplayViewer.Checked = false;
            return;
        }

        if (this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer.Checked)
        {
          //  ObjCopy.obj_MiniRTDVForm.Show();

         //   ObjCopy.obj_MiniRTDVForm.BringToFront();

         //   new RemoteCallAction().StartRTRDV();
        }
        else new RemoteCallAction().StopRTDV();
    }

    private void numericUpDown_RTDV_MaxUpdatePerSec_ValueChanged(object sender, System.EventArgs e)
    {
        if (RTRDVEnabled)
        {
            new RemoteCallAction().StopRTDV();

            this.RTRDVEnabled = false;
        }
    }

    private void comboBox_RTDV_AmountOfRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RTRDVEnabled)
        {
            new RemoteCallAction().StopRTDV();

            this.RTRDVEnabled = false;
        }
    }

    private void trackBar_RTDV_TransferringAlgorithm_ValueChanged(object sender, EventArgs e)
    {
        switch (this.trackBar_RTDV_ImageCodingAlgorithm.Value)
        {
            case 0:
                this.label_RTDV_DataFormat.Text = ClientStringFactory.GetString(664, ClientSettingsEnvironment.CurrentLanguage);
                break;

            case 1:
                this.label_RTDV_DataFormat.Text = ClientStringFactory.GetString(665, ClientSettingsEnvironment.CurrentLanguage);
                break;

            case 2:
                this.label_RTDV_DataFormat.Text = ClientStringFactory.GetString(666, ClientSettingsEnvironment.CurrentLanguage);
                break;
        }

        if (RTRDVEnabled)
        {
            new RemoteCallAction().StopRTDV();

            this.RTRDVEnabled = false;
        }
    }



    private void comboBox_RTDV_SizeMode_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        switch (comboBox_RTDV_SizeMode.SelectedIndex)
        {
            case 0:
                {
                    switch (trackBar_RTDV_ReceivedImageSize.Value)
                    {
                        case 0:
                            ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                            ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(320, 240);
                            ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(320, 240);
                            break;

                        case 1:
                            ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                            ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(400, 300);
                            ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(400, 300);
                            break;

                        case 2:
                            ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                            ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(480, 360);
                            ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(480, 360);
                            break;

                        case 3:
                            ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                            ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(512, 384);
                            ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(512, 384);
                            break;

                        case 4:
                            ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                            ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(640, 480);
                            ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(640, 480);
                            break;

                        case 5:
                            ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                            ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(720, 405);
                            ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(720, 405);
                            break;
                    }
                }
                break;

            case 1:
                {
                    if (trackBar_RTDV_ReceivedImageSize.Value < 5)
                    {
                        ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                        ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(640, 480);
                        ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(640, 480);
                    }
                    else
                    {
                        ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                        ObjCopy.obj_MiniRTDVForm.MiniRemoteDisplay.ClientSize = new Size(720, 405);
                        ObjCopy.obj_MiniRTDVForm.ClientSize = new Size(720, 405);
                    }
                }
                break;
        }
    }

    private void checkBox_RTDV_RealSize_CheckedChanged(object sender, System.EventArgs e)
    {
        try
        {
            this.groupBox_RTDV_AdditionalParameters.Enabled = !this.checkBox_RTDV_RealSize.Checked;

            if (this.checkBox_RTDV_RealSize.Checked == true && RTRDVEnabled == true)
            {
                //	new RemoteCallAction().StopRTDV();

                if (ObjCopy.obj_RTDVForm == null)
                {
                    ObjCopy.obj_RTDVForm = new RTDVForm();
                }
                ObjCopy.obj_RTDVForm.Location = new System.Drawing.Point(0, 0);

                ObjCopy.obj_RTDVForm.Show();

                ObjCopy.obj_RTDVForm.BringToFront();

                ObjCopy.obj_MiniRTDVForm.Hide();

                //	new RemoteCallAction().StartRTRDV();			
            }

            else if (RTRDVEnabled == true)
            {
                //		new RemoteCallAction().StopRTDV();

                if (ObjCopy.obj_RTDVForm != null)
                {
                    ObjCopy.obj_RTDVForm.Close();

                    ObjCopy.obj_RTDVForm = null;
                }


            //!!    ObjCopy.obj_MiniRTDVForm.Show();

                	//!!	new RemoteCallAction().StartRTRDV();
            }
        }
        catch { }
    }


    private void button_RTDV_GetRemoteClipboardData_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                new RemoteCallAction().GetRemoteClipboardTextData();
            }

            catch (Exception exception_obj)
            {

            }
        }
    }

    private void button_RTDV_SetRemoteClipboardData_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                new RemoteCallAction().SetRemoteClipboardTextData();
            }

            catch (Exception exception_obj)
            {

            }
        }
    }


    private void checkBox_RTDV_HideMyCursor_CheckedChanged(object sender, System.EventArgs e)
    {
        ClientSettingsEnvironment.HideLocalCursorOnMiniRTDV = checkBox_RTDV_HideMyCursor.Checked;
    }


    private void checkBox_RTDV_ShowRemoteCursor_CheckedChanged(object sender, System.EventArgs e)
    {
        ClientSettingsEnvironment.ShowRemoteCursorInRTDV = checkBox_RTDV_ShowRemoteCursor.Checked;
    }


    public bool RTDVIsAllowControl
    {
        set
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.checkBox_RTDV_AllowControl.Checked = value;
            });
        }

        get
        {
            if (this.IsHandleCreated == false) return false;

            return (bool)this.Invoke((delegate_ReturningBoolMethod)delegate
            {
                return this.checkBox_RTDV_AllowControl.Checked;
            });
        }
    }


    private void checkBox_NetworkControl_UseProxy_CheckedChanged(object sender, System.EventArgs e)
    {
        foreach (Control control_Current in groupBox_NetworkControl_ProxySettings.Controls)
        {
            control_Current.Enabled = checkBox_ProxySettings_UseProxy.Checked;
        }

        checkBox_ProxySettings_UseProxy.Enabled = true;

        if (listBox_ProxySettings_ProxyType.SelectedIndex == 0) checkBox_ProxySettings_Authentication.Enabled = false;
        if (checkBox_ProxySettings_UseProxy.Checked) checkBox_ProxySettings_Authentication_CheckedChanged(null, null);
    }

    private void checkBox_ProxySettings_Authentication_CheckedChanged(object sender, System.EventArgs e)
    {
        label_ProxySettings_Socks5UserName.Enabled =
            label_ProxySettings_Socks5Password.Enabled =
            textBox_ProxySettings_Socks5UserName.Enabled =
            textBox_ProxySettings_Socks5Password.Enabled =
            (checkBox_ProxySettings_Authentication.Checked && checkBox_ProxySettings_Authentication.Enabled);
    }


    private void button_RTDV_SendKeys_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        contextMenu_RTDV_SendKeys.Show(tabPage_RTDV, new Point(button_RTDV_SendKeys.Location.X + button_RTDV_SendKeys.Size.Width, button_RTDV_SendKeys.Location.Y));
    }


    private void menuItem_AltF12_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        new RemoteCallAction().SetSequenceOfTwoKeysKeyboardEvent(1);
    }

    private void menuItem_CtrlEsc_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        new RemoteCallAction().SetSequenceOfTwoKeysKeyboardEvent(2);
    }

    private void menuItem_AltCtrlF12_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        new RemoteCallAction().SetSequenceOfThreeKeysKeyboardEvent(1);
    }

    private void menuItem_F12_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        new RemoteCallAction().SetSingleKeyKeyboardEvent(1, 123, Keys.None);
    }

    private void menuItem_TAB_Click(object sender, System.EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        new RemoteCallAction().SetSingleKeyKeyboardEvent(1, 9, Keys.None);
    }

    #endregion

    #region Clipboard Manager Environment


    private void button_ClipboardManager_ClearRemoteClipboard_Click(object sender, EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            if (this.checkBox_ClipboardManager_ShowWarnings.Checked && DialogResult.No == MessageBox.Show(ClientStringFactory.GetString(676, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            obj_RemoteCallAction.ClearRemoteClipboard();
        }

        catch (Exception exception_obj)
        {

        }
    }

    private void button_ClipboardManager_ClearLocalClipboard_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.checkBox_ClipboardManager_ShowWarnings.Checked && DialogResult.No == MessageBox.Show(ClientStringFactory.GetString(672, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            Clipboard.Clear();
        }

        catch (Exception exception_obj)
        {

        }
    }


    private void button_ClipboardManager_PreviewLocalClipboard_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.checkBox_ClipboardManager_ShowWarnings.Checked && DialogResult.No == MessageBox.Show(ClientStringFactory.GetString(673, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            if (Clipboard.ContainsImage() == true || Clipboard.ContainsText() == true || Clipboard.ContainsFileDropList() == true)
            {
                ObjCopy.obj_MainClientForm.ClipboardPreviewImageData = new Bitmap(1, 1);

                ObjCopy.obj_MainClientForm.ClipboardPreviewTextData = string.Empty;

                this.listView_ClipboardManager_FileDropList.Items.Clear();
            }

            if (Clipboard.ContainsImage() == true)
            {
                Image image_ClipboardImage = Clipboard.GetImage();

                if (this.pictureBox_ClipboardManager_Image.ClientSize.Width > image_ClipboardImage.Size.Width &&
                    this.pictureBox_ClipboardManager_Image.ClientSize.Height > image_ClipboardImage.Size.Height)
                {
                    this.pictureBox_ClipboardManager_Image.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                else
                {
                    this.pictureBox_ClipboardManager_Image.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                this.pictureBox_ClipboardManager_Image.Image = Clipboard.GetImage();

                switch (this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode.SelectedIndex)
                {
                    case 0:
                        this.pictureBox_ClipboardManager_Image.SizeMode = PictureBoxSizeMode.AutoSize;
                        break;

                    case 1:
                        this.pictureBox_ClipboardManager_Image.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;

                    case 2:
                        this.pictureBox_ClipboardManager_Image.SizeMode = PictureBoxSizeMode.CenterImage;
                        break;
                }
            }

            if (Clipboard.ContainsText() == true)
            {
                this.richTextBox_ClipboardManager_TextData.Text = Clipboard.GetText();
            }

            if (Clipboard.ContainsFileDropList() == true)
            {
                System.Collections.Specialized.StringCollection stringCollection_FileDropList = Clipboard.GetFileDropList();

                foreach (String string_obj in stringCollection_FileDropList)
                {
                    this.listView_ClipboardManager_FileDropList.Items.Add(string_obj);
                }
            }
        }

        catch (Exception exception_obj)
        {

        }
    }

    private void button_ClipboardManager_PreviewRemoteClipboard_Click(object sender, EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            if (this.checkBox_ClipboardManager_ShowWarnings.Checked && DialogResult.No == MessageBox.Show(ClientStringFactory.GetString(674, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            obj_RemoteCallAction.GetRemoteClipboardData();
        }

        catch (Exception exception_obj)
        {

        }
    }


    private void button_RemoteClipboardImageEnv_SendImage_Click(object sender, EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            OpenFileDialog openFileDialog_obj = new OpenFileDialog();

            openFileDialog_obj.Multiselect = false;

            openFileDialog_obj.DefaultExt = "jpg";

            openFileDialog_obj.SupportMultiDottedExtensions = true;

            openFileDialog_obj.AddExtension = true;

            openFileDialog_obj.Filter = "Bitmap files(*.bmp)|*.bmp|Jpeg files(*.jpg)|*.jpg|Gif files(*.gif)|*.gif|TIFF files(*.tiff)|*.tiff|PNG files(*.png)|*.png";

            openFileDialog_obj.FilterIndex = 2;

            openFileDialog_obj.ShowDialog();

            Image image_ImageForRemoteClipboard = Image.FromFile(openFileDialog_obj.FileName);

            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            obj_RemoteCallAction.SendImageToRemoteClipboard(image_ImageForRemoteClipboard);
            
            image_ImageForRemoteClipboard.Dispose();

            openFileDialog_obj.Dispose();
        }

        catch
        {
        }
    }

    private void button_RemoteClipboardImageEnv_SaveImageToDisk_Click(object sender, EventArgs e)
    {
        if (this.pictureBox_ClipboardManager_Image.Image != null && this.pictureBox_ClipboardManager_Image.Size.Width > 1)
        {
            SaveFileDialog saveFileDialog_obj = new SaveFileDialog();

            saveFileDialog_obj.DefaultExt = "jpg";

            saveFileDialog_obj.SupportMultiDottedExtensions = true;

            saveFileDialog_obj.AddExtension = true;

            saveFileDialog_obj.Filter = "Bitmap files(*.bmp)|*.bmp |Jpeg files(*.jpg)|*.jpg|Gif files(*.gif)|*.gif|TIFF files(*.tiff)|*.tiff|PNG files(*.png)|*.png";

            saveFileDialog_obj.FileName = "image";

            DialogResult dialogResult_obj = saveFileDialog_obj.ShowDialog();

            if (dialogResult_obj == DialogResult.OK)
            {
                ImageFormat imageFormat_SavingFormat = null;

                switch (saveFileDialog_obj.FilterIndex)
                {
                    case 1:
                        imageFormat_SavingFormat = ImageFormat.Bmp;
                        break;

                    case 2:
                        imageFormat_SavingFormat = ImageFormat.Jpeg;
                        break;

                    case 3:
                        imageFormat_SavingFormat = ImageFormat.Gif;
                        break;

                    case 4:
                        imageFormat_SavingFormat = ImageFormat.Tiff;
                        break;

                    case 5:
                        imageFormat_SavingFormat = ImageFormat.Png;
                        break;

                    default:
                        imageFormat_SavingFormat = ImageFormat.Jpeg;
                        break;
                }

                this.pictureBox_ClipboardManager_Image.Image.Save(saveFileDialog_obj.FileName, imageFormat_SavingFormat);
            }
        }
    }


    private void button_ClipboardManager_RefreshClipboardsTypeInfo_Click(object sender, EventArgs e)
    {
        RefreshClipboardsTypeInfo();
    }

    private void button_ClipboardManager_Remote2LocalSync_Click(object sender, EventArgs e)
    {
        try
        {
            if (Clipboard.ContainsFileDropList() == false && Clipboard.ContainsImage() == false && Clipboard.ContainsText() == false)
            {
                this.textBox_ClipboardManager_LocalClipboardType.Text = ClientStringFactory.GetString(680, ClientSettingsEnvironment.CurrentLanguage);
            }

            if (Clipboard.ContainsImage() == true)
            {
                this.textBox_ClipboardManager_LocalClipboardType.Text = ClientStringFactory.GetString(677, ClientSettingsEnvironment.CurrentLanguage);
            }

            if (Clipboard.ContainsText() == true)
            {
                this.textBox_ClipboardManager_LocalClipboardType.Text = ClientStringFactory.GetString(678, ClientSettingsEnvironment.CurrentLanguage);
            }

            if (Clipboard.ContainsFileDropList() == true)
            {
                this.textBox_ClipboardManager_LocalClipboardType.Text = ClientStringFactory.GetString(679, ClientSettingsEnvironment.CurrentLanguage);
            }

            if (this.pictureBox_ClipboardManager_Image.Image != null && this.pictureBox_ClipboardManager_Image.Size.Width > 1)
            {
                Clipboard.SetImage(this.pictureBox_ClipboardManager_Image.Image);
            }

            if (this.ClipboardPreviewTextData != null && this.ClipboardPreviewTextData.Length > 0)
            {
                Clipboard.SetText(this.ClipboardPreviewTextData);
            }

            if (this.listView_ClipboardManager_FileDropList.Items.Count > 0)
            {
                System.Collections.Specialized.StringCollection stringCollection_FileDropList = new System.Collections.Specialized.StringCollection();

                foreach (ListViewItem listViewItem_FileDropListItem in this.listView_ClipboardManager_FileDropList.Items)
                {
                    stringCollection_FileDropList.Add(listViewItem_FileDropListItem.Text);
                }

                Clipboard.SetFileDropList(stringCollection_FileDropList);
            }

            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            obj_RemoteCallAction.GetRemoteClipboardData();
        }

        catch (Exception exception_obj)
        {

        }
    }

    private void button_ClipboardManager_Local2RemoteSync_Click(object sender, EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            obj_RemoteCallAction.Local2RemoteClipboardSync();
        }

        catch (Exception exception_obj)
        {

        }
    }



    private void comboBox_RemoteClipboardImageSettings_ImageFormat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.comboBox_RemoteClipboardImageSettings_ImageFormat.SelectedIndex == 4)
        {
            this.comboBox_RemoteClipboardImageSettings_CompressionFormat.Enabled =
                this.label_RemoteClipboardImageSettings_CompressionFormat.Enabled = true;
        }
        else
        {
            this.comboBox_RemoteClipboardImageSettings_CompressionFormat.Enabled =
                this.label_RemoteClipboardImageSettings_CompressionFormat.Enabled = false;
        }

        if (this.comboBox_RemoteClipboardImageSettings_ImageFormat.SelectedIndex == 2)
        {
            this.trackBar_RemoteClipboardImageSettings_ImageQuality.Enabled =
                this.label_RemoteClipboardImageSettings_ImageQuality.Enabled = true;
        }
        else
        {
            this.trackBar_RemoteClipboardImageSettings_ImageQuality.Enabled =
                this.label_RemoteClipboardImageSettings_ImageQuality.Enabled = false;
        }
    }



    private void comboBox_RemoteClipboardImageSettings_PreviewSizeMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode.SelectedIndex)
        {
            case 0:
                this.pictureBox_ClipboardManager_Image.SizeMode = PictureBoxSizeMode.AutoSize;
                break;

            case 1:
                this.pictureBox_ClipboardManager_Image.SizeMode = PictureBoxSizeMode.StretchImage;
                break;

            case 2:
                this.pictureBox_ClipboardManager_Image.SizeMode = PictureBoxSizeMode.CenterImage;
                break;
        }

        this.pictureBox_ClipboardManager_Image.Size = new System.Drawing.Size(360, 254);
    }

    public void RefreshClipboardsTypeInfo()
    {
        if (Clipboard.ContainsFileDropList() == false && Clipboard.ContainsImage() == false && Clipboard.ContainsText() == false)
        {
            this.LocalClipboardType = ClientStringFactory.GetString(680, ClientSettingsEnvironment.CurrentLanguage);
        }

        if (Clipboard.ContainsImage() == true)
        {
            this.LocalClipboardType = ClientStringFactory.GetString(677, ClientSettingsEnvironment.CurrentLanguage);
        }

        if (Clipboard.ContainsText() == true)
        {
            this.LocalClipboardType = ClientStringFactory.GetString(678, ClientSettingsEnvironment.CurrentLanguage);
        }

        if (Clipboard.ContainsFileDropList() == true)
        {
            this.LocalClipboardType = ClientStringFactory.GetString(679, ClientSettingsEnvironment.CurrentLanguage);
        }

        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {
            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            obj_RemoteCallAction.GetRemoteClipboardDataType();
        }

        catch (Exception exception_obj)
        {

        }
    }

    object object_ClipboardTypeInfoThreadIndicator = new object();

    public void RefreshClipboardsTypeInfoInInterval()
    {
        if (this.RefreshClipboardsTypeInfoInterval == 0 || MainTcpClient.IsConnected == false)
        {
            return;
        }

        for (; ; )
        {
            if (Monitor.TryEnter(object_ClipboardTypeInfoThreadIndicator, 1000) == false) return;

            Monitor.Enter(object_ClipboardTypeInfoThreadIndicator);

            if (this.RefreshClipboardsTypeInfoInterval == 0 || MainTcpClient.IsConnected == false)
            {
                Monitor.Exit(object_ClipboardTypeInfoThreadIndicator);

                Monitor.PulseAll(object_ClipboardTypeInfoThreadIndicator);

                return;
            }

            RefreshClipboardsTypeInfo();

            switch (this.RefreshClipboardsTypeInfoInterval)
            {
                case 1:
                    Thread.Sleep(5000);
                    break;

                case 2:
                    Thread.Sleep(10000);
                    break;

                case 3:
                    Thread.Sleep(15000);
                    break;

                case 4:
                    Thread.Sleep(20000);
                    break;

                case 5:
                    Thread.Sleep(25000);
                    break;

                case 6:
                    Thread.Sleep(30000);
                    break;
            }
        }
    }

    private void comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval_SelectedIndexChanged(object sender, EventArgs e)
    {
        Thread thread_obj = new Thread(new ThreadStart(this.RefreshClipboardsTypeInfoInInterval));

        thread_obj.SetApartmentState(ApartmentState.STA);

        thread_obj.Start();
    }


    #endregion

    public string SpreadToHundreds(string string_NecessaryString)
    {
        return (string)this.Invoke((delegate_ReturningStringMethod)delegate
        {
            for (int int_LastDotPosition = string_NecessaryString.Length; int_LastDotPosition - 3 >= 1; int_LastDotPosition -= 3)
            {
                string_NecessaryString = string_NecessaryString.Insert(int_LastDotPosition - 3, ", ");
            }

            return string_NecessaryString;
        });
    }

    #region Refresh JurikSoft Servers List Environment

    private void button_ServersList_Refresh_Click(object sender, System.EventArgs e)
    {
        Thread thread_RefreshJurikSoftServersList = new Thread(new ThreadStart(RefreshJurikSoftServersList));

        thread_RefreshJurikSoftServersList.Start();
    }


    TcpClient tcpClient_LinkToCloseByTimeOut = null;

    int int_GlobalConnectionTimeOutMS = 0;

    int GlobalConnectionTimeOutMS
    {
        get
        {
            return int_GlobalConnectionTimeOutMS;
        }

        set
        {
            int_GlobalConnectionTimeOutMS = value;
        }
    }


    private void ProxyProvider_SendingSocks4ConnectionRequest()
    {

    }

    private void ProxyProvider_SendingSocks5AuthenticationRequest()
    {

    }

    private void ProxyProvider_SendingSocks5ConnectionRequest()
    {

    }

    private void ProxyProvider_SendingSocks5RequestDetails()
    {

    }


    private void ProxyProvider_WaitingForReplyToSocks4ConnectionRequest()
    {

    }

    private void ProxyProvider_WaitingForReplyToSocks5AuthenticationRequest()
    {

    }

    private void ProxyProvider_WaitingForReplyToSocks5ConnectionRequest()
    {

    }

    private void ProxyProvider_WaitingForReplyToSocks5RequestDetails()
    {

    }


    protected void ConnectionTimeOutWatcher()
    {
        if (GlobalConnectionTimeOutMS <= 0 || tcpClient_LinkToCloseByTimeOut == null) return;

        int int_InternalTimeOut = 0;
        while (int_InternalTimeOut <= GlobalConnectionTimeOutMS)
        {
            Thread.Sleep(10);
            int_InternalTimeOut += 10;
        }

        if (tcpClient_LinkToCloseByTimeOut != null) tcpClient_LinkToCloseByTimeOut.Close();
    }


    public void RefreshJurikSoftServersList()
    {
        lock (this)
        {
            this.button_ServersList_Refresh.Enabled = false;

            TcpClient tcpClient_MainClient = new TcpClient();

            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersDataTable jurikSoftServersDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers;

            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings;

            int int_ProxyServerRowIndex = 0;

            bool bool_UseProxyServer = false;

            int int_ServerPort = 0;
            string string_ServerHost = string.Empty;

            string string_LoginForConnection = string.Empty;
            string string_PasswordForConnection = string.Empty;

            string string_ProxyHost = string.Empty;
            int int_ProxyPort = 0;

            int int_ProxyTimeOut = 0;

            int int_ProxyTypeIndex = 0;

            bool bool_UseProxyResolveHostNames = false;
            bool bool_UseAuthentication = false;

            string string_Socks5UserName = string.Empty;
            string string_Socks5Password = string.Empty;


            for (int int_CycleCount = 0; int_CycleCount != jurikSoftServersDataTable_obj.Rows.Count; int_CycleCount++)
            {
                try
                {
                    tcpClient_MainClient = new TcpClient();

                    bool_UseProxyServer = (bool)jurikSoftServersDataTable_obj.Rows[int_CycleCount][jurikSoftServersDataTable_obj.UseProxyServerColumn];

                    string_ServerHost = (string)jurikSoftServersDataTable_obj.Rows[int_CycleCount][jurikSoftServersDataTable_obj.ServerHostColumn];
                    int_ServerPort = (int)jurikSoftServersDataTable_obj.Rows[int_CycleCount][jurikSoftServersDataTable_obj.ServerPortColumn];
                    string_LoginForConnection = (string)jurikSoftServersDataTable_obj.Rows[int_CycleCount][jurikSoftServersDataTable_obj.LoginColumn];
                    string_PasswordForConnection = (string)jurikSoftServersDataTable_obj.Rows[int_CycleCount][jurikSoftServersDataTable_obj.PasswordColumn];

                    if (bool_UseProxyServer == true)
                    {
                        int_ProxyServerRowIndex = (int)jurikSoftServersDataTable_obj.Rows[int_CycleCount][jurikSoftServersDataTable_obj.ProxyServerIDColumn];

                        string_ProxyHost = (string)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.ProxyHostColumn];
                        int_ProxyPort = (int)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.ProxyPortColumn];
                        int_ProxyTimeOut = (int)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.ProxyTimeOutColumn];

                        int_ProxyTypeIndex = (int)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.ProxyTypeColumn];
                        int_ProxyTimeOut = (int)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.ProxyTimeOutColumn];
                        bool_UseProxyResolveHostNames = (bool)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.UseProxyToResolveHostNamesColumn];
                        bool_UseAuthentication = (bool)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.UseAuthenticationColumn];

                        string_Socks5UserName = (string)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.LoginColumn];
                        string_Socks5Password = (string)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.PasswordColumn];
                    }

                    if (bool_UseProxyServer == false)
                    {
                        tcpClient_LinkToCloseByTimeOut = tcpClient_MainClient;
                        GlobalConnectionTimeOutMS = 15000;

                        Thread thread_ConnectionTimeOutWatcher = new Thread(new ThreadStart(ConnectionTimeOutWatcher));

                        thread_ConnectionTimeOutWatcher.Start();

                        tcpClient_MainClient.Connect(string_ServerHost, int_ServerPort);

                        thread_ConnectionTimeOutWatcher.Abort();

                        this.listView_ServersList_ServersList.Items[int_CycleCount].ImageIndex = 0;
                    }
                    else
                    {
                        JurikSoft.Proxy.ProxyProvider proxyProvider_obj = new JurikSoft.Proxy.ProxyProvider();

                        proxyProvider_obj.SendingSocks4ConnectionRequest += new JurikSoft.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_SendingSocks4ConnectionRequest);
                        proxyProvider_obj.SendingSocks5AuthenticationRequest += new JurikSoft.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_SendingSocks5AuthenticationRequest);
                        proxyProvider_obj.SendingSocks5ConnectionRequest += new JurikSoft.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_SendingSocks5ConnectionRequest);
                        proxyProvider_obj.SendingSocks5RequestDetails += new JurikSoft.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_SendingSocks5RequestDetails);

                        proxyProvider_obj.WaitingForReplyToSocks4ConnectionRequest += new JurikSoft.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_WaitingForReplyToSocks4ConnectionRequest);
                        proxyProvider_obj.WaitingForReplyToSocks5AuthenticationRequest += new JurikSoft.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_WaitingForReplyToSocks5AuthenticationRequest);
                        proxyProvider_obj.WaitingForReplyToSocks5ConnectionRequest += new JurikSoft.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_WaitingForReplyToSocks5ConnectionRequest);
                        proxyProvider_obj.WaitingForReplyToSocks5RequestDetails += new JurikSoft.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_WaitingForReplyToSocks5RequestDetails);

                        if (int_ProxyTypeIndex < 0)
                        {
                            return;
                        }

                        JurikSoft.Proxy.ProxyProvider.SerialNumber = "4688445487";
                        JurikSoft.Proxy.ProxyProvider.RegistrationName = "JurikSoft";

                        if (int_ProxyTypeIndex == 0)
                            proxyProvider_obj.ConnectThroughSocks4Proxy(ref tcpClient_MainClient, string_ServerHost, int_ServerPort, string_ProxyHost, int_ProxyPort, bool_UseProxyResolveHostNames, int_ProxyTimeOut);

                        if (int_ProxyTypeIndex == 1)
                        {
                            if (!bool_UseAuthentication)
                                proxyProvider_obj.ConnectThroughSocks5Proxy(ref tcpClient_MainClient, string_ServerHost, int_ServerPort, string_ProxyHost, int_ProxyPort, bool_UseProxyResolveHostNames, int_ProxyTimeOut);

                            if (bool_UseAuthentication)
                                proxyProvider_obj.ConnectThroughSocks5Proxy(ref tcpClient_MainClient, string_ServerHost, int_ServerPort, string_ProxyHost, int_ProxyPort, string_Socks5UserName, string_Socks5Password, bool_UseProxyResolveHostNames, int_ProxyTimeOut);
                        }

                        if (int_ProxyTypeIndex == 2)
                        {
                            if (!bool_UseAuthentication)
                                proxyProvider_obj.ConnectThroughHTTPSProxy(ref tcpClient_MainClient, string_ServerHost, int_ServerPort, string_ProxyHost, int_ProxyPort, bool_UseProxyResolveHostNames, int_ProxyTimeOut);

                            if (bool_UseAuthentication)
                                proxyProvider_obj.ConnectThroughHTTPSProxy(ref tcpClient_MainClient, string_ServerHost, int_ServerPort, string_ProxyHost, int_ProxyPort, string_Socks5UserName, string_Socks5Password, bool_UseProxyResolveHostNames, int_ProxyTimeOut);
                        }
                    }

                    tcpClient_MainClient.GetStream().WriteByte(0);
                }

                catch
                {
                    this.listView_ServersList_ServersList.Items[int_CycleCount].ImageIndex = 1;

                    continue;
                }

                finally
                {
                    tcpClient_MainClient.Close();
                }
            }
        }

        this.button_ServersList_Refresh.Enabled = true;
    }




    private void ApplySelectedJurikSoftServerFromList()
    {
        if (this.listView_ServersList_ServersList.SelectedItems.Count != 1) return;

        int int_ProxyServerRowIndex = 0, int_JurikSoftServerRowIndex = this.listView_ServersList_ServersList.SelectedItems[0].Index;

        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersDataTable jurikSoftServersDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers;

        bool bool_UseProxyServer = (bool)jurikSoftServersDataTable_obj.Rows[int_JurikSoftServerRowIndex][jurikSoftServersDataTable_obj.UseProxyServerColumn];

        if (bool_UseProxyServer == true)
        {
            int_ProxyServerRowIndex = (int)jurikSoftServersDataTable_obj.Rows[int_JurikSoftServerRowIndex][jurikSoftServersDataTable_obj.ProxyServerIDColumn];
        }

        this.ServerHost = (string)jurikSoftServersDataTable_obj.Rows[int_JurikSoftServerRowIndex][jurikSoftServersDataTable_obj.ServerHostColumn];
        this.ServerPort = (int)jurikSoftServersDataTable_obj.Rows[int_JurikSoftServerRowIndex][jurikSoftServersDataTable_obj.ServerPortColumn];
        this.LoginForConnection = (string)jurikSoftServersDataTable_obj.Rows[int_JurikSoftServerRowIndex][jurikSoftServersDataTable_obj.LoginColumn];
        this.PasswordForConnection = (string)jurikSoftServersDataTable_obj.Rows[int_JurikSoftServerRowIndex][jurikSoftServersDataTable_obj.PasswordColumn];


        if (bool_UseProxyServer == false) return;

        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings;

        this.UseProxyServer = true;

        this.ProxyHost = (string)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.ProxyHostColumn];
        this.ProxyPort = (int)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.ProxyPortColumn];
        this.ProxyTimeOut = (int)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.ProxyTimeOutColumn];

        this.ProxyTypeIndex = (int)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.ProxyTypeColumn];
        this.ProxyTimeOut = (int)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.ProxyTimeOutColumn];
        this.UseProxyResolveHostNames = (bool)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.UseProxyToResolveHostNamesColumn];
        this.UseSocks5Authentication = (bool)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.UseAuthenticationColumn];

        this.Socks5UserName = (string)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.LoginColumn];
        this.Socks5Password = (string)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.PasswordColumn];
    }

    private void ApplySelectedJurikSoftServerFromList(int int_GroupIndex)
    {
        if (listView_ServersList_ServersList.SelectedItems.Count != 1) return;

        int int_ProxyServerRowIndex = 0, int_JurikSoftServerIndex = listView_ServersList_ServersList.SelectedItems[0].Index;

        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersRow[] dataRowArray_JurikSoftServersRows = null;
        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersRow dataRowArray_SelectedJurikSoftServersRow = null;

        dataRowArray_JurikSoftServersRows = (DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersRow[])JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes.Rows[int_GroupIndex].GetChildRows("ServerGroupTypes_JurikSoftServerInfo");

        dataRowArray_SelectedJurikSoftServersRow = dataRowArray_JurikSoftServersRows[int_JurikSoftServerIndex];

        bool bool_UseProxyServer = (bool)dataRowArray_SelectedJurikSoftServersRow.UseProxyServer;

        if (bool_UseProxyServer == true)
        {
            int_ProxyServerRowIndex = (int)dataRowArray_SelectedJurikSoftServersRow.ProxyServerID;
        }

        this.ServerHost = (string)dataRowArray_SelectedJurikSoftServersRow.ServerHost;
        this.ServerPort = (int)dataRowArray_SelectedJurikSoftServersRow.ServerPort;
        this.LoginForConnection = (string)dataRowArray_SelectedJurikSoftServersRow.Login;
        this.PasswordForConnection = (string)dataRowArray_SelectedJurikSoftServersRow.Password;

        if (bool_UseProxyServer == false) return;

        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings;

        this.UseProxyServer = true;

        this.ProxyHost = (string)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.ProxyHostColumn];
        this.ProxyPort = (int)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.ProxyPortColumn];
        this.ProxyTimeOut = (int)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.ProxyTimeOutColumn];

        this.ProxyTypeIndex = (int)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.ProxyTypeColumn];
        this.ProxyTimeOut = (int)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.ProxyTimeOutColumn];
        this.UseProxyResolveHostNames = (bool)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.UseProxyToResolveHostNamesColumn];
        this.UseSocks5Authentication = (bool)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.UseAuthenticationColumn];

        this.Socks5UserName = (string)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.LoginColumn];
        this.Socks5Password = (string)ProxyServersSettingsDataTable_obj.Rows[int_ProxyServerRowIndex][ProxyServersSettingsDataTable_obj.PasswordColumn];
    }

    public void RemoveJurikSoftServerFromListView(int int_JurikSoftServerIndex)
    {
        int int_DeletedTagIndex = (int)this.listView_ServersList_ServersList.Items[int_JurikSoftServerIndex].Tag;

        foreach (ListViewItem listViewItem_obj in this.listView_ServersList_ServersList.Items)
        {
            if ((int)listViewItem_obj.Tag > int_DeletedTagIndex)
            {
                listViewItem_obj.Tag = (int)listViewItem_obj.Tag - 1;
            }
        }

        this.listView_ServersList_ServersList.Items.RemoveAt(int_JurikSoftServerIndex);
    }

    private void listView_ServersList_ServersList_DoubleClick(object sender, System.EventArgs e)
    {
        if (this.comboBox_ServersList_ServersGroups.SelectedIndex == -1) return;

        if (this.comboBox_ServersList_ServersGroups.SelectedIndex == 0) ApplySelectedJurikSoftServerFromList();
        else ApplySelectedJurikSoftServerFromList(this.comboBox_ServersList_ServersGroups.SelectedIndex - 1);
    }

    private void button_ServersList_AddRecord_Click(object sender, System.EventArgs e)
    {
        JurikSoftServersDBManagerForm jurikSoftServersDBManagerForm_obj = new JurikSoftServersDBManagerForm();

        jurikSoftServersDBManagerForm_obj.ApplyButton.Visible = false;

        jurikSoftServersDBManagerForm_obj.ShowDialog();
    }

    private void button_ServersList_Use_Click(object sender, System.EventArgs e)
    {
        if (this.comboBox_ServersList_ServersGroups.SelectedIndex == -1) return;

        if (this.comboBox_ServersList_ServersGroups.SelectedIndex == 0) ApplySelectedJurikSoftServerFromList();
        else ApplySelectedJurikSoftServerFromList(this.comboBox_ServersList_ServersGroups.SelectedIndex - 1);
    }

    private void button_ServersList_RemoveServer_Click(object sender, System.EventArgs e)
    {
        if (this.listView_ServersList_ServersList.SelectedItems.Count < 1) return;

        if (DialogResult.Yes == MessageBox.Show(ClientStringFactory.GetString(322, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            new JSClientDBEnvironment().RemoveJurikSoftServersDataBaseRow(GetJurikSoftServerRowIndexFromListIndex());

            RemoveJurikSoftServerFromListView(this.listView_ServersList_ServersList.SelectedItems[0].Index);
        }
    }

    private void button_ServersList_ClearList_Click(object sender, System.EventArgs e)
    {
        if (this.listView_ServersList_ServersList.Items.Count < 1) return;

        if (DialogResult.Yes == MessageBox.Show(ClientStringFactory.GetString(321, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            this.listView_ServersList_ServersList.Items.Clear();

            new JSClientDBEnvironment().ClearJurikSoftServersDataBase();

            return;
        }
    }

    private void button_ServersList_EditRecord_Click(object sender, System.EventArgs e)
    {
        if (this.listView_ServersList_ServersList.SelectedItems.Count == 0) return;

        UserAccountsAndAccessRestrictionRulesEnvironment.EditSelectedJurikSoftServerInfo(GetJurikSoftServerRowIndexFromListIndex());
    }

    private void button_ServersList_ViewRecord_Click(object sender, System.EventArgs e)
    {
        if (this.listView_ServersList_ServersList.SelectedItems.Count == 0) return;

        UserAccountsAndAccessRestrictionRulesEnvironment.ViewSelectedJurikSoftServerInfo(GetJurikSoftServerRowIndexFromListIndex());
    }

    private void comboBox_ServersList_ServersGroups_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (this.comboBox_ServersList_ServersGroups.SelectedIndex == -1) return;

        if (this.comboBox_ServersList_ServersGroups.SelectedIndex == 0)
        {
            ObjCopy.obj_MainClientForm.FillJurikSoftServersList();

            return;
        }

        if (this.comboBox_ServersList_ServersGroups.SelectedIndex > 0)
        {
            int int_SelectedGroupIndex = this.comboBox_ServersList_ServersGroups.SelectedIndex - 1;

            ObjCopy.obj_MainClientForm.FillJurikSoftServersList(int_SelectedGroupIndex);

            return;
        }
    }

    #endregion

    #region Invoke Delegates declaration

    delegate string delegate_ReturningStringMethod();
    delegate bool delegate_ReturningBoolMethod();

    delegate int delegate_ReturningIntMethod();
    delegate long delegate_ReturningLongMethod();
    delegate decimal delegate_ReturningDecimalMethod();

    delegate ListView.ListViewItemCollection delegate_ReturningListViewItemCollectionMethod();
    delegate ImageList delegate_ReturningImageListMethod();
    delegate TrackBar delegate_ReturningTrackBarMethod();
    delegate TreeView delegate_ReturningTreeViewMethod();

    #endregion

    #region Columns Sorter Environment

    ListViewColumnSorter listViewColumnSorter_ProcessesList = new ListViewColumnSorter(),
                        listViewColumnSorter_DrivesList = new ListViewColumnSorter(),
                        listViewColumnSorter_FileManager = new ListViewColumnSorter(),
                        listViewColumnSorter_ServicesList = new ListViewColumnSorter(),
                        listViewColumnSorter_EventsList = new ListViewColumnSorter(),
                        listViewColumnSorter_DriversList = new ListViewColumnSorter(),
                        listViewColumnSorter_ProgramsList = new ListViewColumnSorter(),
                        listViewColumnSorter_ServersList = new ListViewColumnSorter(),
                        listViewColumnSorter_ProxyServersList = new ListViewColumnSorter(),
                        listViewColumnSorter_InstalledUpdates = new ListViewColumnSorter();

    private void listView_ProcessesManager_Processes_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
        this.listView_ProcessesManager_Processes.ListViewItemSorter = listViewColumnSorter_ProcessesList;

        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == listViewColumnSorter_ProcessesList.SortColumn)
        {
            if (listViewColumnSorter_ProcessesList.Order == SortOrder.Ascending)
                listViewColumnSorter_ProcessesList.Order = SortOrder.Descending;

            else listViewColumnSorter_ProcessesList.Order = SortOrder.Ascending;
        }
        else
        {
            listViewColumnSorter_ProcessesList.SortColumn = e.Column;
            listViewColumnSorter_ProcessesList.Order = SortOrder.Ascending;
        }

        this.listView_ProcessesManager_Processes.Sort();
    }

    private void listView_DrivesManager_DrivesInformation_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
        this.listView_DrivesManager_DrivesInformation.ListViewItemSorter = listViewColumnSorter_DrivesList;

        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == listViewColumnSorter_DrivesList.SortColumn)
        {
            if (listViewColumnSorter_DrivesList.Order == SortOrder.Ascending)
                listViewColumnSorter_DrivesList.Order = SortOrder.Descending;

            else listViewColumnSorter_DrivesList.Order = SortOrder.Ascending;
        }
        else
        {
            listViewColumnSorter_DrivesList.SortColumn = e.Column;
            listViewColumnSorter_DrivesList.Order = SortOrder.Ascending;
        }

        this.listView_DrivesManager_DrivesInformation.Sort();
    }

    private void listView_FileManager_FileManager_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
        this.listView_FileManager_FileManager.ListViewItemSorter = listViewColumnSorter_FileManager;

        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == listViewColumnSorter_FileManager.SortColumn)
        {
            if (listViewColumnSorter_FileManager.Order == SortOrder.Ascending)
                listViewColumnSorter_FileManager.Order = SortOrder.Descending;

            else listViewColumnSorter_FileManager.Order = SortOrder.Ascending;
        }
        else
        {
            listViewColumnSorter_FileManager.SortColumn = e.Column;
            listViewColumnSorter_FileManager.Order = SortOrder.Ascending;
        }

        this.listView_FileManager_FileManager.Sort();
    }

    private void listView_ServicesManager_Services_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
        this.listView_ServicesManager_Services.ListViewItemSorter = listViewColumnSorter_ServicesList;

        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == listViewColumnSorter_ServicesList.SortColumn)
        {
            if (listViewColumnSorter_ServicesList.Order == SortOrder.Ascending)
                listViewColumnSorter_ServicesList.Order = SortOrder.Descending;

            else listViewColumnSorter_ServicesList.Order = SortOrder.Ascending;
        }
        else
        {
            listViewColumnSorter_ServicesList.SortColumn = e.Column;
            listViewColumnSorter_ServicesList.Order = SortOrder.Ascending;
        }

        this.listView_ServicesManager_Services.Sort();
    }

    private void listView_SystemEvents_Events_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
        this.listView_SystemEvents_Events.ListViewItemSorter = listViewColumnSorter_EventsList;

        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == listViewColumnSorter_EventsList.SortColumn)
        {
            if (listViewColumnSorter_EventsList.Order == SortOrder.Ascending)
                listViewColumnSorter_EventsList.Order = SortOrder.Descending;

            else listViewColumnSorter_EventsList.Order = SortOrder.Ascending;
        }
        else
        {
            listViewColumnSorter_EventsList.SortColumn = e.Column;
            listViewColumnSorter_EventsList.Order = SortOrder.Ascending;
        }

        this.listView_SystemEvents_Events.Sort();
    }

    private void listView_DriversList_DriversList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
        this.listView_DriversList_DriversList.ListViewItemSorter = listViewColumnSorter_DriversList;

        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == listViewColumnSorter_DriversList.SortColumn)
        {
            if (listViewColumnSorter_DriversList.Order == SortOrder.Ascending)
                listViewColumnSorter_DriversList.Order = SortOrder.Descending;

            else listViewColumnSorter_DriversList.Order = SortOrder.Ascending;
        }
        else
        {
            listViewColumnSorter_DriversList.SortColumn = e.Column;
            listViewColumnSorter_DriversList.Order = SortOrder.Ascending;
        }

        this.listView_DriversList_DriversList.Sort();
    }

    private void listView_InstalledPrograms_ProgramsList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
        this.listView_InstalledPrograms_ProgramsList.ListViewItemSorter = listViewColumnSorter_ProgramsList;

        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == listViewColumnSorter_ProgramsList.SortColumn)
        {
            if (listViewColumnSorter_ProgramsList.Order == SortOrder.Ascending)
                listViewColumnSorter_ProgramsList.Order = SortOrder.Descending;

            else listViewColumnSorter_ProgramsList.Order = SortOrder.Ascending;
        }
        else
        {
            listViewColumnSorter_ProgramsList.SortColumn = e.Column;
            listViewColumnSorter_ProgramsList.Order = SortOrder.Ascending;
        }

        this.listView_InstalledPrograms_ProgramsList.Sort();
    }

    private void listView_InstalledUpdates_UpdatesList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
        this.listView_InstalledUpdates_UpdatesList.ListViewItemSorter = listViewColumnSorter_InstalledUpdates;

        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == listViewColumnSorter_InstalledUpdates.SortColumn)
        {
            if (this.listViewColumnSorter_InstalledUpdates.Order == SortOrder.Ascending)
                this.listViewColumnSorter_InstalledUpdates.Order = SortOrder.Descending;

            else this.listViewColumnSorter_InstalledUpdates.Order = SortOrder.Ascending;
        }
        else
        {
            this.listViewColumnSorter_InstalledUpdates.SortColumn = e.Column;
            this.listViewColumnSorter_InstalledUpdates.Order = SortOrder.Ascending;
        }

        this.listView_InstalledUpdates_UpdatesList.Sort();
    }

    private void listView_ServersList_ServersList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
        this.listView_ServersList_ServersList.ListViewItemSorter = listViewColumnSorter_ServersList;

        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == listViewColumnSorter_ServersList.SortColumn)
        {
            if (listViewColumnSorter_ServersList.Order == SortOrder.Ascending)
            {
                listViewColumnSorter_ServersList.Order = SortOrder.Descending;
            }
            else 
            { 
                listViewColumnSorter_ServersList.Order = SortOrder.Ascending; 
            }
        }
        else
        {
            listViewColumnSorter_ServersList.SortColumn = e.Column;
            listViewColumnSorter_ServersList.Order = SortOrder.Ascending;
        }

        this.listView_ServersList_ServersList.Sort();
    }

    private void listView_ProxyServersList_ProxyServersList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
        this.listView_ProxyServersList_ProxyServersList.ListViewItemSorter = listViewColumnSorter_ProxyServersList;

        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == listViewColumnSorter_ProxyServersList.SortColumn)
        {
            if (listViewColumnSorter_ProxyServersList.Order == SortOrder.Ascending)
                listViewColumnSorter_ProxyServersList.Order = SortOrder.Descending;

            else listViewColumnSorter_ProxyServersList.Order = SortOrder.Ascending;
        }
        else
        {
            listViewColumnSorter_ProxyServersList.SortColumn = e.Column;
            listViewColumnSorter_ProxyServersList.Order = SortOrder.Ascending;
        }

        this.listView_ProxyServersList_ProxyServersList.Sort();
    }

    #endregion

    #region Shared Properties

    string string_CurrentFilePath = "C:\\";
    int int_LastSelectedServiceAction = 0;

    string string_CurrentSystemEventLog;

    public int ConnectionTimeOut
    {
        get
        {
                     
            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                switch (this.comboBox_NetworkControl_ConnectionTimeOut.SelectedIndex)
                {
                    case 0:
                        return 5000;
                     

                    case 1:
                        return 10000;
                 

                    case 2:
                        return 15000;                   
                }
                      
                return 15000;  

            });
          
        }
    }

    public bool EnableGetClipboardDataButton
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.button_RTDV_GetRemoteClipboardData.Enabled = value;
            });
        }
    }

    public bool EnableSetClipboardDataButton
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.button_RTDV_SetRemoteClipboardData.Enabled = value;
            });
        }
    }

    public bool EnableSendMessage
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.button_Message_SendMessage.Enabled = value;
            });
        }
    }

    public bool EnableInstalledSoftwareManager
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.button_InstalledPrograms_Refresh.Enabled = value;
            });
        }
    }

    public bool EnableInstalledUpdatesManager
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.button_InstalledUpdates_Refresh.Enabled = value;
            });
        }
    }

    public bool EnableSystemEventsManager
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.button_SystemEvents_Refresh.Enabled = value;
                this.comboBox_SystemEvents_Logs.Enabled = value;
            });
        }
    }

    public bool EnableServicesManager
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.button_ServicesManager_Refresh.Enabled = value;
            });
        }
    }

    public bool EnableFileManager
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                button_FileManager_DirUp.Enabled = value;

                button_FileManager_Refresh.Enabled = value;

                comboBox_FileManager_LogicalDrives.Enabled = value;
            });
        }
    }

    public bool EnableProcessesManager
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.button_ProcessesManager_Refresh.Enabled = value;
            });
        }
    }

    public bool EnableDisplayCapture
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.button_SingleImageCapture_CaptureImage.Enabled = value;
            });
        }
    }

    public bool EnableDriversManager
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.button_DriversList_Refresh.Enabled = value;
            });

        }
    }

    public bool EnableLogin
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_NetworkControl_Login.Enabled = value;
            });
        }
    }
    public bool EnablePassword
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_NetworkControl_Password.Enabled = value;
            });
        }
    }

    public bool EnableDownloadButton
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.button_FileManager_Download.Enabled = value;
            });
        }
    }

    public bool EnableUploadButton
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.button_FileManager_Upload.Enabled = value;
            });
        }
    }

    public void EnableAllControls()
    {
        if (this.IsHandleCreated == false) return;

        this.Invoke((MethodInvoker)delegate
        {
            EnableSendMessage = true;
            EnableSystemEventsManager = true;
            EnableServicesManager = true;
            EnableFileManager = true;
            EnableProcessesManager = true;
            EnableDisplayCapture = true;
            EnableDriversManager = true;
            EnableLogin = true;
            EnablePassword = true;
            EnableInstalledSoftwareManager = true;
            EnableInstalledUpdatesManager = true;

            this.groupBox_NetworkControl_MainNetworkControl.Enabled = true;
            this.groupBox_NetworkControl_Security.Enabled = true;
        });
    }


    public string MessageBoxText
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_Message_MessageText.Text;
            });
        }
    }

    public int MessageBoxIconIndex
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                if (this.radioButton_Message_IconInformation.Checked == true) return 1;
                if (this.radioButton_Message_IconStop.Checked == true) return 2;
                if (this.radioButton_Message_IconWarning.Checked == true) return 3;
                if (this.radioButton_Message_IconQuestion.Checked == true) return 4;
                if (this.radioButton_Message_IconNone.Checked == true) return 5;

                return 0;
            });
        }
    }

    public int MessageBoxButtonsCollection
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                if (this.radioButton_Message_Ok.Checked == true) return 1;
                if (this.radioButton_Message_YesNo.Checked == true) return 2;
                if (this.radioButton_Message_OkCancel.Checked == true) return 3;
                if (this.radioButton_Message_RetryCancel.Checked == true) return 4;
                if (this.radioButton_Message_radioButton_Message_YesNoCancel.Checked == true) return 5;
                if (this.radioButton_Message_AbortRetryIgnore.Checked == true) return 6;

                return 0;
            });
        }
    }

    public int InformingOfUserChoice
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                if (checkBox_Message_ReceiveUserChoice.Checked == true) return 1;
                else return 0;
            });
        }
    }

    public string MessageBoxCaption
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_Message_MessageCaption.Text;
            });
        }
    }




    public string SystemLogInformation
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_SystemEvents_Information.Text = value;
            });
        }
    }

    public int IndexOfCapturedImageFormat
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.comboBox_SingleImageCapture_ImageFormat.SelectedIndex;
            });
        }
    }




    public string ExecutedNameOfFile
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_RemoteExecution_FileNameWithPath.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_RemoteExecution_FileNameWithPath.Text = value;
            });
        }
    }

    public string CommandLineArguments
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_RemoteExecution_CommandLineArguments.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_RemoteExecution_CommandLineArguments.Text = value;
            });

        }
    }

    public string WorkingDirectory
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_RemoteExecution_WorkingFolder.Text;
            });
        }
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_RemoteExecution_WorkingFolder.Text = value;
            });
        }
    }


    public string CurrentSystemEventLog
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.string_CurrentSystemEventLog;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.string_CurrentSystemEventLog = value;
            });
        }

    }

    public int WindowStyleForExecutedFile
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.comboBox_RemoteExecution_WindowStyle.SelectedIndex;
            });
        }
    }

    public int UseShellExecute
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                if (this.checkBox_RemoteExecution_UseShellExecute.Checked == true) return 1;
                else return 0;
            });
        }
    }

    public int DisplayErrorDialog
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                if (this.checkBox_RemoteExecution_ShowErrorDialog.Checked == true) return 1;

                else return 0;
            });
        }
    }

    public int ExecuteWithoutWindowCreation
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                if (this.checkBox_RemoteExecution_NotCreateWindow.Checked == true) return 1;

                else return 0;
            });
        }
    }


    public string DisplayedNameOfService
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.listView_ServicesManager_Services.FocusedItem.SubItems[0].Text;
            });
        }
    }

    public string NameOfService
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.listView_ServicesManager_Services.FocusedItem.SubItems[1].Text;
            });
        }
    }


    public string DisplayedNameOfDriver
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.listView_DriversList_DriversList.FocusedItem.SubItems[0].Text;
            });
        }
    }

    public string NameOfDriver
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.listView_DriversList_DriversList.FocusedItem.SubItems[1].Text;
            });
        }
    }


    public string NameOfProcess
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.listView_ProcessesManager_Processes.FocusedItem.SubItems[0].Text;
            });
        }
    }

    public string PID
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.listView_ProcessesManager_Processes.FocusedItem.SubItems[3].Text;
            });
        }
    }


    public string LastSelectedNameOfFileWithPath
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                if (this.listView_FileManager_FileManager.SelectedItems.Count > 0 &&
                    this.listView_FileManager_FileManager.FocusedItem.ImageIndex == 1)
                {
                    return CurrentFilePath + listView_FileManager_FileManager.FocusedItem.Text;
                }

                return string.Empty;
            });
        }
    }

    public string LastSelectedNameOfFolderWithPath
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                if (this.listView_FileManager_FileManager.SelectedItems.Count > 0 &&
                    this.listView_FileManager_FileManager.FocusedItem.SubItems[3].Text.IndexOf("Directory") != -1)
                {
                    return CurrentFilePath + listView_FileManager_FileManager.FocusedItem.Text;
                }

                else return string.Empty;
            });
        }
    }


    public string LastSelectedNameOfFolderOrFile
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                if (this.listView_FileManager_FileManager.SelectedItems.Count > 0)
                {
                    return listView_FileManager_FileManager.FocusedItem.Text;
                }

                else return string.Empty;
            });
        }
    }

    public string LastSelectedNameOfFolderOrFileWithPath
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                if (this.listView_FileManager_FileManager.SelectedItems.Count > 0)
                {
                    return CurrentFilePath + listView_FileManager_FileManager.FocusedItem.Text;
                }

                else return string.Empty;
            });
        }
    }


    public string CurrentFilePath
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.string_CurrentFilePath;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.string_CurrentFilePath = value;
                this.textBox_FileManager_CurrentPath.Text = string_CurrentFilePath.ToUpper();
            });
        }
    }


    public string StatusOfService
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.listView_ServicesManager_Services.FocusedItem.SubItems[2].Text;
            });
        }
    }


    public int LastSelectedServiceAction
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.int_LastSelectedServiceAction;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.int_LastSelectedServiceAction = value;
            });
        }
    }


    public int ForcingTermination
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                if (checkBox_SystemStateManager_ForceTerminate.Checked) return 1;
                else return 0;
            });
        }
    }

    public int ForcingTerminationIfHung
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                if (checkBox_SystemStateManager_ForceTerminateIfHung.Checked) return 1;
                else return 0;
            });
        }
    }

    public int ForcedSuspension
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                if (checkBox_SystemStateManager_ForceImmediatelySuspend.Checked) return 1;
                else return 0;
            });
        }
    }


    public string SelectedPriorityOfProcess
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.comboBox_ProcessesManager_ProcessPriority.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.comboBox_ProcessesManager_ProcessPriority.Text = value;
            });
        }
    }


    public int SizeOfLastSelectedFile
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                if (MainTcpClient.IsConnected && listView_FileManager_FileManager.SelectedItems.Count > 0
                    && listView_FileManager_FileManager.FocusedItem.ImageIndex == 1)
                {
                    return int.Parse(listView_FileManager_FileManager.FocusedItem.SubItems[1].Text.Replace(", ", ""));
                }

                else return -1;
            });
        }

    }


    public string LastFileWriteTime
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                if (MainTcpClient.IsConnected && listView_FileManager_FileManager.SelectedItems.Count > 0 &&
                    listView_FileManager_FileManager.FocusedItem.ImageIndex == 1)
                {
                    return listView_FileManager_FileManager.FocusedItem.SubItems[2].Text;
                }

                return string.Empty;
            });
        }
    }


    static long long_Statistic_BytesSent = 0, long_Statistic_BytesReceived = 0, long_Statistic_CompletedTransferTasks = 0;

    static string string_Statistic_LastConnectionTime = string.Empty;

    public string SetStatistic_ConnectedAt
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                string_Statistic_LastConnectionTime = value;

                this.statusBarPanel_LastConnectionTime.Text = ClientStringFactory.GetString(194, ClientSettingsEnvironment.CurrentLanguage) + " " + string_Statistic_LastConnectionTime;
            });
        }

        get
        {

            if (this.IsHandleCreated == false) return string_Statistic_LastConnectionTime;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return string_Statistic_LastConnectionTime;
            });
        }
    }

    public long SetStatistic_BytesSent
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            long_Statistic_BytesSent = value;

            this.Invoke((MethodInvoker)delegate
            {
                this.statusBarPanel_BytesSent.Text = ClientStringFactory.GetString(198, ClientSettingsEnvironment.CurrentLanguage) + " " + this.SpreadToHundreds(long_Statistic_BytesSent.ToString());
            });
        }

        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (long)this.Invoke((delegate_ReturningLongMethod)delegate
            {
                return long_Statistic_BytesSent;
            });
        }
    }

    public long SetStatistic_BytesReceived
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                long_Statistic_BytesReceived = value;

                this.statusBarPanel_BytesReceived.Text = ClientStringFactory.GetString(197, ClientSettingsEnvironment.CurrentLanguage) + " " + this.SpreadToHundreds(long_Statistic_BytesReceived.ToString());
            });
        }

        get
        {
            if (this.IsHandleCreated == false) return long_Statistic_BytesReceived;

            return (long)this.Invoke((delegate_ReturningLongMethod)delegate
            {
                return long_Statistic_BytesReceived;
            });
        }
    }

    public long SetStatistic_CompletedTasks
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                long_Statistic_CompletedTransferTasks = value;

                this.statusBarPanel_CompletedTasksOfTransfers.Text = ClientStringFactory.GetString(196, ClientSettingsEnvironment.CurrentLanguage) + " " + long_Statistic_CompletedTransferTasks.ToString();
            });
        }

        get
        {
            if (this.IsHandleCreated == false) return long_Statistic_CompletedTransferTasks;

            return (long)this.Invoke((delegate_ReturningLongMethod)delegate
            {
                return long_Statistic_CompletedTransferTasks;
            });
        }
    }


    public string PasswordForConnection
    {
        get
        {
            if (this.IsHandleCreated == false) return this.textBox_NetworkControl_Password.Text;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_NetworkControl_Password.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_NetworkControl_Password.Text = value;
            });
        }
    }

    public string LoginForConnection
    {
        get
        {
            if (this.IsHandleCreated == false) return this.textBox_NetworkControl_Login.Text;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_NetworkControl_Login.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_NetworkControl_Login.Text = value;
            });
        }
    }


    public int SelectedActionWithSingleCapturedImage
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                if (radioButton_SingleImageCapture_SaveAndShow.Checked) return 1;
                else return 0;
            });
        }
    }

    public int SelectedActionWithCapturedImageInInterval
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                if (radioButton_CaptureInInterval_SaveAndShow.Checked) return 1;
                else return 0;
            });
        }
    }


    public ImageList RemoteCursorSmall
    {
        get
        {
            if (this.IsHandleCreated == false) return null;

            this.Invoke((delegate_ReturningImageListMethod)delegate
            {
                return imageList_RTDV;
            });

            return imageList_RTDV;
        }
    }


    public int ReceivedImageSizeForRTDV
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.trackBar_RTDV_ReceivedImageSize.Value;
            });
        }
    }

    public decimal MaxRTDVUpsatesPerSec
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (decimal)this.Invoke((delegate_ReturningDecimalMethod)delegate
            {
                return numericUpDown_RTDV_MaxUpdatePerSec.Value;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.numericUpDown_RTDV_MaxUpdatePerSec.Value = value;
            });
        }
    }

    public bool RTRDVEnabled
    {
        get
        {
            if (this.IsHandleCreated == false) return false;

            return (bool)this.Invoke((delegate_ReturningBoolMethod)delegate
            {
                return this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer.Checked;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.checkBox_RTDV_EnableRealTimeRemoteDisplayViewer.Checked = value;
            });
        }
    }

    public bool RTRDVRealSize
    {
        get
        {
            if (this.IsHandleCreated == false) return false;

            return (bool)this.Invoke((delegate_ReturningBoolMethod)delegate
            {
                return this.checkBox_RTDV_RealSize.Checked;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.checkBox_RTDV_RealSize.Checked = value;
            });
        }
    }

    public bool ShowRemoteCursor
    {
        get
        {
            if (this.IsHandleCreated == false) return false;

            return (bool)this.Invoke((delegate_ReturningBoolMethod)delegate
            {
                return this.checkBox_RTDV_ShowRemoteCursor.Checked;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.checkBox_RTDV_ShowRemoteCursor.Checked = value;
            });
        }
    }

    public int RTDVSizeMode
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.comboBox_RTDV_SizeMode.SelectedIndex;
            });
        }
    }

    public int RTDVImageCodingAlgorithm
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.trackBar_RTDV_ImageCodingAlgorithm.Value;
            });
        }
    }

    public int RTDVRegionsCount
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.comboBox_RTDV_AmountOfRegions.SelectedIndex;
            });
        }
    }


    public int CurrentTab
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.tabControl_Main.SelectedIndex;
            });

            return 0;
        }
    }

    public TrackBar DisplayResolutionTrackBar
    {
        get
        {
            if (this.IsHandleCreated == false) return null;

            return (TrackBar)this.Invoke((delegate_ReturningTrackBarMethod)delegate
            {
                return this.trackBar_DisplaySettings_Resolution;
            });
        }
    }


    public int CurrentDisplayFrequency
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                for (int int_CycleCount = 0; comboBox_DisplaySettings_ScreenRefreshRate.Items.Count != int_CycleCount; int_CycleCount++)
                {
                    if (int.Parse(comboBox_DisplaySettings_ScreenRefreshRate.Items[int_CycleCount].ToString()) == value)
                    {
                        this.comboBox_DisplaySettings_ScreenRefreshRate.SelectedIndex = int_CycleCount;
                    }
                }
            });
        }

        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return int.Parse(comboBox_DisplaySettings_ScreenRefreshRate.Items[comboBox_DisplaySettings_ScreenRefreshRate.SelectedIndex].ToString());
            });
        }
    }

    public int CurrentDisplayColorQuality
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                for (int int_CycleCount = 0; comboBox_DisplaySettings_ColorQuality.Items.Count != int_CycleCount; int_CycleCount++)
                {
                    if (int.Parse(comboBox_DisplaySettings_ColorQuality.Items[int_CycleCount].ToString()) == value)
                    {
                        comboBox_DisplaySettings_ColorQuality.SelectedIndex = int_CycleCount;
                    }
                }
            });
        }

        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return int.Parse(comboBox_DisplaySettings_ColorQuality.Items[comboBox_DisplaySettings_ColorQuality.SelectedIndex].ToString());
            });
        }
    }


    public int SingleImageCaptureCompressionFormat
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.comboBox_SingleImageCapture_CompressionFormat.SelectedIndex;
            });
        }
    }

    public int CaptureInIntervaCompressionFormat
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.comboBox_CaptureInInterval_CompressionFormat.SelectedIndex;
            });
        }
    }


    public int SingleImageCaptureQualityLevel
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.trackBar_SingleImageCapture_ImageQuality.Value;
            });
        }
    }

    public int CaptureInIntervaQualityLevel
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.trackBar_CaptureInInterval_ImageQuality.Value;
            });
        }
    }


    public ListView.ListViewItemCollection ProxyServersListItems
    {
        get
        {
            if (this.IsHandleCreated == false) return null;

            return (ListView.ListViewItemCollection)this.Invoke((delegate_ReturningListViewItemCollectionMethod)delegate
            {
                return this.listView_ProxyServersList_ProxyServersList.Items;
            });
        }
    }


    public bool RSIEnableAvailableItemsGroupBox
    {
        get
        {
            if (this.IsHandleCreated == false) return false;

            return (bool)this.Invoke((delegate_ReturningBoolMethod)delegate
            {
                return this.groupBox_RemoteSystemInformation_AvailableItems.Enabled;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.groupBox_RemoteSystemInformation_AvailableItems.Enabled = value;
            });
        }
    }


    public string RSIStatus
    {
        get
        {
            if (this.IsHandleCreated == false) return String.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_RemoteSystemInformation_AvailableItems_CurrentStatus.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_RemoteSystemInformation_AvailableItems_CurrentStatus.Text = value;
            });
        }
    }



    public string RemoteClipboardType
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ClipboardManager_RemoteClipboardType.Text = value;
            });
        }
    }

    public string LocalClipboardType
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ClipboardManager_LocalClipboardType.Text = value;
            });
        }
    }

    public string ClipboardPreviewTextData
    {
        get
        {
            if (this.IsHandleCreated == false) return String.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.richTextBox_ClipboardManager_TextData.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.richTextBox_ClipboardManager_TextData.Text = value;
            });
        }
    }

    public string[] ClipboardPreviewFileDropListItems
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.listView_ClipboardManager_FileDropList.Items.Clear();

                for (int int_CycleCount = 0; value.Length != int_CycleCount; int_CycleCount++)
                {
                    this.listView_ClipboardManager_FileDropList.Items.Add(value[int_CycleCount]);
                }
            });
        }
    }

    public Image ClipboardPreviewImageData
    {
        set
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.pictureBox_ClipboardManager_Image.Image = value;

                switch (this.comboBox_RemoteClipboardImageSettings_PreviewSizeMode.SelectedIndex)
                {
                    case 0:
                        this.pictureBox_ClipboardManager_Image.SizeMode = PictureBoxSizeMode.AutoSize;
                        break;

                    case 1:
                        this.pictureBox_ClipboardManager_Image.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;

                    case 2:
                        this.pictureBox_ClipboardManager_Image.SizeMode = PictureBoxSizeMode.CenterImage;
                        break;
                }

                this.pictureBox_ClipboardManager_Image.Size = new System.Drawing.Size(360, 254);
            });
        }
    }

    public int RemoteClipboardPreviewImageCompressionFormat
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.comboBox_RemoteClipboardImageSettings_CompressionFormat.SelectedIndex;
            });
        }
    }

    public int RemoteClipboardPreviewImageQuality
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.trackBar_RemoteClipboardImageSettings_ImageQuality.Value;
            });
        }
    }

    public int RemoteClipboardPreviewImageFormat
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.comboBox_RemoteClipboardImageSettings_ImageFormat.SelectedIndex;
            });
        }
    }

    public int RefreshClipboardsTypeInfoInterval
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.comboBox_ClipboardManager_RefreshClipboardsTypeInfoInterval.SelectedIndex;
            });
        }
    }

    public bool ShowClipboardWarnings
    {
        get
        {
            if (this.IsHandleCreated == false) return false;

            return (bool)this.Invoke((delegate_ReturningBoolMethod)delegate
            {
                return this.checkBox_ClipboardManager_ShowWarnings.Checked;
            });
        }

    }


    #endregion

    #region Properties for NetworkAction class

    public string ServerHost
    {
        get
        {
            if (this.IsHandleCreated == false) return String.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_NetworkControl_IP.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_NetworkControl_IP.Text = value;
            });
        }
    }

    public int ServerPort
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                try
                {
                    if (Convert.ToInt32(textBox_NetworkControl_Port.Text) > 65535 || Convert.ToInt32(textBox_NetworkControl_Port.Text) < 1)
                    {
                        MessageBox.Show(ClientStringFactory.GetString(444, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK);
                        return -1;
                    }

                    return Convert.ToInt32(this.textBox_NetworkControl_Port.Text);

                }

                catch (FormatException)
                {
                    MessageBox.Show(ClientStringFactory.GetString(444, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK);
                    return -1;
                }
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_NetworkControl_Port.Text = value.ToString();
            });
        }
    }

    public string ConnetionStatus
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_NetworkControl_ConnectionStatus.Text = value;
            });
        }
    }


    public bool UseProxyServer
    {
        get
        {
            if (this.IsHandleCreated == false) return false;

            return (bool)this.Invoke((delegate_ReturningBoolMethod)delegate
            {
                return this.checkBox_ProxySettings_UseProxy.Checked;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.checkBox_ProxySettings_UseProxy.Checked = value;
                this.checkBox_NetworkControl_UseProxy_CheckedChanged(null, null);
            });
        }
    }

    public int ProxyPort
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                try
                {
                    if (Convert.ToInt32(textBox_ProxySettings_ProxyPort.Text) > 65535 || Convert.ToInt32(textBox_ProxySettings_ProxyPort.Text) < 1)
                    {
                        MessageBox.Show(ClientStringFactory.GetString(443, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK);
                        return -1;
                    }

                    return int.Parse(textBox_ProxySettings_ProxyPort.Text);
                }

                catch (FormatException)
                {
                    MessageBox.Show(ClientStringFactory.GetString(443, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK);
                    return -1;
                }
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ProxySettings_ProxyPort.Text = value.ToString();
            });
        }
    }

    public string ProxyHost
    {
        get
        {
            if (this.IsHandleCreated == false) return String.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ProxySettings_ProxyHost.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ProxySettings_ProxyHost.Text = value;
            });
        }
    }

    public int ProxyTimeOut
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                if (this.comboBox_ProxySettings_ProxyTimeOut.SelectedIndex == 0) return 5000;
                if (this.comboBox_ProxySettings_ProxyTimeOut.SelectedIndex == 1) return 10000;
                if (this.comboBox_ProxySettings_ProxyTimeOut.SelectedIndex == 2) return 15000;
                return 5000;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                if (value == 5000) this.comboBox_ProxySettings_ProxyTimeOut.SelectedIndex = 0;
                if (value == 10000) this.comboBox_ProxySettings_ProxyTimeOut.SelectedIndex = 1;
                if (value == 15000) this.comboBox_ProxySettings_ProxyTimeOut.SelectedIndex = 2;
            });
        }
    }

    public bool UseProxyResolveHostNames
    {
        get
        {
            if (this.IsHandleCreated == false) return false;

            return (bool)this.Invoke((delegate_ReturningBoolMethod)delegate
            {
                return this.checkBox_ProxySettings_ResolveHostNames.Checked;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.checkBox_ProxySettings_ResolveHostNames.Checked = value;
            });
        }
    }

    public int ProxyTypeIndex
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.listBox_ProxySettings_ProxyType.SelectedIndex;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.listBox_ProxySettings_ProxyType.SelectedIndex = value;
                this.listBox_ProxySettings_ProxyType.Select();
            });
        }
    }


    public string Socks5UserName
    {
        get
        {
            if (this.IsHandleCreated == false) return String.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ProxySettings_Socks5UserName.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ProxySettings_Socks5UserName.Text = value;
            });
        }
    }

    public string Socks5Password
    {
        get
        {
            if (this.IsHandleCreated == false) return String.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ProxySettings_Socks5Password.Text;
            });
        }
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ProxySettings_Socks5Password.Text = value;
            });
        }
    }


    public bool UseSocks5Authentication
    {
        get
        {
            if (this.IsHandleCreated == false) return false;

            return (bool)this.Invoke((delegate_ReturningBoolMethod)delegate
            {
                return this.checkBox_ProxySettings_Authentication.Checked;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.checkBox_ProxySettings_Authentication.Checked = value;
            });
        }

    }

    public bool NeenProxyAuthentication
    {
        get
        {
            if (this.IsHandleCreated == false) return false;

            return (bool)this.Invoke((delegate_ReturningBoolMethod)delegate
            {
                return (this.listBox_ProxySettings_ProxyType.SelectedIndex > 0 && this.checkBox_ProxySettings_Authentication.Checked);
            });
        }
    }
    

    List<bool> list_ControlsEnabledState = new List<bool>();

    public void RestoreControlsEnabledState()
    {
        if (this.list_ControlsEnabledState == null || this.list_ControlsEnabledState.Count < 18)
        {
            return;
        }

        int int_CurrentControlIndex = 0;

        this.button_RTDV_GetRemoteClipboardData.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.button_RTDV_SetRemoteClipboardData.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.button_Message_SendMessage.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.button_InstalledPrograms_Refresh.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.button_InstalledUpdates_Refresh.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.button_SystemEvents_Refresh.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.comboBox_SystemEvents_Logs.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.button_ServicesManager_Refresh.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.button_FileManager_DirUp.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.button_FileManager_Refresh.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.comboBox_FileManager_LogicalDrives.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.button_ProcessesManager_Refresh.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.button_SingleImageCapture_CaptureImage.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.button_DriversList_Refresh.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.textBox_NetworkControl_Login.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.textBox_NetworkControl_Password.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.button_FileManager_Download.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];

        this.button_FileManager_Upload.Enabled = this.list_ControlsEnabledState[int_CurrentControlIndex++];
    }

    public void SaveControlsEnabledState()
    {
        this.list_ControlsEnabledState.Clear();

        this.list_ControlsEnabledState.Add(this.button_RTDV_GetRemoteClipboardData.Enabled);

        this.list_ControlsEnabledState.Add(this.button_RTDV_SetRemoteClipboardData.Enabled);

        this.list_ControlsEnabledState.Add(this.button_Message_SendMessage.Enabled);

        this.list_ControlsEnabledState.Add(this.button_InstalledPrograms_Refresh.Enabled);

        this.list_ControlsEnabledState.Add(this.button_InstalledUpdates_Refresh.Enabled);

        this.list_ControlsEnabledState.Add(this.button_SystemEvents_Refresh.Enabled);

        this.list_ControlsEnabledState.Add(this.comboBox_SystemEvents_Logs.Enabled);

        this.list_ControlsEnabledState.Add(this.button_ServicesManager_Refresh.Enabled);

        this.list_ControlsEnabledState.Add(this.button_FileManager_DirUp.Enabled);

        this.list_ControlsEnabledState.Add(this.button_FileManager_Refresh.Enabled);

        this.list_ControlsEnabledState.Add(this.comboBox_FileManager_LogicalDrives.Enabled);

        this.list_ControlsEnabledState.Add(this.button_ProcessesManager_Refresh.Enabled);

        this.list_ControlsEnabledState.Add(this.button_SingleImageCapture_CaptureImage.Enabled);

        this.list_ControlsEnabledState.Add(this.button_DriversList_Refresh.Enabled);

        this.list_ControlsEnabledState.Add(this.textBox_NetworkControl_Login.Enabled);

        this.list_ControlsEnabledState.Add(this.textBox_NetworkControl_Password.Enabled);

        this.list_ControlsEnabledState.Add(this.button_FileManager_Download.Enabled);

        this.list_ControlsEnabledState.Add(this.button_FileManager_Upload.Enabled);

    }

    #endregion


    private void button_NetworkControl_ConnectingService_Click(object sender, EventArgs e)
    {
        new ConnectingServiceProviderForm().ShowDialog();

        this.Select();
    }

    private void groupBox_NetworkControl_ServersList_Enter(object sender, EventArgs e)
    {

    }

    private void comboBox_RemoteExecution_WindowStyle_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void tabPage_Camera_Click(object sender, EventArgs e)
    {

    }

    private void checkBox_CameraTab_EnableCamera_CheckedChanged(object sender, EventArgs e)
    {
        if (!MainTcpClient.IsConnected)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        try
        {  
            try
            {
                RemoteCallAction remoteCallAction_obj = new RemoteCallAction();

                remoteCallAction_obj.StartWebCam();
            }

            catch
            {

            }
        }

        catch
        {

        }
    }


    void RefreshDataInForms()
    {
        ObjCopy.obj_MainClientForm.SetStatistic_BytesSent = MainTcpClient.Statistic_BytesSent;
        ObjCopy.obj_MainClientForm.SetStatistic_CompletedTasks = MainTcpClient.Statistic_CompletedReceiveTasks;
        ObjCopy.obj_MainClientForm.SetStatistic_BytesReceived = MainTcpClient.Statistic_BytesReceived;

        ObjCopy.obj_MainClientForm.ConnetionStatus = MainTcpClient.ConnectionStatus;
    }

    private void timer_MainFormTimer_Tick(object sender, EventArgs e)
    {
        RefreshDataInForms();
    }

    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    {
        new RemoteCallAction().StartMicRecord();//!!
    }

}
