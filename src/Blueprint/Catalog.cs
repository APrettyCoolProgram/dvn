// 260617_code
// 260617_documentation

namespace dvn.Blueprint;

/// <summary>Provides predefined data structures.</summary>
internal static class Catalog
{
    /// <summary>A list of repository files that should be ignored when copying.</summary>
    internal static List<string> lst_RepositoryIgnoredFiles =>
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
    internal static List<string> lst_OtherIgnoredFiles =>
        [
        ];

    /// <summary>A list of repository folders that should be ignored when copying.</summary>
    internal static List<string> lst_RepositoryIgnoredFolders =>
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
    internal static List<string> lst_OtherIgnoredolders =>
    [
    ];

    /// <summary>Combines the configured file ignore lists.</summary>
    /// <returns>A list of file names that should be ignored when copying.</returns>
    internal static List<string> lst_IgnoredFiles() =>
    [.. lst_RepositoryIgnoredFiles
        .Concat(lst_OtherIgnoredFiles)
        .Distinct()
    ];

    /// <summary>Combines the configured folder ignore lists.</summary>
    /// <returns>A list of folder names that should be ignored when copying.</returns>
    internal static List<string> lst_IgnoredFolders() =>
    [.. lst_RepositoryIgnoredFolders
        .Concat(lst_OtherIgnoredolders)
        .Distinct()
    ];
}