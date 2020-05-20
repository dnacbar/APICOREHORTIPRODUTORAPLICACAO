using APPCOREHORTIQUERY.CONVERTER;
using APPCOREHORTIQUERY.IAPP;
using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using DATACOREHORTIQUERY.IQUERIES;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.APP
{
    public sealed class ClientQueryApp : IClientQueryApp
    {
        private readonly IClientRepository _clientRepository;

        public ClientQueryApp(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<UserResult> GetClientByIdOrEmail(ConsultClientSignature signature)
        {
            return (await _clientRepository.ClientByIdOrEmail(signature)).ToClientResult();
        }

        public async Task<IEnumerable<ClientResult>> GetFullListOfClients()
        {
            return (await _clientRepository.FullListOfClients()).ToHashSetClientResult();
        }

        public async Task<IEnumerable<ClientResult>> GetListOfClients(ConsultClientSignature signature)
        {
            return (await _clientRepository.ListOfClients(signature)).ToHashSetClientResult();
        }
    }
}
