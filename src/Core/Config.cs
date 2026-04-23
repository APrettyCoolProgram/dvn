// 260423_code
// 260423_documentation

namespace dvn.Core;

internal class Config
{
    public string LogDirectory { get; set; }

    internal static Config Load()
    {
        Config config = new Config();

        config.LogDirectory = @".dvn\Log";

        // Placeholder for loading configuration from a file or environment variables.
        // For now, it returns a default configuration instance.
        return config;
    }
}
