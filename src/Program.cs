/* dvn.Program.cs
 * u250729_code
 * u250729_documentation
 */

using dvn.App.CommandLine;
using dvn.App.Session;

namespace dvn
{
    /// <summary>Entry class for dvn.</summary>
    internal static class Program
    {
        /// <summary>Entry point for dvn.</summary>
        /// <param name="dvnArguments">The command line <see cref="DvnArguments">arguments</see> passed to dvn at execution.</param>
        internal static void Main(string[] dvnArguments)
        {
            DvnSession.Start(dvnArguments);
        }
    }
}