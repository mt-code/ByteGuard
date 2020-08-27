namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    partial class AddVariable
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
            this.components = new System.ComponentModel.Container();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ThemeContainer = new ByteGuardInterface.Theme.ThemeContainer();
            this.ButtonAddVariable = new System.Windows.Forms.Button();
            this.LineSeparator1 = new ByteGuardInterface.Theme.LineSeparator();
            this.TextBoxValue = new System.Windows.Forms.TextBox();
            this.LabelValue = new System.Windows.Forms.Label();
            this.TextBoxKey = new System.Windows.Forms.TextBox();
            this.LabelKey = new System.Windows.Forms.Label();
            this.ThemeContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolTip
            // 
            this.ToolTip.AutomaticDelay = 250;
            // 
            // ThemeContainer
            // 
            this.ThemeContainer.Controls.Add(this.ButtonAddVariable);
            this.ThemeContainer.Controls.Add(this.LineSeparator1);
            this.ThemeContainer.Controls.Add(this.TextBoxValue);
            this.ThemeContainer.Controls.Add(this.LabelValue);
            this.ThemeContainer.Controls.Add(this.TextBoxKey);
            this.ThemeContainer.Controls.Add(this.LabelKey);
            this.ThemeContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThemeContainer.Location = new System.Drawing.Point(0, 0);
            this.ThemeContainer.Name = "ThemeContainer";
            this.ThemeContainer.Size = new System.Drawing.Size(231, 221);
            this.ThemeContainer.TabIndex = 0;
            this.ThemeContainer.Text = "themeContainer1";
            // 
            // ButtonAddVariable
            // 
            this.ButtonAddVariable.Location = new System.Drawing.Point(20, 149);
            this.ButtonAddVariable.Name = "ButtonAddVariable";
            this.ButtonAddVariable.Size = new System.Drawing.Size(188, 25);
            this.ButtonAddVariable.TabIndex = 5;
            this.ButtonAddVariable.Text = "Add Variable";
            this.ButtonAddVariable.UseVisualStyleBackColor = true;
            this.ButtonAddVariable.Click += new System.EventHandler(this.ButtonAddVariable_Click);
            // 
            // LineSeparator1
            // 
            this.LineSeparator1.Location = new System.Drawing.Point(20, 141);
            this.LineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.LineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.LineSeparator1.Name = "LineSeparator1";
            this.LineSeparator1.Size = new System.Drawing.Size(188, 2);
            this.LineSeparator1.TabIndex = 4;
            // 
            // TextBoxValue
            // 
            this.TextBoxValue.Location = new System.Drawing.Point(20, 115);
            this.TextBoxValue.MaxLength = 255;
            this.TextBoxValue.Name = "TextBoxValue";
            this.TextBoxValue.Size = new System.Drawing.Size(188, 20);
            this.TextBoxValue.TabIndex = 3;
            this.ToolTip.SetToolTip(this.TextBoxValue, "The variable value that will be stored in the database.");
            this.TextBoxValue.TextChanged += new System.EventHandler(this.TextBoxValue_TextChanged);
            // 
            // LabelValue
            // 
            this.LabelValue.AutoSize = true;
            this.LabelValue.Location = new System.Drawing.Point(17, 97);
            this.LabelValue.Name = "LabelValue";
            this.LabelValue.Size = new System.Drawing.Size(83, 15);
            this.LabelValue.TabIndex = 2;
            this.LabelValue.Text = "Value (0/255):";
            // 
            // TextBoxKey
            // 
            this.TextBoxKey.Location = new System.Drawing.Point(20, 74);
            this.TextBoxKey.MaxLength = 25;
            this.TextBoxKey.Name = "TextBoxKey";
            this.TextBoxKey.Size = new System.Drawing.Size(188, 20);
            this.TextBoxKey.TabIndex = 1;
            this.ToolTip.SetToolTip(this.TextBoxKey, "A reference key that will be used to retrieve the variable from the database.");
            this.TextBoxKey.TextChanged += new System.EventHandler(this.TextBoxKey_TextChanged);
            // 
            // LabelKey
            // 
            this.LabelKey.AutoSize = true;
            this.LabelKey.Location = new System.Drawing.Point(17, 56);
            this.LabelKey.Name = "LabelKey";
            this.LabelKey.Size = new System.Drawing.Size(65, 15);
            this.LabelKey.TabIndex = 0;
            this.LabelKey.Text = "Key (0/25):";
            // 
            // AddVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ThemeContainer);
            this.Name = "AddVariable";
            this.Size = new System.Drawing.Size(231, 221);
            this.ThemeContainer.ResumeLayout(false);
            this.ThemeContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Theme.ThemeContainer ThemeContainer;
        private System.Windows.Forms.Label LabelKey;
        private System.Windows.Forms.TextBox TextBoxValue;
        private System.Windows.Forms.Label LabelValue;
        private System.Windows.Forms.TextBox TextBoxKey;
        private System.Windows.Forms.Button ButtonAddVariable;
        private Theme.LineSeparator LineSeparator1;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}
