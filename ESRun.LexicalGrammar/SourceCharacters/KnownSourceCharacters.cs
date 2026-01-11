namespace ESRun.LexicalGrammar.SourceCharacters;

public partial class SourceCharacter
{
    public static readonly SourceCharacter CharacterTabulation = new(0x0009);
    public static readonly SourceCharacter LineTabulation = new(0x000B);
    public static readonly SourceCharacter FormFeed = new(0x000C);
    public static readonly SourceCharacter ZeroWidthNoBreakSpace = new(0xFEFF);

    public static readonly SourceCharacter LineFeed = new(0x000A);
    public static readonly SourceCharacter CarriageReturn = new(0x000D);
    public static readonly SourceCharacter LineSeparator = new(0x2028);
    public static readonly SourceCharacter ParagraphSeparator = new(0x2029);
}
