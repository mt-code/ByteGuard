using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Tasks;
using ByteGuard.Tasks.Licensing;
using Variables = ByteGuard.ByteGuardInterface.Globals.Variables;

namespace ByteGuard.ByteGuardInterface.UserControls.Other
{
    public partial class CreateAccount : UserControl
    {
        public CreateAccount()
        {
            InitializeComponent();

            Variables.Containers.Active = ThemeContainer;
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            ActiveControl = ButtonBack;

            ThemeContainer.SetStatus("Please sign in or create an account.", 3);
        }

        private void ButtonCreateAccount_Click(object sender, EventArgs e)
        {
            // Check they have accepted the terms and conditions.
            if (!chkTerms.Checked)
            {
                ThemeContainer.SetStatus("You must accept the terms and conditions.", 1);
                return;
            }

            // Checks if the specified email is valid.
            if (!Regex.Match(TextBoxEmail.Text,
                "^((([a-z]|\\d|[!#\\$%&'\\*\\+\\-\\/=\\?\\^_`{\\|}~]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])+(\\.([a-z]|\\d|[!#\\$%&'\\*\\+\\-\\/=\\?\\^_`{\\|}~]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])+)*)|((\\x22)((((\\x20|\\x09)*(\\x0d\\x0a))?(\\x20|\\x09)+)?(([\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x7f]|\\x21|[\\x23-\\x5b]|[\\x5d-\\x7e]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(\\\\([\\x01-\\x09\\x0b\\x0c\\x0d-\\x7f]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF]))))*(((\\x20|\\x09)*(\\x0d\\x0a))?(\\x20|\\x09)+)?(\\x22)))@((([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])*([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])))\\.)+(([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])*([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])))\\.?$",
                RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.ExplicitCapture).Success)
            {
                ThemeContainer.SetStatus("Please enter a valid e-mail address.", 1);
                return;
            }

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

            // Checks if the specified username and passwords are not the same, to prevent account theft.
            if (TextBoxUsername.Text == TextBoxPassword.Text)
            {
                ThemeContainer.SetStatus("Username/password must not be the same.", 1);
                return;
            }

            // Checks if the specified passwords match.
            if (TextBoxPassword.Text != TextBoxConfirmPassword.Text)
            {
                ThemeContainer.SetStatus("Your passwords do not match.", 1);

                TextBoxPassword.ForeColor = Color.DimGray;
                TextBoxConfirmPassword.ForeColor = Color.DimGray;

                TextBoxPassword.UseSystemPasswordChar = false;
                TextBoxConfirmPassword.UseSystemPasswordChar = false;

                TextBoxPassword.Text = "Password";
                TextBoxConfirmPassword.Text = "Confirm Password";

                return;
            }

            // Disables the CreateAccountForm controls to prevent spamming.
            SetControls(false);

            // Attempts to create a new user account.
            Thread createAccountThread = new Thread(ThreadedCreateAccount);
            createAccountThread.Start();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Form parentForm = ParentForm;

            // Changes from Login controls to CreateAccount controls.
            var conLogin = new Login(false);

            // Changes the form size to fit the CreateAccount user control.
            if (parentForm != null)
            {
                int x = (parentForm.Size.Width - Width);
                int y = (parentForm.Size.Height - Height);

                parentForm.Size = new Size(conLogin.Width + x, conLogin.Height + y);
            }

            Parent.Controls.Add(conLogin);
            Parent.Controls.Remove(this);

            // Forces the theme to refresh to adjust to the new dimensions.
            ThemeContainer.ForceRedraw();
        }

        private delegate void SetControlsDelegate(bool isEnabled);

        #region CreateAccountMethods

        /// <summary>
        ///     Attempts to create a new user account.
        /// </summary>
        private void ThreadedCreateAccount()
        {
            NameValueCollection dataValues = new NameValueCollection
            {
                {"e", TextBoxEmail.Text},
                {"u", TextBoxUsername.Text},
                {"p", Methods.GetMd5(TextBoxPassword.Text, false)},
                {"t", (chkTerms.Checked ? "1" : "0") }
            };

            while (Hwid.HardwareIdentifier == "NOTSET")
                Thread.Sleep(250);

            if (Network.SubmitData("register", dataValues))
                ProcessResponse();
            else
                SetControls(true);
        }

        /// <summary>
        ///     Processes the web response and acts accordingly.
        /// </summary>
        private void ProcessResponse()
        {
            string webResponse = Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                // Account created successfully.
                Invoke((MethodInvoker) delegate
                {
                    Form parentForm = ParentForm;

                    // Changes from Login controls to CreateAccount controls.
                    Parent.Controls.Add(new Login(true));

                    // Changes the form size to fit the CreateAccount user control.
                    if (parentForm != null) parentForm.Size = new Size(296, 289);

                    // Removes the Login user control.
                    Parent.Controls.Remove(this);

                    // Forces the theme to refresh to adjust to the new dimensions.
                    ThemeContainer.ForceRedraw();
                });

                ThemeContainer.SetStatus(webResponse.Replace("[SUCCESS] ", String.Empty), 4);
            }
            else
            {
                // Failed to create account, display error.
                ThemeContainer.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);

                // Enables the CreateAccountForm controls after a failed login.
                SetControls(true);
            }
        }

        #endregion

        #region MiscellaneousControlMethods

        /// <summary>
        ///     Enables/disables the form controls depending on the supplied boolean value.
        /// </summary>
        /// <param name="isEnabled">If true, enables the form controls.</param>
        private void SetControls(bool isEnabled)
        {
            if (InvokeRequired)
            {
                Invoke(new SetControlsDelegate(SetControls), isEnabled);
            }
            else
            {
                TextBoxEmail.Enabled = isEnabled;
                TextBoxUsername.Enabled = isEnabled;
                TextBoxPassword.Enabled = isEnabled;
                TextBoxConfirmPassword.Enabled = isEnabled;
                ButtonCreateAccount.Enabled = isEnabled;
                ButtonBack.Enabled = isEnabled;

                if (!isEnabled)
                {
                    TextBoxEmail.BackColor = Color.White;
                    TextBoxUsername.BackColor = Color.White;
                    TextBoxPassword.BackColor = Color.White;
                    TextBoxConfirmPassword.BackColor = Color.White;
                }
            }
        }

        private bool AreTextBoxesFilled()
        {
            if (TextBoxEmail.Text == "Email" || TextBoxUsername.Text == "Username" || TextBoxPassword.Text == "Password" ||
                TextBoxConfirmPassword.Text == "Confirm Password" || !chkTerms.Checked)
                return false;

            if (TextBoxEmail.Text != String.Empty && TextBoxUsername.Text != String.Empty &&
                TextBoxPassword.Text != String.Empty && TextBoxConfirmPassword.Text != String.Empty)
                return true;

            return false;
        }

        private void TextBoxEmail_Enter(object sender, EventArgs e)
        {
            if (TextBoxEmail.ForeColor == Color.DimGray && TextBoxEmail.Text == "Email")
            {
                TextBoxEmail.Clear();
                TextBoxEmail.ForeColor = Color.Black;
            }
        }

        private void TextBoxEmail_Leave(object sender, EventArgs e)
        {
            if (TextBoxEmail.Text == String.Empty)
            {
                TextBoxEmail.ForeColor = Color.DimGray;
                TextBoxEmail.Text = "Email";
            }
        }

        private void TextBoxEmail_TextChanged(object sender, EventArgs e)
        {
            ButtonCreateAccount.Enabled = AreTextBoxesFilled();
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
            ButtonCreateAccount.Enabled = AreTextBoxesFilled();
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
                TextBoxPassword.ForeColor = Color.DimGray;
                TextBoxPassword.UseSystemPasswordChar = false;
                TextBoxPassword.Text = "Password";
            }
        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            ButtonCreateAccount.Enabled = AreTextBoxesFilled();
        }

        private void TextBoxConfirmPassword_Enter(object sender, EventArgs e)
        {
            if (TextBoxConfirmPassword.ForeColor == Color.DimGray && TextBoxConfirmPassword.Text == "Confirm Password")
            {
                TextBoxConfirmPassword.Clear();
                TextBoxConfirmPassword.ForeColor = Color.Black;
                TextBoxConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private void TextBoxConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (TextBoxConfirmPassword.Text == String.Empty)
            {
                TextBoxConfirmPassword.ForeColor = Color.DimGray;
                TextBoxConfirmPassword.UseSystemPasswordChar = false;
                TextBoxConfirmPassword.Text = "Confirm Password";
            }
        }

        private void TextBoxConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            ButtonCreateAccount.Enabled = AreTextBoxesFilled();
        }

        #endregion

        private void chkTerms_CheckedChanged(object sender, EventArgs e)
        {
            ButtonCreateAccount.Enabled = AreTextBoxesFilled();
        }

        private void linkTerms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.byteguardsoftware.co.uk/terms");
        }
    }
}