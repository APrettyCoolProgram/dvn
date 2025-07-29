/* dvnlib.Profile.Component.Application.cs
 * u250719_code
 * u250719_documentation
 */

using System.Diagnostics;

namespace dvnlib.Profile.Component
{
    internal class Application
    {
        /// <summary>
        /// Gets or sets the name associated with the object.
        /// </summary>

        internal static Application BuildDefault()
        {
            return new Application()
            {
                Name             = "Application name",
                Description      = "Application description",
                FileName         = "filename",
                Arguments        = "-arg1 -arg2",
                WorkingDirectory = "\\path\\to\\application"
            };
        }

        internal static void StartApplications(List<Application> applications)
        {
            foreach (var app in applications)
            {
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

                process.Start();
            }
        }
    }
}