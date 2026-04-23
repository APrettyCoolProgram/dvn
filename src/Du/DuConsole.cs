// 260423_code
// 260423_documentation

// Classes in ns:Du are public, since they may be used in other projects.

namespace dvn.Du;

internal static class DuConsole
{
    internal static void DisplayLine(string message, string logPath = null)
    {
        if (string.IsNullOrWhiteSpace(logPath))
        {
            File.AppendAllText(logPath, $"{message}{Environment.NewLine}");
        }

        Console.WriteLine(message);
    }
}