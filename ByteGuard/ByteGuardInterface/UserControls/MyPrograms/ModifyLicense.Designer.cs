namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    partial class ModifyLicense
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
            this.ThemeContainer = new ByteGuard.ByteGuardInterface.Theme.ThemeContainer();
            this.LineSeparator3 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.LineSeparator2 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.LineSeparator1 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.TextBoxLockReason = new System.Windows.Forms.TextBox();
            this.LabelRedeemedTo = new System.Windows.Forms.Label();
            this.LabelReason = new System.Windows.Forms.Label();
            this.TextBoxRedeemedTo = new System.Windows.Forms.TextBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.LabelCreationDate = new System.Windows.Forms.Label();
            this.DropDownLock = new System.Windows.Forms.ComboBox();
            this.TextBoxCreationDate = new System.Windows.Forms.TextBox();
            this.LabelBanned = new System.Windows.Forms.Label();
            this.LabelDescription = new System.Windows.Forms.Label();
            this.TextBoxTrackingDescription = new System.Windows.Forms.TextBox();
            this.ThemeContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ThemeContainer
            // 
            this.ThemeContainer.Controls.Add(this.LineSeparator3);
            this.ThemeContainer.Controls.Add(this.LineSeparator2);
            this.ThemeContainer.Controls.Add(this.LineSeparator1);
            this.ThemeContainer.Controls.Add(this.TextBoxLockReason);
            this.ThemeContainer.Controls.Add(this.LabelRedeemedTo);
            this.ThemeContainer.Controls.Add(this.LabelReason);
            this.ThemeContainer.Controls.Add(this.TextBoxRedeemedTo);
            this.ThemeContainer.Controls.Add(this.ButtonSave);
            this.ThemeContainer.Controls.Add(this.LabelCreationDate);
            this.ThemeContainer.Controls.Add(this.DropDownLock);
            this.ThemeContainer.Controls.Add(this.TextBoxCreationDate);
            this.ThemeContainer.Controls.Add(this.LabelBanned);
            this.ThemeContainer.Controls.Add(this.LabelDescription);
            this.ThemeContainer.Controls.Add(this.TextBoxTrackingDescription);
            this.ThemeContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThemeContainer.Location = new System.Drawing.Point(0, 0);
            this.ThemeContainer.Name = "ThemeContainer";
            this.ThemeContainer.Size = new System.Drawing.Size(231, 331);
            this.ThemeContainer.TabIndex = 0;
            this.ThemeContainer.Text = "themeContainer1";
            // 
            // LineSeparator3
            // 
            this.LineSeparator3.Location = new System.Drawing.Point(20, 247);
            this.LineSeparator3.MaximumSize = new System.Drawing.Size(2000, 2);
            this.LineSeparator3.MinimumSize = new System.Drawing.Size(0, 2);
            this.LineSeparator3.Name = "LineSeparator3";
            this.LineSeparator3.Size = new System.Drawing.Size(190, 2);
            this.LineSeparator3.TabIndex = 36;
            // 
            // LineSeparator2
            // 
            this.LineSeparator2.Location = new System.Drawing.Point(20, 197);
            this.LineSeparator2.MaximumSize = new System.Drawing.Size(2000, 2);
            this.LineSeparator2.MinimumSize = new System.Drawing.Size(0, 2);
            this.LineSeparator2.Name = "LineSeparator2";
            this.LineSeparator2.Size = new System.Drawing.Size(190, 2);
            this.LineSeparator2.TabIndex = 35;
            // 
            // LineSeparator1
            // 
            this.LineSeparator1.Location = new System.Drawing.Point(20, 107);
            this.LineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.LineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.LineSeparator1.Name = "LineSeparator1";
            this.LineSeparator1.Size = new System.Drawing.Size(190, 2);
            this.LineSeparator1.TabIndex = 34;
            // 
            // TextBoxLockReason
            // 
            this.TextBoxLockReason.Enabled = false;
            this.TextBoxLockReason.Location = new System.Drawing.Point(108, 220);
            this.TextBoxLockReason.MaxLength = 15;
            this.TextBoxLockReason.Name = "TextBoxLockReason";
            this.TextBoxLockReason.Size = new System.Drawing.Size(102, 20);
            this.TextBoxLockReason.TabIndex = 33;
            this.TextBoxLockReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxLockReason.TextChanged += new System.EventHandler(this.TextBoxLockReason_TextChanged);
            this.TextBoxLockReason.Enter += new System.EventHandler(this.TextBoxLockReason_Enter);
            // 
            // LabelRedeemedTo
            // 
            this.LabelRedeemedTo.AutoSize = true;
            this.LabelRedeemedTo.Location = new System.Drawing.Point(17, 63);
            this.LabelRedeemedTo.Name = "LabelRedeemedTo";
            this.LabelRedeemedTo.Size = new System.Drawing.Size(102, 15);
            this.LabelRedeemedTo.TabIndex = 24;
            this.LabelRedeemedTo.Text = "Redeemed (N/A):";
            // 
            // LabelReason
            // 
            this.LabelReason.AutoSize = true;
            this.LabelReason.Location = new System.Drawing.Point(105, 202);
            this.LabelReason.Name = "LabelReason";
            this.LabelReason.Size = new System.Drawing.Size(88, 15);
            this.LabelReason.TabIndex = 32;
            this.LabelReason.Text = "Reason (0/15):";
            // 
            // TextBoxRedeemedTo
            // 
            this.TextBoxRedeemedTo.Location = new System.Drawing.Point(20, 81);
            this.TextBoxRedeemedTo.Name = "TextBoxRedeemedTo";
            this.TextBoxRedeemedTo.ReadOnly = true;
            this.TextBoxRedeemedTo.Size = new System.Drawing.Size(190, 20);
            this.TextBoxRedeemedTo.TabIndex = 26;
            this.TextBoxRedeemedTo.TabStop = false;
            this.TextBoxRedeemedTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Enabled = false;
            this.ButtonSave.Location = new System.Drawing.Point(20, 255);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(190, 25);
            this.ButtonSave.TabIndex = 27;
            this.ButtonSave.Text = "Save Changes";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // LabelCreationDate
            // 
            this.LabelCreationDate.AutoSize = true;
            this.LabelCreationDate.Location = new System.Drawing.Point(17, 112);
            this.LabelCreationDate.Name = "LabelCreationDate";
            this.LabelCreationDate.Size = new System.Drawing.Size(85, 15);
            this.LabelCreationDate.TabIndex = 28;
            this.LabelCreationDate.Text = "Creation Date:";
            // 
            // DropDownLock
            // 
            this.DropDownLock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropDownLock.FormattingEnabled = true;
            this.DropDownLock.Items.AddRange(new object[] {
            "None",
            "Banned",
            "Frozen"});
            this.DropDownLock.Location = new System.Drawing.Point(20, 220);
            this.DropDownLock.Name = "DropDownLock";
            this.DropDownLock.Size = new System.Drawing.Size(82, 21);
            this.DropDownLock.TabIndex = 25;
            this.DropDownLock.SelectedIndexChanged += new System.EventHandler(this.DropDownLock_SelectedIndexChanged);
            // 
            // TextBoxCreationDate
            // 
            this.TextBoxCreationDate.Location = new System.Drawing.Point(20, 130);
            this.TextBoxCreationDate.Name = "TextBoxCreationDate";
            this.TextBoxCreationDate.ReadOnly = true;
            this.TextBoxCreationDate.Size = new System.Drawing.Size(190, 20);
            this.TextBoxCreationDate.TabIndex = 29;
            this.TextBoxCreationDate.TabStop = false;
            this.TextBoxCreationDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LabelBanned
            // 
            this.LabelBanned.AutoSize = true;
            this.LabelBanned.Location = new System.Drawing.Point(17, 202);
            this.LabelBanned.Name = "LabelBanned";
            this.LabelBanned.Size = new System.Drawing.Size(36, 15);
            this.LabelBanned.TabIndex = 31;
            this.LabelBanned.Text = "Lock:";
            // 
            // LabelDescription
            // 
            this.LabelDescription.AutoSize = true;
            this.LabelDescription.Location = new System.Drawing.Point(17, 153);
            this.LabelDescription.Name = "LabelDescription";
            this.LabelDescription.Size = new System.Drawing.Size(122, 15);
            this.LabelDescription.TabIndex = 30;
            this.LabelDescription.Text = "Tracking Description:";
            // 
            // TextBoxTrackingDescription
            // 
            this.TextBoxTrackingDescription.Location = new System.Drawing.Point(20, 171);
            this.TextBoxTrackingDescription.MaxLength = 30;
            this.TextBoxTrackingDescription.Name = "TextBoxTrackingDescription";
            this.TextBoxTrackingDescription.Size = new System.Drawing.Size(190, 20);
            this.TextBoxTrackingDescription.TabIndex = 23;
            this.TextBoxTrackingDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxTrackingDescription.TextChanged += new System.EventHandler(this.TextBoxTrackingDescription_TextChanged);
            // 
            // ModifyLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ThemeContainer);
            this.Name = "ModifyLicense";
            this.Size = new System.Drawing.Size(231, 331);
            this.Load += new System.EventHandler(this.ModifyLicense_Load);
            this.ThemeContainer.ResumeLayout(false);
            this.ThemeContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        
        private ByteGuardInterface.Theme.ThemeContainer ThemeContainer;
        private ByteGuardInterface.Theme.LineSeparator LineSeparator3;
        private ByteGuardInterface.Theme.LineSeparator LineSeparator2;
        private ByteGuardInterface.Theme.LineSeparator LineSeparator1;
        private System.Windows.Forms.TextBox TextBoxLockReason;
        private System.Windows.Forms.Label LabelRedeemedTo;
        private System.Windows.Forms.Label LabelReason;
        private System.Windows.Forms.TextBox TextBoxRedeemedTo;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Label LabelCreationDate;
        private System.Windows.Forms.ComboBox DropDownLock;
        private System.Windows.Forms.TextBox TextBoxCreationDate;
        private System.Windows.Forms.Label LabelBanned;
        private System.Windows.Forms.Label LabelDescription;
        private System.Windows.Forms.TextBox TextBoxTrackingDescription;
    }
}
