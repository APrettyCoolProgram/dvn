// 260419_code
// 260419_documentation

using System.Management.Automation;

namespace dvn.Scooper;

/// <summary>Provides methods for installing Scoop and related tooling.</summary>
internal static class Install
{
    /// <summary>Installs Scoop into the <c>.dvn\Scoop</c> directory.</summary>
    /// <remarks>
    /// Downloads the Scoop installer via <c>irm get.scoop.sh</c> and runs it,
    /// directing the Scoop directory to <c>.dvn\Scoop</c> with the <c>-NoProxy</c> flag.
    /// </remarks>
    internal static void Scoop()
    {
        var scoopInstaller = $@"irm get.scoop.sh -outfile 'install.ps1'";

        Console.WriteLine($@"Downloading Scoop installer ({scoopInstaller})...");

        using var ps2 = PowerShell.Create();
        ps2.AddScript(scoopInstaller);
        ps2.Invoke();

        // Build the install command, targeting .dvn\Scoop and skipping proxy detection.
        var scoopLocation = ".\\install.ps1 -ScoopDir '.\\Scoop' -NoProxy";

        Console.WriteLine($@"Installing Scoop to .dvn\Scoop ({scoopLocation})...");

        // Execute the downloaded installer script in a new PowerShell instance.
        using var ps3 = PowerShell.Create();
        ps3.AddScript(scoopLocation);
        ps3.Invoke(); // Note: this does not execute in the current working directory; set ps3.Runspace or use SetCurrentDirectory if needed.
    }
}
