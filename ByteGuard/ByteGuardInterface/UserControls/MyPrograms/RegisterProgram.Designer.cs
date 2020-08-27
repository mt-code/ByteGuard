namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    partial class RegisterProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterProgram));
            this.lblDistributionStatus = new System.Windows.Forms.Label();
            this.lblDistributionStatusLabel = new System.Windows.Forms.Label();
            this.lblByteGuardMarketplace = new System.Windows.Forms.Label();
            this.tbDistributionModelInformation = new System.Windows.Forms.TextBox();
            this.lblSelfDistribution = new System.Windows.Forms.Label();
            this.lblMarketplaceDistribution = new System.Windows.Forms.Label();
            this.btnRegisterSelf = new System.Windows.Forms.Button();
            this.btnRegisterMarketplace = new System.Windows.Forms.Button();
            this.tbSelfDistributionInfo = new System.Windows.Forms.TextBox();
            this.tbMarketplaceInfo = new System.Windows.Forms.TextBox();
            this.lblFreeTrial = new System.Windows.Forms.Label();
            this.linkMarketplaceDistribution = new System.Windows.Forms.LinkLabel();
            this.linkSelfDistribution = new System.Windows.Forms.LinkLabel();
            this.lineSeparator3 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.verticalLineSeparator1 = new ByteGuard.ByteGuardInterface.Theme.VerticalLineSeparator();
            this.lineSeparator2 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.lineSeparator1 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDistributionStatus
            // 
            this.lblDistributionStatus.AutoSize = true;
            this.lblDistributionStatus.Font = new System.Drawing.Font("Verdana", 14.11765F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistributionStatus.ForeColor = System.Drawing.Color.DarkGray;
            this.lblDistributionStatus.Location = new System.Drawing.Point(251, 15);
            this.lblDistributionStatus.Name = "lblDistributionStatus";
            this.lblDistributionStatus.Size = new System.Drawing.Size(206, 25);
            this.lblDistributionStatus.TabIndex = 6;
            this.lblDistributionStatus.Text = "Awaiting Selection";
            // 
            // lblDistributionStatusLabel
            // 
            this.lblDistributionStatusLabel.AutoSize = true;
            this.lblDistributionStatusLabel.Font = new System.Drawing.Font("Verdana", 16.23529F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistributionStatusLabel.Location = new System.Drawing.Point(14, 13);
            this.lblDistributionStatusLabel.Name = "lblDistributionStatusLabel";
            this.lblDistributionStatusLabel.Size = new System.Drawing.Size(231, 28);
            this.lblDistributionStatusLabel.TabIndex = 5;
            this.lblDistributionStatusLabel.Text = "Distribution Model:";
            // 
            // lblByteGuardMarketplace
            // 
            this.lblByteGuardMarketplace.AutoSize = true;
            this.lblByteGuardMarketplace.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblByteGuardMarketplace.ForeColor = System.Drawing.Color.DimGray;
            this.lblByteGuardMarketplace.Location = new System.Drawing.Point(16, 57);
            this.lblByteGuardMarketplace.Name = "lblByteGuardMarketplace";
            this.lblByteGuardMarketplace.Size = new System.Drawing.Size(307, 14);
            this.lblByteGuardMarketplace.TabIndex = 7;
            this.lblByteGuardMarketplace.Text = "Selecting the right distribution model for you:";
            // 
            // tbDistributionModelInformation
            // 
            this.tbDistributionModelInformation.BackColor = System.Drawing.SystemColors.Control;
            this.tbDistributionModelInformation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDistributionModelInformation.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbDistributionModelInformation.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDistributionModelInformation.Location = new System.Drawing.Point(19, 80);
            this.tbDistributionModelInformation.Multiline = true;
            this.tbDistributionModelInformation.Name = "tbDistributionModelInformation";
            this.tbDistributionModelInformation.ReadOnly = true;
            this.tbDistributionModelInformation.Size = new System.Drawing.Size(665, 84);
            this.tbDistributionModelInformation.TabIndex = 8;
            this.tbDistributionModelInformation.Text = resources.GetString("tbDistributionModelInformation.Text");
            this.tbDistributionModelInformation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbDistributionModelInformation_MouseUp);
            // 
            // lblSelfDistribution
            // 
            this.lblSelfDistribution.AutoSize = true;
            this.lblSelfDistribution.Font = new System.Drawing.Font("Verdana", 12.70588F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelfDistribution.Location = new System.Drawing.Point(106, 178);
            this.lblSelfDistribution.Name = "lblSelfDistribution";
            this.lblSelfDistribution.Size = new System.Drawing.Size(154, 22);
            this.lblSelfDistribution.TabIndex = 10;
            this.lblSelfDistribution.Text = "Self Distribution";
            // 
            // lblMarketplaceDistribution
            // 
            this.lblMarketplaceDistribution.AutoSize = true;
            this.lblMarketplaceDistribution.Font = new System.Drawing.Font("Verdana", 12.70588F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketplaceDistribution.Location = new System.Drawing.Point(405, 178);
            this.lblMarketplaceDistribution.Name = "lblMarketplaceDistribution";
            this.lblMarketplaceDistribution.Size = new System.Drawing.Size(230, 22);
            this.lblMarketplaceDistribution.TabIndex = 11;
            this.lblMarketplaceDistribution.Text = "Marketplace Distribution";
            // 
            // btnRegisterSelf
            // 
            this.btnRegisterSelf.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterSelf.Location = new System.Drawing.Point(23, 391);
            this.btnRegisterSelf.Name = "btnRegisterSelf";
            this.btnRegisterSelf.Size = new System.Drawing.Size(321, 25);
            this.btnRegisterSelf.TabIndex = 14;
            this.btnRegisterSelf.Text = "Select Self Distribution (£2.50) [50% OFF]";
            this.btnRegisterSelf.UseVisualStyleBackColor = true;
            this.btnRegisterSelf.Click += new System.EventHandler(this.btnRegisterSelf_Click);
            // 
            // btnRegisterMarketplace
            // 
            this.btnRegisterMarketplace.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterMarketplace.Location = new System.Drawing.Point(359, 391);
            this.btnRegisterMarketplace.Name = "btnRegisterMarketplace";
            this.btnRegisterMarketplace.Size = new System.Drawing.Size(321, 25);
            this.btnRegisterMarketplace.TabIndex = 15;
            this.btnRegisterMarketplace.Text = "Select Marketplace Distribution (£25) [50% OFF]";
            this.btnRegisterMarketplace.UseVisualStyleBackColor = true;
            this.btnRegisterMarketplace.Click += new System.EventHandler(this.btnRegisterMarketplace_Click);
            // 
            // tbSelfDistributionInfo
            // 
            this.tbSelfDistributionInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tbSelfDistributionInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSelfDistributionInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbSelfDistributionInfo.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSelfDistributionInfo.Location = new System.Drawing.Point(23, 239);
            this.tbSelfDistributionInfo.Multiline = true;
            this.tbSelfDistributionInfo.Name = "tbSelfDistributionInfo";
            this.tbSelfDistributionInfo.ReadOnly = true;
            this.tbSelfDistributionInfo.Size = new System.Drawing.Size(321, 131);
            this.tbSelfDistributionInfo.TabIndex = 16;
            this.tbSelfDistributionInfo.Text = resources.GetString("tbSelfDistributionInfo.Text");
            this.tbSelfDistributionInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbSelfDistributionInfo_MouseUp);
            // 
            // tbMarketplaceInfo
            // 
            this.tbMarketplaceInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tbMarketplaceInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMarketplaceInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbMarketplaceInfo.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMarketplaceInfo.Location = new System.Drawing.Point(359, 239);
            this.tbMarketplaceInfo.Multiline = true;
            this.tbMarketplaceInfo.Name = "tbMarketplaceInfo";
            this.tbMarketplaceInfo.ReadOnly = true;
            this.tbMarketplaceInfo.Size = new System.Drawing.Size(321, 146);
            this.tbMarketplaceInfo.TabIndex = 17;
            this.tbMarketplaceInfo.Text = resources.GetString("tbMarketplaceInfo.Text");
            this.tbMarketplaceInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbMarketplaceInfo_MouseUp);
            // 
            // lblFreeTrial
            // 
            this.lblFreeTrial.AutoSize = true;
            this.lblFreeTrial.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreeTrial.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblFreeTrial.Location = new System.Drawing.Point(25, 369);
            this.lblFreeTrial.Name = "lblFreeTrial";
            this.lblFreeTrial.Size = new System.Drawing.Size(314, 13);
            this.lblFreeTrial.TabIndex = 18;
            this.lblFreeTrial.Text = "* Eligible for free self distribution trial - 1 remaining *";
            this.lblFreeTrial.Visible = false;
            // 
            // linkMarketplaceDistribution
            // 
            this.linkMarketplaceDistribution.AutoSize = true;
            this.linkMarketplaceDistribution.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkMarketplaceDistribution.Location = new System.Drawing.Point(470, 203);
            this.linkMarketplaceDistribution.Name = "linkMarketplaceDistribution";
            this.linkMarketplaceDistribution.Size = new System.Drawing.Size(106, 13);
            this.linkMarketplaceDistribution.TabIndex = 19;
            this.linkMarketplaceDistribution.TabStop = true;
            this.linkMarketplaceDistribution.Text = "More Information";
            // 
            // linkSelfDistribution
            // 
            this.linkSelfDistribution.AutoSize = true;
            this.linkSelfDistribution.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSelfDistribution.Location = new System.Drawing.Point(130, 203);
            this.linkSelfDistribution.Name = "linkSelfDistribution";
            this.linkSelfDistribution.Size = new System.Drawing.Size(106, 13);
            this.linkSelfDistribution.TabIndex = 20;
            this.linkSelfDistribution.TabStop = true;
            this.linkSelfDistribution.Text = "More Information";
            this.linkSelfDistribution.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelfDistribution_LinkClicked);
            // 
            // lineSeparator3
            // 
            this.lineSeparator3.Location = new System.Drawing.Point(19, 225);
            this.lineSeparator3.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator3.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator3.Name = "lineSeparator3";
            this.lineSeparator3.Size = new System.Drawing.Size(665, 2);
            this.lineSeparator3.TabIndex = 13;
            // 
            // verticalLineSeparator1
            // 
            this.verticalLineSeparator1.Location = new System.Drawing.Point(351, 172);
            this.verticalLineSeparator1.MaximumSize = new System.Drawing.Size(2, 2000);
            this.verticalLineSeparator1.MinimumSize = new System.Drawing.Size(2, 2);
            this.verticalLineSeparator1.Name = "verticalLineSeparator1";
            this.verticalLineSeparator1.Size = new System.Drawing.Size(2, 254);
            this.verticalLineSeparator1.TabIndex = 12;
            // 
            // lineSeparator2
            // 
            this.lineSeparator2.Location = new System.Drawing.Point(19, 170);
            this.lineSeparator2.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator2.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator2.Name = "lineSeparator2";
            this.lineSeparator2.Size = new System.Drawing.Size(665, 2);
            this.lineSeparator2.TabIndex = 9;
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(19, 45);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(665, 2);
            this.lineSeparator1.TabIndex = 4;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(609, 16);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 21;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // RegisterProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.linkSelfDistribution);
            this.Controls.Add(this.linkMarketplaceDistribution);
            this.Controls.Add(this.lblFreeTrial);
            this.Controls.Add(this.tbMarketplaceInfo);
            this.Controls.Add(this.tbSelfDistributionInfo);
            this.Controls.Add(this.btnRegisterMarketplace);
            this.Controls.Add(this.btnRegisterSelf);
            this.Controls.Add(this.lineSeparator3);
            this.Controls.Add(this.verticalLineSeparator1);
            this.Controls.Add(this.lblMarketplaceDistribution);
            this.Controls.Add(this.lblSelfDistribution);
            this.Controls.Add(this.lineSeparator2);
            this.Controls.Add(this.tbDistributionModelInformation);
            this.Controls.Add(this.lblByteGuardMarketplace);
            this.Controls.Add(this.lblDistributionStatus);
            this.Controls.Add(this.lblDistributionStatusLabel);
            this.Controls.Add(this.lineSeparator1);
            this.Name = "RegisterProgram";
            this.Size = new System.Drawing.Size(702, 429);
            this.Load += new System.EventHandler(this.RegisterProgram_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDistributionStatus;
        private System.Windows.Forms.Label lblDistributionStatusLabel;
        private Theme.LineSeparator lineSeparator1;
        private System.Windows.Forms.Label lblByteGuardMarketplace;
        private System.Windows.Forms.TextBox tbDistributionModelInformation;
        private Theme.LineSeparator lineSeparator2;
        private System.Windows.Forms.Label lblSelfDistribution;
        private System.Windows.Forms.Label lblMarketplaceDistribution;
        private Theme.VerticalLineSeparator verticalLineSeparator1;
        private Theme.LineSeparator lineSeparator3;
        private System.Windows.Forms.Button btnRegisterSelf;
        private System.Windows.Forms.Button btnRegisterMarketplace;
        private System.Windows.Forms.TextBox tbSelfDistributionInfo;
        private System.Windows.Forms.TextBox tbMarketplaceInfo;
        private System.Windows.Forms.Label lblFreeTrial;
        private System.Windows.Forms.LinkLabel linkMarketplaceDistribution;
        private System.Windows.Forms.LinkLabel linkSelfDistribution;
        private System.Windows.Forms.Button btnBack;

    }
}
