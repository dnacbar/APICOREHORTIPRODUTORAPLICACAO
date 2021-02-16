using System;

namespace HORTICOMMAND.DOMAIN.INTERFACES.MODEL.SIGNATURE
{
    public interface IDistrictCommandSignature
    {
        Guid? Id { get; set; }
        string District { get; set; }
    }
}
