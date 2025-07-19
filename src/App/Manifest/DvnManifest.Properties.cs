/* dvn.App.DvnManifest.Properties.cs
 * u250719_code
 * u250719_documentation
 */

using System.ComponentModel;

namespace dvn.App.Manifest
{
    internal partial class DvnManifest
    {
        /// <summary>The environment name.</summary>
        public string EnvironmentName { get; set; }

        /// <summary>The environment description.</summary>
        public string EnvironmentDescription { get; set; }

        /// <summary>Indicates if data should be backed up.</summary>
        public bool BackupEnabled { get; set; }

        /// <summary>A dictionary mapping source paths to target paths.</summary>
        public List<string> BackupSources { get; set; }

        public string BackupLocation { get; set; }

        /// <summary>A list of applications associated with the environment.</summary>
        public List<Manifest.DvnManifestApplication> ManifestApplication { get; set; }

    }
}
