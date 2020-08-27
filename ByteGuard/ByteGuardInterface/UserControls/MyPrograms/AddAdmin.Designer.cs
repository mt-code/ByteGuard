namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    partial class AddAdmin
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
            this.LabelEmail = new System.Windows.Forms.Label();
            this.TextBoxEmail = new System.Windows.Forms.TextBox();
            this.ButtonAddAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelEmail
            // 
            this.LabelEmail.AutoSize = true;
            this.LabelEmail.Location = new System.Drawing.Point(13, 8);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(173, 13);
            this.LabelEmail.TabIndex = 0;
            this.LabelEmail.Text = "Their account email address:";
            // 
            // TextBoxEmail
            // 
            this.TextBoxEmail.Location = new System.Drawing.Point(16, 25);
            this.TextBoxEmail.Name = "TextBoxEmail";
            this.TextBoxEmail.Size = new System.Drawing.Size(247, 20);
            this.TextBoxEmail.TabIndex = 1;
            // 
            // ButtonAddAdmin
            // 
            this.ButtonAddAdmin.Location = new System.Drawing.Point(16, 49);
            this.ButtonAddAdmin.Name = "ButtonAddAdmin";
            this.ButtonAddAdmin.Size = new System.Drawing.Size(247, 23);
            this.ButtonAddAdmin.TabIndex = 2;
            this.ButtonAddAdmin.Text = "Add Administrator";
            this.ButtonAddAdmin.UseVisualStyleBackColor = true;
            this.ButtonAddAdmin.Click += new System.EventHandler(this.ButtonAddAdmin_Click);
            // 
            // AddAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ButtonAddAdmin);
            this.Controls.Add(this.TextBoxEmail);
            this.Controls.Add(this.LabelEmail);
            this.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AddAdmin";
            this.Size = new System.Drawing.Size(280, 85);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelEmail;
        private System.Windows.Forms.TextBox TextBoxEmail;
        private System.Windows.Forms.Button ButtonAddAdmin;

    }
}
