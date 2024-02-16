using ConsoleFileCounter.Contracts;

namespace ConsoleFileCounter.Implementation;

public sealed class FileReader(FileInfo file) : ILineReader
{
    private readonly StreamReader _streamReader = file.OpenText();

    public void Dispose()
    {
        _streamReader.Dispose();
    }

    public string? ReadLine()
    {
        return _streamReader.ReadLine();
    }
}