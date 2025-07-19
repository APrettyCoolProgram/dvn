/* dvn.App.DvnEnvironment.cs
 * u250719_code
 * u250719_documentation
 */

/* Properties for this class be found in .\Properties\DvnEnvironment.Properties.cs.
 */

using dvn.App.Manifest;
using dvn.Du;

namespace dvn.App
{
    internal partial class DvnEnvironment
    {
        /// <summary>Get a list of available environment names and descriptions.</summary>
        /// <param name="path">The directory path to search for environment files. Must be a valid directory path.</param>
        /// <returns>A string containing the names of all environments found.</returns>
        internal static Dictionary<string, string> GetNameAndDescription(string manifestPath)
        {
            var manifestPaths = Directory.GetFiles(manifestPath, "*.manifest", SearchOption.AllDirectories);

            Dictionary<string, string> environmentDetail = [];

            foreach (var path in manifestPaths)
            {
                Manifest.DvnManifest dvnManifest = DuJson.ImportFromLocalFile<Manifest.DvnManifest>(path);
                environmentDetail[dvnManifest.EnvironmentName] = dvnManifest.EnvironmentDescription;
            }

            return environmentDetail;
        }
    }
}