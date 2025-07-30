/* dvn.App.Configuration.cs
 * u250730_code
 * u250730_documentation
 */

namespace dvn.App;

/// <summary>The dvn configuration settings.</summary>
internal class Configuration
{
    /// <summary>Gets or sets the file extension used for manifest files.</summary>
    internal string ManifestExtension { get; set; }

    /// <summary>The list of files that are excluded when copying.</summary>
    internal List<string> ExcludedFiles { get; set; }

    /// <summary>The list of folder that are excluded when copying.</summary>
    internal List<string> ExcludedFolders { get; set; }

    /// <summary>Loads the dvn configuration from a local file.</summary>
    /// <remarks>If the specified configuration file does not exist, a new configuration file is created.</remarks>
    /// <param name="dvnConfigPath">The dvn configuration file path.</param>
    /// <returns>A <c>DvnConfiguration</c> object.</returns>
    internal static Configuration LoadFromFile(string dvnConfigPath)
    {
        if (!File.Exists(dvnConfigPath))
        {
            CreateNew(dvnConfigPath);
        }

        return Du.DuJson.ImportFromFile<Configuration>(dvnConfigPath);
    }

    /// <summary>Create a new DVN configuration file.</summary>
    /// <param name="dvnConfigPath">The dvn configuration file path.</param>
    internal static void CreateNew(string dvnConfigPath)
    {
        var config = new Configuration
        {
            ManifestExtension = ".dvn.manifest",
            ExcludedFiles     = Blueprint.Catalog.IgnoredFiles(),
            ExcludedFolders   = Blueprint.Catalog.IgnoredFolders()
        };

        Du.DuJson.ExportToFile(config, $@"{dvnConfigPath}");
    }
}