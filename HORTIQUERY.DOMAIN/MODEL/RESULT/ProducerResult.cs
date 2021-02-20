using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using System;

namespace HORTIQUERY.DOMAIN.MODEL.RESULT
{
    public sealed class ProducerResult : UserResult, IProducerResult
    {
        public Guid Id { get; set; }
        public string FantasyName { get; set; }
        public string FederalInscription { get; set; }
        public string Description { get; set; }
    }
}