using ESRun.LexicalGrammar.InputElements.Concrete.Tokens.NumericLiterals;
using ESRun.LexicalGrammar.SourceCharacters;

namespace ESRun.LexicalGrammar.Tests.InputElements.Tokens.NumericLiterals;

[TestClass]
public class HexDigitTests
{
    [TestMethod]
    [DataRow("0")]
    [DataRow("1")]
    [DataRow("2")]
    [DataRow("3")]
    [DataRow("4")]
    [DataRow("5")]
    [DataRow("6")]
    [DataRow("7")]
    [DataRow("8")]
    [DataRow("9")]
    [DataRow("a")]
    [DataRow("b")]
    [DataRow("c")]
    [DataRow("d")]
    [DataRow("e")]
    [DataRow("f")]
    [DataRow("A")]
    [DataRow("B")]
    [DataRow("C")]
    [DataRow("D")]
    [DataRow("E")]
    [DataRow("F")]
    public void TryParse_WhenSourceCharacterIsHexDigit_ParsesSuccessfully(string input)
    {
        // Arrange
        List<SourceCharacter> sourceCharacters = SourceCharacter.Parse(input);

        // Act
        bool didParse = HexDigit.TryParse(sourceCharacters, 0, out HexDigit hexDigit);

        // Assert
        Assert.IsTrue(didParse);
        Assert.AreEqual(sourceCharacters.First(), hexDigit.HexDigitSourceCharacter);
        CollectionAssert.AreEquivalent(sourceCharacters, hexDigit.SourceCharacters);
        Assert.AreEqual(0, hexDigit.StartIndex);
        Assert.AreEqual(0, hexDigit.EndIndex);
    }

    [TestMethod]
    [DataRow("")]
    [DataRow("X")]
    public void TryParse_WhenSourceCharacterIsNotHexDigit_DoesNotParse(string input)
    {
        // Arrange
        List<SourceCharacter> sourceCharacters = SourceCharacter.Parse(input);

        // Act
        bool didParse = HexDigit.TryParse(sourceCharacters, 0, out HexDigit _);

        // Assert
        Assert.IsFalse(didParse);
    }
}
