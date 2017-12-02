using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctClient;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;

public class SettingsForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.ComboBox comboBox_SettingsForm_Language;
    private System.Windows.Forms.Button button_SettingsForm_OK;
    private System.Windows.Forms.GroupBox groupBox_SettingsForm_Language;
    private System.Windows.Forms.Button button_SettingsForm_Cancel;
    private System.Windows.Forms.Label label_SettingsForm_CurrentLanguage;
    private System.Windows.Forms.TabControl tabControl_SettingsForm_SettingsTabs;
    private System.Windows.Forms.TabPage tabPage_SettingsForm_Encryption;
    private System.Windows.Forms.TabPage tabPage_SettingsForm_Compression;
    private System.Windows.Forms.CheckBox checkBox_SettingsForm_ShowToolTips;
    private System.Windows.Forms.TabPage tabPage_SettingsForm_Main;
    private System.Windows.Forms.CheckBox checkBox_SettingsForm_EncryptSentFiles;
    private System.Windows.Forms.CheckBox checkBox_SettingsForm_EncryptDownloadedFiles;
    private System.Windows.Forms.CheckBox checkBox_SettingsForm_EncryptReceivedSystemData;
    private System.Windows.Forms.CheckBox checkBox_SettingsForm_EncryptSendingSystemData;
    private System.Windows.Forms.CheckBox checkBox_SettingsForm_EncryptReceivedScreenshots;
    private System.Windows.Forms.Label label_SettingsForm_EncryptSendingSystemDataAlgorithm;
    private System.Windows.Forms.Label label_SettingsForm_EncryptReceivedSystemDataAlgorithm;
    private System.Windows.Forms.Label label_SettingsForm_EncryptReceivedScreenshotsAlgorithm;
    private System.Windows.Forms.Label label_SettingsForm_EncryptDownloadedFilesAlgorithm;
    private System.Windows.Forms.Label label_SettingsForm_EncryptSentFilesAlgorithm;
    private System.Windows.Forms.ComboBox comboBox_SettingsForm_EncryptSentFilesAlgorithm;
    private System.Windows.Forms.ComboBox comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm;
    private System.Windows.Forms.ComboBox comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm;
    private System.Windows.Forms.ComboBox comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm;
    private System.Windows.Forms.ComboBox comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm;
    private System.Windows.Forms.CheckBox checkBox_SettingsForm_CompressReceivedSystemData;
    private System.Windows.Forms.CheckBox checkBox_SettingsForm_CompressSentFiles;
    private System.Windows.Forms.CheckBox checkBox_SettingsForm_CompressDownloadedFiles;
    private System.Windows.Forms.ComboBox comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm;
    private System.Windows.Forms.Label label_SettingsForm_CompressReceivedSystemDataAlgorithm;
    private System.Windows.Forms.ComboBox comboBox_SettingsForm_CompressDownloadedFilesAlgorithm;
    private System.Windows.Forms.Label label_SettingsForm_CompressDownloadedFilesAlgorithm;
    private System.Windows.Forms.ComboBox comboBox_SettingsForm_CompressSentFilesAlgorithm;
    private System.Windows.Forms.Label label_SettingsForm_CompressSentFilesAlgorithm;
    private System.Windows.Forms.CheckBox checkBox_SettingsForm_ShowAdvancedSettings;
    private System.Windows.Forms.TextBox textBox_SettingsForm_DonwloadedFilesPath;
    private System.Windows.Forms.Label label_SettingsForm_DonwloadedFilesPath;
    private System.Windows.Forms.GroupBox groupBox_SettingsForm_DownloadedFiles;
    private System.Windows.Forms.Button button_SettingsForm_ChangeDownloadedScreenShotsFolder;
    private System.Windows.Forms.Button button_SettingsForm_ChangeDonwloadedFilesFolder;
    private System.Windows.Forms.Button button_SettingsForm_OpenDownloadedScreenShotsFolder;
    private System.Windows.Forms.Button button_SettingsForm_OpenDonwloadedFilesFolder;
    private System.Windows.Forms.GroupBox groupBox_SettingsForm_DownloadedScreenShots;
    private System.Windows.Forms.TextBox textBox_SettingsForm_DownloadedScreenShotsPath;
    private System.Windows.Forms.Label label_SettingsForm_DownloadedScreenShotsPath;
    private System.Windows.Forms.Button button_RestoreToDefaults;
    private System.Windows.Forms.TabPage tabPage_SettingsForm_LocalSecurity;
    private System.Windows.Forms.GroupBox groupBox_SettingsForm_EncryptSendingSystemData;
    private System.Windows.Forms.GroupBox groupBox_SettingsForm_EncryptReceivedSystemData;
    private System.Windows.Forms.GroupBox groupBox_SettingsForm_EncryptReceivedScreenshots;
    private System.Windows.Forms.GroupBox groupBox_SettingsForm_EncryptDownloadedFiles;
    private System.Windows.Forms.GroupBox groupBox_SettingsForm_EncryptSentFiles;
    private System.Windows.Forms.GroupBox groupBox_SettingsForm_CompressReceivedSystemData;
    private System.Windows.Forms.GroupBox groupBox_SettingsForm_CompressDownloadedFiles;
    private System.Windows.Forms.GroupBox groupBox_SettingsForm_CompressSentFiles;
    private System.Windows.Forms.GroupBox groupBox_LocalSecurity_UsedPassword;
    private System.Windows.Forms.Button button_LocalSecurity_SetPassword;
    private System.Windows.Forms.Button button_LocalSecurity_NewPassword;
    private System.Windows.Forms.Label label_LocalSecurity_NewPassword;
    private System.Windows.Forms.TextBox textBox_LocalSecurity_ConfirmedPassword;
    private System.Windows.Forms.TextBox textBox_LocalSecurity_NewPassword;
    private System.Windows.Forms.Label label_LocalSecurity_ConfirmedPassword;
    private System.Windows.Forms.GroupBox groupBox_LocalSecurity_SecurityParameters;
    private System.Windows.Forms.CheckBox checkBox_LocalSecurity_CompressSettingsDatabase;
    private System.Windows.Forms.CheckBox checkBox_LocalSecurity_EncryptSettingsDatabase;
    private System.Windows.Forms.CheckBox checkBox_LocalSecurity_RememberPasswords;
    private System.Windows.Forms.CheckBox checkBox_LocalSecurity_RememberLogins;
    private System.Windows.Forms.ComboBox comboBox_SettingsForm_CompressSendingSystemDataAlgorithm;
    private System.Windows.Forms.Label label_SettingsForm_CompressSendingSystemDataAlgorithm;
    private System.Windows.Forms.CheckBox checkBox_SettingsForm_CompressSendingSystemData;
    private System.Windows.Forms.GroupBox groupBox_SettingsForm_CompressSendingSystemData;
    private System.Windows.Forms.ComboBox comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm;
    private System.Windows.Forms.Label label_SettingsForm_CompressReceivedScreenshotsAlgorithm;
    private System.Windows.Forms.CheckBox checkBox_SettingsForm_CompressReceivedScreenshots;
    private System.Windows.Forms.GroupBox groupBox_SettingsForm_CompressReceivedScreenshots;

    private System.ComponentModel.Container components = null;

    public SettingsForm()
    {
        InitializeComponent();

        ChangeControlsLanguage();

        this.checkBox_SettingsForm_EncryptSentFiles.Checked = ClientSettingsEnvironment.ToEncryptSentFiles;
        this.checkBox_SettingsForm_EncryptDownloadedFiles.Checked = ClientSettingsEnvironment.ToEncryptDownloadedFiles;

        this.checkBox_SettingsForm_EncryptReceivedScreenshots.Checked = ClientSettingsEnvironment.ToEncryptReceivedScreenshots;

        this.checkBox_SettingsForm_EncryptSendingSystemData.Checked = ClientSettingsEnvironment.ToEncryptSentSystemData;
        this.checkBox_SettingsForm_EncryptReceivedSystemData.Checked = ClientSettingsEnvironment.ToEncryptReceivedSystemData;


        this.checkBox_SettingsForm_CompressSentFiles.Checked = ClientSettingsEnvironment.ToCompressSentFiles;
        this.checkBox_SettingsForm_CompressDownloadedFiles.Checked = ClientSettingsEnvironment.ToCompressDownloadedFiles;

        this.checkBox_SettingsForm_CompressReceivedScreenshots.Checked = ClientSettingsEnvironment.ToCompressReceivedScreenshots;

        this.checkBox_SettingsForm_CompressSendingSystemData.Checked = ClientSettingsEnvironment.ToCompressSentSystemData;
        this.checkBox_SettingsForm_CompressReceivedSystemData.Checked = ClientSettingsEnvironment.ToCompressReceivedSystemData;


        this.comboBox_SettingsForm_EncryptSentFilesAlgorithm.SelectedIndex = ClientSettingsEnvironment.SentFilesEncryptAlgorithmIndex;
        this.comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm.SelectedIndex = ClientSettingsEnvironment.DownloadedFilesEncryptAlgorithmIndex;
        this.comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm.SelectedIndex = ClientSettingsEnvironment.ReceivedScreenshotsEncryptAlgorithmIndex;
        this.comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm.SelectedIndex = ClientSettingsEnvironment.SendingSystemDataEncryptAlgorithmIndex;
        this.comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm.SelectedIndex = ClientSettingsEnvironment.ReceivedSystemDataEncryptAlgorithmIndex;

        this.comboBox_SettingsForm_CompressSentFilesAlgorithm.SelectedIndex = ClientSettingsEnvironment.SentFilesCompressAlgorithmIndex;
        this.comboBox_SettingsForm_CompressDownloadedFilesAlgorithm.SelectedIndex = ClientSettingsEnvironment.DownloadedFilesCompressAlgorithmIndex;
        this.comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm.SelectedIndex = ClientSettingsEnvironment.ReceivedScreenshotsCompressAlgorithmIndex;
        this.comboBox_SettingsForm_CompressSendingSystemDataAlgorithm.SelectedIndex = ClientSettingsEnvironment.SendingSystemDataCompressAlgorithmIndex;
        this.comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm.SelectedIndex = ClientSettingsEnvironment.ReceivedSystemDataCompressAlgorithmIndex;


        this.textBox_SettingsForm_DonwloadedFilesPath.Text = ClientSettingsEnvironment.DownloadedFilesPath;
        this.textBox_SettingsForm_DownloadedScreenShotsPath.Text = ClientSettingsEnvironment.DownloadedScreenShotsPath;


        this.comboBox_SettingsForm_EncryptSentFilesAlgorithm.Enabled = this.checkBox_SettingsForm_EncryptSentFiles.Checked;
        this.comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm.Enabled = this.checkBox_SettingsForm_EncryptDownloadedFiles.Checked;
        this.comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm.Enabled = this.checkBox_SettingsForm_EncryptReceivedScreenshots.Checked;
        this.comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm.Enabled = this.checkBox_SettingsForm_EncryptSendingSystemData.Checked;
        this.comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm.Enabled = this.checkBox_SettingsForm_EncryptReceivedSystemData.Checked;

        this.comboBox_SettingsForm_CompressSentFilesAlgorithm.Enabled = this.checkBox_SettingsForm_CompressSentFiles.Checked;
        this.comboBox_SettingsForm_CompressDownloadedFilesAlgorithm.Enabled = this.checkBox_SettingsForm_CompressDownloadedFiles.Checked;
        this.comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm.Enabled = this.checkBox_SettingsForm_CompressReceivedScreenshots.Checked;
        this.comboBox_SettingsForm_CompressSendingSystemDataAlgorithm.Enabled = this.checkBox_SettingsForm_CompressSendingSystemData.Checked;
        this.comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm.Enabled = this.checkBox_SettingsForm_CompressReceivedSystemData.Checked;

        this.checkBox_SettingsForm_ShowToolTips.Checked = ClientSettingsEnvironment.ShowToolTips;
        this.checkBox_SettingsForm_ShowAdvancedSettings.Checked = ClientSettingsEnvironment.ShowAdvancedSettings;

        this.checkBox_LocalSecurity_RememberLogins.Checked = ClientSettingsEnvironment.RememberLogins;
        this.checkBox_LocalSecurity_RememberPasswords.Checked = ClientSettingsEnvironment.RememberPasswords;
        this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked = ClientSettingsEnvironment.EncryptSettingsDataBase;
        this.checkBox_LocalSecurity_CompressSettingsDatabase.Checked = ClientSettingsEnvironment.CompressSettingsDataBase;

        this.textBox_LocalSecurity_NewPassword.Text = this.textBox_LocalSecurity_ConfirmedPassword.Text = ClientSettingsEnvironment.LocalSecurityPassword;

        this.checkBox_SettingsForm_ShowAdvancedSettings_CheckedChanged(null, null);


        if (this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked == false)
        {
            this.groupBox_LocalSecurity_UsedPassword.Enabled = false;

            this.textBox_LocalSecurity_NewPassword.Text = this.textBox_LocalSecurity_ConfirmedPassword.Text = String.Empty;
        }

        this.checkBox_LocalSecurity_EncryptSettingsDatabase_CheckedChanged(null, null);

    }

    void ChangeControlsLanguage()
    {
        this.Text = ClientStringFactory.GetString(239, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_SettingsForm_DownloadedFiles.Text = ClientStringFactory.GetString(254, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_SettingsForm_DownloadedScreenShots.Text = ClientStringFactory.GetString(253, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_SettingsForm_Language.Text = ClientStringFactory.GetString(252, ClientSettingsEnvironment.CurrentLanguage);

        this.button_SettingsForm_OpenDownloadedScreenShotsFolder.Text = ClientStringFactory.GetString(476, ClientSettingsEnvironment.CurrentLanguage);
        this.button_SettingsForm_OpenDonwloadedFilesFolder.Text = ClientStringFactory.GetString(476, ClientSettingsEnvironment.CurrentLanguage);

        this.button_SettingsForm_Cancel.Text = ClientStringFactory.GetString(265, ClientSettingsEnvironment.CurrentLanguage);

        this.button_SettingsForm_ChangeDonwloadedFilesFolder.Text = ClientStringFactory.GetString(475, ClientSettingsEnvironment.CurrentLanguage);
        this.button_SettingsForm_ChangeDownloadedScreenShotsFolder.Text = ClientStringFactory.GetString(475, ClientSettingsEnvironment.CurrentLanguage);

        this.tabPage_SettingsForm_Encryption.Text = ClientStringFactory.GetString(293, ClientSettingsEnvironment.CurrentLanguage);
        this.tabPage_SettingsForm_Main.Text = ClientStringFactory.GetString(466, ClientSettingsEnvironment.CurrentLanguage);
        this.tabPage_SettingsForm_Compression.Text = ClientStringFactory.GetString(468, ClientSettingsEnvironment.CurrentLanguage);
        this.tabPage_SettingsForm_LocalSecurity.Text = ClientStringFactory.GetString(498, ClientSettingsEnvironment.CurrentLanguage);

        this.checkBox_SettingsForm_ShowToolTips.Text = ClientStringFactory.GetString(467, ClientSettingsEnvironment.CurrentLanguage);


        this.label_SettingsForm_DownloadedScreenShotsPath.Text = ClientStringFactory.GetString(255, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SettingsForm_DonwloadedFilesPath.Text = ClientStringFactory.GetString(255, ClientSettingsEnvironment.CurrentLanguage);


        this.checkBox_SettingsForm_EncryptSentFiles.Text = ClientStringFactory.GetString(295, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_SettingsForm_EncryptDownloadedFiles.Text = ClientStringFactory.GetString(294, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_SettingsForm_EncryptReceivedScreenshots.Text = ClientStringFactory.GetString(296, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_SettingsForm_EncryptSendingSystemData.Text = ClientStringFactory.GetString(298, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_SettingsForm_EncryptReceivedSystemData.Text = ClientStringFactory.GetString(297, ClientSettingsEnvironment.CurrentLanguage);

        this.checkBox_SettingsForm_CompressSentFiles.Text = ClientStringFactory.GetString(469, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_SettingsForm_CompressDownloadedFiles.Text = ClientStringFactory.GetString(470, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_SettingsForm_CompressReceivedScreenshots.Text = ClientStringFactory.GetString(471, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_SettingsForm_CompressSendingSystemData.Text = ClientStringFactory.GetString(472, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_SettingsForm_CompressReceivedSystemData.Text = ClientStringFactory.GetString(473, ClientSettingsEnvironment.CurrentLanguage);

        this.label_SettingsForm_CurrentLanguage.Text = ClientStringFactory.GetString(299, ClientSettingsEnvironment.CurrentLanguage);

        this.checkBox_SettingsForm_ShowAdvancedSettings.Text = ClientStringFactory.GetString(477, ClientSettingsEnvironment.CurrentLanguage);

        this.button_RestoreToDefaults.Text = ClientStringFactory.GetString(478, ClientSettingsEnvironment.CurrentLanguage);

        this.label_SettingsForm_CompressDownloadedFilesAlgorithm.Text = ClientStringFactory.GetString(479, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SettingsForm_CompressReceivedScreenshotsAlgorithm.Text = ClientStringFactory.GetString(479, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SettingsForm_CompressReceivedSystemDataAlgorithm.Text = ClientStringFactory.GetString(479, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SettingsForm_CompressSendingSystemDataAlgorithm.Text = ClientStringFactory.GetString(479, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SettingsForm_CompressSentFilesAlgorithm.Text = ClientStringFactory.GetString(479, ClientSettingsEnvironment.CurrentLanguage);

        this.label_SettingsForm_EncryptDownloadedFilesAlgorithm.Text = ClientStringFactory.GetString(479, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SettingsForm_EncryptReceivedScreenshotsAlgorithm.Text = ClientStringFactory.GetString(479, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SettingsForm_EncryptReceivedSystemDataAlgorithm.Text = ClientStringFactory.GetString(479, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SettingsForm_EncryptSendingSystemDataAlgorithm.Text = ClientStringFactory.GetString(479, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SettingsForm_EncryptSentFilesAlgorithm.Text = ClientStringFactory.GetString(479, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_LocalSecurity_SecurityParameters.Text = ClientStringFactory.GetString(521, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_LocalSecurity_UsedPassword.Text = ClientStringFactory.GetString(530, ClientSettingsEnvironment.CurrentLanguage);

        this.label_LocalSecurity_NewPassword.Text = ClientStringFactory.GetString(73, ClientSettingsEnvironment.CurrentLanguage);
        this.label_LocalSecurity_ConfirmedPassword.Text = ClientStringFactory.GetString(529, ClientSettingsEnvironment.CurrentLanguage);

        this.button_LocalSecurity_SetPassword.Text = ClientStringFactory.GetString(527, ClientSettingsEnvironment.CurrentLanguage);
        this.button_LocalSecurity_NewPassword.Text = ClientStringFactory.GetString(526, ClientSettingsEnvironment.CurrentLanguage);

        this.checkBox_LocalSecurity_RememberPasswords.Text = ClientStringFactory.GetString(523, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_LocalSecurity_RememberLogins.Text = ClientStringFactory.GetString(522, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_LocalSecurity_CompressSettingsDatabase.Text = ClientStringFactory.GetString(525, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_LocalSecurity_EncryptSettingsDatabase.Text = ClientStringFactory.GetString(524, ClientSettingsEnvironment.CurrentLanguage);

        this.comboBox_SettingsForm_Language.SelectedIndex = ClientSettingsEnvironment.CurrentLanguage;

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


    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
        this.comboBox_SettingsForm_Language = new System.Windows.Forms.ComboBox();
        this.button_SettingsForm_OK = new System.Windows.Forms.Button();
        this.groupBox_SettingsForm_DownloadedFiles = new System.Windows.Forms.GroupBox();
        this.label_SettingsForm_DonwloadedFilesPath = new System.Windows.Forms.Label();
        this.textBox_SettingsForm_DonwloadedFilesPath = new System.Windows.Forms.TextBox();
        this.button_SettingsForm_ChangeDonwloadedFilesFolder = new System.Windows.Forms.Button();
        this.button_SettingsForm_OpenDonwloadedFilesFolder = new System.Windows.Forms.Button();
        this.button_SettingsForm_ChangeDownloadedScreenShotsFolder = new System.Windows.Forms.Button();
        this.button_SettingsForm_OpenDownloadedScreenShotsFolder = new System.Windows.Forms.Button();
        this.checkBox_SettingsForm_EncryptReceivedSystemData = new System.Windows.Forms.CheckBox();
        this.checkBox_SettingsForm_EncryptSendingSystemData = new System.Windows.Forms.CheckBox();
        this.checkBox_SettingsForm_EncryptSentFiles = new System.Windows.Forms.CheckBox();
        this.checkBox_SettingsForm_EncryptReceivedScreenshots = new System.Windows.Forms.CheckBox();
        this.checkBox_SettingsForm_EncryptDownloadedFiles = new System.Windows.Forms.CheckBox();
        this.button_SettingsForm_Cancel = new System.Windows.Forms.Button();
        this.groupBox_SettingsForm_Language = new System.Windows.Forms.GroupBox();
        this.label_SettingsForm_CurrentLanguage = new System.Windows.Forms.Label();
        this.tabControl_SettingsForm_SettingsTabs = new System.Windows.Forms.TabControl();
        this.tabPage_SettingsForm_Main = new System.Windows.Forms.TabPage();
        this.groupBox_SettingsForm_DownloadedScreenShots = new System.Windows.Forms.GroupBox();
        this.label_SettingsForm_DownloadedScreenShotsPath = new System.Windows.Forms.Label();
        this.textBox_SettingsForm_DownloadedScreenShotsPath = new System.Windows.Forms.TextBox();
        this.checkBox_SettingsForm_ShowAdvancedSettings = new System.Windows.Forms.CheckBox();
        this.checkBox_SettingsForm_ShowToolTips = new System.Windows.Forms.CheckBox();
        this.tabPage_SettingsForm_LocalSecurity = new System.Windows.Forms.TabPage();
        this.groupBox_LocalSecurity_SecurityParameters = new System.Windows.Forms.GroupBox();
        this.checkBox_LocalSecurity_CompressSettingsDatabase = new System.Windows.Forms.CheckBox();
        this.checkBox_LocalSecurity_EncryptSettingsDatabase = new System.Windows.Forms.CheckBox();
        this.checkBox_LocalSecurity_RememberPasswords = new System.Windows.Forms.CheckBox();
        this.checkBox_LocalSecurity_RememberLogins = new System.Windows.Forms.CheckBox();
        this.groupBox_LocalSecurity_UsedPassword = new System.Windows.Forms.GroupBox();
        this.button_LocalSecurity_SetPassword = new System.Windows.Forms.Button();
        this.button_LocalSecurity_NewPassword = new System.Windows.Forms.Button();
        this.label_LocalSecurity_NewPassword = new System.Windows.Forms.Label();
        this.textBox_LocalSecurity_ConfirmedPassword = new System.Windows.Forms.TextBox();
        this.textBox_LocalSecurity_NewPassword = new System.Windows.Forms.TextBox();
        this.label_LocalSecurity_ConfirmedPassword = new System.Windows.Forms.Label();
        this.tabPage_SettingsForm_Encryption = new System.Windows.Forms.TabPage();
        this.groupBox_SettingsForm_EncryptSendingSystemData = new System.Windows.Forms.GroupBox();
        this.comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm = new System.Windows.Forms.ComboBox();
        this.label_SettingsForm_EncryptSendingSystemDataAlgorithm = new System.Windows.Forms.Label();
        this.groupBox_SettingsForm_EncryptReceivedSystemData = new System.Windows.Forms.GroupBox();
        this.comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm = new System.Windows.Forms.ComboBox();
        this.label_SettingsForm_EncryptReceivedSystemDataAlgorithm = new System.Windows.Forms.Label();
        this.groupBox_SettingsForm_EncryptReceivedScreenshots = new System.Windows.Forms.GroupBox();
        this.comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm = new System.Windows.Forms.ComboBox();
        this.label_SettingsForm_EncryptReceivedScreenshotsAlgorithm = new System.Windows.Forms.Label();
        this.groupBox_SettingsForm_EncryptDownloadedFiles = new System.Windows.Forms.GroupBox();
        this.comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm = new System.Windows.Forms.ComboBox();
        this.label_SettingsForm_EncryptDownloadedFilesAlgorithm = new System.Windows.Forms.Label();
        this.groupBox_SettingsForm_EncryptSentFiles = new System.Windows.Forms.GroupBox();
        this.comboBox_SettingsForm_EncryptSentFilesAlgorithm = new System.Windows.Forms.ComboBox();
        this.label_SettingsForm_EncryptSentFilesAlgorithm = new System.Windows.Forms.Label();
        this.tabPage_SettingsForm_Compression = new System.Windows.Forms.TabPage();
        this.groupBox_SettingsForm_CompressSendingSystemData = new System.Windows.Forms.GroupBox();
        this.comboBox_SettingsForm_CompressSendingSystemDataAlgorithm = new System.Windows.Forms.ComboBox();
        this.label_SettingsForm_CompressSendingSystemDataAlgorithm = new System.Windows.Forms.Label();
        this.checkBox_SettingsForm_CompressSendingSystemData = new System.Windows.Forms.CheckBox();
        this.groupBox_SettingsForm_CompressReceivedSystemData = new System.Windows.Forms.GroupBox();
        this.comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm = new System.Windows.Forms.ComboBox();
        this.label_SettingsForm_CompressReceivedSystemDataAlgorithm = new System.Windows.Forms.Label();
        this.checkBox_SettingsForm_CompressReceivedSystemData = new System.Windows.Forms.CheckBox();
        this.groupBox_SettingsForm_CompressReceivedScreenshots = new System.Windows.Forms.GroupBox();
        this.comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm = new System.Windows.Forms.ComboBox();
        this.label_SettingsForm_CompressReceivedScreenshotsAlgorithm = new System.Windows.Forms.Label();
        this.checkBox_SettingsForm_CompressReceivedScreenshots = new System.Windows.Forms.CheckBox();
        this.groupBox_SettingsForm_CompressDownloadedFiles = new System.Windows.Forms.GroupBox();
        this.comboBox_SettingsForm_CompressDownloadedFilesAlgorithm = new System.Windows.Forms.ComboBox();
        this.label_SettingsForm_CompressDownloadedFilesAlgorithm = new System.Windows.Forms.Label();
        this.checkBox_SettingsForm_CompressDownloadedFiles = new System.Windows.Forms.CheckBox();
        this.groupBox_SettingsForm_CompressSentFiles = new System.Windows.Forms.GroupBox();
        this.comboBox_SettingsForm_CompressSentFilesAlgorithm = new System.Windows.Forms.ComboBox();
        this.label_SettingsForm_CompressSentFilesAlgorithm = new System.Windows.Forms.Label();
        this.checkBox_SettingsForm_CompressSentFiles = new System.Windows.Forms.CheckBox();
        this.button_RestoreToDefaults = new System.Windows.Forms.Button();
        this.groupBox_SettingsForm_DownloadedFiles.SuspendLayout();
        this.groupBox_SettingsForm_Language.SuspendLayout();
        this.tabControl_SettingsForm_SettingsTabs.SuspendLayout();
        this.tabPage_SettingsForm_Main.SuspendLayout();
        this.groupBox_SettingsForm_DownloadedScreenShots.SuspendLayout();
        this.tabPage_SettingsForm_LocalSecurity.SuspendLayout();
        this.groupBox_LocalSecurity_SecurityParameters.SuspendLayout();
        this.groupBox_LocalSecurity_UsedPassword.SuspendLayout();
        this.tabPage_SettingsForm_Encryption.SuspendLayout();
        this.groupBox_SettingsForm_EncryptSendingSystemData.SuspendLayout();
        this.groupBox_SettingsForm_EncryptReceivedSystemData.SuspendLayout();
        this.groupBox_SettingsForm_EncryptReceivedScreenshots.SuspendLayout();
        this.groupBox_SettingsForm_EncryptDownloadedFiles.SuspendLayout();
        this.groupBox_SettingsForm_EncryptSentFiles.SuspendLayout();
        this.tabPage_SettingsForm_Compression.SuspendLayout();
        this.groupBox_SettingsForm_CompressSendingSystemData.SuspendLayout();
        this.groupBox_SettingsForm_CompressReceivedSystemData.SuspendLayout();
        this.groupBox_SettingsForm_CompressReceivedScreenshots.SuspendLayout();
        this.groupBox_SettingsForm_CompressDownloadedFiles.SuspendLayout();
        this.groupBox_SettingsForm_CompressSentFiles.SuspendLayout();
        this.SuspendLayout();
        // 
        // comboBox_SettingsForm_Language
        // 
        this.comboBox_SettingsForm_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox_SettingsForm_Language.Items.AddRange(new object[] {
            "English",
            "Russian"});
        this.comboBox_SettingsForm_Language.Location = new System.Drawing.Point(100, 20);
        this.comboBox_SettingsForm_Language.Name = "comboBox_SettingsForm_Language";
        this.comboBox_SettingsForm_Language.Size = new System.Drawing.Size(88, 21);
        this.comboBox_SettingsForm_Language.Sorted = true;
        this.comboBox_SettingsForm_Language.TabIndex = 0;
        this.comboBox_SettingsForm_Language.SelectedIndexChanged += new System.EventHandler(this.comboBox_SettingsForm_Language_SelectedIndexChanged);
        // 
        // button_SettingsForm_OK
        // 
        this.button_SettingsForm_OK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.button_SettingsForm_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_SettingsForm_OK.Location = new System.Drawing.Point(328, 400);
        this.button_SettingsForm_OK.Name = "button_SettingsForm_OK";
        this.button_SettingsForm_OK.Size = new System.Drawing.Size(80, 23);
        this.button_SettingsForm_OK.TabIndex = 2;
        this.button_SettingsForm_OK.Text = "OK";
        this.button_SettingsForm_OK.Click += new System.EventHandler(this.button_SettingsForm_OK_Click);
        // 
        // groupBox_SettingsForm_DownloadedFiles
        // 
        this.groupBox_SettingsForm_DownloadedFiles.Controls.Add(this.label_SettingsForm_DonwloadedFilesPath);
        this.groupBox_SettingsForm_DownloadedFiles.Controls.Add(this.textBox_SettingsForm_DonwloadedFilesPath);
        this.groupBox_SettingsForm_DownloadedFiles.Controls.Add(this.button_SettingsForm_ChangeDonwloadedFilesFolder);
        this.groupBox_SettingsForm_DownloadedFiles.Controls.Add(this.button_SettingsForm_OpenDonwloadedFilesFolder);
        this.groupBox_SettingsForm_DownloadedFiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_SettingsForm_DownloadedFiles.Location = new System.Drawing.Point(16, 16);
        this.groupBox_SettingsForm_DownloadedFiles.Name = "groupBox_SettingsForm_DownloadedFiles";
        this.groupBox_SettingsForm_DownloadedFiles.Size = new System.Drawing.Size(472, 120);
        this.groupBox_SettingsForm_DownloadedFiles.TabIndex = 3;
        this.groupBox_SettingsForm_DownloadedFiles.TabStop = false;
        this.groupBox_SettingsForm_DownloadedFiles.Text = "Donwloaded Files";
        // 
        // label_SettingsForm_DonwloadedFilesPath
        // 
        this.label_SettingsForm_DonwloadedFilesPath.Location = new System.Drawing.Point(16, 64);
        this.label_SettingsForm_DonwloadedFilesPath.Name = "label_SettingsForm_DonwloadedFilesPath";
        this.label_SettingsForm_DonwloadedFilesPath.Size = new System.Drawing.Size(208, 16);
        this.label_SettingsForm_DonwloadedFilesPath.TabIndex = 6;
        this.label_SettingsForm_DonwloadedFilesPath.Text = "Path:";
        // 
        // textBox_SettingsForm_DonwloadedFilesPath
        // 
        this.textBox_SettingsForm_DonwloadedFilesPath.Location = new System.Drawing.Point(16, 80);
        this.textBox_SettingsForm_DonwloadedFilesPath.Name = "textBox_SettingsForm_DonwloadedFilesPath";
        this.textBox_SettingsForm_DonwloadedFilesPath.ReadOnly = true;
        this.textBox_SettingsForm_DonwloadedFilesPath.Size = new System.Drawing.Size(440, 20);
        this.textBox_SettingsForm_DonwloadedFilesPath.TabIndex = 5;
        // 
        // button_SettingsForm_ChangeDonwloadedFilesFolder
        // 
        this.button_SettingsForm_ChangeDonwloadedFilesFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_SettingsForm_ChangeDonwloadedFilesFolder.Location = new System.Drawing.Point(120, 32);
        this.button_SettingsForm_ChangeDonwloadedFilesFolder.Name = "button_SettingsForm_ChangeDonwloadedFilesFolder";
        this.button_SettingsForm_ChangeDonwloadedFilesFolder.Size = new System.Drawing.Size(96, 23);
        this.button_SettingsForm_ChangeDonwloadedFilesFolder.TabIndex = 2;
        this.button_SettingsForm_ChangeDonwloadedFilesFolder.Text = "Change";
        this.button_SettingsForm_ChangeDonwloadedFilesFolder.Click += new System.EventHandler(this.button_SettingsForm_FilesSaveTo_Click);
        // 
        // button_SettingsForm_OpenDonwloadedFilesFolder
        // 
        this.button_SettingsForm_OpenDonwloadedFilesFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_SettingsForm_OpenDonwloadedFilesFolder.Location = new System.Drawing.Point(16, 32);
        this.button_SettingsForm_OpenDonwloadedFilesFolder.Name = "button_SettingsForm_OpenDonwloadedFilesFolder";
        this.button_SettingsForm_OpenDonwloadedFilesFolder.Size = new System.Drawing.Size(96, 23);
        this.button_SettingsForm_OpenDonwloadedFilesFolder.TabIndex = 0;
        this.button_SettingsForm_OpenDonwloadedFilesFolder.Text = "Open";
        this.button_SettingsForm_OpenDonwloadedFilesFolder.Click += new System.EventHandler(this.button_SettingsForm_ViewDonwloadedFiles_Click);
        // 
        // button_SettingsForm_ChangeDownloadedScreenShotsFolder
        // 
        this.button_SettingsForm_ChangeDownloadedScreenShotsFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_SettingsForm_ChangeDownloadedScreenShotsFolder.Location = new System.Drawing.Point(120, 32);
        this.button_SettingsForm_ChangeDownloadedScreenShotsFolder.Name = "button_SettingsForm_ChangeDownloadedScreenShotsFolder";
        this.button_SettingsForm_ChangeDownloadedScreenShotsFolder.Size = new System.Drawing.Size(96, 23);
        this.button_SettingsForm_ChangeDownloadedScreenShotsFolder.TabIndex = 3;
        this.button_SettingsForm_ChangeDownloadedScreenShotsFolder.Text = "Change";
        this.button_SettingsForm_ChangeDownloadedScreenShotsFolder.Click += new System.EventHandler(this.button_SettingsForm_ImagesSaveTo_Click);
        // 
        // button_SettingsForm_OpenDownloadedScreenShotsFolder
        // 
        this.button_SettingsForm_OpenDownloadedScreenShotsFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_SettingsForm_OpenDownloadedScreenShotsFolder.Location = new System.Drawing.Point(16, 32);
        this.button_SettingsForm_OpenDownloadedScreenShotsFolder.Name = "button_SettingsForm_OpenDownloadedScreenShotsFolder";
        this.button_SettingsForm_OpenDownloadedScreenShotsFolder.Size = new System.Drawing.Size(96, 23);
        this.button_SettingsForm_OpenDownloadedScreenShotsFolder.TabIndex = 1;
        this.button_SettingsForm_OpenDownloadedScreenShotsFolder.Text = "Open";
        this.button_SettingsForm_OpenDownloadedScreenShotsFolder.Click += new System.EventHandler(this.button_SettingsForm_CapturedImages_Click);
        // 
        // checkBox_SettingsForm_EncryptReceivedSystemData
        // 
        this.checkBox_SettingsForm_EncryptReceivedSystemData.Checked = true;
        this.checkBox_SettingsForm_EncryptReceivedSystemData.CheckState = System.Windows.Forms.CheckState.Checked;
        this.checkBox_SettingsForm_EncryptReceivedSystemData.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_SettingsForm_EncryptReceivedSystemData.Location = new System.Drawing.Point(8, 24);
        this.checkBox_SettingsForm_EncryptReceivedSystemData.Name = "checkBox_SettingsForm_EncryptReceivedSystemData";
        this.checkBox_SettingsForm_EncryptReceivedSystemData.Size = new System.Drawing.Size(264, 16);
        this.checkBox_SettingsForm_EncryptReceivedSystemData.TabIndex = 4;
        this.checkBox_SettingsForm_EncryptReceivedSystemData.Text = "To Encrypt received system data";
        this.checkBox_SettingsForm_EncryptReceivedSystemData.CheckedChanged += new System.EventHandler(this.checkBox_SettingsForm_EncryptReceivedSystemData_CheckedChanged);
        // 
        // checkBox_SettingsForm_EncryptSendingSystemData
        // 
        this.checkBox_SettingsForm_EncryptSendingSystemData.Checked = true;
        this.checkBox_SettingsForm_EncryptSendingSystemData.CheckState = System.Windows.Forms.CheckState.Checked;
        this.checkBox_SettingsForm_EncryptSendingSystemData.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_SettingsForm_EncryptSendingSystemData.Location = new System.Drawing.Point(8, 24);
        this.checkBox_SettingsForm_EncryptSendingSystemData.Name = "checkBox_SettingsForm_EncryptSendingSystemData";
        this.checkBox_SettingsForm_EncryptSendingSystemData.Size = new System.Drawing.Size(264, 16);
        this.checkBox_SettingsForm_EncryptSendingSystemData.TabIndex = 3;
        this.checkBox_SettingsForm_EncryptSendingSystemData.Text = "To Encrypt sent system data";
        this.checkBox_SettingsForm_EncryptSendingSystemData.CheckedChanged += new System.EventHandler(this.checkBox_SettingsForm_EncryptSendingSystemData_CheckedChanged);
        // 
        // checkBox_SettingsForm_EncryptSentFiles
        // 
        this.checkBox_SettingsForm_EncryptSentFiles.Checked = true;
        this.checkBox_SettingsForm_EncryptSentFiles.CheckState = System.Windows.Forms.CheckState.Checked;
        this.checkBox_SettingsForm_EncryptSentFiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_SettingsForm_EncryptSentFiles.Location = new System.Drawing.Point(8, 24);
        this.checkBox_SettingsForm_EncryptSentFiles.Name = "checkBox_SettingsForm_EncryptSentFiles";
        this.checkBox_SettingsForm_EncryptSentFiles.Size = new System.Drawing.Size(264, 16);
        this.checkBox_SettingsForm_EncryptSentFiles.TabIndex = 2;
        this.checkBox_SettingsForm_EncryptSentFiles.Text = "To Encrypt sent files";
        this.checkBox_SettingsForm_EncryptSentFiles.CheckedChanged += new System.EventHandler(this.checkBox_SettingsForm_EncryptSentFiles_CheckedChanged);
        // 
        // checkBox_SettingsForm_EncryptReceivedScreenshots
        // 
        this.checkBox_SettingsForm_EncryptReceivedScreenshots.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_SettingsForm_EncryptReceivedScreenshots.Location = new System.Drawing.Point(8, 24);
        this.checkBox_SettingsForm_EncryptReceivedScreenshots.Name = "checkBox_SettingsForm_EncryptReceivedScreenshots";
        this.checkBox_SettingsForm_EncryptReceivedScreenshots.Size = new System.Drawing.Size(264, 16);
        this.checkBox_SettingsForm_EncryptReceivedScreenshots.TabIndex = 1;
        this.checkBox_SettingsForm_EncryptReceivedScreenshots.Text = "To Encrypt received screenshots";
        this.checkBox_SettingsForm_EncryptReceivedScreenshots.CheckedChanged += new System.EventHandler(this.checkBox_SettingsForm_EncryptReceivedScreenshots_CheckedChanged);
        // 
        // checkBox_SettingsForm_EncryptDownloadedFiles
        // 
        this.checkBox_SettingsForm_EncryptDownloadedFiles.Checked = true;
        this.checkBox_SettingsForm_EncryptDownloadedFiles.CheckState = System.Windows.Forms.CheckState.Checked;
        this.checkBox_SettingsForm_EncryptDownloadedFiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_SettingsForm_EncryptDownloadedFiles.Location = new System.Drawing.Point(8, 24);
        this.checkBox_SettingsForm_EncryptDownloadedFiles.Name = "checkBox_SettingsForm_EncryptDownloadedFiles";
        this.checkBox_SettingsForm_EncryptDownloadedFiles.Size = new System.Drawing.Size(264, 16);
        this.checkBox_SettingsForm_EncryptDownloadedFiles.TabIndex = 0;
        this.checkBox_SettingsForm_EncryptDownloadedFiles.Text = "To Encrypt downloaded files";
        this.checkBox_SettingsForm_EncryptDownloadedFiles.CheckedChanged += new System.EventHandler(this.checkBox_SettingsForm_EncryptDownloadedFiles_CheckedChanged);
        // 
        // button_SettingsForm_Cancel
        // 
        this.button_SettingsForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_SettingsForm_Cancel.Location = new System.Drawing.Point(416, 400);
        this.button_SettingsForm_Cancel.Name = "button_SettingsForm_Cancel";
        this.button_SettingsForm_Cancel.Size = new System.Drawing.Size(80, 23);
        this.button_SettingsForm_Cancel.TabIndex = 5;
        this.button_SettingsForm_Cancel.Text = "Cancel";
        this.button_SettingsForm_Cancel.Click += new System.EventHandler(this.button_SettingsForm_Cancel_Click);
        // 
        // groupBox_SettingsForm_Language
        // 
        this.groupBox_SettingsForm_Language.Controls.Add(this.label_SettingsForm_CurrentLanguage);
        this.groupBox_SettingsForm_Language.Controls.Add(this.comboBox_SettingsForm_Language);
        this.groupBox_SettingsForm_Language.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_SettingsForm_Language.Location = new System.Drawing.Point(16, 272);
        this.groupBox_SettingsForm_Language.Name = "groupBox_SettingsForm_Language";
        this.groupBox_SettingsForm_Language.Size = new System.Drawing.Size(200, 56);
        this.groupBox_SettingsForm_Language.TabIndex = 6;
        this.groupBox_SettingsForm_Language.TabStop = false;
        // 
        // label_SettingsForm_CurrentLanguage
        // 
        this.label_SettingsForm_CurrentLanguage.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_SettingsForm_CurrentLanguage.Location = new System.Drawing.Point(2, 24);
        this.label_SettingsForm_CurrentLanguage.Name = "label_SettingsForm_CurrentLanguage";
        this.label_SettingsForm_CurrentLanguage.Size = new System.Drawing.Size(95, 16);
        this.label_SettingsForm_CurrentLanguage.TabIndex = 1;
        this.label_SettingsForm_CurrentLanguage.Text = "Current language:";
        this.label_SettingsForm_CurrentLanguage.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // tabControl_SettingsForm_SettingsTabs
        // 
        this.tabControl_SettingsForm_SettingsTabs.Controls.Add(this.tabPage_SettingsForm_Main);
        this.tabControl_SettingsForm_SettingsTabs.Controls.Add(this.tabPage_SettingsForm_LocalSecurity);
        this.tabControl_SettingsForm_SettingsTabs.Controls.Add(this.tabPage_SettingsForm_Encryption);
        this.tabControl_SettingsForm_SettingsTabs.Controls.Add(this.tabPage_SettingsForm_Compression);
        this.tabControl_SettingsForm_SettingsTabs.Location = new System.Drawing.Point(8, 8);
        this.tabControl_SettingsForm_SettingsTabs.Name = "tabControl_SettingsForm_SettingsTabs";
        this.tabControl_SettingsForm_SettingsTabs.SelectedIndex = 0;
        this.tabControl_SettingsForm_SettingsTabs.Size = new System.Drawing.Size(512, 376);
        this.tabControl_SettingsForm_SettingsTabs.TabIndex = 7;
        // 
        // tabPage_SettingsForm_Main
        // 
        this.tabPage_SettingsForm_Main.Controls.Add(this.groupBox_SettingsForm_DownloadedScreenShots);
        this.tabPage_SettingsForm_Main.Controls.Add(this.checkBox_SettingsForm_ShowAdvancedSettings);
        this.tabPage_SettingsForm_Main.Controls.Add(this.checkBox_SettingsForm_ShowToolTips);
        this.tabPage_SettingsForm_Main.Controls.Add(this.groupBox_SettingsForm_Language);
        this.tabPage_SettingsForm_Main.Controls.Add(this.groupBox_SettingsForm_DownloadedFiles);
        this.tabPage_SettingsForm_Main.Location = new System.Drawing.Point(4, 22);
        this.tabPage_SettingsForm_Main.Name = "tabPage_SettingsForm_Main";
        this.tabPage_SettingsForm_Main.Size = new System.Drawing.Size(504, 350);
        this.tabPage_SettingsForm_Main.TabIndex = 0;
        this.tabPage_SettingsForm_Main.Text = "Main";
        // 
        // groupBox_SettingsForm_DownloadedScreenShots
        // 
        this.groupBox_SettingsForm_DownloadedScreenShots.Controls.Add(this.label_SettingsForm_DownloadedScreenShotsPath);
        this.groupBox_SettingsForm_DownloadedScreenShots.Controls.Add(this.textBox_SettingsForm_DownloadedScreenShotsPath);
        this.groupBox_SettingsForm_DownloadedScreenShots.Controls.Add(this.button_SettingsForm_OpenDownloadedScreenShotsFolder);
        this.groupBox_SettingsForm_DownloadedScreenShots.Controls.Add(this.button_SettingsForm_ChangeDownloadedScreenShotsFolder);
        this.groupBox_SettingsForm_DownloadedScreenShots.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_SettingsForm_DownloadedScreenShots.Location = new System.Drawing.Point(16, 144);
        this.groupBox_SettingsForm_DownloadedScreenShots.Name = "groupBox_SettingsForm_DownloadedScreenShots";
        this.groupBox_SettingsForm_DownloadedScreenShots.Size = new System.Drawing.Size(472, 120);
        this.groupBox_SettingsForm_DownloadedScreenShots.TabIndex = 9;
        this.groupBox_SettingsForm_DownloadedScreenShots.TabStop = false;
        this.groupBox_SettingsForm_DownloadedScreenShots.Text = "Downloaded ScreenShots";
        // 
        // label_SettingsForm_DownloadedScreenShotsPath
        // 
        this.label_SettingsForm_DownloadedScreenShotsPath.Location = new System.Drawing.Point(16, 64);
        this.label_SettingsForm_DownloadedScreenShotsPath.Name = "label_SettingsForm_DownloadedScreenShotsPath";
        this.label_SettingsForm_DownloadedScreenShotsPath.Size = new System.Drawing.Size(208, 16);
        this.label_SettingsForm_DownloadedScreenShotsPath.TabIndex = 5;
        this.label_SettingsForm_DownloadedScreenShotsPath.Text = "Path:";
        // 
        // textBox_SettingsForm_DownloadedScreenShotsPath
        // 
        this.textBox_SettingsForm_DownloadedScreenShotsPath.Location = new System.Drawing.Point(16, 80);
        this.textBox_SettingsForm_DownloadedScreenShotsPath.Name = "textBox_SettingsForm_DownloadedScreenShotsPath";
        this.textBox_SettingsForm_DownloadedScreenShotsPath.ReadOnly = true;
        this.textBox_SettingsForm_DownloadedScreenShotsPath.Size = new System.Drawing.Size(440, 20);
        this.textBox_SettingsForm_DownloadedScreenShotsPath.TabIndex = 4;
        // 
        // checkBox_SettingsForm_ShowAdvancedSettings
        // 
        this.checkBox_SettingsForm_ShowAdvancedSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_SettingsForm_ShowAdvancedSettings.Location = new System.Drawing.Point(224, 312);
        this.checkBox_SettingsForm_ShowAdvancedSettings.Name = "checkBox_SettingsForm_ShowAdvancedSettings";
        this.checkBox_SettingsForm_ShowAdvancedSettings.Size = new System.Drawing.Size(272, 15);
        this.checkBox_SettingsForm_ShowAdvancedSettings.TabIndex = 8;
        this.checkBox_SettingsForm_ShowAdvancedSettings.Text = "Show Advanced Settings";
        this.checkBox_SettingsForm_ShowAdvancedSettings.CheckedChanged += new System.EventHandler(this.checkBox_SettingsForm_ShowAdvancedSettings_CheckedChanged);
        // 
        // checkBox_SettingsForm_ShowToolTips
        // 
        this.checkBox_SettingsForm_ShowToolTips.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_SettingsForm_ShowToolTips.Location = new System.Drawing.Point(224, 280);
        this.checkBox_SettingsForm_ShowToolTips.Name = "checkBox_SettingsForm_ShowToolTips";
        this.checkBox_SettingsForm_ShowToolTips.Size = new System.Drawing.Size(200, 15);
        this.checkBox_SettingsForm_ShowToolTips.TabIndex = 7;
        this.checkBox_SettingsForm_ShowToolTips.Text = "Show ToolTips";
        // 
        // tabPage_SettingsForm_LocalSecurity
        // 
        this.tabPage_SettingsForm_LocalSecurity.Controls.Add(this.groupBox_LocalSecurity_SecurityParameters);
        this.tabPage_SettingsForm_LocalSecurity.Controls.Add(this.groupBox_LocalSecurity_UsedPassword);
        this.tabPage_SettingsForm_LocalSecurity.Location = new System.Drawing.Point(4, 22);
        this.tabPage_SettingsForm_LocalSecurity.Name = "tabPage_SettingsForm_LocalSecurity";
        this.tabPage_SettingsForm_LocalSecurity.Size = new System.Drawing.Size(504, 350);
        this.tabPage_SettingsForm_LocalSecurity.TabIndex = 3;
        this.tabPage_SettingsForm_LocalSecurity.Text = "Local Security";
        // 
        // groupBox_LocalSecurity_SecurityParameters
        // 
        this.groupBox_LocalSecurity_SecurityParameters.Controls.Add(this.checkBox_LocalSecurity_CompressSettingsDatabase);
        this.groupBox_LocalSecurity_SecurityParameters.Controls.Add(this.checkBox_LocalSecurity_EncryptSettingsDatabase);
        this.groupBox_LocalSecurity_SecurityParameters.Controls.Add(this.checkBox_LocalSecurity_RememberPasswords);
        this.groupBox_LocalSecurity_SecurityParameters.Controls.Add(this.checkBox_LocalSecurity_RememberLogins);
        this.groupBox_LocalSecurity_SecurityParameters.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_LocalSecurity_SecurityParameters.Location = new System.Drawing.Point(16, 16);
        this.groupBox_LocalSecurity_SecurityParameters.Name = "groupBox_LocalSecurity_SecurityParameters";
        this.groupBox_LocalSecurity_SecurityParameters.Size = new System.Drawing.Size(232, 160);
        this.groupBox_LocalSecurity_SecurityParameters.TabIndex = 6;
        this.groupBox_LocalSecurity_SecurityParameters.TabStop = false;
        this.groupBox_LocalSecurity_SecurityParameters.Text = "Security Parameters";
        // 
        // checkBox_LocalSecurity_CompressSettingsDatabase
        // 
        this.checkBox_LocalSecurity_CompressSettingsDatabase.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_LocalSecurity_CompressSettingsDatabase.Location = new System.Drawing.Point(16, 120);
        this.checkBox_LocalSecurity_CompressSettingsDatabase.Name = "checkBox_LocalSecurity_CompressSettingsDatabase";
        this.checkBox_LocalSecurity_CompressSettingsDatabase.Size = new System.Drawing.Size(208, 24);
        this.checkBox_LocalSecurity_CompressSettingsDatabase.TabIndex = 3;
        this.checkBox_LocalSecurity_CompressSettingsDatabase.Text = "Compress Settings Database";
        // 
        // checkBox_LocalSecurity_EncryptSettingsDatabase
        // 
        this.checkBox_LocalSecurity_EncryptSettingsDatabase.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_LocalSecurity_EncryptSettingsDatabase.Location = new System.Drawing.Point(16, 88);
        this.checkBox_LocalSecurity_EncryptSettingsDatabase.Name = "checkBox_LocalSecurity_EncryptSettingsDatabase";
        this.checkBox_LocalSecurity_EncryptSettingsDatabase.Size = new System.Drawing.Size(208, 24);
        this.checkBox_LocalSecurity_EncryptSettingsDatabase.TabIndex = 2;
        this.checkBox_LocalSecurity_EncryptSettingsDatabase.Text = "Encrypt Settings Database";
        this.checkBox_LocalSecurity_EncryptSettingsDatabase.CheckedChanged += new System.EventHandler(this.checkBox_LocalSecurity_EncryptSettingsDatabase_CheckedChanged);
        // 
        // checkBox_LocalSecurity_RememberPasswords
        // 
        this.checkBox_LocalSecurity_RememberPasswords.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_LocalSecurity_RememberPasswords.Location = new System.Drawing.Point(16, 56);
        this.checkBox_LocalSecurity_RememberPasswords.Name = "checkBox_LocalSecurity_RememberPasswords";
        this.checkBox_LocalSecurity_RememberPasswords.Size = new System.Drawing.Size(208, 24);
        this.checkBox_LocalSecurity_RememberPasswords.TabIndex = 5;
        this.checkBox_LocalSecurity_RememberPasswords.Text = "Remember Passwords";
        // 
        // checkBox_LocalSecurity_RememberLogins
        // 
        this.checkBox_LocalSecurity_RememberLogins.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_LocalSecurity_RememberLogins.Location = new System.Drawing.Point(16, 24);
        this.checkBox_LocalSecurity_RememberLogins.Name = "checkBox_LocalSecurity_RememberLogins";
        this.checkBox_LocalSecurity_RememberLogins.Size = new System.Drawing.Size(208, 24);
        this.checkBox_LocalSecurity_RememberLogins.TabIndex = 4;
        this.checkBox_LocalSecurity_RememberLogins.Text = "Remember Logins";
        // 
        // groupBox_LocalSecurity_UsedPassword
        // 
        this.groupBox_LocalSecurity_UsedPassword.Controls.Add(this.button_LocalSecurity_SetPassword);
        this.groupBox_LocalSecurity_UsedPassword.Controls.Add(this.button_LocalSecurity_NewPassword);
        this.groupBox_LocalSecurity_UsedPassword.Controls.Add(this.label_LocalSecurity_NewPassword);
        this.groupBox_LocalSecurity_UsedPassword.Controls.Add(this.textBox_LocalSecurity_ConfirmedPassword);
        this.groupBox_LocalSecurity_UsedPassword.Controls.Add(this.textBox_LocalSecurity_NewPassword);
        this.groupBox_LocalSecurity_UsedPassword.Controls.Add(this.label_LocalSecurity_ConfirmedPassword);
        this.groupBox_LocalSecurity_UsedPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_LocalSecurity_UsedPassword.Location = new System.Drawing.Point(264, 16);
        this.groupBox_LocalSecurity_UsedPassword.Name = "groupBox_LocalSecurity_UsedPassword";
        this.groupBox_LocalSecurity_UsedPassword.Size = new System.Drawing.Size(224, 160);
        this.groupBox_LocalSecurity_UsedPassword.TabIndex = 0;
        this.groupBox_LocalSecurity_UsedPassword.TabStop = false;
        this.groupBox_LocalSecurity_UsedPassword.Text = "Password";
        // 
        // button_LocalSecurity_SetPassword
        // 
        this.button_LocalSecurity_SetPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_LocalSecurity_SetPassword.Location = new System.Drawing.Point(120, 120);
        this.button_LocalSecurity_SetPassword.Name = "button_LocalSecurity_SetPassword";
        this.button_LocalSecurity_SetPassword.Size = new System.Drawing.Size(88, 23);
        this.button_LocalSecurity_SetPassword.TabIndex = 6;
        this.button_LocalSecurity_SetPassword.Text = "Set";
        this.button_LocalSecurity_SetPassword.Click += new System.EventHandler(this.button_LocalSecurity_SetPassword_Click);
        // 
        // button_LocalSecurity_NewPassword
        // 
        this.button_LocalSecurity_NewPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_LocalSecurity_NewPassword.Location = new System.Drawing.Point(16, 120);
        this.button_LocalSecurity_NewPassword.Name = "button_LocalSecurity_NewPassword";
        this.button_LocalSecurity_NewPassword.Size = new System.Drawing.Size(88, 23);
        this.button_LocalSecurity_NewPassword.TabIndex = 5;
        this.button_LocalSecurity_NewPassword.Text = "New";
        this.button_LocalSecurity_NewPassword.Click += new System.EventHandler(this.button_LocalSecurity_NewPassword_Click);
        // 
        // label_LocalSecurity_NewPassword
        // 
        this.label_LocalSecurity_NewPassword.Location = new System.Drawing.Point(16, 24);
        this.label_LocalSecurity_NewPassword.Name = "label_LocalSecurity_NewPassword";
        this.label_LocalSecurity_NewPassword.Size = new System.Drawing.Size(192, 16);
        this.label_LocalSecurity_NewPassword.TabIndex = 3;
        this.label_LocalSecurity_NewPassword.Text = "New Password:";
        // 
        // textBox_LocalSecurity_ConfirmedPassword
        // 
        this.textBox_LocalSecurity_ConfirmedPassword.Location = new System.Drawing.Point(16, 88);
        this.textBox_LocalSecurity_ConfirmedPassword.MaxLength = 64;
        this.textBox_LocalSecurity_ConfirmedPassword.Name = "textBox_LocalSecurity_ConfirmedPassword";
        this.textBox_LocalSecurity_ConfirmedPassword.PasswordChar = '*';
        this.textBox_LocalSecurity_ConfirmedPassword.Size = new System.Drawing.Size(192, 20);
        this.textBox_LocalSecurity_ConfirmedPassword.TabIndex = 2;
        // 
        // textBox_LocalSecurity_NewPassword
        // 
        this.textBox_LocalSecurity_NewPassword.Location = new System.Drawing.Point(16, 40);
        this.textBox_LocalSecurity_NewPassword.MaxLength = 64;
        this.textBox_LocalSecurity_NewPassword.Name = "textBox_LocalSecurity_NewPassword";
        this.textBox_LocalSecurity_NewPassword.PasswordChar = '*';
        this.textBox_LocalSecurity_NewPassword.Size = new System.Drawing.Size(192, 20);
        this.textBox_LocalSecurity_NewPassword.TabIndex = 1;
        // 
        // label_LocalSecurity_ConfirmedPassword
        // 
        this.label_LocalSecurity_ConfirmedPassword.Location = new System.Drawing.Point(16, 72);
        this.label_LocalSecurity_ConfirmedPassword.Name = "label_LocalSecurity_ConfirmedPassword";
        this.label_LocalSecurity_ConfirmedPassword.Size = new System.Drawing.Size(192, 16);
        this.label_LocalSecurity_ConfirmedPassword.TabIndex = 4;
        this.label_LocalSecurity_ConfirmedPassword.Text = "Retyped Password:";
        // 
        // tabPage_SettingsForm_Encryption
        // 
        this.tabPage_SettingsForm_Encryption.Controls.Add(this.groupBox_SettingsForm_EncryptSendingSystemData);
        this.tabPage_SettingsForm_Encryption.Controls.Add(this.groupBox_SettingsForm_EncryptReceivedSystemData);
        this.tabPage_SettingsForm_Encryption.Controls.Add(this.groupBox_SettingsForm_EncryptReceivedScreenshots);
        this.tabPage_SettingsForm_Encryption.Controls.Add(this.groupBox_SettingsForm_EncryptDownloadedFiles);
        this.tabPage_SettingsForm_Encryption.Controls.Add(this.groupBox_SettingsForm_EncryptSentFiles);
        this.tabPage_SettingsForm_Encryption.Location = new System.Drawing.Point(4, 22);
        this.tabPage_SettingsForm_Encryption.Name = "tabPage_SettingsForm_Encryption";
        this.tabPage_SettingsForm_Encryption.Size = new System.Drawing.Size(504, 350);
        this.tabPage_SettingsForm_Encryption.TabIndex = 1;
        this.tabPage_SettingsForm_Encryption.Text = "Encryption";
        // 
        // groupBox_SettingsForm_EncryptSendingSystemData
        // 
        this.groupBox_SettingsForm_EncryptSendingSystemData.Controls.Add(this.comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm);
        this.groupBox_SettingsForm_EncryptSendingSystemData.Controls.Add(this.label_SettingsForm_EncryptSendingSystemDataAlgorithm);
        this.groupBox_SettingsForm_EncryptSendingSystemData.Controls.Add(this.checkBox_SettingsForm_EncryptSendingSystemData);
        this.groupBox_SettingsForm_EncryptSendingSystemData.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_SettingsForm_EncryptSendingSystemData.Location = new System.Drawing.Point(8, 208);
        this.groupBox_SettingsForm_EncryptSendingSystemData.Name = "groupBox_SettingsForm_EncryptSendingSystemData";
        this.groupBox_SettingsForm_EncryptSendingSystemData.Size = new System.Drawing.Size(488, 56);
        this.groupBox_SettingsForm_EncryptSendingSystemData.TabIndex = 7;
        this.groupBox_SettingsForm_EncryptSendingSystemData.TabStop = false;
        // 
        // comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm
        // 
        this.comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm.Items.AddRange(new object[] {
            "AES 128 bit",
            "AES 256 bit",
            "DES 64 bit",
            "RC2 40 bit",
            "RC2 128 bit",
            "TripleDES 128 bit",
            "TripleDES 192 bit"});
        this.comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm.Location = new System.Drawing.Point(344, 24);
        this.comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm.Name = "comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm";
        this.comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm.Size = new System.Drawing.Size(136, 21);
        this.comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm.TabIndex = 6;
        // 
        // label_SettingsForm_EncryptSendingSystemDataAlgorithm
        // 
        this.label_SettingsForm_EncryptSendingSystemDataAlgorithm.Location = new System.Drawing.Point(278, 24);
        this.label_SettingsForm_EncryptSendingSystemDataAlgorithm.Name = "label_SettingsForm_EncryptSendingSystemDataAlgorithm";
        this.label_SettingsForm_EncryptSendingSystemDataAlgorithm.Size = new System.Drawing.Size(64, 16);
        this.label_SettingsForm_EncryptSendingSystemDataAlgorithm.TabIndex = 4;
        this.label_SettingsForm_EncryptSendingSystemDataAlgorithm.Text = "Algorithm:";
        this.label_SettingsForm_EncryptSendingSystemDataAlgorithm.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // groupBox_SettingsForm_EncryptReceivedSystemData
        // 
        this.groupBox_SettingsForm_EncryptReceivedSystemData.Controls.Add(this.comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm);
        this.groupBox_SettingsForm_EncryptReceivedSystemData.Controls.Add(this.label_SettingsForm_EncryptReceivedSystemDataAlgorithm);
        this.groupBox_SettingsForm_EncryptReceivedSystemData.Controls.Add(this.checkBox_SettingsForm_EncryptReceivedSystemData);
        this.groupBox_SettingsForm_EncryptReceivedSystemData.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_SettingsForm_EncryptReceivedSystemData.Location = new System.Drawing.Point(8, 272);
        this.groupBox_SettingsForm_EncryptReceivedSystemData.Name = "groupBox_SettingsForm_EncryptReceivedSystemData";
        this.groupBox_SettingsForm_EncryptReceivedSystemData.Size = new System.Drawing.Size(488, 56);
        this.groupBox_SettingsForm_EncryptReceivedSystemData.TabIndex = 6;
        this.groupBox_SettingsForm_EncryptReceivedSystemData.TabStop = false;
        // 
        // comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm
        // 
        this.comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm.Items.AddRange(new object[] {
            "AES 128 bit",
            "AES 256 bit",
            "DES 64 bit",
            "RC2 40 bit",
            "RC2 128 bit",
            "TripleDES 128 bit",
            "TripleDES 192 bit"});
        this.comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm.Location = new System.Drawing.Point(344, 24);
        this.comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm.Name = "comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm";
        this.comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm.Size = new System.Drawing.Size(136, 21);
        this.comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm.TabIndex = 6;
        // 
        // label_SettingsForm_EncryptReceivedSystemDataAlgorithm
        // 
        this.label_SettingsForm_EncryptReceivedSystemDataAlgorithm.Location = new System.Drawing.Point(278, 24);
        this.label_SettingsForm_EncryptReceivedSystemDataAlgorithm.Name = "label_SettingsForm_EncryptReceivedSystemDataAlgorithm";
        this.label_SettingsForm_EncryptReceivedSystemDataAlgorithm.Size = new System.Drawing.Size(64, 16);
        this.label_SettingsForm_EncryptReceivedSystemDataAlgorithm.TabIndex = 5;
        this.label_SettingsForm_EncryptReceivedSystemDataAlgorithm.Text = "Algorithm:";
        this.label_SettingsForm_EncryptReceivedSystemDataAlgorithm.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // groupBox_SettingsForm_EncryptReceivedScreenshots
        // 
        this.groupBox_SettingsForm_EncryptReceivedScreenshots.Controls.Add(this.comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm);
        this.groupBox_SettingsForm_EncryptReceivedScreenshots.Controls.Add(this.label_SettingsForm_EncryptReceivedScreenshotsAlgorithm);
        this.groupBox_SettingsForm_EncryptReceivedScreenshots.Controls.Add(this.checkBox_SettingsForm_EncryptReceivedScreenshots);
        this.groupBox_SettingsForm_EncryptReceivedScreenshots.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_SettingsForm_EncryptReceivedScreenshots.Location = new System.Drawing.Point(8, 144);
        this.groupBox_SettingsForm_EncryptReceivedScreenshots.Name = "groupBox_SettingsForm_EncryptReceivedScreenshots";
        this.groupBox_SettingsForm_EncryptReceivedScreenshots.Size = new System.Drawing.Size(488, 56);
        this.groupBox_SettingsForm_EncryptReceivedScreenshots.TabIndex = 5;
        this.groupBox_SettingsForm_EncryptReceivedScreenshots.TabStop = false;
        // 
        // comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm
        // 
        this.comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm.Items.AddRange(new object[] {
            "AES 128 bit",
            "AES 256 bit",
            "DES 64 bit",
            "RC2 40 bit",
            "RC2 128 bit",
            "TripleDES 128 bit",
            "TripleDES 192 bit"});
        this.comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm.Location = new System.Drawing.Point(344, 24);
        this.comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm.Name = "comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm";
        this.comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm.Size = new System.Drawing.Size(136, 21);
        this.comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm.TabIndex = 6;
        // 
        // label_SettingsForm_EncryptReceivedScreenshotsAlgorithm
        // 
        this.label_SettingsForm_EncryptReceivedScreenshotsAlgorithm.Location = new System.Drawing.Point(278, 24);
        this.label_SettingsForm_EncryptReceivedScreenshotsAlgorithm.Name = "label_SettingsForm_EncryptReceivedScreenshotsAlgorithm";
        this.label_SettingsForm_EncryptReceivedScreenshotsAlgorithm.Size = new System.Drawing.Size(64, 16);
        this.label_SettingsForm_EncryptReceivedScreenshotsAlgorithm.TabIndex = 4;
        this.label_SettingsForm_EncryptReceivedScreenshotsAlgorithm.Text = "Algorithm:";
        this.label_SettingsForm_EncryptReceivedScreenshotsAlgorithm.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // groupBox_SettingsForm_EncryptDownloadedFiles
        // 
        this.groupBox_SettingsForm_EncryptDownloadedFiles.Controls.Add(this.comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm);
        this.groupBox_SettingsForm_EncryptDownloadedFiles.Controls.Add(this.label_SettingsForm_EncryptDownloadedFilesAlgorithm);
        this.groupBox_SettingsForm_EncryptDownloadedFiles.Controls.Add(this.checkBox_SettingsForm_EncryptDownloadedFiles);
        this.groupBox_SettingsForm_EncryptDownloadedFiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_SettingsForm_EncryptDownloadedFiles.Location = new System.Drawing.Point(8, 80);
        this.groupBox_SettingsForm_EncryptDownloadedFiles.Name = "groupBox_SettingsForm_EncryptDownloadedFiles";
        this.groupBox_SettingsForm_EncryptDownloadedFiles.Size = new System.Drawing.Size(488, 56);
        this.groupBox_SettingsForm_EncryptDownloadedFiles.TabIndex = 6;
        this.groupBox_SettingsForm_EncryptDownloadedFiles.TabStop = false;
        // 
        // comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm
        // 
        this.comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm.Items.AddRange(new object[] {
            "AES 128 bit",
            "AES 256 bit",
            "DES 64 bit",
            "RC2 40 bit",
            "RC2 128 bit",
            "TripleDES 128 bit",
            "TripleDES 192 bit"});
        this.comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm.Location = new System.Drawing.Point(344, 24);
        this.comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm.Name = "comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm";
        this.comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm.Size = new System.Drawing.Size(136, 21);
        this.comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm.TabIndex = 5;
        // 
        // label_SettingsForm_EncryptDownloadedFilesAlgorithm
        // 
        this.label_SettingsForm_EncryptDownloadedFilesAlgorithm.Location = new System.Drawing.Point(278, 24);
        this.label_SettingsForm_EncryptDownloadedFilesAlgorithm.Name = "label_SettingsForm_EncryptDownloadedFilesAlgorithm";
        this.label_SettingsForm_EncryptDownloadedFilesAlgorithm.Size = new System.Drawing.Size(64, 16);
        this.label_SettingsForm_EncryptDownloadedFilesAlgorithm.TabIndex = 4;
        this.label_SettingsForm_EncryptDownloadedFilesAlgorithm.Text = "Algorithm:";
        this.label_SettingsForm_EncryptDownloadedFilesAlgorithm.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // groupBox_SettingsForm_EncryptSentFiles
        // 
        this.groupBox_SettingsForm_EncryptSentFiles.Controls.Add(this.comboBox_SettingsForm_EncryptSentFilesAlgorithm);
        this.groupBox_SettingsForm_EncryptSentFiles.Controls.Add(this.label_SettingsForm_EncryptSentFilesAlgorithm);
        this.groupBox_SettingsForm_EncryptSentFiles.Controls.Add(this.checkBox_SettingsForm_EncryptSentFiles);
        this.groupBox_SettingsForm_EncryptSentFiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_SettingsForm_EncryptSentFiles.Location = new System.Drawing.Point(8, 16);
        this.groupBox_SettingsForm_EncryptSentFiles.Name = "groupBox_SettingsForm_EncryptSentFiles";
        this.groupBox_SettingsForm_EncryptSentFiles.Size = new System.Drawing.Size(488, 56);
        this.groupBox_SettingsForm_EncryptSentFiles.TabIndex = 6;
        this.groupBox_SettingsForm_EncryptSentFiles.TabStop = false;
        // 
        // comboBox_SettingsForm_EncryptSentFilesAlgorithm
        // 
        this.comboBox_SettingsForm_EncryptSentFilesAlgorithm.Items.AddRange(new object[] {
            "AES 128 bit",
            "AES 256 bit",
            "DES 64 bit",
            "RC2 40 bit",
            "RC2 128 bit",
            "TripleDES 128 bit",
            "TripleDES 192 bit"});
        this.comboBox_SettingsForm_EncryptSentFilesAlgorithm.Location = new System.Drawing.Point(344, 24);
        this.comboBox_SettingsForm_EncryptSentFilesAlgorithm.Name = "comboBox_SettingsForm_EncryptSentFilesAlgorithm";
        this.comboBox_SettingsForm_EncryptSentFilesAlgorithm.Size = new System.Drawing.Size(136, 21);
        this.comboBox_SettingsForm_EncryptSentFilesAlgorithm.TabIndex = 4;
        // 
        // label_SettingsForm_EncryptSentFilesAlgorithm
        // 
        this.label_SettingsForm_EncryptSentFilesAlgorithm.Location = new System.Drawing.Point(278, 24);
        this.label_SettingsForm_EncryptSentFilesAlgorithm.Name = "label_SettingsForm_EncryptSentFilesAlgorithm";
        this.label_SettingsForm_EncryptSentFilesAlgorithm.Size = new System.Drawing.Size(64, 16);
        this.label_SettingsForm_EncryptSentFilesAlgorithm.TabIndex = 3;
        this.label_SettingsForm_EncryptSentFilesAlgorithm.Text = "Algorithm:";
        this.label_SettingsForm_EncryptSentFilesAlgorithm.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // tabPage_SettingsForm_Compression
        // 
        this.tabPage_SettingsForm_Compression.Controls.Add(this.groupBox_SettingsForm_CompressSendingSystemData);
        this.tabPage_SettingsForm_Compression.Controls.Add(this.groupBox_SettingsForm_CompressReceivedSystemData);
        this.tabPage_SettingsForm_Compression.Controls.Add(this.groupBox_SettingsForm_CompressReceivedScreenshots);
        this.tabPage_SettingsForm_Compression.Controls.Add(this.groupBox_SettingsForm_CompressDownloadedFiles);
        this.tabPage_SettingsForm_Compression.Controls.Add(this.groupBox_SettingsForm_CompressSentFiles);
        this.tabPage_SettingsForm_Compression.Location = new System.Drawing.Point(4, 22);
        this.tabPage_SettingsForm_Compression.Name = "tabPage_SettingsForm_Compression";
        this.tabPage_SettingsForm_Compression.Size = new System.Drawing.Size(504, 350);
        this.tabPage_SettingsForm_Compression.TabIndex = 2;
        this.tabPage_SettingsForm_Compression.Text = "Compression";
        // 
        // groupBox_SettingsForm_CompressSendingSystemData
        // 
        this.groupBox_SettingsForm_CompressSendingSystemData.Controls.Add(this.comboBox_SettingsForm_CompressSendingSystemDataAlgorithm);
        this.groupBox_SettingsForm_CompressSendingSystemData.Controls.Add(this.label_SettingsForm_CompressSendingSystemDataAlgorithm);
        this.groupBox_SettingsForm_CompressSendingSystemData.Controls.Add(this.checkBox_SettingsForm_CompressSendingSystemData);
        this.groupBox_SettingsForm_CompressSendingSystemData.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_SettingsForm_CompressSendingSystemData.Location = new System.Drawing.Point(8, 208);
        this.groupBox_SettingsForm_CompressSendingSystemData.Name = "groupBox_SettingsForm_CompressSendingSystemData";
        this.groupBox_SettingsForm_CompressSendingSystemData.Size = new System.Drawing.Size(488, 56);
        this.groupBox_SettingsForm_CompressSendingSystemData.TabIndex = 14;
        this.groupBox_SettingsForm_CompressSendingSystemData.TabStop = false;
        this.groupBox_SettingsForm_CompressSendingSystemData.Visible = false;
        // 
        // comboBox_SettingsForm_CompressSendingSystemDataAlgorithm
        // 
        this.comboBox_SettingsForm_CompressSendingSystemDataAlgorithm.ItemHeight = 13;
        this.comboBox_SettingsForm_CompressSendingSystemDataAlgorithm.Items.AddRange(new object[] {
            "Adaptive Prefix Codes",
            "Non-Adaptive Prefix Codes",
            "LZSS",
            "Deflate"});
        this.comboBox_SettingsForm_CompressSendingSystemDataAlgorithm.Location = new System.Drawing.Point(344, 24);
        this.comboBox_SettingsForm_CompressSendingSystemDataAlgorithm.Name = "comboBox_SettingsForm_CompressSendingSystemDataAlgorithm";
        this.comboBox_SettingsForm_CompressSendingSystemDataAlgorithm.Size = new System.Drawing.Size(136, 21);
        this.comboBox_SettingsForm_CompressSendingSystemDataAlgorithm.TabIndex = 6;
        // 
        // label_SettingsForm_CompressSendingSystemDataAlgorithm
        // 
        this.label_SettingsForm_CompressSendingSystemDataAlgorithm.Location = new System.Drawing.Point(278, 24);
        this.label_SettingsForm_CompressSendingSystemDataAlgorithm.Name = "label_SettingsForm_CompressSendingSystemDataAlgorithm";
        this.label_SettingsForm_CompressSendingSystemDataAlgorithm.Size = new System.Drawing.Size(64, 16);
        this.label_SettingsForm_CompressSendingSystemDataAlgorithm.TabIndex = 4;
        this.label_SettingsForm_CompressSendingSystemDataAlgorithm.Text = "Algorithm:";
        this.label_SettingsForm_CompressSendingSystemDataAlgorithm.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // checkBox_SettingsForm_CompressSendingSystemData
        // 
        this.checkBox_SettingsForm_CompressSendingSystemData.Checked = true;
        this.checkBox_SettingsForm_CompressSendingSystemData.CheckState = System.Windows.Forms.CheckState.Checked;
        this.checkBox_SettingsForm_CompressSendingSystemData.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_SettingsForm_CompressSendingSystemData.Location = new System.Drawing.Point(8, 24);
        this.checkBox_SettingsForm_CompressSendingSystemData.Name = "checkBox_SettingsForm_CompressSendingSystemData";
        this.checkBox_SettingsForm_CompressSendingSystemData.Size = new System.Drawing.Size(264, 16);
        this.checkBox_SettingsForm_CompressSendingSystemData.TabIndex = 8;
        this.checkBox_SettingsForm_CompressSendingSystemData.Text = "To Compress sent system data";
        this.checkBox_SettingsForm_CompressSendingSystemData.CheckedChanged += new System.EventHandler(this.checkBox_SettingsForm_CompressSendingSystemData_CheckedChanged);
        // 
        // groupBox_SettingsForm_CompressReceivedSystemData
        // 
        this.groupBox_SettingsForm_CompressReceivedSystemData.Controls.Add(this.comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm);
        this.groupBox_SettingsForm_CompressReceivedSystemData.Controls.Add(this.label_SettingsForm_CompressReceivedSystemDataAlgorithm);
        this.groupBox_SettingsForm_CompressReceivedSystemData.Controls.Add(this.checkBox_SettingsForm_CompressReceivedSystemData);
        this.groupBox_SettingsForm_CompressReceivedSystemData.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_SettingsForm_CompressReceivedSystemData.Location = new System.Drawing.Point(8, 144);
        this.groupBox_SettingsForm_CompressReceivedSystemData.Name = "groupBox_SettingsForm_CompressReceivedSystemData";
        this.groupBox_SettingsForm_CompressReceivedSystemData.Size = new System.Drawing.Size(488, 56);
        this.groupBox_SettingsForm_CompressReceivedSystemData.TabIndex = 13;
        this.groupBox_SettingsForm_CompressReceivedSystemData.TabStop = false;
        // 
        // comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm
        // 
        this.comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm.Items.AddRange(new object[] {
            "Adaptive Prefix Codes",
            "Non-Adaptive Prefix Codes",
            "LZSS",
            "Deflate"});
        this.comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm.Location = new System.Drawing.Point(344, 24);
        this.comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm.Name = "comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm";
        this.comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm.Size = new System.Drawing.Size(136, 21);
        this.comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm.TabIndex = 6;
        // 
        // label_SettingsForm_CompressReceivedSystemDataAlgorithm
        // 
        this.label_SettingsForm_CompressReceivedSystemDataAlgorithm.Location = new System.Drawing.Point(278, 24);
        this.label_SettingsForm_CompressReceivedSystemDataAlgorithm.Name = "label_SettingsForm_CompressReceivedSystemDataAlgorithm";
        this.label_SettingsForm_CompressReceivedSystemDataAlgorithm.Size = new System.Drawing.Size(64, 16);
        this.label_SettingsForm_CompressReceivedSystemDataAlgorithm.TabIndex = 5;
        this.label_SettingsForm_CompressReceivedSystemDataAlgorithm.Text = "Algorithm:";
        this.label_SettingsForm_CompressReceivedSystemDataAlgorithm.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // checkBox_SettingsForm_CompressReceivedSystemData
        // 
        this.checkBox_SettingsForm_CompressReceivedSystemData.Checked = true;
        this.checkBox_SettingsForm_CompressReceivedSystemData.CheckState = System.Windows.Forms.CheckState.Checked;
        this.checkBox_SettingsForm_CompressReceivedSystemData.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_SettingsForm_CompressReceivedSystemData.Location = new System.Drawing.Point(8, 24);
        this.checkBox_SettingsForm_CompressReceivedSystemData.Name = "checkBox_SettingsForm_CompressReceivedSystemData";
        this.checkBox_SettingsForm_CompressReceivedSystemData.Size = new System.Drawing.Size(264, 16);
        this.checkBox_SettingsForm_CompressReceivedSystemData.TabIndex = 9;
        this.checkBox_SettingsForm_CompressReceivedSystemData.Text = "To Compress received system data";
        this.checkBox_SettingsForm_CompressReceivedSystemData.CheckedChanged += new System.EventHandler(this.checkBox_SettingsForm_CompressReceivedSystemData_CheckedChanged);
        // 
        // groupBox_SettingsForm_CompressReceivedScreenshots
        // 
        this.groupBox_SettingsForm_CompressReceivedScreenshots.Controls.Add(this.comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm);
        this.groupBox_SettingsForm_CompressReceivedScreenshots.Controls.Add(this.label_SettingsForm_CompressReceivedScreenshotsAlgorithm);
        this.groupBox_SettingsForm_CompressReceivedScreenshots.Controls.Add(this.checkBox_SettingsForm_CompressReceivedScreenshots);
        this.groupBox_SettingsForm_CompressReceivedScreenshots.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_SettingsForm_CompressReceivedScreenshots.Location = new System.Drawing.Point(8, 272);
        this.groupBox_SettingsForm_CompressReceivedScreenshots.Name = "groupBox_SettingsForm_CompressReceivedScreenshots";
        this.groupBox_SettingsForm_CompressReceivedScreenshots.Size = new System.Drawing.Size(488, 56);
        this.groupBox_SettingsForm_CompressReceivedScreenshots.TabIndex = 10;
        this.groupBox_SettingsForm_CompressReceivedScreenshots.TabStop = false;
        this.groupBox_SettingsForm_CompressReceivedScreenshots.Visible = false;
        // 
        // comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm
        // 
        this.comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm.ItemHeight = 13;
        this.comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm.Items.AddRange(new object[] {
            "Adaptive Prefix Codes",
            "Non-Adaptive Prefix Codes",
            "LZSS",
            "RLE",
            "Deflate"});
        this.comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm.Location = new System.Drawing.Point(344, 24);
        this.comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm.Name = "comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm";
        this.comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm.Size = new System.Drawing.Size(136, 21);
        this.comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm.TabIndex = 6;
        // 
        // label_SettingsForm_CompressReceivedScreenshotsAlgorithm
        // 
        this.label_SettingsForm_CompressReceivedScreenshotsAlgorithm.Location = new System.Drawing.Point(278, 24);
        this.label_SettingsForm_CompressReceivedScreenshotsAlgorithm.Name = "label_SettingsForm_CompressReceivedScreenshotsAlgorithm";
        this.label_SettingsForm_CompressReceivedScreenshotsAlgorithm.Size = new System.Drawing.Size(64, 16);
        this.label_SettingsForm_CompressReceivedScreenshotsAlgorithm.TabIndex = 4;
        this.label_SettingsForm_CompressReceivedScreenshotsAlgorithm.Text = "Algorithm:";
        this.label_SettingsForm_CompressReceivedScreenshotsAlgorithm.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // checkBox_SettingsForm_CompressReceivedScreenshots
        // 
        this.checkBox_SettingsForm_CompressReceivedScreenshots.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_SettingsForm_CompressReceivedScreenshots.Location = new System.Drawing.Point(8, 24);
        this.checkBox_SettingsForm_CompressReceivedScreenshots.Name = "checkBox_SettingsForm_CompressReceivedScreenshots";
        this.checkBox_SettingsForm_CompressReceivedScreenshots.Size = new System.Drawing.Size(264, 16);
        this.checkBox_SettingsForm_CompressReceivedScreenshots.TabIndex = 6;
        this.checkBox_SettingsForm_CompressReceivedScreenshots.Text = "To Compress received screenshots";
        this.checkBox_SettingsForm_CompressReceivedScreenshots.CheckedChanged += new System.EventHandler(this.checkBox_SettingsForm_CompressReceivedScreenshots_CheckedChanged);
        // 
        // groupBox_SettingsForm_CompressDownloadedFiles
        // 
        this.groupBox_SettingsForm_CompressDownloadedFiles.Controls.Add(this.comboBox_SettingsForm_CompressDownloadedFilesAlgorithm);
        this.groupBox_SettingsForm_CompressDownloadedFiles.Controls.Add(this.label_SettingsForm_CompressDownloadedFilesAlgorithm);
        this.groupBox_SettingsForm_CompressDownloadedFiles.Controls.Add(this.checkBox_SettingsForm_CompressDownloadedFiles);
        this.groupBox_SettingsForm_CompressDownloadedFiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_SettingsForm_CompressDownloadedFiles.Location = new System.Drawing.Point(8, 80);
        this.groupBox_SettingsForm_CompressDownloadedFiles.Name = "groupBox_SettingsForm_CompressDownloadedFiles";
        this.groupBox_SettingsForm_CompressDownloadedFiles.Size = new System.Drawing.Size(488, 56);
        this.groupBox_SettingsForm_CompressDownloadedFiles.TabIndex = 11;
        this.groupBox_SettingsForm_CompressDownloadedFiles.TabStop = false;
        // 
        // comboBox_SettingsForm_CompressDownloadedFilesAlgorithm
        // 
        this.comboBox_SettingsForm_CompressDownloadedFilesAlgorithm.Items.AddRange(new object[] {
            "Adaptive Prefix Codes",
            "Non-Adaptive Prefix Codes",
            "LZSS",
            "Deflate"});
        this.comboBox_SettingsForm_CompressDownloadedFilesAlgorithm.Location = new System.Drawing.Point(344, 24);
        this.comboBox_SettingsForm_CompressDownloadedFilesAlgorithm.Name = "comboBox_SettingsForm_CompressDownloadedFilesAlgorithm";
        this.comboBox_SettingsForm_CompressDownloadedFilesAlgorithm.Size = new System.Drawing.Size(136, 21);
        this.comboBox_SettingsForm_CompressDownloadedFilesAlgorithm.TabIndex = 5;
        // 
        // label_SettingsForm_CompressDownloadedFilesAlgorithm
        // 
        this.label_SettingsForm_CompressDownloadedFilesAlgorithm.Location = new System.Drawing.Point(278, 24);
        this.label_SettingsForm_CompressDownloadedFilesAlgorithm.Name = "label_SettingsForm_CompressDownloadedFilesAlgorithm";
        this.label_SettingsForm_CompressDownloadedFilesAlgorithm.Size = new System.Drawing.Size(64, 16);
        this.label_SettingsForm_CompressDownloadedFilesAlgorithm.TabIndex = 4;
        this.label_SettingsForm_CompressDownloadedFilesAlgorithm.Text = "Algorithm:";
        this.label_SettingsForm_CompressDownloadedFilesAlgorithm.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // checkBox_SettingsForm_CompressDownloadedFiles
        // 
        this.checkBox_SettingsForm_CompressDownloadedFiles.Checked = true;
        this.checkBox_SettingsForm_CompressDownloadedFiles.CheckState = System.Windows.Forms.CheckState.Checked;
        this.checkBox_SettingsForm_CompressDownloadedFiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_SettingsForm_CompressDownloadedFiles.Location = new System.Drawing.Point(8, 24);
        this.checkBox_SettingsForm_CompressDownloadedFiles.Name = "checkBox_SettingsForm_CompressDownloadedFiles";
        this.checkBox_SettingsForm_CompressDownloadedFiles.Size = new System.Drawing.Size(264, 16);
        this.checkBox_SettingsForm_CompressDownloadedFiles.TabIndex = 5;
        this.checkBox_SettingsForm_CompressDownloadedFiles.Text = "To Compress downloaded files";
        this.checkBox_SettingsForm_CompressDownloadedFiles.CheckedChanged += new System.EventHandler(this.checkBox_SettingsForm_CompressDownloadedFiles_CheckedChanged);
        // 
        // groupBox_SettingsForm_CompressSentFiles
        // 
        this.groupBox_SettingsForm_CompressSentFiles.Controls.Add(this.comboBox_SettingsForm_CompressSentFilesAlgorithm);
        this.groupBox_SettingsForm_CompressSentFiles.Controls.Add(this.label_SettingsForm_CompressSentFilesAlgorithm);
        this.groupBox_SettingsForm_CompressSentFiles.Controls.Add(this.checkBox_SettingsForm_CompressSentFiles);
        this.groupBox_SettingsForm_CompressSentFiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_SettingsForm_CompressSentFiles.Location = new System.Drawing.Point(8, 16);
        this.groupBox_SettingsForm_CompressSentFiles.Name = "groupBox_SettingsForm_CompressSentFiles";
        this.groupBox_SettingsForm_CompressSentFiles.Size = new System.Drawing.Size(488, 56);
        this.groupBox_SettingsForm_CompressSentFiles.TabIndex = 12;
        this.groupBox_SettingsForm_CompressSentFiles.TabStop = false;
        // 
        // comboBox_SettingsForm_CompressSentFilesAlgorithm
        // 
        this.comboBox_SettingsForm_CompressSentFilesAlgorithm.Items.AddRange(new object[] {
            "Adaptive Prefix Codes",
            "Non-Adaptive Prefix Codes",
            "LZSS",
            "Deflate"});
        this.comboBox_SettingsForm_CompressSentFilesAlgorithm.Location = new System.Drawing.Point(344, 24);
        this.comboBox_SettingsForm_CompressSentFilesAlgorithm.Name = "comboBox_SettingsForm_CompressSentFilesAlgorithm";
        this.comboBox_SettingsForm_CompressSentFilesAlgorithm.Size = new System.Drawing.Size(136, 21);
        this.comboBox_SettingsForm_CompressSentFilesAlgorithm.TabIndex = 4;
        // 
        // label_SettingsForm_CompressSentFilesAlgorithm
        // 
        this.label_SettingsForm_CompressSentFilesAlgorithm.Location = new System.Drawing.Point(278, 24);
        this.label_SettingsForm_CompressSentFilesAlgorithm.Name = "label_SettingsForm_CompressSentFilesAlgorithm";
        this.label_SettingsForm_CompressSentFilesAlgorithm.Size = new System.Drawing.Size(64, 16);
        this.label_SettingsForm_CompressSentFilesAlgorithm.TabIndex = 3;
        this.label_SettingsForm_CompressSentFilesAlgorithm.Text = "Algorithm:";
        this.label_SettingsForm_CompressSentFilesAlgorithm.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // checkBox_SettingsForm_CompressSentFiles
        // 
        this.checkBox_SettingsForm_CompressSentFiles.Checked = true;
        this.checkBox_SettingsForm_CompressSentFiles.CheckState = System.Windows.Forms.CheckState.Checked;
        this.checkBox_SettingsForm_CompressSentFiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_SettingsForm_CompressSentFiles.Location = new System.Drawing.Point(8, 24);
        this.checkBox_SettingsForm_CompressSentFiles.Name = "checkBox_SettingsForm_CompressSentFiles";
        this.checkBox_SettingsForm_CompressSentFiles.Size = new System.Drawing.Size(264, 16);
        this.checkBox_SettingsForm_CompressSentFiles.TabIndex = 7;
        this.checkBox_SettingsForm_CompressSentFiles.Text = "To Compress sent files";
        this.checkBox_SettingsForm_CompressSentFiles.CheckedChanged += new System.EventHandler(this.checkBox_SettingsForm_CompressSentFiles_CheckedChanged);
        // 
        // button_RestoreToDefaults
        // 
        this.button_RestoreToDefaults.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_RestoreToDefaults.Location = new System.Drawing.Point(40, 400);
        this.button_RestoreToDefaults.Name = "button_RestoreToDefaults";
        this.button_RestoreToDefaults.Size = new System.Drawing.Size(120, 23);
        this.button_RestoreToDefaults.TabIndex = 8;
        this.button_RestoreToDefaults.Text = "Restore to defaults";
        this.button_RestoreToDefaults.Click += new System.EventHandler(this.button_RestoreToDefaults_Click);
        // 
        // SettingsForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.CancelButton = this.button_SettingsForm_OK;
        this.ClientSize = new System.Drawing.Size(530, 440);
        this.Controls.Add(this.button_RestoreToDefaults);
        this.Controls.Add(this.tabControl_SettingsForm_SettingsTabs);
        this.Controls.Add(this.button_SettingsForm_Cancel);
        this.Controls.Add(this.button_SettingsForm_OK);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(536, 472);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(536, 472);
        this.Name = "SettingsForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Settings";
        this.Shown += new System.EventHandler(this.SettingsForm_Shown);
        this.groupBox_SettingsForm_DownloadedFiles.ResumeLayout(false);
        this.groupBox_SettingsForm_DownloadedFiles.PerformLayout();
        this.groupBox_SettingsForm_Language.ResumeLayout(false);
        this.tabControl_SettingsForm_SettingsTabs.ResumeLayout(false);
        this.tabPage_SettingsForm_Main.ResumeLayout(false);
        this.groupBox_SettingsForm_DownloadedScreenShots.ResumeLayout(false);
        this.groupBox_SettingsForm_DownloadedScreenShots.PerformLayout();
        this.tabPage_SettingsForm_LocalSecurity.ResumeLayout(false);
        this.groupBox_LocalSecurity_SecurityParameters.ResumeLayout(false);
        this.groupBox_LocalSecurity_UsedPassword.ResumeLayout(false);
        this.groupBox_LocalSecurity_UsedPassword.PerformLayout();
        this.tabPage_SettingsForm_Encryption.ResumeLayout(false);
        this.groupBox_SettingsForm_EncryptSendingSystemData.ResumeLayout(false);
        this.groupBox_SettingsForm_EncryptReceivedSystemData.ResumeLayout(false);
        this.groupBox_SettingsForm_EncryptReceivedScreenshots.ResumeLayout(false);
        this.groupBox_SettingsForm_EncryptDownloadedFiles.ResumeLayout(false);
        this.groupBox_SettingsForm_EncryptSentFiles.ResumeLayout(false);
        this.tabPage_SettingsForm_Compression.ResumeLayout(false);
        this.groupBox_SettingsForm_CompressSendingSystemData.ResumeLayout(false);
        this.groupBox_SettingsForm_CompressReceivedSystemData.ResumeLayout(false);
        this.groupBox_SettingsForm_CompressReceivedScreenshots.ResumeLayout(false);
        this.groupBox_SettingsForm_CompressDownloadedFiles.ResumeLayout(false);
        this.groupBox_SettingsForm_CompressSentFiles.ResumeLayout(false);
        this.ResumeLayout(false);

    }
    #endregion

    private void button_SettingsForm_Cancel_Click(object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void button_SettingsForm_OK_Click(object sender, System.EventArgs e)
    {
        ClientSettingsEnvironment.ToEncryptSentFiles = this.checkBox_SettingsForm_EncryptSentFiles.Checked;
        ClientSettingsEnvironment.ToEncryptDownloadedFiles = this.checkBox_SettingsForm_EncryptDownloadedFiles.Checked;
        ClientSettingsEnvironment.ToEncryptReceivedScreenshots = this.checkBox_SettingsForm_EncryptReceivedScreenshots.Checked;
        ClientSettingsEnvironment.ToEncryptSentSystemData = this.checkBox_SettingsForm_EncryptSendingSystemData.Checked;
        ClientSettingsEnvironment.ToEncryptReceivedSystemData = this.checkBox_SettingsForm_EncryptReceivedSystemData.Checked;

        ClientSettingsEnvironment.ToCompressSentFiles = this.checkBox_SettingsForm_CompressSentFiles.Checked;
        ClientSettingsEnvironment.ToCompressDownloadedFiles = this.checkBox_SettingsForm_CompressDownloadedFiles.Checked;
        ClientSettingsEnvironment.ToCompressReceivedScreenshots = this.checkBox_SettingsForm_CompressReceivedScreenshots.Checked;
        ClientSettingsEnvironment.ToCompressSentSystemData = this.checkBox_SettingsForm_CompressSendingSystemData.Checked;
        ClientSettingsEnvironment.ToCompressReceivedSystemData = this.checkBox_SettingsForm_CompressReceivedSystemData.Checked;


        ClientSettingsEnvironment.SentFilesEncryptAlgorithmIndex = this.comboBox_SettingsForm_EncryptSentFilesAlgorithm.SelectedIndex;
        ClientSettingsEnvironment.SendingSystemDataEncryptAlgorithmIndex = this.comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm.SelectedIndex;
        ClientSettingsEnvironment.ReceivedSystemDataEncryptAlgorithmIndex = this.comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm.SelectedIndex;
        ClientSettingsEnvironment.ReceivedScreenshotsEncryptAlgorithmIndex = this.comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm.SelectedIndex;
        ClientSettingsEnvironment.DownloadedFilesEncryptAlgorithmIndex = this.comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm.SelectedIndex;

        ClientSettingsEnvironment.SentFilesCompressAlgorithmIndex = this.comboBox_SettingsForm_CompressSentFilesAlgorithm.SelectedIndex;
        ClientSettingsEnvironment.SendingSystemDataCompressAlgorithmIndex = this.comboBox_SettingsForm_CompressSendingSystemDataAlgorithm.SelectedIndex;
        ClientSettingsEnvironment.ReceivedSystemDataCompressAlgorithmIndex = this.comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm.SelectedIndex;
        ClientSettingsEnvironment.ReceivedScreenshotsCompressAlgorithmIndex = this.comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm.SelectedIndex;
        ClientSettingsEnvironment.DownloadedFilesCompressAlgorithmIndex = this.comboBox_SettingsForm_CompressDownloadedFilesAlgorithm.SelectedIndex;

        ClientSettingsEnvironment.ShowToolTips = this.checkBox_SettingsForm_ShowToolTips.Checked;
        ClientSettingsEnvironment.ShowAdvancedSettings = this.checkBox_SettingsForm_ShowAdvancedSettings.Checked;

        ClientSettingsEnvironment.DownloadedFilesPath = this.textBox_SettingsForm_DonwloadedFilesPath.Text;
        ClientSettingsEnvironment.DownloadedScreenShotsPath = this.textBox_SettingsForm_DownloadedScreenShotsPath.Text;

        ClientSettingsEnvironment.RememberLogins = this.checkBox_LocalSecurity_RememberLogins.Checked;
        ClientSettingsEnvironment.RememberPasswords = this.checkBox_LocalSecurity_RememberPasswords.Checked;
        ClientSettingsEnvironment.EncryptSettingsDataBase = this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked;
        ClientSettingsEnvironment.CompressSettingsDataBase = this.checkBox_LocalSecurity_CompressSettingsDatabase.Checked;


        if (ClientSettingsEnvironment.ShowToolTips)
        {
            ObjCopy.obj_MainClientForm.EnableToolTips();
        }
        else
        {
            ObjCopy.obj_MainClientForm.DisableToolTips();
        }

        if (this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked == false)
        {
            ClientSettingsEnvironment.LocalSecurityPassword = String.Empty;
        }

        if (ClientSettingsEnvironment.LocalSecurityPassword.Length < 6)
        {
            ClientSettingsEnvironment.EncryptSettingsDataBase = false;
        }

        try
        {
            if (MainTcpClient.IsConnected)
            {
                new RemoteCallAction().ChangeClientDataTransferSettings();
            }
        }

        catch (Exception)
        {

        }
    }

    private void button_SettingsForm_ViewDonwloadedFiles_Click(object sender, System.EventArgs e)
    {

        if (System.IO.Directory.Exists(ClientSettingsEnvironment.DownloadedFilesPath))
        {
            System.Diagnostics.Process.Start(ClientSettingsEnvironment.DownloadedFilesPath);
        }
        else
        {
            if (DialogResult.Yes == MessageBox.Show(ClientStringFactory.GetString(218, ClientSettingsEnvironment.CurrentLanguage),
                ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                System.IO.Directory.CreateDirectory(ClientSettingsEnvironment.DownloadedFilesPath);
                System.Diagnostics.Process.Start(ClientSettingsEnvironment.DownloadedFilesPath);
            }
        }

    }

    private void button_SettingsForm_CapturedImages_Click(object sender, System.EventArgs e)
    {
        if (System.IO.Directory.Exists(ClientSettingsEnvironment.DownloadedScreenShotsPath))
        {
            System.Diagnostics.Process.Start(ClientSettingsEnvironment.DownloadedScreenShotsPath);
        }

        else
        {
            if (DialogResult.Yes == MessageBox.Show(ClientStringFactory.GetString(49, ClientSettingsEnvironment.CurrentLanguage),
                ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                System.IO.Directory.CreateDirectory(ClientSettingsEnvironment.DownloadedScreenShotsPath);
                System.Diagnostics.Process.Start(ClientSettingsEnvironment.DownloadedScreenShotsPath);
            }
        }
    }

    private void button_SettingsForm_FilesSaveTo_Click(object sender, System.EventArgs e)
    {
        try
        {
            FolderBrowserDialog obj_FolderBrowserDialog = new FolderBrowserDialog();

            obj_FolderBrowserDialog.ShowNewFolderButton = true;

            obj_FolderBrowserDialog.ShowDialog();

            string string_SaveToFolder = obj_FolderBrowserDialog.SelectedPath;

            if (string_SaveToFolder != null)
            {
                string_SaveToFolder += "\\";

                ClientSettingsEnvironment.DownloadedFilesPath = string_SaveToFolder;

                this.textBox_SettingsForm_DonwloadedFilesPath.Text = ClientSettingsEnvironment.DownloadedFilesPath;
            }
        }

        catch (Exception exception_obj)
        {

        }

    }

    private void button_SettingsForm_ImagesSaveTo_Click(object sender, System.EventArgs e)
    {
        try
        {
            FolderBrowserDialog obj_FolderBrowserDialog = new FolderBrowserDialog();

            obj_FolderBrowserDialog.ShowNewFolderButton = true;

            obj_FolderBrowserDialog.ShowDialog();

            string string_SaveToFolder = obj_FolderBrowserDialog.SelectedPath;

            if (string_SaveToFolder != null)
            {
                string_SaveToFolder += "\\";

                ClientSettingsEnvironment.DownloadedScreenShotsPath = string_SaveToFolder;

                this.textBox_SettingsForm_DownloadedScreenShotsPath.Text = ClientSettingsEnvironment.DownloadedScreenShotsPath;

            }
        }

        catch (Exception exception_obj)
        {

        }
    }

    private void button_RestoreToDefaults_Click(object sender, System.EventArgs e)
    {
        if (MessageBox.Show(ClientStringFactory.GetString(482, ClientSettingsEnvironment.CurrentLanguage),
            ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo) != DialogResult.Yes)
            return;

        ClientSettingsEnvironment.ShowToolTips = this.checkBox_SettingsForm_ShowToolTips.Checked = true;
        ClientSettingsEnvironment.ShowAdvancedSettings = this.checkBox_SettingsForm_ShowAdvancedSettings.Checked = false;

        ClientSettingsEnvironment.ToEncryptSentFiles = this.checkBox_SettingsForm_EncryptSentFiles.Checked = true;
        ClientSettingsEnvironment.ToEncryptSentSystemData = this.checkBox_SettingsForm_EncryptSendingSystemData.Checked = true;
        ClientSettingsEnvironment.ToEncryptReceivedScreenshots = this.checkBox_SettingsForm_EncryptReceivedScreenshots.Checked = false;
        ClientSettingsEnvironment.ToEncryptDownloadedFiles = this.checkBox_SettingsForm_EncryptDownloadedFiles.Checked = true;
        ClientSettingsEnvironment.ToEncryptReceivedSystemData = this.checkBox_SettingsForm_CompressReceivedSystemData.Checked = true;

        ClientSettingsEnvironment.ToCompressSentFiles = this.checkBox_SettingsForm_CompressSentFiles.Checked = false;
        ClientSettingsEnvironment.ToCompressSentSystemData = this.checkBox_SettingsForm_CompressSendingSystemData.Checked = false;
        ClientSettingsEnvironment.ToCompressReceivedScreenshots = this.checkBox_SettingsForm_CompressReceivedScreenshots.Checked = false;
        ClientSettingsEnvironment.ToCompressDownloadedFiles = this.checkBox_SettingsForm_CompressDownloadedFiles.Checked = false;
        ClientSettingsEnvironment.ToCompressReceivedSystemData = this.checkBox_SettingsForm_CompressReceivedSystemData.Checked = false;

        /*
            0 - AES 128 bit
            1 - AES 256 bit
            2 - DES 64 bit
            3 - RC2 40 bit
            4 - RC2 128 bit
            5 - TripleDES 128 bit
            6 - TripleDES 192 bit
        */

        ClientSettingsEnvironment.SentFilesEncryptAlgorithmIndex = this.comboBox_SettingsForm_EncryptSentFilesAlgorithm.SelectedIndex = 1;
        ClientSettingsEnvironment.DownloadedFilesEncryptAlgorithmIndex = this.comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm.SelectedIndex = 1;
        ClientSettingsEnvironment.ReceivedScreenshotsEncryptAlgorithmIndex = this.comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm.SelectedIndex = 0;
        ClientSettingsEnvironment.SendingSystemDataEncryptAlgorithmIndex = this.comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm.SelectedIndex = 1;
        ClientSettingsEnvironment.ReceivedSystemDataEncryptAlgorithmIndex = this.comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm.SelectedIndex = 1;

        /*
            0 - Adaptive Huffman
            1 - Non-Adaptive Huffman
            2 - LZSS
            3 - RLE
        */

        ClientSettingsEnvironment.SentFilesCompressAlgorithmIndex = this.comboBox_SettingsForm_CompressSentFilesAlgorithm.SelectedIndex = 2;
        ClientSettingsEnvironment.SendingSystemDataCompressAlgorithmIndex = this.comboBox_SettingsForm_CompressSendingSystemDataAlgorithm.SelectedIndex = 0;
        ClientSettingsEnvironment.ReceivedSystemDataCompressAlgorithmIndex = this.comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm.SelectedIndex = 2;
        ClientSettingsEnvironment.ReceivedScreenshotsCompressAlgorithmIndex = this.comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm.SelectedIndex = 3;
        ClientSettingsEnvironment.DownloadedFilesCompressAlgorithmIndex = this.comboBox_SettingsForm_CompressDownloadedFilesAlgorithm.SelectedIndex = 2;

        ClientSettingsEnvironment.DownloadedFilesPath = this.textBox_SettingsForm_DonwloadedFilesPath.Text = "C:\\juriksoft\\downloads\\files\\";
        ClientSettingsEnvironment.DownloadedScreenShotsPath = this.textBox_SettingsForm_DownloadedScreenShotsPath.Text = "C:\\juriksoft\\downloads\\images\\";

        if (ClientSettingsEnvironment.ShowToolTips)
        {
            ObjCopy.obj_MainClientForm.EnableToolTips();
        }
        else
        {
            ObjCopy.obj_MainClientForm.DisableToolTips();
        }
    }

    private void button_LocalSecurity_NewPassword_Click(object sender, System.EventArgs e)
    {
        SetPasswordInputEnableState(true);

        this.button_LocalSecurity_SetPassword.Enabled = true;
        this.button_LocalSecurity_NewPassword.Enabled = false;

        this.textBox_LocalSecurity_NewPassword.Text = this.textBox_LocalSecurity_ConfirmedPassword.Text =
        ClientSettingsEnvironment.LocalSecurityPassword = String.Empty;
    }

    private void button_LocalSecurity_SetPassword_Click(object sender, System.EventArgs e)
    {
        if (this.textBox_LocalSecurity_NewPassword.Text.Length < 6)
        {
            MessageBox.Show(ClientStringFactory.GetString(532, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return;
        }

        if (this.textBox_LocalSecurity_NewPassword.Text != this.textBox_LocalSecurity_ConfirmedPassword.Text)
        {
            MessageBox.Show(ClientStringFactory.GetString(531, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return;
        }

        ClientSettingsEnvironment.LocalSecurityPassword = this.textBox_LocalSecurity_NewPassword.Text;

        this.button_LocalSecurity_SetPassword.Enabled = false;
        this.button_LocalSecurity_NewPassword.Enabled = true;

        SetPasswordInputEnableState(false);
    }




    private void checkBox_SettingsForm_EncryptSentFiles_CheckedChanged(object sender, System.EventArgs e)
    {
        this.comboBox_SettingsForm_EncryptSentFilesAlgorithm.Enabled = this.checkBox_SettingsForm_EncryptSentFiles.Checked;
    }

    private void checkBox_SettingsForm_EncryptDownloadedFiles_CheckedChanged(object sender, System.EventArgs e)
    {
        this.comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm.Enabled = this.checkBox_SettingsForm_EncryptDownloadedFiles.Checked;
    }

    private void checkBox_SettingsForm_EncryptReceivedScreenshots_CheckedChanged(object sender, System.EventArgs e)
    {
        this.comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm.Enabled = this.checkBox_SettingsForm_EncryptReceivedScreenshots.Checked;
    }

    private void checkBox_SettingsForm_EncryptSendingSystemData_CheckedChanged(object sender, System.EventArgs e)
    {
        this.comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm.Enabled = this.checkBox_SettingsForm_EncryptSendingSystemData.Checked;
    }

    private void checkBox_SettingsForm_EncryptReceivedSystemData_CheckedChanged(object sender, System.EventArgs e)
    {
        this.comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm.Enabled = this.checkBox_SettingsForm_EncryptReceivedSystemData.Checked;
    }


    private void checkBox_SettingsForm_CompressSentFiles_CheckedChanged(object sender, System.EventArgs e)
    {
        this.comboBox_SettingsForm_CompressSentFilesAlgorithm.Enabled = this.checkBox_SettingsForm_CompressSentFiles.Checked;
    }

    private void checkBox_SettingsForm_CompressDownloadedFiles_CheckedChanged(object sender, System.EventArgs e)
    {
        this.comboBox_SettingsForm_CompressDownloadedFilesAlgorithm.Enabled = this.checkBox_SettingsForm_CompressDownloadedFiles.Checked;
    }

    private void checkBox_SettingsForm_CompressReceivedScreenshots_CheckedChanged(object sender, System.EventArgs e)
    {
        this.comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm.Enabled = this.checkBox_SettingsForm_CompressReceivedScreenshots.Checked;
    }

    private void checkBox_SettingsForm_CompressSendingSystemData_CheckedChanged(object sender, System.EventArgs e)
    {
        this.comboBox_SettingsForm_CompressSendingSystemDataAlgorithm.Enabled = this.checkBox_SettingsForm_CompressSendingSystemData.Checked;
    }

    private void checkBox_SettingsForm_CompressReceivedSystemData_CheckedChanged(object sender, System.EventArgs e)
    {
        this.comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm.Enabled = this.checkBox_SettingsForm_CompressReceivedSystemData.Checked;
    }

    private void checkBox_SettingsForm_ShowAdvancedSettings_CheckedChanged(object sender, System.EventArgs e)
    {

        this.comboBox_SettingsForm_EncryptDownloadedFilesAlgorithm.Visible =
        this.comboBox_SettingsForm_EncryptReceivedScreenshotsAlgorithm.Visible =
        this.comboBox_SettingsForm_EncryptReceivedSystemDataAlgorithm.Visible =
        this.comboBox_SettingsForm_EncryptSendingSystemDataAlgorithm.Visible =
        this.comboBox_SettingsForm_EncryptSentFilesAlgorithm.Visible =

        this.label_SettingsForm_EncryptDownloadedFilesAlgorithm.Visible =
        this.label_SettingsForm_EncryptReceivedScreenshotsAlgorithm.Visible =
        this.label_SettingsForm_EncryptReceivedSystemDataAlgorithm.Visible =
        this.label_SettingsForm_EncryptSendingSystemDataAlgorithm.Visible =
        this.label_SettingsForm_EncryptSentFilesAlgorithm.Visible =

        this.comboBox_SettingsForm_CompressDownloadedFilesAlgorithm.Visible =
        this.comboBox_SettingsForm_CompressReceivedScreenshotsAlgorithm.Visible =
        this.comboBox_SettingsForm_CompressReceivedSystemDataAlgorithm.Visible =
        this.comboBox_SettingsForm_CompressSendingSystemDataAlgorithm.Visible =
        this.comboBox_SettingsForm_CompressSentFilesAlgorithm.Visible =

        this.label_SettingsForm_CompressDownloadedFilesAlgorithm.Visible =
        this.label_SettingsForm_CompressReceivedScreenshotsAlgorithm.Visible =
        this.label_SettingsForm_CompressReceivedSystemDataAlgorithm.Visible =
        this.label_SettingsForm_CompressSendingSystemDataAlgorithm.Visible =
        this.label_SettingsForm_CompressSentFilesAlgorithm.Visible =

        this.checkBox_SettingsForm_ShowAdvancedSettings.Checked;

    }

    private void checkBox_LocalSecurity_EncryptSettingsDatabase_CheckedChanged(object sender, System.EventArgs e)
    {
        this.groupBox_LocalSecurity_UsedPassword.Enabled = this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked;


        if (this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked == true && ClientSettingsEnvironment.LocalSecurityPassword.Length < 6)
        {
            this.button_LocalSecurity_NewPassword_Click(null, null);

            return;
        }
        else
        {
            SetPasswordInputEnableState(false);

            this.button_LocalSecurity_SetPassword.Enabled = false;
            this.button_LocalSecurity_NewPassword.Enabled = true;
        }
    }


    private void comboBox_SettingsForm_Language_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ClientSettingsEnvironment.CurrentLanguage != comboBox_SettingsForm_Language.SelectedIndex)
        {
            ClientSettingsEnvironment.CurrentLanguage = comboBox_SettingsForm_Language.SelectedIndex;
        }

        ChangeControlsLanguage();

        ObjCopy.obj_MainClientForm.ChangeControlsLanguage();
    }


    public void SetPasswordInputEnableState(bool bool_EnableState)
    {
        this.label_LocalSecurity_NewPassword.Enabled = bool_EnableState;
        this.label_LocalSecurity_ConfirmedPassword.Enabled = bool_EnableState;

        this.textBox_LocalSecurity_NewPassword.Enabled = bool_EnableState;
        this.textBox_LocalSecurity_ConfirmedPassword.Enabled = bool_EnableState;
    }


    private void SettingsForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }


}

