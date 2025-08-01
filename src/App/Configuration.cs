/* dvn.App.Configuration.cs
 * u250801_code
 * u250801_documentation
 */

namespace dvn.App;

/// <summary>Logic for dvn configuration settings.</summary>
/// <remarks>
///     The <see cref="Configuration"/> class contains the definition of the dvn configuration file, which defines:<br/>
///     <list type="bullet">
///         <item>The <see cref="ManifestExtension"> extension</see> used for dvn manifest files.</item>
///         <item>The list of <see cref="ExcludedFiles"> files</see> that are excluded when backing up data.</item>
///         <item>The list of <see cref="ExcludedFolders"> folders</see> that are excluded when backing up data.</item>
///     </list>
/// </remarks>
internal class Configuration
{
    /// <summary>The file extension used for manifest files.</summary>
    public string ManifestExtension { get; set; }

    /// <summary>The list of files that are excluded when backing up data.</summary>
    public List<string> ExcludedFiles { get; set; }

    /// <summary>The list of folder that are excluded when backing up data.</summary>
    public List<string> ExcludedFolders { get; set; }

    /// <summary>Loads the dvn configuration from a local file.</summary>
    /// <remarks>
    ///     If the specified configuration file does not exist, a new configuration file is created with default values. That newly<br/>
    ///     created file will then be loaded.
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
            ManifestExtension = ".dvn.manifest",
            ExcludedFiles     = Blueprint.Catalog.IgnoredFiles(),
            ExcludedFolders   = Blueprint.Catalog.IgnoredFolders()
        };

        Du.DuJson.ExportToFile<Configuration>(config, $@"{dvnConfigPath}");
    }
}