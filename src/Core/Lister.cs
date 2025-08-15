/* dvn.App.Lister.cs
 * u250815_code
 * u250815_documentation
 */

using dvn.Manifest;

namespace dvn.Core;

internal class Lister
{
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
