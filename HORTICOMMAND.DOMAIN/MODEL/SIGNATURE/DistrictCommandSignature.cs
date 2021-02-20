using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTICOMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class DistrictCommandSignature : IDistrictCommandSignature
    {
        public Guid? Id { get; set; }
        public string District { get; set; }
    }
}
