using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ByteGuard.Licensing
{
    internal class Network
    {
        private static readonly object LockObject = new object();
        public static CookieContainer CookieJar = new CookieContainer();
        public static string WebResponse = "";
        public static string ByteGuardHost = "http://127.0.0.1/";

        public static bool SubmitData(string SubmitAct, NameValueCollection SubmitData)
        {
            try
            {
                using (ByteGuardWebClient ByteguardWebClient = new ByteGuardWebClient())
                {
                    SubmitData.Add("act", SubmitAct);

                    ByteguardWebClient.CookieJar = CookieJar;

                    lock (LockObject)
                    {
                        WebResponse = Encoding.ASCII.GetString(ByteguardWebClient.UploadValues(String.Format("{0}process.php", ByteGuardHost), SubmitData));
                    }

                    //MessageBox.Show(Globals.Variables.WebResponse);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
