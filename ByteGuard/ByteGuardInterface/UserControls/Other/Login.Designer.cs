namespace ByteGuard.ByteGuardInterface.UserControls.Other
{
    partial class Login
    {

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.ThemeContainer = new ByteGuard.ByteGuardInterface.Theme.ThemeContainer();
            this.CheckBoxRememberMe = new System.Windows.Forms.CheckBox();
            this.ButtonRecoverAccount = new System.Windows.Forms.Button();
            this.ButtonCreateAccount = new System.Windows.Forms.Button();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.TextBoxUsername = new System.Windows.Forms.TextBox();
            this.ThemeContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ThemeContainer
            // 
            this.ThemeContainer.Controls.Add(this.CheckBoxRememberMe);
            this.ThemeContainer.Controls.Add(this.ButtonRecoverAccount);
            this.ThemeContainer.Controls.Add(this.ButtonCreateAccount);
            this.ThemeContainer.Controls.Add(this.ButtonLogin);
            this.ThemeContainer.Controls.Add(this.TextBoxPassword);
            this.ThemeContainer.Controls.Add(this.TextBoxUsername);
            this.ThemeContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThemeContainer.Location = new System.Drawing.Point(0, 0);
            this.ThemeContainer.Name = "ThemeContainer";
            this.ThemeContainer.Size = new System.Drawing.Size(284, 258);
            this.ThemeContainer.TabIndex = 0;
            this.ThemeContainer.Text = "themeContainer1";
            // 
            // CheckBoxRememberMe
            // 
            this.CheckBoxRememberMe.AutoSize = true;
            this.CheckBoxRememberMe.Checked = true;
            this.CheckBoxRememberMe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxRememberMe.Location = new System.Drawing.Point(243, 68);
            this.CheckBoxRememberMe.Name = "CheckBoxRememberMe";
            this.CheckBoxRememberMe.Size = new System.Drawing.Size(14, 13);
            this.CheckBoxRememberMe.TabIndex = 12;
            this.CheckBoxRememberMe.TabStop = false;
            this.CheckBoxRememberMe.UseVisualStyleBackColor = true;
            // 
            // ButtonRecoverAccount
            // 
            this.ButtonRecoverAccount.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRecoverAccount.Location = new System.Drawing.Point(49, 177);
            this.ButtonRecoverAccount.Name = "ButtonRecoverAccount";
            this.ButtonRecoverAccount.Size = new System.Drawing.Size(188, 25);
            this.ButtonRecoverAccount.TabIndex = 11;
            this.ButtonRecoverAccount.Text = "Recover Lost Account";
            this.ButtonRecoverAccount.UseVisualStyleBackColor = true;
            this.ButtonRecoverAccount.Click += new System.EventHandler(this.ButtonRecoverAccount_Click);
            // 
            // ButtonCreateAccount
            // 
            this.ButtonCreateAccount.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCreateAccount.Location = new System.Drawing.Point(49, 146);
            this.ButtonCreateAccount.Name = "ButtonCreateAccount";
            this.ButtonCreateAccount.Size = new System.Drawing.Size(188, 25);
            this.ButtonCreateAccount.TabIndex = 10;
            this.ButtonCreateAccount.Text = "Create New Account";
            this.ButtonCreateAccount.UseVisualStyleBackColor = true;
            this.ButtonCreateAccount.Click += new System.EventHandler(this.ButtonCreateAccount_Click);
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.Enabled = false;
            this.ButtonLogin.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLogin.Location = new System.Drawing.Point(49, 115);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(188, 25);
            this.ButtonLogin.TabIndex = 9;
            this.ButtonLogin.Text = "Login";
            this.ButtonLogin.UseVisualStyleBackColor = true;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxPassword.ForeColor = System.Drawing.Color.DimGray;
            this.TextBoxPassword.Location = new System.Drawing.Point(49, 89);
            this.TextBoxPassword.MaxLength = 12;
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(188, 20);
            this.TextBoxPassword.TabIndex = 8;
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
            this.TextBoxUsername.Location = new System.Drawing.Point(49, 65);
            this.TextBoxUsername.MaxLength = 12;
            this.TextBoxUsername.Name = "TextBoxUsername";
            this.TextBoxUsername.Size = new System.Drawing.Size(188, 20);
            this.TextBoxUsername.TabIndex = 7;
            this.TextBoxUsername.Text = "Username";
            this.TextBoxUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxUsername.TextChanged += new System.EventHandler(this.TextBoxUsername_TextChanged);
            this.TextBoxUsername.Enter += new System.EventHandler(this.TextBoxUsername_Enter);
            this.TextBoxUsername.Leave += new System.EventHandler(this.TextBoxUsername_Leave);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ThemeContainer);
            this.Name = "Login";
            this.Size = new System.Drawing.Size(284, 258);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ThemeContainer.ResumeLayout(false);
            this.ThemeContainer.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private Theme.ThemeContainer ThemeContainer;
        private System.Windows.Forms.CheckBox CheckBoxRememberMe;
        private System.Windows.Forms.Button ButtonRecoverAccount;
        private System.Windows.Forms.Button ButtonCreateAccount;
        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.TextBox TextBoxUsername;

    }
}
