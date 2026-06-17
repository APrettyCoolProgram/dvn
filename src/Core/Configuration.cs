// 250920_code
// 260617_documentation

namespace dvn.Core;

/// <summary>Logic for dvn configuration settings.</summary>
/// <remarks>
/// The <see cref="Configuration"/> class contains the definition of the dvn configuration file, which defines:<br/>
/// <list type="bullet">
/// <item>The <see cref="ManifestExtension"/> extension used for dvn manifest files.</item>
/// <item>The list of <see cref="InstallableApps"/> that can be installed.</item>
/// <item>The list of <see cref="ExcludedFiles"/> that are excluded when backing up data.</item>
/// <item>The list of <see cref="ExcludedFolders"/> that are excluded when backing up data.</item>
/// </list>
/// </remarks>
internal class Configuration
{
    /// <summary>The file extension used for manifest files.</summary>
    /// <value>The manifest file extension.</value>
    public string ManifestExtension { get; set; }

    /// <summary>The installable applications that dvn can manage.</summary>
    /// <value>The available installable applications.</value>
    public Dictionary<string, string> InstallableApps { get; set; }

    /// <summary>The list of files that are excluded when backing up data.</summary>
    /// <value>The excluded file names.</value>
    public List<string> ExcludedFiles { get; set; }

    /// <summary>The list of folders that are excluded when backing up data.</summary>
    /// <value>The excluded folder names.</value>
    public List<string> ExcludedFolders { get; set; }

    /// <summary>Loads the dvn configuration from a local file.</summary>
    /// <remarks>
    /// If the specified configuration file does not exist, a new configuration file is created with default values. That newly<br/>
    /// created file will then be loaded.
    /// </remarks>
    /// <param name="dvnConfigPath">The path to the dvn configuration file.</param>
    /// <returns>A <see cref="Configuration"/> object representing the dvn configuration.</returns>
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
            InstallableApps   = Blueprint.Catalog.cat_InstallableApps(),
            ExcludedFiles     = Blueprint.Catalog.cat_IgnoredFiles(),
            ExcludedFolders   = Blueprint.Catalog.cat_IgnoredFolders()
        };

        Du.DuJson.ExportToFile<Configuration>(config, $@"{dvnConfigPath}");
    }
}