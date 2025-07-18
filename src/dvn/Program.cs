/* dvn.Program.cs
 * u250718_code
 * u250718_documentation
 */

using System.Reflection;
using dvnlib;

namespace dvn
{
    /// <summary>Entry class.</summary>
    internal static class Program
    {
        /// <summary>Entry point.</summary>
        /// <param name="dvnArguments">The command line <see cref="Argument">arguments</see> passed to dvn at execution.</param>
        internal static void Main(string[] dvnArguments)
        {
            string exeAsmName    = Assembly.GetExecutingAssembly().GetName().Name;
            string exeAsmVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            Session.Initialize(exeAsmName, exeAsmVersion, dvnArguments);
        }
    }
}