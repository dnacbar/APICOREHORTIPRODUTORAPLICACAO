using Serilog;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CrossCuttingCoreHortiCommand.LOG
{
    public static class LogExtension
    {
        public static void CreateLog(LogObject logMongoObject)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Log.Logger = new LoggerConfiguration()
                                 .WriteTo
                                 .File(@"C:\log\log_error.txt", rollingInterval: RollingInterval.Hour)
                                 .CreateLogger();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Log.Logger = new LoggerConfiguration()
                                 .WriteTo
                                 .File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/.log"), rollingInterval: RollingInterval.Day)
                                 .CreateLogger();
            }

            Log.Information(logMongoObject.LogMessage());
        }
    }
}
