/* dvn.App.DvnFile.cs
 * u250722_code
 * u250722_documentation
 */

namespace dvn.App.Framework
{
    /// <summary>Logic for folders/directories.</summary>
    /// <remarks>
    ///     This class contains any of the following:
    ///     <list type="bullet">
    ///         <item>File names</item>
    ///         <item>File paths</item>
    ///     </list>
    /// </remarks>
    internal class DvnFile
    {
        /// <summary>The path to the dvn configuration file.</summary>
        internal string DvnConfigFileFullPath { get; set; }

        /// <summary>Initializes a new instance of the <see cref="DvnFile"/> class.</summary>
        /// <param name="dvnFolder">The folder containing configuration files.</param>
        /// <returns>A <see cref="DvnFile"/> object.</returns>
        internal static DvnFile Initialize(DvnFolder dvnFolder)
        {
            return new DvnFile
            {
                DvnConfigFileFullPath = $@"{dvnFolder.Configs}\dvn.config"
            };
        }

        /// <summary>Validates that a list of files exists.</summary>
        /// <param name="file">The <see cref="DvnFile"/> object containing the path to the configuration file to validate.</param>
        internal static void Validate(DvnFile file)
        {
            if (!File.Exists(file.DvnConfigFileFullPath))
            {
                DvnConfiguration.Create(file.DvnConfigFileFullPath);
            }
        }
    }
}