namespace ByteGuard.ByteGuardInterface.UserControls.MyLibrary
{
    partial class LockDetails
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
            this.GroupBoxStatus = new System.Windows.Forms.GroupBox();
            this.GroupBoxExplanations = new System.Windows.Forms.GroupBox();
            this.lineSeparator1 = new ByteGuardInterface.Theme.LineSeparator();
            this.LabelReason = new System.Windows.Forms.Label();
            this.TextBoxReason = new System.Windows.Forms.TextBox();
            this.ButtonBannedExplanation = new System.Windows.Forms.Button();
            this.ButtonFrozenExplanation = new System.Windows.Forms.Button();
            this.TextBoxStatus = new System.Windows.Forms.TextBox();
            this.GroupBoxStatus.SuspendLayout();
            this.GroupBoxExplanations.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxStatus
            // 
            this.GroupBoxStatus.Controls.Add(this.TextBoxStatus);
            this.GroupBoxStatus.Controls.Add(this.TextBoxReason);
            this.GroupBoxStatus.Controls.Add(this.LabelReason);
            this.GroupBoxStatus.Controls.Add(this.lineSeparator1);
            this.GroupBoxStatus.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxStatus.Location = new System.Drawing.Point(8, 2);
            this.GroupBoxStatus.Name = "GroupBoxStatus";
            this.GroupBoxStatus.Size = new System.Drawing.Size(186, 74);
            this.GroupBoxStatus.TabIndex = 0;
            this.GroupBoxStatus.TabStop = false;
            this.GroupBoxStatus.Text = "Status:";
            // 
            // GroupBoxExplanations
            // 
            this.GroupBoxExplanations.Controls.Add(this.ButtonFrozenExplanation);
            this.GroupBoxExplanations.Controls.Add(this.ButtonBannedExplanation);
            this.GroupBoxExplanations.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxExplanations.Location = new System.Drawing.Point(8, 82);
            this.GroupBoxExplanations.Name = "GroupBoxExplanations";
            this.GroupBoxExplanations.Size = new System.Drawing.Size(186, 74);
            this.GroupBoxExplanations.TabIndex = 1;
            this.GroupBoxExplanations.TabStop = false;
            this.GroupBoxExplanations.Text = "Lock Explanations:";
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(6, 42);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(174, 2);
            this.lineSeparator1.TabIndex = 1;
            // 
            // LabelReason
            // 
            this.LabelReason.AutoSize = true;
            this.LabelReason.Location = new System.Drawing.Point(5, 51);
            this.LabelReason.Name = "LabelReason";
            this.LabelReason.Size = new System.Drawing.Size(54, 13);
            this.LabelReason.TabIndex = 2;
            this.LabelReason.Text = "Reason:";
            // 
            // TextBoxReason
            // 
            this.TextBoxReason.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBoxReason.Location = new System.Drawing.Point(63, 48);
            this.TextBoxReason.MaxLength = 15;
            this.TextBoxReason.Name = "TextBoxReason";
            this.TextBoxReason.ReadOnly = true;
            this.TextBoxReason.Size = new System.Drawing.Size(117, 20);
            this.TextBoxReason.TabIndex = 3;
            // 
            // ButtonBannedExplanation
            // 
            this.ButtonBannedExplanation.Location = new System.Drawing.Point(7, 19);
            this.ButtonBannedExplanation.Name = "ButtonBannedExplanation";
            this.ButtonBannedExplanation.Size = new System.Drawing.Size(172, 23);
            this.ButtonBannedExplanation.TabIndex = 0;
            this.ButtonBannedExplanation.Text = "Banned";
            this.ButtonBannedExplanation.UseVisualStyleBackColor = true;
            this.ButtonBannedExplanation.Click += new System.EventHandler(this.ButtonBannedExplanation_Click);
            // 
            // ButtonFrozenExplanation
            // 
            this.ButtonFrozenExplanation.Location = new System.Drawing.Point(7, 45);
            this.ButtonFrozenExplanation.Name = "ButtonFrozenExplanation";
            this.ButtonFrozenExplanation.Size = new System.Drawing.Size(172, 23);
            this.ButtonFrozenExplanation.TabIndex = 1;
            this.ButtonFrozenExplanation.Text = "Frozen";
            this.ButtonFrozenExplanation.UseVisualStyleBackColor = true;
            this.ButtonFrozenExplanation.Click += new System.EventHandler(this.ButtonFrozenExplanation_Click);
            // 
            // TextBoxStatus
            // 
            this.TextBoxStatus.BackColor = System.Drawing.SystemColors.Control;
            this.TextBoxStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.TextBoxStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.TextBoxStatus.Location = new System.Drawing.Point(8, 19);
            this.TextBoxStatus.Name = "TextBoxStatus";
            this.TextBoxStatus.ReadOnly = true;
            this.TextBoxStatus.Size = new System.Drawing.Size(172, 13);
            this.TextBoxStatus.TabIndex = 4;
            this.TextBoxStatus.Text = "Unknown";
            this.TextBoxStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LockDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupBoxExplanations);
            this.Controls.Add(this.GroupBoxStatus);
            this.Name = "LockDetails";
            this.Size = new System.Drawing.Size(202, 164);
            this.Load += new System.EventHandler(this.LockDetails_Load);
            this.GroupBoxStatus.ResumeLayout(false);
            this.GroupBoxStatus.PerformLayout();
            this.GroupBoxExplanations.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxStatus;
        private System.Windows.Forms.TextBox TextBoxReason;
        private System.Windows.Forms.Label LabelReason;
        private Theme.LineSeparator lineSeparator1;
        private System.Windows.Forms.GroupBox GroupBoxExplanations;
        private System.Windows.Forms.Button ButtonFrozenExplanation;
        private System.Windows.Forms.Button ButtonBannedExplanation;
        private System.Windows.Forms.TextBox TextBoxStatus;
    }
}
