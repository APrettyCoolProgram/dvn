using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dvnlib.Du;

namespace dvnlib
{
    internal class Framework
    {
        public Dictionary<string, string> Paths { get; set; }

        /// <summary>Validate the devn framework.</summary>
        internal static void Validate(Dictionary<string, string> paths)
        {
            foreach (var path in paths)
            {
                DuDirectory.ForceExist(path.Value);
            }
        }

        /// <summary>Copy the necessary repository files to the staging area.</summary>
        /// <param name="source">The location of the repository.</param>
        internal static void CopyRepo(string source, Dictionary<string, string> paths)
        {
            DuDirectory.Reset(paths["Staging"]);

            string target             = paths["Staging"];
            List<string> excludeFiles = Blueprint.Catalog.ExcludedRepoFiles();
            List<string> excludeDirs  = Blueprint.Catalog.ExcludedRepoDirectories();

            DuDirectory.CopyExclude(source, target, excludeFiles, excludeDirs, true);
        }

        /// <summary>Initializes and returns a <see cref="Framework"/> instance.</summary>
        /// <returns>A <see cref="Framework"/> object containing a dictionary of paths.</returns>
        internal static Framework New()
        {
            return new Framework()
            {
                Paths = new Dictionary<string, string>
                {
                    { "DataPath",    @".\AppData\" },
                    { "StagingPath", @".\AppData\staging\" },
                    { "RepoPath",    @".\AppData\stage\repository\" }
                }
            };
        }
    }
}
