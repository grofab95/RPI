namespace RPI.Web;

public static class WebContentHelper
{
    public static string GetPathToWebContent()
    {
        if (OperatingSystem.IsWindows())
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            return Path.Combine(currentDirectory, "bin", "Debug", "net6.0", "wwwroot");
        }
        
        var rootDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent;
        return Path.Combine(rootDirectory?.FullName ?? string.Empty, "Net", "wwwroot");
    }
}