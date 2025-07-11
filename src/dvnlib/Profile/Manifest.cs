/* dvnlib.Env.cs
 * u250710_code
 * u250710_documentation
 */

using dvnlib.Blueprint;
using dvnlib.Common;
using dvnlib.Du;

namespace dvnlib.Profile
{
    internal class Manifest
    {
        /// <summary>The environment name.</summary>
        public string Name { get; set; }

        /// <summary>The environment description.</summary>
        public string Description { get; set; }

        /// <summary>Indicates if data should be backed up.</summary>
        public bool BackupData { get; set; }

        /// <summary>A dictionary mapping source paths to target paths.</summary>
        public List<string> BackupSources { get; set; }

        public string BackupTarget { get; set; }

        /// <summary>A list of applications associated with the environment.</summary>
        public List<Component.Application> Application { get; set; }

        /// <summary>Creates a new development environment configuration file based on the specified action.</summary>
        /// <remarks>
        ///     If an environment name (<c><see cref="Argument.Option">request</see></c>) is provided, it will be used<br/>
        ///     as the file name for the new environment configuration file, otherwise the file will be named "default.dvn".
        /// </remarks>
        /// <param name="request">The name of the action to use as the basis for the configuration file.</param>
        internal static void CreateNew(string exeAsm, string manifestPath, string envName)
        {
            Manifest defaultEnv = BuildDefault(envName);

            DuJson.ExportToLocalFile<Manifest>(defaultEnv, $@"{manifestPath}\{envName}.dvn");

            UserDisplay.Message(exeAsm, UserMessage.CreateManifestTemplate(envName));
        }

        /// <summary>Creates a default instance of the <see cref="Manifest"/> class.</summary>
        /// <param name="fileName">The name of the environment file.</param>
        /// <returns>A new instance of the <see cref="DevnEnv"/> class initialized with default values.</returns>
        internal static Manifest BuildDefault(string fileName)
        {
            return new Manifest()
            {
                Name         = fileName,
                Description  = "Environment description",
                BackupData = false,
                BackupSources =
                [
                    "\\Path\\To\\Source1",
                    "\\Path\\To\\Source2"
                ],
                BackupTarget = "\\Path\\To\\Backup",
                Application =
                [
                    new Component.Application()
                ]
            };
        }

        /// <summary>Lists all available development environments found in the application's data directory.</summary>
        /// <param name="exeAsm"></param>
        internal static void ListAvailable(string exeAsm, string path)
        {
            string detailString = GetAvailable(exeAsm, path);

            if (string.IsNullOrWhiteSpace(detailString))
            {
                Session.Stop(exeAsm, UserMessage.AvailableEnvironmentsList("No environments found."));
            }
            else
            {
                UserDisplay.Message(exeAsm, UserMessage.AvailableEnvironmentsList(detailString));
            }
        }

        internal static string GetAvailable(string exeAsm, string path)
        {
            List<string> availableFilePaths    = GetAvailableFilePaths(exeAsm, path);
            Dictionary<string, string> details = GetAvailableDetails(exeAsm, availableFilePaths);

            return BuildAvailableDetailString(exeAsm, details);
        }


        /// <summary>
        /// Retrieves a list of available environment names from files with a specific extension in the given directory
        /// and its subdirectories.
        /// </summary>
        /// <param name="path">The directory path to search for environment files. Must be a valid directory path.</param>
        /// <returns>A string containing the names of all environments found, each on a new line. Returns an empty string if no
        /// environment files are found.</returns>
        internal static List<string> GetAvailableFilePaths(string exeAsm, string path)
        {
            //UserDisplay.Message(exeAsm, "Getting list of available environments...");

            return Directory.GetFiles(path, "*.dvn", SearchOption.AllDirectories).ToList();
        }

        /// <summary>
        /// Retrieves a list of available environment names from files with a specific extension in the given directory
        /// and its subdirectories.
        /// </summary>
        /// <param name="path">The directory path to search for environment files. Must be a valid directory path.</param>
        /// <returns>A string containing the names of all environments found, each on a new line. Returns an empty string if no
        /// environment files are found.</returns>
        internal static Dictionary<string, string> GetAvailableDetails(string exeAsm, List<string> availableFilePaths)
        {
            //UserDisplay.Message(exeAsm,"  Building environment details...");

            Dictionary<string, string> envDetail = [];

            foreach (var envFilePath in availableFilePaths)
            {
                if (envFilePath.Contains("default.dvn"))
                {
                    continue;
                }

                var deets = GetNameAndDescription(envFilePath);

                envDetail[deets[0]] = deets[1];
            }

            return envDetail;
        }

        internal static string[] GetNameAndDescription(string envFilePath)
        {
            Manifest devEnv = DuJson.ImportFromLocalFile<Manifest>(envFilePath);

            return
            [
                devEnv.Name,
                devEnv.Description
            ];
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

        internal static void Launch(Session session)
        {
            ////////List<string> envFilePaths       = Directory.GetFiles(session.Framework.Patherwt["Data"], "*.dvn", SearchOption.AllDirectories).ToList();

            ////////var t = $@"{session.Framework.Patherwt["Data"]}\{session.Command.Request}.dvn";

            ////////if (envFilePaths.Contains($@"{session.Framework.Patherwt["Data"]}\{session.Command.Request}.dvn"))
            ////////{
            ////////    Launcher(session);
            ////////}
            ////////else
            ////////{
            ////////    Session.Stop(session.ExeAsm,$@"File not found: {{session.Framework.Path[""Data""]}}\{{session.Command.Action}}.dvn");
            ////////}
        }

        internal static void Launcher(Session session)
        {
            //////////UserDisplay.Message(session.ExeAsm, $@"Importing environment file: {session.Command.Action}.dvn");

            ////////Manifest devEnv = DuJson.ImportFromLocalFile<Manifest>($@"{session.Framework.Patherwt["Data"]}\{session.Command.Request}.dvn");

            ////////Console.WriteLine($"{Environment.NewLine}Launching environment: {devEnv.Description}");

            ////////if (devEnv.CompressData || session.Command.Option.Contains("-c"))
            ////////{
            ////////    UserDisplay.Message(session.ExeAsm, "Compression enabled...");
            ////////    Framework.CopyRepo(devEnv.SourceTarget.First().Key, session.Framework.Patherwt);
            ////////    Compressor.CompressData(devEnv.SourceTarget);
            ////////}
            ////////else
            ////////{
            ////////    UserDisplay.Message(session.ExeAsm, "Compression disabled...");
            ////////}

            ////////Application.StartApplications(devEnv.Applications);
        }
    }
}