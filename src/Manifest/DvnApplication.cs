// 250920_code
// 260617_documentation

using System.Diagnostics;

namespace dvn.Manifest;

/// <summary>Represents a development environment application.</summary>
internal class DvnApplication
{
    /// <summary>The application name.</summary>
    /// <value>The display name of the application.</value>
    public string Name { get; set; }

    /// <summary>The application description.</summary>
    /// <value>The description of the application.</value>
    public string Description { get; set; }

    /// <summary>The application file name.</summary>
    /// <value>The executable file name or path.</value>
    public string FileName { get; set; }

    /// <summary>The application arguments.</summary>
    /// <value>The command-line arguments passed to the application.</value>
    public string Arguments { get; set; }

    /// <summary>The working directory for the application.</summary>
    /// <value>The working directory used when starting the application.</value>
    public string WorkingDirectory { get; set; }

    /// <summary>Starts the specified applications.</summary>
    /// <param name="applications">The applications to start.</param>
    internal static void StartApplications(List<DvnApplication> applications)
    {
        foreach (DvnApplication app in applications)
        {
            if (string.IsNullOrEmpty(app.FileName))
            {
                Console.WriteLine($"  No applications found.");

            }
            else
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

                _=process.Start();
            }
        }
    }
}