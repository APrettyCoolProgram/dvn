// 250801_code
// 260617_documentation

namespace dvn.Core;

/// <summary>Provides logic for <c>dvn</c> configuration settings.</summary>
/// <remarks>
/// The <see cref="Configuration"/> class defines the structure of the <c>dvn</c> configuration file.
/// It includes:
/// <list type="bullet">
/// <item><see cref="ManifestExtension"/> used for <c>dvn</c> manifest files.</item>
/// <item><see cref="ExcludedFiles"/> excluded during backup operations.</item>
/// <item><see cref="ExcludedFolders"/> excluded during backup operations.</item>
/// </list>
/// </remarks>
internal class Configuration
{
    /// <summary>The file extension used for manifest files.</summary>
    public string ManifestExtension { get; set; }

    /// <summary>The list of files that are excluded when backing up data.</summary>
    public List<string> ExcludedFiles { get; set; }

    /// <summary>The list of folders that are excluded when backing up data.</summary>
    public List<string> ExcludedFolders { get; set; }

    /// <summary>Loads the <c>dvn</c> configuration from a local file.</summary>
    /// <remarks>
    /// If the specified configuration file does not exist, a new configuration file is created with default values.
    /// The newly created file is then loaded.
    /// </remarks>
    /// <param name="dvnConfigPath">The path to the <c>dvn</c> configuration file.</param>
    /// <returns>A <see cref="Configuration"/> object representing the <c>dvn</c> configuration.</returns>
    internal static Configuration LoadFromFile(string dvnConfigPath)
    {
        if (!File.Exists(dvnConfigPath))
        {
            CreateNew(dvnConfigPath);
        }

        return Du.DuJson.ImportFromFile<Configuration>(dvnConfigPath);
    }

    /// <summary>Creates a new dvn configuration file using default settings at the specified path.</summary>
    /// <param name="dvnConfigPath">The file path where the dvn configuration will be created.</param>
    internal static void CreateNew(string dvnConfigPath)
    {
        var config = new Configuration()
        {
            ManifestExtension = ".mnfst",
            ExcludedFiles     = Blueprint.Catalog.IgnoredFiles(),
            ExcludedFolders   = Blueprint.Catalog.IgnoredFolders()
        };

        Du.DuJson.ExportToFile<Configuration>(config, $@"{dvnConfigPath}");
    }
}