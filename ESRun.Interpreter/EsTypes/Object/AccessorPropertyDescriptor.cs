using ESRun.Interpreter.EsTypes.Function;

namespace ESRun.Interpreter.EsTypes.Object;

public class AccessorPropertyDescriptor : PropertyDescriptor
{
    public AccessorPropertyDescriptor(FunctionValue? get = null, FunctionValue? set = null, bool configurable = false, bool enumerable = false)
        : base(configurable, enumerable)
    {
        Get = get;
        Set = set;
    }

    public AccessorPropertyDescriptor(bool configurable = false, bool enumerable = false)
        : this(null, null, configurable, enumerable)
    {
    }

    public FunctionValue? Get { get; }

    public FunctionValue? Set { get; }
}