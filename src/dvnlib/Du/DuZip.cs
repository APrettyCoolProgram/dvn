/* DuZip.cs
 * Does stuff with zip.
 * b250710
 * A Pretty Cool Program
 * https://gist.github.com/APrettyCoolProgram/6f8cb8e700fdccc39bf5314aefec8703
 */

using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvnlib.Du
{
    public class DuZip
    {
        /// <summary>Compresses stuff.</summary>
        internal static void CompressSubDirectories(string source, string target)
        {
            foreach (var subDirectory in Directory.GetDirectories(source))
            {
                var name = subDirectory.Split("\\").Last();

                var targetr = $"{target}\\{name}_{DateTime.Now:yyyyMM-ddHHmmss}.zip";

                ZipFile.CreateFromDirectory(subDirectory, targetr);
            }
        }
    }
}
