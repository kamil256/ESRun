using ESRun.Interpreter.EsTypes.Abstract;

namespace ESRun.Interpreter.EsTypes.Undefined;

public class UndefinedValue : EsValue
{
    public const string Literal = "undefined";

    private static UndefinedValue? _instance = null;

    private UndefinedValue() { }

    public static UndefinedValue Instance => _instance ??= new UndefinedValue();

    public override UndefinedValue Clone()
    {
        return this;
    }

    public override string ToString(int nestingLevel)
    {
        return Literal;
    }
}