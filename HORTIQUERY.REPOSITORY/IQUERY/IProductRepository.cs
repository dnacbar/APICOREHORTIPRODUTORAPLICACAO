using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERY
{
    public interface IProductRepository
    {
        Task<IEnumerable<IProduct>> FullListOfProducts();
        Task<IEnumerable<IProduct>> ListOfProducts(ConsultProductSignature signature);
        Task<IProduct> ProductById(ConsultProductSignature signature);
    }
}
