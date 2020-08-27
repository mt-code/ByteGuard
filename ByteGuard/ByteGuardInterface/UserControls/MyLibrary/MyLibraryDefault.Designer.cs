namespace ByteGuard.ByteGuardInterface.UserControls.MyLibrary
{
    partial class MyLibraryDefault
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyLibraryDefault));
            this.PanelProgramButtons = new System.Windows.Forms.Panel();
            this.ButtonLaunchApplication = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButtonViewLockDetails = new System.Windows.Forms.Button();
            this.TextBoxLicenseStatus = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TextBoxExpiration = new System.Windows.Forms.TextBox();
            this.GroupBoxProgramInformation = new System.Windows.Forms.GroupBox();
            this.verticalLineSeparator1 = new ByteGuard.ByteGuardInterface.Theme.VerticalLineSeparator();
            this.lineSeparator5 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.TextBoxVersion = new System.Windows.Forms.TextBox();
            this.TextBoxCreator = new System.Windows.Forms.TextBox();
            this.lineSeparator4 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.LinkLabelViewCreator = new System.Windows.Forms.LinkLabel();
            this.TextBoxProgramDescription = new System.Windows.Forms.TextBox();
            this.LabelProgramName = new System.Windows.Forms.Label();
            this.BlackVLineSeparator1 = new ByteGuard.ByteGuardInterface.Theme.VerticalLineSeparatorBlack();
            this.VLineSeparator2 = new ByteGuard.ByteGuardInterface.Theme.VerticalLineSeparator();
            this.LineSeparator3 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.LineSeparator2 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.LineSeparator1 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.VLineSeparator1 = new ByteGuard.ByteGuardInterface.Theme.VerticalLineSeparator();
            this.PictureBoxProgramImage = new System.Windows.Forms.PictureBox();
            this.PanelProgramButtons.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GroupBoxProgramInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProgramImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelProgramButtons
            // 
            this.PanelProgramButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelProgramButtons.Controls.Add(this.ButtonLaunchApplication);
            this.PanelProgramButtons.Controls.Add(this.groupBox2);
            this.PanelProgramButtons.Controls.Add(this.groupBox1);
            this.PanelProgramButtons.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PanelProgramButtons.Location = new System.Drawing.Point(22, 374);
            this.PanelProgramButtons.Name = "PanelProgramButtons";
            this.PanelProgramButtons.Size = new System.Drawing.Size(654, 45);
            this.PanelProgramButtons.TabIndex = 19;
            // 
            // ButtonLaunchApplication
            // 
            this.ButtonLaunchApplication.Enabled = false;
            this.ButtonLaunchApplication.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLaunchApplication.Location = new System.Drawing.Point(442, 4);
            this.ButtonLaunchApplication.Name = "ButtonLaunchApplication";
            this.ButtonLaunchApplication.Size = new System.Drawing.Size(202, 34);
            this.ButtonLaunchApplication.TabIndex = 2;
            this.ButtonLaunchApplication.Text = "Launch Application";
            this.ButtonLaunchApplication.UseVisualStyleBackColor = true;
            this.ButtonLaunchApplication.Click += new System.EventHandler(this.ButtonLaunchApplication_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ButtonViewLockDetails);
            this.groupBox2.Controls.Add(this.TextBoxLicenseStatus);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(182, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 36);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "License Status:";
            // 
            // ButtonViewLockDetails
            // 
            this.ButtonViewLockDetails.Enabled = false;
            this.ButtonViewLockDetails.Location = new System.Drawing.Point(107, 10);
            this.ButtonViewLockDetails.Name = "ButtonViewLockDetails";
            this.ButtonViewLockDetails.Size = new System.Drawing.Size(133, 22);
            this.ButtonViewLockDetails.TabIndex = 1;
            this.ButtonViewLockDetails.Text = "View Details";
            this.ButtonViewLockDetails.UseVisualStyleBackColor = true;
            this.ButtonViewLockDetails.Click += new System.EventHandler(this.ButtonViewLockDetails_Click);
            // 
            // TextBoxLicenseStatus
            // 
            this.TextBoxLicenseStatus.BackColor = System.Drawing.SystemColors.Control;
            this.TextBoxLicenseStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxLicenseStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.TextBoxLicenseStatus.ForeColor = System.Drawing.Color.DarkGreen;
            this.TextBoxLicenseStatus.Location = new System.Drawing.Point(7, 16);
            this.TextBoxLicenseStatus.Name = "TextBoxLicenseStatus";
            this.TextBoxLicenseStatus.ReadOnly = true;
            this.TextBoxLicenseStatus.Size = new System.Drawing.Size(90, 13);
            this.TextBoxLicenseStatus.TabIndex = 0;
            this.TextBoxLicenseStatus.Text = "N/A";
            this.TextBoxLicenseStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxLicenseStatus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBoxLicenseStatus_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TextBoxExpiration);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 36);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Expires:";
            // 
            // TextBoxExpiration
            // 
            this.TextBoxExpiration.BackColor = System.Drawing.SystemColors.Control;
            this.TextBoxExpiration.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxExpiration.Cursor = System.Windows.Forms.Cursors.Default;
            this.TextBoxExpiration.Location = new System.Drawing.Point(6, 16);
            this.TextBoxExpiration.Name = "TextBoxExpiration";
            this.TextBoxExpiration.ReadOnly = true;
            this.TextBoxExpiration.Size = new System.Drawing.Size(148, 13);
            this.TextBoxExpiration.TabIndex = 0;
            this.TextBoxExpiration.Text = "N/A";
            this.TextBoxExpiration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxExpiration.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBoxExpiration_MouseUp);
            // 
            // GroupBoxProgramInformation
            // 
            this.GroupBoxProgramInformation.Controls.Add(this.verticalLineSeparator1);
            this.GroupBoxProgramInformation.Controls.Add(this.lineSeparator5);
            this.GroupBoxProgramInformation.Controls.Add(this.TextBoxVersion);
            this.GroupBoxProgramInformation.Controls.Add(this.TextBoxCreator);
            this.GroupBoxProgramInformation.Controls.Add(this.lineSeparator4);
            this.GroupBoxProgramInformation.Controls.Add(this.LinkLabelViewCreator);
            this.GroupBoxProgramInformation.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxProgramInformation.Location = new System.Drawing.Point(22, 207);
            this.GroupBoxProgramInformation.Name = "GroupBoxProgramInformation";
            this.GroupBoxProgramInformation.Size = new System.Drawing.Size(175, 141);
            this.GroupBoxProgramInformation.TabIndex = 22;
            this.GroupBoxProgramInformation.TabStop = false;
            // 
            // verticalLineSeparator1
            // 
            this.verticalLineSeparator1.Location = new System.Drawing.Point(87, 100);
            this.verticalLineSeparator1.MaximumSize = new System.Drawing.Size(2, 2000);
            this.verticalLineSeparator1.MinimumSize = new System.Drawing.Size(2, 2);
            this.verticalLineSeparator1.Name = "verticalLineSeparator1";
            this.verticalLineSeparator1.Size = new System.Drawing.Size(2, 34);
            this.verticalLineSeparator1.TabIndex = 9;
            // 
            // lineSeparator5
            // 
            this.lineSeparator5.Location = new System.Drawing.Point(6, 92);
            this.lineSeparator5.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator5.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator5.Name = "lineSeparator5";
            this.lineSeparator5.Size = new System.Drawing.Size(163, 2);
            this.lineSeparator5.TabIndex = 8;
            // 
            // TextBoxVersion
            // 
            this.TextBoxVersion.BackColor = System.Drawing.SystemColors.Control;
            this.TextBoxVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxVersion.Cursor = System.Windows.Forms.Cursors.Default;
            this.TextBoxVersion.Location = new System.Drawing.Point(6, 19);
            this.TextBoxVersion.Name = "TextBoxVersion";
            this.TextBoxVersion.ReadOnly = true;
            this.TextBoxVersion.Size = new System.Drawing.Size(163, 13);
            this.TextBoxVersion.TabIndex = 7;
            this.TextBoxVersion.Text = "Version: N/A";
            this.TextBoxVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxVersion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBoxVersion_MouseUp);
            // 
            // TextBoxCreator
            // 
            this.TextBoxCreator.BackColor = System.Drawing.SystemColors.Control;
            this.TextBoxCreator.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxCreator.Cursor = System.Windows.Forms.Cursors.Default;
            this.TextBoxCreator.Location = new System.Drawing.Point(6, 52);
            this.TextBoxCreator.Name = "TextBoxCreator";
            this.TextBoxCreator.ReadOnly = true;
            this.TextBoxCreator.Size = new System.Drawing.Size(163, 13);
            this.TextBoxCreator.TabIndex = 6;
            this.TextBoxCreator.Text = "Program Creator";
            this.TextBoxCreator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxCreator.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBoxCreator_MouseUp);
            // 
            // lineSeparator4
            // 
            this.lineSeparator4.Location = new System.Drawing.Point(6, 44);
            this.lineSeparator4.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator4.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator4.Name = "lineSeparator4";
            this.lineSeparator4.Size = new System.Drawing.Size(163, 2);
            this.lineSeparator4.TabIndex = 5;
            // 
            // LinkLabelViewCreator
            // 
            this.LinkLabelViewCreator.AutoSize = true;
            this.LinkLabelViewCreator.Location = new System.Drawing.Point(26, 68);
            this.LinkLabelViewCreator.Name = "LinkLabelViewCreator";
            this.LinkLabelViewCreator.Size = new System.Drawing.Size(128, 13);
            this.LinkLabelViewCreator.TabIndex = 4;
            this.LinkLabelViewCreator.TabStop = true;
            this.LinkLabelViewCreator.Text = "View Creators Profile";
            this.LinkLabelViewCreator.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelViewCreator_LinkClicked);
            // 
            // TextBoxProgramDescription
            // 
            this.TextBoxProgramDescription.BackColor = System.Drawing.SystemColors.Control;
            this.TextBoxProgramDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxProgramDescription.Enabled = false;
            this.TextBoxProgramDescription.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxProgramDescription.ForeColor = System.Drawing.Color.DimGray;
            this.TextBoxProgramDescription.Location = new System.Drawing.Point(224, 66);
            this.TextBoxProgramDescription.Multiline = true;
            this.TextBoxProgramDescription.Name = "TextBoxProgramDescription";
            this.TextBoxProgramDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxProgramDescription.Size = new System.Drawing.Size(452, 120);
            this.TextBoxProgramDescription.TabIndex = 23;
            this.TextBoxProgramDescription.Text = resources.GetString("TextBoxProgramDescription.Text");
            // 
            // LabelProgramName
            // 
            this.LabelProgramName.AutoSize = true;
            this.LabelProgramName.Font = new System.Drawing.Font("Verdana", 14.11765F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelProgramName.Location = new System.Drawing.Point(219, 17);
            this.LabelProgramName.Name = "LabelProgramName";
            this.LabelProgramName.Size = new System.Drawing.Size(123, 25);
            this.LabelProgramName.TabIndex = 24;
            this.LabelProgramName.Text = "My Library";
            // 
            // BlackVLineSeparator1
            // 
            this.BlackVLineSeparator1.Location = new System.Drawing.Point(457, 375);
            this.BlackVLineSeparator1.MaximumSize = new System.Drawing.Size(2, 2000);
            this.BlackVLineSeparator1.MinimumSize = new System.Drawing.Size(2, 2);
            this.BlackVLineSeparator1.Name = "BlackVLineSeparator1";
            this.BlackVLineSeparator1.Size = new System.Drawing.Size(2, 43);
            this.BlackVLineSeparator1.TabIndex = 25;
            // 
            // VLineSeparator2
            // 
            this.VLineSeparator2.Location = new System.Drawing.Point(210, 200);
            this.VLineSeparator2.MaximumSize = new System.Drawing.Size(2, 2000);
            this.VLineSeparator2.MinimumSize = new System.Drawing.Size(2, 2);
            this.VLineSeparator2.Name = "VLineSeparator2";
            this.VLineSeparator2.Size = new System.Drawing.Size(2, 161);
            this.VLineSeparator2.TabIndex = 21;
            // 
            // LineSeparator3
            // 
            this.LineSeparator3.Location = new System.Drawing.Point(22, 361);
            this.LineSeparator3.MaximumSize = new System.Drawing.Size(2000, 2);
            this.LineSeparator3.MinimumSize = new System.Drawing.Size(0, 2);
            this.LineSeparator3.Name = "LineSeparator3";
            this.LineSeparator3.Size = new System.Drawing.Size(654, 2);
            this.LineSeparator3.TabIndex = 20;
            // 
            // LineSeparator2
            // 
            this.LineSeparator2.Location = new System.Drawing.Point(22, 199);
            this.LineSeparator2.MaximumSize = new System.Drawing.Size(2000, 2);
            this.LineSeparator2.MinimumSize = new System.Drawing.Size(0, 2);
            this.LineSeparator2.Name = "LineSeparator2";
            this.LineSeparator2.Size = new System.Drawing.Size(654, 2);
            this.LineSeparator2.TabIndex = 18;
            // 
            // LineSeparator1
            // 
            this.LineSeparator1.Location = new System.Drawing.Point(212, 52);
            this.LineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.LineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.LineSeparator1.Name = "LineSeparator1";
            this.LineSeparator1.Size = new System.Drawing.Size(464, 2);
            this.LineSeparator1.TabIndex = 17;
            // 
            // VLineSeparator1
            // 
            this.VLineSeparator1.Location = new System.Drawing.Point(210, 11);
            this.VLineSeparator1.MaximumSize = new System.Drawing.Size(2, 2000);
            this.VLineSeparator1.MinimumSize = new System.Drawing.Size(2, 2);
            this.VLineSeparator1.Name = "VLineSeparator1";
            this.VLineSeparator1.Size = new System.Drawing.Size(2, 188);
            this.VLineSeparator1.TabIndex = 16;
            // 
            // PictureBoxProgramImage
            // 
            this.PictureBoxProgramImage.BackColor = System.Drawing.Color.White;
            this.PictureBoxProgramImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBoxProgramImage.Image = global::ByteGuard.Properties.Resources.DefaultProgramImage;
            this.PictureBoxProgramImage.Location = new System.Drawing.Point(22, 11);
            this.PictureBoxProgramImage.Name = "PictureBoxProgramImage";
            this.PictureBoxProgramImage.Size = new System.Drawing.Size(175, 175);
            this.PictureBoxProgramImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxProgramImage.TabIndex = 14;
            this.PictureBoxProgramImage.TabStop = false;
            // 
            // MyLibraryDefault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BlackVLineSeparator1);
            this.Controls.Add(this.LabelProgramName);
            this.Controls.Add(this.TextBoxProgramDescription);
            this.Controls.Add(this.GroupBoxProgramInformation);
            this.Controls.Add(this.VLineSeparator2);
            this.Controls.Add(this.LineSeparator3);
            this.Controls.Add(this.PanelProgramButtons);
            this.Controls.Add(this.LineSeparator2);
            this.Controls.Add(this.LineSeparator1);
            this.Controls.Add(this.VLineSeparator1);
            this.Controls.Add(this.PictureBoxProgramImage);
            this.Name = "MyLibraryDefault";
            this.Size = new System.Drawing.Size(702, 429);
            this.Load += new System.EventHandler(this.MyLibraryDefault_Load);
            this.PanelProgramButtons.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GroupBoxProgramInformation.ResumeLayout(false);
            this.GroupBoxProgramInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProgramImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxProgramImage;
        private Theme.VerticalLineSeparator VLineSeparator1;
        private Theme.LineSeparator LineSeparator1;
        private Theme.LineSeparator LineSeparator2;
        private System.Windows.Forms.Panel PanelProgramButtons;
        private Theme.LineSeparator LineSeparator3;
        private Theme.VerticalLineSeparator VLineSeparator2;
        private System.Windows.Forms.GroupBox GroupBoxProgramInformation;
        private System.Windows.Forms.TextBox TextBoxProgramDescription;
        private Theme.LineSeparator lineSeparator4;
        private System.Windows.Forms.LinkLabel LinkLabelViewCreator;
        private Theme.VerticalLineSeparator verticalLineSeparator1;
        private Theme.LineSeparator lineSeparator5;
        private System.Windows.Forms.TextBox TextBoxVersion;
        private System.Windows.Forms.TextBox TextBoxCreator;
        private System.Windows.Forms.Label LabelProgramName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TextBoxExpiration;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TextBoxLicenseStatus;
        private System.Windows.Forms.Button ButtonViewLockDetails;
        private System.Windows.Forms.Button ButtonLaunchApplication;
        private Theme.VerticalLineSeparatorBlack BlackVLineSeparator1;
    }
}
