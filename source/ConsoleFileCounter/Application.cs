using System.CommandLine;
using ConsoleFileCounter.Contracts;
using ConsoleFileCounter.Extensions;
using ConsoleFileCounter.Implementation;
using Microsoft.Extensions.Logging;

namespace ConsoleFileCounter;

public class Application : RootCommand
{
    private readonly ILogger<Application> _logger;
    private readonly IFileReaderFactory _fileReaderFactory;
    private readonly WordCounter _wordCounter;

    public Application(ILogger<Application> logger, IFileReaderFactory fileReaderFactory, WordCounter wordCounter)
        : base("Counts the number of words in a file")
    {
        _logger = logger;
        _fileReaderFactory = fileReaderFactory;
        _wordCounter = wordCounter;

        var argument = new Argument<FileInfo>(
            "file",
            "The filename or path to file to count words in")
            .ExistingOnly();
        AddArgument(argument);
        this.SetHandler(CountWords, argument);
    }

    private void CountWords(FileInfo file)
    {
        using var lineReader = _fileReaderFactory.Create(file);
        var word = file.GetFilenameWithoutExtension();
        if(word.Length == 0)
        {
            _logger.LogError("The filename is not valid.");
            throw new ArgumentException("The filename is not valid.");
        }
        var wordInLinesCount = _wordCounter.CountWordInLines(lineReader, word);
        _logger.LogInformation($"The filename {word} occurs {wordInLinesCount} times.");
    }
}