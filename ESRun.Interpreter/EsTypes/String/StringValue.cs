using ESRun.Interpreter.EsTypes.Abstract;

namespace ESRun.Interpreter.EsTypes.String;

public class StringValue : EsValue
{
    public const string NaNLiteral = "NaN";
    public const string InfinityLiteral = "Infinity";
    public const string NegativeInfinityLiteral = "-Infinity";

    private readonly string _value;

    public StringValue(string literal)
    {
        _value = literal;
    }

    public override string ToString()
    {
        return _value;
    }

    public override StringValue Clone()
    {
        return new StringValue(ToString());
    }

    public override string ToString(int nestingLevel)
    {
        return ToString();
    }

    public bool Equals(StringValue otherStringValue)
    {
        return _value == otherStringValue._value;
    }

    public string GetSubstring(int inclusiveStartIndex, int exclusiveEndIndex)
    {
        return _value.Substring(inclusiveStartIndex, exclusiveEndIndex - inclusiveStartIndex);
    }

    public int StringIndexOf(string searchValue, int fromIndex)
    {
        var len = _value.Length;

        if (searchValue.Length == 0 && fromIndex <= len)
        {
            return fromIndex;
        }

        var searchLen = searchValue.Length;

        for (var i = fromIndex; i <= len - searchLen; i++)
        {
            var candiate = GetSubstring(i, i + searchLen);

            if (candiate == searchValue)
            {
                return i;
            }
        }

        return -1;
    }

    public int StringLastIndexOf(string searchValue, int fromIndex)
    {
        throw new NotImplementedException();
    }
}