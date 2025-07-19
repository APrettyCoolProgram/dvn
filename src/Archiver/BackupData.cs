using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dvn.Du;

namespace dvn.Archiver
{
    internal class BackupData
    {
        internal static bool IsBackupEnabled(bool manifest, List<string> dvnOptions)
        {
            // Check if the -b option is present in the arguments
            return manifest || dvnOptions.Contains("-b");
        }

        /// <summary>Backup repository data.</summary>
        /// <param name="backupSources">The repository sources to backup.</param>
        /// <param name="target">Where the backups will be stored.</param>
        /// <param name="staging">The staging location.</param>
        internal static void BackupFolders(List<string> backupSources, string target, string staging, List<string> excludeFiles, List<string> excludeDirs)
        {
            Console.WriteLine($"  Backup enabled.");

            CopyToStaging(backupSources, staging, excludeFiles, excludeDirs);

            foreach (var subDirectory in Directory.GetDirectories(staging))
            {
                string subDirectoryName = Path.GetFileName(subDirectory);
                string dateTimeStamp    = DateTime.Now.ToString("yyyyMMdd-HHmmss");
                string backupLocation   = Path.Combine(target, $"{subDirectoryName}_{dateTimeStamp}.zip");

                ZipFile.CreateFromDirectory(subDirectory, backupLocation);
            }
        }
        internal static void CopyToStaging(List<string> sources, string staging, List<string> excludeFiles, List<string> excludeDirs)
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
