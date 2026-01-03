using ESRun.Interpreter.LanguageTypes;
using ESRun.Interpreter.SpecificationTypes;

namespace ESRun.Interpreter.ObjectBehaviours.PropertyStorage;

public interface IPropertyStorage
{
    bool Has(EsValue key);
    PropertyDescriptor? Get(EsValue key);
    bool Set(EsValue key, PropertyDescriptor descriptor);
    bool Delete(EsValue key);
    EsValue[] Keys { get; }
    public EsValue[] ArrayKeys { get; }

    public EsValue[] StringKeys { get; }

    public EsValue[] SymbolKeys { get; }
}