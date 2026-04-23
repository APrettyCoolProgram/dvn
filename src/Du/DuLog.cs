// 260423_code
// 260423_documentation

// Classes in ns:Du are public, since they may be used in other projects.

using Microsoft.CodeAnalysis.Operations;

namespace dvn.Du;

/// <summary>Logging functionality.</summary>
/// <example>
/// <code>
/// DuLog.StandardLog(".dvn/Log/app.log", "Application started");
/// DuLog.ErrorLog(".dvn/Log/error.log", "Something failed", "12345", "top");
/// </code>
/// </example>
public static class DuLog
{
    private static readonly string _dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    // 260422.221513
    /// <summary>Formatted log message, with the option for an error code.</summary>
    /// <remarks>If <paramref name="code"/> is provided, the message includes an <c>[ERROR-{code}]</c> prefix.</remarks>
    /// <example>
    /// <code>
    /// var msg = DuLog.LogMsg("Initialization complete");
    /// var errMsg = DuLog.LogMsg("File not found", "10042");
    /// </code>
    /// </example>
    /// <param name="msg">The log message text.</param>
    /// <param name="code">An optional error code to include in the message.</param>
    /// <returns>A formatted log message string prefixed with the current timestamp.</returns>
    public static string LogMsg(string msg, string? code = null)
    {
        return string.IsNullOrEmpty(code)
            ? $"{_dateTime} {msg}"
            : $"{_dateTime} [ERROR-{code}] {msg}";
    }

    // 260422.221513
    /// <summary>Writes a formatted error log entry to the specified file.</summary>
    /// <remarks>
    /// The file must already exist. If <paramref name="append"/> is <c>"top"</c>, the entry is prepended;
    /// any other non-empty value appends to the end; otherwise the file is overwritten.
    /// </remarks>
    /// <example>
    /// <code>
    /// // Overwrite the log file with a new error entry.
    /// DuLog.ErrorLog(".dvn/Log/error.log", "Connection timed out", "50001");
    ///
    /// // Prepend an error entry to the top of the log file.
    /// DuLog.ErrorLog(".dvn/Log/error.log", "Connection timed out", "50001", "top");
    /// </code>
    /// </example>
    /// <param name="path">The path to the log file.</param>
    /// <param name="msg">The error message to log.</param>
    /// <param name="code">An optional error code to include in the log entry.</param>
    /// <param name="append">Controls write behavior: <c>"top"</c> to prepend, any other value to append, or <c>null</c> to overwrite.</param>
    public static void ErrorLog(string path, string msg, string code = null, string append = null)
    {
        if (File.Exists(path))
        {
            var errMsg = LogMsg(msg, code);

            if (string.IsNullOrEmpty(append))
            {
                File.WriteAllText(path, errMsg);
            }
            else
            {
                AppendLog(path, errMsg, append);
            }
        }
    }

    // 260422.221513
    /// <summary>Appends or prepends a log entry to the specified file.</summary>
    /// <remarks>If <paramref name="append"/> equals <c>"top"</c> (case-insensitive), the entry is prepended; otherwise it is appended.</remarks>
    /// <param name="path">The path to the log file.</param>
    /// <param name="msg">The formatted log message to write.</param>
    /// <param name="append">Determines placement: <c>"top"</c> to prepend, any other value to append.</param>
    private static void AppendLog(string path, string msg, string append)
    {
        if (append.Equals("top", StringComparison.CurrentCultureIgnoreCase))
        {
            var filecontent = File.ReadAllText(path);

            File.WriteAllText(path, $"{msg}{Environment.NewLine}{filecontent}");
        }
        else
        {
            File.AppendAllText(path, $"{msg}{Environment.NewLine}");
        }
    }

    // 260422.221513
    /// <summary>Writes a log entry to the specified file if the parent directory exists.</summary>
    /// <remarks>
    /// If <paramref name="append"/> is <c>"top"</c>, the entry is prepended; any other non-empty value appends
    /// to the end; otherwise the file is overwritten.
    /// </remarks>
    /// <example>
    /// <code>
    /// // Overwrite the log file with a new entry.
    /// DuLog.StandardLog(".dvn/Log/app.log", "Application started");
    ///
    /// // Append a new entry to the bottom of the log file.
    /// DuLog.StandardLog(".dvn/Log/app.log", "Step completed", "bottom");
    /// </code>
    /// </example>
    /// <param name="path">The path to the log file.</param>
    /// <param name="msg">The message to write.</param>
    /// <param name="append">Controls write behavior: <c>"top"</c> to prepend, any other value to append, or <c>null</c> to overwrite.</param>
    public static void StandardLog(string path, string msg, string append = null)
        {
        if (Directory.Exists(Path.GetDirectoryName(path)))
        {
            if (string.IsNullOrEmpty(append))
            {
                File.WriteAllText(path, msg);
            }
            else
            {
                AppendLog(path, msg, append);
            }
        }
    }
}