/* dvn.App.DvnEnvironment.cs
 * u250719_code
 * u250719_documentation
 */

/* Properties for this class be found in .\Properties\DvnEnvironment.Properties.cs.
 */

using System.Diagnostics;
using dvn.Blueprint;
using dvn.Du;

namespace dvn.App
{
    internal partial class DvnEnvironment
    {
        /// <summary>Get a list of available environment names and descriptions.</summary>
        /// <param name="path">The directory path to search for environment files. Must be a valid directory path.</param>
        /// <returns>A string containing the names of all environments found.</returns>
        internal static Dictionary<string, string> GetNameAndDescription(string manifestPath)
        {
            var manifestPaths = Directory.GetFiles(manifestPath, "*.manifest", SearchOption.AllDirectories);

            Dictionary<string, string> environmentDetail = [];

            foreach (var path in manifestPaths)
            {
                Manifest.DvnManifest dvnManifest = DuJson.ImportFromLocalFile<Manifest.DvnManifest>(path);
                environmentDetail[dvnManifest.EnvironmentName] = dvnManifest.EnvironmentDescription;
            }

            return environmentDetail;
        }

        internal static void DisplayAvailable(Dictionary<string, string> availableEnvironments)
        {
            //string environmentList = GetEnvironmentList(exeAsmName, manifestPath);

            if (availableEnvironments.Count == 0)
            {
                DvnSession.Stop(UserMessage.EnvList("No environments found."));
            }
            else
            {
                string availableList = DuDictionary.ConvertToString(availableEnvironments, "    ", "");
                Console.WriteLine(UserMessage.EnvList(availableList));
            }
        }

        internal static void Load(DvnSession dvnSession)
        {
            if (File.Exists($@"{dvnSession.Framework.Folders.Manifests}\{dvnSession.Arguments.Command}.dvn"))
            {
                //Launch(dvnSession);
            }
            else
            {
                Manifest.DvnManifest.CreateNew(dvnSession.Arguments.Command, dvnSession.Framework.Folders.Manifests);
                DvnSession.Stop(dvnSession.Arguments.Command);
            }
        }

        internal static void Launch(DvnSession dvnSession)
        {
            Manifest.DvnManifest dvnManifest = DuJson.ImportFromLocalFile<Manifest.DvnManifest>($@"{dvnSession.Framework.Folders.Manifests}\{dvnSession.Arguments.Command}.dvn");

            Console.WriteLine($"{Environment.NewLine}  Launching environment: {dvnManifest.EnvironmentDescription}");

            if (Archiver.BackupData.IsBackupEnabled(dvnManifest.BackupEnabled, dvnSession.Arguments.Options))
            {
                //Archiver.BackupData.CopyToStaging(dvnManifest.BackupSources, dvnSession.Framework.Folders.StagingData);
                //Backup.BackupData(session.Framework.Stageing, dvnManifest.BackupTarget);
                Archiver.BackupData.BackupFolders(dvnManifest.BackupSources, dvnManifest.BackupLocation, dvnSession.Framework.Folders.StagingData, dvnSession.Configuration.ExcludedFiles, dvnSession.Configuration.ExcludedFolders);
            }
            else
            {
                Console.WriteLine("  Backup disabled.");
            }

            DvnEnvironment.StartApplications(dvnManifest.ManifestApplications);
        }

        internal static void StartApplications(List<Manifest.DvnManifestApplication> applications)
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