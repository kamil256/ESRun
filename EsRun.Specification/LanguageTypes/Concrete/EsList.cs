using EsRun.Specification.LanguageTypes.Abstract;

namespace EsRun.Specification.LanguageTypes.Concrete;

public class EsList : EsValue
{
    public List<EsValue> Items { get; }

    public EsList(List<EsValue> items)
    {
        Items = items;
    }

    public void Add(EsValue item)
    {
        Items.Add(item);
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
