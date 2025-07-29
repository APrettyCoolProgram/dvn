/* dvn.App.DvnEnvironment.cs
 * u250722_code
 * u250722_documentation
 */

using System.Diagnostics;
using dvn.Blueprint;
using dvn.App.Framework;
using dvn.App.Manifest;
using dvn.Du;

namespace dvn.App
{
    /// <summary> Logic for managing and interacting with DVN environments.</summary>
    internal class DvnEnvironment
    {
        /// <summary>Get a list of environment details.</summary>
        /// <remarks>
        ///     The details we are interested in are:
        ///     <list type="bullet">
        ///         <item>The environment <see cref="Manifest.DvnManifest.EnvironmentName">name</see></item>
        ///         <item>The environment <see cref="Manifest.DvnManifest.EnvironmentName">description</see></item>
        ///     </list>
        /// </remarks>
        /// <param name="manifestFolder">The folder that contains the dvn manifest files.</param>
        /// <returns>The names and descriptions of available environments.</returns>
        internal static Dictionary<string, string> GetDetails(string manifestFolder)
        {
            string[] manifestFiles = Directory.GetFiles(manifestFolder, "*.manifest", SearchOption.AllDirectories);
            Dictionary<string, string> environmentDetail = [];

            foreach (var manifestFile in manifestFiles)
            {
                DvnManifest manifest = DuJson.ImportFromLocalFile<DvnManifest>(manifestFile);

                environmentDetail[manifest.EnvironmentName] = manifest.EnvironmentDescription;
            }

            return environmentDetail;
        }

        /// <summary>Display a list of available environments to the console.</summary>
        /// <param name="availableEnvironments">A dictionary containing environment names and descriptions.</param>
        internal static void DisplayAvailable(Dictionary<string, string> availableEnvironments)
        {
            if (availableEnvironments.Count == 0)
            {
                DvnSession.Stop(UserMessage.EnvList("No environments found."));
            }
            else
            {
                Console.WriteLine(UserMessage.EnvList(DuDictionary.ConvertToString(availableEnvironments, "    ", "")));
            }
        }

        /// <summary>Loads an environment manifest file.</summary>
        /// <remarks>If the specified manifest file does not exist, a new manifest file is created.</remarks>
        /// <param name="session">The session instance.</param>
        internal static void Load(DvnSession session)
        {
            // This is easier to read than using "session.Arguments.Command"
            string manifestName = session.Arguments.Command; // Trim?

            if (File.Exists($@"{session.Framework.Folder.Manifests}\{manifestName}.dvn"))
            {
                //Launch(dvnSession);
            }
            else
            {
                DvnManifest.CreateNew(manifestName, session.Framework.Folder.Manifests);

                DvnSession.Stop();
            }
        }

        /// <summary>Launches the specified environment.</summary>
        /// <param name="session">The session instance.</param>
        internal static void Launch(DvnSession session)
        {
            // This is easier to read/more accurate than using "session.Arguments.Command"
            string manifestName = session.Arguments.Command; // Trim?

            DvnManifest manifest = DuJson.ImportFromLocalFile<DvnManifest>($@"{session.Framework.Folder.Manifests}\{manifestName}.dvn");

            Console.WriteLine($"{Environment.NewLine}  Launching environment: {manifest.EnvironmentDescription}");

            if (Archiver.BackupData.IsBackupEnabled(manifest.BackupEnabled, session.Arguments.Options))
            {
                //Archiver.BackupData.CopyToStaging(dvnManifest.BackupSources, dvnSession.Framework.Folders.StagingData);
                //Backup.BackupData(session.Framework.Stageing, dvnManifest.BackupTarget);
                Archiver.BackupData.BackupFolders(manifest.BackupSources, manifest.BackupLocation, session.Framework.Folder.Staging, session.Configuration.ExcludedFiles, session.Configuration.ExcludedFolders);
            }
            else
            {
                Console.WriteLine("  Backup disabled.");
            }

            StartApplications(manifest.ManifestApplications);
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
            foreach (var app in applications)
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

                process.Start();
            }
        }
    }
}