using Esprima.Ast;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsScope;
using ESRun.Interpreter.EsTypes.Abstract;

namespace ESRun.Interpreter.EsProcessors;

public class MemberExpressionProcessor : INodeProcessor<MemberExpression, EsValue>
{
    private readonly Lazy<INodeProcessor<StaticMemberExpression, EsValue>> _staticMemberExpressionProcessor;

    public MemberExpressionProcessor(Lazy<INodeProcessor<StaticMemberExpression, EsValue>> staticMemberExpressionProcessor)
    {
        _staticMemberExpressionProcessor = staticMemberExpressionProcessor;
    }

    public EsValue Process(MemberExpression node, Scope scope)
    {
        switch (node)
        {
            case StaticMemberExpression staticMemberExpressionNode:
                return _staticMemberExpressionProcessor.Value.Process(staticMemberExpressionNode, scope);
            default:
                throw new NotImplementedException($"Node type '{node.Type}' is not supported yet.");
        }
    }

}
