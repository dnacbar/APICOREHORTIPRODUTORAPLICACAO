using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTIQUERY.DOMAIN.MODEL.SIGNATURE
{
    public sealed class ProducerQuerySignature : _BaseQuantitySignature, IProducerQuerySignature
    {
        public Guid? Id { get; set; }
        public string Producer { get; set; }
        public string Email { get; set; }
    }
}
