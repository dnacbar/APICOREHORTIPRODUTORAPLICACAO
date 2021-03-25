using HORTI.CORE.CROSSCUTTING.DBBASEEF;
using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.REPOSITORY
{
    public sealed class ClientRepository : _BaseEFCommandRepository<Client>, IClientRepository
    {
        public ClientRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public Task CreateClient(Client client)
        {
            return CreateEntity(client);
        }

        public Task UpdateClient(Client client)
        {
            return UpdateEntity(client);
        }
    }
}