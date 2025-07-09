/* dvnlib.Compressor.cs
 * u250707_code
 * u250707_documentation
 */

using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvnlib
{
    internal class Compressor
    {
        /// <summary>Compresses repository data.</summary>
        /// <param name="SourceTarget">The repository source, and compressed location.</param>
        internal static void CompressData(Dictionary<string, string> SourceTarget)
        {
            foreach (var sourceTarget in SourceTarget)
            {
                var source     = @".\AppData\repo";
                var repoName = sourceTarget.Key.Split("\\").Last();

                var target = $"{sourceTarget.Value}\\{repoName}_{DateTime.Now:yyyyMM-ddHHmmss}.zip";

                Console.WriteLine($"Compressing {source} => {target}...");
                ZipFile.CreateFromDirectory(source, target);
            }

            Console.WriteLine($"Compression complete.");
        }
    }
}
