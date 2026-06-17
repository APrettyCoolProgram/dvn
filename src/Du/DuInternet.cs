// 250815_code
// 250815_documentation

using System.Net;

namespace dvn.Du;

/// <summary>Provides internet download helpers.</summary>
internal class DuInternet
{
    /// <summary>Downloads data from a URL to a local file.</summary>
    /// <param name="url">The URL to download from.</param>
    /// <param name="targetPath">The file path where the downloaded data will be saved.</param>
    public static void DownloadUrl(string url, string targetPath)
    {
        var client = new WebClient();
        client.DownloadFile(url, targetPath);
    }
}