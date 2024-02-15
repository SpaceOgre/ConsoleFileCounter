using ConsoleFileCounter.Contracts;

namespace ConsoleFileCounter.Implementation;

public sealed class FileReader : ILineReader
{
    private readonly FileStream _fileReader;
    private readonly StreamReader _streamReader;

    public FileReader(string filename)
    {
        _fileReader = File.Open(filename, FileMode.Open);
        _streamReader = new StreamReader(_fileReader);
    }

    public void Dispose()
    {
        _fileReader.Dispose();
        _streamReader.Dispose();
    }

    public string? ReadLine()
    {
        return _streamReader.ReadLine();
    }
}