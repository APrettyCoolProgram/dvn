/* dvnlib.Blueprint.Catalog.cs
 * u250707_code
 * u250707_documentation
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvnlib.Blueprint
{
    internal class Catalog
    {
        /// <summary>Creates a list of directory names that should be excluded from repository operations.</summary>
        /// <returns>A list of directories to be excluded from repository-related processes</returns>
        internal static List<string> bpl_ExcludedRepoDirectories()
        {
            return
            [
                "node_modules",
                "bin",
                "obj",
                ".git",
                ".vs",
                ".vscode",
                ".idea",
                "packages"
            ];
        }

        /// <summary>Creates a list of folder names that should be excluded from repository operations.</summary>
        /// <returns>A list of folders to be excluded from repository-related processes</returns>
        internal static List<string> bpl_ExcludedRepoFiles()
        {
            return
            [
                ".DS_Store",
                "Thumbs.db",
                "desktop.ini",
                "package-lock.json",
                "yarn.lock",
                "pnpm-lock.yaml",
                "npm-shrinkwrap.json"
            ];
        }
    }
}
