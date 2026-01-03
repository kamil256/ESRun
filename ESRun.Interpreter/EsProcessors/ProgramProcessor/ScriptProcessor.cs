using Esprima.Ast;
using EsRun.Specification.LanguageTypes.Abstract;
using EsRun.Specification.LanguageTypes.Concrete;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsScope;

namespace ESRun.Interpreter.EsProcessors.ProgramProcessor;

public class ScriptProcessor : INodeProcessor<Script, EsValue>
{
    protected readonly Lazy<INodeProcessor<Statement, EsValue>> _statementProcessor;

    public ScriptProcessor(Lazy<INodeProcessor<Statement, EsValue>> statementProcessor)
    {
        _statementProcessor = statementProcessor;
    }

    public EsValue Process(Script script, Scope scope)
    {
        foreach (var statementNode in script.Body)
        {
            _statementProcessor.Value.Process(statementNode, scope);

        }

        return EsUndefined.Instance;
    }
}