/* dvn.App.DvnSession.cs
 * u250719_code
 * u250719_documentation
 */

/* Properties for this class be found in .\Properties\DvnSession.Properties.cs
 */

using dvn.App.Framework;
using dvn.Blueprint;

namespace dvn.App
{
    /// <summary>Session logic.</summary>
    /// <remarks>
    ///     A "<c>session</c>" is a single instance of dvn.<br/>
    ///     <br/>
    ///     When dvn is executed, a <i>Session instance</i> is created, which contains all the necessary<br/>
    ///     components that dvn needs to do its job.<br/>
    ///     <br/>
    ///     When dvn is closed, the <i>Session instance</i> is disposed of.
    /// </remarks>
    internal partial class DvnSession
    {
        /// <summary>Starts a new dvn session.</summary>
        /// <param name="dvnArguments">The dvn <see cref="DvnArguments.Arguments>arguments</see>.</param>
        internal static void Start(string[] dvnArguments)
        {
            Console.Clear();

            Console.WriteLine(UserMessage.StartDvn);

            if (DvnArguments.DoExist(dvnArguments))
            {
                InitializeSession(dvnArguments);
            }
            else
            {
                Console.WriteLine(UserMessage.MissingArguments);
            }   
        }

        internal static void InitializeSession(string[] dvnArguments)
        {
            DvnSession dvnSession = new DvnSession
            {
                Arguments = DvnArguments.GetArguments(dvnArguments),
                Framework = DvnFramework.Initialize()
            };

            dvnSession.Configuration   = DvnConfiguration.Load(dvnSession.Framework.Files.DvnConfig);
            dvnSession.EnvironmentList = DvnEnvironment.GetNameAndDescription(dvnSession.Framework.Folders.Manifests);

            DvnArguments.Parse(dvnSession);
        }

        internal static void Stop(string exitMessage = "")
        {
            Console.WriteLine(UserMessage.ExitDvn(exitMessage));
            Environment.Exit(0);
        }
    }
}
