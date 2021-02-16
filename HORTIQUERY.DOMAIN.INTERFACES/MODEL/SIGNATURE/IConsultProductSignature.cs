using System;

namespace HORTIQUERY.DOMAIN.INTERFACES.MODEL.SIGNATURE
{
    public interface IConsultProductSignature : IBaseQuantitySignature
    {
        string DsProduct { get; set; }
        Guid IdProduct { get; set; }
    }
}
