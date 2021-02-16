using System;

namespace HORTIQUERY.DOMAIN.INTERFACES.MODEL.SIGNATURE
{
    public interface IConsultProducerSignature : IBaseQuantitySignature
    {
        Guid IdProducer { get; set; }
        string DsEmail { get; set; }
    }
}
