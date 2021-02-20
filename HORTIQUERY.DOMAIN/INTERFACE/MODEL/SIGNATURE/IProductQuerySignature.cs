using System;

namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface IProductQuerySignature : IBaseQuantitySignature
    {
        Guid? Id { get; set; }
        string Product { get; set; }
    }
}
