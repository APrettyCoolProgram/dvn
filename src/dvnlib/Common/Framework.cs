/* dvnlib.Framework.cs
 * u250707_code
 * u250707_documentation
 */

using dvnlib.Du;

namespace dvnlib
{
    /// <summary>The dvn framework components.</summary>
    internal class Framework
    {
        /// <summary>The dvn framework paths.</summary>
        public Dictionary<string, string> Path { get; set; }

        /// <summary> Creates a new instance of the <see cref="Framework"/> class with default paths initialized. </summary>
        /// <returns>A new <see cref="Framework"/> instance with predefined paths for data, staging, and repository.</returns>
        internal static Framework CreateNew()
        {
            return new Framework()
            {
                Path = new Dictionary<string, string>
                {
                    { "Data",       @".\AppData" },
                    { "Staging",    @".\AppData\staging" },
                    { "Repository", @".\AppData\staging\repository" }
                }
            };
        }

        /// <summary>Validate the devn framework.</summary>
        /// <param name="dvnFramework"> The <see cref="Framework.Framework"> to validate.</param>
        internal static void Validate(Framework dvnFramework)
        {
            foreach (var path in dvnFramework.Path)
            {
                DuDirectory.ForceExist(path.Value);
            }
        }

        /// <summary>
        /// Copies the contents of a source repository to a staging directory, excluding specified files and
        /// directories.
        /// </summary>
        /// <remarks>This method resets the staging directory before copying the repository contents.
        /// Files and directories excluded from the copy operation are determined by the repository's catalog
        /// configuration.</remarks>
        /// <param name="source">The path to the source repository to copy.</param>
        /// <param name="paths">A dictionary containing paths used during the operation. The key "Staging" must be present and specify the
        /// target directory where the repository will be copied.</param>
        internal static void CopyRepo(string source, Dictionary<string, string> paths)
        {
            DuDirectory.Reset(paths["Staging"]);

            string target             = paths["Staging"];
            List<string> excludeFiles = Blueprint.Catalog.bpl_ExcludedRepoFiles();
            List<string> excludeDirs  = Blueprint.Catalog.bpl_ExcludedRepoDirectories();

            DuDirectory.CopyExclude(source, target, excludeFiles, excludeDirs, true);
        }


    }
}