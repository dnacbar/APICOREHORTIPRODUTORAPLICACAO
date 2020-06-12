using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.ICOMMAND
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task DeleteProduct(Product product);
        Task UpdateProduct(Product product);
    }
}
