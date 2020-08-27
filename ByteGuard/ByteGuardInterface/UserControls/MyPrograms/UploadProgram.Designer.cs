namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    partial class UploadProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadProgram));
            this.lblWhatToUpload = new System.Windows.Forms.Label();
            this.txtUploadInformation = new System.Windows.Forms.TextBox();
            this.lblMostRecentUpload = new System.Windows.Forms.Label();
            this.gboRecentUpload = new System.Windows.Forms.GroupBox();
            this.txtRecentChecksum = new System.Windows.Forms.TextBox();
            this.lblRecentChecksum = new System.Windows.Forms.Label();
            this.lblRecentFileSize = new System.Windows.Forms.Label();
            this.txtRecentFileSize = new System.Windows.Forms.TextBox();
            this.txtLastUpdated = new System.Windows.Forms.TextBox();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.gboUploadNewProgram = new System.Windows.Forms.GroupBox();
            this.lblCreationTime = new System.Windows.Forms.Label();
            this.txtCreationTime = new System.Windows.Forms.TextBox();
            this.lblNewFileSize = new System.Windows.Forms.Label();
            this.txtNewFilesize = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtNewChecksum = new System.Windows.Forms.TextBox();
            this.lblNewChecksum = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.lblUploadNewProgram = new System.Windows.Forms.Label();
            this.progUploadProgress = new System.Windows.Forms.ProgressBar();
            this.lblMarketplaceOnly = new System.Windows.Forms.Label();
            this.gboRecentUpload.SuspendLayout();
            this.gboUploadNewProgram.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWhatToUpload
            // 
            this.lblWhatToUpload.AutoSize = true;
            this.lblWhatToUpload.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhatToUpload.ForeColor = System.Drawing.Color.DimGray;
            this.lblWhatToUpload.Location = new System.Drawing.Point(5, 0);
            this.lblWhatToUpload.Name = "lblWhatToUpload";
            this.lblWhatToUpload.Size = new System.Drawing.Size(112, 14);
            this.lblWhatToUpload.TabIndex = 14;
            this.lblWhatToUpload.Text = "What to upload:";
            // 
            // txtUploadInformation
            // 
            this.txtUploadInformation.BackColor = System.Drawing.SystemColors.Control;
            this.txtUploadInformation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUploadInformation.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtUploadInformation.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUploadInformation.Location = new System.Drawing.Point(8, 21);
            this.txtUploadInformation.Multiline = true;
            this.txtUploadInformation.Name = "txtUploadInformation";
            this.txtUploadInformation.ReadOnly = true;
            this.txtUploadInformation.Size = new System.Drawing.Size(532, 109);
            this.txtUploadInformation.TabIndex = 15;
            this.txtUploadInformation.Text = resources.GetString("txtUploadInformation.Text");
            // 
            // lblMostRecentUpload
            // 
            this.lblMostRecentUpload.AutoSize = true;
            this.lblMostRecentUpload.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMostRecentUpload.ForeColor = System.Drawing.Color.DimGray;
            this.lblMostRecentUpload.Location = new System.Drawing.Point(5, 143);
            this.lblMostRecentUpload.Name = "lblMostRecentUpload";
            this.lblMostRecentUpload.Size = new System.Drawing.Size(137, 14);
            this.lblMostRecentUpload.TabIndex = 18;
            this.lblMostRecentUpload.Text = "Most recent upload:";
            // 
            // gboRecentUpload
            // 
            this.gboRecentUpload.Controls.Add(this.txtRecentChecksum);
            this.gboRecentUpload.Controls.Add(this.lblRecentChecksum);
            this.gboRecentUpload.Controls.Add(this.lblRecentFileSize);
            this.gboRecentUpload.Controls.Add(this.txtRecentFileSize);
            this.gboRecentUpload.Controls.Add(this.txtLastUpdated);
            this.gboRecentUpload.Controls.Add(this.lblLastUpdated);
            this.gboRecentUpload.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboRecentUpload.Location = new System.Drawing.Point(8, 160);
            this.gboRecentUpload.Name = "gboRecentUpload";
            this.gboRecentUpload.Size = new System.Drawing.Size(532, 56);
            this.gboRecentUpload.TabIndex = 19;
            this.gboRecentUpload.TabStop = false;
            // 
            // txtRecentChecksum
            // 
            this.txtRecentChecksum.Enabled = false;
            this.txtRecentChecksum.Location = new System.Drawing.Point(261, 28);
            this.txtRecentChecksum.Name = "txtRecentChecksum";
            this.txtRecentChecksum.ReadOnly = true;
            this.txtRecentChecksum.Size = new System.Drawing.Size(261, 20);
            this.txtRecentChecksum.TabIndex = 8;
            this.txtRecentChecksum.Text = "N/A";
            this.txtRecentChecksum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRecentChecksum
            // 
            this.lblRecentChecksum.AutoSize = true;
            this.lblRecentChecksum.Location = new System.Drawing.Point(258, 12);
            this.lblRecentChecksum.Name = "lblRecentChecksum";
            this.lblRecentChecksum.Size = new System.Drawing.Size(95, 13);
            this.lblRecentChecksum.TabIndex = 7;
            this.lblRecentChecksum.Text = "File Checksum:";
            // 
            // lblRecentFileSize
            // 
            this.lblRecentFileSize.AutoSize = true;
            this.lblRecentFileSize.Location = new System.Drawing.Point(163, 12);
            this.lblRecentFileSize.Name = "lblRecentFileSize";
            this.lblRecentFileSize.Size = new System.Drawing.Size(59, 13);
            this.lblRecentFileSize.TabIndex = 5;
            this.lblRecentFileSize.Text = "File Size:";
            // 
            // txtRecentFileSize
            // 
            this.txtRecentFileSize.Enabled = false;
            this.txtRecentFileSize.Location = new System.Drawing.Point(166, 28);
            this.txtRecentFileSize.Name = "txtRecentFileSize";
            this.txtRecentFileSize.ReadOnly = true;
            this.txtRecentFileSize.Size = new System.Drawing.Size(89, 20);
            this.txtRecentFileSize.TabIndex = 4;
            this.txtRecentFileSize.Text = "N/A";
            this.txtRecentFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLastUpdated
            // 
            this.txtLastUpdated.Enabled = false;
            this.txtLastUpdated.ForeColor = System.Drawing.Color.Black;
            this.txtLastUpdated.Location = new System.Drawing.Point(10, 28);
            this.txtLastUpdated.Name = "txtLastUpdated";
            this.txtLastUpdated.ReadOnly = true;
            this.txtLastUpdated.Size = new System.Drawing.Size(150, 20);
            this.txtLastUpdated.TabIndex = 1;
            this.txtLastUpdated.Text = "N/A";
            this.txtLastUpdated.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.AutoSize = true;
            this.lblLastUpdated.Location = new System.Drawing.Point(7, 12);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(86, 13);
            this.lblLastUpdated.TabIndex = 0;
            this.lblLastUpdated.Text = "Last Updated:";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(6, 366);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 25);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // gboUploadNewProgram
            // 
            this.gboUploadNewProgram.Controls.Add(this.lblCreationTime);
            this.gboUploadNewProgram.Controls.Add(this.txtCreationTime);
            this.gboUploadNewProgram.Controls.Add(this.lblNewFileSize);
            this.gboUploadNewProgram.Controls.Add(this.txtNewFilesize);
            this.gboUploadNewProgram.Controls.Add(this.txtLocation);
            this.gboUploadNewProgram.Controls.Add(this.lblLocation);
            this.gboUploadNewProgram.Controls.Add(this.txtNewChecksum);
            this.gboUploadNewProgram.Controls.Add(this.lblNewChecksum);
            this.gboUploadNewProgram.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboUploadNewProgram.Location = new System.Drawing.Point(8, 248);
            this.gboUploadNewProgram.Name = "gboUploadNewProgram";
            this.gboUploadNewProgram.Size = new System.Drawing.Size(532, 103);
            this.gboUploadNewProgram.TabIndex = 21;
            this.gboUploadNewProgram.TabStop = false;
            // 
            // lblCreationTime
            // 
            this.lblCreationTime.AutoSize = true;
            this.lblCreationTime.Location = new System.Drawing.Point(369, 57);
            this.lblCreationTime.Name = "lblCreationTime";
            this.lblCreationTime.Size = new System.Drawing.Size(90, 13);
            this.lblCreationTime.TabIndex = 9;
            this.lblCreationTime.Text = "Time Created:";
            // 
            // txtCreationTime
            // 
            this.txtCreationTime.Enabled = false;
            this.txtCreationTime.ForeColor = System.Drawing.Color.Black;
            this.txtCreationTime.Location = new System.Drawing.Point(372, 73);
            this.txtCreationTime.Name = "txtCreationTime";
            this.txtCreationTime.ReadOnly = true;
            this.txtCreationTime.Size = new System.Drawing.Size(150, 20);
            this.txtCreationTime.TabIndex = 9;
            this.txtCreationTime.Text = "N/A";
            this.txtCreationTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNewFileSize
            // 
            this.lblNewFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNewFileSize.AutoSize = true;
            this.lblNewFileSize.Location = new System.Drawing.Point(274, 57);
            this.lblNewFileSize.Name = "lblNewFileSize";
            this.lblNewFileSize.Size = new System.Drawing.Size(59, 13);
            this.lblNewFileSize.TabIndex = 10;
            this.lblNewFileSize.Text = "File Size:";
            // 
            // txtNewFilesize
            // 
            this.txtNewFilesize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNewFilesize.Enabled = false;
            this.txtNewFilesize.Location = new System.Drawing.Point(277, 73);
            this.txtNewFilesize.Name = "txtNewFilesize";
            this.txtNewFilesize.ReadOnly = true;
            this.txtNewFilesize.Size = new System.Drawing.Size(89, 20);
            this.txtNewFilesize.TabIndex = 9;
            this.txtNewFilesize.Text = "N/A";
            this.txtNewFilesize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(10, 28);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(512, 20);
            this.txtLocation.TabIndex = 16;
            this.txtLocation.Text = "No file found, please update your program.";
            this.txtLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(7, 12);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(59, 13);
            this.lblLocation.TabIndex = 15;
            this.lblLocation.Text = "Location:";
            // 
            // txtNewChecksum
            // 
            this.txtNewChecksum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNewChecksum.Enabled = false;
            this.txtNewChecksum.Location = new System.Drawing.Point(10, 73);
            this.txtNewChecksum.Name = "txtNewChecksum";
            this.txtNewChecksum.ReadOnly = true;
            this.txtNewChecksum.Size = new System.Drawing.Size(261, 20);
            this.txtNewChecksum.TabIndex = 14;
            this.txtNewChecksum.Text = "N/A";
            this.txtNewChecksum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNewChecksum
            // 
            this.lblNewChecksum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNewChecksum.AutoSize = true;
            this.lblNewChecksum.Location = new System.Drawing.Point(7, 57);
            this.lblNewChecksum.Name = "lblNewChecksum";
            this.lblNewChecksum.Size = new System.Drawing.Size(95, 13);
            this.lblNewChecksum.TabIndex = 13;
            this.lblNewChecksum.Text = "File Checksum:";
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(285, 366);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(255, 25);
            this.btnUpload.TabIndex = 18;
            this.btnUpload.Text = "Upload To Server";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lblUploadNewProgram
            // 
            this.lblUploadNewProgram.AutoSize = true;
            this.lblUploadNewProgram.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUploadNewProgram.ForeColor = System.Drawing.Color.DimGray;
            this.lblUploadNewProgram.Location = new System.Drawing.Point(5, 231);
            this.lblUploadNewProgram.Name = "lblUploadNewProgram";
            this.lblUploadNewProgram.Size = new System.Drawing.Size(219, 14);
            this.lblUploadNewProgram.TabIndex = 22;
            this.lblUploadNewProgram.Text = "Upload a new program/version:";
            // 
            // progUploadProgress
            // 
            this.progUploadProgress.Location = new System.Drawing.Point(87, 367);
            this.progUploadProgress.Name = "progUploadProgress";
            this.progUploadProgress.Size = new System.Drawing.Size(453, 24);
            this.progUploadProgress.TabIndex = 23;
            this.progUploadProgress.Visible = false;
            // 
            // lblMarketplaceOnly
            // 
            this.lblMarketplaceOnly.AutoSize = true;
            this.lblMarketplaceOnly.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketplaceOnly.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMarketplaceOnly.Location = new System.Drawing.Point(200, 1);
            this.lblMarketplaceOnly.Name = "lblMarketplaceOnly";
            this.lblMarketplaceOnly.Size = new System.Drawing.Size(340, 13);
            this.lblMarketplaceOnly.TabIndex = 24;
            this.lblMarketplaceOnly.Text = "This is only enabled for marketplace registered programs.";
            this.lblMarketplaceOnly.Visible = false;
            // 
            // UploadProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMarketplaceOnly);
            this.Controls.Add(this.lblUploadNewProgram);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.gboUploadNewProgram);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gboRecentUpload);
            this.Controls.Add(this.lblMostRecentUpload);
            this.Controls.Add(this.txtUploadInformation);
            this.Controls.Add(this.lblWhatToUpload);
            this.Controls.Add(this.progUploadProgress);
            this.Name = "UploadProgram";
            this.Size = new System.Drawing.Size(548, 397);
            this.Load += new System.EventHandler(this.UploadProgram_Load);
            this.gboRecentUpload.ResumeLayout(false);
            this.gboRecentUpload.PerformLayout();
            this.gboUploadNewProgram.ResumeLayout(false);
            this.gboUploadNewProgram.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWhatToUpload;
        private System.Windows.Forms.TextBox txtUploadInformation;
        private System.Windows.Forms.Label lblMostRecentUpload;
        private System.Windows.Forms.GroupBox gboRecentUpload;
        private System.Windows.Forms.TextBox txtRecentChecksum;
        private System.Windows.Forms.Label lblRecentChecksum;
        private System.Windows.Forms.Label lblRecentFileSize;
        private System.Windows.Forms.TextBox txtRecentFileSize;
        private System.Windows.Forms.TextBox txtLastUpdated;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox gboUploadNewProgram;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtNewChecksum;
        private System.Windows.Forms.Label lblNewChecksum;
        private System.Windows.Forms.Label lblNewFileSize;
        private System.Windows.Forms.TextBox txtNewFilesize;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label lblUploadNewProgram;
        private System.Windows.Forms.Label lblCreationTime;
        private System.Windows.Forms.TextBox txtCreationTime;
        private System.Windows.Forms.ProgressBar progUploadProgress;
        private System.Windows.Forms.Label lblMarketplaceOnly;
    }
}
