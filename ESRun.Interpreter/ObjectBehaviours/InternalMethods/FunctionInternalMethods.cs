using ESRun.Interpreter.LanguageTypes;

namespace ESRun.Interpreter.ObjectBehaviours.InternalMethods;

public class FunctionInternalMethods : OrdinaryInternalMethods
{
    public override EsObject Owner { get; }

    public FunctionInternalMethods(EsObject owner) : base(owner)
    {
        Owner = owner;
    }

    public EsValue Call(EsValue v, EsList argumentsList)
    {
        throw new NotImplementedException();
    }
}