/* dvnlib.Blueprint.UserMessage.cs
 * u250707_code
 * u250707_documentation
 */

namespace dvnlib.Blueprint
{
    public class UserMessage
    {
        public static string bpm_StartDvn() =>
           Environment.NewLine +
           $"======={Environment.NewLine}" +
           $"  dvn{Environment.NewLine}" +
           $"=======";

        public static string bpm_MissingArgument(string dvnVer) =>
            bpm_StartDvn() +
            Environment.NewLine +
            Environment.NewLine +
            "ERROR - No argument passed!" +
            Environment.NewLine +
            MsgDvnHelp +
            Environment.NewLine;

        public static string bpm_DvnInfo(string dvnVer) =>
            $"Dvn version: {dvnVer}";

        public static string MsgDvnHelp =>
            Environment.NewLine +
            $"Usage:{Environment.NewLine}" +
            Environment.NewLine +
            $"   dvn request [options]{Environment.NewLine}" +
            Environment.NewLine +
            $"Examples:{Environment.NewLine}" +
            Environment.NewLine +
            $"  dvn list        List all available development environments{Environment.NewLine}" +
            $"  dvn new myenv   Create a \"myenv.dvn\" file{Environment.NewLine}" +
            $"  dvn myenv       Load the \"myenv\" environment{Environment.NewLine}" +
            $"  dvn myenv -c    Load the \"myenv\" environment, and force compression{Environment.NewLine}" +
            $"  dvn help        Show this help message{Environment.NewLine}" +

            Environment.NewLine +
            "For more information: https://github.com/APrettyCoolProgram/dvn" +
            Environment.NewLine;

        public static string bpm_EnvTemplate(string status)
        {
            return status switch
            {
                "create" => $"Creating default environment template...",
                "created" => $"Default environment template created.",
                _ => $"[ERROR] Unknown error creating default environment template ({status})."
            };
        }

        public static string bpm_DevEnvListHeader(string envs)
        {
            return Environment.NewLine +
                   $"Available environments:{Environment.NewLine}"+
                   Environment.NewLine +
                   $"{envs}";
        }

        public static string bpm_ExitDvn(string message = "")
        {
            return $"{message}{Environment.NewLine}" +
                   Environment.NewLine +
                   "Exiting dvn..." +
                   Environment.NewLine;
        }
    }
}
