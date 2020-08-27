namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    partial class RedeemLicense
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
            this.ThemeContainer = new ByteGuardInterface.Theme.ThemeContainer();
            this.lineSeparator3 = new ByteGuardInterface.Theme.LineSeparator();
            this.lineSeparator2 = new ByteGuardInterface.Theme.LineSeparator();
            this.lineSeparator1 = new ByteGuardInterface.Theme.LineSeparator();
            this.DropDownLicenseType = new System.Windows.Forms.ComboBox();
            this.LabelLicenseType = new System.Windows.Forms.Label();
            this.ButtonRedeem = new System.Windows.Forms.Button();
            this.TextBoxTrackingDescription = new System.Windows.Forms.TextBox();
            this.LabelTrackingDesc = new System.Windows.Forms.Label();
            this.TextBoxValue = new System.Windows.Forms.NumericUpDown();
            this.LabelValue = new System.Windows.Forms.Label();
            this.TextBoxRedeemTo = new System.Windows.Forms.TextBox();
            this.LabelReedemTo = new System.Windows.Forms.Label();
            this.ThemeContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxValue)).BeginInit();
            this.SuspendLayout();
            // 
            // ThemeContainer
            // 
            this.ThemeContainer.Controls.Add(this.lineSeparator3);
            this.ThemeContainer.Controls.Add(this.lineSeparator2);
            this.ThemeContainer.Controls.Add(this.lineSeparator1);
            this.ThemeContainer.Controls.Add(this.DropDownLicenseType);
            this.ThemeContainer.Controls.Add(this.LabelLicenseType);
            this.ThemeContainer.Controls.Add(this.ButtonRedeem);
            this.ThemeContainer.Controls.Add(this.TextBoxTrackingDescription);
            this.ThemeContainer.Controls.Add(this.LabelTrackingDesc);
            this.ThemeContainer.Controls.Add(this.TextBoxValue);
            this.ThemeContainer.Controls.Add(this.LabelValue);
            this.ThemeContainer.Controls.Add(this.TextBoxRedeemTo);
            this.ThemeContainer.Controls.Add(this.LabelReedemTo);
            this.ThemeContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThemeContainer.Location = new System.Drawing.Point(0, 0);
            this.ThemeContainer.Name = "ThemeContainer";
            this.ThemeContainer.Size = new System.Drawing.Size(231, 331);
            this.ThemeContainer.TabIndex = 0;
            this.ThemeContainer.Text = "themeContainer1";
            // 
            // lineSeparator3
            // 
            this.lineSeparator3.Location = new System.Drawing.Point(32, 240);
            this.lineSeparator3.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator3.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator3.Name = "lineSeparator3";
            this.lineSeparator3.Size = new System.Drawing.Size(166, 2);
            this.lineSeparator3.TabIndex = 23;
            // 
            // lineSeparator2
            // 
            this.lineSeparator2.Location = new System.Drawing.Point(32, 193);
            this.lineSeparator2.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator2.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator2.Name = "lineSeparator2";
            this.lineSeparator2.Size = new System.Drawing.Size(166, 2);
            this.lineSeparator2.TabIndex = 22;
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(32, 106);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(166, 2);
            this.lineSeparator1.TabIndex = 21;
            // 
            // DropDownLicenseType
            // 
            this.DropDownLicenseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropDownLicenseType.Enabled = false;
            this.DropDownLicenseType.FormattingEnabled = true;
            this.DropDownLicenseType.Items.AddRange(new object[] {
            "Duration",
            "Points"});
            this.DropDownLicenseType.Location = new System.Drawing.Point(32, 127);
            this.DropDownLicenseType.Name = "DropDownLicenseType";
            this.DropDownLicenseType.Size = new System.Drawing.Size(166, 21);
            this.DropDownLicenseType.TabIndex = 20;
            // 
            // LabelLicenseType
            // 
            this.LabelLicenseType.AutoSize = true;
            this.LabelLicenseType.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLicenseType.Location = new System.Drawing.Point(29, 111);
            this.LabelLicenseType.Name = "LabelLicenseType";
            this.LabelLicenseType.Size = new System.Drawing.Size(86, 13);
            this.LabelLicenseType.TabIndex = 19;
            this.LabelLicenseType.Text = "License Type:";
            // 
            // ButtonRedeem
            // 
            this.ButtonRedeem.Location = new System.Drawing.Point(32, 248);
            this.ButtonRedeem.Name = "ButtonRedeem";
            this.ButtonRedeem.Size = new System.Drawing.Size(166, 25);
            this.ButtonRedeem.TabIndex = 18;
            this.ButtonRedeem.Text = "Redeem License";
            this.ButtonRedeem.UseVisualStyleBackColor = true;
            this.ButtonRedeem.Click += new System.EventHandler(this.ButtonRedeem_Click);
            // 
            // TextBoxTrackingDescription
            // 
            this.TextBoxTrackingDescription.BackColor = System.Drawing.SystemColors.Control;
            this.TextBoxTrackingDescription.Enabled = false;
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
            this.TextBoxValue.BackColor = System.Drawing.SystemColors.Control;
            this.TextBoxValue.Enabled = false;
            this.TextBoxValue.Location = new System.Drawing.Point(32, 167);
            this.TextBoxValue.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.TextBoxValue.Name = "TextBoxValue";
            this.TextBoxValue.Size = new System.Drawing.Size(166, 20);
            this.TextBoxValue.TabIndex = 15;
            // 
            // LabelValue
            // 
            this.LabelValue.AutoSize = true;
            this.LabelValue.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelValue.Location = new System.Drawing.Point(29, 151);
            this.LabelValue.Name = "LabelValue";
            this.LabelValue.Size = new System.Drawing.Size(132, 13);
            this.LabelValue.TabIndex = 14;
            this.LabelValue.Text = "Days (0 = Unlimited):";
            // 
            // TextBoxRedeemTo
            // 
            this.TextBoxRedeemTo.BackColor = System.Drawing.SystemColors.Window;
            this.TextBoxRedeemTo.ForeColor = System.Drawing.Color.DimGray;
            this.TextBoxRedeemTo.Location = new System.Drawing.Point(32, 80);
            this.TextBoxRedeemTo.MaxLength = 12;
            this.TextBoxRedeemTo.Name = "TextBoxRedeemTo";
            this.TextBoxRedeemTo.Size = new System.Drawing.Size(166, 20);
            this.TextBoxRedeemTo.TabIndex = 13;
            this.TextBoxRedeemTo.Text = "Username";
            this.TextBoxRedeemTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxRedeemTo.Enter += new System.EventHandler(this.TextBoxRedeemTo_Enter);
            // 
            // LabelReedemTo
            // 
            this.LabelReedemTo.AutoSize = true;
            this.LabelReedemTo.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelReedemTo.Location = new System.Drawing.Point(29, 64);
            this.LabelReedemTo.Name = "LabelReedemTo";
            this.LabelReedemTo.Size = new System.Drawing.Size(77, 13);
            this.LabelReedemTo.TabIndex = 12;
            this.LabelReedemTo.Text = "Redeem To:";
            // 
            // RedeemLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ThemeContainer);
            this.Name = "RedeemLicense";
            this.Size = new System.Drawing.Size(231, 331);
            this.Load += new System.EventHandler(this.RedeemLicense_Load);
            this.ThemeContainer.ResumeLayout(false);
            this.ThemeContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Theme.ThemeContainer ThemeContainer;
        private Theme.LineSeparator lineSeparator3;
        private Theme.LineSeparator lineSeparator2;
        private Theme.LineSeparator lineSeparator1;
        private System.Windows.Forms.ComboBox DropDownLicenseType;
        private System.Windows.Forms.Label LabelLicenseType;
        private System.Windows.Forms.Button ButtonRedeem;
        private System.Windows.Forms.TextBox TextBoxTrackingDescription;
        private System.Windows.Forms.Label LabelTrackingDesc;
        private System.Windows.Forms.NumericUpDown TextBoxValue;
        private System.Windows.Forms.Label LabelValue;
        private System.Windows.Forms.TextBox TextBoxRedeemTo;
        private System.Windows.Forms.Label LabelReedemTo;
    }
}
