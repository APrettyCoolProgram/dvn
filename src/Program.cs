// 260419_code
// 260419_documentation

namespace dvn;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting...");

        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a command: 'du' or 'scoop'.");
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
}