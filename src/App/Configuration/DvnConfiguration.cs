/* dvn.App.Configuration.DvnConfiguration.cs
 * u250729_code
 * u250729_documentation
 */

namespace dvn.App.Configuration
{
    /// <summary>The dvn configuration settings.</summary>
    internal class DvnConfiguration
    {
        /// <summary>The list of files that are excluded when copying.</summary>
        internal List<string> ExcludedFiles { get; set; }

        /// <summary>The list of folder that are excluded when copying.</summary>
        internal List<string> ExcludedFolders { get; set; }

        /// <summary>Loads the dvn configuration.</summary>
        /// <remarks>If the specified configuration file does not exist, a new configuration file is created.</remarks>
        /// <param name="configPath">The dvn configuration file path.</param>
        /// <returns>A <c>DvnConfiguration</c> object.</returns>
        internal static DvnConfiguration Load(string configPath)
        {
            if (!File.Exists(configPath))
            {
                Create(configPath);
            }

            return Du.DuJson.ImportFromLocalFile<DvnConfiguration>(configPath);
        }

        /// <summary>Create a new DVN configuration file.</summary>
        /// <param name="configPath">The dvn configuration file path.</param>
        internal static void Create(string configPath)
        {
            var config = new DvnConfiguration
            {
                ExcludedFiles   = Blueprint.Catalog.IgnoredFiles(),
                ExcludedFolders = Blueprint.Catalog.IgnoredFolders()
            };

            Du.DuJson.ExportToLocalFile(config, $@"{configPath}");
        }
    }
}