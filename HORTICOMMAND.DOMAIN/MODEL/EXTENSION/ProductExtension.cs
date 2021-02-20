using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTICOMMAND.DOMAIN.MODEL.EXTENSION
{
    public static class ProductExtension
    {
        public static Product GetProduct(this IProductCommandSignature signature)
        {
            return new Product
            {
                IdProduct = signature.Id.GetValueOrDefault(),
                DsProduct = signature.Product,
                NmValue = signature.Value,
                NmPercentDiscount = signature.Discount,
                DtDiscount = signature.DateDiscount,
                IdUnit = signature.Unit,
                BoStock = signature.Stock,
                DtAtualization = DateTime.Now
            };
        }
    }
}
