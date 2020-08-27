using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace ByteGuard.Protections.Online.Anti
{
    internal class Reflector
    {
        public static void Process(ModuleDef targetModule)
        {
            

            foreach (TypeDef t in targetModule.GetTypes().Where(t => t.Name == "Form1"))
            {
                MethodDefUser m = new MethodDefUser("anti", MethodSig.CreateStatic(targetModule.CorLibTypes.Void),
MethodImplAttributes.IL | MethodImplAttributes.Managed,
MethodAttributes.Public | MethodAttributes.Static);
                CilBody body = new CilBody();


                m.Body = body;

                body.Instructions.Add(Instruction.Create(OpCodes.Ret));

                t.Methods.Add(m);
            }
        }
    }
}
