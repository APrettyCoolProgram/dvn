// 250801_code
// 260617_documentation

using dvn.Core;

namespace dvn;

/// <summary>Entry point for dvn.</summary>
internal static class Program
{
    /// <summary>Starts dvn with the provided command-line arguments.</summary>
    /// <param name="dvnArguments">The command-line arguments passed to dvn.</param>
    internal static void Main(string[] dvnArguments) => Session.Start(dvnArguments);
}