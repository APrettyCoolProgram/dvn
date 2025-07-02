using dvnlib.Blueprint;
using dvnlib.Common;

namespace dvnlib
{
    public class Session
    {
        public string Command { get; set; }
        public string Action { get; set; }
        public string Option { get; set; }
        public string AvailableEnvs { get; set; }
        public Framework Framework { get; set; }

        /// <summary>Start a new devn session.</summary>
        /// <param name="devnVer">The current version of devn.</param>
        /// <param name="args">The command line arguments that were passed at execution.</param>
        internal static void Start(string devnVer, string[] args)
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
                Command       = Parse.GetCommand(args),
                Action        = Parse.GetAction(args),
                Option        = Parse.GetOption(args),
                Framework     = Framework.New(),
                AvailableEnvs = DevnEnv.GetAvailable()
            };

            Framework.Validate(session.Framework.Paths);

            Parse.Command(session);
        }
    }
}
