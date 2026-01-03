using Esprima.Ast;
using ESRun.Interpreter.Errors;
using ESRun.Interpreter.LanguageTypes;

namespace ESRun.Interpreter.EsScope;

public class Scope
{
    public Scope(Scope? parent = null)
    {
        Parent = parent;
    }

    public Scope? Parent { get; }

    public Dictionary<string, Variable> Variables { get; } = new Dictionary<string, Variable>();

    public Variable? GetVariable(string identifier, bool mustExist)
    {
        if (Variables.TryGetValue(identifier, out var variable))
        {
            return variable;
        }

        if (Parent != null)
        {
            return Parent.GetVariable(identifier, mustExist);
        }

        return !mustExist ? null : throw new ReferenceError(identifier);
    }

    // TODO: distinguish between declaration and assignment
    public EsValue SetVariable(string identifier, VariableDeclarationKind kind, EsValue? value)
    {
        Variables.TryGetValue(identifier, out var existingVariable);

        if (existingVariable != null)
        {
            if (Variables.ContainsKey(identifier) && (!CanVariableKindBeRedeclared(existingVariable.Kind) || !CanVariableKindBeRedeclared(kind)))
            {
                throw new SyntaxError($"redeclaration of {existingVariable.Kind.ToString().ToLower()} {identifier}");
            }

            existingVariable.Value = value ?? EsUndefined.Instance;

            return existingVariable.Value;
        }

        var newVariable = new Variable(identifier, kind, value);
        Variables[identifier] = newVariable;

        return newVariable.Value;
    }

    private bool CanVariableKindBeRedeclared(VariableDeclarationKind kind)
    {
        if (kind == VariableDeclarationKind.Var)
        {
            return true;
        }

        return false;
    }
}

