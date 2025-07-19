/* dvn.Blueprint.UserMessage.cs
 * u250719_code
 * u250719_documentation
 */

namespace dvn.Blueprint
{
    /// <summary>Provides predefined user messages. </summary>
    internal class UserMessage
    {
        internal static string StartDvn =>
            """
            =========
              dvn
            =========

            """;

        internal static string MissingArguments =>
            $"""
              ERROR: Missing arguments.
              {ExitDvn()}"
            """;

        internal static string ExitDvn(string exitMessage = "") =>
            $"""
              {exitMessage}
              
              Exiting dvn...
            """;
    }
}
