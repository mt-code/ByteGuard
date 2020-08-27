using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace ByteGuard.Protections.Online
{
    internal class ControlFlowProtection
    {
        private static readonly Random R = new Random();

        public static void Process(ModuleDefMD targetModule)
        {
            foreach (TypeDef t in targetModule.GetTypes())//.Where(t => !t.Namespace.Contains("ByteGuard.Protections")))
            {
                foreach (MethodDef m in t.Methods.Where(m => m.HasBody && !m.Body.HasExceptionHandlers))
                {
                    ScrambleBody(m);
                }
            }
        }

        private static void ScrambleBody(MethodDef targetMethod)
        {
            List<Instruction> instructions = targetMethod.Body.Instructions.ToList();
            List<Instruction> scrambled = instructions.OrderBy(c => R.Next()).Select(c => c).ToList(); // Scramble

            for (int i = 0; i < scrambled.Count; i++)
                targetMethod.Body.Instructions[i] = scrambled[i];

            Dictionary<Instruction, Instruction> scrambledDictionary =
                targetMethod.Body.Instructions.ToList().ToDictionary(i => i);

            int index = 0;

            for (int i = 0; i < scrambled.Count; i++)
            {
                targetMethod.Body.Instructions.Insert(index,
                    Instruction.Create(OpCodes.Br, scrambledDictionary[instructions[i]]));

                index = targetMethod.Body.Instructions.ToList().FindIndex(ins => ins == instructions[i]) + 1;
            }

            targetMethod.Body.KeepOldMaxStack = true;
            targetMethod.Body.SimplifyBranches();
        }
    }
}
