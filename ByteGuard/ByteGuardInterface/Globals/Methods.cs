using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using ByteGuard.Tasks;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace ByteGuard.ByteGuardInterface.Globals
{
    internal class Methods
    {
        /// <summary>
        ///     Attempts to get the text stored within the specified element.
        /// </summary>
        /// <param name="filePath">Path to the .ini file.</param>
        /// <param name="stringToRead">The element name to retrieve text from.</param>
        /// <returns>Returns the text within the specified element or 'NOTFOUND' if it is not found.</returns>
        public static string ReadIniString(string filePath, string stringToRead)
        {
            if (File.Exists(filePath))
            {
                foreach (
                    string str in
                        File.ReadAllText(filePath)
                            .Split(new[] {Environment.NewLine}, StringSplitOptions.None)
                            .Where(s => s.Contains('='))
                            .Where(str => str.Split('=')[0] == stringToRead))
                    return str.Split('=')[1].ToLower();
            }

            return "NOTFOUND";
        }

        /// <summary>
        /// Checks if the file is a .NET assembly or not.
        /// </summary>
        /// <param name="fileLocation">The path of the file to check.</param>
        /// <returns>Returns true if the file is a .NET assembly, otherwise returns false.</returns>
        public static bool IsNetAssembly(string fileLocation)
        {
            try
            {
                return (AssemblyName.GetAssemblyName(fileLocation) != null);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Removes a line from the specified file that contains a specified string.
        /// </summary>
        /// <param name="filePath">Path to the file to remove the string from.</param>
        /// <param name="stringToRemove">Any line that contains this shall be removed from the specified file.</param>
        public static void RemoveLineContaining(string filePath, string stringToRemove)
        {
            if (File.Exists(filePath))
            {
                string temporaryFile = Path.GetTempFileName();
                var linesToKeep = File.ReadLines(filePath).Where(l => !l.Contains(stringToRemove));

                File.WriteAllLines(temporaryFile, linesToKeep);

                File.Delete(filePath);
                File.Move(temporaryFile, filePath);
            }
        }

        /// <summary>
        ///     Gets the MD5 hash of the supplied string.
        /// </summary>
        /// <param name="inputString">The input string to hash.</param>
        /// <returns>The MD5 hash of the input string.</returns>
        public static string GetMd5(string inputString, bool isUppercase)
        {
            using (MD5 md5 = MD5.Create())
            {
                //return BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes(inputString)))
                //    .Replace("-", String.Empty);
                return (isUppercase
                    ? BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes(inputString)))
                        .Replace("-", String.Empty)
                    : BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes(inputString)))
                        .Replace("-", String.Empty).ToLower());
            }
        }

        public static string GetMd5(byte[] inputBytes)
        {
            using (MD5 md5 = MD5.Create())
            {
                return BitConverter.ToString(md5.ComputeHash(inputBytes))
                    .Replace("-", String.Empty);
            }
        }

        public static string TimeStampToDate(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();

            return String.Format("{0}/{1}/{2} {3}:{4}", dtDateTime.Day.ToString("00"), dtDateTime.Month.ToString("00"),
                dtDateTime.Year.ToString("0000"), dtDateTime.Hour.ToString("00"), dtDateTime.Minute.ToString("00"));
        }

        public static Variables.ByteGuardUser DownloadUserData(string username)
        {
            NameValueCollection dataValues = new NameValueCollection {{"u", username}};

            if (Network.SubmitData("getuserdata", dataValues))
            {
                // Retrieves the web response.
                string webResponse = Variables.WebResponse;

                if (webResponse.Split('[', ']')[1] == "SUCCESS")
                {
                    // Loads the XML file ready to be parsed.
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(webResponse.Replace("[SUCCESS]", ""));

                    foreach (XmlNode xmlNode in xmlDocument)
                    {
                        foreach (XmlNode xmlUserNode in xmlNode)
                        {
                            return ParseUserData(xmlUserNode);
                        }
                    }
                }
                else
                {
                    // Failed to download user data, display error.
                    Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR] ", String.Empty), 1);
                }
            }

            return new Variables.ByteGuardUser();
        }

        public static Variables.ByteGuardUser ParseUserData(XmlNode userNode)
        {
            Variables.ByteGuardUser byteguardUser = new Variables.ByteGuardUser();

            // Adds the neccesary information to the variable.
            foreach (XmlNode xmlInformationNode in userNode)
            {
                switch (xmlInformationNode.Name)
                {
                    case "uid":
                        byteguardUser.UID = Convert.ToInt32(xmlInformationNode.InnerText);
                        break;

                    case "email":
                        byteguardUser.Email = xmlInformationNode.InnerText;
                        break;

                    case "username":
                        byteguardUser.Username = xmlInformationNode.InnerText;
                        break;

                    case "maxlicenses":
                        byteguardUser.MaxLicenses = Convert.ToInt32(xmlInformationNode.InnerText);
                        break;

                    case "maxvariables":
                        byteguardUser.MaxVariables = Convert.ToInt32(xmlInformationNode.InnerText);
                        break;

                    case "maxadmins":
                        byteguardUser.MaxProgramAdministrators = Convert.ToInt32(xmlInformationNode.InnerText);
                        break;

                    case "freeregused":
                        byteguardUser.FreeRegistrationUsed = Convert.ToInt32(xmlInformationNode.InnerText) == 1;
                        break;

                    case "registeredtime":
                        byteguardUser.TimeRegistered = Convert.ToInt32(xmlInformationNode.InnerText);
                        break;

                    case "lastaction":
                        byteguardUser.LastActive = Convert.ToInt32(xmlInformationNode.InnerText);
                        break;

                    case "isactivated":
                        byteguardUser.IsActivated = Convert.ToInt32(xmlInformationNode.InnerText) == 1;
                        break;

                    case "description":
                        byteguardUser.Description = xmlInformationNode.InnerText;
                        break;

                    case "hasavatar":
                        byteguardUser.HasAvatar = Convert.ToInt32(xmlInformationNode.InnerText) == 1;
                        break;

                    case "licensecount":
                        byteguardUser.LicenseCount = Convert.ToInt32(xmlInformationNode.InnerText);
                        break;

                    case "variablecount":
                        byteguardUser.VariableCount = Convert.ToInt32(xmlInformationNode.InnerText);
                        break;

                    case "admincount":
                        byteguardUser.ProgramAdministratorCount = Convert.ToInt32(xmlInformationNode.InnerText);
                        break;
                }
            }

            byteguardUser.LicensesRemaining = (byteguardUser.MaxLicenses - byteguardUser.LicenseCount);
            byteguardUser.VariablesRemaining = (byteguardUser.MaxVariables - byteguardUser.VariableCount);
            byteguardUser.ProgramAdministratorsRemaining = (byteguardUser.MaxProgramAdministrators -
                                                            byteguardUser.ProgramAdministratorCount);

            return byteguardUser;
        }

        public static bool DownloadAvatar(string username, string imagePath)
        {
            if (File.Exists(imagePath))
                File.Delete(imagePath);

            // The directory exists, download the custom file image.
            Variables.Containers.Main.SetStatus("Downloading avatar image..", 3);

            // Download the specified program image to the ByteGuard/MyPrograms folder.
            Network.DownloadAvatarImage(username, imagePath);

            // If the image downloaded successfully, display it in the file picturebox.
            return (File.Exists(imagePath));
        }

        public static void UnzipFile(string zipFileLocation, string targetDirectory)
        {
            using (FileStream fileStream = File.OpenRead(zipFileLocation))
            {
                using (ZipFile zip = new ZipFile(fileStream))
                {
                    foreach (ZipEntry zipEntry in zip)
                    {
                        if (!zipEntry.IsFile)
                            continue;

                        using (Stream zipStream = zip.GetInputStream(zipEntry))
                        {
                            byte[] buffer = new byte[4096];

                            string fullZipPath = Path.Combine(targetDirectory, zipEntry.Name);
                            string directoryName = Path.GetDirectoryName(fullZipPath);

                            if (directoryName != null)
                                Directory.CreateDirectory(directoryName);

                            using (FileStream streamWriter = File.Create(fullZipPath))
                            {
                                StreamUtils.Copy(zipStream, streamWriter, buffer);
                            }
                        }
                    }
                }
            }
        }

        public static string GetSessionIdentifier()
        {
            if (Network.SubmitData("getsessionid"))
            {
                string webResponse = Variables.WebResponse;

                if (webResponse.Split('[', ']')[1] == "SUCCESS")
                {
                    return webResponse.Replace("[SUCCESS]", "");
                }

                Variables.Containers.Main.SetStatus("Failed to retrieve your session ID, please restart.", 1);
            }

            return null;
        }
    }
}