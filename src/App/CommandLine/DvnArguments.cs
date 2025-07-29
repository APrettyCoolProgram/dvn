/* dvn.App.CommandLine.DvnArgument.cs
 * u250729_code
 * u250729_documentation
 */

using dvn.App.DevelopmentEnvironment;
using dvn.App.Framework;
using dvn.App.Session;
using dvn.Blueprint;

namespace dvn.App.CommandLine
{
    /// <summary>Logic for arguments that are passed to dvn at execution via the command-line.</summary>
    internal class DvnArguments
    {
        /// <summary>The dvn <c>command</c>.</summary>
        /// <remarks>There can only be one command, and it's always the first argument.<br/></remarks>
        internal string Command { get; set; }

        /// <summary>The dvn <c>options</c>.</summary>
        /// <remarks>
        ///     There can be any number of options, only those that are valid will be processed.<br/>
        ///     <br/>
        ///     Options must:
        ///     <list type="bullet">
        ///         <item>Be a single character</item>
        ///         <item>Start with the "<c>-</c>" (dash) character</item>
        ///         <item>Be separated by a space</item>
        ///     </list>
        /// </remarks>
        internal List<string> Options { get; set; }

        /// <summary>Determines if arguments were passed via the command line.</summary>
        /// <param name="arguments">The command line <see cref="DvnArguments">arguments</see> passed to dvn at execution.</param>
        /// <returns><c>true</c> if arguments were passed, <c>false</c> if not.</returns>
        internal static bool DoExist(string[] arguments) => 
            arguments != null && arguments.Length != 0;

        /// <summary>Get the dvn <see cref="Command">command</see> and <see cref="Options">option(s)</see>.</summary>
        /// <param name="arguments">The dvn arguments.</param>
        /// <returns>An <see cref="Argument"/> instance.</returns>
        internal static DvnArguments GetFromCommandLine(string[] arguments)
        {
            return new DvnArguments()
            {
                Command = arguments[0].ToLower().Trim(),
                Options = arguments.Length < 2
                          ? []
                          : [.. arguments[1..].Select(arg => arg.ToLower().Trim())]
            };
        }

        /// <summary>Parses the <see cref="Command"/> argument, and executes an action.</summary>
        /// <param name="session">The session instance.</param>
        internal static void Parse(DvnSession session)
        {
            switch (session.Arguments.Command)
            {
                case "help":
                    Console.WriteLine(UserMessage.Help);
                    break;

                case "about":
                    Console.WriteLine(UserMessage.About);
                    break;

                case "list":
                    DvnEnvironment.DisplayAvailable(session.EnvironmentList);
                    break;

                default:
                    DvnEnvironment.Load(session);
                    break;
            }
        }
    }
}