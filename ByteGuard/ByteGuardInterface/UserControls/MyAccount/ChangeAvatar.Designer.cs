namespace ByteGuard.ByteGuardInterface.UserControls.MyAccount
{
    partial class ChangeAvatar
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
            this.PictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.GroupBoxAvatar = new System.Windows.Forms.GroupBox();
            this.GroupBoxAvatarImage = new System.Windows.Forms.GroupBox();
            this.TextBoxImageLocation = new System.Windows.Forms.TextBox();
            this.ButtonBrowseAvatar = new System.Windows.Forms.Button();
            this.ButtonResetAvatar = new System.Windows.Forms.Button();
            this.ButtonSaveAvatar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxAvatar)).BeginInit();
            this.GroupBoxAvatar.SuspendLayout();
            this.GroupBoxAvatarImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBoxAvatar
            // 
            this.PictureBoxAvatar.BackColor = System.Drawing.Color.White;
            this.PictureBoxAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBoxAvatar.Image = global::ByteGuard.Properties.Resources.ByteGuardDefaultProfileImage;
            this.PictureBoxAvatar.Location = new System.Drawing.Point(13, 12);
            this.PictureBoxAvatar.Name = "PictureBoxAvatar";
            this.PictureBoxAvatar.Size = new System.Drawing.Size(175, 175);
            this.PictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxAvatar.TabIndex = 16;
            this.PictureBoxAvatar.TabStop = false;
            // 
            // GroupBoxAvatar
            // 
            this.GroupBoxAvatar.Controls.Add(this.ButtonSaveAvatar);
            this.GroupBoxAvatar.Controls.Add(this.GroupBoxAvatarImage);
            this.GroupBoxAvatar.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxAvatar.Location = new System.Drawing.Point(197, 7);
            this.GroupBoxAvatar.Name = "GroupBoxAvatar";
            this.GroupBoxAvatar.Size = new System.Drawing.Size(233, 180);
            this.GroupBoxAvatar.TabIndex = 17;
            this.GroupBoxAvatar.TabStop = false;
            // 
            // GroupBoxAvatarImage
            // 
            this.GroupBoxAvatarImage.Controls.Add(this.ButtonResetAvatar);
            this.GroupBoxAvatarImage.Controls.Add(this.ButtonBrowseAvatar);
            this.GroupBoxAvatarImage.Controls.Add(this.TextBoxImageLocation);
            this.GroupBoxAvatarImage.Location = new System.Drawing.Point(6, 11);
            this.GroupBoxAvatarImage.Name = "GroupBoxAvatarImage";
            this.GroupBoxAvatarImage.Size = new System.Drawing.Size(221, 104);
            this.GroupBoxAvatarImage.TabIndex = 0;
            this.GroupBoxAvatarImage.TabStop = false;
            this.GroupBoxAvatarImage.Text = "Avatar Image:";
            // 
            // TextBoxImageLocation
            // 
            this.TextBoxImageLocation.Location = new System.Drawing.Point(6, 19);
            this.TextBoxImageLocation.Name = "TextBoxImageLocation";
            this.TextBoxImageLocation.ReadOnly = true;
            this.TextBoxImageLocation.Size = new System.Drawing.Size(209, 20);
            this.TextBoxImageLocation.TabIndex = 0;
            // 
            // ButtonBrowseAvatar
            // 
            this.ButtonBrowseAvatar.Location = new System.Drawing.Point(6, 45);
            this.ButtonBrowseAvatar.Name = "ButtonBrowseAvatar";
            this.ButtonBrowseAvatar.Size = new System.Drawing.Size(209, 25);
            this.ButtonBrowseAvatar.TabIndex = 1;
            this.ButtonBrowseAvatar.Text = "Change Avatar (50KB)";
            this.ButtonBrowseAvatar.UseVisualStyleBackColor = true;
            this.ButtonBrowseAvatar.Click += new System.EventHandler(this.ButtonBrowseAvatar_Click);
            // 
            // ButtonResetAvatar
            // 
            this.ButtonResetAvatar.Enabled = false;
            this.ButtonResetAvatar.Location = new System.Drawing.Point(6, 73);
            this.ButtonResetAvatar.Name = "ButtonResetAvatar";
            this.ButtonResetAvatar.Size = new System.Drawing.Size(209, 25);
            this.ButtonResetAvatar.TabIndex = 2;
            this.ButtonResetAvatar.Text = "Reset Avatar";
            this.ButtonResetAvatar.UseVisualStyleBackColor = true;
            this.ButtonResetAvatar.Click += new System.EventHandler(this.ButtonResetAvatar_Click);
            // 
            // ButtonSaveAvatar
            // 
            this.ButtonSaveAvatar.Enabled = false;
            this.ButtonSaveAvatar.Location = new System.Drawing.Point(6, 149);
            this.ButtonSaveAvatar.Name = "ButtonSaveAvatar";
            this.ButtonSaveAvatar.Size = new System.Drawing.Size(221, 25);
            this.ButtonSaveAvatar.TabIndex = 3;
            this.ButtonSaveAvatar.Text = "Save Changes";
            this.ButtonSaveAvatar.UseVisualStyleBackColor = true;
            this.ButtonSaveAvatar.Click += new System.EventHandler(this.ButtonSaveAvatar_Click);
            // 
            // ChangeAvatar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupBoxAvatar);
            this.Controls.Add(this.PictureBoxAvatar);
            this.Name = "ChangeAvatar";
            this.Size = new System.Drawing.Size(440, 200);
            this.Load += new System.EventHandler(this.ChangeAvatar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxAvatar)).EndInit();
            this.GroupBoxAvatar.ResumeLayout(false);
            this.GroupBoxAvatarImage.ResumeLayout(false);
            this.GroupBoxAvatarImage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxAvatar;
        private System.Windows.Forms.GroupBox GroupBoxAvatar;
        private System.Windows.Forms.GroupBox GroupBoxAvatarImage;
        private System.Windows.Forms.Button ButtonResetAvatar;
        private System.Windows.Forms.Button ButtonBrowseAvatar;
        private System.Windows.Forms.TextBox TextBoxImageLocation;
        private System.Windows.Forms.Button ButtonSaveAvatar;
    }
}
