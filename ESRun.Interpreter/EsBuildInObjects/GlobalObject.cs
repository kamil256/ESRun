using ESRun.Interpreter.EsTypes.Object;
using ESRun.Interpreter.EsTypes.String;

namespace ESRun.Interpreter.EsBuildInObjects;

public class GlobalObject : ObjectValue
{
    private static GlobalObject? _instance;

    private GlobalObject()
    {
        DefineOwnProperty(new StringValue("console"), new DataPropertyDescriptor(ConsoleObject.Instance));
    }

    public static GlobalObject Instance => _instance ??= new GlobalObject();
}
