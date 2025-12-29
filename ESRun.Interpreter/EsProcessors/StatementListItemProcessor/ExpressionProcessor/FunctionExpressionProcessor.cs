using Esprima.Ast;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsScope;
using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.Function;

namespace ESRun.Interpreter.EsProcessors;

public class FunctionExpressionProcessor : INodeProcessor<FunctionExpression, FunctionValue>
{
    private readonly Lazy<INodeProcessor<BlockStatement, EsValue>> _blockStatementProcessor;

    public FunctionExpressionProcessor(
        Lazy<INodeProcessor<BlockStatement, EsValue>> blockStatementProcessor)
    {
        _blockStatementProcessor = blockStatementProcessor;
    }

    public FunctionValue Process(FunctionExpression node, Scope scope)
    {
        var call = new Func<EsValue, EsValue[], EsValue>((thisContext, _arguments) => _blockStatementProcessor.Value.Process(node.Body, scope));

        return new FunctionValue(call, scope);
    }
}