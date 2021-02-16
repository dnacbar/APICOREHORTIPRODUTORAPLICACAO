using System;

namespace HORTICOMMAND.DOMAIN.INTERFACES.MODEL.SIGNATURE
{
    public interface IClientCommandSignature
    {
        Guid? Id { get; set; }
        string Email { get; set; }
        string Client { get; set; }
        int? City { get; set; }
        Guid? District { get; set; }
        string Phone { get; set; }
        string FederalInscription { get; set; }
        byte[] ImageByte { get; set; }
    }
}
