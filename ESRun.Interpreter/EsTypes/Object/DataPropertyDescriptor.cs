using ESRun.Interpreter.EsTypes.Abstract;

namespace ESRun.Interpreter.EsTypes.Object;

public class DataPropertyDescriptor : PropertyDescriptor
{
    public DataPropertyDescriptor(EsValue value, bool configurable = false, bool enumerable = false, bool writable = false)
        : base(configurable, enumerable, writable)
    {
        Value = value;
    }

    public EsValue Value { get; set; }
}