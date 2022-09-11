namespace RPI.Web;

public static class WebContentHelper
{
    public static string GetPathToWebContent()
    {
        var rootDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent;
        return Path.Combine(rootDirectory?.FullName ?? string.Empty, "RPI.Web", "wwwroot");
    }
}