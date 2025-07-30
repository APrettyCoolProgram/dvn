/* dvn.App.Arguments.cs
 * u250730_code
 * u250730_documentation
 */

using dvn.Blueprint;

namespace dvn.App;
internal class Arguments
{
    /// <summary>Determines if arguments were passed via the command line.</summary>
    /// <param name="arguments">The command line <see cref="CommandLine">arguments</see> passed to dvn at execution.</param>
    /// <returns><c>true</c> if arguments were passed, <c>false</c> if not.</returns>
    internal static bool DoExist(string[] arguments) =>
        arguments != null && arguments.Length != 0;

    /// <summary>Get the dvn <see cref="Command">command</see> and <see cref="Options">option(s)</see>.</summary>
    /// <param name="dvnArguments">The dvn arguments.</param>
    /// <returns>An <see cref="Arguments"/> instance.</returns>
    internal static CommandLine GetFromCommandLine(string[] dvnArguments)
    {
        return new CommandLine()
        {
            Command = dvnArguments[0].ToLower().Trim(),
            Options = dvnArguments.Length < 2
                      ? []
                      : [.. dvnArguments[1..].Select(arg => arg.ToLower().Trim())]
        };
    }

    /// <summary>Parses the <see cref="Command"/> argument, and executes an action.</summary>
    /// <param name="dvnSession">The session instance.</param>
    internal static void ParseCommand(Session dvnSession)
    {
        switch (dvnSession.CommandLine.Command)
        {
            case "help":
                Console.WriteLine(UserMessage.msg_Help);
                break;

            case "about":
                Console.WriteLine(UserMessage.msg_About);
                break;

            case "list":
                DevelopmentEnvironment.DisplayAvailable(dvnSession.AvailableEnvironments);
                break;

            default:
                DevelopmentEnvironment.LoadFromManifest(dvnSession);
                break;
        }
    }
}