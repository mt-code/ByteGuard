using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace ByteGuard.Protections.Online
{
    public class StringProtections
    {
        public static string EmbeddedResourceName { get; set; }
        public static string EmbeddedResourceNameOffline { get; set; }

        public static void Process(ModuleDefMD targetModule, string decryptionKey, bool encodeStrings = true, bool embedStrings = true, bool compressStrings = true)
        {
            decryptionKey = Runtime.ByteGuardHelper.GetMd5(decryptionKey);

            Encryption.EncryptStrings(targetModule, encodeStrings, decryptionKey);
            Embedding.EmbedStrings(targetModule, decryptionKey);
        }
    }

    internal class Encryption
    {
        private static readonly Random R = new Random();

        public static void EncryptStrings(ModuleDefMD targetModule, bool encodeStrings, string encryptionKey)
        {
            // Finds the injected 'ByteGuardStringProtections' class that contains all the decryption methods.
            TypeDef stringProtections =
                targetModule.Find("ByteGuard.Protections.Online.Runtime.ByteGuardStringProtections", true);

            // Finds the 'DecodeAndDecrypt' method located in the 'ByteGuardProtection' class/type.
            MethodDef decryptStringMethod = (encodeStrings
                ? stringProtections.FindMethod("DecodeAndDecrypt")
                : stringProtections.FindMethod("Decrypt"));

            // TODO: Enable this.
            // Encrypts all strings within the 'ByteGuardProtection' type using an offline key.
            foreach (
                TypeDef t in
                    targetModule.GetTypes()
                        .Where(type => type.Namespace.Contains("ByteGuard.Protections.Online.Runtime")))
            {
                    EncryptOfflineType(t, stringProtections.FindMethod("DecodeAndDecryptK"));
            }

            // Iterates through all the types and methods that are editable.
            foreach (TypeDef t in targetModule.GetTypes().Where(type => !type.Namespace.Contains("ByteGuard.Protections.Online.Runtime"))) //TODO: Ignore any classes required for string decrypt
            {
                foreach (MethodDef m in t.Methods.Where(mtd => mtd.HasBody))
                {
                    // Iterates through each instruction and encrypts/encodes any 'ldstr' instruction.
                    for (int i = 0; i < m.Body.Instructions.Count; i++)
                    {
                        // Stores the current instruction into a new variable.
                        Instruction ins = m.Body.Instructions[i];

                        // Checks that the current instruction is a string and is not null.
                        if (ins.Operand is string)
                        {
                            // Randomly generates the encryption key's starting index and length, this will be parsed from the 25-character downloadable decryption key.
                            int keyStartPosition = R.Next(0, (encryptionKey.Length - 1));
                            int keyLength = R.Next(1, ((encryptionKey.Length - 1) - keyStartPosition));

                            // Parses the encryption key using the start index and length generated above.
                            string key = encryptionKey.Substring(keyStartPosition, keyLength);

                            // Changes the instruction operand to the encrypted version of the string.
                            ins.Operand = Methods.EncryptString(ins.Operand.ToString(), key, encodeStrings);

                            // Inserts three new instructions, one of the start index of the key, the next is the key length and the third is the call to the decryption method.
                            m.Body.Instructions.Insert(i + 1, Instruction.CreateLdcI4(keyStartPosition));
                            m.Body.Instructions.Insert(i + 2, Instruction.CreateLdcI4(keyLength));
                            m.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Call, decryptStringMethod));

                            // Simplify the branches of any modified methods as some projects can crash without this.
                            m.Body.Instructions.SimplifyBranches();

                            // Increase the counter by 3 to skip over the newly added instructions.
                            i += 3;
                        }
                    }
                }
            }
        }

        private static void EncryptOfflineType(TypeDef targetType, MethodDef decryptionMethod)
        {
            foreach (MethodDef m in targetType.Methods.Where(mtd => mtd.HasBody && mtd.Name != "LoadIntegers" && mtd.Name != "LoadStrings" && mtd.Name != "LoadStringsOffline"))
            {
                for (int i = 0; i < m.Body.Instructions.Count; i++)
                {
                    // Stores the current instruction into a new variable.
                    Instruction ins = m.Body.Instructions[i];

                    if (ins.Operand is string)
                    {
                        // Randomly generates an offline encryption key between 0 - 1,000,000.
                        string key = R.Next(0, 1000000).ToString();

                        // Changes the instruction operand to the encrypted version of the string.
                        ins.Operand = Methods.EncryptString(ins.Operand.ToString(), key, true);

                        // Inserts two new instructions, one contains the decryption key and the next is the call to the decryption method.
                        m.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, key));
                        m.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Call, decryptionMethod));

                        // Increase the counter by 2 to skip over the newly added instructions.
                        i += 2;
                    }
                }
            }
        }
    }

    internal class Embedding
    {
        private readonly static Random R = new Random();

        public static void EmbedStrings(ModuleDef targetModule, string decryptionKey, bool compressStrings = true)
        {
            // Finds the injected 'ByteGuardStringProtections' class that contains all the decryption methods.
            TypeDef stringProtections =
                targetModule.Find("ByteGuard.Protections.Online.Runtime.ByteGuardStringProtections", true);

            // Finds the 'DecodeAndDecrypt' method located in the 'ByteGuardProtection' class/type.
            MethodDef getStringMethod = stringProtections.FindMethod("GetString");

            // TODO: Enable/fix this.
            EmbedOfflineStrings(targetModule);

            // Creates an integer variable that will hold the starting index of each string.
            int stringIndex = 0;

            // A list collection for the method strings to be added to.
            List<string> stringList = new List<string>();

            // Iterates through all the types and methods that are editable.
            foreach (TypeDef t in targetModule.GetTypes().Where(type => !type.Namespace.Contains("ByteGuard.Protections.Online.Runtime")))
            {
                foreach (MethodDef m in t.Methods.Where(mtd => mtd.HasBody))
                {
                    // Iterates through each instruction inside the method body.
                    for (int i = 0; i < m.Body.Instructions.Count; i++)
                    {
                        // Stores the current instruction into a new variable.
                        Instruction ins = m.Body.Instructions[i];

                        // Checks that the current instruction is a string and is not null.
                        if (ins.Operand is string)
                        {
                            // Stores the string into a string variable.
                            string stringToEmbed = ins.Operand.ToString();

                            // Adds the string to be embedded into the StringList collection.
                            stringList.Add(stringToEmbed);

                            // Changes the opcode and operand of the current instruction to hold the strings starting index.
                            ins.OpCode = OpCodes.Ldc_I4;
                            ins.Operand = stringIndex;

                            // Inserts two new instructions containing the string length and the call to the 'GetString' method.
                            m.Body.Instructions.Insert(i + 1, Instruction.CreateLdcI4(stringToEmbed.Length));
                            m.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Call, getStringMethod));

                            // Increases the StringIndex variable by the size of the string.
                            stringIndex += stringToEmbed.Length;

                            // Increase the counter by 3 to skip over the newly added instructions.
                            i += 3;
                        }
                    }
                }
            }

            // Converts the 'StringList' collection into a byte array.
            byte[] stringListBytes = stringList.SelectMany(s => Encoding.UTF8.GetBytes(s)).ToArray();

            // ResourceName = MD5Hash of randomly genereted integer. (Generated at the start of obfuscation).
            string resourceName = Runtime.ByteGuardHelper.GetMd5(StringProtections.EmbeddedResourceName = R.Next(1, 1000000).ToString());

            // Creates the ResourceEncryptionKey that will be used to encrypt the embedded constants.
            string resourceEncryptionKey = resourceName + Runtime.ByteGuardHelper.GetMd5(decryptionKey);

            // Encrypts the embedded string bytes using the generated encryption key.
            stringListBytes = ProtectionHelper.AesEncrypt(stringListBytes, resourceEncryptionKey);
            
            // Compresses the bytes.
            stringListBytes = ProtectionHelper.GzipCompressBytes(stringListBytes);
            
            // Embeds the byte array as a resource to the target module.
            EmbeddedResource stringsResource = new EmbeddedResource(resourceName, stringListBytes);//EmbeddedResourceName, StringListBytes);
            targetModule.Resources.Add(stringsResource);

            CallLoadStringsMethod(targetModule, false);
        }

        // TODO: Complete this.
        private static void EmbedOfflineStrings(ModuleDef targetModule)
        {
            // Finds the injected 'ByteGuardStringProtections' class that contains all the decryption methods.
            TypeDef stringProtections =
                targetModule.Find("ByteGuard.Protections.Online.Runtime.ByteGuardStringProtections", true);

            // Finds the 'DecodeAndDecrypt' method located in the 'ByteGuardProtection' class/type.
            MethodDef getStringOfflineMethod = stringProtections.FindMethod("GetStringOffline");

            // Creates an integer variable that will hold the starting index of each string.
            int stringIndex = 0;

            // A list collection for the method strings to be added to.
            List<string> stringList = new List<string>();

            // Iterates through all the types and methods that are editable.
            foreach (TypeDef t in targetModule.GetTypes().Where(type => type.Namespace.Contains("ByteGuard.Protections.Online.Runtime")))
            {
                foreach (MethodDef m in t.Methods.Where(mtd => mtd.HasBody && mtd.Name != "LoadIntegers" && mtd.Name != "LoadStrings" && mtd.Name != "LoadStringsOffline" && mtd.Name != "GetMd5"))
                {
                    // Iterates through each instruction inside the method body.
                    for (int i = 0; i < m.Body.Instructions.Count; i++)
                    {
                        // Stores the current instruction into a new variable.
                        Instruction ins = m.Body.Instructions[i];

                        // Checks that the current instruction is a string and is not null.
                        if (ins.Operand is string)
                        {
                            // Stores the string into a string variable.
                            string stringToEmbed = ins.Operand.ToString();

                            // Adds the string to be embedded into the StringList collection.
                            stringList.Add(stringToEmbed);

                            // Changes the opcode and operand of the current instruction to hold the strings starting index.
                            ins.OpCode = OpCodes.Ldc_I4;
                            ins.Operand = stringIndex;

                            // Inserts two new instructions containing the string length and the call to the 'GetString' method.
                            m.Body.Instructions.Insert(i + 1, Instruction.CreateLdcI4(stringToEmbed.Length));
                            m.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Call, getStringOfflineMethod));

                            // Increases the StringIndex variable by the size of the string.
                            stringIndex += stringToEmbed.Length;

                            // Increase the counter by 3 to skip over the newly added instructions.
                            i += 2;
                        }
                    }
                }
            }

            // Converts the 'StringList' collection into a byte array.
            byte[] stringListBytes = stringList.SelectMany(s => Encoding.UTF8.GetBytes(s)).ToArray();

            // ResourceName = MD5Hash of randomly genereted integer. (Generated at the start of obfuscation).
            string resourceName = Runtime.ByteGuardHelper.GetMd5(StringProtections.EmbeddedResourceNameOffline = R.Next(1, 1000000).ToString());

            // TODO: Encrypt.
            // Creates the ResourceEncryptionKey that will be used to encrypt the embedded constants.
            //string resourceEncryptionKey = resourceName + Runtime.ByteGuardHelper.GetMd5(decryptionKey);

            // Encrypts the embedded string bytes using the generated encryption key.
            //stringListBytes = ProtectionHelper.AesEncrypt(stringListBytes, resourceEncryptionKey);

            // Compresses the bytes.
            stringListBytes = ProtectionHelper.GzipCompressBytes(stringListBytes);

            // Embeds the byte array as a resource to the target module.
            EmbeddedResource stringsResource = new EmbeddedResource(resourceName, stringListBytes);//EmbeddedResourceName, StringListBytes);
            targetModule.Resources.Add(stringsResource);

            CallLoadStringsMethod(targetModule, true);
        }

        /// <summary>
        /// Inserts the call to the load strings method into the 'Authenticated' method.
        /// </summary>
        /// <param name="targetModule">The target module to insert the call into.</param>
        /// <param name="isOffline">If true, selects the offline methods.</param>
        private static void CallLoadStringsMethod(ModuleDef targetModule, bool isOffline)
        {
            // Finds the injected 'ByteGuardStringProtections' class that contains all the decryption methods.
            TypeDef stringProtections =
                targetModule.Find("ByteGuard.Protections.Online.Runtime.ByteGuardStringProtections", true);

            TypeDef byteguardCore =
                targetModule.Find("ByteGuard.Protections.Online.Runtime.ByteGuardCore", true);

            MethodDef loadStringsMethod =
                (isOffline
                ? stringProtections.FindMethod("LoadStringsOffline")
                : stringProtections.FindMethod("LoadStrings"));

            MethodDef authenticatedMethod =
                (isOffline
                    ? byteguardCore.FindOrCreateStaticConstructor()
                    : byteguardCore.FindMethod("Authenticated"));

            foreach (Instruction i in loadStringsMethod.Body.Instructions.Where(i => i.OpCode == OpCodes.Ldstr))
                i.Operand =
                    (isOffline
                        ? StringProtections.EmbeddedResourceNameOffline
                        : StringProtections.EmbeddedResourceName);

            authenticatedMethod.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, loadStringsMethod));
        }
    }

    internal class Methods
    {
        public static string EncryptString(string inputString, string encryptionKey, bool encodeStrings)
        {
            return (encodeStrings
                ? EncodeString(ProtectionHelper.AesEncrypt(inputString, encryptionKey))
                : ProtectionHelper.AesEncrypt(inputString, encryptionKey));
        }

        private static string EncodeString(string inputString)
        {
            // Method variables.
            char previousCharacter = new char(); // Previous character.
            StringBuilder stringBuilder = new StringBuilder();

            // Iterates through and encodes each character in the InputString.
            foreach (char c in inputString)
            {
                //sb.Append(sb.Length == 0 ? (pc = c).ToString() : String.Format("-{0}", (c ^ pc) * pc * ((pc = c) / c)));
                stringBuilder.Append(stringBuilder.Length == 0 ? c.ToString() : String.Format("-{0}", (c ^ previousCharacter) * previousCharacter));
                previousCharacter = c;
            }

            // Returns the encoded string.
            return stringBuilder.ToString();
        }
    }
}
