/* dvn.App.HelpInformer.cs
 * u250815_code
 * u250815_documentation
 */

using dvn.Blueprint;

namespace dvn.Core;

internal class HelpInformer
{

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
