// 260423_code
// 260423_documentation

// Classes in ns:Du are public, since they may be used in other projects.

namespace dvn.Du;

/// <summary>Logging functionality.</summary>
public static class DuLog
{
    private static readonly string _dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    /* LogMsg() will be expanded to handle different log levels (e.g., INFO, WARNING, etc.) and to include
     * additional context.
     */

    // 260423.231013
    /// <summary>Build the log message.</summary>
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

    // 260423.231013
    /// <summary>Create an error log file.</summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item>The specified log directory must exist in order for a log file to be created.</item>
    /// <item>The <c>code</c> parameter is optional; if provided, it will be included in the log entry as an error code.</item>
    /// <item>The <c>append</c> parameter is optional; if provided, it controls how the log entry is written to the file:</item>
    /// <list type="bullet">
    /// <item>If <paramref name="append"/> is <c>"top"</c>, the entry is prepended</item>
    /// <item>Any other non-empty value appends to the end</item>
    /// <item>If <paramref name="append"/> is empty/null, the file is overwritten.</item>
    /// </list>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// // Overwrite the log file with a new error entry.
    /// DuLog.ErrorLog(".dvn/Log/error.log", "Connection timed out");
    ///
    /// // Overwrite the log file with a new error entry, and include an error code.
    /// DuLog.ErrorLog(".dvn/Log/error.log", "Connection timed out", "50001");
    ///
    /// // Append an error entry, without an error code, to the log file.
    /// DuLog.ErrorLog(".dvn/Log/error.log", "Connection timed out", null, "bottom");
    ///
    /// // Prepend an error entry, with an error code, to the top of the log file.
    /// DuLog.ErrorLog(".dvn/Log/error.log", "Connection timed out", "50001", "top");
    /// </code>
    /// </example>
    /// <param name="path">The path to the log file.</param>
    /// <param name="msg">The message to log.</param>
    /// <param name="code">An optional error code to include in the log entry.</param>
    /// <param name="append">Controls write behavior: <c>"top"</c> to prepend, any other value to append, or <c>null</c> to overwrite.</param>
    public static void ErrorLog(string path, string msg, string code = null, string append = null)
    {
        //if (Directory.Exists(Path.GetDirectoryName(path)))
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

    // 260423.231013
    /// <summary>Create a standard log file.</summary>
    /// <remarks>
    /// The <c>append</c> parameter is optional; if provided, it controls how the log entry is written to the file:
    /// <list type="bullet">
    /// <item>If <paramref name="append"/> is <c>"top"</c>, the entry is prepended</item>
    /// <item>Any other non-empty value appends to the end</item>
    /// <item>If <paramref name="append"/> is empty/null, the file is overwritten.</item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// // Overwrite the log file with a new entry.
    /// DuLog.StandardLog(".dvn/Log/app.log", "Application started");
    ///
    /// // Append a new entry to the bottom of the log file.
    /// DuLog.StandardLog(".dvn/Log/app.log", "Step completed", "bottom");
    /// 
    /// // Prepend a new entry to the top of the log file.
    /// DuLog.StandardLog(".dvn/Log/app.log", "Step completed", "top");
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

    // 260423.231013
    /// <summary>Appends or prepends a log entry to the specified file.</summary>
    /// <remarks>
    /// The <paramref name="append"/> value can be:
    /// <list type="bullet">    
    /// <item><c>"top"</c> - Prepend the entry to the top of the file.</item>
    /// <item>Any other non-empty value - Append the entry to the end of the file.</item>   
    /// </list>
    /// </remarks>
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
}