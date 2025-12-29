using ESRun.Interpreter.EsTypes.Abstract;

namespace ESRun.Interpreter.EsTypes.Null;

public class NullValue : EsValue
{
    public const string Literal = "null";

    private static NullValue? _instance = null;

    private NullValue() { }

    public static NullValue Instance => _instance ??= new NullValue();

    public override NullValue Clone()
    {
        return this;
    }

    public override string ToString(int nestingLevel)
    {
        return Literal;
    }
}