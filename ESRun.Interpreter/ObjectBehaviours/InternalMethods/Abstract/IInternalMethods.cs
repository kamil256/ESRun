using ESRun.Interpreter.LanguageTypes;
using ESRun.Interpreter.SpecificationTypes;

namespace ESRun.Interpreter.ObjectBehaviours.InternalMethods.Abstract;

public interface IInternalMethods
{
    EsObject? GetPrototypeOf();
    bool SetPrototypeOf(EsObject? v);
    bool IsExtensible();
    bool PreventExtensions();
    PropertyDescriptor? GetOwnProperty(EsValue p);
    bool DefineOwnProperty(EsValue p, PropertyDescriptor desc);
    bool HasProperty(EsValue propertyName);
    EsValue Get(EsValue p, EsValue receiver);
    bool Set(EsValue p, EsValue v, EsValue receiver);
    bool Delete(EsValue p);
    List<EsValue> OwnPropertyKeys();
}