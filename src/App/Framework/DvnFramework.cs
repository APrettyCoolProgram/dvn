/* dvn.App.Framework.DvnFramework.cs
 * u250729_code
 * u250729_documentation
 */

using dvn.App.Session;
using dvn.Blueprint;

namespace dvn.App.Framework
{
    /// <summary>Logic for the dvn framework.</summary>
    internal class DvnFramework
    {
        internal DvnFolder Folder { get; set; }

        internal DvnFile File { get; set; }


        internal static void Verify()
        {
            if (!Directory.Exists(@".\.dvn"))
            {
                Console.WriteLine(UserMessage.WelcomeToDvn);

                DvnFramework fwk = GetFramework();

                Validate(fwk);

                DvnSession.Stop();

                //Console.WriteLine(UserMessage.WelcomeToDvn);

                //Initialize();
            }
        }

        //internal static void Initialize()
        //{
        //    DvnFramework fwk = GetFramework();

        //    Validate(fwk);
        //}

        //internal static DvnFramework Load()
        //{
        //    DvnFramework fwk = GetFramework();

        //    Validate(fwk);

        //    return fwk;
        //}

        internal static DvnFramework GetFramework()
        {
            DvnFolder dvnFolders = DvnFolder.BuildList();
            DvnFile dvnFiles     = DvnFile.BuildList(dvnFolders);

            return new DvnFramework
            {
                Folder = dvnFolders,
                File   = dvnFiles
            };
        }

        internal static void Validate(DvnFramework fwk)
        {
            DvnFolder.Validate(fwk.Folder);
            DvnFile.Validate(fwk.File);
        }
    }
}