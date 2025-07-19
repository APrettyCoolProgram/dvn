/* dvn.App.DvnSession.Properties.cs
 * u250719_code
 * u250719_documentation
 */

namespace dvn.App
{
    internal partial class DvnSession
    {
        /// <summary>The <see cref="DvnConfiguration"/> instance.</summary>
        internal DvnConfiguration Configuration { get; set; }

        /// <summary>The <see cref="DvnArguments"/> component.</summary>
        internal DvnArguments Arguments { get; set; }

        /// <summary>The <see cref="DvnFramework"/> component.</summary>
        internal DvnFramework Framework { get; set; }

        /// <summary>A list of the available environment names and descriptions.</summary>
        internal Dictionary<string, string> EnvironmentList { get; set; }
    }
}