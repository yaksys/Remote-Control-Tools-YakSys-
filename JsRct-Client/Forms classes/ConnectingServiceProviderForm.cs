using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;
using JurikSoft.Proxy;
using JurikSoft.Proxy.Exceptions;
using System.IO;

public partial class ConnectingServiceProviderForm : Form
{
    public ConnectingServiceProviderForm()
    {
        InitializeComponent();

        RetriveCSPSettings();

        this.textBox_CSPForm_ServerAuth_ConnectionStatus.Text = ClientStringFactory.GetString(730, ClientSettingsEnvironment.CurrentLanguage);

        this.Select();

        this.checkBox_CSPForm_ProxySettings_Authentication_CheckedChanged(null, null);
        this.checkBox_CSPForm_ProxySettings_UseProxy_CheckedChanged(null, null);

        this.checkBox_CSPForm_ServerAuth_UseJurikSoftCSPServer_CheckedChanged(null, null);
        this.checkBox_ChangeUINAccountState_UseJurikSoftCSPServer_CheckedChanged(null, null);
        this.checkBox_CSPForm_CSPServersList_UseJurikSoftCSPServer_CheckedChanged(null, null);

        SetLanguageSettings();

        new Thread(new ThreadStart(MonitorConnectionStatus)).Start();

        FillProxyServersList();
    }

    void RetriveCSPSettings()
    {
        this.textBox_CSPForm_CSPServersList_Password.Text = ClientSettingsEnvironment.CSP_CSPServersList_Password;
        this.textBox_CSPForm_CSPServersList_UIN.Text = ClientSettingsEnvironment.CSP_CSPServersList_UIN;
        this.textBox_CSPForm_CSPServersList_CustomCSPServiceIPAddress.Text = ClientSettingsEnvironment.CSP_CSPServersList_CustomCSPServiceIPAddress;
        this.textBox_CSPForm_CSPServersList_CustomCSPServicePort.Text = ClientSettingsEnvironment.CSP_CSPServersList_CustomCSPServicePort.ToString();
        this.checkBox_CSPForm_CSPServersList_UseJurikSoftCSPServer.Checked = ClientSettingsEnvironment.CSP_CSPServersList_UseJurikSoftCSPServer;

        this.textBox_CSPForm_ServerAuth_CustomCSPServiceIPAddress.Text = ClientSettingsEnvironment.CSP_ServerAuth_CustomCSPServiceIPAddress;
        this.textBox_CSPForm_ServerAuth_CustomCSPServicePort.Text = ClientSettingsEnvironment.CSP_ServerAuth_CustomCSPServicePort.ToString();
        this.textBox_CSPForm_ServerAuth_CSPLoginPassword.Text = ClientSettingsEnvironment.CSP_ServerAuth_CSPLoginPassword;
        this.textBox_CSPForm_ServerAuth_CSPLoginUIN.Text = ClientSettingsEnvironment.CSP_ServerAuth_CSPLoginUIN;
        this.textBox_CSPForm_ServerAuth_JSRCTLogin.Text = ClientSettingsEnvironment.CSP_ServerAuth_JSRCTLogin;
        this.textBox_CSPForm_ServerAuth_JSRCTPassword.Text = ClientSettingsEnvironment.CSP_ServerAuth_JSRCTPassword;
        this.textBox_CSPForm_ServerAuth_CSPServerUIN.Text = ClientSettingsEnvironment.CSP_ServerAuth_CSPServerUIN;
        this.checkBox_CSPForm_ServerAuth_UseJurikSoftCSPServer.Checked = ClientSettingsEnvironment.CSP_ServerAuth_UseJurikSoftCSPServer;
        this.checkBox_CSPForm_ServerAuth_WaitForServer.Checked = ClientSettingsEnvironment.CSP_ServerAuth_WaitForServer;

        this.checkBox_CSPForm_ProxySettings_Authentication.Checked = ClientSettingsEnvironment.CSP_ProxySettings_Authentication;
        this.checkBox_CSPForm_ProxySettings_ResolveHostNames.Checked = ClientSettingsEnvironment.CSP_ProxySettings_ResolveHostNames;
        this.checkBox_CSPForm_ProxySettings_UseProxy.Checked = ClientSettingsEnvironment.CSP_ProxySettings_UseProxy;
        this.textBox_CSPForm_ProxySettings_ProxyHost.Text = ClientSettingsEnvironment.CSP_ProxySettings_ProxyHost;
        this.textBox_CSPForm_ProxySettings_ProxyPort.Text = ClientSettingsEnvironment.CSP_ProxySettings_ProxyPort.ToString();
        this.textBox_CSPForm_ProxySettings_Socks5UserName.Text = ClientSettingsEnvironment.CSP_ProxySettings_Socks5UserName;
        this.textBox_CSPForm_ProxySettings_Socks5Password.Text = ClientSettingsEnvironment.CSP_ProxySettings_Socks5Password;
        this.comboBox_CSPForm_ProxySettings_ProxyTimeOut.SelectedIndex = ClientSettingsEnvironment.CSP_ProxySettings_ProxyTimeOutIndex;
        this.listBox_CSPForm_ProxySettings_ProxyType.SelectedIndex = ClientSettingsEnvironment.CSP_ProxySettings_ProxyTypeIndex;

        this.checkBox_ChangeUINAccountState_GetActivationCode.Checked = ClientSettingsEnvironment.CSP_ChangeUINAccountState_GetActivationCode;
        this.checkBox_ChangeUINAccountState_UseJurikSoftCSPServer.Checked = ClientSettingsEnvironment.CSP_ChangeUINAccountState_UseJurikSoftCSPServer;
        this.textBox_ChangeUINAccountState_CustomCSPServiceIPAddress.Text = ClientSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServiceIPAddress;
        this.textBox_ChangeUINAccountState_CustomCSPServicePort.Text = ClientSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServicePort.ToString();
        this.textBox_ChangeUINAccountState_UIN.Text = ClientSettingsEnvironment.CSP_ChangeUINAccountState_UIN;
        this.textBox_ChangeUINAccountState_Password.Text = ClientSettingsEnvironment.CSP_ChangeUINAccountState_Password;
        this.textBox_ChangeUINAccountState_UINActivationCode.Text = ClientSettingsEnvironment.CSP_ChangeUINAccountState_UINActivationCode;
        this.comboBox_ChangeUINAccountState_NewAccountState.SelectedIndex = ClientSettingsEnvironment.CSP_ChangeUINAccountState_NewAccountStateIndex;
    }
    void SaveCSPSettings()
    {
        ClientSettingsEnvironment.CSP_CSPServersList_Password = this.textBox_CSPForm_CSPServersList_Password.Text;
        ClientSettingsEnvironment.CSP_CSPServersList_UIN = this.textBox_CSPForm_CSPServersList_UIN.Text;
        ClientSettingsEnvironment.CSP_CSPServersList_CustomCSPServiceIPAddress = this.textBox_CSPForm_CSPServersList_CustomCSPServiceIPAddress.Text;
        ClientSettingsEnvironment.CSP_CSPServersList_CustomCSPServicePort = CSP_CSPServersLis_CSPPort;
        ClientSettingsEnvironment.CSP_CSPServersList_UseJurikSoftCSPServer = this.checkBox_CSPForm_CSPServersList_UseJurikSoftCSPServer.Checked;

        ClientSettingsEnvironment.CSP_ServerAuth_CustomCSPServiceIPAddress = this.textBox_CSPForm_ServerAuth_CustomCSPServiceIPAddress.Text;
        ClientSettingsEnvironment.CSP_ServerAuth_CustomCSPServicePort = CSP_ServerAuth_CSPPort;
        ClientSettingsEnvironment.CSP_ServerAuth_CSPLoginPassword = this.textBox_CSPForm_ServerAuth_CSPLoginPassword.Text;
        ClientSettingsEnvironment.CSP_ServerAuth_CSPLoginUIN = this.textBox_CSPForm_ServerAuth_CSPLoginUIN.Text;
        ClientSettingsEnvironment.CSP_ServerAuth_JSRCTLogin = this.textBox_CSPForm_ServerAuth_JSRCTLogin.Text;
        ClientSettingsEnvironment.CSP_ServerAuth_JSRCTPassword = this.textBox_CSPForm_ServerAuth_JSRCTPassword.Text;
        ClientSettingsEnvironment.CSP_ServerAuth_CSPServerUIN = this.textBox_CSPForm_ServerAuth_CSPServerUIN.Text;
        ClientSettingsEnvironment.CSP_ServerAuth_UseJurikSoftCSPServer = this.checkBox_CSPForm_ServerAuth_UseJurikSoftCSPServer.Checked;
        ClientSettingsEnvironment.CSP_ServerAuth_WaitForServer = this.checkBox_CSPForm_ServerAuth_WaitForServer.Checked;

        ClientSettingsEnvironment.CSP_ProxySettings_Authentication = this.checkBox_CSPForm_ProxySettings_Authentication.Checked;
        ClientSettingsEnvironment.CSP_ProxySettings_ResolveHostNames = this.checkBox_CSPForm_ProxySettings_ResolveHostNames.Checked;
        ClientSettingsEnvironment.CSP_ProxySettings_UseProxy = this.checkBox_CSPForm_ProxySettings_UseProxy.Checked;
        ClientSettingsEnvironment.CSP_ProxySettings_ProxyHost = this.textBox_CSPForm_ProxySettings_ProxyHost.Text;
        ClientSettingsEnvironment.CSP_ProxySettings_ProxyPort = CSP_ProxySettings_CSPPort;
        ClientSettingsEnvironment.CSP_ProxySettings_Socks5UserName = this.textBox_CSPForm_ProxySettings_Socks5UserName.Text;
        ClientSettingsEnvironment.CSP_ProxySettings_Socks5Password = this.textBox_CSPForm_ProxySettings_Socks5Password.Text;
        ClientSettingsEnvironment.CSP_ProxySettings_ProxyTimeOutIndex = this.comboBox_CSPForm_ProxySettings_ProxyTimeOut.SelectedIndex;
        ClientSettingsEnvironment.CSP_ProxySettings_ProxyTypeIndex = this.listBox_CSPForm_ProxySettings_ProxyType.SelectedIndex;

        ClientSettingsEnvironment.CSP_ChangeUINAccountState_GetActivationCode = this.checkBox_ChangeUINAccountState_GetActivationCode.Checked;
        ClientSettingsEnvironment.CSP_ChangeUINAccountState_UseJurikSoftCSPServer = this.checkBox_ChangeUINAccountState_UseJurikSoftCSPServer.Checked;
        ClientSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServiceIPAddress = this.textBox_ChangeUINAccountState_CustomCSPServiceIPAddress.Text;
        ClientSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServicePort = CSP_ChangeUINAccountState_CSPPort;
        ClientSettingsEnvironment.CSP_ChangeUINAccountState_UIN = this.textBox_ChangeUINAccountState_UIN.Text;
        ClientSettingsEnvironment.CSP_ChangeUINAccountState_Password = this.textBox_ChangeUINAccountState_Password.Text;
        ClientSettingsEnvironment.CSP_ChangeUINAccountState_UINActivationCode = this.textBox_ChangeUINAccountState_UINActivationCode.Text;
        ClientSettingsEnvironment.CSP_ChangeUINAccountState_NewAccountStateIndex = this.comboBox_ChangeUINAccountState_NewAccountState.SelectedIndex;

        new JsRctClientV110XMLConfigImporter().SaveCSPSettingsXmlDB();
    }

    void SetLanguageSettings()
    {
        this.groupBox_CSPForm_ProxySettings.Text = ClientStringFactory.GetString(381, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_ProxySettings_ProxyType.Text = ClientStringFactory.GetString(384, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_CSPForm_ProxySettings_ResolveHostNames.Text = ClientStringFactory.GetString(404, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_CSPForm_ProxySettings_Authentication.Text = ClientStringFactory.GetString(383, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_ProxySettings_ProxyTimeOut.Text = ClientStringFactory.GetString(385, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_ProxySettings_ProxyPort.Text = ClientStringFactory.GetString(72, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_ProxySettings_ProxyHost.Text = ClientStringFactory.GetString(386, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_ProxySettings_Socks5Password.Text = ClientStringFactory.GetString(73, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_ProxySettings_Socks5UserName.Text = ClientStringFactory.GetString(405, ClientSettingsEnvironment.CurrentLanguage);
        this.listBox_CSPForm_ProxySettings_ProxyType.Text = ClientStringFactory.GetString(384, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_CSPForm_ProxySettings_UseProxy.Text = ClientStringFactory.GetString(382, ClientSettingsEnvironment.CurrentLanguage);

        int int_SelectedItemIndex = this.comboBox_CSPForm_ProxySettings_ProxyTimeOut.SelectedIndex;

        this.comboBox_CSPForm_ProxySettings_ProxyTimeOut.Items.Clear();
        this.comboBox_CSPForm_ProxySettings_ProxyTimeOut.Items.AddRange(new object[] {
																				 ClientStringFactory.GetString(388, ClientSettingsEnvironment.CurrentLanguage),
																				 ClientStringFactory.GetString(389, ClientSettingsEnvironment.CurrentLanguage),
																				 ClientStringFactory.GetString(400, ClientSettingsEnvironment.CurrentLanguage),
		});

        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 0;

        this.comboBox_CSPForm_ProxySettings_ProxyTimeOut.SelectedIndex = int_SelectedItemIndex;



        int_SelectedItemIndex = this.listBox_CSPForm_ProxySettings_ProxyType.SelectedIndex;

        this.listBox_CSPForm_ProxySettings_ProxyType.Items.Clear();
        this.listBox_CSPForm_ProxySettings_ProxyType.Items.AddRange(new object[] {
																			 ClientStringFactory.GetString(401, ClientSettingsEnvironment.CurrentLanguage),
																			 ClientStringFactory.GetString(402, ClientSettingsEnvironment.CurrentLanguage),
																			 ClientStringFactory.GetString(548, ClientSettingsEnvironment.CurrentLanguage),
		});

        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 0;

        this.listBox_CSPForm_ProxySettings_ProxyType.SelectedIndex = int_SelectedItemIndex;
        
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        this.groupBox_CSPForm_ProxyServersList.Text = ClientStringFactory.GetString(484, ClientSettingsEnvironment.CurrentLanguage);       
        this.button_CSPForm_ProxyServersList_Use.Text = ClientStringFactory.GetString(486, ClientSettingsEnvironment.CurrentLanguage);
        this.button_CSPForm_ProxyServersList_EditRecord.Text = ClientStringFactory.GetString(483, ClientSettingsEnvironment.CurrentLanguage);
        this.button_CSPForm_ProxyServersList_ClearList.Text = ClientStringFactory.GetString(313, ClientSettingsEnvironment.CurrentLanguage);
        this.button_CSPForm_ProxyServersList_AddRecord.Text = ClientStringFactory.GetString(311, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProxyServersList_Title.Text = ClientStringFactory.GetString(485, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProxyServersList_Host.Text = ClientStringFactory.GetString(317, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProxyServersList_Port.Text = ClientStringFactory.GetString(316, ClientSettingsEnvironment.CurrentLanguage);
        this.button_CSPForm_ProxyServersList_RemoveRecord.Text = ClientStringFactory.GetString(312, ClientSettingsEnvironment.CurrentLanguage);
        this.button_CSPForm_ProxyServersList_ViewRecord.Text = ClientStringFactory.GetString(306, ClientSettingsEnvironment.CurrentLanguage);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////        

        this.columnHeader_PublicServersList_ServerUIN.Text = ClientStringFactory.GetString(732, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_PublicServersList_ServerIP.Text = ClientStringFactory.GetString(733, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_PublicServersList_ConnectionTime.Text = ClientStringFactory.GetString(734, ClientSettingsEnvironment.CurrentLanguage);
        this.button_CSPForm_CSPServersList_RefreshPublicServersList.Text = ClientStringFactory.GetString(718, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_CSPForm_CSPServersList.Text = ClientStringFactory.GetString(716, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_CSPServersList_Password.Text = ClientStringFactory.GetString(719, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_CSPServersList_UIN.Text = ClientStringFactory.GetString(706, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_CSPServersList_ConnectionStatus.Text = ClientStringFactory.GetString(76, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_CSPForm_CSPServersList_UseJurikSoftCSPServer.Text = ClientStringFactory.GetString(703, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_CSPServersList_CustomCSPServicePort.Text = ClientStringFactory.GetString(72, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_CSPServersList_CustomCSPServiceIPAddress.Text = ClientStringFactory.GetString(711, ClientSettingsEnvironment.CurrentLanguage);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        this.groupBox_CSPForm_ServerAuthSettings.Text = ClientStringFactory.GetString(717, ClientSettingsEnvironment.CurrentLanguage);
        this.button_CSPForm_ServerAuth_RegisterNewUIN.Text = ClientStringFactory.GetString(709, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_ServerAuth_JSRCTPassword.Text = ClientStringFactory.GetString(708, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_ServerAuth_JSRCTLogin.Text = ClientStringFactory.GetString(707, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_ServerAuth_ConnectionStatus.Text = ClientStringFactory.GetString(76, ClientSettingsEnvironment.CurrentLanguage);
        this.button_CSPForm_ServerAuth_Connect.Text = ClientStringFactory.GetString(79, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_ServerAuth_CSPServerUIN.Text = ClientStringFactory.GetString(705, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_CSPForm_ServerAuth_WaitForServer.Text = ClientStringFactory.GetString(704, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_ServerAuth_CustomCSPServicePort.Text = ClientStringFactory.GetString(72, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_ServerAuth_CustomCSPServiceIPAddress.Text = ClientStringFactory.GetString(711, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_CSPForm_ServerAuth_UseJurikSoftCSPServer.Text = ClientStringFactory.GetString(703, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_ServerAuth_CSPLoginPassword.Text = ClientStringFactory.GetString(719, ClientSettingsEnvironment.CurrentLanguage);
        this.label_CSPForm_ServerAuth_CSPLoginUIN.Text = ClientStringFactory.GetString(706, ClientSettingsEnvironment.CurrentLanguage);
        this.textBox_CSPForm_ServerAuth_ConnectionStatus.Text = ClientStringFactory.GetString(354, ClientSettingsEnvironment.CurrentLanguage);
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        this.groupBox_ChangeUINAccountState_AccountControl.Text = ClientStringFactory.GetString(715, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ChangeUINAccountState_NewAccountState.Text = ClientStringFactory.GetString(712, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ChangeUINAccountState_UINActivationCode.Text = ClientStringFactory.GetString(720, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ChangeUINAccountState_Status.Text = ClientStringFactory.GetString(649, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ChangeUINAccountState_ProcessNewAccountState.Text = ClientStringFactory.GetString(713, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ChangeUINAccountState_UIN.Text = ClientStringFactory.GetString(706, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ChangeUINAccountState_CustomCSPServicePort.Text = ClientStringFactory.GetString(72, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ChangeUINAccountState_CustomCSPServiceIPAddress.Text = ClientStringFactory.GetString(711, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ChangeUINAccountState_Password.Text = ClientStringFactory.GetString(719, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_ChangeUINAccountState_UseJurikSoftCSPServer.Text = ClientStringFactory.GetString(703, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_ChangeUINAccountState_GetActivationCode.Text = ClientStringFactory.GetString(710, ClientSettingsEnvironment.CurrentLanguage);

        int_SelectedItemIndex = this.comboBox_ChangeUINAccountState_NewAccountState.SelectedIndex;

        this.comboBox_ChangeUINAccountState_NewAccountState.Items.Clear();
        this.comboBox_ChangeUINAccountState_NewAccountState.Items.AddRange(new object[] {
																				 ClientStringFactory.GetString(713, ClientSettingsEnvironment.CurrentLanguage),
																				 ClientStringFactory.GetString(714, ClientSettingsEnvironment.CurrentLanguage)
		});

        if (int_SelectedItemIndex < 0) int_SelectedItemIndex = 0;

        this.comboBox_ChangeUINAccountState_NewAccountState.SelectedIndex = int_SelectedItemIndex;
        
    }

    private void ConnectingServiceProviderForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        SaveCSPSettings();

        ObjCopy.obj_MainClientForm.RefreshProxyServersList();
    }

    #region Proxy Support

    void SetUpCSPProxyParameters()
    {
        CSP.CSPProxySupport.UseProxy = this.UseProxyServer;

        CSP.CSPProxySupport.ProxyTypeIndex = this.ProxyTypeIndex;
        CSP.CSPProxySupport.ProxyTimeOut = this.ProxyTimeOut;

        CSP.CSPProxySupport.Socks5UserName = this.Socks5UserName;
        CSP.CSPProxySupport.Socks5Password = this.Socks5Password;

        CSP.CSPProxySupport.UseProxyResolveHostNames = this.UseProxyResolveHostNames;
        CSP.CSPProxySupport.NeedProxyAuthentication = this.NeenProxyAuthentication;

        CSP.CSPProxySupport.ProxyHost = this.ProxyHost;
        CSP.CSPProxySupport.ProxyPort = this.ProxyPort;
    }

    public void RemoveProxyServerFromListView(int int_ProxyServerIndex)
    {
        int int_DeletedTagIndex = (int)this.listView_CSPForm_ProxyServersList_ProxyServersList.Items[int_ProxyServerIndex].Tag;

        foreach (ListViewItem listViewItem_obj in this.listView_CSPForm_ProxyServersList_ProxyServersList.Items)
        {
            if ((int)listViewItem_obj.Tag > int_DeletedTagIndex)
            {
                listViewItem_obj.Tag = (int)listViewItem_obj.Tag - 1;
            }
        }

        this.listView_CSPForm_ProxyServersList_ProxyServersList.Items.RemoveAt(int_ProxyServerIndex);
    }


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

    public bool UseProxyServer
    {
        get
        {
            if (this.IsHandleCreated == false) return false;

            return (bool)this.Invoke((delegate_ReturningBoolMethod)delegate
            {
                return this.checkBox_CSPForm_ProxySettings_UseProxy.Checked;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.checkBox_CSPForm_ProxySettings_UseProxy.Checked = value;
                this.checkBox_CSPForm_ProxySettings_UseProxy_CheckedChanged(null, null);
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
                    string string_ProxyPort = this.textBox_CSPForm_ProxySettings_ProxyPort.Text;

                    int int_ProxyPort = 1080;

                    if (int.TryParse(string_ProxyPort, out int_ProxyPort) == true)
                    {
                        if (int_ProxyPort < 1024 || int_ProxyPort > 65535)
                        {
                            MessageBox.Show(ClientStringFactory.GetString(725, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK);
                            return -1;
                        }

                        return int_ProxyPort;
                    }
                    else
                    {
                        MessageBox.Show(ClientStringFactory.GetString(724, ClientSettingsEnvironment.CurrentLanguage));

                        return -1;
                    }

                    ////////////////                
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
                this.textBox_CSPForm_ProxySettings_ProxyPort.Text = value.ToString();
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
                return this.textBox_CSPForm_ProxySettings_ProxyHost.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_CSPForm_ProxySettings_ProxyHost.Text = value;
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
                if (this.comboBox_CSPForm_ProxySettings_ProxyTimeOut.SelectedIndex == 0) return 5000;
                if (this.comboBox_CSPForm_ProxySettings_ProxyTimeOut.SelectedIndex == 1) return 10000;
                if (this.comboBox_CSPForm_ProxySettings_ProxyTimeOut.SelectedIndex == 2) return 15000;
                return 5000;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                if (value == 5000) this.comboBox_CSPForm_ProxySettings_ProxyTimeOut.SelectedIndex = 0;
                if (value == 10000) this.comboBox_CSPForm_ProxySettings_ProxyTimeOut.SelectedIndex = 1;
                if (value == 15000) this.comboBox_CSPForm_ProxySettings_ProxyTimeOut.SelectedIndex = 2;
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
                return this.checkBox_CSPForm_ProxySettings_ResolveHostNames.Checked;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.checkBox_CSPForm_ProxySettings_ResolveHostNames.Checked = value;
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
                return this.listBox_CSPForm_ProxySettings_ProxyType.SelectedIndex;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.listBox_CSPForm_ProxySettings_ProxyType.SelectedIndex = value;
                this.listBox_CSPForm_ProxySettings_ProxyType.Select();
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
                return this.textBox_CSPForm_ProxySettings_Socks5UserName.Text;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_CSPForm_ProxySettings_Socks5UserName.Text = value;
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
                return this.textBox_CSPForm_ProxySettings_Socks5Password.Text;
            });
        }
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_CSPForm_ProxySettings_Socks5Password.Text = value;
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
                return this.checkBox_CSPForm_ProxySettings_Authentication.Checked;
            });
        }

        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.checkBox_CSPForm_ProxySettings_Authentication.Checked = value;
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
                return (this.listBox_CSPForm_ProxySettings_ProxyType.SelectedIndex > 0 && this.checkBox_CSPForm_ProxySettings_Authentication.Checked);
            });
        }
    }

    private void ApplySelectedProxyServerFromList()
    {
        if (this.listView_CSPForm_ProxyServersList_ProxyServersList.SelectedItems.Count == 0) return;

        int int_SelectedProxyServerRowIndex = (int)this.listView_CSPForm_ProxyServersList_ProxyServersList.SelectedItems[0].Tag;

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


    private void listView_CSPForm_ProxyServersList_ProxyServersList_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        ApplySelectedProxyServerFromList();
    }

    private void button_CSPForm_ProxyServersList_AddRecord_Click(object sender, System.EventArgs e)
    {
        ProxyDBManagerForm proxyDBManagerForm_obj = new ProxyDBManagerForm();

        proxyDBManagerForm_obj.ApplyButton.Visible = false;

        proxyDBManagerForm_obj.ShowDialog();

        FillProxyServersList();
    }

    private void button_CSPForm_ProxyServersList_Use_Click(object sender, System.EventArgs e)
    {
        ApplySelectedProxyServerFromList();
    }

    private void button_CSPForm_ProxyServersList_RemoveRecord_Click(object sender, System.EventArgs e)
    {
        if (this.listView_CSPForm_ProxyServersList_ProxyServersList.SelectedItems.Count == 0) return;

        if (MessageBox.Show(ClientStringFactory.GetString(488, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        new JurikSoft.XMLConfigImporer.JSClientDBEnvironment().RemoveProxyServerRecord((int)this.listView_CSPForm_ProxyServersList_ProxyServersList.SelectedItems[0].Tag + 1);

        int int_SelectedProxyServerRowIndex = this.listView_CSPForm_ProxyServersList_ProxyServersList.SelectedItems[0].Index;

        this.RemoveProxyServerFromListView(int_SelectedProxyServerRowIndex);
    }

    private void button_CSPForm_ProxyServersList_ClearList_Click(object sender, System.EventArgs e)
    {
        if (this.listView_CSPForm_ProxyServersList_ProxyServersList.Items.Count == 0 ||
            DialogResult.Yes != MessageBox.Show(ClientStringFactory.GetString(489, ClientSettingsEnvironment.CurrentLanguage),
            ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            return;
        }

        for (int int_CycleCount = 1; int_CycleCount != JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows.Count; )
        {
            new JurikSoft.XMLConfigImporer.JSClientDBEnvironment().RemoveProxyServerRecord(int_CycleCount);
        }

        this.listView_CSPForm_ProxyServersList_ProxyServersList.Items.Clear();
    }

    private void button_CSPForm_ProxyServersList_EditRecord_Click(object sender, System.EventArgs e)
    {
        if (this.listView_CSPForm_ProxyServersList_ProxyServersList.SelectedItems.Count == 0) return;

        int int_SelectedProxyServerRowIndex = (int)this.listView_CSPForm_ProxyServersList_ProxyServersList.SelectedItems[0].Tag;

        UserAccountsAndAccessRestrictionRulesEnvironment.EditSelectedProxyServerInfo(int_SelectedProxyServerRowIndex);

        FillProxyServersList();
    }

    private void button_CSPForm_ProxyServersList_ViewRecord_Click(object sender, System.EventArgs e)
    {
        if (this.listView_CSPForm_ProxyServersList_ProxyServersList.SelectedItems.Count == 0) return;

        UserAccountsAndAccessRestrictionRulesEnvironment.ViewSelectedProxyServerInfo((int)this.listView_CSPForm_ProxyServersList_ProxyServersList.SelectedItems[0].Tag);
    }

    public void FillProxyServersList()
    {
        ListViewItem[] listViewItemArray_ProxyServer = new JurikSoft.XMLConfigImporer.JSClientDBEnvironment().GetProxyServersList();

        if (listViewItemArray_ProxyServer != null)
        {
            this.listView_CSPForm_ProxyServersList_ProxyServersList.Items.Clear();

            this.listView_CSPForm_ProxyServersList_ProxyServersList.Items.AddRange(listViewItemArray_ProxyServer);
        }
    }

    private void listBox_NetworkControl_ProxyType_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        bool bool_AuthEnabled = true;

        if (this.listBox_CSPForm_ProxySettings_ProxyType.SelectedIndex == 0) bool_AuthEnabled = false;

        this.label_CSPForm_ProxySettings_Socks5UserName.Enabled =
        this.label_CSPForm_ProxySettings_Socks5Password.Enabled =
        this.textBox_CSPForm_ProxySettings_Socks5UserName.Enabled =
        this.textBox_CSPForm_ProxySettings_Socks5Password.Enabled =
        this.checkBox_CSPForm_ProxySettings_Authentication.Enabled = bool_AuthEnabled;

        this.checkBox_CSPForm_ProxySettings_Authentication_CheckedChanged(null, null);
    }

    public void EditProxyServersListItem(int int_ItemIndex, string string_ProxyServerTitle, string string_ProxyServerHost, string string_ProxyServerPort)
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_CSPForm_ProxyServersList_ProxyServersList.Items[int_ItemIndex].Text = string_ProxyServerTitle;

            this.listView_CSPForm_ProxyServersList_ProxyServersList.Items[int_ItemIndex].SubItems[1].Text = string_ProxyServerHost;

            this.listView_CSPForm_ProxyServersList_ProxyServersList.Items[int_ItemIndex].SubItems[2].Text = string_ProxyServerPort;
        });
    }

    private void checkBox_CSPForm_ProxySettings_UseProxy_CheckedChanged(object sender, System.EventArgs e)
    {
        foreach (Control control_Current in this.groupBox_CSPForm_ProxySettings.Controls)
        {
            control_Current.Enabled = this.checkBox_CSPForm_ProxySettings_UseProxy.Checked;
        }

        this.checkBox_CSPForm_ProxySettings_UseProxy.Enabled = true;

        if (this.listBox_CSPForm_ProxySettings_ProxyType.SelectedIndex == 0) this.checkBox_CSPForm_ProxySettings_Authentication.Enabled = false;
        if (this.checkBox_CSPForm_ProxySettings_UseProxy.Checked) this.checkBox_CSPForm_ProxySettings_Authentication_CheckedChanged(null, null);
    }

    private void checkBox_CSPForm_ProxySettings_Authentication_CheckedChanged(object sender, System.EventArgs e)
    {
        this.label_CSPForm_ProxySettings_Socks5Password.Enabled =
        this.label_CSPForm_ProxySettings_Socks5UserName.Enabled =
        this.textBox_CSPForm_ProxySettings_Socks5Password.Enabled =
        this.textBox_CSPForm_ProxySettings_Socks5UserName.Enabled =
        (this.checkBox_CSPForm_ProxySettings_UseProxy.Checked && this.checkBox_CSPForm_ProxySettings_Authentication.Checked);
    }


    #endregion

    #region Events Processing
      
    void SubscribeToNetworkEvents()
    {
        #region Subscribe to CSP Network Events

        CSP.CommonNetworkEvents.ClientDiconnectionInfoEvent += ClientDisconnectionEventProcessing;

        #endregion
    }

    void ClientUINActivatedEventProcessing(ulong ulong_ActivatedUIN)
    {
        MessageBox.Show(ClientStringFactory.GetString(728, ClientSettingsEnvironment.CurrentLanguage) + ulong_ActivatedUIN.ToString());

        CSP.CommonNetworkEvents.ClientUINActivatedEvent -= ClientUINActivatedEventProcessing;
    }

    void ClientUINDeActivatedEventProcessing(ulong ulong_DeActivatedUIN)
    {
        MessageBox.Show(ClientStringFactory.GetString(729, ClientSettingsEnvironment.CurrentLanguage) + ulong_DeActivatedUIN.ToString());

        CSP.CommonNetworkEvents.ClientUINDeActivatedEvent -= ClientUINDeActivatedEventProcessing;
    }

    void ClientDisconnectionEventProcessing(CSP.ConnectedClient connectedClient_obj, CSP.CommonNetworkEvents.DisconnectionReason disconnectionReason_Result)
    {
        Form.ActiveForm.Invoke((MethodInvoker)delegate
        {
            CSP.CommonNetworkEvents.ClientDiconnectionInfoEvent -= ClientDisconnectionEventProcessing;

            return; //!!!

            switch (disconnectionReason_Result) //!! все эти сообщения на экране показывается на самом заднем уровне!
            {
                case CSP.CommonNetworkEvents.DisconnectionReason.AuthFailure:
                    {
                        MessageBox.Show(this, ClientStringFactory.GetString(756, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case CSP.CommonNetworkEvents.DisconnectionReason.DisconnectByAdmin:
                    {
                        MessageBox.Show(this, ClientStringFactory.GetString(757, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case CSP.CommonNetworkEvents.DisconnectionReason.MaxConnectionLimit:
                    {
                        MessageBox.Show(this, ClientStringFactory.GetString(758, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case CSP.CommonNetworkEvents.DisconnectionReason.MaxConnectionsPerAccountLimit:
                    {
                        MessageBox.Show(this, ClientStringFactory.GetString(759, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case CSP.CommonNetworkEvents.DisconnectionReason.AccountRemoved:
                    {
                        MessageBox.Show(this, ClientStringFactory.GetString(760, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case CSP.CommonNetworkEvents.DisconnectionReason.DisconnectAllClientsByAdmin:
                    {
                        MessageBox.Show(this, ClientStringFactory.GetString(761, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case CSP.CommonNetworkEvents.DisconnectionReason.ConnectionClosedByOperaionCompleted:
                    {
                        MessageBox.Show(this, ClientStringFactory.GetString(762, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case CSP.CommonNetworkEvents.DisconnectionReason.ConnectionClosedByUserRequest:
                    {
                        MessageBox.Show(this, ClientStringFactory.GetString(763, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case CSP.CommonNetworkEvents.DisconnectionReason.ConnectionLost:
                    {
                        MessageBox.Show(this, ClientStringFactory.GetString(764, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case CSP.CommonNetworkEvents.DisconnectionReason.ExceptionThrownInReceivedCycle:
                    {
                        MessageBox.Show(this, ClientStringFactory.GetString(765, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case CSP.CommonNetworkEvents.DisconnectionReason.RequestedServerNotConnected:
                    {
                        MessageBox.Show(this, ClientStringFactory.GetString(766, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
            }
        });

        ObjCopy.obj_NetworkAction.IsCSPClientObjConnected();

        ObjCopy.obj_NetworkAction.DisconnectFromCSP(ref connectedClient_obj);

        this.button_CSPForm_ServerAuth_Connect.Enabled = true;

        this.textBox_CSPForm_ServerAuth_ConnectionStatus.Text = ClientStringFactory.GetString(78, ClientSettingsEnvironment.CurrentLanguage);
        this.button_CSPForm_ServerAuth_Connect.Text = ClientStringFactory.GetString(79, ClientSettingsEnvironment.CurrentLanguage);
    }

    #endregion

    #region Properties

    ulong CSP_ServerAuth_CSPServerUIN
    {
        get
        {
            string string_InterConnectedUIN = this.textBox_CSPForm_ServerAuth_CSPServerUIN.Text;

            ulong ulong_ServerUIN = 0;

            if (ulong.TryParse(string_InterConnectedUIN, out ulong_ServerUIN) == true)
            {
            }
            else
            {
                MessageBox.Show(ClientStringFactory.GetString(727, ClientSettingsEnvironment.CurrentLanguage));

                return 0;
            }

            return ulong_ServerUIN;
        }
    }
   
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
                MessageBox.Show(ClientStringFactory.GetString(726, ClientSettingsEnvironment.CurrentLanguage));

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
                    MessageBox.Show(ClientStringFactory.GetString(725, ClientSettingsEnvironment.CurrentLanguage));

                    return 0;
                }
            }
            else
            {
                MessageBox.Show(ClientStringFactory.GetString(724, ClientSettingsEnvironment.CurrentLanguage));

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
                if (int_ConnectingServicePort < 1023 || int_ConnectingServicePort > 65535)
                {
                    MessageBox.Show(ClientStringFactory.GetString(725, ClientSettingsEnvironment.CurrentLanguage));

                    return 0;
                }
            }
            else
            {
                MessageBox.Show(ClientStringFactory.GetString(724, ClientSettingsEnvironment.CurrentLanguage));

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
                    MessageBox.Show(ClientStringFactory.GetString(725, ClientSettingsEnvironment.CurrentLanguage));

                    return 0;
                }
            }
            else
            {
                MessageBox.Show(ClientStringFactory.GetString(724, ClientSettingsEnvironment.CurrentLanguage));

                return 0;
            }

            return int_ConnectingServicePort;
        }
    }
  
    int CSP_CSPServersLis_CSPPort
    {
        get
        {
            string string_ConnectingServicePort = this.textBox_CSPForm_CSPServersList_CustomCSPServicePort.Text;

            int int_ConnectingServicePort = 5545;

            if (int.TryParse(string_ConnectingServicePort, out int_ConnectingServicePort) == true)
            {
                if (int_ConnectingServicePort < 1024 || int_ConnectingServicePort > 65535)
                {
                    MessageBox.Show(ClientStringFactory.GetString(725, ClientSettingsEnvironment.CurrentLanguage));

                    return 0;
                }
            }
            else
            {
                MessageBox.Show(ClientStringFactory.GetString(724, ClientSettingsEnvironment.CurrentLanguage));

                return 0;
            }

            return int_ConnectingServicePort;
        }
    }

    #endregion
  
    void MonitorConnectionStatus()
    {
        try
        {
            while (this.IsDisposed == false && this.IsHandleCreated == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (NetworkAction.CSPConnectionStatus.TryToConnect == NetworkAction.CSPCurrentConnectionStatus)
                    {
                        this.textBox_CSPForm_ServerAuth_ConnectionStatus.Text = ClientStringFactory.GetString(354, ClientSettingsEnvironment.CurrentLanguage);
                    }

                    if (NetworkAction.CSPConnectionStatus.Disconnected == NetworkAction.CSPCurrentConnectionStatus)
                    {
                        this.button_CSPForm_ServerAuth_Connect.Enabled = true;

                        this.textBox_CSPForm_ServerAuth_ConnectionStatus.Text = ClientStringFactory.GetString(78, ClientSettingsEnvironment.CurrentLanguage);

                        this.button_CSPForm_ServerAuth_Connect.Text = ClientStringFactory.GetString(79, ClientSettingsEnvironment.CurrentLanguage);
                    }

                    if (NetworkAction.CSPConnectionStatus.Connected == NetworkAction.CSPCurrentConnectionStatus)
                    {
                        this.textBox_CSPForm_ServerAuth_ConnectionStatus.Text = ClientStringFactory.GetString(261, ClientSettingsEnvironment.CurrentLanguage);

                        this.button_CSPForm_ServerAuth_Connect.Text = ClientStringFactory.GetString(80, ClientSettingsEnvironment.CurrentLanguage);
                    }

                    if (NetworkAction.CSPConnectionStatus.WaitForServer == NetworkAction.CSPCurrentConnectionStatus)
                    {
                        this.button_CSPForm_ServerAuth_Connect.Enabled = true;

                        this.button_CSPForm_ServerAuth_Connect.Text = ClientStringFactory.GetString(80, ClientSettingsEnvironment.CurrentLanguage);

                        this.textBox_CSPForm_ServerAuth_ConnectionStatus.Text = ClientStringFactory.GetString(767, ClientSettingsEnvironment.CurrentLanguage);
                    }
                });

                if (ObjCopy.obj_NetworkAction.IsCSPClientObjConnected() == true)
                {
                    this.button_CSPForm_ServerAuth_Connect.Enabled = true;

                    if (NetworkAction.CSPConnectionStatus.Connected == NetworkAction.CSPCurrentConnectionStatus)
                    {
                        this.textBox_CSPForm_ServerAuth_ConnectionStatus.Text = ClientStringFactory.GetString(261, ClientSettingsEnvironment.CurrentLanguage);
                    }

                    this.button_CSPForm_ServerAuth_Connect.Text = ClientStringFactory.GetString(80, ClientSettingsEnvironment.CurrentLanguage);
                }
                else
                {
                    Thread.Sleep(100);
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

    public void ConnectUsingCSP()
    {
        string string_ConnectingServiceHost = this.textBox_CSPForm_ServerAuth_CustomCSPServiceIPAddress.Text,
              string_ConnectingServicePort = this.textBox_CSPForm_ServerAuth_CustomCSPServicePort.Text,
              string_CSPLoginUIN = this.textBox_CSPForm_ServerAuth_CSPLoginUIN.Text,
              string_CSPLoginPassword = this.textBox_CSPForm_ServerAuth_CSPLoginPassword.Text,
              string_JSRCTLogin = this.textBox_CSPForm_ServerAuth_JSRCTLogin.Text,
              string_JSRCTPassword = this.textBox_CSPForm_ServerAuth_JSRCTPassword.Text,
              string_InterConnectedUIN = this.textBox_CSPForm_ServerAuth_CSPServerUIN.Text;

        ulong ulong_ServerUIN = CSP_ServerAuth_CSPServerUIN, ulong_CSPLoginUIN = CSP_ServerAuth_CSPLoginUIN;
        
        int int_ConnectingServicePort = CSP_ServerAuth_CSPPort;

        if (int_ConnectingServicePort == 0 || ulong_ServerUIN == 0 || ulong_CSPLoginUIN == 0)
        {
            return;
        }

        bool bool_WaitForServer = this.checkBox_CSPForm_ServerAuth_WaitForServer.Checked;
        bool bool_KeepConnectionAlive = this.checkBox_CSPForm_ServerAuth_KeepConnectionAlive.Checked;

        ObjCopy.obj_NetworkAction.ConnectClientToJSServerUsingCSP(this.checkBox_CSPForm_ServerAuth_UseJurikSoftCSPServer.Checked, string_ConnectingServiceHost, int_ConnectingServicePort, ulong_CSPLoginUIN, string_CSPLoginPassword, ulong_ServerUIN, string_JSRCTLogin, string_JSRCTPassword, bool_WaitForServer, bool_KeepConnectionAlive);
    }


    public void FillPublicServersList(CSP.PublicServerInfo[] publicServerInfo_obj)
    {
        try
        {
            this.listView_CSPForm_CSPServersList_PublicServersList.Items.Clear();

            ListViewItem listViewItem_JurikSoftServerItem;

            for (int int_CycleCount = 0; int_CycleCount != publicServerInfo_obj.Length; int_CycleCount++)
            {
                listViewItem_JurikSoftServerItem = new ListViewItem(publicServerInfo_obj[int_CycleCount].UIN.ToString());

                listViewItem_JurikSoftServerItem.ImageIndex = 0;

                listViewItem_JurikSoftServerItem.SubItems.Add(publicServerInfo_obj[int_CycleCount].IPAddress);
                listViewItem_JurikSoftServerItem.SubItems.Add(publicServerInfo_obj[int_CycleCount].ConnectedTime);

                ObjCopy.obj_NetworkAction.DisconnectFromCSP(ref NetworkAction.connectedClient_ServersListRetriever);

                this.listView_CSPForm_CSPServersList_PublicServersList.Items.Add(listViewItem_JurikSoftServerItem);
            }

            this.textBox_CSPForm_CSPServersList_ConnectionStatus.Text = ClientStringFactory.GetString(723, ClientSettingsEnvironment.CurrentLanguage);
        }
        catch
        {
        }
    }

    private void button_CSPForm_ServerAuth_Connect_Click(object sender, EventArgs e)
    {
        try
        {
            if (ObjCopy.obj_NetworkAction.IsCSPClientObjConnected() == true || NetworkAction.CSPCurrentConnectionStatus != NetworkAction.CSPConnectionStatus.Disconnected)
            {
                Thread.Sleep(500);

                this.button_CSPForm_ServerAuth_Connect.Enabled = false;
                
                ObjCopy.obj_NetworkAction.DisconnectFromCSP(ref NetworkAction.connectedCSPClient_obj);

                Thread.Sleep(500);

                return;
            }
            
            this.button_CSPForm_ServerAuth_Connect.Enabled = false;

            SetUpCSPProxyParameters();

            SubscribeToNetworkEvents();

            ConnectUsingCSP();
        }

        catch (Socks5ServiceNotFoundException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(416, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (TimeOutException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(417, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (AuthenticationRequiredException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(418, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (NoAcceptableMethodsException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(419, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (GeneralSocksServerFailureException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(420, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (ConnectionNotAllowedException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(421, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (NetworkUnreachableException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(422, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (HostUnreachableException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(423, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (ConnectionRefusedException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(424, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (TTLExpiredException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(425, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (UnsupportedSocksCommandException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(426, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (UnsupportedAddressTypeException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(427, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (ProxyConnectionException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(428, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (Socks4ServiceNotFoundException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(429, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (RequestRejectedOrFailed)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(430, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (IdentdOnClientNotResponse)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(431, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (DifferentUserIDs)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(432, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (UnableToResolveHostName)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(433, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (AuthenticationNotAllowedException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(434, ClientSettingsEnvironment.CurrentLanguage));
        }

        catch (AuthenticationFailureException)
        {
            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(435, ClientSettingsEnvironment.CurrentLanguage));
        }
        catch
        {

        }
        finally
        {
        }
    }

    private void button_CSPForm_ServerAuth_Disconnect_Click(object sender, EventArgs e)
    {
        try
        {
            ObjCopy.obj_NetworkAction.DisconnectFromCSP(ref NetworkAction.connectedCSPClient_obj);
        }
        catch
        {
        }
        finally
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

    private void button_ChangeUINAccountState_ProcessNewAccountState_Click(object sender, EventArgs e)
    {
        try
        {
            string string_ConnectingServiceHost = this.textBox_ChangeUINAccountState_CustomCSPServiceIPAddress.Text,
                        string_ConnectingServicePort = this.textBox_ChangeUINAccountState_CustomCSPServicePort.Text,
                        string_LoginUIN = this.textBox_ChangeUINAccountState_UIN.Text,
                        string_Password = this.textBox_ChangeUINAccountState_Password.Text,
                        string_ActivationCode = this.textBox_ChangeUINAccountState_UINActivationCode.Text;

            CSP.CommonNetworkEvents.ClientUINDeActivatedEvent -= ClientUINDeActivatedEventProcessing;
            CSP.CommonNetworkEvents.ClientUINActivatedEvent -= ClientUINActivatedEventProcessing;


            #region CSP TCP\IP Port Parsing

            int int_ConnectingServicePort = 0;

            if (int.TryParse(string_ConnectingServicePort, out int_ConnectingServicePort) == true)
            {
                if (int_ConnectingServicePort < 1024 || int_ConnectingServicePort > 65535)
                {
                    MessageBox.Show(ClientStringFactory.GetString(725, ClientSettingsEnvironment.CurrentLanguage));
                }
            }
            else
            {
                MessageBox.Show(ClientStringFactory.GetString(724, ClientSettingsEnvironment.CurrentLanguage));

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
                MessageBox.Show(ClientStringFactory.GetString(726, ClientSettingsEnvironment.CurrentLanguage));

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
                    MessageBox.Show(ClientStringFactory.GetString(753, ClientSettingsEnvironment.CurrentLanguage));

                    return;
                }
            }
            #endregion

            if (this.checkBox_ChangeUINAccountState_UseJurikSoftCSPServer.Checked == true)
            {
                string_ConnectingServiceHost = CSP.ConnectingServiceProvider.GetCommonCSPIPString();
            }

            CSP.ConnectedClient connectedClient_obj = null;

            CSP.ConnectingServiceProvider connectingServiceProvider_obj = new CSP.ConnectingServiceProvider();

            SetUpCSPProxyParameters();

            if (this.comboBox_ChangeUINAccountState_NewAccountState.SelectedIndex == 0)
            {
                connectedClient_obj = connectingServiceProvider_obj.ActivateClientUINRequest(string_ConnectingServiceHost, int_ConnectingServicePort, ulong_LoginUIN, string_Password, ulong_ActivationCode);

                CSP.CommonNetworkEvents.ClientUINActivatedEvent += ClientUINActivatedEventProcessing;
            }
            else
            {
                bool bool_RequestActivationCode = this.checkBox_ChangeUINAccountState_GetActivationCode.Checked;

                connectedClient_obj = connectingServiceProvider_obj.DeActivateClientUINRequest(string_ConnectingServiceHost, int_ConnectingServicePort, ulong_LoginUIN, string_Password, bool_RequestActivationCode);

                CSP.CommonNetworkEvents.ClientUINDeActivatedEvent += ClientUINDeActivatedEventProcessing;
            }

            if (ObjCopy.obj_NetworkAction.IsCSPObjConnected(connectedClient_obj) == false)
            {
                MessageBox.Show(ClientStringFactory.GetString(731, ClientSettingsEnvironment.CurrentLanguage));
            }
            else
            {
            }
        }
        finally
        {

        }
    }

    private void comboBox_ChangeUINAccountState_NewAccountState_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool bool_EnableUINActivationControls = true;

        if (this.comboBox_ChangeUINAccountState_NewAccountState.SelectedIndex == 0)
        {
            this.button_ChangeUINAccountState_ProcessNewAccountState.Text = ClientStringFactory.GetString(713, ClientSettingsEnvironment.CurrentLanguage);

            this.checkBox_ChangeUINAccountState_GetActivationCode.Enabled = false;
        }
        else
        {
            this.button_ChangeUINAccountState_ProcessNewAccountState.Text = ClientStringFactory.GetString(714, ClientSettingsEnvironment.CurrentLanguage);

            bool_EnableUINActivationControls = false;

            this.checkBox_ChangeUINAccountState_GetActivationCode.Enabled = true;
        }

        this.textBox_ChangeUINAccountState_UINActivationCode.Enabled =
        this.label_ChangeUINAccountState_UINActivationCode.Enabled = bool_EnableUINActivationControls;
    }

    private void button_CSPForm_CSPServersList_RefreshPublicServersList_Click(object sender, EventArgs e)
    {
        try
        {
            string
            string_ConnectingServiceHost = this.textBox_CSPForm_CSPServersList_CustomCSPServiceIPAddress.Text,
            string_ConnectingServicePort = this.textBox_CSPForm_CSPServersList_CustomCSPServicePort.Text,
            string_LoginUIN = this.textBox_CSPForm_CSPServersList_UIN.Text,
            string_Password = this.textBox_CSPForm_CSPServersList_Password.Text,
            string_InterConnectedUIN = this.textBox_CSPForm_ServerAuth_CSPServerUIN.Text,
            string_JSServerLogin = this.textBox_CSPForm_ServerAuth_JSRCTLogin.Text,
            string_JSServerPassword = this.textBox_CSPForm_ServerAuth_JSRCTPassword.Text;

            #region CSP TCP\IP Port Parsing

            int int_ConnectingServicePort = 0;

            if (int.TryParse(string_ConnectingServicePort, out int_ConnectingServicePort) == true)
            {
                if (int_ConnectingServicePort < 1024 || int_ConnectingServicePort > 65535)
                {
                    MessageBox.Show(ClientStringFactory.GetString(725, ClientSettingsEnvironment.CurrentLanguage));
                }
            }
            else
            {
                MessageBox.Show(ClientStringFactory.GetString(724, ClientSettingsEnvironment.CurrentLanguage));

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
                MessageBox.Show(ClientStringFactory.GetString(724, ClientSettingsEnvironment.CurrentLanguage));

                return;
            }

            #endregion

            bool bool_WaitForServer = this.checkBox_CSPForm_ServerAuth_WaitForServer.Checked;

            CSP.CommonNetworkEvents.OnPublicServersListReceivedEvent += new CSP.CommonNetworkEvents.PublicServersListReceivedEventHandler(FillPublicServersList);

            this.textBox_CSPForm_CSPServersList_ConnectionStatus.Text = ClientStringFactory.GetString(354, ClientSettingsEnvironment.CurrentLanguage);
            this.textBox_CSPForm_CSPServersList_ConnectionStatus.Refresh();

            SetUpCSPProxyParameters();

            if (this.checkBox_CSPForm_CSPServersList_UseJurikSoftCSPServer.Checked == true)
            {
                string_ConnectingServiceHost = CSP.ConnectingServiceProvider.GetCommonCSPIPString();
            }

            if (ObjCopy.obj_NetworkAction.IsSystemChannelConnected(NetworkAction.connectedCSPClient_obj) == true)
            {
                NetworkAction.connectedCSPClient_obj.GetPublicServersList(); // если уже подконнекчены то не смотря на галочку Common JSConnecting Service, будет запрос серверов у подключенного сервиса! 
            }
            else
            {
                NetworkAction.connectedClient_ServersListRetriever = new NetworkAction().ConnectSystemClientChannelToCSP(string_ConnectingServiceHost, int_ConnectingServicePort, ulong_LoginUIN, string_Password);

                if (ObjCopy.obj_NetworkAction.IsSystemChannelConnected(NetworkAction.connectedClient_ServersListRetriever) == false)
                {
                    this.textBox_CSPForm_CSPServersList_ConnectionStatus.Text = ClientStringFactory.GetString(721, ClientSettingsEnvironment.CurrentLanguage);

                    ObjCopy.obj_NetworkAction.DisconnectFromCSP(ref NetworkAction.connectedClient_ServersListRetriever);

                    return;
                }

                NetworkAction.connectedClient_ServersListRetriever.GetPublicServersList();
            }            

            this.textBox_CSPForm_CSPServersList_ConnectionStatus.Text = ClientStringFactory.GetString(722, ClientSettingsEnvironment.CurrentLanguage);
        }
        catch
        {
            ObjCopy.obj_NetworkAction.DisconnectFromCSP(ref NetworkAction.connectedClient_ServersListRetriever);

            this.textBox_CSPForm_CSPServersList_ConnectionStatus.Text = ClientStringFactory.GetString(721, ClientSettingsEnvironment.CurrentLanguage);
        }
    }

    private void listView_CSPForm_CSPServersList_PublicServersList_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (this.listView_CSPForm_CSPServersList_PublicServersList.SelectedItems.Count > 0)
        {
            this.textBox_CSPForm_ServerAuth_CSPServerUIN.Text = this.listView_CSPForm_CSPServersList_PublicServersList.SelectedItems[0].Text;
        }
    }

    private void checkBox_CSPForm_ServerAuth_UseJurikSoftCSPServer_CheckedChanged(object sender, EventArgs e)
    {
        this.textBox_CSPForm_ServerAuth_CustomCSPServiceIPAddress.Enabled = this.textBox_CSPForm_ServerAuth_CustomCSPServicePort.Enabled = !this.checkBox_CSPForm_ServerAuth_UseJurikSoftCSPServer.Checked;
    }

    private void checkBox_ChangeUINAccountState_UseJurikSoftCSPServer_CheckedChanged(object sender, EventArgs e)
    {
        this.textBox_ChangeUINAccountState_CustomCSPServiceIPAddress.Enabled = this.textBox_ChangeUINAccountState_CustomCSPServicePort.Enabled = !this.checkBox_ChangeUINAccountState_UseJurikSoftCSPServer.Checked;
    }

    private void checkBox_CSPForm_CSPServersList_UseJurikSoftCSPServer_CheckedChanged(object sender, EventArgs e)
    {
        this.textBox_CSPForm_CSPServersList_CustomCSPServiceIPAddress.Enabled = this.textBox_CSPForm_CSPServersList_CustomCSPServicePort.Enabled = !this.checkBox_CSPForm_CSPServersList_UseJurikSoftCSPServer.Checked;
    }

    private void listBox_CSPForm_ProxySettings_ProxyType_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool bool_AuthEnabled = true;

        if (listBox_CSPForm_ProxySettings_ProxyType.SelectedIndex == 0) bool_AuthEnabled = false;

        this.label_CSPForm_ProxySettings_Socks5UserName.Enabled =
        this.label_CSPForm_ProxySettings_Socks5Password.Enabled =
        this.textBox_CSPForm_ProxySettings_Socks5UserName.Enabled =
        this.textBox_CSPForm_ProxySettings_Socks5Password.Enabled =
        this.checkBox_CSPForm_ProxySettings_Authentication.Enabled = bool_AuthEnabled;

        this.checkBox_CSPForm_ProxySettings_Authentication_CheckedChanged(null, null);
    }

    private void checkBox_CSPForm_ServerAuth_KeepConnectionAlive_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void checkBox_CSPForm_ServerAuth_WaitForServer_CheckedChanged(object sender, EventArgs e)
    {

    }
}

