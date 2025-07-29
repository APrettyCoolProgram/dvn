/* dvn.App.DvnManifest.cs
 * u250722_code
 * u250722_documentation
 */

using dvn.Blueprint;
using dvn.Du;

namespace dvn.App.Manifest
{
    internal class DvnManifest
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
        public List<App.Manifest.DvnManifestApplication> ManifestApplications { get; set; }

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