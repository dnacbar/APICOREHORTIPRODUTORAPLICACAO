using APPDTOCOREHORTICOMMAND.SIGNATURE;
using HORTICOMMAND.DOMAIN.MODEL;
using System;

namespace HORTICOMMAND.APP.CONVERTER
{
    public static class ProducerConverter
    {
        public static IProducer ToCreateProducerDomain(this IProducerCommandSignature signature)
        {
            return new IProducer
            {
                IdProducer = Guid.NewGuid(),
                DsEmail = signature.Email,
                DsProducer = signature.Producer
            };
        }

        public static IProducer ToUpdateProducerDomain(this IProducerCommandSignature signature)
        {
            return new IProducer
            {
                IdProducer = signature.Id.Value,
                DsProducer = signature.Producer,
                DsAddress = signature.Address,
                DsComplement = signature.Complement,
                DsDescription = signature.Description,
                DsEmail = signature.Email,
                DsFantasyname = signature.FantasyName,
                DsNumber = signature.Number,
                DsPhone = signature.Phone,
                IdCity = signature.City,
                IdDistrict = signature.District,
                DsZip = signature.Zip,
                DsFederalInscription = signature.FederalInscription,
                DsStateInscription = signature.StateInscription,
                DsMunicipalInscription = signature.MunicipalInscription,
                DtAtualization = DateTime.Now
            };
        }
    }
}
