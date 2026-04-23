// 260423_code
// 260423_documentation

// Classes in ns:Du are public, since they may be used in other projects.

namespace dvn.Du;

public class DuDirectory
{
    // 260422.221513
    public static void ResetListOf(List<string> directories)
    {
        foreach (var directory in directories)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }

            Directory.CreateDirectory(directory);
        }
    }

    // 260422.221513
    public static void CreateListOf(List<string> directories)
    {
        foreach (var directory in directories)
        {
            Directory.CreateDirectory(directory);
        }
    }
}
