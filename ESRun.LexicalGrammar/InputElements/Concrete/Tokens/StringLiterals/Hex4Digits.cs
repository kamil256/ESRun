using ESRun.LexicalGrammar.InputElements.Abstract;
using ESRun.LexicalGrammar.InputElements.Concrete.Tokens.NumericLiterals;
using ESRun.LexicalGrammar.SourceCharacters;

namespace ESRun.LexicalGrammar.InputElements.Concrete.Tokens.StringLiterals;

public class Hex4Digits : InputElement
{
    public List<HexDigit> HexDigits { get; }
    public SourceCharacter SourceCharacter { get; }

    public Hex4Digits(List<HexDigit> hexDigits, int startIndex) : base([.. hexDigits.SelectMany(hd => hd.SourceCharacters)], startIndex)
    {
        if (hexDigits.Count != 4)
        {
            throw new ArgumentOutOfRangeException(nameof(hexDigits), "Expected four hex digits");
        }

        HexDigits = hexDigits;
        SourceCharacter = new SourceCharacter([.. hexDigits.Select(hd => hd.HexDigitSourceCharacter)]);
    }

    public static bool TryParse(List<SourceCharacter> sourceCharacters, int startIndex, out Hex4Digits hex4Digits)
    {
        if (HexDigit.TryParse(sourceCharacters, startIndex, out HexDigit hexDigit1)
            && HexDigit.TryParse([.. sourceCharacters.Skip(1)], startIndex + 1, out HexDigit hexDigit2)
            && HexDigit.TryParse([.. sourceCharacters.Skip(2)], startIndex + 2, out HexDigit hexDigit3)
            && HexDigit.TryParse([.. sourceCharacters.Skip(3)], startIndex + 3, out HexDigit hexDigit4))
        {
            hex4Digits = new Hex4Digits([hexDigit1, hexDigit2, hexDigit3, hexDigit4], startIndex);
            return true;
        }

        hex4Digits = default!;
        return false;
    }
}
