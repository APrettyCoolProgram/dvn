/* dvnlib.Env.cs
 * u250719_code
 * u250719_documentation
 */

using dvnlib.Blueprint;
using dvnlib.Common;
using dvnlib.Du;

namespace dvnlib.Profile
{
    internal class Manifest
    {

        /// <summary>Creates a new development environment configuration file based on the specified action.</summary>
        /// <remarks>
        ///     If an environment name (<c><see cref="Argument.Options">request</see></c>) is provided, it will be used<br/>
        ///     as the file name for the new environment configuration file, otherwise the file will be named "default.dvn".
        /// </remarks>
        /// <param name="request">The name of the action to use as the basis for the configuration file.</param>
        internal static void New(string asm, string path, string env)
        {
            Manifest defaultEnv = BuildDefault(env);
            DuJson.ExportToLocalFile<Manifest>(defaultEnv, $@"{path}\{env}.manifest");
            UserDisplay.Message(asm, UserMessage.CreateManifest(env));
        }

        /// <summary>Creates a default instance of the <see cref="Manifest"/> class.</summary>
        /// <param name="fileName">The name of the environment file.</param>
        /// <returns>A new instance of the <see cref="DevnEnv"/> class initialized with default values.</returns>
        internal static Manifest BuildDefault(string fileName)
        {
            return new Manifest()
            {
                Name          = fileName,
                Description   = "Environment description",
                BackupData    = false,
                BackupSources =
                [
                    "\\Path\\To\\Source1",
                    "\\Path\\To\\Source2"
                ],
                BackupTarget = "\\Path\\To\\Backup",
                Application  =
                [
                    new Component.Application()
                ]
            };
        }
    }
}