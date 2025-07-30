/* dvn.App.Arguments.cs
 * u250730_code
 * u250730_documentation
 */

using dvn.Blueprint;

namespace dvn.App;

/// <summary>Methods for handling and processing command-line arguments.</summary>
/// <remarks>
///     The dvn syntax is: <c>dvn &lt;command&gt; [-option01 -option02 ...]</c><br/>
///     <br/>
///     Valid commands:
///     <list type="bullet">
///         <item><c>%environment%</c> - Starts the <c>%environment%</c> environment,<br/> or creates a new <c>%environment%.dvn.manifest</c> file.</item>
///         <item><c>about</c> - Displays information about dvn.</item>
///         <item><c>help</c>  - Displays help information.</item>
///         <item><c>list</c>  - Lists all available development environments.</item>
///     </list>
///     Valid options:
///     <list type="bullet">
///         <item><c>-b</c> - Force the data backup functionality, potentially overriding the manifest file setting.</item>
///     </list>
/// </remarks>
internal static class Arguments
{
    /// <summary>Determines whether any arguments were passed via the command line.</summary>
    /// <param name="passedArguments">The arguments, if any, that were passed via the command line.</param>
    /// <returns><see langword="true"/> if one or more arguments were provided; otherwise, <see langword="false"/>.</returns>
    internal static bool DoExist(string[] passedArguments) => passedArguments != null && passedArguments.Length != 0;

    /// <summary>Parses the command component of the arguments passed via the command line.</summary>
    /// <remarks>
    ///     The only commands that are recoginzed are those with case statements.<br/>
    ///     <br/>
    ///     Entering a command that does not match any of the case statements will either:
    ///     <list type="bullet">
    ///         <item>Start the <c>&lt;command&gt;</c> environment, if a <c>&lt;command&gt;.dvn.manifest</c> file exists.</item>
    ///         <item>Create a new, default <c>&lt;command&gt;.dvn.manifest</c> file, if one does not exist.</item>
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