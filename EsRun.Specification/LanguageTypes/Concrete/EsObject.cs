using EsRun.Specification.LanguageTypes.Abstract;
using EsRun.Specification.ObjectBehaviours.InternalMethods;
using EsRun.Specification.ObjectBehaviours.InternalMethods.Abstract;
using EsRun.Specification.ObjectBehaviours.InternalSlots;
using EsRun.Specification.ObjectBehaviours.PropertyStorages.Abstract;
using EsRun.Specification.ObjectBehaviours.PropertyStorages.Concrete;

namespace EsRun.Specification.LanguageTypes.Concrete;

public class EsObject : EsValue
{
    public IPropertyStorage Properties { get; private set; }
    public InternalSlotsStorage InternalSlots { get; private set; }
    public IInternalMethods InternalMethods { get; private set; }

    private EsObject(
        IPropertyStorage properties,
        InternalSlotsStorage internalSlots,
        Func<EsObject, IInternalMethods> internalMethodsFactory
        )
    {
        Properties = properties;
        InternalSlots = internalSlots;
        InternalMethods = internalMethodsFactory(this);
    }

    public static EsObject CreateOrdinary(List<IInternalSlot> internalSlots)
    {
        return new EsObject(
            new OrdinaryPropertyStorage(),
            new InternalSlotsStorage(internalSlots),
            obj => new OrdinaryInternalMethods(obj)
        );
    }

    // public override EsObject Clone()
    // {
    //     return this;
    // }

    // public override string ToString(int nestingLevel)
    // {
    //     var result = "Object";
    //     var indentation = new string(' ', 2 * (nestingLevel + 1));

    //     foreach (var property in _properties)
    //     {
    //         var descriptor = property.Value;

    //         if (descriptor is DataPropertyDescriptor dataPropertyDescriptor)
    //         {
    //             result += $"\r\n{indentation}{property.Key.ToString(0)}: {dataPropertyDescriptor.Value.ToString(nestingLevel + 1)}";
    //         }
    //     }

    //     return result;
    // }
}