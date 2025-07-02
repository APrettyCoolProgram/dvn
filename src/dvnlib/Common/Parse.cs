/* dvnlib.Parse.cs
 * u250630_code
 * u250630_documentation
 */

using dvnlib.Blueprint;

namespace dvnlib
{
    internal class Parse
    {

        internal static void Command(Session session)
        {
            switch (session.Request)
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
