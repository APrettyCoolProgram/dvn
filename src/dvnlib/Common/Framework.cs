/* dvnlib.Framework.cs
 * u250710_code
 * u250710_documentation
 */

using System.Reflection;
using dvnlib.Du;

namespace dvnlib
{
    /// <summary>The dvn framework components.</summary>
    internal class Framework
    {
        /// <summary>The dvn framework paths.</summary>
        //public Dictionary<string, string> Patherwt { get; set; }

        public string DvnDataPath { get; set; }
        public string DvnManifestPath { get; set; }
        public string TemporaryDataPath { get; set; }
        public string TrashPath { get; set; }
        public string ApplicationPath { get; set; }
        //public string Data { get; set; }
        public string EncryptedDataPath { get; set; }
        public string BinPath { get; set; }
        public string RepositoryPath { get; set; }
        public string StagePath { get; set; }
        public string TestingPath { get; set; }
        public string VirtualMachinePath { get; set; }
        public string WinLinSubSysPath { get; set; }


        /// <summary> Creates a new instance of the <see cref="Framework"/> class with default paths initialized. </summary>
        /// <returns>A new <see cref="Framework"/> instance with predefined paths for data, staging, and repository.</returns>
        internal static Framework CreateNew()
        {
            return new Framework()
            {
                DvnDataPath        = @".\.dvn",
                DvnManifestPath    = @".\.dvn\manifest",
                TemporaryDataPath  = @".\.temp",
                TrashPath          = @".\.trash",
                ApplicationPath    = @".\app",
                //Data             = @".\data",
                EncryptedDataPath  = @".\data\enc",
                BinPath            = @".\data\bin",
                RepositoryPath     = @".\data\repo",
                StagePath          = @".\data\stage",
                TestingPath        = @".\data\test",
                VirtualMachinePath = @".\vm",
                WinLinSubSysPath   = @".\wsl"
            };
         }

        /// <summary>Validate the dvn framework.</summary>
        /// <param name="dvnFramework"> The <see cref="Framework.Framework"> to validate.</param>
        internal static void Validate(Framework dvnFramework)
        {
            foreach (PropertyInfo frameworkPath in dvnFramework.GetType().GetProperties())
            {
                var pathName = frameworkPath.GetValue(dvnFramework);

                if (!Directory.Exists(pathName.ToString()))
                {
                    Directory.CreateDirectory(pathName.ToString());
                }
            }
        }

        /// <summary>
        /// Copies the contents of a source repository to a staging directory, excluding specified files and
        /// directories.
        /// </summary>
        /// <remarks>This method resets the staging directory before copying the repository contents.
        /// Files and directories excluded from the copy operation are determined by the repository's catalog
        /// configuration.</remarks>
        /// <param name="source">The path to the source repository to copy.</param>
        /// <param name="paths">A dictionary containing paths used during the operation. The key "Staging" must be present and specify the
        /// target directory where the repository will be copied.</param>
        internal static void CopyRepo(List<string> sources, string target, string staging)
        {
            DuDirectory.Reset(staging);

            List<string> excludeFiles = Blueprint.Catalog.ExcludedRepoFiles();
            List<string> excludeDirs  = Blueprint.Catalog.ExcludedRepoDirectories();

            foreach (var source in sources)
            {
                var namer = source.Split("\\").Last();
                DuDirectory.CopyExclude(source, $@"{staging}\{namer}", excludeFiles, excludeDirs, true);
            }
        }
    }
}