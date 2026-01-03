using Esprima.Ast;
using EsRun.Specification.LanguageTypes.Abstract;
using EsRun.Specification.LanguageTypes.Concrete;

namespace ESRun.Interpreter.EsScope;

public class Variable
{
    public Variable(string identifier, VariableDeclarationKind kind, EsValue? value)
    {
        Identifier = identifier;
        Kind = kind;
        Value = value ?? EsUndefined.Instance;
    }

    public string Identifier { get; }

    public VariableDeclarationKind Kind { get; set; }

    public EsValue Value { get; set; }
}