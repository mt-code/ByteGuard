using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ByteGuard.ByteGuardInterface.Forms;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Tasks;
using ByteGuard.Tasks.Licensing;
using Variables = ByteGuard.ByteGuardInterface.Globals.Variables;

namespace ByteGuard.ByteGuardInterface.UserControls.Other
{
    public partial class Login : UserControl
    {
        private readonly bool _accountCreatedSuccessfully;
        private delegate void SetControlsDelegate(bool isEnabled);

        public Login(bool accountCreatedSuccessfully)
        {
            InitializeComponent();

            if (Variables.Threads.UpdateHwid == null)
            {
                Thread getHwid = new Thread(Hwid.Update)
                {
                    IsBackground = true
                };

                Variables.Threads.UpdateHwid = getHwid;

                getHwid.Start();
            }

            Variables.Containers.Active = ThemeContainer;
            _accountCreatedSuccessfully = accountCreatedSuccessfully;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Sets the status bar text.
            if (_accountCreatedSuccessfully)
            {
                ThemeContainer.SetStatus("Account created successfully.", 4);
            }
            else
            {
                ThemeContainer.SetStatus("Please sign in or create an account.", 3);
            }

            // If stored, gets the stored username. Also creates installation directories if not already created.
            PreLoginProcessing();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            // Checks if the specified username is the correct length.
            if (TextBoxUsername.TextLength < 4 || TextBoxUsername.TextLength > 12 || TextBoxUsername.Text == "Username")
            {
                ThemeContainer.SetStatus("Username must be 4-12 characters.", 1);
                return;
            }

            // Checks if the specified username is valid.
            if (!Regex.Match(TextBoxUsername.Text, "^[a-zA-Z0-9]+$").Success)
            {
                ThemeContainer.SetStatus("Username can only contain letters/numbers.", 1);
                return;
            }

            // Disables the form controls to prevent spamming.
            SetControls(false);

            ThemeContainer.SetStatus("Logging in, please wait...", 3);

            // Attempts to log the user in with the specified credentials on a seperate thread.
            Thread threadLogin = new Thread(ThreadedLogin);
            threadLogin.Start();
        }

        private void ButtonCreateAccount_Click(object sender, EventArgs e)
        {
            Form parentForm = ParentForm;

            // Changes from Login controls to CreateAccount controls.
            var conCreateAccount = new CreateAccount();

            // Changes the form size to fit the CreateAccount user control.
            if (parentForm != null)
            {
                int x = (parentForm.Size.Width - Width);
                int y = (parentForm.Size.Height - Height);

                parentForm.Size = new Size(conCreateAccount.Width + x, conCreateAccount.Height + y);
            }

            Parent.Controls.Add(conCreateAccount);
            Parent.Controls.Remove(this);

            // Forces the theme to refresh to adjust to the new dimensions.
            ThemeContainer.ForceRedraw();
        }

        private void ButtonRecoverAccount_Click(object sender, EventArgs e)
        {
            // TODO: Do this.
        }

        private void StoreUserInformation()
        {
            string userXml = Path.Combine(Variables.Paths.ByteGuardAppData, TextBoxUsername.Text, "user.xml");

            // Creates the directory for user avatar/information to be stored in.
            if (!Directory.Exists(Path.Combine(Variables.Paths.ByteGuardAppData, TextBoxUsername.Text)))
                Directory.CreateDirectory(Path.Combine(Variables.Paths.ByteGuardAppData, TextBoxUsername.Text));

            File.WriteAllText(userXml, Variables.WebResponse.Replace("[SUCCESS]", ""));

            if (File.Exists(userXml))
            {
                // Loads the XML file ready to be parsed.
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(userXml);

                foreach (XmlNode xmlNode in xmlDocument)
                {
                    foreach (XmlNode xmlUserNode in xmlNode)
                    {
                        Variables.Users.Current = Methods.ParseUserData(xmlUserNode);
                        break;
                    }
                }
            }
        }

        #region LoginMethods

        /// <summary>
        /// Attempts to log the user in, resets the controls if the server is offline.
        /// </summary>
        private void ThreadedLogin()
        {
            NameValueCollection dataValues = new NameValueCollection
            {
                {"u", TextBoxUsername.Text},
                {"p", Methods.GetMd5(TextBoxPassword.Text, false)}
            };

            while (Hwid.HardwareIdentifier == "NOTSET")
                Thread.Sleep(250);

            if (Network.SubmitData("login", dataValues))
            {
                ProcessResponse();
            }
            else
            {
                SetControls(true);
            }
        }

        
        /// <summary>
        /// Processes the web response and acts accordingly.
        /// </summary>
        private void ProcessResponse()
        {
            // Retrieves the web response.
            string webResponse = Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                Thread storeUserInformationThread = new Thread(StoreUserInformation);
                storeUserInformationThread.Start();

                // Logged in successfully, saves username/shows EULA.
                PostLoginProcessing();

                MainForm m = new MainForm();
                Form parentForm = ParentForm;

                // When the MainForm is closed, the whole application will exit.
                if (parentForm != null) m.FormClosed += (closedSender, closedE) => parentForm.Close();

                // Hides the current form and shows the MainForm.
                Invoke((MethodInvoker)delegate
                {
                    if (parentForm != null) parentForm.Hide();
                    m.Show();
                });
            }
            else
            {
                // Failed to create account, display error.
                ThemeContainer.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);

                // Resets/Enables the controls after an incorrect login.
                SetControls(true);
            }
        }

        #endregion

        #region PreLoginProcessingMethods
        /// <summary>
        /// If stored, gets the stored username. Also creates installation directories if not already created.
        /// </summary>
        private void PreLoginProcessing()
        {
            // Check if %APPDATA%/Byteguard path exists.
            if (Directory.Exists(Variables.Paths.ByteGuardAppData))
            {
                // The path exists, check if config.xml exists.
                if (File.Exists(Variables.Paths.ByteGuardConfig))
                {
                    // config.ini exists, check if username is stored.
                    if (Methods.ReadIniString(Variables.Paths.ByteGuardConfig, "rememberme") == "true")
                    {
                        // User wants to be remembered so load username.
                        string storedUsername = Methods.ReadIniString(Variables.Paths.ByteGuardConfig, "username");

                        // If the username is stored, sets the textbox.
                        if (storedUsername != "NOTFOUND")
                        {
                            TextBoxUsername.Text = storedUsername;
                            TextBoxUsername.ForeColor = Color.Black;

                            ActiveControl = TextBoxPassword;
                        }
                        else
                        {
                            ActiveControl = ButtonLogin;
                        }
                    }
                    else
                    {
                        // User didn't want to be remembered so uncheck RememberMe checkbox.
                        CheckBoxRememberMe.Checked = false;

                        // Stops the cursor starting within a textbox.
                        ActiveControl = ButtonLogin;
                    }
                }
                else
                {
                    // config.ini doesn't exist, create it.
                    CreateConfigIni(Variables.Paths.ByteGuardConfig);

                    // Stops the cursor starting within a textbox.
                    ActiveControl = ButtonLogin;
                }
            }
            else
            {
                // The path doesn't exist, create it.
                Directory.CreateDirectory(Variables.Paths.ByteGuardAppData);
                PreLoginProcessing();
            }
        }

        /// <summary>
        /// Create an empty config.ini file at the specified path.
        /// </summary>
        /// <param name="filePath">Path to create the ini file. (Usually: %APPDATA%/ByteGuard/config.ini)</param>
        private void CreateConfigIni(string filePath)
        {
            using (StreamWriter configWriter = File.CreateText(filePath))
            {
                configWriter.WriteLine("eula=false");
                configWriter.WriteLine("rememberme=true");
            }
        }
        #endregion

        #region PostLoginProcessingMethods
        /// <summary>
        /// Saves the username if requested and shows the EULA if not already accepted.
        /// </summary>
        private void PostLoginProcessing()
        {
            // Saves whether the user would like to save their username or not.
            Methods.RemoveLineContaining(Variables.Paths.ByteGuardConfig, "rememberme");
            File.AppendAllText(Variables.Paths.ByteGuardConfig, String.Format("rememberme={0}{1}", CheckBoxRememberMe.Checked, Environment.NewLine));

            // Saves their username if requested.
            if (CheckBoxRememberMe.Checked)
            {
                Methods.RemoveLineContaining(Variables.Paths.ByteGuardConfig, "username");
                File.AppendAllText(Variables.Paths.ByteGuardConfig, String.Format("username={0}{1}", TextBoxUsername.Text, Environment.NewLine));
            }

            // Creates the directory for programs to be stored in.
            if (!Directory.Exists("MyPrograms"))
                Directory.CreateDirectory("MyPrograms");

            // Creates the directory for account details to be stored in.
            if (!Directory.Exists("MyLibrary"))
                Directory.CreateDirectory("MyLibrary");
        }
        #endregion
        
        #region MiscellaneousControlMethods

        // Enables/disables the form controls to prevent button spamming.
        private void SetControls(bool isEnabled)
        {
            if (InvokeRequired)
            {
                Invoke(new SetControlsDelegate(SetControls), isEnabled);
            }
            else
            {
                TextBoxUsername.Enabled = isEnabled;
                TextBoxPassword.Enabled = isEnabled;

                CheckBoxRememberMe.Enabled = isEnabled;

                ButtonLogin.Enabled = isEnabled;
                ButtonCreateAccount.Enabled = isEnabled;
                ButtonRecoverAccount.Enabled = isEnabled;

                if (!isEnabled)
                {
                    TextBoxUsername.BackColor = Color.White;
                    TextBoxPassword.BackColor = Color.White;
                }
                else
                {
                    TextBoxPassword.Clear();
                    ActiveControl = TextBoxPassword;
                }
            }
        }

        private void TextBoxUsername_Enter(object sender, EventArgs e)
        {
            if (TextBoxUsername.ForeColor == Color.DimGray && TextBoxUsername.Text == "Username")
            {
                TextBoxUsername.Clear();
                TextBoxUsername.ForeColor = Color.Black;
            }
        }

        private void TextBoxUsername_Leave(object sender, EventArgs e)
        {
            if (TextBoxUsername.Text == String.Empty)
            {
                TextBoxUsername.ForeColor = Color.DimGray;
                TextBoxUsername.Text = "Username";
            }
        }

        private void TextBoxUsername_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxUsername.Text != "Username" && TextBoxPassword.Text != "Password")
            {
                ButtonLogin.Enabled = (TextBoxUsername.Text != String.Empty && TextBoxPassword.Text != String.Empty);
            }
        }

        private void TextBoxPassword_Enter(object sender, EventArgs e)
        {
            if (TextBoxPassword.ForeColor == Color.DimGray && TextBoxPassword.Text == "Password")
            {
                TextBoxPassword.Clear();
                TextBoxPassword.ForeColor = Color.Black;
                TextBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void TextBoxPassword_Leave(object sender, EventArgs e)
        {
            if (TextBoxPassword.Text == String.Empty)
            {
                TextBoxPassword.Text = "Password";
                TextBoxPassword.ForeColor = Color.DimGray;
                TextBoxPassword.UseSystemPasswordChar = false;
            }
        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxUsername.Text != "Username" && TextBoxPassword.Text != "Password")
            {
                ButtonLogin.Enabled = (TextBoxUsername.Text != String.Empty && TextBoxPassword.Text != String.Empty);
            }
        }
        #endregion
    }
}
