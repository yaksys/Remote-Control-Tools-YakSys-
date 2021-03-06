using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Data;
using YakSys;
using YakSysConnectingService;

public class ServersAccessRestrictionRulesManagerForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.Button button_ServersAccessRestrictionRulesManager_Add;
    private System.Windows.Forms.GroupBox groupBox_ServersAccessRestrictionRulesManager_IPRange;
    private System.Windows.Forms.GroupBox groupBox_ServersAccessRestrictionRulesManager_MACAddress;
    private System.Windows.Forms.CheckBox checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule;
    private System.Windows.Forms.GroupBox groupBox_ServersAccessRestrictionRulesManager_IPAddress;
    private System.Windows.Forms.Button button_ServersAccessRestrictionRulesManager_Cancel;
    private System.Windows.Forms.Button button_ServersAccessRestrictionRulesManager_Apply;
    private System.Windows.Forms.RadioButton radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange;
    private System.Windows.Forms.RadioButton radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress;
    private System.Windows.Forms.RadioButton radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress;
    private System.Windows.Forms.ComboBox comboBox_ServersAccessRestrictionRulesManager_RuleType;
    private System.Windows.Forms.Label label_ServersAccessRestrictionRulesManager_RuleType;
    private System.Windows.Forms.TextBox textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne;
    private System.Windows.Forms.Label label_ServersAccessRestrictionRulesManager_IPRangeEndValue;
    private System.Windows.Forms.Label label_ServersAccessRestrictionRulesManager_IPRangeStartValue;
    private System.Windows.Forms.TextBox textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix;
    private System.Windows.Forms.TextBox textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive;
    private System.Windows.Forms.TextBox textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour;
    private System.Windows.Forms.TextBox textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree;
    private System.Windows.Forms.TextBox textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo;
    private System.Windows.Forms.Label label_ServersAccessRestrictionRulesManager_MACAddress;
    private System.Windows.Forms.Label label_ServersAccessRestrictionRulesManager_IPAddress;
    private System.Windows.Forms.TextBox textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue;
    private System.Windows.Forms.TextBox textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue;
    private System.Windows.Forms.TextBox textBox_ServersAccessRestrictionRulesManager_IPAddress;
    private System.Windows.Forms.Label label_Dash1;
    private System.Windows.Forms.Label label_Dash2;
    private System.Windows.Forms.Label label_Dash3;
    private System.Windows.Forms.Label label_Dash4;
    private System.Windows.Forms.Label label_Dash5;

    private System.ComponentModel.Container components = null;

    void ChangeControlsLanguage()
    {
        this.Text = ServerStringFactory.GetString(195, MainForm.CurrentLanguage);

        this.button_ServersAccessRestrictionRulesManager_Add.Text = ServerStringFactory.GetString(23, MainForm.CurrentLanguage);
        this.button_ServersAccessRestrictionRulesManager_Apply.Text = ServerStringFactory.GetString(79, MainForm.CurrentLanguage);
        this.button_ServersAccessRestrictionRulesManager_Cancel.Text = ServerStringFactory.GetString(86, MainForm.CurrentLanguage);

        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Text = ServerStringFactory.GetString(189, MainForm.CurrentLanguage);
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.Text = ServerStringFactory.GetString(190, MainForm.CurrentLanguage);
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.Text = ServerStringFactory.GetString(191, MainForm.CurrentLanguage);

        this.label_ServersAccessRestrictionRulesManager_IPRangeStartValue.Text = ServerStringFactory.GetString(192, MainForm.CurrentLanguage);
        this.label_ServersAccessRestrictionRulesManager_IPRangeEndValue.Text = ServerStringFactory.GetString(193, MainForm.CurrentLanguage);

        this.label_ServersAccessRestrictionRulesManager_IPAddress.Text = ServerStringFactory.GetString(185, MainForm.CurrentLanguage);

        this.label_ServersAccessRestrictionRulesManager_MACAddress.Text = ServerStringFactory.GetString(186, MainForm.CurrentLanguage);

        this.label_ServersAccessRestrictionRulesManager_RuleType.Text = ServerStringFactory.GetString(196, MainForm.CurrentLanguage);

        this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Text = ServerStringFactory.GetString(194, MainForm.CurrentLanguage);

        this.comboBox_ServersAccessRestrictionRulesManager_RuleType.Items.Clear();

        this.comboBox_ServersAccessRestrictionRulesManager_RuleType.Items.AddRange(new object[] {
																							 ServerStringFactory.GetString(197, MainForm.CurrentLanguage),
																							 ServerStringFactory.GetString(198, MainForm.CurrentLanguage)});

        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.Text = ServerStringFactory.GetString(227, MainForm.CurrentLanguage);
    }


    public ServersAccessRestrictionRulesManagerForm()
    {
        InitializeComponent();

        ChangeControlsLanguage();

        this.comboBox_ServersAccessRestrictionRulesManager_RuleType.SelectedIndex = 0;

        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Checked = true;
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

    private void InitializeComponent()
    {
        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ServersAccessRestrictionRulesManagerForm));
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne = new System.Windows.Forms.TextBox();
        this.groupBox_ServersAccessRestrictionRulesManager_IPRange = new System.Windows.Forms.GroupBox();
        this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue = new System.Windows.Forms.TextBox();
        this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue = new System.Windows.Forms.TextBox();
        this.label_ServersAccessRestrictionRulesManager_IPRangeEndValue = new System.Windows.Forms.Label();
        this.label_ServersAccessRestrictionRulesManager_IPRangeStartValue = new System.Windows.Forms.Label();
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress = new System.Windows.Forms.GroupBox();
        this.label_Dash5 = new System.Windows.Forms.Label();
        this.label_Dash4 = new System.Windows.Forms.Label();
        this.label_Dash3 = new System.Windows.Forms.Label();
        this.label_Dash2 = new System.Windows.Forms.Label();
        this.label_Dash1 = new System.Windows.Forms.Label();
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix = new System.Windows.Forms.TextBox();
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive = new System.Windows.Forms.TextBox();
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour = new System.Windows.Forms.TextBox();
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree = new System.Windows.Forms.TextBox();
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo = new System.Windows.Forms.TextBox();
        this.label_ServersAccessRestrictionRulesManager_MACAddress = new System.Windows.Forms.Label();
        this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule = new System.Windows.Forms.CheckBox();
        this.groupBox_ServersAccessRestrictionRulesManager_IPAddress = new System.Windows.Forms.GroupBox();
        this.textBox_ServersAccessRestrictionRulesManager_IPAddress = new System.Windows.Forms.TextBox();
        this.label_ServersAccessRestrictionRulesManager_IPAddress = new System.Windows.Forms.Label();
        this.button_ServersAccessRestrictionRulesManager_Cancel = new System.Windows.Forms.Button();
        this.button_ServersAccessRestrictionRulesManager_Apply = new System.Windows.Forms.Button();
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange = new System.Windows.Forms.RadioButton();
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress = new System.Windows.Forms.RadioButton();
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress = new System.Windows.Forms.RadioButton();
        this.button_ServersAccessRestrictionRulesManager_Add = new System.Windows.Forms.Button();
        this.comboBox_ServersAccessRestrictionRulesManager_RuleType = new System.Windows.Forms.ComboBox();
        this.label_ServersAccessRestrictionRulesManager_RuleType = new System.Windows.Forms.Label();
        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.SuspendLayout();
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.SuspendLayout();
        this.groupBox_ServersAccessRestrictionRulesManager_IPAddress.SuspendLayout();
        this.SuspendLayout();
        // 
        // textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne
        // 
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne.Location = new System.Drawing.Point(16, 48);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne.MaxLength = 2;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne.Name = "textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne";
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne.Size = new System.Drawing.Size(24, 20);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne.TabIndex = 3;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne.Text = "00";
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne.TextChanged += new System.EventHandler(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne_TextChanged);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne.Leave += new System.EventHandler(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne_Leave);
        // 
        // groupBox_ServersAccessRestrictionRulesManager_IPRange
        // 
        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.Controls.Add(this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue);
        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.Controls.Add(this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue);
        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.Controls.Add(this.label_ServersAccessRestrictionRulesManager_IPRangeEndValue);
        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.Controls.Add(this.label_ServersAccessRestrictionRulesManager_IPRangeStartValue);
        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.Location = new System.Drawing.Point(16, 32);
        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.Name = "groupBox_ServersAccessRestrictionRulesManager_IPRange";
        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.Size = new System.Drawing.Size(280, 88);
        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.TabIndex = 5;
        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.TabStop = false;
        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.Text = "(������� �������� ��������)";
        // 
        // textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue
        // 
        this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue.Location = new System.Drawing.Point(144, 48);
        this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue.Name = "textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue";
        this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue.Size = new System.Drawing.Size(120, 20);
        this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue.TabIndex = 12;
        this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue.Text = String.Empty;
        // 
        // textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue
        // 
        this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue.Location = new System.Drawing.Point(16, 48);
        this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue.Name = "textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue";
        this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue.Size = new System.Drawing.Size(120, 20);
        this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue.TabIndex = 11;
        this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue.Text = String.Empty;
        // 
        // label_ServersAccessRestrictionRulesManager_IPRangeEndValue
        // 
        this.label_ServersAccessRestrictionRulesManager_IPRangeEndValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ServersAccessRestrictionRulesManager_IPRangeEndValue.Location = new System.Drawing.Point(144, 32);
        this.label_ServersAccessRestrictionRulesManager_IPRangeEndValue.Name = "label_ServersAccessRestrictionRulesManager_IPRangeEndValue";
        this.label_ServersAccessRestrictionRulesManager_IPRangeEndValue.Size = new System.Drawing.Size(120, 16);
        this.label_ServersAccessRestrictionRulesManager_IPRangeEndValue.TabIndex = 10;
        this.label_ServersAccessRestrictionRulesManager_IPRangeEndValue.Text = "IP Range End Value:";
        // 
        // label_ServersAccessRestrictionRulesManager_IPRangeStartValue
        // 
        this.label_ServersAccessRestrictionRulesManager_IPRangeStartValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ServersAccessRestrictionRulesManager_IPRangeStartValue.Location = new System.Drawing.Point(16, 32);
        this.label_ServersAccessRestrictionRulesManager_IPRangeStartValue.Name = "label_ServersAccessRestrictionRulesManager_IPRangeStartValue";
        this.label_ServersAccessRestrictionRulesManager_IPRangeStartValue.Size = new System.Drawing.Size(120, 16);
        this.label_ServersAccessRestrictionRulesManager_IPRangeStartValue.TabIndex = 9;
        this.label_ServersAccessRestrictionRulesManager_IPRangeStartValue.Text = "IP Range Start Value:";
        // 
        // groupBox_ServersAccessRestrictionRulesManager_MACAddress
        // 
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Controls.Add(this.label_Dash5);
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Controls.Add(this.label_Dash4);
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Controls.Add(this.label_Dash3);
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Controls.Add(this.label_Dash2);
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Controls.Add(this.label_Dash1);
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Controls.Add(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix);
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Controls.Add(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive);
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Controls.Add(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour);
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Controls.Add(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree);
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Controls.Add(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo);
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Controls.Add(this.label_ServersAccessRestrictionRulesManager_MACAddress);
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Controls.Add(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne);
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Location = new System.Drawing.Point(504, 32);
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Name = "groupBox_ServersAccessRestrictionRulesManager_MACAddress";
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Size = new System.Drawing.Size(216, 88);
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.TabIndex = 6;
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.TabStop = false;
        // 
        // label_Dash5
        // 
        this.label_Dash5.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_Dash5.Location = new System.Drawing.Point(168, 48);
        this.label_Dash5.Name = "label_Dash5";
        this.label_Dash5.Size = new System.Drawing.Size(8, 16);
        this.label_Dash5.TabIndex = 18;
        this.label_Dash5.Text = "__";
        this.label_Dash5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label_Dash4
        // 
        this.label_Dash4.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_Dash4.Location = new System.Drawing.Point(136, 48);
        this.label_Dash4.Name = "label_Dash4";
        this.label_Dash4.Size = new System.Drawing.Size(8, 16);
        this.label_Dash4.TabIndex = 17;
        this.label_Dash4.Text = "__";
        this.label_Dash4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label_Dash3
        // 
        this.label_Dash3.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_Dash3.Location = new System.Drawing.Point(104, 48);
        this.label_Dash3.Name = "label_Dash3";
        this.label_Dash3.Size = new System.Drawing.Size(8, 16);
        this.label_Dash3.TabIndex = 16;
        this.label_Dash3.Text = "__";
        this.label_Dash3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label_Dash2
        // 
        this.label_Dash2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_Dash2.Location = new System.Drawing.Point(72, 48);
        this.label_Dash2.Name = "label_Dash2";
        this.label_Dash2.Size = new System.Drawing.Size(8, 16);
        this.label_Dash2.TabIndex = 15;
        this.label_Dash2.Text = "__";
        this.label_Dash2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label_Dash1
        // 
        this.label_Dash1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_Dash1.Location = new System.Drawing.Point(40, 48);
        this.label_Dash1.Name = "label_Dash1";
        this.label_Dash1.Size = new System.Drawing.Size(8, 16);
        this.label_Dash1.TabIndex = 14;
        this.label_Dash1.Text = "__";
        this.label_Dash1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix
        // 
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix.Location = new System.Drawing.Point(176, 48);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix.MaxLength = 2;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix.Name = "textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix";
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix.Size = new System.Drawing.Size(24, 20);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix.TabIndex = 13;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix.Text = "00";
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix.TextChanged += new System.EventHandler(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix_TextChanged);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix.Leave += new System.EventHandler(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix_Leave);
        // 
        // textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive
        // 
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive.Location = new System.Drawing.Point(144, 48);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive.MaxLength = 2;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive.Name = "textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive";
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive.Size = new System.Drawing.Size(24, 20);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive.TabIndex = 12;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive.Text = "00";
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive.TextChanged += new System.EventHandler(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive_TextChanged);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive.Leave += new System.EventHandler(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive_Leave);
        // 
        // textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour
        // 
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour.Location = new System.Drawing.Point(112, 48);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour.MaxLength = 2;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour.Name = "textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour";
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour.Size = new System.Drawing.Size(24, 20);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour.TabIndex = 11;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour.Text = "00";
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour.TextChanged += new System.EventHandler(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour_TextChanged);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour.Leave += new System.EventHandler(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour_Leave);
        // 
        // textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree
        // 
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree.Location = new System.Drawing.Point(80, 48);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree.MaxLength = 2;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree.Name = "textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree";
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree.Size = new System.Drawing.Size(24, 20);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree.TabIndex = 10;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree.Text = "00";
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree.TextChanged += new System.EventHandler(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree_TextChanged);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree.Leave += new System.EventHandler(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree_Leave);
        // 
        // textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo
        // 
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo.Location = new System.Drawing.Point(48, 48);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo.MaxLength = 2;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo.Name = "textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo";
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo.Size = new System.Drawing.Size(24, 20);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo.TabIndex = 9;
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo.Text = "00";
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo.TextChanged += new System.EventHandler(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo_TextChanged);
        this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo.Leave += new System.EventHandler(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo_Leave);
        // 
        // label_ServersAccessRestrictionRulesManager_MACAddress
        // 
        this.label_ServersAccessRestrictionRulesManager_MACAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ServersAccessRestrictionRulesManager_MACAddress.Location = new System.Drawing.Point(16, 32);
        this.label_ServersAccessRestrictionRulesManager_MACAddress.Name = "label_ServersAccessRestrictionRulesManager_MACAddress";
        this.label_ServersAccessRestrictionRulesManager_MACAddress.Size = new System.Drawing.Size(120, 16);
        this.label_ServersAccessRestrictionRulesManager_MACAddress.TabIndex = 8;
        this.label_ServersAccessRestrictionRulesManager_MACAddress.Text = "MAC Address:";
        // 
        // checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule
        // 
        this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Location = new System.Drawing.Point(504, 128);
        this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Name = "checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule";
        this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Size = new System.Drawing.Size(216, 40);
        this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.TabIndex = 7;
        this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Text = "Complementary use MAC Address in Rule";
        this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.TextAlign = System.Drawing.ContentAlignment.TopLeft;
        this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.CheckedChanged += new System.EventHandler(this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule_CheckedChanged);
        // 
        // groupBox_ServersAccessRestrictionRulesManager_IPAddress
        // 
        this.groupBox_ServersAccessRestrictionRulesManager_IPAddress.Controls.Add(this.textBox_ServersAccessRestrictionRulesManager_IPAddress);
        this.groupBox_ServersAccessRestrictionRulesManager_IPAddress.Controls.Add(this.label_ServersAccessRestrictionRulesManager_IPAddress);
        this.groupBox_ServersAccessRestrictionRulesManager_IPAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ServersAccessRestrictionRulesManager_IPAddress.Location = new System.Drawing.Point(304, 32);
        this.groupBox_ServersAccessRestrictionRulesManager_IPAddress.Name = "groupBox_ServersAccessRestrictionRulesManager_IPAddress";
        this.groupBox_ServersAccessRestrictionRulesManager_IPAddress.Size = new System.Drawing.Size(192, 88);
        this.groupBox_ServersAccessRestrictionRulesManager_IPAddress.TabIndex = 8;
        this.groupBox_ServersAccessRestrictionRulesManager_IPAddress.TabStop = false;
        // 
        // textBox_ServersAccessRestrictionRulesManager_IPAddress
        // 
        this.textBox_ServersAccessRestrictionRulesManager_IPAddress.Location = new System.Drawing.Point(16, 48);
        this.textBox_ServersAccessRestrictionRulesManager_IPAddress.Name = "textBox_ServersAccessRestrictionRulesManager_IPAddress";
        this.textBox_ServersAccessRestrictionRulesManager_IPAddress.Size = new System.Drawing.Size(160, 20);
        this.textBox_ServersAccessRestrictionRulesManager_IPAddress.TabIndex = 12;
        this.textBox_ServersAccessRestrictionRulesManager_IPAddress.Text = String.Empty;
        // 
        // label_ServersAccessRestrictionRulesManager_IPAddress
        // 
        this.label_ServersAccessRestrictionRulesManager_IPAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ServersAccessRestrictionRulesManager_IPAddress.Location = new System.Drawing.Point(16, 32);
        this.label_ServersAccessRestrictionRulesManager_IPAddress.Name = "label_ServersAccessRestrictionRulesManager_IPAddress";
        this.label_ServersAccessRestrictionRulesManager_IPAddress.Size = new System.Drawing.Size(160, 16);
        this.label_ServersAccessRestrictionRulesManager_IPAddress.TabIndex = 8;
        this.label_ServersAccessRestrictionRulesManager_IPAddress.Text = "IP Address:";
        // 
        // button_ServersAccessRestrictionRulesManager_Cancel
        // 
        this.button_ServersAccessRestrictionRulesManager_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersAccessRestrictionRulesManager_Cancel.Location = new System.Drawing.Point(208, 144);
        this.button_ServersAccessRestrictionRulesManager_Cancel.Name = "button_ServersAccessRestrictionRulesManager_Cancel";
        this.button_ServersAccessRestrictionRulesManager_Cancel.Size = new System.Drawing.Size(88, 23);
        this.button_ServersAccessRestrictionRulesManager_Cancel.TabIndex = 9;
        this.button_ServersAccessRestrictionRulesManager_Cancel.Text = "Cancel";
        this.button_ServersAccessRestrictionRulesManager_Cancel.Click += new System.EventHandler(this.button_ServersAccessRestrictionRulesManager_Cancel_Click);
        // 
        // button_ServersAccessRestrictionRulesManager_Apply
        // 
        this.button_ServersAccessRestrictionRulesManager_Apply.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersAccessRestrictionRulesManager_Apply.Location = new System.Drawing.Point(112, 144);
        this.button_ServersAccessRestrictionRulesManager_Apply.Name = "button_ServersAccessRestrictionRulesManager_Apply";
        this.button_ServersAccessRestrictionRulesManager_Apply.Size = new System.Drawing.Size(88, 23);
        this.button_ServersAccessRestrictionRulesManager_Apply.TabIndex = 10;
        this.button_ServersAccessRestrictionRulesManager_Apply.Text = "Apply";
        this.button_ServersAccessRestrictionRulesManager_Apply.Click += new System.EventHandler(this.button_ServersAccessRestrictionRulesManager_Apply_Click);
        // 
        // radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange
        // 
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Location = new System.Drawing.Point(16, 16);
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Name = "radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange";
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Size = new System.Drawing.Size(280, 16);
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.TabIndex = 17;
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Text = "Restrict Access by IP Range";
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.CheckedChanged += new System.EventHandler(this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange_CheckedChanged);
        // 
        // radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress
        // 
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.Location = new System.Drawing.Point(304, 16);
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.Name = "radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress";
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.Size = new System.Drawing.Size(192, 16);
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.TabIndex = 12;
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.Text = "Restrict Access by IP Address";
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.CheckedChanged += new System.EventHandler(this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress_CheckedChanged);
        // 
        // radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress
        // 
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.Location = new System.Drawing.Point(504, 16);
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.Name = "radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress";
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.Size = new System.Drawing.Size(216, 16);
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.TabIndex = 13;
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.Text = "Restrict by MAC Address";
        this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.CheckedChanged += new System.EventHandler(this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress_CheckedChanged);
        // 
        // button_ServersAccessRestrictionRulesManager_Add
        // 
        this.button_ServersAccessRestrictionRulesManager_Add.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersAccessRestrictionRulesManager_Add.Location = new System.Drawing.Point(16, 144);
        this.button_ServersAccessRestrictionRulesManager_Add.Name = "button_ServersAccessRestrictionRulesManager_Add";
        this.button_ServersAccessRestrictionRulesManager_Add.Size = new System.Drawing.Size(88, 23);
        this.button_ServersAccessRestrictionRulesManager_Add.TabIndex = 14;
        this.button_ServersAccessRestrictionRulesManager_Add.Text = "Add";
        this.button_ServersAccessRestrictionRulesManager_Add.Click += new System.EventHandler(this.button_ServersAccessRestrictionRulesManager_Add_Click);
        // 
        // comboBox_ServersAccessRestrictionRulesManager_RuleType
        // 
        this.comboBox_ServersAccessRestrictionRulesManager_RuleType.Items.AddRange(new object[] {
																							 "Allow Connections",
																							 "Deny Connections"});
        this.comboBox_ServersAccessRestrictionRulesManager_RuleType.Location = new System.Drawing.Point(320, 144);
        this.comboBox_ServersAccessRestrictionRulesManager_RuleType.Name = "comboBox_ServersAccessRestrictionRulesManager_RuleType";
        this.comboBox_ServersAccessRestrictionRulesManager_RuleType.Size = new System.Drawing.Size(160, 21);
        this.comboBox_ServersAccessRestrictionRulesManager_RuleType.TabIndex = 15;
        // 
        // label_ServersAccessRestrictionRulesManager_RuleType
        // 
        this.label_ServersAccessRestrictionRulesManager_RuleType.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ServersAccessRestrictionRulesManager_RuleType.Location = new System.Drawing.Point(320, 128);
        this.label_ServersAccessRestrictionRulesManager_RuleType.Name = "label_ServersAccessRestrictionRulesManager_RuleType";
        this.label_ServersAccessRestrictionRulesManager_RuleType.Size = new System.Drawing.Size(80, 16);
        this.label_ServersAccessRestrictionRulesManager_RuleType.TabIndex = 16;
        this.label_ServersAccessRestrictionRulesManager_RuleType.Text = "Rule Type:";
        this.label_ServersAccessRestrictionRulesManager_RuleType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
        // 
        // ServersAccessRestrictionRulesManagerForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(738, 184);
        this.Controls.Add(this.label_ServersAccessRestrictionRulesManager_RuleType);
        this.Controls.Add(this.comboBox_ServersAccessRestrictionRulesManager_RuleType);
        this.Controls.Add(this.button_ServersAccessRestrictionRulesManager_Add);
        this.Controls.Add(this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress);
        this.Controls.Add(this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress);
        this.Controls.Add(this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange);
        this.Controls.Add(this.button_ServersAccessRestrictionRulesManager_Apply);
        this.Controls.Add(this.button_ServersAccessRestrictionRulesManager_Cancel);
        this.Controls.Add(this.groupBox_ServersAccessRestrictionRulesManager_IPAddress);
        this.Controls.Add(this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule);
        this.Controls.Add(this.groupBox_ServersAccessRestrictionRulesManager_MACAddress);
        this.Controls.Add(this.groupBox_ServersAccessRestrictionRulesManager_IPRange);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(744, 224);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(744, 216);
        this.Name = "ServersAccessRestrictionRulesManagerForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Access Restriction Rules Manager";
        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.ResumeLayout(false);
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.ResumeLayout(false);
        this.groupBox_ServersAccessRestrictionRulesManager_IPAddress.ResumeLayout(false);
        this.ResumeLayout(false);

    }
    #endregion

    bool VerifySingleIPAddressToCorrectValue()
    {
        try
        {
            string string_IPCheck = this.textBox_ServersAccessRestrictionRulesManager_IPAddress.Text.Replace(".", "");

            if (string_IPCheck.Length + 3 != this.textBox_ServersAccessRestrictionRulesManager_IPAddress.Text.Length ||
                this.textBox_ServersAccessRestrictionRulesManager_IPAddress.Text.Length == 0 || string_IPCheck.Length > 12)
            {
                throw new FormatException();
            }

            IPAddress.Parse(this.textBox_ServersAccessRestrictionRulesManager_IPAddress.Text);

            return true;
        }

        catch
        {
            MessageBox.Show(ServerStringFactory.GetString(199, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return false;
        }
    }

    bool VerifyIPAddressesRangeStartValueToCorrect()
    {
        try
        {
            string string_IPCheck = this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue.Text.Replace(".", "");

            if (string_IPCheck.Length + 3 != this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue.Text.Length ||
               this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue.Text.Length == 0 || string_IPCheck.Length > 12)
            {
                throw new FormatException();
            }

            IPAddress.Parse(this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue.Text);

            return true;
        }

        catch
        {
            MessageBox.Show(ServerStringFactory.GetString(200, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage));

            return false;
        }
    }

    bool VerifyIPAddressesRangeEndValueToCorrect()
    {
        try
        {
            string string_IPCheck = this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue.Text.Replace(".", "");

            if (string_IPCheck.Length + 3 != this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue.Text.Length ||
                this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue.Text.Length == 0 || string_IPCheck.Length > 12)
            {
                throw new FormatException();
            }

            IPAddress iPAddress_StartValue = IPAddress.Parse(this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue.Text);

            IPAddress iPAddress_EndValue = IPAddress.Parse(this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue.Text);

            if (CommonMethods.IsSecondIPAddressBiggerOrEquals(iPAddress_StartValue, iPAddress_EndValue) == false)
            {
                MessageBox.Show(ServerStringFactory.GetString(202, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage));

                return false;
            };

            return true;
        }

        catch
        {
            MessageBox.Show(ServerStringFactory.GetString(201, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage));

            return false;
        }
    }

    bool CheckForLogicalConfictsInRulesList(int int_MissRecord)
    {
        ServersNetworkSecurity.AccessRestrictionRuleObject accessRestrictionRuleObject_obj = null;

        for (int int_CycleCount = 0; int_CycleCount != ServersNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules.Count; int_CycleCount++)
        {
            if (int_MissRecord == int_CycleCount) continue;

            accessRestrictionRuleObject_obj = ServersNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules[int_CycleCount];

            if (accessRestrictionRuleObject_obj.RuleType != this.comboBox_ServersAccessRestrictionRulesManager_RuleType.SelectedIndex)
            {
                MessageBox.Show(ServerStringFactory.GetString(203, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage));

                return false;
            }
        }

        if (this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Checked == true ||
            this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.Checked == true)
        {
            MACAddress = this.MACAddressValueOneTextBox.Text + "-" + this.MACAddressValueTwoTextBox.Text + "-" + this.MACAddressValueThreeTextBox.Text + "-" + this.MACAddressValueFourTextBox.Text + "-" + this.MACAddressValueFiveTextBox.Text + "-" + this.MACAddressValueSixTextBox.Text;

            for (int int_CycleCount = 0; int_CycleCount != ServersNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules.Count; int_CycleCount++)
            {
                if (int_MissRecord == int_CycleCount) continue;

                accessRestrictionRuleObject_obj = ServersNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules[int_CycleCount];

                if (this.MACAddress == accessRestrictionRuleObject_obj.MACAddress)
                {
                    MessageBox.Show(ServerStringFactory.GetString(204, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage));

                    return false;
                }
            }
        }

        if (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.Checked == true)
        {
            IPAddress iPAddress_IPAddress = IPAddress.Parse(this.textBox_ServersAccessRestrictionRulesManager_IPAddress.Text);

            for (int int_CycleCount = 0; int_CycleCount != ServersNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules.Count; int_CycleCount++)
            {
                if (int_MissRecord == int_CycleCount) continue;

                accessRestrictionRuleObject_obj = ServersNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules[int_CycleCount];

                if (accessRestrictionRuleObject_obj.IPAddress != null && iPAddress_IPAddress.Address == accessRestrictionRuleObject_obj.IPAddress.Address)
                {
                    MessageBox.Show(ServerStringFactory.GetString(205, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage));

                    return false;
                }

                if (accessRestrictionRuleObject_obj.IPAddressesRangeStartValue != null &&
                   accessRestrictionRuleObject_obj.IPAddressesRangeEndValue != null &&

                   CommonMethods.IsSecondIPAddressBiggerOrEquals(iPAddress_IPAddress, accessRestrictionRuleObject_obj.IPAddressesRangeStartValue) == false &&
                   CommonMethods.IsSecondIPAddressBiggerOrEquals(iPAddress_IPAddress, accessRestrictionRuleObject_obj.IPAddressesRangeEndValue) == true
                  )
                {
                    MessageBox.Show(ServerStringFactory.GetString(206, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage));

                    return false;
                }
            }
        }


        if (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Checked == true)
        {
            IPAddress iPAddress_IPAddressesRangeStartValue = IPAddress.Parse(this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue.Text);

            IPAddress iPAddress_IPAddressesRangeEndValue = IPAddress.Parse(this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue.Text);

            for (int int_CycleCount = 0; int_CycleCount != ServersNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules.Count; int_CycleCount++)
            {
                if (int_MissRecord == int_CycleCount) continue;

                accessRestrictionRuleObject_obj = ServersNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules[int_CycleCount];

                if (accessRestrictionRuleObject_obj.IPAddress != null &&
                    CommonMethods.IsSecondIPAddressBiggerOrEquals(accessRestrictionRuleObject_obj.IPAddress, iPAddress_IPAddressesRangeStartValue) == false &&
                    CommonMethods.IsSecondIPAddressBiggerOrEquals(accessRestrictionRuleObject_obj.IPAddress, iPAddress_IPAddressesRangeEndValue) == true
                  )
                {
                    MessageBox.Show(ServerStringFactory.GetString(207, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage));

                    return false;
                }
                // first value                               last value
                // -----------|------------range-------------|---------
                if (accessRestrictionRuleObject_obj.IPAddressesRangeStartValue != null &&
                    accessRestrictionRuleObject_obj.IPAddressesRangeEndValue != null &&
                   (  // Check is first value entering to previous range
                    (CommonMethods.IsSecondIPAddressBiggerOrEquals(iPAddress_IPAddressesRangeStartValue, accessRestrictionRuleObject_obj.IPAddressesRangeStartValue) == false &&
                     CommonMethods.IsSecondIPAddressBiggerOrEquals(iPAddress_IPAddressesRangeStartValue, accessRestrictionRuleObject_obj.IPAddressesRangeEndValue) == true)
                    ||// Check is last value entering to previous range
                    (CommonMethods.IsSecondIPAddressBiggerOrEquals(iPAddress_IPAddressesRangeEndValue, accessRestrictionRuleObject_obj.IPAddressesRangeStartValue) == false &&
                     CommonMethods.IsSecondIPAddressBiggerOrEquals(iPAddress_IPAddressesRangeEndValue, accessRestrictionRuleObject_obj.IPAddressesRangeEndValue) == true)
                    ||// Check for range covering (first value less than last value)
                    (CommonMethods.IsSecondIPAddressBiggerOrEquals(iPAddress_IPAddressesRangeStartValue, accessRestrictionRuleObject_obj.IPAddressesRangeStartValue) == true &&
                     CommonMethods.IsSecondIPAddressBiggerOrEquals(iPAddress_IPAddressesRangeEndValue, accessRestrictionRuleObject_obj.IPAddressesRangeEndValue) == false)
                   )
                  )
                {
                    MessageBox.Show(ServerStringFactory.GetString(208, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage));

                    return false;
                }
            }
        }

        return true;
    }

    void PrepareToSaveChanges()
    {
        if (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.Checked == false ||
            this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.Checked == true)
        {
            this.textBox_ServersAccessRestrictionRulesManager_IPAddress.Text = String.Empty;
        }

        if (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Checked == false ||
            this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.Checked == true)
        {
            this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue.Text = String.Empty;
            this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue.Text = String.Empty;
        }

        if (this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Checked == true ||
            this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.Checked == true)
        {
            MACAddress = this.MACAddressValueOneTextBox.Text + "-" + this.MACAddressValueTwoTextBox.Text + "-" + this.MACAddressValueThreeTextBox.Text + "-" + this.MACAddressValueFourTextBox.Text + "-" + this.MACAddressValueFiveTextBox.Text + "-" + this.MACAddressValueSixTextBox.Text;
        }
        else
        {
            this.MACAddressValueOneTextBox.Text = this.MACAddressValueTwoTextBox.Text =
            this.MACAddressValueThreeTextBox.Text = this.MACAddressValueFourTextBox.Text =
            this.MACAddressValueFiveTextBox.Text = this.MACAddressValueSixTextBox.Text = String.Empty;
        }
    }

    void EditExistingRule()
    {
        DataSet_ConnectingServiceDB.ServersAccessRestrictionRulesDataTable serversAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules;

        DataRow dataRow_EditedRecord = null;

        DateTime dateTime_CreationTime = DateTime.Now;

        dataRow_EditedRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules[EditedRecordIndex];

        dataRow_EditedRecord[serversAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn] = this.IPRangeStartValueTextBox.Text;
        dataRow_EditedRecord[serversAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn] = this.IPRangeEndValueTextBox.Text;
        dataRow_EditedRecord[serversAccessRestrictionRulesDataTable_obj.IPAddressColumn] = this.IPAddressTextBox.Text;
        dataRow_EditedRecord[serversAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn] = this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Checked;
        dataRow_EditedRecord[serversAccessRestrictionRulesDataTable_obj.MACAddressColumn] = MACAddress;
        dataRow_EditedRecord[serversAccessRestrictionRulesDataTable_obj.RuleTypeColumn] = this.comboBox_ServersAccessRestrictionRulesManager_RuleType.SelectedIndex;
        dataRow_EditedRecord[serversAccessRestrictionRulesDataTable_obj.CreationTimeColumn] = dateTime_CreationTime;

        IPAddress iPAddress_IPAddressesRangeStartValue = null;
        IPAddress iPAddress_IPAddressesRangeEndValue = null;
        IPAddress iPAddress_IPAddress = null;

        string string_IPAddressesRangeValue = String.Empty;

        if (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Checked == true)
        {
            string_IPAddressesRangeValue = this.IPRangeStartValueTextBox.Text + " - " + this.IPRangeEndValueTextBox.Text;
        }

        if (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Checked == true)
        {
            iPAddress_IPAddressesRangeStartValue = IPAddress.Parse(this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue.Text);

            iPAddress_IPAddressesRangeEndValue = IPAddress.Parse(this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue.Text);
        }

        if (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.Checked == true)
        {
            iPAddress_IPAddress = IPAddress.Parse(this.textBox_ServersAccessRestrictionRulesManager_IPAddress.Text);
        }


        ServersNetworkSecurity.EditExistingAccessRestrictionRule(iPAddress_IPAddressesRangeStartValue, iPAddress_IPAddressesRangeEndValue, iPAddress_IPAddress, MACAddress, this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Checked,
                                                                dateTime_CreationTime, this.comboBox_ServersAccessRestrictionRulesManager_RuleType.SelectedIndex, EditedRecordIndex);

        ObjCopy.obj_MainForm.EditServerAccessRestrictionRuleInListView(EditedRecordIndex, string_IPAddressesRangeValue, this.IPAddressTextBox.Text, MACAddress, this.comboBox_ServersAccessRestrictionRulesManager_RuleType.Text);

    }

    void AddNewRule()
    {
        DataSet_ConnectingServiceDB.ServersAccessRestrictionRulesDataTable serversAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules;

        ////////////////////////////////////////////////////////////////////////////////

        DataRow dataRow_NewRecord = null;

        dataRow_NewRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules.NewRow();

        int int_ServersAccessRestrictionRulesID = 0;

        for (int int_CycleCount = 0; ; int_CycleCount++)
        {
            if (serversAccessRestrictionRulesDataTable_obj.Rows.Count == 0) break;

            if (int_CycleCount >= serversAccessRestrictionRulesDataTable_obj.Rows.Count
                || (int)serversAccessRestrictionRulesDataTable_obj.Rows[int_CycleCount][serversAccessRestrictionRulesDataTable_obj.IDColumn] == int_ServersAccessRestrictionRulesID)
            {
                int_ServersAccessRestrictionRulesID++;
                int_CycleCount = -1;
                continue;
            }

            else if (int_CycleCount + 1 == serversAccessRestrictionRulesDataTable_obj.Rows.Count) break;
        }

        DateTime dateTime_CreationTime = DateTime.Now;

        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.IDColumn] = int_ServersAccessRestrictionRulesID;

        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn] = this.IPRangeStartValueTextBox.Text;
        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn] = this.IPRangeEndValueTextBox.Text;
        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.IPAddressColumn] = this.IPAddressTextBox.Text;
        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn] = this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Checked;
        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.MACAddressColumn] = MACAddress;
        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.RuleTypeColumn] = this.comboBox_ServersAccessRestrictionRulesManager_RuleType.SelectedIndex;
        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.CreationTimeColumn] = dateTime_CreationTime;
        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn] = true;

        ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules.Rows.Add(dataRow_NewRecord);

        string string_IPAddressesRangeValue = String.Empty;

        if (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Checked == true)
        {
            string_IPAddressesRangeValue = this.IPRangeStartValueTextBox.Text + " - " + this.IPRangeEndValueTextBox.Text;
        }

        IPAddress iPAddress_IPAddressesRangeStartValue = null;
        IPAddress iPAddress_IPAddressesRangeEndValue = null;
        IPAddress iPAddress_IPAddress = null;

        if (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Checked == true)
        {
            iPAddress_IPAddressesRangeStartValue = IPAddress.Parse(this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue.Text);

            iPAddress_IPAddressesRangeEndValue = IPAddress.Parse(this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue.Text);
        }

        if (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.Checked == true)
        {
            iPAddress_IPAddress = IPAddress.Parse(this.textBox_ServersAccessRestrictionRulesManager_IPAddress.Text);
        }

        ServersNetworkSecurity.AddNewAccessRestrictionRule(iPAddress_IPAddressesRangeStartValue, iPAddress_IPAddressesRangeEndValue, iPAddress_IPAddress, MACAddress, this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Checked,
                                                            dateTime_CreationTime, this.comboBox_ServersAccessRestrictionRulesManager_RuleType.SelectedIndex, true);

        ObjCopy.obj_MainForm.AddServerAccessRestrictionRuleToListView(string_IPAddressesRangeValue, this.IPAddressTextBox.Text, MACAddress, dateTime_CreationTime, this.comboBox_ServersAccessRestrictionRulesManager_RuleType.Text, true);

        this.Close();
    }


    private void button_ServersAccessRestrictionRulesManager_Add_Click(object sender, System.EventArgs e)
    {
        if (
            (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.Checked == true &&
            VerifySingleIPAddressToCorrectValue() == true)
            ||
            (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Checked == true &&
            VerifyIPAddressesRangeStartValueToCorrect() == true && VerifyIPAddressesRangeEndValueToCorrect() == true)
            ||
            (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.Checked == true)
          )
        {
            if (CheckForLogicalConfictsInRulesList(-1) == false) return;

            PrepareToSaveChanges();

            AddNewRule();

            //	 ObjCopy.obj_MainForm.InsertDataToLog(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(),
            // 											DateTime.Now.ToLongTimeString(), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(214, MainForm.CurrentLanguage));		

            this.Close();
        }
    }

    private void button_ServersAccessRestrictionRulesManager_Apply_Click(object sender, System.EventArgs e)
    {
        if (
            (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.Checked == true &&
            VerifySingleIPAddressToCorrectValue() == true)
            ||
            (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Checked == true &&
            VerifyIPAddressesRangeStartValueToCorrect() == true && VerifyIPAddressesRangeEndValueToCorrect() == true)
            ||
            (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.Checked == true)
          )
        {
            if (CheckForLogicalConfictsInRulesList(this.EditedRecordIndex) == false) return;

            PrepareToSaveChanges();

            EditExistingRule();

            this.Close();
        }
    }

    private void button_ServersAccessRestrictionRulesManager_Cancel_Click(object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule_CheckedChanged(object sender, System.EventArgs e)
    {
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Enabled = (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.Checked || this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Checked);
    }


    private void radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange_CheckedChanged(object sender, System.EventArgs e)
    {
        this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Enabled = true;

        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.Enabled = this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Checked;
        this.groupBox_ServersAccessRestrictionRulesManager_IPAddress.Enabled = this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.Checked;
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Enabled = (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.Checked || this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Checked);
    }

    private void radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress_CheckedChanged(object sender, System.EventArgs e)
    {
        this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Enabled = true;

        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.Enabled = this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Checked;
        this.groupBox_ServersAccessRestrictionRulesManager_IPAddress.Enabled = this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.Checked;
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Enabled = (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.Checked || this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Checked);
    }

    private void radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress_CheckedChanged(object sender, System.EventArgs e)
    {
        this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Enabled = false;

        this.groupBox_ServersAccessRestrictionRulesManager_IPRange.Enabled = this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange.Checked;
        this.groupBox_ServersAccessRestrictionRulesManager_IPAddress.Enabled = this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress.Checked;
        this.groupBox_ServersAccessRestrictionRulesManager_MACAddress.Enabled = (this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress.Checked || this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule.Checked);
    }


    private void textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne_Leave(object sender, System.EventArgs e)
    {
        CheckTextBoxForMissingDigits(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne);
    }

    private void textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo_Leave(object sender, System.EventArgs e)
    {
        CheckTextBoxForMissingDigits(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo);
    }

    private void textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree_Leave(object sender, System.EventArgs e)
    {
        CheckTextBoxForMissingDigits(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree);
    }

    private void textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour_Leave(object sender, System.EventArgs e)
    {
        CheckTextBoxForMissingDigits(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour);
    }

    private void textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive_Leave(object sender, System.EventArgs e)
    {
        CheckTextBoxForMissingDigits(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive);
    }

    private void textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix_Leave(object sender, System.EventArgs e)
    {
        CheckTextBoxForMissingDigits(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix);
    }

    private void textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne_TextChanged(object sender, System.EventArgs e)
    {
        CheckTextBoxForHexValue(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne);
    }

    private void textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo_TextChanged(object sender, System.EventArgs e)
    {
        CheckTextBoxForHexValue(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo);
    }

    private void textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree_TextChanged(object sender, System.EventArgs e)
    {
        CheckTextBoxForHexValue(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree);
    }

    private void textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour_TextChanged(object sender, System.EventArgs e)
    {
        CheckTextBoxForHexValue(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour);
    }

    private void textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive_TextChanged(object sender, System.EventArgs e)
    {
        CheckTextBoxForHexValue(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive);
    }

    private void textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix_TextChanged(object sender, System.EventArgs e)
    {
        CheckTextBoxForHexValue(this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix);
    }


    public void CheckTextBoxForMissingDigits(TextBox textBox_CheckedField)
    {
        if (textBox_CheckedField.Text.Length == 0) textBox_CheckedField.Text = "00";
        if (textBox_CheckedField.Text.Length == 1) textBox_CheckedField.Text = textBox_CheckedField.Text.Insert(0, "0");
    }


    public void CheckTextBoxForHexValue(TextBox textBox_CheckedField)
    {
        for (int int_CycleCount = 0; int_CycleCount != textBox_CheckedField.Text.Length; int_CycleCount++)
        {
            if (Uri.IsHexDigit(textBox_CheckedField.Text[int_CycleCount]) == false)
            {
                textBox_CheckedField.Text = textBox_CheckedField.Text.Remove(int_CycleCount, 1);
                textBox_CheckedField.SelectionStart = int_CycleCount;

                return;
            }
        }
    }


    #region Common Properties

    string string_MACAddress = String.Empty;

    string MACAddress
    {
        get
        {
            return string_MACAddress;
        }

        set
        {
            string_MACAddress = value;
        }
    }


    int int_EditedRecordIndex = 0;

    public int EditedRecordIndex
    {
        get
        {
            return int_EditedRecordIndex;
        }

        set
        {
            int_EditedRecordIndex = value;
        }
    }


    public RadioButton RestrictByIPRangeRadioButton
    {
        get
        {
            return this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPRange;
        }
    }

    public RadioButton RestrictByIPAddressRadioButton
    {
        get
        {
            return this.radioButton_ServersAccessRestrictionRulesManager_RestrictByIPAddress;
        }
    }

    public RadioButton RestrictByMACAddressRadioButton
    {
        get
        {
            return this.radioButton_ServersAccessRestrictionRulesManager_RestrictByMACAddress;
        }
    }


    public TextBox IPRangeStartValueTextBox
    {
        get
        {
            return this.textBox_ServersAccessRestrictionRulesManager_IPRangeStartValue;
        }
    }

    public TextBox IPRangeEndValueTextBox
    {
        get
        {
            return this.textBox_ServersAccessRestrictionRulesManager_IPRangeEndValue;
        }
    }


    public TextBox IPAddressTextBox
    {
        get
        {
            return this.textBox_ServersAccessRestrictionRulesManager_IPAddress;
        }
    }


    public TextBox MACAddressValueOneTextBox
    {
        get
        {
            return this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueOne;
        }
    }

    public TextBox MACAddressValueTwoTextBox
    {
        get
        {
            return this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueTwo;
        }
    }

    public TextBox MACAddressValueThreeTextBox
    {
        get
        {
            return this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueThree;
        }
    }

    public TextBox MACAddressValueFourTextBox
    {
        get
        {
            return this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFour;
        }
    }

    public TextBox MACAddressValueFiveTextBox
    {
        get
        {
            return this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueFive;
        }
    }

    public TextBox MACAddressValueSixTextBox
    {
        get
        {
            return this.textBox_ServersAccessRestrictionRulesManager_MACAddressValueSix;
        }
    }


    public CheckBox AddMACAdressToRuleCheckBox
    {
        get
        {
            return this.checkBox_ServersAccessRestrictionRulesManager_AddMACAdressToRule;
        }
    }

    public ComboBox RuleTypeComboBox
    {
        get
        {
            return this.comboBox_ServersAccessRestrictionRulesManager_RuleType;
        }
    }


    public Button ApplyButton
    {
        get
        {
            return this.button_ServersAccessRestrictionRulesManager_Apply;
        }

        set
        {
            this.button_ServersAccessRestrictionRulesManager_Apply = value;
        }
    }

    public Button OverrideCancelButton
    {
        get
        {
            return this.button_ServersAccessRestrictionRulesManager_Cancel;
        }

        set
        {
            this.button_ServersAccessRestrictionRulesManager_Cancel = value;
        }
    }

    public Button AddButton
    {
        get
        {
            return this.button_ServersAccessRestrictionRulesManager_Add;
        }

        set
        {
            this.button_ServersAccessRestrictionRulesManager_Add = value;
        }
    }


    public GroupBox RestrictByIPRangeGroupBox
    {
        get
        {
            return this.groupBox_ServersAccessRestrictionRulesManager_IPRange;
        }
    }

    public GroupBox RestrictByIPAddressGroupBox
    {
        get
        {
            return this.groupBox_ServersAccessRestrictionRulesManager_IPRange;
        }
    }

    public GroupBox RestrictByMACAddressGroupBox
    {
        get
        {
            return this.groupBox_ServersAccessRestrictionRulesManager_MACAddress;
        }
    }

    #endregion

}
