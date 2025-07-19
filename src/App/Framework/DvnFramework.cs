/* dvn.App.DvnFramework.cs
 * u250719_code
 * u250719_documentation
 */

/* Properties for this class be found in:
 *      .\Properties\DvnFramework.Properties.cs
 *      .\Properties\DvnFramework.DvnFiles.Properties.cs
 *      .\Properties\DvnFramework.DvnFolders.Properties.cs
 */

using System.Data;
using System.Reflection;

namespace dvn.App.Framework
{
    internal partial class DvnFramework
    {
        internal static DvnFramework Initialize()
        {
            DvnFolders dvnFolders = InitializeFolders();
            DvnFiles dvnFiles     = InitializeFiles(dvnFolders);

            ValidateFolders(dvnFolders);
            ValidateFiles(dvnFiles);

            return new DvnFramework
            {
                Folders = dvnFolders,
                Files   = dvnFiles
            };

        }

        internal static DvnFiles InitializeFiles(DvnFolders dvnFolders)
        {
            return new DvnFiles
            {
                DvnConfig = $@"{dvnFolders.ConfigurationData}\dvn.config"
            };
        }

        internal static DvnFolders InitializeFolders()
        {
            return new DvnFolders
            {
                // Roots
                Root = @".\",
                // Applications
                LinuxApps = @".\apps\lin",
                MacApps   = @".\apps\mac",
                WinApps   = @".\apps\win",
                // dvn data
                BackupData        = @".\.dvn\bkup",
                ConfigurationData = @".\.dvn\cfg",
                Manifests         = @".\.dvn\mfst",
                StagingData       = @".\.dvn\stg",
                TemporaryData     = @".\.dvn\tmp",
                Trash             = @".\.dvn\trsh",
                // Repository data
                RepositoryData = @".\data\repos"
            };
        }

        /// <summary>Validate the folder framework.</summary>
        /// <param name="folderFramework"> The <see cref="FolderFramework.FolderFramework"/> to validate.</param>
        internal static void ValidateFolders(DvnFolders folders)
        {
            foreach (PropertyInfo property in typeof(DvnFolders).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                var value = property.GetValue(folders) as string;
                if (!string.IsNullOrWhiteSpace(value) && !Directory.Exists(value))
                {
                    Directory.CreateDirectory(value);
                }
            }
        }

        internal static void ValidateFiles(DvnFiles files)
        {
            if (!File.Exists(files.DvnConfig))
            {
                DvnConfiguration.CreateNew(files.DvnConfig);
            }
        }
    }
}

/* TODO

    VirtualMachines
    WindowsSubsystemForLinux
    encrypted
    bins


 */