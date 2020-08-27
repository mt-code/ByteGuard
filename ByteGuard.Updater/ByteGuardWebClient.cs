using System;
using System.Net;

namespace ByteGuard.Tasks
{
    internal sealed class ByteGuardWebClient : WebClient
    {
        // Class variables.
        
        public CookieContainer CookieJar;

        public ByteGuardWebClient()
        {
            CookieJar = new CookieContainer();
        }

        // TODO: Find their username and hardware id.
        protected override WebRequest GetWebRequest(Uri webAddress)
        {
            HttpWebRequest webRequest = (HttpWebRequest)base.GetWebRequest(webAddress);

            if (webRequest != null)
            {
                webRequest.Proxy = null;
                webRequest.Timeout = 15000;
                webRequest.KeepAlive = false;
                webRequest.AllowAutoRedirect = true;
                webRequest.ReadWriteTimeout = 12000;
                webRequest.CookieContainer = CookieJar;
                //httpWebReq.AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
                
            }

            return webRequest;
        }
    }
}
