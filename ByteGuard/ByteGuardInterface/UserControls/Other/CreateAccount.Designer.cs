namespace ByteGuard.ByteGuardInterface.UserControls.Other
{
    partial class CreateAccount
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
            this.linkTerms = new System.Windows.Forms.LinkLabel();
            this.chkTerms = new System.Windows.Forms.CheckBox();
            this.ButtonBack = new System.Windows.Forms.Button();
            this.ButtonCreateAccount = new System.Windows.Forms.Button();
            this.TextBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.TextBoxUsername = new System.Windows.Forms.TextBox();
            this.TextBoxEmail = new System.Windows.Forms.TextBox();
            this.ThemeContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ThemeContainer
            // 
            this.ThemeContainer.Controls.Add(this.linkTerms);
            this.ThemeContainer.Controls.Add(this.chkTerms);
            this.ThemeContainer.Controls.Add(this.ButtonBack);
            this.ThemeContainer.Controls.Add(this.ButtonCreateAccount);
            this.ThemeContainer.Controls.Add(this.TextBoxConfirmPassword);
            this.ThemeContainer.Controls.Add(this.TextBoxPassword);
            this.ThemeContainer.Controls.Add(this.TextBoxUsername);
            this.ThemeContainer.Controls.Add(this.TextBoxEmail);
            this.ThemeContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThemeContainer.Location = new System.Drawing.Point(0, 0);
            this.ThemeContainer.Name = "ThemeContainer";
            this.ThemeContainer.Size = new System.Drawing.Size(284, 296);
            this.ThemeContainer.TabIndex = 0;
            this.ThemeContainer.Text = "ThemeContainer";
            // 
            // linkTerms
            // 
            this.linkTerms.AutoSize = true;
            this.linkTerms.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkTerms.Location = new System.Drawing.Point(129, 234);
            this.linkTerms.Name = "linkTerms";
            this.linkTerms.Size = new System.Drawing.Size(132, 13);
            this.linkTerms.TabIndex = 8;
            this.linkTerms.TabStop = true;
            this.linkTerms.Text = "Terms and Conditions";
            this.linkTerms.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTerms_LinkClicked);
            // 
            // chkTerms
            // 
            this.chkTerms.AutoSize = true;
            this.chkTerms.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTerms.Location = new System.Drawing.Point(30, 234);
            this.chkTerms.Name = "chkTerms";
            this.chkTerms.Size = new System.Drawing.Size(104, 17);
            this.chkTerms.TabIndex = 7;
            this.chkTerms.Text = "I agree to the";
            this.chkTerms.UseVisualStyleBackColor = true;
            this.chkTerms.CheckedChanged += new System.EventHandler(this.chkTerms_CheckedChanged);
            // 
            // ButtonBack
            // 
            this.ButtonBack.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonBack.Location = new System.Drawing.Point(49, 200);
            this.ButtonBack.Name = "ButtonBack";
            this.ButtonBack.Size = new System.Drawing.Size(188, 25);
            this.ButtonBack.TabIndex = 6;
            this.ButtonBack.Text = "Back";
            this.ButtonBack.UseVisualStyleBackColor = true;
            this.ButtonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // ButtonCreateAccount
            // 
            this.ButtonCreateAccount.Enabled = false;
            this.ButtonCreateAccount.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCreateAccount.Location = new System.Drawing.Point(49, 169);
            this.ButtonCreateAccount.Name = "ButtonCreateAccount";
            this.ButtonCreateAccount.Size = new System.Drawing.Size(188, 25);
            this.ButtonCreateAccount.TabIndex = 5;
            this.ButtonCreateAccount.Text = "Create Account";
            this.ButtonCreateAccount.UseVisualStyleBackColor = true;
            this.ButtonCreateAccount.Click += new System.EventHandler(this.ButtonCreateAccount_Click);
            // 
            // TextBoxConfirmPassword
            // 
            this.TextBoxConfirmPassword.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxConfirmPassword.ForeColor = System.Drawing.Color.DimGray;
            this.TextBoxConfirmPassword.Location = new System.Drawing.Point(49, 143);
            this.TextBoxConfirmPassword.Name = "TextBoxConfirmPassword";
            this.TextBoxConfirmPassword.Size = new System.Drawing.Size(188, 20);
            this.TextBoxConfirmPassword.TabIndex = 4;
            this.TextBoxConfirmPassword.Text = "Confirm Password";
            this.TextBoxConfirmPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxConfirmPassword.TextChanged += new System.EventHandler(this.TextBoxConfirmPassword_TextChanged);
            this.TextBoxConfirmPassword.Enter += new System.EventHandler(this.TextBoxConfirmPassword_Enter);
            this.TextBoxConfirmPassword.Leave += new System.EventHandler(this.TextBoxConfirmPassword_Leave);
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxPassword.ForeColor = System.Drawing.Color.DimGray;
            this.TextBoxPassword.Location = new System.Drawing.Point(49, 117);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(188, 20);
            this.TextBoxPassword.TabIndex = 3;
            this.TextBoxPassword.Text = "Password";
            this.TextBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxPassword.TextChanged += new System.EventHandler(this.TextBoxPassword_TextChanged);
            this.TextBoxPassword.Enter += new System.EventHandler(this.TextBoxPassword_Enter);
            this.TextBoxPassword.Leave += new System.EventHandler(this.TextBoxPassword_Leave);
            // 
            // TextBoxUsername
            // 
            this.TextBoxUsername.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxUsername.ForeColor = System.Drawing.Color.DimGray;
            this.TextBoxUsername.Location = new System.Drawing.Point(49, 91);
            this.TextBoxUsername.MaxLength = 12;
            this.TextBoxUsername.Name = "TextBoxUsername";
            this.TextBoxUsername.Size = new System.Drawing.Size(188, 20);
            this.TextBoxUsername.TabIndex = 2;
            this.TextBoxUsername.Text = "Username";
            this.TextBoxUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxUsername.TextChanged += new System.EventHandler(this.TextBoxUsername_TextChanged);
            this.TextBoxUsername.Enter += new System.EventHandler(this.TextBoxUsername_Enter);
            this.TextBoxUsername.Leave += new System.EventHandler(this.TextBoxUsername_Leave);
            // 
            // TextBoxEmail
            // 
            this.TextBoxEmail.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxEmail.ForeColor = System.Drawing.Color.DimGray;
            this.TextBoxEmail.Location = new System.Drawing.Point(49, 65);
            this.TextBoxEmail.Name = "TextBoxEmail";
            this.TextBoxEmail.Size = new System.Drawing.Size(188, 20);
            this.TextBoxEmail.TabIndex = 1;
            this.TextBoxEmail.Text = "Email";
            this.TextBoxEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxEmail.TextChanged += new System.EventHandler(this.TextBoxEmail_TextChanged);
            this.TextBoxEmail.Enter += new System.EventHandler(this.TextBoxEmail_Enter);
            this.TextBoxEmail.Leave += new System.EventHandler(this.TextBoxEmail_Leave);
            // 
            // CreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ThemeContainer);
            this.Name = "CreateAccount";
            this.Size = new System.Drawing.Size(284, 296);
            this.Load += new System.EventHandler(this.CreateAccount_Load);
            this.ThemeContainer.ResumeLayout(false);
            this.ThemeContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Theme.ThemeContainer ThemeContainer;
        private System.Windows.Forms.Button ButtonBack;
        private System.Windows.Forms.Button ButtonCreateAccount;
        private System.Windows.Forms.TextBox TextBoxConfirmPassword;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.TextBox TextBoxUsername;
        private System.Windows.Forms.TextBox TextBoxEmail;
        private System.Windows.Forms.LinkLabel linkTerms;
        private System.Windows.Forms.CheckBox chkTerms;

    }
}
