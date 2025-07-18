using dvnlib.Du;

namespace dvnlib.Common
{
    internal class DvnApp
    {
        /// <summary>The name of the executing assembly.</summary>
        /// <remarks>
        ///     dvnlib is designed to be used as a library by both console and GUI applications.<br/>
        ///     The <see cref="ExeAsmName"/> property determines if the session is running in a console<br/>
        ///     application (e.g., <c>dvn</c>) or a GUI application (e.g., <c>dvngui</c>).<br/>
        /// </remarks>
        public string ExeAsmName { get; set; }

        /// <summary>The current version of the executing assembly.</summary>
        public string ExeAsmVersion { get; set; }

        public List<string> ExcludedRepositoryFiles { get; set; }
        public List<string> ExcludedRepositoryFolders { get; set; }

        /// <summary>Creates a new <see cref="Session"/> instance.</summary>
        /// <param name="exeAsmName">The <see cref="ExeAsmName">executing assembly name</see>.</param>
        /// <param name="exeAsmVersion">The <see cref="ExeAsmVersion">executing assembly version</see>.</param>
        /// <param name="dvnArguments">The dvn <see cref="Arguments.Arguments">arguments</see>.</param>
        /// <returns>A new <see cref="Session"/> instance.</returns>
        internal static DvnApp New(string exeAsmName, string exeAsmVersion)
        {
            return new DvnApp
            {
                ExeAsmName      = exeAsmName,
                ExeAsmVersion   = exeAsmVersion,
            };
        }

        /// <summary></summary>
        /// <param name="exeAsmName">The <see cref="ExeAsmName">executing assembly name</see>.</param>
        /// <param name="exeAsmVersion">The <see cref="ExeAsmVersion">executing assembly version</see>.</param>
        /// <param name="dvnConfigPath">Path to the dvnApp.config file.</param>
        /// <returns></returns>
        internal static DvnApp Load(string exeAsmName, string exeAsmVersion,string dvnConfigPath)
        {
            if (!File.Exists(dvnConfigPath))
            {
                CreateDefault(dvnConfigPath);
            }

            DvnApp dvnApp = DuJson.ImportFromLocalFile<DvnApp>(dvnConfigPath);

            dvnApp.ExeAsmName    = exeAsmName;
            dvnApp.ExeAsmVersion = exeAsmVersion;

            return dvnApp;
        }

        /// <summary>Creates a default configuration file for the application at the specified path.</summary>
        /// <param name="dvnConfigPath">Path to the dvnApp.config file.</param>
        internal static void CreateDefault(string dvnConfigPath)
        {
            var dvnApp = new DvnApp
            {
                ExeAsmName              = null,
                ExeAsmVersion           = null,
                ExcludedRepositoryFiles =
                [
                    ".DS_Store",
                    "Thumbs.db",
                    "desktop.ini",
                    "package-lock.json",
                    "yarn.lock",
                    "pnpm-lock.yaml",
                    "npm-shrinkwrap.json"
                ],
                ExcludedRepositoryFolders =
                [
                    "node_modules",
                    "bin",
                    "obj",
                    ".git",
                    ".vs",
                    ".vscode",
                    ".idea",
                    "packages"
                ]
            };

            DuJson.ExportToLocalFile<DvnApp>(dvnApp, $@"{dvnConfigPath}");
        }
    }
}