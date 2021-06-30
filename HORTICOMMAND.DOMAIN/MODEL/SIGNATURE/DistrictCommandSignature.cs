using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTICOMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class DistrictCommandSignature : IDistrictCommandSignature
    {
        public DistrictCommandSignature()
        {
            Id = Id.GetValueOrDefault() == Guid.Empty ? Guid.NewGuid() : Id;
        }

        public Guid? Id { get; set; }
        public string District { get; set; }
    }
}
