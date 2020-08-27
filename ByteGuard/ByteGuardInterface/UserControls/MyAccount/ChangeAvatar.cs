using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Properties;
using ByteGuard.Tasks;

namespace ByteGuard.ByteGuardInterface.UserControls.MyAccount
{
    public partial class ChangeAvatar : UserControl
    {
        // Class variables.
        private readonly string _avatarLocation = Path.Combine(Variables.Paths.ByteGuardAppData, Variables.Users.Current.Username, "avatar.png");

        public ChangeAvatar()
        {
            InitializeComponent();
        }

        private void ChangeAvatar_Load(object sender, EventArgs e)
        {
            // Sets the ThemeContainer status bar.
            //Variables.Containers.Main.SetStatus("Upload a new avatar or reset your old one.", 3);

            // Displays the current avatar is there is one.
            if (File.Exists(_avatarLocation))
            {
                PictureBoxAvatar.ImageLocation = _avatarLocation;
                ButtonResetAvatar.Enabled = true;
            }
            else
            {
                PictureBoxAvatar.Image = Resources.ByteGuardDefaultProfileImage;
            }
        }

        private void ButtonBrowseAvatar_Click(object sender, EventArgs e)
        {
            // Allows the user to browse for their avatar image.
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg"
            };

            // Displays the image they choose.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PictureBoxAvatar.ImageLocation = openFileDialog.FileName;
                TextBoxImageLocation.Text = openFileDialog.FileName;
                ButtonSaveAvatar.Enabled = true;
            }
        }

        private void ButtonResetAvatar_Click(object sender, EventArgs e)
        {
            // Double checks the user wants to reset their avatar, if so resets the avatar on a new thread.
            if (
                MessageBox.Show("Are you sure you want to reset your avatar?", "ByteGuard Avatar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Thread resetAvatarThread = new Thread(ResetAvatar);
                resetAvatarThread.Start();
            }
        }

        private void ButtonSaveAvatar_Click(object sender, EventArgs e)
        {
            // Uploads chosen avatar to the server.
            Thread uploadAvatarThread = new Thread(UploadAvatar);
            uploadAvatarThread.Start();
        }

        private void UploadAvatar()
        {
            // If the program image has been edited, checks the file size is less than 50KB.
            FileInfo imageFileInformation = new FileInfo(PictureBoxAvatar.ImageLocation);

            // Checks the avatar image size is less than 50KB.
            if (imageFileInformation.Length > 50000)
            {
                Variables.Containers.Main.SetStatus("Program image must be below 50KB in size.", 1);
                return;
            }

            // Locks all the form controls to prevent spamming.
            SetControls(false);

            // Informs the user the image is being uploaded.
            Variables.Containers.Main.SetStatus("Uploading avatar image...", 3);

            // Upload the image using the 'avatar' keyword.
            Network.UploadFile(PictureBoxAvatar.ImageLocation, "avatar");

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
                Variables.Containers.Main.SetStatus(webResponse.Replace("[SUCCESS]", String.Empty), 4);

                // Copies the chosen avatar to the %APPDATA%/ByteGuard/avatar.png location.
                File.Copy(TextBoxImageLocation.Text, _avatarLocation, true);

                // Enables the form controls.
                SetControls(true);

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

        private void ResetAvatar()
        {
            // Disables the form controls.
            SetControls(false);

            if (Network.SubmitData("resetavatar"))
            {
                // Gets the web response that has been returned from the server.
                string webResponse = Variables.WebResponse;

                // Parses the web response.
                if (webResponse.Split('[', ']')[1] == "SUCCESS")
                {
                    // Displays the success message.
                    Variables.Containers.Main.SetStatus(webResponse.Replace("[SUCCESS]", String.Empty), 4);

                    // Deletes the old avatar image.
                    if (File.Exists(_avatarLocation))
                        File.Delete(_avatarLocation);

                    // Resets the avatar picture box.
                    PictureBoxAvatar.Image = Resources.ByteGuardDefaultProfileImage;

                    // Enables the form controls.
                    SetControls(true);

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

        /// <summary>
        ///     Enables/disables the form controls.
        /// </summary>
        /// <param name="isEnabled"></param>
        private void SetControls(bool isEnabled)
        {
            Invoke((MethodInvoker) delegate { GroupBoxAvatar.Enabled = isEnabled; });
        }
    }
}