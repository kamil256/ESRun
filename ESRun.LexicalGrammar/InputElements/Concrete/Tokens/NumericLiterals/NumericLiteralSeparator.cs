using ESRun.LexicalGrammar.InputElements.Abstract;
using ESRun.LexicalGrammar.SourceCharacters;

namespace ESRun.LexicalGrammar.InputElements.Concrete.Tokens.NumericLiterals;

public class NumericLiteralSeparator(int startIndex) : InputElement([new SourceCharacter('_')], startIndex)
{
    public static bool TryParse(List<SourceCharacter> sourceCharacters, int startIndex, out NumericLiteralSeparator numericLiteralSeparator)
    {
        SourceCharacter? firstSourceCharacter = sourceCharacters.FirstOrDefault();

        if (firstSourceCharacter is not null && firstSourceCharacter == new SourceCharacter('_'))
        {
            numericLiteralSeparator = new NumericLiteralSeparator(startIndex);
            return true;
        }

        numericLiteralSeparator = default!;
        return false;
    }
}
