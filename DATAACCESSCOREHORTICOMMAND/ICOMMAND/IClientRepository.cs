using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.ICOMMAND
{
    public interface IClientRepository
    {
        Task CreateClient(Client client);
        Task UpdateClient(Client client);
    }
}
