// 250920_code
// 250920_documentation

using dvn.Core;

namespace dvn;

/// <summary>Entry class for dvn.</summary>
internal static class Program
{
    /// <summary>Entry point for dvn.</summary>
    /// <param name="dvnArguments">The command line arguments passed to dvn at execution.</param>
    internal static void Main(string[] dvnArguments) => Session.Start(dvnArguments);
}