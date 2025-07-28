/* dvnlib.Initializer.cs
 * u250719_code
 * u250719_documentation
 */

using dvnlib.Blueprint;
using dvnlib.Framework;

namespace dvnlib
{
    /// <summary>
    /// 
    /// </summary>
    internal class Initializer
    {
        internal static void InitializeFramework(string exeAsmName, FolderFramework folderFramework)
        {
            FolderFramework.Validate(folderFramework);
            FileFramework.Validate(FileFramework.New(folderFramework));

            Session.Stop(exeAsmName, UserMessage.FirstRun);
        }
    }
}
