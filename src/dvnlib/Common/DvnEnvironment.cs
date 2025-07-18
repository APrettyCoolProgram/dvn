/* dvnlib.DvnEnvironment.cs
 * u250717_code
 * u250717_documentation
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
        internal static void DisplayEnvironments(string exeAsmName, Dictionary<string, string> availableEnvironments)
        {
            //string environmentList = GetEnvironmentList(exeAsmName, manifestPath);

            if (availableEnvironments.Count == 0)
            {
                Session.Stop(exeAsmName, UserMessage.EnvList("No environments found."));
            }
            else
            {
                string availableList = DuDictionary.ConvertToString(availableEnvironments, "    ", "");
                UserDisplay.Message(exeAsmName, UserMessage.EnvList(availableList));
            }
        }

        /// <summary>Get a list of available environment names</summary>
        /// <param name="path">The directory path to search for environment files. Must be a valid directory path.</param>
        /// <returns>A string containing the names of all environments found.</returns>
        internal static Dictionary<string, string> GetEnvironmentDetails(string manifestPath)
        {
            var manifestPaths = Directory.GetFiles(manifestPath, "*.manifest", SearchOption.AllDirectories);

            Dictionary<string, string> environmentDetail = [];

            foreach (var path in manifestPaths)
            {
                Manifest environment                = DuJson.ImportFromLocalFile<Manifest>(path);
                environmentDetail[environment.Name] = environment.Description;
            }

            return environmentDetail;
        }

        internal static void Load(Session session)
        {
            //if (File.Exists($@"{session.Framework.Manifests}\{session.Argument.Command}.dvn"))
            //{
            //    Launch(session);
            //}
            //else
            //{
            //    Manifest.New(session.Asm, session.Framework.Manifests, session.Argument.Command);
            //    Session.Stop(session.Asm);
            //}
        }

        internal static void Launch(Session session)
        {
            //Manifest manifest = DuJson.ImportFromLocalFile<Manifest>($@"{session.Framework.Manifests}\{session.Argument.Command}.dvn");

            //Console.WriteLine($"{Environment.NewLine}  Launching environment: {manifest.Description}");

            //if (manifest.BackupData || session.Argument.Option.Contains("-b"))
            //{
            //    Framework.CopyRepo(manifest.BackupSources, session.Framework.Stageing);
            //    Backup.BackupData(session.Framework.Stageing, manifest.BackupTarget);
            //}
            //else
            //{
            //    UserDisplay.Message(session.Asm, "  Backup disabled.");
            //}

            //Profile.Component.Application.StartApplications(manifest.Application);
        }
    }
}