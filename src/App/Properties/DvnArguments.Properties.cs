/* dvn.App.DvnArgument.cs
 * u250719_code
 * u250719_documentation
 */

namespace dvn.App
{
    internal partial class DvnArguments
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
    }
}
