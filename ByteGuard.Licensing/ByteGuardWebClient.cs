using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ByteGuard.Licensing
{
    internal sealed class ByteGuardWebClient : WebClient
    {
        // Class variables.
        public CookieContainer CookieJar;

        public ByteGuardWebClient()
        {
            CookieJar = new CookieContainer();
        }

        // TODO: Find their username and hardware ID.
        protected override WebRequest GetWebRequest(Uri WebAddress)
        {
            HttpWebRequest WebRequest;

            WebRequest = (HttpWebRequest)base.GetWebRequest(WebAddress);
            WebRequest.Proxy = null;
            WebRequest.Timeout = 15000;
            WebRequest.KeepAlive = false;
            WebRequest.AllowAutoRedirect = true;
            WebRequest.ReadWriteTimeout = 12000;
            WebRequest.CookieContainer = CookieJar;
            //httpWebReq.AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
            WebRequest.UserAgent = "Matt-XPS (HARDWAREID)";

            return WebRequest;
        }
    }
}
