/* dvnlib.Argument.cs
 * u250716_code
 * u250716_documentation
 */

namespace dvnlib
{
    /// <summary>Logic for dvn arguments.</summary>
    internal class Argument
    {
        /// <summary>The dvn command.</summary>
        internal string Command { get; set; }

        /// <summary>The dvn arguments.</summary>
        internal List<string> Option { get; set; }

        /// <summary>Get the dvn command and options.</summary>
        /// <param name="args">The dvn arguments.</param>
        /// <returns>An <see cref="Argument"/> instance.</returns>
        internal static Argument Get (string[] args) => new Argument()
        {
            Command = args[0].ToLower().Trim(),
            Option  = args.Length < 2
                          ? []
                          : [.. args[1..].Select(arg => arg.ToLower().Trim())]
        };
    }
}