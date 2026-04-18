/* dvnlib.Framework.cs
 * u250719_code
 * u250719_documentation
 */

using System.Reflection;
using dvnlib.Du;

namespace dvnlib.Framework
{
    /// <summary>The dvn folder framework components.</summary>
    internal class FolderFramework
    {
        /* Root paths */

        public string AppRoot => @".\";

        public string DvnRoot => $@".\.dvn";

        public string ApplicationRoot => $@".\apps";

        public string DataRoot => $@".\data";

        /* dvn */

        public string Manifests => $@"{DvnRoot}\mfst";

        public string CacheData => $@"{DvnRoot}\cache";

        public string StagingData => $@"{DvnRoot}\stage";

        public string TemporaryData => $@"{DvnRoot}\tmp";

        public string Trash => $@"{DvnRoot}\trash";


        /* Applications */

        public string WinApps => $@"{ApplicationRoot}\win";

        public string MacApps => $@"{ApplicationRoot}\mac";

        public string LinuxApps => $@"{ApplicationRoot}\lin";


        /* Data */

        public string BackupData => $@"{DataRoot}\bkup";
        public string EncryptedData => $@"{DataRoot}\enc";

        public string RepositoryData => $@"{DataRoot}\repo";

        public string Bins => $@".\data\bin";

        /* Virtual machines */

        public string VirtualMachines => $@"{AppRoot}\vm";

        /* Windows Subsystem for Linux */

        public string WindowsSubsystemForLinux => $@"{AppRoot}\wsl";

        /// <summary>Validate the folder framework.</summary>
        /// <param name="folderFramework"> The <see cref="FolderFramework.FolderFramework"/> to validate.</param>
        internal static void Validate(FolderFramework folderFramework)
        {
            foreach (PropertyInfo path in folderFramework.GetType().GetProperties())
            {
                if (!Directory.Exists(path.GetValue(folderFramework).ToString()))
                {
                    Directory.CreateDirectory(path.GetValue(folderFramework).ToString());
                }
            }
        }


    }
}