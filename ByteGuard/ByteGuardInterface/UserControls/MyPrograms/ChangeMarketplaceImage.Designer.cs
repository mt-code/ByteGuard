namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    partial class ChangeMarketplaceImage
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
            this.gboxControls = new System.Windows.Forms.GroupBox();
            this.txtImageLocation = new System.Windows.Forms.TextBox();
            this.lblFileLocation = new System.Windows.Forms.Label();
            this.verticalLineSeparator1 = new ByteGuard.ByteGuardInterface.Theme.VerticalLineSeparator();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.picMarketplaceImage = new System.Windows.Forms.PictureBox();
            this.gboxControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMarketplaceImage)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxControls
            // 
            this.gboxControls.Controls.Add(this.txtImageLocation);
            this.gboxControls.Controls.Add(this.lblFileLocation);
            this.gboxControls.Controls.Add(this.verticalLineSeparator1);
            this.gboxControls.Controls.Add(this.btnUpload);
            this.gboxControls.Controls.Add(this.btnBrowse);
            this.gboxControls.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxControls.Location = new System.Drawing.Point(3, 383);
            this.gboxControls.Name = "gboxControls";
            this.gboxControls.Size = new System.Drawing.Size(480, 76);
            this.gboxControls.TabIndex = 1;
            this.gboxControls.TabStop = false;
            // 
            // txtImageLocation
            // 
            this.txtImageLocation.Location = new System.Drawing.Point(9, 46);
            this.txtImageLocation.Name = "txtImageLocation";
            this.txtImageLocation.ReadOnly = true;
            this.txtImageLocation.Size = new System.Drawing.Size(260, 20);
            this.txtImageLocation.TabIndex = 4;
            this.txtImageLocation.Text = "Please select an image... (150KB or less)";
            // 
            // lblFileLocation
            // 
            this.lblFileLocation.AutoSize = true;
            this.lblFileLocation.Location = new System.Drawing.Point(6, 30);
            this.lblFileLocation.Name = "lblFileLocation";
            this.lblFileLocation.Size = new System.Drawing.Size(82, 13);
            this.lblFileLocation.TabIndex = 3;
            this.lblFileLocation.Text = "File Location:";
            // 
            // verticalLineSeparator1
            // 
            this.verticalLineSeparator1.Location = new System.Drawing.Point(278, 14);
            this.verticalLineSeparator1.MaximumSize = new System.Drawing.Size(2, 2000);
            this.verticalLineSeparator1.MinimumSize = new System.Drawing.Size(2, 2);
            this.verticalLineSeparator1.Name = "verticalLineSeparator1";
            this.verticalLineSeparator1.Size = new System.Drawing.Size(2, 56);
            this.verticalLineSeparator1.TabIndex = 2;
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.Enabled = false;
            this.btnUpload.Location = new System.Drawing.Point(286, 44);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(188, 25);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "Upload Image";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(286, 13);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(188, 25);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Choose Image (480x378)";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // picMarketplaceImage
            // 
            this.picMarketplaceImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMarketplaceImage.Image = global::ByteGuard.Properties.Resources.DefaultMarketplaceImage;
            this.picMarketplaceImage.Location = new System.Drawing.Point(3, 3);
            this.picMarketplaceImage.Name = "picMarketplaceImage";
            this.picMarketplaceImage.Size = new System.Drawing.Size(480, 378);
            this.picMarketplaceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMarketplaceImage.TabIndex = 0;
            this.picMarketplaceImage.TabStop = false;
            // 
            // ChangeMarketplaceImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gboxControls);
            this.Controls.Add(this.picMarketplaceImage);
            this.Name = "ChangeMarketplaceImage";
            this.Size = new System.Drawing.Size(486, 464);
            this.Load += new System.EventHandler(this.ChangeMarketplaceImage_Load);
            this.gboxControls.ResumeLayout(false);
            this.gboxControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMarketplaceImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picMarketplaceImage;
        private System.Windows.Forms.GroupBox gboxControls;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnBrowse;
        private Theme.VerticalLineSeparator verticalLineSeparator1;
        private System.Windows.Forms.TextBox txtImageLocation;
        private System.Windows.Forms.Label lblFileLocation;
    }
}
