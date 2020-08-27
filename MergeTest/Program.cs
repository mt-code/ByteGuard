using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteGuard.Engine;
using dnlib.DotNet;
using dnlib.DotNet.Writer;
using dnlib.DotNet.Pdb;

namespace MergeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ModuleDefMD targetModule = ModuleDefMD.Load(args[0]);
            ModuleDefMD moduleToMerge = ModuleDefMD.Load(args[1]);
            
            Merger.Merge(targetModule, moduleToMerge, "ByteGuard.Helper.Core").Write("A:/merge.exe");
        }
    }
}
