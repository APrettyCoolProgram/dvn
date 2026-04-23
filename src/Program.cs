// 260423_code
// 260423_documentation

using System.Reflection;
using dvn.Du;

namespace dvn;

internal static class Program
{


    private static readonly Version _applicationVersion = Assembly.GetExecutingAssembly().GetName().Version;


    internal static void Main(string[] args)
    {
        Console.WriteLine("Starting dvn...");
        InitializeDvn();

        if (args.Length == 0)
        {
            DuLog.ErrorLog(".dvn/Log/error.log", "Missing command", "66210", "top");
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

    internal static void InitializeDvn()
    {
        Console.WriteLine("Initializing...");
        Core.Framework.InitializeFramework();
    }
}