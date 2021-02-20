using System;

namespace HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface IDistrictCommandSignature
    {
        Guid? Id { get; set; }
        string District { get; set; }
    }
}
