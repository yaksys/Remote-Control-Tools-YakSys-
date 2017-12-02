using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JurikSoft.RCTServiceGUI;


public partial class RegisterNewUINForm : Form
{
    string string_Host, string_Port;
    string Port
    {
        get
        {
            return string_Port;
        }
        set
        {
            string_Port = value;
        }
    }
    string Host
    {
        get
        {
            return string_Host;
        }
        set
        {
            string_Host = value;
        }
    }

    public RegisterNewUINForm()
    {
        InitializeComponent();

        SetLanguageSettings();

        checkBox_UINRegistrationForm_UseCommonJSCSPService_CheckedChanged(null, null);

        LocalObjCopy.obj_MainServerForm.Activate();
    }

    void SetLanguageSettings()
    {
        this.Text = ServerStringFactory.GetString(765, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.groupBox_UINRegistrationForm_AdditionalInformation.Text = ServerStringFactory.GetString(141, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.groupBox_UINRegistrationForm_AccountInformation.Text = ServerStringFactory.GetString(140, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.label_UINRegistrationForm_Company.Text = ServerStringFactory.GetString(136, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.label_UINRegistrationForm_FirstName.Text = ServerStringFactory.GetString(131, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_UINRegistrationForm_MiddleName.Text = ServerStringFactory.GetString(133, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_UINRegistrationForm_LastName.Text = ServerStringFactory.GetString(132, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.label_UINRegistrationForm_ICQ.Text = ServerStringFactory.GetString(135, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_UINRegistrationForm_EMailAddress.Text = ServerStringFactory.GetString(134, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.label_UINRegistrationForm_HomePhone.Text = ServerStringFactory.GetString(137, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_UINRegistrationForm_WorkPhone.Text = ServerStringFactory.GetString(138, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_UINRegistrationForm_PrivateCellular.Text = ServerStringFactory.GetString(139, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.label_UINRegistrationForm_UserName.Text = ServerStringFactory.GetString(142, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.label_UINRegistrationForm_NewPassword.Text = ServerStringFactory.GetString(104, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_UINRegistrationForm_ConfirmedPassword.Text = ServerStringFactory.GetString(105, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.button_UINRegistrationForm_Cancel.Text = ServerStringFactory.GetString(86, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_UINRegistrationForm_Register.Text = ServerStringFactory.GetString(761, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.label_UINRegistrationForm_Notice.Text = ServerStringFactory.GetString(762, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.label_UINRegistrationForm_CustomCSPServicePort.Text = ServerStringFactory.GetString(8, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_UINRegistrationForm_CustomCSPServiceIPAddress.Text = ServerStringFactory.GetString(763, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.checkBox_UINRegistrationForm_UseCommonJSCSPService.Text = ServerStringFactory.GetString(764, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
    }

    void ServerUINRegisteredEventProcessing(ulong ulong_RegisteredUIN)
    {
        this.Invoke((MethodInvoker)delegate
        {
            MessageBox.Show(ServerStringFactory.GetString(798, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage) + ulong_RegisteredUIN.ToString());

            CSP.CommonNetworkEvents.ServerUINRegisteredEvent -= ServerUINRegisteredEventProcessing;
        });

        this.Close();
    }

    int CSP_ServerAuth_CSPPort
    {
        get
        {
            string string_ConnectingServicePort = this.textBox_UINRegistrationForm_CustomCSPServicePort.Text;

            int int_ConnectingServicePort = 5545;

            if (int.TryParse(string_ConnectingServicePort, out int_ConnectingServicePort) == true)
            {
                if (int_ConnectingServicePort < 1024 || int_ConnectingServicePort > 65535)
                {
                    MessageBox.Show(ServerStringFactory.GetString(725, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

                    return 0;
                }
            }
            else
            {
                MessageBox.Show(ServerStringFactory.GetString(724, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

                return 0;
            }

            return int_ConnectingServicePort;
        }
    }

    private void button_UINRegistrationForm_Register_Click(object sender, EventArgs e)
    {
        CSP.CommonNetworkEvents.ServerUINRegisteredEvent -= ServerUINRegisteredEventProcessing;

        if (this.textBox_UINRegistrationForm_NewPassword.Text != this.textBox_UINRegistrationForm_ConfirmedPassword.Text)
        {
            MessageBox.Show(ServerStringFactory.GetString(115, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

            return;
        }

        string string_UserName = this.textBox_UINRegistrationForm_UserName.Text,
                string_Password = this.textBox_UINRegistrationForm_NewPassword.Text,
                string_FirstName = this.textBox_UINRegistrationForm_FirstName.Text,
                string_SecondName = this.textBox_UINRegistrationForm_MiddleName.Text,
                string_LastName = this.textBox_UINRegistrationForm_LastName.Text,
                string_ICQ = this.textBox_UINRegistrationForm_ICQ.Text,
                string_EMail = this.textBox_UINRegistrationForm_EMailAddress.Text,
                string_Work = this.textBox_UINRegistrationForm_Company.Text,
                string_HomePhone = this.textBox_UINRegistrationForm_HomePhome.Text,
                string_WorkPhone = this.textBox_UINRegistrationForm_WorkPhone.Text,
                string_MobilePhone = this.textBox_UINRegistrationForm_PrivateCellular.Text;


        if (string_Password.Length < 6)
        {
            MessageBox.Show(ServerStringFactory.GetString(116, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

            return;
        }

        if (string_EMail.Length < 6)
        {
            MessageBox.Show(ServerStringFactory.GetString(810, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

            return;
        }

        if (string_UserName.Length < 1)
        {
            MessageBox.Show(ServerStringFactory.GetString(811, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

            return;
        }


        this.Host = this.textBox_UINRegistrationForm_CustomCSPServiceIPAddress.Text;
        this.Port = this.textBox_UINRegistrationForm_CustomCSPServicePort.Text;

        int int_Port = CSP_ServerAuth_CSPPort;

        if (int_Port == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(787, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

            return;
        }

        if (this.checkBox_UINRegistrationForm_UseCommonJSCSPService.Checked == true)
        {
            this.Host = CSP.ConnectingServiceProvider.GetCommonCSPIPString();

            System.Net.IPAddress iPAddress_ParsedCSIP;

            if (System.Net.IPAddress.TryParse(this.Host, out iPAddress_ParsedCSIP) == false)
            {
                MessageBox.Show(ServerStringFactory.GetString(812, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

                return;
            }
        }

        try
        {
            CSP.ConnectingServiceProvider connectingServiceProvider_obj = new CSP.ConnectingServiceProvider();

            bool bool_AuthComplete = connectingServiceProvider_obj.RegisterNewServerUINRequest(string_Host, int_Port, string_UserName, string_Password, string_FirstName, string_SecondName, string_LastName, string_ICQ, string_EMail, string_Work, string_HomePhone, string_WorkPhone, string_MobilePhone);

            if (bool_AuthComplete == false)
            {
                MessageBox.Show(ServerStringFactory.GetString(813, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

                return;
            }

            CSP.CommonNetworkEvents.ServerUINRegisteredEvent += ServerUINRegisteredEventProcessing;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ServerStringFactory.GetString(813, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
        }
    }

    private void button_UINRegistrationForm_Cancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void checkBox_UINRegistrationForm_UseCommonJSCSPService_CheckedChanged(object sender, EventArgs e)
    {
        this.textBox_UINRegistrationForm_CustomCSPServiceIPAddress.Enabled = this.textBox_UINRegistrationForm_CustomCSPServicePort.Enabled = !this.checkBox_UINRegistrationForm_UseCommonJSCSPService.Checked;
    }
}
