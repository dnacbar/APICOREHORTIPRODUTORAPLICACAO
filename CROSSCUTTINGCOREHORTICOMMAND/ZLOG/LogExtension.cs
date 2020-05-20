using Serilog;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CROSSCUTTINGCOREHORTI.LOG
{
    public static class LogExtension
    {
        public static void CreateLog(LogObject logObject)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Log.Logger = new LoggerConfiguration()
                                 .WriteTo
                                 .File(@"C:\log\LOG_LEVEL_" + logObject.LevelLog.ToString().ToUpperInvariant() + ".txt", rollingInterval: RollingInterval.Hour)
                                 .CreateLogger();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Log.Logger = new LoggerConfiguration()
                                 .WriteTo
                                 .File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log/LOG_LEVEL" + logObject.LevelLog.ToString().ToUpperInvariant() + "/.log"),
                                                    rollingInterval: RollingInterval.Day)
                                 .CreateLogger();
            }

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
