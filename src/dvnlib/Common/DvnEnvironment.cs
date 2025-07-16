/* dvnlib.DvnEnvironment.cs
 * u250716_code
 * u250716_documentation
 */

using dvnlib.Blueprint;
using dvnlib.Common;
using dvnlib.Du;
using dvnlib.Profile;

namespace dvnlib
{
    internal class DvnEnvironment
    {
        /// <summary>Lists all available development environments found in the application's data directory.</summary>
        internal static void ListEnvs(string asm, string path)
        {
            string envList = GetEnvsString(asm, GetManifestDetails([.. Directory.GetFiles(path, "*.dvn", SearchOption.AllDirectories)]));

            if (string.IsNullOrWhiteSpace(envList))
            {
                Session.Stop(asm, UserMessage.EnvList("No environments found."));
            }
            else
            {
                UserDisplay.Message(asm, UserMessage.EnvList(envList));
            }
        }

        /// <summary>Get a list of available environment names</summary>
        /// <param name="path">The directory path to search for environment files. Must be a valid directory path.</param>
        /// <returns>A string containing the names of all environments found.</returns>
        internal static Dictionary<string, string> GetManifestDetails(List<string> paths)
        {
            Dictionary<string, string> envDetail = [];

            foreach (var path in paths)
            {
                var env = DuJson.ImportFromLocalFile<Manifest>(path);
                envDetail[env.Name] = env.Description;
            }

            return envDetail;
        }

        /// <summary>Get a list of available environment names.</summary>
        /// <param name="path">The directory path to search for environment files. Must be a valid directory path.</param>
        /// <returns>A string containing the names of all environments found.</returns>
        internal static string GetEnvsString(string asm, Dictionary<string, string> details)
        {
            var envs = string.Empty;

            foreach (var detail in details)
            {
                envs += $"  {detail.Key} - {detail.Value}{Environment.NewLine}";
            }

            return envs;
        }

        internal static void Load(Session session)
        {
            if (File.Exists($@"{session.Framework.Manifests}\{session.Argument.Command}.dvn"))
            {
                Launch(session);
            }
            else
            {
                Manifest.New(session.Asm, session.Framework.Manifests, session.Argument.Command);
                Session.Stop(session.Asm);
            }
        }

        internal static void Launch(Session session)
        {
            Manifest manifest = DuJson.ImportFromLocalFile<Manifest>($@"{session.Framework.Manifests}\{session.Argument.Command}.dvn");

            Console.WriteLine($"{Environment.NewLine}  Launching environment: {manifest.Description}");

            if (manifest.BackupData || session.Argument.Option.Contains("-b"))
            {
                Framework.CopyRepo(manifest.BackupSources, session.Framework.Stageing);
                Backup.BackupData(session.Framework.Stageing, manifest.BackupTarget);
            }
            else
            {
                UserDisplay.Message(session.Asm, "  Backup disabled.");
            }

            Profile.Component.Application.StartApplications(manifest.Application);
        }
    }
}