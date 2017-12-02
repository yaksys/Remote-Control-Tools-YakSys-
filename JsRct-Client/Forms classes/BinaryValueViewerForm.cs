using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctClient;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;

public partial class BinaryValueViewerForm : Form
{
    private System.ComponentModel.Design.ByteViewer viewBinaryValue_obj;

    public BinaryValueViewerForm(Form form_Owner, byte[] byteArray_Value)
    {
        InitializeComponent();

        this.viewBinaryValue_obj = new ByteViewer();
        this.viewBinaryValue_obj.Location = new Point(8, 46);
        this.viewBinaryValue_obj.Size = new Size(600, 338);
        this.viewBinaryValue_obj.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;

        this.viewBinaryValue_obj.SetBytes(byteArray_Value);

        this.Controls.Add(viewBinaryValue_obj);

        this.comboBox_BinaryValueViewerForm_ViewMode.SelectedIndex = 0;

        this.Owner = form_Owner;

        ChangeControlsLanguage();
    }

    void ChangeControlsLanguage()
    {
        this.Text = ClientStringFactory.GetString(671, ClientSettingsEnvironment.CurrentLanguage);

        this.label_BinaryValueViewerForm_ViewMode.Text = ClientStringFactory.GetString(670, ClientSettingsEnvironment.CurrentLanguage);

        this.label_BinaryValueViewerForm_Note.Text = ClientStringFactory.GetString(669, ClientSettingsEnvironment.CurrentLanguage);

        this.button_BinaryValueViewerForm_OK.Text = ClientStringFactory.GetString(175, ClientSettingsEnvironment.CurrentLanguage);
    }

    private void BinaryValueViewerForm_Load(object sender, EventArgs e)
    {

    }

    private void button_BinaryValueViewerForm_OK_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void comboBox_BinaryValueViewerForm_ViewMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayMode displayMode_obj;
        
        switch (this.comboBox_BinaryValueViewerForm_ViewMode.SelectedIndex)
        {
            case 0:
                displayMode_obj = DisplayMode.Hexdump;
                break;
            case 1:
                displayMode_obj = DisplayMode.Ansi;                
                break;
            case 2:
                displayMode_obj = DisplayMode.Unicode;
                break;
            default:
                displayMode_obj = DisplayMode.Hexdump;
                break;
        }

        this.viewBinaryValue_obj.SetDisplayMode(displayMode_obj);
    }

    private void BinaryValueViewerForm_Shown(object sender, EventArgs e)
    {
        this.Focus();
    }
}
