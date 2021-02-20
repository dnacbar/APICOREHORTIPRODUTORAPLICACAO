using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> FullListOfProducts();
        Task<IEnumerable<Product>> ListOfProducts(IProductQuerySignature signature);
        Task<Product> ProductById(IProductQuerySignature signature);
    }
}
