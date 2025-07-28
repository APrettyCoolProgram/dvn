/* dvn.App.DvnFramework.cs
 * u250722_code
 * u250722_documentation
 */

namespace dvn.App.Framework
{
    /// <summary>Logic for the dvn framework.</summary>
    internal class DvnFramework
    {
        internal DvnFolder Folder { get; set; }

        internal DvnFile File { get; set; }

        internal static DvnFramework Initialize()
        {
            DvnFolder dvnFolders = DvnFolder.Initialize();
            DvnFile dvnFiles     = DvnFile.Initialize(dvnFolders);

            DvnFolder.Validate(dvnFolders);
            DvnFile.Validate(dvnFiles);

            return new DvnFramework
            {
                Folder = dvnFolders,
                File   = dvnFiles
            };
        }
    }
}