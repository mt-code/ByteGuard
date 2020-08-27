namespace ByteGuard.Tasks
{
    partial class UpdaterForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUpdates = new System.Windows.Forms.Label();
            this.pbarUpdates = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblUpdates
            // 
            this.lblUpdates.AutoSize = true;
            this.lblUpdates.Location = new System.Drawing.Point(12, 9);
            this.lblUpdates.Name = "lblUpdates";
            this.lblUpdates.Size = new System.Drawing.Size(141, 13);
            this.lblUpdates.TabIndex = 0;
            this.lblUpdates.Text = "Checking for updates...";
            // 
            // pbarUpdates
            // 
            this.pbarUpdates.Location = new System.Drawing.Point(15, 29);
            this.pbarUpdates.Name = "pbarUpdates";
            this.pbarUpdates.Size = new System.Drawing.Size(361, 15);
            this.pbarUpdates.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 56);
            this.Controls.Add(this.pbarUpdates);
            this.Controls.Add(this.lblUpdates);
            this.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ByteGuard Updater [BETA - Progress Broken]";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUpdates;
        private System.Windows.Forms.ProgressBar pbarUpdates;
    }
}

