/* dvnlib.Session.cs
 * u250710_code
 * u250710_documentation
 */

using dvnlib.Blueprint;
using dvnlib.Common;

namespace dvnlib
{
    /// <summary> Session logic for devn.</summary>
    public class Session
    {
        public string DvnVer { get; set; }

        /// <summary>The executing assembly.</summary>
        /// <remarks>
        ///     dvnlib is designed to be used as a library by both console and GUI applications.<br/>
        ///     The <see cref="ExeAsm"/> property determines if the session is running in a console<br/>
        ///     application (e.g., dvn) or a GUI application (e.g., dvngui).<br/>
        /// </remarks>
        public string ExeAsm { get; set; }

        /// <summary>The dvn <see cref="Argument.Argument"/> components.</summary>
        internal Argument Argument { get; set; }

        /// <summary>The dvn <see cref="Framework.Framework"/> components.</summary>
        internal Framework Framework { get; set; }

        /// <summary>Creates a new <see cref="Session"/> instance.</summary>
        /// <param name="exeAsm">The <see cref="ExeAsm">executing assembly</see>.</param>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>A new <see cref="Session"/> instance.</returns>
        public static Session CreateNew(string dvnVer, string exeAsm, string[] args)
        {
            return new Session
            {
                DvnVer    = dvnVer,
                ExeAsm    = exeAsm,
                Argument  = Argument.Get(args),
                Framework = Framework.CreateNew()
            };
        }

        /// <summary>Starts a new dvn session.</summary>
        /// <param name="exeAsm">The <see cref="ExeAsm">executing assembly</see>.</param>
        /// <param name="dvnVer">The current version of dvn.</param>
        /// <param name="args">Command-line arguments.</param>
        public static void Start(string exeAsm, string dvnVer, string[] args)
        {
            UserDisplay.Message(exeAsm, UserMessage.StartDvn);

            Session session = CreateNew(dvnVer, exeAsm,  args);

            Framework.Validate(session.Framework);

            Parse.Action(session);
        }

        /// <summary>Terminates the current dvn session.</summary>
        /// <param name="exeAsm">The <see cref="ExeAsm">executing assembly</see>.</param>
        /// <param name="message">The message to display to the user.</param>
        public static void Stop(string exeAsm, string message = "")
        {
            UserDisplay.Message(exeAsm, UserMessage.ExitDvn(message));

            Environment.Exit(0);
        }
    }
}