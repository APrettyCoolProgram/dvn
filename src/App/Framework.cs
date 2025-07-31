/* dvn.App.Framework.cs
 * u250731_code
 * u250731_documentation
 */

using dvn.Blueprint;

namespace dvn.App;

/// <summary>Logic for the dvn framework.</summary>
/// <remarks>
///     The <see cref="Framework"/> class contains the definitions for:<br/>
///     <list type="bullet">
///         <item>A list of <see cref="Files">files</see> required by dvn.</item>
///         <item>A list of <see cref="Folders">folders</see> required by dvn.</item>
///     </list>
/// </remarks>
internal class Framework
{
    /// <summary>Files required by dvn.</summary>
    internal Dictionary<string,string> Files { get; set; }

    /// <summary>Folders required by dvn.</summary>
    internal Dictionary<string, string> Folders { get; set; }

    /// <summary>Verifies that the dvn framework exists.</summary>
    /// <remarks>If the dvn framework does not exist, it will be created.</remarks>
    /// <param name="frameworkBase">The base path for the dvn framework.</param>
    internal static void VerifyExists(string frameworkBase)
    {
        if (!Directory.Exists(frameworkBase))
        {
            Console.WriteLine(UserMessage.msg_WelcomeToDvn);

            var dvnFramework = BuildNew();

            Validate(dvnFramework);

            Session.Stop();
        }
    }

    /// <summary>Constructs and returns a new instance of the <see cref="Framework"/> class.</summary>
    /// <remarks>
    ///     The <see cref="Framework"/> instance contains:<br/>
    ///     <list type="bullet">
    ///         <item>The list of <see cref="Files">files</see> required by dvn.</item>
    ///         <item>The list of <see cref="Folders">folders</see> required by dvn.</item>
    ///     </list>
    /// </remarks>
    /// <returns>A <see cref="Framework"/> object.</returns>
    internal static Framework BuildNew()
    {
        Dictionary<string, string> folders = BuildFolderDictionary();
        Dictionary<string, string> files   = BuildFileDictionary(folders);

        return new Framework
        {
            Folders = folders,
            Files   = files
        };
    }

    /// <summary>Builds a dictionary of folder details required by dvn.</summary>
    /// <remarks>The dictionary key represents the folder identifier, and the value is the full path to the folder.</remarks>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> of folder identifiers/paths.</returns>
    internal static Dictionary<string, string> BuildFolderDictionary()
    {
        return new Dictionary<string, string>
        {
            { "Root"         , @".\" },
            { "WinApps"      , @".\apps\win" },
            { "Backups"      , @".\.dvn\backups" },
            { "Configs"      , @".\.dvn\configs" },
            { "Manifests"    , @".\.dvn\manifests" },
            { "Staging"      , @".\.dvn\staging" },
            { "Temporary"    , @".\.dvn\temporary" },
            { "Trash"        , @".\.dvn\trash" },
            { "Repositories" , @".\data\repositories" }
        };
    }

    /// <summary>Builds a dictionary of file details required by dvn.</summary>>
    /// <remarks>The dictionary key represents the file identifier, and the value is the full path to the file.</remarks>
    /// <param name="folders">A dictionary containing dvn file paths.</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> of file identifiers/paths.</returns>

    internal static Dictionary<string, string> BuildFileDictionary(Dictionary<string, string> folders) =>
        new Dictionary<string, string>
        {
            { "ConfigFile", $@"{folders["Configs"]}\dvn.config" }
        };

    /// <summary>Validates the dvn framework.</summary>
    /// <param name="dvnFramework">The framework details to validate.</param>
    internal static void Validate(Framework dvnFramework)
    {
        ValidateFolders(dvnFramework.Folders);
        ValidateFiles(dvnFramework.Files);
    }

    /// <summary>Validates required files exist.</summary>
    /// <remarks>If the file does not exist, it is created.</remarks>
    /// <param name="files">The <see cref="Framework.Files"/> object containing file details.</param>
    internal static void ValidateFiles(Dictionary<string, string> files)
    {
        if (!File.Exists(files["ConfigFile"]))
        {
            Configuration.CreateNew(files["ConfigFile"]);
        }
    }

    /// <summary>Validates required folders exist.</summary>
    /// <remarks>If the folder does not exist, it is created.</remarks>
    /// <param name="folders">The <see cref="Framework.Folders"/> object containing folder details.</param>
    internal static void ValidateFolders(Dictionary<string, string> folders)
    {
        foreach (var folder in folders)
        {
            if (!Directory.Exists(folder.Value))
            {
                Directory.CreateDirectory(folder.Value);
            }
        }
    }
}