using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvn.Du
{
    internal class DuDictionary
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
