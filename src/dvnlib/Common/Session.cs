/* dvnlib.Session.cs
 * u250630_code
 * u250630_documentation
 */

using dvnlib.Blueprint;
using dvnlib.Common;

namespace dvnlib
{
    /// <summary> Session logic for devn.</summary>
    public class Session
    {
        /// <summary>The first command line argument.</summary>
        /// <remarks>
        ///     The <c>request</c> argument tells dvn what to do.
        /// </remarks>
        public string Request { get; set; }

        /// <summary>The second command line argument.</summary>
        /// <remarks>
        /// </remarks>
        public string Action { get; set; }

        /// <summary>The third command line argument.</summary>
        /// <remarks>
        /// </remarks>
        public string Option { get; set; }


        //public string AvailableEnvs { get; set; }


        internal Framework Framework { get; set; }

        /// <summary>Start a new devn session.</summary>
        /// <param name="devnVer">The current version of devn.</param>
        /// <param name="args">The command line arguments that were passed at execution.</param>
        public static void Start(string devnVer, string[] args)
        {
            Console.WriteLine(UserMessage.DevnStart(devnVer));

            if (args == null || args.Length == 0)
            {
                Stop(UserMessage.MissingArgument);
            }
            else
            {
                Proceed(args);
            }
        }

        /// <summary>Stop the devn session and exit the application.</summary>
        /// <param name="message">The message to be displayed when devn stops.</param>
        internal static void Stop(string message = "")
        {
            Console.WriteLine(UserMessage.ExitMsg(message));

            Environment.Exit(0);
        }

        /// <summary>Proceed with the devn session.</summary>
        internal static void Proceed(string[] args)
        {
            Session session = new Session
            {
                Request       = Parse.GetCommand(args),
                Action        = Parse.GetAction(args),
                Option        = Parse.GetOption(args),
                Framework     = Framework.New()
            };

            Framework.Validate(session.Framework.Paths);

            //session.AvailableEnvs = Env.GetAvailable();

            Parse.Command(session);
        }
    }
}
