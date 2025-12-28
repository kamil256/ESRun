using Esprima.Ast;
using Esprima.Utils;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.Object;

namespace ESRun.Interpreter.EsProcessors;

public class StaticMemberExpressionProcessor : INodeProcessor<StaticMemberExpression, EsValue>
{
    private readonly Lazy<INodeProcessor<MemberExpression, EsValue>> _memberExpressionProcessor;

    public StaticMemberExpressionProcessor(Lazy<INodeProcessor<MemberExpression, EsValue>> memberExpressionProcessor)
    {
        _memberExpressionProcessor = memberExpressionProcessor;
    }

    public EsValue Process(StaticMemberExpression node, Scope scope)
    {
        if (node.Property is not Identifier propertyIdentifierNode)
        {
            throw new NotImplementedException("Only identifier objects are supported in member expressions.");
        }

        var propertyIdentifier = propertyIdentifierNode.Name;

        switch (node.Object)
        {
            case Identifier identifierNode:
                {
                    var objectIdentifier = identifierNode.Name;
                    var objectValue = scope.GetVariable(objectIdentifier, true)?.Value;

                    if (objectValue is not ObjectValue existingOjectValue)
                    {
                        throw new Exception($"Variable '{objectIdentifier}' is not an object.");
                    }

                    return existingOjectValue.GetPropertyValue(propertyIdentifier);
                }
            case StaticMemberExpression memberExpressionNode:
                {
                    var objectValue = _memberExpressionProcessor.Value.Process(memberExpressionNode, scope);

                    if (objectValue is not ObjectValue existingOjectValue)
                    {
                        throw new Exception($"Member expression does not evaluate to an object.");
                    }

                    return existingOjectValue.GetPropertyValue(propertyIdentifier);
                }
            default:
                throw new NotImplementedException($"Member expression object type '{node.Object.Type}' is not supported yet.");
        }
    }
}