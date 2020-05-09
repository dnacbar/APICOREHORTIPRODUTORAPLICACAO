using APPDTOCOREHORTIQUERY.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERY
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> FullListOfProducts();
        Task<IEnumerable<Product>> ListOfProducts(ConsultProductSignature signature);
        Task<Product> ProductById(ConsultProductSignature signature);
    }
}
