/* DuWindowsOS.cs
 * Does stuff with the Windows Operating System.
 * b250707
 * A Pretty Cool Program
 * https://gist.github.com/APrettyCoolProgram/6f8cb8e700fdccc39bf5314aefec8703
 */


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dvnlib.Profile.Component;

namespace dvnlib.Du
{
    public class DuWindowsOS
    {
        internal static void StartWindowsProcess(Application app)
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
