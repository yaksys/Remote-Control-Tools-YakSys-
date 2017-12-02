using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

public partial class Form_WorkingProgress : Form
{
    public Form_WorkingProgress(string [] stringArray_JobsDescription)
    {
        InitializeComponent();

        Form_Main.JobSuccessfullyCompletedEvent += new Form_Main.InstallationEventHandler(Form_Main_InstallationProcessSuccessfullyComplete);

        Form_Main.Standard_Error += new Form_Main.InstallationEventHandler(Form_Main_Standard_Error);

        Form_Main.Standard_ObjectAlreadyExists += new Form_Main.InstallationEventHandler(Form_Main_Standard_ObjectAlreadyExists);

        Form_Main.Standard_StepSuccessfullyCompleteEvent += new Form_Main.InstallationEventHandler(Form_Main_Standard_StepSuccessfullyCompleteEvent);

        Form_Main.Standard_NextStepSuccessfullyCompleteEvent += new Form_Main.NextStepCompletedEventHandler(Form_Main_Standard_NextStepSuccessfullyCompleteEvent);


        ListViewItem listViewItem_obj;

        foreach (string string_CurrentObject in stringArray_JobsDescription)
        {
            listViewItem_obj = new ListViewItem(string_CurrentObject);
            listViewItem_obj.SubItems.Add(string.Empty);

            this.listBox_WorkingProgress_Progress.Items.Add(listViewItem_obj);
        }

        ChangeControlsLanguage();
    }


    public void ChangeControlsLanguage()
    {
        this.Text = StringFactory.GetString(72, CommonEnvironment.CurrentLanguage);

        this.button_WorkingProgress_Cancel.Text = StringFactory.GetString(27, CommonEnvironment.CurrentLanguage);

        this.columnHeader_WorkingProgress_Operation.Text = StringFactory.GetString(70, CommonEnvironment.CurrentLanguage);

        this.columnHeader_WorkingProgress_OperationResult.Text = StringFactory.GetString(71, CommonEnvironment.CurrentLanguage);

    }

    public static string string_LatestOperationResult = string.Empty;


    public static string LatestOperationResult
    {
        get
        {
            return Form_WorkingProgress.string_LatestOperationResult;
        }

        set
        {
            Form_WorkingProgress.string_LatestOperationResult = value;
        }
    }

    void Form_Main_Standard_NextStepSuccessfullyCompleteEvent(int int_StepNumber, int StepsCount)
    {
        //this.Invoke((MethodInvoker)delegate
        {
            if (StepsCount < int_StepNumber)
            {
                StepsCount = int_StepNumber;
            }

            this.progressBar_WorkingProgress_Progree.Maximum = StepsCount;
            this.progressBar_WorkingProgress_Progree.Value = int_StepNumber;

            if (this.listBox_WorkingProgress_Progress.Items.Count >= int_StepNumber)
            {
                this.listBox_WorkingProgress_Progress.Items[int_StepNumber - 1].SubItems[1].Text = string_LatestOperationResult;
            }
        }//);
    }
    
    void Form_Main_Standard_StepSuccessfullyCompleteEvent(string string_Message)
    {
        Form_WorkingProgress.LatestOperationResult = "OK";
    }

    void Form_Main_Standard_ObjectAlreadyExists(string string_Message)
    {
        Form_WorkingProgress.LatestOperationResult = StringFactory.GetString(46, CommonEnvironment.CurrentLanguage);
    }

    void Form_Main_Standard_Error(string string_Message)
    {
        if (this.IsHandleCreated == false)
        {
            return;
        }

        //this.Invoke((MethodInvoker)delegate
        {
            MessageBox.Show(string_Message, StringFactory.GetString(72, CommonEnvironment.CurrentLanguage));
        }//);
        try
        {
            if (InstallationProcessAborted != null)
            {
                InstallationProcessAborted(StringFactory.GetString(47, CommonEnvironment.CurrentLanguage));
            }
        }
        catch
        {            
        }
        finally
        {
            this.CloseWindow();
        }
    }

    void Form_Main_InstallationProcessSuccessfullyComplete(string string_Message)
    {
        MessageBox.Show(string_Message, StringFactory.GetString(72, CommonEnvironment.CurrentLanguage));

        this.CloseWindow();
    }


    private void button_WorkingProgress_Cancel_Click(object sender, EventArgs e)
    {
        if (InstallationProcessAborted != null)
        {
            InstallationProcessAborted(StringFactory.GetString(48, CommonEnvironment.CurrentLanguage));
        }

        if (UninstallProcessAborted != null)
        {
            UninstallProcessAborted(StringFactory.GetString(49, CommonEnvironment.CurrentLanguage));
        }

        this.Close();

        this.CloseWindow();
    }

    private void CloseWindow()
    {        
        if (this.IsHandleCreated == false)
        {
            return;
        }

        //this.Invoke((MethodInvoker)delegate
        {
            this.Close();
        }//);
    }

    public delegate void InstallationEventHandler(string string_Message);
    public static event InstallationEventHandler InstallationProcessAborted;
    public static event InstallationEventHandler UninstallProcessAborted;

    private void Form_WorkingProgress_FormClosing(object sender, FormClosingEventArgs e)
    {
        Form_Main.JobSuccessfullyCompletedEvent -= new Form_Main.InstallationEventHandler(Form_Main_InstallationProcessSuccessfullyComplete);

        Form_Main.Standard_Error -= new Form_Main.InstallationEventHandler(Form_Main_Standard_Error);

        Form_Main.Standard_ObjectAlreadyExists -= new Form_Main.InstallationEventHandler(Form_Main_Standard_ObjectAlreadyExists);

        Form_Main.Standard_StepSuccessfullyCompleteEvent -= new Form_Main.InstallationEventHandler(Form_Main_Standard_StepSuccessfullyCompleteEvent);

        Form_Main.Standard_NextStepSuccessfullyCompleteEvent -= new Form_Main.NextStepCompletedEventHandler(Form_Main_Standard_NextStepSuccessfullyCompleteEvent);    
    }
}
