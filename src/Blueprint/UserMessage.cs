/* dvn.Blueprint.UserMessage.cs
 * u250722_code
 * u250722_documentation
 */

using System.Reflection;

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

        public static string CreateManifest(string environmentName) =>
            $"""
               A "{environmentName}.manifest" did not exist, so it was created.

               You will need to edit the "{environmentName}.manifest" file manually.

               For more information, please refer to the dvn documentation.
             """;

        public static string Help =>
            $"""
              Usage: dvn <command> [-options]

              Commands:

                %manifest%   Start/create a development environment manifest" +
                info         Display information about dvn" +
                help         Display the dvn help screen" +
                list         Display the available development environments

              Options:

                -b           Force backups

              For more information: https://github.com/APrettyCoolProgram/dvn"+
              {ExitDvn()}"
            """;

        public static string Info() =>
            $"""
              dvn: A command lint utility for managing development environments
              Version {Assembly.GetExecutingAssembly().GetName().Version.ToString()}
              Developed by A Pretty Cool Program (https://github.com/APrettyCoolProgram)
              https://github.com/APrettyCoolProgram/dvn
              Licensed under Apache 2.0
              {ExitDvn()}
            """;

        public static string EnvList(string environmentList) =>
            $"""
            Available environments:

                {environmentList}
            {ExitDvn()}
            """;
    }
}
