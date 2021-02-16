using APPDTOCOREHORTICOMMAND.SIGNATURE;
using HORTICOMMAND.DOMAIN.MODEL;
using System;

namespace HORTICOMMAND.APP.CONVERTER
{
    public static class ClientConverter
    {
        public static IClient ToCreateClientDomain(this ClientCommandSignature signature)
        {
            return new IClient
            {
                IdClient = Guid.NewGuid(),
                DsEmail = signature.Email,
                DsClient = signature.Client,
                DsPhone = signature.Phone
            };
        }

        public static IClient ToUpdateClientDomain(this ClientCommandSignature signature)
        {
            return new IClient
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
