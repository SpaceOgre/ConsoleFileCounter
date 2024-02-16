namespace ConsoleFileCounter.Helpers;

public static class FileHelper
{
    public static string GetFileNameWithoutExtension(string filename)
    {
        var pos = filename.LastIndexOf('.');
        if (pos == -1) return filename;
        return filename[..pos];
    }
}