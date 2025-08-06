/* dvn.Manifest.DvnWebBrowser.cs
 * u250806_code
 * u250806_documentation
 */

using System.Diagnostics;
using dvn.App;
using dvn.Blueprint;

namespace dvn.Manifest;
internal class DvnWebBrowser
{
    public Dictionary<string,string> Firefox { get; set; }

    /// <summary>Starts a list of applications.</summary>
    /// <remarks>Currently this functionality only works on Windows systems.</remarks>
    /// <param name="applications">A list of <see cref="DvnApplication"> applications</see>.</param>
    internal static void StartFirefox(Dictionary<string, string> webpages)
    {
        if (webpages.Count == 0)
        {
            Console.WriteLine($"  No Firefox pages found.");

            Session.Stop(UserMessage.msg_ExitDvn());
        }
        else
        {
            foreach (var page in webpages)
            {
                Console.WriteLine($"  Opening: {page.Key}");

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName         = "start firefox",
                        Arguments        = page.Value,
                        UseShellExecute  = true,
                        CreateNoWindow   = false
                    }
                };

                _=process.Start();
            }

            //foreach (string webpage in webpages)
            //{
            //    Console.WriteLine($"  Opening: {app.Name}");

            //    var process = new Process
            //    {
            //        StartInfo = new ProcessStartInfo
            //        {
            //            FileName         = app.FileName,
            //            Arguments        = app.Arguments,
            //            WorkingDirectory = app.WorkingDirectory,
            //            UseShellExecute  = true,
            //            CreateNoWindow   = false
            //        }
            //    };

            //    _=process.Start();
            //}
        }


    }
}
