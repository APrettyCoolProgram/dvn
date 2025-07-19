/* dvn.App.DvnManifest.cs
 * u250719_code
 * u250719_documentation
 */

/* Properties for this class be found in dvn.App.DvnManifest.Properties.cs.
 */

using System.ComponentModel;

namespace dvn.App.Manifest
{
    internal partial class DvnManifest
    {
        /// <summary>Creates a default instance of the <see cref="Manifest"/> class.</summary>
        /// <param name="fileName">The name of the environment file.</param>
        /// <returns>A new instance of the <see cref="DevnEnv"/> class initialized with default values.</returns>
        internal static DvnManifest CreateNew(string fileName)
        {
            return new DvnManifest()
            {
                EnvironmentName        = fileName,
                EnvironmentDescription = "Environment description",
                BackupEnabled = false,
                BackupSources =
                [
                    "\\Path\\To\\Source1",
                    "\\Path\\To\\Source2"
                ],
                BackupLocation = "\\Path\\To\\Backup",
                ManifestApplication  =
                [
                    new DvnManifestApplication()
                ]
            };
        }
    }
}