// 260419_code
// 260419_documentation

namespace dvn.Command;

internal class Initialize
{
    internal static void New(string loc = null) // Can get rid of loc
    {

        if (string.IsNullOrEmpty(loc))
        {
            if (!Directory.Exists("Applications"))
            {
                Directory.CreateDirectory("Applications");
            }

            if (!Directory.Exists(".dvn"))
            {
                Directory.CreateDirectory(".dvn");
            }

            if (!Directory.Exists(@".dvn/App"))
            {
                Directory.CreateDirectory(@".dvn/App");
            }

            if (!Directory.Exists(@".dvn/Archive"))
            {
                Directory.CreateDirectory(@".dvn/Archive");
            }

            if (!Directory.Exists(@".dvn/Backup"))
            {
                Directory.CreateDirectory(@".dvn/Backup");
            }

            if (!Directory.Exists(@".dvn/Cache"))
            {
                Directory.CreateDirectory(@".dvn/Cache");
            }

            if (!Directory.Exists(@".dvn/Log"))
            {
                Directory.CreateDirectory(@".dvn/Log");
            }

            if (!Directory.Exists(@".dvn/Package"))
            {
                Directory.CreateDirectory(@".dvn/Package");
            }

            if (!Directory.Exists(@".dvn/Package/Scoop"))
            {
                Directory.CreateDirectory(@".dvn/Package/Scoop");
            }


            if (!Directory.Exists(@".dvn/Release"))
            {
                Directory.CreateDirectory(@".dvn/Release");
            }

            if (!Directory.Exists(@".dvn/Scoop"))
            {
                Directory.CreateDirectory(@".dvn/Scoop");
            }

            if (!Directory.Exists(@".dvn/Temporary"))
            {
                Directory.CreateDirectory(@".dvn/Temporary");
            }

            if (!Directory.Exists("Repositories"))
            {
                Directory.CreateDirectory("Repositories");
            }

            if (!Directory.Exists("Secure"))
            {
                Directory.CreateDirectory("Secure");
            }

            if (!Directory.Exists("Trash"))
            {
                Directory.CreateDirectory("Trash");
            }

            if (!Directory.Exists("VirtualMachines"))
            {
                Directory.CreateDirectory("VirtualMachines");
            }

            if (!Directory.Exists("WSL"))
            {
                Directory.CreateDirectory("WSL");
            }
        }
        //else
        //{
        //    if (!Directory.Exists($@"{loc}:/Scoop"))
        //    {
        //        Directory.CreateDirectory($@"{loc}:/Scoop");
        //    }

        //    if (!Directory.Exists($@"{loc}:/Temporary"))
        //    {
        //        Directory.CreateDirectory($@"{loc}:/Temporary");
        //    }

        //    if (!Directory.Exists($@"{loc}:/Trash"))
        //    {
        //        Directory.CreateDirectory($@"{loc}:/Trash");
        //    }

        //    if (!Directory.Exists($@"{loc}:/VirtualMachines"))
        //    {
        //        Directory.CreateDirectory($@"{loc}:/VirtualMachines");
        //    }
        //}
    }
}