using System;

namespace HORTIQUERY.DOMAIN.MODEL.SIGNATURE
{
    public sealed class ConsultProducerSignature : _BaseQuantitySignature
    {
        public Guid IdProducer { get; set; }
        public string DsEmail { get; set; }
    }
}
