using System.Text;

namespace ESRun.LexicalGrammar.SourceCharacters;

public partial class SourceCharacter
{
    public Rune CodePoint { get; }
    public int Value => CodePoint.Value;

    public SourceCharacter(int value) : this(new Rune(value))
    {
    }

    public SourceCharacter(char codeUnit) : this(new Rune(codeUnit))
    {
    }

    public SourceCharacter(params SourceCharacter[] hexDigits)
    {
        if (hexDigits.Length == 0)
        {
            throw new ArgumentException("Collection doesn't include any hex digits", nameof(hexDigits));
        }

        if (hexDigits.Any(hd => !hd.IsHexDigit))
        {
            throw new ArgumentOutOfRangeException(nameof(hexDigits), "Not all source characters are not a hex digits");
        }

        int value = Convert.ToInt32(string.Concat(hexDigits.Select(hd => hd.CodePoint)), 16);
        CodePoint = new Rune(value);
    }

    public SourceCharacter(Rune codePoint)
    {
        CodePoint = codePoint;
    }

    public static List<SourceCharacter> Parse(string sourceString)
    {
        return [.. sourceString.EnumerateRunes().Select(r => new SourceCharacter(r))];
    }

    public override bool Equals(object? obj)
    {
        return obj is SourceCharacter sourceCharacter && CodePoint.Equals(sourceCharacter.CodePoint);
    }

    public override int GetHashCode()
    {
        return CodePoint.GetHashCode();
    }

    public static bool operator ==(SourceCharacter left, SourceCharacter right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(SourceCharacter left, SourceCharacter right)
    {
        return !(left == right);
    }
}
