using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace RPI.Core.Logging;

public class LoggingHelper
{
    public static void AddLoggerConfiguration()
    {
        const string configPath = "appsettings.json";
        const string outputTemplate = "[{Timestamp:HH:mm:ss:fff} {Level:u4}][{SourceContext}] {Message:lj}{NewLine}{Exception}";

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(path: configPath, optional: false, reloadOnChange: true)
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console(outputTemplate: outputTemplate)
            .WriteTo.File(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "logs/log-.txt"),
                rollingInterval: RollingInterval.Day,
                outputTemplate: outputTemplate)
            .CreateLogger();
    }
}