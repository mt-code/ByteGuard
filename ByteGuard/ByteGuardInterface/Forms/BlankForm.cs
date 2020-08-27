using System.Drawing;
using System.Windows.Forms;
using ByteGuard.Properties;

namespace ByteGuard.ByteGuardInterface.Forms
{
    public partial class BlankForm : Form
    {
        public BlankForm(UserControl usercontrolToAdd, bool isToolWindow)
        {
            InitializeComponent();

            Icon = Resources.ByteGuardIcon;

            Size = new Size(usercontrolToAdd.Size.Width, usercontrolToAdd.Size.Height);

            Controls.Add(usercontrolToAdd);

            FormBorderStyle = isToolWindow
                ? FormBorderStyle.FixedToolWindow
                : FormBorderStyle.FixedSingle;
        }
    }
}
