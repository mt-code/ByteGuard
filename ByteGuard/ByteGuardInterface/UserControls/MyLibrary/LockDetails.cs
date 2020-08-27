using System;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Tasks;

namespace ByteGuard.ByteGuardInterface.UserControls.MyLibrary
{
    public partial class LockDetails : UserControl
    {
        private readonly Variables.ByteGuardProgram _byteguardProgram;

        public LockDetails(Variables.ByteGuardProgram byteguardProgram)
        {
            _byteguardProgram = byteguardProgram;

            InitializeComponent();
        }

        private void LockDetails_Load(object sender, EventArgs e)
        {
            Variables.Containers.Active.SetStatus("Retrieving lock details...", 3);

            Thread getLockDetailsThread = new Thread(GetLockDetails);
            getLockDetailsThread.Start();
        }

        private void GetLockDetails()
        {
            NameValueCollection dataValues = new NameValueCollection {{"lid", _byteguardProgram.Licenseid.ToString()}};

            if (Network.SubmitData("getlockdetails", dataValues))
                ProcessResponse();
            else
                Variables.Containers.Active.SetStatus("Failed to retrieve.", 1);
        }

        private void ProcessResponse()
        {
            string webResponse = Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                Form parentForm = ParentForm;

                // Loads the XML file ready to be parsed.
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(webResponse.Replace("[SUCCESS]", ""));

                // Iterates through each program node.
                foreach (XmlNode xmlNode in xmlDocument)
                {
                    foreach (XmlNode xmlLockNode in xmlNode)
                    {
                        foreach (XmlNode xmlInformationNode in xmlLockNode)
                        {
                            XmlNode node = xmlInformationNode;

                            Invoke((MethodInvoker)delegate
                            {
                                switch (node.Name)
                                {
                                    case "code":
                                        if (parentForm != null) parentForm.Text = String.Format("License ({0})", node.InnerText);
                                        break;

                                    case "banned":
                                        if (Convert.ToInt32(node.InnerText) == 1)
                                            TextBoxStatus.Text = "Banned";
                                        break;

                                    case "frozen":
                                        if (Convert.ToInt32(node.InnerText) == 1)
                                            TextBoxStatus.Text = "Frozen";
                                        break;

                                    case "time":
                                        Variables.Containers.Active.SetStatus(String.Format("Locked at: {0}", Methods.TimeStampToDate(Convert.ToInt32(node.InnerText))), 0);
                                        break;

                                    case "reason":
                                        TextBoxReason.Text = node.InnerText;
                                        break;
                                }
                            });
                        }
                    }
                }
            }
            else
            {
                // Failed to create account, display error.
                Variables.Containers.Active.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);
            }
        }

        private void ButtonBannedExplanation_Click(object sender, EventArgs e)
        {
            const string lockExplanation = "If your license has been banned, you will not be able to use the licensed program even if your license has not yet expired. Any remaining license duration you had will expire as originally intended before the ban was put in place.\n\nIf you wish to appeal, please contact the program creator.";

            MessageBox.Show(lockExplanation, "Banned Explanation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonFrozenExplanation_Click(object sender, EventArgs e)
        {
            const string lockExplanation = "If your license has been frozen, you will not be able to use the licensed program even if your license has not yet expired. Any remaining license duration you had will be returned to you when/if your license is unfrozen.\n\nWhen a license is frozen, it is usually to allow the program creator to apply updates that require downtime without you losing any of the license duration you have paid for.";

            MessageBox.Show(lockExplanation, "Frozen Explanation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
