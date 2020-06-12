using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace SERVICECOREHORTICOMMAND.ISERVICE
{
    public interface IClientDomainService
    {
        Task ClientServiceCreate(Client client);
        Task ClientServiceDelete(Client client);
        Task ClientServiceUpdate(Client client);
    }
}
