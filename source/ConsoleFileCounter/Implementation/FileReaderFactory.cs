using ConsoleFileCounter.Contracts;

namespace ConsoleFileCounter.Implementation;

public class FileReaderFactory : IFileReaderFactory
{
    public ILineReader Create(FileInfo file)
    {
        return new FileReader(file);
    }
}