using System;
using System.Management;
using System.Threading;

namespace ByteGuard.Helper.Core
{
    class Hwid
    {
        private static string _hardwareIdentifier = "NOTSET";
        public static string HardwareIdentifier
        {
            get { return _hardwareIdentifier; }
            set { _hardwareIdentifier = value; }
        }

        public static string Get()
        {
            //return GetCPUidentifiers();
            return Methods.GetMd5(String.Format("{0}{1}{2}{3}{4}",
                                    GetCpuIdentifiers(),
                                        GetBiosIdentifiers(),
                                            GetHddIdentifiers(),
                                                GetMbIdentifiers(),
                                                    GetGfxIdentifiers()));
        }

        public static void Update()
        {
            while (true)
            {
                _hardwareIdentifier = Get();

                Thread.Sleep(120000);
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private static string GetCpuIdentifiers()
        {
            return String.Format("{0}{1}", Getid("Win32_Processor", "Processorid"), Getid("Win32_Processor", "Name"));
        }

        private static string GetBiosIdentifiers()
        {
            return String.Format("{0}{1}{2}{3}{4}{5}", Getid("Win32_BIOS", "Manufacturer"), Getid("Win32_BIOS", "SMBIOSBIOSVersion"), Getid("Win32_BIOS", "identificationCode"), Getid("Win32_BIOS", "SerialNumber"), Getid("Win32_BIOS", "ReleaseDate"), Getid("Win32_BIOS", "Version"));
        }

        private static string GetHddIdentifiers()
        {
            return String.Format("{0}{1}{2}", Getid("Win32_DiskDrive", "Model"), Getid("Win32_DiskDrive", "Signature"), Getid("Win32_DiskDrive", "TotalHeads"));
        }

        private static string GetMbIdentifiers()
        {
            return String.Format("{0}{1}{2}{3}", Getid("Win32_BaseBoard", "Model"), Getid("Win32_BaseBoard", "Manufacturer"), Getid("Win32_BaseBoard", "Name"), Getid("Win32_BaseBoard", "SerialNumber"));
        }

        private static string GetGfxIdentifiers()
        {
            return String.Format("{0}{1}", Getid("Win32_VideoController", "Name"), Getid("Win32_VideoController", "DriverVersion"));
        }

        private static string Getid(string classid, string propertyid)
        {
            try
            {
                using (ManagementClass m = new ManagementClass(classid))
                {
                    using (ManagementObjectCollection c = m.GetInstances())
                    {
                        foreach (ManagementBaseObject o in c)
                        {
                            return o[propertyid].ToString();
                        }
                    }
                }
            }
            catch
            {
                // ignored
            }

            return null;
        }
    }
}
