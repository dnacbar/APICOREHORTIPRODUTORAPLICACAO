using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using HORTICOMMAND.REPOSITORY;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.COMMAND
{
    public sealed class ProductRepository : _BaseRepository<IProduct>, IProductRepository
    {
        public ProductRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public async Task CreateProduct(IProduct product)
        {
            await CreateEntity(product);
        }

        public async Task DeleteProduct(IProduct product)
        {
            await DeleteEntity(product);
        }

        public async Task UpdateProduct(IProduct product)
        {
            await UpdateEntity(product);
        }
    }
}
