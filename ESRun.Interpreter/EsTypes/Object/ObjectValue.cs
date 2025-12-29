using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.String;
using ESRun.Interpreter.EsTypes.Symbol;
using ESRun.Interpreter.EsTypes.Undefined;

namespace ESRun.Interpreter.EsTypes.Object;

public class ObjectValue : EsValue
{
    public Dictionary<StringValue, PropertyDescriptor> Properties { get; set; } = new Dictionary<StringValue, PropertyDescriptor>();
    public Dictionary<SymbolValue, PropertyDescriptor> SymbolProperties { get; set; } = new Dictionary<SymbolValue, PropertyDescriptor>();

    public EsValue GetPropertyValue(StringValue propertyName)
    {
        var propertyKey = Properties.Keys.FirstOrDefault(k => k.ToString() == propertyName.ToString());

        if (propertyKey != null)
        {
            if (Properties[propertyKey] is DataPropertyDescriptor dataPropertyDescriptor)
            {
                return dataPropertyDescriptor.Value;
            }
        }

        return UndefinedValue.Instance;
    }

    public override ObjectValue Clone()
    {
        return this;
    }

    public override string ToString(int nestingLevel)
    {
        var result = "Object";
        var indentation = new string(' ', 2 * (nestingLevel + 1));

        foreach (var property in Properties)
        {
            var descriptor = property.Value;

            if (descriptor is DataPropertyDescriptor dataPropertyDescriptor)
            {
                result += $"\r\n{indentation}{property.Key.ToString(0)}: {dataPropertyDescriptor.Value.ToString(nestingLevel + 1)}";
            }
        }

        return result;
    }
}