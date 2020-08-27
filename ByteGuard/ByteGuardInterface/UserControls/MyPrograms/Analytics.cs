using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Globals;

namespace ByteGuard.ByteGuardInterface.UserControls.MyPrograms
{
    public partial class Analytics : UserControl
    {
        public Analytics()
        {
            InitializeComponent();
        }

        private void Analytics_Load(object sender, EventArgs e)
        {
            // Check the if the current program is marketplace registered/accepted.
            if (!Variables.MyProgramsSelected.MarketplaceFeePaid && Variables.MyProgramsSelected.DistributionModel != 1)
            {
                lblMarketplaceOnly.Visible = true;
                btnViewAnalytics.Enabled = false;
            }
        }

        private void btnViewAnalytics_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(
                () => Tasks.Network.StartAutoLoginUrl("http://www.byteguardsoftware.co.uk/profile?area=stats"));
        }
    }
}
