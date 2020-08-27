using System.Drawing;
using System.Windows.Forms;

namespace ByteGuard.ByteGuardInterface.Theme
{
    sealed class TabControlTop : TabControl
    {
        public TabControlTop()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(150, 45);
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}
