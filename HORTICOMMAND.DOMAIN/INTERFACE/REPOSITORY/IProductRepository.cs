using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task DeleteProduct(Product product);
        Task UpdateProduct(Product product);
    }
}
