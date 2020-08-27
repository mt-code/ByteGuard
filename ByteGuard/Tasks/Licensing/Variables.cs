using System;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Xml;
using ByteGuard.ByteGuardInterface.Globals;

namespace ByteGuard.Tasks.Licensing
{
    class Variables
    {
        private static bool _isFirstTime = true;

        public static void Initialize()
        {
            _isFirstTime = true;
        }

        public static bool IsAdmin { get; set; }

        public static ListView ListViewVariables { get; set; }

        public static Label VariablesRemaining { get; set; }

        public static Button CreateVariableButton { get; set; }

        public static void GetVariables(string programid)
        {
            NameValueCollection dataValues = new NameValueCollection {{"pid", programid}};

            if (Network.SubmitData("getvariables", dataValues))
                LoadVariables();
        }

        private static void LoadVariables()
        {
            // Retrieves the web response.
            string webResponse = ByteGuardInterface.Globals.Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                // Got the list of licenses successfully, parse the response.
                ByteGuardInterface.Globals.Variables.MyVariables.Clear();

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ByteGuardInterface.Globals.Variables.WebResponse.Replace("[SUCCESS]", ""));

                // Variables.
                string variableKey = "", variableValue = "";

                // Iterates through each program node.
                foreach (XmlNode xmlNode in xmlDocument)
                {
                    foreach (XmlNode xmlVariableNode in xmlNode)
                    {
                        foreach (XmlNode xmlInformationNode in xmlVariableNode)
                        {
                            switch (xmlInformationNode.Name)
                            {
                                case "key":
                                    variableKey = xmlInformationNode.InnerText;
                                    break;

                                case "value":
                                    variableValue = xmlInformationNode.InnerText;
                                    break;
                            }
                        }

                        ByteGuardInterface.Globals.Variables.MyVariables.Add(variableKey, variableValue);
                    }
                }

                DisplayVariables();
            }
            else
            {
                ByteGuardInterface.Globals.Variables.Containers.Main.SetStatus(ByteGuardInterface.Globals.Variables.WebResponse.Replace("[ERROR]", ""), 1);
            }
        }

        private static void DisplayVariables()
        {
            try
            {
                ListViewVariables.Invoke((MethodInvoker) delegate
                {
                    ListViewVariables.Items.Clear();
                });

                // TODO: Multi-thread adding to listbox.
                foreach (var dictionaryItem in ByteGuardInterface.Globals.Variables.MyVariables)
                {
                    ListViewItem listviewItem = new ListViewItem(dictionaryItem.Key);
                    listviewItem.SubItems.Add(dictionaryItem.Value);

                    ListViewVariables.Invoke((MethodInvoker) delegate
                    {
                        ListViewVariables.Items.Add(listviewItem);
                    });
                }

                if (!_isFirstTime)
                {
                    if (IsAdmin)
                        ByteGuardInterface.Globals.Variables.Users.ProgramOwner = Methods.DownloadUserData(ByteGuardInterface.Globals.Variables.Users.ProgramOwner.Username);
                    else
                        ByteGuardInterface.Globals.Variables.Users.Current = Methods.DownloadUserData(ByteGuardInterface.Globals.Variables.Users.Current.Username);

                    VariablesRemaining.Invoke((MethodInvoker)delegate
                    {
                        // Show how many licenses the users account has remaining.
                        VariablesRemaining.Text = (IsAdmin ? String.Format("This program can support {0} more variable(s).", ByteGuardInterface.Globals.Variables.Users.ProgramOwner.VariablesRemaining) : String.Format("Your account can support {0} more variable(s).", ByteGuardInterface.Globals.Variables.Users.Current.VariablesRemaining));

                        CreateVariableButton.Enabled = (IsAdmin ? (ByteGuardInterface.Globals.Variables.Users.ProgramOwner.VariablesRemaining > 0) : (ByteGuardInterface.Globals.Variables.Users.Current.VariablesRemaining > 0));
                    });
                }
                else
                {
                    _isFirstTime = false;

                    CreateVariableButton.Invoke((MethodInvoker)delegate
                    {
                        CreateVariableButton.Enabled = (IsAdmin
                            ? (ByteGuardInterface.Globals.Variables.Users.ProgramOwner.VariablesRemaining > 0)
                            : (ByteGuardInterface.Globals.Variables.Users.Current.VariablesRemaining > 0));
                    });
                }
            }
            catch
            {
                // IsDisposed
            }
        }

    }
}
