using ESRun.Interpreter.EsTypes.Abstract;

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
        _logger?.LogInfo(value.ToString(0));
    }
}