namespace ConsoleFileCounter.Contracts;

public interface IFileReaderFactory
{
    ILineReader Create(FileInfo file);
}
