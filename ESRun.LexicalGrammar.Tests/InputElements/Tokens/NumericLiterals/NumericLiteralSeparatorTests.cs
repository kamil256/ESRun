using ESRun.LexicalGrammar.InputElements.Concrete.Tokens.NumericLiterals;
using ESRun.LexicalGrammar.SourceCharacters;

namespace ESRun.LexicalGrammar.Tests.InputElements.Tokens.NumericLiterals;

[TestClass]
public class NumericLiteralSeparatorTests
{
    [TestMethod]
    [DataRow("_")]
    public void TryParse_WhenSourceCharacterIsUnderscore_ParsesSuccessfully(string input)
    {
        // Arrange
        List<SourceCharacter> sourceCharacters = SourceCharacter.Parse(input);

        // Act
        bool didParse = NumericLiteralSeparator.TryParse(sourceCharacters, 0, out NumericLiteralSeparator numericLiteralSeparator);

        // Assert
        Assert.IsTrue(didParse);
        CollectionAssert.AreEquivalent(sourceCharacters, numericLiteralSeparator.SourceCharacters);
        Assert.AreEqual(0, numericLiteralSeparator.StartIndex);
        Assert.AreEqual(0, numericLiteralSeparator.EndIndex);
    }

    [TestMethod]
    [DataRow("")]
    [DataRow("X")]
    public void TryParse_WhenSourceCharacterIsNotUnderscore_DoesNotParse(string input)
    {
        // Arrange
        List<SourceCharacter> sourceCharacters = SourceCharacter.Parse(input);

        // Act
        bool didParse = NumericLiteralSeparator.TryParse(sourceCharacters, 0, out NumericLiteralSeparator _);

        // Assert
        Assert.IsFalse(didParse);
    }
}
