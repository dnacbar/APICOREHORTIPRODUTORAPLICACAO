using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using DOMAINCOREHORTICOMMAND;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SERVICECOREHORTICOMMAND.SERVICE
{
    public sealed class ClientDomainService : IClientDomainService
    {
        private readonly IClientRepository _clientRepository;

        public ClientDomainService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task ClientServiceCreate(Client client)
        {
            await _clientRepository.CreateClient(client);
        }

        public async Task ClientServiceDelete(Client client)
        {
            throw new NotImplementedException();
        }

        public async Task ClientServiceUpdate(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
