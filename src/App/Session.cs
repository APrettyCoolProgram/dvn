/* dvn.App.Session.cs
 * u250731_code
 * u250731_documentation
 */

using dvn.Blueprint;

namespace dvn.App;

/// <summary>Session logic.</summary>
/// <remarks>
///     A "<c>session</c>" is a single instance of dvn.<br/>
///     <br/>
///     When dvn is executed, a <i>Session instance</i> is created, which contains all the necessary<br/>
///     components that dvn needs to do its job, including:
///     <list type="bullet">
///         <item>The dvn <see cref="App.Configuration">configuration</see></item>
///         <item>The <see cref="App.CommandLine">arguments</see> passed to dvn</item>
///         <item>The dvn <see cref="App.Framework">framework</see> information</item>
///         <item>The list of available <see cref="DevelopmentEnvironment">environments</see></item>
///     </list>
///     <br/>
///     When dvn is closed, the <i>Session instance</i> is disposed of.
/// </remarks>
internal class Session
{
    /// <summary>The <see cref="App.Configuration"/> instance.</summary>
    internal Configuration Configuration { get; set; }

    /// <summary>The <see cref="App.CommandLine"/> component.</summary>
    internal CommandLine CommandLine { get; set; }

    /// <summary>The <see cref="App.Framework"/> component.</summary>
    internal Framework Framework { get; set; }

    /// <summary>A list of the available environment names and descriptions.</summary>
    internal Dictionary<string, string> AvailableEnvironments { get; set; }

    /// <summary>Starts a new dvn session.</summary>
    /// <remarks>The <c>".\.dvn"</c> folder is hard-coded here, since the dvn framework hasn't been initialized yet.</remarks>
    /// <param name="passedArguments">The dvn <see cref="CommandLine.CommandLine"/> arguments passed to dvn.</param>
    internal static void Start(string[] passedArguments)
    {
        Console.Clear();

        Console.WriteLine(UserMessage.msg_StartDvn);

        Framework.VerifyExists(@".\.dvn");

        if (Arguments.DoExist(passedArguments))
        {
            InitializeNew(passedArguments);
        }
        else
        {
            Stop(UserMessage.msg_MissingArguments);
        }
    }

    /// <summary>Initialize a new dvn session.</summary>
    /// <param name="dvnArguments">The dvn <see cref="CommandLine.Arguments">arguments</see> passed to dvn.</param>
    internal static void InitializeNew(string[] passedArguments)
    {
        var dvnSession = new Session
        {
            CommandLine = CommandLine.GetComponents(passedArguments),
            Framework   = Framework.BuildNew()
        };

        dvnSession.Configuration         = Configuration.LoadFromFile(dvnSession.Framework.Files["ConfigFile"]);
        dvnSession.AvailableEnvironments = DevelopmentEnvironment.GetEnvironmentDetails(dvnSession.Framework.Folders["Manifests"], dvnSession.Configuration.ManifestExtension);

        Framework.Validate(dvnSession.Framework);

        Arguments.ParseCommand(dvnSession);
    }

    /// <summary>Terminates the application with an optional exit message.</summary>
    /// <param name="exitMessage">The message to display before the application exits.</param>
    internal static void Stop(string exitMessage = "")
    {
        Console.WriteLine(exitMessage);

        Environment.Exit(0);
    }
}