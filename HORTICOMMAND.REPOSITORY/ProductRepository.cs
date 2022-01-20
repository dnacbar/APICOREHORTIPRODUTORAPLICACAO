using HORTI.CORE.CROSSCUTTING.DBBASEEF;
using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.REPOSITORY
{
    public sealed class ProductRepository : _BaseEFCommandRepository<Product>, IProductRepository
    {
        public ProductRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public Task CreateProduct(Product product)
        {
            return CreateEntity(product);
        }

        public Task DeleteProduct(Product product)
        {
            return DeleteEntity(product);
        }

        public Task UpdateProduct(Product product)
        {
            return UpdateEntity(product);
        }
    }
}
