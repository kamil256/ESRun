using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.Undefined;

namespace ESRun.Interpreter.EsTypes.Object;

public class ObjectValue : EsValue
{
    public Dictionary<string, SimplePropertyDescriptor> Properties { get; set; } = new Dictionary<string, SimplePropertyDescriptor>();

    public EsValue GetPropertyValue(string propertyName)
    {
        if (Properties.TryGetValue(propertyName, out var propertyDescriptor))
        {
            return propertyDescriptor.Value;
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
            result += $"\r\n{indentation}{property.Key}: {property.Value.Value.ToString(nestingLevel + 1)}";
        }

        return result;
    }
}