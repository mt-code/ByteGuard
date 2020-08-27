using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ByteGuard.Helper.Core
{
    internal class Methods
    {
        /// <summary>
        ///     Gets the MD5 hash of the supplied string.
        /// </summary>
        /// <param name="inputString">The input string to hash.</param>
        /// <returns>The MD5 hash of the input string.</returns>
        public static string GetMd5(string inputString)
        {
            using (MD5 md5 = MD5.Create())
            {
                return BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes(inputString)))
                    .Replace("-", String.Empty);
            }
        }
    }
}
