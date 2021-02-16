using System;

namespace HORTIQUERY.DOMAIN.INTERFACES.MODEL.SIGNATURE
{
    public interface IConsultUserSignature
    {
        Guid Id { get; set; }
        bool IsProducer { get; set; }
    }
}