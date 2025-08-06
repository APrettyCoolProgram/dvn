/* dvn.Manifest.DvnManifest.cs
 * u250806_code
 * u250806_documentation
 */

using dvn.App;
using dvn.Blueprint;
using dvn.Du;

namespace dvn.Manifest;

internal class DvnManifest
{
    /// <summary>The environment name.</summary>
    public DvnEnvironment DevelopmentEnvironment { get; set; }

    /// <summary>A list of applications associated with the environment.</summary>
    public List<DvnApplication> EnvironmentApplications { get; set; }

    public DvnWebBrowser WebBrowser { get; set; }

    /// <summary>Creates a default instance of the <see cref="DvnManifest"/> class.</summary>
    /// <param name="fileName">The name of the environment file.</param>
    /// <returns>A new instance of the <see cref="DevnEnv"/> class initialized with default values.</returns>
    internal static void CreateNew(string manifestFolder, string manifestName, string manifestExtension)
    {
        var dvnManifest = new DvnManifest()
        {
            DevelopmentEnvironment  = DvnEnvironment.New(manifestName),
            EnvironmentApplications =
            [
                new DvnApplication()
            ],
            WebBrowser = new DvnWebBrowser()
        };

        DuJson.ExportToFile(dvnManifest, $@"{manifestFolder}\{manifestName}{manifestExtension}");

        Console.WriteLine(UserMessage.msg_CreateManifest(manifestName));

        Session.Stop();
    }
}