// 260423_code
// 260423_documentation

// Classes in ns:Du are public, since they may be used in other projects.

namespace dvn.Du;

public class DuInternet
{
    private static readonly HttpClient httpClient = new();

    // 260422.221513

    public static async Task DownloadFileFromUrlAsync(string downloadUrl, string filePath)
    {
        var response = await httpClient.GetAsync(downloadUrl);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsByteArrayAsync();
        await File.WriteAllBytesAsync(filePath, content);
    }
}