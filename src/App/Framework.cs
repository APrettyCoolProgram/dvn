/* dvn.App.Framework.cs
 * u250730_code
 * u250730_documentation
 */

using dvn.Blueprint;

namespace dvn.App;

/// <summary>Logic for the dvn framework.</summary>
internal class Framework
{
    /// <summary>The dvn file framework.</summary>
    internal Dictionary<string,string> Files { get; set; }

    /// <summary>The dvn folder framework.</summary>
    internal Dictionary<string, string> Folders { get; set; }

    /// <summary> Verifies the existence of the required directory and performs initialization if necessary.</summary>
    internal static void VerifyExists()
    {
        if (!Directory.Exists(@".\.dvn"))
        {
            Console.WriteLine(UserMessage.msg_WelcomeToDvn);

            var dvnFramework = BuildNew();

            Validate(dvnFramework);

            Session.Stop();
        }
    }

    /// <summary>Constructs and returns a new instance of the <see cref="Framework"/> class.</summary>
    /// <returns>A <see cref="Framework"/> object initialized with the current folder and file lists.</returns>
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

    /// <summary>Validates the specified framework configuration.</summary>
    /// <param name="dvnFramework">The framework configuration to validate. Must not be null.</param>
    internal static void Validate(Framework dvnFramework)
    {
        ValidateFolders(dvnFramework.Folders);
        ValidateFiles(dvnFramework.Files);
    }
    /// <summary>Initializes a new instance of the <see cref="DvnFile"/> class.</summary>
    /// <param name="dvnFolder">The folder containing configuration files.</param>
    /// <returns>A <see cref="DvnFile"/> object.</returns>
    internal static Dictionary<string, string> BuildFileDictionary(Dictionary<string, string> folders)
    {
        return new Dictionary<string, string>
        {
            { "ConfigFile", $@"{folders["Configs"]}\dvn.config" }
        };
    }

    /// <summary>Validates that a list of files exists.</summary>
    /// <param name="file">The <see cref="DvnFile"/> object containing the path to the configuration file to validate.</param>
    internal static void ValidateFiles(Dictionary<string, string> files)
    {
        if (!File.Exists(files["ConfigFile"]))
        {
            Configuration.CreateNew(files["ConfigFile"]);
        }
    }
    /// <summary>Creates a new instance of the <see cref="DvnFolder"/> class.</summary>
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

    /// <summary>Validates the directory paths in the specified <see cref="DvnFolder"/> instance.</summary>
    /// <remarks>If the specified folder does not exist, it will be created.</remarks>
    /// <param name="folders">The <see cref="DvnFolder"/> instance containing directory paths to validate.</param>
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