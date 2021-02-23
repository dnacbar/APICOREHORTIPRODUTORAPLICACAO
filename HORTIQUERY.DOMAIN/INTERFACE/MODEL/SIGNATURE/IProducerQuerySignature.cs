using System;

namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface IProducerQuerySignature : IBaseQuantitySignature
    {
        Guid? Id { get; set; }
        string Producer { get; set; }
        string Email { get; set; }
    }
}
