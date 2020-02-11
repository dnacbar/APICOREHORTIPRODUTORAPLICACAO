using System;

namespace APPDTOCOREHORTIQUERY.SIGNATURE
{
    public sealed class ConsultDistrictByIdNameSignature : ConsultByQuantitySignature
    {
        public Guid IdDistrict { get; set; }
        public string DsDistrict { get; set; }
    }
}
