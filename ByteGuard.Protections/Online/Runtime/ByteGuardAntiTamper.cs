using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ByteGuard.Protections.Online.Runtime
{
    public unsafe class ByteGuardAntiTamper
    {
        [DllImport("kernel32.dll", EntryPoint="VirtualProtect")]
        private static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);

        public static void DecryptMethods()
        {
            Module currentModule = typeof (ByteGuardAntiTamper).Module;

            IntPtr hInstance = Marshal.GetHINSTANCE(currentModule);

            //int rva = 0x20CB;
            //int size = 0x14;

            

            
            
            Stream input = new UnmanagedMemoryStream((byte*)hInstance.ToPointer(), 0xfffffffL, 0xfffffffL, FileAccess.ReadWrite);
            using (BinaryReader reader = new BinaryReader(input))
            {
                input.Seek(0x20, SeekOrigin.Begin);

                uint sectionPosition = reader.ReadUInt32();

                input.Seek(sectionPosition, SeekOrigin.Begin);

                int methodCount = (int)reader.ReadUInt32();

                uint old;

                for (int i = 0; i < methodCount; i++)
                {
                    int rva = (int) reader.ReadUInt32();
                    int size = (int) reader.ReadUInt32();
                    //reader.ReadUInt32();
                    //reader.ReadUInt32();


                    IntPtr methodAddress = (IntPtr)(ulong)((int)(hInstance + rva));

                    //byte[] source = reader.ReadBytes(reader.ReadUInt32());
                    byte[] source = reader.ReadBytes(size);

                    //MessageBox.Show(String.Format("RVA: {0:X}\nSize: {1:X}\nPosition: {3:X}\nBytes: {2}",
                    //    rva, size, BitConverter.ToString(source), input.Position));

                    VirtualProtect(methodAddress, (uint)size, 0x40, out old);
                    Marshal.Copy(source, 0, methodAddress, source.Length);
                    VirtualProtect(methodAddress, (uint)size, old, out old);
                }
           
            }
        }

        private static int GetPosition()
        {
            return 0;
        }
    }
}
