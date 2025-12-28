using Esprima.Ast;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsTypes.Function;

namespace ESRun.Interpreter.EsProcessors;

public class ArrowFunctionExpressionProcessor : INodeProcessor<ArrowFunctionExpression, FunctionValue>
{
    public FunctionValue Process(ArrowFunctionExpression node, Scope scope)
    {
        if (node.Body is not BlockStatement blockStatement)
        {
            throw new NotImplementedException("Only block statement bodies are supported in arrow functions.");
        }

        var arrowFunctionValue = new FunctionValue(true, scope, blockStatement)
        {
        };

        return arrowFunctionValue;
    }
}