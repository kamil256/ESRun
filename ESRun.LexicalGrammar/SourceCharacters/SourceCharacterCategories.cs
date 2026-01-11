using System.Globalization;
using System.Text;

namespace ESRun.LexicalGrammar.SourceCharacters;

public partial class SourceCharacter
{
    public bool IsWhiteSpace =>
        Rune.GetUnicodeCategory(CodePoint) == UnicodeCategory.SpaceSeparator
        || this == CharacterTabulation
        || this == LineTabulation
        || this == FormFeed
        || this == ZeroWidthNoBreakSpace;

    public bool IsLineTerminator =>
        this == LineFeed
        || this == CarriageReturn
        || this == LineSeparator
        || this == ParagraphSeparator;

    public bool IsIDStart()
    {
        if (IsWhiteSpace || IsLineTerminator)
        {
            return false;
        }

        var category = Rune.GetUnicodeCategory(CodePoint);

        return category is UnicodeCategory.UppercaseLetter
            or UnicodeCategory.LowercaseLetter
            or UnicodeCategory.TitlecaseLetter
            or UnicodeCategory.ModifierLetter
            or UnicodeCategory.OtherLetter
            or UnicodeCategory.LetterNumber;
    }

    public bool IsIDContinue
    {
        get
        {
            if (IsWhiteSpace || IsLineTerminator)
            {
                return false;
            }

            var category = Rune.GetUnicodeCategory(CodePoint);

            return IsIDStart()
                || category == UnicodeCategory.NonSpacingMark
                || category == UnicodeCategory.SpacingCombiningMark
                || category == UnicodeCategory.DecimalDigitNumber
                || category == UnicodeCategory.ConnectorPunctuation;
        }
    }

    public bool IsHexDigit =>
        CodePoint.Value is (>= '0' and <= '9') or (>= 'a' and <= 'f') or (>= 'A' and <= 'F');
}
