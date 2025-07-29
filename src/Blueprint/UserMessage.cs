/* dvn.Blueprint.UserMessage.cs
 * u250729_code
 * u250729_documentation
 */

using System.Reflection;

namespace dvn.Blueprint
{
    /// <summary>Provides predefined user messages.</summary>
    internal class UserMessage
    {
        /// <summary>The message that is displayed every time dvn is executed.</summary>
        internal static string StartDvn =>
            """
            =======
              dvn
            =======

            """;

        /// <summary>The message that is displayed when dvn is executed for the first time.</summary>
        internal static string WelcomeToDvn =>
            $"""
              -------------------
                Welcome to dvn!
              -------------------
              
              It looks like this is the first time you are running dvn on this
              machine, so we need to create the dvn framework.

              Once that's done, dvn will exit.
              
              Then just type "dvn help" on the command line to get started.
              
              For more detailed information, please refer to the dvn documentation:
                  https://github.com/APrettyCoolProgram/dvn
              {ExitDvn()}
            """;

        /// <summary>The message that is displayed when there are missing command line arguments.</summary>
        internal static string MissingArguments =>
            $"""
              ERROR: Missing arguments.
              {ExitDvn()}
            """;

        /// <summary>The message that is displayed when dvn exits.</summary>
        /// <param name="exitMessage">A customizable exit message.</param>
        /// <returns>The exit message.</returns>
        internal static string ExitDvn(string exitMessage = "Exiting dvn...") =>
            $"""


              {exitMessage}


            """;

        /// <summary>The message that is displayed when creating a new dvn manifest.</summary>
        /// <param name="environmentName">The name of the environment.</param>
        /// <returns>The new manifest message.</returns>
        public static string CreateManifest(string environmentName) =>
            $"""
               A "{environmentName}.manifest" did not exist, so it was created.

               You will need to edit the "{environmentName}.manifest" file manually.

               For more detailed information, please refer to the dvn documentation:
                   https://github.com/APrettyCoolProgram/dvn
             """;

        /// <summary>The help message.</summary>
        public static string Help =>
            $"""
              --------
                Help
              --------

              Usage: dvn <command> [-options]

              Commands:

                %manifest%   Start/create a development environment manifest
                help         Display the dvn help screen
                info         Display information about dvn
                list         Display the available development environments

              Options:

                -b           Force data backups

              Examples:

                To list the available environments:

                    "dvn list"

                To start a specific environment:

                    "dvn %manifest% -b"  


              For more detailed information, please refer to the dvn documentation:
                  https://github.com/APrettyCoolProgram/dvn
              {ExitDvn()}
            """;

        /// <summary>The about message.</summary>
        public static string About =>
            $"""
              -------------
                About dvn
              -------------

              dvn is a command lint utility for managing development environments
              Version {Assembly.GetExecutingAssembly().GetName().Version.ToString()}
              https://github.com/APrettyCoolProgram/dvn
              Developed by A Pretty Cool Program
              Licensed under Apache 2.0
              {ExitDvn()}
            """;

        /// <summary>The message that displays the list of available environments.</summary>
        /// <param name="environmentList">The list of available environments.</param>
        /// <returns>The available environments message.</returns>
        public static string EnvList(string environmentList) =>
            $"""
              --------------------------
                Available environments
              --------------------------

               {environmentList}
            {ExitDvn()}
            """;
    }
}