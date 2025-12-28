using Esprima.Ast;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.Undefined;

namespace ESRun.Interpreter.EsProcessors;

public class ExpressionStatementProcessor : INodeProcessor<ExpressionStatement, EsValue>
{
    protected readonly Lazy<INodeProcessor<CallExpression, EsValue>> _callExpressionProcessor;

    public ExpressionStatementProcessor(Lazy<INodeProcessor<CallExpression, EsValue>> callExpressionProcessor)
    {
        _callExpressionProcessor = callExpressionProcessor;
    }

    public EsValue Process(ExpressionStatement expressionStatement, Scope scope)
    {
        switch (expressionStatement.Expression)
        {
            case CallExpression callExpression:
                _callExpressionProcessor.Value.Process(callExpression, scope);
                break;
            default:
                throw new NotImplementedException($"Node type '{expressionStatement.Type}' is not supported yet.");
        }

        return UndefinedValue.Singleton;
    }
}