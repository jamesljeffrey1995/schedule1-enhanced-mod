namespace Schedule1EnhancedMod.Utils;

/// <summary>
/// Helper class for logging messages
/// Provides consistent logging throughout the mod
/// </summary>
public static class Logger
{
    private static string ModPrefix => "[Schedule1Enhanced]";
    
    /// <summary>
    /// Log an informational message
    /// </summary>
    public static void Info(string message)
    {
        MelonLoader.MelonLogger.Msg($"{ModPrefix} {message}");
    }
    
    /// <summary>
    /// Log a warning message
    /// </summary>
    public static void Warning(string message)
    {
        MelonLoader.MelonLogger.Warning($"{ModPrefix} {message}");
    }
    
    /// <summary>
    /// Log an error message
    /// </summary>
    public static void Error(string message)
    {
        MelonLoader.MelonLogger.Error($"{ModPrefix} {message}");
    }
    
    /// <summary>
    /// Log an error with exception details
    /// </summary>
    public static void Error(string message, Exception ex)
    {
        MelonLoader.MelonLogger.Error($"{ModPrefix} {message}");
        MelonLoader.MelonLogger.Error($"{ModPrefix} Exception: {ex.Message}");
        MelonLoader.MelonLogger.Error($"{ModPrefix} Stack Trace: {ex.StackTrace}");
    }
    
    /// <summary>
    /// Log a debug message (only if debug logging is enabled)
    /// </summary>
    public static void Debug(string message)
    {
        if (Schedule1EnhancedMod.Config?.EnableDebugLogging == true)
        {
            MelonLoader.MelonLogger.Msg($"{ModPrefix} [DEBUG] {message}");
        }
    }
}
