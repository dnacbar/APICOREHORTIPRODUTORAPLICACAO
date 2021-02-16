using Serilog;
using System.IO;

namespace HORTI.CORE.CROSSCUTTING.LOG
{
    public static class LogExtension
    {
        public static void CreateLog(LogObject logObject)
        {
            Log.Logger = new LoggerConfiguration()
                        .WriteTo
                        .File(Path.Combine(Path.GetPathRoot(Directory.GetCurrentDirectory()), "log", "LOG_LEVEL_" + logObject.LevelLog.ToString().ToUpperInvariant() + ".txt"), rollingInterval: RollingInterval.Hour)
                        .CreateLogger();

            if (logObject.LevelLog == ENUM.EnumLogLevel.Fatal)
                Log.Fatal(logObject.LogMessage());
            else if (logObject.LevelLog == ENUM.EnumLogLevel.Error)
                Log.Fatal(logObject.LogMessage());
            else if (logObject.LevelLog == ENUM.EnumLogLevel.Warning)
                Log.Warning(logObject.LogMessage());
            else if (logObject.LevelLog == ENUM.EnumLogLevel.Information)
                Log.Information(logObject.LogMessage());
        }
    }
}
