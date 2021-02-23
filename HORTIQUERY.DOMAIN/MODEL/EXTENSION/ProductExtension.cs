using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;

namespace HORTIQUERY.DOMAIN.MODEL.EXTENSION
{
    public static class ProductExtension
    {
        public static IProductResult GetProductResult(this Product signature)
        {
            return new ProductResult
            {
                Id = signature.IdProduct,
                Product = signature.DsProduct,
                Value = signature.NmValue,
                Stock = signature.BoStock,
                Unit = signature.IdUnit,
                PercentDiscount = signature.NmPercentDiscount,
                DateDiscount = signature.DtDiscount,
                Description = signature.DsDescription
                
            };
        }

        public static IEnumerable<IProductResult> GetListOfProductResult(this IEnumerable<Product> signature)
        {
            var result = new List<IProductResult>();
            foreach (var item in signature)
            {
                result.Add(new ProductResult
                {
                    Id = item.IdProduct,
                    Product = item.DsProduct,
                    Value = item.NmValue,
                    Stock = item.BoStock,
                    Unit = item.IdUnit,
                    PercentDiscount = item.NmPercentDiscount,
                    DateDiscount = item.DtDiscount,
                    Description = item.DsDescription
                });
            }
            return result;
        }
    }
}
