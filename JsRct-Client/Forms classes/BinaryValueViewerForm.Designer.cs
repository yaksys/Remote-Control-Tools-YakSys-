    partial class BinaryValueViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BinaryValueViewerForm));
            this.button_BinaryValueViewerForm_OK = new System.Windows.Forms.Button();
            this.comboBox_BinaryValueViewerForm_ViewMode = new System.Windows.Forms.ComboBox();
            this.label_BinaryValueViewerForm_ViewMode = new System.Windows.Forms.Label();
            this.label_BinaryValueViewerForm_Note = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_BinaryValueViewerForm_OK
            // 
            this.button_BinaryValueViewerForm_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_BinaryValueViewerForm_OK.Location = new System.Drawing.Point(285, 382);
            this.button_BinaryValueViewerForm_OK.Name = "button_BinaryValueViewerForm_OK";
            this.button_BinaryValueViewerForm_OK.Size = new System.Drawing.Size(75, 23);
            this.button_BinaryValueViewerForm_OK.TabIndex = 0;
            this.button_BinaryValueViewerForm_OK.Text = "OK";
            this.button_BinaryValueViewerForm_OK.UseVisualStyleBackColor = false;
            this.button_BinaryValueViewerForm_OK.Click += new System.EventHandler(this.button_BinaryValueViewerForm_OK_Click);
            // 
            // comboBox_BinaryValueViewerForm_ViewMode
            // 
            this.comboBox_BinaryValueViewerForm_ViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_BinaryValueViewerForm_ViewMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_BinaryValueViewerForm_ViewMode.FormattingEnabled = true;
            this.comboBox_BinaryValueViewerForm_ViewMode.Items.AddRange(new object[] {
            "HEX",
            "ANSI",
            "Unicode"});
            this.comboBox_BinaryValueViewerForm_ViewMode.Location = new System.Drawing.Point(511, 12);
            this.comboBox_BinaryValueViewerForm_ViewMode.Name = "comboBox_BinaryValueViewerForm_ViewMode";
            this.comboBox_BinaryValueViewerForm_ViewMode.Size = new System.Drawing.Size(121, 21);
            this.comboBox_BinaryValueViewerForm_ViewMode.TabIndex = 1;
            this.comboBox_BinaryValueViewerForm_ViewMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_BinaryValueViewerForm_ViewMode_SelectedIndexChanged);
            // 
            // label_BinaryValueViewerForm_ViewMode
            // 
            this.label_BinaryValueViewerForm_ViewMode.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label_BinaryValueViewerForm_ViewMode.Location = new System.Drawing.Point(384, 10);
            this.label_BinaryValueViewerForm_ViewMode.Name = "label_BinaryValueViewerForm_ViewMode";
            this.label_BinaryValueViewerForm_ViewMode.Size = new System.Drawing.Size(121, 23);
            this.label_BinaryValueViewerForm_ViewMode.TabIndex = 2;
            this.label_BinaryValueViewerForm_ViewMode.Text = "View Mode:";
            this.label_BinaryValueViewerForm_ViewMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_BinaryValueViewerForm_Note
            // 
            this.label_BinaryValueViewerForm_Note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_BinaryValueViewerForm_Note.Location = new System.Drawing.Point(4, 371);
            this.label_BinaryValueViewerForm_Note.Name = "label_BinaryValueViewerForm_Note";
            this.label_BinaryValueViewerForm_Note.Size = new System.Drawing.Size(243, 23);
            this.label_BinaryValueViewerForm_Note.TabIndex = 3;
            this.label_BinaryValueViewerForm_Note.Text = "You can only view this binary value";
            this.label_BinaryValueViewerForm_Note.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BinaryValueViewerForm
            // 
            this.AcceptButton = this.button_BinaryValueViewerForm_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 414);
            this.Controls.Add(this.label_BinaryValueViewerForm_Note);
            this.Controls.Add(this.label_BinaryValueViewerForm_ViewMode);
            this.Controls.Add(this.comboBox_BinaryValueViewerForm_ViewMode);
            this.Controls.Add(this.button_BinaryValueViewerForm_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(658, 446);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(658, 446);
            this.Name = "BinaryValueViewerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.BinaryValueViewerForm_Shown);
            this.Load += new System.EventHandler(this.BinaryValueViewerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_BinaryValueViewerForm_OK;
        private System.Windows.Forms.ComboBox comboBox_BinaryValueViewerForm_ViewMode;
        private System.Windows.Forms.Label label_BinaryValueViewerForm_ViewMode;
        private System.Windows.Forms.Label label_BinaryValueViewerForm_Note;
    }
