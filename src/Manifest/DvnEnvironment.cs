// u250920_code
// u250920_documentation

using dvn.Blueprint;
using dvn.Core;
using dvn.Du;

namespace dvn.Manifest;

/// <summary>Logic for development environments.</summary>
internal class DvnEnvironment
{
    /// <summary>The environment name.</summary>
    /// <value>The environment name.</value>
    public string Name { get; set; }

    /// <summary>The environment description.</summary>
    /// <value>The environment description.</value>
    public string Description { get; set; }

    /// <summary>Indicates whether data should be backed up.</summary>
    /// <value><see langword="true"/> when backups are enabled; otherwise, <see langword="false"/>.</value>
    public bool BackupEnabled { get; set; }

    /// <summary>The backup source directories.</summary>
    /// <value>The directories that will be copied during backup.</value>
    public List<string> BackupSources { get; set; }

    /// <summary>The backup destination path.</summary>
    /// <value>The directory where backup archives are stored.</value>
    public string BackupLocation { get; set; }

    /// <summary>Gets the available development environment details.</summary>
    /// <remarks>
    /// The returned dictionary contains environment names as keys and environment descriptions as values.
    /// </remarks>
    /// <param name="manifestFolder">The folder that contains the dvn manifest files.</param>
    /// <param name="manifestExtension">The file extension used by dvn manifest files.</param>
    /// <returns>A dictionary containing the available environment names and descriptions.</returns>
    internal static Dictionary<string, string> GetEnvironmentDetails(string manifestFolder, string manifestExtension)
    {
        var manifestFiles = Directory.GetFiles(manifestFolder, $"*{manifestExtension}", SearchOption.AllDirectories);

        Dictionary<string, string> environmentDetails = [];

        foreach (var manifestFile in manifestFiles)
        {
            DvnManifest manifest = DuJson.ImportFromFile<DvnManifest>(manifestFile);

            environmentDetails[manifest.DevelopmentEnvironment.Name] = manifest.DevelopmentEnvironment.Description;
        }

        return environmentDetails;
    }

    /// <summary>Displays a list of available environments to the console.</summary>
    /// <param name="availableEnvironments">A dictionary containing environment names and descriptions.</param>
    internal static void DisplayAvailable(Dictionary<string, string> availableEnvironments)
    {
        if (availableEnvironments.Count == 0)
        {
            Session.Stop(UserMessage.usrmsg_EnvList("No environments found."));
        }
        else
        {
            Console.WriteLine(UserMessage.usrmsg_EnvList(DuDictionary.ConvertToString(availableEnvironments, "    ", "")));
        }
    }

    /// <summary>Loads an environment manifest file.</summary>
    /// <remarks>If the specified manifest file does not exist, a new manifest file is created.</remarks>
    /// <param name="dvnSession">The session instance.</param>
    internal static void LoadFromManifest(Session dvnSession)
    {
        if (File.Exists($@"{dvnSession.Framework.Folders["Manifests"]}\{dvnSession.Arguments.Command}{dvnSession.Configuration.ManifestExtension}"))
        {
            Launch(dvnSession.Framework.Folders["Manifests"], dvnSession.Arguments.Command, dvnSession.Configuration.ManifestExtension,
                   dvnSession.Framework.Folders["Staging"], dvnSession.Arguments.Options, dvnSession.Configuration.ExcludedFiles,
                   dvnSession.Configuration.ExcludedFolders);
        }
        else
        {
            DvnManifest.CreateDefault(dvnSession.Framework.Folders["Manifests"], dvnSession.Arguments.Command, dvnSession.Configuration.ManifestExtension);

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
        DvnManifest dvnManifest = DuJson.ImportFromFile<DvnManifest>($@"{manifestFolder}\{manifestName}{manifestExtension}");

        Console.WriteLine($"{Environment.NewLine}  Launching environment: {dvnManifest.DevelopmentEnvironment.Description}");

        if (Archiver.IsBackupEnabled(dvnManifest.DevelopmentEnvironment.BackupEnabled, dvnOptions))
        {
            Archiver.BackupFolders(dvnManifest.DevelopmentEnvironment.BackupSources, dvnManifest.DevelopmentEnvironment.BackupLocation, stagingPath, excludedFiles, excludedFolders);
        }
        else
        {
            Console.WriteLine("  Data backup functionality is disabled.");
        }

        DvnApplication.StartApplications(dvnManifest.EnvironmentApplications);
        DvnWebBrowser.OpenPages(dvnManifest.WebBrowser.PagesToOpen);

        Session.Stop(UserMessage.usrmsg_ExitDvn());
    }
}