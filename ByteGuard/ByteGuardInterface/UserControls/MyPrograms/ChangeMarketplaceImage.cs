using System;
using System.IO;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Tasks;

namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    public partial class ChangeMarketplaceImage : UserControl
    {
        private readonly PictureBox _defaultMarketplaceImage;

        public ChangeMarketplaceImage(PictureBox pictureBox)
        {
            InitializeComponent();

            _defaultMarketplaceImage = pictureBox;
        }

        private void ChangeMarketplaceImage_Load(object sender, EventArgs e)
        {
            string imageLocation = String.Format("MyPrograms/{0}/marketplace.png",
                Variables.MyProgramsSelected.Programid);

            if (File.Exists(imageLocation))
                picMarketplaceImage.ImageLocation = imageLocation;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg"
            };

            // Displays the image they choose.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picMarketplaceImage.ImageLocation = openFileDialog.FileName;
                txtImageLocation.Text = openFileDialog.FileName;
                btnUpload.Enabled = true;
            }
        }

        // TODO: Multi-thread this.
        private void btnUpload_Click(object sender, EventArgs e)
        {
            // If the program image has been edited, checks the file size is less than 50KB.
            FileInfo imageFileInformation = new FileInfo(picMarketplaceImage.ImageLocation);

            // Checks the avatar image size is less than 150KB.
            if (imageFileInformation.Length > 150000)
            {
                Variables.Containers.Main.SetStatus("Program image must be below 150KB in size.", 1);
                return;
            }

            // Locks all the form controls to prevent spamming.
            SetControls(false);

            // Informs the user the image is being uploaded.
            Variables.Containers.Main.SetStatus("Uploading marketplace image...", 3);

            // Upload the image using the 'avatar' keyword.
            Network.UploadFile(picMarketplaceImage.ImageLocation, "marketplace", Variables.MyProgramsSelected.Programid);

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
                
                string marketplaceImageLocation = String.Format("MyPrograms/{0}/marketplace.png", Variables.MyProgramsSelected.Programid);

                // Copies the chosen avatar to the %APPDATA%/ByteGuard/avatar.png location.
                File.Copy(txtImageLocation.Text, marketplaceImageLocation, true);

                _defaultMarketplaceImage.ImageLocation = marketplaceImageLocation;

                btnUpload.Enabled = false;

                // Enables the form controls.
                SetControls(true);
            }
            else
            {
                // Failed to upload avatar, display error.
                Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);
            }
        }

        /// <summary>
        ///     Enables/disables the form controls.
        /// </summary>
        /// <param name="isEnabled"></param>
        private void SetControls(bool isEnabled)
        {
            Invoke((MethodInvoker)delegate { gboxControls.Enabled = isEnabled; });
        }
    }
}
