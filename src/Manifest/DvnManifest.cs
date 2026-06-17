// =============================================================================
// dvn.Manifest.DvnManifest.cs
// https://github.com/aprettycoolprogram/dvn
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// -----------------------------------------------------------------------------
// u250920_code
// u250920_documentation
// =============================================================================

using dvn.Core;
using dvn.Blueprint;
using dvn.Du;

namespace dvn.Manifest;

/// <summary>Manifest logic.</summary>
internal class DvnManifest
{
    /// <summary>The environment name.</summary>
    public DvnEnvironment DevelopmentEnvironment { get; set; }

    /// <summary>A list of applications associated with the environment.</summary>
    public List<DvnApplication> EnvironmentApplications { get; set; }

    public DvnWebBrowser WebBrowser { get; set; }

    /// <summary>Creates a default instance of the <see cref="DvnManifest"/> class.</summary>
    /// <param name="fileName">The name of the environment file.</param>
    /// <returns>A new instance of the <see cref="DevnEnv"/> class initialized with default values.</returns>
    internal static void CreateDefault(string manifestFolder, string manifestName, string manifestExtension)
    {
        var dvnManifest = new DvnManifest()
        {
            DevelopmentEnvironment = new DvnEnvironment
            {
                Name          = manifestName,
                Description   = "Default environment description.",
                BackupEnabled = false,
            },
            EnvironmentApplications =
            [
                new DvnApplication()
            ],
            WebBrowser = new DvnWebBrowser()
            {
                PagesToOpen = new Dictionary<string, Dictionary<string, string>>()
                {
                    { "Chrome",  new Dictionary<string, string>() },
                    { "Firefox",  new Dictionary<string, string>() },
                    { "IExplore", new Dictionary<string, string>() }
                }
            }
        };

        //TODO Split this out into a separate method.

        DuJson.ExportToFile(dvnManifest, $@"{manifestFolder}\{manifestName}{manifestExtension}");

        Console.WriteLine(UserMessage.msg_CreateManifest(manifestName));

        Session.Stop();
    }
}