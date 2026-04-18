/* dvnlib.Session.Properties.cs
 * u250719_code
 * u250719_documentation
 */

using dvnlib.Common;
using dvnlib.Framework;

namespace dvnlib
{
    public partial class Session
    {
        /// <summary>The <see cref="Common.DvnApp"/> component.</summary>
        internal DvnApp DvnApp { get; set; }

        /// <summary>The dvn <see cref="Argument.Argument">arguments</see> component.</summary>
        internal Argument Argument { get; set; }

        /// <summary>The dvn <see cref="FolderFramework.FolderFramework">folder framework</see> components.</summary>
        internal FolderFramework FolderFramework { get; set; }

        /// <summary>The dvn <see cref="FileFramework.FileFramework">file framework</see> components.</summary>
        internal FileFramework FileFramework { get; set; }

        /// <summary>A list of the available environment names and descriptions.</summary>
        internal Dictionary<string, string> EnvironmentList { get; set; }
    }
}