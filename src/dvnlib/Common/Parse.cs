using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dvnlib.Blueprint;

namespace dvnlib
{
    internal class Parse
    {
        internal static string GetCommand(string[] args) =>
            args[0].ToLower().Trim();

        internal static string GetAction(string[] args) =>
            args.Length > 1
            ? args[1].ToLower().Trim()
            : string.Empty;

        internal static string GetOption(string[] args) =>
            args.Length > 2
            ? args[2].ToLower().Trim()
            : string.Empty;

        internal static void Command(Session session)
        {
            switch (session.Command)
            {
                case "new":
                {
                    DevnEnv.New(session.Action);
                    break;
                }
                case "help":
                {
                    Console.WriteLine(UserMessage.DevnHelp);
                    break;
                }
                case "list":
                {
                    DevnEnv.ListAvailable();
                    break;
                }
                default:
                {
                    DevnEnv.Launch(session);
                    break;
                }
            }
        }
    }
}
