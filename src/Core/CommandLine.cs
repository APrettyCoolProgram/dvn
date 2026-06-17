// 250801_code
// 260617_documentation

namespace dvn.Core;

/// <summary>Represents parsed <c>dvn</c> command-line input.</summary>
/// <remarks>
/// The <c>dvn</c> syntax is: <c>dvn &lt;command&gt; [-option01 -option02 ...]</c><br/>
/// <br/>
/// Example: <c>dvn %myEnvironment% -b</c>
/// </remarks>
internal class CommandLine
{
    /// <summary>The <c>dvn</c> command.</summary>
    /// <remarks>There can only be one command, and it is always the first argument.</remarks>
    /// <value>The command portion of the input.</value>
    internal string Command { get; set; }

    /// <summary>The <c>dvn</c> options.</summary>
    /// <remarks>
    /// There can be any number of options, but only valid options are processed.<br/>
    /// <br/>
    /// Options must:
    /// <list type="bullet">
    /// <item>Be a single character</item>
    /// <item>Start with the <c>-</c> character</item>
    /// <item>Be separated by a space</item>
    /// </list>
    /// </remarks>
    /// <value>The parsed options.</value>
    internal List<string> Options { get; set; }

    /// <summary>Parses the specified command-line arguments into a <see cref="CommandLine"/> object.</summary>
    /// <param name="passedArguments">The arguments passed via the command line.</param>
    /// <returns>A <see cref="CommandLine"/> object containing the parsed command and, potentially, options.</returns>
    internal static CommandLine GetComponents(string[] passedArguments) =>
        new CommandLine()
        {
            Command = passedArguments[0].ToLower().Trim(),
            Options = passedArguments.Length < 2
                      ? []
                      : [.. passedArguments[1..].Select(arg => arg.ToLower().Trim())]
        };
}