using Esprima.Ast;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsTypes.Function;

namespace ESRun.Interpreter.EsProcessors;

public class FunctionExpressionProcessor : INodeProcessor<FunctionExpression, FunctionValue>
{
    public FunctionValue Process(FunctionExpression node, Scope scope)
    {
        var functionValue = new FunctionValue(false, scope, node.Body)
        {
        };

        return functionValue;
    }
}