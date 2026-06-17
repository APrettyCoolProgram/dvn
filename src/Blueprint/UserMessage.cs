// 250801_code
// 260617_documentation

using System.Reflection;

namespace dvn.Blueprint;

/// <summary>Provides predefined user messages.</summary>
internal static class UserMessage
{
    /// <summary>The dvn start message.</summary>
    internal static string msg_StartDvn =>
        """
        =======
          dvn
        =======

        """;

    /// <summary>The message displayed when dvn is executed for the first time.</summary>
    internal static string msg_WelcomeToDvn =>
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
          {msg_ExitDvn()}
        """;

    /// <summary>The message displayed when command-line arguments are missing.</summary>
    internal static string msg_MissingArguments =>
        $"""
          ERROR: Missing arguments.
          {msg_ExitDvn()}
        """;

    /// <summary>The exit message template for dvn.</summary>
    /// <param name="exitMessage">A customizable exit message.</param>
    /// <returns>The formatted exit message.</returns>
    internal static string msg_ExitDvn(string exitMessage = "Exiting dvn...") =>
        $"""


          {exitMessage}


        """;

    // TODO pass extension
    /// <summary>The message displayed when creating a new dvn manifest.</summary>
    /// <param name="environmentName">The name of the environment.</param>
    /// <returns>The new manifest message.</returns>
    public static string msg_CreateManifest(string environmentName) =>
        $"""
           A "{environmentName}.dvn.manifest" file did not exist, so one was created.

           You will need to edit the "{environmentName}.dvn.manifest" file manually.

           For more detailed information, please refer to the dvn documentation:
             https://github.com/APrettyCoolProgram/dvn
           {msg_ExitDvn()}
         """;

    /// <summary>The help message.</summary>
    public static string msg_Help =>
        $"""
          --------
            Help
          --------

          Usage: dvn <command> [-options]

          Commands:

            %environment%   Start/create a development environment manifest
            help            Display the dvn help screen
            about           Display information about dvn
            list            Display the available development environments

          Options:

            -b              Force data backups

          Examples:

            To list the available environments:

                "dvn list"

            To start a specific environment:

                "dvn %manifest% -b"


          For more detailed information, please refer to the dvn documentation:
              https://github.com/APrettyCoolProgram/dvn
          {msg_ExitDvn()}
        """;

    /// <summary>The about message.</summary>
    public static string msg_About =>
        $"""
          -------------
            About dvn
          -------------

          dvn is a command lint utility for managing development environments
          Version {Assembly.GetExecutingAssembly().GetName().Version}
          https://github.com/APrettyCoolProgram/dvn
          Developed by A Pretty Cool Program
          Licensed under Apache 2.0
          {msg_ExitDvn()}
        """;

    /// <summary>The message that displays the list of available environments.</summary>
    /// <param name="environmentList">The list of available environments.</param>
    /// <returns>The available environments message.</returns>
    public static string msg_EnvList(string environmentList) =>
        $"""
          --------------------------
            Available environments
          --------------------------

           {environmentList}
        {msg_ExitDvn()}
        """;
}