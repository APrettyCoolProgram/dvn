// =============================================================================
// dvn.Blueprint.UserMessage.cs
// https://github.com/aprettycoolprogram/dvn
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// -----------------------------------------------------------------------------
// 250920_code
// 250920_documentation
// =============================================================================

using System.Reflection;

namespace dvn.Blueprint;

/// <summary>Provides predefined user messages.</summary>
internal static class UserMessage
{
    /// <summary>The dvn start message.</summary>
    internal static string usrmsg_StartDvn =>
        """
        =======
          dvn
        =======

        """;

    /// <summary>The message that is displayed when dvn is executed for the first time.</summary>
    internal static string usrmsg_WelcomeToDvn =>
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
          {usrmsg_ExitDvn()}
        """;

    /// <summary>The message that is displayed when there are missing command line arguments.</summary>
    internal static string usrmsg_MissingArguments =>
        $"""
          ERROR: Missing arguments.
          {usrmsg_ExitDvn()}
        """;

    /// <summary>The message that is displayed when dvn exits.</summary>
    /// <param name="exitMessage">A customizable exit message.</param>
    /// <returns>The exit message.</returns>
    internal static string usrmsg_ExitDvn(string exitMessage = "Exiting dvn...") =>
        $"""


          {exitMessage}


        """;

    // TODO pass extension
    /// <summary>The message that is displayed when creating a new dvn manifest.</summary>
    /// <param name="environmentName">The name of the environment.</param>
    /// <returns>The new manifest message.</returns>
    public static string msg_CreateManifest(string environmentName) =>
        $"""
           A "{environmentName}.dvn.manifest" file did not exist, so one was created.

           You will need to edit the "{environmentName}.dvn.manifest" file manually.

           For more detailed information, please refer to the dvn documentation:
             https://github.com/APrettyCoolProgram/dvn
           {usrmsg_ExitDvn()}
         """;


    /// <summary>The about message.</summary>
    public static string usrmsg_About =>
        $"""
          -------------
            About dvn
          -------------

          dvn is a command lint utility for managing development environments
          Version {Assembly.GetExecutingAssembly().GetName().Version}
          https://github.com/APrettyCoolProgram/dvn
          Developed by A Pretty Cool Program
          Licensed under Apache 2.0
          {usrmsg_ExitDvn()}
        """;


    /// <summary>The standard help message.</summary>
    public static string usrmsg_Help =>
        $"""
          --------
            Help
          --------

          Usage: dvn <command> [-options]

          Commands:

            %environment%   Start/create a development environment manifest
            install         Install an application or package

          Options:

            -i --info       Display information about dvn
            -h --help       Display the dvn help screen
            -l --list       Display the available dvn environments

          For more information on a specific command, use:

            dvn <command> -help

          For more detailed information, please refer to the dvn documentation:
              https://github.com/APrettyCoolProgram/dvn
          {usrmsg_ExitDvn()}
        """;

    /// <summary>The %environment% command help message.</summary>
    public static string usrmsg_HelpEnvironment =>
        $"""
          -------------------------------
            %environment% command help
          -------------------------------

          Description:
            The %environment% command is used to start an environment by loading
            it's manifest file, or create a manifest file if one does not exist.

          Usage:
            dvn %environment% [-options]

          Options:

            -b --backup   Force the backup of data before starting the environment
            -h --help     Display this message
            -l --list     List the available dvn environments

          To start a specific environment, and force the backup of data:

            "dvn %environment% -b"

          For more detailed information, please refer to the dvn documentation:
              https://github.com/APrettyCoolProgram/dvn
          {usrmsg_ExitDvn()}
        """;


    /// <summary>The message that displays the list of available environments.</summary>
    /// <param name="environmentList">The list of available environments.</param>
    /// <returns>The available environments message.</returns>
    public static string usrmsg_EnvList(string environmentList) =>
        $"""
          --------------------------
            Available environments
          --------------------------

           {environmentList}
        {usrmsg_ExitDvn()}
        """;
}