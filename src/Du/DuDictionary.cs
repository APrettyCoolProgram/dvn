// 250801_code
// 250801_documentation

using System.Text;

namespace dvn.Du;

/// <summary>Provides helpers for working with dictionaries.</summary>
internal static class DuDictionary
{
    // [250801]
    /// <summary>Converts a dictionary to a formatted string.</summary>
    /// <param name="dictionary">The dictionary containing key-value pairs to convert.</param>
    /// <param name="prefix">The text to prepend to each key.</param>
    /// <param name="suffix">The text to append to each value.</param>
    /// <returns>A formatted string containing the dictionary entries.</returns>
    public static string ConvertToString(Dictionary<string, string> dictionary, string prefix, string suffix)
    {
        var convertedString = new StringBuilder();

        foreach (KeyValuePair<string, string> keyValuePair in dictionary)
        {
            _=convertedString.AppendLine($"{prefix}{keyValuePair.Key}: {keyValuePair.Value}{suffix}");
        }

        return convertedString.ToString();
    }
}