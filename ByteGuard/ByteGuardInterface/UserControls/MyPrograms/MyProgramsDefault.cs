using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Properties;
using ByteGuard.Tasks;

// TODO: Delete program folder on desktop when program is deleted.
// TODO: Move program image to image location, rather than downloading it from the server. (Saves bandwidth)

namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    public partial class MyProgramsDefault : UserControl
    {
        private bool _imageChanged;
        private int _secondCounter = 3;

        public MyProgramsDefault()
        {
            InitializeComponent();

            Version = 1.0m;
        }

        public decimal Version { get; set; }

        private void MyProgramsDefault_Load(object sender, EventArgs e)
        {
            // Gets the users programs (if any) and adds them to the listbox for editing/modificaiton.
            Thread threadLoadPrograms = new Thread(DownloadPrograms);
            threadLoadPrograms.Start(false);
        }

        private void ButtonCreateProgram_Click(object sender, EventArgs e)
        {
            // Changes from MyProgramsDefault controls to CreateProgram controls.
            Parent.Controls.Add(new CreateProgram());
            Parent.Controls.Remove(this);
        }

        private void ButtonEditProgram_Click(object sender, EventArgs e)
        {
            string programid = LabelProgramName.Text.Split('(', ')')[1];

            // Checks the text value of the btnEditSave button.
            if (ButtonEditProgram.Text == "Edit Program")
            {
                // Sets the $SESSION['Programid'] to the selected Programid.
                Thread tSelectProgram = new Thread(PrepareProgramThreaded);
                tSelectProgram.Start(programid);

                DeleteTimer.Start();

                // Enables all the controls to allow modification.
                SetControls(true);

                // Disables the 'Create Program' button.
                ButtonCreateProgram.Enabled = false;

                // Shows the current character count/limit of the program name/description textboxes.
                LabelProgramName.Text = String.Format("Program Name ({0}) - ({1}/25):", programid,
                    TextBoxProgramName.TextLength);
                LabelProgramDescription.Text = String.Format("Program Description ({0}/500):",
                    TextBoxProgramDescription.TextLength);

                // Changes the button text and disables it until the program is modified.
                ButtonEditProgram.Text = "Cancel Editing";
            }
            else if (ButtonEditProgram.Text == "Save Changes")
            {
                // Disables all the controls to prevent modification.
                SetControls(false);

                DeleteTimer.Stop();
                _secondCounter = 3;
                ButtonDeleteProgram.Enabled = false;
                ButtonDeleteProgram.Text = "Delete Program (3)";

                // Disables the btnEditSave button.
                ButtonEditProgram.Enabled = false;

                // Resets the program description label.
                LabelProgramDescription.Text = "Program Description:";

                string programDescription = TextBoxProgramDescription.Text.Replace(Environment.NewLine, "<br>");

                // ProgramDetails = { ProgramName, ProgramVersion, AutoUpdateBOOL, ProgramDescription, Programid }
                string[] programDetails =
                {
                    TextBoxProgramName.Text,
                    LabelVersion.Text.Replace("Version: ", String.Empty),
                    programDescription,
                    programid
                };

                // Updates the database with the new program details on a seperate thread.
                Thread updateProgramThread = new Thread(UpdateProgram);
                updateProgramThread.Start(programDetails);
            }
            else
            {
                // Disables all the controls to prevent modification.
                SetControls(false);

                // Resets the program name/description labels if the user cancels editing.
                LabelProgramName.Text = String.Format("Program Name ({0}):", programid);
                LabelProgramDescription.Text = "Program Description:";

                // Resets the text of the btnEditSave button.
                ButtonEditProgram.Text = "Edit Program";

                DeleteTimer.Stop();
                _secondCounter = 3;
                ButtonDeleteProgram.Enabled = false;
                ButtonDeleteProgram.Text = "Delete Program (3)";

                ButtonManageProgram.Enabled = true;
                ButtonCreateProgram.Enabled = true;
            }
        }

        // TODO: Delete program folder from MyPrograms.
        private void ButtonDeleteProgram_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Are you sure you want to permanantly delete this program?", "Program Deletion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Resets the MyProgramsDefault controls.
                CancelProgramEditing();

                // User clicked yes, delete program.
                Thread deleteProgramThread = new Thread(DeleteProgram);
                deleteProgramThread.Start(LabelProgramName.Text.Split('(', ')')[1]);
            }
        }

        private void ButtonManageProgram_Click(object sender, EventArgs e)
        {
            var selectedProgram = Variables.MyProgramsSelected;

            // If the user hasn't registered their application, 
            if (selectedProgram.DistributionModel == 0)
            {
                Parent.Controls.Add(new RegisterProgram());
                Parent.Controls.Remove(this);
            }
            else if (selectedProgram.DistributionModel == 1 || selectedProgram.DistributionModel == 2)
            {
                Parent.Controls.Add(new ManageProgramDefault());
                Parent.Controls.Remove(this);
            }

            Variables.Containers.Main.ForceRedraw();
        }

        private void DeleteTimer_Tick(object sender, EventArgs e)
        {
            ButtonDeleteProgram.Text = String.Format("Delete Program ({0})", --_secondCounter);

            if (_secondCounter == 0)
            {
                DeleteTimer.Stop();
                _secondCounter = 3;
                ButtonDeleteProgram.Enabled = true;
                ButtonDeleteProgram.Text = "Delete Program";
            }
        }

        private delegate void CancelEditingDelegate();

        private delegate void SetControlsDelegate(bool isEnabled);

        #region Download Programs Methods

        /// <summary>
        ///     Downloads the users programs (if any) and adds them to the listbox for editing/modification.
        /// </summary>
        public void DownloadPrograms(object isDeleted)
        {
            // TODO: Encrypt/decrypt programs.xml with the username.
            DisplayPrograms((bool) isDeleted);

            // TODO: Maybe enable?
            //Globals.Variables.Containers.Main.SetStatus("Updating programs list...", 3);

            // Gets the users programs (if any).
            if (Network.SubmitData("getprograms"))
                ParsePrograms();

            // Adds the users programs (if any) to the listbox on the MainForm.
            Variables.Forms.Main.PopulatePrograms((bool) isDeleted);

            // Checks if listboxMyPrograms is empty, if it is, resets all the MyProgramsDefault controls (Incase last program has just been deleted).
            if (Variables.Forms.Main.MyProgramsCount == 0)
            {
                Invoke((MethodInvoker) delegate
                {
                    LabelProgramName.Text = "Program Name:";
                    LabelProgramDescription.Text = "Program Description:";
                    LabelVersion.Text = "Version: 1.0";

                    TextBoxProgramName.Clear();
                    TextBoxProgramDescription.Clear();

                    PictureBoxProgramImage.Image = Resources.DefaultProgramImage;

                    ButtonCreateProgram.Enabled = true;
                    ButtonEditProgram.Enabled = false;
                    ButtonManageProgram.Enabled = false;
                });

                Variables.Containers.Main.SetStatus("Create and manage your programs.", 3);
            }
            else
            {
                Invoke((MethodInvoker) delegate
                {
                    ButtonEditProgram.Enabled = true;
                    ButtonManageProgram.Enabled = true;
                    ButtonCreateProgram.Enabled = true;
                });
            }

            // TODO: Fix this. (Stop CreatButton being disabled after deleting a program).
            Invoke((MethodInvoker) delegate
            {
                Variables.Containers.Main.SetStatus("Create and manage your programs.", 3);
            });
        }

        // TODO: Encrypt/Decrypt with logged in users password.
        /// <summary>
        ///     Displays pre-downloaded programs stored in the 'MyPrograms/programs.xml' file.
        /// </summary>
        private void DisplayPrograms(bool isDeleted)
        {
            // Checks if the programs.xml file exists.
            if (File.Exists(@"MyPrograms/programs.xml"))
            {
                // Clears all stored ByteGuardProgram's if it exists.
                Variables.MyPrograms.Clear();

                // Loads the XML file ready to be parsed.
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(@"MyPrograms/programs.xml");

                // Iterates through each program node.
                foreach (XmlNode xmlNode in xmlDocument)
                {
                    if (xmlNode.NextSibling != null && xmlNode.NextSibling.Name != Variables.Users.Current.Username)
                        return;

                    foreach (XmlNode xmlProgramNode in xmlNode)
                        Variables.MyPrograms.Add(ParseProgramNode(xmlProgramNode));
                }
                // Populates the 'MyPrograms' listbox with our parsed programs.
                Variables.Forms.Main.PopulatePrograms(isDeleted);
            }
        }

        /// <summary>
        ///     Checks if the user has any current programs, if so gets and stores them in GlobalVariables.MyPrograms.
        /// </summary>
        private void ParsePrograms()
        {
            // Gets the webResponse from GlobalVariables.StorageBytes and splits it.
            string webResponse = Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                // Got the list of programs successfully, parse the response.
                Variables.MyPrograms.Clear();

                // Saves the downloaded xml file to the programs.xml file.
                File.WriteAllText(@"MyPrograms/programs.xml", webResponse.Replace("[SUCCESS]", ""));

                // Loads the XML file ready to be parsed.
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(@"MyPrograms/programs.xml");

                // Iterates through each program node.
                foreach (
                    XmlNode xmlProgramNode in xmlDocument.Cast<XmlNode>().SelectMany(xmlNode => xmlNode.Cast<XmlNode>())
                    )
                {
                    Variables.MyPrograms.Add(ParseProgramNode(xmlProgramNode));
                }
            }
            else
            {
                Variables.Containers.Main.SetStatus("Failed to retrieve your programs.", 1);
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

                    case "name":
                        byteguardProgram.ProgramName = xmlInformationNode.InnerText;
                        break;

                    case "version":
                        byteguardProgram.ProgramVersion = float.Parse(xmlInformationNode.InnerText);
                        break;

                    case "description":
                        byteguardProgram.ProgramDescription = xmlInformationNode.InnerText;
                        break;

                    case "licenses":
                        byteguardProgram.ProgramLicenses = Convert.ToInt32(xmlInformationNode.InnerText);
                        break;

                    case "hasimage":
                        byteguardProgram.ProgramHasImage = Convert.ToInt32(xmlInformationNode.InnerText) == 1;
                        break;

                    case "creatorusername":
                        byteguardProgram.CreatorUsername = xmlInformationNode.InnerText;
                        break;

                    case "isadmin":
                        byteguardProgram.IsAdmin = Convert.ToInt32(xmlInformationNode.InnerText) == 1;
                        break;

                    case "distmodel":
                        byteguardProgram.DistributionModel = Convert.ToInt32(xmlInformationNode.InnerText);
                        break;

                    case "mpfeepaid":
                        byteguardProgram.MarketplaceFeePaid = Convert.ToInt32(xmlInformationNode.InnerText) == 1;
                        break;
                }
            }

            return byteguardProgram;
        }

        #endregion

        #region Display/Select Program Methods

        /// <summary>
        ///     When a program is selected in 'listboxMyPrograms' it loads the selected program information.
        /// </summary>
        /// <param name="selectedIndex">The GlobalVariables.MyPrograms index.</param>
        public void SelectProgram(int selectedIndex)
        {
            // Loads the ByteGuardPrograms using the specified GlobalVariables.MyPrograms index.
            Variables.ByteGuardProgram byteguardProgram = Variables.MyPrograms[selectedIndex];

            // Resets the MyProgramsDefault controls. (In case the user selects another program mid-edit).
            if (ButtonEditProgram.Text != "Edit Program")
                CancelProgramEditing();

            // Displays the selected program on the MyProgramsDefault user control.
            DisplayProgram(byteguardProgram);

            Version = (decimal) byteguardProgram.ProgramVersion;
        }

        /// <summary>
        ///     Displays the selected program on the MyProgramsDefault user control.
        /// </summary>
        /// <param name="byteguardProgram">The selected program to display.</param>
        private void DisplayProgram(Variables.ByteGuardProgram byteguardProgram)
        {
            // Sets the program name label.
            LabelProgramName.Text = (byteguardProgram.IsAdmin
                ? String.Format("Program Name ({0}): [ADMIN]", byteguardProgram.Programid)
                : String.Format("Program Name ({0}):", byteguardProgram.Programid));

            // Resets the program description.
            LabelProgramDescription.Text = "Program Description:";

            // Sets the program name textbox.
            TextBoxProgramName.Text = byteguardProgram.ProgramName;

            // Sets the program description textbox.
            TextBoxProgramDescription.Text = byteguardProgram.ProgramDescription.Replace("<br />", Environment.NewLine);

            // Shows how many programs the license has assigned.
            LabelUsedLicenses.Text = String.Format("Licenses: {0}", byteguardProgram.ProgramLicenses);

            // Sets the program version label.
            LabelVersion.Text = String.Format("Version: {0:0.0}", (decimal) byteguardProgram.ProgramVersion);

            // Check if the selected program has a custom image.
            if (byteguardProgram.ProgramHasImage)
            {
                // Gets the path where the program image should be stored/downloaded to. (%APPDATA%/ByteGuard/MyPrograms/{Programid}.png).
                string imagePath = String.Format(@"MyPrograms/{0}/main.png", byteguardProgram.Programid);

                // Check if the program image already exists, if so display it, if not download it.
                if (!File.Exists(imagePath))
                {
                    // Custom file image has not already been downloaded, download it!
                    string[] imageObject = {byteguardProgram.Programid, imagePath};

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
            else
            {
                // If the selected program does not have a custom image, then show the DefaultProgram image.
                PictureBoxProgramImage.Image = Resources.DefaultProgramImage;
            }
        }

        #endregion

        #region Prepare Program Methods

        private void PrepareProgramThreaded(object programid)
        {
            PrepareProgram((string) programid);
        }

        /// <summary>
        ///     Sets the $SESSION['progid'] to the selected Programid.
        /// </summary>
        /// <param name="programid">The selected Programid.</param>
        private void PrepareProgram(string programid)
        {
            NameValueCollection dataValues = new NameValueCollection {{"pid", programid}};

            Network.SubmitData("selectprog", dataValues);
        }

        #endregion

        #region Download Image Methods

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
            if (Directory.Exists(Path.Combine("MyPrograms", programid)))
            {
                PictureBoxProgramImage.Image = Resources.DefaultProgramImage;

                if (File.Exists(imagePath))
                    File.Delete(imagePath);

                // The directory exists, download the custom file image.
                Variables.Containers.Main.SetStatus("Downloading program image..", 3);

                // Download the specified program image to the ByteGuard/MyPrograms folder.
                Network.DownloadProgramImage(programid, imagePath);

                // If the image downloaded successfully, display it in the file picturebox.
                if (File.Exists(imagePath))
                {
                    PictureBoxProgramImage.ImageLocation = imagePath;
                    Variables.Containers.Main.SetStatus("Create a new program or manage an existing one.", 3);
                }
                else
                    Variables.Containers.Main.SetStatus("There was an error downloading the program image.", 1);
            }
            else
            {
                // The directory doesn't exist, create the directory and re-download the custom file image.
                Directory.CreateDirectory(Path.Combine("MyPrograms", programid));
                DownloadImage(programid, imagePath);
            }
        }

        #endregion

        #region Update Program Methods

        // TODO: Check prog name/desc length etc.
        /// <summary>
        ///     Updates the specified program in the database with the supplied program details.
        /// </summary>
        /// <param name="programDetailsObject">
        ///     ProgramDetails = { ProgramName, ProgramVersion, AutoUpdateBOOL, ProgramDescription,
        ///     Programid }
        /// </param>
        private void UpdateProgram(object programDetailsObject)
        {
            string[] programDetails = (string[])programDetailsObject;

            // Checks if the program image has been edited.
            if (_imageChanged)
            {
                // If the program image has been edited, checks the file size is less than 50KB.
                FileInfo imageInformation = new FileInfo(PictureBoxProgramImage.ImageLocation);

                if (imageInformation.Length > 100000)
                {
                    Variables.Containers.Main.SetStatus("Program image must be below 100KB in size.", 1);

                    SetControls(true);

                    Invoke((MethodInvoker)delegate { ButtonEditProgram.Enabled = true; });

                    return;
                }
            }

            NameValueCollection dataValues = new NameValueCollection
            {
                {"n", programDetails[0]},
                {"v", programDetails[1]},
                {"d", programDetails[2]}
            };
            // ProgramName.
            // ProgramVersion.
            // ProgramDescription.

            if (Network.SubmitData("editprog", dataValues))
            {
                // Gets the web response that has been returned from the server.
                string webResponse = Variables.WebResponse;

                // Parses the web response.
                if (webResponse.Split('[', ']')[1] == "SUCCESS")
                {
                    // Resets the MyProgramsDefault controls.
                    CancelProgramEditing();

                    // If the user has changed the image, check it is below 50KB.
                    if (_imageChanged)
                    {
                        string programImagePath = String.Format(@"MyPrograms/{0}/main.png", programDetails[3]);

                        // Deletes the old custom program image ready to download the new one.
                        if (File.Exists(programImagePath))
                            File.Delete(programImagePath);

                        // Uploads the new custom program image to the server.
                        Network.UploadFile(PictureBoxProgramImage.ImageLocation, "thumbnail", programDetails[3]);

                        if (Variables.WebResponse.Contains("[SUCCESS]"))
                        {
                            if (!Directory.Exists(String.Format(@"MyPrograms/{0}", programDetails[3])))
                                Directory.CreateDirectory(String.Format(@"MyPrograms/{0}", programDetails[3]));

                            File.Copy(PictureBoxProgramImage.ImageLocation, programImagePath);
                        }
                        else
                        {
                            Variables.Containers.Main.SetStatus(Variables.WebResponse.Replace("[ERROR] ", ""), 1);
                            Thread.Sleep(3500);
                        }
                    }

                    // Gets the users programs (if any) and adds them to the listbox for editing/modificaiton.
                    Thread downloadProgramsThread = new Thread(DownloadPrograms);
                    downloadProgramsThread.Start(false);

                    Variables.Containers.Main.SetStatus(webResponse.Replace("[SUCCESS] ", String.Empty), 4);
                }
                else
                {
                    Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);
                }
            }
        }

        #endregion

        #region Delete Program Methods

        /// <summary>
        ///     Deletes the specified program from the database and deletes the custom image file (if it exists).
        /// </summary>
        /// <param name="programid">The Programid of the program to delete.</param>
        private void DeleteProgram(object programid)
        {
            NameValueCollection dataValues = new NameValueCollection { { "pid", (string)programid } };

            // Requests the program be deleted from the database.
            if (!Network.SubmitData("deleteprog", dataValues))
                return;

            // Gets the web response from the request made above.
            string webResponse = Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                // Successfully deleted program from the database, delete the local image file if it exists.
                if (
                    File.Exists(Path.Combine(Variables.Paths.ByteGuardAppData, "MyPrograms",
                        String.Format("{0}.png", programid))))
                    File.Delete(Path.Combine(Variables.Paths.ByteGuardAppData, "MyPrograms",
                        String.Format("{0}.png", programid)));

                Variables.Containers.Main.SetStatus(webResponse.Replace("[SUCCESS] ", String.Empty), 4);
            }
            else
            {
                // Failed to delete program.
                Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);
            }

            Invoke((MethodInvoker)delegate
            {
                ButtonCreateProgram.Enabled = true;
                ButtonDeleteProgram.Enabled = false;
            });

            //Globals.Variables.Users.Current = Globals.Methods.DownloadUserData(Globals.Variables.Users.Current.Username);
            //Globals.Variables.UserControls.MyAccount.DisplayUserData();

            // Refreshes the listboxMyPrograms (remove deleted program) on a new thread.
            Thread downloadProgramsThread = new Thread(DownloadPrograms);
            downloadProgramsThread.Start(true);
        }

        #endregion

        #region Miscellaneous Control Methods

        /// <summary>
        ///     Resets the MyProgramsDefault controls. (For use if the user selects another program mid-edit).
        /// </summary>
        private void CancelProgramEditing()
        {
            if (InvokeRequired)
            {
                Invoke(new CancelEditingDelegate(CancelProgramEditing));
            }
            else
            {
                // Re-enables the 'Create Program' button.
                ButtonCreateProgram.Enabled = true;

                // Disables all MyProgramsDefault controls to prevent editing.
                SetControls(false);

                DeleteTimer.Stop();
                _secondCounter = 3;
                ButtonDeleteProgram.Text = "Delete Program (3)";
                ButtonDeleteProgram.Enabled = false;

                // Resets the btnEditSave text value to 'Edit Program'.
                ButtonEditProgram.Text = "Edit Program";

                // Enables the Manage Program button.
                ButtonManageProgram.Enabled = true;
            }
        }

        /// <summary>
        ///     If the user has programs stored within the database, it enables the controls for editing.
        /// </summary>
        /// <param name="isEnabled">If enabled then controls will be enabled and visa versa.</param>
        private void SetControls(bool isEnabled)
        {
            if (InvokeRequired)
            {
                Invoke(new SetControlsDelegate(SetControls), isEnabled);
            }
            else
            {
                ButtonManageProgram.Enabled = isEnabled;
                ButtonDeleteProgram.Enabled = false;
                TextBoxProgramName.Enabled = isEnabled;
                ButtonChangeImage.Enabled = isEnabled;
                ButtonVersionPlus.Enabled = isEnabled;
                ButtonVersionMinus.Enabled = isEnabled;
                TextBoxProgramDescription.Enabled = isEnabled;
            }
        }

        /*// <summary>
        /// Enables/Disables the btnEditSave button depending on the specified parameter.
        /// </summary>
        /// <param name="isEnabled">If true, the button will be enabled. If false, the button will be disabled.</param>
        public void SetButtonState(bool isEnabled)
        {
            //ButtonEditProgram.Enabled = isEnabled;
        }*/

        // Changes the ButtonEditProgram text value to 'Save Changes'.
        private void SetButtonText()
        {
            if (ButtonEditProgram.Text == "Cancel Editing")
                ButtonEditProgram.Text = "Save Changes";
        }

        private void ButtonChangeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PictureBoxProgramImage.ImageLocation = openFileDialog.FileName;
                SetButtonText();
                _imageChanged = true;
            }
        }

        private void TextBoxProgramName_TextChanged(object sender, EventArgs e)
        {
            SetButtonText();

            if (ButtonEditProgram.Text == "Save Changes")
                LabelProgramName.Text = String.Format("Program Name ({0}) - ({1}/25):",
                    LabelProgramName.Text.Split('(', ')')[1], TextBoxProgramName.TextLength);
        }

        private void TextBoxProgramDescription_TextChanged(object sender, EventArgs e)
        {
            SetButtonText();

            if (ButtonEditProgram.Text == "Save Changes")
                LabelProgramDescription.Text = String.Format("Program Description ({0}/500):",
                    TextBoxProgramDescription.TextLength);
        }

        private void ButtonVersionPlus_Click(object sender, EventArgs e)
        {
            if (Version < 99.9m)
                Version += 0.1m;

            if (ButtonEditProgram.Text == "Cancel Editing")
                SetButtonText();

            LabelVersion.Text = String.Format("Version: {0:0.0}", Version);
        }

        private void ButtonVersionMinus_Click(object sender, EventArgs e)
        {
            if (Version > 1.0m)
                Version -= 0.1m;

            if (ButtonEditProgram.Text == "Cancel Editing")
                SetButtonText();

            LabelVersion.Text = String.Format("Version: {0:0.0}", Version);
        }

        #endregion
    }
}
