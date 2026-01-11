using ESRun.LexicalGrammar.InputElements.Abstract;
using ESRun.LexicalGrammar.SourceCharacters;

namespace ESRun.LexicalGrammar.InputElements.Concrete.Tokens.NumericLiterals;

public class HexDigit(SourceCharacter hexDigitSourceCharacter, int startIndex) : InputElement([hexDigitSourceCharacter], startIndex)
{
    public SourceCharacter HexDigitSourceCharacter { get; } = hexDigitSourceCharacter;

    public static bool TryParse(List<SourceCharacter> sourceCharacters, int startIndex, out HexDigit hexDigit)
    {
        SourceCharacter? firstSourceCharacter = sourceCharacters.FirstOrDefault();

        if (firstSourceCharacter is not null && firstSourceCharacter.IsHexDigit)
        {
            hexDigit = new HexDigit(firstSourceCharacter, startIndex);
            return true;
        }

        hexDigit = default!;
        return false;
    }
}
