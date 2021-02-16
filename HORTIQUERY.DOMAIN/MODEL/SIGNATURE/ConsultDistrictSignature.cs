using System;

namespace HORTIQUERY.DOMAIN.MODEL.SIGNATURE
{
    public sealed class ConsultDistrictSignature : _BaseQuantitySignature
    {
        public Guid IdDistrict { get; set; }
        public string DsDistrict { get; set; }
    }
}
