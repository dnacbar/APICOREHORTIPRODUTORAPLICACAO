using System;

namespace HORTIQUERY.DOMAIN.INTERFACES.MODEL.RESULT
{
    public interface IUserResult
    {
        string DsName { get; set; }
        string DsEmail { get; set; }
        int? IdState { get; set; }
        int? IdCity { get; set; }
        Guid? IdDistrict { get; set; }
        string DsPhone { get; set; }
    }
}
