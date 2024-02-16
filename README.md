# ConsoleFileCounter

The ConsoleFileCounter is a program that counts how many times a files filename appears in the file.

## Limitations
- Files can only start with one dot, eg: `.gitignore` and not two or more `..gitignore`
- Only UTF8 encoding is supported, if the filename only contains ASCII characters then other encodings will probably also work.

## Notable 3-party libraries
- [System.CommandLine](https://learn.microsoft.com/en-us/dotnet/standard/commandline/)
  - This library helps with parsing commandline arguments, fault handling for input, printing help information etc
  - It is still in preview but is widly used with the latest version having over 7miljon downloads from Nuget.

## Building the Program

You can build the program using either Visual Studio or the `dotnet run` command.

### Building with Visual Studio

1. Open the solution file (`ConsoleFileCounter.sln`) in Visual Studio.
2. Build the solution by selecting the "Build" menu and clicking on "Build Solution" or by pressing `Ctrl + Shift + B`.
3. The program will be built and the executable file will be generated.

### Building with dotnet run

1. Open a terminal or command prompt.
2. Navigate to the root directory of the ConsoleFileCounter solution.
3. Run the following command: `dotnet build`
4. The program will be built.

## Running the Program
In both examples bellow this applies:
Replace `<filename>` with the name of the file you want to count.

### Executable
To run the program, open a terminal or command prompt and navigate to the directory where the executable file is located. Then, run the following command:
`ConsoleFileCounter.exe <filename>`

### dotnet run
1. Open a terminal
2. Navigate to the ConsoleFileCounter.csproj directory
3. Run the following command: `dotnet run <filename>`

## Tests

The ConsoleFileCounter solution includes unit tests to ensure the correctness of the program. The tests can be found in the `ConsoleFileCounter.Tests` project.

To run the tests, you can use Visual Studio's built-in test runner or run the following command in the terminal or command prompt: `dotnet test`
