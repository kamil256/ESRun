namespace ESRun.Interpreter.EsTypes.Object;

public abstract class PropertyDescriptor
{
    public PropertyDescriptor(bool configurable, bool enumerable, bool writable)
    {
        Configurable = configurable;
        Enumerable = enumerable;
        Writable = writable;
    }

    public bool Configurable { get; }
    public bool Enumerable { get; }
    public bool Writable { get; }
}