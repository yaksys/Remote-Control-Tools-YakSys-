using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctServer;
using JurikSoft.XMLConfigImporer.JsRctServer.Version110;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels;
using JurikSoft.Server_Core;
using System.Security.Principal;
using System.Runtime.InteropServices;


public partial class JurikSoftServerWindowsService : ServiceBase
{
    public JurikSoftServerWindowsService()
    {
        InitializeComponent();
    }


    //!!! ������ ����� IPC � �������� ������� �� ������� ������������� ?
    public static NetworkAction obj_NetworkAction = (NetworkAction)Activator.GetObject(typeof(NetworkAction), "ipc://ZNIIS Server Service IPC Port/ZNIIS Server/ClassObj_NetworkAction_URI");



protected void KillProcWindowModule()
    {
        try
        {
            Process[] processArray_Info = Process.GetProcesses();

            foreach (Process processArray_CurrentProcess in processArray_Info)
            {
                if (processArray_CurrentProcess.ProcessName == "Remote Control Tools ProcWindow")
                {
                    processArray_CurrentProcess.Kill();

                    KillProcWindowModule();

                    return;
                }
            }
        }

        catch (Exception e)
        {
            KillProcWindowModule();

            return;
        }
    }

    protected void ReloadProcWindowModule()//!!!!
    {
        //return;//!!!!
        try
        {
            Process[] processArray_Info = Process.GetProcesses();

            foreach (Process processArray_CurrentProcess in processArray_Info)
            {
                if (processArray_CurrentProcess.ProcessName == "Remote Control Tools ProcWindow")
                {
                    processArray_CurrentProcess.Kill();

                    ReloadProcWindowModule();

                    return;
                }
            }
        }

        catch (Exception e)
        {
            ReloadProcWindowModule();

            return;
        }

        ProcessStartInfo ExecutingProcessStartInfo = new ProcessStartInfo();
        
        ExecutingProcessStartInfo.LoadUserProfile = true;

        ExecutingProcessStartInfo.FileName = "Remote Control Tools ProcWindow.exe";
        ExecutingProcessStartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

        ExecutingProcessStartInfo.WindowStyle = ProcessWindowStyle.Normal;

        ExecutingProcessStartInfo.CreateNoWindow = false;
        ExecutingProcessStartInfo.UseShellExecute = false;
        ExecutingProcessStartInfo.ErrorDialog = true;

        Process.Start(ExecutingProcessStartInfo);
    }


    protected bool bool_NeedToStopProcWinWatcher = false;



    protected void WatchProcWindowModule()
    {
        /////////////////////////////////
        try
        {
            if (WindowsIdentity.GetCurrent() == null)
            {
                KillProcWindowModule();

                Thread.Sleep(10000);

                WatchProcWindowModule();

                return;
            }
        }
        catch
        {
            KillProcWindowModule();

            Thread.Sleep(10000);

            WatchProcWindowModule();

            return;
        }
        ///////////////////////////////

        if (bool_NeedToStopProcWinWatcher == true) return;

        try
        {

            Thread.Sleep(5000);

            Process[] processArray_Info = Process.GetProcesses();

            foreach (Process processArray_CurrentProcess in processArray_Info)
            {
                if (processArray_CurrentProcess.ProcessName == "Remote Control Tools ProcWindow")
                {
                    Thread.Sleep(10000);

                    WatchProcWindowModule();

                    return;
                }
            }
        }

        catch (Exception e)
        {

        }

        ReloadProcWindowModule();

        WatchProcWindowModule();
    }



    protected override void OnStart(string[] args)
    {
        try
        {
            Thread.CurrentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

            System.Threading.Thread.Sleep(1000);

            ServiceController serviceController_obj = new ServiceController("ZNIIS Server");

            if (!File.Exists(Application.StartupPath + "\\JsRctServerLib.dll"))
            {
                try
                {
                    MessageBox.Show(null, ServerStringFactory.GetString(36, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(37, ServerSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);

                    serviceController_obj.Refresh();

                    serviceController_obj.Stop();
                }
                catch
                {
                }

                return;
            }

            new Thread(new ThreadStart(WatchProcWindowModule)).Start();

            JurikSoft.XMLConfigImporer.JSServerDBEnvironment.LoadXMLDataFile(Application.StartupPath + "\\JurikSoftServerDB", false);

            NetworkSecurity.LoadSecurityDB(new JSServerDBEnvironment().GetSecurityDataBase());

            NetworkSecurity.LoadAccessRestrictionRulesDB(new JSServerDBEnvironment().GetAccessRestrictionRules());

            NETRemotingInteractionLayer.StartNETRemotingHost(5550);

            NetworkStatusAndStatistics.ServerStatus = ServerStringFactory.GetString(7, ServerSettingsEnvironment.CurrentLanguage);

            if (ServerSettingsEnvironment.StartServerAtRun == true)
            {
                if (NetworkSecurity.UserAccount.UsersAccounts.Count == 0)
                {
                    MessageBox.Show(ServerStringFactory.GetString(69, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    obj_NetworkAction.StartServer(ServerSettingsEnvironment.ServerPort);//IPC call

                    string string_ConnectingServiceHost = CSP.ConnectingServiceProvider.GetCommonCSPIPString();         
                }
            }
        }
        catch (Exception e)
        {
            // MessageBox.Show("Starting JurikSoft Server Service failed");
        }
    }

    void UnregisterAllIPCChannels()
    {
        if (ChannelServices.RegisteredChannels.Length > 0)
        {
            ChannelServices.UnregisterChannel(ChannelServices.GetChannel(ChannelServices.RegisteredChannels[0].ChannelName));

            UnregisterAllIPCChannels();
        }
    }

    protected override void OnStop()
    {
        //!!ObjCopy.obj_NetworkAction.StopServer();//!!�������� �� IPC
        obj_NetworkAction.StopServer();//IPC call

        new JSServerDBEnvironment().WriteServerSettingsData(Application.StartupPath + "\\JurikSoftServerDB");

        UnregisterAllIPCChannels();

        bool_NeedToStopProcWinWatcher = true;

        Thread.Sleep(500);

        KillProcWindowModule();

        Process.GetCurrentProcess().Kill();
    }
}

