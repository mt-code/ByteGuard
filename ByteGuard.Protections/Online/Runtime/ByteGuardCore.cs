using System;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using ByteGuard.Pipes;

namespace ByteGuard.Protections.Online.Runtime
{
    public class ByteGuardCore : WebClient
    {
        // Strings variables.
        private static string Hwid { get; set; }
        private static string WebResponse { get; set; }
        private static string DecryptionKey { get; set; }

        // CookieContainer.
        private static CookieContainer CookieContainer { get; set; }
        
        // PipeClient.
        private static readonly PipeClient PipeClient = new PipeClient("ByteGuardNamedPipe_Protections");

        public static void InitializeByteGuard()
        {
            try
            {
                // TODO: Enable
                Hwid = GetHwid();
                CookieContainer = GetCookieContainer();

                GetDecryptionKey();

                if (DecryptionKey == null)
                    Environment.Exit(0);
            }
            catch (Exception ex)
            {
                ByteGuardHelper.ThrowException(ex);
            }
        }

        private static string GetProgramId()
        {
            return "";
        }

        private static string GetProgramVersion()
        {
            return "";
        }

        private static void GetDecryptionKey()
        {
            // Adds the required data values to a NameValueCollection ready to be submitted.
            NameValueCollection dataValues = new NameValueCollection
            {
                {"pid", GetProgramId()},
                //{"csm", ByteGuardHelper.GetMd5(null, File.ReadAllBytes(Assembly.GetExecutingAssembly().Location))},
                {"csm", "00000111112222233333444445555566"},
                {"ver", GetProgramVersion()}
            };
            // TODO: GetFileChecksum(File.ReadAllBytes(Assembly.GetExecutingAssembly().Location)));

            // Submits the required information to download the correct decryption key.
            if (!SubmitData("byteguard", dataValues))
                Environment.Exit(0);

            if (WebResponse.Split('[', ']')[1] == "SUCCESS")
            {
                SetCookieContainer(false);

                // If the submitted file checksum matches the checksum in the database, return the decryption key.
                DecryptionKey = WebResponse.Replace("[SUCCESS] ", String.Empty);

                if ((DecryptionKey = ByteGuardHelper.GetMd5(DecryptionKey)) != null)
                {
                    ByteGuardStringProtections.K = DecryptionKey;
                    ByteGuardConstantProtections.K = DecryptionKey;

                    Authenticated();
                }
                else
                {
                    MessageBox.Show("Error downloading program data.", "ByteGuard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetCookieContainer(true);
                }
            }
            else
            {
                // If the submitted file checksum does NOT match the checksum in the database, display the returned error and exit.
                MessageBox.Show(WebResponse.Replace("[ERROR] ", String.Empty), "ByteGuard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetCookieContainer(true);
            }
        }

        private static void Authenticated()
        {
        }

        #region Network methods.

        private static bool SubmitData(string submitAct, NameValueCollection submitData)
        {
            const string host = "http://127.0.0.1/byteguard/process.php";
            //const string host = "http://www.byteguardsoftware.co.uk/process.php";

            try
            {
                using (ByteGuardCore byteguardWebClient = new ByteGuardCore())
                {
                    submitData.Add("act", submitAct);

                    WebResponse = Encoding.ASCII.GetString(
                                    byteguardWebClient.UploadValues(
                                        host, submitData));

                    return true;
                }
            }
            catch
            {
                MessageBox.Show("There was an error connecting to the ByteGuard server.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest webRequest = (HttpWebRequest)base.GetWebRequest(address);

            if (webRequest != null)
            {
                webRequest.Proxy = null;
                webRequest.Timeout = 30000;
                webRequest.KeepAlive = false;
                webRequest.AllowAutoRedirect = true;
                webRequest.ReadWriteTimeout = 12000;
                webRequest.CookieContainer = CookieContainer;
                //httpWebReq.AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
                webRequest.UserAgent = Hwid; // TODO: Set to HWID.
            }

            return webRequest;
        }

        #endregion

        #region NamedPipe methods.

        private static CookieContainer GetCookieContainer()
        {
            PipeClient.SendMessage("[GET]");

            while (CookieContainer == null)
                Thread.Sleep(100);

            return CookieContainer;
        }

        private static string GetHwid()
        {
            PipeClient.ExceptionThrown += ByteGuardHelper.ThrowException;
            PipeClient.MessageReceived += MessageReceived;
            PipeClient.Connect();

            PipeClient.SendMessage("[GETID]");

            return null;
        }

        private static void MessageReceived(string message)
        {
            string requestedAction = message.Split('[', ']')[1];
            message = message.Replace(String.Format("[{0}]", requestedAction), "");

            switch (requestedAction.ToLower())
            {
                case "get":
                    SetCookieContainer(false);
                    break;

                case "set":
                    if (File.Exists(message))
                    {
                        using (Stream fileStream = File.OpenRead(message))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            CookieContainer = (CookieContainer) formatter.Deserialize(fileStream);
                        }

                        File.Delete(message);
                    }
                    else
                    {
                        ByteGuardHelper.ThrowException(new FileNotFoundException("The specified file could not be found."));
                    }
                    break;

                case "setid":
                    Hwid = message;
                    break;
            }
        }

        private static void SetCookieContainer(bool quitAfter)
        {
            string filePath;

            using (Stream fileStream = File.Create(filePath = Path.GetTempFileName()))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, CookieContainer);

                PipeClient.SendMessage(String.Format("[SET]{0}", filePath), quitAfter);
            }
        }

        #endregion
    }


}
