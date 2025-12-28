using Esprima.Ast;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsScope;
using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.Object;

namespace ESRun.Interpreter.EsProcessors;

public class ObjectExpressionProcessor : INodeProcessor<ObjectExpression, EsValue>
{
    protected readonly Lazy<INodeProcessor<Property, KeyValuePair<string, SimplePropertyDescriptor>>> _propertyProcessor;

    public ObjectExpressionProcessor(
        Lazy<INodeProcessor<Property, KeyValuePair<string, SimplePropertyDescriptor>>> propertyProcessor)
    {
        _propertyProcessor = propertyProcessor;
    }

    public EsValue Process(ObjectExpression node, Scope scope)
    {
        var objectValue = new ObjectValue();

        foreach (var property in node.Properties)
        {
            if (property is not Property propertyNode)
            {
                throw new NotImplementedException("Only standard properties are supported in object expressions.");
            }

            var (identifier, propertyDescriptor) = _propertyProcessor.Value.Process(propertyNode, scope);

            objectValue.Properties.Add(identifier, propertyDescriptor);
        }

        return objectValue;
    }
}