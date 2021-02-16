using HORTICROSSCUTTINGCORE.EXTENSION;
using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using HORTICOMMAND.DOMAIN.MODEL;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System.Threading.Tasks;
using HORTICOMMAND.VALIDATION.DOMAIN;

namespace SERVICECOREHORTICOMMAND.SERVICE
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

        public async Task ClientServiceCreate(Client client)
        {
            _createClientDomainServiceValidation.ValidateHorti(client);

            await _clientRepository.CreateClient(client);
        }

        public async Task ClientServiceUpdate(Client client)
        {
            _updateClientDomainServiceValidation.ValidateHorti(client);

            await _clientRepository.UpdateClient(client);
        }
    }
}
