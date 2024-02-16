using ConsoleFileCounter.Contracts;
using ConsoleFileCounter.Helpers;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace ConsoleFileCounter.Tests;

public class ApplicationTests
{
    //TODO this does not realy test anything atm
    [Fact]
    public void Run_ValidFilename_CallsWordCounter()
    {
        // Arrange
        var logger = Substitute.For<ILogger<Application>>();
        var fileReaderFactory = Substitute.For<IFileReaderFactory>();
        var application = new Application(logger, fileReaderFactory);
        var args = new string[] { "test.txt" };
        var linereader = Substitute.For<ILineReader>();
        linereader.ReadLine().Returns((string?)null);
        fileReaderFactory.Create(Arg.Any<string>()).Returns(linereader);
        var filename = "test";

        // Act
        application.Run(args);
    }

    [Fact]
    public void Run_NoFilename_ThrowsArgumentException()
    {
        // Arrange
        var logger = Substitute.For<ILogger<Application>>();
        var fileReaderFactory = Substitute.For<IFileReaderFactory>();
        var application = new Application(logger, fileReaderFactory);
        var args = new string[] { };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => application.Run(args));
    }

    [Fact]
    public void Run_MultipleFilenames_ThrowsArgumentException()
    {
        // Arrange
        var logger = Substitute.For<ILogger<Application>>();
        var fileReaderFactory = Substitute.For<IFileReaderFactory>();
        var application = new Application(logger, fileReaderFactory);
        var args = new string[] { "test1.txt", "test2.txt" };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => application.Run(args));
    }
}
