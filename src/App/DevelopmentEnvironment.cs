/* dvn.App.DevelopmentEnvironment.cs
 * u250730_code
 * u250730_documentation
 */

using System.Diagnostics;
using dvn.App.Manifest;
using dvn.Blueprint;
using dvn.Du;

namespace dvn.App;

/// <summary> Logic for managing and interacting with DVN environments.</summary>
internal static class DevelopmentEnvironment
{
    /// <summary>Get a list of environment details.</summary>
    /// <remarks>
    ///     The details we are interested in are:
    ///     <list type="bullet">
    ///         <item>The environment <see cref="DvnManifest.EnvironmentName">name</see></item>
    ///         <item>The environment <see cref="DvnManifest.EnvironmentDescription">description</see></item>
    ///     </list>
    /// </remarks>
    /// <param name="manifestFolder">The folder that contains the dvn manifest files.</param>
    /// <returns>The names and descriptions of available environments.</returns>
    internal static Dictionary<string, string> GetAvailableEnvironmentDetails(string manifestFolder)
    {
        var manifestFiles = Directory.GetFiles(manifestFolder, "*.manifest", SearchOption.AllDirectories);
        Dictionary<string, string> availableEnvironmentDetails = [];

        foreach (var manifestFile in manifestFiles)
        {
            DvnManifest manifest = DuJson.ImportFromFile<DvnManifest>(manifestFile);

            availableEnvironmentDetails[manifest.EnvironmentName] = manifest.EnvironmentDescription;
        }

        return availableEnvironmentDetails;
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
            DvnManifest.CreateNew(dvnSession.Framework.Folders["Manifests"], dvnSession.CommandLine.Command, dvnSession.Configuration.ManifestExtension);

            Session.Stop();
        }
    }

    /// <summary>Launches the environment specified by the manifest, performing backup operations if enabled.</summary>
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

        Console.WriteLine($"{Environment.NewLine}  Launching environment: {dvnManifest.EnvironmentDescription}");

        if (Archiver.BackupData.IsBackupEnabled(dvnManifest.BackupEnabled, dvnOptions))
        {
            Archiver.BackupData.BackupFolders(dvnManifest.BackupSources, dvnManifest.BackupLocation, stagingPath, excludedFiles, excludedFolders);
        }
        else
        {
            Console.WriteLine("  Backup disabled.");
        }

        StartApplications(dvnManifest.ManifestApplications);
    }

    /// <summary>Starts a list of applications.</summary>
    /// <remarks>
    ///     This method iterates over the provided list of applications and starts each one using the specified file name,
    ///     arguments, and working directory. The applications are started with shell execution enabled and without creating a
    ///     new window.<br/>
    ///     <br/>
    ///     Currently this functionality only works on Windows systems.
    /// </remarks>
    /// <param name="applications">A list of <see cref="DvnManifestApplication"/> objects, each representing an application to be started. The
    /// list must not be null, and each application must have a valid file name.</param>
    internal static void StartApplications(List<DvnManifestApplication> applications)
    {
        foreach (DvnManifestApplication app in applications)
        {
            Console.WriteLine($"  Starting application: {app.Name}");

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName         = app.FileName,
                    Arguments        = app.Arguments,
                    WorkingDirectory = app.WorkingDirectory,
                    UseShellExecute  = true,
                    CreateNoWindow   = false
                }
            };

            _=process.Start();
        }
    }
}