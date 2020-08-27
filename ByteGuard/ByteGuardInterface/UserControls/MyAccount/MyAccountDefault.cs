using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Forms;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.ByteGuardInterface.UserControls.Other;
using ByteGuard.Properties;
using ByteGuard.Tasks;

namespace ByteGuard.ByteGuardInterface.UserControls.MyAccount
{
    public partial class MyAccountDefault : UserControl
    {
        private delegate void DisplayUserDataDelegate();

        public MyAccountDefault()
        {
            InitializeComponent();

            Variables.UserControls.MyAccountDefault = this;
        }

        private void MyAccount_Load(object sender, EventArgs e)
        {
            Variables.Containers.Main.SetStatus("View and manage your user profile.", 3);

            Thread displayUserDataThread = new Thread(DisplayUserData);
            displayUserDataThread.Start();
        }

        private void ButtonViewReputation_Click(object sender, EventArgs e)
        {
        }

        private void ButtonViewMessages_Click(object sender, EventArgs e)
        {
        }

        private void ButtonBuyLicenseSlots_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(
                () => Network.StartAutoLoginUrl("http://www.byteguardsoftware.co.uk/profile?area=slots"));
        }
        // TODO: Tidy this region.

        #region Download/Display Methods.

        public void DownloadAndDisplayCurrentUser()
        {
            Variables.Users.Current = Methods.DownloadUserData(Variables.Users.Current.Username);

            Variables.UserControls.MyAccountDefault.DisplayUserData();
        }

        public void DisplayUserData()
        {
            // Method variables.
            if (Variables.Users.Current.Username == null)
                Environment.Exit(0);

            string avatarLocation = Path.Combine(Variables.Paths.ByteGuardAppData, Variables.Users.Current.Username,
                "avatar.png");

            Variables.ByteGuardUser byteguardUser = Variables.Users.Current;

            if (byteguardUser.HasAvatar && !File.Exists(avatarLocation) && !InvokeRequired)
            {
                Thread downloadAvatarThreaded = new Thread(DownloadAvatar);
                downloadAvatarThreaded.Start(avatarLocation);
            }

            if (InvokeRequired)
            {
                Invoke(new DisplayUserDataDelegate(DisplayUserData));
            }
            else
            {
                ButtonActivateAccount.Enabled = !byteguardUser.IsActivated;
                ButtonHideShowEmail.Text = String.Format("{0} Email",
                    (byteguardUser.Email == "Email Hidden" ? "Show" : "Hide"));

                LabelUsernamePreview.Text = byteguardUser.Username;
                LabelEmailAddressPreview.Text = byteguardUser.Email; // TODO: Substring.
                LabelLastOnline.Text = Methods.TimeStampToDate(byteguardUser.LastActive);
                LabelRegistrationDate.Text = Methods.TimeStampToDate(byteguardUser.TimeRegistered);
                LabelLicensesRemaining.Text = byteguardUser.LicensesRemaining.ToString();

                TextBoxUserDescription.Text = byteguardUser.Description;
                TextBoxUserDescriptionPreview.Text = byteguardUser.Description;

                if (File.Exists(avatarLocation))
                    PictureBoxProfileImage.ImageLocation = avatarLocation;
                else
                    PictureBoxProfileImage.Image = Resources.ByteGuardDefaultProfileImage;
            }
        }

        #endregion

        #region SaveDescription Methods.

        private void ButtonSaveDescription_Click(object sender, EventArgs e)
        {
            Thread saveDescriptionThread = new Thread(SaveDescription);
            saveDescriptionThread.Start(TextBoxUserDescription.Text);
        }

        private void TextBoxUserDescription_TextChanged(object sender, EventArgs e)
        {
            GroupBoxUserDescription.Text = String.Format("User Description/Bio ({0}/255):",
                TextBoxUserDescription.TextLength);

            ButtonSaveDescription.Enabled = (TextBoxUserDescription.TextLength != 0 &&
                                             TextBoxUserDescription.Text != Variables.Users.Current.Description);
        }

        private void SaveDescription(object description)
        {
            Invoke((MethodInvoker) delegate { GroupBoxUserDescription.Enabled = false; });

            NameValueCollection dataValues = new NameValueCollection {{"d", description.ToString()}};

            if (Network.SubmitData("changebio", dataValues))
            {
                // Gets the web response that has been returned from the server.
                string webResponse = Variables.WebResponse;

                // Parses the web response.
                if (webResponse.Split('[', ']')[1] == "SUCCESS")
                {
                    // Displays the success message.
                    Variables.Containers.Main.SetStatus(webResponse.Replace("[SUCCESS]", String.Empty), 4);

                    // Enables the 'Hide/Show' button.
                    Invoke((MethodInvoker) delegate
                    {
                        GroupBoxUserDescription.Enabled = true;
                        ButtonSaveDescription.Enabled = false;
                    });

                    // Reloads the data shown on 'My Account'.
                    Thread displayUserData =
                        new Thread(Variables.UserControls.MyAccountDefault.DownloadAndDisplayCurrentUser);
                    displayUserData.Start();
                }
                else
                {
                    // Failed to upload avatar, display error.
                    Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);

                    Invoke((MethodInvoker) delegate { GroupBoxUserDescription.Enabled = true; });
                }
            }
        }

        #endregion

        #region AlterEmail Methods.

        private void ButtonHideShowEmail_Click(object sender, EventArgs e)
        {
            // Determines if the email is already being hidden.
            bool emailHidden = (Variables.Users.Current.Email == "Email Hidden");

            // Asks the user if they want to make the change.
            if (
                MessageBox.Show(
                    String.Format("Are you sure you want to {0} your email?", (emailHidden ? "show" : "hide")),
                    "ByteGuard Email", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                // Changes the email preference on a new thread.
                Thread alterEmailThread = new Thread(AlterEmail);
                alterEmailThread.Start(emailHidden);
            }
        }

        /// <summary>
        ///     Hides/shows the current users email depending on the specified parameter.
        /// </summary>
        /// <param name="hideEmail">Determines whether the user is hiding/showing the email.</param>
        private void AlterEmail(object hideEmail)
        {
            // Disables the 'Hide/Show' button.
            Invoke((MethodInvoker) delegate { ButtonHideShowEmail.Enabled = false; });

            // Creates a NameValueCollection variable, and adds the email preference setting.
            NameValueCollection dataValues = new NameValueCollection {{"h", ((bool) hideEmail ? "0" : "1")}};

            if (Network.SubmitData("alteremail", dataValues))
            {
                // Gets the web response that has been returned from the server.
                string webResponse = Variables.WebResponse;

                // Parses the web response.
                if (webResponse.Split('[', ']')[1] == "SUCCESS")
                {
                    // Displays the success message.
                    Variables.Containers.Main.SetStatus(webResponse.Replace("[SUCCESS]", String.Empty), 4);

                    // Enables the 'Hide/Show' button.
                    Invoke((MethodInvoker) delegate { ButtonHideShowEmail.Enabled = true; });

                    // Reloads the data shown on 'My Account'.
                    Thread displayUserData =
                        new Thread(Variables.UserControls.MyAccountDefault.DownloadAndDisplayCurrentUser);
                    displayUserData.Start();
                }
                else
                {
                    // Failed to upload avatar, display error.
                    Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);
                }
            }
        }

        #endregion

        #region Miscellaneous Methods.

        private void ButtonChangeEmail_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Are you sure you want to change your email?", "Email Change", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
            {
                ButtonChangeEmail.Enabled = false;
                Variables.Containers.Main.SetStatus("An email reset link has been sent to your current email address.",
                    4);
                // TODO: This.
            }
        }

        private void ButtonChangePassword_Click(object sender, EventArgs e)
        {
            ButtonChangePassword.Enabled = false;

            BlankForm changePasswordForm = new BlankForm(new ChangePassword(), true) {Text = "ByteGuard - Change Password"};
            changePasswordForm.FormClosing += (closedSender, closedE) => ButtonChangePassword.Enabled = true;
            changePasswordForm.Show();
        }

        private void ButtonChangeAvatar_Click(object sender, EventArgs e)
        {
            ButtonChangeAvatar.Enabled = false;

            BlankForm changeAvatarForm = new BlankForm(new ChangeAvatar(), true) {Text = "ByteGuard - Change Avatar "};
            changeAvatarForm.FormClosing += (closedSender, closedE) => ButtonChangeAvatar.Enabled = true;
            changeAvatarForm.Show();
        }

        private void ButtonActivateAccount_Click(object sender, EventArgs e)
        {
            ButtonActivateAccount.Enabled = false;

            BlankForm f = new BlankForm(new ActivateAccount(), true);
            f.FormClosing +=
                (closedSender, closedE) => ButtonActivateAccount.Enabled = (!Variables.Users.Current.IsActivated);
            f.Show();
        }

        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            ButtonLogout.Enabled = false;

            if (Network.SubmitData("logout"))
            {
                Form parentForm = ParentForm;
                Form currentForm = FindForm();

                BlankForm f = new BlankForm(new Login(false), true);

                if (parentForm != null) f.FormClosed += (closedSender, closedE) => parentForm.Close();

                if (currentForm != null) currentForm.Hide();

                f.Show();
            }
        }

        private void DownloadAvatar(object imageLocation)
        {
            if (Methods.DownloadAvatar(Variables.Users.Current.Username, imageLocation.ToString()))
            {
                Invoke((MethodInvoker) delegate { PictureBoxProfileImage.ImageLocation = imageLocation.ToString(); });

                Variables.Containers.Main.SetStatus("View and manage your user profile.", 3);
            }
            else
            {
                Variables.Containers.Main.SetStatus("There was an error downloading your avatar.", 1);
            }
        }

        #endregion
    }
}