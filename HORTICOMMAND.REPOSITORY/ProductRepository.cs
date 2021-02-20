using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.REPOSITORY
{
    public sealed class ProductRepository : _BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public async Task CreateProduct(Product product)
        {
            await CreateEntity(product);
        }

        public async Task DeleteProduct(Product product)
        {
            await DeleteEntity(product);
        }

        public async Task UpdateProduct(Product product)
        {
            await UpdateEntity(product);
        }
    }
}
