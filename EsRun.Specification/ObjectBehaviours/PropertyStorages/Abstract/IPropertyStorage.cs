using EsRun.Specification.LanguageTypes.Abstract;
using EsRun.Specification.SpecificationTypes.PropertyDescriptor;

namespace EsRun.Specification.ObjectBehaviours.PropertyStorages.Abstract;

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