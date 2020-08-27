using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ByteGuard.Hook
{
    public unsafe class Data
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate uint compileMethod(IntPtr self, ICorJitInfo* comp, CORINFO_METHOD_INFO* info, uint flags, byte** nativeEntry, uint* nativeSizeOfCode);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void getEHinfo(IntPtr self, IntPtr ftn, uint EHnumber, CORINFO_EH_CLAUSE* clause);


        public static bool hasLinkInfo;

        [StructLayout(LayoutKind.Sequential, Size = 0x18)]
		public struct CORINFO_EH_CLAUSE { }

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct CORINFO_METHOD_INFO {
			//public IntPtr ftn;
			//public IntPtr scope;
			//public byte* ILCode;
			//public uint ILCodeSize;

            public IntPtr methodHandle;
            public IntPtr moduleHandle;
            public byte* ilCode;
            public uint ilCodeSize;
            public UInt16 maxStack;
            public UInt16 EHCount;
            public UInt32 corInfoOptions;
            public CorinfoSigInst args;
            public CorinfoSigInst locals;
		}

        [StructLayout(LayoutKind.Sequential)]
        public struct CorinfoSigInst
        {
            public uint classInstCount;
            public IntPtr* classInst;
            public uint methInstCount;
            public IntPtr* methInst;
        }

		[StructLayout(LayoutKind.Sequential)]
		public struct CORINFO_SIG_INFO_x64 {
			public uint callConv;
			private uint pad1;
			public IntPtr retTypeClass;
			public IntPtr retTypeSigClass;
			public byte retType;
			public byte flags;
			public ushort numArgs;
			private uint pad2;
			public CORINFO_SIG_INST_x64 sigInst;
			public IntPtr args;
			public IntPtr sig;
			public IntPtr scope;
			public uint token;
			public uint pad3;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct CORINFO_SIG_INFO_x86 {
			public uint callConv;
			public IntPtr retTypeClass;
			public IntPtr retTypeSigClass;
			public byte retType;
			public byte flags;
			public ushort numArgs;
			public CORINFO_SIG_INST_x86 sigInst;
			public IntPtr args;
			public IntPtr sig;
			public IntPtr scope;
			public uint token;
		}

		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct CORINFO_SIG_INST_x64 { }

		[StructLayout(LayoutKind.Sequential, Size = 16)]
		public struct CORINFO_SIG_INST_x86 { }

		[StructLayout(LayoutKind.Sequential)]
		public struct ICorClassInfo {
			public IntPtr* vfptr;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct ICorDynamicInfo {
			public IntPtr* vfptr;
			public int* vbptr;

			public static ICorStaticInfo* ICorStaticInfo(ICorDynamicInfo* ptr) {
				return (ICorStaticInfo*)((byte*)&ptr->vbptr + ptr->vbptr[hasLinkInfo ? 9 : 8]);
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct ICorJitInfo {
			public IntPtr* vfptr;
			public int* vbptr;

			public static ICorDynamicInfo* ICorDynamicInfo(ICorJitInfo* ptr) {
				hasLinkInfo = ptr->vbptr[10] > 0 && ptr->vbptr[10] >> 16 == 0; // != 0 and hiword byte == 0
				return (ICorDynamicInfo*)((byte*)&ptr->vbptr + ptr->vbptr[hasLinkInfo ? 10 : 9]);
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct ICorMethodInfo {
			public IntPtr* vfptr;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct ICorModuleInfo {
			public IntPtr* vfptr;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct ICorStaticInfo {
			public IntPtr* vfptr;
			public int* vbptr;

			public static ICorMethodInfo* ICorMethodInfo(ICorStaticInfo* ptr) {
				return (ICorMethodInfo*)((byte*)&ptr->vbptr + ptr->vbptr[1]);
			}

			public static ICorModuleInfo* ICorModuleInfo(ICorStaticInfo* ptr) {
				return (ICorModuleInfo*)((byte*)&ptr->vbptr + ptr->vbptr[2]);
			}

			public static ICorClassInfo* ICorClassInfo(ICorStaticInfo* ptr) {
				return (ICorClassInfo*)((byte*)&ptr->vbptr + ptr->vbptr[3]);
			}
		}

        public class CorMethodInfoHook
        {
            private static int ehNum = -1;
            public CORINFO_EH_CLAUSE* clauses;
            public IntPtr ftn;
            public ICorMethodInfo* info;
            public getEHinfo n_getEHinfo;
            public IntPtr* newVfTbl;

            public getEHinfo o_getEHinfo;
            public IntPtr* oldVfTbl;

            private void hookEHInfo(IntPtr self, IntPtr ftn, uint EHnumber, CORINFO_EH_CLAUSE* clause)
            {
                if (ftn == this.ftn)
                {
                    *clause = clauses[EHnumber];
                }
                else
                {
                    o_getEHinfo(self, ftn, EHnumber, clause);
                }
            }

            public void Dispose()
            {
                Marshal.FreeHGlobal((IntPtr) newVfTbl);
                info->vfptr = oldVfTbl;
            }

            /*public static CorMethodInfoHook Hook(ICorJitInfo* comp, IntPtr ftn, CORINFO_EH_CLAUSE* clauses) {
				ICorMethodInfo* mtdInfo = ICorStaticInfo.ICorMethodInfo(ICorDynamicInfo.ICorStaticInfo(ICorJitInfo.ICorDynamicInfo(comp)));
				IntPtr* vfTbl = mtdInfo->vfptr;
				const int SLOT_NUM = 0x1B;
				var newVfTbl = (IntPtr*)Marshal.AllocHGlobal(SLOT_NUM * IntPtr.Size);
				for (int i = 0; i < SLOT_NUM; i++)
					newVfTbl[i] = vfTbl[i];
				if (ehNum == -1)
					for (int i = 0; i < SLOT_NUM; i++) {
						bool isEh = true;
						for (var func = (byte*)vfTbl[i]; *func != 0xe9; func++)
							if (IntPtr.Size == 8 ?
								    (*func == 0x48 && *(func + 1) == 0x81 && *(func + 2) == 0xe9) :
								    (*func == 0x83 && *(func + 1) == 0xe9)) {
								isEh = false;
								break;
							}
						if (isEh) {
							ehNum = i;
							break;
						}
					}

				var ret = new CorMethodInfoHook {
					ftn = ftn,
					info = mtdInfo,
					clauses = clauses,
					newVfTbl = newVfTbl,
					oldVfTbl = vfTbl
				};

				ret.n_getEHinfo = ret.hookEHInfo;
				ret.o_getEHinfo = (getEHinfo)Marshal.GetDelegateForFunctionPointer(vfTbl[ehNum], typeof (getEHinfo));
				newVfTbl[ehNum] = Marshal.GetFunctionPointerForDelegate(ret.n_getEHinfo);

				mtdInfo->vfptr = newVfTbl;
				return ret;
			}
		}*/

            [StructLayout(LayoutKind.Sequential)]
            public struct MethodData
            {
                public readonly uint ILCodeSize;
                public readonly uint MaxStack;
                public readonly uint EHCount;
                public readonly uint LocalVars;
                public readonly uint Options;
                public readonly uint MulSeed;
            }
        }
    }
}
