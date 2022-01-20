using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;

namespace HORTIQUERY.DOMAIN.MODEL.EXTENSION
{
    public static class ProductExtension
    {
        public static IEnumerable<IProductResult> GetListOfProductResult(this IEnumerable<Product> signature)
        {
            var result = new List<IProductResult>();

            foreach (var item in signature)
                result.Add(new ProductResult(item));

            return result;
        }
    }
}
