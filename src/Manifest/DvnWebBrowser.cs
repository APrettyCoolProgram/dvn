// 250920_code
// 260617_documentation

using System.Diagnostics;

namespace dvn.Manifest;

/// <summary>Represents browser launch configuration for a manifest.</summary>
internal class DvnWebBrowser
{
    /// <summary>The pages to open per browser.</summary>
    /// <value>A dictionary keyed by browser name with page titles and URLs.</value>
    public Dictionary<string, Dictionary<string, string>> PagesToOpen { get; set; }

    /// <summary>Opens the specified pages in their respective browsers.</summary>
    /// <param name="browserPages">The browser-to-pages mapping to open.</param>
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