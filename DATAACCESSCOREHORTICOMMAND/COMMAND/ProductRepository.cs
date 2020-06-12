using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using DATACOREHORTICOMMAND;
using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.COMMAND
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
            await DeleteEntity(product, true);
        }

        public async Task UpdateProduct(Product product)
        {
            await UpdateEntity(product);
        }
    }
}
