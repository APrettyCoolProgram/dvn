/* dvn.App.DvnSession.cs
 * u250722_code
 * u250722_documentation
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
    ///     components that dvn needs to do its job, including:
    ///     <list type="bullet">
    ///         <item>The dvn <see cref="DvnConfiguration">configuration</see></item>
    ///         <item>The <see cref="DvnArguments">arguments</see> passed to dvn</item>
    ///         <item>The dvn <see cref="DvnFramework">framework</see> information</item>
    ///         <item>The list of available <see cref="DvnEnvironment">environments</see></item>
    ///     </list>
    ///     <br/>
    ///     When dvn is closed, the <i>Session instance</i> is disposed of.
    /// </remarks>
    internal class DvnSession
    {
        /// <summary>The <see cref="DvnConfiguration"/> instance.</summary>
        internal DvnConfiguration Configuration { get; set; }

        /// <summary>The <see cref="DvnArguments"/> component.</summary>
        internal DvnArguments Arguments { get; set; }

        /// <summary>The <see cref="DvnFramework"/> component.</summary>
        internal DvnFramework Framework { get; set; }

        /// <summary>A list of the available environment names and descriptions.</summary>
        internal Dictionary<string, string> EnvironmentList { get; set; }

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

            dvnSession.Configuration   = DvnConfiguration.Load(dvnSession.Framework.File.DvnConfigFileFullPath);
            dvnSession.EnvironmentList = DvnEnvironment.GetDetails(dvnSession.Framework.Folder.Manifests);

            DvnArguments.Parse(dvnSession);
        }

        internal static void Stop(string exitMessage = "")
        {
            Console.WriteLine(UserMessage.ExitDvn(exitMessage));
            Environment.Exit(0);
        }
    }
}
