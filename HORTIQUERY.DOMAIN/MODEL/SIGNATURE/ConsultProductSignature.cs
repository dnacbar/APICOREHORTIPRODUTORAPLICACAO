using System;

namespace HORTIQUERY.DOMAIN.MODEL.SIGNATURE
{
    public class ConsultProductSignature : _BaseQuantitySignature
    {
        public string DsProduct { get; set; }
        public Guid IdProduct { get; set; }
    }
}
