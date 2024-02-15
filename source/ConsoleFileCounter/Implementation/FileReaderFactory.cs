using ConsoleFileCounter.Contracts;

namespace ConsoleFileCounter.Implementation;

public class FileReaderFactory : IFileReaderFactory
{
    public ILineReader Create(string filename)
    {
        return new FileReader(filename);
    }
}