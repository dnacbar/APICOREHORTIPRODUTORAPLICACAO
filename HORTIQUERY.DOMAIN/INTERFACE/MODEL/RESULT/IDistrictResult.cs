using System;

namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT
{
    public interface IDistrictResult : IResult
    {
        Guid Id { get; set; }
        string District { get; set; }
    }
}
