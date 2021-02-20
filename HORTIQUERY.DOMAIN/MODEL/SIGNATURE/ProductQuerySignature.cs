using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTIQUERY.DOMAIN.MODEL.SIGNATURE
{
    public class ProductQuerySignature : _BaseQuantitySignature, IProductQuerySignature
    {
        public Guid? Id { get; set; }
        public string Product { get; set; }
    }
}
