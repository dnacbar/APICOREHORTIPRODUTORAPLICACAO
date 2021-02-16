using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACES.SERVICE
{
    public interface IClientDomainService
    {
        Task ClientServiceCreate(Client client);
        Task ClientServiceUpdate(Client client);
    }
}
