/* dvn.App.DvnManifest.cs
 * u250719_code
 * u250719_documentation
 */

/* Properties for this class be found in .\Properties\DvnManifest.Properties.cs.
 */

using dvn.Blueprint;
using dvn.Du;

namespace dvn.App.Manifest
{
    internal partial class DvnManifest
    {
        /// <summary>Creates a default instance of the <see cref="App.DvnManifest"/> class.</summary>
        /// <param name="fileName">The name of the environment file.</param>
        /// <returns>A new instance of the <see cref="DevnEnv"/> class initialized with default values.</returns>
        internal static void CreateNew(string fileName, string manifestPath)
        {
            Manifest.DvnManifest dvnManifest = new Manifest.DvnManifest()
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
                ManifestApplications  =
                [
                    new DvnManifestApplication()
                ]
            };

            DuJson.ExportToLocalFile<DvnManifest>(dvnManifest, $@"{manifestPath}\{fileName}.manifest");
            Console.WriteLine(UserMessage.CreateManifest(fileName));

        }
    }
}