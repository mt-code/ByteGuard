using System;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Tasks;
using ByteGuard.Tasks.Licensing;
using Variables = ByteGuard.ByteGuardInterface.Globals.Variables;

namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    public partial class ModifyLicense : UserControl
    {
        private delegate void SetControlsDelegate(bool isEnabled);

        private Variables.ByteGuardLicense _byteguardLicense;

        public ModifyLicense(Variables.ByteGuardLicense byteguardLicense)
        {
            InitializeComponent();

            _byteguardLicense = byteguardLicense;

            Variables.Containers.Active = ThemeContainer;
        }

        private void ModifyLicense_Load(object sender, EventArgs e)
        {
            // Sets the active control to the save button.
            ActiveControl = ButtonSave;

            Form parentForm = ParentForm;

            // Displays the license code in the form title text.
            if (parentForm != null) parentForm.Text = String.Format("License [{0}]", _byteguardLicense.LicenseCode);

            // Checks if the current license has been redeemed.
            if (_byteguardLicense.RedeemedTime != "0")
            {
                // If so, displays the time it was redeeemed.
                LabelRedeemedTo.Text = String.Format("Redeemed ({0}):",
                    Methods.TimeStampToDate(Convert.ToDouble(_byteguardLicense.RedeemedTime)));

                // If so, displays who the license was redeemed to.
                TextBoxRedeemedTo.Text = _byteguardLicense.RedeemedTo;
            }

            // Displays the date the license was created.
            TextBoxCreationDate.Text = Methods.TimeStampToDate(Convert.ToDouble(_byteguardLicense.CreationTime));

            // Displays how many characters have been used for the tracking description.
            LabelDescription.Text = String.Format("Tracking Description ({0}/30):",
                TextBoxTrackingDescription.TextLength);

            // Displays the license tracking description.
            TextBoxTrackingDescription.Text = _byteguardLicense.TrackingDescription;

            // Checks if the current license has been banned or frozen.
            if (_byteguardLicense.IsFrozen)
            {
                // If banned, displays the ban reason.
                DropDownLock.SelectedIndex = 2;
                TextBoxLockReason.Text = _byteguardLicense.LockReason;
            }
            else if (_byteguardLicense.IsBanned)
            {
                // If frozen, displays the freeze reason.
                DropDownLock.SelectedIndex = 1;
                TextBoxLockReason.Text = _byteguardLicense.LockReason;
            }
            else
            {
                DropDownLock.SelectedIndex = 0;
            }

            // If LicenseType = Points, disable the LockLicense controls.
            if (_byteguardLicense.LicenseType == 1)
            {
                DropDownLock.Enabled = false;
                TextBoxLockReason.Enabled = false;
            }

            if (TextBoxLockReason.Text != "None Specified")
                TextBoxLockReason.ForeColor = System.Drawing.Color.Black;

            // Disables the 'Save' button until the license has been edited.
            ButtonSave.Enabled = false;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Disables the forms controls.
            SetControls(false);

            string[] threadObject =
            {
                _byteguardLicense.LicenseCode,
                TextBoxTrackingDescription.Text,
                DropDownLock.SelectedIndex.ToString(),
                TextBoxLockReason.Text
            };

            // Attempts to update the current license with the specified details on a seperate thread.
            Thread threadUpdateLicense = new Thread(UpdateLicenseThreaded);
            threadUpdateLicense.Start(threadObject);
        }

        /// <summary>
        ///     Updates the current license with the specified details.
        /// </summary>
        private void UpdateLicenseThreaded(object threadObject)
        {
            string[] threadObjectArray = (string[]) threadObject;

            NameValueCollection dataValues = new NameValueCollection
            {
                {"c", threadObjectArray[0]},
                {"d", threadObjectArray[1]},
                {"l", threadObjectArray[2]},
                {"ld", threadObjectArray[3]}
            };

            if (Network.SubmitData("updatelicense", dataValues))
                ProcessResponse();
            else
                SetControls(true);
        }

        /// <summary>
        ///     Gets and displays the licenses for the specified Programid.
        /// </summary>
        /// <param name="programid">The Programid to fetch the licenses for.</param>
        private void GetLicenses(object programid)
        {
            // Alerts the user that the licenses are being downloaded.
            Variables.Containers.Main.SetStatus("Loading licenses...", 3);

            Licenses.GetLicenses((string) programid);
        }

        /// <summary>
        ///     Processes the server response and acts accordingly.
        /// </summary>
        private void ProcessResponse()
        {
            // Converts the response bytes into a string.
            string webResponse = Variables.WebResponse;

            // Check if the request completed successfully.
            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                // Displays the success message in the status strip.
                ThemeContainer.SetStatus(webResponse.Replace("[SUCCESS] ", String.Empty), 4);

                // Gets and displays the licenses for the current Programid.
                Thread getLicensesThread = new Thread(GetLicenses);
                getLicensesThread.Start(Variables.MyProgramsSelected.Programid);
            }
            else
            {
                // Displays the error message in the status strip.
                ThemeContainer.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);
            }

            // Re-enables the form controls.
            SetControls(true);
        }

        #region Miscellaneous Control Methods.

        /// <summary>
        ///     Enables/Disables the form controls depending on the specified boolean value.
        /// </summary>
        /// <param name="isEnabled">If TRUE, controls are enabled. If FALSE, controls are disabled.</param>
        private void SetControls(bool isEnabled)
        {
            if (InvokeRequired)
            {
                Invoke(new SetControlsDelegate(SetControls), isEnabled);
            }
            else
            {
                TextBoxTrackingDescription.Enabled = isEnabled;
                DropDownLock.Enabled = isEnabled;

                if (!isEnabled)
                {
                    ButtonSave.Enabled = false;
                    TextBoxLockReason.Enabled = false;
                }
                else
                    TextBoxLockReason.Enabled = (DropDownLock.SelectedIndex == 1 || DropDownLock.SelectedIndex == 2);
            }
        }

        private void DropDownLock_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Displays different message depending on the selected item.
            switch (DropDownLock.SelectedIndex)
            {
                // None.
                case 0:
                    TextBoxLockReason.Clear();
                    TextBoxLockReason.Enabled = false;
                    Variables.Containers.Active.SetStatus("This license is not locked.", 3);
                    break;

                // Banned.
                case 1:
                case 2:
                    TextBoxLockReason.Text = "None Specified";
                    TextBoxLockReason.ForeColor = System.Drawing.Color.DarkGray;
                    TextBoxLockReason.Enabled = true;
                    Variables.Containers.Active.SetStatus((DropDownLock.SelectedIndex == 1 ? "License is locked, will expire." : "License is locked, will not expire."), 3);
                    break;
            }

            // Enables the 'Save' button if the selected item is changed.
            ButtonSave.Enabled = true;
        }

        private void TextBoxTrackingDescription_TextChanged(object sender, EventArgs e)
        {
            LabelDescription.Text = String.Format("Tracking Description ({0}/30):",
                TextBoxTrackingDescription.TextLength);
            ButtonSave.Enabled = true;
        }

        private void TextBoxLockReason_TextChanged(object sender, EventArgs e)
        {
            LabelReason.Text = String.Format("Reason ({0}/15):", TextBoxLockReason.TextLength);
            ButtonSave.Enabled = true;
        }

        #endregion

        private void TextBoxLockReason_Enter(object sender, EventArgs e)
        {
            if (TextBoxLockReason.Text == "None Specified")
            {
                TextBoxLockReason.Clear();
                TextBoxLockReason.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
}