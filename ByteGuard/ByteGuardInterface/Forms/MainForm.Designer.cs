namespace ByteGuard.ByteGuardInterface.Forms
{
    partial class MainForm
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
            this.ThemeContainer = new ByteGuard.ByteGuardInterface.Theme.ThemeContainer();
            this.ButtonRedeemProgram = new System.Windows.Forms.Button();
            this.TabControlMain = new ByteGuard.ByteGuardInterface.Theme.TabControlTop();
            this.TabPageMyAccount = new System.Windows.Forms.TabPage();
            this.PanelMyAccount = new System.Windows.Forms.Panel();
            this.TabPageMyPrograms = new System.Windows.Forms.TabPage();
            this.PanelMyPrograms = new System.Windows.Forms.Panel();
            this.ListBoxMyPrograms = new System.Windows.Forms.ListBox();
            this.TabPageMyLibrary = new System.Windows.Forms.TabPage();
            this.PanelMyLibrary = new System.Windows.Forms.Panel();
            this.ListBoxMyLibrary = new System.Windows.Forms.ListBox();
            this.TabPageStore = new System.Windows.Forms.TabPage();
            this.ThemeContainer.SuspendLayout();
            this.TabControlMain.SuspendLayout();
            this.TabPageMyAccount.SuspendLayout();
            this.TabPageMyPrograms.SuspendLayout();
            this.TabPageMyLibrary.SuspendLayout();
            this.SuspendLayout();
            // 
            // ThemeContainer
            // 
            this.ThemeContainer.Controls.Add(this.ButtonRedeemProgram);
            this.ThemeContainer.Controls.Add(this.TabControlMain);
            this.ThemeContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThemeContainer.Location = new System.Drawing.Point(0, 0);
            this.ThemeContainer.Name = "ThemeContainer";
            this.ThemeContainer.Size = new System.Drawing.Size(879, 522);
            this.ThemeContainer.TabIndex = 0;
            this.ThemeContainer.Text = "ThemeContainer";
            // 
            // ButtonRedeemProgram
            // 
            this.ButtonRedeemProgram.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRedeemProgram.Location = new System.Drawing.Point(642, 493);
            this.ButtonRedeemProgram.Name = "ButtonRedeemProgram";
            this.ButtonRedeemProgram.Size = new System.Drawing.Size(202, 25);
            this.ButtonRedeemProgram.TabIndex = 1;
            this.ButtonRedeemProgram.Text = "Redeem License";
            this.ButtonRedeemProgram.UseVisualStyleBackColor = true;
            this.ButtonRedeemProgram.Visible = false;
            this.ButtonRedeemProgram.Click += new System.EventHandler(this.ButtonRedeemProgram_Click);
            // 
            // TabControlMain
            // 
            this.TabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControlMain.Controls.Add(this.TabPageMyAccount);
            this.TabControlMain.Controls.Add(this.TabPageMyPrograms);
            this.TabControlMain.Controls.Add(this.TabPageMyLibrary);
            this.TabControlMain.Controls.Add(this.TabPageStore);
            this.TabControlMain.ItemSize = new System.Drawing.Size(150, 45);
            this.TabControlMain.Location = new System.Drawing.Point(1, 4);
            this.TabControlMain.Name = "TabControlMain";
            this.TabControlMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TabControlMain.RightToLeftLayout = true;
            this.TabControlMain.SelectedIndex = 0;
            this.TabControlMain.Size = new System.Drawing.Size(878, 482);
            this.TabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControlMain.TabIndex = 0;
            this.TabControlMain.SelectedIndexChanged += new System.EventHandler(this.TabControlMain_SelectedIndexChanged);
            // 
            // TabPageMyAccount
            // 
            this.TabPageMyAccount.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageMyAccount.Controls.Add(this.PanelMyAccount);
            this.TabPageMyAccount.Location = new System.Drawing.Point(4, 49);
            this.TabPageMyAccount.Name = "TabPageMyAccount";
            this.TabPageMyAccount.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageMyAccount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TabPageMyAccount.Size = new System.Drawing.Size(870, 429);
            this.TabPageMyAccount.TabIndex = 0;
            this.TabPageMyAccount.Text = "My Account";
            // 
            // PanelMyAccount
            // 
            this.PanelMyAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMyAccount.Location = new System.Drawing.Point(3, 3);
            this.PanelMyAccount.Name = "PanelMyAccount";
            this.PanelMyAccount.Size = new System.Drawing.Size(864, 423);
            this.PanelMyAccount.TabIndex = 0;
            // 
            // TabPageMyPrograms
            // 
            this.TabPageMyPrograms.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageMyPrograms.Controls.Add(this.PanelMyPrograms);
            this.TabPageMyPrograms.Controls.Add(this.ListBoxMyPrograms);
            this.TabPageMyPrograms.Location = new System.Drawing.Point(4, 49);
            this.TabPageMyPrograms.Name = "TabPageMyPrograms";
            this.TabPageMyPrograms.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageMyPrograms.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TabPageMyPrograms.Size = new System.Drawing.Size(870, 429);
            this.TabPageMyPrograms.TabIndex = 1;
            this.TabPageMyPrograms.Text = "My Programs";
            // 
            // PanelMyPrograms
            // 
            this.PanelMyPrograms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMyPrograms.Location = new System.Drawing.Point(171, 3);
            this.PanelMyPrograms.Name = "PanelMyPrograms";
            this.PanelMyPrograms.Size = new System.Drawing.Size(696, 423);
            this.PanelMyPrograms.TabIndex = 5;
            // 
            // ListBoxMyPrograms
            // 
            this.ListBoxMyPrograms.Dock = System.Windows.Forms.DockStyle.Left;
            this.ListBoxMyPrograms.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxMyPrograms.FormattingEnabled = true;
            this.ListBoxMyPrograms.Location = new System.Drawing.Point(3, 3);
            this.ListBoxMyPrograms.Name = "ListBoxMyPrograms";
            this.ListBoxMyPrograms.Size = new System.Drawing.Size(168, 423);
            this.ListBoxMyPrograms.TabIndex = 1;
            this.ListBoxMyPrograms.SelectedIndexChanged += new System.EventHandler(this.ListBoxMyPrograms_SelectedIndexChanged);
            // 
            // TabPageMyLibrary
            // 
            this.TabPageMyLibrary.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageMyLibrary.Controls.Add(this.PanelMyLibrary);
            this.TabPageMyLibrary.Controls.Add(this.ListBoxMyLibrary);
            this.TabPageMyLibrary.Location = new System.Drawing.Point(4, 49);
            this.TabPageMyLibrary.Name = "TabPageMyLibrary";
            this.TabPageMyLibrary.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageMyLibrary.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TabPageMyLibrary.Size = new System.Drawing.Size(870, 429);
            this.TabPageMyLibrary.TabIndex = 2;
            this.TabPageMyLibrary.Text = "My Library";
            // 
            // PanelMyLibrary
            // 
            this.PanelMyLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMyLibrary.Location = new System.Drawing.Point(171, 3);
            this.PanelMyLibrary.Name = "PanelMyLibrary";
            this.PanelMyLibrary.Size = new System.Drawing.Size(696, 423);
            this.PanelMyLibrary.TabIndex = 6;
            // 
            // ListBoxMyLibrary
            // 
            this.ListBoxMyLibrary.Dock = System.Windows.Forms.DockStyle.Left;
            this.ListBoxMyLibrary.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxMyLibrary.FormattingEnabled = true;
            this.ListBoxMyLibrary.Location = new System.Drawing.Point(3, 3);
            this.ListBoxMyLibrary.Name = "ListBoxMyLibrary";
            this.ListBoxMyLibrary.Size = new System.Drawing.Size(168, 423);
            this.ListBoxMyLibrary.TabIndex = 2;
            this.ListBoxMyLibrary.SelectedIndexChanged += new System.EventHandler(this.ListBoxMyLibrary_SelectedIndexChanged);
            // 
            // TabPageStore
            // 
            this.TabPageStore.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageStore.Location = new System.Drawing.Point(4, 49);
            this.TabPageStore.Name = "TabPageStore";
            this.TabPageStore.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TabPageStore.Size = new System.Drawing.Size(870, 429);
            this.TabPageStore.TabIndex = 3;
            this.TabPageStore.Text = "Store";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 522);
            this.Controls.Add(this.ThemeContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ByteGuard - Control Panel";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ThemeContainer.ResumeLayout(false);
            this.TabControlMain.ResumeLayout(false);
            this.TabPageMyAccount.ResumeLayout(false);
            this.TabPageMyPrograms.ResumeLayout(false);
            this.TabPageMyLibrary.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Theme.ThemeContainer ThemeContainer;
        private Theme.TabControlTop TabControlMain;
        private System.Windows.Forms.TabPage TabPageMyAccount;
        private System.Windows.Forms.TabPage TabPageMyPrograms;
        private System.Windows.Forms.TabPage TabPageMyLibrary;
        private System.Windows.Forms.TabPage TabPageStore;
        private System.Windows.Forms.ListBox ListBoxMyPrograms;
        private System.Windows.Forms.Panel PanelMyPrograms;
        private System.Windows.Forms.Panel PanelMyAccount;
        private System.Windows.Forms.ListBox ListBoxMyLibrary;
        private System.Windows.Forms.Panel PanelMyLibrary;
        private System.Windows.Forms.Button ButtonRedeemProgram;
    }
}