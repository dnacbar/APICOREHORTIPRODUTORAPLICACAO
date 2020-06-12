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
                DsClient = signature.Client,
                DsEmail = signature.Email,
                DsPhone = signature.Phone,
                IdCity = signature.City,
                DsFederalInscription = signature.FederalInscription,
                DtCreation = DateTime.Now
            };
        }

        public static Client ToDeleteClientDomain(this ClientCommandSignature signature)
        {
            return new Client
            {
                IdClient = signature.Id,
                BoActive = false
            };
        }

        public static Client ToUpdateClientDomain(this ClientCommandSignature signature)
        {
            return new Client
            {
                IdClient = signature.Id,
                DsClient = signature.Client,
                DsEmail = signature.Email,
                DsPhone = signature.Phone,
                IdCity = signature.City,
                DsFederalInscription = signature.FederalInscription,
                DtCreation = DateTime.Now
            };
        }
    }
}
