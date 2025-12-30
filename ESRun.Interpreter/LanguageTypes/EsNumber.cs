namespace ESRun.Interpreter.LanguageTypes;

public class EsNumber : EsValue
{
    public const string NaNLiteral = "NaN";
    public const string InfinityLiteral = "Infinity";
    public const string NegativeInfinityLiteral = "-Infinity";

    private readonly double _value;

    public EsNumber(string literal)
    {
        switch (literal)
        {
            case NaNLiteral:
                _value = double.NaN;
                break;
            case InfinityLiteral:
                _value = double.PositiveInfinity;
                break;
            case NegativeInfinityLiteral:
                _value = double.NegativeInfinity;
                break;
            default:
                if (double.TryParse(literal, out var number))
                {
                    _value = number;
                    break;
                }
                else
                {
                    throw new Exception($"Cannot parse number from literal '{literal}'");
                }
        }
    }

    public override string ToString()
    {
        switch (_value)
        {
            case double.NaN:
                return NaNLiteral;
            case double.PositiveInfinity:
                return InfinityLiteral;
            case double.NegativeInfinity:
                return NegativeInfinityLiteral;
            default:
                return _value.ToString();
        }
    }

    // public override EsNumber Clone()
    // {
    //     return new EsNumber(ToString());
    // }

    // public override string ToString(int nestingLevel)
    // {
    //     var stringValue = ToString();
    //     return stringValue;
    // }

    public static bool Equal(EsNumber x, EsNumber y)
    {
        if (double.IsNaN(x._value))
        {
            return false;
        }

        if (double.IsNaN(y._value))
        {
            return false;
        }

        if (x._value == y._value)
        {
            return true;
        }

        if (x._value == 0 && y._value == -0)
        {
            return true;
        }

        if (x._value == -0 && y._value == 0)
        {
            return true;
        }

        return false;
    }

    public static bool SameValue(EsNumber x, EsNumber y)
    {
        if (double.IsNaN(x._value) && double.IsNaN(y._value))
        {
            return true;
        }

        if (x._value == 0 && y._value == -0)
        {
            return false;
        }

        if (x._value == -0 && y._value == 0)
        {
            return false;
        }

        if (x._value == y._value)
        {
            return true;
        }

        return false;
    }

    public bool IsNaNOrZero()
    {
        return double.IsNaN(_value) || _value == -0 || _value == 0;
    }
}