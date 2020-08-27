using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Tasks;
using ByteGuard.Tasks.Licensing;
using Variables = ByteGuard.ByteGuardInterface.Globals.Variables;

namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    public partial class CreateProgram : UserControl
    {
        private bool _imageChanged;

        public CreateProgram()
        {
            InitializeComponent();

            Version = 1.0m;
        }

        public decimal Version { get; set; }

        private delegate void SetControlsDelegate(bool isEnabled);

        private void CreateProgram_Load(object sender, EventArgs e)
        {
            DropDownProtectionPreset.SelectedIndex = 3;
            CharacterSetComboBox.SelectedIndex = 4;
            comboMainExecutable.SelectedIndex = 0;
        }

        private void ButtonCreateProgram_Click(object sender, EventArgs e)
        {
            // Checks the program name is between 5-25 characters.
            if (TextBoxProgramName.TextLength < 5 || TextBoxProgramName.TextLength > 25)
            {
                Variables.Containers.Main.SetStatus("Program name must be between 5-25 characters.", 1);
                return;
            }

            // Checks the program description is between 35-255 characters.
            if (TextBoxProgramDescription.TextLength < 35 || TextBoxProgramDescription.TextLength > 500)
            {
                Variables.Containers.Main.SetStatus("Program description must be between 35-500 characters.", 1);
                return;
            }

            // Checks if the program image has been edited.
            if (_imageChanged)
            {
                // If the program image has been edited, checks the file size is less than 50KB.
                FileInfo imageFileInformation = new FileInfo(PictureBoxProgramImage.ImageLocation);

                if (imageFileInformation.Length > 100000)
                {
                    Variables.Containers.Main.SetStatus("Program image must be below 100KB in size.", 1);
                    return;
                }
            }

            // Disables all controls on the form to prevent spamming/tampering.
            SetControls(false);

            // Attempts to create the program on a new thread.
            Thread threadCreateProgram = new Thread(CreateProgramThreaded);
            threadCreateProgram.Start();
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
                _imageChanged = true;
            }
        }

        private void ButtonVersionPlus_Click(object sender, EventArgs e)
        {
            if (Version < 99.9m)
                Version += 0.1m;

            LabelVersion.Text = String.Format("Version: {0:0.0}", Version);
        }

        private void ButtonVersionMinus_Click(object sender, EventArgs e)
        {
            if (Version > 1.0m)
                Version -= 0.1m;

            LabelVersion.Text = String.Format("Version: {0:0.0}", Version);
        }

        private void ButtonBrowseProgram_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowse = new FolderBrowserDialog())
            {
                folderBrowse.ShowNewFolderButton = false;
                folderBrowse.RootFolder = Environment.SpecialFolder.MyComputer;

                folderBrowse.Description =
                    "Select the folder that contains your program and any neccesary files, ensure the folder only contains required files. **(Sub-directories not yet supported)**";

                if (folderBrowse.ShowDialog() == DialogResult.OK)
                {
                    TextBoxProgramLocation.Text = folderBrowse.SelectedPath;

                    // Enable select main executable controls.
                    lblMainExecutable.Enabled = true;
                    comboMainExecutable.Enabled = true;

                    if (comboMainExecutable.Items.Count > 1)
                    {
                        comboMainExecutable.Items.Clear();
                        comboMainExecutable.Items.Add("Select executable...");
                        comboMainExecutable.SelectedIndex = 0;
                    }

                    foreach (string filePath in Directory.GetFiles(folderBrowse.SelectedPath).Where(filePath => Methods.IsNetAssembly(filePath)).Where(filePath => Path.GetExtension(filePath).ToLower() == ".exe"))
                    {
                        comboMainExecutable.Items.Add(Path.GetFileName(filePath));
                    }
                }
            }
        }

        private void DropDownProtectionPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: This.
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            // Changes from CreateProgram controls to MyProgramsDefault controls.
            Parent.Controls.Add(Variables.UserControls.MyProgramsDefault);
            Parent.Controls.Remove(this);
        }

        /// <summary>
        ///     Creates the program with the specified details.
        /// </summary>
        private void CreateProgramThreaded()
        {
            // Initialize variables.
            string programName = "", programVersion = "", programDescription = "";

            // Gets the required information and stores it in the variables for use. (Prevents the UI from freezing on the seperate thread)
            Invoke((MethodInvoker) delegate
            {
                programName = TextBoxProgramName.Text;
                programVersion = LabelVersion.Text.Replace("Version: ", String.Empty);
                programDescription = TextBoxProgramDescription.Text;
            });

            // Adds the program details to a name value collection.
            NameValueCollection dataValues = new NameValueCollection
            {
                {"n", programName},
                {"v", programVersion},
                {"d", programDescription},
                {"i", _imageChanged.ToString()}
            };

            // Submits the program details and creates a new program in the database.
            if (Network.SubmitData("createprogram", dataValues))
                ProcessResponse(_imageChanged);
        }

        /// <summary>
        ///     Processes the web response and acts accordingly.
        /// </summary>
        private void ProcessResponse(bool hasImage)
        {
            // Gets the web response that has been returned from the server.
            string webResponse = Variables.WebResponse;

            // Parses the web response.
            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                string fileLocation = null;
                string decryptionKey = webResponse.Split(')')[1];
                string programId = webResponse.Split('(', ')')[1];

                Invoke((MethodInvoker) delegate
                {
                    fileLocation = Path.Combine(TextBoxProgramLocation.Text, comboMainExecutable.Text);
                });
                
                // TODO: Multi-thread this.
                string targetModuleHash = Protect(fileLocation, decryptionKey, programId);

                // Submits the protected files checksum.
                Task.Factory.StartNew(() => Programs.UpdateMd5Hash(programId, targetModuleHash));

                // Checks if the user chosen a custom program image.
                if (!hasImage)
                {
                    // Shows the MyProgramsDefault usercontrol.
                    Invoke((MethodInvoker) delegate
                    {
                        Parent.Controls.Add(Variables.UserControls.MyProgramsDefault);
                        Parent.Controls.Remove(this);
                    });
                }
                else
                {
                    Variables.Containers.Main.SetStatus("Uploading program image..", 3);

                    // Created program successfully, image upload required.
                    Network.UploadFile(PictureBoxProgramImage.ImageLocation, "thumbnail", programId);

                    // Gets the web response that has been returned from the server.
                    webResponse = Variables.WebResponse;


                    // Shows the MyProgramsDefault usercontrol.
                    Invoke((MethodInvoker) delegate
                    {
                        this.Parent.Controls.Add(Variables.UserControls.MyProgramsDefault);
                        this.Parent.Controls.Remove(this);
                    });
                }

                Thread threadDownloadPrograms = new Thread(Variables.UserControls.MyProgramsDefault.DownloadPrograms);
                threadDownloadPrograms.Start(false);

                // TODO: Check if successful before showing success message.
                // No image upload required, created the program successfully.
                Variables.Containers.Main.SetStatus(webResponse.Replace("[SUCCESS] ", String.Empty), 4);
            }
            else
            {
                // Failed to create program, show res
                Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);
            }

            // Enables the form controls after a successful/unsuccessul program creation attempt.
            SetControls(true);
        }

        private static string Protect(string fileLocation, string decryptionKey, string programId)
        {
            return Protections.Online.Protections.Protect(fileLocation, decryptionKey, programId);
        }

        #region Miscellaneous Control Functions.

        /// <summary>
        ///     Enables/disables the form controls depending on the specified parameter.
        /// </summary>
        /// <param name="isEnabled">If True, all controls will be enabled. If False, all controls will be disabled.</param>
        private void SetControls(bool isEnabled)
        {
            if (InvokeRequired)
            {
                Invoke(new SetControlsDelegate(SetControls), isEnabled);
            }
            else
            {
                TextBoxProgramName.Enabled = isEnabled;
                TextBoxProgramDescription.Enabled = isEnabled;
                ButtonChangeImage.Enabled = isEnabled;
                ButtonCreateProgram.Enabled = isEnabled;
                ButtonBack.Enabled = isEnabled;
                ButtonVersionMinus.Enabled = isEnabled;
                ButtonVersionPlus.Enabled = isEnabled;
                DropDownProtectionPreset.Enabled = isEnabled;
            }
        }

        private void TextBoxProgramName_Enter(object sender, EventArgs e)
        {
            if (TextBoxProgramName.ForeColor == Color.DimGray && TextBoxProgramName.Text == "Please enter a name...")
            {
                TextBoxProgramName.Clear();
                TextBoxProgramName.ForeColor = Color.Black;
            }
        }

        private void TextBoxProgramName_Leave(object sender, EventArgs e)
        {
            if (TextBoxProgramName.Text == String.Empty)
            {
                TextBoxProgramName.ForeColor = Color.DimGray;
                TextBoxProgramName.Text = "Please enter a name...";
            }
        }

        private void TextBoxProgramName_TextChanged(object sender, EventArgs e)
        {
            LabelProgramName.Text = ((TextBoxProgramName.Text != "Please enter a name...")
                ? (String.Format("Program Name ({0}/25):", TextBoxProgramName.TextLength))
                : "Program Name (0/25):");

            ButtonCreateProgram.Enabled = CanCreateProgram();
        }

        private void TextBoxProgramDescription_Enter(object sender, EventArgs e)
        {
            if (TextBoxProgramDescription.ForeColor == Color.DimGray &&
                TextBoxProgramDescription.Text == "Please enter a description...")
            {
                TextBoxProgramDescription.Clear();
                TextBoxProgramDescription.ForeColor = Color.Black;
            }
        }

        private void TextBoxProgramDescription_Leave(object sender, EventArgs e)
        {
            if (TextBoxProgramDescription.Text == String.Empty)
            {
                TextBoxProgramDescription.ForeColor = Color.DimGray;
                TextBoxProgramDescription.Text = "Please enter a description...";
            }
        }

        private void TextBoxProgramDescription_TextChanged(object sender, EventArgs e)
        {
            LabelProgramDescription.Text = ((TextBoxProgramDescription.Text != "Please enter a description...")
                ? (String.Format("Description ({0}/500):", TextBoxProgramDescription.TextLength))
                : "Description (0/255):");

            ButtonCreateProgram.Enabled = CanCreateProgram();
        }

        private void comboMainExecutable_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isEnabled = comboMainExecutable.SelectedItem.ToString() != "Select executable...";

            StringsGroupBox.Enabled = isEnabled;
            AssemblyRenameGroupBox.Enabled = isEnabled;
            ConstantsGroupBox.Enabled = isEnabled;
            LabelProtectionPreset.Enabled = isEnabled;
            DropDownProtectionPreset.Enabled = isEnabled;

            ButtonCreateProgram.Enabled = CanCreateProgram();
        }

        private bool CanCreateProgram()
        {
            if (TextBoxProgramName.Text == "" || TextBoxProgramName.Text == "Please enter a name...")
                return false;

            if (TextBoxProgramDescription.Text == "" ||
                TextBoxProgramDescription.Text == "Please enter a description...")
                return false;

            if (comboMainExecutable.SelectedItem.ToString() == "Select executable...")
                return false;

            return true;
        }

        #endregion

        private void EmbedStringsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CompressStringsCheckBox.Checked = EmbedStringsCheckBox.Checked;
        }
    }
}