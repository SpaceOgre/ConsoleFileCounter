using ConsoleFileCounter.Contracts;
using ConsoleFileCounter.Implementation;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace ConsoleFileCounter.Tests.Unit;

public class WordCounterTests
{
    [Theory]
    [InlineData(2, "test", "This is a test line", "Another test line")]
    [InlineData(0, "test1", "This is a test line", "Another test line")]
    [InlineData(2, "test", "", "Another test line", "test")]
    [InlineData(3, "test", "This is a test line test", "Another test line")]
    [InlineData(2, "test", "This is a testtest")]
    [InlineData(0, "test", "This is a tes")]
    public void CountWordInLines_ShouldReturnCorrectWordCount(int expectedCount, string word, params string[] lines)
    {
        // Arrange
        var lineReader = Substitute.For<ILineReader>();
        var logger = Substitute.For<ILogger<WordCounter>>();
        var wordCounter = new WordCounter(logger);

        lineReader.ReadLine().Returns(lines[0], [.. lines[1..], null]);

        // Act
        var result = wordCounter.CountWordInLines(lineReader, word);

        // Assert
        Assert.Equal(expectedCount, result);
    }
}