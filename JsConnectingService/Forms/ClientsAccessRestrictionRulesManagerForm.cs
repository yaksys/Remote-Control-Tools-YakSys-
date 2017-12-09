using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Data;
using YakSys;
using YakSysConnectingService;

public class ClientsAccessRestrictionRulesManagerForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.Button button_AccessRestrictionRulesManager_Add;
    private System.Windows.Forms.GroupBox groupBox_AccessRestrictionRulesManager_IPRange;
    private System.Windows.Forms.GroupBox groupBox_AccessRestrictionRulesManager_MACAddress;
    private System.Windows.Forms.CheckBox checkBox_AccessRestrictionRulesManager_AddMACAdressToRule;
    private System.Windows.Forms.GroupBox groupBox_AccessRestrictionRulesManager_IPAddress;
    private System.Windows.Forms.Button button_AccessRestrictionRulesManager_Cancel;
    private System.Windows.Forms.Button button_AccessRestrictionRulesManager_Apply;
    private System.Windows.Forms.RadioButton radioButton_AccessRestrictionRulesManager_RestrictByIPRange;
    private System.Windows.Forms.RadioButton radioButton_AccessRestrictionRulesManager_RestrictByIPAddress;
    private System.Windows.Forms.RadioButton radioButton_AccessRestrictionRulesManager_RestrictByMACAddress;
    private System.Windows.Forms.ComboBox comboBox_AccessRestrictionRulesManager_RuleType;
    private System.Windows.Forms.Label label_AccessRestrictionRulesManager_RuleType;
    private System.Windows.Forms.TextBox textBox_AccessRestrictionRulesManager_MACAddressValueOne;
    private System.Windows.Forms.Label label_AccessRestrictionRulesManager_IPRangeEndValue;
    private System.Windows.Forms.Label label_AccessRestrictionRulesManager_IPRangeStartValue;
    private System.Windows.Forms.TextBox textBox_AccessRestrictionRulesManager_MACAddressValueSix;
    private System.Windows.Forms.TextBox textBox_AccessRestrictionRulesManager_MACAddressValueFive;
    private System.Windows.Forms.TextBox textBox_AccessRestrictionRulesManager_MACAddressValueFour;
    private System.Windows.Forms.TextBox textBox_AccessRestrictionRulesManager_MACAddressValueThree;
    private System.Windows.Forms.TextBox textBox_AccessRestrictionRulesManager_MACAddressValueTwo;
    private System.Windows.Forms.Label label_AccessRestrictionRulesManager_MACAddress;
    private System.Windows.Forms.Label label_AccessRestrictionRulesManager_IPAddress;
    private System.Windows.Forms.TextBox textBox_AccessRestrictionRulesManager_IPRangeStartValue;
    private System.Windows.Forms.TextBox textBox_AccessRestrictionRulesManager_IPRangeEndValue;
    private System.Windows.Forms.TextBox textBox_AccessRestrictionRulesManager_IPAddress;
    private System.Windows.Forms.Label label_Dash1;
    private System.Windows.Forms.Label label_Dash2;
    private System.Windows.Forms.Label label_Dash3;
    private System.Windows.Forms.Label label_Dash4;
    private System.Windows.Forms.Label label_Dash5;

    private System.ComponentModel.Container components = null;

    void ChangeControlsLanguage()
    {
        this.Text = StringFactory.GetString(195, MainForm.CurrentLanguage);

        this.button_AccessRestrictionRulesManager_Add.Text = StringFactory.GetString(23, MainForm.CurrentLanguage);
        this.button_AccessRestrictionRulesManager_Apply.Text = StringFactory.GetString(79, MainForm.CurrentLanguage);
        this.button_AccessRestrictionRulesManager_Cancel.Text = StringFactory.GetString(86, MainForm.CurrentLanguage);

        this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Text = StringFactory.GetString(189, MainForm.CurrentLanguage);
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.Text = StringFactory.GetString(190, MainForm.CurrentLanguage);
        this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.Text = StringFactory.GetString(191, MainForm.CurrentLanguage);

        this.label_AccessRestrictionRulesManager_IPRangeStartValue.Text = StringFactory.GetString(192, MainForm.CurrentLanguage);
        this.label_AccessRestrictionRulesManager_IPRangeEndValue.Text = StringFactory.GetString(193, MainForm.CurrentLanguage);

        this.label_AccessRestrictionRulesManager_IPAddress.Text = StringFactory.GetString(185, MainForm.CurrentLanguage);

        this.label_AccessRestrictionRulesManager_MACAddress.Text = StringFactory.GetString(186, MainForm.CurrentLanguage);

        this.label_AccessRestrictionRulesManager_RuleType.Text = StringFactory.GetString(196, MainForm.CurrentLanguage);

        this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Text = StringFactory.GetString(194, MainForm.CurrentLanguage);

        this.comboBox_AccessRestrictionRulesManager_RuleType.Items.Clear();

        this.comboBox_AccessRestrictionRulesManager_RuleType.Items.AddRange(new object[] {
																							 StringFactory.GetString(197, MainForm.CurrentLanguage),
																							 StringFactory.GetString(198, MainForm.CurrentLanguage)});

        this.groupBox_AccessRestrictionRulesManager_IPRange.Text = StringFactory.GetString(227, MainForm.CurrentLanguage);
    }


    public ClientsAccessRestrictionRulesManagerForm()
    {
        InitializeComponent();

        ChangeControlsLanguage();

        this.comboBox_AccessRestrictionRulesManager_RuleType.SelectedIndex = 0;

        this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Checked = true;
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
        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ClientsAccessRestrictionRulesManagerForm));
        this.textBox_AccessRestrictionRulesManager_MACAddressValueOne = new System.Windows.Forms.TextBox();
        this.groupBox_AccessRestrictionRulesManager_IPRange = new System.Windows.Forms.GroupBox();
        this.textBox_AccessRestrictionRulesManager_IPRangeEndValue = new System.Windows.Forms.TextBox();
        this.textBox_AccessRestrictionRulesManager_IPRangeStartValue = new System.Windows.Forms.TextBox();
        this.label_AccessRestrictionRulesManager_IPRangeEndValue = new System.Windows.Forms.Label();
        this.label_AccessRestrictionRulesManager_IPRangeStartValue = new System.Windows.Forms.Label();
        this.groupBox_AccessRestrictionRulesManager_MACAddress = new System.Windows.Forms.GroupBox();
        this.label_Dash5 = new System.Windows.Forms.Label();
        this.label_Dash4 = new System.Windows.Forms.Label();
        this.label_Dash3 = new System.Windows.Forms.Label();
        this.label_Dash2 = new System.Windows.Forms.Label();
        this.label_Dash1 = new System.Windows.Forms.Label();
        this.textBox_AccessRestrictionRulesManager_MACAddressValueSix = new System.Windows.Forms.TextBox();
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFive = new System.Windows.Forms.TextBox();
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFour = new System.Windows.Forms.TextBox();
        this.textBox_AccessRestrictionRulesManager_MACAddressValueThree = new System.Windows.Forms.TextBox();
        this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo = new System.Windows.Forms.TextBox();
        this.label_AccessRestrictionRulesManager_MACAddress = new System.Windows.Forms.Label();
        this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule = new System.Windows.Forms.CheckBox();
        this.groupBox_AccessRestrictionRulesManager_IPAddress = new System.Windows.Forms.GroupBox();
        this.textBox_AccessRestrictionRulesManager_IPAddress = new System.Windows.Forms.TextBox();
        this.label_AccessRestrictionRulesManager_IPAddress = new System.Windows.Forms.Label();
        this.button_AccessRestrictionRulesManager_Cancel = new System.Windows.Forms.Button();
        this.button_AccessRestrictionRulesManager_Apply = new System.Windows.Forms.Button();
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange = new System.Windows.Forms.RadioButton();
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress = new System.Windows.Forms.RadioButton();
        this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress = new System.Windows.Forms.RadioButton();
        this.button_AccessRestrictionRulesManager_Add = new System.Windows.Forms.Button();
        this.comboBox_AccessRestrictionRulesManager_RuleType = new System.Windows.Forms.ComboBox();
        this.label_AccessRestrictionRulesManager_RuleType = new System.Windows.Forms.Label();
        this.groupBox_AccessRestrictionRulesManager_IPRange.SuspendLayout();
        this.groupBox_AccessRestrictionRulesManager_MACAddress.SuspendLayout();
        this.groupBox_AccessRestrictionRulesManager_IPAddress.SuspendLayout();
        this.SuspendLayout();
        // 
        // textBox_AccessRestrictionRulesManager_MACAddressValueOne
        // 
        this.textBox_AccessRestrictionRulesManager_MACAddressValueOne.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueOne.Location = new System.Drawing.Point(16, 48);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueOne.MaxLength = 2;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueOne.Name = "textBox_AccessRestrictionRulesManager_MACAddressValueOne";
        this.textBox_AccessRestrictionRulesManager_MACAddressValueOne.Size = new System.Drawing.Size(24, 20);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueOne.TabIndex = 3;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueOne.Text = "00";
        this.textBox_AccessRestrictionRulesManager_MACAddressValueOne.TextChanged += new System.EventHandler(this.textBox_AccessRestrictionRulesManager_MACAddressValueOne_TextChanged);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueOne.Leave += new System.EventHandler(this.textBox_AccessRestrictionRulesManager_MACAddressValueOne_Leave);
        // 
        // groupBox_AccessRestrictionRulesManager_IPRange
        // 
        this.groupBox_AccessRestrictionRulesManager_IPRange.Controls.Add(this.textBox_AccessRestrictionRulesManager_IPRangeEndValue);
        this.groupBox_AccessRestrictionRulesManager_IPRange.Controls.Add(this.textBox_AccessRestrictionRulesManager_IPRangeStartValue);
        this.groupBox_AccessRestrictionRulesManager_IPRange.Controls.Add(this.label_AccessRestrictionRulesManager_IPRangeEndValue);
        this.groupBox_AccessRestrictionRulesManager_IPRange.Controls.Add(this.label_AccessRestrictionRulesManager_IPRangeStartValue);
        this.groupBox_AccessRestrictionRulesManager_IPRange.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_AccessRestrictionRulesManager_IPRange.Location = new System.Drawing.Point(16, 32);
        this.groupBox_AccessRestrictionRulesManager_IPRange.Name = "groupBox_AccessRestrictionRulesManager_IPRange";
        this.groupBox_AccessRestrictionRulesManager_IPRange.Size = new System.Drawing.Size(280, 88);
        this.groupBox_AccessRestrictionRulesManager_IPRange.TabIndex = 5;
        this.groupBox_AccessRestrictionRulesManager_IPRange.TabStop = false;
        this.groupBox_AccessRestrictionRulesManager_IPRange.Text = "(Включая конечное значение)";
        // 
        // textBox_AccessRestrictionRulesManager_IPRangeEndValue
        // 
        this.textBox_AccessRestrictionRulesManager_IPRangeEndValue.Location = new System.Drawing.Point(144, 48);
        this.textBox_AccessRestrictionRulesManager_IPRangeEndValue.Name = "textBox_AccessRestrictionRulesManager_IPRangeEndValue";
        this.textBox_AccessRestrictionRulesManager_IPRangeEndValue.Size = new System.Drawing.Size(120, 20);
        this.textBox_AccessRestrictionRulesManager_IPRangeEndValue.TabIndex = 12;
        this.textBox_AccessRestrictionRulesManager_IPRangeEndValue.Text = String.Empty;
        // 
        // textBox_AccessRestrictionRulesManager_IPRangeStartValue
        // 
        this.textBox_AccessRestrictionRulesManager_IPRangeStartValue.Location = new System.Drawing.Point(16, 48);
        this.textBox_AccessRestrictionRulesManager_IPRangeStartValue.Name = "textBox_AccessRestrictionRulesManager_IPRangeStartValue";
        this.textBox_AccessRestrictionRulesManager_IPRangeStartValue.Size = new System.Drawing.Size(120, 20);
        this.textBox_AccessRestrictionRulesManager_IPRangeStartValue.TabIndex = 11;
        this.textBox_AccessRestrictionRulesManager_IPRangeStartValue.Text = String.Empty;
        // 
        // label_AccessRestrictionRulesManager_IPRangeEndValue
        // 
        this.label_AccessRestrictionRulesManager_IPRangeEndValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_AccessRestrictionRulesManager_IPRangeEndValue.Location = new System.Drawing.Point(144, 32);
        this.label_AccessRestrictionRulesManager_IPRangeEndValue.Name = "label_AccessRestrictionRulesManager_IPRangeEndValue";
        this.label_AccessRestrictionRulesManager_IPRangeEndValue.Size = new System.Drawing.Size(120, 16);
        this.label_AccessRestrictionRulesManager_IPRangeEndValue.TabIndex = 10;
        this.label_AccessRestrictionRulesManager_IPRangeEndValue.Text = "IP Range End Value:";
        // 
        // label_AccessRestrictionRulesManager_IPRangeStartValue
        // 
        this.label_AccessRestrictionRulesManager_IPRangeStartValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_AccessRestrictionRulesManager_IPRangeStartValue.Location = new System.Drawing.Point(16, 32);
        this.label_AccessRestrictionRulesManager_IPRangeStartValue.Name = "label_AccessRestrictionRulesManager_IPRangeStartValue";
        this.label_AccessRestrictionRulesManager_IPRangeStartValue.Size = new System.Drawing.Size(120, 16);
        this.label_AccessRestrictionRulesManager_IPRangeStartValue.TabIndex = 9;
        this.label_AccessRestrictionRulesManager_IPRangeStartValue.Text = "IP Range Start Value:";
        // 
        // groupBox_AccessRestrictionRulesManager_MACAddress
        // 
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Controls.Add(this.label_Dash5);
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Controls.Add(this.label_Dash4);
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Controls.Add(this.label_Dash3);
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Controls.Add(this.label_Dash2);
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Controls.Add(this.label_Dash1);
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Controls.Add(this.textBox_AccessRestrictionRulesManager_MACAddressValueSix);
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Controls.Add(this.textBox_AccessRestrictionRulesManager_MACAddressValueFive);
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Controls.Add(this.textBox_AccessRestrictionRulesManager_MACAddressValueFour);
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Controls.Add(this.textBox_AccessRestrictionRulesManager_MACAddressValueThree);
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Controls.Add(this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo);
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Controls.Add(this.label_AccessRestrictionRulesManager_MACAddress);
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Controls.Add(this.textBox_AccessRestrictionRulesManager_MACAddressValueOne);
        this.groupBox_AccessRestrictionRulesManager_MACAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Location = new System.Drawing.Point(504, 32);
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Name = "groupBox_AccessRestrictionRulesManager_MACAddress";
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Size = new System.Drawing.Size(216, 88);
        this.groupBox_AccessRestrictionRulesManager_MACAddress.TabIndex = 6;
        this.groupBox_AccessRestrictionRulesManager_MACAddress.TabStop = false;
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
        // textBox_AccessRestrictionRulesManager_MACAddressValueSix
        // 
        this.textBox_AccessRestrictionRulesManager_MACAddressValueSix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueSix.Location = new System.Drawing.Point(176, 48);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueSix.MaxLength = 2;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueSix.Name = "textBox_AccessRestrictionRulesManager_MACAddressValueSix";
        this.textBox_AccessRestrictionRulesManager_MACAddressValueSix.Size = new System.Drawing.Size(24, 20);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueSix.TabIndex = 13;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueSix.Text = "00";
        this.textBox_AccessRestrictionRulesManager_MACAddressValueSix.TextChanged += new System.EventHandler(this.textBox_AccessRestrictionRulesManager_MACAddressValueSix_TextChanged);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueSix.Leave += new System.EventHandler(this.textBox_AccessRestrictionRulesManager_MACAddressValueSix_Leave);
        // 
        // textBox_AccessRestrictionRulesManager_MACAddressValueFive
        // 
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFive.Location = new System.Drawing.Point(144, 48);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFive.MaxLength = 2;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFive.Name = "textBox_AccessRestrictionRulesManager_MACAddressValueFive";
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFive.Size = new System.Drawing.Size(24, 20);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFive.TabIndex = 12;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFive.Text = "00";
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFive.TextChanged += new System.EventHandler(this.textBox_AccessRestrictionRulesManager_MACAddressValueFive_TextChanged);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFive.Leave += new System.EventHandler(this.textBox_AccessRestrictionRulesManager_MACAddressValueFive_Leave);
        // 
        // textBox_AccessRestrictionRulesManager_MACAddressValueFour
        // 
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFour.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFour.Location = new System.Drawing.Point(112, 48);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFour.MaxLength = 2;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFour.Name = "textBox_AccessRestrictionRulesManager_MACAddressValueFour";
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFour.Size = new System.Drawing.Size(24, 20);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFour.TabIndex = 11;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFour.Text = "00";
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFour.TextChanged += new System.EventHandler(this.textBox_AccessRestrictionRulesManager_MACAddressValueFour_TextChanged);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueFour.Leave += new System.EventHandler(this.textBox_AccessRestrictionRulesManager_MACAddressValueFour_Leave);
        // 
        // textBox_AccessRestrictionRulesManager_MACAddressValueThree
        // 
        this.textBox_AccessRestrictionRulesManager_MACAddressValueThree.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueThree.Location = new System.Drawing.Point(80, 48);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueThree.MaxLength = 2;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueThree.Name = "textBox_AccessRestrictionRulesManager_MACAddressValueThree";
        this.textBox_AccessRestrictionRulesManager_MACAddressValueThree.Size = new System.Drawing.Size(24, 20);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueThree.TabIndex = 10;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueThree.Text = "00";
        this.textBox_AccessRestrictionRulesManager_MACAddressValueThree.TextChanged += new System.EventHandler(this.textBox_AccessRestrictionRulesManager_MACAddressValueThree_TextChanged);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueThree.Leave += new System.EventHandler(this.textBox_AccessRestrictionRulesManager_MACAddressValueThree_Leave);
        // 
        // textBox_AccessRestrictionRulesManager_MACAddressValueTwo
        // 
        this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo.Location = new System.Drawing.Point(48, 48);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo.MaxLength = 2;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo.Name = "textBox_AccessRestrictionRulesManager_MACAddressValueTwo";
        this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo.Size = new System.Drawing.Size(24, 20);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo.TabIndex = 9;
        this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo.Text = "00";
        this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo.TextChanged += new System.EventHandler(this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo_TextChanged);
        this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo.Leave += new System.EventHandler(this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo_Leave);
        // 
        // label_AccessRestrictionRulesManager_MACAddress
        // 
        this.label_AccessRestrictionRulesManager_MACAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_AccessRestrictionRulesManager_MACAddress.Location = new System.Drawing.Point(16, 32);
        this.label_AccessRestrictionRulesManager_MACAddress.Name = "label_AccessRestrictionRulesManager_MACAddress";
        this.label_AccessRestrictionRulesManager_MACAddress.Size = new System.Drawing.Size(120, 16);
        this.label_AccessRestrictionRulesManager_MACAddress.TabIndex = 8;
        this.label_AccessRestrictionRulesManager_MACAddress.Text = "MAC Address:";
        // 
        // checkBox_AccessRestrictionRulesManager_AddMACAdressToRule
        // 
        this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Location = new System.Drawing.Point(504, 128);
        this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Name = "checkBox_AccessRestrictionRulesManager_AddMACAdressToRule";
        this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Size = new System.Drawing.Size(216, 40);
        this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.TabIndex = 7;
        this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Text = "Complementary use MAC Address in Rule";
        this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.TextAlign = System.Drawing.ContentAlignment.TopLeft;
        this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.CheckedChanged += new System.EventHandler(this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule_CheckedChanged);
        // 
        // groupBox_AccessRestrictionRulesManager_IPAddress
        // 
        this.groupBox_AccessRestrictionRulesManager_IPAddress.Controls.Add(this.textBox_AccessRestrictionRulesManager_IPAddress);
        this.groupBox_AccessRestrictionRulesManager_IPAddress.Controls.Add(this.label_AccessRestrictionRulesManager_IPAddress);
        this.groupBox_AccessRestrictionRulesManager_IPAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_AccessRestrictionRulesManager_IPAddress.Location = new System.Drawing.Point(304, 32);
        this.groupBox_AccessRestrictionRulesManager_IPAddress.Name = "groupBox_AccessRestrictionRulesManager_IPAddress";
        this.groupBox_AccessRestrictionRulesManager_IPAddress.Size = new System.Drawing.Size(192, 88);
        this.groupBox_AccessRestrictionRulesManager_IPAddress.TabIndex = 8;
        this.groupBox_AccessRestrictionRulesManager_IPAddress.TabStop = false;
        // 
        // textBox_AccessRestrictionRulesManager_IPAddress
        // 
        this.textBox_AccessRestrictionRulesManager_IPAddress.Location = new System.Drawing.Point(16, 48);
        this.textBox_AccessRestrictionRulesManager_IPAddress.Name = "textBox_AccessRestrictionRulesManager_IPAddress";
        this.textBox_AccessRestrictionRulesManager_IPAddress.Size = new System.Drawing.Size(160, 20);
        this.textBox_AccessRestrictionRulesManager_IPAddress.TabIndex = 12;
        this.textBox_AccessRestrictionRulesManager_IPAddress.Text = String.Empty;
        // 
        // label_AccessRestrictionRulesManager_IPAddress
        // 
        this.label_AccessRestrictionRulesManager_IPAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_AccessRestrictionRulesManager_IPAddress.Location = new System.Drawing.Point(16, 32);
        this.label_AccessRestrictionRulesManager_IPAddress.Name = "label_AccessRestrictionRulesManager_IPAddress";
        this.label_AccessRestrictionRulesManager_IPAddress.Size = new System.Drawing.Size(160, 16);
        this.label_AccessRestrictionRulesManager_IPAddress.TabIndex = 8;
        this.label_AccessRestrictionRulesManager_IPAddress.Text = "IP Address:";
        // 
        // button_AccessRestrictionRulesManager_Cancel
        // 
        this.button_AccessRestrictionRulesManager_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_AccessRestrictionRulesManager_Cancel.Location = new System.Drawing.Point(208, 144);
        this.button_AccessRestrictionRulesManager_Cancel.Name = "button_AccessRestrictionRulesManager_Cancel";
        this.button_AccessRestrictionRulesManager_Cancel.Size = new System.Drawing.Size(88, 23);
        this.button_AccessRestrictionRulesManager_Cancel.TabIndex = 9;
        this.button_AccessRestrictionRulesManager_Cancel.Text = "Cancel";
        this.button_AccessRestrictionRulesManager_Cancel.Click += new System.EventHandler(this.button_AccessRestrictionRulesManager_Cancel_Click);
        // 
        // button_AccessRestrictionRulesManager_Apply
        // 
        this.button_AccessRestrictionRulesManager_Apply.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_AccessRestrictionRulesManager_Apply.Location = new System.Drawing.Point(112, 144);
        this.button_AccessRestrictionRulesManager_Apply.Name = "button_AccessRestrictionRulesManager_Apply";
        this.button_AccessRestrictionRulesManager_Apply.Size = new System.Drawing.Size(88, 23);
        this.button_AccessRestrictionRulesManager_Apply.TabIndex = 10;
        this.button_AccessRestrictionRulesManager_Apply.Text = "Apply";
        this.button_AccessRestrictionRulesManager_Apply.Click += new System.EventHandler(this.button_AccessRestrictionRulesManager_Apply_Click);
        // 
        // radioButton_AccessRestrictionRulesManager_RestrictByIPRange
        // 
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Location = new System.Drawing.Point(16, 16);
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Name = "radioButton_AccessRestrictionRulesManager_RestrictByIPRange";
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Size = new System.Drawing.Size(280, 16);
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.TabIndex = 17;
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Text = "Restrict Access by IP Range";
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.CheckedChanged += new System.EventHandler(this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange_CheckedChanged);
        // 
        // radioButton_AccessRestrictionRulesManager_RestrictByIPAddress
        // 
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.Location = new System.Drawing.Point(304, 16);
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.Name = "radioButton_AccessRestrictionRulesManager_RestrictByIPAddress";
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.Size = new System.Drawing.Size(192, 16);
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.TabIndex = 12;
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.Text = "Restrict Access by IP Address";
        this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.CheckedChanged += new System.EventHandler(this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress_CheckedChanged);
        // 
        // radioButton_AccessRestrictionRulesManager_RestrictByMACAddress
        // 
        this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.Location = new System.Drawing.Point(504, 16);
        this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.Name = "radioButton_AccessRestrictionRulesManager_RestrictByMACAddress";
        this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.Size = new System.Drawing.Size(216, 16);
        this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.TabIndex = 13;
        this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.Text = "Restrict by MAC Address";
        this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.CheckedChanged += new System.EventHandler(this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress_CheckedChanged);
        // 
        // button_AccessRestrictionRulesManager_Add
        // 
        this.button_AccessRestrictionRulesManager_Add.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_AccessRestrictionRulesManager_Add.Location = new System.Drawing.Point(16, 144);
        this.button_AccessRestrictionRulesManager_Add.Name = "button_AccessRestrictionRulesManager_Add";
        this.button_AccessRestrictionRulesManager_Add.Size = new System.Drawing.Size(88, 23);
        this.button_AccessRestrictionRulesManager_Add.TabIndex = 14;
        this.button_AccessRestrictionRulesManager_Add.Text = "Add";
        this.button_AccessRestrictionRulesManager_Add.Click += new System.EventHandler(this.button_AccessRestrictionRulesManager_Add_Click);
        // 
        // comboBox_AccessRestrictionRulesManager_RuleType
        // 
        this.comboBox_AccessRestrictionRulesManager_RuleType.Items.AddRange(new object[] {
																							 "Allow Connections",
																							 "Deny Connections"});
        this.comboBox_AccessRestrictionRulesManager_RuleType.Location = new System.Drawing.Point(320, 144);
        this.comboBox_AccessRestrictionRulesManager_RuleType.Name = "comboBox_AccessRestrictionRulesManager_RuleType";
        this.comboBox_AccessRestrictionRulesManager_RuleType.Size = new System.Drawing.Size(160, 21);
        this.comboBox_AccessRestrictionRulesManager_RuleType.TabIndex = 15;
        // 
        // label_AccessRestrictionRulesManager_RuleType
        // 
        this.label_AccessRestrictionRulesManager_RuleType.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_AccessRestrictionRulesManager_RuleType.Location = new System.Drawing.Point(320, 128);
        this.label_AccessRestrictionRulesManager_RuleType.Name = "label_AccessRestrictionRulesManager_RuleType";
        this.label_AccessRestrictionRulesManager_RuleType.Size = new System.Drawing.Size(80, 16);
        this.label_AccessRestrictionRulesManager_RuleType.TabIndex = 16;
        this.label_AccessRestrictionRulesManager_RuleType.Text = "Rule Type:";
        this.label_AccessRestrictionRulesManager_RuleType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
        // 
        // AccessRestrictionRulesManagerForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(738, 184);
        this.Controls.Add(this.label_AccessRestrictionRulesManager_RuleType);
        this.Controls.Add(this.comboBox_AccessRestrictionRulesManager_RuleType);
        this.Controls.Add(this.button_AccessRestrictionRulesManager_Add);
        this.Controls.Add(this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress);
        this.Controls.Add(this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress);
        this.Controls.Add(this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange);
        this.Controls.Add(this.button_AccessRestrictionRulesManager_Apply);
        this.Controls.Add(this.button_AccessRestrictionRulesManager_Cancel);
        this.Controls.Add(this.groupBox_AccessRestrictionRulesManager_IPAddress);
        this.Controls.Add(this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule);
        this.Controls.Add(this.groupBox_AccessRestrictionRulesManager_MACAddress);
        this.Controls.Add(this.groupBox_AccessRestrictionRulesManager_IPRange);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(744, 224);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(744, 216);
        this.Name = "AccessRestrictionRulesManagerForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Access Restriction Rules Manager";
        this.groupBox_AccessRestrictionRulesManager_IPRange.ResumeLayout(false);
        this.groupBox_AccessRestrictionRulesManager_MACAddress.ResumeLayout(false);
        this.groupBox_AccessRestrictionRulesManager_IPAddress.ResumeLayout(false);
        this.ResumeLayout(false);

    }
    #endregion

    bool VerifySingleIPAddressToCorrectValue()
    {
        try
        {
            string string_IPCheck = this.textBox_AccessRestrictionRulesManager_IPAddress.Text.Replace(".", "");

            if (string_IPCheck.Length + 3 != this.textBox_AccessRestrictionRulesManager_IPAddress.Text.Length ||
                this.textBox_AccessRestrictionRulesManager_IPAddress.Text.Length == 0 || string_IPCheck.Length > 12)
            {
                throw new FormatException();
            }

            IPAddress.Parse(this.textBox_AccessRestrictionRulesManager_IPAddress.Text);

            return true;
        }

        catch
        {
            MessageBox.Show(StringFactory.GetString(199, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return false;
        }
    }

    bool VerifyIPAddressesRangeStartValueToCorrect()
    {
        try
        {
            string string_IPCheck = this.textBox_AccessRestrictionRulesManager_IPRangeStartValue.Text.Replace(".", "");

            if (string_IPCheck.Length + 3 != this.textBox_AccessRestrictionRulesManager_IPRangeStartValue.Text.Length ||
               this.textBox_AccessRestrictionRulesManager_IPRangeStartValue.Text.Length == 0 || string_IPCheck.Length > 12)
            {
                throw new FormatException();
            }

            IPAddress.Parse(this.textBox_AccessRestrictionRulesManager_IPRangeStartValue.Text);

            return true;
        }

        catch
        {
            MessageBox.Show(StringFactory.GetString(200, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

            return false;
        }
    }

    bool VerifyIPAddressesRangeEndValueToCorrect()
    {
        try
        {
            string string_IPCheck = this.textBox_AccessRestrictionRulesManager_IPRangeEndValue.Text.Replace(".", "");

            if (string_IPCheck.Length + 3 != this.textBox_AccessRestrictionRulesManager_IPRangeEndValue.Text.Length ||
                this.textBox_AccessRestrictionRulesManager_IPRangeEndValue.Text.Length == 0 || string_IPCheck.Length > 12)
            {
                throw new FormatException();
            }

            IPAddress iPAddress_StartValue = IPAddress.Parse(this.textBox_AccessRestrictionRulesManager_IPRangeStartValue.Text);

            IPAddress iPAddress_EndValue = IPAddress.Parse(this.textBox_AccessRestrictionRulesManager_IPRangeEndValue.Text);

            if (CommonMethods.IsSecondIPAddressBiggerOrEquals(iPAddress_StartValue, iPAddress_EndValue) == false)
            {
                MessageBox.Show(StringFactory.GetString(202, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

                return false;
            };

            return true;
        }

        catch
        {
            MessageBox.Show(StringFactory.GetString(201, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

            return false;
        }
    }

    bool CheckForLogicalConfictsInRulesList(int int_MissRecord)
    {
        ClientsNetworkSecurity.AccessRestrictionRuleObject accessRestrictionRuleObject_obj = null;

        for (int int_CycleCount = 0; int_CycleCount != ClientsNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules.Count; int_CycleCount++)
        {
            if (int_MissRecord == int_CycleCount) continue;

            accessRestrictionRuleObject_obj = ClientsNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules[int_CycleCount];

            if (accessRestrictionRuleObject_obj.RuleType != this.comboBox_AccessRestrictionRulesManager_RuleType.SelectedIndex)
            {
                MessageBox.Show(StringFactory.GetString(203, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

                return false;
            }
        }

        if (this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Checked == true ||
            this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.Checked == true)
        {
            MACAddress = this.MACAddressValueOneTextBox.Text + "-" + this.MACAddressValueTwoTextBox.Text + "-" + this.MACAddressValueThreeTextBox.Text + "-" + this.MACAddressValueFourTextBox.Text + "-" + this.MACAddressValueFiveTextBox.Text + "-" + this.MACAddressValueSixTextBox.Text;

            for (int int_CycleCount = 0; int_CycleCount != ClientsNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules.Count; int_CycleCount++)
            {
                if (int_MissRecord == int_CycleCount) continue;

                accessRestrictionRuleObject_obj = ClientsNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules[int_CycleCount];

                if (this.MACAddress == accessRestrictionRuleObject_obj.MACAddress)
                {
                    MessageBox.Show(StringFactory.GetString(204, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

                    return false;
                }
            }
        }

        if (this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.Checked == true)
        {
            IPAddress iPAddress_IPAddress = IPAddress.Parse(this.textBox_AccessRestrictionRulesManager_IPAddress.Text);

            for (int int_CycleCount = 0; int_CycleCount != ClientsNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules.Count; int_CycleCount++)
            {
                if (int_MissRecord == int_CycleCount) continue;

                accessRestrictionRuleObject_obj = ClientsNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules[int_CycleCount];

                if (accessRestrictionRuleObject_obj.IPAddress != null &&
                iPAddress_IPAddress.Address == accessRestrictionRuleObject_obj.IPAddress.Address)
                {
                    MessageBox.Show(StringFactory.GetString(205, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

                    return false;
                }

                if (accessRestrictionRuleObject_obj.IPAddressesRangeStartValue != null &&
                   accessRestrictionRuleObject_obj.IPAddressesRangeEndValue != null &&

                   CommonMethods.IsSecondIPAddressBiggerOrEquals(iPAddress_IPAddress, accessRestrictionRuleObject_obj.IPAddressesRangeStartValue) == false &&
                   CommonMethods.IsSecondIPAddressBiggerOrEquals(iPAddress_IPAddress, accessRestrictionRuleObject_obj.IPAddressesRangeEndValue) == true
                  )
                {
                    MessageBox.Show(StringFactory.GetString(206, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

                    return false;
                }
            }
        }


        if (this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Checked == true)
        {
            IPAddress iPAddress_IPAddressesRangeStartValue = IPAddress.Parse(this.textBox_AccessRestrictionRulesManager_IPRangeStartValue.Text);

            IPAddress iPAddress_IPAddressesRangeEndValue = IPAddress.Parse(this.textBox_AccessRestrictionRulesManager_IPRangeEndValue.Text);

            for (int int_CycleCount = 0; int_CycleCount != ClientsNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules.Count; int_CycleCount++)
            {
                if (int_MissRecord == int_CycleCount) continue;

                accessRestrictionRuleObject_obj = ClientsNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules[int_CycleCount];

                if (accessRestrictionRuleObject_obj.IPAddress != null &&
                    CommonMethods.IsSecondIPAddressBiggerOrEquals(accessRestrictionRuleObject_obj.IPAddress, iPAddress_IPAddressesRangeStartValue) == false &&
                    CommonMethods.IsSecondIPAddressBiggerOrEquals(accessRestrictionRuleObject_obj.IPAddress, iPAddress_IPAddressesRangeEndValue) == true
                  )
                {
                    MessageBox.Show(StringFactory.GetString(207, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

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
                    MessageBox.Show(StringFactory.GetString(208, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

                    return false;
                }
            }
        }

        return true;
    }

    void PrepareToSaveChanges()
    {
        if (this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.Checked == false ||
            this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.Checked == true)
        {
            this.textBox_AccessRestrictionRulesManager_IPAddress.Text = String.Empty;
        }

        if (this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Checked == false ||
            this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.Checked == true)
        {
            this.textBox_AccessRestrictionRulesManager_IPRangeStartValue.Text = String.Empty;
            this.textBox_AccessRestrictionRulesManager_IPRangeEndValue.Text = String.Empty;
        }

        if (this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Checked == true ||
            this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.Checked == true)
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
        DataSet_ConnectingServiceDB.ClientsAccessRestrictionRulesDataTable clientsAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules;

        DataRow dataRow_EditedRecord = null;

        DateTime dateTime_CreationTime = DateTime.Now;

        dataRow_EditedRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules[EditedRecordIndex];

        dataRow_EditedRecord[clientsAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn] = this.IPRangeStartValueTextBox.Text;
        dataRow_EditedRecord[clientsAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn] = this.IPRangeEndValueTextBox.Text;
        dataRow_EditedRecord[clientsAccessRestrictionRulesDataTable_obj.IPAddressColumn] = this.IPAddressTextBox.Text;
        dataRow_EditedRecord[clientsAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn] = this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Checked;
        dataRow_EditedRecord[clientsAccessRestrictionRulesDataTable_obj.MACAddressColumn] = MACAddress;
        dataRow_EditedRecord[clientsAccessRestrictionRulesDataTable_obj.RuleTypeColumn] = this.comboBox_AccessRestrictionRulesManager_RuleType.SelectedIndex;
        dataRow_EditedRecord[clientsAccessRestrictionRulesDataTable_obj.CreationTimeColumn] = dateTime_CreationTime;

        IPAddress iPAddress_IPAddressesRangeStartValue = null;
        IPAddress iPAddress_IPAddressesRangeEndValue = null;
        IPAddress iPAddress_IPAddress = null;

        string string_IPAddressesRangeValue = String.Empty;

        if (this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Checked == true)
        {
            string_IPAddressesRangeValue = this.IPRangeStartValueTextBox.Text + " - " + this.IPRangeEndValueTextBox.Text;
        }

        if (this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Checked == true)
        {
            iPAddress_IPAddressesRangeStartValue = IPAddress.Parse(this.textBox_AccessRestrictionRulesManager_IPRangeStartValue.Text);

            iPAddress_IPAddressesRangeEndValue = IPAddress.Parse(this.textBox_AccessRestrictionRulesManager_IPRangeEndValue.Text);
        }

        if (this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.Checked == true)
        {
            iPAddress_IPAddress = IPAddress.Parse(this.textBox_AccessRestrictionRulesManager_IPAddress.Text);
        }

        ClientsNetworkSecurity.EditExistingAccessRestrictionRule(iPAddress_IPAddressesRangeStartValue, iPAddress_IPAddressesRangeEndValue, iPAddress_IPAddress, MACAddress, this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Checked,
                                                                dateTime_CreationTime, this.comboBox_AccessRestrictionRulesManager_RuleType.SelectedIndex, EditedRecordIndex);

        ObjCopy.obj_MainForm.EditClientAccessRestrictionRuleInListView(EditedRecordIndex, string_IPAddressesRangeValue, this.IPAddressTextBox.Text, MACAddress, this.comboBox_AccessRestrictionRulesManager_RuleType.Text);
    }

    void AddNewRule()
    {
        DataSet_ConnectingServiceDB.ClientsAccessRestrictionRulesDataTable clientsAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules;

        ////////////////////////////////////////////////////////////////////////////////

        DataRow dataRow_NewRecord = null;

        dataRow_NewRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules.NewRow();

        int int_AccessRestrictionRulesID = 0;

        for (int int_CycleCount = 0; ; int_CycleCount++)
        {
            if (clientsAccessRestrictionRulesDataTable_obj.Rows.Count == 0) break;

            if (int_CycleCount >= clientsAccessRestrictionRulesDataTable_obj.Rows.Count
                || (int)clientsAccessRestrictionRulesDataTable_obj.Rows[int_CycleCount][clientsAccessRestrictionRulesDataTable_obj.IDColumn] == int_AccessRestrictionRulesID)
            {
                int_AccessRestrictionRulesID++;
                int_CycleCount = -1;
                continue;
            }

            else if (int_CycleCount + 1 == clientsAccessRestrictionRulesDataTable_obj.Rows.Count) break;
        }

        DateTime dateTime_CreationTime = DateTime.Now;

        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.IDColumn] = int_AccessRestrictionRulesID;

        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn] = this.IPRangeStartValueTextBox.Text;
        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn] = this.IPRangeEndValueTextBox.Text;
        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.IPAddressColumn] = this.IPAddressTextBox.Text;
        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn] = this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Checked;
        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.MACAddressColumn] = MACAddress;
        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.RuleTypeColumn] = this.comboBox_AccessRestrictionRulesManager_RuleType.SelectedIndex;
        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.CreationTimeColumn] = dateTime_CreationTime;
        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn] = true;

        ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules.Rows.Add(dataRow_NewRecord);

        string string_IPAddressesRangeValue = String.Empty;

        if (this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Checked == true)
        {
            string_IPAddressesRangeValue = this.IPRangeStartValueTextBox.Text + " - " + this.IPRangeEndValueTextBox.Text;
        }

        IPAddress iPAddress_IPAddressesRangeStartValue = null;
        IPAddress iPAddress_IPAddressesRangeEndValue = null;
        IPAddress iPAddress_IPAddress = null;

        if (this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Checked == true)
        {
            iPAddress_IPAddressesRangeStartValue = IPAddress.Parse(this.textBox_AccessRestrictionRulesManager_IPRangeStartValue.Text);

            iPAddress_IPAddressesRangeEndValue = IPAddress.Parse(this.textBox_AccessRestrictionRulesManager_IPRangeEndValue.Text);
        }

        if (this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.Checked == true)
        {
            iPAddress_IPAddress = IPAddress.Parse(this.textBox_AccessRestrictionRulesManager_IPAddress.Text);
        }

        ClientsNetworkSecurity.AddNewAccessRestrictionRule(iPAddress_IPAddressesRangeStartValue, iPAddress_IPAddressesRangeEndValue, iPAddress_IPAddress, MACAddress, this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Checked,
                                                            dateTime_CreationTime, this.comboBox_AccessRestrictionRulesManager_RuleType.SelectedIndex, true);

        ObjCopy.obj_MainForm.AddClientAccessRestrictionRuleToListView(string_IPAddressesRangeValue, this.IPAddressTextBox.Text, MACAddress, dateTime_CreationTime, this.comboBox_AccessRestrictionRulesManager_RuleType.Text, true);

        this.Close();
    }


    private void button_AccessRestrictionRulesManager_Add_Click(object sender, System.EventArgs e)
    {
        if (
            (this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.Checked == true &&
            VerifySingleIPAddressToCorrectValue() == true)
            ||
            (this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Checked == true &&
            VerifyIPAddressesRangeStartValueToCorrect() == true && VerifyIPAddressesRangeEndValueToCorrect() == true)
            ||
            (this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.Checked == true)
          )
        {
            if (CheckForLogicalConfictsInRulesList(-1) == false) return;

            PrepareToSaveChanges();

            AddNewRule();

            #region Call Log Event

            ConnectingServiceLogsEvents.NewClientsLogRecordEvent(StringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "", "", StringFactory.GetString(1, MainForm.CurrentLanguage), StringFactory.GetString(214, MainForm.CurrentLanguage), false);

            #endregion

            this.Close();
        }
    }


    private void button_AccessRestrictionRulesManager_Apply_Click(object sender, System.EventArgs e)
    {
        if (
            (this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.Checked == true &&
            VerifySingleIPAddressToCorrectValue() == true)
            ||
            (this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Checked == true &&
            VerifyIPAddressesRangeStartValueToCorrect() == true && VerifyIPAddressesRangeEndValueToCorrect() == true)
            ||
            (this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.Checked == true)
          )
        {
            if (CheckForLogicalConfictsInRulesList(this.EditedRecordIndex) == false) return;

            PrepareToSaveChanges();

            EditExistingRule();

            this.Close();
        }
    }


    private void button_AccessRestrictionRulesManager_Cancel_Click(object sender, System.EventArgs e)
    {
        this.Close();
    }


    private void checkBox_AccessRestrictionRulesManager_AddMACAdressToRule_CheckedChanged(object sender, System.EventArgs e)
    {
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Enabled = (this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.Checked || this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Checked);
    }


    private void radioButton_AccessRestrictionRulesManager_RestrictByIPRange_CheckedChanged(object sender, System.EventArgs e)
    {
        this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Enabled = true;

        this.groupBox_AccessRestrictionRulesManager_IPRange.Enabled = this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Checked;
        this.groupBox_AccessRestrictionRulesManager_IPAddress.Enabled = this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.Checked;
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Enabled = (this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.Checked || this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Checked);
    }

    private void radioButton_AccessRestrictionRulesManager_RestrictByIPAddress_CheckedChanged(object sender, System.EventArgs e)
    {
        this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Enabled = true;

        this.groupBox_AccessRestrictionRulesManager_IPRange.Enabled = this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Checked;
        this.groupBox_AccessRestrictionRulesManager_IPAddress.Enabled = this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.Checked;
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Enabled = (this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.Checked || this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Checked);
    }

    private void radioButton_AccessRestrictionRulesManager_RestrictByMACAddress_CheckedChanged(object sender, System.EventArgs e)
    {
        this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Enabled = false;

        this.groupBox_AccessRestrictionRulesManager_IPRange.Enabled = this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange.Checked;
        this.groupBox_AccessRestrictionRulesManager_IPAddress.Enabled = this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress.Checked;
        this.groupBox_AccessRestrictionRulesManager_MACAddress.Enabled = (this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress.Checked || this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule.Checked);
    }


    private void textBox_AccessRestrictionRulesManager_MACAddressValueOne_Leave(object sender, System.EventArgs e)
    {
        CheckTextBoxForMissingDigits(this.textBox_AccessRestrictionRulesManager_MACAddressValueOne);
    }

    private void textBox_AccessRestrictionRulesManager_MACAddressValueTwo_Leave(object sender, System.EventArgs e)
    {
        CheckTextBoxForMissingDigits(this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo);
    }

    private void textBox_AccessRestrictionRulesManager_MACAddressValueThree_Leave(object sender, System.EventArgs e)
    {
        CheckTextBoxForMissingDigits(this.textBox_AccessRestrictionRulesManager_MACAddressValueThree);
    }

    private void textBox_AccessRestrictionRulesManager_MACAddressValueFour_Leave(object sender, System.EventArgs e)
    {
        CheckTextBoxForMissingDigits(this.textBox_AccessRestrictionRulesManager_MACAddressValueFour);
    }

    private void textBox_AccessRestrictionRulesManager_MACAddressValueFive_Leave(object sender, System.EventArgs e)
    {
        CheckTextBoxForMissingDigits(this.textBox_AccessRestrictionRulesManager_MACAddressValueFive);
    }

    private void textBox_AccessRestrictionRulesManager_MACAddressValueSix_Leave(object sender, System.EventArgs e)
    {
        CheckTextBoxForMissingDigits(this.textBox_AccessRestrictionRulesManager_MACAddressValueSix);
    }

    private void textBox_AccessRestrictionRulesManager_MACAddressValueOne_TextChanged(object sender, System.EventArgs e)
    {
        CheckTextBoxForHexValue(this.textBox_AccessRestrictionRulesManager_MACAddressValueOne);
    }

    private void textBox_AccessRestrictionRulesManager_MACAddressValueTwo_TextChanged(object sender, System.EventArgs e)
    {
        CheckTextBoxForHexValue(this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo);
    }

    private void textBox_AccessRestrictionRulesManager_MACAddressValueThree_TextChanged(object sender, System.EventArgs e)
    {
        CheckTextBoxForHexValue(this.textBox_AccessRestrictionRulesManager_MACAddressValueThree);
    }

    private void textBox_AccessRestrictionRulesManager_MACAddressValueFour_TextChanged(object sender, System.EventArgs e)
    {
        CheckTextBoxForHexValue(this.textBox_AccessRestrictionRulesManager_MACAddressValueFour);
    }

    private void textBox_AccessRestrictionRulesManager_MACAddressValueFive_TextChanged(object sender, System.EventArgs e)
    {
        CheckTextBoxForHexValue(this.textBox_AccessRestrictionRulesManager_MACAddressValueFive);
    }

    private void textBox_AccessRestrictionRulesManager_MACAddressValueSix_TextChanged(object sender, System.EventArgs e)
    {
        CheckTextBoxForHexValue(this.textBox_AccessRestrictionRulesManager_MACAddressValueSix);
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
            return this.radioButton_AccessRestrictionRulesManager_RestrictByIPRange;
        }
    }

    public RadioButton RestrictByIPAddressRadioButton
    {
        get
        {
            return this.radioButton_AccessRestrictionRulesManager_RestrictByIPAddress;
        }
    }

    public RadioButton RestrictByMACAddressRadioButton
    {
        get
        {
            return this.radioButton_AccessRestrictionRulesManager_RestrictByMACAddress;
        }
    }


    public TextBox IPRangeStartValueTextBox
    {
        get
        {
            return this.textBox_AccessRestrictionRulesManager_IPRangeStartValue;
        }
    }

    public TextBox IPRangeEndValueTextBox
    {
        get
        {
            return this.textBox_AccessRestrictionRulesManager_IPRangeEndValue;
        }
    }


    public TextBox IPAddressTextBox
    {
        get
        {
            return this.textBox_AccessRestrictionRulesManager_IPAddress;
        }
    }


    public TextBox MACAddressValueOneTextBox
    {
        get
        {
            return this.textBox_AccessRestrictionRulesManager_MACAddressValueOne;
        }
    }

    public TextBox MACAddressValueTwoTextBox
    {
        get
        {
            return this.textBox_AccessRestrictionRulesManager_MACAddressValueTwo;
        }
    }

    public TextBox MACAddressValueThreeTextBox
    {
        get
        {
            return this.textBox_AccessRestrictionRulesManager_MACAddressValueThree;
        }
    }

    public TextBox MACAddressValueFourTextBox
    {
        get
        {
            return this.textBox_AccessRestrictionRulesManager_MACAddressValueFour;
        }
    }

    public TextBox MACAddressValueFiveTextBox
    {
        get
        {
            return this.textBox_AccessRestrictionRulesManager_MACAddressValueFive;
        }
    }

    public TextBox MACAddressValueSixTextBox
    {
        get
        {
            return this.textBox_AccessRestrictionRulesManager_MACAddressValueSix;
        }
    }


    public CheckBox AddMACAdressToRuleCheckBox
    {
        get
        {
            return this.checkBox_AccessRestrictionRulesManager_AddMACAdressToRule;
        }
    }

    public ComboBox RuleTypeComboBox
    {
        get
        {
            return this.comboBox_AccessRestrictionRulesManager_RuleType;
        }
    }


    public Button ApplyButton
    {
        get
        {
            return this.button_AccessRestrictionRulesManager_Apply;
        }

        set
        {
            this.button_AccessRestrictionRulesManager_Apply = value;
        }
    }

    public Button OverrideCancelButton
    {
        get
        {
            return this.button_AccessRestrictionRulesManager_Cancel;
        }

        set
        {
            this.button_AccessRestrictionRulesManager_Cancel = value;
        }
    }

    public Button AddButton
    {
        get
        {
            return this.button_AccessRestrictionRulesManager_Add;
        }

        set
        {
            this.button_AccessRestrictionRulesManager_Add = value;
        }
    }


    public GroupBox RestrictByIPRangeGroupBox
    {
        get
        {
            return this.groupBox_AccessRestrictionRulesManager_IPRange;
        }
    }

    public GroupBox RestrictByIPAddressGroupBox
    {
        get
        {
            return this.groupBox_AccessRestrictionRulesManager_IPRange;
        }
    }

    public GroupBox RestrictByMACAddressGroupBox
    {
        get
        {
            return this.groupBox_AccessRestrictionRulesManager_MACAddress;
        }
    }

    #endregion

}
