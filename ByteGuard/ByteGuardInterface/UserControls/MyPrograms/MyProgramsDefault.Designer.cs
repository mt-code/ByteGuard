namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    partial class MyProgramsDefault
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
            this.GroupBoxProgramSettings = new System.Windows.Forms.GroupBox();
            this.LabelUsedLicenses = new System.Windows.Forms.Label();
            this.LineSeparator1 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.LineSeparator2 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.ButtonManageProgram = new System.Windows.Forms.Button();
            this.ButtonVersionMinus = new System.Windows.Forms.Button();
            this.ButtonVersionPlus = new System.Windows.Forms.Button();
            this.LabelVersion = new System.Windows.Forms.Label();
            this.ButtonChangeImage = new System.Windows.Forms.Button();
            this.GroupBoxStoreSettings = new System.Windows.Forms.GroupBox();
            this.GroupBoxProgramInformation = new System.Windows.Forms.GroupBox();
            this.LabelProgramName = new System.Windows.Forms.Label();
            this.TextBoxProgramDescription = new System.Windows.Forms.TextBox();
            this.LabelProgramDescription = new System.Windows.Forms.Label();
            this.TextBoxProgramName = new System.Windows.Forms.TextBox();
            this.PanelProgramButtons = new System.Windows.Forms.Panel();
            this.ButtonEditProgram = new System.Windows.Forms.Button();
            this.ButtonCreateProgram = new System.Windows.Forms.Button();
            this.ButtonDeleteProgram = new System.Windows.Forms.Button();
            this.PictureBoxProgramImage = new System.Windows.Forms.PictureBox();
            this.DeleteTimer = new System.Windows.Forms.Timer(this.components);
            this.GroupBoxProgramSettings.SuspendLayout();
            this.GroupBoxProgramInformation.SuspendLayout();
            this.PanelProgramButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProgramImage)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBoxProgramSettings
            // 
            this.GroupBoxProgramSettings.Controls.Add(this.LabelUsedLicenses);
            this.GroupBoxProgramSettings.Controls.Add(this.LineSeparator1);
            this.GroupBoxProgramSettings.Controls.Add(this.LineSeparator2);
            this.GroupBoxProgramSettings.Controls.Add(this.ButtonManageProgram);
            this.GroupBoxProgramSettings.Controls.Add(this.ButtonVersionMinus);
            this.GroupBoxProgramSettings.Controls.Add(this.ButtonVersionPlus);
            this.GroupBoxProgramSettings.Controls.Add(this.LabelVersion);
            this.GroupBoxProgramSettings.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxProgramSettings.Location = new System.Drawing.Point(22, 226);
            this.GroupBoxProgramSettings.Name = "GroupBoxProgramSettings";
            this.GroupBoxProgramSettings.Size = new System.Drawing.Size(175, 133);
            this.GroupBoxProgramSettings.TabIndex = 17;
            this.GroupBoxProgramSettings.TabStop = false;
            this.GroupBoxProgramSettings.Text = "Program Settings";
            // 
            // LabelUsedLicenses
            // 
            this.LabelUsedLicenses.AutoSize = true;
            this.LabelUsedLicenses.Location = new System.Drawing.Point(13, 24);
            this.LabelUsedLicenses.Name = "LabelUsedLicenses";
            this.LabelUsedLicenses.Size = new System.Drawing.Size(71, 13);
            this.LabelUsedLicenses.TabIndex = 11;
            this.LabelUsedLicenses.Text = "Licenses: 0";
            // 
            // LineSeparator1
            // 
            this.LineSeparator1.Location = new System.Drawing.Point(16, 49);
            this.LineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.LineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.LineSeparator1.Name = "LineSeparator1";
            this.LineSeparator1.Size = new System.Drawing.Size(143, 2);
            this.LineSeparator1.TabIndex = 10;
            // 
            // LineSeparator2
            // 
            this.LineSeparator2.Location = new System.Drawing.Point(16, 88);
            this.LineSeparator2.MaximumSize = new System.Drawing.Size(2000, 2);
            this.LineSeparator2.MinimumSize = new System.Drawing.Size(0, 2);
            this.LineSeparator2.Name = "LineSeparator2";
            this.LineSeparator2.Size = new System.Drawing.Size(143, 2);
            this.LineSeparator2.TabIndex = 9;
            // 
            // ButtonManageProgram
            // 
            this.ButtonManageProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonManageProgram.Enabled = false;
            this.ButtonManageProgram.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonManageProgram.Location = new System.Drawing.Point(16, 96);
            this.ButtonManageProgram.Name = "ButtonManageProgram";
            this.ButtonManageProgram.Size = new System.Drawing.Size(143, 25);
            this.ButtonManageProgram.TabIndex = 8;
            this.ButtonManageProgram.Text = "Manage Program";
            this.ButtonManageProgram.UseVisualStyleBackColor = true;
            this.ButtonManageProgram.Click += new System.EventHandler(this.ButtonManageProgram_Click);
            // 
            // ButtonVersionMinus
            // 
            this.ButtonVersionMinus.Enabled = false;
            this.ButtonVersionMinus.Location = new System.Drawing.Point(134, 57);
            this.ButtonVersionMinus.Name = "ButtonVersionMinus";
            this.ButtonVersionMinus.Size = new System.Drawing.Size(25, 25);
            this.ButtonVersionMinus.TabIndex = 3;
            this.ButtonVersionMinus.Text = "-";
            this.ButtonVersionMinus.UseVisualStyleBackColor = true;
            this.ButtonVersionMinus.Click += new System.EventHandler(this.ButtonVersionMinus_Click);
            // 
            // ButtonVersionPlus
            // 
            this.ButtonVersionPlus.Enabled = false;
            this.ButtonVersionPlus.Location = new System.Drawing.Point(105, 57);
            this.ButtonVersionPlus.Name = "ButtonVersionPlus";
            this.ButtonVersionPlus.Size = new System.Drawing.Size(25, 25);
            this.ButtonVersionPlus.TabIndex = 2;
            this.ButtonVersionPlus.Text = "+";
            this.ButtonVersionPlus.UseVisualStyleBackColor = true;
            this.ButtonVersionPlus.Click += new System.EventHandler(this.ButtonVersionPlus_Click);
            // 
            // LabelVersion
            // 
            this.LabelVersion.AutoSize = true;
            this.LabelVersion.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVersion.Location = new System.Drawing.Point(13, 62);
            this.LabelVersion.Name = "LabelVersion";
            this.LabelVersion.Size = new System.Drawing.Size(77, 13);
            this.LabelVersion.TabIndex = 1;
            this.LabelVersion.Text = "Version: 1.0";
            // 
            // ButtonChangeImage
            // 
            this.ButtonChangeImage.Enabled = false;
            this.ButtonChangeImage.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonChangeImage.Location = new System.Drawing.Point(22, 195);
            this.ButtonChangeImage.Name = "ButtonChangeImage";
            this.ButtonChangeImage.Size = new System.Drawing.Size(175, 25);
            this.ButtonChangeImage.TabIndex = 16;
            this.ButtonChangeImage.Text = "Change Image (175x175)";
            this.ButtonChangeImage.UseVisualStyleBackColor = true;
            this.ButtonChangeImage.Click += new System.EventHandler(this.ButtonChangeImage_Click);
            // 
            // GroupBoxStoreSettings
            // 
            this.GroupBoxStoreSettings.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxStoreSettings.Location = new System.Drawing.Point(209, 193);
            this.GroupBoxStoreSettings.Name = "GroupBoxStoreSettings";
            this.GroupBoxStoreSettings.Size = new System.Drawing.Size(468, 166);
            this.GroupBoxStoreSettings.TabIndex = 15;
            this.GroupBoxStoreSettings.TabStop = false;
            this.GroupBoxStoreSettings.Text = "Store Settings";
            this.GroupBoxStoreSettings.Visible = false;
            // 
            // GroupBoxProgramInformation
            // 
            this.GroupBoxProgramInformation.Controls.Add(this.LabelProgramName);
            this.GroupBoxProgramInformation.Controls.Add(this.TextBoxProgramDescription);
            this.GroupBoxProgramInformation.Controls.Add(this.LabelProgramDescription);
            this.GroupBoxProgramInformation.Controls.Add(this.TextBoxProgramName);
            this.GroupBoxProgramInformation.Location = new System.Drawing.Point(209, 6);
            this.GroupBoxProgramInformation.Name = "GroupBoxProgramInformation";
            this.GroupBoxProgramInformation.Size = new System.Drawing.Size(468, 181);
            this.GroupBoxProgramInformation.TabIndex = 14;
            this.GroupBoxProgramInformation.TabStop = false;
            // 
            // LabelProgramName
            // 
            this.LabelProgramName.AutoSize = true;
            this.LabelProgramName.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelProgramName.Location = new System.Drawing.Point(13, 20);
            this.LabelProgramName.Name = "LabelProgramName";
            this.LabelProgramName.Size = new System.Drawing.Size(98, 13);
            this.LabelProgramName.TabIndex = 4;
            this.LabelProgramName.Text = "Program Name:";
            // 
            // TextBoxProgramDescription
            // 
            this.TextBoxProgramDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxProgramDescription.BackColor = System.Drawing.SystemColors.Window;
            this.TextBoxProgramDescription.Enabled = false;
            this.TextBoxProgramDescription.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxProgramDescription.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TextBoxProgramDescription.Location = new System.Drawing.Point(16, 77);
            this.TextBoxProgramDescription.MaxLength = 500;
            this.TextBoxProgramDescription.Multiline = true;
            this.TextBoxProgramDescription.Name = "TextBoxProgramDescription";
            this.TextBoxProgramDescription.Size = new System.Drawing.Size(438, 88);
            this.TextBoxProgramDescription.TabIndex = 3;
            this.TextBoxProgramDescription.TextChanged += new System.EventHandler(this.TextBoxProgramDescription_TextChanged);
            // 
            // LabelProgramDescription
            // 
            this.LabelProgramDescription.AutoSize = true;
            this.LabelProgramDescription.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelProgramDescription.Location = new System.Drawing.Point(13, 61);
            this.LabelProgramDescription.Name = "LabelProgramDescription";
            this.LabelProgramDescription.Size = new System.Drawing.Size(129, 13);
            this.LabelProgramDescription.TabIndex = 2;
            this.LabelProgramDescription.Text = "Program Description:";
            // 
            // TextBoxProgramName
            // 
            this.TextBoxProgramName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxProgramName.BackColor = System.Drawing.SystemColors.Window;
            this.TextBoxProgramName.Enabled = false;
            this.TextBoxProgramName.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxProgramName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TextBoxProgramName.Location = new System.Drawing.Point(16, 36);
            this.TextBoxProgramName.MaxLength = 25;
            this.TextBoxProgramName.Multiline = true;
            this.TextBoxProgramName.Name = "TextBoxProgramName";
            this.TextBoxProgramName.Size = new System.Drawing.Size(438, 20);
            this.TextBoxProgramName.TabIndex = 1;
            this.TextBoxProgramName.TextChanged += new System.EventHandler(this.TextBoxProgramName_TextChanged);
            // 
            // PanelProgramButtons
            // 
            this.PanelProgramButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelProgramButtons.Controls.Add(this.ButtonEditProgram);
            this.PanelProgramButtons.Controls.Add(this.ButtonCreateProgram);
            this.PanelProgramButtons.Controls.Add(this.ButtonDeleteProgram);
            this.PanelProgramButtons.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PanelProgramButtons.Location = new System.Drawing.Point(22, 374);
            this.PanelProgramButtons.Name = "PanelProgramButtons";
            this.PanelProgramButtons.Size = new System.Drawing.Size(655, 45);
            this.PanelProgramButtons.TabIndex = 12;
            // 
            // ButtonEditProgram
            // 
            this.ButtonEditProgram.Enabled = false;
            this.ButtonEditProgram.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonEditProgram.Location = new System.Drawing.Point(226, 6);
            this.ButtonEditProgram.Name = "ButtonEditProgram";
            this.ButtonEditProgram.Size = new System.Drawing.Size(200, 30);
            this.ButtonEditProgram.TabIndex = 6;
            this.ButtonEditProgram.Text = "Edit Program";
            this.ButtonEditProgram.UseVisualStyleBackColor = true;
            this.ButtonEditProgram.Click += new System.EventHandler(this.ButtonEditProgram_Click);
            // 
            // ButtonCreateProgram
            // 
            this.ButtonCreateProgram.Enabled = false;
            this.ButtonCreateProgram.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCreateProgram.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.ButtonCreateProgram.Location = new System.Drawing.Point(440, 6);
            this.ButtonCreateProgram.Name = "ButtonCreateProgram";
            this.ButtonCreateProgram.Size = new System.Drawing.Size(200, 30);
            this.ButtonCreateProgram.TabIndex = 5;
            this.ButtonCreateProgram.Text = "Create New Program";
            this.ButtonCreateProgram.UseVisualStyleBackColor = true;
            this.ButtonCreateProgram.Click += new System.EventHandler(this.ButtonCreateProgram_Click);
            // 
            // ButtonDeleteProgram
            // 
            this.ButtonDeleteProgram.Enabled = false;
            this.ButtonDeleteProgram.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDeleteProgram.Location = new System.Drawing.Point(14, 6);
            this.ButtonDeleteProgram.Name = "ButtonDeleteProgram";
            this.ButtonDeleteProgram.Size = new System.Drawing.Size(200, 30);
            this.ButtonDeleteProgram.TabIndex = 4;
            this.ButtonDeleteProgram.Text = "Delete Program (3)";
            this.ButtonDeleteProgram.UseVisualStyleBackColor = true;
            this.ButtonDeleteProgram.Click += new System.EventHandler(this.ButtonDeleteProgram_Click);
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
            this.PictureBoxProgramImage.TabIndex = 13;
            this.PictureBoxProgramImage.TabStop = false;
            // 
            // DeleteTimer
            // 
            this.DeleteTimer.Interval = 1000;
            this.DeleteTimer.Tick += new System.EventHandler(this.DeleteTimer_Tick);
            // 
            // MyProgramsDefault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupBoxProgramSettings);
            this.Controls.Add(this.ButtonChangeImage);
            this.Controls.Add(this.GroupBoxStoreSettings);
            this.Controls.Add(this.GroupBoxProgramInformation);
            this.Controls.Add(this.PictureBoxProgramImage);
            this.Controls.Add(this.PanelProgramButtons);
            this.Name = "MyProgramsDefault";
            this.Size = new System.Drawing.Size(702, 429);
            this.Load += new System.EventHandler(this.MyProgramsDefault_Load);
            this.GroupBoxProgramSettings.ResumeLayout(false);
            this.GroupBoxProgramSettings.PerformLayout();
            this.GroupBoxProgramInformation.ResumeLayout(false);
            this.GroupBoxProgramInformation.PerformLayout();
            this.PanelProgramButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProgramImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxProgramSettings;
        private System.Windows.Forms.Button ButtonManageProgram;
        private System.Windows.Forms.Button ButtonVersionMinus;
        private System.Windows.Forms.Button ButtonVersionPlus;
        private System.Windows.Forms.Label LabelVersion;
        private System.Windows.Forms.Button ButtonChangeImage;
        private System.Windows.Forms.GroupBox GroupBoxStoreSettings;
        private System.Windows.Forms.GroupBox GroupBoxProgramInformation;
        private System.Windows.Forms.Label LabelProgramName;
        private System.Windows.Forms.TextBox TextBoxProgramDescription;
        private System.Windows.Forms.Label LabelProgramDescription;
        private System.Windows.Forms.TextBox TextBoxProgramName;
        private System.Windows.Forms.PictureBox PictureBoxProgramImage;
        private System.Windows.Forms.Panel PanelProgramButtons;
        private System.Windows.Forms.Button ButtonEditProgram;
        private System.Windows.Forms.Button ButtonCreateProgram;
        private System.Windows.Forms.Button ButtonDeleteProgram;
        private System.Windows.Forms.Label LabelUsedLicenses;
        private Theme.LineSeparator LineSeparator1;
        private Theme.LineSeparator LineSeparator2;
        private System.Windows.Forms.Timer DeleteTimer;
    }
}
