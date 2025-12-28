using Esprima.Ast;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.Undefined;

namespace ESRun.Interpreter.EsProcessors;

public class VariableDeclarationProcessor : INodeProcessor<VariableDeclaration, EsValue>
{
    private readonly Lazy<INodeProcessor<VariableDeclarator, KeyValuePair<string, EsValue>>> _variableDeclaratorProcessor;

    public VariableDeclarationProcessor(
        Lazy<INodeProcessor<VariableDeclarator, KeyValuePair<string, EsValue>>> variableDeclaratorProcessor)
    {
        _variableDeclaratorProcessor = variableDeclaratorProcessor;
    }

    public EsValue Process(VariableDeclaration node, Scope scope)
    {
        foreach (var declaratorNode in node.Declarations)
        {
            var (identifier, value) = _variableDeclaratorProcessor.Value.Process(declaratorNode, scope);
            scope.SetVariable(identifier, node.Kind, value);
        }

        return UndefinedValue.Singleton;
    }
}