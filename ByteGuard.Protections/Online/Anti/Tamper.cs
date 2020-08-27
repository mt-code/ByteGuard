using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;

namespace ByteGuard.Protections.Online.Anti
{
    internal class Tamper
    {
        public static void Process(ModuleDef targetModule)
        {
            InjectCall(targetModule);
            
        }

        private static void InjectCall(ModuleDef targetModule)
        {
            MethodDef cctor = targetModule.GlobalType.FindOrCreateStaticConstructor();

            TypeDef antiTamperType = targetModule.Find(
                "ByteGuard.Protections.Online.Runtime.ByteGuardAntiTamper", true);

            MethodDef hookMethod = antiTamperType.FindMethod("DecryptMethods");

            cctor.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, hookMethod));
        }

        public static void WriteSection(ModuleWriterBase writer)
        {
            // Add a PE section
            var sect1 = new PESection(".dummy", 0x40000040);
            writer.Sections.Add(sect1);
            // Let's add data
            sect1.Add(new ByteArrayChunk(new byte[File.ReadAllBytes(writer.Module.Location).Length]), 4);
        }

        public static void EncryptMethods(string protectedLocation, uint sectionrva)
        {
            // Converts the section RVA to file offset.
            PEReader.PEReader pe = new PEReader.PEReader(protectedLocation);

            // Byte list to store the section bytes in.
            List<byte> section = new List<byte>();

            // Initialize variables.
            uint methodCount = 0;

            // Create two byte arrays, one to be wiped and another to use as a reference.
            byte[] fileBytes = File.ReadAllBytes(protectedLocation);
            byte[] original = File.ReadAllBytes(protectedLocation);

            // Load the protected module.
            ModuleDefMD protectedModule = ModuleDefMD.Load(protectedLocation);

            // Iterate through all types except <Module> and the anti tamper type.
            foreach (TypeDef t in protectedModule.GetTypes().Where(t => t != protectedModule.GlobalType && t.Name != "ByteGuardAntiTamper"))
            {
                // Iterate through all methods that have a body & instructions.
                foreach (MethodDef m in t.Methods.Where(m => m.HasBody && m.Body.HasInstructions))
                {
                    uint firstOffset = (uint)m.RVA;
                    uint bodySize = m.Body.Instructions[m.Body.Instructions.Count - 1].Offset + 1;
                    
                    // Wipes the method bytes and returns true if it is a FAT method.
                    bool isFatMethod = WipeBytes(fileBytes, m, pe);

                    // Adjusts the offset accordingly. (12 for FAT, 1 for TINY).
                    firstOffset += (uint)(isFatMethod ? 12 : 1);

                    // Adds the method RVA to the section bytes.
                    // (This is used to find where to write the method bytes in memory)
                    section.AddRange(BitConverter.GetBytes(firstOffset));

                    // Adds the method size to the section bytes.
                    // (This is used to know how many bytes to read)
                    section.AddRange(BitConverter.GetBytes(bodySize));

                    // Adds every byte for each method to the section bytes.
                    // (This will be read and copied into memory).
                    for (int i = 0; i < bodySize; i++)
                    {
                        uint fileOffset = pe.RVAToOffset((uint)(firstOffset + i));

                        section.Add(original[fileOffset]);
                    }

                    methodCount++;
                }
            }

            Array.Resize(ref fileBytes, fileBytes.Length + section.Count);

            MemoryStream memoryStream = new MemoryStream(fileBytes);
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            section.InsertRange(0, BitConverter.GetBytes(methodCount));

            binaryWriter.Seek(0x20, SeekOrigin.Begin);
            binaryWriter.Write(sectionrva);

            // Copy method bytes to section.
            binaryWriter.Seek((int)pe.RVAToOffset(sectionrva), SeekOrigin.Begin);
            binaryWriter.Write(section.ToArray());

            byte[] sectionBytes = memoryStream.ToArray();

            File.WriteAllBytes("A://ByteGuard-Protected.exe", sectionBytes);
        }

        


        private static bool WipeBytes(byte[] fileBytes, MethodDef targetMethod, PEReader.PEReader peReader)
        {
            bool isFat;

            uint firstOffset = (uint)targetMethod.RVA;
            uint bodySize = targetMethod.Body.Instructions[targetMethod.Body.Instructions.Count - 1].Offset + 1;

            firstOffset = peReader.RVAToOffset(firstOffset);

            if ((fileBytes[firstOffset] & 0x3) == 0x2)
            {
                // Tiny method.
                firstOffset += 1;
                isFat = false;
            }
            else
            {
                // Fat method.
                firstOffset += 12;
                isFat = true;
            }

            for (int i = 0; i < bodySize; i++)
            {
                fileBytes[firstOffset + i] = 0;
            }

            return isFat;
        }
    }
}
