using ConsoleFileCounter.Contracts;

namespace ConsoleFileCounter.Implementation;

public class WordCounter
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

    private static int CountWordInLine(string word, string line, int counter)
    {
        var index = 0;
        while ((index = line.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            counter++;
            index += word.Length;
        }
        return counter;
    }
}