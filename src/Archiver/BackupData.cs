/* dvn.Archiver.BackupData.cs
 * u250730_code
 * u250730_documentation
 */

using System.IO.Compression;
using dvn.Du;

namespace dvn.Archiver;

/// <summary>Logic related to backing up data.</summary>
internal static class BackupData
{
    /// <summary>Determines if the data backup functionality is enabled.</summary>
    /// <remarks>
    ///     The data backup functionality can be enabled by either:
    ///     <list type="bullet">
    ///         <item>Setting the <c>BackupEnabled</c> property in the manifest file to <c>true</c></item>
    ///         <item>Passing the <c>-b</c> option via the command line</item>
    ///     </list>
    ///     Since the backup process can take a significant amount of time, the <c>BackupEnabled</c> property is set<br/>
    ///     to <c>false</c> when a manifest file is created.<br/>
    ///     <br/>
    ///     The recommended method to enable backups is to use the <c>-b</c> option when executing dvn, which gives<br/>
    ///     the user more control over when backups are performed.<br/>
    /// </remarks>
    /// <param name="manifest">The data backup flag in the manifest file.</param>
    /// <param name="dvnOptions">The data backup flag in the command line arguments.</param>
    /// <returns><c>true</c> if data backups are enabled, and <c>false</c> if they are not.</returns>
    internal static bool IsBackupEnabled(bool manifest, List<string> dvnOptions) =>  manifest || dvnOptions.Contains("-b");

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
            var subDirectoryName = Path.GetFileName(subDirectory);
            var dateTimeStamp    = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            var backupLocation   = Path.Combine(target, $"{subDirectoryName}_{dateTimeStamp}.zip");

            ZipFile.CreateFromDirectory(subDirectory, backupLocation);
        }
    }

    /// <summary>Copies specified source directories to a staging directory</summary>
    /// <remarks>
    ///     In order to keep archive sizes manageable, this method allows for the exclusion of specific files and directories.<br/>
    /// </remarks>
    /// <param name="sources">A list of source directory paths to be copied to the staging directory.</param>
    /// <param name="staging">The path to the staging directory where the source directories will be copied.</param>
    /// <param name="excludeFiles">A list of file names to exclude from the copy operation.</param>
    /// <param name="excludeDirs">A list of directory names to exclude from the copy operation.</param>
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