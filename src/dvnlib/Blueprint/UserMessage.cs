/* dvnlib.Blueprint.UserMessage.cs
 * u250712_code
 * u250716_documentation
 */

namespace dvnlib.Blueprint
{
    internal class UserMessage
    {
        internal static string StartDvn =>
           $"{Environment.NewLine}========={Environment.NewLine}   dvn{Environment.NewLine}=========";

        public static string MissingArgument =>
            $"{Environment.NewLine}  ERROR: No argument passed.{Environment.NewLine}";

        public static string Help =>
            $"{Environment.NewLine}  Usage: dvn <command> [-options]{Environment.NewLine}" +
            $"{Environment.NewLine}  Commands:{Environment.NewLine}" +
            $"{Environment.NewLine}    %manifest%   Start/create a development environment manifest" +
            $"{Environment.NewLine}    info         Display information about dvn" +
            $"{Environment.NewLine}    help         Display the dvn help screen" +
            $"{Environment.NewLine}    list         Display the available development environments{Environment.NewLine}" +
            $"{Environment.NewLine}  Options:{Environment.NewLine}" +
            $"{Environment.NewLine}    -b           Force backups{Environment.NewLine}" +
            $"{Environment.NewLine}  For more information: https://github.com/APrettyCoolProgram/dvn"+
            $"{Environment.NewLine}{ExitDvn()}";

        public static string Info(string ver) =>
            $"{Environment.NewLine}  dvn: A command lint utility for managing development environments" +
            $"{Environment.NewLine}  Version {ver}" +
            $"{Environment.NewLine}  Developed by A Pretty Cool Program (https://github.com/APrettyCoolProgram)" +
            $"{Environment.NewLine}  https://github.com/APrettyCoolProgram/dvn" +
            $"{Environment.NewLine}  Licensed under Apache 2.0" +
            $"{Environment.NewLine}{ExitDvn()}";

        public static string CreateManifest(string env) =>
            $"{Environment.NewLine}  A template for \"{env}\" did not exist, so it was created.{Environment.NewLine}" +
            $"{Environment.NewLine}  You will need to edit the \"{env}.dvn\" template manually.{Environment.NewLine}" +
            $"{Environment.NewLine}  For more information, please refer to the dvn documentation." +
            $"{Environment.NewLine}{ExitDvn()}";

        public static string EnvList(string envs) =>
            $"{Environment.NewLine}  Available environments:{Environment.NewLine}" +
            $"{Environment.NewLine}{envs}" +
            $"{ExitDvn()}";

        public static string ExitDvn(string msg = "") =>
            $"{msg}{Environment.NewLine}  Exiting dvn...{Environment.NewLine}";
    }
}