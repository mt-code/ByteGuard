using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Tasks;

namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    public partial class UploadProgram : UserControl
    {
        private readonly Control _manageProgramsControl;

        private delegate void DisplayInformationDelegate(XmlDocument xmlDocument);

        public UploadProgram(Control control)
        {
            InitializeComponent();

            _manageProgramsControl = control;
        }

        private void UploadProgram_Load(object sender, EventArgs e)
        {
            // Check the if the current program is marketplace registered/accepted.
            if (Variables.MyProgramsSelected.MarketplaceFeePaid && Variables.MyProgramsSelected.DistributionModel == 1)
            {
                // Registered/accepted.

                // File location of the compressed project.
                string uploadFileLocation = String.Format("MyPrograms/{0}/Protected/Marketplace/Compressed.zip",
                    Variables.MyProgramsSelected.Programid);

                // Converts the relative path to the actual path.
                uploadFileLocation = Path.GetFullPath(uploadFileLocation);

                // Displays the most recently uploaded file (if exists).
                Thread threadDisplayMostRecent = new Thread(DisplayRecentlyUploaded);
                threadDisplayMostRecent.Start();

                // If the file to upload exists, displays the relevant file information.
                if (File.Exists(uploadFileLocation))
                {
                    Thread threadShowInformation = new Thread(ShowFileInformation);
                    threadShowInformation.Start(uploadFileLocation);
                }
                else
                {
                    btnUpload.Text = "Update Program";
                }
            }
            else
            {
                // Not registered/accepted.
                lblMarketplaceOnly.Visible = true;
                btnUpload.Enabled = false;
                gboUploadNewProgram.Enabled = false;
                gboRecentUpload.Enabled = false;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (btnUpload.Text == "Upload To Server")
            {
                // Uploads the program.
                Thread threadUploadProgram = new Thread(UploadProgramToServer);
                threadUploadProgram.Start(txtLocation.Text);
            }
            else
            {
                // Shows the 'UPDATE' tab.
                TabControl tabControlManageProgram = (TabControl)Parent.Parent;
                tabControlManageProgram.SelectedIndex = 3;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _manageProgramsControl.Parent.Controls.Add(Variables.UserControls.MyProgramsDefault);
            _manageProgramsControl.Parent.Controls.Remove(_manageProgramsControl);
            _manageProgramsControl.Dispose();
        }

        #region Upload methods.

        private void UploadProgramToServer(object fileLocation)
        {
            // If the program image has been edited, checks the file size is less than 50KB.
            FileInfo imageFileInformation = new FileInfo(fileLocation.ToString());

            // Checks the avatar image size is less than 150KB.
            if (imageFileInformation.Length > (20 * 1000 * 1024))
            {
                Variables.Containers.Main.SetStatus("Your compressed program must be less than 20MB, please contact support for additional options.", 1);
                return;
            }

            // Hides the upload button and shows the upload progress bar.
            Invoke((MethodInvoker) delegate
            {
                btnUpload.Visible = false;
                progUploadProgress.Visible = true;
            });

            // Upload the image using the 'avatar' keyword.
            Network.UploadFileAsync(fileLocation.ToString(), "program", UploadProgress, UploadCompleted, Variables.MyProgramsSelected.Programid);
        }

        private void UploadProgress(object sender, System.Net.UploadProgressChangedEventArgs e)
        {
            try
            {
                Invoke((MethodInvoker) delegate { progUploadProgress.Value = e.ProgressPercentage; });
            }
            catch
            {
                // TODO: Sort out upload progress.
            }
        }

        private void UploadCompleted(object sender, System.Net.UploadFileCompletedEventArgs e)
        {
            // Gets the web response that has been returned from the server.
            string webResponse = Encoding.ASCII.GetString(e.Result);

            // Parses the web response.
            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                // Displays the most recently uploaded file.
                Thread threadDisplayMostRecent = new Thread(DisplayRecentlyUploaded);
                threadDisplayMostRecent.Start();

                // Displays the success message.
                Variables.Containers.Main.SetStatus(webResponse.Replace("[SUCCESS]", String.Empty), 4);
            }
            else
            {
                // Failed to upload avatar, display error.
                Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);
            }

            Invoke((MethodInvoker)delegate
            {
                progUploadProgress.Value = 0;
                progUploadProgress.Visible = false;
                btnUpload.Visible = true;
            });
        }

        #endregion

        private void DisplayRecentlyUploaded()
        {
            NameValueCollection dataValues = new NameValueCollection { { "pid", Variables.MyProgramsSelected.Programid } };

            if (Network.SubmitData("getlastupload", dataValues))
                ProcessResponse();
        }

        private void ProcessResponse()
        {
            // Gets the webResponse from GlobalVariables.StorageBytes and splits it.
            string webResponse = Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(webResponse.Replace("[SUCCESS]", ""));

                DisplayInformation(xmlDocument);
            }
            else
            {
                string errorMessage = webResponse.Replace("[ERROR]", "");

                if (errorMessage != "null")
                    Variables.Containers.Main.SetStatus(errorMessage, 1);
            }
        }

        private void DisplayInformation(XmlDocument xmlDocument)
        {
            if (InvokeRequired)
            {
                Invoke(new DisplayInformationDelegate(DisplayInformation), xmlDocument);
            }
            else
            {
                foreach (XmlNode xmlNode in xmlDocument)
                {
                    foreach (XmlNode xmlInformationNode in xmlNode)
                    {
                        switch (xmlInformationNode.Name)
                        {
                            case "time":
                                txtLastUpdated.Text = Methods.TimeStampToDate(Convert.ToDouble(xmlInformationNode.InnerText));
                                break;

                            case "size":
                                txtRecentFileSize.Text = String.Format("{0}KB",
                                    Convert.ToInt32(xmlInformationNode.InnerText) / 1000);
                                break;

                            case "checksum":
                                txtRecentChecksum.Text = xmlInformationNode.InnerText;
                                break;
                        }
                    }
                }
            }
        }

        private void ShowFileInformation(object fileLocation)
        {
            FileInfo fileInfo = new FileInfo(fileLocation.ToString());

            Invoke((MethodInvoker) delegate
            {
                txtLocation.Text = fileLocation.ToString();
                txtNewChecksum.Text = Methods.GetMd5(File.ReadAllBytes(fileLocation.ToString()));
                txtNewFilesize.Text = String.Format("{0}KB", fileInfo.Length / 1000);
                txtCreationTime.Text = fileInfo.CreationTime.ToString("dd/MM/yyyy HH:mm");
            });
        }
    }
}
