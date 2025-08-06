/* dvn.Manifest.DvnWebBrowser.cs
 * u250806_code
 * u250806_documentation
 */

using System.Diagnostics;

namespace dvn.Manifest;
internal class DvnWebBrowser
{
    /// <summary>A dictionary containing browser names and their associated pages.</summary>
    /// <remarks>
    ///     The keys are the browser names (e.g., "IExplore", "Firefox"), and the values are dictionaries
    ///     where the keys are page titles and the values are URLs.
    /// </remarks>
    public Dictionary<string, Dictionary<string, string>> BrowserPages { get; set; }

    /// <summary>Opens the specified pages in their respective browsers.</summary>
    /// <param name="browserPages">A dictionary containing browser names and their associated pages.</param>
    internal static void OpenPages(Dictionary<string, Dictionary<string, string>> browserPages)
    {
        foreach (var browser in browserPages)
        {
            if (browser.Value.Count == 0)
            {
                Console.WriteLine($"  No pages found for {browser.Key}.");
            }
            else
            {
                Console.WriteLine($"  Opening pages in {browser.Key}:");

                foreach (var page in browser.Value)
                {
                    Console.WriteLine($"    Opening: {page.Key}");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {browser.Key.ToLower()} {page.Value}"));
                }
            }
        }
    }
}
