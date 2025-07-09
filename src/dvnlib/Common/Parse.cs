/* dvnlib.Parse.cs
 * u250707_code
 * u250707_documentation
 */

using dvnlib.Blueprint;

namespace dvnlib
{
    /// <summary>Parses the <see cref="Command.Command"/> components.</summary>
    internal class Parse
    {
        /// <summary>Parses the <see cref="Command.Request"/> component.</summary>
        /// <remarks>
        ///     Current valid actions are:
        ///     <list type="bullet">
        ///         <item>new - Create a new dvn environment file.</item>
        ///         <item>help - Display the help message.</item>
        ///         <item>list - List all available development environments.</item>
        ///         <item>%environment% - Launch the specified dvn environment.</item>
        ///     </list>
        /// </remarks>
        /// <param name="session">The current dvn <see cref="Session.Session"/> instance.</param>
        internal static void Action(Session session)
        {
            switch (session.Command.Request)
            {
                case "new":
                {
                    DvnEnvironment.CreateNew(session.ExeAsm, session.Command.Option[0]);
                    break;
                }
                case "help":
                {
                    Console.WriteLine(UserMessage.MsgDvnHelp);
                    break;
                }
                case "list":
                {
                    DvnEnvironment.ListAvailable(session.ExeAsm, session.Framework.Path["Data"]);
                    break;
                }
                default:
                {
                    DvnEnvironment.Launch(session);
                    break;
                }
            }
        }
    }
}