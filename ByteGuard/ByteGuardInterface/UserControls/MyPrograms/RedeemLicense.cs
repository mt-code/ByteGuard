using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ByteGuard.Tasks;
using ByteGuard.Tasks.Licensing;
using Variables = ByteGuard.ByteGuardInterface.Globals.Variables;

namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    public partial class RedeemLicense : UserControl
    {
        private Variables.ByteGuardLicense _byteguardLicense;

        private delegate void SetControlsDelegate(bool isEnabled);

        public RedeemLicense(Variables.ByteGuardLicense byteguardLicense)
        {
            InitializeComponent();

            _byteguardLicense = byteguardLicense;
            Variables.Containers.Active = ThemeContainer;
        }

        private void RedeemLicense_Load(object sender, EventArgs e)
        {
            ActiveControl = ThemeContainer;

            // Changes the value label depending on if it is a point/duration license.
            DropDownLicenseType.Text = (_byteguardLicense.LicenseType == 0 ? "Duration" : "Points");
            LabelValue.Text = (_byteguardLicense.LicenseType == 0 ? "Days (0 = Unlimited):" : "Value");

            // Sets the numeric textbox to the licenses' value.
            TextBoxValue.Value = Convert.ToDecimal(_byteguardLicense.LicenseValue);

            // Sets the tracking description textbox to the licenses' tracking description.
            TextBoxTrackingDescription.Text = _byteguardLicense.TrackingDescription;

            // Displays the license code in the status bar.
            ThemeContainer.SetStatus(String.Format("Code: {0}", _byteguardLicense.LicenseCode), 3);
        }

        private void ButtonRedeem_Click(object sender, EventArgs e)
        {
            // Check the username textbox has been changed, and that the text is between 4-12 characters.
            if (TextBoxRedeemTo.Text == "Username" || TextBoxRedeemTo.TextLength > 12 || TextBoxRedeemTo.TextLength < 4)
            {
                ThemeContainer.SetStatus("Enter a valid username.", 1);
                return;
            }

            // Asks the user to confirm they have entered the correct username.
            if (
                MessageBox.Show(String.Format("Have you entered the correct username? ({0})", TextBoxRedeemTo.Text),
                    "Redeem License", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Disables the form controls.
                SetControls(false);

                // Attempts to redeem the license to the specified username on a seperate thread.
                Thread redeemLicenseThread = new Thread(RedeemLicenseThreaded);
                redeemLicenseThread.Start(TextBoxRedeemTo.Text);
            }
        }

        /// <summary>
        ///     Redeems the current license code to the specified username.
        /// </summary>
        /// <param name="usernameToRedeem">The username to redeem the license to.</param>
        private void RedeemLicenseThreaded(object usernameToRedeem)
        {
            NameValueCollection dataValues = new NameValueCollection
            {
                {"c", _byteguardLicense.LicenseCode},
                {"u", (string) usernameToRedeem}
            };

            if (Network.SubmitData("redeemtouser", dataValues))
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

            // Checks if the request completed successfully.
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
                // Displays the error message in the status strip and re-enables the controls.
                ThemeContainer.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);
                SetControls(true);
            }
        }

        #region Misellaneous Control Methods.

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
                TextBoxRedeemTo.Enabled = isEnabled;
                ButtonRedeem.Enabled = isEnabled;
            }
        }

        private void TextBoxRedeemTo_Enter(object sender, EventArgs e)
        {
            TextBoxRedeemTo.Clear();
            TextBoxRedeemTo.ForeColor = Color.Black;
        }

        #endregion
    }
}