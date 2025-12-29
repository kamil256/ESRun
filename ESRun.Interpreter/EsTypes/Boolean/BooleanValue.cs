using ESRun.Interpreter.EsTypes.Abstract;

namespace ESRun.Interpreter.EsTypes.Boolean;

public class BooleanValue : EsValue
{
    public const string FalseLiteral = "false";
    public const string TrueLiteral = "true";

    private readonly bool _value;
    private static BooleanValue? _falseInstance = null;
    private static BooleanValue? _trueInstance = null;

    private BooleanValue(bool value)
    {
        _value = value;
    }

    public static BooleanValue FalseInstance => _falseInstance ??= new BooleanValue(false);
    public static BooleanValue TrueInstance => _trueInstance ??= new BooleanValue(true);

    public override BooleanValue Clone()
    {
        return this;
    }

    public override string ToString(int nestingLevel)
    {
        return _value ? TrueLiteral : FalseLiteral;
    }
}