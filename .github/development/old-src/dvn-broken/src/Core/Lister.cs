// 250920_code
// 260617_documentation

using dvn.Manifest;

namespace dvn.Core;

/// <summary>Handles list-related commands.</summary>
internal class Lister
{
    /// <summary>Processes the list command output.</summary>
    /// <remarks>
    /// When no options are supplied, available environments are displayed.<br/>
    /// Otherwise, the method evaluates list-specific options.
    /// </remarks>
    /// <param name="dvnSession">The current dvn session.</param>
    internal static void Parse(Session dvnSession)
    {
        if (dvnSession.Arguments.Options.Count == 0)
        {
            DvnEnvironment.DisplayAvailable(dvnSession.AvailableEnvironments);
        }
        else
        {
            if (dvnSession.Arguments.Options.Contains("apps"))
            {

            }

            //foreach (var option in dvnSession.CommandLine.Options)
            //{
            //    switch (option)
            //    {
            //        case "all":
            //            DvnEnvironment.DisplayAvailable(dvnSession.AvailableEnvironments);
            //            break;
            //        case "installed":
            //            DvnEnvironment.DisplayInstalled(dvnSession.AvailableEnvironments);
            //            break;
            //        default:
            //            Console.WriteLine(UserMessage.msg_InvalidOption, option);
            //            break;
            //    }
            //}
        }
    }
}