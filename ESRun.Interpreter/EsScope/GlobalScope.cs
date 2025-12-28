using Esprima.Ast;
using ESRun.Interpreter.EsBuildInObjects;

namespace ESRun.Interpreter.EsScope;

public class GlobalScope : Scope
{
    private static GlobalScope? _instance;

    private GlobalScope() : base(null)
    {
        Variables["globalThis"] = new Variable("globalThis", VariableDeclarationKind.Const, GlobalObject.Instance);
    }

    public static GlobalScope Instance => _instance ??= new GlobalScope();
}