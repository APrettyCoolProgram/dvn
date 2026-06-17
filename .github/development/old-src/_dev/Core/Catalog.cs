// 260423_code
// 260423_documentation

namespace dvn.Core;

internal class Catalog
{
    internal static List<string> FrameworkDirectories() =>
    [
        ".dvn",
        ".dvn/App",
        ".dvn/Archive",
        ".dvn/Backup",
        ".dvn/Cache",
        ".dvn/Config",
        ".dvn/Log",
        ".dvn/Release",
        ".dvn/Scoop",
        ".dvn/Temporary",
        "Applications",
        "Repositories",
        "Secure",
        "Trash",
        "VirtualMachines",
        "WSL"
    ];
}