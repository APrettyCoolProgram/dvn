/* dvnlib.DataBackup.cs
 * u250717_code
 * u250717_documentation
 */

using System.IO.Compression;
using dvnlib.Common;
using dvnlib.Profile;

namespace dvnlib
{
    /// <summary>Data backup logic.</summary>
    /// <remarks>
    ///     Any directory included in the  <see cref="Profile.Manifest.BackupSources">backup sources</see> component of<br/>
    ///     a manifest file will be 
    ///     As of v1.0, the backup process is intended for repositories, but can be used with any type of data.<br/>
    /// </remarks>
    internal class DataBackup
    {
        /// <summary>Backup data.</summary>
        /// <param name="source">The source path containing the repositories to back up.</param>
        /// <param name="target">The target path where the backups will be stored.</param>
        internal static bool IsEnabled(string exeAsmName, bool manifest, List<string> options)
        {
            if (manifest || options.Contains("-b"))
            {
                return true;
            }
            else
            {
                UserDisplay.Message(exeAsmName, "  Backup disabled.");
                return false;
            }
        }

        // For future non-repository backups, uncomment the following method.
        ///// <summary>Backup data.</summary>
        ///// <param name="source">The source path containing the repositories to back up.</param>
        ///// <param name="target">The target path where the backups will be stored.</param>
        //internal static void BackupData(string source, string target)
        //{
        //    Console.WriteLine($"  Backing up data...");

        //    foreach (var subDirectory in Directory.GetDirectories(source))
        //    {
        //        string backupLocation = Path.Combine(target, $"{Path.GetFileName(subDirectory)}_{DateTime.Now:yyyyMMdd-HHmmss}.zip");
        //        Console.WriteLine($"  Backing up: {subDirectory}...");
        //        ZipFile.CreateFromDirectory(subDirectory, backupLocation);
        //    }
        //}

        /// <summary>Backup repository data.</summary>
        /// <param name="backupSources">The repository sources to backup.</param>
        /// <param name="target">Where the backups will be stored.</param>
        /// <param name="staging">The staging location.</param>
        internal static void BackupRepository(List<string> backupSources, string target, string staging)
        {
            Console.WriteLine($"  Backing up data...");

            ////Framework.CopyRepo(backupSources, staging);

            foreach (var subDirectory in Directory.GetDirectories(staging))
            {
                string subDirectoryName = Path.GetFileName(subDirectory);
                string dateTimeStamp    = DateTime.Now.ToString("yyyyMMdd-HHmmss");
                string backupLocation   = Path.Combine(target, $"{subDirectoryName}_{dateTimeStamp}.zip");
                //Console.WriteLine($"  Backing up: {subDirectory}...");
                ZipFile.CreateFromDirectory(subDirectory, backupLocation);
            }
        }
    }
}


//if (manifest.BackupData || session.Argument.Options.Contains("-b"))
//{
//    Framework.CopyRepo(manifest.BackupSources, session.Framework.Stageing);
//    DataBackup.BackupData(session.Framework.Stageing, manifest.BackupTarget);
//}
//else
//{
//    UserDisplay.Message(session.ExeAsmName, "  Backup disabled.");
//}