using APPDTOCOREHORTIQUERY.RESULT;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;

namespace APPCOREHORTIQUERY.CONVERTER
{
    public static class ProducerConverter
    {
        public static HashSet<ProducerResult> ToHashSetProducerResult(this IEnumerable<Producer> lstProducer)
        {
            var result = new HashSet<ProducerResult>();

            foreach (var item in lstProducer)
            {
                result.Add(new ProducerResult
                {
                    IdProducer = item.IdProducer,
                    DsFantasyName = item.DsFantasyname,
                    DsName = item.DsProducer,
                    IdState = item.IdCityNavigation.IdState,
                    IdCity = item.IdCity,
                    DsAddress = item.DsAddress,
                    DsEmail = item.DsEmail,
                    DsPhone = item.DsPhone,
                    DsComplement = item.DsComplement,
                    DsDescription = item.DsDescription,
                    IdDistrict = item.IdDistrict,
                    DsFederalInscription = item.DsFederalInscription,
                    DsZip = item.DsZip,
                    DsNumber = item.DsNumber
                });
            }

            return result;
        }

        public static ProducerResult ToProducerResult(this Producer producer)
        {
            return new ProducerResult
            {
                IdProducer = producer.IdProducer,
                DsFantasyName = producer.DsFantasyname,
                DsName = producer.DsProducer,
                IdState = producer.IdCityNavigation.IdState,
                IdCity = producer.IdCity,
                DsAddress = producer.DsAddress,
                DsEmail = producer.DsEmail,
                DsPhone = producer.DsPhone,
                DsComplement = producer.DsComplement,
                DsDescription = producer.DsDescription,
                IdDistrict = producer.IdDistrict,
                DsFederalInscription = producer.DsFederalInscription,
                DsZip = producer.DsZip,
                DsNumber = producer.DsNumber
            };
        }
    }
}
