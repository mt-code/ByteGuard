using System;
using System.Security.Cryptography;

namespace ByteGuard.Tasks
{
    class General
    {
        public static bool IsUpdating = false;
        public static string WebResponse { get; set; }
        public static string ByteGuardHost = "http://www.byteguardsoftware.co.uk/byteguard/";

        public static string GetMd5(byte[] inputBytes)
        {
            using (MD5 md5 = MD5.Create())
            {
                return BitConverter.ToString(md5.ComputeHash(inputBytes))
                    .Replace("-", String.Empty);
            }
        }
    }
}
