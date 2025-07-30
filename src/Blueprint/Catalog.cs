/* dvn.Blueprint.Catalog.cs
 * u250730_code
 * u250730_documentation
 */

namespace dvn.Blueprint;

/// <summary>Provides predefined data structures.</summary>
internal static class Catalog
{
    /// <summary>A list of repository files that should be ignored when copying.</summary>
    internal static List<string> cat_RepositoryIgnoredFiles =>
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
    internal static List<string> cat_OtherIgnoredFiles =>
        [
        ];

    /// <summary>A list of repository folders that should be ignored when copying.</summary>
    internal static List<string> cat_RepositoryIgnoredFolders =>
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
    internal static List<string> cat_OtherIgnoredolders =>
    [
    ];

    /// <summary>A list of files that should be ignored when copying.</summary>
    internal static List<string> IgnoredFiles() =>
    [.. cat_RepositoryIgnoredFiles
        .Concat(cat_OtherIgnoredFiles)
        .Distinct()
    ];

    /// <summary>A list of folders that should be ignored when copying.</summary>
    internal static List<string> IgnoredFolders() =>
    [.. cat_RepositoryIgnoredFolders
        .Concat(cat_OtherIgnoredolders)
        .Distinct()
    ];
}
