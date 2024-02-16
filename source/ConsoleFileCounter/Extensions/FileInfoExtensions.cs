namespace ConsoleFileCounter.Extensions;

public static class FileInfoExtensions
{
    /// <summary>
    /// Gets the filename without the extension, if it starts with a dot, the dot is preserved.
    /// </summary>
    /// <param name="file">The <see cref="FileInfo"/> object representing the file.</param>
    /// <returns>The filename without the extension.</returns>
    public static string GetFilenameWithoutExtension(this FileInfo file)
    {
        var filename = file.Name;
        var startsWithDot = filename.StartsWith('.');
        if (startsWithDot)
            filename = filename[1..];

        var word = Path.GetFileNameWithoutExtension(filename);

        if (startsWithDot)
            word = '.' + word;

        return word;
    }
}
