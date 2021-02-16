using System;

namespace APPDTOCOREHORTICOMMAND.SIGNATURE
{
    public interface DistrictCommandSignature
    {
        Guid? Id { get; set; }
        string District { get; set; }
    }
}
