using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace ByteGuard.Protections.Online
{
    public class ConstantProtections
    {
        public static void Process(ModuleDef targetModule, string decryptionKey, bool encryptConstants = true, bool embedConstants = true, bool compressConstants = true)
        {
            decryptionKey = Runtime.ByteGuardHelper.GetMd5(decryptionKey);

            if (encryptConstants)
                Encryption.EncryptConstants(targetModule);

            if (embedConstants)
                Embedding.EmbedConstants(targetModule, decryptionKey);
        }

        internal class Encryption
        {
            private static readonly Random R = new Random();

            public static void EncryptConstants(ModuleDef targetModule)
            {
                // Method variables.
                int sizeofValue = 0;
                ITypeDefOrRef importedType = null;

                // Iterates through all types included nested types.
                foreach (TypeDef t in targetModule.GetTypes().Where(t => !t.Namespace.Contains("ByteGuard.Protections.Online.Runtime")))
                {
                    // Iterates through all methods that contain instructions.
                    foreach (MethodDef m in t.Methods.Where(mtd => mtd.HasBody))
                    {
                        // Simplifies all macros so that all constants can be encrypted.
                        m.Body.SimplifyMacros(m.Parameters);

                        // Iterates through each instruction within the current method.
                        for (int i = 0; i < m.Body.Instructions.Count; i++)
                        {
                            // Creates an instruction variable for us to work with.
                            Instruction ins = m.Body.Instructions[i];

                            // If the current instruction contains a constant to be encrypted.
                            if (ins.IsLdcI4())
                            {
                                // TODO: Add more sizeof types, make sure they are the same cross-platform/system.
                                // Randomly selects a case between 1-7. (Max value of R.Next() is unreachable).
                                switch (R.Next(1, 8))
                                {
                                    case 1:
                                        importedType = targetModule.Import(typeof(Int32));
                                        sizeofValue = sizeof(Int32);
                                        break;

                                    case 2:
                                        importedType = targetModule.Import(typeof(SByte));
                                        sizeofValue = sizeof(SByte);
                                        break;

                                    case 3:
                                        importedType = targetModule.Import(typeof(Byte));
                                        sizeofValue = sizeof(Byte);
                                        break;

                                    case 4:
                                        importedType = targetModule.Import(typeof(Boolean));
                                        sizeofValue = sizeof(Boolean);
                                        break;

                                    case 5:
                                        importedType = targetModule.Import(typeof(Decimal));
                                        sizeofValue = sizeof(Decimal);
                                        break;

                                    case 6:
                                        importedType = targetModule.Import(typeof(Int16));
                                        sizeofValue = sizeof(Int16);
                                        break;

                                    case 7:
                                        importedType = targetModule.Import(typeof(Int64));
                                        sizeofValue = sizeof(Int64);
                                        break;
                                }

                                // Creates a random integer to be used for encryption.
                                int randomInt = R.Next(1, 1000);

                                // Randomly creates a boolean value to determine how the RandomInt will be used.
                                bool operatorChoice = Convert.ToBoolean(R.Next(0, 2)); // True (1) = Addition, False (0) = Subtraction.

                                // If the constant is divisible by the sizeofValue then it allows the multiplication case.
                                switch (sizeofValue != 0 ? ((Convert.ToInt32(ins.Operand) % sizeofValue) == 0 ? R.Next(1, 5) : R.Next(1, 4)) : R.Next(1, 4))
                                {
                                    // Addition
                                    case 1:
                                        m.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, importedType));
                                        m.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Add));

                                        ins.Operand = ((Convert.ToInt32(ins.Operand) - sizeofValue) + (operatorChoice ? -randomInt : +randomInt));// RandomInt;//(Convert.ToInt32(ins.Operand) - SizeofValue);

                                        break;

                                    // Subtraction
                                    case 2:
                                        m.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, importedType));
                                        m.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Sub));

                                        ins.Operand = ((Convert.ToInt32(ins.Operand) + sizeofValue) + (operatorChoice ? -randomInt : +randomInt));
                                        break;

                                    // Division
                                    case 3:
                                        m.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, importedType));
                                        m.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Div));

                                        ins.Operand = ((Convert.ToInt32(ins.Operand) + (operatorChoice ? -randomInt : +randomInt)) * sizeofValue);// - RandomInt;
                                        break;

                                    // Multiplication
                                    case 4:
                                        m.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, importedType));
                                        m.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Mul));

                                        ins.Operand = (Convert.ToInt32(ins.Operand) / sizeofValue);

                                        goto SkipAdditionalInstructions;
                                }

                                m.Body.Instructions.Insert(i + 3, Instruction.CreateLdcI4(randomInt));
                                m.Body.Instructions.Insert(i + 4, Instruction.Create(operatorChoice ? OpCodes.Add : OpCodes.Sub));

                                i += 2;

                            SkipAdditionalInstructions:
                                i += 2;
                            }
                        }

                        // Optimizes macros to increase performed and reduce file size.
                        m.Body.OptimizeMacros();
                    }
                }
            }
        }

        internal class Embedding
        {
            private static readonly Random R = new Random();
            private static string EmbeddedResourceName { get; set; }

            // TODO: Make 'ByteGuardGetInteger' method take only one parameter.
            public static void EmbedConstants(ModuleDef targetModule, string decryptionKey, bool compressConstants = true)
            {
                List<byte> constantByteList = new List<byte>();

                // Finds the injected 'ByteGuardProtection' class that contains all the decryption methods.
                TypeDef constantProtections = targetModule.Find("ByteGuard.Protections.Online.Runtime.ByteGuardConstantProtections", true);

                // Finds the 'DecodeAndDecrypt' method located in the 'ByteGuardProtection' class/type.
                MethodDef byteguardGetInteger = constantProtections.FindMethod("ByteGuardGetInteger");

                // Iterates through all the types and methods that are editable.
                foreach (TypeDef t in targetModule.GetTypes().Where(type => !type.Namespace.Contains("ByteGuard.Protections.Online.Runtime")))
                {
                    foreach (MethodDef m in t.Methods.Where(mtd => mtd.HasBody))
                    {
                        // Simplifies all macros so that all constants can be encrypted.
                        m.Body.SimplifyMacros(m.Parameters);

                        // Iterates through each instruction inside the method body.
                        for (int i = 0; i < m.Body.Instructions.Count; i++)
                        {
                            // Stores the current instruction into a variable for us to work with.
                            Instruction ins = m.Body.Instructions[i];

                            // If the current instruction is a constant.
                            if (ins.IsLdcI4())
                            {
                                // Randomly generates an integer that is within the size of a byte.
                                int randomInteger = R.Next(0, 128);

                                // Inserts a call to the method that will get the constant from resources.
                                m.Body.Instructions.Insert(i + 1, Instruction.CreateLdcI4(Convert.ToInt32(ins.Operand) ^ randomInteger));
                                m.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Call, byteguardGetInteger));

                                ins.Operand = constantByteList.Count;

                                // Adds the generated byte to the byte list.
                                constantByteList.Add(Convert.ToByte(randomInteger));

                                // Skips the newly added instructions.
                                i += 2;
                            }
                        }

                        // Optimizes macros to increase performed and reduce file size.
                        m.Body.OptimizeMacros();
                    }
                }

                // Converts the constant byte list into a byte array.
                byte[] constantListBytes = constantByteList.ToArray();

                // Creates a name for the resource.
                string resourceName = Runtime.ByteGuardHelper.GetMd5(EmbeddedResourceName = R.Next(1, 1000000).ToString());

                // Creates an encryption key to encrypt the embedded resource with.
                string resourceEncryptionKey = resourceName + Runtime.ByteGuardHelper.GetMd5(decryptionKey);

                // Encrypts the byte array.
                constantListBytes = ProtectionHelper.AesEncrypt(constantListBytes, resourceEncryptionKey);

                // Compresses the byte array if the user has decided to compress.
                //if (compressBool)
                    //constantListBytes = ProtectionHelper.GzipCompressBytes(constantListBytes);
                //else
                    //Protection.Miscellaneous.ProtectionHelper.SetByteGuardBool(ByteGuardProtection, "DecompressEmbeddedConstants", false);

                constantListBytes = ProtectionHelper.GzipCompressBytes(constantListBytes);

                // Adds the byte array as an embedded resource to the module.
                EmbeddedResource constantResource = new EmbeddedResource(resourceName, constantListBytes);
                targetModule.Resources.Add(constantResource);

                CallLoadIntegersMethod(targetModule, false);
            }

            private static void CallLoadIntegersMethod(ModuleDef targetModule, bool isOffline)
            {
                // Finds the injected 'ByteGuardStringProtections' class that contains all the decryption methods.
                TypeDef stringProtections =
                    targetModule.Find("ByteGuard.Protections.Online.Runtime.ByteGuardConstantProtections", true);

                TypeDef byteguardCore =
                    targetModule.Find("ByteGuard.Protections.Online.Runtime.ByteGuardCore", true);

                MethodDef loadStringsMethod =
                    (isOffline
                    ? stringProtections.FindMethod("LoadIntegersOffline")
                    : stringProtections.FindMethod("LoadIntegers"));

                MethodDef authenticatedMethod =
                    (isOffline
                        ? byteguardCore.FindOrCreateStaticConstructor()
                        : byteguardCore.FindMethod("Authenticated"));

                foreach (Instruction i in loadStringsMethod.Body.Instructions.Where(i => i.OpCode == OpCodes.Ldstr))
                    i.Operand =
                        (isOffline
                            ? StringProtections.EmbeddedResourceNameOffline
                            : EmbeddedResourceName);

                authenticatedMethod.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, loadStringsMethod));
            }
        }
    }
}
