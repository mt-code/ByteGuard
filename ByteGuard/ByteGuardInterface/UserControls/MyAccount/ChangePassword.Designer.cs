namespace ByteGuard.ByteGuardInterface.UserControls.MyAccount
{
    partial class ChangePassword
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
            this.TextBoxCurrentPassword = new System.Windows.Forms.TextBox();
            this.LabelCurrentPassword = new System.Windows.Forms.Label();
            this.LabelNewPassword = new System.Windows.Forms.Label();
            this.TextBoxNewPassword = new System.Windows.Forms.TextBox();
            this.LabelConfirmPassword = new System.Windows.Forms.Label();
            this.TextBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.ButtonChangePassword = new System.Windows.Forms.Button();
            this.LineSeparator2 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.LineSeparator1 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.SuspendLayout();
            // 
            // TextBoxCurrentPassword
            // 
            this.TextBoxCurrentPassword.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCurrentPassword.ForeColor = System.Drawing.Color.DimGray;
            this.TextBoxCurrentPassword.Location = new System.Drawing.Point(16, 25);
            this.TextBoxCurrentPassword.MaxLength = 12;
            this.TextBoxCurrentPassword.Name = "TextBoxCurrentPassword";
            this.TextBoxCurrentPassword.PasswordChar = '*';
            this.TextBoxCurrentPassword.Size = new System.Drawing.Size(188, 20);
            this.TextBoxCurrentPassword.TabIndex = 0;
            this.TextBoxCurrentPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxCurrentPassword.TextChanged += new System.EventHandler(this.TextBoxCurrentPassword_TextChanged);
            // 
            // LabelCurrentPassword
            // 
            this.LabelCurrentPassword.AutoSize = true;
            this.LabelCurrentPassword.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCurrentPassword.Location = new System.Drawing.Point(13, 9);
            this.LabelCurrentPassword.Name = "LabelCurrentPassword";
            this.LabelCurrentPassword.Size = new System.Drawing.Size(114, 13);
            this.LabelCurrentPassword.TabIndex = 3;
            this.LabelCurrentPassword.Text = "Current Password:";
            // 
            // LabelNewPassword
            // 
            this.LabelNewPassword.AutoSize = true;
            this.LabelNewPassword.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNewPassword.Location = new System.Drawing.Point(13, 56);
            this.LabelNewPassword.Name = "LabelNewPassword";
            this.LabelNewPassword.Size = new System.Drawing.Size(94, 13);
            this.LabelNewPassword.TabIndex = 6;
            this.LabelNewPassword.Text = "New Password:";
            // 
            // TextBoxNewPassword
            // 
            this.TextBoxNewPassword.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxNewPassword.ForeColor = System.Drawing.Color.DimGray;
            this.TextBoxNewPassword.Location = new System.Drawing.Point(16, 72);
            this.TextBoxNewPassword.MaxLength = 12;
            this.TextBoxNewPassword.Name = "TextBoxNewPassword";
            this.TextBoxNewPassword.PasswordChar = '*';
            this.TextBoxNewPassword.Size = new System.Drawing.Size(188, 20);
            this.TextBoxNewPassword.TabIndex = 1;
            this.TextBoxNewPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxNewPassword.TextChanged += new System.EventHandler(this.TextBoxNewPassword_TextChanged);
            // 
            // LabelConfirmPassword
            // 
            this.LabelConfirmPassword.AutoSize = true;
            this.LabelConfirmPassword.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelConfirmPassword.Location = new System.Drawing.Point(13, 95);
            this.LabelConfirmPassword.Name = "LabelConfirmPassword";
            this.LabelConfirmPassword.Size = new System.Drawing.Size(116, 13);
            this.LabelConfirmPassword.TabIndex = 8;
            this.LabelConfirmPassword.Text = "Confirm Password:";
            // 
            // TextBoxConfirmPassword
            // 
            this.TextBoxConfirmPassword.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxConfirmPassword.ForeColor = System.Drawing.Color.DimGray;
            this.TextBoxConfirmPassword.Location = new System.Drawing.Point(16, 111);
            this.TextBoxConfirmPassword.MaxLength = 12;
            this.TextBoxConfirmPassword.Name = "TextBoxConfirmPassword";
            this.TextBoxConfirmPassword.PasswordChar = '*';
            this.TextBoxConfirmPassword.Size = new System.Drawing.Size(188, 20);
            this.TextBoxConfirmPassword.TabIndex = 2;
            this.TextBoxConfirmPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxConfirmPassword.TextChanged += new System.EventHandler(this.TextBoxConfirmPassword_TextChanged);
            // 
            // ButtonChangePassword
            // 
            this.ButtonChangePassword.Enabled = false;
            this.ButtonChangePassword.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonChangePassword.Location = new System.Drawing.Point(16, 145);
            this.ButtonChangePassword.Name = "ButtonChangePassword";
            this.ButtonChangePassword.Size = new System.Drawing.Size(188, 25);
            this.ButtonChangePassword.TabIndex = 3;
            this.ButtonChangePassword.Text = "Change Password";
            this.ButtonChangePassword.UseVisualStyleBackColor = true;
            this.ButtonChangePassword.Click += new System.EventHandler(this.ButtonChangePassword_Click);
            // 
            // LineSeparator2
            // 
            this.LineSeparator2.Location = new System.Drawing.Point(16, 137);
            this.LineSeparator2.MaximumSize = new System.Drawing.Size(2000, 2);
            this.LineSeparator2.MinimumSize = new System.Drawing.Size(0, 2);
            this.LineSeparator2.Name = "LineSeparator2";
            this.LineSeparator2.Size = new System.Drawing.Size(188, 2);
            this.LineSeparator2.TabIndex = 9;
            // 
            // LineSeparator1
            // 
            this.LineSeparator1.Location = new System.Drawing.Point(16, 51);
            this.LineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.LineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.LineSeparator1.Name = "LineSeparator1";
            this.LineSeparator1.Size = new System.Drawing.Size(188, 2);
            this.LineSeparator1.TabIndex = 4;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ButtonChangePassword);
            this.Controls.Add(this.LineSeparator2);
            this.Controls.Add(this.LabelConfirmPassword);
            this.Controls.Add(this.TextBoxConfirmPassword);
            this.Controls.Add(this.LabelNewPassword);
            this.Controls.Add(this.TextBoxNewPassword);
            this.Controls.Add(this.LineSeparator1);
            this.Controls.Add(this.LabelCurrentPassword);
            this.Controls.Add(this.TextBoxCurrentPassword);
            this.Name = "ChangePassword";
            this.Size = new System.Drawing.Size(220, 182);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxCurrentPassword;
        private System.Windows.Forms.Label LabelCurrentPassword;
        private Theme.LineSeparator LineSeparator1;
        private System.Windows.Forms.Label LabelNewPassword;
        private System.Windows.Forms.TextBox TextBoxNewPassword;
        private System.Windows.Forms.Label LabelConfirmPassword;
        private System.Windows.Forms.TextBox TextBoxConfirmPassword;
        private Theme.LineSeparator LineSeparator2;
        private System.Windows.Forms.Button ButtonChangePassword;
    }
}
