using APPDTOCOREHORTIQUERY.RESULT;
using DOMAINCOREHORTICOMMAND;

namespace APPCOREHORTIQUERY.CONVERTERS
{
    public static class ProducerConverter
    {
        public static UserProducerInformationResult ToUserProducerInformationResult(this Producer producer)
        {
            return new UserProducerInformationResult
            {
                IdProducer = producer.IdProducer,
                DsFantasyName = producer.DsFantasyname,
                DsName = producer.DsProducer,
                DsState = producer.IdCityNavigation.Id.DsState,
                DsCity = producer.IdCityNavigation.DsCity,
                DsAddress = producer.DsAddress,
                DsEmail = producer.DsEmail,
                DsPhone = producer.DsPhone,
                DsComplement = producer.DsComplement,
                DsDescription = producer.DsDescription,
                DsDistrict = producer.IdDistrictNavigation.DsDistrict,
                DsFederalInscription = producer.DsFederalinscription,
                DsZip = producer.DsZip,
                DsNumber = producer.DsNumber
            };
        }
    }
}
