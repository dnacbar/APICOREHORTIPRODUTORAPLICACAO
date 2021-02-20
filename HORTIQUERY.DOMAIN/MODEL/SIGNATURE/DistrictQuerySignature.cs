using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTIQUERY.DOMAIN.MODEL.SIGNATURE
{
    public sealed class DistrictQuerySignature : _BaseQuantitySignature, IDistrictQuerySignature
    {
        public Guid Id { get; set; }
        public string District { get; set; }
    }
}
