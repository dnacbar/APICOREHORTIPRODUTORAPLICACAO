using APPDTOCOREHORTICOMMAND.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System;

namespace APPCOREHORTICOMMAND.APP.CONVERTER
{
    public static class ClientConverter
    {
        public static Client ToCreateClientDomain(this ClientCommandSignature signature)
        {
            return new Client
            {
                IdClient = Guid.NewGuid(),
                DsEmail = signature.Email,
                DsClient = signature.Client,
                DsPhone = signature.Phone
            };
        }

        public static Client ToUpdateClientDomain(this ClientCommandSignature signature)
        {
            return new Client
            {
                IdClient = signature.Id.Value,
                DsClient = signature.Client,
                DsEmail = signature.Email,
                DsPhone = signature.Phone,
                IdCity = signature.City,
                IdDistrict = signature.District,
                DsFederalInscription = signature.FederalInscription,
                DtAtualization = DateTime.Now
            };
        }
    }
}
