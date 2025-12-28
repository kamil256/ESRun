using Esprima.Ast;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsScope;
using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.Function;
using ESRun.Interpreter.EsTypes.Object;

namespace ESRun.Interpreter.EsProcessors;

public class PropertyProcessor : INodeProcessor<Property, KeyValuePair<string, SimplePropertyDescriptor>>
{
    protected readonly Lazy<INodeProcessor<FunctionExpression, FunctionValue>> _functionExpressionProcessor;
    protected readonly Lazy<INodeProcessor<Literal, EsValue>> _literalProcessor;
    protected readonly Lazy<INodeProcessor<ObjectExpression, EsValue>> _objectExpressionProcessor;

    public PropertyProcessor(Lazy<INodeProcessor<FunctionExpression, FunctionValue>> functionExpressionProcessor,
        Lazy<INodeProcessor<Literal, EsValue>> literalProcessor,
        Lazy<INodeProcessor<ObjectExpression, EsValue>> objectExpressionProcessor)
    {
        _objectExpressionProcessor = objectExpressionProcessor;
        _literalProcessor = literalProcessor;
        _functionExpressionProcessor = functionExpressionProcessor;
    }

    public KeyValuePair<string, SimplePropertyDescriptor> Process(Property node, Scope scope)
    {
        if (node.Key is not Identifier identifierNode)
        {
            throw new NotImplementedException("Only identifier keys are supported in object expressions.");
        }

        var identifier = identifierNode.Name;
        var value = GetValue(node.Value, scope);

        return new KeyValuePair<string, SimplePropertyDescriptor>(identifier, new SimplePropertyDescriptor(value));
    }

    private EsValue GetValue(Node node, Scope scope)
    {
        switch (node)
        {
            case ObjectExpression objectExpressionNode:
                return _objectExpressionProcessor.Value.Process(objectExpressionNode, scope);
            case Literal literalNode:
                return _literalProcessor.Value.Process(literalNode, scope);
            case FunctionExpression functionExpressionNode:
                return _functionExpressionProcessor.Value.Process(functionExpressionNode, scope);
            default:
                throw new NotImplementedException($"Object expression type '{node.Type}' is not supported yet.");
        }
    }
}