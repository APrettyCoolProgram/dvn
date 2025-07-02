/* dvnlib.App.cs
 * u250630_code
 * u250630_documentation
 */

using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvnlib.Common
{
    internal class App
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string Arguments { get; set; }
        public string WorkingDirectory { get; set; }

        internal static App BuildDefault()
        {
            return new App()
            {
                Name             = "Application name",
                Description      = "Application description",
                FileName         = "filename",
                Arguments        = "-arg1 -arg2",
                WorkingDirectory = "\\path\\to\\application"
            };
        }

        internal static void StartApplications(List<App> applications)
        {
            foreach (var app in applications)
            {
                StartWindowsProcess(app);
            }
        }

        internal static void StartWindowsProcess(App app)
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
