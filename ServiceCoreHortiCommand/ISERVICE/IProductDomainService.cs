using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace SERVICECOREHORTICOMMAND.ISERVICE
{
    public interface IProductDomainService
    {
        Task ProductServiceCreate(Product product);
        Task ProductServiceDelete(Product product);
        Task ProductServiceUpdate(Product product);
    }
}
