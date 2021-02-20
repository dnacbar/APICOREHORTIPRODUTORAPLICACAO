using HORTICOMMAND.DOMAIN.INTERFACE.MODEL;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IClientRepository
    {
        Task CreateClient(Client client);
        Task UpdateClient(Client client);
    }
}
