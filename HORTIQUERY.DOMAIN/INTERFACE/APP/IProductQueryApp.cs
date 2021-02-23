using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.APP
{
    public interface IProductQueryApp
    {
        Task<IProductResult> GetProductByIdOrName(IProductQuerySignature signature);
        Task<IEnumerable<IProductResult>> GetFullListOfProducts();
        Task<IEnumerable<IProductResult>> GetListOfProducts(IProductQuerySignature signature);

    }
}
