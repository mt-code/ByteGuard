using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ByteGuard.Tasks
{
    public partial class UpdaterForm : Form
    {
        private string _programToUpdate;
        private bool _isFinalUpdate;

        public UpdaterForm()
        {
            InitializeComponent();

            Icon = Properties.Resources.ByteGuardIcon;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(CheckForUpdates);
        }

        private struct UpdateStruct
        {
            public string FileName;
            public string Checksum;
        }
        
        private void CheckForUpdates()
        {
            Thread.Sleep(1000);

            if (Network.SubmitData("getbgchecksums"))
            {
                string webResponse = General.WebResponse;

                if (webResponse.Split('[', ']')[1] == "SUCCESS")
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(webResponse.Replace("[SUCCESS]", ""));

                    foreach (XmlNode xmlNode in xmlDocument)
                    {
                        foreach (XmlNode fileNode in xmlNode)
                        {
                            foreach (XmlNode xmlInformationNode in fileNode)
                            {
                                UpdateStruct u = new UpdateStruct();

                                switch (xmlInformationNode.Name)
                                {
                                    case "filename":
                                        u.FileName = xmlInformationNode.InnerText;
                                        break;

                                    case "checksum":
                                        u.Checksum = xmlInformationNode.InnerText;
                                        break;
                                }

                                CheckFile(u);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(webResponse.Replace("[ERROR]", ""), "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            _isFinalUpdate = true;
        }

        private void CheckFile(UpdateStruct u)
        {
            if (u.FileName == null)
                return;

            if (File.Exists(u.FileName))
            {
                if (General.GetMd5(File.ReadAllBytes(u.FileName)) == u.Checksum)
                    return;

                UpdateFile(u.FileName);
            }
            else
            {
                UpdateFile(u.FileName);
            }
        }

        private void UpdateFile(string fileName)
        {
            while (General.IsUpdating)
                Thread.Sleep(1000);

            _programToUpdate = fileName;

            Network.DownloadFileAsync(fileName, DownloadProgress, DownloadCompleted, fileName);
        }

        private void DownloadProgress(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                pbarUpdates.Value = e.ProgressPercentage;

                lblUpdates.Text = String.Format("Downloading '{0}' - ({1}KB downloaded):", _programToUpdate, e.BytesReceived / 1000, e.TotalBytesToReceive / 1000);
            });
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string firstLine = File.ReadAllLines(_programToUpdate)[0];

            if (firstLine.Contains("[ERROR]"))
            {
                // Failed to download.
                MessageBox.Show(firstLine.Replace("[ERROR]", ""), "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Invoke((MethodInvoker) delegate
            {
                pbarUpdates.Value = 0;
            });

            General.IsUpdating = false;

            if (_isFinalUpdate)
            {
                Process.Start("ByteGuard.exe", "true");
                Application.Exit();
            }
        }
    }
}
