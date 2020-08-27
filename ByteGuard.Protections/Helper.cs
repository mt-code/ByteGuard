using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;

namespace ByteGuard.Protections
{
    class Helper
    {
        // TODO: Show progress as for large files it can take a while.
        /// <summary>
        /// Writes the specified file to the zipfile stream.
        /// </summary>
        /// <param name="fileLocation">The full path of the file to add to the zip stream.</param>
        /// <param name="zipStream">The zip stream to add the specified file too.</param>
        public static void WriteFileToZipStream(string fileLocation, ZipOutputStream zipStream)
        {
            ZipEntry zipEntry = new ZipEntry(Path.GetFileName(fileLocation)) { DateTime = DateTime.Now };

            zipStream.PutNextEntry(zipEntry);

            byte[] buffer = new byte[4096];

            using (FileStream fileStream = File.OpenRead(fileLocation))
            {
                int sourceBytes;
                do
                {
                    sourceBytes = fileStream.Read(buffer, 0, buffer.Length);
                    zipStream.Write(buffer, 0, sourceBytes);
                } while (sourceBytes > 0);
            }
        }

        /// <summary>
        /// Clones a drive (including all files and sub-directores) to the target location. Optionally allows you to avoid/skip a certain file path.
        /// </summary>
        /// <param name="originalDirectory">The original directory you want to clone.</param>
        /// <param name="targetDirectory">The target location for the cloned directory.</param>
        /// <param name="pathToAvoid">The complete file path for any files you want to avoid/skip.</param>
        public static void CloneDirectory(string originalDirectory, string targetDirectory, string pathToAvoid = null)
        {
            if (pathToAvoid == null)
            {
                foreach (string filePath in Directory.GetFiles(originalDirectory))
                {
                    FileAttributes fileAttribs = File.GetAttributes(filePath);

                    if ((fileAttribs & FileAttributes.Directory) != FileAttributes.Directory)
                    {
                        File.Copy(filePath, Path.Combine(targetDirectory, Path.GetFileName(filePath)), true);
                    }
                    else
                    {
                        CloneDirectory(filePath, targetDirectory);
                    }
                }
            }
            else
            {
                foreach (string filePath in Directory.GetFiles(originalDirectory).Where(file => file != pathToAvoid))
                {
                    FileAttributes fileAttribs = File.GetAttributes(filePath);

                    if ((fileAttribs & FileAttributes.Directory) != FileAttributes.Directory)
                    {
                        File.Copy(filePath, Path.Combine(targetDirectory, Path.GetFileName(filePath)), true);
                    }
                    else
                    {
                        CloneDirectory(filePath, targetDirectory);
                    }
                }
            }
        }

        public static void CopyFileFromResource(string resourceName, string targetLocation)
        {
            using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null) throw new NullReferenceException("Invalid resource name specified.");

                using (Stream outputStream = File.Open(targetLocation, FileMode.Create))
                {
                    resourceStream.CopyTo(outputStream);
                }
            }
        }
    }
}
