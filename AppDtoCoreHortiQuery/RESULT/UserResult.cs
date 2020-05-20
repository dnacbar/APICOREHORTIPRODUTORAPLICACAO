using System;

namespace APPDTOCOREHORTIQUERY.RESULT
{
    public abstract class UserResult
    {
        public string DsName { get; set; }
        public string DsEmail { get; set; }
        public int? IdState { get; set; }
        public int? IdCity { get; set; }
        public Guid? IdDistrict { get; set; }
        public string DsPhone { get; set; }
    }
}
