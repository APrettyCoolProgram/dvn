/* dvnlib.Argument.cs
 * u250717_code
 * u250717_documentation
 */

namespace dvnlib
{
    /// <summary>Argument logic.</summary>
    /// <remarks>
    ///     dvn <c>Arguments</c> tell dvn <i>what</i> to do, and (optionally) <i>how</i> to do it.<br/>
    ///     <br/>
    ///     Arguments are comprised of a single <see cref="Command">command</see> (the <i>what</i>), and <see cref="Options">option(s)</see> (the <i>how</i>).
    /// </remarks>
    internal class Arguments
    {
        /// <summary>The dvn command.</summary>
        /// <remarks>There can only be one command, and it's always the first argument.<br/></remarks>
        internal string Command { get; set; }

        /// <summary>The dvn arguments.</summary>
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

        /// <summary>Get the dvn <see cref="Command">command</see> and <see cref="Options">option(s)</see>.</summary>
        /// <param name="args">The dvn arguments.</param>
        /// <returns>An <see cref="Arguments"/> instance.</returns>
        internal static Arguments GetArguments (string[] args) => new Arguments()
        {
            Command = args[0].ToLower().Trim(),
            Options = args.Length < 2
                          ? []
                          : [.. args[1..].Select(arg => arg.ToLower().Trim())]
        };
    }
}