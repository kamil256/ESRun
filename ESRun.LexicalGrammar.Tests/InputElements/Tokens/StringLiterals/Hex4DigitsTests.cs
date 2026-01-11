using ESRun.LexicalGrammar.InputElements.Concrete.Tokens.StringLiterals;
using ESRun.LexicalGrammar.SourceCharacters;

namespace ESRun.LexicalGrammar.Tests.InputElements.Tokens.StringLiterals;

[TestClass]
public class Hex4DigitsTests
{
    [TestMethod]
    [DataRow('A', "0041")]
    [DataRow('A', "0041X")]
    public void TryParse_WhenSourceCharactersAreFourHexDigits_ParsesSuccessfully(char identifierCodePoint, string input)
    {
        // Arrange
        List<SourceCharacter> sourceCharacters = SourceCharacter.Parse(input);

        // Act
        bool didParse = Hex4Digits.TryParse(sourceCharacters, 0, out Hex4Digits hex4Digits);

        // Assert
        Assert.IsTrue(didParse);
        Assert.AreEqual(4, hex4Digits.HexDigits.Count);
        Assert.AreEqual(sourceCharacters[0], hex4Digits.HexDigits[0].HexDigitSourceCharacter);
        Assert.AreEqual(sourceCharacters[1], hex4Digits.HexDigits[1].HexDigitSourceCharacter);
        Assert.AreEqual(sourceCharacters[2], hex4Digits.HexDigits[2].HexDigitSourceCharacter);
        Assert.AreEqual(sourceCharacters[3], hex4Digits.HexDigits[3].HexDigitSourceCharacter);
        Assert.AreEqual(new SourceCharacter(identifierCodePoint), hex4Digits.SourceCharacter);
        CollectionAssert.AreEquivalent(sourceCharacters.Take(4).ToList(), hex4Digits.SourceCharacters);
        Assert.AreEqual(0, hex4Digits.StartIndex);
        Assert.AreEqual(3, hex4Digits.EndIndex);
    }

    [TestMethod]
    [DataRow("")]
    [DataRow("X")]
    [DataRow("FFFX")]
    public void TryParse_WhenSourceCharactersAreNotFourHexDigits_DoesNotParse(string input)
    {
        // Arrange
        List<SourceCharacter> sourceCharacters = SourceCharacter.Parse(input);

        // Act
        bool didParse = Hex4Digits.TryParse(sourceCharacters, 0, out Hex4Digits _);

        // Assert
        Assert.IsFalse(didParse);
    }
}
