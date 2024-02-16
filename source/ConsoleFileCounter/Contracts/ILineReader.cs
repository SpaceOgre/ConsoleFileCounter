namespace ConsoleFileCounter.Contracts;

public interface ILineReader : IDisposable
{
    string? ReadLine();
}