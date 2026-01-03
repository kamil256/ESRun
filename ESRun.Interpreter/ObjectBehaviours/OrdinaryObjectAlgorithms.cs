using ESRun.Interpreter.Errors;
using ESRun.Interpreter.LanguageTypes;
using ESRun.Interpreter.ObjectBehaviours.InternalSlots.Abstract;
using ESRun.Interpreter.ObjectBehaviours.InternalSlots.Concrete;
using ESRun.Interpreter.Operations;
using ESRun.Interpreter.SpecificationTypes;

namespace ESRun.Interpreter.ObjectBehaviours;

public static class OrdinaryObjectAlgorithms
{
    public static EsObject? OrdinaryGetPrototypeOf(EsObject o)
    {
        return o.InternalSlots.Get<PrototypeInternalSlot>().Value;
    }

    public static bool OrdinarySetPrototypeOf(EsObject o, EsObject? v)
    {
        var current = o.InternalSlots.Get<PrototypeInternalSlot>().Value;

        if (TestingAndComparitionOperations.SameValue(v ?? (EsValue)EsNull.Instance, current ?? (EsValue)EsNull.Instance))
        {
            return true;
        }

        var extensible = o.InternalSlots.Get<ExtensibleInternalSlot>().Value;

        if (extensible == false)
        {
            return false;
        }

        var p = v;
        var done = false;

        while (done == false)
        {
            if (p == null)
            {
                done = true;
            }
            else if (TestingAndComparitionOperations.SameValue(p, o) == true)
            {
                return false;
            }
            else
            {
                if (p.InternalMethods.GetPrototypeOf != o.InternalMethods.GetPrototypeOf)
                {
                    done = true;
                }
                else
                {
                    p = p.InternalSlots.Get<PrototypeInternalSlot>().Value;
                }
            }
        }

        o.InternalSlots.Get<PrototypeInternalSlot>().Value = v;

        return true;
    }

    public static bool OrdinaryIsExtensible(EsObject o)
    {
        return o.InternalSlots.Get<ExtensibleInternalSlot>().Value == true;
    }

    public static bool OrdinaryPreventExtensions(EsObject o)
    {
        o.InternalSlots.Get<ExtensibleInternalSlot>().Value = false;

        return true;
    }

    public static PropertyDescriptor? OrdinaryGetOwnProperty(EsObject o, EsValue p)
    {
        var x = o.Properties.Get(p);

        if (x == null)
        {
            return null;
        }

        var d = new PropertyDescriptor();

        if (PropertyDescriptor.IsDataDescriptor(x))
        {
            d.Value = x.Value;
            d.Writable = x.Writable;
        }
        else
        {
            if (!PropertyDescriptor.IsAccessorDescriptor(x))
            {
                throw new InvalidOperationException("Invalid property descriptor type.");
            }

            d.Get = x.Get; ;
            d.Set = x.Set;
        }

        d.Enumerable = x.Enumerable;
        d.Configurable = x.Configurable;

        return d;
    }

    public static bool OrdinaryDefineOwnProperty(EsObject o, EsValue p, PropertyDescriptor desc)
    {
        var current = o.InternalMethods.GetOwnProperty(p);
        var extensible = TestingAndComparitionOperations.IsExtensible(o);

        return ValidateAndApplyPropertyDescriptor(o, p, extensible, desc, current);
    }

    public static bool IsCompatiblePropertyDescriptor(bool extensible, PropertyDescriptor desc, PropertyDescriptor? current)
    {
        return ValidateAndApplyPropertyDescriptor(null, new EsString(""), extensible, desc, current);
    }

    public static bool ValidateAndApplyPropertyDescriptor(EsObject? o, EsValue p, bool extensible, PropertyDescriptor desc, PropertyDescriptor? current)
    {
        if (p is not EsString && p is not EsSymbol)
        {
            throw new ArgumentException("Key must be StringValue or SymbolValue", nameof(p));
        }

        if (current == null)
        {
            if (extensible == false)
            {
                return false;
            }

            if (o == null)
            {
                return true;
            }

            if (PropertyDescriptor.IsAccessorDescriptor(desc) == true)
            {
                o.Properties.Set(p, new PropertyDescriptor
                {
                    Get = desc.Get,
                    Set = desc.Set,
                    Enumerable = desc.Enumerable ?? false,
                    Configurable = desc.Configurable ?? false,
                });
            }
            else
            {
                o.Properties.Set(p, new PropertyDescriptor
                {
                    Value = desc.Value,
                    Writable = desc.Writable ?? false,
                    Enumerable = desc.Enumerable ?? false,
                    Configurable = desc.Configurable ?? false,
                });
            }

            return true;
        }

        if (PropertyDescriptor.IsDataDescriptor(current) && (current.Value == null || current.Writable == null || current.Enumerable == null || current.Configurable == null))
        {
            throw new InvalidOperationException("Current property descriptor is not fully populated.");
        }

        if (PropertyDescriptor.IsAccessorDescriptor(current) && (current.Get == null || current.Set == null || current.Enumerable == null || current.Configurable == null))
        {
            throw new InvalidOperationException("Current property descriptor is not fully populated.");
        }

        if (desc.Value == null && desc.Writable == null && desc.Get == null && desc.Set == null && desc.Enumerable == null && desc.Configurable == null)
        {
            return true;
        }

        if (current.Configurable == false)
        {
            if (desc.Configurable != null && desc.Configurable == true)
            {
                return false;
            }

            if (desc.Enumerable != null && desc.Enumerable != current.Enumerable)
            {
                return false;
            }

            if (PropertyDescriptor.IsGenericDescriptor(desc) == false && PropertyDescriptor.IsAccessorDescriptor(desc) != PropertyDescriptor.IsAccessorDescriptor(current))
            {
                return false;
            }

            if (PropertyDescriptor.IsAccessorDescriptor(current) == true)
            {
                if (desc.Get != null && TestingAndComparitionOperations.SameValue(desc.Get ?? (EsValue)EsUndefined.Instance, current.Get ?? (EsValue)EsUndefined.Instance) == false)
                {
                    return false;
                }

                if (desc.Set != null && TestingAndComparitionOperations.SameValue(desc.Set ?? (EsValue)EsUndefined.Instance, current.Set ?? (EsValue)EsUndefined.Instance) == false)
                {
                    return false;
                }
            }
            else if (current.Writable == false)
            {
                if (desc.Writable != null && desc.Writable == true)
                {
                    return false;
                }

                if (desc.Value != null)
                {
                    return TestingAndComparitionOperations.SameValue(desc.Value, current.Value ?? EsUndefined.Instance);
                }
            }
        }

        if (o != null)
        {
            if (PropertyDescriptor.IsDataDescriptor(current) == true && PropertyDescriptor.IsAccessorDescriptor(desc) == true)
            {
                bool? configurable = null;
                bool? enumerable = null;

                if (desc.Configurable != null)
                {
                    configurable = desc.Configurable;
                }
                else
                {
                    configurable = current.Configurable;
                }

                if (desc.Enumerable != null)
                {
                    enumerable = desc.Enumerable;
                }
                else
                {
                    enumerable = current.Enumerable;
                }

                o.Properties.Set(p, new PropertyDescriptor
                {
                    Configurable = configurable,
                    Enumerable = enumerable,
                    Get = desc.Get,
                    Set = desc.Set,
                });
            }
            else if (PropertyDescriptor.IsAccessorDescriptor(current) == true && PropertyDescriptor.IsDataDescriptor(desc) == true)
            {
                bool? configurable = null;
                bool? enumerable = null;

                if (desc.Configurable != null)
                {
                    configurable = desc.Configurable;
                }
                else
                {
                    configurable = current.Configurable;
                }

                if (desc.Enumerable != null)
                {
                    enumerable = desc.Enumerable;
                }
                else
                {
                    enumerable = current.Enumerable;
                }

                o.Properties.Set(p, new PropertyDescriptor
                {
                    Configurable = configurable,
                    Enumerable = enumerable,
                    Value = desc.Value,
                    Writable = desc.Writable ?? false,
                });
            }
            else
            {
                o.Properties.Set(p, new PropertyDescriptor
                {
                    Value = desc.Value,
                    Writable = desc.Writable,
                    Get = desc.Get,
                    Set = desc.Set,
                    Configurable = desc.Writable,
                    Enumerable = desc.Enumerable,
                });
            }
        }

        return true;
    }

    public static bool OrdinaryHasProperty(EsObject o, EsValue p)
    {
        var hasOwn = o.InternalMethods.GetOwnProperty(p);

        if (hasOwn != null)
        {
            return true;
        }

        var parent = o.InternalMethods.GetPrototypeOf();

        if (parent != null)
        {
            return parent.InternalMethods.HasProperty(p);
        }

        return false;
    }

    public static EsValue OrdinaryGet(EsObject o, EsValue p, EsValue receiver)
    {
        var desc = o.InternalMethods.GetOwnProperty(p);

        if (desc == null)
        {
            var parent = o.InternalMethods.GetPrototypeOf();

            if (parent == null)
            {
                return EsUndefined.Instance;
            }

            return parent.InternalMethods.Get(p, receiver);
        }

        if (PropertyDescriptor.IsDataDescriptor(desc) == true)
        {
            return desc.Value ?? EsUndefined.Instance;
        }

        if (PropertyDescriptor.IsAccessorDescriptor(desc) != true)
        {
            throw new InvalidOperationException("Invalid property descriptor type.");

        }

        var getter = desc.Get;

        if (getter == null)
        {
            return EsUndefined.Instance;
        }

        return ObjectOperations.Call(getter, receiver);

    }

    public static bool OrdinarySet(EsObject o, EsValue p, EsValue v, EsValue receiver)
    {
        var ownDesc = o.InternalMethods.GetOwnProperty(p);

        return OrdinarySetWithOwnDescriptor(o, p, v, receiver, ownDesc);
    }

    public static bool OrdinarySetWithOwnDescriptor(EsObject o, EsValue p, EsValue v, EsValue receiver, PropertyDescriptor? ownDesc)
    {
        if (ownDesc == null)
        {
            var parent = o.InternalMethods.GetPrototypeOf();

            if (parent != null)
            {
                return parent.InternalMethods.Set(p, v, receiver);
            }
            else
            {
                ownDesc = new PropertyDescriptor
                {
                    Value = EsUndefined.Instance,
                    Writable = true,
                    Enumerable = true,
                    Configurable = true,
                };
            }
        }

        if (PropertyDescriptor.IsDataDescriptor(ownDesc) == true)
        {
            if (ownDesc.Writable == false)
            {
                return false;
            }

            if (receiver is not EsObject objectReceiver)
            {
                return false;
            }

            var existingDescriptor = objectReceiver.InternalMethods.GetOwnProperty(p);

            if (existingDescriptor != null)
            {
                if (PropertyDescriptor.IsAccessorDescriptor(existingDescriptor))
                {
                    return false;
                }

                if (existingDescriptor.Writable == false)
                {
                    return false;
                }

                var valueDesc = new PropertyDescriptor
                {
                    Value = v,
                };

                return objectReceiver.InternalMethods.DefineOwnProperty(p, valueDesc);
            }
            else
            {
                if (objectReceiver.Properties.Has(p))
                {
                    throw new InvalidOperationException("Existing property is not configurable.");
                }

                return ObjectOperations.CreateDataProperty(objectReceiver, p, v);
            }
        }

        if (!PropertyDescriptor.IsAccessorDescriptor(ownDesc))
        {
            throw new InvalidOperationException("Invalid property descriptor type.");
        }

        var setter = ownDesc.Set;

        if (setter == null)
        {
            return false;
        }

        ObjectOperations.Call(setter, receiver, new EsList([v]));

        return true;
    }

    public static bool OrdinaryDelete(EsObject o, EsValue p)
    {
        var desc = o.InternalMethods.GetOwnProperty(p);

        if (desc == null)
        {
            return true;
        }

        if (desc.Configurable == true)
        {
            o.Properties.Delete(p);
            return true;
        }

        return false;
    }

    public static List<EsValue> OrdinaryOwnPropertyKeys(EsObject o)
    {
        var keys = new List<EsValue>();

        foreach (var key in o.Properties.ArrayKeys)
        {
            keys.Add(key);
        }

        foreach (var key in o.Properties.StringKeys)
        {
            keys.Add(key);
        }

        foreach (var key in o.Properties.SymbolKeys)
        {
            keys.Add(key);
        }

        return keys;
    }

    public static EsObject OrdinaryObjectCreate(EsObject? proto, List<IInternalSlot>? additionalInternalSlotsList = null)
    {
        var internalSlotsList = new List<IInternalSlot> { new PrototypeInternalSlot(), new ExtensibleInternalSlot() };

        if (additionalInternalSlotsList != null)
        {
            internalSlotsList.AddRange(additionalInternalSlotsList);
        }

        var o = ObjectOperations.MakeBasicObject(internalSlotsList);
        o.InternalSlots.Get<PrototypeInternalSlot>().Value = proto;

        return o;
    }

    public static EsObject OrdinaryCreateFromConstructor(EsObject constructor, EsString? intrinsicDefaultProto, List<string>? internalSlotsList = null)
    {
        throw new NotImplementedException();
    }

    public static EsObject GetPrototypeFromConstructor(EsObject constructor, EsString intrinsicDefaultProto)
    {
        throw new NotImplementedException();
    }

    public static void RequireInternalSlot<TInternalSlot>(EsValue o) where TInternalSlot : IInternalSlot
    {
        if (o is not EsObject obj)
        {
            throw new TypeError("TypeError: Object expected");
        }

        if (!obj.InternalSlots.Has<TInternalSlot>())
        {
            throw new TypeError($"TypeError: Object does not have required internal slot '{typeof(TInternalSlot).Name}'");
        }
    }
}