/* dvnlib.Blueprint.UserMessage.cs
 * u250712_code
 * u250719_documentation
 */

namespace dvnlib.Blueprint
{
    /// <summary>
    /// 
    /// </summary>
    internal class UserMessage
    {
        internal static string InitializeDvn =>
            """
            =========
              dvn
            =========

            """;

        public static string FirstRun =>
            $"""
            The dvn framework does not exist, and will be created.
            """;

        public static string MissingArgument =>
            $"""
              ERROR: No argument passed.
              {ExitDvn()}"
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

        public static string Info(string exeAsmVersion) =>
            $"""
              dvn: A command lint utility for managing development environments
              Version {exeAsmVersion}
              Developed by A Pretty Cool Program (https://github.com/APrettyCoolProgram)
              https://github.com/APrettyCoolProgram/dvn
              Licensed under Apache 2.0
              {ExitDvn()}
            """;

        public static string CreateManifest(string environmentName) =>
            $"""
              A template for \"{environmentName}\" did not exist, so it was created.
            
              You will need to edit the \"{environmentName}.manifest\" file manually.

              For more information, please refer to the dvn documentation.
              {ExitDvn()}
             """;

        public static string EnvList(string environmentList) =>
            $"""
            Available environments:

                {environmentList}
            {ExitDvn()}
            """;

        public static string ExitDvn(string exitMessage = "") =>
            $"""
              {exitMessage}
              
              Exiting dvn...
            """;
    }
}