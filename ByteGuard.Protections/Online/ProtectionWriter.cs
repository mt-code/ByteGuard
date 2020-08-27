using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.DotNet.MD;
using dnlib.DotNet.Writer;
using ICSharpCode.SharpZipLib.Zip;

namespace ByteGuard.Protections.Online
{
    class ProtectionWriter : IModuleWriterListener
    {
        private static uint sectionrva;

        public static string WriteFile(ModuleDef targetModule, string programId, string originalFileLocation)
        {
            return new ProtectionWriter().Process(targetModule, programId, originalFileLocation);
        }

        private string Process(ModuleDef targetModule, string programId, string originalFileLocation)
        {
            //CreateFolderStructure(programId);

            ModuleWriterOptions writerOptions = new ModuleWriterOptions(targetModule)
            {
                Listener = this
            };

            targetModule.Write("A://BlankForm-protected.exe", writerOptions);

            targetModule.Dispose();
            Anti.Tamper.EncryptMethods("A://BlankForm-protected.exe", sectionrva);

            return null;



            // TODO: This.
            //writerOptions.PEHeadersOptions.NumberOfRvaAndSizes = 10; // Set less than 14.
            //writerOptions.MetaDataOptions.TablesHeapOptions.ExtraData = 1337;

            string protectedFileLocation = Path.Combine(Path.GetTempPath(), "ByteGuard_Protected.exe");

            targetModule.Write(protectedFileLocation, writerOptions);

            SaveMarketplaceFiles(protectedFileLocation, programId, originalFileLocation);
            SaveByteGuardFiles(protectedFileLocation, programId, originalFileLocation);
            SaveCustomFiles(protectedFileLocation, programId, originalFileLocation);

            return Runtime.ByteGuardHelper.GetMd5(null, File.ReadAllBytes(protectedFileLocation)); // MD5 hash.
        }

        // Gets notified during module writing
        public void OnWriterEvent(ModuleWriterBase writer, ModuleWriterEvent evt)
        {
            switch (evt)
            {
                case ModuleWriterEvent.Begin:
                    
                    break;

                case ModuleWriterEvent.PESectionsCreated:
                    Anti.Tamper.WriteSection(writer);
                    break;

                case ModuleWriterEvent.EndCalculateRvasAndFileOffsets:
                    var x = writer.Sections.Find(s => s.Name == ".dummy");
                    sectionrva = (uint)x.RVA;
                    //System.Windows.Forms.MessageBox.Show(x.RVA.ToString("X"));
                    break;

                case ModuleWriterEvent.End:
                    break;

                default:
                    break;
            }
        }

        private static void CreateFolderStructure(string programid)
        {
            string programDirectory = String.Format(@"MyPrograms/{0}/Protected", programid);
            string storeDirectory = Path.Combine(programDirectory, "Marketplace");
            string byteguardDirectory = Path.Combine(programDirectory, "Self-Distribution", "ByteGuard_Interface");
            string customDirectory = Path.Combine(programDirectory, "Self-Distribution", "Custom_Interface", "Helper_Files");

            if (!Directory.Exists(storeDirectory))
                Directory.CreateDirectory(storeDirectory);

            if (!Directory.Exists(byteguardDirectory))
                Directory.CreateDirectory(byteguardDirectory);

            if (!Directory.Exists(customDirectory))
                Directory.CreateDirectory(customDirectory);
        }

        private static void SaveMarketplaceFiles(string protectedModule,
                                                        string programId,
                                                            string originalFileLocation)
        {
            // Stores the marketplace directory into a variable.
            string marketplaceDirectory = Path.GetFullPath(String.Format("MyPrograms/{0}/Protected/Marketplace", programId));

            // Checks the directory has been created (from CreateFolderStructure).
            if (Directory.Exists(marketplaceDirectory))
            {
                // Gets the directory path of the original project files.
                string programFileDirectory = Path.GetDirectoryName(originalFileLocation);

                // Checks it's been retrieved successfully.
                if (programFileDirectory == null)
                    throw new NullReferenceException("Couldn't locate file directory.");

                // Copies the marketplace readme file from resources to the martketplace directory.
                Helper.CopyFileFromResource("ByteGuard.Protections.Resources.marketplace_readme.txt",
                                                Path.Combine(marketplaceDirectory, "README.txt"));

                // TODO: Password protect zip file.
                using (ZipOutputStream zip = new ZipOutputStream(File.Create(Path.Combine(marketplaceDirectory, "Compressed.zip"))))
                {
                    // Sets the compression level to 4, good compression with good speed.
                    zip.SetLevel(4);

                    // Adds the obfuscated module to the zip file.
                    Helper.WriteFileToZipStream(protectedModule, zip);

                    // Adds the remaining (currently unprotected) files to the zip file.
                    foreach (string filePath in Directory.GetFiles(programFileDirectory).Where(f => f != originalFileLocation))
                        Helper.WriteFileToZipStream(filePath, zip);

                    // Closes the zipfile stream.
                    zip.Finish();
                    zip.Close();
                }
            }
        }

        // TODO: Add byteguard interface login application to launch the programs.
        private static void SaveByteGuardFiles(string protectionModule, string programid, string originalFileLocation)
        {
            string byteguardDirectory = Path.GetFullPath(
                                            String.Format("MyPrograms/{0}/Protected/Self-Distribution/ByteGuard_Interface", programid));

            if (Directory.Exists(byteguardDirectory))
            {
                // Gets the directory path of the original project files.
                string programFileDirectory = Path.GetDirectoryName(originalFileLocation);

                // Checks it's been retrieved successfully.
                if (programFileDirectory == null)
                    throw new NullReferenceException("Couldn't locate file directory.");

                // Copies the byteguard readme file from resources to the relevant directory.
                Helper.CopyFileFromResource("ByteGuard.Protections.Resources.selfdist_byteguard_readme.txt",
                    Path.Combine(byteguardDirectory, "README.txt"));

                Helper.CloneDirectory(programFileDirectory, byteguardDirectory, originalFileLocation);

                File.Copy(protectionModule, Path.Combine(byteguardDirectory, "ByteGuard_Protected.exe"));
            }
            else
            {
                throw new NullReferenceException("Failed to locate the target directory.");
            }
        }

        private static void SaveCustomFiles(string protectionModule, string programid, string originalFileLocation)
        {
            string customDirectory = Path.GetFullPath(
                                            String.Format("MyPrograms/{0}/Protected/Self-Distribution/Custom_Interface", programid));

            if (Directory.Exists(customDirectory))
            {
                // Gets the directory path of the original project files.
                string programFileDirectory = Path.GetDirectoryName(originalFileLocation);

                // Checks it's been retrieved successfully.
                if (programFileDirectory == null)
                    throw new NullReferenceException("Couldn't locate file directory.");

                // Copies the custom readme file from resources to the relevant directory.
                Helper.CopyFileFromResource("ByteGuard.Protections.Resources.selfdist_custom_readme.txt",
                    Path.Combine(customDirectory, "README.txt"));

                // Clone the specified directory to the custom directory.
                Helper.CloneDirectory(programFileDirectory, customDirectory, originalFileLocation);

                // Copies the protected module to the custom directory.
                File.Copy(protectionModule, Path.Combine(customDirectory, "ByteGuard_Protected.exe"));

                string helperPath = Path.GetFullPath(Path.Combine(customDirectory, "Helper_Files"));

                if (Directory.Exists(helperPath))
                {
                    if (!File.Exists("ByteGuard.Helper.dll"))
                        throw new FileNotFoundException(
                            "Couldn't locate the ByteGuard.Helper.dll file, please use the updater.");

                    File.Copy("ByteGuard.Helper.dll", Path.Combine(helperPath, "ByteGuard.Helper.dll"));
                }
                else
                {
                    throw new NullReferenceException("Failed to locate the target directory.");
                }
            }
        }
    }
}
