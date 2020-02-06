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
                switch (logMongoObject.LevelLog)
                {
                    case ENUM.EnumLevelLog.Error:
                        Log.Logger = new LoggerConfiguration()
                                         .WriteTo
                                         .File(@"C:\log\log_error.txt", rollingInterval: RollingInterval.Hour)
                                         .CreateLogger();
                        break;
                    case ENUM.EnumLevelLog.Fatal:
                        Log.Logger = new LoggerConfiguration()
                                         .WriteTo
                                         .File(@"C:\log\log_fatal.txt", rollingInterval: RollingInterval.Hour)
                                         .CreateLogger();
                        break;
                    case ENUM.EnumLevelLog.Information:
                        Log.Logger = new LoggerConfiguration()
                                         .WriteTo
                                         .File(@"C:\log\log_information.txt", rollingInterval: RollingInterval.Hour)
                                         .CreateLogger();
                        break;
                    default:
                        break;
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Log.Logger = new LoggerConfiguration()
                                 .WriteTo
                                 .File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/.log"), rollingInterval: RollingInterval.Day)
                                 .CreateLogger();
            }

            if (logMongoObject.LevelLog == ENUM.EnumLevelLog.Information)
                Log.Information(logMongoObject.LogMessage());

            else if (logMongoObject.LevelLog == ENUM.EnumLevelLog.Error)
                Log.Error(logMongoObject.LogMessage());

            else if (logMongoObject.LevelLog == ENUM.EnumLevelLog.Fatal)
                Log.Fatal(logMongoObject.LogMessage());
        }
    }
}
