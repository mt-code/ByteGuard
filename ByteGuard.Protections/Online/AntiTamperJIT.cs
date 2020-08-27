using System;
using System.IO;
using System.Windows.Forms;
using dnlib.DotNet;
using ByteGuard.Engine;
using System.Linq;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;

using ByteGuard.PEReader;

namespace ByteGuard.Protections.Online
{
    public class AntiTamperJIT
    {
        public static void Process(ModuleDef targetModule, string decryptionKey)
        {
            Merge(targetModule);
            InjectCall(targetModule);
        }

        /// <summary>
        /// Injects/merges all the required types into the target module.
        /// </summary>
        /// <param name="targetModule">The module to inject the types into.</param>
        private static void Merge(ModuleDef targetModule)
        {
			ModuleDefMD currentModule = ModuleDefMD.Load(typeof(AntiTamperJIT).Assembly.ManifestModule);

            Merger.Merge(targetModule, currentModule, "ByteGuard.Protections.Online.Runtime.JIT");

            TypeDef emptyType = currentModule.Find("EmptyType", true);
            targetModule.Types.Add(Cloner.Clone(emptyType, targetModule));
        }

        private static void InjectCall(ModuleDef targetModule)
        {
            MethodDef cctor = targetModule.GlobalType.FindOrCreateStaticConstructor();
            TypeDef antiTamperType = targetModule.Find(
                "ByteGuard.Protections.Online.Runtime.JIT.ByteGuardAntiTamperJIT", true);
				
            MethodDef hookMethod = antiTamperType.FindMethod("Hook");

            // TODO: Insert before InitializeByteGuard.
            cctor.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, hookMethod));
        }

        public static void EncryptMethods(ModuleDef targetModule)
        {
            PEReader.PEReader pe = new PEReader.PEReader(targetModule.Location);

            byte[] bytes = File.ReadAllBytes(targetModule.Location);

            foreach (TypeDef t in targetModule.GetTypes().Where(t => !t.Namespace.Contains("ByteGuard") && t.Name != "<Module>"))
            {
                foreach (MethodDef m in t.Methods.Where(m => m.HasBody))
                {
                    bytes = EncryptMethod(bytes, m, pe);
                }
            }

            //File.WriteAllBytes("A://new.exe", bytes);
        }

        private static byte[] EncryptMethod(byte[] byteArray, MethodDef targetMethod, PEReader.PEReader peReader)
        {
            int firstOffset, lastOffset;

            // Checks if the method is tiny or fat and calculates the offsets accordingly.
            if ((byteArray[peReader.RVAToOffset(Convert.ToUInt32(targetMethod.RVA))] & 0x3) == 0x2)
            {
                // TINY:
                firstOffset = peReader.GetOffset((int)targetMethod.RVA + 1, 0);
                lastOffset = peReader.GetOffset((int)targetMethod.RVA + 1, (int)targetMethod.Body.Instructions[targetMethod.Body.Instructions.Count - 1].Offset);
            }
            else
            {
                // FAT:
                firstOffset = peReader.GetOffset((int)targetMethod.RVA + 12, 0);
                lastOffset = peReader.GetOffset((int)targetMethod.RVA + 12, (int)targetMethod.Body.Instructions[targetMethod.Body.Instructions.Count - 1].Offset);
            }

            for (int i = firstOffset; i <= lastOffset; i++)
            {
            }

            return byteArray;
        }
        
    }
}
