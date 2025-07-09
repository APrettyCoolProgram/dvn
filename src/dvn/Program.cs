/* dvn.Program.cs
 * u250708_code
 * u250708_documentation
 */

using System.Reflection;
using dvnlib;
using dvnlib.Blueprint;
using dvnlib.Common;

namespace dvn
{
    /// <summary>Entry class for dvn.</summary>
    internal static class Program
    {
        /// <summary>Entry point for devn.</summary>
        /// <param name="args">The command line arguments passed to dvn at execution.</param>
        internal static void Main(string[] args)
        {
            Console.Clear();

            string dvnVer = Assembly.GetExecutingAssembly()
                                     .GetName().Version
                                     .ToString();

            string exeAsm = Assembly.GetExecutingAssembly()
                                    .GetName().Name;

            if (args == null || args.Length == 0)
            {

                Session.Stop(exeAsm, UserMessage.bpm_MissingArgument(dvnVer));
            }
            else
            {
                Session.Start(dvnVer, exeAsm, args);
            }
        }
    }
}