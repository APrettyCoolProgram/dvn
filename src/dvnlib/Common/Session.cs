/* dvnlib.Session.cs
 * u250716_code
 * u250716_documentation
 */

using dvnlib.Blueprint;
using dvnlib.Common;

namespace dvnlib
{
    /// <summary> Session logic for devn.</summary>
    public class Session
    {
        public string Ver { get; set; }

        /// <summary>The executing assembly.</summary>
        /// <remarks>
        ///     dvnlib is designed to be used as a library by both console and GUI applications.<br/>
        ///     The <see cref="Asm"/> property determines if the session is running in a console<br/>
        ///     application (e.g., dvn) or a GUI application (e.g., dvngui).<br/>
        /// </remarks>
        public string Asm { get; set; }

        /// <summary>The dvn <see cref="Argument.Argument"/> components.</summary>
        internal Argument Argument { get; set; }

        /// <summary>The dvn <see cref="Framework.Framework"/> components.</summary>
        internal Framework Framework { get; set; }

        /// <summary>Starts a new dvn session.</summary>
        /// <param name="asm">The <see cref="Asm">executing assembly</see>.</param>
        /// <param name="ver">The current version of dvn.</param>
        /// <param name="args">Command-line arguments.</param>
        public static void Start(string asm, string ver, string[] args)
        {
            Console.Clear();
            UserDisplay.Message(asm, UserMessage.StartDvn);

            if (args == null || args.Length == 0)
            {
                Stop(asm, UserMessage.MissingArgument);
            }
            else
            {
                Session session = New(ver, asm, args);
                Framework.Validate(session.Framework);
                Parse.Action(session);
            }
        }

        /// <summary>Creates a new <see cref="Session"/> instance.</summary>
        /// <param name="exeAsmName">The <see cref="Asm">executing assembly</see>.</param>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>A new <see cref="Session"/> instance.</returns>
        public static Session New(string dvnVersion, string exeAsmName, string[] args)
        {
            return new Session
            {
                Ver       = dvnVersion,
                Asm       = exeAsmName,
                Argument  = Argument.Get(args),
                Framework = Framework.CreateNew()
            };
        }

        /// <summary>Terminates the current dvn session.</summary>
        /// <param name="asm">The <see cref="Asm">executing assembly</see>.</param>
        /// <param name="msg">The message to display to the user.</param>
        public static void Stop(string asm, string msg = "")
        {
            UserDisplay.Message(asm, UserMessage.ExitDvn(msg));
            Environment.Exit(0);
        }
    }
}