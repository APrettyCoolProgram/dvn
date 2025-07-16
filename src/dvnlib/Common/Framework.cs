/* dvnlib.Framework.cs
 * u250716_code
 * u250716_documentation
 */

using System.Reflection;
using dvnlib.Du;

namespace dvnlib
{
    /// <summary>The dvn framework components.</summary>
    internal class Framework
    {
        public string Manifests { get; set; }
        public string Tmp { get; set; }
        public string Trash { get; set; }
        public string Apps { get; set; }
        public string Encrypted{ get; set; }
        public string Bins { get; set; }
        public string Repos { get; set; }
        public string Stageing { get; set; }
        public string Testing { get; set; }
        public string Vms { get; set; }
        public string Wsl { get; set; }


        /// <summary> Creates a new instance of the <see cref="Framework"/> class with default paths initialized. </summary>
        /// <returns>A new <see cref="Framework"/> instance with predefined paths for data, staging, and repository.</returns>
        internal static Framework CreateNew()
        {
            return new Framework()
            {
                Manifests = @".\.dvn\manifest",
                Tmp       = @".\.temp",
                Trash     = @".\.trash",
                Apps      = @".\app",
                Encrypted = @".\data\enc",
                Bins      = @".\data\bin",
                Repos     = @".\data\repo",
                Stageing  = @".\data\stage",
                Testing   = @".\data\test",
                Vms       = @".\vm",
                Wsl       = @".\wsl"
            };
         }

        /// <summary>Validate the dvn framework.</summary>
        /// <param name="framework"> The <see cref="Framework.Framework"> to validate.</param>
        internal static void Validate(Framework framework)
        {
            foreach (PropertyInfo path in framework.GetType().GetProperties())
            {
                var name = path.GetValue(framework);

                if (!Directory.Exists(name.ToString()))
                {
                    Directory.CreateDirectory(name.ToString());
                }
            }
        }

        /// <summary>Copies the contents of a source repository to a staging directory.</summary>
        /// <param name="source">The path to the source repository to copy.</param>
        /// <param name="paths">A dictionary containing paths used during the operation.</param>
        internal static void CopyRepo(List<string> sources, string staging)
        {
            DuDirectory.Reset(staging);

            List<string> excludeFiles = Blueprint.Catalog.ExcludeFiles();
            List<string> excludeDirs  = Blueprint.Catalog.ExcludedDirs();

            foreach (var source in sources)
            {
                var namer = source.Split("\\").Last();
                DuDirectory.CopyExclude(source, $@"{staging}\{namer}", excludeFiles, excludeDirs, true);
            }
        }
    }
}