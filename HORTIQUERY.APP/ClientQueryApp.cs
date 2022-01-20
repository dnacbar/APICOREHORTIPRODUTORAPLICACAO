using HORTIQUERY.DOMAIN.INTERFACE.APP;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIQUERY.DOMAIN.MODEL.EXTENSION;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.APP
{
    public sealed class ClientQueryApp : IClientQueryApp
    {
        private readonly IClientRepository _clientRepository;

        public ClientQueryApp(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IClientResult> GetClientByIdOrName(IClientQuerySignature signature)
        {
            return new ClientResult(await _clientRepository.ClientByIdOrName(signature));
        }

        public async Task<IEnumerable<IClientResult>> GetFullListOfClients()
        {
            return (await _clientRepository.FullListOfClients()).GetListOfClientResult();
        }

        public async Task<IEnumerable<IClientResult>> GetListOfClients(IClientQuerySignature signature)
        {
            return (await _clientRepository.ListOfClients(signature)).GetListOfClientResult();
        }
    }
}
