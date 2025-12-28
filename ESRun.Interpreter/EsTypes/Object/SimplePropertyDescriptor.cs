using ESRun.Interpreter.EsTypes.Abstract;

namespace ESRun.Interpreter.EsTypes.Object;

public class SimplePropertyDescriptor
{
    public SimplePropertyDescriptor(EsValue value)
    {
        Value = value;
    }

    public EsValue Value { get; set; }
}