using EsRun.Specification.Errors;
using EsRun.Specification.FundamentalObjects;
using EsRun.Specification.LanguageTypes.Abstract;
using EsRun.Specification.LanguageTypes.Concrete;
using EsRun.Specification.ObjectBehaviours;
using EsRun.Specification.Operations;

namespace EsRun.Specification.SpecificationTypes.PropertyDescriptor;

public class PropertyDescriptor
{
    public EsValue? Value { get; set; }
    public bool? Writable { get; set; }
    public EsObject? Get { get; set; }
    public EsObject? Set { get; set; }
    public bool? Enumerable { get; set; }
    public bool? Configurable { get; set; }

    public static bool IsAccessorDescriptor(PropertyDescriptor desc)
    {
        if (desc.Get != null)
        {
            return true;
        }

        if (desc.Set != null)
        {
            return true;
        }

        return false;
    }

    public static bool IsDataDescriptor(PropertyDescriptor desc)
    {
        if (desc.Value != null)
        {
            return true;
        }

        if (desc.Writable != null)
        {
            return true;
        }

        return false;
    }

    public static bool IsGenericDescriptor(PropertyDescriptor desc)
    {
        if (IsAccessorDescriptor(desc))
        {
            return false;
        }

        if (IsDataDescriptor(desc))
        {
            return false;
        }

        return true;
    }

    public static EsObject? FromPropertyDescriptor(PropertyDescriptor? desc)
    {
        if (desc == null)
        {
            return null;
        }

        var obj = OrdinaryObjectBehaviours.OrdinaryObjectCreate(ObjectPrototype.Instance);

        if (!obj.InternalMethods.IsExtensible() || obj.InternalMethods.OwnPropertyKeys().Count > 0)
        {
            throw new InvalidOperationException("Object must be extensible and have no own properties");
        }

        if (desc.Value != null)
        {
            OperationsOnObjects.CreateDataPropertyOrThrow(obj, new EsString("value"), desc.Value);
        }

        if (desc.Writable != null)
        {
            OperationsOnObjects.CreateDataPropertyOrThrow(obj, new EsString("writable"), EsBoolean.FromBoolean((bool)desc.Writable));
        }

        if (desc.Get != null)
        {
            OperationsOnObjects.CreateDataPropertyOrThrow(obj, new EsString("get"), desc.Get);
        }

        if (desc.Set != null)
        {
            OperationsOnObjects.CreateDataPropertyOrThrow(obj, new EsString("set"), desc.Set);
        }

        if (desc.Enumerable != null)
        {
            OperationsOnObjects.CreateDataPropertyOrThrow(obj, new EsString("enumerable"), EsBoolean.FromBoolean((bool)desc.Enumerable));
        }

        if (desc.Configurable != null)
        {
            OperationsOnObjects.CreateDataPropertyOrThrow(obj, new EsString("configurable"), EsBoolean.FromBoolean((bool)desc.Configurable));
        }

        return obj;
    }

    public static PropertyDescriptor ToPropertyDescriptor(EsValue val)
    {
        if (val is not EsObject obj)
        {
            throw new ArgumentException("obj must be an ObjectValue", nameof(obj));
        }

        var desc = new PropertyDescriptor();
        var hasEnumerable = OperationsOnObjects.HasProperty(obj, new EsString("enumerable"));

        if (hasEnumerable == true)
        {
            var enumerable = TypeConversion.ToBoolean(OperationsOnObjects.Get(obj, new EsString("enumerable")));
            desc.Enumerable = enumerable.ToBoolean();
        }

        var hasConfigurable = OperationsOnObjects.HasProperty(obj, new EsString("configurable"));

        if (hasConfigurable == true)
        {
            var configurable = TypeConversion.ToBoolean(OperationsOnObjects.Get(obj, new EsString("configurable")));
            desc.Configurable = configurable.ToBoolean();
        }

        var hasValue = OperationsOnObjects.HasProperty(obj, new EsString("value"));

        if (hasValue == true)
        {
            var value = OperationsOnObjects.Get(obj, new EsString("value"));
            desc.Value = value;
        }

        var hasWritable = OperationsOnObjects.HasProperty(obj, new EsString("writable"));

        if (hasWritable == true)
        {
            var writable = TypeConversion.ToBoolean(OperationsOnObjects.Get(obj, new EsString("writable")));
            desc.Writable = writable.ToBoolean();
        }

        var hasGet = OperationsOnObjects.HasProperty(obj, new EsString("get"));

        if (hasGet == true)
        {
            var getter = OperationsOnObjects.Get(obj, new EsString("get"));

            if (TestingAndComparitionOperations.IsCallable(getter) == false && getter != null)
            {
                throw new TypeError("Getter must be a function or undefined");
            }

            desc.Get = getter as EsObject;
        }

        var hasSet = OperationsOnObjects.HasProperty(obj, new EsString("set"));

        if (hasSet == true)
        {
            var setter = OperationsOnObjects.Get(obj, new EsString("set"));

            if (TestingAndComparitionOperations.IsCallable(setter) == false && setter != null)
            {
                throw new TypeError("Getter must be a function or undefined");
            }

            desc.Set = setter as EsObject;
        }

        if (desc.Get != null || desc.Set != null)
        {
            if (desc.Value != null || desc.Writable != null)
            {
                throw new TypeError("Invalid property descriptor. Cannot be both data and accessor descriptor.");
            }
        }

        return desc;
    }

    public static void CompletePropertyDescriptor(PropertyDescriptor desc)
    {
        var like = new PropertyDescriptor
        {
            Value = EsUndefined.Instance,
            Writable = false,
            Get = null,
            Set = null,
            Enumerable = false,
            Configurable = false,
        };

        if (IsGenericDescriptor(desc) == true || IsDataDescriptor(desc) == true)
        {
            if (desc.Value == null)
            {
                desc.Value = like.Value;
            }

            if (desc.Writable == null)
            {
                desc.Writable = like.Writable;
            }
        }
        else
        {
            if (desc.Get == null)
            {
                desc.Get = like.Get;
            }

            if (desc.Set == null)
            {
                desc.Set = like.Set;
            }
        }

        if (desc.Enumerable == null)
        {
            desc.Enumerable = like.Enumerable;
        }

        if (desc.Configurable == null)
        {
            desc.Configurable = like.Configurable;
        }
    }
}
