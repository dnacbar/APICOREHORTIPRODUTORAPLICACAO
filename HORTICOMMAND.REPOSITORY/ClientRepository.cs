using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.REPOSITORY
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