using ESRun.Interpreter.LanguageTypes;
using ESRun.Interpreter.ObjectBehaviours.InternalMethods.Abstract;
using ESRun.Interpreter.SpecificationTypes;

namespace ESRun.Interpreter.ObjectBehaviours.InternalMethods;

public class OrdinaryInternalMethods : IInternalMethods
{
    public virtual EsObject Owner { get; }

    public OrdinaryInternalMethods(EsObject owner)
    {
        Owner = owner;
    }

    public EsObject? GetPrototypeOf()
    {
        return OrdinaryObjectAlgorithms.OrdinaryGetPrototypeOf(Owner);
    }

    public bool SetPrototypeOf(EsObject? v)
    {
        return OrdinaryObjectAlgorithms.OrdinarySetPrototypeOf(Owner, v);
    }

    public bool IsExtensible()
    {
        return OrdinaryObjectAlgorithms.OrdinaryIsExtensible(Owner);
    }

    public bool PreventExtensions()
    {
        return OrdinaryObjectAlgorithms.OrdinaryPreventExtensions(Owner);
    }

    public PropertyDescriptor? GetOwnProperty(EsValue p)
    {
        return OrdinaryObjectAlgorithms.OrdinaryGetOwnProperty(Owner, p);
    }

    public bool DefineOwnProperty(EsValue p, PropertyDescriptor desc)
    {
        return OrdinaryObjectAlgorithms.OrdinaryDefineOwnProperty(Owner, p, desc);
    }

    public bool HasProperty(EsValue propertyName)
    {
        return OrdinaryObjectAlgorithms.OrdinaryHasProperty(Owner, propertyName);
    }

    public EsValue Get(EsValue p, EsValue receiver)
    {
        return OrdinaryObjectAlgorithms.OrdinaryGet(Owner, p, receiver);
    }

    public bool Set(EsValue p, EsValue v, EsValue receiver)
    {
        return OrdinaryObjectAlgorithms.OrdinarySet(Owner, p, v, receiver);
    }

    public bool Delete(EsValue p)
    {
        return OrdinaryObjectAlgorithms.OrdinaryDelete(Owner, p);
    }

    public List<EsValue> OwnPropertyKeys()
    {
        return OrdinaryObjectAlgorithms.OrdinaryOwnPropertyKeys(Owner);
    }
}