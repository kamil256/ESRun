using ESRun.Interpreter.EsScope;
using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.Function;
using ESRun.Interpreter.EsTypes.Object;
using ESRun.Interpreter.EsTypes.Undefined;
using ESRun.Interpreter.Logging;

namespace ESRun.Interpreter.EsBuildInObjects;

public class ConsoleObject : ObjectValue
{
    private static ConsoleObject? _instance;

    private EsValue Log(EsValue[] arguments)
    {
        LoggerHelper.LogInfo(arguments[0] ?? UndefinedValue.Instance);

        return UndefinedValue.Instance;
    }

    private ConsoleObject()
    {
        Properties.Add("log", new SimplePropertyDescriptor(new FunctionValue(Log, new Scope())));
    }

    public static ConsoleObject Instance => _instance ??= new ConsoleObject();
}
