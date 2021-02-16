using HORTI.CORE.CROSSCUTTING.ENUM;
using System;
using System.Net;

namespace HORTI.CORE.CROSSCUTTING.LOG
{
    public class LogObject
    {
        public string Id { get; set; }
        public string UserLog { get; set; }
        public string InfoLog { get; set; }
        public EnumLogLevel LevelLog { get; set; }
        public DateTime TimeLog { get; set; }
        public IPAddress IPAddress { get; set; }

        public string LogMessage()
        {
            return @"DATETIME: " + TimeLog + " ID: " + Id + " USER: " + UserLog + " \r\n" +
                    "IP: " + IPAddress?.MapToIPv4().ToString() + " \r\n" +
                    "LOG: " + InfoLog + "\r\n\r\n";
        }
    }
}
