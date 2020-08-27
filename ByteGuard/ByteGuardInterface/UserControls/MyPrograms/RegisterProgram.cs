using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Globals;

//http://gjsdesign.com/byteguard/register-program?program_id=EE9282E1&model=1&login_id=f5b939297011b1a40036db2f8d916181&login_user=3
namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    public partial class RegisterProgram : UserControl
    {
        public RegisterProgram()
        {
            InitializeComponent();
        }

        private void RegisterProgram_Load(object sender, EventArgs e)
        {
            if (!Variables.Users.Current.FreeRegistrationUsed)
            {
                // Free registration has not yet been used.
                lblFreeTrial.Visible = true;
                btnRegisterSelf.Text = "Select Self Distribution (£2.50 or FREE)";
            }
        }

        private void btnRegisterSelf_Click(object sender, EventArgs e)
        {
            string url = String.Format("http://www.byteguardsoftware.co.uk/register-program?program_id={0}&model=2", Variables.MyProgramsSelected.Programid);

            Task.Factory.StartNew(() => Tasks.Network.StartAutoLoginUrl(url));
        }

        private void btnRegisterMarketplace_Click(object sender, EventArgs e)
        {
            string url = String.Format("http://www.byteguardsoftware.co.uk/register-program?program_id={0}&model=1", Variables.MyProgramsSelected.Programid);

            Task.Factory.StartNew(() => Tasks.Network.StartAutoLoginUrl(url));
        }

        private void tbDistributionModelInformation_MouseUp(object sender, MouseEventArgs e)
        {
            tbDistributionModelInformation.DeselectAll();
            ActiveControl = null;
        }

        private void tbSelfDistributionInfo_MouseUp(object sender, MouseEventArgs e)
        {
            tbSelfDistributionInfo.DeselectAll();
            ActiveControl = null;
        }

        private void tbMarketplaceInfo_MouseUp(object sender, MouseEventArgs e)
        {
            tbMarketplaceInfo.DeselectAll();
            ActiveControl = null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Parent.Controls.Add(Variables.UserControls.MyProgramsDefault);
            Parent.Controls.Remove(this);
        }

        private void linkSelfDistribution_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.byteguardsoftware.co.uk/blog/self-distribution-explained");
        }
    }
}
