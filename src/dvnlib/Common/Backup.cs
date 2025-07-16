/* dvnlib.Compressor.cs
 * u250716_code
 * u250716_documentation
 */

using System.IO.Compression;

namespace dvnlib
{
    /// <summary>Backup logic.</summary>
    internal class Backup
    {
        /// <summary>Backup repository data.</summary>
        /// <param name="source">The source path containing the repositories to back up.</param>
        /// <param name="target">The target path where the backups will be stored.</param>
        internal static void BackupData(string source, string target)
        {
            Console.WriteLine($"  Backing up data...");

            foreach (var subDirectory in Directory.GetDirectories(source))
            {
                string backupLocation = Path.Combine(target, $"{Path.GetFileName(subDirectory)}_{DateTime.Now:yyyyMMdd-HHmmss}.zip");
                Console.WriteLine($"  Backing up: {subDirectory}...");
                ZipFile.CreateFromDirectory(subDirectory, backupLocation);
            }
        }
    }
}