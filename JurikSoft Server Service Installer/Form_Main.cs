using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.DirectoryServices;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net;

public partial class Form_Main : Form
{
    public Form_Main()
    {
        InitializeComponent();

        this.treeView_Computers.Nodes[0].Nodes.Add(string.Empty);
        this.treeView_Computers.Nodes[1].Nodes.Add(string.Empty);
    }

    private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        Process.GetCurrentProcess().Kill();
    }

    private void Form_Main_Load(object sender, EventArgs e)
    {
        this.comboBox_ServerServiceControl_StartMode.SelectedIndexChanged -= new System.EventHandler(this.comboBox_ServerServiceControl_StartMode_SelectedIndexChanged);

        this.ServiceStartMode = 0;

        this.comboBox_ServerServiceControl_StartMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_ServerServiceControl_StartMode_SelectedIndexChanged);

        this.ChangeControlsLanguage();
    }

    public void ChangeControlsLanguage()
    {
        Application.EnableVisualStyles();

        this.Text = StringFactory.GetString(1, CommonEnvironment.CurrentLanguage);

        this.button_ServerServiceControl_InstallServer.Text = StringFactory.GetString(23, CommonEnvironment.CurrentLanguage);
      
        this.label_ServerServiceControl_Login.Text = StringFactory.GetString(18, CommonEnvironment.CurrentLanguage);

        this.label_ServerServiceControl_Password.Text = StringFactory.GetString(20, CommonEnvironment.CurrentLanguage);

        this.label_ServerServiceControl_Address.Text = StringFactory.GetString(17, CommonEnvironment.CurrentLanguage);
        this.button_ServerServiceControl_UninstallServer.Text = StringFactory.GetString(24, CommonEnvironment.CurrentLanguage);
        this.groupBox_NetworkComputers.Text = StringFactory.GetString(25, CommonEnvironment.CurrentLanguage);
        this.button_ServerServiceControl_GetInformation.Text = StringFactory.GetString(16, CommonEnvironment.CurrentLanguage);

        this.label_ServerServiceControl_Domain.Text = StringFactory.GetString(19, CommonEnvironment.CurrentLanguage);

        this.languageToolStripMenuItem.Text = StringFactory.GetString(76, CommonEnvironment.CurrentLanguage);

        this.russianToolStripMenuItem.Text = StringFactory.GetString(77, CommonEnvironment.CurrentLanguage);

        this.fileToolStripMenuItem.Text = StringFactory.GetString(74, CommonEnvironment.CurrentLanguage);

        this.exitToolStripMenuItem.Text = StringFactory.GetString(75, CommonEnvironment.CurrentLanguage);


        /////////////////////////////
        this.comboBox_ServerServiceControl_StartMode.SelectedIndexChanged -= new System.EventHandler(this.comboBox_ServerServiceControl_StartMode_SelectedIndexChanged);

        int int_SelectedItemIndex = this.comboBox_ServerServiceControl_StartMode.SelectedIndex;

        this.comboBox_ServerServiceControl_StartMode.Items.Clear();

        this.comboBox_ServerServiceControl_StartMode.Items.AddRange(new object[] {
																				 StringFactory.GetString(13, CommonEnvironment.CurrentLanguage),
																				 StringFactory.GetString(14, CommonEnvironment.CurrentLanguage),
																				 StringFactory.GetString(15, CommonEnvironment.CurrentLanguage),
		});

        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 0;

        this.comboBox_ServerServiceControl_StartMode.SelectedIndex = int_SelectedItemIndex;

        this.comboBox_ServerServiceControl_StartMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_ServerServiceControl_StartMode_SelectedIndexChanged);
        /////////////////////////////


        this.label_ServerServiceControl_StartMode.Text = StringFactory.GetString(12, CommonEnvironment.CurrentLanguage);
        this.label_ServerServiceControl_ServiceState.Text = StringFactory.GetString(10, CommonEnvironment.CurrentLanguage);
        this.label_ServerServiceControl_InstallDate.Text = StringFactory.GetString(69, CommonEnvironment.CurrentLanguage);
        this.label_ServerServiceControl_ServiceStatus.Text = StringFactory.GetString(8, CommonEnvironment.CurrentLanguage);
        this.groupBox_ServerServiceControl.Text = StringFactory.GetString(26, CommonEnvironment.CurrentLanguage);
        this.label_ServerServiceControl_ProcessID.Text = StringFactory.GetString(11, CommonEnvironment.CurrentLanguage);
        
        this.label_ServerServiceControl_HostAddress.Text = StringFactory.GetString(4, CommonEnvironment.CurrentLanguage); ;

        this.label_ServerServiceControl_HostType.Text = StringFactory.GetString(5, CommonEnvironment.CurrentLanguage);

        this.label_ServerServiceControl_DesktopInteract.Text = StringFactory.GetString(7, CommonEnvironment.CurrentLanguage);

        this.label_ServerServiceControl_ServiceType.Text = StringFactory.GetString(6, CommonEnvironment.CurrentLanguage);

        this.label_ServerServiceControl_ServiceName.Text = StringFactory.GetString(9, CommonEnvironment.CurrentLanguage);

        this.groupBox_NetworkComputers.SuspendLayout();
        this.groupBox_ServerServiceControl.SuspendLayout();
    }

    #region WinAPI functions and resource declaration

    [StructLayout(LayoutKind.Sequential)]
    public struct NETRESOURCE
    {
        public int dwScope;
        public int dwType;
        public int dwDisplayType;
        public int dwUsage;
        public string LocalName;
        public string RemoteName;
        public string Comment;
        public string Provider;
    }

    [DllImport("mpr.dll", SetLastError = true)]
    static extern int WNetAddConnection2(ref NETRESOURCE netResource, string string_Password, string string_Username, int int_Flags);

    [DllImport("mpr.dll", SetLastError = true)]
    public static extern int WNetCancelConnection2(string string_Name, int int_Flags, bool bool_Force);

    #endregion

    #region Common network auth methods

    private bool ImpersonateUser(string string_Host, string string_AccountLogin, string string_AccountPassword)
    {
        NETRESOURCE netresource_obj = new NETRESOURCE();

        netresource_obj.dwType = 0x000000000;
        netresource_obj.RemoteName = @"\\" + string_Host + @"\ADMIN$"; //@\ADMIN$ is a remote Windows System32 directory
        netresource_obj.LocalName = null;
        netresource_obj.Provider = null;

        int int_AddConnectionReturnValue = WNetAddConnection2(ref netresource_obj, string_AccountPassword, string_AccountLogin, 0);

        if (int_AddConnectionReturnValue != 0)
        {
            switch (int_AddConnectionReturnValue)
            {
                case 5:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(30, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 85:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(66, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 66:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(31, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 1200:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(32, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 67:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(33, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 1206:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(34, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 1204:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(35, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 170:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(36, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 1223:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(37, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 1205:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(38, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 1202:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(39, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 1208:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(40, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 86:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(41, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 1203:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(42, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 1222:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(43, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 1326:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(44, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;

                case 1219:
                    {
                        InitializeStandardErrorEvent(StringFactory.GetString(45, CommonEnvironment.CurrentLanguage));

                        return false;
                    }
                    break;
            }
        }
        if (int_AddConnectionReturnValue != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool CloseEstablishedConnection(string string_Host)
    {
        int int_CancelConnectionReturnValue = WNetCancelConnection2(@"\\" + string_Host + @"\ADMIN$",
                                                1,      //  remove connection from profile (stored in registry) 
                                                        //  CONNECT_UPDATE_PROFILE == 1 , else == 0
                                                false); //  fail if open files or jobs 

        return true;
    }

    #endregion

    #region WMI methods

    public void RunAndDeleteJsRctServerSfxExe(string string_Host, string string_AccountLogin, string string_AccountPassword, string string_Authority, string string_ProcessDirectory, string string_SfxExeName)
    {
        ManagementOperationObserver managementOperationObserver_obj = new ManagementOperationObserver();

        ConnectionOptions connectionOptions_obj = new ConnectionOptions();

        if (IsRemoteHostIPAddress(Dns.GetHostEntry(string_Host)) == true)
        {
            connectionOptions_obj.Username = string_AccountLogin;
            connectionOptions_obj.Password = string_AccountPassword;
            connectionOptions_obj.Authority = string_Authority;
        }

        connectionOptions_obj.Impersonation = ImpersonationLevel.Impersonate;
        connectionOptions_obj.EnablePrivileges = true;

        ManagementScope managementScope_obj = new ManagementScope("\\\\" + string_Host + "\\root\\cimv2", connectionOptions_obj);

        ManagementPath managementPath_obj = new ManagementPath("Win32_Process");

        ManagementClass managementClass_obj = new ManagementClass(managementScope_obj, managementPath_obj, null);

        ManagementBaseObject managementBaseObject_InputArgs = managementClass_obj.GetMethodParameters("Create");

        managementBaseObject_InputArgs["CommandLine"] = "cmd.exe /c " + string_SfxExeName;
        managementBaseObject_InputArgs["CurrentDirectory"] = string_ProcessDirectory;
        managementBaseObject_InputArgs["ProcessStartupInformation"] = null;

        managementClass_obj.InvokeMethod("Create", managementBaseObject_InputArgs, null);

        Thread.Sleep(3000);

        managementBaseObject_InputArgs["CommandLine"] = "cmd.exe /c del " + string_SfxExeName + " /q";
        managementBaseObject_InputArgs["CurrentDirectory"] = string_ProcessDirectory;
        managementBaseObject_InputArgs["ProcessStartupInformation"] = null;

        managementClass_obj.InvokeMethod("Create", managementBaseObject_InputArgs, null);

        InitializeStepSuccessfullyCompleteEvent(string.Empty);
    }

    public string GetRemotePCSystemDirectory(string string_Host, string string_AccountLogin, string string_AccountPassword, string string_Authority)
    {
        ConnectionOptions connectionOptions_obj = new ConnectionOptions();

        if (IsRemoteHostIPAddress(Dns.GetHostEntry(string_Host)) == true)
        {
            connectionOptions_obj.Username = string_AccountLogin;
            connectionOptions_obj.Password = string_AccountPassword;
            connectionOptions_obj.Authority = string_Authority;
        }

        connectionOptions_obj.Impersonation = ImpersonationLevel.Impersonate;
        connectionOptions_obj.EnablePrivileges = true;

        ManagementScope managementScope_obj = new ManagementScope("\\\\" + string_Host + "\\root\\cimv2", connectionOptions_obj);

        ObjectQuery objectQuery_obj = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");

        ManagementObjectSearcher managementObjectSearcher_obj = new ManagementObjectSearcher(managementScope_obj, objectQuery_obj);

        ManagementObjectCollection managementObjectCollection = managementObjectSearcher_obj.Get();

        InitializeStepSuccessfullyCompleteEvent(string.Empty);

        foreach (ManagementObject managementObject_Current in managementObjectCollection)
        {
            return (string)managementObject_Current["SystemDirectory"];
        }

        return string.Empty;
    }

    public void CreateJsRctServerService(string string_Host, string string_AccountLogin, string string_AccountPassword, string string_Authority, string string_ServiceDirectory, string string_ServiceExeName)
    {
        ConnectionOptions connectionOptions_obj = new ConnectionOptions();

        // Set the options.Username and 
        // options.Password properties 
        // to the correct values and also set 
        // options.Authority = "ntdlmdomain:DOMAIN";
        // and replace DOMAIN with the remote computer's
        // domain.  You can also use kerberose instead
        // of ntdlmdomain.

        if (IsRemoteHostIPAddress(Dns.GetHostEntry(string_Host)) == true)
        {
            connectionOptions_obj.Username = string_AccountLogin;
            connectionOptions_obj.Password = string_AccountPassword;
            connectionOptions_obj.Authority = string_Authority;
        }

        ManagementScope managementScope_obj = new ManagementScope("\\\\" + string_Host + "\\root\\cimv2", connectionOptions_obj);

        ManagementPath managementPath_obj = new ManagementPath("Win32_Service");

        ManagementClass managementClass_obj = new ManagementClass(managementScope_obj, managementPath_obj, null);

        ManagementBaseObject managementBaseObject_ServiceParameters = managementClass_obj.GetMethodParameters("Create");

        managementBaseObject_ServiceParameters["Name"] = "JurikSoft Server";
        managementBaseObject_ServiceParameters["DisplayName"] = "JurikSoft Server";
        managementBaseObject_ServiceParameters["PathName"] = string_ServiceDirectory + "\\JsRct-Server WindowsService.exe";
        managementBaseObject_ServiceParameters["ServiceType"] = (byte)32;
        managementBaseObject_ServiceParameters["ErrorControl"] = (byte)0;
        managementBaseObject_ServiceParameters["StartMode"] = "Automatic";
        managementBaseObject_ServiceParameters["DesktopInteract"] = true;
        managementBaseObject_ServiceParameters["StartName"] = "LocalSystem";
        managementBaseObject_ServiceParameters["StartPassword"] = string.Empty;
        managementBaseObject_ServiceParameters["LoadOrderGroup"] = null;
        managementBaseObject_ServiceParameters["LoadOrderGroupDependencies"] = null;
        managementBaseObject_ServiceParameters["ServiceDependencies"] = null;

        ManagementBaseObject outParams = managementClass_obj.InvokeMethod("Create", managementBaseObject_ServiceParameters, null);

        InitializeStepSuccessfullyCompleteEvent(string.Empty);
    }

    public void StartJsRctServerService(string string_Host, string string_AccountLogin, string string_AccountPassword, string string_Authority)
    {
        ConnectionOptions connectionOptions_obj = new ConnectionOptions();

        if (IsRemoteHostIPAddress(Dns.GetHostEntry(string_Host)) == true)
        {
            connectionOptions_obj.Username = string_AccountLogin;
            connectionOptions_obj.Password = string_AccountPassword;
            connectionOptions_obj.Authority = string_Authority;
        }

        ManagementScope managementScope_obj = new ManagementScope("\\\\" + string_Host + "\\root\\cimv2", connectionOptions_obj);

        ObjectQuery objectQuery_obj = new ObjectQuery("select * from Win32_Service where Name=\"JurikSoft Server\"");

        ManagementObjectSearcher managementObjectSearcher_obj = new ManagementObjectSearcher(managementScope_obj, objectQuery_obj);

        ManagementObjectCollection managementObjectCollection = managementObjectSearcher_obj.Get();

        foreach (ManagementObject managementObject_Current in managementObjectCollection)
        {
            managementObject_Current.InvokeMethod("StartService", null);
        }

        InitializeStepSuccessfullyCompleteEvent(string.Empty);
    }

    public void StopJsRctServerService(string string_Host, string string_AccountLogin, string string_AccountPassword, string string_Authority)
    {
        ConnectionOptions connectionOptions_obj = new ConnectionOptions();

        if (IsRemoteHostIPAddress(Dns.GetHostEntry(string_Host)) == true)
        {
            connectionOptions_obj.Username = string_AccountLogin;
            connectionOptions_obj.Password = string_AccountPassword;
            connectionOptions_obj.Authority = string_Authority;
        }

        ManagementScope managementScope_obj = new ManagementScope("\\\\" + string_Host + "\\root\\cimv2", connectionOptions_obj);

        ObjectQuery objectQuery_obj = new ObjectQuery("select * from Win32_Service where Name=\"JurikSoft Server\"");

        EnumerationOptions enumerationOptions_obj = new EnumerationOptions();
        enumerationOptions_obj.Timeout = new TimeSpan(0, 0, 1);

        ManagementObjectSearcher managementObjectSearcher_obj = new ManagementObjectSearcher(managementScope_obj, objectQuery_obj, enumerationOptions_obj);

        ManagementObjectCollection managementObjectCollection = managementObjectSearcher_obj.Get();

        foreach (ManagementObject managementObject_Current in managementObjectCollection)
        {
            managementObject_Current.InvokeMethod("StopService", null);
        }

        InitializeStepSuccessfullyCompleteEvent(string.Empty);
    }

    public void DeleteJsRctServerService(string string_Host, string string_AccountLogin, string string_AccountPassword, string string_Authority)
    {
        ConnectionOptions connectionOptions_obj = new ConnectionOptions();

        if (IsRemoteHostIPAddress(Dns.GetHostEntry(string_Host)) == true)
        {
            connectionOptions_obj.Username = string_AccountLogin;
            connectionOptions_obj.Password = string_AccountPassword;
            connectionOptions_obj.Authority = string_Authority;
        }

        ManagementScope managementScope_obj = new ManagementScope("\\\\" + string_Host + "\\root\\cimv2", connectionOptions_obj);

        ObjectQuery objectQuery_obj = new ObjectQuery("select * from Win32_Service where Name=\"JurikSoft Server\"");

        ManagementObjectSearcher managementObjectSearcher_obj = new ManagementObjectSearcher(managementScope_obj, objectQuery_obj);

        ManagementObjectCollection managementObjectCollection = managementObjectSearcher_obj.Get();

        foreach (ManagementObject managementObject_Current in managementObjectCollection)
        {
            managementObject_Current.InvokeMethod("Delete", null);
        }

        InitializeStepSuccessfullyCompleteEvent(string.Empty);
    }

    public void UpdateServiceInformation(string string_Host, string string_AccountLogin, string string_AccountPassword, string string_Authority)
    {
        this.ServiceProcessID = string.Empty;
        this.DesktopInteract = string.Empty;
        this.InstallDate = string.Empty;
        this.ServiceName = string.Empty;
        this.ServiceState = string.Empty;
        this.ServiceType = string.Empty;
        this.ServiceStatus = string.Empty;
        this.ServiceHostAddress = string_Host;
        this.HostType = string.Empty;

        ConnectionOptions connectionOptions_obj = new ConnectionOptions();

        if (IsRemoteHostIPAddress(Dns.GetHostEntry(string_Host)) == true)
        {
            connectionOptions_obj.Username = string_AccountLogin;
            connectionOptions_obj.Password = string_AccountPassword;
            connectionOptions_obj.Authority = string_Authority;

            this.HostType = StringFactory.GetString(67, CommonEnvironment.CurrentLanguage);
        }
        else
        {
            this.HostType = StringFactory.GetString(68, CommonEnvironment.CurrentLanguage);
        }

        ManagementScope managementScope_obj = new ManagementScope("\\\\" + string_Host + "\\root\\cimv2", connectionOptions_obj);

        ObjectQuery objectQuery_obj = new ObjectQuery("select * from Win32_Service where Name=\"JurikSoft Server\"");

        ManagementObjectSearcher managementObjectSearcher_obj = new ManagementObjectSearcher(managementScope_obj, objectQuery_obj);

        ManagementObjectCollection managementObjectCollection = managementObjectSearcher_obj.Get();


        foreach (ManagementObject managementObject_Current in managementObjectCollection)
        {
            if (managementObject_Current["StartMode"] != null)
            {
                string string_ServiceStartMode = (string)managementObject_Current["StartMode"];

                if (string_ServiceStartMode == "Auto")
                {
                    this.ServiceStartMode = 0;
                }

                if (string_ServiceStartMode == "Manual")
                {
                    this.ServiceStartMode = 1;
                }

                if (string_ServiceStartMode == "Disabled")
                {
                    this.ServiceStartMode = 2;
                }
            }

            if (managementObject_Current["ProcessId"] != null)
            {
                this.ServiceProcessID = (string)managementObject_Current["ProcessId"].ToString();
            }

            if (managementObject_Current["DesktopInteract"] != null)
            {
                this.DesktopInteract = (string)managementObject_Current["DesktopInteract"].ToString();
            }

            if (managementObject_Current["InstallDate"] != null)
            {
                this.InstallDate = ((DateTime)managementObject_Current["InstallDate"]).ToShortDateString();
            }

            if (managementObject_Current["Name"] != null)
            {
                this.ServiceName = (string)managementObject_Current["Name"];
            }

            if (managementObject_Current["State"] != null)
            {
                this.ServiceState = (string)managementObject_Current["State"];
            }

            if (managementObject_Current["ServiceType"] != null)
            {
                this.ServiceType = (string)managementObject_Current["ServiceType"];
            }

            if (managementObject_Current["Status"] != null)
            {
                this.ServiceStatus = (string)managementObject_Current["Status"];
            }

            break;
        }

        InitializeCallerSuccessfullyCompleteJobEvent(string.Empty);
    }

    public void ChangeServiceStartMode(string string_Host, string string_AccountLogin, string string_AccountPassword, string string_Authority)
    {
        ConnectionOptions connectionOptions_obj = new ConnectionOptions();

        if (IsRemoteHostIPAddress(Dns.GetHostEntry(string_Host)) == true)
        {
            connectionOptions_obj.Username = string_AccountLogin;
            connectionOptions_obj.Password = string_AccountPassword;
            connectionOptions_obj.Authority = string_Authority;
        }

        ManagementScope managementScope_obj = new ManagementScope("\\\\" + string_Host + "\\root\\cimv2", connectionOptions_obj);

        ObjectQuery objectQuery_obj = new ObjectQuery("select * from Win32_Service where Name=\"JurikSoft Server\"");

        ManagementObjectSearcher managementObjectSearcher_obj = new ManagementObjectSearcher(managementScope_obj, objectQuery_obj);

        ManagementObjectCollection managementObjectCollection = managementObjectSearcher_obj.Get();

        string string_StartModeParameter = "Automatic";

        foreach (ManagementObject managementObject_Current in managementObjectCollection)
        {
            switch (this.ServiceStartMode)
            {
                case 0:
                    {
                        string_StartModeParameter = "Automatic";
                    }
                    break;

                case 1:
                    {
                        string_StartModeParameter = "Manual";
                    }
                    break;

                case 2:
                    {
                        string_StartModeParameter = "Disabled";
                    }
                    break;

                default:
                    {
                        string_StartModeParameter = "Automatic";
                    }
                    break;
            }

            managementObject_Current.InvokeMethod("ChangeStartMode", new object[1] { string_StartModeParameter });

        }

        InitializeCallerSuccessfullyCompleteJobEvent(string.Empty);
    }

    #endregion


    static Thread thread_JurikSoftServiceInstallationProcess;
    private void button_ServerServiceControl_Install_Click(object sender, EventArgs e)
    {
        Form_WorkingProgress.InstallationProcessAborted += new Form_WorkingProgress.InstallationEventHandler(Form_WorkingProgress_InstallationProcessAborted);

        thread_JurikSoftServiceInstallationProcess = new Thread(new ThreadStart(InstallJurikSoftService));

        string[] stringArray_JobsDescription = new string[7];

        stringArray_JobsDescription[0] = StringFactory.GetString(50, CommonEnvironment.CurrentLanguage);
        stringArray_JobsDescription[1] = StringFactory.GetString(51, CommonEnvironment.CurrentLanguage);
        stringArray_JobsDescription[2] = StringFactory.GetString(52, CommonEnvironment.CurrentLanguage);
        stringArray_JobsDescription[3] = StringFactory.GetString(53, CommonEnvironment.CurrentLanguage);
        stringArray_JobsDescription[4] = StringFactory.GetString(54, CommonEnvironment.CurrentLanguage);
        stringArray_JobsDescription[5] = StringFactory.GetString(55, CommonEnvironment.CurrentLanguage);
        stringArray_JobsDescription[6] = StringFactory.GetString(56, CommonEnvironment.CurrentLanguage);

        Form_WorkingProgress form_WorkingProgress_obj = new Form_WorkingProgress(stringArray_JobsDescription);

        thread_JurikSoftServiceInstallationProcess.Start();

        form_WorkingProgress_obj.ShowDialog();
    }
    public void InstallJurikSoftService()
    {
        try
        {
            string string_Host = this.NetworkAddress;
            string string_Authority = string.Empty;
            string string_AccountLogin = this.Login;
            string string_AccountPassword = this.Password;
            string string_SfxExeName = "jsrctserverarh.exe";

            if (this.Domain != string.Empty)
            {
                string_Authority = "ntdlmdomain:" + this.Domain;
            }

            if (ImpersonateUser(string_Host, string_AccountLogin, string_AccountPassword) == false)
            {
                InitializeStepSuccessfullyCompleteEvent(string.Empty);

                return;
            }

            InitializeStepSuccessfullyCompleteEvent(string.Empty);
            InitializeNextStepSuccessfullyCompleteEvent(1, 7);

            #region Create JurikSoft Server Directory

            if (Directory.Exists(@"\\" + string_Host + @"\admin$\system32\JurikSoft Server") == false)
            {
                try
                {
                    Directory.CreateDirectory(@"\\" + string_Host + @"\admin$\system32\JurikSoft Server");

                    InitializeStepSuccessfullyCompleteEvent(string.Empty);

                }
                catch (Exception exception)
                {
                    InitializeStandardErrorEvent(exception.Message);

                    return;
                }
            }
            else
            {
                InitializeObjectAlreadyExistsEvent(string.Empty);
            }

            InitializeNextStepSuccessfullyCompleteEvent(2, 7);

            #endregion

            #region Copy JurikSoft Server Files

            if (File.Exists(@"\\" + string_Host + @"\admin$\system32\JurikSoft Server\" + string_SfxExeName) == false)
            {
                try
                {
                    File.Copy(Application.StartupPath + @"\sfxarh\" + string_SfxExeName, @"\\" + string_Host + @"\admin$\system32\JurikSoft Server\" + string_SfxExeName);

                    InitializeStepSuccessfullyCompleteEvent(string.Empty);

                }
                catch (Exception exception)
                {
                    InitializeStandardErrorEvent(exception.Message);

                    return;
                }
            }
            else
            {
                InitializeObjectAlreadyExistsEvent(string.Empty);
            }

            InitializeNextStepSuccessfullyCompleteEvent(3, 7);

            #endregion

            string string_RemotePCSystemDirectory = GetRemotePCSystemDirectory(string_Host, string_AccountLogin, string_AccountPassword, string_Authority);
            InitializeNextStepSuccessfullyCompleteEvent(4, 7);

            string_RemotePCSystemDirectory += "\\JurikSoft Server";

            RunAndDeleteJsRctServerSfxExe(string_Host, string_AccountLogin, string_AccountPassword, string_Authority, string_RemotePCSystemDirectory, string_SfxExeName);
            InitializeNextStepSuccessfullyCompleteEvent(5, 7);

            CreateJsRctServerService(string_Host, string_AccountLogin, string_AccountPassword, string_Authority, string_RemotePCSystemDirectory, string_SfxExeName);
            InitializeNextStepSuccessfullyCompleteEvent(6, 7);

            StartJsRctServerService(string_Host, string_AccountLogin, string_AccountPassword, string_Authority);
            InitializeNextStepSuccessfullyCompleteEvent(7, 7);

            InitializeJobSuccessfullyCompletedEvent(StringFactory.GetString(58, CommonEnvironment.CurrentLanguage));
        }
        catch (Exception e)
        {

        }
        finally
        {
            CloseEstablishedConnection(this.NetworkAddress);
        }
    }
    void Form_WorkingProgress_InstallationProcessAborted(string string_Message)
    {
        if (thread_JurikSoftServiceInstallationProcess != null)
        {
            thread_JurikSoftServiceInstallationProcess.Abort();

            Form_WorkingProgress.InstallationProcessAborted -= new Form_WorkingProgress.InstallationEventHandler(Form_WorkingProgress_InstallationProcessAborted);
        }
    }

    static Thread thread_JurikSoftServiceUninstallProcess;
    private void button_ServerServiceControl_UninstallServer_Click(object sender, EventArgs e)
    {
        Form_WorkingProgress.UninstallProcessAborted += new Form_WorkingProgress.InstallationEventHandler(Form_WorkingProgress_UninstallProcessAborted);

        thread_JurikSoftServiceUninstallProcess = new Thread(new ThreadStart(UninstallJurikSoftService));

        thread_JurikSoftServiceUninstallProcess.Start();

        string[] stringArray_JobsDescription = new string[4];

        stringArray_JobsDescription[0] = StringFactory.GetString(50, CommonEnvironment.CurrentLanguage);
        stringArray_JobsDescription[1] = StringFactory.GetString(59, CommonEnvironment.CurrentLanguage);
        stringArray_JobsDescription[2] = StringFactory.GetString(60, CommonEnvironment.CurrentLanguage);
        stringArray_JobsDescription[3] = StringFactory.GetString(61, CommonEnvironment.CurrentLanguage);

        Form_WorkingProgress form_WorkingProgress_obj = new Form_WorkingProgress(stringArray_JobsDescription);

        form_WorkingProgress_obj.ShowDialog();
    }
    public void UninstallJurikSoftService()
    {
        try
        {
            StopService();

            string string_Host = this.NetworkAddress;
            string string_Authority = string.Empty;
            string string_AccountLogin = this.Login;
            string string_AccountPassword = this.Password;

            if (this.Domain != string.Empty)
            {
                string_Authority = "ntdlmdomain:" + this.Domain;
            }

            if (ImpersonateUser(string_Host, string_AccountLogin, string_AccountPassword) == false)
            {
                InitializeStepSuccessfullyCompleteEvent(string.Empty);

                return;
            }

            InitializeStepSuccessfullyCompleteEvent(string.Empty);
            InitializeNextStepSuccessfullyCompleteEvent(1, 4);

            StopJsRctServerService(this.NetworkAddress, this.Login, this.Password, string_Authority);
            InitializeNextStepSuccessfullyCompleteEvent(2, 4);

            DeleteJsRctServerService(this.NetworkAddress, this.Login, this.Password, string_Authority);
            InitializeNextStepSuccessfullyCompleteEvent(3, 4);

            #region Delete JurikSoft Server Files and Directory

            if (Directory.Exists(@"\\" + string_Host + @"\admin$\system32\JurikSoft Server") == true)
            {
                try
                {
                    foreach (string string_CurrentFile in Directory.GetFiles(@"\\" + string_Host + @"\admin$\system32\JurikSoft Server"))
                    {
                        File.Delete(string_CurrentFile);
                    }

                    Directory.Delete(@"\\" + string_Host + @"\admin$\system32\JurikSoft Server");

                    InitializeStepSuccessfullyCompleteEvent(string.Empty);
                }
                catch (Exception exception)
                {
                    InitializeStandardErrorEvent(exception.Message);

                    return;
                }
            }
            else
            {
                InitializeStepSuccessfullyCompleteEvent(string.Empty);
            }

            InitializeNextStepSuccessfullyCompleteEvent(4, 4);

            #endregion

            InitializeJobSuccessfullyCompletedEvent(StringFactory.GetString(62, CommonEnvironment.CurrentLanguage));
        }
        catch
        {
        }
        finally
        {
            CloseEstablishedConnection(this.NetworkAddress);
        }
    }
    void Form_WorkingProgress_UninstallProcessAborted(string string_Message)
    {
        if (thread_JurikSoftServiceInstallationProcess != null)
        {
            thread_JurikSoftServiceInstallationProcess.Abort();

            Form_WorkingProgress.UninstallProcessAborted -= new Form_WorkingProgress.InstallationEventHandler(Form_WorkingProgress_UninstallProcessAborted);
        }
    }



    void UpdateServiceInformation()
    {
        try
        {
            string string_Host = this.NetworkAddress;
            string string_Authority = string.Empty;
            string string_AccountLogin = this.Login;
            string string_AccountPassword = this.Password;

            if (this.Domain != string.Empty)
            {
                string_Authority = "ntdlmdomain:" + this.Domain;
            }

            this.comboBox_ServerServiceControl_StartMode.SelectedIndexChanged -= new System.EventHandler(this.comboBox_ServerServiceControl_StartMode_SelectedIndexChanged);

            this.UpdateServiceInformation(this.NetworkAddress, this.Login, this.Password, string_Authority);

            this.comboBox_ServerServiceControl_StartMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_ServerServiceControl_StartMode_SelectedIndexChanged);
        }
        catch(Exception exception_obj)
        {
            MessageBox.Show(exception_obj.Message);

            InitializeCallerSuccessfullyCompleteJobEvent(string.Empty);
        }
    }

    private void button_ServerServiceControl_RefreshStatus_Click(object sender, EventArgs e)
    {
        try
        {
            Form_WorkingActivity.WorkingActivityProcessAborted += new Form_WorkingActivity.InstallationEventHandler(Form_WorkingActivity_WorkingActivityProcessAborted);

            thread_WorkingActivityProcess = new Thread(new ThreadStart(UpdateServiceInformation));

            Form_WorkingActivity form_WorkingActivity_obj = new Form_WorkingActivity();

            thread_WorkingActivityProcess.Start();

            form_WorkingActivity_obj.ShowDialog();
        }
        catch
        {
        }
    }

    void ChangeServiceStartMode()
    {
        try
        {
            string string_Host = this.NetworkAddress;
            string string_Authority = string.Empty;
            string string_AccountLogin = this.Login;
            string string_AccountPassword = this.Password;

            if (this.Domain != string.Empty)
            {
                string_Authority = "ntdlmdomain:" + this.Domain;
            }

            this.ChangeServiceStartMode(this.NetworkAddress, this.Login, this.Password, string_Authority);
        }
        catch
        {
            InitializeCallerSuccessfullyCompleteJobEvent(string.Empty);
        }
    }

    private void comboBox_ServerServiceControl_StartMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Form_WorkingActivity.WorkingActivityProcessAborted += new Form_WorkingActivity.InstallationEventHandler(Form_WorkingActivity_WorkingActivityProcessAborted);

            thread_WorkingActivityProcess = new Thread(new ThreadStart(ChangeServiceStartMode));

            Form_WorkingActivity form_WorkingActivity_obj = new Form_WorkingActivity();

            thread_WorkingActivityProcess.Start();

            form_WorkingActivity_obj.ShowDialog();
        }
        catch
        {
            InitializeCallerSuccessfullyCompleteJobEvent(string.Empty);
        }
    }


    static Thread thread_WorkingActivityProcess;
    void Form_WorkingActivity_WorkingActivityProcessAborted(string string_Message)
    {
        if (thread_WorkingActivityProcess != null)
        {
            thread_WorkingActivityProcess.Abort();

            Form_WorkingActivity.WorkingActivityProcessAborted -= new Form_WorkingActivity.InstallationEventHandler(Form_WorkingActivity_WorkingActivityProcessAborted);

            Form_Main.bool_IsSearchProcessAborted = true;
        }
    }

    public void StopService()
    {
        try
        {
            string string_Authority = string.Empty;

            if (this.Domain != string.Empty)
            {
                string_Authority = "ntdlmdomain:" + this.Domain;
            }

            StopJsRctServerService(this.NetworkAddress, this.Login, this.Password, string_Authority);

            InitializeCallerSuccessfullyCompleteJobEvent(string.Empty);
        }
        catch
        {
            InitializeCallerSuccessfullyCompleteJobEvent(string.Empty);
        }
    }
    private void button_ServerServiceControl_ServiceStop_Click(object sender, EventArgs e)
    {
        try
        {
            Form_WorkingActivity.WorkingActivityProcessAborted += new Form_WorkingActivity.InstallationEventHandler(Form_WorkingActivity_WorkingActivityProcessAborted);

            thread_WorkingActivityProcess = new Thread(new ThreadStart(StopService));

            Form_WorkingActivity form_WorkingActivity_obj = new Form_WorkingActivity();

            thread_WorkingActivityProcess.Start();

            form_WorkingActivity_obj.ShowDialog();
        }
        catch
        {
            InitializeCallerSuccessfullyCompleteJobEvent(string.Empty);
        }
    }

    public void StartService()
    {
        try
        {
            string string_Authority = string.Empty;

            if (this.Domain != string.Empty)
            {
                string_Authority = "ntdlmdomain:" + this.Domain;
            }

            StartJsRctServerService(this.NetworkAddress, this.Login, this.Password, string_Authority);

            InitializeCallerSuccessfullyCompleteJobEvent(string.Empty);
        }
        catch
        {
            InitializeCallerSuccessfullyCompleteJobEvent(string.Empty);
        }
    }
    private void button_ServerServiceControl_ServiceStart_Click(object sender, EventArgs e)
    {
        try
        {
            Form_WorkingActivity.WorkingActivityProcessAborted += new Form_WorkingActivity.InstallationEventHandler(Form_WorkingActivity_WorkingActivityProcessAborted);

            thread_WorkingActivityProcess = new Thread(new ThreadStart(StartService));

            Form_WorkingActivity form_WorkingActivity_obj = new Form_WorkingActivity();

            thread_WorkingActivityProcess.Start();

            form_WorkingActivity_obj.ShowDialog();
        }
        catch
        {
            InitializeCallerSuccessfullyCompleteJobEvent(string.Empty);
        }
    }


    static string string_NetworkPath = string.Empty;
    static TreeNode treeNode_SelectedNode = null;
    static bool bool_IsSearchProcessAborted = false;

    void RefreshMSNetworkObjectsThread()
    {
        DirectoryEntry directoryEntry_RootNode = new DirectoryEntry(string_NetworkPath);

        this.Invoke((MethodInvoker)delegate
        {
            treeNode_SelectedNode.Nodes.Clear();
        });

        TreeNode treeNode_Temp = null;

        foreach (DirectoryEntry directoryEntry_CurrentNode in directoryEntry_RootNode.Children)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (directoryEntry_CurrentNode.SchemaClassName == "Domain")
                {
                    treeNode_Temp = treeNode_SelectedNode.Nodes.Add(directoryEntry_CurrentNode.Name);

                    treeNode_Temp.Nodes.Add(string.Empty);
                }

                if (directoryEntry_CurrentNode.SchemaClassName == "Computer")
                {
                    treeNode_Temp = treeNode_SelectedNode.Nodes.Add(directoryEntry_CurrentNode.Name);
                }
            });
        }

        InitializeCallerSuccessfullyCompleteJobEvent(string.Empty);

        return;
    }

    void RefreshActiveDirectoryObjectsThread()
    {
        try
        {
            DirectoryEntry directoryEntry_RootNode = new DirectoryEntry(string_NetworkPath);// + "//CN=Computers,DC=DOMAIN,DC=JS");

            DirectorySearcher directorySearcher_obj = new DirectorySearcher(directoryEntry_RootNode, "(objectClass=computer)");

            SearchResultCollection searchResultCollection_obj = directorySearcher_obj.FindAll();

            TreeNode treeNode_Temp = null;

            this.Invoke((MethodInvoker)delegate
            {
                treeNode_SelectedNode.Nodes.Clear();
            });

            foreach (SearchResult searchResult_CurrentObj in searchResultCollection_obj)
            {
                foreach (Object object_Current in searchResult_CurrentObj.Properties["distinguishedname"])
                {                    
                    if (object_Current.ToString().IndexOf("Domain Controllers") == -1)
                    {
                        if (IsHostAvailableToPing((string)searchResult_CurrentObj.Properties["name"][0]) == true)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                treeNode_Temp = treeNode_SelectedNode.Nodes.Add((string)searchResult_CurrentObj.Properties["name"][0]);
                            });
                        }
                    }                    
                }

                /*
                foreach (string myKey in searchResult_CurrentObj.Properties.PropertyNames)
                {
                    foreach (Object myCollection in searchResult_CurrentObj.Properties[myKey])
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            treeNode_Temp = treeNode_SelectedNode.Nodes.Add(myKey + "   :   " + myCollection.ToString());
                        });
                    }         
                }

                this.Invoke((MethodInvoker)delegate             
                {                
                    treeNode_Temp = treeNode_SelectedNode.Nodes.Add("");            
                });
                */
            }

            if (treeNode_SelectedNode.Nodes.Count < 1)
            {                            
                this.Invoke((MethodInvoker)delegate             
                {                
                    treeNode_Temp = treeNode_SelectedNode.Nodes.Add("");

                    treeNode_SelectedNode.Collapse();
                });
            }
        }
        catch
        {
            Thread.Sleep(600); //Need to sleep 400ms minimum (on tested P4 2000)! else the some threads sync error (with events) will appear 

            InitializeCallerSuccessfullyCompleteJobEvent(string.Empty);          

            if (thread_WorkingActivityProcess != null)
            {
                Form_WorkingActivity.WorkingActivityProcessAborted -= new Form_WorkingActivity.InstallationEventHandler(Form_WorkingActivity_WorkingActivityProcessAborted);

                Form_Main.bool_IsSearchProcessAborted = true;
            }
        }
        finally
        {
            InitializeCallerSuccessfullyCompleteJobEvent(string.Empty);
        }
    }

    bool IsHostAvailableToPing(string string_HostAddress)
    {
        try
        {
            new Ping().Send(string_HostAddress);
        }
        catch
        {
            return false;
        }

        return true;
    }

    private void treeView_Computers_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        TreeNode treeNode_Temp = e.Node;

     //   if (treeNode_Temp == null)
        {
       //     MessageBox.Show(this.treeView_Computers.SelectedNode.Index.ToString());
        }

        string string_FullNodePath = string.Empty;

        Form_Main.treeNode_SelectedNode = e.Node;

        Form_Main.bool_IsSearchProcessAborted = false;

        while (true)
        {
            if (treeNode_Temp.Parent == null)
            {
                if (treeNode_Temp.Index == 0)
                {
                    string_FullNodePath = e.Node.FullPath.Replace(treeNode_Temp.Text, string.Empty);

                    if (string_FullNodePath.Length > 0)
                    {
                        string_FullNodePath = "//" + string_FullNodePath;
                    }

                    Form_Main.string_NetworkPath = "WinNT:" + string_FullNodePath;

                    thread_WorkingActivityProcess = new Thread(new ThreadStart(RefreshMSNetworkObjectsThread));
                }

                if (treeNode_Temp.Index == 1)
                {
                    Form_Main.string_NetworkPath = "LDAP://" + this.Domain;

                    thread_WorkingActivityProcess = new Thread(new ThreadStart(RefreshActiveDirectoryObjectsThread));
                }

                break;
            }

            treeNode_Temp = treeNode_Temp.Parent;
        }

        Form_WorkingActivity.WorkingActivityProcessAborted += new Form_WorkingActivity.InstallationEventHandler(Form_WorkingActivity_WorkingActivityProcessAborted);

        Form_WorkingActivity form_WorkingActivity_obj = new Form_WorkingActivity();

        thread_WorkingActivityProcess.Start();
        
        Thread.Sleep(400);

        form_WorkingActivity_obj.ShowDialog();



        if (bool_IsSearchProcessAborted == true)
        {
            e.Cancel = true;

            Form_Main.treeNode_SelectedNode.Nodes.Clear();
            Form_Main.treeNode_SelectedNode.Nodes.Add(String.Empty);
            Form_Main.treeNode_SelectedNode.Collapse();

            bool_IsSearchProcessAborted = false;
        }
    }

    private void treeView_Computers_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (this.treeView_Computers.SelectedNode.Parent != null && this.treeView_Computers.SelectedNode.Nodes.Count == 0)
        {
            this.textBox_ServerServiceControl_Address.Text = this.treeView_Computers.SelectedNode.Text;

            TreeNode treeNode_Temp = e.Node;

            string string_FullNodePath = string.Empty;

            while (true)
            {
                if (treeNode_Temp.Parent == null)
                {
                    if (treeNode_Temp.Index == 0)
                    {
                        this.Domain = string.Empty;

                        this.textBox_ServerServiceControl_Domain.Enabled = this.label_ServerServiceControl_Domain.Enabled = false;
                    }

                    break;
                }

                if (treeNode_Temp.Parent == null)
                {
                    if (treeNode_Temp.Index == 1)
                    {
                        this.Domain = e.Node.Parent.Text;
                    }

                    break;
                }

                treeNode_Temp = treeNode_Temp.Parent;
            }
        }
    }

    #region Shared Events

    public delegate void InstallationEventHandler(string string_Message);
    public delegate void NextStepCompletedEventHandler(int int_StepNumber, int StepsCount);

    public static event InstallationEventHandler Standard_StepSuccessfullyCompleteEvent;
    public static event InstallationEventHandler Standard_Error;
    public static event InstallationEventHandler Standard_ObjectAlreadyExists;

    public static event InstallationEventHandler JobSuccessfullyCompletedEvent;

    public static event NextStepCompletedEventHandler Standard_NextStepSuccessfullyCompleteEvent;

    public static event InstallationEventHandler CallerSuccessfullyCompleteJobEvent;

    public void InitializeNextStepSuccessfullyCompleteEvent(int int_StepNumber, int StepsCount)
    {
        this.Invoke((MethodInvoker)delegate
            {
                if (Standard_NextStepSuccessfullyCompleteEvent != null)
                {
                    Standard_NextStepSuccessfullyCompleteEvent(int_StepNumber, StepsCount);
                }
            });
    }

    public void InitializeStandardErrorEvent(string string_Message)
    {
        if (Standard_Error != null)
        {
            Standard_Error(string_Message);
        }
    }

    public void InitializeStepSuccessfullyCompleteEvent(string string_Message)
    {
        if (Standard_StepSuccessfullyCompleteEvent != null)
        {
            Standard_StepSuccessfullyCompleteEvent(string_Message);
        }
    }

    public void InitializeObjectAlreadyExistsEvent(string string_Message)
    {
        if (Standard_ObjectAlreadyExists != null)
        {
            Standard_ObjectAlreadyExists(string_Message);
        }
    }

    public void InitializeJobSuccessfullyCompletedEvent(string string_Message)
    {
        if (JobSuccessfullyCompletedEvent != null)
        {
            JobSuccessfullyCompletedEvent(string_Message);
        }
    }

    public void InitializeCallerSuccessfullyCompleteJobEvent(string string_Message)
    {//!!! возникала ошибка при исключении - почему то без задержки thread.Sleep
        // не закрывалось акно активность .. какая топ роблема с потоками и событиями
        if (CallerSuccessfullyCompleteJobEvent != null)
        {
            CallerSuccessfullyCompleteJobEvent(string_Message);
        }
    }

    #endregion

    #region Safe Properties

    delegate string delegate_ReturningStringMethod();

    delegate int delegate_ReturningIntMethod();

    public string Login
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ServerServiceControl_Login.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ServerServiceControl_Login.Text = value;
            });
        }
    }

    public string Password
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ServerServiceControl_Password.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ServerServiceControl_Password.Text = value;
            });
        }
    }

    public string Domain
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ServerServiceControl_Domain.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ServerServiceControl_Domain.Text = value;
            });
        }
    }

    public string NetworkAddress
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ServerServiceControl_Address.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ServerServiceControl_Address.Text = value;
            });
        }
    }



    public int ServiceStartMode
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return this.comboBox_ServerServiceControl_StartMode.SelectedIndex;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.comboBox_ServerServiceControl_StartMode.SelectedIndex = value;
            });
        }
    }

    public string ServiceProcessID
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ServerServiceControl_ProcessID.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ServerServiceControl_ProcessID.Text = value;
            });
        }
    }

    public string DesktopInteract
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ServerServiceControl_DesktopInteract.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ServerServiceControl_DesktopInteract.Text = value;
            });
        }
    }

    public string ServiceHostAddress
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ServerServiceControl_HostAddress.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ServerServiceControl_HostAddress.Text = value;
            });
        }
    }

    public string HostType
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ServerServiceControl_HostType.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ServerServiceControl_HostType.Text = value;
            });
        }
    }

    public string InstallDate
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ServerServiceControl_InstallDate.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ServerServiceControl_InstallDate.Text = value;
            });
        }
    }

    public string ServiceName
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ServerServiceControl_ServiceName.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ServerServiceControl_ServiceName.Text = value;
            });
        }
    }

    public string ServiceState
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ServerServiceControl_ServiceState.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ServerServiceControl_ServiceState.Text = value;
            });
        }
    }

    public string ServiceType
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ServerServiceControl_ServiceType.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ServerServiceControl_ServiceType.Text = value;
            });
        }
    }

    public string ServiceStatus
    {
        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_ServerServiceControl_ServiceStatus.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_ServerServiceControl_ServiceStatus.Text = value;
            });
        }
    }

    #endregion

    bool IsRemoteHostIPAddress(IPHostEntry iPHostEntry_obj)
    {
        foreach (NetworkInterface networkInterface_CurrentObj in NetworkInterface.GetAllNetworkInterfaces())
        {
            foreach (IPAddressInformation iPAddressInformation_AnycastAddressCurrentObj in networkInterface_CurrentObj.GetIPProperties().AnycastAddresses)
            {
                if (iPHostEntry_obj.AddressList[0].Address == iPAddressInformation_AnycastAddressCurrentObj.Address.Address)
                {
                    return false;
                }
            }

            foreach (IPAddressInformation iPAddressInformation_UnicastAddressCurrentObj in networkInterface_CurrentObj.GetIPProperties().UnicastAddresses)
            {
                if (iPHostEntry_obj.AddressList[0].Address == iPAddressInformation_UnicastAddressCurrentObj.Address.Address)
                {
                    return false;
                }
            }

            foreach (IPAddressInformation iPAddressInformation_MulticastAddressCurrentObj in networkInterface_CurrentObj.GetIPProperties().MulticastAddresses)
            {
                if (iPHostEntry_obj.AddressList[0].Address == iPAddressInformation_MulticastAddressCurrentObj.Address.Address)
                {
                    return false;
                }
            }
        }

        return true;
    }




    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if(DialogResult.Yes == MessageBox.Show(StringFactory.GetString(79, CommonEnvironment.CurrentLanguage), StringFactory.GetString(1, CommonEnvironment.CurrentLanguage), MessageBoxButtons.YesNo))
        {
            Application.Exit();
        }
    }

    private void russianToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.russianToolStripMenuItem.Checked != true)
        {
            this.russianToolStripMenuItem.Checked = true;

            this.englishToolStripMenuItem.Checked = false;

            CommonEnvironment.CurrentLanguage = 1;

            this.ChangeControlsLanguage();
        }
    }

    private void englishToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.englishToolStripMenuItem.Checked != true)
        {
            this.russianToolStripMenuItem.Checked = false;

            this.englishToolStripMenuItem.Checked = true;

            CommonEnvironment.CurrentLanguage = 0;

            this.ChangeControlsLanguage();
        }
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }
}
