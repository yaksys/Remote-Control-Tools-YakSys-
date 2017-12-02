using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;

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

        ObjCopy.obj_MainClientForm.Activate();
    }

    void SetLanguageSettings()
    {
        this.Text = ClientStringFactory.GetString(748, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_UINRegistrationForm_AdditionalInformation.Text = ClientStringFactory.GetString(746, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_UINRegistrationForm_AccountInformation.Text = ClientStringFactory.GetString(745, ClientSettingsEnvironment.CurrentLanguage);

        this.label_UINRegistrationForm_Company.Text = ClientStringFactory.GetString(741, ClientSettingsEnvironment.CurrentLanguage);

        this.label_UINRegistrationForm_FirstName.Text = ClientStringFactory.GetString(736, ClientSettingsEnvironment.CurrentLanguage);
        this.label_UINRegistrationForm_MiddleName.Text = ClientStringFactory.GetString(738, ClientSettingsEnvironment.CurrentLanguage);
        this.label_UINRegistrationForm_LastName.Text = ClientStringFactory.GetString(737, ClientSettingsEnvironment.CurrentLanguage);

        this.label_UINRegistrationForm_ICQ.Text = ClientStringFactory.GetString(740, ClientSettingsEnvironment.CurrentLanguage);
        this.label_UINRegistrationForm_EMailAddress.Text = ClientStringFactory.GetString(739, ClientSettingsEnvironment.CurrentLanguage);

        this.label_UINRegistrationForm_HomePhone.Text = ClientStringFactory.GetString(742, ClientSettingsEnvironment.CurrentLanguage);
        this.label_UINRegistrationForm_WorkPhone.Text = ClientStringFactory.GetString(743, ClientSettingsEnvironment.CurrentLanguage);
        this.label_UINRegistrationForm_PrivateCellular.Text = ClientStringFactory.GetString(744, ClientSettingsEnvironment.CurrentLanguage);

        this.label_UINRegistrationForm_UserName.Text = ClientStringFactory.GetString(747, ClientSettingsEnvironment.CurrentLanguage);

        this.label_UINRegistrationForm_NewPassword.Text = ClientStringFactory.GetString(528, ClientSettingsEnvironment.CurrentLanguage);
        this.label_UINRegistrationForm_ConfirmedPassword.Text = ClientStringFactory.GetString(529, ClientSettingsEnvironment.CurrentLanguage);

        this.button_UINRegistrationForm_Cancel.Text = ClientStringFactory.GetString(265, ClientSettingsEnvironment.CurrentLanguage);
        this.button_UINRegistrationForm_Register.Text = ClientStringFactory.GetString(330, ClientSettingsEnvironment.CurrentLanguage);

        this.label_UINRegistrationForm_Notice.Text = ClientStringFactory.GetString(749, ClientSettingsEnvironment.CurrentLanguage);

        this.label_UINRegistrationForm_CustomCSPServicePort.Text = ClientStringFactory.GetString(72, ClientSettingsEnvironment.CurrentLanguage);
        this.label_UINRegistrationForm_CustomCSPServiceIPAddress.Text = ClientStringFactory.GetString(711, ClientSettingsEnvironment.CurrentLanguage);

        this.checkBox_UINRegistrationForm_UseCommonJSCSPService.Text = ClientStringFactory.GetString(703, ClientSettingsEnvironment.CurrentLanguage);
    }

    void ClientUINRegisteredEventProcessing(ulong ulong_RegisteredUIN)
    {
        this.Invoke((MethodInvoker)delegate
              {
                  MessageBox.Show(ClientStringFactory.GetString(750, ClientSettingsEnvironment.CurrentLanguage) + ulong_RegisteredUIN.ToString());

                  CSP.CommonNetworkEvents.ClientUINRegisteredEvent -= ClientUINRegisteredEventProcessing;
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

    private void button_UINRegistrationForm_Register_Click(object sender, EventArgs e)
    {
        CSP.CommonNetworkEvents.ClientUINRegisteredEvent -= ClientUINRegisteredEventProcessing;

        if (this.textBox_UINRegistrationForm_NewPassword.Text != this.textBox_UINRegistrationForm_ConfirmedPassword.Text)
        {
            MessageBox.Show(ClientStringFactory.GetString(531, ClientSettingsEnvironment.CurrentLanguage));

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
            MessageBox.Show(ClientStringFactory.GetString(532, ClientSettingsEnvironment.CurrentLanguage));

            return;
        }

        if (string_EMail.Length < 6)
        {
            MessageBox.Show(ClientStringFactory.GetString(751, ClientSettingsEnvironment.CurrentLanguage));

            return;
        }

        if (string_UserName.Length < 1)
        {
            MessageBox.Show(ClientStringFactory.GetString(752, ClientSettingsEnvironment.CurrentLanguage));

            return;
        }


        this.Host = this.textBox_UINRegistrationForm_CustomCSPServiceIPAddress.Text;
        this.Port = this.textBox_UINRegistrationForm_CustomCSPServicePort.Text;

        int int_Port = CSP_ServerAuth_CSPPort;

        if (int_Port == 0)
        {
            MessageBox.Show(ClientStringFactory.GetString(724, ClientSettingsEnvironment.CurrentLanguage));

            return;
        }

        if (this.checkBox_UINRegistrationForm_UseCommonJSCSPService.Checked == true)
        {
            this.Host = CSP.ConnectingServiceProvider.GetCommonCSPIPString();

            System.Net.IPAddress iPAddress_ParsedCSIP;

            if (System.Net.IPAddress.TryParse(this.Host, out iPAddress_ParsedCSIP) == false)
            {
                MessageBox.Show(ClientStringFactory.GetString(735, ClientSettingsEnvironment.CurrentLanguage));

                return;
            }
        }

        try
        {
            CSP.ConnectingServiceProvider connectingServiceProvider_obj = new CSP.ConnectingServiceProvider();

            bool bool_AuthComplete = connectingServiceProvider_obj.RegisterNewClientUINRequest(string_Host, int_Port, string_UserName, string_Password, string_FirstName, string_SecondName, string_LastName, string_ICQ, string_EMail, string_Work, string_HomePhone, string_WorkPhone, string_MobilePhone);

            if (bool_AuthComplete == false)
            {
                MessageBox.Show(ClientStringFactory.GetString(753, ClientSettingsEnvironment.CurrentLanguage));

                return;
            }

            CSP.CommonNetworkEvents.ClientUINRegisteredEvent += ClientUINRegisteredEventProcessing;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ClientStringFactory.GetString(753, ClientSettingsEnvironment.CurrentLanguage));
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
