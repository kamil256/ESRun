using ESRun.Interpreter.EsScope;
using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.Object;
using ESRun.Interpreter.SpecificationTypes.CompletionRecord;

namespace ESRun.Interpreter.EsTypes.Function;

public class ConstructorFunctionValue : FunctionValue
{
    private Func<EsValue[], ObjectValue, ObjectValue> _construct;

    public ConstructorFunctionValue(Func<EsValue[], ObjectValue, ObjectValue> construct, Func<EsValue, EsValue[], EsValue> call, Scope scope) : base(call, scope)
    {
        _construct = construct;
    }

    public CompletionRecord<ObjectValue> Construct(EsValue[] arguments, ObjectValue newTarget)
    {
        var result = _construct(arguments, newTarget);

        return CompletionRecord<ObjectValue>.NormalCompletion(result);
    }
}