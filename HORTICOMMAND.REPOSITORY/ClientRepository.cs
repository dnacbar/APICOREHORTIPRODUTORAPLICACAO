using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using HORTICOMMAND.REPOSITORY;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.COMMAND
{
    public sealed class ClientRepository : _BaseRepository<IClient>, IClientRepository
    {
        public ClientRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public async Task CreateClient(IClient client)
        {
            await CreateEntity(client);
        }

        public async Task UpdateClient(IClient client)
        {
            await UpdateEntity(client);
        }
    }
}