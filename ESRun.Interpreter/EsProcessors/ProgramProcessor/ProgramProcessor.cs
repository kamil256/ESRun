using Esprima.Ast;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsScope;
using ESRun.Interpreter.LanguageTypes;

namespace ESRun.Interpreter.EsProcessors;

public class ProgramProcessor : INodeProcessor<Program, EsValue>
{
    private readonly Lazy<INodeProcessor<Script, EsValue>> _scriptProcessor;

    public ProgramProcessor(Lazy<INodeProcessor<Script, EsValue>> scriptProcessor)
    {
        _scriptProcessor = scriptProcessor;
    }

    public EsValue Process(Program node, Scope scope)
    {
        switch (node)
        {
            case Script scriptNode:
                return _scriptProcessor.Value.Process(scriptNode, scope);
            default:
                throw new NotImplementedException($"Node type '{node.Type}' is not supported yet.");
        }
    }
}