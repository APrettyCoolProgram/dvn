// 260419_code
// 260419_documentation

using System.Net;

namespace dvn.Du;

internal class DuInternet
{
    /// <summary>Downloads a file from the specified URL and saves it to the specified local path.</summary>
    /// <remarks>The file at <paramref name="filePath"/> is created or overwritten with the downloaded content.</remarks>
    /// <param name="downloadUrl">The URL of the file to download.</param>
    /// <param name="filePath">The local path where the downloaded file will be saved.</param>
    internal static void DownloadFileFromUrl(string downloadUrl, string filePath)
    {
        var client = new WebClient();
        client.DownloadFile(downloadUrl, filePath);
    }
}