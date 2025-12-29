namespace ESRun.Interpreter.EsTypes.Object;

public abstract class PropertyDescriptor
{
    public PropertyDescriptor(bool configurable, bool enumerable)
    {
        Configurable = configurable;
        Enumerable = enumerable;
    }

    public bool Configurable { get; }
    public bool Enumerable { get; }
}