/* dvn.Program.cs
 * u250716_code
 * u250716_documentation
 */

using System.Reflection;
using dvnlib;

namespace dvn
{
    /// <summary>Entry class for dvn.</summary>
    internal static class Program
    {
        /// <summary>Entry point for devn.</summary>
        /// <param name="args">The command line arguments passed to dvn at execution.</param>
        internal static void Main(string[] args) =>
            Session.Start(Assembly.GetExecutingAssembly().GetName().Name, Assembly.GetExecutingAssembly().GetName().Version.ToString(), args);
    }
}