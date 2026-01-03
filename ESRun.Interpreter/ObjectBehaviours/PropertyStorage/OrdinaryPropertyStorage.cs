using ESRun.Interpreter.LanguageTypes;
using ESRun.Interpreter.Operations;
using ESRun.Interpreter.SpecificationTypes;

namespace ESRun.Interpreter.ObjectBehaviours.PropertyStorage;

public class OrdinaryPropertyStorage : IPropertyStorage
{
    private readonly Dictionary<EsValue, PropertyDescriptor> _properties = new();

    public bool Has(EsValue key)
    {
        var foundKey = FindKey(key);

        return foundKey != null;
    }

    public PropertyDescriptor? Get(EsValue key)
    {
        var foundKey = FindKey(key);

        return foundKey != null ? _properties[foundKey] : null;
    }

    public bool Set(EsValue key, PropertyDescriptor descriptor)
    {
        if (key.GetType() != typeof(EsString) && key.GetType() != typeof(EsSymbol))
        {
            throw new ArgumentException("Key must be StringValue or SymbolValue", nameof(key));
        }

        var foundKey = FindKey(key);
        _properties[foundKey ?? key] = descriptor;

        return true;
    }

    public bool Delete(EsValue key)
    {
        var foundKey = FindKey(key);

        return _properties.Remove(foundKey ?? key);
    }

    public EsValue[] Keys => _properties.Keys.ToArray();

    public EsValue[] ArrayKeys => throw new NotImplementedException();

    public EsValue[] StringKeys => _properties.Keys.Where(k => k is EsString).ToArray();

    public EsValue[] SymbolKeys => _properties.Keys.Where(k => k is EsSymbol).ToArray();

    private EsValue? FindKey(EsValue key)
    {
        return _properties.Keys.FirstOrDefault(k => TestingAndComparitionOperations.SameValue(k, key));
    }
}