using System;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;
using ByteGuard.Tasks;
using ByteGuard.Tasks.Licensing;
using Variables = ByteGuard.ByteGuardInterface.Globals.Variables;

namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    public partial class AddAdmin : UserControl
    {
        private delegate void SetControlsDelegate(bool isEnabled);

        public AddAdmin()
        {
            InitializeComponent();
        }

        private void ButtonAddAdmin_Click(object sender, EventArgs e)
        {
            if (TextBoxEmail.TextLength <= 0)
            {
                Variables.Containers.Main.SetStatus("You have entered an invalid email address.", 1);
                return;
            }

            SetControls(false);

            Thread addAdminThread = new Thread(AddAdminThreaded);
            addAdminThread.Start();
        }

        private void AddAdminThreaded()
        {
            string adminEmail = "";

            Invoke((MethodInvoker) delegate { adminEmail = TextBoxEmail.Text; });

            NameValueCollection dataValues = new NameValueCollection
            {
                {"pid", Variables.MyProgramsSelected.Programid},
                {"a", adminEmail}
            };

            if (Network.SubmitData("addadmin", dataValues))
            {
                ProcessResponse();
            }
            else
            {
                SetControls(true);
            }
        }

        private void ProcessResponse()
        {
            string webResponse = Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                Variables.Containers.Main.SetStatus(webResponse.Replace("[SUCCESS]", String.Empty), 4);

                SetControls(true);

                Programs.GetAdministrators(Variables.MyProgramsSelected.Programid);
            }
            else
            {
                Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR]", String.Empty), 1);
                SetControls(true);
            }
        }

        private void SetControls(bool isEnabled)
        {
            if (InvokeRequired)
            {
                Invoke(new SetControlsDelegate(SetControls), isEnabled);
            }
            else
            {
                TextBoxEmail.Enabled = isEnabled;
                ButtonAddAdmin.Enabled = isEnabled;

                if (isEnabled)
                    TextBoxEmail.Clear();
            }
        }
    }
}