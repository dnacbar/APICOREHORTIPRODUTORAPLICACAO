using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACE.SERVICE
{
    public interface IClientDomainService
    {
        Task ClientServiceCreate(Client client);
        Task ClientServiceUpdate(Client client);
    }
}
