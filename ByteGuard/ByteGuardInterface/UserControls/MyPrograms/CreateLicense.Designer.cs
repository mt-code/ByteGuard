namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    partial class CreateLicense
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ThemeContainer = new ByteGuardInterface.Theme.ThemeContainer();
            this.LineSeperator3 = new ByteGuardInterface.Theme.LineSeparator();
            this.LineSeperator2 = new ByteGuardInterface.Theme.LineSeparator();
            this.LineSeperator1 = new ByteGuardInterface.Theme.LineSeparator();
            this.DropDownLicenseType = new System.Windows.Forms.ComboBox();
            this.LabelLicenseType = new System.Windows.Forms.Label();
            this.ButtonCreateLicense = new System.Windows.Forms.Button();
            this.CheckBoxCopyToClipboard = new System.Windows.Forms.CheckBox();
            this.TextBoxTrackingDescription = new System.Windows.Forms.TextBox();
            this.LabelTrackingDesc = new System.Windows.Forms.Label();
            this.TextBoxValue = new System.Windows.Forms.NumericUpDown();
            this.LabelDuration = new System.Windows.Forms.Label();
            this.TextBoxLicenseCode = new System.Windows.Forms.TextBox();
            this.LabelGeneratedCode = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ThemeContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxValue)).BeginInit();
            this.SuspendLayout();
            // 
            // ThemeContainer
            // 
            this.ThemeContainer.Controls.Add(this.LineSeperator3);
            this.ThemeContainer.Controls.Add(this.LineSeperator2);
            this.ThemeContainer.Controls.Add(this.LineSeperator1);
            this.ThemeContainer.Controls.Add(this.DropDownLicenseType);
            this.ThemeContainer.Controls.Add(this.LabelLicenseType);
            this.ThemeContainer.Controls.Add(this.ButtonCreateLicense);
            this.ThemeContainer.Controls.Add(this.CheckBoxCopyToClipboard);
            this.ThemeContainer.Controls.Add(this.TextBoxTrackingDescription);
            this.ThemeContainer.Controls.Add(this.LabelTrackingDesc);
            this.ThemeContainer.Controls.Add(this.TextBoxValue);
            this.ThemeContainer.Controls.Add(this.LabelDuration);
            this.ThemeContainer.Controls.Add(this.TextBoxLicenseCode);
            this.ThemeContainer.Controls.Add(this.LabelGeneratedCode);
            this.ThemeContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThemeContainer.Location = new System.Drawing.Point(0, 0);
            this.ThemeContainer.Name = "ThemeContainer";
            this.ThemeContainer.Size = new System.Drawing.Size(231, 331);
            this.ThemeContainer.TabIndex = 0;
            this.ThemeContainer.Text = "ThemeContainer";
            // 
            // LineSeperator3
            // 
            this.LineSeperator3.Location = new System.Drawing.Point(32, 240);
            this.LineSeperator3.MaximumSize = new System.Drawing.Size(2000, 2);
            this.LineSeperator3.MinimumSize = new System.Drawing.Size(0, 2);
            this.LineSeperator3.Name = "LineSeperator3";
            this.LineSeperator3.Size = new System.Drawing.Size(166, 2);
            this.LineSeperator3.TabIndex = 24;
            // 
            // LineSeperator2
            // 
            this.LineSeperator2.Location = new System.Drawing.Point(32, 154);
            this.LineSeperator2.MaximumSize = new System.Drawing.Size(2000, 2);
            this.LineSeperator2.MinimumSize = new System.Drawing.Size(0, 2);
            this.LineSeperator2.Name = "LineSeperator2";
            this.LineSeperator2.Size = new System.Drawing.Size(166, 2);
            this.LineSeperator2.TabIndex = 23;
            // 
            // LineSeperator1
            // 
            this.LineSeperator1.Location = new System.Drawing.Point(32, 106);
            this.LineSeperator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.LineSeperator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.LineSeperator1.Name = "LineSeperator1";
            this.LineSeperator1.Size = new System.Drawing.Size(166, 2);
            this.LineSeperator1.TabIndex = 22;
            // 
            // DropDownLicenseType
            // 
            this.DropDownLicenseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropDownLicenseType.FormattingEnabled = true;
            this.DropDownLicenseType.Items.AddRange(new object[] {
            "Duration",
            "Points"});
            this.DropDownLicenseType.Location = new System.Drawing.Point(32, 127);
            this.DropDownLicenseType.Name = "DropDownLicenseType";
            this.DropDownLicenseType.Size = new System.Drawing.Size(166, 21);
            this.DropDownLicenseType.TabIndex = 21;
            this.DropDownLicenseType.SelectedIndexChanged += new System.EventHandler(this.DropDownLicenseType_SelectedIndexChanged);
            // 
            // LabelLicenseType
            // 
            this.LabelLicenseType.AutoSize = true;
            this.LabelLicenseType.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLicenseType.Location = new System.Drawing.Point(29, 111);
            this.LabelLicenseType.Name = "LabelLicenseType";
            this.LabelLicenseType.Size = new System.Drawing.Size(86, 13);
            this.LabelLicenseType.TabIndex = 20;
            this.LabelLicenseType.Text = "License Type:";
            // 
            // ButtonCreateLicense
            // 
            this.ButtonCreateLicense.Location = new System.Drawing.Point(32, 248);
            this.ButtonCreateLicense.Name = "ButtonCreateLicense";
            this.ButtonCreateLicense.Size = new System.Drawing.Size(166, 25);
            this.ButtonCreateLicense.TabIndex = 19;
            this.ButtonCreateLicense.Text = "Generate License";
            this.ButtonCreateLicense.UseVisualStyleBackColor = true;
            this.ButtonCreateLicense.Click += new System.EventHandler(this.ButtonCreateLicense_Click);
            // 
            // CheckBoxCopyToClipboard
            // 
            this.CheckBoxCopyToClipboard.AutoSize = true;
            this.CheckBoxCopyToClipboard.Checked = true;
            this.CheckBoxCopyToClipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxCopyToClipboard.Location = new System.Drawing.Point(186, 84);
            this.CheckBoxCopyToClipboard.Name = "CheckBoxCopyToClipboard";
            this.CheckBoxCopyToClipboard.Size = new System.Drawing.Size(14, 13);
            this.CheckBoxCopyToClipboard.TabIndex = 18;
            this.ToolTip.SetToolTip(this.CheckBoxCopyToClipboard, "Copy generated license code to clipboard?");
            this.CheckBoxCopyToClipboard.UseVisualStyleBackColor = true;
            // 
            // TextBoxTrackingDescription
            // 
            this.TextBoxTrackingDescription.Location = new System.Drawing.Point(32, 214);
            this.TextBoxTrackingDescription.MaxLength = 30;
            this.TextBoxTrackingDescription.Name = "TextBoxTrackingDescription";
            this.TextBoxTrackingDescription.Size = new System.Drawing.Size(166, 20);
            this.TextBoxTrackingDescription.TabIndex = 17;
            // 
            // LabelTrackingDesc
            // 
            this.LabelTrackingDesc.AutoSize = true;
            this.LabelTrackingDesc.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTrackingDesc.Location = new System.Drawing.Point(29, 198);
            this.LabelTrackingDesc.Name = "LabelTrackingDesc";
            this.LabelTrackingDesc.Size = new System.Drawing.Size(129, 13);
            this.LabelTrackingDesc.TabIndex = 16;
            this.LabelTrackingDesc.Text = "Tracking Description:";
            // 
            // TextBoxValue
            // 
            this.TextBoxValue.Location = new System.Drawing.Point(32, 175);
            this.TextBoxValue.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.TextBoxValue.Name = "TextBoxValue";
            this.TextBoxValue.Size = new System.Drawing.Size(166, 20);
            this.TextBoxValue.TabIndex = 15;
            // 
            // LabelDuration
            // 
            this.LabelDuration.AutoSize = true;
            this.LabelDuration.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDuration.Location = new System.Drawing.Point(29, 159);
            this.LabelDuration.Name = "LabelDuration";
            this.LabelDuration.Size = new System.Drawing.Size(132, 13);
            this.LabelDuration.TabIndex = 14;
            this.LabelDuration.Text = "Days (0 = Unlimited):";
            // 
            // TextBoxLicenseCode
            // 
            this.TextBoxLicenseCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextBoxLicenseCode.Location = new System.Drawing.Point(32, 80);
            this.TextBoxLicenseCode.Name = "TextBoxLicenseCode";
            this.TextBoxLicenseCode.ReadOnly = true;
            this.TextBoxLicenseCode.Size = new System.Drawing.Size(146, 20);
            this.TextBoxLicenseCode.TabIndex = 13;
            // 
            // LabelGeneratedCode
            // 
            this.LabelGeneratedCode.AutoSize = true;
            this.LabelGeneratedCode.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGeneratedCode.Location = new System.Drawing.Point(29, 64);
            this.LabelGeneratedCode.Name = "LabelGeneratedCode";
            this.LabelGeneratedCode.Size = new System.Drawing.Size(106, 13);
            this.LabelGeneratedCode.TabIndex = 12;
            this.LabelGeneratedCode.Text = "Generated Code:";
            // 
            // ToolTip
            // 
            this.ToolTip.AutoPopDelay = 5000;
            this.ToolTip.InitialDelay = 250;
            this.ToolTip.ReshowDelay = 100;
            // 
            // CreateLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ThemeContainer);
            this.Name = "CreateLicense";
            this.Size = new System.Drawing.Size(231, 331);
            this.Load += new System.EventHandler(this.CreateLicense_Load);
            this.ThemeContainer.ResumeLayout(false);
            this.ThemeContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Theme.ThemeContainer ThemeContainer;
        private Theme.LineSeparator LineSeperator3;
        private Theme.LineSeparator LineSeperator2;
        private Theme.LineSeparator LineSeperator1;
        private System.Windows.Forms.ComboBox DropDownLicenseType;
        private System.Windows.Forms.Label LabelLicenseType;
        private System.Windows.Forms.Button ButtonCreateLicense;
        private System.Windows.Forms.CheckBox CheckBoxCopyToClipboard;
        private System.Windows.Forms.TextBox TextBoxTrackingDescription;
        private System.Windows.Forms.Label LabelTrackingDesc;
        private System.Windows.Forms.NumericUpDown TextBoxValue;
        private System.Windows.Forms.Label LabelDuration;
        private System.Windows.Forms.TextBox TextBoxLicenseCode;
        private System.Windows.Forms.Label LabelGeneratedCode;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}
