using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTICOMMAND.DOMAIN.MODEL.EXTENSION
{
    public static class ProducerExtension
    {
        public static Producer GetProducer(this IProducerCommandSignature signature)
        {
            return new Producer
            {
                IdProducer = signature.Id.GetValueOrDefault(),
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
