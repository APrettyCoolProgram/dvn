/* dvn.App.CommandLine.cs
 * u250730_code
 * u250730_documentation
 */

namespace dvn.App;

/// <summary>Logic for arguments that are passed to dvn at execution via the command-line.</summary>
internal class CommandLine
{
    /// <summary>The dvn <c>command</c>.</summary>
    /// <remarks>There can only be one command, and it's always the first argument.<br/></remarks>
    internal required string Command { get; set; }

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
    internal required List<string> Options { get; set; }

    /// <summary>
    /// Parses the specified command-line arguments into a <see cref="CommandLine"/> object.
    /// </summary>
    /// <param name="passedArguments">An array of strings representing the command-line arguments. The first element is expected to be the command,
    /// and any subsequent elements are treated as options.</param>
    /// <returns>A <see cref="CommandLine"/> object containing the parsed command and options. The command is the first argument
    /// converted to lowercase and trimmed. Options are any additional arguments, also converted to lowercase and
    /// trimmed. If no options are provided, the options list will be empty.</returns>
    internal static CommandLine GetComponents(string[] passedArguments)
    {
        return new CommandLine()
        {
            Command = passedArguments[0].ToLower().Trim(),
            Options = passedArguments.Length < 2
                      ? []
                      : [.. passedArguments[1..].Select(arg => arg.ToLower().Trim())]
        };
    }
}