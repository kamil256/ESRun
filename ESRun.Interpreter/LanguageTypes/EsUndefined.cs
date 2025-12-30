namespace ESRun.Interpreter.LanguageTypes;

public class EsUndefined : EsValue
{
    public const string Literal = "undefined";

    private static EsUndefined? _instance = null;

    private EsUndefined() { }

    public static EsUndefined Instance => _instance ??= new EsUndefined();

    // public override EsUndefined Clone()
    // {
    //     return this;
    // }

    // public override string ToString(int nestingLevel)
    // {
    //     return Literal;
    // }
}