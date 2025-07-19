/* dvnlib.Session.cs
 * u250719_code
 * u250719_documentation
 */

/* Properties for this class be found in Session.Properties.cs.
 */

using dvnlib.Blueprint;
using dvnlib.Common;
using dvnlib.Framework;

namespace dvnlib
{

    public partial class Session
    {


        /// <summary>Continue the dvn session.</summary>
        /// <param name="exeAsmName">The <see cref="ExeAsmName">executing assembly name</see>.</param>
        /// <param name="exeAsmVersion">The <see cref="ExeAsmVersion">executing assembly version</see>.</param>
        /// <param name="dvnArguments">The dvn <see cref="Argument.Argument">arguments</see>.</param>
        internal static void Run(string exeAsmName, string exeAsmVersion, string[] dvnArguments)
        {
            Session session = new Session();

            InitializeSession(exeAsmName, exeAsmVersion, dvnArguments, session);

            Parse.Action(session);
        }

        /// <summary>Initialize the session instance.</summary>
        /// <param name="exeAsmName">The <see cref="ExeAsmName">executing assembly name</see>.</param>
        /// <param name="exeAsmVersion">The <see cref="ExeAsmVersion">executing assembly version</see>.</param>
        /// <param name="dvnArguments">The dvn <see cref="Argument.Argument">arguments</see>.</param>
        /// <param name="session">The current dvn <see cref="Session.Session"/> instance.</param>
        internal static void InitializeSession(string exeAsmName, string exeAsmVersion, string[] dvnArguments, Session session)
        {
            session.Argument        = Argument.GetArguments(dvnArguments);
            session.FolderFramework = new FolderFramework();
            session.FileFramework   = FileFramework.New(session.FolderFramework);
            session.DvnApp          = DvnApp.Load(exeAsmName, exeAsmVersion, session.FileFramework.DvnConfig);

            FolderFramework.Validate(session.FolderFramework);

            session.EnvironmentList = DvnEnvironment.GetNameAndDescription(session.FolderFramework.Manifests);

            FileFramework.Validate(session.FileFramework);
        }

        /// <summary>Stops the current dvn session.</summary>
        /// <param name="exeAsmName">The <see cref="ExeAsmName">executing assembly name</see>.</param>
        /// <param name="exitMessage">The message to display to the user when dvn exits.</param>
        internal static void Stop(string exeAsmName, string exitMessage = "")
        {
            UserDisplay.Message(exeAsmName, UserMessage.ExitDvn(exitMessage));
            Environment.Exit(0);
        }
    }
}