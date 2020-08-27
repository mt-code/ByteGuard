using System.Drawing;
using System.Windows.Forms;

namespace ByteGuard.ByteGuardInterface.Theme
{
    sealed class VerticalLineSeparator : UserControl
    {
        public VerticalLineSeparator()
        {
            Paint += VerticalLineSeparator_Paint;

            MaximumSize = new Size(2, 2000);
            MinimumSize = new Size(2, 2);
            Height = 350;
        }
        
        private void VerticalLineSeparator_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(Pens.DarkGray, new Point(0, 0), new Point(0, Height));
            g.DrawLine(Pens.White, new Point(1, 0), new Point(1, Height));
        }
    }
}
