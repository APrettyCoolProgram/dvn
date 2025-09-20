/* dvnlib.Blueprint.Catalog.cs
 * u250719_code
 * u250719_documentation
 */

namespace dvnlib.Blueprint
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Catalog
    {
        /// <summary>A list of repository files that should be ignored when copying.</summary>
        internal static List<string> RepositoryIgnoredFiles =>
            [
                ".DS_Store",
                "Thumbs.db",
                "desktop.ini",
                "package-lock.json",
                "yarn.lock",
                "pnpm-lock.yaml",
                "npm-shrinkwrap.json"
            ];

        /// <summary>A list of other files that should be ignored when copying.</summary>
        internal static List<string> OtherIgnoredFiles =>
            [
            ];

        /// <summary>A list of repository folders that should be ignored when copying.</summary>
        internal static List<string> RepositoryIgnoredFolders =>
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

        /// <summary>A list of other folders that should be ignored when copying.</summary>
        internal static List<string> OtherIgnoredolders =>
            [
            ];


        /// <summary>A list of files that should be ignored when copying.</summary>
        internal static List<string> IgnoredFiles() =>
            [.. RepositoryIgnoredFiles
                .Concat(OtherIgnoredFiles)
                .Distinct()
            ];

        /// <summary>A list of folders that should be ignored when copying.</summary>
        internal static List<string> IgnoredFolders() =>
            [.. RepositoryIgnoredFolders
                .Concat(OtherIgnoredolders)
                .Distinct()
            ];
    }
}