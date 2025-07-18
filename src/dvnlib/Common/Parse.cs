/* dvnlib.Parse.cs
 * u250718_code
 * u250718_documentation
 */

using dvnlib.Blueprint;

namespace dvnlib
{
    /// <summary>Parses the <see cref="Arguments.Arguments"/> components.</summary>
    internal class Parse
    {
        /// <summary>Parses the <see cref="Arguments.Command"/> component.</summary>
        /// <param name="session">The current dvn <see cref="Session.Session"/> instance.</param>
        internal static void Action(Session session)
        {
            switch (session.Arguments.Command)
            {
                case "help":
                    Console.WriteLine(UserMessage.Help);
                    break;

                case "info":
                    Console.WriteLine(UserMessage.Info(session.DvnApps.ExeAsmVersion));
                    break;

                case "list":
                    DvnEnvironment.DisplayEnvironments(session.DvnApps.ExeAsmName, session.EnvironmentDetails);
                    break;

                default:
                    DvnEnvironment.Load(session);
                    break;
            }
        }
    }
}