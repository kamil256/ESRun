using Esprima.Ast;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.Number;
using ESRun.Interpreter.EsTypes.Undefined;

namespace ESRun.Interpreter.EsProcessors;

public class LiteralProcessor : INodeProcessor<Literal, EsValue>
{
    public EsValue Process(Literal node, Scope scope)
    {
        switch (node.TokenType)
        {
            case Esprima.TokenType.NumericLiteral when node.Raw is not null:
                return new NumberValue(node.Raw);
        }

        return UndefinedValue.Singleton;
    }
}