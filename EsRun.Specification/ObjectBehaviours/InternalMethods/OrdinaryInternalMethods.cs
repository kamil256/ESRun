using EsRun.Specification.LanguageTypes.Abstract;
using EsRun.Specification.LanguageTypes.Concrete;
using EsRun.Specification.ObjectBehaviours.InternalMethods.Abstract;
using EsRun.Specification.SpecificationTypes.PropertyDescriptor;

namespace EsRun.Specification.ObjectBehaviours.InternalMethods;

public class OrdinaryInternalMethods : IInternalMethods
{
    public virtual EsObject Owner { get; }

    public OrdinaryInternalMethods(EsObject owner)
    {
        Owner = owner;
    }

    public EsObject? GetPrototypeOf()
    {
        return OrdinaryObjectBehaviours.OrdinaryGetPrototypeOf(Owner);
    }

    public bool SetPrototypeOf(EsObject? v)
    {
        return OrdinaryObjectBehaviours.OrdinarySetPrototypeOf(Owner, v);
    }

    public bool IsExtensible()
    {
        return OrdinaryObjectBehaviours.OrdinaryIsExtensible(Owner);
    }

    public bool PreventExtensions()
    {
        return OrdinaryObjectBehaviours.OrdinaryPreventExtensions(Owner);
    }

    public PropertyDescriptor? GetOwnProperty(EsValue p)
    {
        return OrdinaryObjectBehaviours.OrdinaryGetOwnProperty(Owner, p);
    }

    public bool DefineOwnProperty(EsValue p, PropertyDescriptor desc)
    {
        return OrdinaryObjectBehaviours.OrdinaryDefineOwnProperty(Owner, p, desc);
    }

    public bool HasProperty(EsValue propertyName)
    {
        return OrdinaryObjectBehaviours.OrdinaryHasProperty(Owner, propertyName);
    }

    public EsValue Get(EsValue p, EsValue receiver)
    {
        return OrdinaryObjectBehaviours.OrdinaryGet(Owner, p, receiver);
    }

    public bool Set(EsValue p, EsValue v, EsValue receiver)
    {
        return OrdinaryObjectBehaviours.OrdinarySet(Owner, p, v, receiver);
    }

    public bool Delete(EsValue p)
    {
        return OrdinaryObjectBehaviours.OrdinaryDelete(Owner, p);
    }

    public List<EsValue> OwnPropertyKeys()
    {
        return OrdinaryObjectBehaviours.OrdinaryOwnPropertyKeys(Owner);
    }
}