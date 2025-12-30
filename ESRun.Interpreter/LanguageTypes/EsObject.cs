using ESRun.Interpreter.ObjectBehaviours.InternalMethods;
using ESRun.Interpreter.ObjectBehaviours.PropertyStorage;

namespace ESRun.Interpreter.LanguageTypes;

public class EsObject : EsValue
{
    public IPropertyStorage Properties { get; private set; }
    public IInternalMethods InternalMethods { get; private set; }
    public readonly Dictionary<string, EsValue?> InternalSlots = new();

    public EsObject(
        IPropertyStorage properties,
        IInternalMethods internalMethods,
        Dictionary<string, EsValue?> internalSlots)
    {
        Properties = properties;
        InternalMethods = internalMethods;
        InternalSlots = internalSlots;
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