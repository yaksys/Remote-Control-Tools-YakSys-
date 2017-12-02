using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace Unhide_JurikSoft_Server
{
	public class UnhideJurikSoftServerForm : System.Windows.Forms.Form
	{
		[DllImport("User32.dll", CharSet=CharSet.Ansi)]
		static extern bool ShowWindow(IntPtr intptr_WindowHandle, int int_CmdShow);

		[DllImport("User32.dll", CharSet=CharSet.Ansi)]
		static extern IntPtr FindWindow(string string_ClassName, string string_WindowName);


		private System.Windows.Forms.Button button_Unhide;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UnhideJurikSoftServerForm()
		{
			
			InitializeComponent();

			Application.EnableVisualStyles();
			
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnhideJurikSoftServerForm));
            this.button_Unhide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Unhide
            // 
            this.button_Unhide.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Unhide.Location = new System.Drawing.Point(16, 24);
            this.button_Unhide.Name = "button_Unhide";
            this.button_Unhide.Size = new System.Drawing.Size(256, 23);
            this.button_Unhide.TabIndex = 0;
            this.button_Unhide.Text = "Вывести JurikSoft Server из Скрытого Режима";
            this.button_Unhide.Click += new System.EventHandler(this.button_Unhide_Click);
            // 
            // UnhideJurikSoftServerForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(290, 72);
            this.Controls.Add(this.button_Unhide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(296, 104);
            this.MinimumSize = new System.Drawing.Size(296, 104);
            this.Name = "UnhideJurikSoftServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Раскрыть JurikSoft Server";
            this.ResumeLayout(false);

		}
		#endregion

		
		[STAThread]
		static void Main() 
		{
			Application.Run(new UnhideJurikSoftServerForm());
		}

		private void button_Unhide_Click(object sender, System.EventArgs e)
		{
			int int_ShowCommand = 1;

			IntPtr intPtr_ReturnedHandel = FindWindow(null, "JurikSoft Server");

			if(intPtr_ReturnedHandel != IntPtr.Zero) ShowWindow(intPtr_ReturnedHandel, int_ShowCommand);
		}

	}
}
