using System;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;

namespace ByteGuard.ByteGuardInterface.UserControls.MyLibrary
{
    public partial class MarketplaceApplication : UserControl
    {
        private delegate void SetControlsDelegate(bool isEnabled);

        public MarketplaceApplication()
        {
            InitializeComponent();
        }

        private void tbMarketplaceInformation_MouseUp(object sender, MouseEventArgs e)
        {
            tbMarketplaceInformation.DeselectAll();
            ActiveControl = null;
        }
    }
}
