using EsRun.Specification.Errors;
using EsRun.Specification.LanguageTypes.Abstract;
using EsRun.Specification.LanguageTypes.Concrete;
using EsRun.Specification.ObjectBehaviours.InternalMethods;
using EsRun.Specification.ObjectBehaviours.InternalSlots.Concrete;
using EsRun.Specification.SpecificationTypes.PropertyDescriptor;

namespace EsRun.Specification.Operations;

public static class OperationsOnObjects
{
    public static EsObject MakeBasicObject(List<IInternalSlot> internalSlotsList)
    {
        internalSlotsList.Add(new PrivateElementsInternalSlot());

        var obj = EsObject.CreateOrdinary(internalSlotsList);

        obj.InternalSlots.Get<PrivateElementsInternalSlot>().Value = new EsList([]);

        if (obj.InternalSlots.Has<ExtensibleInternalSlot>())
        {
            obj.InternalSlots.Get<ExtensibleInternalSlot>().Value = true;
        }

        return obj;
    }

    public static EsValue Get(EsObject o, EsValue p)
    {
        return o.InternalMethods.Get(p, o);
    }

    public static bool CreateDataProperty(EsObject o, EsValue p, EsValue v)
    {
        var newDesc = new PropertyDescriptor
        {
            Value = v,
            Writable = true,
            Enumerable = true,
            Configurable = true,
        };

        return o.InternalMethods.DefineOwnProperty(p, newDesc);
    }

    public static void CreateDataPropertyOrThrow(EsObject o, EsValue p, EsValue v)
    {
        var success = CreateDataProperty(o, p, v);

        if (success == false)
        {
            throw new TypeError("TypeError: Cannot create property");
        }
    }

    public static bool HasProperty(EsObject o, EsValue p)
    {
        return o.InternalMethods.HasProperty(p);
    }

    public static EsValue Call(EsValue f, EsValue v, EsList? argumentsList = null)
    {
        if (argumentsList == null)
        {
            argumentsList = new EsList([]);
        }

        if (TestingAndComparitionOperations.IsCallable(f) == false)
        {
            throw new TypeError("TypeError: Value is not callable");
        }

        return ((FunctionInternalMethods)((EsObject)f).InternalMethods).Call(v, argumentsList);
    }
}
