/* dvnlib.Parse.cs
 * u250716_code
 * u250716_documentation
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
                    Console.WriteLine(UserMessage.Info(session.Ver));
                    break;

                case "list":
                    DvnEnvironment.ListEnvs(session.Asm, session.Framework.Manifests);
                    break;

                default:
                    DvnEnvironment.Load(session);
                    break;
            }
        }
    }
}