using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ByteGuard.ByteGuardInterface.Forms;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Properties;
using ByteGuard.Tasks;

namespace ByteGuard.ByteGuardInterface.UserControls.MyLibrary
{
    public partial class MyLibraryDefault : UserControl
    {
        public MyLibraryDefault()
        {
            InitializeComponent();

            Variables.UserControls.MyLibraryDefault = this;
        }

        private void MyLibraryDefault_Load(object sender, EventArgs e)
        {
            Thread downloadProgramsThread = new Thread(DownloadPrograms);
            downloadProgramsThread.Start();
        }

        private void DownloadPrograms()
        {
            // TODO: Display offline cache.
            DisplayPrograms();

            Variables.Containers.Main.SetStatus("Updating library list...", 3);

            if (Network.SubmitData("getlibrary"))
                ParseLibrary();

            Variables.Forms.Main.PopulateLibrary();

            Variables.Containers.Main.SetStatus("View programs you have previously purchased or redeem a new license.",
                3);
        }

        // TODO: Change hard-typed paths to global variables.
        private void ParseLibrary()
        {
            // Gets the webResponse from GlobalVariables.StorageBytes and splits it.
            string webResponse = Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                // Got the list of programs successfully, parse the response.
                Variables.MyLibrary.Clear();

                // Saves the downloaded xml file to the programs.xml file.
                File.WriteAllText(@"MyLibrary/programs.xml", webResponse.Replace("[SUCCESS]", ""));

                // Loads the XML file ready to be parsed.
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(@"MyLibrary/programs.xml");

                // Iterates through each program node.
                foreach (
                    XmlNode xmlProgramNode in xmlDocument.Cast<XmlNode>().SelectMany(xmlNode => xmlNode.Cast<XmlNode>())
                    )
                {
                    Variables.MyLibrary.Add(ParseProgramNode(xmlProgramNode));
                }
            }
        }

        // TODO: Encrypt/Decrypt with logged in users password.
        /// <summary>
        ///     Displays pre-downloaded programs stored in the 'MyLibrary/programs.xml' file.
        /// </summary>
        private void DisplayPrograms()
        {
            // Checks if the programs.xml file exists.
            if (File.Exists(@"MyLibrary/programs.xml"))
            {
                // Clears all stored ByteGuardProgram's if it exists.
                Variables.MyLibrary.Clear();

                // Loads the XML file ready to be parsed.
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(@"MyLibrary/programs.xml");

                // Iterates through each program node.
                foreach (XmlNode xmlNode in xmlDocument)
                {
                    if (xmlNode.NextSibling != null && xmlNode.NextSibling.Name != Variables.Users.Current.Username)
                        return;

                    foreach (XmlNode xmlProgramNode in xmlNode)
                        Variables.MyLibrary.Add(ParseProgramNode(xmlProgramNode));
                }
                // Populates the 'MyLibrary' listbox with our parsed programs.
                Variables.Forms.Main.PopulateLibrary();
            }
        }

        private Variables.ByteGuardProgram ParseProgramNode(XmlNode programNode)
        {
            // Initializes a ByteGuardProgram variable for us to work with.
            Variables.ByteGuardProgram byteguardProgram = new Variables.ByteGuardProgram();

            foreach (XmlNode xmlInformationNode in programNode)
            {
                switch (xmlInformationNode.Name)
                {
                    case "id":
                        byteguardProgram.Programid = xmlInformationNode.InnerText;
                        break;

                    case "lid":
                        byteguardProgram.Licenseid = Convert.ToInt32(xmlInformationNode.InnerText);
                        break;

                    case "name":
                        byteguardProgram.ProgramName = xmlInformationNode.InnerText;
                        break;

                    case "creator":
                        byteguardProgram.CreatorUsername = xmlInformationNode.InnerText;
                        break;

                    case "version":
                        byteguardProgram.ProgramVersion = float.Parse(xmlInformationNode.InnerText);
                        break;

                    case "description":
                        byteguardProgram.ProgramDescription = xmlInformationNode.InnerText;
                        break;

                    case "hasimage":
                        byteguardProgram.ProgramHasImage = Convert.ToInt32(xmlInformationNode.InnerText) == 1;
                        break;

                    case "expiration":
                        byteguardProgram.ExpirationTime = Convert.ToInt32(xmlInformationNode.InnerText);
                        break;

                    case "banned":
                        byteguardProgram.IsBanned = Convert.ToInt32(xmlInformationNode.InnerText) == 1;
                        break;
                }
            }

            return byteguardProgram;
        }

        /// <summary>
        ///     When a program is selected in 'listboxMyPrograms' it loads the selected program information.
        /// </summary>
        /// <param name="selectedIndex">The GlobalVariables.MyPrograms index.</param>
        public void SelectProgram(int selectedIndex)
        {
            // Loads the ByteGuardPrograms using the specified GlobalVariables.MyPrograms index.
            Variables.ByteGuardProgram byteguardProgram = Variables.MyLibrary[selectedIndex];

            // Displays the selected program on the MyProgramsDefault user control.
            DisplayProgram(byteguardProgram);
        }

        private delegate void DisplayProgramDelegate(Variables.ByteGuardProgram byteguardProgram);

        /// <summary>
        ///     Displays the selected program on the MyProgramsDefault user control.
        /// </summary>
        /// <param name="byteguardProgram">The selected program to display.</param>
        private void DisplayProgram(Variables.ByteGuardProgram byteguardProgram)
        {
            if (InvokeRequired)
            {
                Invoke(new DisplayProgramDelegate(DisplayProgram), byteguardProgram);
            }
            else
            {
                ButtonLaunchApplication.Enabled = false;

                // Sets the program name label.
                LabelProgramName.Text = byteguardProgram.ProgramName;

                // Sets the program description textbox.
                TextBoxProgramDescription.Text = byteguardProgram.ProgramDescription;

                // Sets the program version label.
                TextBoxVersion.Text = String.Format("Version: {0:0.0}", (decimal)byteguardProgram.ProgramVersion);

                // Sets the creator textbox.
                TextBoxCreator.Text = byteguardProgram.CreatorUsername;

                TextBoxExpiration.Text = (byteguardProgram.ExpirationTime == -1
                    ? "Never"
                    : Methods.TimeStampToDate(byteguardProgram.ExpirationTime));

                TextBoxLicenseStatus.Text = (byteguardProgram.IsBanned ? "Locked" : "Unlocked");

                TextBoxLicenseStatus.ForeColor = (byteguardProgram.IsBanned ? Color.DarkRed : Color.DarkGreen);

                ButtonViewLockDetails.Enabled = byteguardProgram.IsBanned;

                ButtonLaunchApplication.Enabled = !byteguardProgram.IsBanned;

                Thread threadSetLaunchButton = new Thread(SetLaunchButton);
                threadSetLaunchButton.Start();

                // Check if the selected program has a custom image.
                if (byteguardProgram.ProgramHasImage)
                {
                    ShowProgramImage(byteguardProgram.Programid);
                }
                else
                {
                    // If the selected program does not have a custom image, then show the DefaultProgram image.
                    PictureBoxProgramImage.Image = Resources.DefaultProgramImage;
                }
            }
        }

        private void ShowProgramImage(string programid)
        {
            // Gets the path where the program image should be stored/downloaded to. (%APPDATA%/ByteGuard/MyPrograms/{Programid}.png).
            string imagePath = String.Format(@"MyLibrary/{0}/main.png", programid);

            // Check if the program image already exists, if so display it, if not download it.
            if (!File.Exists(imagePath))
            {
                // Custom file image has not already been downloaded, download it!
                string[] imageObject = { programid, imagePath };

                // Downloads the selected programs custom image on a new thread.
                Thread downloadImageThread = new Thread(DownloadImageThreaded);
                downloadImageThread.Start(imageObject);
            }
            else
            {
                // File image has been previously downloaded, display it.
                PictureBoxProgramImage.ImageLocation = imagePath;
            }
        }

        private void DownloadImageThreaded(object imageObject)
        {
            string[] imageObjects = (string[]) imageObject;
            DownloadImage(imageObjects[0], imageObjects[1]);
        }

        /// <summary>
        ///     Downloads the selected programs custom image.
        /// </summary>
        /// <param name="programid">The selected programs Programid</param>
        /// <param name="imagePath"></param>
        private void DownloadImage(string programid, string imagePath)
        {
            // TODO: Move the message to status strip.
            // Checks if the %APPDATA%/ByteGuard/MyPrograms directory exists.
            if (Directory.Exists(Path.Combine("MyLibrary", programid)))
            {
                PictureBoxProgramImage.Image = Resources.DefaultProgramImage;

                if (File.Exists(imagePath))
                    File.Delete(imagePath);

                // The directory exists, download the custom file image.
                Variables.Containers.Main.SetStatus("Downloading program image...", 3);

                // Download the specified program image to the ByteGuard/MyPrograms folder.
                Network.DownloadProgramImage(programid, imagePath);

                // If the image downloaded successfully, display it in the file picturebox.
                if (File.Exists(imagePath))
                {
                    PictureBoxProgramImage.ImageLocation = imagePath;
                    Variables.Containers.Main.SetStatus(
                        "View programs you have previously purchased or redeem a new license.", 3);
                }
                else
                    Variables.Containers.Main.SetStatus("There was an error downloading the program image.", 1);
            }
            else
            {
                // The directory doesn't exist, create the directory and re-download the custom file image.
                Directory.CreateDirectory(Path.Combine("MyLibrary", programid));
                DownloadImage(programid, imagePath);
            }
        }

        private void ButtonViewLockDetails_Click(object sender, EventArgs e)
        {
            ButtonViewLockDetails.Enabled = false;

            Variables.ByteGuardProgram byteguardProgram =
                Variables.MyLibrary[Variables.Forms.Main.MyLibrarySelectedIndex];

            BlankForm f = new BlankForm(new LockDetails(byteguardProgram), true);
            f.FormClosing += (closedSender, closedE) => ButtonViewLockDetails.Enabled = true;
            f.Show();
        }

        private void LinkLabelViewCreator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabelViewCreator.Enabled = false;

            BlankForm viewProfileForm = new BlankForm(new ViewProfile(TextBoxCreator.Text), true)
            {
                Text = "ByteGuard - User profile"
            };
            viewProfileForm.FormClosing += (closedSender, closedE) => LinkLabelViewCreator.Enabled = true;
            viewProfileForm.Show();
        }

        private void ButtonLaunchApplication_Click(object sender, EventArgs e)
        {
            ButtonLaunchApplication.Enabled = false;

            string filePath = String.Format(@"MyLibrary/{0}/Raw/ByteGuard_Protected.exe", Variables.MyLibrarySelected.Programid);

            if (File.Exists(filePath))
            {
                Task.Factory.StartNew(() => LaunchApplication(Path.GetFullPath(filePath)));
            }
            else
                InstallApplication();
        }

        private void LaunchApplication(string launchLocation)
        {
            if (Process.GetProcessesByName("ByteGuard_Protected").Length != 0)
            {
                Variables.Containers.Main.SetStatus("You can only run one program at a time.", 1);

                Invoke((MethodInvoker)delegate
                {
                    ButtonLaunchApplication.Enabled = true;
                });

                return;
            }

            Process.Start(launchLocation);

            Invoke((MethodInvoker) delegate
            {
                Variables.Forms.Main.WindowState = FormWindowState.Minimized;
            });

            lock (Network.LockObject)
            {
                while (Network.IsReset == false)
                {
                    Thread.Sleep(250);
                }
            }

            Network.IsReset = false;
        }

        private void InstallApplication()
        {
            BlankForm f = new BlankForm(new ProgramDownloader(Variables.MyLibrarySelected), true)
            {
                Text = "ByteGuard Downloader (BETA - Progress Broken)"
            };
            f.Show();
        }

        private void TextBoxVersion_MouseUp(object sender, MouseEventArgs e)
        {
            DeselectTextbox(TextBoxVersion);
        }

        private void TextBoxCreator_MouseUp(object sender, MouseEventArgs e)
        {
            DeselectTextbox(TextBoxCreator);
        }

        private void TextBoxExpiration_MouseUp(object sender, MouseEventArgs e)
        {
            DeselectTextbox(TextBoxExpiration);
        }

        private void TextBoxLicenseStatus_MouseUp(object sender, MouseEventArgs e)
        {
            DeselectTextbox(TextBoxLicenseStatus);
        }

        private void DeselectTextbox(TextBox textboxToDeselect)
        {
            textboxToDeselect.DeselectAll();
            ActiveControl = null;
        }

        private void SetLaunchButton()
        {
            string filePath = String.Format(@"MyLibrary/{0}/Raw/ByteGuard_Protected.exe", Variables.MyLibrarySelected.Programid);

            if (!File.Exists(filePath))
            {
                Invoke((MethodInvoker) delegate
                {
                    ButtonLaunchApplication.Text = "Install Application";
                });
            }
            else
            {
                Invoke((MethodInvoker)delegate
                {
                    ButtonLaunchApplication.Text = (AreUpdatesAvailable(Variables.MyLibrarySelected.Programid)
                        ? "Update Application"
                        : "Launch Application");
                });
            }

            Invoke((MethodInvoker)delegate
            {
                ButtonLaunchApplication.Enabled = true;
            });
        }

        private bool AreUpdatesAvailable(string programid)
        {
            string filePath = String.Format(@"MyLibrary/{0}/Compressed.zip", programid);

            filePath = Path.GetFullPath(filePath);

            if (!File.Exists(filePath))
                return true;

            NameValueCollection dataValues = new NameValueCollection()
                {
                    { "pid", programid },
                    { "csm", Methods.GetMd5(File.ReadAllBytes(filePath)) }
                };

            if (Network.SubmitData("checkupdates", dataValues))
            {
                // Gets the webResponse from GlobalVariables.StorageBytes and splits it.
                string webResponse = Variables.WebResponse;

                if (webResponse.Split('[', ']')[1] == "1")
                    return false;
            }

            return true;
        }

    }
}