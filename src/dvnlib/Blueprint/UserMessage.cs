/* dvnlib.Blueprint.UserMessage.cs
 * u250710_code
 * u250710_documentation
 */

namespace dvnlib.Blueprint
{
    internal class UserMessage
    {
        internal static string StartDvn =>
           Environment.NewLine +
           $"========={Environment.NewLine}" +
           $"   dvn{Environment.NewLine}" +
           $"=========";

        public static string MissingArgument =>
            $"{UserMessage.StartDvn}{Environment.NewLine}" +
            Environment.NewLine +
            $"  ERROR - No argument passed!{Environment.NewLine}" +
            Environment.NewLine +
            "  Type \"dvn help\" for additional information." +
            Environment.NewLine;

        public static string MsgDvnHelp =>
            Environment.NewLine +
            $"  Usage: dvn <command> [-options]{Environment.NewLine}" +
            Environment.NewLine +
            $"  Commands:{Environment.NewLine}" +
            Environment.NewLine +
            $"    %environment-name%       Launch the <environment-name> development environment,{Environment.NewLine}" +
            $"                             or create a new template if it does not exist.{Environment.NewLine}" +
            $"    info                     Display information about dvn{Environment.NewLine}" +
            $"    help                     Display the dvn help screen{Environment.NewLine}" +
            $"    list                     Display the available development environments{Environment.NewLine}" +
            Environment.NewLine +
            $"  Options:{Environment.NewLine}" +
            Environment.NewLine +
            $"    -b   Force backups{Environment.NewLine}" +
            Environment.NewLine +
            "  For more information: https://github.com/APrettyCoolProgram/dvn" +
            Environment.NewLine;

        public static string DvnInfo(string dvnVer) =>
            Environment.NewLine +
            $"  dvn: A command lint utility for managing development environments{Environment.NewLine}" +
            $"  Version {dvnVer}{Environment.NewLine}" +
            $"  Developed by A Pretty Cool Program (https://github.com/APrettyCoolProgram){Environment.NewLine}" +
            $"  https://github.com/APrettyCoolProgram/dvn{Environment.NewLine}" +
            $"  Licensed under Apache 2.0{Environment.NewLine}";

        public static string CreateManifestTemplate(string name) =>
            Environment.NewLine +
            $"  A template for \"{name}\" did not exist, so it was created.{Environment.NewLine}" +
            Environment.NewLine +
            $"  You will need to edit the \"{name}.dvn\" template manually.{Environment.NewLine}" +
            Environment.NewLine +
            $"  For more information, please refer to the dvn documentation.";
        

        public static string AvailableEnvironmentsList(string envs) =>
            Environment.NewLine +
            $"  Available environments:{Environment.NewLine}"+
            Environment.NewLine +
            $"  {envs}";

        public static string ExitDvn(string message = "") =>
            $"{message}{Environment.NewLine}" +
            "  Exiting dvn..." +
            Environment.NewLine;
    }
}