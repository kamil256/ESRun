using EsRun.Specification.LanguageTypes.Abstract;

namespace EsRun.Specification.LanguageTypes.Concrete;

public class EsNull : EsValue
{
    public const string Literal = "null";

    private static EsNull? _instance = null;

    private EsNull() { }

    public static EsNull Instance => _instance ??= new EsNull();

    // public override EsNull Clone()
    // {
    //     return this;
    // }

    // public override string ToString(int nestingLevel)
    // {
    //     return Literal;
    // }
}