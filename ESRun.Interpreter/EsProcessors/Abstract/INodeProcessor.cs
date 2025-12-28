using Esprima.Ast;
using ESRun.Interpreter.EsScope;

namespace ESRun.Interpreter.EsProcessors.Abstract;

public interface INodeProcessor<TNode, TResult> where TNode : Node
{
    TResult Process(TNode node, Scope scope);
}