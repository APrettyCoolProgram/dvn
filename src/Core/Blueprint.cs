// 260423_code
// 260423_documentation

namespace dvn.Core;

/// <summary>Provides static blueprint templates for formatted output strings.</summary>
internal static class Blueprint
{
    /// <summary>Returns a formatted error log entry string.</summary>
    /// <remarks>The entry includes a timestamp, error code, and error message.</remarks>
    /// <param name="errCode">The error code to include in the log entry.</param>
    /// <param name="errMsg">The error message to include in the log entry.</param>
    /// <returns>A formatted error log entry string.</returns>
    internal static string ErrorLog(string errCode, string errMsg)
        => $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [ERR-{errCode}] {errMsg}";
}