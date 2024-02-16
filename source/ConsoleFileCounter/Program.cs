using System.CommandLine;
using ConsoleFileCounter;
using ConsoleFileCounter.Contracts;
using ConsoleFileCounter.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddTransient<Application>()
         .AddTransient<IFileReaderFactory, FileReaderFactory>()
         .AddSingleton<WordCounter>();
    })
    .Build()
    .Services
    .GetRequiredService<Application>()
    .Invoke(args);