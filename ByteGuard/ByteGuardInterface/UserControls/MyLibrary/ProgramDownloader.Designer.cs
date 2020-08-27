namespace ByteGuard.ByteGuardInterface.UserControls.MyLibrary
{
    partial class ProgramDownloader
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
            this.lblDownload = new System.Windows.Forms.Label();
            this.pbarDownloadProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblDownload
            // 
            this.lblDownload.AutoSize = true;
            this.lblDownload.Location = new System.Drawing.Point(8, 7);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(85, 13);
            this.lblDownload.TabIndex = 0;
            this.lblDownload.Text = "Downloading:";
            // 
            // pbarDownloadProgress
            // 
            this.pbarDownloadProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbarDownloadProgress.Location = new System.Drawing.Point(11, 25);
            this.pbarDownloadProgress.Name = "pbarDownloadProgress";
            this.pbarDownloadProgress.Size = new System.Drawing.Size(405, 18);
            this.pbarDownloadProgress.TabIndex = 1;
            // 
            // ProgramDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbarDownloadProgress);
            this.Controls.Add(this.lblDownload);
            this.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProgramDownloader";
            this.Size = new System.Drawing.Size(428, 53);
            this.Load += new System.EventHandler(this.ProgramDownloader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDownload;
        private System.Windows.Forms.ProgressBar pbarDownloadProgress;
    }
}
