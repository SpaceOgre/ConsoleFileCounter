using ConsoleFileCounter.Contracts;

namespace ConsoleFileCounter.Helpers;

public static class WordCounter
{
    public static int CountWordInLines(ILineReader linereader, string word)
    {
        string? line;
        var counter = 0;
        while (true)
        {
            line = linereader.ReadLine();
            if (line == null) break;

            counter += CountWordInLine(word, line, 0);
        }

        return counter;
    }

    private static int CountWordInLine(string word, string line, int counter)
    {
        var index = line.IndexOf(word, StringComparison.OrdinalIgnoreCase);
        if (index == -1) return counter;
        return CountWordInLine(word, line[index..], ++counter);
    }
}