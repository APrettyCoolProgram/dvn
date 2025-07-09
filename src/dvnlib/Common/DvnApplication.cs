/* dvnlib.App.cs
 * u250707_code
 * u250707_documentation
 */

using System.Diagnostics;

namespace dvnlib.Common
{
    internal class DvnApplication
    {
        /// <summary>
        /// Gets or sets the name associated with the object.
        /// </summary>
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string Arguments { get; set; }
        public string WorkingDirectory { get; set; }

        internal static DvnApplication BuildDefault()
        {
            return new DvnApplication()
            {
                Name             = "Application name",
                Description      = "Application description",
                FileName         = "filename",
                Arguments        = "-arg1 -arg2",
                WorkingDirectory = "\\path\\to\\application"
            };
        }

        internal static void StartApplications(List<DvnApplication> applications)
        {
            foreach (var app in applications)
            {
                StartWindowsProcess(app);
            }
        }

        internal static void StartWindowsProcess(DvnApplication app)
        {
            Console.WriteLine($"Starting application: {app.Name}");
            try
            {
                Process process = new Process
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting process: {ex.Message}");
            }
        }
    }
}
