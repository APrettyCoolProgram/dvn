/* dvnlib.Profile.Component.Application.cs
 * u250710_code
 * u250710_documentation
 */

using System.Diagnostics;

namespace dvnlib.Profile.Component
{
    internal class Application
    {
        /// <summary>
        /// Gets or sets the name associated with the object.
        /// </summary>
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string Argument { get; set; }
        public string WorkingDirectory { get; set; }

        internal static Application BuildDefault()
        {
            return new Application()
            {
                Name             = "Application name",
                Description      = "Application description",
                FileName         = "filename",
                Argument         = "-arg1 -arg2",
                WorkingDirectory = "\\path\\to\\application"
            };
        }

        internal static void StartApplications(List<Application> applications)
        {
            foreach (var app in applications)
            {
                StartWindowsProcess(app);
            }
        }

        internal static void StartWindowsProcess(Application app)
        {
            Console.WriteLine($"Starting application: {app.Name}");
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName         = app.FileName,
                        Arguments        = app.Argument,
                        WorkingDirectory = app.WorkingDirectory,
                        UseShellExecute  = true,
                        CreateNoWindow   = false
                    }
                };
                process.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting process: {ex.Message}");
            }
        }
    }
}
