using EsRun.Specification.LanguageTypes.Abstract;
using EsRun.Specification.LanguageTypes.Concrete;

namespace EsRun.Specification.Operations;

public static class TypeConversion
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