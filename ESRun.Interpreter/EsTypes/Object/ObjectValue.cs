using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.String;
using ESRun.Interpreter.EsTypes.Symbol;
using ESRun.Interpreter.EsTypes.Undefined;
using ESRun.Interpreter.SpecificationTypes.CompletionRecord;

namespace ESRun.Interpreter.EsTypes.Object;

public class ObjectValue : EsValue
{
    protected Dictionary<StringValue, PropertyDescriptor> _properties = new Dictionary<StringValue, PropertyDescriptor>();
    protected Dictionary<SymbolValue, PropertyDescriptor> _symbolProperties = new Dictionary<SymbolValue, PropertyDescriptor>();

    public EsValue GetPropertyValue(StringValue propertyName)
    {
        var propertyKey = _properties.Keys.FirstOrDefault(k => k.Equals(propertyName));

        if (propertyKey != null)
        {
            if (_properties[propertyKey] is DataPropertyDescriptor dataPropertyDescriptor)
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

        foreach (var property in _properties)
        {
            var descriptor = property.Value;

            if (descriptor is DataPropertyDescriptor dataPropertyDescriptor)
            {
                result += $"\r\n{indentation}{property.Key.ToString(0)}: {dataPropertyDescriptor.Value.ToString(nestingLevel + 1)}";
            }
        }

        return result;
    }

    private ObjectValue? _prototype = null;
    private bool _isExtensible = true;

    public CompletionRecord<ObjectValue?> GetPrototypeOf()
    {
        return CompletionRecord<ObjectValue?>.NormalCompletion(_prototype);
    }

    public CompletionRecord<bool> SetPrototypeOf(ObjectValue? prototype)
    {
        if (!_isExtensible && _prototype != prototype)
        {
            return CompletionRecord<bool>.NormalCompletion(false);
        }

        _prototype = prototype;

        return CompletionRecord<bool>.NormalCompletion(true);
    }

    public CompletionRecord<bool> IsExtensible()
    {
        return CompletionRecord<bool>.NormalCompletion(_isExtensible);
    }

    public CompletionRecord<bool> PreventExtensions()
    {
        _isExtensible = false;

        return CompletionRecord<bool>.NormalCompletion(true);
    }

    public CompletionRecord<PropertyDescriptor?> GetOwnProperty(StringValue propertyName)
    {
        var propertyKey = _properties.Keys.FirstOrDefault(k => k.Equals(propertyName));

        if (propertyKey != null)
        {
            return CompletionRecord<PropertyDescriptor?>.NormalCompletion(_properties[propertyKey]);
        }

        return CompletionRecord<PropertyDescriptor?>.NormalCompletion(null);
    }

    public CompletionRecord<PropertyDescriptor?> GetOwnProperty(SymbolValue propertySymbol)
    {
        var propertyKey = _symbolProperties.Keys.FirstOrDefault(k => k.Equals(propertySymbol));

        if (propertyKey != null)
        {
            return CompletionRecord<PropertyDescriptor?>.NormalCompletion(_symbolProperties[propertyKey]);
        }

        return CompletionRecord<PropertyDescriptor?>.NormalCompletion(null);
    }

    public CompletionRecord<bool> DefineOwnProperty(StringValue propertyName, PropertyDescriptor descriptor)
    {
        var existingDescriptor = GetOwnProperty(propertyName).Value;

        if (existingDescriptor != null && existingDescriptor == descriptor)
        {
            return CompletionRecord<bool>.NormalCompletion(true);
        }

        if (existingDescriptor != null && !existingDescriptor.Configurable)
        {
            return CompletionRecord<bool>.NormalCompletion(false);
        }

        if (existingDescriptor == null && !IsExtensible().Value)
        {
            return CompletionRecord<bool>.NormalCompletion(false);
        }

        _properties[propertyName] = descriptor;

        return CompletionRecord<bool>.NormalCompletion(true);
    }

    public CompletionRecord<bool> DefineOwnProperty(SymbolValue propertySymbol, PropertyDescriptor descriptor)
    {
        var existingDescriptor = GetOwnProperty(propertySymbol).Value;

        if (existingDescriptor != null && existingDescriptor == descriptor)
        {
            return CompletionRecord<bool>.NormalCompletion(true);
        }

        if (existingDescriptor != null && !existingDescriptor.Configurable)
        {
            return CompletionRecord<bool>.NormalCompletion(false);
        }

        if (existingDescriptor == null && !IsExtensible().Value)
        {
            return CompletionRecord<bool>.NormalCompletion(false);
        }

        _symbolProperties[propertySymbol] = descriptor;

        return CompletionRecord<bool>.NormalCompletion(true);
    }

    public CompletionRecord<bool> HasProperty(StringValue propertyName)
    {
        var propertyKey = _properties.Keys.FirstOrDefault(k => k.Equals(propertyName));

        if (propertyKey != null)
        {
            return CompletionRecord<bool>.NormalCompletion(true);
        }

        if (GetPrototypeOf().Value is ObjectValue prototype)
        {
            return prototype.HasProperty(propertyName);
        }

        return CompletionRecord<bool>.NormalCompletion(false);
    }

    public CompletionRecord<bool> HasProperty(SymbolValue propertySymbol)
    {
        var propertyKey = _symbolProperties.Keys.FirstOrDefault(k => k.Equals(propertySymbol));

        if (propertyKey != null)
        {
            return CompletionRecord<bool>.NormalCompletion(true);
        }

        if (GetPrototypeOf().Value is ObjectValue prototype)
        {
            return prototype.HasProperty(propertySymbol);
        }

        return CompletionRecord<bool>.NormalCompletion(false);
    }

    public CompletionRecord<EsValue> Get(StringValue propertyName, EsValue? receiver = null)
    {
        var propertyKey = _properties.Keys.FirstOrDefault(k => k.Equals(propertyName));

        if (propertyKey != null)
        {
            var descriptor = _properties[propertyKey];

            if (descriptor is DataPropertyDescriptor dataPropertyDescriptor)
            {
                return CompletionRecord<EsValue>.NormalCompletion(dataPropertyDescriptor.Value);
            }
            else if (descriptor is AccessorPropertyDescriptor accessorPropertyDescriptor)
            {
                if (accessorPropertyDescriptor.Get != null)
                {
                    accessorPropertyDescriptor.Get.Call(receiver ?? this, Array.Empty<EsValue>());
                }
                else
                {
                    return CompletionRecord<EsValue>.NormalCompletion(UndefinedValue.Instance);
                }
            }
        }

        if (GetPrototypeOf().Value is ObjectValue prototype)
        {
            return prototype.Get(propertyName);
        }

        return CompletionRecord<EsValue>.NormalCompletion(UndefinedValue.Instance);
    }

    public CompletionRecord<EsValue> Get(SymbolValue propertySymbol, EsValue? receiver = null)
    {
        var propertyKey = _symbolProperties.Keys.FirstOrDefault(k => k.Equals(propertySymbol));

        if (propertyKey != null)
        {
            var descriptor = _symbolProperties[propertyKey];

            if (descriptor is DataPropertyDescriptor dataPropertyDescriptor)
            {
                return CompletionRecord<EsValue>.NormalCompletion(dataPropertyDescriptor.Value);
            }
            else if (descriptor is AccessorPropertyDescriptor accessorPropertyDescriptor)
            {
                if (accessorPropertyDescriptor.Get != null)
                {
                    accessorPropertyDescriptor.Get.Call(receiver ?? this, Array.Empty<EsValue>());
                }
                else
                {
                    return CompletionRecord<EsValue>.NormalCompletion(UndefinedValue.Instance);
                }
            }
        }

        if (GetPrototypeOf().Value is ObjectValue prototype)
        {
            return prototype.Get(propertySymbol);
        }

        return CompletionRecord<EsValue>.NormalCompletion(UndefinedValue.Instance);
    }

    public CompletionRecord<bool> Set(StringValue propertyName, EsValue value, EsValue? receiver = null)
    {
        throw new NotImplementedException();
    }

    public CompletionRecord<bool> Set(SymbolValue propertySymbol, EsValue value, EsValue? receiver = null)
    {
        throw new NotImplementedException();
    }

    public CompletionRecord<bool> Delete(StringValue propertyName)
    {
        throw new NotImplementedException();
    }

    public CompletionRecord<bool> Delete(SymbolValue propertySymbol)
    {
        throw new NotImplementedException();
    }

    public CompletionRecord<List<StringValue>> OwnPropertyKeys()
    {
        var keys = _properties.Keys.ToList();

        return CompletionRecord<List<StringValue>>.NormalCompletion(keys);
    }
}