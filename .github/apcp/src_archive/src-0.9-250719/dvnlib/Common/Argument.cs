/* dvnlib.Argument.cs
 * u250719_code
 * u250719_documentation
 */

/* Properties for this class be found in Arguments.Properties.cs.
 */

using dvnlib.Blueprint;
using dvnlib.Framework;
using dvnlib.Common;

namespace dvnlib
{
    /// <summary>Argument logic.</summary>
    /// <remarks>
    ///     dvn <c>Arguments</c> tell dvn <i>what</i> to do, and (optionally) <i>how</i> to do it.<br/>
    ///     <br/>
    ///     Arguments are comprised of a single <see cref="Command">command</see> (the <i>what</i>), and <see cref="Options">option(s)</see> (the <i>how</i>).
    /// </remarks>
    internal partial class Argument
    {
        /// <summary>Get the dvn <see cref="Command">command</see> and <see cref="Options">option(s)</see>.</summary>
        /// <param name="args">The dvn arguments.</param>
        /// <returns>An <see cref="Argument"/> instance.</returns>
        internal static Argument GetArguments (string[] args) => new Argument()
        {
            Command = args[0].ToLower().Trim(),
            Options = args.Length < 2
                          ? []
                          : [.. args[1..].Select(arg => arg.ToLower().Trim())]
        };

        /// <summary>Logic for when arguments are not passed to dvn.</summary>
        /// <remarks>
        ///     There are two reasons why arguments may not be passed to dvn:<br/>
        ///     <list type="bullet">
        ///         <item>User error - The user did not pass any arguments, so let them know, then exit.</item>
        ///         <item>Initial run - This is the first time dvn has been executed, and needs to be initialized.</item>
        ///     </list>
        /// </remarks>
        /// <param name="exeAsmName">The <see cref="DvnApp.ExeAsmName">executing assembly name</see>.</param>
        internal static void NoArgumentsPassed(string exeAsmName)
        {
            var folderFramework = new FolderFramework();

            if (!Directory.Exists(folderFramework.DvnRoot))
            {
                Initializer.InitializeFramework(exeAsmName, folderFramework);
            }
            else
            {
                Session.Stop(exeAsmName, UserMessage.MissingArgument);
            }
        }
    }
}