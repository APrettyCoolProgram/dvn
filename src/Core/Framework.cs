// 260419_code
// 260419_documentation

namespace dvn.Core;

internal class Framework
{
    internal static void InitializeFramework()
    {
        Du.DuDirectory.CreateListOf(Catalog.FrameworkDirectories());
    }
}