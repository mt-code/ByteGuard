using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using ByteGuard.ByteGuardInterface.Forms;
using ByteGuard.ByteGuardInterface.Theme;
using ByteGuard.ByteGuardInterface.UserControls.MyAccount;
using ByteGuard.ByteGuardInterface.UserControls.MyLibrary;
using ByteGuard.ByteGuardInterface.UserControls.MyPrograms;

namespace ByteGuard.ByteGuardInterface.Globals
{
    public class Variables
    {
        // List variables.
        public static List<ByteGuardProgram> MyPrograms = new List<ByteGuardProgram>();
        public static List<ByteGuardProgram> MyLibrary = new List<ByteGuardProgram>();
        public static List<ByteGuardLicense> MyLicenses = new List<ByteGuardLicense>();

        // Dictionary variables.
        public static Dictionary<string, string> MyVariables = new Dictionary<string, string>();

        // Integer variables.
        public static ByteGuardProgram MyProgramsSelected
        {
            get { return MyPrograms[Forms.Main.MyProgramSelectedIndex]; }
        }

        public static ByteGuardProgram MyLibrarySelected
        {
            get { return MyLibrary[Forms.Main.MyLibrarySelectedIndex]; }
        }

        // String variables.
        public static string ByteGuardHost = @"http://127.0.0.1/byteguard/";
        //public static string ByteGuardHost = @"http://www.byteguardsoftware.co.uk/byteguard/";
        public static string WebResponse { get; set; }

        public class Paths
        {
            public static string MyProgramsPath { get; set; }
            public static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            public static string ByteGuardAppData = Path.Combine(AppData, "ByteGuard");
            public static string ByteGuardConfig = Path.Combine(ByteGuardAppData, "config.ini");
        }

        public class Containers
        {
            public static ThemeContainer Active { get; set; }
            public static ThemeContainer Main { get; set; }
        }

        public class Users
        {
            public static ByteGuardUser Current { get; set; }
            public static ByteGuardUser ProgramOwner { get; set; }
        }

        public class Forms
        {
            public static MainForm Main { get; set; }
        }

        public class Threads
        {
            public static Thread UpdateHwid { get; set; }
        }

        public class UserControls
        {
            public static ManageProgramDefault ManageProgram { get; set; }
            public static MyProgramsDefault MyProgramsDefault { get; set; }
            public static MyLibraryDefault MyLibraryDefault { get; set; }
            public static MyAccountDefault MyAccountDefault { get; set; }
        }

        public struct ByteGuardUser
        {
            public int UID;
            public string Description;
            public string Email;
            public bool HasAvatar;
            public bool IsActivated;
            public int LastActive;
            public int LicenseCount;
            public int LicensesRemaining;
            public bool FreeRegistrationUsed;
            public int MaxLicenses;
            public int MaxProgramAdministrators;
            public int MaxVariables;
            public int ProgramAdministratorCount;
            public int ProgramAdministratorsRemaining;
            public int TimeRegistered;
            public string Username;
            public int VariableCount;
            public int VariablesRemaining;

            public ByteGuardUser(int uid, string email, string username, int maxLicenses,
                int licenseCount, bool freeRegistration, int maxVariables, int variableCount, int maxProgramAdministrators,
                int programAdministratorCount, int timeRegistered, int lastActive, bool isActivated, string description,
                bool hasAvatar)
            {
                UID = uid;
                Email = email;
                Username = username;
                MaxLicenses = maxLicenses;
                LicenseCount = licenseCount;
                LicensesRemaining = (maxLicenses - licenseCount);
                FreeRegistrationUsed = freeRegistration;
                MaxVariables = maxVariables;
                VariableCount = variableCount;
                VariablesRemaining = (maxVariables - variableCount);
                MaxProgramAdministrators = maxProgramAdministrators;
                ProgramAdministratorCount = programAdministratorCount;
                ProgramAdministratorsRemaining = (maxProgramAdministrators - programAdministratorCount);
                TimeRegistered = timeRegistered;
                LastActive = lastActive;
                IsActivated = isActivated;
                Description = description;
                HasAvatar = hasAvatar;
            }
        }

        public struct ByteGuardProgram
        {
            public string CreatorUsername;
            public int ExpirationTime;
            public bool IsAdmin;
            public bool IsBanned;
            public int Licenseid;
            public string ProgramDescription;
            public bool ProgramHasImage;
            public string Programid;
            public int ProgramLicenses;
            public string ProgramName;
            public float ProgramVersion;
            public int DistributionModel;
            public bool MarketplaceFeePaid;

            public ByteGuardProgram(string programid, int licenseid, string programName, string creatorUsername,
                float programVersion, string programDescription, int programLicenses, bool programHasImage,
                int expirationTime, bool isBanned, bool isAdmin, int distributionModel, bool marketplaceFeePaid)
            {
                Programid = programid;
                Licenseid = licenseid;
                ProgramName = programName;
                CreatorUsername = creatorUsername;
                ProgramVersion = programVersion;
                ProgramDescription = programDescription;
                ProgramLicenses = programLicenses;
                ProgramHasImage = programHasImage;
                ExpirationTime = expirationTime;
                IsBanned = isBanned;
                IsAdmin = isAdmin;
                DistributionModel = distributionModel;
                MarketplaceFeePaid = marketplaceFeePaid;
            }
        }

        public struct ByteGuardLicense
        {
            public string CreationTime;
            public string ExpirationTime;
            public bool IsBanned;
            public bool IsFrozen;
            public string LicenseCode;
            public int LicenseType;
            public string LicenseValue;
            public string LockReason;
            public int LockTime;
            public string Programid;
            public string RedeemedTime;
            public string RedeemedTo;
            public string TrackingDescription;
            public bool MarketplaceLicense;

            // TODO: Fix types in here.
            public ByteGuardLicense(string programid, string licenseCode, string licenseValue, string creationTime,
                string redeemedTime, string redeemedTo, string expirationTime, string licenseType,
                string trackingDescription, string isBanned, string isFrozen, string lockTime, string lockReason,
                bool marketplaceLicense)
            {
                Programid = programid;
                LicenseCode = licenseCode;
                LicenseValue = licenseValue;
                CreationTime = creationTime;
                RedeemedTime = redeemedTime;
                RedeemedTo = redeemedTo;
                ExpirationTime = expirationTime;
                LicenseType = Convert.ToInt32(licenseType);
                TrackingDescription = trackingDescription;
                IsBanned = Convert.ToInt32(isBanned) == 1;
                IsFrozen = Convert.ToInt32(isFrozen) == 1;
                LockTime = Int32.Parse(lockTime);
                LockReason = lockReason;
                MarketplaceLicense = marketplaceLicense;
            }
        }
    }
}
