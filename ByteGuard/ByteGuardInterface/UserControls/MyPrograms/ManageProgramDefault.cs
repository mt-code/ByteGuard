using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Forms;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Tasks;
using ByteGuard.Tasks.Licensing;
using Variables = ByteGuard.ByteGuardInterface.Globals.Variables;

namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    public partial class ManageProgramDefault : UserControl
    {
        private bool _isAdmin;

        public ManageProgramDefault()
        {
            InitializeComponent();

            Variables.UserControls.ManageProgram = this;
        }

        // TODO: Change SetStatus depending on the selected tab.
        private void TabControlManageProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Back()
        {
            Variables.Containers.Main.SetStatus("Create a new program or manage an existing one.", 3);
            
            Parent.Controls.Add(Variables.UserControls.MyProgramsDefault);
            Parent.Controls.Remove(this);
            Dispose();
        }

        private void GetProgramOwnerInformation(object username)
        {
            Variables.Users.ProgramOwner = Methods.DownloadUserData(username.ToString());

            try
            {
                Invoke((MethodInvoker)delegate
                {
                    LabelLicensesRemaining.Text = String.Format("This program can create {0} more license(s).",
                        Variables.Users.ProgramOwner.LicensesRemaining);
                    LabelVariablesRemaining.Text = String.Format("This program can support {0} more variable(s).",
                        Variables.Users.ProgramOwner.VariablesRemaining);
                    LabelAdministratorsRemaining.Text = String.Format(
                        "This program can support {0} more administrator(s).",
                        Variables.Users.ProgramOwner.ProgramAdministratorsRemaining);
                });
            }
            catch
            {
                // IsDisposed
            }
        }

        // TODO: Add bool to getX methods to allow the remaining count to be updated.
        private void ManageProgram_Load(object sender, EventArgs e)
        {
            var currentProgram = Variables.MyProgramsSelected;
            _isAdmin = currentProgram.IsAdmin;

            // Resets the IsFirstTime variable to true.
            Licenses.Initialize();
            Programs.Initialize();
            Tasks.Licensing.Variables.Initialize();

            pbStorePurchased.BackColor = Color.FromArgb(40, 95, 125);

            // Allow the static methods access to the variables.
            // Licenses Controls.
            Licenses.IsAdmin = _isAdmin;
            Licenses.LicensesRemaining = LabelLicensesRemaining;
            Licenses.CreateLicenseButton = ButtonCreateLicense;
            Licenses.ListViewLicenses = ListViewLicenses;

            // Variables Controls.
            Tasks.Licensing.Variables.IsAdmin = _isAdmin;
            Tasks.Licensing.Variables.VariablesRemaining = LabelVariablesRemaining;
            Tasks.Licensing.Variables.CreateVariableButton = ButtonAddVariable;
            Tasks.Licensing.Variables.ListViewVariables = ListViewVariables;

            // Options/Administrator Controls.
            Programs.IsAdmin = _isAdmin;
            Programs.AdminsRemaining = LabelAdministratorsRemaining;
            Programs.ButtonAddAdministrator = ButtonAddAdministrator;
            Programs.ListViewAdministrators = ListViewAdministrators;

            // Options/Limit Controls.
            Programs.ButtonSaveLockChanges = ButtonSaveLockChanges;
            Programs.BanLicenseIfLimitReached = CheckBoxBanLicenseLimitReached;
            Programs.HwidLimit = TextBoxHWidLimit;
            Programs.HWidExpiration = TextBoxHWidExpiration;
            Programs.IpLimit = TextBoxIPLimit;
            Programs.IpExpiration = TextBoxIPExpiration;

            string programid = currentProgram.Programid;

            Thread getLicensesThread = new Thread(GetLicenses);
            getLicensesThread.Start(programid);

            Thread getAdminsThread = new Thread(GetAdministrators);
            getAdminsThread.Start(programid);

            Thread getLimitsThread = new Thread(GetLockLimits);
            getLimitsThread.Start(programid);

            Thread getVariablesThread = new Thread(GetVariables);
            getVariablesThread.Start(programid);

            // TODO: If not marketplace registered, show a different tab as upload tab isn't required.
            TabPageUpload.Controls.Add(new UploadProgram(this));
            TabPageAnalytics.Controls.Add(new Analytics());

            // Adds the relevant marketplace user control to the marketplace tab.
            if (currentProgram.MarketplaceFeePaid && currentProgram.DistributionModel == 1) // Marketplace.
            {
                // TODO: Show marketplace controls/options, user has been approved and has paid.
                TabPageMarketplace.Controls.Add(new MyLibrary.MarketplaceDefault());
            }
            else if (currentProgram.DistributionModel == 2) // Self Distribution.
            {
                // TODO: Show marketplace registration, user needs to pay here.
                TabPageMarketplace.Controls.Add(new MyLibrary.MarketplaceApplication());
            }

            if (!_isAdmin)
            {
                // User owns program.
                LabelLicensesRemaining.Text = String.Format("Your account can create {0} more license(s).",
                    Variables.Users.Current.LicensesRemaining);
                LabelVariablesRemaining.Text = String.Format("Your account can support {0} more variable(s).",
                    Variables.Users.Current.VariablesRemaining);
                LabelAdministratorsRemaining.Text = String.Format(
                    "This program can support {0} more administrator(s).",
                    Variables.Users.Current.ProgramAdministratorsRemaining);
            }
            else
            {
                // User is a program administrator.
                Thread getOwnerInfoThread = new Thread(GetProgramOwnerInformation);
                getOwnerInfoThread.Start(
                    Variables.MyProgramsSelected.CreatorUsername);
            }

            ComboBoxLockType.SelectedIndex = 0;
        }

        private void ButtonSaveLockChanges_Click(object sender, EventArgs e)
        {
            Thread setLockLimits = new Thread(Programs.SetLockLimits);
            setLockLimits.Start(Variables.MyProgramsSelected.Programid);
        }

        private void ComboBoxLockType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ButtonViewLocks_Click(object sender, EventArgs e)
        {
        }

        private void GetLockLimits(object programid)
        {
            Programs.GetLockLimits((string) programid);
        }

        private void TextBoxHWidLimit_ValueChanged(object sender, EventArgs e)
        {
            ButtonSaveLockChanges.Enabled = true;
        }

        private void TextBoxHWidExpiration_ValueChanged(object sender, EventArgs e)
        {
            ButtonSaveLockChanges.Enabled = true;
        }

        private void TextBoxIPLimit_ValueChanged(object sender, EventArgs e)
        {
            ButtonSaveLockChanges.Enabled = true;
        }

        private void TextBoxIPExpiration_ValueChanged(object sender, EventArgs e)
        {
            ButtonSaveLockChanges.Enabled = true;
        }

        private void CheckBoxBanLicenseLimitReached_CheckedChanged(object sender, EventArgs e)
        {
            ButtonSaveLockChanges.Enabled = true;
        }

        #region Licenses Methods.

        private void ListViewLicenses_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewLicenses.SelectedIndices.Clear();

                if (ListViewLicenses.FocusedItem.Bounds.Contains(e.Location))
                {
                    ListViewLicenses.FocusedItem.Selected = true;

                    // Disable 'Redeem' item if license has been redeemed.
                    MenuItemRedeem.Enabled = (ListViewLicenses.FocusedItem.SubItems[0].Text == String.Empty);

                    // Disable 'Unlock Code' item if license is not locked.
                    MenuItemUnlockLicense.Enabled = (ListViewLicenses.FocusedItem.SubItems[2].Text == "True");

                    MenuStripLicenses.Show(Cursor.Position);
                }
            }
        }

        private void ButtonCreateLicense_Click(object sender, EventArgs e)
        {
            ButtonCreateLicense.Enabled = false;

            BlankForm createLicenseForm = new BlankForm(new CreateLicense(), true) {Text = "Create License"};
            createLicenseForm.FormClosing += (closedSender, closedE) => ButtonCreateLicense.Enabled = true;
            createLicenseForm.Show();
        }

        private void ButtonSearchLicenses_Click(object sender, EventArgs e)
        {
            switch (ButtonSearchLicenses.Text)
            {
                case "Search":
                    TextBoxLicenseSearch.Enabled = false;

                    if (TextBoxLicenseSearch.Text != String.Empty)
                    {
                        foreach (ListViewItem lvItem in ListViewLicenses.Items)
                        {
                            foreach (ListViewItem.ListViewSubItem lvsItem in lvItem.SubItems)
                            {
                                if (lvsItem.Text.ToLower().Contains(TextBoxLicenseSearch.Text.ToLower()))
                                {
                                    lvItem.BackColor = Color.FromArgb(137, 195, 217);
                                    break;
                                }
                            }
                        }

                        ButtonSearchLicenses.Text = "Reset";
                    }
                    else
                    {
                        TextBoxLicenseSearch.Enabled = true;
                    }
                    break;

                case "Reset":
                    foreach (ListViewItem lvItem in ListViewLicenses.Items)
                        lvItem.BackColor = Color.White;

                    TextBoxLicenseSearch.Clear();
                    TextBoxLicenseSearch.Enabled = true;
                    ButtonSearchLicenses.Text = "Search";
                    break;
            }
        }

        private void ButtonBackLicenses_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void GetLicenses(object programid)
        {
            Licenses.GetLicenses((string) programid);
        }

        private void MenuItemRedeem_Click(object sender, EventArgs e)
        {
            BlankForm redeemLicenseForm =
                new BlankForm(new RedeemLicense(Variables.MyLicenses[ListViewLicenses.SelectedItems[0].Index]), true)
                {
                    Text = "Redeem License"
                };
            redeemLicenseForm.Show();
        }

        private void MenuItemModify_Click(object sender, EventArgs e)
        {
            BlankForm f =
                new BlankForm(
                    new ModifyLicense(
                        Variables.MyLicenses.First(
                            l => l.LicenseCode == ListViewLicenses.SelectedItems[0].SubItems[1].Text)), true)
                {
                    Text = "Modify License"
                };
            f.Show();
        }

        private void MenuItemUnlockLicense_Click(object sender, EventArgs e)
        {
            // Asks the user to confirm they want to unlock this license.
            if (
                MessageBox.Show("Are you sure you want to unlock this license?", "Unlock License",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Unlocks the selected license.
                Thread unlockLicenseThread = new Thread(UnlockLicenseThreaded);
                unlockLicenseThread.Start(ListViewLicenses.FocusedItem.SubItems[1].Text);
            }
        }

        private void MenuItemCopyCode_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ListViewLicenses.SelectedItems[0].SubItems[1].Text);
        }

        /// <summary>
        ///     Updates the current license with the specified details.
        /// </summary>
        /// <param name="licenseCode">The details to update the license. (code:description:lock:lockdetails)</param>
        private void UnlockLicenseThreaded(object licenseCode)
        {
            NameValueCollection dataValues = new NameValueCollection {{"c", (string) licenseCode}};

            if (Network.SubmitData("unlocklicense", dataValues))
                ProcessResponseUnlockLicense();
        }

        private void ProcessResponseUnlockLicense()
        {
            // Converts the response bytes into a string.
            string webResponse = Variables.WebResponse;

            // Check if the request completed successfully.
            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                // Displays the success message in the status strip.
                Variables.Containers.Main.SetStatus(webResponse.Replace("[SUCCESS] ", String.Empty), 4);

                // Gets and displays the licenses for the current Programid.
                Thread getLicensesThread = new Thread(GetLicenses);
                getLicensesThread.Start(Variables.MyProgramsSelected.Programid);
            }
            else
            {
                // Displays the error message in the status strip.
                Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);
            }
        }

        #endregion

        #region Variables Methods.

        private void ButtonAddVariable_Click(object sender, EventArgs e)
        {
            ButtonAddVariable.Enabled = false;

            BlankForm addVariableForm = new BlankForm(new AddVariable(), true) {Text = "Add Server Variable"};
            addVariableForm.FormClosing += (closedSender, closedE) => ButtonAddVariable.Enabled = true;
            addVariableForm.Show();
        }

        private void ButtonSearchVariable_Click(object sender, EventArgs e)
        {
            switch (ButtonSearchVariables.Text)
            {
                case "Search":
                    TextBoxSearchVariables.Enabled = false;

                    if (TextBoxSearchVariables.Text != String.Empty)
                    {
                        foreach (ListViewItem lvItem in ListViewVariables.Items)
                        {
                            foreach (ListViewItem.ListViewSubItem lvsItem in lvItem.SubItems)
                            {
                                if (lvsItem.Text.ToLower().Contains(TextBoxSearchVariables.Text.ToLower()))
                                {
                                    lvItem.BackColor = Color.FromArgb(137, 195, 217);
                                    break;
                                }
                            }
                        }

                        ButtonSearchVariables.Text = "Reset";
                    }
                    else
                    {
                        TextBoxSearchVariables.Enabled = true;
                    }
                    break;

                case "Reset":
                    foreach (ListViewItem lvItem in ListViewVariables.Items)
                        lvItem.BackColor = Color.White;

                    TextBoxSearchVariables.Clear();
                    TextBoxSearchVariables.Enabled = true;
                    ButtonSearchVariables.Text = "Search";
                    break;
            }
        }

        private void ButtonBackVariable_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void GetVariables(object programid)
        {
            Tasks.Licensing.Variables.GetVariables((string) programid);
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Are you sure you want to permanently remove this server variable?",
                    "Remove Server Variable", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Thread removeVariableThread = new Thread(RemoveVariable);
                removeVariableThread.Start(ListViewVariables.FocusedItem.SubItems[0].Text);
            }
        }

        private void RemoveVariable(object variableKey)
        {
            NameValueCollection dataValues = new NameValueCollection
            {
                {"pid", Variables.MyProgramsSelected.Programid},
                {"k", variableKey.ToString()}
            };

            if (Network.SubmitData("removevar", dataValues))
                ProcessResponseRemoveVariable();
        }

        private void ProcessResponseRemoveVariable()
        {
            // Converts the response bytes into a string.
            string webResponse = Variables.WebResponse;

            // Check if the request completed successfully.
            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                // Displays the success message in the status strip.
                Variables.Containers.Main.SetStatus(webResponse.Replace("[SUCCESS] ", String.Empty), 4);

                // Gets and displays the licenses for the current Programid.
                Thread getVariablesThread = new Thread(GetVariables);
                getVariablesThread.Start(Variables.MyProgramsSelected.Programid);
            }
            else
            {
                // Displays the error message in the status strip.
                Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);
            }
        }

        private void ListViewVariables_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewVariables.SelectedIndices.Clear();

                if (ListViewVariables.FocusedItem.Bounds.Contains(e.Location))
                {
                    ListViewVariables.FocusedItem.Selected = true;

                    MenuStripVariables.Show(Cursor.Position);
                }
            }
        }

        private void LinkLabelServerVariableTutorial_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // TODO: Browse to server variables tutorial.
            System.Diagnostics.Process.Start("http://www.byteguardsoftware.co.uk/blog/server-variables-tutorial");
        }

        private void LinkLabelOpenHelperDirectory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // TODO: Check if DLL exists in current directory (it should). If it doesn't, decompress from resources and save.
            System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
        }

        #endregion

        #region Options/Administrator Methods.

        private void ButtonAddAdministrator_Click(object sender, EventArgs e)
        {
            ButtonAddAdministrator.Enabled = false;

            BlankForm addAdministratorForm = new BlankForm(new AddAdmin(), true) {Text = "Add Program Administrator"};
            addAdministratorForm.FormClosing += (closedSender, closedE) => ButtonAddAdministrator.Enabled = true;
            addAdministratorForm.Show();
        }

        private void GetAdministrators(object programid)
        {
            Programs.GetAdministrators((string) programid);
        }

        private void ButtonBackOptions_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void ListViewAdministrators_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewAdministrators.SelectedIndices.Clear();

                if (ListViewAdministrators.FocusedItem.Bounds.Contains(e.Location))
                {
                    ListViewAdministrators.FocusedItem.Selected = true;

                    MenuStripAdmins.Show(Cursor.Position);
                }
            }
        }

        private void MenuItemRemove_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Are you sure you want to remove this program administrator?",
                    "Remove Program Administrator", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                DialogResult.Yes)
            {
                Thread removeAdminThread = new Thread(RemoveAdmin);
                removeAdminThread.Start(ListViewAdministrators.FocusedItem.SubItems[1].Text);
            }
        }

        private void RemoveAdmin(object adminEmail)
        {
            NameValueCollection dataValues = new NameValueCollection
            {
                {"pid", Variables.MyProgramsSelected.Programid},
                {"e", adminEmail.ToString()}
            };

            if (Network.SubmitData("removeadmin", dataValues))
                ProcessResponseRemoveAdmin();
        }

        private void ProcessResponseRemoveAdmin()
        {
            // Converts the response bytes into a string.
            string webResponse = Variables.WebResponse;

            // Check if the request completed successfully.
            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                // Displays the success message in the status strip.
                Variables.Containers.Main.SetStatus(webResponse.Replace("[SUCCESS] ", String.Empty), 4);

                // Gets and displays the licenses for the current Programid.
                Thread getAdminsThread = new Thread(GetAdministrators);
                getAdminsThread.Start(Variables.MyProgramsSelected.Programid);
            }
            else
            {
                // Displays the error message in the status strip.
                Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);
            }
        }

        #endregion
    }
}