namespace ByteGuard.ByteGuardInterface.UserControls.MyAccount
{
    partial class ActivateAccount
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
            this.GroupBoxActivationCode = new System.Windows.Forms.GroupBox();
            this.TextBoxActivationCode = new System.Windows.Forms.TextBox();
            this.ButtonActivateAccount = new System.Windows.Forms.Button();
            this.ButtonSendActivationCode = new System.Windows.Forms.Button();
            this.LineSeparator1 = new ByteGuardInterface.Theme.LineSeparator();
            this.GroupBoxActivationCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxActivationCode
            // 
            this.GroupBoxActivationCode.Controls.Add(this.TextBoxActivationCode);
            this.GroupBoxActivationCode.Location = new System.Drawing.Point(11, 3);
            this.GroupBoxActivationCode.Name = "GroupBoxActivationCode";
            this.GroupBoxActivationCode.Size = new System.Drawing.Size(208, 50);
            this.GroupBoxActivationCode.TabIndex = 0;
            this.GroupBoxActivationCode.TabStop = false;
            this.GroupBoxActivationCode.Text = "Activation code:";
            // 
            // TextBoxActivationCode
            // 
            this.TextBoxActivationCode.Location = new System.Drawing.Point(6, 22);
            this.TextBoxActivationCode.MaxLength = 8;
            this.TextBoxActivationCode.Name = "TextBoxActivationCode";
            this.TextBoxActivationCode.Size = new System.Drawing.Size(196, 20);
            this.TextBoxActivationCode.TabIndex = 0;
            this.TextBoxActivationCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxActivationCode.TextChanged += new System.EventHandler(this.TextBoxActivationCode_TextChanged);
            // 
            // ButtonActivateAccount
            // 
            this.ButtonActivateAccount.Enabled = false;
            this.ButtonActivateAccount.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonActivateAccount.Location = new System.Drawing.Point(11, 59);
            this.ButtonActivateAccount.Name = "ButtonActivateAccount";
            this.ButtonActivateAccount.Size = new System.Drawing.Size(208, 25);
            this.ButtonActivateAccount.TabIndex = 1;
            this.ButtonActivateAccount.Text = "Activate Account";
            this.ButtonActivateAccount.UseVisualStyleBackColor = true;
            this.ButtonActivateAccount.Click += new System.EventHandler(this.ButtonActivateAccount_Click);
            // 
            // ButtonSendActivationCode
            // 
            this.ButtonSendActivationCode.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSendActivationCode.Location = new System.Drawing.Point(11, 98);
            this.ButtonSendActivationCode.Name = "ButtonSendActivationCode";
            this.ButtonSendActivationCode.Size = new System.Drawing.Size(208, 25);
            this.ButtonSendActivationCode.TabIndex = 2;
            this.ButtonSendActivationCode.Text = "Resend Activation Code";
            this.ButtonSendActivationCode.UseVisualStyleBackColor = true;
            this.ButtonSendActivationCode.Click += new System.EventHandler(this.ButtonSendActivationCode_Click);
            // 
            // LineSeparator1
            // 
            this.LineSeparator1.Location = new System.Drawing.Point(11, 90);
            this.LineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.LineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.LineSeparator1.Name = "LineSeparator1";
            this.LineSeparator1.Size = new System.Drawing.Size(208, 2);
            this.LineSeparator1.TabIndex = 3;
            // 
            // ActivateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LineSeparator1);
            this.Controls.Add(this.ButtonSendActivationCode);
            this.Controls.Add(this.ButtonActivateAccount);
            this.Controls.Add(this.GroupBoxActivationCode);
            this.Name = "ActivateAccount";
            this.Size = new System.Drawing.Size(230, 132);
            this.GroupBoxActivationCode.ResumeLayout(false);
            this.GroupBoxActivationCode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxActivationCode;
        private System.Windows.Forms.TextBox TextBoxActivationCode;
        private System.Windows.Forms.Button ButtonActivateAccount;
        private System.Windows.Forms.Button ButtonSendActivationCode;
        private Theme.LineSeparator LineSeparator1;
    }
}
