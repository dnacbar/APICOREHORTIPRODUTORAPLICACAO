using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACE.SERVICE
{
    public interface IProductDomainService
    {
        Task ProductServiceCreate(Product product);
        Task ProductServiceDelete(Product product);
        Task ProductServiceUpdate(Product product);
    }
}
