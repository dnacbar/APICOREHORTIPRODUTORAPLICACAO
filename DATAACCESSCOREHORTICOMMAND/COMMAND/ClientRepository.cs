using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using DATACOREHORTICOMMAND;
using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.COMMAND
{
    public sealed class ClientRepository : _BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public async Task CreateClient(Client client)
        {
            await CreateEntity(client);
        }

        public async Task UpdateClient(Client client)
        {
            await UpdateEntity(client);
        }
    }
}