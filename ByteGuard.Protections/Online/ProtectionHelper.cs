using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace ByteGuard.Protections.Online
{
    internal class ProtectionHelper
    {
        public static string AesEncrypt(string inputString, string encryptionKey)
        {
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                using (MD5CryptoServiceProvider c = new MD5CryptoServiceProvider())
                {
                    byte[] destinationArray = new byte[0x20];
                    byte[] sourceArray = c.ComputeHash(Encoding.ASCII.GetBytes(encryptionKey));
                    byte[] buffer = Encoding.ASCII.GetBytes(inputString);

                    Array.Copy(sourceArray, 0, destinationArray, 0, 0x10);
                    Array.Copy(sourceArray, 0, destinationArray, 15, 0x10);

                    rijndaelManaged.Key = destinationArray;
                    rijndaelManaged.Mode = CipherMode.ECB;

                    using (ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor())
                        return Convert.ToBase64String(cryptoTransform.TransformFinalBlock(buffer, 0, buffer.Length));
                }
            }
        }

        public static byte[] AesEncrypt(byte[] inputBytes, string encryptionKey)
        {
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                using (MD5CryptoServiceProvider c = new MD5CryptoServiceProvider())
                {
                    byte[] destinationArray = new byte[0x20];
                    byte[] sourceArray = c.ComputeHash(Encoding.ASCII.GetBytes(encryptionKey));
                    byte[] buffer = inputBytes;

                    Array.Copy(sourceArray, 0, destinationArray, 0, 0x10);
                    Array.Copy(sourceArray, 0, destinationArray, 15, 0x10);

                    rijndaelManaged.Key = destinationArray;
                    rijndaelManaged.Mode = CipherMode.ECB;

                    using (ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor())
                        return Encoding.ASCII.GetBytes(Convert.ToBase64String(cryptoTransform.TransformFinalBlock(buffer, 0, buffer.Length)));
                }
            }
        }

        /// <summary>
        /// Compresses the specified byte array using a GZIP stream.
        /// </summary>
        /// <param name="uncompressedBytes">The original uncompressed byte array to be compressed.</param>
        /// <returns>The GZIP compressed byte array.</returns>
        public static byte[] GzipCompressBytes(byte[] uncompressedBytes)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                {
                    gzipStream.Write(uncompressedBytes, 0, uncompressedBytes.Length);
                }

                return memoryStream.ToArray();
            }
        }
    }
}
