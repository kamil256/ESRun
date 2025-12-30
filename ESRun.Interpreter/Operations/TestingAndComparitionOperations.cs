using ESRun.Interpreter.LanguageTypes;
using ESRun.Interpreter.ObjectBehaviours;
using ESRun.Interpreter.ObjectBehaviours.InternalMethods;

namespace ESRun.Interpreter.Operations;

public static class TestingAndComparitionOperations
{
    public static bool IsCallable(EsValue argument)
    {
        if (argument is not EsObject obj)
        {
            return false;
        }

        if (obj.InternalMethods is FunctionInternalMethods functionInternalMethods && functionInternalMethods.Call != null)
        {
            return true;
        }

        return false;
    }

    public static bool IsExtensible(EsObject o)
    {
        return o.InternalSlots[InternalSlotNames.Extensible] as EsBoolean == EsBoolean.TrueInstance;
    }

    public static bool SameType(EsValue x, EsValue y)
    {
        if (x is EsNull && y is EsNull)
        {
            return true;
        }

        if (x is EsUndefined && y is EsUndefined)
        {
            return true;
        }

        if (x is EsBoolean && y is EsBoolean)
        {
            return true;
        }

        if (x is EsNumber && y is EsNumber)
        {
            return true;
        }

        if (x is EsSymbol && y is EsSymbol)
        {
            return true;
        }

        if (x is EsString && y is EsString)
        {
            return true;
        }

        if (x is EsObject && y is EsObject)
        {
            return true;
        }

        return false;
    }

    public static bool SameValue(EsValue x, EsValue y)
    {
        if (SameType(x, y) == false)
        {
            return false;
        }

        if (x is EsNumber numberX && y is EsNumber numbery)
        {
            return EsNumber.SameValue(numberX, numbery);
        }

        return SameValueNonNumber(x, y);
    }

    public static bool SameValueNonNumber(EsValue x, EsValue y)
    {
        if (SameType(x, y) != true)
        {
            throw new InvalidOperationException("SameValueNonNumber called with different types");
        }

        if (x is EsUndefined || x is EsNull)
        {
            return true;
        }

        // if (x is EsBigInt bigIntX && y is EsBigInt bigIntY)
        // {
        //     return EsBigInt.Equals(bigIntX, bigIntY);
        // }

        if (x is EsString stringX && y is EsString stringY)
        {
            return stringX.Equals(stringY);
        }

        if (x is EsBoolean && y is EsBoolean)
        {
            return x == y;
        }

        if (x == y)
        {
            return true;
        }

        return false;
    }
}