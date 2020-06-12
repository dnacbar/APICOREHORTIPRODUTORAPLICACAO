using APPDTOCOREHORTICOMMAND.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System;

namespace APPCOREHORTICOMMAND.APP.CONVERTER
{
    public static class ProductConverter
    {
        public static Product ToCreateProductDomain(this ProductCommandSignature signature)
        {
            return new Product
            {
                IdProduct = Guid.NewGuid(),
                DsProduct = signature.Product,
                NmValue = signature.Value,
                DtDiscount = signature.DateDiscount,
                NmPercentDiscount = signature.Discount,
                IdUnit = signature.Unit,
                BoStock = signature.Stock,
                DtCreation = DateTime.Now
            };
        }

        public static Product ToDeleteProductDomain(this ProductCommandSignature signature)
        {
            return new Product
            {
                IdProduct = signature.Id,
                BoActive = false
            };
        }

        public static Product ToUpdateProductDomain(this ProductCommandSignature signature)
        {
            return new Product
            {
                IdProduct = signature.Id,
                DsProduct = signature.Product,
                NmValue = signature.Value,
                NmPercentDiscount = signature.Discount,
                DtDiscount = signature.DateDiscount,
                IdUnit = signature.Unit,
                BoStock = signature.Stock
            };
        }
    }
}
