/* dvnlib.DataBackup.cs
 * u250719_code
 * u250719_documentation
 */

using System.IO.Compression;
using dvnlib.Common;
using dvnlib.Du;

namespace dvnlib
{
    /// <summary>Data backup logic.</summary>
    /// <remarks>
    ///     Any directory included in the  <see cref="Profile.Manifest.BackupSources">backup sources</see> component of<br/>
    ///     a manifest file will be backed up to the <see cref="Profile.Manifest.BackupTarget">backup target</see> directory.<br/>
    ///     <br/>
    ///     As of v1.0, the backup process is intended for repositories, but can be used with any type of data.<br/>
    /// </remarks>
    internal static class DataBackup
    {
        /// <summary>Checks to see if the data backup functionality is enabled.</summary>
        /// <param name="exeAsmName">The <see cref="DvnApp.ExeAsmName">executing assembly name</see>.</param>
        /// <param name="manifest">The manifest file <see cref="Profile.Manifest.BackupData"/> setting </param>
        /// <param name="options">The command line <see cref="Argument.Options"/> list.</param>
        /// <returns><c>True</c>, if data backup is enabled, <c>false</c> if not.</returns>
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

        /// <summary>Backup repository data.</summary>
        /// <param name="backupSources">The repository sources to backup.</param>
        /// <param name="target">Where the backups will be stored.</param>
        /// <param name="staging">The staging location.</param>
        internal static void BackupFolders(List<string> backupSources, string target, string staging, List<string> excludeFiles, List<string> excludeDirs)
        {
            Console.WriteLine($"  Backup enabled.");

            CopyFoldersToStaging(backupSources, staging, excludeFiles, excludeDirs);

            foreach (var subDirectory in Directory.GetDirectories(staging))
            {
                string subDirectoryName = Path.GetFileName(subDirectory);
                string dateTimeStamp    = DateTime.Now.ToString("yyyyMMdd-HHmmss");
                string backupLocation   = Path.Combine(target, $"{subDirectoryName}_{dateTimeStamp}.zip");

                ZipFile.CreateFromDirectory(subDirectory, backupLocation);
            }
        }

        /// <summary>Copies the contents of a source repository to a staging directory.</summary>
        /// <param name="source">The path to the source repository to copy.</param>
        /// <param name="paths">A dictionary containing paths used during the operation.</param>
        internal static void CopyFoldersToStaging(List<string> sources, string staging, List<string> excludeFiles, List<string> excludeDirs)
        {
            DuDirectory.Reset(staging);

            foreach (var source in sources)
            {
                var namer = source.Split("\\").Last();

                DuDirectory.CopyExclude(source, $@"{staging}\{namer}", excludeFiles, excludeDirs, true);
            }
        }
    }
}

// TODO - Should probably have a second method that backs up non-repository data.