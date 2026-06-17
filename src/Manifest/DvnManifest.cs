// 250920_code
// 260617_documentation

using dvn.Blueprint;
using dvn.Core;
using dvn.Du;

namespace dvn.Manifest;

/// <summary>Manifest logic.</summary>
internal class DvnManifest
{
    /// <summary>The development environment.</summary>
    /// <value>The environment settings defined by the manifest.</value>
    public DvnEnvironment DevelopmentEnvironment { get; set; }

    /// <summary>The applications associated with the environment.</summary>
    /// <value>The applications that will be started for the environment.</value>
    public List<DvnApplication> EnvironmentApplications { get; set; }

    /// <summary>The web browser configuration.</summary>
    /// <value>The pages that will be opened in each browser.</value>
    public DvnWebBrowser WebBrowser { get; set; }

    /// <summary>Creates a default dvn manifest file.</summary>
    /// <remarks>
    /// The manifest is created with a default environment, a placeholder application list, and default browser pages.
    /// </remarks>
    /// <param name="manifestFolder">The folder where the manifest file will be created.</param>
    /// <param name="manifestName">The name of the manifest file without extension.</param>
    /// <param name="manifestExtension">The manifest file extension.</param>
    internal static void CreateDefault(string manifestFolder, string manifestName, string manifestExtension)
    {
        var dvnManifest = new DvnManifest()
        {
            DevelopmentEnvironment = new DvnEnvironment
            {
                Name          = manifestName,
                Description   = "Default environment description.",
                BackupEnabled = false,
            },
            EnvironmentApplications =
            [
                new DvnApplication()
            ],
            WebBrowser = new DvnWebBrowser()
            {
                PagesToOpen = new Dictionary<string, Dictionary<string, string>>()
                {
                    { "Chrome",  new Dictionary<string, string>() },
                    { "Firefox",  new Dictionary<string, string>() },
                    { "IExplore", new Dictionary<string, string>() }
                }
            }
        };

        //TODO Split this out into a separate method.

        DuJson.ExportToFile(dvnManifest, $@"{manifestFolder}\{manifestName}{manifestExtension}");

        Console.WriteLine(UserMessage.msg_CreateManifest(manifestName));

        Session.Stop();
    }
}