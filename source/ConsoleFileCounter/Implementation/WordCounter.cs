using ConsoleFileCounter.Contracts;
using Microsoft.Extensions.Logging;

namespace ConsoleFileCounter.Implementation;

public class WordCounter(ILogger<WordCounter> logger)
{
    public int CountWordInLines(ILineReader linereader, string word)
    {
        string? line;
        var counter = 0;
        while ((line = linereader.ReadLine()) != null)
        {
            counter += CountWordInLine(word, line, 0);
        }

        return counter;
    }

    private int CountWordInLine(string word, string line, int counter)
    {
        var index = 0;
        while ((index = line.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            counter++;
            index += word.Length;
        }
        logger.LogDebug($"Line: {line}{Environment.NewLine}Counter: {counter}");
        return counter;
    }
}