using HORTI.CORE.CROSSCUTTING.EXTENSION;
using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTICOMMAND.DOMAIN.MODEL;
using HORTICOMMAND.VALIDATION.DOMAIN;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.SERVICE
{
    public sealed class ClientDomainService : IClientDomainService
    {
        private readonly CreateClientDomainServiceValidation _createClientDomainServiceValidation;
        private readonly UpdateClientDomainServiceValidation _updateClientDomainServiceValidation;

        private readonly IClientRepository _clientRepository;

        public ClientDomainService(CreateClientDomainServiceValidation createClientDomainServiceValidation,
                                   UpdateClientDomainServiceValidation updateClientDomainServiceValidation, 
                                   IClientRepository clientRepository)
        {
            _createClientDomainServiceValidation = createClientDomainServiceValidation;
            _updateClientDomainServiceValidation = updateClientDomainServiceValidation;
            _clientRepository = clientRepository;
        }

        public Task ClientServiceCreate(Client client)
        {
            _createClientDomainServiceValidation.ValidateHorti(client);

            return _clientRepository.CreateClient(client);
        }

        public Task ClientServiceUpdate(Client client)
        {
            _updateClientDomainServiceValidation.ValidateHorti(client);

            return _clientRepository.UpdateClient(client);
        }
    }
}
