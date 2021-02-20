using System;

namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface IUserQuerySignature
    {
        Guid Id { get; set; }
        bool IsProducer { get; set; }
    }
}