using System;

namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface IDistrictQuerySignature : IBaseQuantitySignature
    {
        Guid Id { get; set; }
        string District { get; set; }
    }
}
