using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using ByteGuard.ByteGuardInterface.Globals;

namespace ByteGuard.Tasks.Licensing
{
    class Programs
    {
        private static bool _isFirstTime = true;

        public static void Initialize()
        {
            _isFirstTime = true;
        }

        public static bool IsAdmin { get; set; }

        #region Administrator Methods.

        public static ListView ListViewAdministrators { get; set; }

        public static Label AdminsRemaining { get; set; }

        public static Button ButtonAddAdministrator { get; set; }

        public static void GetAdministrators(string programid)
        {
            NameValueCollection dataValues = new NameValueCollection {{"pid", programid}};

            if (Network.SubmitData("getadmins", dataValues))
                LoadAdmins();
        }

        private static void LoadAdmins()
        {
            // Retrieves the web response.
            string webResponse = ByteGuardInterface.Globals.Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                // Got the list of licenses successfully, parse the response.
                ByteGuardInterface.Globals.Variables.Forms.Main.Invoke((MethodInvoker)delegate
                {
                    ListViewAdministrators.Items.Clear();
                });

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ByteGuardInterface.Globals.Variables.WebResponse.Replace("[SUCCESS]", ""));

                // Variables.
                int timeAdded = 0;
                string username = "", email = "";

                // Iterates through each program node.
                foreach (XmlNode xmlNode in xmlDocument)
                {
                    foreach (XmlNode xmlAdminNode in xmlNode)
                    {
                        foreach (XmlNode xmlInformationNode in xmlAdminNode)
                        {
                            switch (xmlInformationNode.Name)
                            {
                                case "username":
                                    username = xmlInformationNode.InnerText;
                                    break;

                                case "email":
                                    email = xmlInformationNode.InnerText;
                                    break;

                                case "time":
                                    timeAdded = Convert.ToInt32(xmlInformationNode.InnerText);
                                    break;
                            }
                        }

                        ListViewItem listviewItem = new ListViewItem(username);
                        listviewItem.SubItems.Add(email);
                        listviewItem.SubItems.Add(Methods.TimeStampToDate(timeAdded));

                        try
                        {
                            ListViewAdministrators.Invoke((MethodInvoker) delegate
                            {
                                ListViewAdministrators.Items.Add(listviewItem);
                            });
                        }
                        catch
                        {
                            // IsDisposed
                        }
                    }
                }

                if (!_isFirstTime)
                {
                    ByteGuardInterface.Globals.Variables.Users.Current = Methods.DownloadUserData(ByteGuardInterface.Globals.Variables.Users.Current.Username);

                    ByteGuardInterface.Globals.Variables.Forms.Main.Invoke((MethodInvoker)delegate
                    {
                        // Show how many admins the user account has remaining.
                        AdminsRemaining.Text = String.Format("This program can support {0} more administrator(s).", ByteGuardInterface.Globals.Variables.Users.Current.ProgramAdministratorsRemaining);

                        ButtonAddAdministrator.Enabled = (ByteGuardInterface.Globals.Variables.Users.Current.ProgramAdministratorsRemaining > 0);
                    });
                }
                else
                {
                    _isFirstTime = false;

                    ByteGuardInterface.Globals.Variables.Forms.Main.Invoke((MethodInvoker)delegate
                    {
                        ButtonAddAdministrator.Enabled = (ByteGuardInterface.Globals.Variables.Users.Current.ProgramAdministratorsRemaining > 0);
                    });
                }
            }
            else
            {
                ByteGuardInterface.Globals.Variables.Containers.Main.SetStatus(ByteGuardInterface.Globals.Variables.WebResponse.Replace("[ERROR]", ""), 1);
            }
        }
        #endregion

        public static NumericUpDown HwidLimit { get; set; }

        public static NumericUpDown HWidExpiration { get; set; }

        public static NumericUpDown IpLimit { get; set; }

        public static NumericUpDown IpExpiration { get; set; }

        public static CheckBox BanLicenseIfLimitReached { get; set; }

        public static Button ButtonSaveLockChanges { get; set; }

        public static void UpdateMd5Hash(string programid, string md5Hash)
        {
            NameValueCollection dataValues = new NameValueCollection
            {
                {"pid", programid},
                {"cs", md5Hash}
            };

            if (Network.SubmitData("sethash", dataValues))
            {
                string webResponse = ByteGuardInterface.Globals.Variables.WebResponse;

                if (webResponse.Split('[', ']')[1] == "SUCCESS")
                {
                    ByteGuardInterface.Globals.Variables.Containers.Main.SetStatus(
                        webResponse.Replace("[SUCCESS]", ""), 4);
                }
                else
                {
                    ByteGuardInterface.Globals.Variables.Containers.Main.SetStatus(
                        webResponse.Replace("[ERROR]", ""), 1);
                }
        }
            else
            {
                MessageBox.Show("Failed to update your programs checksum, please delete the program and start again.",
                    "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void GetLockLimits(string programid)
        {
            NameValueCollection dataValues = new NameValueCollection {{"pid", programid}};

            if (Network.SubmitData("getlocklimits", dataValues))
                LoadLockLimits();
        }

        public static void UpdateMyPrograms()
        {
            if (Network.SubmitData("getprograms"))
            {
                // Gets the webResponse from GlobalVariables.StorageBytes and splits it.
                string webResponse = ByteGuardInterface.Globals.Variables.WebResponse;

                if (webResponse.Split('[', ']')[1] == "SUCCESS")
                {
                    // Got the list of programs successfully, parse the response.
                    ByteGuardInterface.Globals.Variables.MyPrograms.Clear();

                    // Saves the downloaded xml file to the programs.xml file.
                    File.WriteAllText(@"MyPrograms/programs.xml", webResponse.Replace("[SUCCESS]", ""));

                    // Loads the XML file ready to be parsed.
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(@"MyPrograms/programs.xml");

                    // Iterates through each program node.
                    foreach (XmlNode xmlProgramNode in xmlDocument.Cast<XmlNode>().SelectMany(xmlNode => xmlNode.Cast<XmlNode>()))
                    {
                        ByteGuardInterface.Globals.Variables.MyPrograms.Add(ParseProgramNode(xmlProgramNode));
                    }
                }
            }
        }

        private static ByteGuardInterface.Globals.Variables.ByteGuardProgram ParseProgramNode(XmlNode programNode)
        {
            // Initializes a ByteGuardProgram variable for us to work with.
            ByteGuardInterface.Globals.Variables.ByteGuardProgram byteguardProgram = new ByteGuardInterface.Globals.Variables.ByteGuardProgram();

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

        private static void LoadLockLimits()
        {
            // Retrieves the web response.
            string webResponse = ByteGuardInterface.Globals.Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ByteGuardInterface.Globals.Variables.WebResponse.Replace("[SUCCESS]", ""));

                // Variables.
                int hwidLimit = 0, hwidExpiration = 0, ipLimit = 0, ipExpiration = 0, ban = 0;

                // Iterates through each program node.
                foreach (XmlNode xmlNode in xmlDocument)
                {
                    foreach (XmlNode xmlLimitNode in xmlNode)
                    {
                        foreach (XmlNode xmlInformationNode in xmlLimitNode)
                        {
                            switch (xmlInformationNode.Name)
                            {
                                case "hwidlimit":
                                    hwidLimit = Convert.ToInt32(xmlInformationNode.InnerText);
                                    break;

                                case "hwidexpiration":
                                    hwidExpiration = Convert.ToInt32(xmlInformationNode.InnerText);
                                    break;

                                case "iplimit":
                                    ipLimit = Convert.ToInt32(xmlInformationNode.InnerText);
                                    break;

                                case "ipexpiration":
                                    ipExpiration = Convert.ToInt32(xmlInformationNode.InnerText);
                                    break;

                                case "ban":
                                    ban = Convert.ToInt32(xmlInformationNode.InnerText);
                                    break;
                            }
                        }

                        // TODO: Change all control invokes like this one to MainForm incase the user control is disposed before it is invoked.
                        ByteGuardInterface.Globals.Variables.Forms.Main.Invoke((MethodInvoker)delegate
                        {
                            // ReSharper disable AccessToModifiedClosure
                            HwidLimit.Value = hwidLimit;
                            HWidExpiration.Value = hwidExpiration;

                            IpLimit.Value = ipLimit;
                            IpExpiration.Value = ipExpiration;

                            BanLicenseIfLimitReached.Checked = (ban == 1);

                            ButtonSaveLockChanges.Enabled = false;
                        });
                    }
                }
            }
            else
            {
                ByteGuardInterface.Globals.Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR]", ""), 1);
            }
        }

        public static void SetLockLimits(object programid)
        {
            decimal hwidLimit = 0, hwidExpiration = 0, ipLimit = 0, ipExpiration = 0, ban = 0;

            SetLockLimitControls(false);

            ByteGuardInterface.Globals.Variables.Forms.Main.Invoke((MethodInvoker)delegate
            {
                hwidLimit = HwidLimit.Value;
                hwidExpiration = HWidExpiration.Value;

                ipLimit = IpLimit.Value;
                ipExpiration = IpExpiration.Value;

                ban = (BanLicenseIfLimitReached.Checked ? 1 : 0);
            });

            NameValueCollection dataValues = new NameValueCollection
            {
                {"pid", programid.ToString()},
                {"hwidlimit", hwidLimit.ToString(CultureInfo.InvariantCulture)},
                {"hwidexpiration", hwidExpiration.ToString(CultureInfo.InvariantCulture)},
                {"iplimit", ipLimit.ToString(CultureInfo.InvariantCulture)},
                {"ipexpiration", ipExpiration.ToString(CultureInfo.InvariantCulture)},
                {"ban", ban.ToString(CultureInfo.InvariantCulture)}
            };

            if (Network.SubmitData("setlocklimits", dataValues))
            {
                // Retrieves the web response.
                string webResponse = ByteGuardInterface.Globals.Variables.WebResponse;

                if (webResponse.Split('[', ']')[1] == "SUCCESS")
                {
                    SetLockLimitControls(true);
                    ByteGuardInterface.Globals.Variables.Containers.Main.SetStatus(webResponse.Replace("[SUCCESS] ", ""), 4);
                }
                else
                {
                    SetLockLimitControls(true);
                    ByteGuardInterface.Globals.Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR]", ""), 1);
                }
            }
        }

        private static void SetLockLimitControls(bool isEnabled)
        {
            ByteGuardInterface.Globals.Variables.Forms.Main.Invoke((MethodInvoker)delegate
            {
                HwidLimit.Enabled = isEnabled;
                HWidExpiration.Enabled = isEnabled;
                IpLimit.Enabled = isEnabled;
                IpExpiration.Enabled = isEnabled;
                BanLicenseIfLimitReached.Enabled = isEnabled;

                ButtonSaveLockChanges.Enabled = false;
            });
        }
    }
}
