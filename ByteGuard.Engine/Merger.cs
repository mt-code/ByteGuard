using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteGuard.Engine
{
    public static class Merger
    {
        /// <summary>
        ///     Merges a .NET module (usually .DLL) into another .NET module (usually .EXE).
        /// </summary>
        /// <param name="moduleToMerge">The .NET module to merge into the <paramref name="targetModule"/>.</param>
        /// <param name="targetModule">The .NET module that will be combined with <paramref name="moduleToMerge"/>.</param>
        /// <param name="namespaceToMerge">If set, only copies types from this namespace.</param>
        /// <param name="mergeNamespacesWithin">If true, merges all namespaces within the <paramref name="namespaceToMerge"/>.</param>
        /// <returns>The <paramref name="targetModule"/> that has been merged with <paramref name="moduleToMerge"/>.</returns>
        public static ModuleDef Merge(ModuleDef targetModule, ModuleDef moduleToMerge, string namespaceToMerge = null, bool mergeNamespacesWithin = true)
        {
            Dictionary<IDnlibDef, IDnlibDef> moduleContent = new Dictionary<IDnlibDef, IDnlibDef>();

            if (namespaceToMerge == null)
            {
                // Injects each type from the module to merge into the target module and stores the definitions in a dictionary.
                foreach (TypeDef t in moduleToMerge.Types.Where(t => !t.IsGlobalModuleType))
                {
                    moduleContent = MergeDictionaries(moduleContent, Cloner.Inject(t, targetModule));
                }
            }
            else
            {
                // Injects each type from the module to merge into the target module and stores the definitions in a dictionary.
                foreach (TypeDef t in moduleToMerge.Types.Where(t => !t.IsGlobalModuleType && (mergeNamespacesWithin ? t.Namespace.Contains(namespaceToMerge) : t.Namespace == namespaceToMerge)))
                {
                    moduleContent = MergeDictionaries(moduleContent, Cloner.Inject(t, targetModule));
                }
            }

            Dictionary<string, IDnlibDef> convertedDictionary = ConvertDictionary(moduleContent);

            foreach (MethodDef m in targetModule.GetTypes().SelectMany(t => t.Methods.Where(method => method.HasBody)))
            {
                foreach (Instruction i in m.Body.Instructions.Where(i => i.Operand != null && convertedDictionary.ContainsKey(i.Operand.ToString())))
                    i.Operand = convertedDictionary[i.Operand.ToString()];
                
                foreach (Local l in m.Body.Variables.Where(l => convertedDictionary.ContainsKey(l.Type.ToString())))
                {
                    //var x = convertedDictionary[GetUniqueString(l.Type.TryGetTypeDef())];
                    var x = convertedDictionary[l.Type.ToString()];

                    if (x is TypeDef)
                    {
                        TypeDef injectedType = (TypeDef)convertedDictionary[l.Type.ToString()];
                        l.Type = injectedType.ToTypeSig();
                    }
                    else if (x is MethodDef)
                    {
                        MethodDef test = (MethodDef) convertedDictionary[l.Type.ToString()];

                        Console.WriteLine("Type: {0}, Method: {1}", m.DeclaringType, m.Name);
                        Console.WriteLine("Type: {0}, Method: {1}", x.Name, l.Type);
                        Console.WriteLine("");
                    }


                }

            }

            return targetModule;
        }



        private static Dictionary<string, IDnlibDef> ConvertDictionary(Dictionary<IDnlibDef, IDnlibDef> originalDictionary)
        {
            Dictionary<string, IDnlibDef> returnDictionary = new Dictionary<string, IDnlibDef>();

            foreach (
                var dictionaryItem in
                    originalDictionary.Where(
                        dictionaryItem => !returnDictionary.ContainsKey(dictionaryItem.Value.ToString())))
            {
                    returnDictionary.Add(dictionaryItem.Value.ToString(), dictionaryItem.Value);
                
            }
                

            return returnDictionary;
        }

        private static Dictionary<IDnlibDef, IDnlibDef> MergeDictionaries(
            Dictionary<IDnlibDef, IDnlibDef> firstDictionary,
            Dictionary<IDnlibDef, IDnlibDef> secondDictionary
            )
        {
            if (firstDictionary == null || secondDictionary == null)
                throw new ArgumentNullException();

            foreach (var dictionaryItem in secondDictionary)
                firstDictionary.Add(dictionaryItem.Key, dictionaryItem.Value);

            return firstDictionary;
        }
    }
}