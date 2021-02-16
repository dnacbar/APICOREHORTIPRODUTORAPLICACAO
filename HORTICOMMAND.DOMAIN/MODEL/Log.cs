using System;

namespace HORTICOMMAND.DOMAIN.MODEL
{
    public class Log
    {
        public Guid IdLog { get; set; }
        public string DsUserlog { get; set; }
        public string DsInfolog { get; set; }
        public string CdLevellog { get; set; }
        public DateTime DtCreation { get; set; }
    }
}
