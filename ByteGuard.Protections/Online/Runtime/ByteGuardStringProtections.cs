using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace ByteGuard.Protections.Online.Runtime
{
    // TODO: Perhaps use the calling methods name to decrypt the string too?
    public class ByteGuardStringProtections
    {
        public static string K { get; set; }
        private static byte[] B { get; set; }
        private static byte[] O { get; set; }

        public static string Decrypt(string i, int s, int l)
        {
            return AesDecrypt(i, K.Substring(s, l));
        }

        public static string DecodeAndDecrypt(string i, int s, int l)
        {
            return Decrypt(Decode(i), s, l);
        }

        public static string DecodeAndDecryptK(string i, string k)
        {
            return AesDecrypt(Decode(i), k);
        }

        private static string AesDecrypt(string i, string k)
        {
            using (RijndaelManaged r = new RijndaelManaged())
            {
                using (MD5CryptoServiceProvider cs = new MD5CryptoServiceProvider())
                {
                    byte[] d = new byte[0x20];
                    byte[] s = cs.ComputeHash(Encoding.ASCII.GetBytes(k));
                    byte[] b = Convert.FromBase64String(i);

                    Array.Copy(s, 0, d, 0, 0x10);
                    Array.Copy(s, 0, d, 15, 0x10);

                    r.Key = d;
                    r.Mode = CipherMode.ECB;

                    using (ICryptoTransform c = r.CreateDecryptor())
                        return Encoding.ASCII.GetString(c.TransformFinalBlock(b, 0, b.Length));
                }
            }
        }

        public static byte[] AesDecrypt(byte[] i, string k)
        {
            using (RijndaelManaged r = new RijndaelManaged())
            {
                using (MD5CryptoServiceProvider cs = new MD5CryptoServiceProvider())
                {
                    byte[] d = new byte[0x20];
                    byte[] s = cs.ComputeHash(Encoding.ASCII.GetBytes(k));
                    byte[] b = Convert.FromBase64String(Encoding.ASCII.GetString(i));

                    Array.Copy(s, 0, d, 0, 0x10);
                    Array.Copy(s, 0, d, 15, 0x10);

                    r.Key = d;
                    r.Mode = CipherMode.ECB;

                    using (ICryptoTransform c = r.CreateDecryptor())
                        return c.TransformFinalBlock(b, 0, b.Length);
                }
            }
        }

        private static string Decode(string i)
        {
            // Method variables.
            char c = new char();
            StringBuilder sb = new StringBuilder();

            // Iterates through each character and perform the decoding routine.
            foreach (string s in i.Split('-'))
                sb.Append(sb.Length == 0 ? c = Convert.ToChar(s) : c = Convert.ToChar(c ^ (Convert.ToInt32(s) / c)));

            // Returns the decoded string.
            return sb.ToString();
        }

        public static string GetString(int i, int l)
        {
            // Creates a character array the same size as the string to be parsed.
            char[] b = new char[l];

            using (Stream m = new MemoryStream(B))
            {
                // Sets the stream position to the start of the string.
                m.Position = i;

                // Reads the string from the stream.
                using (StreamReader r = new StreamReader(m))
                {
                    r.Read(b, 0, l);
                }
            }

            // Converts the character array to a string and returns.
            return new string(b);
        }

        public static string GetStringOffline(int i, int l)
        {
            char[] b = new char[l];

            using (Stream m = new MemoryStream(O))
            {
                // Sets the stream position to the start of the string.
                m.Position = i;

                // Reads the string from the stream.
                using (StreamReader r = new StreamReader(m))
                {
                    r.Read(b, 0, l);
                }
            }

            return new string(b);
        }

        public static void LoadStrings()
        {
            byte[] stringByteArray;

            // Stores the current executing assembly and stores it in a variable.
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            // TODO: Encrypt the string here as it is skipped.
            string stringResourceName = currentAssembly.GetManifestResourceNames()
                .Aggregate("", (current, s) => (s == ByteGuardHelper.GetMd5(current) ? s : current));

            // Creates a stream using the embedded resource in the current assembly.
            using (Stream resourceStream = currentAssembly.GetManifestResourceStream(stringResourceName))//BYTEGUARDRESOURCESTRINGPADDINGBYTEGUARD"))
            {
                // Resizes the 'StringByteArray' to the correct size.
                stringByteArray = new byte[resourceStream.Length];

                // Reads the bytes from the embedded resource into the 'StringByteArray'.
                resourceStream.Read(stringByteArray, 0, stringByteArray.Length);
            }

            // Decompresses the compressed bytes.
            //if (DecompressEmbeddedStrings())
                stringByteArray = ByteGuardHelper.GzipDecompressBytes(stringByteArray);

            stringByteArray = AesDecrypt(stringByteArray, (stringResourceName + ByteGuardHelper.GetMd5(K)));

            B = stringByteArray;
        }

        // TODO: Encrypt offline strings.
        // TODO: Use MD5 hash of all offline strings to protect online strings?
        public static void LoadStringsOffline()
        {
            byte[] stringByteArray;

            // Get the currently executing assembly and stores it in a variable.
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            string stringResourceName = currentAssembly.GetManifestResourceNames()
                .Aggregate("", (current, s) => (s == ByteGuardHelper.GetMd5(current) ? s : current));

            using (Stream resourceStream = currentAssembly.GetManifestResourceStream(stringResourceName))
            {
                // Resizes the 'stringByteArray' to the correct size.
                stringByteArray = new byte[resourceStream.Length];

                // Reads the bytes from the embdded resource into the 'stringByteArray'.
                resourceStream.Read(stringByteArray, 0, stringByteArray.Length);
            }

            stringByteArray = ByteGuardHelper.GzipDecompressBytes(stringByteArray);

            O = stringByteArray;
        }
    }
}
