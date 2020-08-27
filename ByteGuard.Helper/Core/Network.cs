using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Collections.Specialized;
using ByteGuard.Pipes;

namespace ByteGuard.Helper.Core
{
    internal class Network : WebClient
    {
        internal delegate void NetworkExceptionEventHandler(string errorMessage);

        /// <summary>
        /// Invoked if/when a network exception or error occurs.
        /// </summary>
        public static event NetworkExceptionEventHandler NetworkError;

        // Other variables.
        public static string WebResponse { get; set; }
        public static CookieContainer CookieContainer { get; set; }
        private static readonly PipeServer PipeServer = new PipeServer("ByteGuardNamedPipe_Protections");

        static Network()
        {
            PipeServer.MessageReceived += MessageReceived;
            PipeServer.Start();
        }

        /// <summary>
        /// Submits the login data to the ByteGuard server.
        /// </summary>
        /// <param name="submitData">The login data containing the users username and password.</param>
        /// <returns>Returns true if a response is received, or false if otherwise.</returns>
        public static bool SubmitData(NameValueCollection submitData)
        {
            // Creates a new instance of the CookieContainer class for each login attempt.
            CookieContainer = new CookieContainer();

            try
            {
                using (Network byteguardWebClient = new Network())
                {
                    WebResponse = Encoding.ASCII.GetString(
                                    byteguardWebClient.UploadValues(
                                        "http://127.0.0.1/byteguard/process.php", submitData));

                    return true;
                }
            }
            catch
            {
                if (NetworkError != null) NetworkError("There was an error connecting to the ByteGuard server.");
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
                webRequest.UserAgent = Hwid.HardwareIdentifier;
            }

            return webRequest;
        }

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

                        File.Delete(message);
                    }
                    else
                    {
                        throw new FileNotFoundException("The specified file could not be found.");
                    }
                    break;

                case "getid":
                    PipeServer.SendMessage(String.Format("[SETID]{0}", Hwid.HardwareIdentifier));
                    break;
            }
        }
    }
}
