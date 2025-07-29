/* dvn.App.DvnFramework.cs
 * u250722_code
 * u250722_documentation
 */

using System.Reflection;

namespace dvn.App.Framework
{
    /// <summary>Logic for folders/directories.</summary>
    internal class DvnFolder
    {
        /// <summary>The dvn root folder.</summary>
        internal string Root { get; set; }
        /// <summary>The location of Windows Operating System applications.</summary>
        internal string WinApps { get; set; }

        /// <summary>The location of data backups.</summary>
        internal string Backups { get; set; }

        /// <summary>The location of configuration files/data.</summary>
        internal string Configs { get; set; }

        /// <summary>The location of manifest files.</summary>
        internal string Manifests { get; set; }

        /// <summary>The location of staging files.</summary>
        internal string Staging { get; set; }

        /// <summary>The location of temporary files.</summary>
        internal string Temporary { get; set; }

        /// <summary>The location of trashed files.</summary>
        internal string Trash { get; set; }

        /// <summary>The location of repository data.</summary>
        internal string Repositories { get; set; }

        /// <summary>Creates a new instance of the <see cref="DvnFolder"/> class.</summary>
        internal static DvnFolder Initialize()
        {
            return new DvnFolder
            {
                Root         = @".\",
                WinApps      = @".\apps\win",
                Backups      = @".\.dvn\backups",
                Configs      = @".\.dvn\configs",
                Manifests    = @".\.dvn\manifests",
                Staging      = @".\.dvn\staging",
                Temporary    = @".\.dvn\temporary",
                Trash        = @".\.dvn\trash",
                Repositories = @".\data\repositories"
            };
        }

        /// <summary>Validates the directory paths in the specified <see cref="DvnFolder"/> instance.</summary>
        /// <remarks>If the specified folder does not exist, it will be created.</remarks>
        /// <param name="folders">The <see cref="DvnFolder"/> instance containing directory paths to validate.</param>
        internal static void Validate(DvnFolder folders)
        {
            foreach (PropertyInfo property in typeof(DvnFolder).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                var value = property.GetValue(folders) as string;

                if (!string.IsNullOrWhiteSpace(value) && !Directory.Exists(value))
                {
                    Directory.CreateDirectory(value);
                }
            }
        }
    }
}