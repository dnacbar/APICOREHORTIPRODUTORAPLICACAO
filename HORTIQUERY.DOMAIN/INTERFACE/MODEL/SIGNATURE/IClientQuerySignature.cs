using System;

namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface IClientQuerySignature : IBaseQuantitySignature
    {
        Guid? Id { get; set; }
        string Client { get; set; }
        string Email { get; set; }
    }
}
