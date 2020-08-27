using System;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Tasks;

namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    public partial class AddVariable : UserControl
    {
        private delegate void SetControlsDelegate(bool isEnabled);

        public AddVariable()
        {
            InitializeComponent();
        }

        private void ButtonAddVariable_Click(object sender, EventArgs e)
        {
            if (TextBoxKey.TextLength <= 0 || TextBoxKey.TextLength > 25)
            {
                ThemeContainer.SetStatus("Invalid key length.", 1);
                return;
            }

            if (TextBoxValue.TextLength <= 0 || TextBoxValue.TextLength > 255)
            {
                ThemeContainer.SetStatus("Invalid value length.", 1);
                return;
            }

            SetControls(false);

            Thread addVariableThread = new Thread(AddVariableThreaded);
            addVariableThread.Start();
        }

        private void AddVariableThreaded()
        {
            string variableKey = "", variableValue = "";

            Invoke((MethodInvoker) delegate
            {
                variableKey = TextBoxKey.Text;
                variableValue = TextBoxValue.Text;
            });

            NameValueCollection dataValues = new NameValueCollection
            {
                {"pid", Variables.MyProgramsSelected.Programid},
                {"k", variableKey},
                {"v", variableValue}
            };

            if (Network.SubmitData("addvariable", dataValues))
                ProcessResponse();
            else
                SetControls(true);
        }

        private void ProcessResponse()
        {
            string webResponse = Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                ThemeContainer.SetStatus(webResponse.Replace("[SUCCESS]", String.Empty), 4);

                SetControls(true);

                Tasks.Licensing.Variables.GetVariables(
                    Variables.MyProgramsSelected.Programid);
            }
            else
            {
                ThemeContainer.SetStatus(webResponse.Replace("[ERROR]", String.Empty), 1);
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
                TextBoxKey.Enabled = isEnabled;
                TextBoxValue.Enabled = isEnabled;
                ButtonAddVariable.Enabled = isEnabled;

                if (isEnabled)
                {
                    TextBoxKey.Clear();
                    TextBoxValue.Clear();
                }
            }
        }

        private void TextBoxKey_TextChanged(object sender, EventArgs e)
        {
            LabelKey.Text = String.Format("Key ({0}/25):", TextBoxKey.TextLength);
        }

        private void TextBoxValue_TextChanged(object sender, EventArgs e)
        {
            LabelValue.Text = String.Format("Value ({0}/255):", TextBoxValue.TextLength);
        }
    }
}