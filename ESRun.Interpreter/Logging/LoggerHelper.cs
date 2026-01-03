using ESRun.Interpreter.LanguageTypes;

namespace ESRun.Interpreter.Logging;

public static class LoggerHelper
{
    private static ILogger? _logger;

    public static void RegisterLogger(ILogger logger)
    {
        _logger = logger;
    }

    public static void LogInfo(EsValue value)
    {
        throw new NotImplementedException();
        // _logger?.LogInfo(value.ToString(0));
    }
}