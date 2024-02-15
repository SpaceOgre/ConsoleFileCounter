using ConsoleFileCounter.Contracts;
using ConsoleFileCounter.Helpers;
using Microsoft.Extensions.Logging;

namespace ConsoleFileCounter;

public class Application(ILogger<Application> logger, IFileReaderFactory fileReaderFactory)
{
    private readonly ILogger _logger = logger;
    private readonly IFileReaderFactory _fileReaderFactory = fileReaderFactory;

    public void Run(string[] args)
    {
        //TODO should we do anything if the arg is a path and not only a filename?

        ValidateInput(args);

        var fullFilename = args[0];

        var filename = FileHelper.GetFileNameWithoutExtension(fullFilename);

        using var linereader = _fileReaderFactory.Create(fullFilename);
        var counter = WordCounter.CountWordInLines(linereader, filename);

        _logger.LogInformation($"The filename {filename} occurs {counter} times.");
    }

    private static void ValidateInput(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args.Length == 0)
            throw new ArgumentException("The filename needs to be supplied");
        if (args.Length > 1)
            throw new ArgumentException("Only the filename should be supplied");
    }
}