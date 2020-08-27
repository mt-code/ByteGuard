using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Timers;
using System.Windows.Forms;
using ByteGuard.Properties;
using Timer = System.Timers.Timer;

namespace ByteGuard.ByteGuardInterface.Theme
{
    public sealed class ThemeContainer : ContainerControl
    {
        private int _imageCode;
        private bool _isError;
        private bool _isSuccess;
        private string _statusText = String.Empty;
        private readonly Timer _t = new Timer(500);

        public ThemeContainer()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            DoubleBuffered = true;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Dock = DockStyle.Fill;

            _t.Elapsed += Repaint;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Bitmap bMap = new Bitmap(Width, Height))
            {
                using (Graphics gfx = Graphics.FromImage(bMap))
                {
                    // Pens.
                    Pen pLightBlue = new Pen(new SolidBrush(Color.FromArgb(137, 195, 217)));

                    // Brushes.
                    Brush bGrey = new SolidBrush(Color.FromArgb(220, 220, 220));
                    Brush bGreyGradient = new LinearGradientBrush(new Point(0, 0), new Point(0, 90), Color.FromArgb(165, 165, 165), Color.White);

                    // Fonts.
                    Font statusFont = new Font("Verdana", 7);

                    // Background Gradient
                    Rectangle themeHeader = new Rectangle(0, 0, Width, 50);
                    Rectangle themeFooter = new Rectangle(0, Height - 35, Width, 35);

                    // *** HEADER **
                    // Header gradient.
                    gfx.FillRectangle(bGreyGradient, themeHeader);

                    // Header separator.
                    gfx.DrawLine(pLightBlue, new Point(0, 50), new Point(Width, 50));

                    // Header image.
                    gfx.DrawImage(Resources.ByteGuardHeaderImage, 0, 1, 185, 48);

                    // *** FOOTER ***
                    // Footer fill.
                    if (_isError)
                    {
                        gfx.FillRectangle(Brushes.IndianRed, themeFooter);

                        _isError = false;
                        _t.Start();
                    }
                    else if (_isSuccess)
                    {
                        gfx.FillRectangle(Brushes.LawnGreen, themeFooter);

                        _isSuccess = false;
                        _t.Start();
                    }
                    else
                    {
                        gfx.FillRectangle(bGrey, themeFooter);
                    }

                    // Footer line/highlight.
                    gfx.DrawLine(Pens.DarkGray, new Point(0, Height - 35), new Point(Width, Height - 35));
                    gfx.DrawLine(Pens.White, new Point(0, Height - 34), new Point(Width, Height - 34));

                    switch (_imageCode)
                    {
                        // No Image.
                        case 0:
                            gfx.DrawString(_statusText, statusFont, Brushes.Black, new PointF(10, Height - 23));
                            break;

                        // Warning Image.
                        case 1:
                            gfx.DrawImage(Resources.StatusWarning, 15, Height - 25, 16, 16);
                            gfx.DrawString(_statusText, statusFont, Brushes.Black, new PointF(40, Height - 23));
                            break;

                        // Question Image.
                        case 2:
                            gfx.DrawImage(Resources.StatusQuestion, 15, Height - 25, 16, 16);
                            gfx.DrawString(_statusText, statusFont, Brushes.Black, new PointF(40, Height - 23));
                            break;

                        // Information Image.
                        case 3:
                            gfx.DrawImage(Resources.StatusInformation, 15, Height - 25, 16, 16);
                            gfx.DrawString(_statusText, statusFont, Brushes.Black, new PointF(40, Height - 23));
                            break;

                        // Success Image.
                        case 4:
                            gfx.DrawImage(Resources.StatusTick, 15, Height - 25, 16, 16);
                            gfx.DrawString(_statusText, statusFont, Brushes.Black, new PointF(40, Height - 23));
                            break;
                    }

                    base.OnPaint(e);
                    e.Graphics.DrawImage(bMap, 0, 0);
                }
            }
        }

        /// <summary>
        /// Displays text (and an image is requested) in the theme footer.
        /// </summary>
        /// <param name="statusText">The text to display.</param>
        /// <param name="imageCode">0 = None, 1 = Warning, 2 = Question, 3 = Information, 4 = Success</param>
        public void SetStatus(string statusText, int imageCode)
        {
            _statusText = statusText;

            if ((_imageCode = imageCode) == 1)
                _isError = true;

            else if ((_imageCode = imageCode) == 4)
                _isSuccess = true;

            if (!IsDisposed)
                Invoke((MethodInvoker)Refresh);
        }

        public void ForceRedraw()
        {
            Refresh();
        }

        private void Repaint(object sender, ElapsedEventArgs e)
        {
            _t.Stop();

            if (!IsDisposed)
                Invoke((MethodInvoker)Refresh);
        }
    }
}
