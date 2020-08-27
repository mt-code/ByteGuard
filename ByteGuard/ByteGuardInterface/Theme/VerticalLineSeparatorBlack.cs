using System.Drawing;
using System.Windows.Forms;

namespace ByteGuard.ByteGuardInterface.Theme
{
    public sealed partial class VerticalLineSeparatorBlack : UserControl
    {
        public VerticalLineSeparatorBlack()
        {
            Paint += VerticalLineSeparatorBlack_Paint;

            MaximumSize = new Size(2, 2000);
            MinimumSize = new Size(2, 2);
            Height = 350;
        }

        private void VerticalLineSeparatorBlack_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(Pens.Black, new Point(0, 0), new Point(0, Height));
        }
    }
}
