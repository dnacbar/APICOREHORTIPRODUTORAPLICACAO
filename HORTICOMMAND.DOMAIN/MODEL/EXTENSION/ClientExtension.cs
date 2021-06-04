using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTICOMMAND.DOMAIN.MODEL.EXTENSION
{
    public static class ClientExtension
    {
        public static Client GetClient(this IClientCommandSignature signature)
        {
            return new Client
            {
                IdClient = signature.Id.GetValueOrDefault(),
                DsClient = signature.Client,
                DsEmail = signature.Email,
                DsPhone = signature.Phone,
                IdCity = signature.City,
                IdDistrict = signature.District,
                DsFederalInscription = signature.FederalInscription
            };
        }
    }
}
