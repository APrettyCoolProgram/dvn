// 250801_code
// 260617_documentation

using System.Text;

namespace dvn.Du;

/// <summary>Utility methods for working with dictionary objects.</summary>
internal static class DuDictionary
{
    // [250801]
    /// <summary>Converts the specified dictionary into a formatted string.</summary>
    /// <param name="dictionary">The dictionary containing key-value pairs to be converted.</param>
    /// <param name="prefix">The string to prepend to each key in the output.</param>
    /// <param name="suffix">The string to append to each value in the output.</param>
    /// <returns>A string containing the contents of the passed dictionary.</returns>
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