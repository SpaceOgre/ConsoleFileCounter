using ConsoleFileCounter;
using ConsoleFileCounter.Contracts;
using ConsoleFileCounter.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

try
{
    var serviceProvider = new ServiceCollection()
        .AddLogging((loggingBuilder) => loggingBuilder
            .SetMinimumLevel(LogLevel.Information)
            .AddConsole()
            )
        .AddTransient<Application>()
        .AddTransient<IFileReaderFactory, FileReaderFactory>()
        .BuildServiceProvider();

    var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
    serviceProvider.GetRequiredService<Application>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}