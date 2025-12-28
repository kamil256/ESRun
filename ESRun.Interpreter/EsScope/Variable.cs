using Esprima.Ast;
using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.Undefined;

namespace ESRun.Interpreter.EsScope;

public class Variable
{
    public Variable(string identifier, VariableDeclarationKind kind, EsValue? value)
    {
        Identifier = identifier;
        Kind = kind;
        Value = value ?? UndefinedValue.Instance;
    }

    public string Identifier { get; }

    public VariableDeclarationKind Kind { get; set; }

    public EsValue Value { get; set; }
}