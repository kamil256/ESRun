using ESRun.Interpreter.LanguageTypes;

namespace ESRun.Interpreter.Operations;

public static class TypeConversions
{
    public static EsBoolean ToBoolean(EsValue argument)
    {
        if (argument is EsBoolean booleanValue)
        {
            return booleanValue;
        }

        if (argument is EsUndefined ||
            argument is EsNull ||
            (argument is EsNumber numberValue && numberValue.IsNaNOrZero()) ||
            argument is EsString stringValue && stringValue.Length == 0)
        {
            return EsBoolean.FalseInstance;
        }

        return EsBoolean.TrueInstance;
    }
}