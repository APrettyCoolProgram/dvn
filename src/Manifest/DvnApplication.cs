/* dvn.Manifest.DvnApplication.cs
 * u250806_code
 * u250806_documentation
 */

using System.Diagnostics;
using dvn.App;
using dvn.Blueprint;

namespace dvn.Manifest;

internal class DvnApplication
{
    ///<summary>The application name.</summary>
    public string Name { get; set; }

    ///<summary>The application description.</summary>
    public string Description { get; set; }

    ///<summary>The application file name.</summary>
    public string FileName { get; set; }

    ///<summary>The application arguments.</summary>
    public string Arguments { get; set; }

    ///<summary>The working directory for the application.</summary>
    public string WorkingDirectory { get; set; }

    /// <summary>Starts a list of applications.</summary>
    /// <remarks>Currently this functionality only works on Windows systems.</remarks>
    /// <param name="applications">A list of <see cref="DvnApplication"> applications</see>.</param>
    internal static void StartApplications(List<DvnApplication> applications)
    {
        foreach (DvnApplication app in applications)
        {
            if (string.IsNullOrEmpty(app.FileName))
            {
                Console.WriteLine($"  No applications found.");

                Session.Stop(UserMessage.msg_ExitDvn());
            }

            Console.WriteLine($"  Starting application: {app.Name}");

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName         = app.FileName,
                    Arguments        = app.Arguments,
                    WorkingDirectory = app.WorkingDirectory,
                    UseShellExecute  = true,
                    CreateNoWindow   = false
                }
            };

            _=process.Start();
        }
    }
}
