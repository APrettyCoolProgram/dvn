/* dvnlib.Compressor.cs
 * u250715_code
 * u250715_documentation
 */

using System.IO.Compression;

namespace dvnlib
{
    /// <summary>Compression</summary>
    internal class Backup
    {
        /// <summary>Compresses repository data.</summary>
        /// <param name="sourcePath">The repository source, and compressed location.</param>
        internal static void BackupData(string sourcePath, string targetPath)
        {
            foreach (var subDirectory in Directory.GetDirectories(sourcePath))
            {
                var repo       = Path.GetFileName(subDirectory);
                var timestamp  = DateTime.Now.ToString("yyyyMMdd-HHmmss");
                var target     = Path.Combine(targetPath, $"{repo}_{timestamp}.zip");

                Console.WriteLine($"    Backing up [{subDirectory}] => [{target}]...");

                ZipFile.CreateFromDirectory(subDirectory, target);
            }

            Console.WriteLine($"  Backup complete!");
        }
    }
}