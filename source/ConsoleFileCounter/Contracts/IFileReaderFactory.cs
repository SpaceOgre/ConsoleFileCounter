﻿namespace ConsoleFileCounter.Contracts;

public interface IFileReaderFactory
{
    ILineReader Create(string filename);
}
