using System;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ByteGuard.ByteGuardInterface.Globals;

namespace ByteGuard.Tasks.Licensing
{
    /* ByteGuardLicense
     * 
     * Programid
     * LicenseCode
     * LicenseValue (Duration/Points)
     * CreationDate
     * RedeemedDate
     * RedeemedTo
     * ExpirationDate
     * LicenseType (Duration/Points)
     * TrackingDescription
     * IsBanned
     * BannedTime
     * BanReason
     * IsFrozen
     * FrozenTime
     * FreezeReason
     */

    class Licenses
    {
        private static bool _isFirstTime = true;

        public static void Initialize()
        {
            _isFirstTime = true;
        }

        public static bool IsAdmin { get; set; }

        public static ListView ListViewLicenses { get; set; }

        public static Label LicensesRemaining { get; set; }

        public static Button CreateLicenseButton { get; set; }

        public static void GetLicenses(string programid)
        {
            NameValueCollection dataValues = new NameValueCollection {{"pid", programid}};

            if (Network.SubmitData("getlicenses", dataValues))
                LoadLicenses();
        }

        private static void LoadLicenses()
        {
            // Retrieves the web response.
            string webResponse = ByteGuardInterface.Globals.Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                // Got the list of licenses successfully, parse the response.
                ByteGuardInterface.Globals.Variables.MyLicenses.Clear();

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ByteGuardInterface.Globals.Variables.WebResponse.Replace("[SUCCESS]", ""));

                // Iterates through each program node.
                foreach (XmlNode xmlNode in xmlDocument)
                {
                    foreach (XmlNode xmlLicenseNode in xmlNode)
                    {
                        ByteGuardInterface.Globals.Variables.ByteGuardLicense byteguardLicense = new ByteGuardInterface.Globals.Variables.ByteGuardLicense();

                        foreach (XmlNode xmlInformationNode in xmlLicenseNode)
                        {
                            switch (xmlInformationNode.Name)
                            {
                                case "programid":
                                    byteguardLicense.Programid = xmlInformationNode.InnerText;
                                    break;

                                case "code":
                                    byteguardLicense.LicenseCode = xmlInformationNode.InnerText;
                                    break;

                                case "value":
                                    byteguardLicense.LicenseValue = xmlInformationNode.InnerText;
                                    break;

                                case "creationtime":
                                    byteguardLicense.CreationTime = xmlInformationNode.InnerText;
                                    break;

                                case "redeemedtime":
                                    byteguardLicense.RedeemedTime = xmlInformationNode.InnerText;
                                    break;

                                case "redeemedusername":
                                    byteguardLicense.RedeemedTo = xmlInformationNode.InnerText;
                                    break;

                                case "expiration":
                                    byteguardLicense.ExpirationTime = xmlInformationNode.InnerText;
                                    break;

                                case "type":
                                    byteguardLicense.LicenseType = Convert.ToInt32(xmlInformationNode.InnerText);
                                    break;

                                case "description":
                                    byteguardLicense.TrackingDescription = xmlInformationNode.InnerText;
                                    break;

                                case "banned":
                                    byteguardLicense.IsBanned =
                                        (Convert.ToInt32(xmlInformationNode.InnerText) == 1);
                                    break;

                                case "locktime":
                                    byteguardLicense.LockTime = Convert.ToInt32(xmlInformationNode.InnerText);
                                    break;

                                case "lockreason":
                                    byteguardLicense.LockReason = xmlInformationNode.InnerText;
                                    break;

                                case "frozen":
                                    byteguardLicense.IsFrozen =
                                        (Convert.ToInt32(xmlInformationNode.InnerText) == 1);
                                    break;

                                case "mplicense":
                                    byteguardLicense.MarketplaceLicense =
                                        (Convert.ToInt32(xmlInformationNode.InnerText) == 1);
                                    break;
                            }
                        }

                        ByteGuardInterface.Globals.Variables.MyLicenses.Add(byteguardLicense);
                    }
                }

                if (ByteGuardInterface.Globals.Variables.MyLicenses.Count != 0)
                    DisplayLicenses();
                else
                {
                    try
                    {
                        CreateLicenseButton.Invoke((MethodInvoker) delegate
                        {
                            CreateLicenseButton.Enabled = true;
                        });
                    }
                    catch
                    {
                        // IsDisposed.
                    }

                    ByteGuardInterface.Globals.Variables.Containers.Main.SetStatus("Create and manage your programs.", 3);
                }
            }
            else
            {
                ByteGuardInterface.Globals.Variables.Containers.Main.SetStatus(ByteGuardInterface.Globals.Variables.WebResponse.Replace("[ERROR]", ""), 1);
            }
        }

        private static void DisplayLicenses()
        {
            ByteGuardInterface.Globals.Variables.Forms.Main.Invoke((MethodInvoker)delegate
            {
                ListViewLicenses.Items.Clear();
            });

            foreach (ByteGuardInterface.Globals.Variables.ByteGuardLicense byteguardLicense in ByteGuardInterface.Globals.Variables.MyLicenses)
            {
                // TODO: Undo multi-threaded adding as it can cause the listview indexes to become incorrect.
                //Thread tAddLicense = new Thread(AddLicenseToListview);
                //tAddLicense.Start(byteguardLicense);
                AddLicenseToListview(byteguardLicense);
            }

            try
            {
                if (!_isFirstTime)
                {
                    if (IsAdmin)
                        ByteGuardInterface.Globals.Variables.Users.ProgramOwner = Methods.DownloadUserData(ByteGuardInterface.Globals.Variables.Users.ProgramOwner.Username);
                    else
                        ByteGuardInterface.Globals.Variables.Users.Current = Methods.DownloadUserData(ByteGuardInterface.Globals.Variables.Users.Current.Username);

                    CreateLicenseButton.Invoke((MethodInvoker)delegate
                    {
                        // Show how many licenses the users account has remaining.
                        LicensesRemaining.Text = (IsAdmin ? String.Format("This program can create {0} more license(s).", ByteGuardInterface.Globals.Variables.Users.ProgramOwner.LicensesRemaining) : String.Format("Your account can create {0} more license(s).", ByteGuardInterface.Globals.Variables.Users.Current.LicensesRemaining));

                        CreateLicenseButton.Enabled = (IsAdmin ? (ByteGuardInterface.Globals.Variables.Users.ProgramOwner.LicensesRemaining > 0) : (ByteGuardInterface.Globals.Variables.Users.Current.LicensesRemaining > 0));
                    });
                }
                else
                {
                    _isFirstTime = false;

                    CreateLicenseButton.Invoke((MethodInvoker)delegate
                    {
                        CreateLicenseButton.Enabled = (IsAdmin ? (ByteGuardInterface.Globals.Variables.Users.ProgramOwner.LicensesRemaining > 0) : (ByteGuardInterface.Globals.Variables.Users.Current.LicensesRemaining > 0));
                    });
                }
            }
            catch
            {
                // IsDisposed.
            }

            ByteGuardInterface.Globals.Variables.Containers.Main.SetStatus(
                ByteGuardInterface.Globals.Variables.Users.Current.LicensesRemaining == 0
                    ? "Manage your program licenses. (You have reached your license limit, please buy more on your account page)"
                    : "Create and manage your programs.", 3);
        }

        private static void AddLicenseToListview(object bgLicense)
        {
            ByteGuardInterface.Globals.Variables.ByteGuardLicense byteguardLicense = (ByteGuardInterface.Globals.Variables.ByteGuardLicense)bgLicense;
            ListViewItem listviewItem = new ListViewItem(byteguardLicense.RedeemedTo);

            // LicenseCode
            listviewItem.SubItems.Add(byteguardLicense.LicenseCode);

            if (byteguardLicense.MarketplaceLicense)
                listviewItem.SubItems[0].ForeColor = System.Drawing.Color.FromArgb(40, 95, 125);

            // IsBanned
            if (byteguardLicense.IsBanned || byteguardLicense.IsFrozen)
                listviewItem.SubItems.Add("True");
            else
                listviewItem.SubItems.Add("False");

            if (byteguardLicense.LicenseType == 0) // If LicenseType = Duration.
            {
                listviewItem.SubItems.Add("Duration");

                /*/ LicenseValue
                if (ByteguardLicense.LicenseValue == "0")
                {
                    LVI.SubItems.Add("0");
                }
                else
                {*/
                listviewItem.SubItems.Add(byteguardLicense.LicenseValue);

                if (byteguardLicense.IsFrozen)
                {
                    // Banned.
                    listviewItem.SubItems.Add("Frozen");
                }
                else if (byteguardLicense.IsBanned)
                {
                    // Frozen.
                    listviewItem.SubItems.Add("Banned");
                }
                else if (byteguardLicense.LicenseValue == "0")
                {
                    listviewItem.SubItems.Add("Never");
                }
                else if (byteguardLicense.ExpirationTime == "-1")
                {
                    // Unredeemed.
                    listviewItem.SubItems.Add("Not Redeemed");
                }
                else
                {
                    // Redeemed.
                    listviewItem.SubItems.Add(Methods.TimeStampToDate(Convert.ToDouble(byteguardLicense.ExpirationTime)));
                }
            }
            else
            {
                listviewItem.SubItems.Add("Points");
                listviewItem.SubItems.Add(byteguardLicense.LicenseValue);
                listviewItem.SubItems.Add("N/A");
            }

            ByteGuardInterface.Globals.Variables.Forms.Main.Invoke((MethodInvoker)delegate
            {
                ListViewLicenses.Items.Add(listviewItem);
            });
        }
    }
}
