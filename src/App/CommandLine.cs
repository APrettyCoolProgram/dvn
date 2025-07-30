/* dvn.App.CommandLine.cs
 * u250730_code
 * u250730_documentation
 */

namespace dvn.App;

/// <summary>Logic for command-line stuff.</summary> /// <remarks>
///     The dvn syntax is: <c>dvn &lt;command&gt; [-option01 -option02 ...]</c><br/>
///     <br/>
///     Example: <c>dvn %myEnvironment% -b</c><br/>
/// </remarks>
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

    /// <summary>Parses the specified command-line arguments into a <see cref="CommandLine"/> object.</summary>
    /// <param name="passedArguments">The arguments passed via the command-line.</param>
    /// <returns>A <see cref="CommandLine"/> object containing the parsed command, and potentially, options.</returns>
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