/* dvn.Program.cs
 * u250719_code
 * u250719_documentation
 */

using dvn.App;

namespace dvn
{
    /// <summary>Entry class.</summary>
    internal static class Program
    {
        /// <summary>Entry point.</summary>
        /// <param name="dvnArguments">The command line <see cref="Argument">arguments</see> passed to dvn at execution.</param>
        internal static void Main(string[] dvnArguments)
        {
            DvnSession.Start(dvnArguments);
        }
    }
}