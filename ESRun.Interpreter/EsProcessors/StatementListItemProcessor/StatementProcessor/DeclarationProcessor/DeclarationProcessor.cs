using Esprima.Ast;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsTypes.Abstract;

namespace ESRun.Interpreter.EsProcessors;

public class DeclarationProcessor : INodeProcessor<Declaration, EsValue>
{
    private readonly Lazy<INodeProcessor<VariableDeclaration, EsValue>> _variableDeclarationProcessor;

    public DeclarationProcessor(Lazy<INodeProcessor<VariableDeclaration, EsValue>> variableDeclarationProcessor)
    {
        _variableDeclarationProcessor = variableDeclarationProcessor;
    }

    public EsValue Process(Declaration node, Scope scope)
    {
        switch (node)
        {
            case VariableDeclaration declarationNode:
                return _variableDeclarationProcessor.Value.Process(declarationNode, scope);
            default:
                throw new NotImplementedException($"Node type '{node.Type}' is not supported yet.");
        }
    }
}