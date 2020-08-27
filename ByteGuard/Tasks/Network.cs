using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Pipes;

namespace ByteGuard.Tasks
{
    class Network
    {
        public static readonly object LockObject = new object();
        public static CookieContainer CookieContainer = new CookieContainer();
        private static readonly PipeServer PipeServer = new PipeServer("ByteGuardNamedPipe_Protections");

        static Network()
        {
            PipeServer.MessageReceived += MessageReceived;
            PipeServer.Start();
        }

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
                        Variables.WebResponse = Encoding.ASCII.GetString(byteguardWebClient.UploadValues(String.Format("{0}process.php", Variables.ByteGuardHost), submitData));
                    }

                    //MessageBox.Show(ByteGuardInterface.Globals.Variables.WebResponse);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                Variables.Containers.Active.SetStatus("The server appears to be offline.", 1);

                if (Variables.Containers.Main != null)
                    Variables.Containers.Main.SetStatus("The server appears to be offline.", 1);
                return false;
            }
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
                        Variables.WebResponse = Encoding.ASCII.GetString(byteguardWebClient.UploadValues(String.Format("{0}process.php", Variables.ByteGuardHost), submitData));
                    }

                    //MessageBox.Show(ByteGuardInterface.Globals.Variables.WebResponse);
                    return true;
                }
            }
            catch
            {
                Variables.Containers.Active.SetStatus("The server appears to be offline.", 1);

                if (Variables.Containers.Main != null)
                    Variables.Containers.Main.SetStatus("The server appears to be offline.", 1);
                return false;
            }
        }

        /// <summary>
        /// Uploads the specified file and stores it on the server.
        /// </summary>
        /// <param name="fileLocation">The file path to the file that is being uploaded.</param>
        /// <param name="submitAct"></param>
        public static void UploadFile(string fileLocation, string submitAct, string programid = null)
        {
            try
            {
                using (ByteGuardWebClient byteguardWebClient = new ByteGuardWebClient())
                {
                    byteguardWebClient.Headers.Add("Content-Type", "binary/octet-stream");
                    byteguardWebClient.CookieJar = CookieContainer;

                    lock (LockObject)
                    {
                        Variables.WebResponse = Encoding.ASCII.GetString(byteguardWebClient.UploadFile(String.Format("{0}files/upload.php?type={1}&pid={2}", Variables.ByteGuardHost, submitAct, programid), "POST", fileLocation));
                    }
                }
            }
            catch
            {
                Variables.Containers.Main.SetStatus("Failed to upload file, please try again shortly.", 1);
            }
        }

        public static void UploadFileAsync(string fileLocation, string submitAct, UploadProgressChangedEventHandler uploadHandler, UploadFileCompletedEventHandler completedHandler, string programid = null)
        {
            try
            {
                using (ByteGuardWebClient byteguardWebClient = new ByteGuardWebClient())
                {
                    byteguardWebClient.Headers.Add("Content-Type", "binary/octet-stream");
                    byteguardWebClient.CookieJar = CookieContainer;

                    byteguardWebClient.UploadProgressChanged += uploadHandler;
                    byteguardWebClient.UploadFileCompleted += completedHandler;

                    Uri postUri =
                        new Uri(
                            String.Format("{0}files/upload.php?type={1}&pid={2}",
                                Variables.ByteGuardHost, submitAct, programid));

                    lock (LockObject)
                    {
                        byteguardWebClient.UploadFileAsync(postUri, "POST", fileLocation);
                    }
                }
            }
            catch
            {
                Variables.Containers.Main.SetStatus("Failed to upload program image, please try again shortly.", 1);
            }
        }

        public static void DownloadFileAsync(string fileLocation,
            DownloadProgressChangedEventHandler downloadHandler,
            AsyncCompletedEventHandler downloadCompletedHandler, string programid = null)
        {
            try
            {
                using (ByteGuardWebClient byteguardWebClient = new ByteGuardWebClient())
                {
                    byteguardWebClient.CookieJar = CookieContainer;

                    byteguardWebClient.DownloadProgressChanged += downloadHandler;
                    //byteguardWebClient.DownloadDataCompleted += downloadCompletedHandler;
                    byteguardWebClient.DownloadFileCompleted += downloadCompletedHandler;
                    
                    Uri postUri =
                        new Uri(
                            String.Format("{0}process.php?act=dlprogram&pid={1}",
                                Variables.ByteGuardHost, programid));

                    lock (LockObject)
                    {
                        byteguardWebClient.DownloadFileAsync(postUri, fileLocation);
                    }
                }
            }
            catch
            {
                Variables.Containers.Main.SetStatus("Failed to download program, please try again shortly.", 1);
            }
        }

        /// <summary>
        /// Downloads the custom program image from the server and saves it at the specified file path.
        /// </summary>
        /// <param name="programid">The Programid of the program we wish to download the image of.</param>
        /// <param name="imageLocation">The file path where we want to download the image to.</param>
        public static void DownloadProgramImage(string programid, string imageLocation)
        {
            try
            {
                using (ByteGuardWebClient byteguardWebClient = new ByteGuardWebClient())
                {
                    byteguardWebClient.CookieJar = CookieContainer;

                    lock (LockObject)
                    {
                        byteguardWebClient.DownloadFile(String.Format("{0}process.php?act=getprogimage&data={1}", Variables.ByteGuardHost, programid), imageLocation);
                    }
                }
            }
            catch
            {
                Variables.Containers.Main.SetStatus("The server appears to be offline.", 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="imageLocation"></param>
        public static void DownloadAvatarImage(string username, string imageLocation)
        {
            try
            {
                using (ByteGuardWebClient byteguardWebClient = new ByteGuardWebClient())
                {
                    byteguardWebClient.CookieJar = CookieContainer;

                    lock (LockObject)
                    {
                        byteguardWebClient.DownloadFile(String.Format("{0}process.php?act=getavatar&u={1}", Variables.ByteGuardHost, username), imageLocation);
                    }
                }
            }
            catch
            {
                Variables.Containers.Main.SetStatus("The server appears to be offline.", 1);
            }
        }

        public static bool IsReset = false;

        // TODO: Lock the lock object while awaiting for the cookiecontainer to be reset so that the session isn't lost.
        /// <summary>
        /// Handles the PipeServer's received messages.
        /// </summary>
        /// <param name="message">The message received from the pipe client.</param>
        private static void MessageReceived(string message)
        {
            // Gets the request action.
            string requestedAction = message.Split('[', ']')[1];

            // Parses the message to remove the request action.
            message = message.Replace(String.Format("[{0}]", requestedAction), "");

            switch (requestedAction.ToLower())
            {
                // The pipe client is requesting the CookieContainer.
                case "get":
                    string filePath;

                    using (Stream fileStream = File.Create(filePath = Path.GetTempFileName()))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(fileStream, CookieContainer);

                        PipeServer.SendMessage(String.Format("[SET]{0}", filePath));
                    }
                    break;

                // The pipe client is setting the CookieContainer.
                case "set":
                    if (File.Exists(message))
                    {
                        using (Stream fileStream = File.OpenRead(message))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            CookieContainer = (CookieContainer)formatter.Deserialize(fileStream);
                        }

                        IsReset = true;
                        
                        File.Delete(message);
                    }
                    else
                    {
                        throw new FileNotFoundException("The specified file could not be found.");
                    }
                    break;

                case "getid":
                    PipeServer.SendMessage(String.Format("[SETID]{0}", Licensing.Hwid.HardwareIdentifier));
                    break;
            }
        }

        public static void StartAutoLoginUrl(string url)
        {
            url = String.Format("{0}&login_id={1}&login_user={2}", url,
                Methods.GetSessionIdentifier(),
                Variables.Users.Current.UID);

            System.Diagnostics.Process.Start(url);
        }
    }
}
