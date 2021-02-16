using System;

namespace HORTIQUERY.DOMAIN.MODEL.SIGNATURE
{
    public class ConsultClientSignature : _BaseQuantitySignature
    {
        public string DsClient { get; set; }
        public string DsEmail { get; set; }
        public Guid? IdClient { get; set; }
    }
}
