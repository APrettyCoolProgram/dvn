using System.Text;

namespace dvn.Du;

internal static class DuDictionary
{
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
