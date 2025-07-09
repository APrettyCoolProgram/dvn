/* dvnlib.Command.cs
 * u250707_code
 * u250707_documentation
 */

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvnlib
{
    internal class Command
    {
        /// <summary>The first command line argument.</summary>
        /// <remarks>
        ///     The <c>action</c> argument tells dvn what to do.<br/>
        ///     <br/>
        ///     Example: "<c>devn <b>new</b></c>"
        /// </remarks>
        /// </remarks>
        internal string Request { get; set; }

        /// <summary>The second command line argument.</summary>
        /// <remarks>
        ///     The <c>request</c> argument tells dvn what to do with the action.<br/>
        ///     Actions do not <i>require</i> a request, and will perform default<br/>
        ///     logic if no request is provided.<br/>
        ///     <br/>
        ///     Example: "<c>devn new <b>myenv</b></c>"
        /// </remarks>
        internal List<string> Option { get; set; }

        ///// <summary>The third command line argument.</summary>
        ///// <remarks>
        /////     Any action/request arguments are passed as <c>options</c>.<br/>
        /////     Actions/requests do not <i>require</i> options, and will perform default<br/>
        /////     logic if no options are provided.<br/>
        /////     <br/>
        /////     Options start with a "<c>-</c>" character.<br/>
        /////     <br/>
        /////     Multiple options can be passed as a single string, separated by spaces.<br/>
        /////     <br/>
        /////     Example:  "<c>devn start myenv <b>-c -r</b></c>"
        ///// </remarks>
        //internal string Options { get; set; }

        internal static Command Get (string[] args)
        {
            return new Command()
            {
                Request = GetRequest(args),
                Option  = GetOption(args),
                ////Options = GetOptions(args),
            };
        }

        internal static string GetRequest(string[] args) =>
            args[0].ToLower().Trim();

        internal static List<string> GetOption(string[] args)
        {
            List<string> option = [];

            if (args.Length >= 2)
            {
                for (int i = 1; i < args.Length; i++)
                {
                    option.Add(args[i].ToLower().Trim());
                }
            }

            return option;
        }

        ////internal static string GetOptions(string[] args) =>
        ////    args.Length > 2
        ////    ? args[2].ToLower().Trim()
        ////    : string.Empty;
    }
}
