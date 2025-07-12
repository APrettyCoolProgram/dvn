/* dvnlib.DvnEnvironment.cs
 * u250710_code
 * u250710_documentation
 */

using dvnlib.Blueprint;
using dvnlib.Common;
using dvnlib.Du;
using dvnlib.Profile;

namespace dvnlib
{
    internal class DvnEnvironment
    {
        /// <summary>Lists all available development environments found in the application's data directory.</summary>
        internal static void ListAvailable(string exeAsm, string manifestPath)
        {
            string availableEnvironments = GetAvailable(exeAsm, manifestPath);

            if (string.IsNullOrWhiteSpace(availableEnvironments))
            {
                Session.Stop(exeAsm, UserMessage.AvailableEnvironmentsList("No environments found."));
            }
            else
            {
                UserDisplay.Message(exeAsm, UserMessage.AvailableEnvironmentsList(availableEnvironments));
            }
        }

        /// <summary>
        /// Retrieves a formatted string containing details of available files and their associated information.
        /// </summary>
        /// <remarks>This method combines file paths and their details into a single string. It is
        /// intended for use in scenarios where a summary of available files and their metadata is required.</remarks>
        /// <param name="exeAsm">The name of the executable assembly to be used as a reference for locating files.</param>
        /// <param name="path">The directory path where the search for available files will be conducted.</param>
        /// <returns>A string that represents the details of available files, formatted for display or further processing.</returns>
        internal static string GetAvailable(string exeAsm, string path)
        {
            List<string> availableFilePaths    = GetPaths(exeAsm, path);
            Dictionary<string, string> details = GetDetails(exeAsm, availableFilePaths);

            return BuildAvailableDetailString(exeAsm, details);
        }

        /// <summary>
        /// Retrieves a list of available environment names from files with a specific extension in the given directory
        /// and its subdirectories.
        /// </summary>
        /// <param name="path">The directory path to search for environment files. Must be a valid directory path.</param>
        /// <returns>A string containing the names of all environments found, each on a new line. Returns an empty string if no
        /// environment files are found.</returns>
        internal static List<string> GetPaths(string exeAsm, string path)
        {
            return Directory.GetFiles(path, "*.dvn", SearchOption.AllDirectories).ToList();
        }

        /// <summary>
        /// Retrieves a list of available environment names from files with a specific extension in the given directory
        /// and its subdirectories.
        /// </summary>
        /// <param name="path">The directory path to search for environment files. Must be a valid directory path.</param>
        /// <returns>A string containing the names of all environments found, each on a new line. Returns an empty string if no
        /// environment files are found.</returns>
        internal static Dictionary<string, string> GetDetails(string exeAsm, List<string> availableFilePaths)
        {
            Dictionary<string, string> envDetail = [];

            foreach (var envFilePath in availableFilePaths)
            {
                if (envFilePath.Contains("default.dvn"))
                {
                    continue;
                }

                var test = DuJson.ImportFromLocalFile<Profile.Manifest>(envFilePath);

                envDetail[test.Name] = test.Description;
            }

            return envDetail;
        }

        /// <summary>
        /// Retrieves a list of available environment names from files with a specific extension in the given directory
        /// and its subdirectories.
        /// </summary>
        /// <param name="path">The directory path to search for environment files. Must be a valid directory path.</param>
        /// <returns>A string containing the names of all environments found, each on a new line. Returns an empty string if no
        /// environment files are found.</returns>
        internal static string BuildAvailableDetailString(string exeAsm, Dictionary<string, string> envDetail)
        {
            ///UserDisplay.Message(exeAsm, "Building string...");

            var dvnEnvironments = string.Empty;

            foreach (var devnEnvironment in envDetail)
            {
                dvnEnvironments += $"  {devnEnvironment.Key} - {devnEnvironment.Value}{Environment.NewLine}";
            }

            return dvnEnvironments;
        }

        internal static void Load(Session session)
        {
            if (File.Exists($@"{session.Framework.DvnManifestPath}\{session.Argument.Command}.dvn"))
            {
                Launch(session);
            }
            else
            {
                Profile.Manifest.CreateNew(session.ExeAsm, session.Framework.DvnManifestPath, session.Argument.Command);
                Session.Stop(session.ExeAsm);
            }
        }

        internal static void Launch(Session session)
        {
            Manifest manifest = DuJson.ImportFromLocalFile<Manifest>($@"{session.Framework.DvnManifestPath}\{session.Argument.Command}.dvn");

            Console.WriteLine($"{Environment.NewLine}  Launching environment: {manifest.Description}");

            if (manifest.BackupData || session.Argument.Option.Contains("-b"))
            {
                UserDisplay.Message(session.ExeAsm, "  Backup enabled...");
                Framework.CopyRepo(manifest.BackupSources, manifest.BackupTarget, session.Framework.StagePath);
                Backup.BackupData(session.Framework.StagePath, manifest.BackupTarget);
            }
            else
            {
                UserDisplay.Message(session.ExeAsm, "  Backup disabled...");
            }

            Profile.Component.Application.StartApplications(manifest.Application);
        }
    }
}