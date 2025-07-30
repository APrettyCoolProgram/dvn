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
}