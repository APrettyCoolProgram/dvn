/* dvn.App.DvnConfiguration.cs
 * u250719_code
 * u250719_documentation
 */

/* Properties for this class be found in .\Properties\DvnConfiguration.Properties.cs.
 */

namespace dvn.App
{
    internal partial class DvnConfiguration
    {
        internal static DvnConfiguration Load(string dvnConfigPath)
        {
            if (!File.Exists(dvnConfigPath))
            {
                CreateNew(dvnConfigPath);
            }

            return Du.DuJson.ImportFromLocalFile<DvnConfiguration>(dvnConfigPath);
        }

        internal static void CreateNew(string dvnConfigPath)
        {
            var config = new DvnConfiguration
            {
                ExcludedFiles   = Blueprint.Catalog.IgnoredFiles(),
                ExcludedFolders = Blueprint.Catalog.IgnoredFolders()
            };

            Du.DuJson.ExportToLocalFile<DvnConfiguration>(config, $@"{dvnConfigPath}");
        }
    }
}