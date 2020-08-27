using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Forms;
using ByteGuard.ByteGuardInterface.UserControls.Other;

namespace ByteGuard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // TODO: Enable this.
            /*if (args.Length <= 0)
            {
                Process.Start("ByteGuard.Updater.exe");
            }
            else
            {
                if (args[0] == "true")
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new BlankForm(new Login(false), true));
                }
            }*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BlankForm(new Login(false), true));
        }
    }
}
