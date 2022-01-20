using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IProductRepository
    {
        Task<List<Product>> FullListOfProducts();
        Task<List<Product>> ListOfProducts(IProductQuerySignature signature);
        Task<Product> ProductByIdOrName(IProductQuerySignature signature);
    }
}
