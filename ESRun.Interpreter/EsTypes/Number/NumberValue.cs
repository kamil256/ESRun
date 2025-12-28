using ESRun.Interpreter.EsTypes.Abstract;

namespace ESRun.Interpreter.EsTypes.Number;

public class NumberValue : EsValue
{
    public const string NaNLiteral = "NaN";
    public const string InfinityLiteral = "Infinity";
    public const string NegativeInfinityLiteral = "-Infinity";

    private readonly double _value;

    public NumberValue(string literal)
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

    public override NumberValue Clone()
    {
        return new NumberValue(ToString());
    }

    public override string ToString(int nestingLevel)
    {
        var stringValue = ToString();
        return stringValue;
    }
}