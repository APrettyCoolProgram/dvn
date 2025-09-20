// =============================================================================
// dvn.Program.cs
// https://github.com/aprettycoolprogram/dvn
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// -----------------------------------------------------------------------------
// u250920_code
// u250920_documentation
// =============================================================================

using dvn.Core;

namespace dvn;

/// <summary>Entry class for dvn.</summary>
internal static class Program
{
    /// <summary>Entry point for dvn.</summary>
    /// <param name="dvnArguments">The command line arguments passed to dvn at execution.</param>
    internal static void Main(string[] dvnArguments) => Session.Start(dvnArguments);
}