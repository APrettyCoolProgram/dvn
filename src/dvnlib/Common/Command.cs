using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvnlib
{
    internal class Command
    {
        /// <summary>The first command line argument.</summary>
        /// <remarks>
        ///     The <c>request</c> argument tells dvn what to do.
        ///     Example requests include:
        ///     <list type="bullet">
        ///         <item>help</item>
        ///         <item>list</item>
        ///         <item>new</item>
        ///     </list>
        /// </remarks>
        internal string Request { get; set; }

        /// <summary>The second command line argument.</summary>
        /// <remarks>
        /// </remarks>
        internal string Action { get; set; }

        /// <summary>The third command line argument.</summary>
        /// <remarks>
        /// </remarks>
        internal string Option { get; set; }

        internal Command Set (string[] args)
        {
            return new Command()
            {
                Request       = GetRequest(args),
                Action        = GetAction(args),
                Option        = GetOption(args),
            };
        }

        internal static string GetRequest(string[] args) =>
            args[0].ToLower().Trim();

        internal static string GetAction(string[] args) =>
            args.Length > 1
            ? args[1].ToLower().Trim()
            : string.Empty;

        internal static string GetOption(string[] args) =>
            args.Length > 2
            ? args[2].ToLower().Trim()
            : string.Empty;
    }
}
