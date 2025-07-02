/* den.Program.cs
* u250701_code
* u250701_documentation
*/

using System.Reflection;

namespace dvn
{
    /// <summary>Entry class for dvn.</summary>
    internal class Program
    {
        /// <summary>Entry point for devn.</summary>
        /// <param name="args">Command line arguments.</param>
        static void Main(string[] args)
        {
            Console.Clear();

            string devnVer = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            dvnlib.Session.Start(devnVer, args);
        }
    }
}
