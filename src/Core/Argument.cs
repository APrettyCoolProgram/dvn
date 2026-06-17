// u250920_code
// u250920_documentation

using dvn.Blueprint;

namespace dvn.Core;

/// <summary>Methods for handling and processing arguments passed via the <see cref="CommandLine"/>.</summary>
/// <remarks>To get a list of available commands/requests/options, run "<c>dvn ---help</c>.<br/>"</remarks>
internal class Argument
{
    /// <summary>The dvn <c>command</c>.</summary>
    /// <remarks>
    ///    There can only be one command.<br/>
    ///    <br/>
    ///    The command:
    ///     <list type="bullet">
    ///         <item>Should be the <i>first</i> argument passed to dvn</item>
    ///         <item>Cannot contain a space</item>
    ///         <item><b>Cannot start</b> with the "<c>-</c>" character (e.g., "<c>dvn install</c>")</item>
    ///     </list>
    /// </remarks>
    internal string Command { get; set; }

    /// <summary>
    /// Gets or sets the list of valid commands that can be processed.
    /// </summary>
    internal List<string> ValidCommands { get; set; }

    /// <summary>The dvn <c>request</c>.</summary>
    /// <remarks>
    ///    There can only be one request.<br/>
    ///     <br/>
    ///    That request:
    ///     <list type="bullet">
    ///         <item>Should be the <i>second</i> argument passed to dvn</item>
    ///         <item>Cannot contain a space</item>
    ///         <item><b>Cannot start</b> with the "<c>-</c>" character (e.g., "<c>dvn install ahk</c>")</item>
    ///     </list>
    /// </remarks>
    internal string Request { get; set; }

    /// <summary>
    /// Gets or sets the list of valid requests that can be processed.
    /// </summary>
    internal List<string> ValidRequests { get; set; }


    /// <summary>The dvn <c>options</c>.</summary>
    /// <remarks>
    ///     There can be any number of options, only those that are valid will be processed.<br/>
    ///     <br/>
    ///     Options:
    ///     <list type="bullet">
    ///         <item>Should <i>follow</i> the <c>command</c> and/or <c>request</c></item>
    ///         <item>Must be separated by a space</item>
    ///         <item><b>Must start</b> with the "<c>-</c>" character (e.g., "<c>dvn install ahk -b</c>", "<c>dvn install ahk --backup</c>")</item>
    ///     </list>
    /// </remarks>
    internal List<string> Options { get; set; }

    /// <summary>
    /// Gets or sets the list of valid options that can be processed.
    /// </summary>
    internal List<string> ValidOptions { get; set; }

    /// <summary>Determines whether any arguments were passed via the command-line.</summary>
    /// <param name="passedArguments">The arguments, if any, that were passed via the command-line.</param>
    /// <returns><see langword="true"/> if one or more arguments were provided; otherwise, <see langword="false"/>.</returns>
    internal static bool DoExist(string[] passedArguments) =>
        passedArguments != null && passedArguments.Length != 0;

    /// <summary>Parses the specified command-line arguments into a <see cref="CommandLine"/> object.</summary>
    /// <param name="passedArguments">The arguments passed via the command-line.</param>
    /// <returns>A <see cref="CommandLine"/> object containing the parsed command and, potentially, options.</returns>
    internal static Argument GetComponents(string[] passedArguments)
    {
        Argument arguments = new Argument();

        /* If the first argument starts with a dash, then only options were passed.
          *  For example: "$ dvn --help"
          */
        if (passedArguments[0].StartsWith('-'))
        {
            arguments = new Argument()
            {
                Command = "no-command-passed",
                Request = "no-request-passed",
                Options = [.. passedArguments[1..].Select(arg => arg.ToLower().Trim())]
            };
        }
        else
        {
            /* If only one argument was passed, then it is a command.
               *  For example: "$ dvn install"
               */
            if (passedArguments.Length == 1)
            {
                arguments = new Argument()
                {
                    Command = passedArguments[0].ToLower().Trim(),
                    Request = "no-request-passed",
                    Options = []
                };
            }
            else if (passedArguments.Length == 2)
            {
                /* If two arguments were passed, then the first is a command and the second is either a request or an option.
                   *  For example: "$ dvn install ahk" OR "$ dvn install --backup"
                  */
                var cmd = passedArguments[0].ToLower().Trim();

                if (passedArguments[1].StartsWith('-'))
                {
                    // If the second argument starts with a dash, then it is an option, and the request is not passed.
                    arguments = new Argument()
                    {
                        Command = cmd,
                        Request = "no-request-passed",
                        Options = [.. passedArguments[1..].Select(arg => arg.ToLower().Trim())]
                    };
                }
                else
                {
                    // The second argument is a request.
                    arguments = new Argument()
                    {
                        Command = cmd,
                        Request = passedArguments[1].ToLower().Trim(),
                        Options = []
                    };
                }
            }
            else if (passedArguments.Length > 2)
            {
                /* If more than two arguments were passed, then the first is a command, the second is a request, and the rest are options.
                   *  For example: "$ dvn install ahk --backup --full"
                   */
                var cmd = passedArguments[0].ToLower().Trim();
                var req = passedArguments[1].ToLower().Trim();
                // The rest are options.
                arguments = new Argument()
                {
                    Command = cmd,
                    Request = req,
                    Options = [.. passedArguments[2..].Select(arg => arg.ToLower().Trim())]
                };
            }
        }
        return arguments;
    }

    /// <summary>Parses the command component of the arguments passed via the command-line.</summary>
    /// <remarks>
    ///     Entering a command that does not match any of the case statements will either:
    ///     <list type="bullet">
    ///         <item>Start the <c>&lt;command&gt;</c> environment, if a <c>&lt;command&gt;.dvn.manifest</c> file exists.</item>
    ///         <item>If a <c>&lt;command&gt;.dvn.manifest</c> does not exist, create a new file with default values.</item>
    ///     </list>
    /// </remarks>
    /// <param name="dvnSession">The <see cref="Core.Session"/> instance.</param>
    internal static void ParseCommand(Session dvnSession)
    {
        var command = dvnSession.Arguments.Command;

        if (string.IsNullOrEmpty(command))
        {
            //Stop(UserMessage.usrmsg_MissingCommand);
            //return;
        }
        else if (command == "help")
        {
            //HelpInformer.Parse(dvnSession);
            return;
        }
        else if (command == "about")
        {
            Console.WriteLine(UserMessage.usrmsg_About);
            return;
        }
        else if (command == "install")
        {
            Console.WriteLine(UserMessage.usrmsg_Help);
            return;
        }
        else if (command == "list")
        {
            //Lister.Parse(dvnSession);
            //DvnEnvironment.DisplayAvailable(dvnSession.AvailableEnvironments);
            return;
        }
    }
}