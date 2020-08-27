using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using ByteGuard.Tasks;

namespace ByteGuard.Tasks
{
    class Network
    {
        public static readonly object LockObject = new object();
        public static CookieContainer CookieContainer = new CookieContainer();

        /// <summary>
        /// Submits data to be processed that has parameters.
        /// </summary>
        /// <param name="submitAct">The act being processed. (Example: login, register)</param>
        /// <param name="submitData">The act parameters. (Example: username, password)</param>
        /// <returns>The result of the query as a byte array.</returns>
        public static bool SubmitData(string submitAct, NameValueCollection submitData)
        {
            try
            {
                //MessageBox.Show(submitAct);

                using (ByteGuardWebClient byteguardWebClient = new ByteGuardWebClient())
                {
                    submitData.Add("act", submitAct);

                    byteguardWebClient.CookieJar = CookieContainer;

                    lock (LockObject)
                    {
                        General.WebResponse = Encoding.ASCII.GetString(byteguardWebClient.UploadValues(String.Format("{0}process.php", General.ByteGuardHost), submitData));
                    }

                    //MessageBox.Show(ByteGuardInterface.Globals.Variables.WebResponse);
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("The server appears to be offline1.", "Update Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
        /// Submits data to be processed that has parameters.
        /// </summary>
        /// <param name="submitAct">The act being processed. (Example: login, register)</param>
        /// <returns>The result of the query as a byte array.</returns>
        public static bool SubmitData(string submitAct)
        {
            try
            {
                //MessageBox.Show(submitAct);

                using (ByteGuardWebClient byteguardWebClient = new ByteGuardWebClient())
                {
                    NameValueCollection submitData = new NameValueCollection {{"act", submitAct}};

                    byteguardWebClient.CookieJar = CookieContainer;

                    lock (LockObject)
                    {
                        General.WebResponse = Encoding.ASCII.GetString(byteguardWebClient.UploadValues(String.Format("{0}process.php", General.ByteGuardHost), submitData));
                    }

                    //MessageBox.Show(ByteGuardInterface.Globals.Variables.WebResponse);
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("The server appears to be offline.2", "Update Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        public static void DownloadFileAsync(string fileLocation,
            DownloadProgressChangedEventHandler downloadHandler,
            AsyncCompletedEventHandler downloadCompletedHandler, string fileName)
        {
            General.IsUpdating = true;

            try
            {
                using (ByteGuardWebClient byteguardWebClient = new ByteGuardWebClient())
                {
                    byteguardWebClient.CookieJar = CookieContainer;

                    byteguardWebClient.DownloadProgressChanged += downloadHandler;
                    byteguardWebClient.DownloadFileCompleted += downloadCompletedHandler;
                    
                    Uri postUri =
                        new Uri(
                            String.Format("{0}process.php?act=downloadupdate&filename={1}", General.ByteGuardHost, fileName));

                    lock (LockObject)
                    {
                        byteguardWebClient.DownloadFileAsync(postUri, fileLocation);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Failed to download update, please try again shortly.", "Update Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
