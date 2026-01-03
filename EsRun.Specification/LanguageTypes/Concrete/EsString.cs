using EsRun.Specification.LanguageTypes.Abstract;

namespace EsRun.Specification.LanguageTypes.Concrete;

public class EsString : EsValue
{
    private readonly string _value;

    public EsString(string literal)
    {
        _value = literal;
    }

    public override string ToString()
    {
        return _value;
    }

    // public override EsString Clone()
    // {
    //     return new EsString(ToString());
    // }

    // public override string ToString(int nestingLevel)
    // {
    //     return ToString();
    // }

    public bool Equals(EsString otherStringValue)
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

    public int Length => _value.Length;
}