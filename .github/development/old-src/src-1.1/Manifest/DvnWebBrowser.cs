// =============================================================================
// dvn.Manifest.DvnWebBrowser.cs
// https://github.com/aprettycoolprogram/dvn
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// -----------------------------------------------------------------------------
// u250920_code
// u250920_documentation
// =============================================================================

using System.Diagnostics;

namespace dvn.Manifest;

/// <summary>Web browser-related logic.</summary>
internal class DvnWebBrowser
{
    /// <summary>A dictionary containing browser names and their associated pages.</summary>
    /// <remarks>
    ///     The keys are the browser names (e.g., "IExplore", "Firefox"), and the values are dictionaries
    ///     where the keys are page titles and the values are URLs.
    ///
    ///     For example: <<"IExplore">, <"Project Documentation", "http://the-url.com">>
    ///
    /// </remarks>
    public Dictionary<string, Dictionary<string, string>> PagesToOpen { get; set; }

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
