using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace ByteGuard.Protections.Online.Runtime
{
    public class ByteGuardAntiTamperDynamic
    {
        private delegate long SquareItInvoker(int input);

        private delegate TReturn OneParameter<TReturn, TParameter0>
            (TParameter0 p0);

        public static void SetKey()
        {
            Type dynamicType = CreateDynamicType();
            MethodInfo method = dynamicType.GetMethod("SetKey", BindingFlags.Static | BindingFlags.Public);

            var activator = Activator.CreateInstance(dynamicType);
            string key = (string)method.Invoke(activator, new object[] {"haha123"});

            System.Windows.Forms.MessageBox.Show(key);
        }

        private static Type CreateDynamicType()
        {
            try
            {
                AssemblyName assembly = new AssemblyName("d");

                TypeBuilder typeBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
                    assembly, AssemblyBuilderAccess.RunAndSave
                    ).DefineDynamicModule(
                        assembly.Name, String.Format("{0}.exe", assembly.Name)
                    ).DefineType("Dynamic", TypeAttributes.Public);

                byte[] il = DeobfuscateCode(GetIL());

                typeBuilder.DefineMethod("SetKey",
                    MethodAttributes.Static | MethodAttributes.Public,
                        CallingConventions.Standard,
                            typeof(string),
                                new[] { typeof(string) }).CreateMethodBody(il, il.Length);

                return typeBuilder.CreateType();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }


            return null;
        }

        private static byte[] GetIL()
        {
            return
                typeof (ByteGuardAntiTamperDynamic).GetMethod("Set", BindingFlags.NonPublic | BindingFlags.Static)
                    .GetMethodBody()
                    .GetILAsByteArray();
        }

        private static byte[] DeobfuscateCode(byte[] byteArray)
        {
            return byteArray;
        }

        private static string Set(string s)
        {
            s = (10 ^ 10).ToString();

            return s;
        }
    }
}
