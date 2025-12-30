namespace ESRun.Interpreter.LanguageTypes;

public class EsList : EsValue
{
    public List<EsValue> Items { get; }

    public EsList(List<EsValue> items)
    {
        Items = items;
    }

    // public override EsValue Clone()
    // {
    //     return new EsList(Items);
    // }

    // public override string ToString(int nestingLevel)
    // {
    //     return "[" + string.Join(", ", Items.Select(item => item.ToString(nestingLevel + 1))) + "]";
    // }
}
