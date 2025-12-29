using ESRun.Interpreter.EsScope;
using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.Object;

namespace ESRun.Interpreter.EsTypes.Function;

public class FunctionValue : ObjectValue
{
    public FunctionValue(Func<EsValue[], EsValue> call, Scope scope)
    {
        Call = call;
        Scope = scope;
    }

    public Func<EsValue[], EsValue> Call { get; set; }

    public Scope Scope { get; set; }

    public override string ToString(int nestingLevel)
    {
        var temporaryConstructorName = "Object";
        var result = $"function {temporaryConstructorName}()";
        var indentation = new string(' ', 2 * (nestingLevel + 1));

        foreach (var property in Properties)
        {
            var descriptor = property.Value;

            if (descriptor is DataPropertyDescriptor dataPropertyDescriptor)
            {
                if (dataPropertyDescriptor.Value is ObjectValue nestedObject)
                {
                    result += $"{indentation}{property.Key}: ";
                    result += nestedObject.ToString(nestingLevel + 1);
                }
                else
                {
                    result += $"\r\n{indentation}{property.Key}: {dataPropertyDescriptor.Value}";
                }
            }
        }

        return result;
    }
}