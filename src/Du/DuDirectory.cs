/* DuDirectory.cs
 * Does stuff with directories.
 * b250801
 * A Pretty Cool Program
 * https://
 */

namespace dvn.Du;

/// <summary>Does stuff with directories.</summary>
internal static class DuDirectory
{
    // [250801]
    /// <summary>If the directory does not exist, create it.</summary>
    /// <param name="path">The directory path.</param>
    public static void ForceExist(string path)
    {
        if (!Directory.Exists(path))
        {
            _=Directory.CreateDirectory(path);
        }
    }

    // [250801]
    /// <summary>If the directory exists, delete it, then recreate it.</summary>
    /// <param name="path">The directory path.</param>
    public static void Reset(string path)
    {
        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }

        _=Directory.CreateDirectory(path);
    }

    // [250801]
    /// <summary>Verify a parent directory of a file exists.</summary>
    /// <param name="fullPath">The full path of a file.</param>
    public static void VerifyParent(string fullPath)
    {
        var dirInfo = new DirectoryInfo(fullPath);

        if (!dirInfo.Parent.Exists)
        {
            _=Directory.CreateDirectory(dirInfo.Parent.ToString());
        }
    }

    // [250801]
    /// <summary>Copies the contents of a source directory to a target directory.</summary>
    /// <remarks>
    ///     This method copies all files from the <paramref name="source"/> directory to the
    ///     <paramref name="target"/> directory, which is created if it does not exist.
    ///     If <paramref name="recursive"/> is <see langword="true"/>, subdirectories and
    ///     their contents are also copied. Existing files in the target directory will be
    ///     overwritten.
    /// </remarks>
    /// <param name="source">The path of the source directory to copy.</param>
    /// <param name="target">The path of the target directory where the contents will be copied.</param>
    /// <param name="recursive">A value indicating whether subdirectories should be copied recursively.</param>
    public static void Copy(string source, string target, bool recursive = true)
    {
        if (!Directory.Exists(source))
        {
            throw new DirectoryNotFoundException($"Source directory does not exist: {source}");
        }

        ForceExist(target);

        foreach (var file in Directory.GetFiles(source))
        {
            var destFile = Path.Combine(target, Path.GetFileName(file));
            File.Copy(file, destFile, true);
        }

        if (recursive)
        {
            foreach (var subDir in Directory.GetDirectories(source))
            {
                var destSubDir = Path.Combine(target, Path.GetFileName(subDir));
                Copy(subDir, destSubDir, true);
            }
        }
    }

    // [250801]
    /// <summary>Copies contents from the source directory to the target directory, excluding specified files and directories.</summary>
    /// <remarks>This method ensures that the <paramref name="target"/> directory exists before
    /// copying. Files and directories specified in <paramref name="excludeFiles"/> and <paramref
    /// name="excludeDirs"/>  are skipped during the copy operation.</remarks>
    /// <param name="source">The path of the source directory to copy from. Must exist.</param>
    /// <param name="target">The path of the target directory to copy to. Will be created if it does not exist.</param>
    /// <param name="excludeFiles">A list of file names to exclude from copying. File names should not include path information.</param>
    /// <param name="excludeDirs">A list of directory names to exclude from copying. Directory names should not include path information.</param>
    /// <param name="recursive">A value indicating whether subdirectories should be copied recursively.  <see langword="true"/> to copy
    /// subdirectories; otherwise, <see langword="false"/>.</param>
    /// <exception cref="DirectoryNotFoundException">Thrown if the <paramref name="source"/> directory does not exist.</exception>
    public static void CopyExclude(string source, string target, List<string> excludeFiles, List<string> excludeDirs, bool recursive = true)
    {
        if (!Directory.Exists(source))
        {
            throw new DirectoryNotFoundException($"Source directory does not exist: {source}");
        }

        ForceExist(target);

        foreach (var file in Directory.GetFiles(source))
        {
            if (excludeFiles.Contains(Path.GetFileName(file)))
            {
                continue;
            }

            var destFile = Path.Combine(target, Path.GetFileName(file));
            File.Copy(file, destFile, true);
        }

        if (recursive)
        {
            foreach (var subDir in Directory.GetDirectories(source))
            {
                if (excludeDirs.Contains(Path.GetFileName(subDir)))
                {
                    continue;
                }

                var destSubDir = Path.Combine(target, Path.GetFileName(subDir));
                CopyExclude(subDir, destSubDir, excludeFiles, excludeDirs, true);
            }
        }

        var test = 0;
    }
}