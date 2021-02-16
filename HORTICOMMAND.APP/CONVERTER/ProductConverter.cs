using APPDTOCOREHORTICOMMAND.SIGNATURE;
using HORTICOMMAND.DOMAIN.MODEL;
using System;

namespace HORTICOMMAND.APP.CONVERTER
{
    public static class ProductConverter
    {
        public static IProduct ToCreateProductDomain(this IProductCommandSignature signature)
        {
            return new IProduct
            {
                IdProduct = Guid.NewGuid(),
                DsProduct = signature.Product,
                NmValue = signature.Value,
                DtDiscount = signature.DateDiscount,
                NmPercentDiscount = signature.Discount,
                IdUnit = signature.Unit,
                BoStock = signature.Stock
            };
        }

        public static IProduct ToDeleteProductDomain(this IProductCommandSignature signature)
        {
            return new IProduct { IdProduct = signature.Id.Value };
        }

        public static IProduct ToUpdateProductDomain(this IProductCommandSignature signature)
        {
            return new IProduct
            {
                IdProduct = signature.Id.Value,
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
