// 260423_code
// 260423_documentation

using System.Text.Json;
using dvn.Du;

namespace dvn.Core;

internal class Config
{
    public string LogDirectory   = @".dvn\Log";
    public string ErrorLogPath => Path.Combine(LogDirectory, "error.log");
    public string SessionLogPath => Path.Combine(LogDirectory, "session.log");

    internal static Config Load(string configPath)
    {
        if (!File.Exists(configPath))
        {
            Config config = new Config();

            DuJson.ExportToFile<Config>(config, configPath);
        }

        string json = File.ReadAllText(configPath);

        return JsonSerializer.Deserialize<Config>(json) ?? new Config();
    }
}