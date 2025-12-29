using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.Undefined;

namespace ESRun.Interpreter.EsTypes.Object;

public class DataPropertyDescriptor : PropertyDescriptor
{
    public DataPropertyDescriptor(EsValue value, bool configurable = false, bool enumerable = false, bool writable = false)
        : base(configurable, enumerable)
    {
        Value = value;
        Writable = writable;
    }

    public DataPropertyDescriptor(bool configurable = false, bool enumerable = false, bool writable = false)
        : this(UndefinedValue.Instance, configurable, enumerable, writable)
    {
    }

    public EsValue Value { get; set; }

    public bool Writable { get; }
}