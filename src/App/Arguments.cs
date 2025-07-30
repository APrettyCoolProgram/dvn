/* dvn.App.Arguments.cs
 * u250730_code
 * u250730_documentation
 */

using dvn.Blueprint;

namespace dvn.App;

/// <summary>Methods for handling and processing arguments passed via the <see cref="CommandLine"/>.</summary>
/// <remarks>
///     Valid <see cref="CommandLine.Command"> commands</see>:
///     <list type="bullet">
///         <item><c>%environment%</c> - Loads or creates a <c>%environment%.dvn.manifest</c> file.</item>
///         <item><c>about</c> - Displays information about dvn.</item>
///         <item><c>help</c>  - Displays help information.</item>
///         <item><c>list</c>  - Lists all available development environments.</item>
///     </list>
///     Valid <see cref="CommandLine.Options"> options</see>:
///     <list type="bullet">
///         <item><c>-b</c> - Force the data backup functionality, potentially overriding the manifest file setting.</item>
///     </list>
/// </remarks>
internal static class Arguments
{
    /// <summary>Determines whether any arguments were passed via the command-line.</summary>
    /// <param name="passedArguments">The arguments, if any, that were passed via the command-line.</param>
    /// <returns><see langword="true"/> if one or more arguments were provided; otherwise, <see langword="false"/>.</returns>
    internal static bool DoExist(string[] passedArguments) =>
        passedArguments != null && passedArguments.Length != 0;

    /// <summary>Parses the command component of the arguments passed via the command-line.</summary>
    /// <remarks>
    ///     Entering a command that does not match any of the case statements will either:
    ///     <list type="bullet">
    ///         <item>Start the <c>&lt;command&gt;</c> environment, if a <c>&lt;command&gt;.dvn.manifest</c> file exists.</item>
    ///         <item>If a <c>&lt;command&gt;.dvn.manifest</c> does not exist, create a new file with default values.</item>
    ///     </list>
    /// </remarks>
    /// <param name="dvnSession">The <see cref="App.Session"/> instance.</param>
    internal static void ParseCommand(Session dvnSession)
    {
        switch (dvnSession.CommandLine.Command)
        {
            case "about":
                Console.WriteLine(UserMessage.msg_About);
                break;

            case "help":
                Console.WriteLine(UserMessage.msg_Help);
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