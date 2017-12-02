﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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






namespace YakRCTServerProcess
{
    public partial class Form_yakServer_Main : Form
    {
        public Form_yakServer_Main()
        {
            InitializeComponent();
        }

        private void button_StartYakRCT_Click(object sender, EventArgs e)
        {
            try
            {
                Thread.CurrentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

                System.Threading.Thread.Sleep(1000);

                //!!ServiceController serviceController_obj = new ServiceController("JurikSoft Server");

                if (!File.Exists(Application.StartupPath + "\\JsRctServerLib.dll"))
                {
                    try
                    {
                        MessageBox.Show(null, ServerStringFactory.GetString(36, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(37, ServerSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
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
            catch (Exception)
            {
                // MessageBox.Show("Starting JurikSoft Server Service failed");
            }
        }






        //!!! почему через IPC и локально события по разному привязываются ?
        public static NetworkAction obj_NetworkAction = (NetworkAction)Activator.GetObject(typeof(NetworkAction), "ipc://JurikSoft Server Service IPC Port/JurikSoft Server/ClassObj_NetworkAction_URI");




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





        void UnregisterAllIPCChannels()
        {
            if (ChannelServices.RegisteredChannels.Length > 0)
            {
                ChannelServices.UnregisterChannel(ChannelServices.GetChannel(ChannelServices.RegisteredChannels[0].ChannelName));

                UnregisterAllIPCChannels();
            }
        }

        protected  void OnStop()
        {

            try
            {

                //!!ObjCopy.obj_NetworkAction.StopServer();//!!заменено на IPC
                obj_NetworkAction.StopServer();//IPC call

                new JSServerDBEnvironment().WriteServerSettingsData(Application.StartupPath + "\\JurikSoftServerDB");

                UnregisterAllIPCChannels();

            }
            catch { }


            bool_NeedToStopProcWinWatcher = true;

            Thread.Sleep(500);

            KillProcWindowModule();

            Process.GetCurrentProcess().Kill();
        }

        private void button_StopRCT_Click(object sender, EventArgs e)
        {
            OnStop();
        }

        private void Form_yakServer_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnStop();
        }

        private void button_ServerGUI_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("Remote Control Tools Server (Windows Service) GUI.exe");
            }
            catch
            {
            }
        }
    }
}
