/* dvn.Program.cs
 * u250731_code
 * u250731_documentation
 */

using dvn.App;

namespace dvn;

/// <summary>Entry class for dvn.</summary>
internal static class Program
{
    /// <summary>Entry point for dvn.</summary>
    /// <param name="dvnArguments">The command line <see cref="CommandLine">arguments</see> passed to dvn at execution.</param>
    internal static void Main(string[] dvnArguments) => Session.Start(dvnArguments);
}