using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.SERVICE
{
    public sealed class ClientDomainService : IClientDomainService
    {
        private readonly IClientRepository _clientRepository;

        public ClientDomainService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task ClientServiceCreate(Client client)
        {
            return _clientRepository.CreateClient(client);
        }

        public Task ClientServiceUpdate(Client client)
        {
            return _clientRepository.UpdateClient(client);
        }
    }
}
