using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Tasks;

// TODO: Substring email label.
namespace ByteGuard.ByteGuardInterface.UserControls.MyLibrary
{
    public partial class ViewProfile : UserControl
    {
        private readonly string _username;
        private readonly string _avatarPath = Path.Combine(Path.GetTempPath(), "byteguardavatar.png");

        public ViewProfile(string username)
        {
            _username = username;

            InitializeComponent();

            Variables.Containers.Active = ThemeContainer;
        }

        private void ViewProfile_Load(object sender, EventArgs e)
        {
            ThemeContainer.SetStatus("Loading profile, please wait...", 3);

            Thread loadProfileThread = new Thread(LoadProfile);
            loadProfileThread.Start();
        }

        private void LoadProfile()
        {
            NameValueCollection dataValues = new NameValueCollection {{"u", _username}};

            if (Network.SubmitData("getprofile", dataValues))
            {
                ProcessResponse();
            }
            else
            {
                ThemeContainer.SetStatus("Failed to load profile.", 1);
            }
        }

        private void ProcessResponse()
        {
            string webResponse = Variables.WebResponse;
            bool hasAvatar = false;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                Form parentForm = ParentForm;

                // Loads the XML file ready to be parsed.
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(webResponse.Replace("[SUCCESS]", ""));

                // Iterates through each program node.
                foreach (XmlNode xmlInformationNode in xmlDocument.Cast<XmlNode>().SelectMany(xmlNode => xmlNode.Cast<XmlNode>().SelectMany(xmlUserNode => xmlUserNode.Cast<XmlNode>())))
                {
                    XmlNode node = xmlInformationNode;

                    try
                    {
                        Invoke((MethodInvoker) delegate
                        {
                            switch (node.Name)
                            {
                                case "email":
                                    LabelEmailAddress.Text = node.InnerText;
                                    break;

                                case "username":
                                    LabelUsername.Text = node.InnerText;
                                    if (parentForm != null)
                                        parentForm.Text = String.Format("ByteGuard - {0}'s profile", node.InnerText);
                                    break;

                                case "registeredtime":
                                    LabelRegistrationDate.Text = Methods.TimeStampToDate(Convert.ToInt32(node.InnerText));
                                    break;

                                case "lastaction":
                                    LabelLastOnline.Text = Methods.TimeStampToDate(Convert.ToInt32(node.InnerText));
                                    break;

                                // TODO: Show the user is verified/activated.
                                case "isactivated":
                                    break;

                                case "description":
                                    TextBoxUserDescription.Text = node.InnerText;
                                    break;

                                // TODO: Do something!
                                case "hasavatar":
                                    hasAvatar = (Convert.ToInt32(node.InnerText) == 1);
                                    break;
                            }
                        });
                    }
                    catch
                    {
                        // Catches error if controls are disposed.
                    }
                }

                if (hasAvatar)
                {
                    Thread downloadAvatarThreaded = new Thread(DownloadAvatar);
                    downloadAvatarThreaded.Start(_avatarPath);
                }

                Invoke((MethodInvoker)delegate
                {
                    ButtonAddReputation.Enabled = true;
                    ButtonSendMessage.Enabled = true;
                });

                ThemeContainer.SetStatus("Send the user a message or add to their reputation.", 3);
            }
            else
            {
                // Failed to create account, display error.
                ThemeContainer.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);
            }
        }

        private void DownloadAvatar(object imageLocation)
        {
            ThemeContainer.SetStatus("Downloading profile image...", 3);

            if (Methods.DownloadAvatar(_username, imageLocation.ToString()))
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        PictureBoxProfileImage.ImageLocation = imageLocation.ToString();
                    });
                }
                catch
                {
                    // If control is disposed, catches any errors.
                }

                ThemeContainer.SetStatus("Send the user a message or add to their reputation.", 3);
            }
            else
            {
                ThemeContainer.SetStatus("There was an error downloading the profile avatar.", 1);
            }
        }
    }
}
