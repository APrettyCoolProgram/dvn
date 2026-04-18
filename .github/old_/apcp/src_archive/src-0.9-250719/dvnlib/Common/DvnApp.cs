/* dvnlib.DvnApp.cs
 * u250719_code
 * u250719_documentation
 */


/* Properties for this class be found in DvnApp.Properties.cs.
 */

using dvnlib.Du;

namespace dvnlib.Common
{

    /// <summary>The dvn application instance, which contains dvn-specific information.</summary>
    internal partial class DvnApp
    {
        /// <summary>Creates a new <see cref="DvnApp"/> instance.</summary>
        /// <param name="exeAsmName">The <see cref="ExeAsmName">executing assembly name</see>.</param>
        /// <param name="exeAsmVersion">The <see cref="ExeAsmVersion">executing assembly version</see>.</param>
        /// <returns>A new <see cref="DvnApp"/> instance.</returns>
        internal static DvnApp New(string exeAsmName, string exeAsmVersion)
        {
            return new DvnApp
            {
                ExeAsmName      = exeAsmName,
                ExeAsmVersion   = exeAsmVersion,
            };
        }

        /// <summary>Loads a dvn app configuration file.</summary>
        /// <param name="exeAsmName">The <see cref="ExeAsmName">executing assembly name</see>.</param>
        /// <param name="exeAsmVersion">The <see cref="ExeAsmVersion">executing assembly version</see>.</param>
        /// <param name="dvnConfigPath">Path to the dvnApp.config file.</param>
        /// <returns></returns>
        internal static DvnApp Load(string exeAsmName, string exeAsmVersion,string dvnConfigPath)
        {
            if (!File.Exists(dvnConfigPath))
            {
                CreateDefault(dvnConfigPath);
            }

            DvnApp dvnApp = DuJson.ImportFromLocalFile<DvnApp>(dvnConfigPath);

            dvnApp.ExeAsmName    = exeAsmName;
            dvnApp.ExeAsmVersion = exeAsmVersion;

            return dvnApp;
        }

        /// <summary>Creates a default configuration file for the application at the specified path.</summary>
        /// <param name="dvnConfigPath">Path to the dvnApp.config file.</param>
        internal static void CreateDefault(string dvnConfigPath)
        {
            var dvnApp = new DvnApp
            {
                ExeAsmName      = null,
                ExeAsmVersion   = null,
                ExcludedFiles   = Blueprint.Catalog.IgnoredFiles(),
                ExcludedFolders = Blueprint.Catalog.IgnoredFolders()
            };

            DuJson.ExportToLocalFile<DvnApp>(dvnApp, $@"{dvnConfigPath}");
        }
    }
}