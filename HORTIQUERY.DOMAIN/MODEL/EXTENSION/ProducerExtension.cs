using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;

namespace HORTIQUERY.DOMAIN.MODEL.EXTENSION
{
    public static class ProducerExtension
    {
        public static IProducerResult GetProducerResult(this Producer signature)
        {
            return new ProducerResult
            {
                Id = signature.IdProducer,
                Name = signature.DsProducer,
                FantasyName = signature.DsFantasyname,
                FederalInscription = signature.DsFederalInscription,
                Address = signature.DsAddress,
                Number = signature.DsNumber,
                Complement = signature.DsComplement,
                Email = signature.DsEmail,
                Phone = signature.DsPhone,
                IdCity = signature.IdCity,
                IdState = signature.IdCityNavigation.IdState,
                IdDistrict = signature.IdDistrict,
                Zip = signature.DsZip,
                Description = signature.DsDescription
            };
        }

        public static IEnumerable<IProducerResult> GetListOfProducerResult(this IEnumerable<Producer> signature)
        {
            var result = new List<IProducerResult>();
            foreach (var item in signature)
            {
                result.Add(new ProducerResult
                {
                    Id = item.IdProducer,
                    Name = item.DsProducer,
                    FantasyName = item.DsFantasyname,
                    FederalInscription = item.DsFederalInscription,
                    Address = item.DsAddress,
                    Number = item.DsNumber,
                    Complement = item.DsComplement,
                    Email = item.DsEmail,
                    Phone = item.DsPhone,
                    IdCity = item.IdCity,
                    IdState = item.IdCityNavigation.IdState,
                    IdDistrict = item.IdDistrict,
                    Zip = item.DsZip,
                    Description = item.DsDescription
                });
            }
            return result;
        }
    }
}
