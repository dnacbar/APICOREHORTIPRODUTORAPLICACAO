using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACES.SERVICE
{
    public interface IProductDomainService
    {
        Task ProductServiceCreate(Product product);
        Task ProductServiceDelete(Product product);
        Task ProductServiceUpdate(Product product);
    }
}
