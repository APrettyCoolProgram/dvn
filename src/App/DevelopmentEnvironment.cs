/* dvn.App.DevelopmentEnvironment.cs
 * u250801_code
 * u250801_documentation
 */

using dvn.Blueprint;
using dvn.Du;

namespace dvn.App;

/// <summary>Logic for development environments.</summary>
internal class DevelopmentEnvironment
{
    /// <summary>The environment name.</summary>
    public string Name { get; set; }

    /// <summary>The environment description.</summary>
    public string Description { get; set; }

    /// <summary>Indicates if data should be backed up.</summary>
    public bool BackupEnabled { get; set; }

    /// <summary>A dictionary mapping source paths to target paths.</summary>
    public List<string> BackupSources { get; set; }

    public string BackupLocation { get; set; }

    /// <summary>Creates a new instance of the <see cref="DevelopmentEnvironment"/> class.</summary>
    /// <param name="environmentName">The name of the development environment.</param>
    /// <returns>A <see cref="DevelopmentEnvironment"/> instance</returns>
    internal static DevelopmentEnvironment New(string environmentName)
    {
        return new DevelopmentEnvironment
        {
            Name          = environmentName,
            Description   = "Default development environment",
            BackupEnabled = false,
            BackupSources =
            [
                "\\Path\\To\\Source1",
                "\\Path\\To\\Source2"
            ],
            BackupLocation = "\\Path\\To\\Backup"
        };
    }

    /// <summary>Get the details for the available development environments.</summary>
    /// <remarks>
    ///     The details we are interested in are:
    ///     <list type="bullet">
    ///         <item>The environment <see cref="Manifest.EnvironmentName">name</see></item>
    ///         <item>The environment <see cref="Manifest.EnvironmentDescription">description</see></item>
    ///     </list>
    /// </remarks>
    /// <param name="manifestFolder">The folder that contains the dvn manifest files.</param>
    /// <returns>The names and descriptions of available environments.</returns>
    internal static Dictionary<string, string> GetEnvironmentDetails(string manifestFolder, string manifestExtension)
    {
        var manifestFiles = Directory.GetFiles(manifestFolder, $"*{manifestExtension}", SearchOption.AllDirectories);

        Dictionary<string, string> environmentDetails = [];

        foreach (var manifestFile in manifestFiles)
        {
            Manifest manifest = DuJson.ImportFromFile<Manifest>(manifestFile);

            environmentDetails[manifest.DevelopmentEnvironment.Name] = manifest.DevelopmentEnvironment.Description;
        }

        return environmentDetails;
    }

    /// <summary>Display a list of available environments to the console.</summary>
    /// <param name="availableEnvironments">A dictionary containing environment names and descriptions.</param>
    internal static void DisplayAvailable(Dictionary<string, string> availableEnvironments)
    {
        if (availableEnvironments.Count == 0)
        {
            Session.Stop(UserMessage.msg_EnvList("No environments found."));
        }
        else
        {
            Console.WriteLine(UserMessage.msg_EnvList(DuDictionary.ConvertToString(availableEnvironments, "    ", "")));
        }
    }

    /// <summary>Loads an environment manifest file.</summary>
    /// <remarks>If the specified manifest file does not exist, a new manifest file is created.</remarks>
    /// <param name="dvnSession">The session instance.</param>
    internal static void LoadFromManifest(Session dvnSession)
    {
        if (File.Exists($@"{dvnSession.Framework.Folders["Manifests"]}\{dvnSession.CommandLine.Command}{dvnSession.Configuration.ManifestExtension}"))
        {
            Launch(dvnSession.Framework.Folders["Manifests"], dvnSession.CommandLine.Command, dvnSession.Configuration.ManifestExtension,
                   dvnSession.Framework.Folders["Staging"], dvnSession.CommandLine.Options, dvnSession.Configuration.ExcludedFiles,
                   dvnSession.Configuration.ExcludedFolders);
        }
        else
        {
            Manifest.CreateNew(dvnSession.Framework.Folders["Manifests"], dvnSession.CommandLine.Command, dvnSession.Configuration.ManifestExtension);

            Session.Stop();
        }
    }

    /// <summary>Launches a development environment.</summary>
    /// <param name="manifestFolder">The folder path where the manifest file is located.</param>
    /// <param name="manifestName">The name of the manifest file without extension.</param>
    /// <param name="manifestExtension">The file extension of the manifest.</param>
    /// <param name="stagingPath">The path to the staging area for backup operations.</param>
    /// <param name="dvnOptions">A list of options that modify the behavior of the launch process.</param>
    /// <param name="excludedFiles">A list of file names to exclude from backup operations.</param>
    /// <param name="excludedFolders">A list of folder names to exclude from backup operations.</param>
    internal static void Launch(string manifestFolder, string manifestName, string manifestExtension, string stagingPath, List<string> dvnOptions, List<string> excludedFiles, List<string> excludedFolders)
    {
        Manifest dvnManifest = DuJson.ImportFromFile<Manifest>($@"{manifestFolder}\{manifestName}{manifestExtension}");

        Console.WriteLine($"{Environment.NewLine}  Launching environment: {dvnManifest.DevelopmentEnvironment.Description}");

        if (Archiver.BackupData.IsBackupEnabled(dvnManifest.DevelopmentEnvironment.BackupEnabled, dvnOptions))
        {
            Archiver.BackupData.BackupFolders(dvnManifest.DevelopmentEnvironment.BackupSources, dvnManifest.DevelopmentEnvironment.BackupLocation, stagingPath, excludedFiles, excludedFolders);
        }
        else
        {
            Console.WriteLine("  Data backup functionality is disabled.");
        }

        EnvironmentApplication.StartApplications(dvnManifest.EnvironmentApplications);
    }
}