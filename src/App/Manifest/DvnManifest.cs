/* dvn.App.Manifest.DvnManifest.cs
 * u250730_code
 * u250730_documentation
 */

using dvn.Blueprint;
using dvn.Du;

namespace dvn.App.Manifest;

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
    public List<DvnManifestApplication> ManifestApplications { get; set; }

    /// <summary>Creates a default instance of the <see cref="App.DvnManifest"/> class.</summary>
    /// <param name="fileName">The name of the environment file.</param>
    /// <returns>A new instance of the <see cref="DevnEnv"/> class initialized with default values.</returns>
    internal static void CreateNew(string manifestFolder, string manifestName, string manifestExtension)
    {
        var dvnManifest = new DvnManifest()
        {
            EnvironmentName        = manifestName,
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

        DuJson.ExportToFile<DvnManifest>(dvnManifest, $@"{manifestFolder}\{manifestName}{manifestExtension}");

        Console.WriteLine(UserMessage.msg_CreateManifest(manifestName));

        Session.Stop();
    }
}