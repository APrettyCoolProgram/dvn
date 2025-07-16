/* TingenWebService.TingenWebService.asmx.cs
 * u250709_code
 * u250709_documentation
 */

using System.Reflection;
using System.Web.Services;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;
using ScriptLinkStandard.Objects;

namespace TingenWebService
{
    /// <summary>The entry class for the Tingen Web Service.</summary>
    /// <remarks>
    ///     <para>
    ///       This class doesn't do much actual work, and should remain fairly static. For the most part, it just hands information to
    ///       <see href="https://github.com/spectrum-health-systems/outpost31"> Outpost31</see>, where the heavy lifting is done.
    ///       <br/>
    ///       There are two methods in this class, both of which <i>are required</i>:
    ///       <list type="bullet">
    ///          <item><see cref="GetVersion()"/></item>
    ///          <item><see cref="RunScript(OptionObject2015, string)"/></item>
    ///       </list>
    ///     </para>
    /// </remarks>
    /// <seealso href="https://github.com/spectrum-health-systems/tingen-documentation-project">Tingen Documentation Project</seealso>
    /// <seealso href="https://spectrum-health-systems.github.io/tingen-documentation-project/api">Tingen API Documentation</seealso>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TingenWebService : WebService
    {
        /// <summary>The executing assembly name.</summary>
        /// <remarks>A required log component, defined here so it can be used throughout the class.</remarks>
        public static string ExeAsm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>The current version of the Tingen Web Service.</summary>
        public static string WsvcVer { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>The Avatar System that the Tingen Web Service will interface with.</summary>
        /// <remarks>
        ///     The Avatar <see cref="Outpost31.Core.Avatar.AvtrSystemInfo.AvtrSys"><i>System</i></see> is different than an
        ///     Avatar <see cref="Outpost31.Core.Avatar.AvtrSystemInfo.AvtrSysCode"><i>System Code</i></see>.
        /// </remarks>
        /// <value><c>UAT</c> (testing) or <c>LIVE</c>(production)</value>
        public static string AvtrSys { get; set; } = "UAT";

        /// <summary>Get the current version of the Tingen Web Service.</summary>
        /// <remarks>This method is required and <i>should not be modified</i>.</remarks>
        /// <returns>The current <see cref="WsvcVer">version</see> of the Tingen Web Service.</returns>
        [WebMethod]
        public string GetVersion() => $"VERSION {WsvcVer}";

        /// <summary>The entry point for the Tingen Web Service.</summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>
        ///             This method is required and <i>should not be modified</i>.
        ///         </item>
        ///         <item>
        ///             <see cref="LogEvent.Trace(int, string, string, string, string, int, string)">Trace Logs</see>
        ///             can't go here because the logging infrastructure hasn't been initialized yet.
        ///         </item>
        ///         <item>
        ///             If Avatar doesn't pass an <paramref name="origOptObj"/> or <paramref name="origScriptParam"/>, the Tingen Web
        ///             Service will fail, and a <see cref= "LogEvent.Critical(string, string)">Critical Failure Log</see> will be created.
        ///         </item>
        ///      </list>
        /// </remarks>
        /// <param name="origOptObj">The <see cref="OptionObject2015"/> sent from Avatar.</param>
        /// <param name="origScriptParam">The <see cref="Outpost31.Core.Avatar.AvtrParameter.Original">original Script Parameter</see> that is sent from Avatar.</param>
        /// <returns>An <see cref="OptionObject2015"/> representing the result of the Script Parameter request.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 origOptObj, string origScriptParam) /* TODO - fix */
        {
            /* This should be uncommented unless needed.
             */
            LogEvent.Primeval(AvtrSys, "The TingenWebService has started.");

            if (string.IsNullOrWhiteSpace(origScriptParam) || origOptObj == null)
            {
                LogEvent.Critical(AvtrSys, Outpost31.Core.Blueprint.ErrorContent.WsvcCriticalMissingArgs(origOptObj, origScriptParam));

                /* TODO - Since the OptionObject may not exist, we should figure out a way to exit the application without returning a null object. */
                return origOptObj.ToReturnOptionObject(0, "");
            }
            else
            {
                var wsvcSession = WsvcSession.New(origOptObj, origScriptParam, WsvcVer, AvtrSys);

                Outpost31.Core.Avatar.AvtrParameter.Request(wsvcSession);

                return wsvcSession.OptObj.Finalized;
            }
        }
    }
}