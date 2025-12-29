using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.String;

namespace ESRun.Interpreter.EsTypes.Symbol;

public class SymbolValue : EsValue
{
    public SymbolValue(StringValue? description)
    {
        Description = description;
    }

    public StringValue? Description { get; }

    public override SymbolValue Clone()
    {
        return new SymbolValue(Description);
    }

    public override string ToString(int nestingLevel) => $"Symbol({Description?.ToString(0) ?? ""})";
}