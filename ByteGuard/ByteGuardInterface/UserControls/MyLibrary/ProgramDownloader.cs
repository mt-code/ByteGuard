using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Globals;

namespace ByteGuard.ByteGuardInterface.UserControls.MyLibrary
{
    public partial class ProgramDownloader : UserControl
    {
        private readonly Variables.ByteGuardProgram _programToDownload;

        public ProgramDownloader(Variables.ByteGuardProgram programToDownload)
        {
            InitializeComponent();

            _programToDownload = programToDownload;
        }

        private void ProgramDownloader_Load(object sender, EventArgs e)
        {
            CreateFolderStructure();

            Task.Factory.StartNew(DownloadProgram);
        }

        private void DownloadProgram()
        {
            string installLocation = String.Format("MyLibrary/{0}/Compressed.zip", _programToDownload.Programid);

            Tasks.Network.DownloadFileAsync(installLocation, DownloadProgress, DownloadCompleted,
                _programToDownload.Programid);
        }

        private void CreateFolderStructure()
        {
            string directoryPath = String.Format("MyLibrary/{0}/Raw", _programToDownload.Programid);

            if (Directory.Exists(directoryPath))
                Directory.Delete(directoryPath, true);
            
            Directory.CreateDirectory(directoryPath);
        }

        private void DownloadProgress(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            Invoke((MethodInvoker) delegate
            {
                pbarDownloadProgress.Value = e.ProgressPercentage;

                lblDownload.Text = String.Format("Downloading '{0}' - ({1}KB downloaded):", _programToDownload.ProgramName, e.BytesReceived / 1000, e.TotalBytesToReceive / 1000);
            });
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string installLocation = String.Format("MyLibrary/{0}/Compressed.zip", _programToDownload.Programid);

            string firstLine = File.ReadAllLines(installLocation)[0];

            if (!firstLine.Contains("[ERROR]"))
            {
                // Successful download.
                string unzipLocation = String.Format("MyLibrary/{0}/Raw", _programToDownload.Programid);

                Methods.UnzipFile(installLocation, unzipLocation);

                MessageBox.Show(String.Format("Your '{0}' download completed successfully.", _programToDownload.ProgramName), "Download Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Variables.UserControls.MyLibraryDefault.SelectProgram(Variables.Forms.Main.MyLibrarySelectedIndex);
            }
            else
            {
                // Failed to download.
                MessageBox.Show(firstLine.Replace("[ERROR]", ""), "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Invoke((MethodInvoker) (() => Parent.Dispose()));
        }
    }
}
