/* dvnlib.Parse.cs
 * u250715_code
 * u250715_documentation
 */

using dvnlib.Blueprint;

namespace dvnlib
{
    /// <summary>Parses the <see cref="Argument.Argument"/> components.</summary>
    internal class Parse
    {
        /// <summary>Parses the <see cref="Argument.Command"/> component.</summary>
        /// <remarks>
        ///     Current valid actions are:
        ///     <list type="bullet">
        ///         <item>new           - Create a new dvn environment file.</item>
        ///         <item>help          - Display the help message.</item>
        ///         <item>info          - Information about dvn</item>
        ///         <item>list          - List all available development environments.</item>
        ///         <item>%environment% - Launch the specified dvn environment.</item>
        ///     </list>
        /// </remarks>
        /// <param name="session">The current dvn <see cref="Session.Session"/> instance.</param>
        internal static void Action(Session session)
        {
            switch (session.Argument.Command)
            {
                case "new":
                    Profile.Manifest.CreateNew(session.ExeAsm, session.Framework.DvnManifestPath, session.Argument.Option[0]);
                    break;

                case "help":
                    Console.WriteLine(UserMessage.MsgDvnHelp);
                    break;

                case "info":
                    Console.WriteLine(UserMessage.DvnInfo(session.DvnVer));
                    break;

                case "list":
                    DvnEnvironment.ListAvailable(session.ExeAsm, session.Framework.DvnManifestPath);
                    break;

                default:
                    DvnEnvironment.Load(session);
                    break;
            }
        }
    }
}