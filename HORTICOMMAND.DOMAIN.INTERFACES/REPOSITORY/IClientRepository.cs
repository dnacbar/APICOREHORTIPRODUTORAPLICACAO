using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACES.REPOSITORY
{
    public interface IClientRepository
    {
        Task CreateClient(Client client);
        Task UpdateClient(Client client);
    }
}
