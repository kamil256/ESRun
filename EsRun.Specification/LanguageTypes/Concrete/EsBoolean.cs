using EsRun.Specification.LanguageTypes.Abstract;

namespace EsRun.Specification.LanguageTypes.Concrete;

public class EsBoolean : EsValue
{
    public const string FalseLiteral = "false";
    public const string TrueLiteral = "true";

    private readonly bool _value;
    private static EsBoolean? _falseInstance = null;
    private static EsBoolean? _trueInstance = null;

    private EsBoolean(bool value)
    {
        _value = value;
    }

    public static EsBoolean FalseInstance => _falseInstance ??= new EsBoolean(false);
    public static EsBoolean TrueInstance => _trueInstance ??= new EsBoolean(true);

    public static EsBoolean FromBoolean(bool value)
    {
        return value ? TrueInstance : FalseInstance;
    }

    public bool ToBoolean()
    {
        return _value;
    }

    // public override EsBoolean Clone()
    // {
    //     return this;
    // }

    // public override string ToString(int nestingLevel)
    // {
    //     return _value ? TrueLiteral : FalseLiteral;
    // }
}