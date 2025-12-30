namespace ESRun.Interpreter.LanguageTypes;

public class EsSymbol : EsValue
{
    public EsSymbol(EsString? description)
    {
        Description = description;
    }

    public EsString? Description { get; }

    // public override EsSymbol Clone()
    // {
    //     return new EsSymbol(Description);
    // }

    // public override string ToString(int nestingLevel) => $"Symbol({Description?.ToString(0) ?? ""})";

    private static EsSymbol _asyncIterator = new EsSymbol(new EsString("Symbol.iterator"));
    private static EsSymbol _hasInstance = new EsSymbol(new EsString("Symbol.hasInstance"));
    private static EsSymbol _isConcatSpreadable = new EsSymbol(new EsString("Symbol.isConcatSpreadable"));
    private static EsSymbol _iterator = new EsSymbol(new EsString("Symbol.iterator"));
    private static EsSymbol _match = new EsSymbol(new EsString("Symbol.match"));
    private static EsSymbol _matchAll = new EsSymbol(new EsString("Symbol.matchAll"));
    private static EsSymbol _replace = new EsSymbol(new EsString("Symbol.replace"));
    private static EsSymbol _search = new EsSymbol(new EsString("Symbol.search"));
    private static EsSymbol _species = new EsSymbol(new EsString("Symbol.species"));
    private static EsSymbol _split = new EsSymbol(new EsString("Symbol.split"));
    private static EsSymbol _toPrimitive = new EsSymbol(new EsString("Symbol.toPrimitive"));
    private static EsSymbol _toStringTag = new EsSymbol(new EsString("Symbol.toStringTag"));
    private static EsSymbol _unscopables = new EsSymbol(new EsString("Symbol.unscopables"));

    public static EsSymbol AsyncIterator { get; } = _asyncIterator;
    public static EsSymbol HasInstance { get; } = _hasInstance;
    public static EsSymbol IsConcatSpreadable { get; } = _isConcatSpreadable;
    public static EsSymbol Iterator { get; } = _iterator;
    public static EsSymbol Match { get; } = _match;
    public static EsSymbol MatchAll { get; } = _matchAll;
    public static EsSymbol Replace { get; } = _replace;
    public static EsSymbol Search { get; } = _search;
    public static EsSymbol Species { get; } = _species;
    public static EsSymbol Split { get; } = _split;
    public static EsSymbol ToPrimitive { get; } = _toPrimitive;
    public static EsSymbol ToStringTag { get; } = _toStringTag;
    public static EsSymbol Unscopables { get; } = _unscopables;
}