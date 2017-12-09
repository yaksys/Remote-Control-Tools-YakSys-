using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using YakSys.RCTServiceGUI;
using YakSys.Server_Core;
using YakSys.XMLConfigImporter.YakSysRctServer.Version110;

public partial class ConnectingServiceProviderForm : Form
{
    public ConnectingServiceProviderForm()
    {
        InitializeComponent();

        this.Select();

        RetriveCSPSettings();

        SetLanguageSettings();

        this.checkBox_ServerAuthSettings_UseCommonJSCSPService_CheckedChanged(null, null);
        this.checkBox_ChangeUINAccountState_UseCommonJSCSPService_CheckedChanged(null, null);

        new Thread(new ThreadStart(MonitorConnectionStatus)).Start();
    }

    void RetriveCSPSettings()
    {
        this.textBox_CSPForm_ServerAuth_CustomCSPServiceIPAddress.Text = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_CustomCSPServiceIPAddress;
        this.textBox_CSPForm_ServerAuth_CustomCSPServicePort.Text = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_CustomCSPServicePort.ToString();
        this.textBox_CSPForm_ServerAuth_CSPLoginPassword.Text = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_CSPLoginPassword;
        this.textBox_CSPForm_ServerAuth_CSPLoginUIN.Text = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_CSPLoginUIN;
        this.checkBox_ServerAuthSettings_UseCommonJSCSPService.Checked = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_UseYakSysCSPServer;
        this.checkBox_ServerAuthSettings_KeepConnectionAlive.Checked = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_KeepConnectionAlive;
        this.checkBox_ServerAuthSettings_IsServerPublic.Checked = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_IsPublicServer;
        this.checkBox_ServerAuthSettings_HideServerIP.Checked = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_HideIP;
        this.checkBox_ServerAuthSettings_ConnectAtStartUp.Checked = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_ConnectAtStartUp;

        this.checkBox_ChangeUINAccountState_GetActivationCode.Checked = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_GetActivationCode;
        this.checkBox_ChangeUINAccountState_UseCommonJSCSPService.Checked = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_UseYakSysCSPServer;
        this.textBox_ChangeUINAccountState_CustomCSPServiceIPAddress.Text = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_CustomCSPServiceIPAddress;
        this.textBox_ChangeUINAccountState_CustomCSPServicePort.Text = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_CustomCSPServicePort.ToString();
        this.textBox_ChangeUINAccountState_UIN.Text = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_UIN;
        this.textBox_ChangeUINAccountState_Password.Text = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_Password;
        this.textBox_ChangeUINAccountState_UINActivationCode.Text = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_UINActivationCode;
        this.comboBox_ChangeUINAccountState_NewAccountState.SelectedIndex = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_NewAccountStateIndex;
    }
    void SaveCSPSettings()
    {
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_CustomCSPServiceIPAddress = this.textBox_CSPForm_ServerAuth_CustomCSPServiceIPAddress.Text;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_CustomCSPServicePort = CSP_ServerAuth_CSPPort;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_CSPLoginPassword = this.textBox_CSPForm_ServerAuth_CSPLoginPassword.Text;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_CSPLoginUIN = this.textBox_CSPForm_ServerAuth_CSPLoginUIN.Text;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_UseYakSysCSPServer = this.checkBox_ServerAuthSettings_UseCommonJSCSPService.Checked;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_KeepConnectionAlive = this.checkBox_ServerAuthSettings_KeepConnectionAlive.Checked;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_IsPublicServer = this.checkBox_ServerAuthSettings_IsServerPublic.Checked;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_HideIP = this.checkBox_ServerAuthSettings_HideServerIP.Checked;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ServerAuth_ConnectAtStartUp = this.checkBox_ServerAuthSettings_ConnectAtStartUp.Checked;

        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_GetActivationCode = this.checkBox_ChangeUINAccountState_GetActivationCode.Checked;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_UseYakSysCSPServer = this.checkBox_ChangeUINAccountState_UseCommonJSCSPService.Checked;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_CustomCSPServiceIPAddress = this.textBox_ChangeUINAccountState_CustomCSPServiceIPAddress.Text;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_CustomCSPServicePort = CSP_ChangeUINAccountState_CSPPort;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_UIN = this.textBox_ChangeUINAccountState_UIN.Text;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_Password = this.textBox_ChangeUINAccountState_Password.Text;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_UINActivationCode = this.textBox_ChangeUINAccountState_UINActivationCode.Text;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CSP_ChangeUINAccountState_NewAccountStateIndex = this.comboBox_ChangeUINAccountState_NewAccountState.SelectedIndex;

        LocalObjCopy.obj_YakSysRctServerV110XMLConfigImporter.SaveCSPSettingsXmlDB();
    }

    void SetLanguageSettings()
    {
        this.groupBox_CSPForm_ServerAuthSettings.Text = ServerStringFactory.GetString(778, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_CSPForm_ServerAuth_RegisterNewUIN.Text = ServerStringFactory.GetString(768, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_CSPForm_ServerAuth_ConnectionStatus.Text = ServerStringFactory.GetString(777, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_CSPForm_ServerAuth_Connect.Text = ServerStringFactory.GetString(776, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_CSPForm_ServerAuth_CustomCSPServicePort.Text = ServerStringFactory.GetString(8, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_CSPForm_ServerAuth_CustomCSPServiceIPAddress.Text = ServerStringFactory.GetString(763, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.checkBox_ServerAuthSettings_UseCommonJSCSPService.Text = ServerStringFactory.GetString(764, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_CSPForm_ServerAuth_CSPLoginPassword.Text = ServerStringFactory.GetString(775, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_CSPForm_ServerAuth_CSPLoginUIN.Text = ServerStringFactory.GetString(767, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.textBox_CSPForm_ServerAuth_ConnectionStatus.Text = ServerStringFactory.GetString(780, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.checkBox_ServerAuthSettings_ConnectAtStartUp.Text = ServerStringFactory.GetString(784, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.checkBox_ServerAuthSettings_HideServerIP.Text = ServerStringFactory.GetString(782, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.checkBox_ServerAuthSettings_IsServerPublic.Text = ServerStringFactory.GetString(783, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.checkBox_ServerAuthSettings_KeepConnectionAlive.Text = ServerStringFactory.GetString(785, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        this.groupBox_ChangeUINAccountState_AccountControl.Text = ServerStringFactory.GetString(774, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_ChangeUINAccountState_NewAccountState.Text = ServerStringFactory.GetString(771, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_ChangeUINAccountState_UINActivationCode.Text = ServerStringFactory.GetString(786, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_ChangeUINAccountState_Status.Text = ServerStringFactory.GetString(777, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_ChangeUINAccountState_ProcessNewAccountState.Text = ServerStringFactory.GetString(713, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_ChangeUINAccountState_UIN.Text = ServerStringFactory.GetString(767, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_ChangeUINAccountState_CustomCSPServicePort.Text = ServerStringFactory.GetString(8, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_ChangeUINAccountState_CustomCSPServiceIPAddress.Text = ServerStringFactory.GetString(763, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_ChangeUINAccountState_Password.Text = ServerStringFactory.GetString(775, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.checkBox_ChangeUINAccountState_UseCommonJSCSPService.Text = ServerStringFactory.GetString(764, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.checkBox_ChangeUINAccountState_GetActivationCode.Text = ServerStringFactory.GetString(769, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.textBox_ChangeUINAccountState_Status.Text = ServerStringFactory.GetString(780, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        int int_SelectedItemIndex = this.comboBox_ChangeUINAccountState_NewAccountState.SelectedIndex;

        this.comboBox_ChangeUINAccountState_NewAccountState.Items.Clear();
        this.comboBox_ChangeUINAccountState_NewAccountState.Items.AddRange(new object[] {
																				 ServerStringFactory.GetString(772, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage),
																				 ServerStringFactory.GetString(773, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage)
		});

        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 0;

        this.comboBox_ChangeUINAccountState_NewAccountState.SelectedIndex = int_SelectedItemIndex;

    }

    private void ConnectingServiceProviderForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        SaveCSPSettings();
    }


    private void button_CSPForm_ConnectingServiceSettings_RefreshPublicServersList_Click(object sender, EventArgs e)
    {

    }

    private void button_CSPForm_ConnectingServiceSettings_RegisterNewUIN_Click(object sender, EventArgs e)
    {

    }


    #region Events Processing

    void ServerUINActivatedEventProcessing(ulong ulong_ActivatedUIN)
    {
        MessageBox.Show(ServerStringFactory.GetString(791, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage) + ulong_ActivatedUIN.ToString());

        CSP.CommonNetworkEvents.ClientUINActivatedEvent -= ServerUINActivatedEventProcessing;
    }

    void ServerUINDeActivatedEventProcessing(ulong ulong_DeActivatedUIN)
    {
        MessageBox.Show(ServerStringFactory.GetString(792, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage) + ulong_DeActivatedUIN.ToString());

        CSP.CommonNetworkEvents.ServerUINDeActivatedEvent -= ServerUINDeActivatedEventProcessing;
    }

    #endregion

    #region Properties

    ulong CSP_ServerAuth_CSPLoginUIN
    {
        get
        {
            string string_CSPLoginUIN = this.textBox_CSPForm_ServerAuth_CSPLoginUIN.Text;

            ulong ulong_CSPLoginUIN = 0;

            if (ulong.TryParse(string_CSPLoginUIN, out ulong_CSPLoginUIN) == true)
            {
            }
            else
            {
                MessageBox.Show(ServerStringFactory.GetString(789, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

                return 0;
            }

            return ulong_CSPLoginUIN;
        }
    }

    int CSP_ServerAuth_CSPPort
    {
        get
        {
            string string_ConnectingServicePort = this.textBox_CSPForm_ServerAuth_CustomCSPServicePort.Text;

            int int_ConnectingServicePort = 5545;

            if (int.TryParse(string_ConnectingServicePort, out int_ConnectingServicePort) == true)
            {
                if (int_ConnectingServicePort < 1024 || int_ConnectingServicePort > 65535)
                {
                    MessageBox.Show(ServerStringFactory.GetString(788, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

                    return 0;
                }
            }
            else
            {
                MessageBox.Show(ServerStringFactory.GetString(787, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

                return 0;
            }

            return int_ConnectingServicePort;
        }
    }

    int CSP_ChangeUINAccountState_CSPPort
    {
        get
        {
            string string_ConnectingServicePort = this.textBox_ChangeUINAccountState_CustomCSPServicePort.Text;

            int int_ConnectingServicePort = 5545;

            if (int.TryParse(string_ConnectingServicePort, out int_ConnectingServicePort) == true)
            {
                if (int_ConnectingServicePort < 1024 || int_ConnectingServicePort > 65535)
                {
                    MessageBox.Show(ServerStringFactory.GetString(788, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

                    return 0;
                }
            }
            else
            {
                MessageBox.Show(ServerStringFactory.GetString(787, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

                return 0;
            }

            return int_ConnectingServicePort;
        }
    }

    int CSP_ProxySettings_CSPPort
    {
        get
        {
            string string_ConnectingServicePort = this.textBox_CSPForm_ProxySettings_ProxyPort.Text;

            int int_ConnectingServicePort = 5545;

            if (int.TryParse(string_ConnectingServicePort, out int_ConnectingServicePort) == true)
            {
                if (int_ConnectingServicePort < 1024 || int_ConnectingServicePort > 65535)
                {
                    MessageBox.Show(ServerStringFactory.GetString(788, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

                    return 0;
                }
            }
            else
            {
                MessageBox.Show(ServerStringFactory.GetString(787, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

                return 0;
            }

            return int_ConnectingServicePort;
        }
    }

    #endregion

    void ServerDisconnectionEventProcessing()
    {
        switch (LocalObjCopy.obj_NetworkAction.disconnectionReason_LastResult)
        {
            case CSP.CommonNetworkEvents.DisconnectionReason.AuthFailure:
                {
                    MessageBox.Show(ServerStringFactory.GetString(799, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
                }
                break;

            case CSP.CommonNetworkEvents.DisconnectionReason.DisconnectByAdmin:
                {
                    MessageBox.Show(ServerStringFactory.GetString(800, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
                }
                break;

            case CSP.CommonNetworkEvents.DisconnectionReason.MaxConnectionLimit:
                {
                    MessageBox.Show(ServerStringFactory.GetString(801, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
                }
                break;

            case CSP.CommonNetworkEvents.DisconnectionReason.MaxConnectionsPerAccountLimit:
                {
                    MessageBox.Show(ServerStringFactory.GetString(802, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
                }
                break;

            case CSP.CommonNetworkEvents.DisconnectionReason.AccountRemoved:
                {
                    MessageBox.Show(ServerStringFactory.GetString(803, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
                }
                break;

            case CSP.CommonNetworkEvents.DisconnectionReason.DisconnectAllClientsByAdmin:
                {
                    MessageBox.Show(ServerStringFactory.GetString(804, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
                }
                break;

            case CSP.CommonNetworkEvents.DisconnectionReason.ConnectionClosedByOperaionCompleted:
                {
                    MessageBox.Show(ServerStringFactory.GetString(805, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
                }
                break;

            case CSP.CommonNetworkEvents.DisconnectionReason.ConnectionClosedByUserRequest:
                {
                    MessageBox.Show(ServerStringFactory.GetString(806, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
                }
                break;

            case CSP.CommonNetworkEvents.DisconnectionReason.ConnectionLost:
                {
                    MessageBox.Show(ServerStringFactory.GetString(807, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
                }
                break;

            case CSP.CommonNetworkEvents.DisconnectionReason.ExceptionThrownInReceivedCycle:
                {
                    MessageBox.Show(ServerStringFactory.GetString(808, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
                }
                break;

            case CSP.CommonNetworkEvents.DisconnectionReason.RequestedServerNotConnected:
                {
                    MessageBox.Show(ServerStringFactory.GetString(809, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
                }
                break;
        }

        (LocalObjCopy.obj_NetworkAction.disconnectionReason_LastResult) = (CSP.CommonNetworkEvents.DisconnectionReason) (- 1); // Clear  to unused value for blocking notify when user disconnected manually!!!
        
        ObjCopy.obj_NetworkAction.IsCSPServerObjConnected();

        ObjCopy.obj_NetworkAction.DisconnectFromCSP();
    }
               

    void MonitorConnectionStatus()
    {
        try
        {
            bool bool_IsMessageFirstTimeShown = false;

            while (this.IsDisposed == false && this.IsHandleCreated == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (LocalObjCopy.obj_NetworkAction.IsPublishServerCallWorking() == false)
                    {
                        this.button_CSPForm_ServerAuth_Connect.Enabled = true;

                        if (LocalObjCopy.obj_NetworkAction.IsCSPServerObjConnected() == false)
                        {
                            this.textBox_CSPForm_ServerAuth_ConnectionStatus.Text = ServerStringFactory.GetString(780, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

                            this.button_CSPForm_ServerAuth_Connect.Text = ServerStringFactory.GetString(776, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

                            if (bool_IsMessageFirstTimeShown == true)
                            {
                                bool_IsMessageFirstTimeShown = false;

                                ServerDisconnectionEventProcessing();
                            }
                        }
                        else
                        {
                            this.textBox_CSPForm_ServerAuth_ConnectionStatus.Text = ServerStringFactory.GetString(629, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

                            this.button_CSPForm_ServerAuth_Connect.Text = ServerStringFactory.GetString(779, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
                        }
                    }
                    else
                    {
                        bool_IsMessageFirstTimeShown = true;
                    }
                });

                if (LocalObjCopy.obj_NetworkAction.IsCSPServerObjConnected() == true)
                {
                    Thread.Sleep(2000);
                }
                else
                {
                    Thread.Sleep(200);
                }
            }
        }
        catch
        {
        }
        finally
        {
            this.button_CSPForm_ServerAuth_Connect.Enabled = true;
        }
    }

    private void button_CSPForm_ServerAuth_Connect_Click(object sender, EventArgs e)
    {
        try
        {
            if (LocalObjCopy.obj_NetworkAction.IsCSPServerObjConnected() == true)
            {
                ObjCopy.obj_NetworkAction.DisconnectFromCSP();

                this.button_CSPForm_ServerAuth_Connect.Enabled = false;

                return;
            }


            this.button_CSPForm_ServerAuth_Connect.Enabled = false;

            this.textBox_CSPForm_ServerAuth_ConnectionStatus.Text = ServerStringFactory.GetString(781, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
            this.textBox_CSPForm_ServerAuth_ConnectionStatus.Refresh();

            ObjCopy.obj_NetworkAction.DisconnectFromCSP();
            
            ConnectUsingCSP();

            if (LocalObjCopy.obj_NetworkAction.RemotingWrapper_InstanceCount > 0)
            {
                LocalObjCopy.obj_MainServerForm.ServerStatus = ServerStringFactory.GetString(56, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
            }
            else
            {
                LocalObjCopy.obj_MainServerForm.ServerStatus = ServerStringFactory.GetString(7, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
            }
        }

        catch(Exception ex)
        {

        }
    }

    private void button_CSPForm_ServerAuth_Disconnect_Click(object sender, EventArgs e)
    {
        new Thread(new ThreadStart(ObjCopy.obj_NetworkAction.DisconnectFromCSP)).Start();
    }

    public void ConnectUsingCSP()
    {
        string string_ConnectingServiceHost = this.textBox_CSPForm_ServerAuth_CustomCSPServiceIPAddress.Text,
              string_ConnectingServicePort = this.textBox_CSPForm_ServerAuth_CustomCSPServicePort.Text,
              string_CSPLoginUIN = this.textBox_CSPForm_ServerAuth_CSPLoginUIN.Text,
              string_CSPLoginPassword = this.textBox_CSPForm_ServerAuth_CSPLoginPassword.Text;

        bool bool_HideIP = this.checkBox_ServerAuthSettings_HideServerIP.Checked,
             bool_IsServerPublic = this.checkBox_ServerAuthSettings_IsServerPublic.Checked,
             bool_UseCommonJSCSPService = this.checkBox_ServerAuthSettings_UseCommonJSCSPService.Checked,
             bool_KeepConnectionAlive = this.checkBox_ServerAuthSettings_KeepConnectionAlive.Checked;
        
        ulong ulong_CSPLoginUIN = CSP_ServerAuth_CSPLoginUIN;
        int int_ConnectingServicePort = CSP_ServerAuth_CSPPort;

        if (int_ConnectingServicePort == 0 || ulong_CSPLoginUIN == 0)
        {
            return;
        }

        LocalObjCopy.obj_NetworkAction.CSP_PublishServerWrapper(bool_UseCommonJSCSPService, string_ConnectingServiceHost, int_ConnectingServicePort, ulong_CSPLoginUIN, string_CSPLoginPassword, bool_HideIP, bool_IsServerPublic, bool_KeepConnectionAlive);
    }

    public bool IsCSPObjConnected(CSP.ConnectedServer checkedCSPServer_obj)
    {
        if (checkedCSPServer_obj != null && checkedCSPServer_obj.SystemChannel != null && checkedCSPServer_obj.SystemChannel.IsConnected == true)
        {
            try
            {
                checkedCSPServer_obj.CheckConnection();
            }
            catch
            {
                try
                {
                    foreach (CSP.ConnectedServer.AppliedServerChannel appliedServerChannel_obj in checkedCSPServer_obj.AppliedServerChannels)
                    {
                        appliedServerChannel_obj.Disconnect();

                        appliedServerChannel_obj.IsConnected = false;

                        appliedServerChannel_obj.Socket.Close();
                    }

                    checkedCSPServer_obj.SystemChannel.Socket.Close();

                    return false;
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }
        else
        {
            return false;
        }
    }


    private void button_ChangeUINAccountState_ProcessNewAccountState_Click(object sender, EventArgs e)
    {
        string string_ConnectingServiceHost = this.textBox_ChangeUINAccountState_CustomCSPServiceIPAddress.Text,
              string_ConnectingServicePort = this.textBox_ChangeUINAccountState_CustomCSPServicePort.Text,
              string_LoginUIN = this.textBox_ChangeUINAccountState_UIN.Text,
              string_Password = this.textBox_ChangeUINAccountState_Password.Text,
              string_ActivationCode = this.textBox_ChangeUINAccountState_UINActivationCode.Text;


        #region CSP TCP\IP Port Parsing

        int int_ConnectingServicePort = 0;

        if (int.TryParse(string_ConnectingServicePort, out int_ConnectingServicePort) == true)
        {
            if (int_ConnectingServicePort < 1024 || int_ConnectingServicePort > 65535)
            {
                MessageBox.Show(ServerStringFactory.GetString(788, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
            }
        }
        else
        {
            MessageBox.Show(ServerStringFactory.GetString(787, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

            return;
        }

        #endregion

        #region Login UIN Parsing

        ulong ulong_LoginUIN = 0;

        if (ulong.TryParse(string_LoginUIN, out ulong_LoginUIN) == true)
        {
        }
        else
        {
            MessageBox.Show(ServerStringFactory.GetString(795, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

            return;
        }

        #endregion

        #region Activation Code Parsing

        ulong ulong_ActivationCode = 0;

        if (this.comboBox_ChangeUINAccountState_NewAccountState.SelectedIndex == 0)
        {
            if (ulong.TryParse(string_ActivationCode, out ulong_ActivationCode) == true)
            {
            }
            else
            {
                MessageBox.Show(ServerStringFactory.GetString(795, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

                return;
            }
        }
        #endregion

        CSP.ConnectedServer connectedServer_obj = null;

        CSP.ConnectingServiceProvider connectingServiceProvider_obj = new CSP.ConnectingServiceProvider();

        if (this.checkBox_ChangeUINAccountState_UseCommonJSCSPService.Checked == true)
        {
            string_ConnectingServiceHost = CSP.ConnectingServiceProvider.GetCommonCSPIPString();
        }

        ///////////////////////////////////////////////////////
        if (this.comboBox_ChangeUINAccountState_NewAccountState.SelectedIndex == 0)
        {
            connectedServer_obj = connectingServiceProvider_obj.ActivateServerUINRequest(string_ConnectingServiceHost, int_ConnectingServicePort, ulong_LoginUIN, string_Password, ulong_ActivationCode);

            CSP.CommonNetworkEvents.ServerUINActivatedEvent += ServerUINActivatedEventProcessing;
        }
        else
        {
            bool bool_RequestActivationCode = this.checkBox_ChangeUINAccountState_GetActivationCode.Checked;

            connectedServer_obj = connectingServiceProvider_obj.DeActivateServerUINRequest(string_ConnectingServiceHost, int_ConnectingServicePort, ulong_LoginUIN, string_Password, bool_RequestActivationCode);

            CSP.CommonNetworkEvents.ServerUINDeActivatedEvent += ServerUINDeActivatedEventProcessing;
        }
        if (IsCSPObjConnected(connectedServer_obj) == false)
        {
            MessageBox.Show(ServerStringFactory.GetString(796, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
        }
        else
        {
        }
    }

    private void button_CSPForm_ServerAuth_RegisterNewUIN_Click(object sender, EventArgs e)
    {
        this.Visible = false;

        this.Hide();

        RegisterNewUINForm registerNewUINForm_obj = new RegisterNewUINForm();

        registerNewUINForm_obj.ShowDialog();

        this.Show();
    }

    private void checkBox_ServerAuthSettings_KeepConnectionAlive_CheckedChanged(object sender, EventArgs e)
    {
        if (this.checkBox_ServerAuthSettings_KeepConnectionAlive.Checked == false)
        {
            LocalObjCopy.obj_NetworkAction.StopKeepingCSPConnectionAlive();
        }
    }

    private void comboBox_ChangeUINAccountState_NewAccountState_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool bool_EnableUINActivationControls = true;

        if (this.comboBox_ChangeUINAccountState_NewAccountState.SelectedIndex == 0)
        {
            this.button_ChangeUINAccountState_ProcessNewAccountState.Text = ServerStringFactory.GetString(772, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

            this.checkBox_ChangeUINAccountState_GetActivationCode.Enabled = false;
        }
        else
        {
            this.button_ChangeUINAccountState_ProcessNewAccountState.Text = ServerStringFactory.GetString(773, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

            bool_EnableUINActivationControls = false;

            this.checkBox_ChangeUINAccountState_GetActivationCode.Enabled = true;
        }

        this.textBox_ChangeUINAccountState_UINActivationCode.Enabled =
        this.label_ChangeUINAccountState_UINActivationCode.Enabled = bool_EnableUINActivationControls;
    }

    private void checkBox_ServerAuthSettings_UseCommonJSCSPService_CheckedChanged(object sender, EventArgs e)
    {
        this.textBox_CSPForm_ServerAuth_CustomCSPServiceIPAddress.Enabled = this.textBox_CSPForm_ServerAuth_CustomCSPServicePort.Enabled = !this.checkBox_ServerAuthSettings_UseCommonJSCSPService.Checked;
    }

    private void checkBox_ChangeUINAccountState_UseCommonJSCSPService_CheckedChanged(object sender, EventArgs e)
    {
        this.textBox_ChangeUINAccountState_CustomCSPServiceIPAddress.Enabled = this.textBox_ChangeUINAccountState_CustomCSPServicePort.Enabled = !this.checkBox_ChangeUINAccountState_UseCommonJSCSPService.Checked;
    }


}

