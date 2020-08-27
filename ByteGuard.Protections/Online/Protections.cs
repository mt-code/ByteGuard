using System;
using System.IO;
using System.Linq;

using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ByteGuard.Engine;
using dnlib.DotNet.Writer;

using ICSharpCode.SharpZipLib.Zip;

namespace ByteGuard.Protections.Online
{
    public class Protections
    {
        public static string Protect(string fileLocation, string decryptionKey, string programId, string programVersion = "1.0")
        {
            // Injects the protection runtime methods and calls the 'InitializeByteGuard' method upon module launch.
            ModuleDefMD targetModule = InitializeProtection(fileLocation);
            //ModuleDefMD targetModule = ModuleDefMD.Load(fileLocation);

            // Sets the ByteGuard variables such as programId and programVersion.
            SetVariables(targetModule, programId, programVersion);

            // Performs the file obfuscations.
            StringProtections.Process(targetModule, decryptionKey);
            ConstantProtections.Process(targetModule, decryptionKey);
            //AntiTamperJIT.Process(targetModule, decryptionKey);
            //ControlFlowProtection.Process(targetModule);


            Anti.Tamper.Process(targetModule);


            //WriteFile(targetModule, programId, fileLocation);

            //ModuleDefMD mod = ModuleDefMD.Load("A://BlankForm-protected.exe");

            //AntiTamperJIT.EncryptMethods(mod);

            // Writes the module to the specified folder.
            return ProtectionWriter.WriteFile(targetModule, programId, fileLocation);
        }

        /// <summary>
        /// Injects the protection runtime methods and calls the 'InitializeByteGuard' method upon module launch.
        /// </summary>
        /// <param name="fileLocation">The file location of the file to protect.</param>
        private static ModuleDefMD InitializeProtection(string fileLocation)
        {
            ModuleDefMD targetModule = ModuleDefMD.Load(fileLocation);
            ModuleDefMD protectionModule = ModuleDefMD.Load("ByteGuard.Protections.dll");

            targetModule = (ModuleDefMD)Merger.Merge(targetModule, protectionModule, "ByteGuard.Protections.Online.Runtime", false);

            TypeDef byteguardCore = targetModule.Find("ByteGuard.Protections.Online.Runtime.ByteGuardCore", true);

            MethodDef cctor = targetModule.GlobalType.FindOrCreateStaticConstructor();
            MethodDef initializeByteguard = byteguardCore.FindMethod("InitializeByteGuard");

            cctor.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, initializeByteguard));

            return targetModule;
        }

        private static void SetVariables(ModuleDef targetModule, string programId, string programVersion)
        {
            foreach (TypeDef t in targetModule.GetTypes().Where(t => t.Name == "ByteGuardCore"))
            {
                foreach (MethodDef m in t.Methods.Where(m => m.HasBody))
                {
                    switch (m.Name)
                    {
                        case "GetProgramId":
                            m.Body.Instructions[0] = Instruction.Create(OpCodes.Ldstr, programId);
                            break;

                        case "GetProgramVersion":
                            m.Body.Instructions[0] = Instruction.Create(OpCodes.Ldstr, programVersion);
                            break;
                    }
                }
            }
        }

        
    }
}
