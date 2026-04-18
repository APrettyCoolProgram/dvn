using System.Text;

namespace dvnlib.Du
{
    public static class DuDictionary
    {
        public static string ConvertToString(Dictionary<string, string> dictionary, string prefix, string suffix)
        {
            StringBuilder convertedString = new StringBuilder();

            foreach (var keyValuePair in dictionary)
            {
                convertedString.AppendLine($"{prefix}{keyValuePair.Key}: {keyValuePair.Value}{suffix}");
            }

            return convertedString.ToString();
        }
    }
}