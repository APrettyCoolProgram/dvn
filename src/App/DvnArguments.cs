/* dvn.App.DvnArgument.cs
 * u250719_code
 * u250719_documentation
 */

/* Properties for this class be found in .\Properties\DvnArgument.Properties.cs.
 */

namespace dvn.App
{
    internal partial class DvnArguments
    {
        /// <summary>Determines if arguments were passed via the command line.</summary>
        /// <param name="dvnArguments">The command line <see cref="DvnArguments">arguments</see> passed to dvn at execution.</param>
        /// <returns><c>true</c> if arguments were passed, <c>false</c> if not.</returns>
        internal static bool DoExist(string[] dvnArguments) => 
            dvnArguments != null && dvnArguments.Length != 0;

        /// <summary>Get the dvn <see cref="Command">command</see> and <see cref="Options">option(s)</see>.</summary>
        /// <param name="dvnArguments">The dvn arguments.</param>
        /// <returns>An <see cref="Argument"/> instance.</returns>
        internal static DvnArguments GetArguments(string[] dvnArguments)
        {
            return new DvnArguments()
            {
                Command = dvnArguments[0].ToLower().Trim(),
                Options = dvnArguments.Length < 2
                          ? []
                          : [.. dvnArguments[1..].Select(arg => arg.ToLower().Trim())]
            };
        }
    }
}
