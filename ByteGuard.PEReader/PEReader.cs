using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ByteGuard.PEReader
{
    public class PEReader
    {
        /// <summary>
        /// The DOS header
        /// </summary>
        private Data.IMAGE_DOS_HEADER dosHeader;
        /// <summary>
        /// The file header
        /// </summary>
        private Data.IMAGE_FILE_HEADER fileHeader;
        /// <summary>
        /// Optional 32 bit file header 
        /// </summary>
        private Data.IMAGE_OPTIONAL_HEADER32 optionalHeader32;
        /// <summary>
        /// Optional 64 bit file header 
        /// </summary>
        private Data.IMAGE_OPTIONAL_HEADER64 optionalHeader64;
        /// <summary>
        /// Image Section headers. Number of sections is in the file header.
        /// </summary>
        private Data.IMAGE_SECTION_HEADER[] imageSectionHeaders;


        public PEReader(string filePath)
        {
            // Read in the DLL or EXE and get the timestamp
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                dosHeader = FromBinaryReader<Data.IMAGE_DOS_HEADER>(binaryReader);

                // Add 4 bytes to the offset
                fileStream.Seek(dosHeader.e_lfanew, SeekOrigin.Begin);

                UInt32 ntHeadersSignature = binaryReader.ReadUInt32();
                fileHeader = FromBinaryReader<Data.IMAGE_FILE_HEADER>(binaryReader);
                if (Is32BitHeader)
                {
                    optionalHeader32 = FromBinaryReader<Data.IMAGE_OPTIONAL_HEADER32>(binaryReader);
                }
                else
                {
                    optionalHeader64 = FromBinaryReader<Data.IMAGE_OPTIONAL_HEADER64>(binaryReader);
                }

                imageSectionHeaders = new Data.IMAGE_SECTION_HEADER[fileHeader.NumberOfSections];
                for (int headerNo = 0; headerNo < imageSectionHeaders.Length; ++headerNo)
                {
                    imageSectionHeaders[headerNo] = FromBinaryReader<Data.IMAGE_SECTION_HEADER>(binaryReader);
                }

            }
        }

        /// <summary>
        /// Converts the specified RVA to the file offfset.
        /// </summary>
        /// <param name="rva">The RVA to convert.</param>
        /// <returns>The actual file offset that the RVA pointed to.</returns>
        public UInt32 RVAToOffset(UInt32 rva)
        {
            for (int i = 0; i < fileHeader.NumberOfSections; i++)
            {
                if (ImageSectionHeaders[i].VirtualAddress <= rva)
                {
                    if (ImageSectionHeaders[i].VirtualAddress + ImageSectionHeaders[i].VirtualSize > rva)
                    {
                        rva -= ImageSectionHeaders[i].VirtualAddress;
                        rva += ImageSectionHeaders[i].PointerToRawData;
                            
                        return rva;
                    }
                }
            }
            return 0;
        }

        public UInt32 GetSectionVAFromRawAddress(uint raw)
        {
            for (int i = 0; i < fileHeader.NumberOfSections; i++)
            {
                if (ImageSectionHeaders[i].PointerToRawData == raw)
                {
                    return ImageSectionHeaders[i].VirtualAddress;
                }
            }

            return 0;
        }
     

        public
            int GetOffset(int rva, int offset)
        {
            return Convert.ToInt32(RVAToOffset(Convert.ToUInt32(rva + offset)));
        }

        /// <summary>
        /// Reads in a block from a file and converts it to the struct
        /// type specified by the template parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static T FromBinaryReader<T>(BinaryReader reader)
        {
            // Read in a byte array
            byte[] bytes = reader.ReadBytes(Marshal.SizeOf(typeof(T)));

            // Pin the managed memory while, copy it out the data, then unpin it
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();

            return theStructure;
        }

        /// <summary>
        /// Gets if the file header is 32 bit or not
        /// </summary>
        public bool Is32BitHeader
        {
            get
            {
                const UInt16 IMAGE_FILE_32BIT_MACHINE = 0x0100;
                return (IMAGE_FILE_32BIT_MACHINE & FileHeader.Characteristics) == IMAGE_FILE_32BIT_MACHINE;
            }
        }

        /// <summary>
        /// Gets the file header
        /// </summary>
        public Data.IMAGE_FILE_HEADER FileHeader
        {
            get
            {
                return fileHeader;
            }
        }


        /// <summary>
        /// Gets the optional header
        /// </summary>
        public Data.IMAGE_OPTIONAL_HEADER32 OptionalHeader32
        {
            get
            {
                return optionalHeader32;
            }
        }

        /// <summary>
        /// Gets the optional header
        /// </summary>
        public Data.IMAGE_OPTIONAL_HEADER64 OptionalHeader64
        {
            get
            {
                return optionalHeader64;
            }
        }

        public Data.IMAGE_SECTION_HEADER[] ImageSectionHeaders
        {
            get
            {
                return imageSectionHeaders;
            }
        }
    }
}
