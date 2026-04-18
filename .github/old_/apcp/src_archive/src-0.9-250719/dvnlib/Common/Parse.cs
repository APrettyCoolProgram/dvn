/* dvnlib.Parse.cs
 * u250719_code
 * u250719_documentation
 */

using dvnlib.Blueprint;

namespace dvnlib
{
    /// <summary>Parses the <see cref="Argument.Argument"/> components.</summary>
    internal class Parse
    {
        /// <summary>Parses the <see cref="Argument.Command"/> component.</summary>
        /// <param name="session">The current dvn <see cref="Session.Session"/> instance.</param>
        internal static void Action(Session session)
        {
            switch (session.Argument.Command)
            {
                case "help":
                    Console.WriteLine(UserMessage.Help);
                    break;

                case "info":
                    Console.WriteLine(UserMessage.Info(session.DvnApp.ExeAsmVersion));
                    break;

                case "list":
                    DvnEnvironment.DisplayAvailable(session.DvnApp.ExeAsmName, session.EnvironmentList);
                    break;

                default:
                    DvnEnvironment.Load(session);
                    break;
            }
        }
    }
}