// 250801_code
// 250801_documentation

using System.Text.Json;

namespace dvn.Du;

/// <summary>Provides helpers for reading and writing JSON data.</summary>
public static class DuJson
{
    // [250801]
    /// <summary>Exports JSON data to a file.</summary>
    /// <typeparam name="JsonObject">The JSON object type.</typeparam>
    /// <param name="jsonObject">The JSON object to serialize.</param>
    /// <param name="filePath">The export file path.</param>
    /// <remarks>
    /// Use this method to write a JSON object to disk with indented formatting.
    /// </remarks>
    /// <example>
    /// <code>
    /// TheObject theObject = new TheObject();
    /// DuJson.ExportToFile&lt;TheObject&gt;(theObject, "/Path/To/Export/File");
    /// </code>
    /// </example>
    public static void ExportToFile<JsonObject>(JsonObject jsonObject, string filePath)
    {
        var jsonFormat = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var fileContent = JsonSerializer.Serialize(jsonObject, jsonFormat);

        File.WriteAllText(filePath, fileContent);
    }

    // [250801]
    /// <summary>Imports JSON data from a file.</summary>
    /// <typeparam name="JsonObject">The JSON object type.</typeparam>
    /// <param name="filePath">The import file path.</param>
    /// <remarks>
    /// Use this method to read JSON data from disk and deserialize it into an object.
    /// </remarks>
    /// <returns>The deserialized JSON object.</returns>
    /// <example>
    /// <code>
    /// TheObject theObject = DuJson.ImportFromFile&lt;TheObject&gt;("/Path/To/Import/File");
    /// </code>
    /// </example>
    public static JsonObject ImportFromFile<JsonObject>(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<JsonObject>(fileContents);
    }
}
