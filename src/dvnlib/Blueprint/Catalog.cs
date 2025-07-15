/* dvnlib.Blueprint.Catalog.cs
 * u250715_code
 * u250715_documentation
 */

namespace dvnlib.Blueprint
{
    internal class Catalog
    {
        /// <summary>A list of folder names that should be excluded from repository operations.</summary>
        /// <returns>A list of folders to be excluded from repository-related processes</returns>
        internal static List<string> ExcludedRepoFiles() =>
        [
            ".DS_Store",
            "Thumbs.db",
            "desktop.ini",
            "package-lock.json",
            "yarn.lock",
            "pnpm-lock.yaml",
            "npm-shrinkwrap.json"
        ];

        /// <summary>Creates a list of directory names that should be excluded from repository operations.</summary>
        /// <returns>A list of directories to be excluded from repository-related processes</returns>
        internal static List<string> ExcludedRepoDirectories() =>
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
}