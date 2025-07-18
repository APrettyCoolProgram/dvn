/* dvnlib.Session.cs
 * u250717_code
 * u250717_documentation
 */

using dvnlib.Blueprint;
using dvnlib.Common;
using dvnlib.Framework;

namespace dvnlib
{
    /// <summary>Session logic.</summary>
    /// <remarks>
    ///     A "<c>session</c>" is a single instance of dvn.<br/>
    ///     When dvn is executed, a <i><see cref="Session"/> instance</i> is created, which contains all the necessary<br/>
    ///     components that dvn needs to do its job.
    /// </remarks>
    public class Session
    {
        /// <summary>The dvn <see cref="DvnApp"/> component.</summary>
        internal DvnApp DvnApps { get; set; }

        /// <summary>The dvn <see cref="Arguments.Arguments">arguments</see> component.</summary>
        internal Arguments Arguments { get; set; }

        /// <summary>The dvn <see cref="FolderFramework.FolderFramework">framework</see> components.</summary>
        internal FolderFramework FolderFramework { get; set; }

        /// <summary>The dvn <see cref="FileFramework.FileFramework">framework</see> components.</summary>
        internal FileFramework FileFramework { get; set; }

        /// <summary>The environment details.</summary>
        internal Dictionary<string, string> EnvironmentDetails { get; set; }

        /// <summary>Starts a new dvn session.</summary>
        /// <param name="exeAsmName">The <see cref="ExeAsmName">executing assembly name</see>.</param>
        /// <param name="exeAsmVersion">The <see cref="ExeAsmVersion">executing assembly version</see>.</param>
        /// <param name="dvnArguments">The dvn <see cref="Arguments.Arguments">arguments</see>.</param>
        public static void Initialize(string exeAsmName, string exeAsmVersion, string[] dvnArguments)
        {
            Console.Clear();

            UserDisplay.Message(exeAsmName, UserMessage.InitializeDvn);

            if (dvnArguments == null || dvnArguments.Length == 0)
            {
                Stop(exeAsmName, UserMessage.MissingArgument);
            }
            else
            {
                Start(exeAsmName, exeAsmVersion, dvnArguments);
            }
        }

        /// <summary>Creates a new <see cref="Session"/> instance.</summary>
        /// <param name="exeAsmName">The <see cref="ExeAsmName">executing assembly name</see>.</param>
        /// <param name="exeAsmVersion">The <see cref="ExeAsmVersion">executing assembly version</see>.</param>
        /// <param name="dvnArguments">The dvn <see cref="Arguments.Arguments">arguments</see>.</param>
        /// <returns>A new <see cref="Session"/> instance.</returns>
        internal static Session New(string exeAsmName, string exeAsmVersion, string[] dvnArguments)
        {
            var session = new Session
            {
                Arguments       = Arguments.GetArguments(dvnArguments),
                FolderFramework = new FolderFramework()
            };

            session.FileFramework = FileFramework.New(session.FolderFramework);
            session.DvnApps        = DvnApp.Load(exeAsmName, exeAsmVersion, session.FileFramework.DvnConfig);

            //if (Directory.Exists(session.FolderFramework.Manifests))
            //{
            //    session.EnvironmentDetails = DvnEnvironment.GetEnvironmentDetails(session.FolderFramework.Manifests);
            //}

            return session;
        }

        /// <summary>Starts a new dvn session.</summary>
        /// <param name="exeAsmName">The <see cref="ExeAsmName">executing assembly name</see>.</param>
        /// <param name="exeAsmVersion">The <see cref="ExeAsmVersion">executing assembly version</see>.</param>
        /// <param name="dvnArguments">The dvn <see cref="Arguments.Arguments">arguments</see>.</param>
        internal static void Start(string exeAsmName, string exeAsmVersion, string[] dvnArguments)
        {
            Session session = New(exeAsmName, exeAsmVersion, dvnArguments);

            FolderFramework.Validate(session.FolderFramework);

            session.EnvironmentDetails = DvnEnvironment.GetEnvironmentDetails(session.FolderFramework.Manifests);

            FileFramework.Validate(session.FileFramework);

            Parse.Action(session);
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