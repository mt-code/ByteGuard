
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ByteGuard.Protections.Online.Runtime
{
    public class ByteGuardConstantProtections
    {
        private static byte[] B { get; set; }
        public static string K { get; set; }

        public static int ByteGuardGetInteger(int i, int r)
        {
            return (B[i] ^ r);
        }

        public static void LoadIntegers()
        {
            // Stores the current executing assembly and stores it in a variable.
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            string resourceName = currentAssembly.GetManifestResourceNames()
                .Aggregate("", (current, s) => (s == ByteGuardHelper.GetMd5(current) ? s : current));

            // Creates a stream using the embedded resource in the current assembly.
            using (Stream resourceStream = currentAssembly.GetManifestResourceStream(resourceName))
            {
                // Resizes the 'StringByteArray' to the correct size.
                B = new byte[resourceStream.Length];

                // Reads the bytes from the embedded resource into the 'StringByteArray'.
                resourceStream.Read(B, 0, B.Length);
            }

            B = ByteGuardStringProtections.AesDecrypt(
                ByteGuardHelper.GzipDecompressBytes(B), (resourceName + ByteGuardHelper.GetMd5(K)));

            //B = ByteGuardStringProtections.AesDecrypt(B, key);
        }
    }
}
