using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using System;

namespace HORTIQUERY.DOMAIN.MODEL.RESULT
{
    public sealed class ProducerResult : UserResult, IProducerResult
    {
        public ProducerResult(Producer producer)
        {
            Id = producer.IdProducer;
            Name = producer.DsProducer;
            FantasyName = producer.DsFantasyname;
            FederalInscription = producer.DsFederalInscription;
            Email = producer.DsEmail;
            IdState = producer.IdCityNavigation.IdState;
            IdCity = producer.IdCity;
            IdDistrict = producer.IdDistrict;
            Phone = producer.DsPhone;
            Address = producer.DsAddress;
            Number = producer.DsNumber;
            Complement = producer.DsComplement;
            Zip = producer.DsZip;
            Description = producer.DsDescription;
        }

        public Guid Id { get; set; }
        public string FantasyName { get; set; }
        public string FederalInscription { get; set; }
        public string Description { get; set; }
    }
}