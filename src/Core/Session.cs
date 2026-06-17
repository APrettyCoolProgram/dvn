// 250920_code
// 260617_documentation

using dvn.Blueprint;
using dvn.Manifest;

namespace dvn.Core;

/// <summary>Represents a dvn session.</summary>
/// <remarks>
/// A session contains the configuration, arguments, framework data, and available environments used by dvn.<br/>
/// When dvn exits, the session is disposed of.
/// </remarks>
internal class Session
{
    /// <summary>The <see cref="Configuration"/> instance.</summary>
    /// <value>The loaded dvn configuration.</value>
    internal Configuration Configuration { get; set; }

    /// <summary>The parsed command-line arguments.</summary>
    /// <value>The arguments supplied to dvn.</value>
    internal Argument Arguments { get; set; }

    /// <summary>The <see cref="Framework"/> instance.</summary>
    /// <value>The initialized dvn framework.</value>
    internal Framework Framework { get; set; }

    /// <summary>The available environment names and descriptions.</summary>
    /// <value>The discovered environments.</value>
    internal Dictionary<string, string> AvailableEnvironments { get; set; }

    /// <summary>Starts a new dvn session.</summary>
    /// <remarks>The <c>".\.dvn"</c> folder is hard-coded here because the framework has not been initialized yet.</remarks>
    /// <param name="passedArguments">The command-line arguments passed to dvn.</param>
    internal static void Start(string[] passedArguments)
    {
        Console.Clear();

        if (Argument.DoExist(passedArguments))
        {
            InitializeNew(passedArguments);
        }
        else
        {
            Stop(UserMessage.usrmsg_MissingArguments);
        }
    }

    /// <summary>Initializes a new dvn session.</summary>
    /// <param name="passedArguments">The command-line arguments passed to dvn.</param>
    internal static void InitializeNew(string[] passedArguments)
    {
        var dvnSession = new Session
        {
            Arguments = Argument.GetComponents(passedArguments),
            Framework = Framework.BuildNew()
        };

        dvnSession.Configuration         = Configuration.LoadFromFile(dvnSession.Framework.Files["ConfigFile"]);
        dvnSession.AvailableEnvironments = DvnEnvironment.GetEnvironmentDetails(dvnSession.Framework.Folders["Manifests"], dvnSession.Configuration.ManifestExtension);

        Framework.Validate(dvnSession.Framework);

        Argument.ParseCommand(dvnSession);
    }

    /// <summary>Terminates the application with an optional exit message.</summary>
    /// <param name="exitMessage">The message to display before the application exits.</param>
    internal static void Stop(string exitMessage = "")
    {
        Console.WriteLine(exitMessage);

        Environment.Exit(0);
    }
}