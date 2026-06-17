// 250806_code
// 260617_documentation

using dvn.Blueprint;
using dvn.Du;
using dvn.Core;

namespace dvn.Manifest;

/// <summary>Represents a dvn manifest file.</summary>
internal class DvnManifest
{
    /// <summary>The development environment definition.</summary>
    public DvnEnvironment DevelopmentEnvironment { get; set; }

    /// <summary>The applications associated with the environment.</summary>
    public List<DvnApplication> EnvironmentApplications { get; set; }

    /// <summary>The web browser configuration for the environment.</summary>
    public DvnWebBrowser WebBrowser { get; set; }

    /// <summary>Creates a default instance of the <see cref="DvnManifest"/> class.</summary>
    /// <param name="manifestFolder">The folder where the manifest file will be created.</param>
    /// <param name="manifestName">The name of the environment file.</param>
    /// <param name="manifestExtension">The file extension used for manifest files.</param>
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
                BrowserPages = new Dictionary<string, Dictionary<string, string>>()
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