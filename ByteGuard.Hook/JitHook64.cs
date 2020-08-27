using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ByteGuard.Hook
{
    public unsafe class JitHook64
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lib);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr lib, string proc);

        [DllImport("kernel32.dll")]
        private static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);

        private delegate IntPtr* getJit();

        private static Data.compileMethod originalDelegate;
        private static Data.compileMethod handler;

        public static void Hook()
        {
            bool isNetFramework4 = RuntimeEnvironment.GetSystemVersion()[1] == '4';

            IntPtr jitLibrary = LoadLibrary(isNetFramework4 ? "clrjit.dll" : "mscorjit.dll");

            getJit getJitDelegate = (getJit)Marshal.GetDelegateForFunctionPointer(GetProcAddress(jitLibrary, "getJit"), typeof(getJit));

            IntPtr getJitAddress = *getJitDelegate();
 
            IntPtr originalAddress = *(IntPtr*)getJitAddress;

            //originalDelegate = (Data.compileMethod)Marshal.GetDelegateForFunctionPointer(getJitAddress, typeof(Data.compileMethod));
            handler = HookHandler;

            originalDelegate =
                (Data.compileMethod) Marshal.GetDelegateForFunctionPointer(originalAddress, typeof (Data.compileMethod));

            RuntimeHelpers.PrepareDelegate(originalDelegate);
            RuntimeHelpers.PrepareDelegate(handler);

            uint oldPl;

            VirtualProtect(getJitAddress, (uint)IntPtr.Size, 0x40, out oldPl);
            Marshal.WriteIntPtr(getJitAddress, Marshal.GetFunctionPointerForDelegate(handler));
            VirtualProtect(getJitAddress, (uint)IntPtr.Size, oldPl, out oldPl);
        }

        private static uint HookHandler(IntPtr self, Data.ICorJitInfo* comp, Data.CORINFO_METHOD_INFO* methodInfo, uint flags,
            byte** nativeEntry, uint* nativeSizeOfCode)
        {
            int token;
            token = (0x06000000 + *(ushort*)methodInfo->methodHandle);

            System.Windows.Forms.MessageBox.Show(token.ToString("x8"));

            return originalDelegate(self, comp, methodInfo, flags, nativeEntry, nativeSizeOfCode);
        }
    }
}
