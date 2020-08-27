namespace ByteGuard.ByteGuardInterface.UserControls.MyLibrary
{
    partial class MarketplaceApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketplaceApplication));
            this.btnApply = new System.Windows.Forms.Button();
            this.lblDistributionModelStatus = new System.Windows.Forms.Label();
            this.lblDistributionModel = new System.Windows.Forms.Label();
            this.lblByteGuardMarketplace = new System.Windows.Forms.Label();
            this.tbMarketplaceInformation = new System.Windows.Forms.TextBox();
            this.lblMoreInformation = new System.Windows.Forms.Label();
            this.linkFAQ = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.verticalLineSeparator1 = new ByteGuard.ByteGuardInterface.Theme.VerticalLineSeparator();
            this.lineSeparator1 = new ByteGuard.ByteGuardInterface.Theme.LineSeparator();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Verdana", 7.058824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(335, 355);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(201, 31);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Upgrade (£50)";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // lblDistributionModelStatus
            // 
            this.lblDistributionModelStatus.AutoSize = true;
            this.lblDistributionModelStatus.Font = new System.Drawing.Font("Verdana", 16.23529F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistributionModelStatus.Location = new System.Drawing.Point(7, 7);
            this.lblDistributionModelStatus.Name = "lblDistributionModelStatus";
            this.lblDistributionModelStatus.Size = new System.Drawing.Size(231, 28);
            this.lblDistributionModelStatus.TabIndex = 2;
            this.lblDistributionModelStatus.Text = "Distribution Model:";
            // 
            // lblDistributionModel
            // 
            this.lblDistributionModel.AutoSize = true;
            this.lblDistributionModel.Font = new System.Drawing.Font("Verdana", 14.11765F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistributionModel.ForeColor = System.Drawing.Color.DarkGray;
            this.lblDistributionModel.Location = new System.Drawing.Point(244, 9);
            this.lblDistributionModel.Name = "lblDistributionModel";
            this.lblDistributionModel.Size = new System.Drawing.Size(181, 25);
            this.lblDistributionModel.TabIndex = 3;
            this.lblDistributionModel.Text = "Self Distribution";
            // 
            // lblByteGuardMarketplace
            // 
            this.lblByteGuardMarketplace.AutoSize = true;
            this.lblByteGuardMarketplace.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblByteGuardMarketplace.ForeColor = System.Drawing.Color.DimGray;
            this.lblByteGuardMarketplace.Location = new System.Drawing.Point(9, 58);
            this.lblByteGuardMarketplace.Name = "lblByteGuardMarketplace";
            this.lblByteGuardMarketplace.Size = new System.Drawing.Size(292, 14);
            this.lblByteGuardMarketplace.TabIndex = 5;
            this.lblByteGuardMarketplace.Text = "Using the ByteGuard Marketplace, you can:";
            // 
            // tbMarketplaceInformation
            // 
            this.tbMarketplaceInformation.BackColor = System.Drawing.SystemColors.Control;
            this.tbMarketplaceInformation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMarketplaceInformation.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbMarketplaceInformation.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMarketplaceInformation.Location = new System.Drawing.Point(9, 84);
            this.tbMarketplaceInformation.Multiline = true;
            this.tbMarketplaceInformation.Name = "tbMarketplaceInformation";
            this.tbMarketplaceInformation.ReadOnly = true;
            this.tbMarketplaceInformation.Size = new System.Drawing.Size(306, 236);
            this.tbMarketplaceInformation.TabIndex = 6;
            this.tbMarketplaceInformation.Text = resources.GetString("tbMarketplaceInformation.Text");
            this.tbMarketplaceInformation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbMarketplaceInformation_MouseUp);
            // 
            // lblMoreInformation
            // 
            this.lblMoreInformation.AutoSize = true;
            this.lblMoreInformation.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoreInformation.ForeColor = System.Drawing.Color.DimGray;
            this.lblMoreInformation.Location = new System.Drawing.Point(9, 332);
            this.lblMoreInformation.Name = "lblMoreInformation";
            this.lblMoreInformation.Size = new System.Drawing.Size(294, 14);
            this.lblMoreInformation.TabIndex = 7;
            this.lblMoreInformation.Text = "For more information, please read the FAQ:";
            // 
            // linkFAQ
            // 
            this.linkFAQ.AutoSize = true;
            this.linkFAQ.Location = new System.Drawing.Point(39, 357);
            this.linkFAQ.Name = "linkFAQ";
            this.linkFAQ.Size = new System.Drawing.Size(232, 15);
            this.linkFAQ.TabIndex = 8;
            this.linkFAQ.TabStop = true;
            this.linkFAQ.Text = "Marketplace: Frequently Asked Questions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(332, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "What we need:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 7.764706F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(332, 84);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(201, 236);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "In order for you to upgrade, the only details we require is your PayPal email so " +
    "we know how to pay you.";
            // 
            // verticalLineSeparator1
            // 
            this.verticalLineSeparator1.Location = new System.Drawing.Point(324, 44);
            this.verticalLineSeparator1.MaximumSize = new System.Drawing.Size(2, 2000);
            this.verticalLineSeparator1.MinimumSize = new System.Drawing.Size(2, 2);
            this.verticalLineSeparator1.Name = "verticalLineSeparator1";
            this.verticalLineSeparator1.Size = new System.Drawing.Size(2, 342);
            this.verticalLineSeparator1.TabIndex = 4;
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(12, 42);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(524, 2);
            this.lineSeparator1.TabIndex = 1;
            // 
            // MarketplaceApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkFAQ);
            this.Controls.Add(this.lblMoreInformation);
            this.Controls.Add(this.tbMarketplaceInformation);
            this.Controls.Add(this.lblByteGuardMarketplace);
            this.Controls.Add(this.verticalLineSeparator1);
            this.Controls.Add(this.lblDistributionModel);
            this.Controls.Add(this.lblDistributionModelStatus);
            this.Controls.Add(this.lineSeparator1);
            this.Controls.Add(this.btnApply);
            this.Name = "MarketplaceApplication";
            this.Size = new System.Drawing.Size(548, 397);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private Theme.LineSeparator lineSeparator1;
        private System.Windows.Forms.Label lblDistributionModelStatus;
        private System.Windows.Forms.Label lblDistributionModel;
        private Theme.VerticalLineSeparator verticalLineSeparator1;
        private System.Windows.Forms.Label lblByteGuardMarketplace;
        private System.Windows.Forms.TextBox tbMarketplaceInformation;
        private System.Windows.Forms.Label lblMoreInformation;
        private System.Windows.Forms.LinkLabel linkFAQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
