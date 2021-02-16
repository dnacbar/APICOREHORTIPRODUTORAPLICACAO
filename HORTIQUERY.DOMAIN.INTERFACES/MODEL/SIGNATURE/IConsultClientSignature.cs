using System;

namespace HORTIQUERY.DOMAIN.INTERFACES.MODEL.SIGNATURE
{
    public interface IConsultClientSignature : IBaseQuantitySignature
    {
        string DsClient { get; set; }
        string DsEmail { get; set; }
        Guid? IdClient { get; set; }
    }
}
