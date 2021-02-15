using APPDTOCOREHORTICOMMAND.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System;

namespace APPCOREHORTICOMMAND.APP.CONVERTER
{
    public static class ProducerConverter
    {
        public static Producer ToCreateProducerDomain(this ProducerCommandSignature signature)
        {
            return new Producer
            {
                IdProducer = Guid.NewGuid(),
                DsEmail = signature.Email,
                DsProducer = signature.Producer
            };
        }

        public static Producer ToUpdateProducerDomain(this ProducerCommandSignature signature)
        {
            return new Producer
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
