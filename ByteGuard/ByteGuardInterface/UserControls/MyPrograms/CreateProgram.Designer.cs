namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    partial class CreateProgram
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
            this.ButtonCreateProgram = new System.Windows.Forms.Button();
            this.ButtonBack = new System.Windows.Forms.Button();
            this.GroupBoxProtectionSettings = new System.Windows.Forms.GroupBox();
            this.lineSeparator1 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.comboMainExecutable = new System.Windows.Forms.ComboBox();
            this.lblMainExecutable = new System.Windows.Forms.Label();
            this.ConstantsGroupBox = new System.Windows.Forms.GroupBox();
            this.CompressConstantsCheckBox = new System.Windows.Forms.CheckBox();
            this.ConstantCheckBox = new System.Windows.Forms.CheckBox();
            this.EmbedConstantsCheckBox = new System.Windows.Forms.CheckBox();
            this.EncryptConstantsCheckBox = new System.Windows.Forms.CheckBox();
            this.AssemblyRenameGroupBox = new System.Windows.Forms.GroupBox();
            this.ExcludeMembersButton = new System.Windows.Forms.Button();
            this.MergeNamespacesCheckBox = new System.Windows.Forms.CheckBox();
            this.AssemblyRenameCheckBox = new System.Windows.Forms.CheckBox();
            this.CharacterSetLabel = new System.Windows.Forms.Label();
            this.CharacterSetComboBox = new System.Windows.Forms.ComboBox();
            this.StringsGroupBox = new System.Windows.Forms.GroupBox();
            this.EncodeStringsCheckBox = new System.Windows.Forms.CheckBox();
            this.EmbedStringsCheckBox = new System.Windows.Forms.CheckBox();
            this.CompressStringsCheckBox = new System.Windows.Forms.CheckBox();
            this.EncryptStringsCheckBox = new System.Windows.Forms.CheckBox();
            this.ButtonBrowseProgram = new System.Windows.Forms.Button();
            this.TextBoxProgramLocation = new System.Windows.Forms.TextBox();
            this.GroupBoxProgramSettings = new System.Windows.Forms.GroupBox();
            this.LabelProtectionPreset = new System.Windows.Forms.Label();
            this.ButtonVersionMinus = new System.Windows.Forms.Button();
            this.ButtonVersionPlus = new System.Windows.Forms.Button();
            this.LabelVersion = new System.Windows.Forms.Label();
            this.DropDownProtectionPreset = new System.Windows.Forms.ComboBox();
            this.GroupBoxProgramInformation = new System.Windows.Forms.GroupBox();
            this.LabelProgramName = new System.Windows.Forms.Label();
            this.TextBoxProgramDescription = new System.Windows.Forms.TextBox();
            this.LabelProgramDescription = new System.Windows.Forms.Label();
            this.TextBoxProgramName = new System.Windows.Forms.TextBox();
            this.PictureBoxProgramImage = new System.Windows.Forms.PictureBox();
            this.ButtonChangeImage = new System.Windows.Forms.Button();
            this.GroupBoxProtectionSettings.SuspendLayout();
            this.ConstantsGroupBox.SuspendLayout();
            this.AssemblyRenameGroupBox.SuspendLayout();
            this.StringsGroupBox.SuspendLayout();
            this.GroupBoxProgramSettings.SuspendLayout();
            this.GroupBoxProgramInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProgramImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonCreateProgram
            // 
            this.ButtonCreateProgram.Enabled = false;
            this.ButtonCreateProgram.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCreateProgram.Location = new System.Drawing.Point(22, 339);
            this.ButtonCreateProgram.Name = "ButtonCreateProgram";
            this.ButtonCreateProgram.Size = new System.Drawing.Size(175, 30);
            this.ButtonCreateProgram.TabIndex = 11;
            this.ButtonCreateProgram.Text = "Create Program";
            this.ButtonCreateProgram.UseVisualStyleBackColor = true;
            this.ButtonCreateProgram.Click += new System.EventHandler(this.ButtonCreateProgram_Click);
            // 
            // ButtonBack
            // 
            this.ButtonBack.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonBack.Location = new System.Drawing.Point(22, 375);
            this.ButtonBack.Name = "ButtonBack";
            this.ButtonBack.Size = new System.Drawing.Size(175, 30);
            this.ButtonBack.TabIndex = 12;
            this.ButtonBack.Text = "Back";
            this.ButtonBack.UseVisualStyleBackColor = true;
            this.ButtonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // GroupBoxProtectionSettings
            // 
            this.GroupBoxProtectionSettings.Controls.Add(this.lineSeparator1);
            this.GroupBoxProtectionSettings.Controls.Add(this.comboMainExecutable);
            this.GroupBoxProtectionSettings.Controls.Add(this.lblMainExecutable);
            this.GroupBoxProtectionSettings.Controls.Add(this.ConstantsGroupBox);
            this.GroupBoxProtectionSettings.Controls.Add(this.AssemblyRenameGroupBox);
            this.GroupBoxProtectionSettings.Controls.Add(this.StringsGroupBox);
            this.GroupBoxProtectionSettings.Controls.Add(this.ButtonBrowseProgram);
            this.GroupBoxProtectionSettings.Controls.Add(this.TextBoxProgramLocation);
            this.GroupBoxProtectionSettings.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxProtectionSettings.Location = new System.Drawing.Point(211, 194);
            this.GroupBoxProtectionSettings.Name = "GroupBoxProtectionSettings";
            this.GroupBoxProtectionSettings.Size = new System.Drawing.Size(466, 211);
            this.GroupBoxProtectionSettings.TabIndex = 10;
            this.GroupBoxProtectionSettings.TabStop = false;
            this.GroupBoxProtectionSettings.Text = "Protection Settings";
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(291, 88);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(160, 2);
            this.lineSeparator1.TabIndex = 10;
            // 
            // comboMainExecutable
            // 
            this.comboMainExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboMainExecutable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMainExecutable.Enabled = false;
            this.comboMainExecutable.FormattingEnabled = true;
            this.comboMainExecutable.Items.AddRange(new object[] {
            "Select executable..."});
            this.comboMainExecutable.Location = new System.Drawing.Point(291, 62);
            this.comboMainExecutable.Name = "comboMainExecutable";
            this.comboMainExecutable.Size = new System.Drawing.Size(160, 20);
            this.comboMainExecutable.TabIndex = 5;
            this.comboMainExecutable.SelectedIndexChanged += new System.EventHandler(this.comboMainExecutable_SelectedIndexChanged);
            // 
            // lblMainExecutable
            // 
            this.lblMainExecutable.AutoSize = true;
            this.lblMainExecutable.Enabled = false;
            this.lblMainExecutable.Location = new System.Drawing.Point(288, 46);
            this.lblMainExecutable.Name = "lblMainExecutable";
            this.lblMainExecutable.Size = new System.Drawing.Size(167, 13);
            this.lblMainExecutable.TabIndex = 9;
            this.lblMainExecutable.Text = "Select the main executable:";
            // 
            // ConstantsGroupBox
            // 
            this.ConstantsGroupBox.Controls.Add(this.CompressConstantsCheckBox);
            this.ConstantsGroupBox.Controls.Add(this.ConstantCheckBox);
            this.ConstantsGroupBox.Controls.Add(this.EmbedConstantsCheckBox);
            this.ConstantsGroupBox.Controls.Add(this.EncryptConstantsCheckBox);
            this.ConstantsGroupBox.Enabled = false;
            this.ConstantsGroupBox.Location = new System.Drawing.Point(14, 161);
            this.ConstantsGroupBox.Name = "ConstantsGroupBox";
            this.ConstantsGroupBox.Size = new System.Drawing.Size(268, 40);
            this.ConstantsGroupBox.TabIndex = 8;
            this.ConstantsGroupBox.TabStop = false;
            this.ConstantsGroupBox.Text = "Constants";
            // 
            // CompressConstantsCheckBox
            // 
            this.CompressConstantsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CompressConstantsCheckBox.AutoSize = true;
            this.CompressConstantsCheckBox.Checked = true;
            this.CompressConstantsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CompressConstantsCheckBox.Location = new System.Drawing.Point(175, 16);
            this.CompressConstantsCheckBox.Name = "CompressConstantsCheckBox";
            this.CompressConstantsCheckBox.Size = new System.Drawing.Size(83, 17);
            this.CompressConstantsCheckBox.TabIndex = 5;
            this.CompressConstantsCheckBox.Text = "Compress";
            this.CompressConstantsCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConstantCheckBox
            // 
            this.ConstantCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConstantCheckBox.AutoSize = true;
            this.ConstantCheckBox.Checked = true;
            this.ConstantCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ConstantCheckBox.Location = new System.Drawing.Point(250, 1);
            this.ConstantCheckBox.Name = "ConstantCheckBox";
            this.ConstantCheckBox.Size = new System.Drawing.Size(14, 13);
            this.ConstantCheckBox.TabIndex = 5;
            this.ConstantCheckBox.UseVisualStyleBackColor = true;
            // 
            // EmbedConstantsCheckBox
            // 
            this.EmbedConstantsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EmbedConstantsCheckBox.AutoSize = true;
            this.EmbedConstantsCheckBox.Checked = true;
            this.EmbedConstantsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EmbedConstantsCheckBox.Location = new System.Drawing.Point(96, 16);
            this.EmbedConstantsCheckBox.Name = "EmbedConstantsCheckBox";
            this.EmbedConstantsCheckBox.Size = new System.Drawing.Size(64, 17);
            this.EmbedConstantsCheckBox.TabIndex = 5;
            this.EmbedConstantsCheckBox.Text = "Embed";
            this.EmbedConstantsCheckBox.UseVisualStyleBackColor = true;
            // 
            // EncryptConstantsCheckBox
            // 
            this.EncryptConstantsCheckBox.AutoSize = true;
            this.EncryptConstantsCheckBox.Checked = true;
            this.EncryptConstantsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EncryptConstantsCheckBox.Location = new System.Drawing.Point(16, 16);
            this.EncryptConstantsCheckBox.Name = "EncryptConstantsCheckBox";
            this.EncryptConstantsCheckBox.Size = new System.Drawing.Size(68, 17);
            this.EncryptConstantsCheckBox.TabIndex = 1;
            this.EncryptConstantsCheckBox.Text = "Encrypt";
            this.EncryptConstantsCheckBox.UseVisualStyleBackColor = true;
            // 
            // AssemblyRenameGroupBox
            // 
            this.AssemblyRenameGroupBox.Controls.Add(this.ExcludeMembersButton);
            this.AssemblyRenameGroupBox.Controls.Add(this.MergeNamespacesCheckBox);
            this.AssemblyRenameGroupBox.Controls.Add(this.AssemblyRenameCheckBox);
            this.AssemblyRenameGroupBox.Controls.Add(this.CharacterSetLabel);
            this.AssemblyRenameGroupBox.Controls.Add(this.CharacterSetComboBox);
            this.AssemblyRenameGroupBox.Enabled = false;
            this.AssemblyRenameGroupBox.Location = new System.Drawing.Point(129, 45);
            this.AssemblyRenameGroupBox.Name = "AssemblyRenameGroupBox";
            this.AssemblyRenameGroupBox.Size = new System.Drawing.Size(153, 113);
            this.AssemblyRenameGroupBox.TabIndex = 7;
            this.AssemblyRenameGroupBox.TabStop = false;
            this.AssemblyRenameGroupBox.Text = "Assembly Renaming";
            // 
            // ExcludeMembersButton
            // 
            this.ExcludeMembersButton.Location = new System.Drawing.Point(9, 61);
            this.ExcludeMembersButton.Name = "ExcludeMembersButton";
            this.ExcludeMembersButton.Size = new System.Drawing.Size(135, 23);
            this.ExcludeMembersButton.TabIndex = 4;
            this.ExcludeMembersButton.Text = "Exclude Members";
            this.ExcludeMembersButton.UseVisualStyleBackColor = true;
            // 
            // MergeNamespacesCheckBox
            // 
            this.MergeNamespacesCheckBox.AutoSize = true;
            this.MergeNamespacesCheckBox.Location = new System.Drawing.Point(11, 90);
            this.MergeNamespacesCheckBox.Name = "MergeNamespacesCheckBox";
            this.MergeNamespacesCheckBox.Size = new System.Drawing.Size(136, 17);
            this.MergeNamespacesCheckBox.TabIndex = 3;
            this.MergeNamespacesCheckBox.Text = "Merge Namespaces";
            this.MergeNamespacesCheckBox.UseVisualStyleBackColor = true;
            // 
            // AssemblyRenameCheckBox
            // 
            this.AssemblyRenameCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AssemblyRenameCheckBox.AutoSize = true;
            this.AssemblyRenameCheckBox.Checked = true;
            this.AssemblyRenameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AssemblyRenameCheckBox.Location = new System.Drawing.Point(132, 1);
            this.AssemblyRenameCheckBox.Name = "AssemblyRenameCheckBox";
            this.AssemblyRenameCheckBox.Size = new System.Drawing.Size(14, 13);
            this.AssemblyRenameCheckBox.TabIndex = 2;
            this.AssemblyRenameCheckBox.UseVisualStyleBackColor = true;
            // 
            // CharacterSetLabel
            // 
            this.CharacterSetLabel.AutoSize = true;
            this.CharacterSetLabel.Location = new System.Drawing.Point(8, 19);
            this.CharacterSetLabel.Name = "CharacterSetLabel";
            this.CharacterSetLabel.Size = new System.Drawing.Size(90, 13);
            this.CharacterSetLabel.TabIndex = 1;
            this.CharacterSetLabel.Text = "Character set:";
            // 
            // CharacterSetComboBox
            // 
            this.CharacterSetComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterSetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CharacterSetComboBox.FormattingEnabled = true;
            this.CharacterSetComboBox.Items.AddRange(new object[] {
            "Alphanumeric",
            "Arabic",
            "Chinese",
            "Dots",
            "Invisible",
            "Mixed",
            "Numeric",
            "Symbols",
            "Unicode"});
            this.CharacterSetComboBox.Location = new System.Drawing.Point(9, 35);
            this.CharacterSetComboBox.Name = "CharacterSetComboBox";
            this.CharacterSetComboBox.Size = new System.Drawing.Size(135, 20);
            this.CharacterSetComboBox.TabIndex = 0;
            // 
            // StringsGroupBox
            // 
            this.StringsGroupBox.Controls.Add(this.EncodeStringsCheckBox);
            this.StringsGroupBox.Controls.Add(this.EmbedStringsCheckBox);
            this.StringsGroupBox.Controls.Add(this.CompressStringsCheckBox);
            this.StringsGroupBox.Controls.Add(this.EncryptStringsCheckBox);
            this.StringsGroupBox.Enabled = false;
            this.StringsGroupBox.Location = new System.Drawing.Point(14, 45);
            this.StringsGroupBox.Name = "StringsGroupBox";
            this.StringsGroupBox.Size = new System.Drawing.Size(109, 113);
            this.StringsGroupBox.TabIndex = 6;
            this.StringsGroupBox.TabStop = false;
            this.StringsGroupBox.Text = "Strings";
            // 
            // EncodeStringsCheckBox
            // 
            this.EncodeStringsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EncodeStringsCheckBox.AutoSize = true;
            this.EncodeStringsCheckBox.Checked = true;
            this.EncodeStringsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EncodeStringsCheckBox.Location = new System.Drawing.Point(16, 42);
            this.EncodeStringsCheckBox.Name = "EncodeStringsCheckBox";
            this.EncodeStringsCheckBox.Size = new System.Drawing.Size(66, 17);
            this.EncodeStringsCheckBox.TabIndex = 4;
            this.EncodeStringsCheckBox.Text = "Encode";
            this.EncodeStringsCheckBox.UseVisualStyleBackColor = true;
            // 
            // EmbedStringsCheckBox
            // 
            this.EmbedStringsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EmbedStringsCheckBox.AutoSize = true;
            this.EmbedStringsCheckBox.Checked = true;
            this.EmbedStringsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EmbedStringsCheckBox.Location = new System.Drawing.Point(16, 65);
            this.EmbedStringsCheckBox.Name = "EmbedStringsCheckBox";
            this.EmbedStringsCheckBox.Size = new System.Drawing.Size(64, 17);
            this.EmbedStringsCheckBox.TabIndex = 3;
            this.EmbedStringsCheckBox.Text = "Embed";
            this.EmbedStringsCheckBox.UseVisualStyleBackColor = true;
            this.EmbedStringsCheckBox.CheckedChanged += new System.EventHandler(this.EmbedStringsCheckBox_CheckedChanged);
            // 
            // CompressStringsCheckBox
            // 
            this.CompressStringsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CompressStringsCheckBox.AutoSize = true;
            this.CompressStringsCheckBox.Checked = true;
            this.CompressStringsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CompressStringsCheckBox.Enabled = false;
            this.CompressStringsCheckBox.Location = new System.Drawing.Point(16, 88);
            this.CompressStringsCheckBox.Name = "CompressStringsCheckBox";
            this.CompressStringsCheckBox.Size = new System.Drawing.Size(83, 17);
            this.CompressStringsCheckBox.TabIndex = 2;
            this.CompressStringsCheckBox.Text = "Compress";
            this.CompressStringsCheckBox.UseVisualStyleBackColor = true;
            // 
            // EncryptStringsCheckBox
            // 
            this.EncryptStringsCheckBox.AutoSize = true;
            this.EncryptStringsCheckBox.Checked = true;
            this.EncryptStringsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EncryptStringsCheckBox.Enabled = false;
            this.EncryptStringsCheckBox.Location = new System.Drawing.Point(16, 19);
            this.EncryptStringsCheckBox.Name = "EncryptStringsCheckBox";
            this.EncryptStringsCheckBox.Size = new System.Drawing.Size(68, 17);
            this.EncryptStringsCheckBox.TabIndex = 0;
            this.EncryptStringsCheckBox.Text = "Encrypt";
            this.EncryptStringsCheckBox.UseVisualStyleBackColor = true;
            // 
            // ButtonBrowseProgram
            // 
            this.ButtonBrowseProgram.Location = new System.Drawing.Point(360, 17);
            this.ButtonBrowseProgram.Name = "ButtonBrowseProgram";
            this.ButtonBrowseProgram.Size = new System.Drawing.Size(89, 23);
            this.ButtonBrowseProgram.TabIndex = 2;
            this.ButtonBrowseProgram.Text = "Browse";
            this.ButtonBrowseProgram.UseVisualStyleBackColor = true;
            this.ButtonBrowseProgram.Click += new System.EventHandler(this.ButtonBrowseProgram_Click);
            // 
            // TextBoxProgramLocation
            // 
            this.TextBoxProgramLocation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextBoxProgramLocation.ForeColor = System.Drawing.Color.DimGray;
            this.TextBoxProgramLocation.Location = new System.Drawing.Point(14, 19);
            this.TextBoxProgramLocation.Name = "TextBoxProgramLocation";
            this.TextBoxProgramLocation.ReadOnly = true;
            this.TextBoxProgramLocation.Size = new System.Drawing.Size(340, 20);
            this.TextBoxProgramLocation.TabIndex = 0;
            this.TextBoxProgramLocation.Text = "Please select your programs directory...";
            // 
            // GroupBoxProgramSettings
            // 
            this.GroupBoxProgramSettings.Controls.Add(this.LabelProtectionPreset);
            this.GroupBoxProgramSettings.Controls.Add(this.ButtonVersionMinus);
            this.GroupBoxProgramSettings.Controls.Add(this.ButtonVersionPlus);
            this.GroupBoxProgramSettings.Controls.Add(this.LabelVersion);
            this.GroupBoxProgramSettings.Controls.Add(this.DropDownProtectionPreset);
            this.GroupBoxProgramSettings.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxProgramSettings.Location = new System.Drawing.Point(22, 223);
            this.GroupBoxProgramSettings.Name = "GroupBoxProgramSettings";
            this.GroupBoxProgramSettings.Size = new System.Drawing.Size(175, 110);
            this.GroupBoxProgramSettings.TabIndex = 9;
            this.GroupBoxProgramSettings.TabStop = false;
            this.GroupBoxProgramSettings.Text = "Program Settings";
            // 
            // LabelProtectionPreset
            // 
            this.LabelProtectionPreset.AutoSize = true;
            this.LabelProtectionPreset.Location = new System.Drawing.Point(13, 62);
            this.LabelProtectionPreset.Name = "LabelProtectionPreset";
            this.LabelProtectionPreset.Size = new System.Drawing.Size(109, 13);
            this.LabelProtectionPreset.TabIndex = 4;
            this.LabelProtectionPreset.Text = "Protection Preset:";
            // 
            // ButtonVersionMinus
            // 
            this.ButtonVersionMinus.Location = new System.Drawing.Point(135, 27);
            this.ButtonVersionMinus.Name = "ButtonVersionMinus";
            this.ButtonVersionMinus.Size = new System.Drawing.Size(25, 25);
            this.ButtonVersionMinus.TabIndex = 3;
            this.ButtonVersionMinus.Text = "-";
            this.ButtonVersionMinus.UseVisualStyleBackColor = true;
            this.ButtonVersionMinus.Click += new System.EventHandler(this.ButtonVersionMinus_Click);
            // 
            // ButtonVersionPlus
            // 
            this.ButtonVersionPlus.Location = new System.Drawing.Point(103, 27);
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
            this.LabelVersion.Location = new System.Drawing.Point(13, 32);
            this.LabelVersion.Name = "LabelVersion";
            this.LabelVersion.Size = new System.Drawing.Size(77, 13);
            this.LabelVersion.TabIndex = 1;
            this.LabelVersion.Text = "Version: 1.0";
            // 
            // DropDownProtectionPreset
            // 
            this.DropDownProtectionPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropDownProtectionPreset.Enabled = false;
            this.DropDownProtectionPreset.FormattingEnabled = true;
            this.DropDownProtectionPreset.Items.AddRange(new object[] {
            "None",
            "Minimum",
            "Normal",
            "Maximum",
            "Custom"});
            this.DropDownProtectionPreset.Location = new System.Drawing.Point(16, 80);
            this.DropDownProtectionPreset.Name = "DropDownProtectionPreset";
            this.DropDownProtectionPreset.Size = new System.Drawing.Size(144, 20);
            this.DropDownProtectionPreset.TabIndex = 0;
            this.DropDownProtectionPreset.SelectedIndexChanged += new System.EventHandler(this.DropDownProtectionPreset_SelectedIndexChanged);
            // 
            // GroupBoxProgramInformation
            // 
            this.GroupBoxProgramInformation.Controls.Add(this.LabelProgramName);
            this.GroupBoxProgramInformation.Controls.Add(this.TextBoxProgramDescription);
            this.GroupBoxProgramInformation.Controls.Add(this.LabelProgramDescription);
            this.GroupBoxProgramInformation.Controls.Add(this.TextBoxProgramName);
            this.GroupBoxProgramInformation.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxProgramInformation.Location = new System.Drawing.Point(211, 5);
            this.GroupBoxProgramInformation.Name = "GroupBoxProgramInformation";
            this.GroupBoxProgramInformation.Size = new System.Drawing.Size(468, 181);
            this.GroupBoxProgramInformation.TabIndex = 8;
            this.GroupBoxProgramInformation.TabStop = false;
            // 
            // LabelProgramName
            // 
            this.LabelProgramName.AutoSize = true;
            this.LabelProgramName.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelProgramName.Location = new System.Drawing.Point(13, 20);
            this.LabelProgramName.Name = "LabelProgramName";
            this.LabelProgramName.Size = new System.Drawing.Size(138, 13);
            this.LabelProgramName.TabIndex = 4;
            this.LabelProgramName.Text = "Program Name (0/25):";
            // 
            // TextBoxProgramDescription
            // 
            this.TextBoxProgramDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxProgramDescription.ForeColor = System.Drawing.Color.DimGray;
            this.TextBoxProgramDescription.Location = new System.Drawing.Point(16, 77);
            this.TextBoxProgramDescription.MaxLength = 500;
            this.TextBoxProgramDescription.Multiline = true;
            this.TextBoxProgramDescription.Name = "TextBoxProgramDescription";
            this.TextBoxProgramDescription.Size = new System.Drawing.Size(435, 88);
            this.TextBoxProgramDescription.TabIndex = 3;
            this.TextBoxProgramDescription.Text = "Please enter a description...";
            this.TextBoxProgramDescription.TextChanged += new System.EventHandler(this.TextBoxProgramDescription_TextChanged);
            this.TextBoxProgramDescription.Enter += new System.EventHandler(this.TextBoxProgramDescription_Enter);
            this.TextBoxProgramDescription.Leave += new System.EventHandler(this.TextBoxProgramDescription_Leave);
            // 
            // LabelProgramDescription
            // 
            this.LabelProgramDescription.AutoSize = true;
            this.LabelProgramDescription.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelProgramDescription.Location = new System.Drawing.Point(13, 61);
            this.LabelProgramDescription.Name = "LabelProgramDescription";
            this.LabelProgramDescription.Size = new System.Drawing.Size(123, 13);
            this.LabelProgramDescription.TabIndex = 2;
            this.LabelProgramDescription.Text = "Description (0/500):";
            // 
            // TextBoxProgramName
            // 
            this.TextBoxProgramName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxProgramName.ForeColor = System.Drawing.Color.DimGray;
            this.TextBoxProgramName.Location = new System.Drawing.Point(16, 36);
            this.TextBoxProgramName.MaxLength = 25;
            this.TextBoxProgramName.Name = "TextBoxProgramName";
            this.TextBoxProgramName.Size = new System.Drawing.Size(435, 20);
            this.TextBoxProgramName.TabIndex = 1;
            this.TextBoxProgramName.Text = "Please enter a name...";
            this.TextBoxProgramName.TextChanged += new System.EventHandler(this.TextBoxProgramName_TextChanged);
            this.TextBoxProgramName.Enter += new System.EventHandler(this.TextBoxProgramName_Enter);
            this.TextBoxProgramName.Leave += new System.EventHandler(this.TextBoxProgramName_Leave);
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
            this.PictureBoxProgramImage.TabIndex = 7;
            this.PictureBoxProgramImage.TabStop = false;
            // 
            // ButtonChangeImage
            // 
            this.ButtonChangeImage.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonChangeImage.Location = new System.Drawing.Point(22, 192);
            this.ButtonChangeImage.Name = "ButtonChangeImage";
            this.ButtonChangeImage.Size = new System.Drawing.Size(175, 25);
            this.ButtonChangeImage.TabIndex = 13;
            this.ButtonChangeImage.Text = "Change Image (175x175)";
            this.ButtonChangeImage.UseVisualStyleBackColor = true;
            this.ButtonChangeImage.Click += new System.EventHandler(this.ButtonChangeImage_Click);
            // 
            // CreateProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ButtonChangeImage);
            this.Controls.Add(this.ButtonCreateProgram);
            this.Controls.Add(this.ButtonBack);
            this.Controls.Add(this.GroupBoxProtectionSettings);
            this.Controls.Add(this.GroupBoxProgramSettings);
            this.Controls.Add(this.GroupBoxProgramInformation);
            this.Controls.Add(this.PictureBoxProgramImage);
            this.Name = "CreateProgram";
            this.Size = new System.Drawing.Size(702, 429);
            this.Load += new System.EventHandler(this.CreateProgram_Load);
            this.GroupBoxProtectionSettings.ResumeLayout(false);
            this.GroupBoxProtectionSettings.PerformLayout();
            this.ConstantsGroupBox.ResumeLayout(false);
            this.ConstantsGroupBox.PerformLayout();
            this.AssemblyRenameGroupBox.ResumeLayout(false);
            this.AssemblyRenameGroupBox.PerformLayout();
            this.StringsGroupBox.ResumeLayout(false);
            this.StringsGroupBox.PerformLayout();
            this.GroupBoxProgramSettings.ResumeLayout(false);
            this.GroupBoxProgramSettings.PerformLayout();
            this.GroupBoxProgramInformation.ResumeLayout(false);
            this.GroupBoxProgramInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxProgramImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonCreateProgram;
        private System.Windows.Forms.Button ButtonBack;
        private System.Windows.Forms.GroupBox GroupBoxProtectionSettings;
        private System.Windows.Forms.Button ButtonBrowseProgram;
        private System.Windows.Forms.TextBox TextBoxProgramLocation;
        private System.Windows.Forms.GroupBox GroupBoxProgramSettings;
        private System.Windows.Forms.Label LabelProtectionPreset;
        private System.Windows.Forms.Button ButtonVersionMinus;
        private System.Windows.Forms.Button ButtonVersionPlus;
        private System.Windows.Forms.Label LabelVersion;
        private System.Windows.Forms.ComboBox DropDownProtectionPreset;
        private System.Windows.Forms.GroupBox GroupBoxProgramInformation;
        private System.Windows.Forms.Label LabelProgramName;
        private System.Windows.Forms.TextBox TextBoxProgramDescription;
        private System.Windows.Forms.Label LabelProgramDescription;
        private System.Windows.Forms.TextBox TextBoxProgramName;
        private System.Windows.Forms.PictureBox PictureBoxProgramImage;
        private System.Windows.Forms.Button ButtonChangeImage;
        private System.Windows.Forms.GroupBox ConstantsGroupBox;
        private System.Windows.Forms.CheckBox CompressConstantsCheckBox;
        private System.Windows.Forms.CheckBox ConstantCheckBox;
        private System.Windows.Forms.CheckBox EmbedConstantsCheckBox;
        private System.Windows.Forms.CheckBox EncryptConstantsCheckBox;
        private System.Windows.Forms.GroupBox AssemblyRenameGroupBox;
        private System.Windows.Forms.Button ExcludeMembersButton;
        private System.Windows.Forms.CheckBox MergeNamespacesCheckBox;
        private System.Windows.Forms.CheckBox AssemblyRenameCheckBox;
        private System.Windows.Forms.Label CharacterSetLabel;
        private System.Windows.Forms.ComboBox CharacterSetComboBox;
        private System.Windows.Forms.GroupBox StringsGroupBox;
        private System.Windows.Forms.CheckBox EncodeStringsCheckBox;
        private System.Windows.Forms.CheckBox EmbedStringsCheckBox;
        private System.Windows.Forms.CheckBox CompressStringsCheckBox;
        private System.Windows.Forms.CheckBox EncryptStringsCheckBox;
        private System.Windows.Forms.ComboBox comboMainExecutable;
        private System.Windows.Forms.Label lblMainExecutable;
        private Theme.LineSeparator lineSeparator1;
    }
}
