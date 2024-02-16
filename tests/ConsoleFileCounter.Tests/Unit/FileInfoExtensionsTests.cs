using ConsoleFileCounter.Extensions;

namespace ConsoleFileCounter.Tests.Unit;

public class FileInfoExtensionsTests
{
    [Theory]
    [InlineData("file.txt", "file")]
    [InlineData(".config", ".config")]
    [InlineData("file", "file")]
    public void GetFilenameWithoutExtension_WithValidFile_ReturnsFilenameWithoutExtension(string filename, string expected)
    {
        // Arrange
        var fileInfo = new FileInfo(filename);

        // Act
        var result = fileInfo.GetFilenameWithoutExtension();

        // Assert
        Assert.Equal(expected, result);
    }
}