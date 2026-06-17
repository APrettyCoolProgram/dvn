// 250920_code
// 260617_documentation

using dvn.Blueprint;

namespace dvn.Core;

/// <summary>Displays help information for dvn.</summary>
internal class HelpInformer
{
    /// <summary>Writes the appropriate help message to the console.</summary>
    /// <remarks>
    /// If no options are supplied, the general help message is displayed.<br/>
    /// If the <c>-e</c> option is supplied, the environment help message is displayed.
    /// </remarks>
    /// <param name="dvnSession">The current dvn session.</param>
    internal static void Parse(Session dvnSession)
    {
        var options = dvnSession.Arguments.Options;

        if (options.Count == 0)
        {
            Console.WriteLine(UserMessage.usrmsg_Help);
        }
        else
        {
            if (options.Contains("-e"))
            {
                Console.WriteLine(UserMessage.usrmsg_HelpEnvironment);
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