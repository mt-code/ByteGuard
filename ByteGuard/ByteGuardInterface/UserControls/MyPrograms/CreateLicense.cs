using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using ByteGuard.Tasks;
using ByteGuard.Tasks.Licensing;
using Variables = ByteGuard.ByteGuardInterface.Globals.Variables;

namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    public partial class CreateLicense : UserControl
    {
        public CreateLicense()
        {
            InitializeComponent();

            Variables.Containers.Active = ThemeContainer;
        }

        private void CreateLicense_Load(object sender, EventArgs e)
        {
            // Sets the active control.
            ActiveControl = TextBoxTrackingDescription;

            // Selects the first item in the drop down list.
            DropDownLicenseType.SelectedIndex = 0;
        }

        private void ButtonCreateLicense_Click(object sender, EventArgs e)
        {
            // Checks that the tracking description is not greater than 30 charaters.
            if (TextBoxTrackingDescription.TextLength > 30)
            {
                Variables.Containers.Active.SetStatus("Invalid tracking description.", 1);
            }
            else
            {
                // Disables all neccesary controls on the form to prevent spamming.
                SetControls(false);

                // Attempts to create the new license on a seperate thread.
                Thread createLicenseThread = new Thread(CreateLicenseThreaded);
                createLicenseThread.Start();
            }
        }

        private void CreateLicenseThreaded()
        {
            string licenseType = "", licenseValue = "", licenseDescription = "";

            Invoke((MethodInvoker) delegate
            {
                licenseType = DropDownLicenseType.SelectedIndex.ToString();
                licenseValue = TextBoxValue.Value.ToString(CultureInfo.InvariantCulture);
                licenseDescription = TextBoxTrackingDescription.Text;
            });

            NameValueCollection dataValues = new NameValueCollection
            {
                {"pid", Variables.MyProgramsSelected.Programid},
                {"t", licenseType},
                {"v", licenseValue},
                {"d", licenseDescription}
            };

            if (Network.SubmitData("createlicense", dataValues))
                ProcessResponse();
            else
                ResetControls(false);
        }

        private void ProcessResponse()
        {
            string webResponse = Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                string licenseCode = webResponse.Replace("[SUCCESS] ", String.Empty);

                Invoke((MethodInvoker) delegate
                {
                    TextBoxLicenseCode.Text = licenseCode;

                    if (CheckBoxCopyToClipboard.Checked)
                        Clipboard.SetText(licenseCode);
                });

                SetControls(true);
                ResetControls(true);

                Variables.Containers.Active.SetStatus("License successfully created.", 4);

                Licenses.GetLicenses(Variables.MyProgramsSelected.Programid);
            }
            else
            {
                Variables.Containers.Active.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);
                ResetControls(false);
            }
        }

        private delegate void SetControlsDelegate(bool isEnabled);

        #region Miscellaneous Control Methods.

        /// <summary>
        ///     Enables/disables the required form controls depending on the specified boolean value.
        /// </summary>
        /// <param name="isEnabled">If true, the controls will be enabled. If false, the controls will be disabled.</param>
        private void SetControls(bool isEnabled)
        {
            if (InvokeRequired)
            {
                Invoke(new SetControlsDelegate(SetControls), isEnabled);
            }
            else
            {
                DropDownLicenseType.Enabled = isEnabled;
                TextBoxValue.Enabled = isEnabled;
                TextBoxTrackingDescription.Enabled = isEnabled;
                ButtonCreateLicense.Enabled = isEnabled;
            }
        }

        /// <summary>
        ///     Resets the controls after an unsuccessful generation attempt.
        /// </summary>
        /// <param name="displayCode">If true, will clear the generated license code.</param>
        private void ResetControls(bool displayCode)
        {
            Invoke((MethodInvoker) delegate
            {
                if (!displayCode)
                    TextBoxLicenseCode.Clear();

                TextBoxTrackingDescription.Clear();
            });
        }

        private void DropDownLicenseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownLicenseType.SelectedIndex)
            {
                case 0:
                    ToolTip.SetToolTip(TextBoxValue, "The license duration in days.");
                    TextBoxValue.Value = 0;
                    LabelDuration.Text = "Days (0 = Unlimited):";
                    break;

                case 1:
                    ToolTip.SetToolTip(TextBoxValue, "The point value of the license.");
                    TextBoxValue.Value = 0;
                    LabelDuration.Text = "Value:";

                    break;
            }
        }

        #endregion
    }
}