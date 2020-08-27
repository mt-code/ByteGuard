using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ByteGuard.Protections.Online.Runtime
{
    public class ByteGuardHelper
    {
        public static string GetMd5(string inputString = null, byte[] inputBytes = null)
        {
            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    byte[] byteData = (inputString == null? inputBytes : Encoding.ASCII.GetBytes(inputString));

                    using (MemoryStream memoryStream = new MemoryStream(byteData))
                    {
                        return BitConverter.ToString(md5Hash.ComputeHash(memoryStream)).Replace("-", String.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: Change this error.
                MessageBox.Show(ex.ToString());
                MessageBox.Show("An error occurred launching the application. (0x01)", "Byteguard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0x01);
                return null;
            }
        }

        
        public static byte[] GzipDecompressBytes(byte[] cb)
        {
            using (GZipStream g = new GZipStream(new MemoryStream(cb), CompressionMode.Decompress))
            {
                byte[] b = new byte[4096];

                using (MemoryStream m = new MemoryStream())
                {
                    int c;
                    do
                    {
                        c = g.Read(b, 0, 4096);

                        if (c > 0)
                            m.Write(b, 0, c);
                    }
                    while (c > 0);

                    return m.ToArray();
                }
            }
        }

        public static void ThrowException(Exception exception)
        {
            MessageBox.Show(exception.ToString(), "ByteGuard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
