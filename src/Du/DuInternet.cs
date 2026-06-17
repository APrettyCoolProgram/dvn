// 250815_code
// 250815_documentation

using System.Net;

namespace dvn.Du;

internal class DuInternet
{
    /// <summary>
    /// Download data from a URL. [250109]
    /// </summary
    public static void DownloadUrl(string url, string targetPath)
    {
        var client = new WebClient();
        client.DownloadFile(url, targetPath);
    }
}