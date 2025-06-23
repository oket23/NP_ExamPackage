using Serilog;
using Serilog.Core;
using System.IO;

namespace LoggerSevice;

public static class LoggerService
{
    public static Logger GetLogger(string serviceName)
    {
        var logPath = $"Logs/{serviceName}.log";

        var logDirectory = Path.GetDirectoryName(logPath);
        Directory.CreateDirectory(logDirectory);

        return new LoggerConfiguration()
            .Enrich.WithProperty("ServiceName", serviceName)
               .WriteTo.File(logPath, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] [{serviceName}]: {Message:lj}{NewLine}{Exception}")
               .MinimumLevel.Debug()
               .CreateLogger();
    }

}



