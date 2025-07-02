using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvnlib.Blueprint
{
    internal class UserMessage
    {
        public static string DevnStart(string devnVer) =>
           Environment.NewLine +
           $"================={Environment.NewLine}" +
           $"  devn v{devnVer}{Environment.NewLine}" +
           $"================={Environment.NewLine}";

        public static string MissingArgument =>
            "No argument passed." +
            DevnHelp +
            Environment.NewLine;

        public static string DevnInfo(string devnVer) =>
            $"Devn version: {devnVer}";

        public static string DevnHelp =>
            $"Usage: devn [command]{Environment.NewLine}" +
            Environment.NewLine +
            $"Commands:{Environment.NewLine}" +
            $"  <template-name>      Name of the template to load{Environment.NewLine}" +
            $"  help                 Show this help message{Environment.NewLine}" +
            $"  list                 List all available development environments{Environment.NewLine}" +
            $"  new                  Create a default environment template file{Environment.NewLine}" +
            Environment.NewLine +
            $"Example:{Environment.NewLine}" +
            $"  ~$ devn myenv           Load the development environment named 'myenv'{Environment.NewLine}";

        public static string EnvTemplate(string status)
        {
            return status switch
            {
                "create" => $"Creating default environment template...",
                "created" => $"Default environment template created.",
                _ => $"[ERROR] Unknown error creating default environment template ({status})."
            };
        }

        public static string DevEnvListHeader(string envs)
        {
            return $"Available environments:{Environment.NewLine}"+
            Environment.NewLine +
            $"{envs}";
        }

        public static string ExitMsg(string message = "")
        {
            return $"{message}{Environment.NewLine}" +
                   Environment.NewLine +
                   "Exiting devn..." +
                   Environment.NewLine;
        }
    }
}
