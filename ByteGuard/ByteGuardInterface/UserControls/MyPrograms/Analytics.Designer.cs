namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    partial class Analytics
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
            this.lblMarketplaceOnly = new System.Windows.Forms.Label();
            this.lblNotice = new System.Windows.Forms.Label();
            this.btnViewAnalytics = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMarketplaceOnly
            // 
            this.lblMarketplaceOnly.AutoSize = true;
            this.lblMarketplaceOnly.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketplaceOnly.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMarketplaceOnly.Location = new System.Drawing.Point(200, 1);
            this.lblMarketplaceOnly.Name = "lblMarketplaceOnly";
            this.lblMarketplaceOnly.Size = new System.Drawing.Size(340, 13);
            this.lblMarketplaceOnly.TabIndex = 25;
            this.lblMarketplaceOnly.Text = "This is only enabled for marketplace registered programs.";
            this.lblMarketplaceOnly.Visible = false;
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotice.Location = new System.Drawing.Point(51, 148);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(457, 13);
            this.lblNotice.TabIndex = 26;
            this.lblNotice.Text = "Sorry, we\'re afraid the analytics module is not yet implemented into the client.";
            // 
            // btnViewAnalytics
            // 
            this.btnViewAnalytics.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAnalytics.Location = new System.Drawing.Point(88, 182);
            this.btnViewAnalytics.Name = "btnViewAnalytics";
            this.btnViewAnalytics.Size = new System.Drawing.Size(388, 23);
            this.btnViewAnalytics.TabIndex = 27;
            this.btnViewAnalytics.Text = "Click here to view your analytics on the website";
            this.btnViewAnalytics.UseVisualStyleBackColor = true;
            this.btnViewAnalytics.Click += new System.EventHandler(this.btnViewAnalytics_Click);
            // 
            // Analytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnViewAnalytics);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.lblMarketplaceOnly);
            this.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Analytics";
            this.Size = new System.Drawing.Size(548, 397);
            this.Load += new System.EventHandler(this.Analytics_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMarketplaceOnly;
        private System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.Button btnViewAnalytics;
    }
}
