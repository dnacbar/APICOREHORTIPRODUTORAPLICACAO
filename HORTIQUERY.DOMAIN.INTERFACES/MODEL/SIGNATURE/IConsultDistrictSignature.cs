using System;

namespace HORTIQUERY.DOMAIN.INTERFACES.MODEL.SIGNATURE
{
    public interface IConsultDistrictSignature : IBaseQuantitySignature
    {
        Guid IdDistrict { get; set; }
        string DsDistrict { get; set; }
    }
}
