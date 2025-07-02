/* dvnlib.Parse.cs
 * u250630_code
 * u250630_documentation
 */

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
                    Env.New(session.Action);
                    break;
                }
                case "help":
                {
                    Console.WriteLine(UserMessage.DevnHelp);
                    break;
                }
                case "list":
                {
                    Env.ListAvailable();
                    break;
                }
                default:
                {
                    Env.Launch(session);
                    break;
                }
            }
        }
    }
}
