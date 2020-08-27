using System;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Tasks;

namespace ByteGuard.ByteGuardInterface.UserControls.MyAccount
{
    public partial class ActivateAccount : UserControl
    {
        private delegate void SetControlsDelegate(bool isEnabled);

        public ActivateAccount()
        {
            InitializeComponent();
        }

        private void ButtonActivateAccount_Click(object sender, EventArgs e)
        {
            // Activates the email on a new thread.
            Thread activateEmailThread = new Thread(ActivateEmail);
            activateEmailThread.Start(TextBoxActivationCode.Text);
        }

        private void ButtonSendActivationCode_Click(object sender, EventArgs e)
        {
            // Asks if they want to resend their activation link.
            if (MessageBox.Show("Would you like to resend your activation link?", "Activate Email",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                // TODO: This / Limit to one email a day.
                ButtonSendActivationCode.Enabled = false;
                Variables.Containers.Active.SetStatus("Code has been emailed.", 4);
            }
        }

        /// <summary>
        ///     Activates the current users email using the specified activation code.
        /// </summary>
        /// <param name="activationCode">The activation code that is emailed to the user.</param>
        private void ActivateEmail(object activationCode)
        {
            // Disables the form controls.
            SetControls(false);

            // If the supplied activation code isn't the correct length, enable the controls and prompt the user.
            if (activationCode.ToString().Length != 8)
            {
                Variables.Containers.Active.SetStatus("Invalid activation code.", 1);
                SetControls(true);
                return;
            }

            // Creates a NameValueCollection and adds the activation code.
            NameValueCollection dataValues = new NameValueCollection {{"c", activationCode.ToString()}};

            // Attempts to activate the email and processes the response if successful.
            if (Network.SubmitData("activate", dataValues))
                ProcessResponse();
        }

        private void ProcessResponse()
        {
            // Gets the web response that has been returned from the server.
            string webResponse = Variables.WebResponse;

            // Parses the web response.
            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                // Displays the success message.
                Variables.Containers.Active.SetStatus(webResponse.Replace("[SUCCESS]", String.Empty), 4);

                // Reloads the data shown on 'My Account'.
                Thread displayUserData =
                    new Thread(Variables.UserControls.MyAccountDefault.DownloadAndDisplayCurrentUser);
                displayUserData.Start();
            }
            else
            {
                // Failed to upload avatar, display error.
                Variables.Containers.Active.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);

                // Enables the form controls.
                SetControls(true);
            }
        }

        /// <summary>
        ///     Enables/disables the form controls depending on the specified value.
        /// </summary>
        /// <param name="isEnabled">Decides the controls should be enabled or disabled.</param>
        private void SetControls(bool isEnabled)
        {
            if (InvokeRequired)
            {
                Invoke(new SetControlsDelegate(SetControls), isEnabled);
            }
            else
            {
                GroupBoxActivationCode.Enabled = isEnabled;
                ButtonActivateAccount.Enabled = isEnabled;
                ButtonSendActivationCode.Enabled = isEnabled;

                if (isEnabled)
                    TextBoxActivationCode.Clear();
            }
        }

        private void TextBoxActivationCode_TextChanged(object sender, EventArgs e)
        {
            ButtonActivateAccount.Enabled = (TextBoxActivationCode.TextLength != 0);
        }
    }
}