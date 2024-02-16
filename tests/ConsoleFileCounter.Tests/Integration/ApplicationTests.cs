using System.CommandLine;
using ConsoleFileCounter.Contracts;
using ConsoleFileCounter.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace ConsoleFileCounter.Tests.Integration;

public class ApplicationTests
{
    [Theory]
    [InlineData("Integration/TestFiles/InputFile1.txt", 1)]
    public void CountWords_WithValidFile_ReturnsCorrectWordCountAndZeroExitCode(string filePath, int expectedOccurs)
    {
        // Arrange
        const int ExpectedExitCode = 0;
        var logger = Substitute.For<ILogger<Application>>();
        var application = GetServiceProvider(logger).GetRequiredService<Application>();

        // Act
        var exitCode = application.Invoke([filePath]);
        var filename = Path.GetFileNameWithoutExtension(filePath);

        // Assert
        Assert.Equal(ExpectedExitCode, exitCode);

        if (ExpectedExitCode == 0)
        {
            logger.Received(1).Log(
                LogLevel.Information,
                Arg.Any<EventId>(),
                Arg.Is<IReadOnlyList<KeyValuePair<string, object?>>>(x => x.ToString() == $"The filename {filename} occurs {expectedOccurs} times."),
                Arg.Any<Exception>(),
                Arg.Any<Func<IReadOnlyList<KeyValuePair<string, object?>>, Exception?, string>>());
        }
    }

    [Theory]
    [InlineData("Integration/TestFiles/InputFileThatDontExist.txt")]
    [InlineData("Integration/TestFiles/")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Integration/TestFiles/InputFile1.txt", "Integration/TestFiles/InputFile1.txt")]
    public void CountWords_WithInvalidArguments_ReturnsNonZeroExitCode(params string[] args)
    {
        // Arrange
        const int ExpectedExitCode = 1;
        var logger = Substitute.For<ILogger<Application>>();
        var application = GetServiceProvider(logger).GetRequiredService<Application>();

        // Act
        var exitCode = application.Invoke(args);

        // Assert
        Assert.Equal(ExpectedExitCode, exitCode);
    }

    private static ServiceProvider GetServiceProvider(ILogger<Application> logger)
    {
        return new ServiceCollection()
            .AddLogging()
            .AddTransient(_ => logger)
            .AddTransient<Application>()
            .AddTransient<IFileReaderFactory, FileReaderFactory>()
            .AddSingleton<WordCounter>()
            .BuildServiceProvider();
    }
}