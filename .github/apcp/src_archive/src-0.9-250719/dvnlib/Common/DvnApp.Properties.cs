/* dvnlib.DvnApp.Properties.cs
 * u250719_code
 * u250719_documentation
 */

using dvnlib.Du;

namespace dvnlib.Common
{
    internal partial class DvnApp
    {
        internal string ExeAsmName { get; set; }

        /// <summary>The current version of the executing assembly.</summary>
        internal string ExeAsmVersion { get; set; }

        internal List<string> ExcludedFiles { get; set; }
        internal List<string> ExcludedFolders { get; set; }
    }
}