using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ByteGuard.ByteGuardInterface.Theme
{
    internal sealed class TabControlLeft : TabControl
    {
        private int _hoveredTabIndex;

        public TabControlLeft()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(30, 135);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            Alignment = TabAlignment.Left;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Rectangle mouseRect = new Rectangle(e.X, e.Y, 1, 1);
            for (int i = 0; i < TabCount; i++)
            {
                if (GetTabRect(i).IntersectsWith(mouseRect))
                {
                    _hoveredTabIndex = i;
                    Invalidate();
                    break;
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            _hoveredTabIndex = TabCount + 1;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Bitmap bMap = new Bitmap(Width, Height))
            {
                using (Graphics gfx = Graphics.FromImage(bMap))
                {
                    gfx.SmoothingMode = SmoothingMode.AntiAlias;

                    // Pens.
                    Pen pLightBlue = new Pen(new SolidBrush(Color.FromArgb(114, 201, 229)));
                    Pen pDarkBlue = new Pen(new SolidBrush(Color.FromArgb(31, 48, 63)));

                    // Brushes.
                    Brush bGreyGradient = new LinearGradientBrush(new Point(0, 0), new Point(0, 30),
                        Color.FromArgb(200, 200, 200), Color.FromArgb(240, 240, 240));
                    Brush textBrush = new SolidBrush(Color.FromArgb(75, 75, 75));
                    Brush polygonBrush = new SolidBrush(Color.FromArgb(91, 183, 223));
                    Brush textBrushDark = new SolidBrush(Color.FromArgb(31, 48, 63));

                    for (int i = 0; i <= TabCount - 1; i++)
                    {
                        Rectangle tabRect = GetTabRect(i);

                        tabRect.Width = 120;
                        tabRect.Height = 25;

                        StringFormat sFormat = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };

                        if (SelectedIndex == i)
                        {
                            // Selected Tab
                            DrawRoundedRectangle(gfx, tabRect, 15, pDarkBlue, bGreyGradient);
                            gfx.DrawString(TabPages[i].Text, Font, textBrushDark, tabRect, sFormat);

                            // Draws blue triangle.
                            Point[] p =
                            {
                                new Point(tabRect.Width + 5, 15 + (30*i)), new Point(135, (30*i)),
                                new Point(135, 30 + (30*i))
                            };
                            gfx.FillPolygon(polygonBrush, p);
                            //GFX.DrawPolygon(Pens.DarkGray, p);
                            gfx.DrawPolygon(pDarkBlue, p);

                        }
                        else if (_hoveredTabIndex == i)
                        {
                            // Hovering Tab.
                            tabRect.X = tabRect.X + 5;
                            DrawRoundedRectangle(gfx, tabRect, 15, pLightBlue, bGreyGradient);
                            gfx.DrawString(TabPages[i].Text, Font, textBrushDark, tabRect, sFormat);
                        }
                        else
                        {
                            // Non Selected.
                            DrawRoundedRectangle(gfx, tabRect, 15, Pens.DarkGray, bGreyGradient);
                            gfx.DrawString(TabPages[i].Text, Font, textBrush, tabRect, sFormat);
                        }
                    }

                    // Draws tab/tabpage seperator line.
                    //Rectangle ATabRect = GetTabRect(0);
                    gfx.DrawLine(pLightBlue, new Point(2 + ItemSize.Height, 0),
                        new Point(2 + ItemSize.Height, Height));

                    base.OnPaint(e);

                    e.Graphics.DrawImage(bMap, 0, 0);
                }
            }
        }

        private void DrawRoundedRectangle(Graphics gfx, Rectangle rectBounds, int cornerRadius, Pen drawPen,
            Brush fillColour)
        {
            GraphicsPath gPath = new GraphicsPath();
            gPath.AddArc(rectBounds.X, rectBounds.Y, cornerRadius, cornerRadius, 180, 90);
            gPath.AddArc(rectBounds.X + rectBounds.Width - cornerRadius, rectBounds.Y, cornerRadius, cornerRadius, 270, 90);
            gPath.AddArc(rectBounds.X + rectBounds.Width - cornerRadius, rectBounds.Y + rectBounds.Height - cornerRadius, cornerRadius,
                cornerRadius, 0, 90);
            gPath.AddArc(rectBounds.X, rectBounds.Y + rectBounds.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            gPath.CloseAllFigures();

            gfx.FillPath(fillColour, gPath);
            gfx.DrawPath(drawPen, gPath);
        }
    }
}