using ESRun.Interpreter.EsTypes.String;

namespace ESRun.Interpreter.EsTypes.Symbol;

public static class WellKnownSymbols
{
    private static SymbolValue _asyncIterator = new SymbolValue(new StringValue("Symbol.iterator"));
    private static SymbolValue _hasInstance = new SymbolValue(new StringValue("Symbol.hasInstance"));
    private static SymbolValue _isConcatSpreadable = new SymbolValue(new StringValue("Symbol.isConcatSpreadable"));
    private static SymbolValue _iterator = new SymbolValue(new StringValue("Symbol.iterator"));
    private static SymbolValue _match = new SymbolValue(new StringValue("Symbol.match"));
    private static SymbolValue _matchAll = new SymbolValue(new StringValue("Symbol.matchAll"));
    private static SymbolValue _replace = new SymbolValue(new StringValue("Symbol.replace"));
    private static SymbolValue _search = new SymbolValue(new StringValue("Symbol.search"));
    private static SymbolValue _species = new SymbolValue(new StringValue("Symbol.species"));
    private static SymbolValue _split = new SymbolValue(new StringValue("Symbol.split"));
    private static SymbolValue _toPrimitive = new SymbolValue(new StringValue("Symbol.toPrimitive"));
    private static SymbolValue _toStringTag = new SymbolValue(new StringValue("Symbol.toStringTag"));
    private static SymbolValue _unscopables = new SymbolValue(new StringValue("Symbol.unscopables"));

    public static SymbolValue AsyncIterator { get; } = _asyncIterator;
    public static SymbolValue HasInstance { get; } = _hasInstance;
    public static SymbolValue IsConcatSpreadable { get; } = _isConcatSpreadable;
    public static SymbolValue Iterator { get; } = _iterator;
    public static SymbolValue Match { get; } = _match;
    public static SymbolValue MatchAll { get; } = _matchAll;
    public static SymbolValue Replace { get; } = _replace;
    public static SymbolValue Search { get; } = _search;
    public static SymbolValue Species { get; } = _species;
    public static SymbolValue Split { get; } = _split;
    public static SymbolValue ToPrimitive { get; } = _toPrimitive;
    public static SymbolValue ToStringTag { get; } = _toStringTag;
    public static SymbolValue Unscopables { get; } = _unscopables;
}
