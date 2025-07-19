/* dvn.App.DvnFramework.DvnFolders.Properties.cs
 * u250719_code
 * u250719_documentation
 */

using System.Reflection;

namespace dvn.App
{
    internal class DvnFolders
    {
        /* Roots */
        internal string Root { get; set; }

        /* Applications */
        internal string LinuxApps { get; set; }
        internal string MacApps { get; set; }
        internal string WinApps { get; set; }

        /* dvn */
        internal string BackupData { get; set; }
        internal string ConfigurationData { get; set; }
        internal string Manifests { get; set; }
        internal string StagingData { get; set; }
        internal string TemporaryData { get; set; }
        internal string Trash { get; set; }

        /* Repositories */
        internal string RepositoryData { get; set; }
    }
}
