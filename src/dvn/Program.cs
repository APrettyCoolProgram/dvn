/* dvn.Program.cs
 * u250710_code
 * u250710_documentation
 */

using System.Reflection;
using dvnlib;
using dvnlib.Blueprint;

namespace dvn
{
    /// <summary>Entry class for dvn.</summary>
    internal static class Program
    {
        internal static string MsgMissingArgument =>
            $"{Environment.NewLine}" +
            "  dvn ERROR - No argument passed";

        /// <summary>Entry point for devn.</summary>
        /// <param name="args">The command line arguments passed to dvn at execution.</param>
        internal static void Main(string[] args)
        {
            Console.Clear();

            string dvnVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string exeAsm     = Assembly.GetExecutingAssembly().GetName().Name;

            if (args == null || args.Length == 0)
            {
                Session.Stop(exeAsm, MsgMissingArgument);
            }
            else
            {
                Session.Start(exeAsm, dvnVersion, args);
            }
        }
    }
}