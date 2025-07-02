/* dvnlib.Env.cs
 * u250630_code
 * u250630_documentation
 */

using dvnlib.Blueprint;
using dvnlib.Common;
using dvnlib.Du;

namespace dvnlib
{
    internal class Env
    {
        public string EnvironmentName { get; set; }
        public string EnvironmentDescription { get; set; }
        public bool CompressData { get; set; }
        public Dictionary<string, string> SourceTarget { get; set; }
        public List<App> Applications { get; set; }

        /// <summary>Creates a new development environment configuration file based on the specified action.</summary>
        /// <param name="action">The name of the action to use as the basis for the configuration file.</param>
        internal static void New(string action)
        {
            var fileName = string.IsNullOrEmpty(action)
                ? "default"
                : action;

            Console.WriteLine(UserMessage.EnvTemplate("create"));

            Env defaultEnv = BuildDefault(fileName);

            DuJson.ExportToLocalFile<Env>(defaultEnv, $@"./AppData/{fileName}.devn");

            Console.WriteLine(UserMessage.EnvTemplate("created"));
        }

        /// <summary>Creates a default instance of the <see cref="DevnEnv"/> class.</summary>
        /// <param name="fileName">The name of the environment file.</param>
        /// <returns>A new instance of the <see cref="DevnEnv"/> class initialized with default values.</returns>
        internal static Env BuildDefault(string fileName)
        {
            return new Env()
            {
                EnvironmentName        = fileName,
                EnvironmentDescription = "Environment Description",
                CompressData           = false,
                SourceTarget = new Dictionary<string, string>
                {
                    {"\\path\\to\\source", "\\path\\to\\target" }
                },
                Applications =
                [
                    new App()
                ]
            };
        }

        /// <summary>Lists all available development environments found in the application's data directory.</summary>
        internal static void ListAvailable()
        {
            var availableEnvs = GetAvailable();

            if (string.IsNullOrWhiteSpace(availableEnvs))
            {
                Session.Stop(UserMessage.DevEnvListHeader("No environments found."));
            }
            else
            {
                Console.WriteLine(UserMessage.DevEnvListHeader(availableEnvs));
            }
        }

        internal static string GetAvailable()
        {
            List<string> envFilePaths = Directory.GetFiles(@".\AppData", "*.devn", SearchOption.AllDirectories).ToList();

            var devnEnvironments = string.Empty;

            foreach (var devnEnvironmentFilePath in envFilePaths)
            {
                var devnEnvironmentFullFileName = devnEnvironmentFilePath.Split('\\').Last();
                var devnEnvironmentFileName     = devnEnvironmentFullFileName.Split('.').First();

                devnEnvironments += $"  {devnEnvironmentFileName}{Environment.NewLine}";
            }

            return devnEnvironments;
        }

        internal static void Launch(Session session)
        {
            List<string> envFilePaths = Directory.GetFiles(@".\AppData", "*.devn", SearchOption.AllDirectories).ToList();

            if (envFilePaths.Contains($@".\AppData\{session.Command}.devn"))
            {
                Launcher(session);
            }
            else
            {
                Session.Stop($@"File not found: .\AppData\{session.Command}.devn");
            }
        }

        internal static void Launcher(Session session)
        {
            Console.WriteLine($@"Importing environment file: {session.Command}.devn");

            Env devEnv = DuJson.ImportFromLocalFile<Env>($@".\AppData\{session.Command}.devn");

            Console.WriteLine($"Launching environment: {devEnv.EnvironmentDescription}");

            if (devEnv.CompressData || session.Action.Contains("-c"))
            {
                Console.WriteLine($"Compression enabled...");
                Framework.CopyRepo(devEnv.SourceTarget.First().Key, session.Framework.Paths);
                Compressor.CompressData(devEnv.SourceTarget);
            }
            else
            {
                Console.WriteLine($"Compression disabled.");
            }

            App.StartApplications(devEnv.Applications);
        }
    }
}
