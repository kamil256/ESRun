using ESRun.Interpreter.EsTypes.Object;

namespace ESRun.Interpreter.EsBuildInObjects;

public class GlobalObject : ObjectValue
{
    private static GlobalObject? _instance;

    private GlobalObject()
    {
        Properties.Add("console", new SimplePropertyDescriptor(ConsoleObject.Instance));
    }

    public static GlobalObject Instance => _instance ??= new GlobalObject();
}
