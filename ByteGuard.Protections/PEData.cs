using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ByteGuard.Protections
{
    class PEData
    {
        public static SECTION_HEADER_STRUCT[] SECTION_HEADERS;
        public static IMAGE_FILE_HEADER_STRUCT IMAGE_FILE_HEADER;

        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms680313%28v=vs.85%29.aspx
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_FILE_HEADER_STRUCT
        {
            public UInt16 Machine;
            public UInt16 NumberOfSections;
            public UInt32 TimeDateStamp;
            public UInt32 PointerToSymbolTable;
            public UInt32 NumberOfSymbols;
            public UInt16 SizeOfOptionalHeader;
            public UInt16 Characteristics;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SECTION_HEADER_STRUCT
        {
            public UInt64 Name;
            public UInt32 VirtualSize;
            public UInt32 VirtualAddress;
            public UInt32 RawSize;
            public UInt32 RawAddress;
            public UInt32 RelocAddress;
            public UInt32 LineNumbers;
            public UInt16 RelocationsNumber;
            public UInt16 LineNumbersNumber;
            public UInt32 Characteristics;
        }

        public static void ProcessPE(string filePath)
        {
            using (FileStream FS = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                BinaryReader BR = new BinaryReader(FS);
                IMAGE_FILE_HEADER = FromBinaryReader<IMAGE_FILE_HEADER_STRUCT>(BR);

                Array.Resize(ref SECTION_HEADERS, (int)IMAGE_FILE_HEADER.NumberOfSections);
                for (int i = 0; i <= IMAGE_FILE_HEADER.NumberOfSections - 1; i++)
                {
                    SECTION_HEADERS[i] = FromBinaryReader<SECTION_HEADER_STRUCT>(BR);
                }

                BR.Close();
            }
        }

        public static int GetOffset(int RVA, int Offset)
        {
            return Convert.ToInt32(RVAToOffset(Convert.ToUInt32(RVA + Offset)));
        }

        public static UInt32 RVAToOffset(UInt32 dwRVA)
        {
            for (int i = 0; i <= IMAGE_FILE_HEADER.NumberOfSections - 1; i++)
            {
                if (SECTION_HEADERS[i].VirtualAddress <= dwRVA)
                {
                    if (SECTION_HEADERS[i].VirtualAddress + SECTION_HEADERS[i].VirtualSize > dwRVA)
                    {
                        dwRVA -= SECTION_HEADERS[i].VirtualSize;
                        dwRVA += SECTION_HEADERS[i].RawSize;
                        return dwRVA;
                    }
                }
            }
            return 0;
        }

        private static T FromBinaryReader<T>(BinaryReader reader)
        {
            byte[] bytes = reader.ReadBytes(Marshal.SizeOf(typeof(T)));
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return theStructure;
        }
    }
}
