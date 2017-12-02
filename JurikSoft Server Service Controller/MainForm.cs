using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace JurikSoft_Server_Service_Controller
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        void ServiceStatusMonitor()
        {
            for (; ;)
            {
                Thread.Sleep(1000);

                this.RefreshServiceStatus();

                if (this.FormIsClosed == true)
                {
                    return;
                }
            }
        }

        public void RefreshServiceStatus()
        {
            try
            {
                if (this.IsHandleCreated == false) return;

                this.Invoke((MethodInvoker)delegate
                {
                    this.serviceController_Main.Refresh();

                    this.label_MainForm_ServiceStatus.Text = "Service Status: " + serviceController_Main.Status.ToString();

                    if (serviceController_Main.Status == System.ServiceProcess.ServiceControllerStatus.Stopped ||
                        serviceController_Main.Status == System.ServiceProcess.ServiceControllerStatus.StopPending)
                    {
                        this.button_MainForm_ServiceStop.Enabled = false;
                        this.button_MainForm_ServiceStart.Enabled = true;
                    }
                    else
                    {
                        this.button_MainForm_ServiceStop.Enabled = true;
                        this.button_MainForm_ServiceStart.Enabled = false;
                    }
                });


            }
            catch
            {
                return;
            }
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.RefreshServiceStatus();

            new Thread(new ThreadStart(ServiceStatusMonitor)).Start();
        }

        private void button_MainForm_ServiceStart_Click(object sender, EventArgs e)
        {
            try
            {
                this.serviceController_Main.Start();
            }
            catch { }
        }

        private void button_MainForm_ServiceStop_Click(object sender, EventArgs e)
        {
            try
            {
                this.serviceController_Main.Stop();
            }
            catch { }
        }

        private void button_MainForm_ServiceStart_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                this.serviceController_Main.Refresh();

                if (serviceController_Main.Status == System.ServiceProcess.ServiceControllerStatus.Running ||                
                    serviceController_Main.Status == System.ServiceProcess.ServiceControllerStatus.StartPending)
                {
                    this.button_MainForm_ServiceStart.Enabled = false;
                    this.button_MainForm_ServiceStop.Enabled = true;
                }
                else
                {
                    this.button_MainForm_ServiceStart.Enabled = true;
                    this.button_MainForm_ServiceStop.Enabled = false;
                }
            }
            catch { }
        }

        private void button_MainForm_ServiceStop_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                this.serviceController_Main.Refresh();

                if (serviceController_Main.Status == System.ServiceProcess.ServiceControllerStatus.Stopped ||
                    serviceController_Main.Status == System.ServiceProcess.ServiceControllerStatus.StopPending)
                {
                    this.button_MainForm_ServiceStop.Enabled = false;
                    this.button_MainForm_ServiceStart.Enabled = true;
                }
                else
                {
                    this.button_MainForm_ServiceStop.Enabled = true;
                    this.button_MainForm_ServiceStart.Enabled = false;
                }
            }
            catch { }
        }

        delegate bool delegate_ReturningBoolMethod();

        bool FormIsClosed
        {
            get
            {
                if (this.IsHandleCreated == false) return true;

                return (bool)this.Invoke((delegate_ReturningBoolMethod)delegate
                {
                    return this.bool_FormIsClosed;
                });
            }
        }

        bool bool_FormIsClosed = false;

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            bool_FormIsClosed = true;
        }

    }
}