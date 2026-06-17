// 260423_code
// 260423_documentation

using System.Reflection;
using dvn.Core;
using dvn.Du;

namespace dvn;

internal static class Program
{
    //public static Config config = new Config();

    private static string _errLogPath { get; set; }

    private static string _sessionLogPath { get; set; }

    private static string _configPath = Path.Combine(".dvn", "Config", "dvn.config");

    private static readonly Version _dvnVersion = Assembly.GetExecutingAssembly().GetName().Version;

    internal static void Main(string[] args)
    {
        Framework.InitializeFramework();
        Config config = Config.Load(_configPath); // Up top?

        DuConsole.DisplayLine(Blueprint.Starter(_dvnVersion.ToString()), "teT");

        //Console.WriteLine(Blueprint.Starter(_dvnVersion.ToString()));

        InitializeDvn(config);

        if (args.Length == 0)
        {
            DuLog.ErrorLog(config.ErrorLogPath, "Missing command", "66210", "top");
            Console.WriteLine("Missing command. Please type \"dvn -help\" for more information");
            return;
        }

        if (args[0].Equals("init", StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine("Initializing...");
            Command.Initialize.New();
        }

        if (args[0].Equals("install", StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine("Installing...");
            if (args[1].Equals("scoop", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Scoop...");
                Scooper.Install.Scoop();
            }
        }
    }

    internal static void InitializeDvn(Config config)
    {
        Console.WriteLine("Initializing...");
        Framework.InitializeFramework();

        _errLogPath = Path.Combine(config.LogDirectory, "error.log");
        //_sessionLogPath = Path.Combine(config.LogDirectory, "session.log");

    }
}