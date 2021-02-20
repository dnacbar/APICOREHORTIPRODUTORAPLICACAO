using System;

namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT
{
    public interface IDistrictResult
    {
        Guid Id { get; set; }
        string District { get; set; }
    }
}
