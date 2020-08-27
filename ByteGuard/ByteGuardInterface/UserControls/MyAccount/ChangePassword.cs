using System;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Tasks;

namespace ByteGuard.ByteGuardInterface.UserControls.MyAccount
{
    public partial class ChangePassword : UserControl
    {
        private delegate void SetControlsDelegate(bool isEnabled);

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ButtonChangePassword_Click(object sender, EventArgs e)
        {
            if (TextBoxCurrentPassword.TextLength == 0)
            {
                Variables.Containers.Main.SetStatus("You must enter your current password.", 1);
                return;
            }

            if (TextBoxNewPassword.TextLength == 0)
            {
                Variables.Containers.Main.SetStatus("You must enter a new password.", 1);
                return;
            }

            if (TextBoxConfirmPassword.TextLength == 0)
            {
                Variables.Containers.Main.SetStatus("You must confirm your new password.", 1);
                return;
            }

            if (TextBoxNewPassword.Text != TextBoxConfirmPassword.Text)
            {
                Variables.Containers.Main.SetStatus("Your passwords do not match.", 1);
                return;
            }

            if (TextBoxCurrentPassword.Text == TextBoxNewPassword.Text)
            {
                Variables.Containers.Main.SetStatus("Current and new passwords cannot match.", 1);
                return;
            }

            Thread changePasswordThread = new Thread(ChangePasswordThreaded);
            changePasswordThread.Start();
        }

        private void ChangePasswordThreaded()
        {
            SetControls(false);

            NameValueCollection dataValues = new NameValueCollection
            {
                {"c", Methods.GetMd5(TextBoxCurrentPassword.Text, false)},
                {"n", Methods.GetMd5(TextBoxNewPassword.Text, false)}
            };

            if (Network.SubmitData("changepass", dataValues))
                ProcessResponse();
            else
                SetControls(true);
        }

        private void ProcessResponse()
        {
            string webResponse = Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                Variables.Containers.Main.SetStatus(webResponse.Replace("[SUCCESS] ", String.Empty), 4);
            }
            else
            {
                // Failed to create account, display error.
                Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);

                // Enables the CreateAccountForm controls after a failed login.
                SetControls(true);
            }
        }

        private void SetControls(bool isEnabled)
        {
            if (InvokeRequired)
            {
                Invoke(new SetControlsDelegate(SetControls), isEnabled);
            }
            else
            {
                TextBoxCurrentPassword.Enabled = isEnabled;
                TextBoxNewPassword.Enabled = isEnabled;
                TextBoxConfirmPassword.Enabled = isEnabled;
                ButtonChangePassword.Enabled = isEnabled;
            }
        }

        private void TextBoxCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            ButtonChangePassword.Enabled = (TextBoxCurrentPassword.Text != "" && TextBoxNewPassword.Text != "" &&
                                            TextBoxConfirmPassword.Text != "");
        }

        private void TextBoxNewPassword_TextChanged(object sender, EventArgs e)
        {
            ButtonChangePassword.Enabled = (TextBoxCurrentPassword.Text != "" && TextBoxNewPassword.Text != "" &&
                                            TextBoxConfirmPassword.Text != "");
        }

        private void TextBoxConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            ButtonChangePassword.Enabled = (TextBoxCurrentPassword.Text != "" && TextBoxNewPassword.Text != "" &&
                                            TextBoxConfirmPassword.Text != "");
        }
    }
}