using Esprima.Ast;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.Undefined;

namespace ESRun.Interpreter.EsProcessors;

public class BlockStatementProcessor : INodeProcessor<BlockStatement, EsValue>
{
    protected readonly Lazy<INodeProcessor<Statement, EsValue>> _statementProcessor;

    public BlockStatementProcessor(Lazy<INodeProcessor<Statement, EsValue>> statementProcessor)
    {
        _statementProcessor = statementProcessor;
    }

    public EsValue Process(BlockStatement node, Scope scope)
    {
        var nestedScope = new Scope(scope);

        foreach (var statementNode in node.Body)
        {
            _statementProcessor.Value.Process(statementNode, nestedScope);
        }

        return UndefinedValue.Singleton;
    }
}