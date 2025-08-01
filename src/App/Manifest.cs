/* dvn.App.Manifest.DvnManifest.cs
 * u250801_code
 * u250801_documentation
 */

using dvn.Blueprint;
using dvn.Du;

namespace dvn.App;

internal class Manifest
{
    /// <summary>The environment name.</summary>
    public DevelopmentEnvironment DevelopmentEnvironment { get; set; }

    /// <summary>A list of applications associated with the environment.</summary>
    public List<EnvironmentApplication> EnvironmentApplications { get; set; }

    /// <summary>Creates a default instance of the <see cref="Manifest"/> class.</summary>
    /// <param name="fileName">The name of the environment file.</param>
    /// <returns>A new instance of the <see cref="DevnEnv"/> class initialized with default values.</returns>
    internal static void CreateNew(string manifestFolder, string manifestName, string manifestExtension)
    {
        var dvnManifest = new Manifest()
        {
            DevelopmentEnvironment  = DevelopmentEnvironment.New(manifestName),
            EnvironmentApplications =
            [
                new EnvironmentApplication()
            ]
        };

        DuJson.ExportToFile(dvnManifest, $@"{manifestFolder}\{manifestName}{manifestExtension}");

        Console.WriteLine(UserMessage.msg_CreateManifest(manifestName));

        Session.Stop();
    }
}